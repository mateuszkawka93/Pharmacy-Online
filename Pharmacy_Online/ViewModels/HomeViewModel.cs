using Pharmacy_Online.Models;
using System.Collections.Generic;

namespace Pharmacy_Online.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Product> News { get; set; }
        public IEnumerable<Product> Bestsellers { get; set; }
    }
}