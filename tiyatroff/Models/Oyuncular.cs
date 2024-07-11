using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace tiyatroff.Models;

[Table("oyuncular")]
public partial class Oyuncular
{
    [Key]
    [Column("oyuncuId")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int OyuncuId { get; set; }

    [Column("oyuncuAd")]
    [StringLength(25)]
    [DisplayName("Oyuncu Adı")]
    public string? OyuncuAd { get; set; }

    [Column("oyuncuFoto")]
    [StringLength(70)]
    public string? OyuncuFoto { get; set; }
    [NotMapped]
    [DisplayName("Upload Image File")]
    public IFormFile? ImageFile { get; set; }

    [Column("universite")]
    [StringLength(40)]
    [DisplayName("Üniversite")]
    public string? Universite { get; set; }

    [Column("telNo")]
    [StringLength(15)]
    [DisplayName("Telefon Numarası")]
    public string? TelNo { get; set; }
}
