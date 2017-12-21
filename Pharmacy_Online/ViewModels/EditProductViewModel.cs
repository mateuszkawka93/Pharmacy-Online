using Pharmacy_Online.Models;
using System.Collections.Generic;

namespace Pharmacy_Online.ViewModels
{
    public class EditProductViewModel
    {
        public Product Product { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public bool? Confirm { get; set; }
    }
}