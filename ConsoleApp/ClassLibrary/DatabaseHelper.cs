using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using ClassLibrary.Models;

namespace ClassLibrary
{
    public class DatabaseHelper
    {
        private readonly string dbPath;
        private readonly string connectionString;

        public DatabaseHelper(string dbPath)
        {
            // Ensure the directory exists
            string directory = Path.GetDirectoryName(dbPath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            this.dbPath = dbPath;
            this.connectionString = $"Data Source={dbPath};Version=3;";
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            bool isNewDatabase = !File.Exists(dbPath);
            if (isNewDatabase)
            {
                SQLiteConnection.CreateFile(dbPath);
            }

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(connection))
                {
                    // Create Users table if not exists
                    command.CommandText = @"
                        CREATE TABLE IF NOT EXISTS Users (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Username TEXT NOT NULL UNIQUE,
                            Password TEXT NOT NULL,
                            Role TEXT NOT NULL
                        )";
                    command.ExecuteNonQuery();

                    // Create Categories table if not exists
                    command.CommandText = @"
                        CREATE TABLE IF NOT EXISTS Categories (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Name TEXT NOT NULL UNIQUE
                        )";
                    command.ExecuteNonQuery();

                    // Create Products table if not exists
                    command.CommandText = @"
                        CREATE TABLE IF NOT EXISTS Products (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Name TEXT NOT NULL,
                            Price REAL NOT NULL,
                            Stock INTEGER NOT NULL,
                            CategoryId INTEGER NOT NULL,
                            Barcode TEXT NOT NULL UNIQUE,
                            FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
                        )";
                    command.ExecuteNonQuery();

                    // Create Sales table if not exists
                    command.CommandText = @"
                        CREATE TABLE IF NOT EXISTS Sales (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Date TEXT NOT NULL,
                            CashierName TEXT NOT NULL,
                            PaymentMethod TEXT NOT NULL,
                            Total REAL NOT NULL
                        )";
                    command.ExecuteNonQuery();

                    // Create SaleItems table if not exists
                    command.CommandText = @"
                        CREATE TABLE IF NOT EXISTS SaleItems (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            SaleId INTEGER NOT NULL,
                            ProductId INTEGER NOT NULL,
                            Quantity INTEGER NOT NULL,
                            Price REAL NOT NULL,
                            FOREIGN KEY (SaleId) REFERENCES Sales(Id),
                            FOREIGN KEY (ProductId) REFERENCES Products(Id)
                        )";
                    command.ExecuteNonQuery();

                    // Insert default admin user if it's a new database
                    if (isNewDatabase)
                    {
                        command.CommandText = @"
                            INSERT INTO Users (Username, Password, Role)
                            VALUES ('admin', 'admin', 'Admin')";
                        command.ExecuteNonQuery();

                        // Insert default manager and cashier users
                        command.CommandText = @"
                            INSERT INTO Users (Username, Password, Role)
                            VALUES 
                            ('manager', '0000', 'Manager'),
                            ('cashier1', '0000', 'Cashier'),
                            ('cashier2', '0000', 'Cashier')";
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public List<User> GetUsers()
        {
            var users = new List<User>();
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand("SELECT * FROM Users", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            users.Add(new User
                            {
                                Id = reader.GetInt32(0),
                                Username = reader.GetString(1),
                                Password = reader.GetString(2),
                                Role = reader.GetString(3)
                            });
                        }
                    }
                }
            }
            return users;
        }

        public User GetUser(string username)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand("SELECT * FROM Users WHERE Username = @Username", connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                Id = reader.GetInt32(0),
                                Username = reader.GetString(1),
                                Password = reader.GetString(2),
                                Role = reader.GetString(3)
                            };
                        }
                    }
                }
            }
            return null;
        }

        public List<Category> GetCategories()
        {
            var categories = new List<Category>();
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand("SELECT * FROM Categories", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            categories.Add(new Category
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1)
                            });
                        }
                    }
                }
            }
            return categories;
        }

        public void AddCategory(string name)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand("INSERT INTO Categories (Name) VALUES (@Name)", connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Product> GetProducts()
        {
            var products = new List<Product>();
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
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
                                Barcode = reader.GetString(5)
                            });
                        }
                    }
                }
            }
            return products;
        }

        public Product GetProductById(int id)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
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
                                Barcode = reader.GetString(5)
                            };
                        }
                    }
                }
            }
            return null;
        }

        public void AddProduct(string name, decimal price, int stock, int categoryId, string barcode)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(
                    "INSERT INTO Products (Name, Price, Stock, CategoryId, Barcode) " +
                    "VALUES (@Name, @Price, @Stock, @CategoryId, @Barcode)", connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Price", price);
                    command.Parameters.AddWithValue("@Stock", stock);
                    command.Parameters.AddWithValue("@CategoryId", categoryId);
                    command.Parameters.AddWithValue("@Barcode", barcode);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateProduct(int id, string name, decimal price, int stock, int categoryId, string barcode)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
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
        }

        public void DeleteProduct(int id)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand("DELETE FROM Products WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteCategory(int id)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // First delete all products in this category
                        using (var command = new SQLiteCommand("DELETE FROM Products WHERE CategoryId = @CategoryId", connection))
                        {
                            command.Parameters.AddWithValue("@CategoryId", id);
                            command.ExecuteNonQuery();
                        }

                        // Then delete the category
                        using (var command = new SQLiteCommand("DELETE FROM Categories WHERE Id = @Id", connection))
                        {
                            command.Parameters.AddWithValue("@Id", id);
                            command.ExecuteNonQuery();
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

        public void ProcessSale(List<SaleItem> items, string cashierName, string paymentMethod)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Insert sale
                        long saleId;
                        using (var command = new SQLiteCommand(
                            "INSERT INTO Sales (Date, CashierName, PaymentMethod, Total) " +
                            "VALUES (@Date, @CashierName, @PaymentMethod, @Total); " +
                            "SELECT last_insert_rowid();", connection))
                        {
                            command.Parameters.AddWithValue("@Date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            command.Parameters.AddWithValue("@CashierName", cashierName);
                            command.Parameters.AddWithValue("@PaymentMethod", paymentMethod);
                            command.Parameters.AddWithValue("@Total", items.Sum(item => item.Total));
                            saleId = (long)command.ExecuteScalar();
                        }

                        // Insert sale items
                        foreach (var item in items)
                        {
                            using (var command = new SQLiteCommand(
                                "INSERT INTO SaleItems (SaleId, ProductId, Quantity, Price) " +
                                "VALUES (@SaleId, @ProductId, @Quantity, @Price)", connection))
                            {
                                command.Parameters.AddWithValue("@SaleId", saleId);
                                command.Parameters.AddWithValue("@ProductId", item.Product.Id);
                                command.Parameters.AddWithValue("@Quantity", item.Quantity);
                                command.Parameters.AddWithValue("@Price", item.Product.Price);
                                command.ExecuteNonQuery();
                            }

                            // Update product stock
                            using (var command = new SQLiteCommand(
                                "UPDATE Products SET Stock = Stock - @Quantity WHERE Id = @ProductId", connection))
                            {
                                command.Parameters.AddWithValue("@Quantity", item.Quantity);
                                command.Parameters.AddWithValue("@ProductId", item.Product.Id);
                                command.ExecuteNonQuery();
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