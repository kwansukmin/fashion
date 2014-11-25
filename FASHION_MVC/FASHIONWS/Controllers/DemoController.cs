using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FASHIONWS.Controllers
{
    public class DemoController : Controller
    {
        //
        // GET: /Demo/EXTruyenDL

        public ViewResult EXTruyenDL()
        {
            ViewBag.NgayHienHanh = DateTime.Today;
            ViewData["Thoi diem hien hanh"] = DateTime.Now;


            return View();
        }

    }
}
