using Microsoft.AspNetCore.Mvc;
using WebAPI_QLNhanSu.Models;
using WebAPI_QLNhanSu.RequestModel;

namespace WebAPI_QLNhanSu.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class HopDong_Controller
    {
        private readonly QLNhanSu_DbContext _context;

        public HopDong_Controller(QLNhanSu_DbContext context)
        {
            _context = context;
        }

        /// API Get DS HopDongLaoDong
        [HttpGet]
        public IEnumerable<HopDongLaoDong> Get()
        {
            return _context.HopDongLaoDongs.ToList();
        }

        /// API Them HopDongLaoDong
        [HttpPost]
        public HopDongLaoDong Post(Add_HopDong_Model addHopDongLaoDong)
        {
            HopDongLaoDong _hdld = new HopDongLaoDong()
            {
                MaHopDong = addHopDongLaoDong.MaHopDong,
                LoaiHopDong = addHopDongLaoDong.LoaiHopDong,
                NgayBatDau = addHopDongLaoDong.NgayBatDau,
                NgayKetThuc = addHopDongLaoDong.NgayKetThuc,
                MaNhanVien = addHopDongLaoDong.MaNhanVien,
            };
            _context.HopDongLaoDongs.Add(_hdld);
            _context.SaveChanges();
            return _hdld;
        }

        /// API Sua HopDongLaoDong
        [HttpPut]
        public HopDongLaoDong Update(String MaHD, Update_HopDong_Model updateHopDongLaoDong)
        {
            HopDongLaoDong _hdld = _context.HopDongLaoDongs.FirstOrDefault(e => e.MaHopDong == MaHD);
            if (_hdld != null)
            {
                _hdld.LoaiHopDong = updateHopDongLaoDong.MaHopDong;
                _hdld.NgayBatDau = updateHopDongLaoDong.NgayBatDau;
                _hdld.NgayKetThuc = updateHopDongLaoDong.NgayKetThuc;
                _hdld.MaNhanVien = updateHopDongLaoDong.MaNhanVien;
                _context.SaveChanges();
            }
            return _hdld;
        }

        ///API Xoa HopDongLaoDong
        [HttpDelete]
        public HopDongLaoDong Delete(String MaHD)
        {
            HopDongLaoDong _hdld = _context.HopDongLaoDongs.FirstOrDefault(e => e.MaHopDong == MaHD);
            if (_hdld != null)
            {
                _context.Remove(_hdld);
                _context.SaveChanges();
            }
            return _hdld;
        }
    }
}
