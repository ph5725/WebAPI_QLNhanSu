using System;
using System.Collections.Generic;

namespace WebAPI_QLNhanSu.Models;

public partial class ChucVuNhanVien
{
    public string MaChucVu { get; set; } = null!;

    public string MaNhanVien { get; set; } = null!;

    public virtual ChucVu MaChucVuNavigation { get; set; } = null!;

    public virtual NhanVien MaNhanVienNavigation { get; set; } = null!;
}
