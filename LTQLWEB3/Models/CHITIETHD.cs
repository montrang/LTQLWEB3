using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LTQLWEB3.Models
{
    public class CHITIETHD
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Hóa đơn")]
        public string HOADON_MaHD { get; set; }
        [ForeignKey("HOADON_MaHD")]
        public HOADON HOADON { get; set; }
        [Display(Name = "Sản phẩm")]
        public string SANPHAM_MaSP { get; set; }
        [ForeignKey("SANPHAM_MaSP")]
        public SANPHAM SANPHAM { get; set; }
        [Display(Name = "Số lượng")]
        public string SoLuong { get; set; }
        [Display(Name = "Đơn giá")]
        public string DonGia { get; set; }
        [Display(Name = "Giảm giá")]
        public string GiamGia { get; set; }
        [Display(Name = "Thành tiền")]
        public string ThanhTien { get; set; }
    }
}