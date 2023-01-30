using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using VTT.Data;
using VTT.Models.Entities;
using VTT.Services.Characters;
using VTT.Services.Users;

namespace VTT.Controllers
{
    public class CharactersController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IUserService _userService;
        private readonly IWorldService _worldService;

        public CharactersController(AppDbContext context, IUserService userService, IWorldService worldService)
        {
            _context = context;
            _userService = userService;
            _worldService = worldService;
        }

        // GET: Characters
        public async Task<IActionResult> Index()
        {
            ViewData["WorldsList"] = await _context.World.ToListAsync();
            return View(await _context.Character.ToListAsync());
        }

        // GET: Characters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Character == null)
            {
                return NotFound();
            }

            var character = await _context.Character
                .FirstOrDefaultAsync(m => m.id == id);
            if (character == null)
            {
                return NotFound();
            }

            return View(character);
        }

        // GET: Characters/Create
        public async Task<IActionResult> Create(int worldId)
        {
            await _worldService.SetCurrentWorldById(worldId);
            return View();
        }

        // POST: Characters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Character character)
        {

            var user_world = await _context.User_World.FirstOrDefaultAsync(
                uw => uw.user_id == _userService.LoggedUser.id && uw.world_id == _worldService.CurrentWorld.id);

            character.Users_Worlds_id = user_world.id;
            character.Users_Worlds = user_world;
            user_world.Characters.Add(character);
            character.CalculateStats();
            if (ModelState.IsValid)
            {
                _context.User_World.Update(user_world);
                _context.Character.Add(character);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(character);
        }

        // GET: Characters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Character == null)
            {
                return NotFound();
            }

            var character = await _context.Character.FindAsync(id);
            if (character == null)
            {
                return NotFound();
            }
            return View(character);
        }

        // POST: Characters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Character character)
        {
            if (id != character.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var characterToUpdate = _context.Character.FirstOrDefault(x => x.id == character.id);
                    if (characterToUpdate == null)
                    {
                        return NotFound();
                    }

                    characterToUpdate.name = character.name;
                    characterToUpdate.sex = character.sex;
                    characterToUpdate.age = character.age;
                    characterToUpdate.race = character.race;
                    characterToUpdate.social_standing = character.social_standing;
                    characterToUpdate.homeland = character.homeland;
                    characterToUpdate.intelligence = character.intelligence;
                    characterToUpdate.reflex = character.reflex;
                    characterToUpdate.dexterity = character.dexterity;
                    characterToUpdate.body = character.body;
                    characterToUpdate.speed = character.speed;
                    characterToUpdate.empathy = character.empathy;
                    characterToUpdate.craft = character.craft;
                    characterToUpdate.will = character.will;
                    characterToUpdate.luck = character.luck;

                    characterToUpdate.CalculateStats();

                    await _context.SaveChangesAsync();
                }
                
                catch (DbUpdateConcurrencyException)
                {
                    if (!CharacterExists(character.id))
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
            return View(character);
        }

        // GET: Characters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Character == null)
            {
                return NotFound();
            }

            var character = await _context.Character
                .FirstOrDefaultAsync(m => m.id == id);
            if (character == null)
            {
                return NotFound();
            }

            return View(character);
        }

        // POST: Characters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Character == null)
            {
                return Problem("Entity set 'AppDbContext.Character'  is null.");
            }
            var character = await _context.Character.FindAsync(id);
            if (character != null)
            {
                _context.Character.Remove(character);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CharacterExists(int id)
        {
          return _context.Character.Any(e => e.id == id);
        }
    }
}
