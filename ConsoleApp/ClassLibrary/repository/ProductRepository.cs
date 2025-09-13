using System.Data.SQLite;
using ClassLibrary.Models;

namespace ClassLibrary.Repository
{
    /// <summary>
    /// Butegdehuunii ogogdliig udirdah zoriulalttai SQLite repogiin class.
    /// </summary>
    public class ProductRepository
    {
        private SQLiteConnection connection;

        /// <summary>
        /// Product repo giin klassiig ogogdliin sangiin holboltoor initsializ hiideg.
        /// </summary>
        /// <param name="connection">ogogdliin santai holbogdson neelttei holbolt</param>
        public ProductRepository(SQLiteConnection connection)
        {
            this.connection = connection;
        }

        /// <summary>
        /// Shine buteegdehuuniig ogogdliin sand nemne.
        /// </summary>
        /// <param name="product">nemeh gej bui obiekt</param>
        public void AddProduct(Product product)
        {
            string query = "INSERT INTO Products (Name, Price, Stock, CategoryId, Barcode) VALUES (@name, @price, @stock, @categoryId, @barcode)";
            using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@name", product.Name);
                cmd.Parameters.AddWithValue("@price", product.Price);
                cmd.Parameters.AddWithValue("@stock", product.Stock);
                cmd.Parameters.AddWithValue("@categoryId", product.CategoryId);
                cmd.Parameters.AddWithValue("@barcode", product.Barcode);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Ogogdliin sangaas buh buteegdehuunii jagsaaltiig avchirna.
        /// </summary>
        /// <returns>Obiektuudiin jagsaalt</returns>
        public List<Product> GetProducts()
        {
            var products = new List<Product>();
            using (var command = new SQLiteCommand("SELECT * FROM Products", connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        products.Add(new Product
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Price = reader.GetDecimal(2),
                            Stock = reader.GetInt32(3),
                            CategoryId = reader.GetInt32(4),
                            Barcode = reader.IsDBNull(5) ? "" : reader.GetString(5)
                        });
                    }
                }
            }
            return products;
        }
        /// <summary>
        /// Todorhoi ID-tai butegdehuuniig ogogdliin sangaas avchirna.
        /// </summary>
        /// <param name="id">haij bui buteegdehuuni ID </param>
        /// <returns>oldson obiekt esvel null</returns>
        public Product GetProductById(int id)
        {
            using (var command = new SQLiteCommand("SELECT * FROM Products WHERE Id = @Id", connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Product
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Price = reader.GetDecimal(2),
                            Stock = reader.GetInt32(3),
                            CategoryId = reader.GetInt32(4),
                            Barcode = reader.IsDBNull(5) ? "" : reader.GetString(5)
                        };
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Ogogdliin san dahi buteegdehuunii medeelliig shineclene.
        /// </summary>
        /// <param name="id">shinecleh buteegdehuunii id</param>
        /// <param name="name">shine ner</param>
        /// <param name="price">shine une</param>
        /// <param name="stock">shine noots too</param>
        /// <param name="categoryId">hamaaraltai angilaliin ID</param>
        /// <param name="barcode">Shine barcode</param>
        public void UpdateProduct(int id, string name, decimal price, int stock, int categoryId, string barcode)
        {
            using (var command = new SQLiteCommand(
                "UPDATE Products SET Name = @Name, Price = @Price, Stock = @Stock, " +
                "CategoryId = @CategoryId, Barcode = @Barcode WHERE Id = @Id", connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Price", price);
                command.Parameters.AddWithValue("@Stock", stock);
                command.Parameters.AddWithValue("@CategoryId", categoryId);
                command.Parameters.AddWithValue("@Barcode", barcode);
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// todorhoi id tai buteegdehuuniig ogogdliin sangaas ustgana.
        /// </summary>
        /// <param name="id">ustgah buteegdehuunii id</param>
        public void DeleteProduct(int id)
        {
            using (var command = new SQLiteCommand("DELETE FROM Products WHERE Id = @Id", connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }
    }
}
