namespace LTQLWEB3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_table_KHACHHANG : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KHACHHANGs", "PassWord", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.KHACHHANGs", "PassWord");
        }
    }
}
