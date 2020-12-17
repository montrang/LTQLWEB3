namespace LTQLWEB3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_table_account2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.accounts", "NHANVIEN_MaNV", c => c.String(maxLength: 128));
            CreateIndex("dbo.accounts", "NHANVIEN_MaNV");
            AddForeignKey("dbo.accounts", "NHANVIEN_MaNV", "dbo.NHANVIENs", "MaNV");
            DropColumn("dbo.accounts", "MaNV");
        }
        
        public override void Down()
        {
            AddColumn("dbo.accounts", "MaNV", c => c.String());
            DropForeignKey("dbo.accounts", "NHANVIEN_MaNV", "dbo.NHANVIENs");
            DropIndex("dbo.accounts", new[] { "NHANVIEN_MaNV" });
            DropColumn("dbo.accounts", "NHANVIEN_MaNV");
        }
    }
}
