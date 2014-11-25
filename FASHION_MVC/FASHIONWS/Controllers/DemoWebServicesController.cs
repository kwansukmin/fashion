using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using FASHIONWS.WS_DienTu;

namespace FASHIONWS.Controllers
{
    public class DemoWebServicesController : Controller
    {
        //
        // GET: /DemoWebServices/Index

        public ActionResult Index()
        {
            DienTu ws = new DienTu();
            
            IList<vw_SanPham> dsSP = ws.DocSanPhamTheoTen("tivi");

            return View(dsSP);
        }

    }
}
