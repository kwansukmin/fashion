using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace FASHIONWS.Models
{
    [MetadataTypeAttribute(typeof(PhanLoai.PhanLoaiMetadata))]
    public partial class PhanLoai
    {
        internal sealed class PhanLoaiMetadata
        {
            private PhanLoaiMetadata() { }
            [Display(Name = "Phân loại ID")]
            public int PhanLoaiID;

            [Display(Name = "Tên phân loại")]
            public string TenPhanLoai;

            [Display(Name = "Bí danh")]
            public string BiDanh;

        }
    }

    //
    [MetadataTypeAttribute(typeof(SanPham.SanPhamMetadata))]
    public partial class SanPham
    {
        internal sealed class SanPhamMetadata
        {
            private SanPhamMetadata() { }
            [Display(Name = "Sản phẩm ID")]
            public int SanPhamID;

            [Display(Name = "Tên sản phẩm")]
            [Required(ErrorMessage = "{0} không được để trống")]
            [StringLength(150, MinimumLength = 2, ErrorMessage = "{0} tối đa là {1}, tối thiểu là {2} ký tự.")]
            //[MaxLength(150,ErrorMessage="{0} tối đa là {1} ký tự.")]
            //[MinLength(3, ErrorMessage = "{0} tối thiểu là {1} ký tự.")]
            public string TenSanPham;

            [Display(Name = "Mô tả")]
            [DataType(DataType.MultilineText)]
            public string MoTa;

            [Display(Name = "Đơn giá")]
            [Required(ErrorMessage = "{0} không được để trống")]
            [DisplayFormat(DataFormatString = "{0:#,##0vnđ}")]
            [Range(0, 9000000, ErrorMessage = "{0} phải từ {1} đến {2} đồng")]
            public int DonGia;


            [Display(Name = "Giá khuyến mãi")]
            [Required(ErrorMessage = "{0} không được để trống")]
            public int GiaKM;

            [Display(Name = "Hình")]
            public string Hinh;

            [Display(Name = "Nhóm sản phẩm")]
            [Required(ErrorMessage = "{0} không được để trống")]
            public int NhomspID;

            [Display(Name = "Ngày cập nhật")]
            [Required(ErrorMessage = "{0} không được để trống")]
            public System.DateTime NgayCapNhat;
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]

            [Display(Name = "Ngừng bán")]
            public bool NgungBan;

            [Display(Name = "Bí danh")]
            public string BiDanh;
        }
    }

    //
    [MetadataTypeAttribute(typeof(Nhomsp.NhomspMetadata))]
    public partial class Nhomsp
    {
        internal sealed class NhomspMetadata
        {
            private NhomspMetadata() { }
            [Display(Name = "Nhóm sản phẩm ID")]
            public int NhomspID;

            [Display(Name = "Tên nhóm sản phẩm")]
            [Required(ErrorMessage = "{0} không được để trống")] //Cài kiểm tra dữ liệu
            public string TenNhomsp;

            [Display(Name = "Phân loại ID")]
            [Required(ErrorMessage = "{0} không được để trống")]
            public int PhanLoaiID;

            [ScaffoldColumn(false)] //Không cho hiển thị bí danh
            [Display(Name = "Bí danh")]
            public string BiDanh;
        }
    }

    //
    [MetadataTypeAttribute(typeof(HopThu.HopThuMetadata))]
    public partial class HopThu
    {
        internal sealed class HopThuMetadata
        {
            private HopThuMetadata() { }
            [Display(Name = "Hộp thư ID")]
            public int HopThuID;

            [Display(Name = "Họ tên")]
            public string Hoten;

            [Display(Name = "Nghề nghiệp")]
            public string NgheNghiep;

            [Display(Name = "Địa chỉ")]
            public string DiaChi;

            [Display(Name = "Email")]
            public string Email;

            [Display(Name = "Nội dung")]
            public string NoiDung;

            [Display(Name = "Hình")]
            public string Hinh;

            [Display(Name = "User ID")]
            public Nullable<int> UserId;

            [Display(Name = "Ngày cập nhật")]
            public System.DateTime NgayCapNhat;
        }
    }
    
    //
    [MetadataTypeAttribute(typeof(DatHangCT.DatHangCTMetada))]
    public partial class DatHangCT
    {
        internal sealed class DatHangCTMetada
        {
            private DatHangCTMetada() { }
            [Display(Name = "Đặt hàng ID")]
            public int DatHangID;

            [Display(Name = "Sản phẩm ID")]
            public int SanPhamID;

            [Display(Name = "Số lượng")]
            public int SoLuong;

            [Display(Name = "Đơn giá")]
            public int DonGia;

            [Display(Name = "Thành tiền")]
            public int ThanhTien;

        }
    }

    //
    [MetadataTypeAttribute(typeof(DatHang.DatHangMetaData))]
    public partial class DatHang
    {
        internal sealed class DatHangMetaData
        {
            private DatHangMetaData() { }
            [Display(Name = "Đặt hàng ID")]
            public int DatHangID;

            [Display(Name = "Họ tên")]
            public string Hoten;

            [Display(Name = "Điện thoại")]
            public string DienThoai;

            [Display(Name = "Địa chỉ")]
            public string DiaChi;

            [Display(Name = "Email")]
            public string Email;

            [Display(Name = "Ngày đặt")]
            public System.DateTime NgayDat;

            [Display(Name = "Trị giá")]
            public int TriGia;

            [Display(Name = "Đã giao")]
            public bool DaGiao;

            [Display(Name = "Ngày giao")]
            public Nullable<System.DateTime> NgayGiao;

            [Display(Name = "Ghi chú")]
            public string GhiChu;
        }
    }

    //
    [MetadataTypeAttribute(typeof(BaiViet.BaiVietMetadata))]
    public partial class BaiViet
    {
        internal sealed class BaiVietMetadata
        {
            private BaiVietMetadata() { }
            [Display(Name = "Bài viết ID")]
            public int BaiVietID;

            [Display(Name = "Tựa bài viết")]
            public string TuaBaiViet;

            [Display(Name = "Nội dung")]
            public string NoiDung;

            [Display(Name = "Thể loại")]
            public int TheLoai;

            [Display(Name = "Hinh đại diện")]
            public string HinhDaiDien;

            [Display(Name = "Ngày cập nhật")]
            public System.DateTime NgayCapNhat;

            [Display(Name = "User ID")]
            public Nullable<int> UserId;

            [Display(Name = "Bí danh")]
            public string BiDanh;

        }
    }

}