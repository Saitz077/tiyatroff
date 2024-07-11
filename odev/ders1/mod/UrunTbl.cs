using System;
using System.Collections.Generic;

namespace ders1.mod;

public partial class UrunTbl
{
    public int UrunId { get; set; }

    public int? KategoriId { get; set; }

    public string? UrunAd { get; set; }

    public decimal? UrunFiyat { get; set; }

    public int? UrunAdet { get; set; }

    public byte[]? UrunPhoto { get; set; }

    public bool? FavoriUrun { get; set; }

    public virtual KategoriTbl? Kategori { get; set; }
}
