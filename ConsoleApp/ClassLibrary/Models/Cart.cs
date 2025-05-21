using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary.Models
{
    /// <summary>
    /// POS sistem dehi sagsnii medeelliig udirdah klass.
    /// </summary>
    public class Cart
    {
        /// <summary>
        /// Sagsand baigaa baraa buriin jagsaalt
        /// </summary>
        public List<SaleItem> Items { get; private set; }

        /// <summary>
        /// Sagsnii niit toloh dun
        /// </summary>
        public decimal TotalAmount => Items.Sum(item => item.Total);

        /// <summary>
        /// Sagsand baigaa niit baraanii too hemjee
        /// </summary>
        public int TotalItems => Items.Sum(item => item.Quantity);

        /// <summary>
        /// shine sags uusgeh baiguulagch
        /// </summary>
        public Cart()
        {
            Items = new List<SaleItem>();
        }

        /// <summary>
        /// Sagsand shine baraa nemeh esvel baigaa baraanii toog nemegduuleh
        /// </summary>
        /// <param name="product">nemeh gej bui baraanii buteegdehuun</param>
        /// <param name="quantity">nemeh too hemjee</param>
        public void AddItem(Product product, int quantity = 1)
        {
            var existingItem = Items.FirstOrDefault(item => item.Product.Id == product.Id);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                Items.Add(new SaleItem { Product = product, Quantity = quantity });
            }
        }

        /// <summary>
        /// Sagsand baigaa baraanii too hemjeeg shinecleh.
        /// </summary>
        /// <param name="productId">Buteegdehuunii ID</param>
        /// <param name="quantity">shine too hemjee.Herev 0 esvel baga bol baraag ustgana.</param>
        public void UpdateItemQuantity(int productId, int quantity)
        {
            var existingItem = Items.FirstOrDefault(item => item.Product.Id == productId);
            if (existingItem != null)
            {
                if (quantity > 0)
                {
                    existingItem.Quantity = quantity;
                }
                else
                {
                    Items.Remove(existingItem);
                }
            }
        }

        /// <summary>
        /// Sagsnaas todorhoi baraag hasah.
        /// </summary>
        /// <param name="productId">Ustgah gej bui baraanii ID</param>
        public void RemoveItem(int productId)
        {
            var itemToRemove = Items.FirstOrDefault(item => item.Product.Id == productId);
            if (itemToRemove != null)
            {
                Items.Remove(itemToRemove);
            }
        }

        /// <summary>
        /// Sagsiig buren tseverlej,buh baraag ustgana.
        /// </summary>
        public void ClearCart()
        {
            Items.Clear();
        }
    }
} 