using WebAPI_QLNhanSu.Models;

namespace WebAPI_QLNhanSu.RequestModel
{
    public class Add_HopDong_Model
    {
        public string MaHopDong { get; set; } = null!;

        public string LoaiHopDong { get; set; } = null!;

        public DateOnly NgayBatDau { get; set; }

        public DateOnly? NgayKetThuc { get; set; }

        public string? MaNhanVien { get; set; }

        //public virtual NhanVien? MaNhanVienNavigation { get; set; }
    }
}
