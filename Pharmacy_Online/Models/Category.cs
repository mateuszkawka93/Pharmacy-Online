using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pharmacy_Online.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Wprowadź nazwę kategorii")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Wprowadź opis kategorii")]
        public string Description { get; set; }


        //do każdej kategorii możemy przypisać wiele produktów dlatego kolekcja, ICollection pozwala na dodawanie i usuwania
        public virtual ICollection<Product> Products { get; set; }
    }
}