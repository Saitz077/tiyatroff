using System;
using System.Collections.Generic;
using System.Drawing;
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
    public class GosterimsController : Controller
    {
        private readonly DbTiyatroContext _context;
       


        public GosterimsController(DbTiyatroContext context)
        {
            _context = context;
        }

        // GET: Gosterims

        public async Task<IActionResult> Index()
        {
            var dbTiyatroContext = _context.Gosterims.Include(g => g.Oyun).Include(g => g.Salon);
            return View(await dbTiyatroContext.ToListAsync());
        }

        // GET: Gosterims/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Gosterims == null)
            {
                return NotFound();
            }

            var gosterim = await _context.Gosterims
                .Include(g => g.Oyun)
                .Include(g => g.Salon)
                .FirstOrDefaultAsync(m => m.GosterimId == id);
            if (gosterim == null)
            {
                return NotFound();
            }

            return View(gosterim);
        }

        // GET: Gosterims/Create
        public IActionResult Create()
        {

            List<Ilceler> ilcelistesi = new List<Ilceler>();
            ilcelistesi = (from Ilceler in _context.Ilcelers
                            select
                            Ilceler).ToList();
            ilcelistesi.Insert(0, new Ilceler { IlceId = 0, IlceAd = "İlçe Seçiniz" });
            ViewBag.ListofIlce = ilcelistesi;
            ViewData["OyunId"] = new SelectList(_context.Oyunlars, "OyunId", "OyunAd");
            ViewData["SalonId"] = new SelectList(_context.Salonlars, "SalonId", "SalonAd");
            ViewData["IlceId"] = new SelectList(_context.Ilcelers, "IlceId", "IlceAd");


            return View();



        }

        // POST: Gosterims/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GosterimId,OyunId,SalonId,Tarih,Fiyat")] Gosterim gosterim)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gosterim);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            List<Ilceler> ilcelistesi = new List<Ilceler>();
            ilcelistesi = (from Ilceler in _context.Ilcelers
                           select
                           Ilceler).ToList();
            ilcelistesi.Insert(0, new Ilceler { IlceId = 0, IlceAd = "İlçe Seçiniz" });
            ViewBag.ListofIlce = ilcelistesi;
            ViewData["OyunId"] = new SelectList(_context.Oyunlars, "OyunId", "OyunAd");
            ViewData["SalonId"] = new SelectList(_context.Salonlars, "SalonId", "SalonAd");
            ViewData["IlceId"] = new SelectList(_context.Ilcelers, "IlceId", "IlceAd");
            return View(gosterim);
        }
        [HttpPost]
        public JsonResult GetSalonlarByIlce(int ilceId)
        {

            var salonlist = (from salon in _context.Salonlars
                                 where salon.IlceId == ilceId
                                 select new
                                 {
                                     Text = salon.SalonAd,
                                     Value = salon.SalonId
                                 }).ToList();

            return Json(salonlist, new System.Text.Json.JsonSerializerOptions());
            
        }

        // GET: Gosterims/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Gosterims == null)
            {
                return NotFound();
            }

            var gosterim = await _context.Gosterims.FindAsync(id);
            if (gosterim == null)
            {
                return NotFound();
            }
            List<Ilceler> ilcelistesi = new List<Ilceler>();
            ilcelistesi = (from Ilceler in _context.Ilcelers
                           select
                           Ilceler).ToList();
            ilcelistesi.Insert(0, new Ilceler { IlceId = 0, IlceAd = "İlçe Seçiniz" });
            ViewBag.ListofIlce = ilcelistesi;

            ViewData["OyunId"] = new SelectList(_context.Oyunlars, "OyunId", "OyunId", gosterim.OyunId);
            ViewData["SalonId"] = new SelectList(_context.Salonlars, "SalonId", "SalonId", gosterim.SalonId);
            ViewData["IlceId"] = new SelectList(_context.Ilcelers, "IlceId", "IlceAd", gosterim.IlceId);
            return View(gosterim);
        }

        // POST: Gosterims/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GosterimId,OyunId,SalonId,Tarih,Fiyat")] Gosterim gosterim)
        {
            if (id != gosterim.GosterimId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gosterim);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GosterimExists(gosterim.GosterimId))
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
            ViewData["OyunId"] = new SelectList(_context.Oyunlars, "OyunId", "OyunId", gosterim.OyunId);
            ViewData["SalonId"] = new SelectList(_context.Salonlars, "SalonId", "SalonId", gosterim.SalonId);
            return View(gosterim);
        }

        // GET: Gosterims/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Gosterims == null)
            {
                return NotFound();
            }

            var gosterim = await _context.Gosterims
                .Include(g => g.Oyun)
                .Include(g => g.Salon)
                .FirstOrDefaultAsync(m => m.GosterimId == id);
            if (gosterim == null)
            {
                return NotFound();
            }

            return View(gosterim);
        }

        // POST: Gosterims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Gosterims == null)
            {
                return Problem("Entity set 'DbTiyatroContext.Gosterims'  is null.");
            }
            var gosterim = await _context.Gosterims.FindAsync(id);
            if (gosterim != null)
            {
                _context.Gosterims.Remove(gosterim);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GosterimExists(int id)
        {
          return (_context.Gosterims?.Any(e => e.GosterimId == id)).GetValueOrDefault();
        }
    }
}
