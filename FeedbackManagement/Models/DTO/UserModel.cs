using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FeedbackManagement.Models.DTO
{
    public class UserModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}