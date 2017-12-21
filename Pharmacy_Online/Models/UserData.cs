using System.ComponentModel.DataAnnotations;

namespace Pharmacy_Online.Models
{
    public class UserData
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string PostCode { get; set; }

        [RegularExpression(@"(\+\d{2})*[\d\s-]+", ErrorMessage = "Błędny format numeru telefonu.")]
        public string Phone { get; set; }

        [EmailAddress(ErrorMessage = "Błędny format adresu e-mail")]
        public string Email { get; set; }

        //public Delivery Delivery { get; set; }

        
        
    }

    //public enum Delivery
    //{
    //    [Display(Name = "Przesyłka kurierska DHL + 15,00zł")]
    //    Courier,

    //    [Display(Name = "Paczka pocztowa polecona + 10,00zł")]
    //    PostOfficeRegistered,

    //    [Display(Name = "Paczka pocztowa ekonomiczna + 8,00zł")]
    //    PostOfficeEconomic,


    //}
}