using ClassLibrary.Models;

namespace ClassLibrary
{/// <summary>
/// hudaldan avaltiin medeelliig hadgalah zoriulalttai klass.
/// Borluulaltiin ognoo,baraanuud bolon niit dung aguulna
/// </summary>
    public class Sale
    {

        /// <summary>
        /// Borluultiin davtagdashgui ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Hudaldan avalt hiigdsen ognoo
        /// </summary>
        public DateTime SaleDate { get; set; }

        /// <summary>
        /// Borluulaltiin burdel baraanuudiin jagsalt
        /// </summary>
        public List<SaleItem> Items { get; set; }

        /// <summary>
        /// hudaldan avaltiin niit dun 
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Sale klassiin anhni utguudiig onooj,hooson baraani jagsaalt uusgene,
        /// </summary>
        public Sale()
        {
            SaleDate = DateTime.Now;
            Items = new List<SaleItem>();
            TotalAmount = 0;
        }

        /// <summary>
        /// baraag todorhoi hemjeegeer borluulaltand nemne.
        /// Mon niit dung shinechilj,baraanii uldegdel toog hasna.
        /// </summary>
        /// <param name="product">borluulah baraa</param>
        /// <param name="quantity">borluulj bui too hemjee</param>
        /// <exception cref="Exception">hangalttai uldegdel baihgui yed aldaa shidne</exception>
        public void AddItem(Product product, int quantity)
        {
            if (product.StockQuantity >= quantity)
            {
                var saleItem = new Models.SaleItem { Product = product, Quantity = quantity };
                Items.Add(saleItem);
                TotalAmount += saleItem.Total;
                product.StockQuantity -= quantity;
            }
            else
            {
                throw new Exception("Insufficient stock");
            }
        }
    }
}