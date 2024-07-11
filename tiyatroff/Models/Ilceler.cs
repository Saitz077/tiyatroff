using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace tiyatroff.Models;

[Table("ilceler")]
public partial class Ilceler
{
    public Ilceler()
    {
        Salonlars = new HashSet<Salonlar>();
        Gosterims = new HashSet<Gosterim>();
    }
    [Key]
    [Column("ilceId")]
    public int IlceId { get; set; }

    [Column("ilceAd")]
    [StringLength(15)]
    public string? IlceAd { get; set; }

    [InverseProperty("Ilce")]
    public virtual ICollection<Salonlar> Salonlars { get; set; } = new List<Salonlar>();

    [InverseProperty("Ilce")]
    public virtual ICollection<Gosterim> Gosterims { get; set; } = new List<Gosterim>();
}
