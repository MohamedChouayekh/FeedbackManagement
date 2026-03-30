namespace FeedbackManagement.Models.ViewModels
{
    public class FeedbackStatusViewModel
    {
        public int Id { get; set; }
        public int? StatusId { get; set; }
        public string Comment { get; set; }

        // Champs pour affichage
        public string ContactName { get; set; }
        public string Email { get; set; }
        public string StatusName { get; set; }
    }
}
