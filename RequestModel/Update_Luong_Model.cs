using WebAPI_QLNhanSu.Models;

namespace WebAPI_QLNhanSu.RequestModel
{
    public class Update_Luong_Model
    {
        public int BacLuong { get; set; }

        public decimal? LuongCoBan { get; set; }

        public decimal? HeSoLuong { get; set; }

        public decimal? HeSoCoBan { get; set; }

        //public virtual ICollection<NhanVien> NhanViens { get; set; } = new List<NhanVien>();
    }
}
