using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace tiyatroff.Models;

[Table("biletler")]
public partial class Biletler
{
    [Key]
    [Column("biletId")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int BiletId { get; set; }

    [Column("gosterimId")]
    public int? GosterimId { get; set; }

    [Column("satistarih", TypeName = "datetime")]
    public DateTime? Satistarih { get; set; }

    [Column("fiyat")]
    [StringLength(10)]
    public string? Fiyat { get; set; }

    [ForeignKey("GosterimId")]
    [InverseProperty("Biletlers")]
    public virtual Gosterim? Gosterim { get; set; }
}
