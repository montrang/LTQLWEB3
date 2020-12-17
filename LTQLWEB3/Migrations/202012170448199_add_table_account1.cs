namespace LTQLWEB3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_table_account1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.accounts",
                c => new
                    {
                        MaTk = c.String(nullable: false, maxLength: 128),
                        TenTK = c.String(),
                        MaNV = c.String(),
                        Password = c.String(nullable: false, maxLength: 15),
                        Role_MaVaiTro = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaTk)
                .ForeignKey("dbo.Roles", t => t.Role_MaVaiTro, cascadeDelete: true)
                .Index(t => t.Role_MaVaiTro);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        MaVaiTro = c.Int(nullable: false, identity: true),
                        TenVaiTro = c.String(),
                    })
                .PrimaryKey(t => t.MaVaiTro);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.accounts", "Role_MaVaiTro", "dbo.Roles");
            DropIndex("dbo.accounts", new[] { "Role_MaVaiTro" });
            DropTable("dbo.Roles");
            DropTable("dbo.accounts");
        }
    }
}
