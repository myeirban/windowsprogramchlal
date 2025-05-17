namespace ClassLibrary.Models
{
    public class SaleItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal Total => Product.Price * Quantity;
    }
} 