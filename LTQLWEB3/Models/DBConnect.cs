//namespace LTQLWEB3.Models
//{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;

    namespace LTQLWEB3.Models
    {
        public partial class DBConnect : DbContext
        {
            public virtual DbSet<KHACHHANG> KHACHHANGs { get; set; }
            public virtual DbSet<SANPHAM> SANPHAMs { get; set; }
            public virtual DbSet<NHOMSP> NHOMSPs { get; set; }
            public virtual DbSet<NHANVIEN> NHANVIENs { get; set; }
            public virtual DbSet<CHITIETHD> CHITIETHDs { get; set; }
            public virtual DbSet<HOADON> HOADONs { get; set; }
            public virtual DbSet<account> accounts { get; set; }
            public virtual DbSet<Role> Roles { get; set; }

            public DBConnect()
                : base("name=DBConnect")
            {
            }


            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
            }
        }
    }
//}
