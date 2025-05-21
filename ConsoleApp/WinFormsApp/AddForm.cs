using System;
using System.Windows.Forms;
using ClassLibrary;
using ClassLibrary.Models;
using System.Linq;

namespace WinFormsApp
{
    /// <summary>
    /// Shine baraa nemeh zoriulalttai form.
    /// Hereglegch baraanii ner,une,barkod,angilal bolon zurag oruulj ,burtgeh bolomjtoi
    /// </summary>
    public partial class AddForm : Form
    {
        private POSSystem posSystem;
        private Category selectedCategory;
        private readonly string imageSaveDirectory = Path.Combine(Application.StartupPath, "Images");

        /// <summary>
        /// Addform iin shine huulbariig  uusgej ,angilaliig songoj tohiruulna
        /// </summary>
        /// <param name="posSystem">Pos systeminn undsen logic</param>
        /// <param name="category">Ug form neegdehed avtomataar songogdoh angilal</param>
        public AddForm(POSSystem posSystem, Category category)
        {
            InitializeComponent();
            this.posSystem = posSystem;
            this.selectedCategory = category;
            LoadCategories();
            if (category != null)
            {
                cmbCategory.SelectedItem = category;
            }
        }
        /// <summary>
        /// Angilaluudiig ComboBox-d achaalna.
        /// </summary>
        private void LoadCategories()
        {
            cmbCategory.Items.Clear();
            var categories = posSystem.CategoryRepository.GetCategories();

            cmbCategory.DisplayMember = "Name";

            foreach (var category in categories)
            {
                cmbCategory.Items.Add(category);
            }

            if (cmbCategory.Items.Count > 0 && selectedCategory == null)
                cmbCategory.SelectedIndex = 0;
        }

        /// <summary>
        /// Hereglegch save tovch darsan yed baraag burtgene.
        /// Mon dabhardsan bar kod shalgaj,zurag hadgalah uildel hiine.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtItemCode.Text) ||
                string.IsNullOrEmpty(txtItemName.Text) ||
                string.IsNullOrEmpty(txtItemPrice.Text) ||
                string.IsNullOrEmpty(txtItemStock.Text) ||
                cmbCategory.SelectedIndex == -1)
            {
                MessageBox.Show("Бүх талбарыг бөглөнө үү!", "Анхаар", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ID
            if (!int.TryParse(txtItemCode.Text, out int itemId) || itemId < 0)
            {
                MessageBox.Show("ID-г зөв оруулна уу!", "Анхаар", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ҮНЭ
            if (!decimal.TryParse(txtItemPrice.Text, out decimal price) || price <= 0)
            {
                MessageBox.Show("Үнийг зөв оруулна уу!", "Анхаар", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // НӨӨЦ
            if (!int.TryParse(txtItemStock.Text, out int stock) || stock < 0)
            {
                MessageBox.Show("Нөөцийн тоог зөв оруулна уу!", "Анхаар", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var category = cmbCategory.SelectedItem as Category;
            if (category == null)
            {
                MessageBox.Show("Ангилал олдсонгүй!", "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Давхар ID шалгах
            var existingId = posSystem.ProductRepository.GetProducts()
                                  .FirstOrDefault(p => p.Id == itemId);
            if (existingId != null)
            {
                MessageBox.Show("Энэ ID-тай бараа бүртгэгдсэн байна!", "Анхаар", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Бар код давхардал шалгах
            var existingProduct = posSystem.ProductRepository.GetProducts()
                                         .FirstOrDefault(p => p.Barcode == txtItemCode.Text);
            if (existingProduct != null)
            {
                MessageBox.Show("Энэ бар кодтой бараа бүртгэгдсэн байна!", "Анхаар", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Шинэ бүтээгдэхүүн үүсгэх
            Product product = new()
            {
                Id = itemId,
                Name = txtItemName.Text,
                Price = price,
                Stock = stock,
                CategoryId = category.Id,
                Barcode = txtItemCode.Text
            };

            posSystem.ProductService.AddProductWithImage(product, picItemImage.Image as Image, imageSaveDirectory);

            MessageBox.Show("Бараа амжилттай нэмэгдлээ!", "Мэдээлэл", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        /// <summary>
        /// Hereglegch Cancel tovch darsan yed formiig haana.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Zurag oruulah tovch darsan yed zurag songoj haruulah logic.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUploadPhoto_Click(object sender, EventArgs e)
        {
            // TODO: Implement photo upload logic
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.gif; *.bmp)|*.jpg; *.jpeg; *.png; *.gif; *.bmp|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    picItemImage.Image = new System.Drawing.Bitmap(openFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Зургийг уншихад алдаа гарлаа: " + ex.Message, "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Angilal songogdohod hiih uiliig todorhoiloh gazar.
        /// odoogoor btnSaveItem_Click-d ashiglagdaj baigaa.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TODO: Implement category selection logic
            // The selected category is already used in btnSaveItem_Click
            // Add any additional logic here if needed.
        }

        /// <summary>
        /// Une oruulah talbart oorclolt hiihed validats hiih bolomjtoi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtItemPrice_TextChanged(object sender, EventArgs e)
        {
            // TODO: Implement price text changed logic
            // Basic validation: Ensure the text is a valid decimal.
            if (!string.IsNullOrEmpty(txtItemPrice.Text) && !decimal.TryParse(txtItemPrice.Text, out _))
            {
                // You might want to provide visual feedback to the user, e.g., change background color or show an error icon.
            }
        }

        /// <summary>
        /// Baraanii ner oorclogdoh yed heregjih logic bicih heseg.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtItemName_TextChanged(object sender, EventArgs e)
        {
            // TODO: Implement name text changed logic
            // Add any validation or formatting for the item name here.
        }

        /// <summary>
        /// Barkodiin text oorclogdoh yed heregjih logic bicih heseg.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtItemCode_TextChanged(object sender, EventArgs e)
        {
            // TODO: Implement code text changed logic
            // Add any validation or formatting for the item code (barcode) here.
            // You might also want to check for duplicate barcodes.
        }

        /// <summary>
        /// Zurag deer darsan yed zurag oruulah uildliig dahin ehluulne.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picItemImage_Click(object sender, EventArgs e)
        {
            // TODO: Implement image click logic
            // Link this to the photo upload button click.
            btnUploadPhoto_Click(sender, e);
        }

        /// <summary>
        /// Label deer darsan heregjih logic.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label1_Click(object sender, EventArgs e)
        {
            // TODO: Implement label click logic
            // This is likely a placeholder. Add any specific logic if needed.
        }

        private void txtItemStock_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
