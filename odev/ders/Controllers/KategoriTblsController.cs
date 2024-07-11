using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ders.Models;

namespace ders.Controllers
{
    public class KategoriTblsController : Controller
    {
        private readonly DbUruntakipContext _context;

        public KategoriTblsController(DbUruntakipContext context)
        {
            _context = context;
        }

        // GET: KategoriTbls
        public async Task<IActionResult> Index()
        {
              return _context.KategoriTbls != null ? 
                          View(await _context.KategoriTbls.ToListAsync()) :
                          Problem("Entity set 'DbUruntakipContext.KategoriTbls'  is null.");
        }

        // GET: KategoriTbls/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.KategoriTbls == null)
            {
                return NotFound();
            }

            var kategoriTbl = await _context.KategoriTbls
                .FirstOrDefaultAsync(m => m.KategoriId == id);
            if (kategoriTbl == null)
            {
                return NotFound();
            }

            return View(kategoriTbl);
        }

        // GET: KategoriTbls/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KategoriTbls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KategoriId,KategoriAd")] KategoriTbl kategoriTbl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kategoriTbl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kategoriTbl);
        }

        // GET: KategoriTbls/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.KategoriTbls == null)
            {
                return NotFound();
            }

            var kategoriTbl = await _context.KategoriTbls.FindAsync(id);
            if (kategoriTbl == null)
            {
                return NotFound();
            }
            return View(kategoriTbl);
        }

        // POST: KategoriTbls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KategoriId,KategoriAd")] KategoriTbl kategoriTbl)
        {
            if (id != kategoriTbl.KategoriId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kategoriTbl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KategoriTblExists(kategoriTbl.KategoriId))
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
            return View(kategoriTbl);
        }

        // GET: KategoriTbls/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.KategoriTbls == null)
            {
                return NotFound();
            }

            var kategoriTbl = await _context.KategoriTbls
                .FirstOrDefaultAsync(m => m.KategoriId == id);
            if (kategoriTbl == null)
            {
                return NotFound();
            }

            return View(kategoriTbl);
        }

        // POST: KategoriTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.KategoriTbls == null)
            {
                return Problem("Entity set 'DbUruntakipContext.KategoriTbls'  is null.");
            }
            var kategoriTbl = await _context.KategoriTbls.FindAsync(id);
            if (kategoriTbl != null)
            {
                _context.KategoriTbls.Remove(kategoriTbl);
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                ViewBag.messageString = kategoriTbl.KategoriAd.ToString() +
                " Kategorisinde Ürün Girişi Mevcuttur.Kategori Silinemez ";
                return View("Information");
            }
            return RedirectToAction(nameof(Index));
        }

        private bool KategoriTblExists(int id)
        {
          return (_context.KategoriTbls?.Any(e => e.KategoriId == id)).GetValueOrDefault();
        }
    }
}
