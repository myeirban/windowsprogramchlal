using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary.Models;
using ClassLibrary;

namespace WinFormsApp
{
    public partial class EditForm : Form
    {
        private POSSystem posSystem;
        private Product product;

        public EditForm(POSSystem posSystem, Product product)
        {
            InitializeComponent();
            this.posSystem = posSystem;
            this.product = product;
            LoadCategories();
            LoadProductData();
        }

        private void LoadCategories()
        {
            cmbEditCategory.Items.Clear();
            foreach (var category in posSystem.GetCategories())
            {
                cmbEditCategory.Items.Add(category.Name);
            }
        }

        private void LoadProductData()
        {
            if (product == null) return;

            txtEditName.Text = product.Name;
            txtEditPrice.Text = product.Price.ToString();
            txtEditCode.Text = product.Barcode;

            var category = posSystem.GetCategories().FirstOrDefault(c => c.Id == product.CategoryId);
            if (category != null)
            {
                cmbEditCategory.SelectedItem = category.Name;
            }
        }


        private void btnSaveEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEditName.Text) ||
                string.IsNullOrEmpty(txtEditPrice.Text) ||
                string.IsNullOrEmpty(txtEditCode.Text) ||
                cmbEditCategory.SelectedIndex == -1)
            {
                MessageBox.Show("Бүх талбарыг бөглөнө үү!", "Анхаар", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtEditPrice.Text, out decimal price) || price <= 0)
            {
                MessageBox.Show("Үнийг зөв оруулна уу!", "Анхаар", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Stock field is missing in designer, so we skip it for now
            int stock = 0;

            string categoryName = cmbEditCategory.SelectedItem?.ToString() ?? "";
            var category = posSystem.GetCategories().FirstOrDefault(c => c.Name == categoryName);
            if (category == null)
            {
                MessageBox.Show("Ангилал олдсонгүй!", "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            posSystem.UpdateProduct(
                product.Id,
                txtEditName.Text,
                price,
                stock,
                category.Id,
                txtEditCode.Text
            );

            MessageBox.Show("Барааны мэдээлэл амжилттай шинэчлэгдлээ!", "Мэдээлэл", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelEdit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // textBox1-д текст өөрчлөгдөхөд дуудагдах эвент
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Энд та хүссэн кодаа бичиж болно
            // Жишээ нь: MessageBox харуулах
            // MessageBox.Show("Item Code changed!");
        }

        private void picEditImage_Click(object sender, EventArgs e)
        {

        }

        private void txtEditName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEditPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbEditCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdatePhoto_Click(object sender, EventArgs e)
        {

        }

        private void btnSaveEdit_Click_1(object sender, EventArgs e)
        {

        }

        private void btnCancelEdit_Click_1(object sender, EventArgs e)
        {

        }
    }
}
