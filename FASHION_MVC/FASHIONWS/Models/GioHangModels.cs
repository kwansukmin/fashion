using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FASHIONWS.Models;

namespace FASHIONWS.Models
{
    // Bài tập 8.3
    public class HangHoa
    {
        private int giaKhuyenMai = 0;

        public int HangHoaID { get; set; }
        public string TenHang { get; set; }
        public int DonGia { get; set; }
        public int SoLuong { get; set; }
        public string Hinh { get; set; }
        public int Thanhtien
        {
            get { return SoLuong * (DonGia - giaKhuyenMai); }
        }
       
        public HangHoa(int id)
        {
            FashionDbContext db = new FashionDbContext();
            SanPham sp = db.SanPhams.SingleOrDefault(p=>p.SanPhamID==id);
            
            HangHoaID = sp.SanPhamID;
            TenHang = sp.TenSanPham;
            DonGia = sp.DonGia;
            SoLuong = 1;
            Hinh = sp.Hinh;

            giaKhuyenMai = sp.GiaKM;
        }


    }

   
}