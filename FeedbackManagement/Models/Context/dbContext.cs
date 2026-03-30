using System.Data.Entity;
using FeedbackManagement.Models.Entities;

namespace FeedbackManagement.Models.Context
{
    public class dbcontext : DbContext
    {
        public dbcontext() : base("name=dbcontext")
        {
            Database.SetInitializer<dbcontext>(null); // Désactive l'initialiseur automatique
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<FeedbackStatus> FeedbackStatuses { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<User> Users { get; set; }
    }
}