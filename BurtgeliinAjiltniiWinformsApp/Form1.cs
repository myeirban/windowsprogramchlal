using System;
using System.Data.SQLite;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;


namespace BurtgeliinAjiltniiWinformsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void loginform_close_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void loginform_register_btn_Click(object sender, EventArgs e)
        {
            RegisterForm regform = new RegisterForm();
            regform.Show();
            this.Hide();
        }

        SQLiteConnection conn;

        private void Loginform_login_btn_Click(object sender, EventArgs e)
        {
            string username = loginform_username_txt.Text;
            string password = loginform_pass_txt.Text;

           
            string dbPath = @"C:\Users\22B1NUM7158\Documents\C# summer\BurtgeliinAjiltniiWinformsApp\ogogdliinsan.db";
            string connectionString = $"Data Source={dbPath};Version=3;";

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open(); 

                    string query = "SELECT COUNT(*) FROM Users WHERE Username=@u AND Password=@p";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@u", username);
                        cmd.Parameters.AddWithValue("@p", password);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show("Login successful!");
                            this.Hide();
                            BurtgeliinAjiltniiAjillahForm form = new BurtgeliinAjiltniiAjillahForm();
                            form.Show();
                        }
                        else
                        {
                            MessageBox.Show("Wrong username or password!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

    }
}
