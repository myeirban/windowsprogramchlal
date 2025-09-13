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
using ClassLibrary.Repository;

namespace WinFormsApp
{
    /// <summary>
    /// Baraanii medeelliig zasah zoriulalttai form.
    /// Ner ,une ,angilal,barkod zereg medeelliig shinechleh bolomjtoi.
    /// </summary>
    public partial class EditForm : Form
    {
        private POSSystem posSystem;
        private ClassLibrary.Models.Product product;

        /// <summary>
        /// Edit form iin shine huulbariig uusgene.
        /// </summary>
        /// <param name="posSystem"></param>
        /// <param name="product"></param>
        public EditForm(POSSystem posSystem, ClassLibrary.Models.Product product)
        {
            InitializeComponent();
            this.posSystem = posSystem;
            this.product = product;
            LoadCategories();
            LoadProductData();
        }

        
        /// <summary>
        /// POS systemees buh angilaliig achaalj ComboBox-d haruulan.
        /// </summary>
        private void LoadCategories()
        {
            cmbEditCategory.Items.Clear();
            foreach (var category in posSystem.CategoryRepository.GetCategories())
            {
                cmbEditCategory.Items.Add(category.Name);
            }
        }

        /// <summary>
        /// zasah gej bui baraanii medeelliig talbaruud deer haruulna.
        /// </summary>
        private void LoadProductData()
        {
            if (product == null) return;

            txtEditName.Text = product.Name;
            txtEditPrice.Text = product.Price.ToString();
            txtEditCode.Text = product.Barcode;

            var category = posSystem.CategoryRepository.GetCategories().FirstOrDefault(c => c.Id == product.CategoryId);
            if (category != null)
            {
                cmbEditCategory.SelectedItem = category.Name;
            }
        }

        /// <summary>
        /// Hadgalah tovch daragdahad baraanii medeelliig shinechlene.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveEdit_Click(object sender, EventArgs e)
        {
            try
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
                var category = posSystem.CategoryRepository.GetCategories().FirstOrDefault(c => c.Name == categoryName);
                if (category == null)
                {
                    MessageBox.Show("Ангилал олдсонгүй!", "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                posSystem.ProductRepository.UpdateProduct(
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
            catch (Exception ex)
            {
                MessageBox.Show($"Алдаа гарлаа: {ex.Message}", "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Bolih tovch darsan yed form -g haana.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelEdit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Neriin talbar oorclogdoh yed(Validatsi hiihed ashiglana.)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtEditName_TextChanged(object sender, EventArgs e)
        {
            // Validate name if needed
        }

        /// <summary>
        /// Une oorclogdoh yed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtEditPrice_TextChanged(object sender, EventArgs e)
        {
            // Validate price if needed
        }
        /// <summary>
        /// Angilal songogdson yed heregjih logic
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbEditCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Handle category change if needed
        }

        /// <summary>
        /// Zurag shinecleh tovch darsan yed heregjih event,odoogoor asiglaagui
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdatePhoto_Click(object sender, EventArgs e)
        {
            // Handle photo update if needed
        }
    }
}
