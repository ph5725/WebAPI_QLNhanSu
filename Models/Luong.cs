using System;
using System.Collections.Generic;

namespace WebAPI_QLNhanSu.Models;

public partial class Luong
{
    public int BacLuong { get; set; }

    public decimal? LuongCoBan { get; set; }

    public decimal? HeSoLuong { get; set; }

    public decimal? HeSoCoBan { get; set; }

    public virtual ICollection<NhanVien> NhanViens { get; set; } = new List<NhanVien>();
}
