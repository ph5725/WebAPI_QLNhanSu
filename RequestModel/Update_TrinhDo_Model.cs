using WebAPI_QLNhanSu.Models;

namespace WebAPI_QLNhanSu.RequestModel
{
    public class Update_TrinhDo_Model
    {
        public string MaTrinhDoHocVan { get; set; } = null!;

        public string TrinhDoHocVan1 { get; set; } = null!;

        public string? ChuyenNganh { get; set; }

        //public virtual ICollection<NhanVien> NhanViens { get; set; } = new List<NhanVien>();
    }
}
