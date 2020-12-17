using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LTQLWEB3.Models
{
    public class NHANVIEN
    {
        [Key]
        [Display(Name = "Mã nhân viên")]
        public string MaNV { get; set; }
        [Required, MaxLength(20)]
        [Display(Name = "Tên nhân viên")]
        public string TenNV { get; set; }
        [Display(Name = "Ngày sinh")]
        public string NgaySinh { get; set; }
        [Display(Name = "Giới tính")]
        public string GioiTinh { get; set; }
        [Display(Name = "Số điện thoại")]
        public string SoDT { get; set; }
        [Display(Name = "Địa chỉ")]
        public string DiaChi { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        public ICollection<HOADON> HOADONs { get; set; }
        public ICollection<account> accounts { get; set; }

    }
}