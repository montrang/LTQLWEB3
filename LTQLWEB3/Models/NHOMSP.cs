using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LTQLWEB3.Models
{
    public class NHOMSP
    {
        [Key]
        [Display(Name = "Mã nhóm sản phẩm")]
        public string MaNhomSP { get; set; }
        [Required, MaxLength(15)]
        [Display(Name = "Tên nhóm sản phẩm")]
        public string TenNhomSP { get; set; }
        public virtual ICollection<SANPHAM> SANPHAMs { get; set; }
    }
}