using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LTQLWEB3.Models
{
    public class Role
    {
        [Key]
        [Display(Name = "Mã vai trò")]
        public int MaVaiTro { get; set; }
        [Display(Name = "Tên vai trò")]
        public string TenVaiTro { get; set; }
        public virtual ICollection<account> accounts { get; set; }

    }
}