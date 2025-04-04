using WebAPI_QLNhanSu.Models;

namespace WebAPI_QLNhanSu.RequestModel
{
    public class Add_PhongBan_Model
    {
        public string MaPhongBan { get; set; } = null!;

        public string TenPhongBan { get; set; } = null!;

        public string? DiaChi { get; set; }

        public string? SoDienThoai { get; set; }

        //public virtual ICollection<NhanVien> NhanViens { get; set; } = new List<NhanVien>();
    }
}
