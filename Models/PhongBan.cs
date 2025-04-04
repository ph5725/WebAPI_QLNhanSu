using System;
using System.Collections.Generic;

namespace WebAPI_QLNhanSu.Models;

public partial class PhongBan
{
    public string MaPhongBan { get; set; } = null!;

    public string TenPhongBan { get; set; } = null!;

    public string? DiaChi { get; set; }

    public string? SoDienThoai { get; set; }

    public virtual ICollection<NhanVien> NhanViens { get; set; } = new List<NhanVien>();
}
