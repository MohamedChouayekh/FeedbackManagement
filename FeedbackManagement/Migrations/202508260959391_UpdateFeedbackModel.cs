namespace FeedbackManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class UpdateFeedbackModel : DbMigration
    {
        public override void Up()
        {
            // 1️⃣ Créer FeedbackStatuses si elle n'existe pas
            CreateTable(
                "dbo.FeedbackStatuses",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 100)
                })
                .PrimaryKey(t => t.Id);

            // 2️⃣ Insérer le statut Pending
            Sql("INSERT INTO dbo.FeedbackStatuses (Name) VALUES ('Pending')");

            // 3️⃣ Ajouter les nouvelles colonnes dans Feedbacks
            AddColumn("dbo.Feedbacks", "Name", c => c.String(nullable: false));
            AddColumn("dbo.Feedbacks", "Lastname", c => c.String(nullable: false));
            AddColumn("dbo.Feedbacks", "Email", c => c.String(nullable: false));
        }

        public override void Down()
        {
            // Supprimer les nouvelles colonnes
            DropColumn("dbo.Feedbacks", "Email");
            DropColumn("dbo.Feedbacks", "Lastname");
            DropColumn("dbo.Feedbacks", "Name");

            // Supprimer la table FeedbackStatuses
            DropTable("dbo.FeedbackStatuses");
        }
    }
}
