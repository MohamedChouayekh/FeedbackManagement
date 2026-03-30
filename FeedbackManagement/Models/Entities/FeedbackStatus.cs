using System.Collections.Generic;

namespace FeedbackManagement.Models.Entities
{
    public class FeedbackStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // <- ajoute ceci
        public virtual ICollection<Feedback> Feedbacks { get; set; }

        public FeedbackStatus()
        {
            Feedbacks = new HashSet<Feedback>();
        }
    }
}
