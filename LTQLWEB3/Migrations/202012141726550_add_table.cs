namespace LTQLWEB3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CHITIETHDs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        HOADON_MaHD = c.String(maxLength: 128),
                        SANPHAM_MaSP = c.String(maxLength: 128),
                        SoLuong = c.String(),
                        DonGia = c.String(),
                        GiamGia = c.String(),
                        ThanhTien = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.HOADONs", t => t.HOADON_MaHD)
                .ForeignKey("dbo.SANPHAMs", t => t.SANPHAM_MaSP)
                .Index(t => t.HOADON_MaHD)
                .Index(t => t.SANPHAM_MaSP);
            
            CreateTable(
                "dbo.HOADONs",
                c => new
                    {
                        MaHD = c.String(nullable: false, maxLength: 128),
                        NHANVIEN_MaNV = c.String(maxLength: 128),
                        NgayBan = c.String(),
                        KHACHHANG_MaKH = c.String(maxLength: 128),
                        TongTien = c.String(),
                    })
                .PrimaryKey(t => t.MaHD)
                .ForeignKey("dbo.KHACHHANGs", t => t.KHACHHANG_MaKH)
                .ForeignKey("dbo.NHANVIENs", t => t.NHANVIEN_MaNV)
                .Index(t => t.NHANVIEN_MaNV)
                .Index(t => t.KHACHHANG_MaKH);
            
            CreateTable(
                "dbo.KHACHHANGs",
                c => new
                    {
                        MaKH = c.String(nullable: false, maxLength: 128),
                        TenKH = c.String(nullable: false, maxLength: 20),
                        DiaChi = c.String(),
                        SoDT = c.String(),
                        Email = c.String(nullable: false),
                        role = c.String(),
                        PassWord = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.MaKH);
            
            CreateTable(
                "dbo.NHANVIENs",
                c => new
                    {
                        MaNV = c.String(nullable: false, maxLength: 128),
                        TenNV = c.String(nullable: false, maxLength: 20),
                        NgaySinh = c.String(),
                        GioiTinh = c.String(),
                        SoDT = c.String(),
                        DiaChi = c.String(),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.MaNV);
            
            CreateTable(
                "dbo.SANPHAMs",
                c => new
                    {
                        MaSP = c.String(nullable: false, maxLength: 128),
                        TenSP = c.String(),
                        NHOMSP_MaNhomSP = c.String(maxLength: 128),
                        SoLuong = c.String(),
                        DVT = c.String(),
                        Anh = c.String(),
                        DonGiaNhap = c.String(),
                        DonGiaBan = c.String(),
                        HSD = c.String(),
                        GhiChu = c.String(),
                    })
                .PrimaryKey(t => t.MaSP)
                .ForeignKey("dbo.NHOMSPs", t => t.NHOMSP_MaNhomSP)
                .Index(t => t.NHOMSP_MaNhomSP);
            
            CreateTable(
                "dbo.NHOMSPs",
                c => new
                    {
                        MaNhomSP = c.String(nullable: false, maxLength: 128),
                        TenNhomSP = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => t.MaNhomSP);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SANPHAMs", "NHOMSP_MaNhomSP", "dbo.NHOMSPs");
            DropForeignKey("dbo.CHITIETHDs", "SANPHAM_MaSP", "dbo.SANPHAMs");
            DropForeignKey("dbo.HOADONs", "NHANVIEN_MaNV", "dbo.NHANVIENs");
            DropForeignKey("dbo.HOADONs", "KHACHHANG_MaKH", "dbo.KHACHHANGs");
            DropForeignKey("dbo.CHITIETHDs", "HOADON_MaHD", "dbo.HOADONs");
            DropIndex("dbo.SANPHAMs", new[] { "NHOMSP_MaNhomSP" });
            DropIndex("dbo.HOADONs", new[] { "KHACHHANG_MaKH" });
            DropIndex("dbo.HOADONs", new[] { "NHANVIEN_MaNV" });
            DropIndex("dbo.CHITIETHDs", new[] { "SANPHAM_MaSP" });
            DropIndex("dbo.CHITIETHDs", new[] { "HOADON_MaHD" });
            DropTable("dbo.NHOMSPs");
            DropTable("dbo.SANPHAMs");
            DropTable("dbo.NHANVIENs");
            DropTable("dbo.KHACHHANGs");
            DropTable("dbo.HOADONs");
            DropTable("dbo.CHITIETHDs");
        }
    }
}
