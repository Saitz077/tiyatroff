using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace tiyatroff.Models;

[Table("kullanici")]
public partial class Kullanici
{
    [Key]
    [Column("kullaniciId")]
    public int KullaniciId { get; set; }

    [Column("status")]
    public bool Status { get; set; }

    [Column("eposta")]
    [StringLength(30)]
    public string? Eposta { get; set; }

    [Column("sifre")]
    [StringLength(10)]
    public string? Sifre { get; set; }
}
