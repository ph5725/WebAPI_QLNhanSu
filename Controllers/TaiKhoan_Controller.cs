using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using WebAPI_QLNhanSu.Models;
using WebAPI_QLNhanSu.RequestModel;
using WebAPI_QLNhanSu.ResponeModel;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WebAPI_QLNhanSu.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaiKhoan_Controller : ControllerBase
    {
        private readonly QLNhanSu_DbContext _context;
        private readonly JwtHelper _jwtHelper;

        public TaiKhoan_Controller(QLNhanSu_DbContext context, JwtHelper jwtHelper)
        {
            _context = context;
            _jwtHelper = jwtHelper;
        }

        /// API Get DS TaiKhoan
        [HttpGet]
        [Authorize]
        public IEnumerable<TaiKhoanResponeModel> Get()
        {
            var query = from taikhoan in _context.TaiKhoans
            .Include(tk => tk.MaNhanVienNavigation) // Eager Load NhanVien
                select new TaiKhoanResponeModel
                {
                    Id = taikhoan.Id,
                    TenTaiKhoan = taikhoan.TenTaiKhoan,
                    Email = taikhoan.Email,
                    MatKhau = taikhoan.MatKhau,
                    NhanViens = taikhoan.MaNhanVienNavigation != null ? new NhanVienDto
                    {
                        MaNhanVien = taikhoan.MaNhanVienNavigation.MaNhanVien,
                        HoTen = taikhoan.MaNhanVienNavigation.HoTen,
                        NgaySinh = taikhoan.MaNhanVienNavigation.NgaySinh,
                        GioiTinh = taikhoan.MaNhanVienNavigation.GioiTinh,
                        QueQuan = taikhoan.MaNhanVienNavigation.QueQuan,
                        DanToc = taikhoan.MaNhanVienNavigation.DanToc,
                        DiaChi = taikhoan.MaNhanVienNavigation.DiaChi,
                        SoDienThoai = taikhoan.MaNhanVienNavigation.SoDienThoai,

                    } : null
                };
                return query.ToList();
        }

        [HttpPost("login")]
        public ActionResult<string> Login([FromBody] LoginRequestModel loginRequest)
        {
            var taiKhoan = _context.TaiKhoans
                .FirstOrDefault(taiKhoan => taiKhoan.Email == loginRequest.Email && taiKhoan.MatKhau == loginRequest.Password);
            if (taiKhoan == null)
            {
                return NotFound();
            }

            return _jwtHelper.GenerateToken(taiKhoan.Email, "user");
        }

        /// API Them TaiKhoan
        [HttpPost]
        public TaiKhoan Post(Add_TaiKhoan_Model addTaiKhoan)
        {
            TaiKhoan _tk = new TaiKhoan()
            {
                Id = addTaiKhoan.Id,
                TenTaiKhoan = addTaiKhoan.TenTaiKhoan,
                Email = addTaiKhoan.Email,
                MatKhau = addTaiKhoan.MatKhau,
                MaNhanVien = addTaiKhoan.MaNhanVien,
            };
            _context.TaiKhoans.Add(_tk);
            _context.SaveChanges();
            return _tk;
        }

        /// API Sua TaiKhoan
        [HttpPut]
        public TaiKhoan Update(String TenTK, Update_TaiKhoan_Model updateTaiKhoan)
        {
            TaiKhoan _tk = _context.TaiKhoans.FirstOrDefault(e => e.TenTaiKhoan == TenTK);
            if (_tk != null)
            {
                _tk.TenTaiKhoan = updateTaiKhoan.TenTaiKhoan;
                _tk.Email = updateTaiKhoan.Email;
                _tk.MatKhau = updateTaiKhoan.MatKhau;
                _tk.MaNhanVien = updateTaiKhoan.MaNhanVien;
                _context.SaveChanges();
            }
            return _tk;
        }

        ///API Xoa TaiKhoan
        [HttpDelete]
        public TaiKhoan Delete(String TenTK)
        {
            TaiKhoan _tk = _context.TaiKhoans.FirstOrDefault(e => e.TenTaiKhoan == TenTK);
            if (_tk != null)
            {
                _context.Remove(_tk);
                _context.SaveChanges();
            }
            return _tk;
        }

    }
}