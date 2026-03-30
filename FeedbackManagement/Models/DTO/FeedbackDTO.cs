using System.ComponentModel.DataAnnotations;

namespace FeedbackManagement.Models.DTO
{
    public class FeedbackDTO
    {
        [Required]
        public int LocationId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; } // ⚡ Ajouter cette propriété

        [Required]
        [EmailAddress]
        [MaxLength(256)]
        public string Email { get; set; }

        [Required]
        [Range(1, 10)]
        public int Score { get; set; }

        [MaxLength(1000)]
        public string Comment { get; set; }
    }
}
