using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using FASHIONWS.Models;

namespace FASHIONWS.Controllers
{
    public class HomeController : Controller
    {
        #region 4.10
        //khởi tạo 
        FashionDbContext db = new FashionDbContext();
        protected override void Dispose(bool disposing)
        {// Xóa | giải phóng biến
            db.Dispose();
            base.Dispose(disposing);
        }
        #endregion

        //5.1
        // GET: /Home/Index
        public ViewResult Index()
        {
            ViewBag.Title = "Trang Chủ";
            ViewBag.Message = "Cửa hàng của chúng tôi";

            string f = Server.MapPath("~/Data/GioiThieu.txt");
            string noidung=System.IO.File.ReadAllText(f);
            ViewBag.GioiThieu = noidung;
            return View();
        }

        //5.3


        [ChildActionOnly] //chi duoc phep goi tu View ngan khong cho ben ngoai Get truc tiep Action MenuDynamic
        public PartialViewResult MenuDynamic()
        {
            //lấy 3 phân loại đầu tiên
            List<PhanLoai> dsPhanLoai = db.PhanLoais.Include("Nhomsps").Take(3).ToList();
            ViewBag.PhanLoais = dsPhanLoai;
            return PartialView("_MenuDynamicPartial");
        }

    }
}
