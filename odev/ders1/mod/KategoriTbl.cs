using System;
using System.Collections.Generic;

namespace ders1.mod;

public partial class KategoriTbl
{
    public int KategoriId { get; set; }

    public string? KategoriAd { get; set; }

    public virtual ICollection<UrunTbl> UrunTbls { get; set; } = new List<UrunTbl>();
}
