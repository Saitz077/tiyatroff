using Microsoft.AspNetCore.Mvc;
using Ogreciler.Models;

namespace Ogreciler.Controllers
{
    public class StudentController : Controller
    {
        private readonly OgrenciRepository _ogrenciRepository;

        public StudentController()
        {
            _ogrenciRepository = new OgrenciRepository();
            if (!_ogrenciRepository.GetAll().Any())
            {
                _ogrenciRepository.Add(new() { Id = 1, ad = "Mehmet Sait", soyad = "ÖZMEN", sinif = "2", dersTanimi = "OOP", kredi = 4, sinavTarihi = "17.04.2023", vizeNot = 45, finalNot = 55, ortalama = 51, harfNotu = "DD" });
                _ogrenciRepository.Add(new() { Id = 2, ad = "Ahmmet", soyad = "ÖN", sinif = "3", dersTanimi = "Sistem Programlama", kredi = 6, sinavTarihi = "15.04.2023", vizeNot = 65, finalNot = 55, ortalama = 60, harfNotu = "CC" });
                _ogrenciRepository.Add(new() { Id = 3, ad = "Mehmet", soyad = "UZUN", sinif = "3", dersTanimi = "Veri Tabanı", kredi = 6, sinavTarihi = "16.04.2023", vizeNot = 85, finalNot = 55, ortalama = 70, harfNotu = "BB" });
                _ogrenciRepository.Add(new() { Id = 4, ad = "Cem", soyad = "Cs", sinif = "4", dersTanimi = "MAchine Learning", kredi = 7, sinavTarihi = "18.04.2023", vizeNot = 55, finalNot = 55, ortalama = 55, harfNotu = "DC" });
                _ogrenciRepository.Add(new() { Id = 5, ad = "Emre", soyad = "ÖZ", sinif = "1", dersTanimi = "Mat1", kredi = 4, sinavTarihi = "18.04.2023", vizeNot = 75, finalNot = 85, ortalama = 80, harfNotu = "BA" });
            }

        }
        

        public IActionResult Index()
        {
            var ogrenci = _ogrenciRepository.GetAll();
            return View(ogrenci);
        }
        public IActionResult Remove(int id) 
        {
            _ogrenciRepository.Remove(id);
            return RedirectToAction("Index");
        }
        public IActionResult Add() { return View(); }
        [HttpPost]
        public IActionResult Add(Models.Student _ogrenci) 
        {
            _ogrenciRepository.Add(_ogrenci);
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var ogrenci = _ogrenciRepository.GetAll().FirstOrDefault(x => x.Id == id);
           
            return View(ogrenci);
        }
        public IActionResult Edit(int id) {
            var ogrenci = _ogrenciRepository.GetAll().FirstOrDefault(x => x.Id == id);
           
            return View(ogrenci);
        }
        [HttpPost]
        public IActionResult Edit(Models.Student _ogrenci) 
        {
            var ogrenci = _ogrenciRepository.GetAll().FirstOrDefault(x => x.Id == _ogrenci.Id);
            ogrenci.ad = _ogrenci.ad;
            ogrenci.soyad = _ogrenci.soyad;
            ogrenci.sinif = _ogrenci.sinif;
            ogrenci.dersTanimi = _ogrenci.dersTanimi;
            ogrenci.kredi = _ogrenci.kredi;
            ogrenci.vizeNot = _ogrenci.vizeNot;
            ogrenci.finalNot = _ogrenci.finalNot;
            ogrenci.ortalama = _ogrenci.ortalama;
            ogrenci.harfNotu = _ogrenci.harfNotu;
       
        return RedirectToAction("Index");
        }
        public IActionResult Listele(int id) 
        {
            var ogrenciler = _ogrenciRepository.GetAll();
            return View(ogrenciler);
        }    
    }
    
}
