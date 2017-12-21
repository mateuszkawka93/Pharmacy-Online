using Pharmacy_Online.Models;
using System.Collections.Generic;

namespace Pharmacy_Online.ViewModels
{
    public class CartViewModel
    {
        public List<CartPosition> CartPositions { get; set; }
        public decimal TotalPrice { get; set; }
    }
}