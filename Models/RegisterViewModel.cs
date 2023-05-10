using System.ComponentModel.DataAnnotations;

namespace LabWork.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string Name { get; set; }

        public string Surname { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "{0} повинен мати довжину мінімум {2} символів", MinimumLength = 6)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Пароль і підтвердження паролю не співпадає")]
        public string ConfirmPassword { get; set; }
    }
}
