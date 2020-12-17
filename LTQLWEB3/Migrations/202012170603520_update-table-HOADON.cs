namespace LTQLWEB3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetableHOADON : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HOADONs", "NgayBan", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HOADONs", "NgayBan", c => c.String());
        }
    }
}
