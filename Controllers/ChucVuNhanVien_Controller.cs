using Microsoft.AspNetCore.Mvc;
using WebAPI_QLNhanSu.Models;
using WebAPI_QLNhanSu.RequestModel;

namespace WebAPI_QLNhanSu.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ChucVuNhanVien_Controller
    {
    private readonly QLNhanSu_DbContext _context;

        public ChucVuNhanVien_Controller(QLNhanSu_DbContext context)
        {
            _context = context;
        }

        /// API Get DS ChucVuNhanVien
        [HttpGet]
        public IEnumerable<ChucVuNhanVien> Get()
        {
            return _context.ChucVuNhanViens.ToList();
        }

        /// API Them ChucVuNhanVien
        [HttpPost]
        public ChucVuNhanVien Post(Add_ChucVuNhanVien_Model addChucVuNhanVien)
        {
            ChucVuNhanVien _cvnv = new ChucVuNhanVien()
            {
                MaChucVu= addChucVuNhanVien.MaChucVu,
                MaNhanVien = addChucVuNhanVien.MaNhanVien,
            };
            _context.ChucVuNhanViens.Add(_cvnv);
            _context.SaveChanges();
            return _cvnv;
        }

        /// API Sua ChucVuNhanVien
        [HttpPut]
        public ChucVuNhanVien Update(String MaCV, String MaNV, Update_ChucVuNhanVien_Model updateChucVuNhanVien)
        {
            ChucVuNhanVien _cvnv = _context.ChucVuNhanViens.FirstOrDefault(e => e.MaChucVu == MaCV && e.MaNhanVien == MaNV);
            if (_cvnv != null)
            {
                _cvnv.MaChucVu = updateChucVuNhanVien.MaChucVu;
                _cvnv.MaNhanVien = updateChucVuNhanVien.MaNhanVien;
                _context.SaveChanges();
            }
            return _cvnv;
        }

        ///API Xoa ChucVuNhanVien
        [HttpDelete]
        public ChucVuNhanVien Delete(String MaCV, String MaNV)
        {
            ChucVuNhanVien _cvnv = _context.ChucVuNhanViens.FirstOrDefault(e => e.MaChucVu == MaCV && e.MaNhanVien == MaNV);
            if (_cvnv != null)
            {
                _context.Remove(_cvnv);
                _context.SaveChanges();
            }
            return _cvnv;
        }

    }
}
