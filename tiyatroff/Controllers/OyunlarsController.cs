using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using tiyatroff.Models;

namespace tiyatroff.Controllers
{
    [Authorize]
    public class OyunlarsController : Controller
    {
        private readonly DbTiyatroContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public OyunlarsController(DbTiyatroContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: Oyunlars
        public async Task<IActionResult> Index()
        {
              return _context.Oyunlars != null ? 
                          View(await _context.Oyunlars.ToListAsync()) :
                          Problem("Entity set 'DbTiyatroContext.Oyunlars'  is null.");
        }

        // GET: Oyunlars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Oyunlars == null)
            {
                return NotFound();
            }

            var oyunlar = await _context.Oyunlars
                .FirstOrDefaultAsync(m => m.OyunId == id);
            if (oyunlar == null)
            {
                return NotFound();
            }

            return View(oyunlar);
        }

        // GET: Oyunlars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Oyunlars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OyunId,OyunAd,OyunFoto,ImageFile,OyunTur,Yonetmen,Sure")] Oyunlar oyunlar)
        {
            if (ModelState.IsValid)
            {
                string wwwrootpath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(oyunlar.ImageFile.FileName);
                string extension = Path.GetExtension(oyunlar.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                oyunlar.OyunFoto = "/Contents/" + fileName;
                string path = Path.Combine(wwwrootpath + "/Contents", fileName);
                using (var filestream = new FileStream(path, FileMode.Create))
                {
                    await oyunlar.ImageFile.CopyToAsync(filestream);
                }
                _context.Add(oyunlar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(oyunlar);
        }

        // GET: Oyunlars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Oyunlars == null)
            {
                return NotFound();
            }

            var oyunlar = await _context.Oyunlars.FindAsync(id);
            if (oyunlar == null)
            {
                return NotFound();
            }
            return View(oyunlar);
        }

        // POST: Oyunlars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OyunId,OyunAd,OyunFoto,ImageFile,OyunTur,Yonetmen,Sure")] Oyunlar oyunlar)
        {
            if (id != oyunlar.OyunId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (oyunlar.ImageFile != null)
                {
                    string wwwrootpath = _hostEnvironment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(oyunlar.ImageFile.FileName);
                    string extension = Path.GetExtension(oyunlar.ImageFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    oyunlar.OyunFoto = "/Contents/" + fileName;
                    string path = Path.Combine(wwwrootpath, "Contents", fileName);
                    using (var filestream = new FileStream(path, FileMode.Create))
                    {
                        await oyunlar.ImageFile.CopyToAsync(filestream);
                    }
                }

                try
                {
                    _context.Update(oyunlar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OyunlarExists(oyunlar.OyunId))
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
            return View(oyunlar);
        }

        // GET: Oyunlars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Oyunlars == null)
            {
                return NotFound();
            }

            var oyunlar = await _context.Oyunlars
                .FirstOrDefaultAsync(m => m.OyunId == id);
            if (oyunlar == null)
            {
                return NotFound();
            }

            return View(oyunlar);
        }

        // POST: Oyunlars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Oyunlars == null)
            {
                return Problem("Entity set 'DbTiyatroContext.Oyunlars'  is null.");
            }
            var oyunlar = await _context.Oyunlars.FindAsync(id);
            if (oyunlar != null)
            {
                _context.Oyunlars.Remove(oyunlar);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OyunlarExists(int id)
        {
          return (_context.Oyunlars?.Any(e => e.OyunId == id)).GetValueOrDefault();
        }
    }
}
