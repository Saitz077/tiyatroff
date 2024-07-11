using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace tiyatroff.Models;

[Table("oyunlar")]
public partial class Oyunlar
{
    [Key]
    [Column("oyunId")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int OyunId { get; set; }

    [Column("oyunAd")]
    [StringLength(30)]
    [DisplayName("Oyun Adı")]
    public string? OyunAd { get; set; }

    [Column("oyunFoto")]
    [StringLength(70)]
    [DisplayName("Oyun Fotoğrafı")]
    public string? OyunFoto { get; set; }
    [NotMapped]
    [DisplayName("Upload Image File")]
    public IFormFile? ImageFile { get; set; }

    [Column("oyunTur")]
    [StringLength(25)]
    [DisplayName("Oyun Türü")]
    public string? OyunTur { get; set; }

    [Column("yonetmen")]
    [DisplayName("Yönetmen")]
    [StringLength(30)]
    public string? Yonetmen { get; set; }

    [Column("sure")]
    [StringLength(10)]
    [DisplayName("Süre")]
    public string? Sure { get; set; }

    [InverseProperty("Oyun")]
    public virtual ICollection<Gosterim> Gosterims { get; set; } = new List<Gosterim>();
}
