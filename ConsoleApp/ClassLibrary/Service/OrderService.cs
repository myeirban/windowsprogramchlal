
using System.Data.SQLite;

using ClassLibrary.Repository;
using ClassLibrary.Models;

namespace ClassLibrary.Service
{
    /// <summary>
    /// hudaldan avaltiin medeelliig sand burtgeh,baraanii uldegdliig shinecleh uuregtei uilcilgeenii class
    /// </summary>
    public class OrderService
    {
        private readonly DatabaseRepository databaseRepository;
        // Potentially other repositories or services needed for order processing

        /// <summary>
        /// Orderservice iin shine examplyariig uusgej sntai holbon 
        /// </summary>
        /// <param name="databaseRepository">ogogdliin sngiin repo</param>
        public OrderService(DatabaseRepository databaseRepository)
        {
            this.databaseRepository = databaseRepository;
        }

        /// <summary>
        /// Hudaldan avaltiin medeelliig sand hadgalah bolon baraanii uldegdliig hasah undsen uildel
        /// </summary>
        /// <param name="items">sagsand baigaa borluulaltiin baraanuud</param>
        /// <param name="cashierName">kasschin hereglegchiin ner</param>
        /// <param name="paymentMethod">tolboriin helber</param>
        public void ProcessSale(List<SaleItem> items, string cashierName, string paymentMethod)
        {
            using (var connection = databaseRepository.GetConnection())
            {
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Insert Sale
                        string saleQuery = "INSERT INTO Sales (Date, CashierName, PaymentMethod, Total) VALUES (@Date, @CashierName, @PaymentMethod, @Total)";
                        long saleId;
                        using (SQLiteCommand saleCmd = new SQLiteCommand(saleQuery, connection, transaction))
                        {
                            saleCmd.Parameters.AddWithValue("@Date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            saleCmd.Parameters.AddWithValue("@CashierName", cashierName);
                            saleCmd.Parameters.AddWithValue("@PaymentMethod", paymentMethod);
                            saleCmd.Parameters.AddWithValue("@Total", items.Sum(item => item.Total));
                            saleCmd.ExecuteNonQuery();
                            saleId = connection.LastInsertRowId;
                        }

                        // Insert SaleItems and update product stock
                        string saleItemQuery = "INSERT INTO SaleItems (SaleId, ProductId, Quantity, Price) VALUES (@SaleId, @ProductId, @Quantity, @Price)";
                        string updateStockQuery = "UPDATE Products SET Stock = Stock - @Quantity WHERE Id = @ProductId";

                        foreach (var item in items)
                        {
                            using (SQLiteCommand saleItemCmd = new SQLiteCommand(saleItemQuery, connection, transaction))
                            {
                                saleItemCmd.Parameters.AddWithValue("@SaleId", saleId);
                                saleItemCmd.Parameters.AddWithValue("@ProductId", item.Product.Id);
                                saleItemCmd.Parameters.AddWithValue("@Quantity", item.Quantity);
                                saleItemCmd.Parameters.AddWithValue("@Price", item.Product.Price);
                                saleItemCmd.ExecuteNonQuery();
                            }

                            using (SQLiteCommand updateStockCmd = new SQLiteCommand(updateStockQuery, connection, transaction))
                            {
                                updateStockCmd.Parameters.AddWithValue("@Quantity", item.Quantity);
                                updateStockCmd.Parameters.AddWithValue("@ProductId", item.Product.Id);
                                updateStockCmd.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

          

    }
} 