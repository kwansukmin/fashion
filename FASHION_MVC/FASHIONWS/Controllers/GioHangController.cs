using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FASHIONWS.Models;

namespace FASHIONWS.Controllers
{
    public partial class GioHangController : Controller
    {
        FashionDbContext db = new FashionDbContext();
              

        #region Bài tập 8.3
        [HttpPost]
        public ActionResult Add(int SanPhamID, string returnUrl)
        {
            List<HangHoa> giohang = HttpContext.Session["GioHang"] as List<HangHoa>; //Ten section GioHang có thể đặt khác
            if (giohang == null)
            {
                giohang = new List<HangHoa>();
                HttpContext.Session["GioHang"] = giohang;
            }
            HangHoa entity = giohang.Find(p => p.HangHoaID == SanPhamID);
            if (entity == null)
            {
                entity = new HangHoa(SanPhamID);
                giohang.Add(entity);
            }
            else
            {
                entity.SoLuong += 1;
            }
            if (Url.IsLocalUrl(returnUrl))
            {//Trở về đúng trang nd đang chọn mua
                return Redirect(returnUrl);
            }
           
            return RedirectToAction("Index", "Home");
           
        }
        #endregion

        #region  Bài tập 8.5
        //
        // GET: /GioHang/
        public ActionResult Index()
        {
            ViewBag.Title = "Giỏ hàng";
            List<HangHoa> giohang = HttpContext.Session["GioHang"] as List<HangHoa>;
            if (giohang == null || giohang.Count==0)
            {
                ViewBag.Message = "Giỏ hàng của bạn đang trống!";
                return View();
            }
            ViewBag.Message = "Giỏ hàng của bạn";
            ViewBag.TongTriGia = giohang.Sum(p => p.Thanhtien).ToString("#,##0VNĐ");
            return View(giohang);//truyen du lieu qua tham sao model
        }      
        [HttpPost]
        public ActionResult Edit(int HangHoaID, int SoLuong)
        {
            List<HangHoa> giohang = HttpContext.Session["GioHang"] as List<HangHoa>;
            HangHoa item = giohang.Find(p => p.HangHoaID == HangHoaID);
            item.SoLuong = SoLuong;
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Delete(int HangHoaID)
        {
            List<HangHoa> giohang = HttpContext.Session["GioHang"] as List<HangHoa>;
            giohang.RemoveAll(p => p.HangHoaID == HangHoaID);
            return RedirectToAction("Index");
        }
        #endregion

        #region Bài tập 8.6

       [HttpGet]
       public ActionResult DatMua()
       {
           List<HangHoa> giohang = HttpContext.Session["GioHang"] as List<HangHoa>;

           if (giohang==null || giohang.Count == 0)
           {//Giỏ hàng trống!
               return RedirectToAction("Index");
           }
           ViewBag.Title = "Đặt hàng";
           ViewBag.Message = "Nhập thông tin đặt hàng";
           return View();
       }
       [HttpPost]
       public ActionResult DatMua(DatHang dh)
       {// Gợi ý hv bổ sung Transactions
           
           List<HangHoa> giohang = HttpContext.Session["GioHang"] as List<HangHoa>;
           if (giohang == null || giohang.Count == 0)
           {
               return RedirectToAction("Index","Home");
           }
           if (ModelState.IsValid)
           {
               try
               {
                   //1. Cập nhật DatHang        
                   dh.NgayDat = DateTime.Today;
                   dh.DaGiao = false;
                   dh.TriGia = giohang.Sum(p => p.Thanhtien);
                   db.DatHangs.Add(dh);
                   db.SaveChanges();
                   //2. Cập nhật DatHangCT
                  
                   foreach (HangHoa item in giohang)
                   {
                       DatHangCT ct = new DatHangCT
                       {
                           DatHangID = dh.DatHangID,
                           SanPhamID = item.HangHoaID,
                           SoLuong = item.SoLuong,
                           DonGia = item.DonGia,
                           ThanhTien = item.Thanhtien
                       };
                       db.DatHangCTs.Add(ct);
                   }
                   db.SaveChanges();
                   giohang.Clear();

                   ViewBag.Title = "Thông báo";
                   ViewBag.Message = "Thông báo";
                   object noiDung = "Đặt hàng thành công!<br/>Cám ơn bạn đã đặt mua hàng của chúng tôi!";
                   return View("ThongBao", noiDung);
               }
               catch (Exception ex)
               {
                   return View("Error", "Phát sinh đơn đặt hàng không thành công!<br/>" + ex.Message);
               }
           }
           ViewBag.Title = "Đặt hàng";
           ViewBag.Message = "Nhập thông tin đặt hàng";
           return View(dh);
       }
        #endregion

       protected override void Dispose(bool disposing)
       {
           db.Dispose();
           base.Dispose(disposing);
       }
    }
}
