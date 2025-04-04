using WebAPI_QLNhanSu.Models;

namespace WebAPI_QLNhanSu.RequestModel
{
    public class Add_TaiKhoan_Model
    {
        public int Id { get; set; }

        public string TenTaiKhoan { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string MatKhau { get; set; } = null!;

        public string? MaNhanVien { get; set; }

        //public virtual NhanVien? MaNhanVienNavigation { get; set; }
    }
}
