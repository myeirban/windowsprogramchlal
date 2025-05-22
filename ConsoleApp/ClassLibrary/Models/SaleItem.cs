namespace ClassLibrary.Models
{
    /// <summary>
    /// Borluulaltiin neg baraanii medeelliig hdgalah modeli klass.
    /// </summary>
    public class SaleItem
    {
        /// <summary>
        /// borluulsan butegdehuun
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// borluulsan too hemjee
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// niit une
        /// </summary>
        public decimal Total => Product.Price * Quantity;

        public int ProductId { get; set; }
        public decimal Price { get; set; }
    }
} 