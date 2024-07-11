using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using odevalbum.Models;
using System;

namespace odevalbum.Controllers
{
    public class AlbumController : Controller
    {
        private readonly AppDbContext _dbContext;

        public AlbumController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var repository = _dbContext.Sanat.ToList();

            return View(repository);
        }

        public IActionResult Delete(int  id)
        {
            var tabloSanat = _dbContext.Sanat.Find(id);
            

            _dbContext.Sanat.Remove(tabloSanat);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(TabloSanat tabloSanat)
        {
            var managerBilgi = HttpContext.Request.Form["managerBilgi"];

            _dbContext.Sanat.Add(tabloSanat);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var tabloSanat = _dbContext.Sanat.Find(id);
            return View(tabloSanat);
        }
        [HttpPost]
        public IActionResult Update(TabloSanat guncelleSanat)
        {
            _dbContext.Sanat.Update(guncelleSanat);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Yeni()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Yeni(IFormCollection collection)
        {
            var managerBilgisi = collection["Adi"];
            TempData["ManagerBilgisi"] = managerBilgisi;

            return RedirectToAction("Index");
        }
    }
}
