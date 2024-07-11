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
    public class IlcelersController : Controller
    {
        private readonly DbTiyatroContext _context;

        public IlcelersController(DbTiyatroContext context)
        {
            _context = context;
        }

        // GET: Ilcelers
        public async Task<IActionResult> Index()
        {
              return _context.Ilcelers != null ? 
                          View(await _context.Ilcelers.ToListAsync()) :
                          Problem("Entity set 'DbTiyatroContext.Ilcelers'  is null.");
        }

        // GET: Ilcelers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ilcelers == null)
            {
                return NotFound();
            }

            var ilceler = await _context.Ilcelers
                .FirstOrDefaultAsync(m => m.IlceId == id);
            if (ilceler == null)
            {
                return NotFound();
            }

            return View(ilceler);
        }

        // GET: Ilcelers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ilcelers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IlceId,IlceAd")] Ilceler ilceler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ilceler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ilceler);
        }

        // GET: Ilcelers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ilcelers == null)
            {
                return NotFound();
            }

            var ilceler = await _context.Ilcelers.FindAsync(id);
            if (ilceler == null)
            {
                return NotFound();
            }
            return View(ilceler);
        }

        // POST: Ilcelers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IlceId,IlceAd")] Ilceler ilceler)
        {
            if (id != ilceler.IlceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ilceler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IlcelerExists(ilceler.IlceId))
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
            return View(ilceler);
        }

        // GET: Ilcelers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ilcelers == null)
            {
                return NotFound();
            }

            var ilceler = await _context.Ilcelers
                .FirstOrDefaultAsync(m => m.IlceId == id);
            if (ilceler == null)
            {
                return NotFound();
            }

            return View(ilceler);
        }

        // POST: Ilcelers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ilcelers == null)
            {
                return Problem("Entity set 'DbTiyatroContext.Ilcelers'  is null.");
            }
            var ilceler = await _context.Ilcelers.FindAsync(id);
            if (ilceler != null)
            {
                _context.Ilcelers.Remove(ilceler);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IlcelerExists(int id)
        {
          return (_context.Ilcelers?.Any(e => e.IlceId == id)).GetValueOrDefault();
        }
    }
}
