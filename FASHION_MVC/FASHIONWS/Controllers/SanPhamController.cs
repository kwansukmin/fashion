using FASHIONWS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FASHIONWS.Controllers
{
    public class SanPhamController : Controller
    {
        private FashionDbContext db = new FashionDbContext();

        #region Phần 1
        //[ChildActionOnly]
        public PartialViewResult _SanPhamMoiPartial()
        {// Được gọi từ view Home/Index
            ViewBag.Message = "Sản Phẩm Mới";
            List<SanPham> dsSanPham = db.SanPhams
                                        .OrderByDescending(p => p.NgayCapNhat)
                                        .Take(20).ToList();
            return PartialView(dsSanPham); //Phuong thuc 2 - Truyen du lieu qua tham so Model- Partial view cung ten Action
        }

        

        //5.6
        //
        public PartialViewResult _SanPhamHotPartial()
        {
            ViewBag.Message = "Thời trang cực hot!!!";
            IList<SanPham> dsSanPham = db.SanPhams.Include("DatHangCTs")
                                      .OrderByDescending(p => p.DatHangCTs.Sum(x => x.SoLuong)).Take(10).ToList();

            return PartialView(dsSanPham);

        }

        //5.9
        //
        public PartialViewResult _TuiXachMoiPartial()
        {
            ViewBag.Message = "Thời trang túi xách";
            List<SanPham> dsSanPham = db.SanPhams.Include("Nhomsp").Where(p => p.Nhomsp.TenNhomsp == "Túi xách").Take(10).ToList();
            return PartialView(dsSanPham);
        }

        //5.11
        // GET: /SanPham/ThongTin/217
        public ViewResult ThongTin(int id = 0)
        {
            SanPham sanPham = db.SanPhams.Include("nhomsp").SingleOrDefault(p => p.SanPhamID == id);
            if (sanPham == null)
            {
                object noidung = "Thông tin truy cập không hợp lệ!";
                return View("ThongBao", noidung); //phuong thuc 6/8

            }
            ViewBag.Message = "Sản phẩm - " + sanPham.TenSanPham;
            return View(sanPham);
        }
        #endregion

        //
        // GET: /SanPham/

        public ActionResult Index()
        {
            var sanphams = db.SanPhams.Include(s => s.Nhomsp);
            ViewBag.Title = "Index";
            ViewBag.Message = "Sản Phẩm";
            return View(sanphams.ToList());
        }

        //
        // GET: /SanPham/Details/5

        public ActionResult Details(int id = 0)
        {
            SanPham sanpham = db.SanPhams.Find(id);
            if (sanpham == null)
            {
                object noidung = "Truy cập không hợp lệ!";
                return View("ThongBao", noidung);
            }
            ViewBag.Title = "Details";
            ViewBag.Message = "Xem Chi Tiết - Sản Phẩm";
            return View(sanpham);
        }

        //
        // GET: /SanPham/Create

        public ActionResult Create()
        {
            ViewBag.Title = "Create";
            ViewBag.Message = "Thêm - Sản Phẩm";
            ViewBag.NhomspID = new SelectList(db.Nhomsps, "NhomspID", "TenNhomsp");
            return View();
        }

        //
        // POST: /SanPham/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SanPham sanpham)
        {
            int d = db.SanPhams.Count(p => p.TenSanPham == sanpham.TenSanPham.Trim());
            if (d > 0) ModelState.AddModelError("TenSanPham", "Tên sản phẩm bị trùng!");

            if (ModelState.IsValid)
            {
                try
                {
                    sanpham.BiDanh = XuLyDuLieu.LoaiBoDauTiengViet(sanpham.TenSanPham);
                    sanpham.NgayCapNhat = DateTime.Today;
                    db.SanPhams.Add(sanpham);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ViewBag.Error = "Ghi không thành công!" + ex.Message;
                }
                
            }

            ViewBag.Title = "Create";
            ViewBag.Message = "Thêm - Sản Phẩm";
            ViewBag.NhomspID = new SelectList(db.Nhomsps, "NhomspID", "TenNhomsp", sanpham.NhomspID);
            return View(sanpham);
        }

        //
        // GET: /SanPham/Edit/5

        public ActionResult Edit(int id = 0)
        {
            SanPham sanpham = db.SanPhams.Find(id);
            if (sanpham == null)
            {
                object noidung = "Truy cập không hợp lệ!";
                return View("ThongBao", noidung);
            }
            ViewBag.Title = "Edit";
            ViewBag.Message = "Hiệu chỉnh - Sản Phẩm";
            ViewBag.NhomspID = new SelectList(db.Nhomsps, "NhomspID", "TenNhomsp", sanpham.NhomspID);
            return View(sanpham);
        }

        //
        // POST: /SanPham/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SanPham sanpham)
        {
            int d = db.SanPhams.Count(p => (p.SanPhamID != sanpham.SanPhamID && p.TenSanPham == sanpham.TenSanPham.Trim()));
            if (d > 0) ModelState.AddModelError("TenSanPham", "Tên sản phẩm bị trùng!");

            if (ModelState.IsValid)
            {
                try
                {
                    sanpham.BiDanh = XuLyDuLieu.LoaiBoDauTiengViet(sanpham.TenSanPham);
                    db.Entry(sanpham).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ViewBag.Error = "Ghi không thành công!" + ex.Message;
                }
                
            }
            ViewBag.Title = "Edit";
            ViewBag.Message = "Hiệu chỉnh - Sản Phẩm";
            ViewBag.NhomspID = new SelectList(db.Nhomsps, "NhomspID", "TenNhomsp", sanpham.NhomspID);
            return View(sanpham);
        }

        //
        // GET: /SanPham/Delete/5

        public ActionResult Delete(int id = 0)
        {
            SanPham sanpham = db.SanPhams.Find(id);
            if (sanpham == null)
            {
                object noidung = "Truy cập không hợp lệ!";
                return View("ThongBao", noidung);
            }
            ViewBag.Title = "Delete";
            ViewBag.Message = "Xóa - Sản Phẩm";
            return View(sanpham);
        }

        //
        // POST: /SanPham/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                SanPham sanpham = db.SanPhams.Find(id);
                db.SanPhams.Remove(sanpham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                object noidung = "Hủy không thành công!";
                return View("ThongBao", noidung);
            }
            
        }
        #region bai 7.13 Upload Hinh
        //
        // GET: /Sach/UploadPhoto/
        public ActionResult UpLoadPhoto(int id = 0)
        {
            SanPham sanpham = db.SanPhams.SingleOrDefault(p => p.SanPhamID == id);
            if (sanpham == null)
            {
                object noidung = "Thông tin truy cập không tồn tại!";
                return View("ThongBao", noidung);
            }
            ViewBag.Title = "UpLoadPhoto - Sản phẩm";
            ViewBag.Message = string.Format("Upload hình cho sản phẩm - (<i>{0}<i>)", sanpham.TenSanPham);
            return View(id);
        }
        //
        //POST: /Sach/UploadPhoto/3
        [HttpPost]
        public ActionResult UploadPhoto(int id, HttpPostedFileBase file)
        {
            SanPham sanpham = db.SanPhams.SingleOrDefault(p => p.SanPhamID == id);
            if (file != null && file.ContentLength > 0)
            {
                try
                {
                    //Neu co chon file thi doi ten hinh theo ten SanphamID
                    string fileName = sanpham.SanPhamID.ToString() + Path.GetExtension(file.FileName);

                    //upload hinh len Server
                    string path = Server.MapPath("~/Photos/SanPham/" + fileName);
                    file.SaveAs(path);

                    //cap nhan lai thong tin CSDL
                    sanpham.Hinh = fileName;
                    db.Entry(sanpham).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch
                {
                    ViewBag.Error = "Upload không thành công!";
                }
            }
            ViewBag.Title = "UpLoadPhoto - Sản phẩm";
            ViewBag.Message = string.Format("Upload hình cho sản phẩm - (<i>{0}<i>)", sanpham.TenSanPham);
            return View(id);
        }
        #endregion
        #region Bai Tap Tren Lop
        //
        public ActionResult List()
        {
            ViewBag.Message = "Danh Sách Hình";
            List<SanPham> dsSanPham = db.SanPhams.OrderByDescending(p => p.NgayCapNhat).Take(10).ToList();
            return View(dsSanPham);
        }
        #endregion
        #region Bai 8.1 Theo Loai
        //
        // GET: /SanPham/TheoLoai/3
        public ActionResult TheoLoai(int id=0,string name="")
        {
            
            List<SanPham> dsSanPham = db.SanPhams.Where(p =>p.Nhomsp.PhanLoaiID == id).OrderByDescending(p=>p.NgayCapNhat).ToList();
            if (dsSanPham.Count == 0)
            {
                object noidung = "Thông tin truy cập không tồn tại!";
                return View("ThongBao", noidung);
            }
            PhanLoai phanLoai = db.PhanLoais.SingleOrDefault(p => p.PhanLoaiID == id);
            
            ViewBag.Message = "Sản phẩm thuộc phân loại - " + phanLoai.TenPhanLoai;
            ViewBag.Title = "Sản Phẩm";
            return View("DanhSach",dsSanPham);
        }
        #endregion
        #region Bai 8.1 Theo Nhom
        //
        // GET: /SanPham/TheoNhom/3
        public ActionResult TheoNhom(int id = 0, string name = "")
        {

            List<SanPham> dsSanPham = db.SanPhams.Where(p => p.NhomspID == id).OrderByDescending(p => p.NgayCapNhat).ToList();
            if (dsSanPham.Count == 0)
            {
                object noidung = "Thông tin truy cập không tồn tại!";
                return View("ThongBao", noidung);
            }
            Nhomsp nhomsp = db.Nhomsps.SingleOrDefault(p => p.NhomspID == id);

            ViewBag.Message = "Sản phẩm thuộc nhóm - " + nhomsp.TenNhomsp;
            ViewBag.Title = "Sản Phẩm";
            return View("DanhSach", dsSanPham);
        }
        #endregion

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}