using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LTQLWEB3.Models
{
    public class SANPHAM
    {
        [Key]
        [Display(Name = "Mã sản phẩm")]
        public string MaSP { get; set; }
        [Display(Name = "Tên sản phẩm")]
        public string TenSP { get; set; }
        [Display(Name = "Nhóm sản phẩm")]
        public string NHOMSP_MaNhomSP { get; set; }
        [ForeignKey("NHOMSP_MaNhomSP")]
        public NHOMSP NHOMSP { get; set; }
        [Display(Name = "Số lượng")]
        public string SoLuong { get; set; }
        [Display(Name = "Đơn vị tính")]
        public string DVT { get; set; }
        [Display(Name = "Ảnh")]
        public string Anh { get; set; }
        [Display(Name = "Đơn giá nhập")]
        public string DonGiaNhap { get; set; }
        [Display(Name = "Đơn giá bán")]
        public string DonGiaBan { get; set; }
        [Display(Name = "Hạn sử dụng")]
        public string HSD { get; set; }
        [Display(Name = "Ghi chú")]
        public string GhiChu { get; set; }
        public virtual ICollection<CHITIETHD> CHITIETHDs { get; set; }

    }
}