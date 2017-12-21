using Pharmacy_Online.Models;
using Postal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pharmacy_Online.ViewModels
{
    public class ConfirmOrderEmail : Email
    {
        public string To { get; set; }
        public string From { get; set; }
        public decimal TotalValue { get; set; }
        public int OrderNumber { get; set; }
        public Delivery DeliveryValue { get; set; }
        
        public List<OrderPosition> OrderPositions { get; set; }
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