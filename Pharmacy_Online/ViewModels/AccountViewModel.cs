using System.ComponentModel.DataAnnotations;

namespace Pharmacy_Online.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Podaj swój e-mail")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Podaj swoje hasło")]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Password { get; set; }

        [Display(Name = "Zapamiętaj mnie")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [StringLength(30, ErrorMessage = "{0} musi mieć co najmniej {2} znaków.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Podaj swój e-mail")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Wpisane hasła są różne !")]
        [DataType(DataType.Password)]
        [Display(Name = "Potwierdź hasło")]
        public string ConfirmPassword { get; set; }
    }
}