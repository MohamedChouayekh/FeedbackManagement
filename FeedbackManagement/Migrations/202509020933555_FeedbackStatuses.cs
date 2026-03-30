namespace FeedbackManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FeedbackStatuses : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FeedbackStatus", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FeedbackStatus", "Name", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
