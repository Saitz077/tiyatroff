using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace tiyatroff.Models;

[Table("gosterim")]
public partial class Gosterim
{
    [Key]
    [Column("gosterimId")]
    public int GosterimId { get; set; }

    [Column("oyunId")]
    public int? OyunId { get; set; }

    [Column("salonId")]
    public int? SalonId { get; set; }

    [Column("tarih", TypeName = "datetime")]
    public DateTime? Tarih { get; set; }

    [Column("fiyat")]
    [StringLength(10)]
    public string? Fiyat { get; set; }

    [Column("ilceId")]
    public int? IlceId { get; set; }


    [InverseProperty("Gosterim")]
    public virtual ICollection<Biletler> Biletlers { get; set; } = new List<Biletler>();

    [ForeignKey("IlceId")]
    [InverseProperty("Gosterims")]
    public virtual Ilceler? Ilce { get; set; }

    [ForeignKey("OyunId")]
    [InverseProperty("Gosterims")]
    public virtual Oyunlar? Oyun { get; set; }

    [ForeignKey("SalonId")]
    [InverseProperty("Gosterims")]
    public virtual Salonlar? Salon { get; set; }


}

