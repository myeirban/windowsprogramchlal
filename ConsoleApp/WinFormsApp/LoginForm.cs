using System;
using System.Windows.Forms;
using System.Collections.Generic;
using ClassLibrary;

namespace WinFormsApp
{
    public partial class LoginForm : Form
    {
        private POSSystem posSystem;
        private const string DB_PATH = @"C:\Users\22B1NUM7158\Documents\school\windowsprogramchlal\ConsoleApp\miniidatabase";

        public LoginForm()
        {
            InitializeComponent();
            posSystem = new POSSystem(DB_PATH);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void usernametxtbox_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Нэвтрэх нэр болон нууц үгээ оруулна уу!", "Анхаар", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (posSystem.Login(username, password))
            {
                var user = posSystem.GetUser(username);
                MainPosForm mainForm = new MainPosForm(posSystem, user);
                this.Hide();
                mainForm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Нэвтрэх нэр эсвэл нууц үг буруу байна!", "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}