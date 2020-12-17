namespace LTQLWEB3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_table_account3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.accounts", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.accounts", "Password", c => c.String(nullable: false, maxLength: 15));
        }
    }
}
