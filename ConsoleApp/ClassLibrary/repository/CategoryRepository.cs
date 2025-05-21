using System.Data.SQLite;
using System.Collections.Generic;
using ClassLibrary.Models;
using Microsoft.Extensions.Configuration;

namespace ClassLibrary.Repository
{
    /// <summary>
    /// Baraanii angilliin medeelliig udirdah zoriulalttai ogogdliin sangiin repo class
    /// </summary>
    public class CategoryRepository
    {
        private SQLiteConnection connection;

        /// <summary>
        /// CategoryRepo klassiin shine ekzamplariig uusgene.
        /// </summary>
        /// <param name="connection">SQLite ogogdliin santai holbogdson neelttei holbolt</param>
        public CategoryRepository(SQLiteConnection connection)
        {
            this.connection = connection;
        }

        /// <summary>
        /// Ogogdliin sangaas buh angilaliin medeelliig avchirna.
        /// </summary>
        /// <returns>Category obiektuudiin jagsaalt</returns>
        public List<Category> GetCategories()
        {
            var categories = new List<Category>();
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
            return categories;
        }

        /// <summary>
        /// Shine angilaliig ogogdliin sand nemen.
        /// </summary>
        /// <param name="name">Angilaliin ner</param>
        public void AddCategory(string name)
        {
            using (var command = new SQLiteCommand("INSERT INTO Categories (Name) VALUES (@Name)", connection))
            {
                command.Parameters.AddWithValue("@Name", name);
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Ogogdliin sand baigaa angilaliin neriig shinechilne.
        /// </summary>
        /// <param name="id">Shinecleh gej bui angilaliin ID</param>
        /// <param name="name">Shine ner</param>
        public void UpdateCategory(int id, string name)
        {
            using (var command = new SQLiteCommand("UPDATE Categories SET Name = @Name WHERE Id = @Id", connection))
            {
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Tuhain angilaliig bolon tuund hamaarah buh baraag ogogdliin sangaas ustgana.
        /// </summary>
        /// <param name="id">Ustgah gej bui angilaliin ID</param>
        public void DeleteCategory(int id)
        {
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
} 