using Microsoft.AspNetCore.Mvc;
using WebAPI_QLNhanSu.Models;
using WebAPI_QLNhanSu.RequestModel;

namespace WebAPI_QLNhanSu.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PhongBan_Controller
    {
        private readonly QLNhanSu_DbContext _context;

        public PhongBan_Controller(QLNhanSu_DbContext context)
        {
            _context = context;
        }

        /// API Get DS PhongBan
        [HttpGet]
        public IEnumerable<PhongBan> Get()
        {
            return _context.PhongBans.ToList();
        }

        /// API Them PhongBan
        [HttpPost]
        public PhongBan Post(Add_PhongBan_Model addPhongBan)
        {
            PhongBan _pb = new PhongBan()
            {
                MaPhongBan = addPhongBan.MaPhongBan,
                TenPhongBan = addPhongBan.TenPhongBan,
                DiaChi = addPhongBan.DiaChi,
                SoDienThoai = addPhongBan.SoDienThoai,
            };
            _context.PhongBans.Add(_pb);
            _context.SaveChanges();
            return _pb;
        }

        /// API Sua PhongBan
        [HttpPut]
        public PhongBan Update(String MaPB, Update_PhongBan_Model updatePhongBan)
        {
            PhongBan _pb = _context.PhongBans.FirstOrDefault(e => e.MaPhongBan == MaPB);
            if (_pb != null)
            {
                _pb.TenPhongBan = updatePhongBan.TenPhongBan;
                _pb.DiaChi = updatePhongBan.DiaChi;
                _pb.SoDienThoai = updatePhongBan.SoDienThoai;
                _context.SaveChanges();
            }
            return _pb;
        }

        ///API Xoa PhongBan
        [HttpDelete]
        public PhongBan Delete(String MaPB)
        {
            PhongBan _pb = _context.PhongBans.FirstOrDefault(e => e.MaPhongBan == MaPB);
            if (_pb != null)
            {
                _context.Remove(_pb);
                _context.SaveChanges();
            }
            return _pb;
        }

    }
}
