using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using tiyatroff.Models;

namespace tiyatroff.Controllers
{
    [Authorize]
    public class BiletlersController : Controller
    {
        private readonly DbTiyatroContext _context;

        public BiletlersController(DbTiyatroContext context)
        {
            _context = context;
        }

        // GET: Biletlers
        public async Task<IActionResult> Index()
        {
            var dbTiyatroContext = _context.Biletlers
                .Include(b => b.Gosterim)
                .ThenInclude(g => g.Oyun); // 'Oyun' tablosunu da dahil et

            return View(await dbTiyatroContext.ToListAsync());
        }

        // GET: Biletlers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Biletlers == null)
            {
                return NotFound();
            }

            var biletler = await _context.Biletlers
                .Include(b => b.Gosterim)
                .FirstOrDefaultAsync(m => m.BiletId == id);
            if (biletler == null)
            {
                return NotFound();
            }

            return View(biletler);
        }

        // GET: Biletlers/Create
        public IActionResult Create()
        {
            ViewData["GosterimId"] = new SelectList(_context.Gosterims, "GosterimId", "GosterimId");
            return View();
        }

        // POST: Biletlers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BiletId,GosterimId,Satistarih,Fiyat")] Biletler biletler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(biletler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GosterimId"] = new SelectList(_context.Gosterims, "GosterimId", "GosterimId", biletler.GosterimId);
            return View(biletler);
        }

        // GET: Biletlers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Biletlers == null)
            {
                return NotFound();
            }

            var biletler = await _context.Biletlers.FindAsync(id);
            if (biletler == null)
            {
                return NotFound();
            }
            ViewData["GosterimId"] = new SelectList(_context.Gosterims, "GosterimId", "GosterimId", biletler.GosterimId);
            return View(biletler);
        }

        // POST: Biletlers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BiletId,GosterimId,Satistarih,Fiyat")] Biletler biletler)
        {
            if (id != biletler.BiletId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(biletler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BiletlerExists(biletler.BiletId))
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
            ViewData["GosterimId"] = new SelectList(_context.Gosterims, "GosterimId", "GosterimId", biletler.GosterimId);
            return View(biletler);
        }

        // GET: Biletlers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Biletlers == null)
            {
                return NotFound();
            }

            var biletler = await _context.Biletlers
                .Include(b => b.Gosterim)
                .FirstOrDefaultAsync(m => m.BiletId == id);
            if (biletler == null)
            {
                return NotFound();
            }

            return View(biletler);
        }

        // POST: Biletlers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Biletlers == null)
            {
                return Problem("Entity set 'DbTiyatroContext.Biletlers'  is null.");
            }
            var biletler = await _context.Biletlers.FindAsync(id);
            if (biletler != null)
            {
                _context.Biletlers.Remove(biletler);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BiletlerExists(int id)
        {
          return (_context.Biletlers?.Any(e => e.BiletId == id)).GetValueOrDefault();
        }
    }
}
