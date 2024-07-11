using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using tiyatroff.Models;

namespace tiyatroff.Controllers
{
    public class SalonlarsController : Controller
    {
        private readonly DbTiyatroContext _context;

        public SalonlarsController(DbTiyatroContext context)
        {
            _context = context;
        }

        // GET: Salonlars
        public async Task<IActionResult> Index()
        {
            var dbTiyatroContext = _context.Salonlars.Include(s => s.Ilce);
            return View(await dbTiyatroContext.ToListAsync());
        }

        // GET: Salonlars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Salonlars == null)
            {
                return NotFound();
            }

            var salonlar = await _context.Salonlars
                .Include(s => s.Ilce)
                .FirstOrDefaultAsync(m => m.SalonId == id);
            if (salonlar == null)
            {
                return NotFound();
            }

            return View(salonlar);
        }

        // GET: Salonlars/Create
        public IActionResult Create()
        {
            ViewData["IlceId"] = new SelectList(_context.Ilcelers, "IlceId", "IlceId");
            return View();
        }

        // POST: Salonlars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SalonId,SalonAd,IlceId,SalonAdres,SalonNo")] Salonlar salonlar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salonlar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IlceId"] = new SelectList(_context.Ilcelers, "IlceId", "IlceId", salonlar.IlceId);
            return View(salonlar);
        }

        // GET: Salonlars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Salonlars == null)
            {
                return NotFound();
            }

            var salonlar = await _context.Salonlars.FindAsync(id);
            if (salonlar == null)
            {
                return NotFound();
            }
            ViewData["IlceId"] = new SelectList(_context.Ilcelers, "IlceId", "IlceId", salonlar.IlceId);
            return View(salonlar);
        }

        // POST: Salonlars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SalonId,SalonAd,IlceId,SalonAdres,SalonNo")] Salonlar salonlar)
        {
            if (id != salonlar.SalonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salonlar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalonlarExists(salonlar.SalonId))
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
            ViewData["IlceId"] = new SelectList(_context.Ilcelers, "IlceId", "IlceId", salonlar.IlceId);
            return View(salonlar);
        }

        // GET: Salonlars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Salonlars == null)
            {
                return NotFound();
            }

            var salonlar = await _context.Salonlars
                .Include(s => s.Ilce)
                .FirstOrDefaultAsync(m => m.SalonId == id);
            if (salonlar == null)
            {
                return NotFound();
            }

            return View(salonlar);
        }

        // POST: Salonlars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Salonlars == null)
            {
                return Problem("Entity set 'DbTiyatroContext.Salonlars'  is null.");
            }
            var salonlar = await _context.Salonlars.FindAsync(id);
            if (salonlar != null)
            {
                _context.Salonlars.Remove(salonlar);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalonlarExists(int id)
        {
          return (_context.Salonlars?.Any(e => e.SalonId == id)).GetValueOrDefault();
        }
    }
}
