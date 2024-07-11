using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ders.Models;

[Table("urun_tbl")]
public partial class UrunTbl
{
    [Key]
    [Column("urunId")]
    public Guid UrunId { get; set; }

    [Column("kategoriId")]
    public int? KategoriId { get; set; }

    [Column("urunAd")]
    [StringLength(20)]
    public string? UrunAd { get; set; }

    [Column("urunFiyat", TypeName = "money")]
    public decimal? UrunFiyat { get; set; }

    [Column("urunAdet")]
    public int? UrunAdet { get; set; }

    [Column("urunPhoto", TypeName = "image")]
    public string? UrunPhoto { get; set; }
    [NotMapped]
    [DisplayName("Upload Image File")]
    public IFormFile? ImageFile { get; set; }

    [Column("favoriUrun")]
    public bool? FavoriUrun { get; set; }

    [ForeignKey("KategoriId")]
    [InverseProperty("UrunTbls")]
    public virtual KategoriTbl? Kategori { get; set; }
}
