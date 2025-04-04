using System;
using System.Collections.Generic;

namespace WebAPI_QLNhanSu.Models;

public partial class TrinhDoHocVan
{
    public string MaTrinhDoHocVan { get; set; } = null!;

    public string TrinhDoHocVan1 { get; set; } = null!;

    public string? ChuyenNganh { get; set; }

    public virtual ICollection<NhanVien> NhanViens { get; set; } = new List<NhanVien>();
}
