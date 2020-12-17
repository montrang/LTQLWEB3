using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LTQLWEB3.Models
{
    public class HOADON
    {
        [Key]
        [Display(Name = "Mã hóa đơn")]
        public string MaHD { get; set; }
        [Display(Name = "Nhân viên")]
        public string NHANVIEN_MaNV { get; set; }
        [ForeignKey("NHANVIEN_MaNV")]
        public NHANVIEN NHANVIEN { get; set; }
        [Display(Name = "Ngày bán")]
        public DateTime NgayBan { get; set; }
        [Display(Name = "Khách hàng")]
        public string KHACHHANG_MaKH { get; set; }
        [ForeignKey("KHACHHANG_MaKH")]
        public KHACHHANG KHACHHANG { get; set; }
        [Display(Name = "Tổng tiền")]
        public string TongTien { get; set; }
        public virtual ICollection<CHITIETHD> CHITIETHDs { get; set; }
    }
}