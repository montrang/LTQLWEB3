using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LTQLWEB3.Models
{
    public class KHACHHANG
    {
        [Key]
        [Display(Name = "Mã khách hàng")]
        public string MaKH { get; set; }
        [Required, MaxLength(20)]
        [Display(Name = "Tên khách hàng")]
        public string TenKH { get; set; }
        [Display(Name = "Địa chỉ")]
        public string DiaChi { get; set; }
        [Display(Name = "Số điện thoại")]
        public string SoDT { get; set; }
        [Required, EmailAddress]

        public string Email { get; set; }
        [Display(Name = "Mật khẩu")]
        public string PassWord { get; set; }
        [NotMapped]
        [Required]
        [System.ComponentModel.DataAnnotations.Compare("PassWord")]
        public string confirm_password { get; set; }
        public virtual ICollection<HOADON> HOADONs { get; set; }
    }
}