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
    public class Item_ConcealmentController : Controller
    {
        private readonly AppDbContext _context;

        public Item_ConcealmentController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Item_Concealmen
        public async Task<IActionResult> Index()
        {
              return View(await _context.Item_Concealment.ToListAsync());
        }

        // GET: Item_Concealmen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Item_Concealment == null)
            {
                return NotFound();
            }

            var item_Concealmen = await _context.Item_Concealment
                .FirstOrDefaultAsync(m => m.id == id);
            if (item_Concealmen == null)
            {
                return NotFound();
            }

            return View(item_Concealmen);
        }

        // GET: Item_Concealmen/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Item_Concealmen/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("name,id,CreationDate")] Item_Concealment item_Concealmen)
        {
            if (ModelState.IsValid)
            {
                _context.Add(item_Concealmen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(item_Concealmen);
        }

        // GET: Item_Concealmen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Item_Concealment == null)
            {
                return NotFound();
            }

            var item_Concealmen = await _context.Item_Concealment.FindAsync(id);
            if (item_Concealmen == null)
            {
                return NotFound();
            }
            return View(item_Concealmen);
        }

        // POST: Item_Concealmen/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("name,id,CreationDate")] Item_Concealment item_Concealmen)
        {
            if (id != item_Concealmen.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(item_Concealmen);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Item_ConcealmenExists(item_Concealmen.id))
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
            return View(item_Concealmen);
        }

        // GET: Item_Concealmen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Item_Concealment == null)
            {
                return NotFound();
            }

            var item_Concealmen = await _context.Item_Concealment
                .FirstOrDefaultAsync(m => m.id == id);
            if (item_Concealmen == null)
            {
                return NotFound();
            }

            return View(item_Concealmen);
        }

        // POST: Item_Concealmen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Item_Concealment == null)
            {
                return Problem("Entity set 'AppDbContext.Item_Concealmen'  is null.");
            }
            var item_Concealmen = await _context.Item_Concealment.FindAsync(id);
            if (item_Concealmen != null)
            {
                _context.Item_Concealment.Remove(item_Concealmen);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Item_ConcealmenExists(int id)
        {
          return _context.Item_Concealment.Any(e => e.id == id);
        }
    }
}
