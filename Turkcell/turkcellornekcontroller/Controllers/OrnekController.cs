using Microsoft.AspNetCore.Mvc;

namespace turkcellornekcontroller.Controllers
{
    public class OrnekController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.name = "Asp.net Core";

            return View();
        }
        public RedirectToActionResult Index2() {
        
            return RedirectToAction("Index");
        }
    }
}
