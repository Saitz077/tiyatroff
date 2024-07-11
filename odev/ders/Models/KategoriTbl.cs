using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ders.Models;

[Table("Kategori_Tbl")]
public partial class KategoriTbl
{
    public KategoriTbl()
    {
        UrunTbls = new HashSet<UrunTbl>();
    }
    [Key]
    [Column("kategoriId")]
    public int KategoriId { get; set; }

    [Column("kategoriAd")]
    [StringLength(20)]
    public string? KategoriAd { get; set; }

    [InverseProperty("Kategori")]
    public virtual ICollection<UrunTbl> UrunTbls { get; set; } = new List<UrunTbl>();
}
