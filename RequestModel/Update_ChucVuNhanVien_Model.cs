using WebAPI_QLNhanSu.Models;

namespace WebAPI_QLNhanSu.RequestModel
{
    public class Update_ChucVuNhanVien_Model
    {
        public string MaChucVu { get; set; } = null!;

        public string MaNhanVien { get; set; } = null!;

        //public virtual ChucVu MaChucVuNavigation { get; set; } = null!;

        //public virtual NhanVien MaNhanVienNavigation { get; set; } = null!;
    }
}
