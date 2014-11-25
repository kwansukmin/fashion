using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//4.8
using System.Data;


//khai báo Namespace
using FASHIONWS.Models;

namespace FASHIONWS.Controllers
{
    public class PhanLoaiController : Controller
    {
        //khởi tạo 
        FashionDbContext db = new FashionDbContext();
        protected override void Dispose(bool disposing)
        {//4.1 Xóa | giải phóng biến
            db.Dispose();
            base.Dispose(disposing);
        }

        //4.2
        // GET: /PhanLoai/

        public ViewResult Details(int id=0)
        {
            PhanLoai phanLoai = db.PhanLoais.SingleOrDefault(p => p.PhanLoaiID == id);
            if (phanLoai == null)
            {
                object noidung = "Thông tin truy cập không hợp lệ!";
                return View("ThongBao", noidung); //phuong thuc 6/8

            }
            return View(phanLoai); //phuong thuc 3/8
        }


        //4.4
        // GET: /PhanLoai/Index

        public ViewResult Index()
        {
            ViewBag.Message = "Xem danh sách - Phân loại";
            ViewBag.Title = "Phân Loại - Index";

            IList<PhanLoai> dsPhanLoai = db.PhanLoais.ToList();
            return View(dsPhanLoai);
        }
        #region 4.6
        //4.6
        //GET: /PhanLoai/Create
        public ViewResult Create()
        {

            return View();
        }

        //
        //POST: /PhanLoai/Create
        [HttpPost]
        public ActionResult Create(PhanLoai phanLoai)
        {
            try
            {
                phanLoai.BiDanh = XuLyDuLieu.LoaiBoDauTiengViet(phanLoai.TenPhanLoai);
                db.PhanLoais.Add(phanLoai);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                object noidung = "Thông tin phân loại không thành công!";
                return View("ThongBao", noidung);
            }

        }
        #endregion



        

        #region 4.8
        //4.8
        // GET: /PhanLoai/Edit
        [HttpGet]
        public ViewResult Edit(int id = 0)
        {
            PhanLoai phanLoai = db.PhanLoais.SingleOrDefault(p => p.PhanLoaiID == id);
            if (phanLoai == null)
            {
                object noidung = "Thông tin truy cập không hợp lệ!";
                return View("ThongBao", noidung); //phuong thuc 6/8

            }
            return View(phanLoai); //phuong thuc 3/8
        }

        //
        //POST: /PhanLoai/Create
        [HttpPost]
        public ActionResult Edit(PhanLoai phanLoai)
        {
            try
            {
                phanLoai.BiDanh = XuLyDuLieu.LoaiBoDauTiengViet(phanLoai.TenPhanLoai);
                db.Entry(phanLoai).State = EntityState.Modified;
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                object noidung = "Hiệu chỉnh phân loại không thành công!";
                return View("ThongBao", noidung);
            }

        }
        #endregion
    }
}
