using System.Collections.Generic;
using System.Data.SQLite;
using ClassLibrary.Models;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace ClassLibrary.Repository
{
    /// <summary>
    /// SQLite ogogdliin sand hereglegchiin medeelliig udirdah zoriulalttai klass
    /// </summary>
    public class UserRepository
    {
        private SQLiteConnection connection;

        /// <summary>
        /// Shine obiektiig uusgene.
        /// </summary>
        /// <param name="connection">SQLite ogogdliin santai holbogdson neelttei holbolt</param>
        public UserRepository(SQLiteConnection connection)
        {
            this.connection = connection;
        }

        /// <summary>
        /// Hereglegchiin ner deer undeslen ogogdliin sangaas hereglegchiig avchirna.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public User GetUser(string username)
        {
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
            return null;
        }

        /// <summary>
        /// shine hereglegchiig ogogdliin sangiin Users husnegted nemen.
        /// </summary>
        /// <param name="user">nemeh gej bui obiekt</param>
        public void AddUser(User user)
        {
            using (var command = new SQLiteCommand("INSERT INTO Users (Username, Password, Role) VALUES (@Username, @Password, @Role)", connection))
            {
                command.Parameters.AddWithValue("@Username", user.Username);
                command.Parameters.AddWithValue("@Password", user.Password);
                command.Parameters.AddWithValue("@Role", user.Role);
                command.ExecuteNonQuery();
            }
        }

        // Other user related methods (e.g., UpdateUser, DeleteUser) can be added here
    }
} 