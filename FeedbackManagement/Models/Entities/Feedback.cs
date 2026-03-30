using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // Ajouté pour DatabaseGenerated et ForeignKey

namespace FeedbackManagement.Models.Entities
{
    public class Feedback
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int LocationId { get; set; }

        [ForeignKey("LocationId")]
        public Location Location { get; set; }

        [Required]
        public int ContactId { get; set; }

        [ForeignKey("ContactId")]
        public Contact Contact { get; set; } // Assurez-vous que la classe Contact existe, sinon créez-la (voir ci-dessous)

        [Required]
        public int StatusId { get; set; }

        [ForeignKey("StatusId")]
        public FeedbackStatus Status { get; set; } // Assurez-vous que la classe Status existe, sinon créez-la (voir ci-dessous)
        [Required]
        [Range(1, 10)]
        public int Score { get; set; }

        [Required]
        [MaxLength(500)]
        public string Comment { get; set; }
    }
}