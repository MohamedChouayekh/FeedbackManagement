using System.ComponentModel.DataAnnotations;

namespace FeedbackManagement.Models.Entities
{
    public class RegisterViewModel
    {
        [Required]
        [MaxLength(256)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}