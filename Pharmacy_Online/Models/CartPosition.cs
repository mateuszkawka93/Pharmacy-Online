namespace Pharmacy_Online.Models
{
    public class CartPosition
    {
        public Product Product { get; set; }
        public int Amount { get; set; }
        public decimal Value { get; set; }
        
    }
}