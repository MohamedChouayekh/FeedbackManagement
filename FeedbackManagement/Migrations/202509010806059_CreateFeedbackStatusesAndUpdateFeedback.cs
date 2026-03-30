namespace FeedbackManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class CreateFeedbackStatusesAndUpdateFeedback : DbMigration
    {
        public override void Up()
        {
            // Ne pas recréer StatusId car il existe déjà
            AddForeignKey("dbo.Feedbacks", "StatusId", "dbo.FeedbackStatuses", "Id", cascadeDelete: true);

            DropColumn("dbo.Feedbacks", "Name");
            DropColumn("dbo.Feedbacks", "Lastname");
            DropColumn("dbo.Feedbacks", "Email");
        }

        public override void Down()
        {
            AddColumn("dbo.Feedbacks", "Email", c => c.String(nullable: false));
            AddColumn("dbo.Feedbacks", "Lastname", c => c.String(nullable: false));
            AddColumn("dbo.Feedbacks", "Name", c => c.String(nullable: false));

            DropForeignKey("dbo.Feedbacks", "StatusId", "dbo.FeedbackStatuses");
        }
    }
}
