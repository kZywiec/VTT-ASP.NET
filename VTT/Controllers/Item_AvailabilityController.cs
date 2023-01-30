using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VTT.Data;
using VTT.Models.Entities;

namespace VTT.Controllers
{
    public class Item_AvailabilityController : Controller
    {
        private readonly AppDbContext _context;

        public Item_AvailabilityController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Item_Availability
        public async Task<IActionResult> Index()
        {
              return View(await _context.Item_Availabilitie.ToListAsync());
        }

        // GET: Item_Availability/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Item_Availabilitie == null)
            {
                return NotFound();
            }

            var item_Availability = await _context.Item_Availabilitie
                .FirstOrDefaultAsync(m => m.id == id);
            if (item_Availability == null)
            {
                return NotFound();
            }

            return View(item_Availability);
        }

        // GET: Item_Availability/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Item_Availability/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("name,id,CreationDate")] Item_Availability item_Availability)
        {
            if (ModelState.IsValid)
            {
                _context.Add(item_Availability);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(item_Availability);
        }

        // GET: Item_Availability/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Item_Availabilitie == null)
            {
                return NotFound();
            }

            var item_Availability = await _context.Item_Availabilitie.FindAsync(id);
            if (item_Availability == null)
            {
                return NotFound();
            }
            return View(item_Availability);
        }

        // POST: Item_Availability/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("name,id,CreationDate")] Item_Availability item_Availability)
        {
            if (id != item_Availability.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(item_Availability);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Item_AvailabilityExists(item_Availability.id))
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
            return View(item_Availability);
        }

        // GET: Item_Availability/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Item_Availabilitie == null)
            {
                return NotFound();
            }

            var item_Availability = await _context.Item_Availabilitie
                .FirstOrDefaultAsync(m => m.id == id);
            if (item_Availability == null)
            {
                return NotFound();
            }

            return View(item_Availability);
        }

        // POST: Item_Availability/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Item_Availabilitie == null)
            {
                return Problem("Entity set 'AppDbContext.Item_Availabilitie'  is null.");
            }
            var item_Availability = await _context.Item_Availabilitie.FindAsync(id);
            if (item_Availability != null)
            {
                _context.Item_Availabilitie.Remove(item_Availability);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Item_AvailabilityExists(int id)
        {
          return _context.Item_Availabilitie.Any(e => e.id == id);
        }
    }
}
