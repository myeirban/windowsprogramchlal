using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary;
using System.IO;

namespace WinFormsApp
{
    public partial class AddForm : Form
    {

        private POSSystem posSystem;
        private ErrorProvider
        errorProvider;

        public AddForm(POSSystem posSystem)
        {
            InitializeComponent();
            this.posSystem = posSystem;
            this.errorProvider = new
            ErrorProvider();
            LoadCategories();
        }

        private void LoadCategories()
        {
            cmbCategory.Items.Clear();
            foreach (var category in posSystem.GetCategories())
            {
                cmbCategory.Items.Add(category.Name);
            }
        }

        private void AddForm_Load(object sender, EventArgs e)
        {
            LoadCategories();
        }

        private void picItemImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                openFileDialog.Title = "Select Product Image";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        picItemImage.Image = Image.FromFile(openFileDialog.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Зураг ачаалахад алдаа гарлаа: {ex.Message}", "Алдаа",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void txtItemCode_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtItemCode.Text))
            {
                errorProvider.SetError(txtItemCode, "Барааны код оруулна уу!");
            }
            else
            {
                errorProvider.SetError(txtItemCode, "");
            }
        }

        private void txtItemName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtItemName.Text))
            {
                errorProvider.SetError(txtItemName, "Барааны нэр оруулна уу!");
            }
            else
            {
                errorProvider.SetError(txtItemName, "");
            }
        }

        private void txtItemPrice_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtItemPrice.Text))
            {
                errorProvider.SetError(txtItemPrice, "Үнийг оруулна уу!");
            }
            else if (!decimal.TryParse(txtItemPrice.Text, out decimal price) || price <= 0)
            {
                errorProvider.SetError(txtItemPrice, "Үнийг зөв оруулна уу!");
            }
            else
            {
                errorProvider.SetError(txtItemPrice, "");
            }
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategory.SelectedIndex == -1)
            {
                errorProvider.SetError(cmbCategory, "Ангилал сонгоно уу!");
            }
            else
            {
                errorProvider.SetError(cmbCategory, "");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUploadPhoto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                openFileDialog.Title = "Select Product Image";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        picItemImage.Image = Image.FromFile(openFileDialog.FileName);
                        MessageBox.Show("Зураг амжилттай ачаалагдлаа!", "Мэдээлэл",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Зураг ачаалахад алдаа гарлаа: {ex.Message}", "Алдаа",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnSaveItem_Click(object sender, EventArgs e)
        {
            // Validate all required fields
            if (string.IsNullOrEmpty(txtItemName.Text) ||
                string.IsNullOrEmpty(txtItemPrice.Text) ||
                string.IsNullOrEmpty(txtItemCode.Text) ||
                cmbCategory.SelectedIndex == -1)
            {
                MessageBox.Show("Бүх талбарыг бөглөнө үү!", "Анхаар", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate price
            if (!decimal.TryParse(txtItemPrice.Text, out decimal price) || price <= 0)
            {
                MessageBox.Show("Үнийг зөв оруулна уу!", "Анхаар", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get category
            string categoryName = cmbCategory.SelectedItem?.ToString() ?? "";
            var category = posSystem.GetCategories().FirstOrDefault(c => c.Name == categoryName);
            if (category == null)
            {
                MessageBox.Show("Ангилал олдсонгүй!", "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Add product to system
            posSystem.AddProduct(
                txtItemName.Text,
                price,
                0, // Default stock
                category.Id,
                txtItemCode.Text
            );

            // Save image if exists
            if (picItemImage.Image != null)
            {
                try
                {
                    string imagePath = Path.Combine(Application.StartupPath, "Images", $"{txtItemCode.Text}.jpg");
                    Directory.CreateDirectory(Path.GetDirectoryName(imagePath));
                    picItemImage.Image.Save(imagePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Зураг хадгалахад алдаа гарлаа: {ex.Message}", "Анхаар",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            MessageBox.Show("Бараа амжилттай нэмэгдлээ!", "Мэдээлэл", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }


    public class ComboBoxItem
    {
        public string Text { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;

        public override string ToString()
        {
            return Text;
        }
    }
}