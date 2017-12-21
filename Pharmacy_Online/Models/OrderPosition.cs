namespace Pharmacy_Online.Models
{
    public class OrderPosition
    {
        public int OrderPositionId { get; set; }
        public int OrderId { get; set; } // klucz obcy do zamówienia
        public int ProductId { get; set; } //klucz obcy do produktu
        public int Amount { get; set; }
        public decimal OrderPrice { get; set; }


        // będziemy wiedzieli, które produkty i zamówienia pasują do tej pozycji zamówienia
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }

    }
}