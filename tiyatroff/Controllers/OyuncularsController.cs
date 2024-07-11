using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using tiyatroff.Models;

namespace tiyatroff.Controllers
{
    [Authorize]
    public class OyuncularsController : Controller
    {
        private readonly DbTiyatroContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public OyuncularsController(DbTiyatroContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: Oyunculars
        public async Task<IActionResult> Index()
        {
              return _context.Oyunculars != null ? 
                          View(await _context.Oyunculars.ToListAsync()) :
                          Problem("Entity set 'DbTiyatroContext.Oyunculars'  is null.");
        }

        // GET: Oyunculars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Oyunculars == null)
            {
                return NotFound();
            }

            var oyuncular = await _context.Oyunculars
                .FirstOrDefaultAsync(m => m.OyuncuId == id);
            if (oyuncular == null)
            {
                return NotFound();
            }

            return View(oyuncular);
        }

        // GET: Oyunculars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Oyunculars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OyuncuId,OyuncuAd,OyuncuFoto,ImageFile,Universite,TelNo")] Oyuncular oyuncular)
        {
            if (ModelState.IsValid)
            {
                string wwwrootpath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(oyuncular.ImageFile.FileName);
                string extension = Path.GetExtension(oyuncular.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                oyuncular.OyuncuFoto = "/Contents/" + fileName;
                string path = Path.Combine(wwwrootpath + "/Contents", fileName);
                using (var filestream = new FileStream(path, FileMode.Create))
                {
                    await oyuncular.ImageFile.CopyToAsync(filestream);
                }
                _context.Add(oyuncular);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(oyuncular);
        }

        // GET: Oyunculars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Oyunculars == null)
            {
                return NotFound();
            }

            var oyuncular = await _context.Oyunculars.FindAsync(id);
            if (oyuncular == null)
            {
                return NotFound();
            }
            return View(oyuncular);
        }

        // POST: Oyunculars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OyuncuId,OyuncuAd,OyuncuFoto,ImageFile,Universite,TelNo")] Oyuncular oyuncular)
        {
            if (id != oyuncular.OyuncuId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (oyuncular.ImageFile != null)
                {
                    string wwwrootpath = _hostEnvironment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(oyuncular.ImageFile.FileName);
                    string extension = Path.GetExtension(oyuncular.ImageFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    oyuncular.OyuncuFoto = "/Contents/" + fileName;
                    string path = Path.Combine(wwwrootpath, "Contents", fileName);
                    using (var filestream = new FileStream(path, FileMode.Create))
                    {
                        await oyuncular.ImageFile.CopyToAsync(filestream);
                    }

                }
                try
                {
                    _context.Update(oyuncular);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OyuncularExists(oyuncular.OyuncuId))
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
            return View(oyuncular);
        }

        // GET: Oyunculars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Oyunculars == null)
            {
                return NotFound();
            }

            var oyuncular = await _context.Oyunculars
                .FirstOrDefaultAsync(m => m.OyuncuId == id);
            if (oyuncular == null)
            {
                return NotFound();
            }

            return View(oyuncular);
        }

        // POST: Oyunculars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Oyunculars == null)
            {
                return Problem("Entity set 'DbTiyatroContext.Oyunculars'  is null.");
            }
            var oyuncular = await _context.Oyunculars.FindAsync(id);
            if (oyuncular != null)
            {
                _context.Oyunculars.Remove(oyuncular);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OyuncularExists(int id)
        {
          return (_context.Oyunculars?.Any(e => e.OyuncuId == id)).GetValueOrDefault();
        }
    }
}
