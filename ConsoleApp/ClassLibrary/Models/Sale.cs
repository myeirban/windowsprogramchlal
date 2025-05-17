using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public List<SaleItem> Items { get; set; } = new List<SaleItem>();
        public decimal Total => Items.Sum(item => item.Total);
        public string CashierName { get; set; }
        public string PaymentMethod { get; set; }
    }
} 