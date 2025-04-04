using WebAPI_QLNhanSu.Models;

namespace WebAPI_QLNhanSu.ResponeModel
{
    public class NhanVienDto
    {
        public string MaNhanVien { get; set; } = null!;
        public string HoTen { get; set; } = null!;

        public DateOnly? NgaySinh { get; set; }

        public string? GioiTinh { get; set; }

        public string? QueQuan { get; set; }

        public string? DanToc { get; set; }

        public string? DiaChi { get; set; }

        public string? SoDienThoai { get; set; }
    }
}
