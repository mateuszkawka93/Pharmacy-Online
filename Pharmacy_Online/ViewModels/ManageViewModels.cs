using Pharmacy_Online.Controllers;
using Pharmacy_Online.Models;
using System.ComponentModel.DataAnnotations;

namespace Pharmacy_Online.ViewModels
{
    public class ManageCredentialsViewModel
    {
        public ChangePasswordViewModel ChangePasswordViewModel { get; set; }
        public ManageController.ManageMessageId? Message { get; set; }
        public UserData UserData { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Nowe hasło musi mieć przynajmniej 6 znaków", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Nowe hasło i hasło potwierdzające nie pasują do siebie.")]
        public string ConfirmPassword { get; set; }
    }
}