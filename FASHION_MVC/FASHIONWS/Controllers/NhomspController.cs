using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FASHIONWS.Models;

namespace FASHIONWS.Controllers
{
    public class NhomspController : Controller
    {
        private FashionDbContext db = new FashionDbContext();

        //
        // GET: /Nhomsp/

        public ActionResult Index()
        {
            var nhomsps = db.Nhomsps.Include(n => n.PhanLoai);
            return View(nhomsps.ToList());
        }

        //
        // GET: /Nhomsp/Details/5

        public ActionResult Details(int id = 0)
        {
            Nhomsp nhomsp = db.Nhomsps.Include("PhanLoai").SingleOrDefault(p=>p.NhomspID==id);
            if (nhomsp == null)
            {
                object noidung = "Dữ liệu truy cập không hợp lệ";
                return View("ThongBao", noidung);
            }
            return View(nhomsp);
        }

        //
        // GET: /Nhomsp/Create

        public ActionResult Create()
        {
            ViewBag.PhanLoaiID = new SelectList(db.PhanLoais, "PhanLoaiID", "TenPhanLoai");
            return View();
        }

        //
        // POST: /Nhomsp/Create

        [HttpPost]
        public ActionResult Create(Nhomsp nhomsp)
        {
            if (ModelState.IsValid)
            {//Bổ sung loại bỏ dấu tiếng việt cho Bí Danh
                nhomsp.BiDanh = XuLyDuLieu.LoaiBoDauTiengViet(nhomsp.TenNhomsp);
                db.Nhomsps.Add(nhomsp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PhanLoaiID = new SelectList(db.PhanLoais, "PhanLoaiID", "TenPhanLoai", nhomsp.PhanLoaiID);
            return View(nhomsp);
        }

        //
        // GET: /Nhomsp/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Nhomsp nhomsp = db.Nhomsps.Find(id);
            if (nhomsp == null)
            {
                return HttpNotFound();
            }
            ViewBag.PhanLoaiID = new SelectList(db.PhanLoais, "PhanLoaiID", "TenPhanLoai", nhomsp.PhanLoaiID);
            return View(nhomsp);
        }

        //
        // POST: /Nhomsp/Edit/5

        [HttpPost]
        public ActionResult Edit(Nhomsp nhomsp)
        {
            if (ModelState.IsValid)
            {
                nhomsp.BiDanh = XuLyDuLieu.LoaiBoDauTiengViet(nhomsp.TenNhomsp);
                db.Entry(nhomsp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PhanLoaiID = new SelectList(db.PhanLoais, "PhanLoaiID", "TenPhanLoai", nhomsp.PhanLoaiID);
            return View(nhomsp);
        }

        //
        // GET: /Nhomsp/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Nhomsp nhomsp = db.Nhomsps.Find(id);
            if (nhomsp == null)
            {
                object noidung = "Dữ liệu không hợp lệ!";
                return View("ThongBao", noidung);
            }
            return View(nhomsp);
        }

        //
        // POST: /Nhomsp/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Nhomsp nhomsp = db.Nhomsps.Find(id);
            db.Nhomsps.Remove(nhomsp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}