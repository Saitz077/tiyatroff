using Microsoft.AspNetCore.Mvc;

namespace odev1.Controllers
{
    public class Irıs : Controller
    {

        public IActionResult Index()
        {
            // JSON dosyasının içeriğini oku
            var jsonContent = System.IO.File.ReadAllBytes(@"C:\Users\saitz\OneDrive\Desktop\MyTurkcellProject\odev\odev1\iris.json");

            // JSON içeriğini ViewData'ya ekle
            ViewData["JsonContent"] = jsonContent;

            return View();
        }
    }
}
