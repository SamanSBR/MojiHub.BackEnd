using System.ComponentModel.DataAnnotations;

namespace MojiHub.Data.DTOs
{
    public class SignUpViewModel
    {
        [Required(ErrorMessage = "Please enter your full name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your email address.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a password.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please enter a Repassword.")]
        [DataType(DataType.Password)]
        public string RePassword { get; set; }
    }
}
