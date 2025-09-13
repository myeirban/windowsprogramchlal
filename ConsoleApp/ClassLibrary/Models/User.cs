namespace ClassLibrary.Models
{
    /// <summary>
    /// sistemiin hereglegchiin medeelliig ilerhiildeg klass.
    /// </summary>
    public class User
    {
        /// <summary>
        /// hereglegchiin davtagdashgui dugaar
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// hereglegchiin nevtreh ner
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// hereglegchiin nuuts ug
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// hereglegchiin erhiin tuvshin
        /// </summary>
        public string Role { get; set; }
    }
} 