using ders.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ders.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DbUruntakipContext _dbUruntakipContext;

        public HomeController(ILogger<HomeController> logger, DbUruntakipContext dbUruntakipContext)
        {
            _logger = logger;
            this._dbUruntakipContext = dbUruntakipContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}