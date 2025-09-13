using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace BurtgeliinAjiltniiWinformsApp
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void registerform_close_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void registerform_signin_btn_Click(object sender, EventArgs e)
        {
            Form1 loginForm = new Form1();
            loginForm.Show();

            this.Hide();
        }

        private void registerform_signup_btn_Click(object sender, EventArgs e)
        {
            string username = registerform_username_txt.Text.Trim();
            string password = registerform_password_txt.Text.Trim();
            string confirm = registerform_confirmpass_txt.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            if (password != confirm)
            {
                MessageBox.Show("Passwords do not match");
                return;
            }



            string connStr = "Data source= C:\\Users\\22B1NUM7158\\Documents\\C# summer\\BurtgeliinAjiltniiWinformsApp\\OgogdliinSan.db;Version=3;";


            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                try
                {
                    conn.Open();


                    string checkQuery = "SELECT COUNT(*) FROM users WHERE username=@u";

                    using (SQLiteCommand checkCmd = new SQLiteCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@u", username);
                        int exists = Convert.ToInt32(checkCmd.ExecuteScalar());


                        if (exists > 0)
                        {
                            MessageBox.Show("Username already exists");
                            return;
                        }
                    }

                    string query = "INSERT INTO users (username,password) VALUES (@u , @p)";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@u", username);
                        cmd.Parameters.AddWithValue("@p", password);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Account created successfully");

                        Form1 loginform = new Form1();
                        loginform.Show();
                        this.Hide();


                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("error" + ex.Message);
                }
            }
        }





                        private void registerform_username_txt_TextChanged(object sender, EventArgs e)
                        {

                        }

        private void registerform_password_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void registerform_confirmpass_txt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
