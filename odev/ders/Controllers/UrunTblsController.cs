using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ders.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Text;

namespace ders.Controllers
{
    public class UrunTblsController : Controller
    {
        private readonly DbUruntakipContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public UrunTblsController(DbUruntakipContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: UrunTbls
        public async Task<IActionResult> Index()
        {
            var dbUruntakipContext = _context.UrunTbls.Include(u => u.Kategori);
            return View(await dbUruntakipContext.ToListAsync());
        }

        // GET: UrunTbls/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.UrunTbls == null)
            {
                return NotFound();
            }

            var urunTbl = await _context.UrunTbls
                .Include(u => u.Kategori)
                .FirstOrDefaultAsync(m => m.UrunId == id);
            if (urunTbl == null)
            {
                return NotFound();
            }

            return View(urunTbl);
        }

        // GET: UrunTbls/Create
        public IActionResult Create()
        {
            
            ViewData["KategoriId"] = new SelectList(_context.KategoriTbls, "KategoriId", "KategoriAd");
            return View();
        }

        // POST: UrunTbls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KategoriId,UrunAd,UrunFiyat,UrunAdet,UrunPhoto,ImageFile,FavoriUrun")] UrunTbl urunTbl)
        {
            
            if (ModelState.IsValid)
            {
                var str = new StringContent(JsonConvert.SerializeObject(urunTbl).ToString(), Encoding.UTF8, "application/json");

                Debug.WriteLine("inner123!", urunTbl.ToString());
                Console.WriteLine("payload", urunTbl);
                if (true)
                {
                    Debug.WriteLine("inner321!", urunTbl);
                    string wwwrootpath = _hostEnvironment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(urunTbl.ImageFile.FileName);
                    string extension = Path.GetExtension(urunTbl.ImageFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    urunTbl.UrunPhoto = "~/contents/" + fileName;
                    string path = Path.Combine(wwwrootpath + "/contents/", fileName);
                    using (var filestream = new FileStream(path, FileMode.Create))
                    {
                        await urunTbl.ImageFile.CopyToAsync(filestream);
                    }
                    Console.WriteLine(urunTbl);
                    _context.Add(urunTbl);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewData["KategoriId"] = new SelectList(_context.KategoriTbls, "KategoriId", "KategoriId", urunTbl.KategoriId);
            return View(urunTbl);
        }

        // GET: UrunTbls/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UrunTbls == null)
            {
                return NotFound();
            }

            var urunTbl = await _context.UrunTbls.FindAsync(id);
            if (urunTbl == null)
            {
                return NotFound();
            }
            ViewData["KategoriId"] = new SelectList(_context.KategoriTbls, "KategoriId", "KategoriAd", urunTbl.KategoriId);
            return View(urunTbl);
        }

        // POST: UrunTbls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("UrunId,KategoriId,UrunAd,UrunFiyat,UrunAdet,UrunPhoto,FavoriUrun")] UrunTbl urunTbl)
        {
            if (id != urunTbl.UrunId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(urunTbl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UrunTblExists(urunTbl.UrunId))
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
            ViewData["KategoriId"] = new SelectList(_context.KategoriTbls, "KategoriId", "KategoriId", urunTbl.KategoriId);
            return View(urunTbl);
        }

        // GET: UrunTbls/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.UrunTbls == null)
            {
                return NotFound();
            }

            var urunTbl = await _context.UrunTbls
                .Include(u => u.Kategori)
                .FirstOrDefaultAsync(m => m.UrunId == id);
            if (urunTbl == null)
            {
                return NotFound();
            }

            return View(urunTbl);
        }

        // POST: UrunTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UrunTbls == null)
            {
                return Problem("Entity set 'DbUruntakipContext.UrunTbls'  is null.");
            }
            var urunTbl = await _context.UrunTbls.FindAsync(id);
            if (urunTbl != null)
            {
                _context.UrunTbls.Remove(urunTbl);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UrunTblExists(Guid id)
        {
          return (_context.UrunTbls?.Any(e => e.UrunId == id)).GetValueOrDefault();
        }
    }
}
