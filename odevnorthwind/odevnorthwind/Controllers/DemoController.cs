using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using odevnorthwind.Models;

namespace odevnorthwind.Controllers
{
    public class DemoController : Controller
    {
        private readonly NorthwindContext _context;
        Cascade cd=new Cascade();
        public DemoController(NorthwindContext context) { _context = context; }
        public IActionResult Index()
        {
            List<Region> regionlist = new List<Region>();
            cd.RegionList = new SelectList(_context.Regions, "RegionId", "RegionDescription");
            cd.TerritorieList = new SelectList(_context.Territories, "TerritoryId", "TerritoryDescription");
            return View(cd);
        }
        public JsonResult GetTerritories(int regionId)
        {
            var territoryList=(from  territory in _context.Territories
                               where territory.RegionId == regionId
                               select new
                               {
                                   Text =territory.TerritoryDescription,
                                  Value=territory.TerritoryId
                               }).ToList();
            return Json(territoryList,new System.Text.Json.JsonSerializerOptions());
        }
    }
}
