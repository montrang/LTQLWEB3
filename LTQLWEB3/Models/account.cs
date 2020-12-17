using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LTQLWEB3.Models
{
    public class account
    {
        [Key]
        [Display(Name = "Mã tài khoản")]
        public string MaTk { get; set; }
        [Display(Name = "Tên tài khoản")]
        public string TenTK { get; set; }
        [Display(Name = "Tên nhân viên")]
        public string NHANVIEN_MaNV { get; set; }
        [ForeignKey("NHANVIEN_MaNV")]
        public virtual NHANVIEN NHANVIEN { get; set; }

        //[Required, MinLength(6), MaxLength(15)]
        [Required]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }
        [Display(Name = "Vai trò")]
        public int Role_MaVaiTro { get; set; }
        [ForeignKey("Role_MaVaiTro")]
        public virtual Role Role { get; set; }
    }
}