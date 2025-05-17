using System;
using System.Data.SQLite;
using System.Collections.Generic;

class Program
{
    private const string DB_PATH = @"C:\Users\22B1NUM7158\Documents\school\windowsprogramchlal\ConsoleApp\miniidatabase";

    static void Main()
    {
        string connectionString = $"Data Source={DB_PATH};Version=3;";

        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();

            // Get all tables
            var tables = new List<string>();
            using (var command = new SQLiteCommand("SELECT name FROM sqlite_master WHERE type='table'", connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tables.Add(reader.GetString(0));
                    }
                }
            }

            // Display contents of each table
            foreach (var table in tables)
            {
                Console.WriteLine($"\n=== Contents of {table} table ===");
                using (var command = new SQLiteCommand($"SELECT * FROM {table}", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        // Print column names
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Console.Write($"{reader.GetName(i)}\t");
                        }
                        Console.WriteLine();

                        // Print data
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                Console.Write($"{reader[i]}\t");
                            }
                            Console.WriteLine();
                        }
                    }
                }
            }
        }

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
