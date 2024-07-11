using Microsoft.AspNetCore.Mvc.Rendering;

namespace odevnorthwind.Models
{
    public class Cascade
    {
        public IEnumerable<SelectListItem> RegionList { get; set; }
        public IEnumerable<SelectListItem> TerritorieList { get; set; }
    }
}
