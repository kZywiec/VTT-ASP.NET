using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VTT.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VTT.Data;
using VTT.Models.Entities;

namespace VTT.Controllers
{
    public class WorldsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IUserService _userService;
        public WorldsController(AppDbContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        // GET: Worlds
        public async Task<IActionResult> Index()
        {
              return View(await _context.World.ToListAsync());
        }

        // GET: Worlds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.World == null)
            {
                return NotFound();
            }

            var world = await _context.World
                .FirstOrDefaultAsync(m => m.id == id);
            if (world == null)
            {
                return NotFound();
            }

            return View(world);
        }

        // GET: Worlds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Worlds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("title,description,nextSessionDate,id,CreationDate")] World world)
        {
            User_World uw = new User_World()
            {
                user_id = _userService.LoggedUser.id,
                world_id = world.id,
                User = _userService.LoggedUser,
                World = world
            };

            world.Users_Worlds.Add(uw);
            _userService.LoggedUser.Users_Worlds_Characters.Add(uw);

            if (ModelState.IsValid)
            {
                _context.User_World.Add(uw);
                _context.World.Add(world);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(world);
        }

        // GET: Worlds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.World == null)
            {
                return NotFound();
            }

            var world = await _context.World.FindAsync(id);
            if (world == null)
            {
                return NotFound();
            }
            return View(world);
        }

        // POST: Worlds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("title,description,nextSessionDate,id,CreationDate")] World world)
        {
            if (id != world.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(world);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorldExists(world.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(world);
        }

        // GET: Worlds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.World == null)
            {
                return NotFound();
            }

            var world = await _context.World
                .FirstOrDefaultAsync(m => m.id == id);
            if (world == null)
            {
                return NotFound();
            }

            return View(world);
        }

        // POST: Worlds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.World == null)
            {
                return Problem("Entity set 'AppDbContext.World'  is null.");
            }
            var world = await _context.World.FindAsync(id);
            if (world != null)
            {
                _context.World.Remove(world);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorldExists(int id)
        {
          return _context.World.Any(e => e.id == id);
        }
    }
}
