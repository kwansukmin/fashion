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
    public class BaiVietController : Controller
    {
        private FashionDbContext db = new FashionDbContext();

        //
        // GET: /BaiViet/

        public ActionResult Index()
        {
            return View(db.BaiViets.ToList());
        }

        //
        // GET: /BaiViet/Details/5

        public ActionResult Details(int id = 0)
        {
            BaiViet baiviet = db.BaiViets.Find(id);
            if (baiviet == null)
            {
                return HttpNotFound();
            }
            return View(baiviet);
        }

        //
        // GET: /BaiViet/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /BaiViet/Create

        [HttpPost]
        public ActionResult Create(BaiViet baiviet)
        {
            if (ModelState.IsValid)
            {
                db.BaiViets.Add(baiviet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(baiviet);
        }

        //
        // GET: /BaiViet/Edit/5

        public ActionResult Edit(int id = 0)
        {
            BaiViet baiviet = db.BaiViets.Find(id);
            if (baiviet == null)
            {
                return HttpNotFound();
            }
            return View(baiviet);
        }

        //
        // POST: /BaiViet/Edit/5

        [HttpPost]
        public ActionResult Edit(BaiViet baiviet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(baiviet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(baiviet);
        }

        //
        // GET: /BaiViet/Delete/5

        public ActionResult Delete(int id = 0)
        {
            BaiViet baiviet = db.BaiViets.Find(id);
            if (baiviet == null)
            {
                return HttpNotFound();
            }
            return View(baiviet);
        }

        //
        // POST: /BaiViet/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            BaiViet baiviet = db.BaiViets.Find(id);
            db.BaiViets.Remove(baiviet);
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