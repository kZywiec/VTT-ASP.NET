using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VTT.Data;
using VTT.Models.Entities;
using VTT.Services.Characters;

namespace VTT.Controllers
{
    public class ItemsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ICharacterService _characterService;

        public ItemsController(AppDbContext context, ICharacterService characterService)
        {
            _context = context;
            _characterService = characterService;
        }

        public async Task<IActionResult> StartUp(int character_id)
        {
            await _characterService.SetCurrentCharacterById(character_id);
            return RedirectToAction(nameof(Index));
        }

        // GET: Items
        public async Task<IActionResult> Index()
        {
            var character_id = _characterService.CurrentCharacter.id;
            var characterItemIds = await _context.Character_Item.Where(ci => ci.character_id == character_id).Select(ci => ci.item_id).ToListAsync();
            var items = await _context.Item.Where(i => characterItemIds.Contains(i.id)).ToListAsync();
            ViewData["CharacterName"] = _characterService.CurrentCharacter.name;
            ViewData["Character_Id"] = _characterService.CurrentCharacter.id;
            return View(items);
        }

        // GET: Items/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Item == null)
            {
                return NotFound();
            }

            var item = await _context.Item
                .Include(i => i.availability)
                .Include(i => i.concealment)
                .Include(i => i.type)
                .FirstOrDefaultAsync(m => m.id == id);
            if (item == null)
            {
                return NotFound();
            }
            
            
            
            return View(item);
        }

        // GET: Items/Create
        public IActionResult Create()
        {
            
            ViewData["availability_id"] = new SelectList(_context.Item_Availabilitie, "id", "name");
            ViewData["concealment_id"] = new SelectList(_context.Item_Concealment, "id", "name");
            ViewData["type_id"] = new SelectList(_context.Item_Type, "id", "name");
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("name,type_id,quantity,weight,cost,availability_id,concealment_id,description,id,CreationDate")] Item item)
        {

            Character_Item ci = new ()
            {
                character_id = _characterService.CurrentCharacter.id,
                item_id = item.id
            };

            if (ModelState.IsValid)
            {
                _context.Add(item);
                await _context.SaveChangesAsync();
                ci.item_id = item.id;
                _context.Character_Item.Add(ci);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            
            ViewData["availability_id"] = new SelectList(_context.Item_Availabilitie, "id", "name", item.availability_id);
            ViewData["concealment_id"] = new SelectList(_context.Item_Concealment, "id", "name", item.concealment_id);
            ViewData["type_id"] = new SelectList(_context.Item_Type, "id", "name", item.type_id);
            return View(item);
        }

        // GET: Items/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Item == null)
            {
                return NotFound();
            }

            var item = await _context.Item.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            
            ViewData["availability_id"] = new SelectList(_context.Item_Availabilitie, "id", "name", item.availability_id);
            ViewData["concealment_id"] = new SelectList(_context.Item_Concealment, "id", "name", item.concealment_id);
            ViewData["type_id"] = new SelectList(_context.Item_Type, "id", "name", item.type_id);
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("name,type_id,quantity,weight,cost,availability_id,concealment_id,description,id,CreationDate")] Item item)
        {
            if (id != item.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.id))
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
            
            ViewData["availability_id"] = new SelectList(_context.Item_Availabilitie, "id", "name", item.availability_id);
            ViewData["concealment_id"] = new SelectList(_context.Item_Concealment, "id", "name", item.concealment_id);
            ViewData["type_id"] = new SelectList(_context.Item_Type, "id", "name", item.type_id);
            return View(item);
        }

        // GET: Items/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Item == null)
            {
                return NotFound();
            }

            var item = await _context.Item
                .Include(i => i.availability)
                .Include(i => i.concealment)
                .Include(i => i.type)
                .FirstOrDefaultAsync(m => m.id == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Item == null)
            {
                return Problem("Entity set 'AppDbContext.Item'  is null.");
            }
            var item = await _context.Item.FindAsync(id);
            if (item != null)
            {
                _context.Item.Remove(item);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemExists(int id)
        {
          return _context.Item.Any(e => e.id == id);
        }
    }
}
