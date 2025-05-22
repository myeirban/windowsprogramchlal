using Microsoft.Extensions.Configuration;
using System.Data.SQLite;
using System.IO;

namespace ClassLibrary.Repository
{
    /// <summary>
    /// Ogogdliin san uusgeh,husnegtuud beldeh,SQLite holbolt neeh uurgtei klass.
    /// </summary>
    public class DatabaseRepository
    {   
        private readonly string dbPath;
        private readonly string connectionString;


        /// <summary>
        /// DatabaseRepo klassiig shine ogogdliin sangiin zamaar initsializ hiij,shaardlagatai bol ogogdliin san uusgene.
        /// </summary>
        /// <param name="dbPath">Db zam</param>
        public DatabaseRepository(string dbPath)
        {
            string directory = Path.GetDirectoryName(dbPath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            this.dbPath = dbPath;
            connectionString = $"Data Source={dbPath};Version=3;";
            InitializeDatabase();
        }

        /// <summary>
        /// Ogogdliin san shineer baigaa esehiig shalgaj,shaardlagatai husnegtuudiig uusgene.
        /// shineer uusej baigaa bol anhni hereglegchdiig nemen.
        /// </summary>
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
                    // Users
                    command.CommandText = @"
                        CREATE TABLE IF NOT EXISTS Users (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Username TEXT NOT NULL UNIQUE,
                            Password TEXT NOT NULL,
                            Role TEXT NOT NULL
                        );";
                    command.ExecuteNonQuery();

                    // Categories
                    command.CommandText = @"
                        CREATE TABLE IF NOT EXISTS Categories (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Name TEXT NOT NULL UNIQUE
                        );";
                    command.ExecuteNonQuery();

                    // Products
                    command.CommandText = @"
                        CREATE TABLE IF NOT EXISTS Products (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Name TEXT NOT NULL,
                            Price REAL NOT NULL,
                            Stock INTEGER NOT NULL,
                            CategoryId INTEGER NOT NULL,
                            Barcode TEXT UNIQUE,
                            FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
                        );";
                    command.ExecuteNonQuery();

                    // Sales
                    command.CommandText = @"
                        CREATE TABLE IF NOT EXISTS Sales (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Date TEXT NOT NULL,
                            CashierName TEXT NOT NULL,
                            PaymentMethod TEXT NOT NULL,
                            Total REAL NOT NULL
                        );";
                    command.ExecuteNonQuery();

                    // SaleItems
                    command.CommandText = @"
                        CREATE TABLE IF NOT EXISTS SaleItems (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            SaleId INTEGER NOT NULL,
                            ProductId INTEGER NOT NULL,
                            Quantity INTEGER NOT NULL,
                            Price REAL NOT NULL,
                            FOREIGN KEY (SaleId) REFERENCES Sales(Id),
                            FOREIGN KEY (ProductId) REFERENCES Products(Id)
                        );";
                    command.ExecuteNonQuery();

                    // Always add default users
                    command.CommandText = @"
                        DELETE FROM Users;
                        INSERT INTO Users (Username, Password, Role) VALUES 
                        ('admin', 'admin', 'Admin'),
                        ('manager', '0000', 'Manager'),
                        ('cashier1', '0000', 'Cashier'),
                        ('cashier2', '0000', 'Cashier');";
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// SQLite ogogdliin sntai holbogdoh shine holboltiig neene.
        /// </summary>
        /// <returns>obiekt butsaana.</returns>
        public SQLiteConnection GetConnection()
        {
            var connection = new SQLiteConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}
