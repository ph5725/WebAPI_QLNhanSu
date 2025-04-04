using Microsoft.AspNetCore.Mvc;
using WebAPI_QLNhanSu.Models;
using WebAPI_QLNhanSu.RequestModel;

namespace WebAPI_QLNhanSu.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class NhanVien_Controller
    {
        private readonly QLNhanSu_DbContext _context;

        public NhanVien_Controller(QLNhanSu_DbContext context)
        {
            _context = context;
        }

        /// API Get DS NhanVien
        [HttpGet]
        public IEnumerable<NhanVien> Get()
        {
            return _context.NhanViens.ToList();
        }

        /// API Them NhanVien
        [HttpPost]

        public NhanVien Post(Add_NhanVien_Model addNhanVien)
        {
            NhanVien _nv = new NhanVien()
            {
                MaNhanVien = addNhanVien.MaNhanVien,
                HoTen = addNhanVien.HoTen,
                NgaySinh = addNhanVien.NgaySinh,
                GioiTinh = addNhanVien.GioiTinh,
                QueQuan = addNhanVien.QueQuan,
                DanToc = addNhanVien.DanToc,
                DiaChi = addNhanVien.DiaChi,
                Email = addNhanVien.Email,
                SoDienThoai = addNhanVien.SoDienThoai,
                BacLuong = addNhanVien.BacLuong,
                MaPhongBan = addNhanVien.MaPhongBan,
                MaChucVu = addNhanVien.MaChucVu,
                MaTrinhDoHocVan = addNhanVien.MaTrinhDoHocVan,
            };
            _context.NhanViens.Add(_nv);
            _context.SaveChanges();
            return _nv;
        }

        /// API Sua NhanVien
        [HttpPut]
        public NhanVien Update(String MaNV, Update_NhanVien_Model updateNhanVien)
        {
            NhanVien _nv = _context.NhanViens.FirstOrDefault(e => e.MaNhanVien == MaNV);
            if (_nv != null)
            {
                _nv.HoTen = updateNhanVien.HoTen;
                _nv.NgaySinh = updateNhanVien.NgaySinh;
                _nv.GioiTinh = updateNhanVien.GioiTinh;
                _nv.QueQuan = updateNhanVien.QueQuan;
                _nv.DanToc = updateNhanVien.DanToc;
                _nv.DiaChi = updateNhanVien.DiaChi;
                _nv.Email = updateNhanVien.Email;
                _nv.SoDienThoai = updateNhanVien.SoDienThoai;
                _nv.BacLuong = updateNhanVien.BacLuong;
                _nv.MaPhongBan = updateNhanVien.MaPhongBan;
                _nv.MaChucVu = updateNhanVien.MaChucVu;
                _nv.MaTrinhDoHocVan = updateNhanVien.MaTrinhDoHocVan;
                
                _context.SaveChanges();
            }
            return _nv;
        }

        ///API Xoa NhanVien
        [HttpDelete]
        public NhanVien Delete(String MaNV)
        {
            NhanVien _nv = _context.NhanViens.FirstOrDefault(e => e.MaNhanVien == MaNV);
            if (_nv != null)
            {
                _context.Remove(_nv);
                _context.SaveChanges();
            }
            return _nv;
        }

    }
}
