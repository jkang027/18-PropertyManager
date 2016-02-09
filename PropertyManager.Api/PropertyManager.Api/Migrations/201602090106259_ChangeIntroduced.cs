namespace PropertyManager.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeIntroduced : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.WorkOrders", "ClosedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WorkOrders", "ClosedDate", c => c.DateTime(nullable: false));
        }
    }
}
