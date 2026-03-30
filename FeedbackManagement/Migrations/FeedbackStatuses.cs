using System;
using System.Data.Entity.Migrations;

namespace FeedbackManagement.Migrations
{
    public partial class CreateFeedbackStatusTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FeedbackStatuses",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 100),
                })
                .PrimaryKey(t => t.Id);

            // Insérer le statut "Pending" automatiquement
            Sql("INSERT INTO dbo.FeedbackStatuses (Name) VALUES ('Pending')");
        }

        public override void Down()
        {
            DropTable("dbo.FeedbackStatuses");
        }
    }
}
