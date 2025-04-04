    using System;
    using System.Collections.Generic;

    namespace WebAPI_QLNhanSu.Models;

    public partial class TaiKhoan
    {
        public int Id { get; set; }

        public string TenTaiKhoan { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string MatKhau { get; set; } = null!;

        public string MaNhanVien { get; set; }

        //public NhanVien NhanViens { get; set; }

        public virtual NhanVien? MaNhanVienNavigation { get; set; }
    }
