using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pharmacy_Online.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Required(ErrorMessage = "Wprowadź imię !")]
        [StringLength(60)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Wprowadź nazwisko !")]
        [StringLength(60)]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Wprowadź ulicę !")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Wprowadź miasto !")]
        public string City { get; set; }

        [Required(ErrorMessage = "Wprowadź kod pocztowy !")]
        [StringLength(6)]
        public string PostCode { get; set; }

        [Required(ErrorMessage = "Wprowadź numer telefonu !")]
        [RegularExpression(@"(\+\d{2})*[\d\s-]+", ErrorMessage = "Błędny format numeru telefonu !")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Wprowadź adres e-mail")]
        [EmailAddress(ErrorMessage = "Błędny format adresu e-mail !")]
        public string Email { get; set; }

        [StringLength(300)]
        public string Comment { get; set; }

        public DateTime OrderTime { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public decimal OrderValue { get; set; }
        public Delivery Delivery { get; set; }
        public List<OrderPosition> OrderPositions { get; set; }
    }

    public enum OrderStatus
    {
        [Display(Name="Nowe")]
        New,
        [Display(Name="Zrealizowane")]
        Completed
    }

    public enum Delivery
    {
        [Display(Name = "Przesyłka kurierska DHL + 15,00zł")]
        Courier,

        [Display(Name = "Paczka pocztowa polecona + 10,00zł")]
        PostOfficeRegistered,

        [Display(Name = "Paczka pocztowa ekonomiczna + 8,00zł")]
        PostOfficeEconomic,


    }
}