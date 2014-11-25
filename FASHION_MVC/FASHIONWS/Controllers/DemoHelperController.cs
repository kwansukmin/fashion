using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FASHIONWS.Models;

namespace FASHIONWS.Controllers
{
    public class DemoHelperController : Controller
    {
        FashionDbContext db = new FashionDbContext();
        //
        // GET: /DemoHelper/


        public ActionResult Index()
        {
            return View();
        }
        //
        //GET: /DemoHelper/EX01Display
        public ActionResult EX01Display()
        {
            ViewBag.TenPhanLoai = db.PhanLoais.SingleOrDefault(p => p.PhanLoaiID == 1).TenPhanLoai;
            ViewData["Ten Nhom"] = db.Nhomsps.SingleOrDefault(p => p.NhomspID == 1).TenNhomsp;
            SanPham sp = db.SanPhams.Single(p => p.SanPhamID == 1);
            return View(sp);
        }

        public ActionResult EX02Form()
        {
            SanPham sp = db.SanPhams.Single(p => p.SanPhamID == 1);
            return View();
 
        }
        //
        // GET: /DemoHelper/TimKiem
        public ActionResult TimKiem(string GiaTriTim)
        {
            ViewBag.NoiDung = GiaTriTim;
            return View();
        }
    }
}
