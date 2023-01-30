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
    public class Item_TypeController : Controller
    {
        private readonly AppDbContext _context;

        public Item_TypeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Item_Type
        public async Task<IActionResult> Index()
        {
              return View(await _context.Item_Type.ToListAsync());
        }

        // GET: Item_Type/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Item_Type == null)
            {
                return NotFound();
            }

            var item_Type = await _context.Item_Type
                .FirstOrDefaultAsync(m => m.id == id);
            if (item_Type == null)
            {
                return NotFound();
            }

            return View(item_Type);
        }

        // GET: Item_Type/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Item_Type/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("name,id,CreationDate")] Item_Type item_Type)
        {
            if (ModelState.IsValid)
            {
                _context.Add(item_Type);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(item_Type);
        }

        // GET: Item_Type/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Item_Type == null)
            {
                return NotFound();
            }

            var item_Type = await _context.Item_Type.FindAsync(id);
            if (item_Type == null)
            {
                return NotFound();
            }
            return View(item_Type);
        }

        // POST: Item_Type/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("name,id,CreationDate")] Item_Type item_Type)
        {
            if (id != item_Type.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(item_Type);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Item_TypeExists(item_Type.id))
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
            return View(item_Type);
        }

        // GET: Item_Type/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Item_Type == null)
            {
                return NotFound();
            }

            var item_Type = await _context.Item_Type
                .FirstOrDefaultAsync(m => m.id == id);
            if (item_Type == null)
            {
                return NotFound();
            }

            return View(item_Type);
        }

        // POST: Item_Type/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Item_Type == null)
            {
                return Problem("Entity set 'AppDbContext.Item_Type'  is null.");
            }
            var item_Type = await _context.Item_Type.FindAsync(id);
            if (item_Type != null)
            {
                _context.Item_Type.Remove(item_Type);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Item_TypeExists(int id)
        {
          return _context.Item_Type.Any(e => e.id == id);
        }
    }
}
