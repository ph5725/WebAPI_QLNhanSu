namespace WebAPI_QLNhanSu.ResponeModel
{
    public class TaiKhoanResponeModel
    {
        public int Id { get; set; }

        public string TenTaiKhoan { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string MatKhau { get; set; } = null!;

        public NhanVienDto NhanViens { get; set; }
    }
}
