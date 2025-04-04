using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_QLNhanSu.Models;
using WebAPI_QLNhanSu.RequestModel;

namespace WebAPI_QLNhanSu.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Luong_Controller
    {
        private readonly QLNhanSu_DbContext _context;

        public Luong_Controller(QLNhanSu_DbContext context)
        {
            _context = context;
        }

        /// API Get DS Luong
        [HttpGet]
        public IEnumerable<Luong> Get()
        {
            return _context.Luongs.ToList();
        }

        /// API Them Luong
        [HttpPost]
        public Luong Post(Add_Luong_Model addLuong)
        {
            Luong _luong = new Luong()
            {
                BacLuong = addLuong.BacLuong,
                LuongCoBan = addLuong.LuongCoBan,
                HeSoLuong = addLuong.HeSoLuong,
                HeSoCoBan = addLuong.HeSoCoBan,
            };
            _context.Luongs.Add(_luong);
            _context.SaveChanges();
            return _luong;
        }

        /// API Sua Luong
        [HttpPut]
        public Luong Update(int BLuong, Update_Luong_Model updateLuong)
        {
            Luong _luong = _context.Luongs.FirstOrDefault(e => e.BacLuong == BLuong);
            if (_luong != null)
            {
                _luong.LuongCoBan = updateLuong.LuongCoBan;
                _luong.HeSoLuong = updateLuong.HeSoLuong;
                _luong.HeSoCoBan = updateLuong.HeSoCoBan;
                _context.SaveChanges();
            }
            return _luong;
        }

        ///API Xoa Luong
        [HttpDelete]
        public Luong Delete(int BLuong)
        {
            Luong _luong = _context.Luongs.FirstOrDefault(e => e.BacLuong == BLuong);
            if (_luong != null)
            {
                _context.Remove(_luong);
                _context.SaveChanges();
            }
            return _luong;
        }

    }
}
