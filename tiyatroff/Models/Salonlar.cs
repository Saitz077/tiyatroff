using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace tiyatroff.Models;

[Table("salonlar")]
public partial class Salonlar
{
    [Key]
    [Column("salonId")]
    public int SalonId { get; set; }

    [Column("salonAd")]
    [StringLength(30)]
    [DisplayName("Salon Adı")]
    public string? SalonAd { get; set; }

    [Column("ilceId")]
    public int? IlceId { get; set; }

    [Column("salonAdres")]
    [StringLength(70)]
    [DisplayName("Salon Adres")]
    public string? SalonAdres { get; set; }

    [Column("salonNo")]
    [StringLength(15)]
    [DisplayName("Telefon Numarası")]
    public string? SalonNo { get; set; }

    [InverseProperty("Salon")]
    public virtual ICollection<Gosterim> Gosterims { get; set; } = new List<Gosterim>();

    [ForeignKey("IlceId")]
    [InverseProperty("Salonlars")]
    public virtual Ilceler? Ilce { get; set; }
}
