namespace FeedbackManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateFeedbackTables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FeedbackForm", "ContactId", "dbo.Contact");
            DropIndex("dbo.FeedbackForm", new[] { "ContactId" });
            CreateTable(
                "dbo.Feedback",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LocationId = c.Int(nullable: false),
                        ContactId = c.Int(nullable: false),
                        Score = c.Int(nullable: false),
                        Comment = c.String(nullable: false, maxLength: 500),
                        StatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contact", t => t.ContactId, cascadeDelete: true)
                .ForeignKey("dbo.Location", t => t.LocationId, cascadeDelete: true)
                .ForeignKey("dbo.FeedbackStatus", t => t.StatusId, cascadeDelete: true)
                .Index(t => t.LocationId)
                .Index(t => t.ContactId)
                .Index(t => t.StatusId);
            
            DropTable("dbo.FeedbackForm");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.FeedbackForm",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Location = c.String(nullable: false, maxLength: 200),
                        ContactId = c.Int(nullable: false),
                        Score = c.Int(nullable: false),
                        Comment = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Feedback", "StatusId", "dbo.FeedbackStatus");
            DropForeignKey("dbo.Feedback", "LocationId", "dbo.Location");
            DropForeignKey("dbo.Feedback", "ContactId", "dbo.Contact");
            DropIndex("dbo.Feedback", new[] { "StatusId" });
            DropIndex("dbo.Feedback", new[] { "ContactId" });
            DropIndex("dbo.Feedback", new[] { "LocationId" });
            DropTable("dbo.Feedback");
            CreateIndex("dbo.FeedbackForm", "ContactId");
            AddForeignKey("dbo.FeedbackForm", "ContactId", "dbo.Contact", "Id", cascadeDelete: true);
        }
    }
}
