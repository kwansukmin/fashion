using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using FASHIONWS.Models;

namespace FASHIONWS.Controllers
{
    public class NhapMonController : Controller
    {

        //
        // GET: /NhapMon/ChaoMung
        public string ChaoMung()
        {
            string cauChao = "CHÀO MỪNG BẠN ĐẾN VỚI ASP.NET MVC";
            return cauChao;
        }
        
        
        //
        // GET: /NhapMon/Chao/Tôi

        public string Chao(string name)
        {
            string cauChao = string.Format("CHÀO MỪNG BẠN {0} ĐẾN VỚI ASP.NET MVC", name);
            return cauChao;
        }

        //
        //GET: /NhapMon/XinChao
        public ViewResult XinChao()
        {
            return View("MVCChao");
        }

        //
        //GET: /NhapMon/XemDanhSach
        public ViewResult XemDanhSach()
        {
            FashionDbContext db = new FashionDbContext();
            List<PhanLoai> dsPL = db.PhanLoais.ToList();

            return View(dsPL);
        }
        //
        //GET: /NhapMon/XemDanhSachSP
        public ViewResult XemDanhSachSP()
        {
            FashionDbContext db = new FashionDbContext();
            List<SanPham> dsSP = db.SanPhams.OrderByDescending(p => p.NgayCapNhat).Take(20).ToList();

            return View(dsSP);
        }
        
    }
}
