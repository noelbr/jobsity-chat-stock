using System;
using System.ComponentModel.DataAnnotations;

namespace jobsity_chat.Models
{
    public class RegisterViewModel
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "password not the same")]
        public string ConfirmPassword { get; set; }
    }
}
