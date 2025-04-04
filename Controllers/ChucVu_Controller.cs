using Microsoft.AspNetCore.Mvc;
using WebAPI_QLNhanSu.Models;
using WebAPI_QLNhanSu.RequestModel;

namespace WebAPI_QLNhanSu.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChucVu_Controller
    {
        private readonly QLNhanSu_DbContext _context;

        public ChucVu_Controller(QLNhanSu_DbContext context)
        {
            _context = context;
        }

        /// API Get DS ChucVu
        [HttpGet]
        public IEnumerable<ChucVu> Get()
        {
            return _context.ChucVus.ToList();
        }

        /// API Them ChucVu
        [HttpPost]
        public ChucVu Post(Add_ChucVu_Model addChucVu)
        {
            ChucVu _cv = new ChucVu()
            {
                MaChucVu = addChucVu.MaChucVu,
                TenChucVu = addChucVu.TenChucVu,
            };
            _context.ChucVus.Add(_cv);
            _context.SaveChanges();
            return _cv;
        }

        /// API Sua ChucVu
        [HttpPut]
        public ChucVu Update(String MaCV, Update_ChucVu_Model updateChucVu)
        {
            ChucVu _cv = _context.ChucVus.FirstOrDefault(e => e.MaChucVu == MaCV);
            if (_cv != null)
            {
                _cv.TenChucVu = updateChucVu.TenChucVu;
                _context.SaveChanges();
            }
            return _cv;
        }

        ///API Xoa ChucVu
        [HttpDelete]
        public ChucVu Delete(String MaCV)
        {
            ChucVu _cv = _context.ChucVus.FirstOrDefault(e => e.MaChucVu == MaCV);
            if (_cv != null)
            {
                _context.Remove(_cv);
                _context.SaveChanges();
            }
            return _cv;
        }

    }
}