namespace ClassLibrary.Models
{
    /// <summary>
    /// POS systemmiin baraa buteegdehuunii medeelliig hadgalah klass.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// baraanii dotood kod esvel sistemiin kod
        /// </summary>
        public string Code { get; set; } = "";

        /// <summary>
        /// baraanii ovormots id
        /// </summary>

        public int Id { get; set; }

        /// <summary>
        /// baraanii ner
        /// </summary>

        public string Name { get; set; }

        /// <summary>
        /// baraanii une
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// baraanii uldegdel noots
        /// </summary>
        public int Stock { get; set; }

        /// <summary>
        /// harialagdah angilaliin id
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Tur ashiglagddag dotood too hemjee
        /// </summary>
        public int StockQuantity { get; internal set; }

        /// <summary>
        /// baraanii shtrih kod
        /// </summary>
        public string Barcode { get; set; } 
    }
} 