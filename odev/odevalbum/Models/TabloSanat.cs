using System.ComponentModel.DataAnnotations;

namespace odevalbum.Models
{
    public class TabloSanat
    {
        [Key]
        public int Id { get; set; }
        public int No { get; set; }
        public string Tur { get; set; }
        public string SanatciBilgi { get; set; }
        public string AlbumAdi { get; set; }
        public decimal Fiyat { get; set; }
        public bool Yerli { get; set; }
    }
}
