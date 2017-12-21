using System;
using System.ComponentModel.DataAnnotations;

namespace Pharmacy_Online.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; } // klucz obcy 

        [Required(ErrorMessage = "Wprowadź nazwę produktu")]
        [StringLength(150)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Wprowadź producenta")]
        [StringLength(50)]
        public string Producer { get; set; }

        public DateTime AddTime { get; set; }

        [StringLength(100)]
        public string ImageFile { get; set; }

        public string Description { get; set; }
        public string Recommendation { get; set; }
        public string Ingredients { get; set; }
        public decimal Price { get; set; }
        public bool Bestseller { get; set; }
        public bool Hidden { get; set; }
        

        // będziemy wiedzieli, które kategorie pasują do tego produktu
        public virtual Category Category { get; set; }
    }
}