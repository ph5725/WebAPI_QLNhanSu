using Microsoft.AspNetCore.Mvc;
using WebAPI_QLNhanSu.Models;
using WebAPI_QLNhanSu.RequestModel;

namespace WebAPI_QLNhanSu.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrinhDo_Controller
    {
        private readonly QLNhanSu_DbContext _context;

        public TrinhDo_Controller(QLNhanSu_DbContext context)
        {
            _context = context;
        }

        /// API Get DS TrinhDo
        [HttpGet]
        public IEnumerable<TrinhDoHocVan> Get()
        {
            return _context.TrinhDoHocVans.ToList();
        }

        /// API Them TrinhDo
        [HttpPost]
        public TrinhDoHocVan Post(Add_TrinhDo_Model addTrinhDo)
        {
            TrinhDoHocVan _tdhv = new TrinhDoHocVan()
            {
                MaTrinhDoHocVan = addTrinhDo.MaTrinhDoHocVan,
                TrinhDoHocVan1 = addTrinhDo.TrinhDoHocVan1,
                ChuyenNganh = addTrinhDo.ChuyenNganh,
            };
            _context.TrinhDoHocVans.Add(_tdhv);
            _context.SaveChanges();
            return _tdhv;
        }

        /// API Sua TrinhDo
        [HttpPut]
        public TrinhDoHocVan Update(String MaTD, Update_TrinhDo_Model updateTrinhDo)
        {
            TrinhDoHocVan _tdhv = _context.TrinhDoHocVans.FirstOrDefault(e => e.MaTrinhDoHocVan == MaTD);
            if (_tdhv != null)
            {
                _tdhv.TrinhDoHocVan1 = updateTrinhDo.TrinhDoHocVan1;
                _tdhv.ChuyenNganh = updateTrinhDo.ChuyenNganh;
                _context.SaveChanges();
            }
            return _tdhv;
        }

        ///API Xoa TrinhDo
        [HttpDelete]
        public TrinhDoHocVan Delete(String MaTD)
        {
            TrinhDoHocVan _tdhv = _context.TrinhDoHocVans.FirstOrDefault(e => e.MaTrinhDoHocVan == MaTD);
            if (_tdhv != null)
            {
                _context.Remove(_tdhv);
                _context.SaveChanges();
            }
            return _tdhv;
        }

    }
}

