namespace FeedbackManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateFeedbackTables1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Contact", newName: "Contacts");
            RenameTable(name: "dbo.Feedback", newName: "Feedbacks");
            RenameTable(name: "dbo.Location", newName: "Locations");
            RenameTable(name: "dbo.User", newName: "Users");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Users", newName: "User");
            RenameTable(name: "dbo.Locations", newName: "Location");
            RenameTable(name: "dbo.Feedbacks", newName: "Feedback");
            RenameTable(name: "dbo.Contacts", newName: "Contact");
        }
    }
}
