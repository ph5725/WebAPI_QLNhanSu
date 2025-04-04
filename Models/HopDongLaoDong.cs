using System;
using System.Collections.Generic;

namespace WebAPI_QLNhanSu.Models;

public partial class HopDongLaoDong
{
    public string MaHopDong { get; set; } = null!;

    public string LoaiHopDong { get; set; } = null!;

    public DateOnly NgayBatDau { get; set; }

    public DateOnly? NgayKetThuc { get; set; }

    public string? MaNhanVien { get; set; }

    public virtual NhanVien? MaNhanVienNavigation { get; set; }
}
