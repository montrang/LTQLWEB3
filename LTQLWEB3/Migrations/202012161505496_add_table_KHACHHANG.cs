namespace LTQLWEB3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_table_KHACHHANG : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.KHACHHANGs", "role");
            DropColumn("dbo.KHACHHANGs", "PassWord");
        }
        
        public override void Down()
        {
            AddColumn("dbo.KHACHHANGs", "PassWord", c => c.String(nullable: false));
            AddColumn("dbo.KHACHHANGs", "role", c => c.String());
        }
    }
}
