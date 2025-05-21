using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary.Models
{
    /// <summary>
    /// POS systemiin borluulaltiin medeelliig ilerhiileh klass.
    /// </summary>
    public class Sale
    {
        /// <summary>
        /// borluulaltiin davtagdashgui dugaar
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Borluulalt hiigdsen ognoo,tsag
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Ene borluultand orson baraa buteegdehuunii jagsaalt
        /// </summary>
        public List<SaleItem> Items { get; set; } = new List<SaleItem>();

        /// <summary>
        /// niit borluulaltiin dun
        /// </summary>
        public decimal Total => Items.Sum(item => item.Total);

        /// <summary>
        /// Borluulalt hiisen kasschin ner
        /// </summary>
        public string CashierName { get; set; }

        /// <summary>
        /// tolboriin helber
        /// </summary>
        public string PaymentMethod { get; set; }
    }
} 