using Microsoft.AspNetCore.Mvc.Rendering;

namespace tiyatroff.Models
{
    public class Cascade
    {
        public Gosterim Gosterim { get; set; } 
        public List<SelectListItem> IlcelerList { get; set; }
        public List<SelectListItem> SalonlarList { get; set; } = new List<SelectListItem>();
    }
}
