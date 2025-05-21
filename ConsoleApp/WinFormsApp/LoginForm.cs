using System;
using System.Windows.Forms;
using System.Collections.Generic;
using ClassLibrary;

namespace WinFormsApp
{
    /// <summary>
    /// POS systemiin nevtreh form.
    /// Hereglegch hereglegchiin ner,nuuts ugeer nevtreh bolomjtoi
    /// Amjilttai nevtervel MainPosForm -g neene.
    /// </summary>
    public partial class LoginForm : Form
    {
        /// <summary>
        /// POS systemiin ogogdliin sangiin bairshliig zaana.
        /// </summary>
        private POSSystem posSystem;
        private const string DB_PATH = @"C:\Users\22B1NUM7158\Documents\school\windowsprogramchlal\ConsoleApp\miniidatabase";

        /// <summary>
        /// Login Form-iin shine huulbariig uusgeh baiguulagch
        /// POS sistemiig initsializ hiideg.
        /// </summary>
        public LoginForm()
        {
            InitializeComponent();
            posSystem = new POSSystem(DB_PATH);
        }

        /// <summary>
        /// Form achaalagdah yed heregjih event,odoogoor hooson.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Hereglegchiin neriin text talbar oorclogdoh yed 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void usernametxtbox_TextChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Login tovch darsnii daraah nevtreh logic
        /// amjilttai bolbol MainPosForm-g neene.Amjiltgui bol anhaaruulga haruulan.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                var mainForm = new MainPosForm(posSystem, user);

                //  Main форм хаагдвал LoginForm дахин гарч ирэх
                mainForm.FormClosed += (s, args) => this.Show();

                this.Hide();
                mainForm.Show(); // ShowDialog биш
            }
            else
            {
                MessageBox.Show("Нэвтрэх нэр эсвэл нууц үг буруу байна!", "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// sistemees garah tovch darsan yed programiig haana.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Hereglegchiin ner bicih talbriin text oorclogdoh yed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Nuuts ug bicih talbariin text oorclogdoh yed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Panel deer zurj baigaa event,ashiglaagui
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}