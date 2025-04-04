using System;
using System.Collections.Generic;

namespace WebAPI_QLNhanSu.Models;

public partial class NhanVien
{
    public string MaNhanVien { get; set; } = null!;

    public string HoTen { get; set; } = null!;

    public DateOnly? NgaySinh { get; set; }

    public string? GioiTinh { get; set; }

    public string? QueQuan { get; set; }

    public string? DanToc { get; set; }

    public string? DiaChi { get; set; }

    public string? Email { get; set; }

    public string? SoDienThoai { get; set; }

    public int? BacLuong { get; set; }

    public string? MaPhongBan { get; set; }

    public string? MaChucVu { get; set; }

    public string? MaTrinhDoHocVan { get; set; }

    //public TaiKhoan TaiKhoans { get; set; }



    public virtual Luong? BacLuongNavigation { get; set; }

    public virtual HopDongLaoDong? HopDongLaoDong { get; set; }

    public virtual PhongBan? MaPhongBanNavigation { get; set; }

    public virtual TrinhDoHocVan? MaTrinhDoHocVanNavigation { get; set; }

    public virtual TaiKhoan? TaiKhoan { get; set; }
}
