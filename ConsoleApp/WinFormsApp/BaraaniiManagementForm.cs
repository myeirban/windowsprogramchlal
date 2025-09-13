using ClassLibrary;
using ClassLibrary.Models;

namespace WinFormsApp
{
    /// <summary>
    /// Pos systemiin baraa,angilaliig udirdah form.
    /// Baraa nemeh ,zasah ,ustgah ,angilal uusgeh,baraa haruulah uildluud hiideg.
    /// </summary>
    public partial class BaraaniiManagementForm : Form
    {
        private POSSystem posSystem;
        private ComboBox cmbCategories;
        private Button btnAddCategory;
        private TextBox txtNewCategory;

        /// <summary>
        /// BaraaniiManagementForm-g uusgene.
        /// </summary>
        /// <param name="posSystem">POS sistemiin undsen obiekt</param>
        /// <param name="owner">Ene formiig duudaj bui etseg form</param>
        public BaraaniiManagementForm(POSSystem posSystem, Form owner)
        {
            InitializeComponent();
            this.posSystem = posSystem;
            this.Owner = owner;
            SetupProductColumns();
            LoadProducts();
            LoadCategoriesGrid();
        }



        /// <summary>
        /// Angilaliin Grid-g achaalah(odoogoor hooson heregjuulelttei).
        /// </summary>
        private void LoadCategoriesGrid()
        {

            var categories = posSystem.CategoryRepository.GetCategories();
            foreach (var category in categories)
            {

            }
        }


        /// <summary>
        /// Shihe angilal nemeh tovch darsnii daraah uildel.
        /// </summary>
        /// <param name="sender">Ihenh tohioldol btnAddCategory tovch ooroo bn</param>
        /// <param name="e">Tovch daragdah yed uussen event -iin medeelel</param>
        private void BtnAddCategory_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNewCategory.Text))
            {
                MessageBox.Show("Ангилалын нэрийг оруулна уу!", "Анхаар", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                posSystem.CategoryRepository.AddCategory(txtNewCategory.Text);
                LoadCategoriesGrid();
                txtNewCategory.Clear();
                MessageBox.Show("Ангилал амжилттай нэмэгдлээ!", "Мэдээлэл", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Алдаа гарлаа: {ex.Message}", "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Baraanii husnegtiin baganuudiig tohiruulna.
        /// </summary>
        private void SetupProductColumns()
        {
            lstProducts.Columns.Clear();

            lstProducts.Columns.Add("Id", "ID");
            lstProducts.Columns.Add("Name", "Барааны нэр");
            lstProducts.Columns.Add("Price", "Үнэ");
            lstProducts.Columns.Add("Stock", "Тоо");
            lstProducts.Columns.Add("Barcode", "Баркод");
            lstProducts.Columns.Add("Category", "Ангилал");

            lstProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            lstProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            lstProducts.MultiSelect = false;
            lstProducts.ReadOnly = true;
        }

        /// <summary>
        /// Buh baraanuudiig jagsaaltad achaalj haruulna.
        /// </summary>
        private void LoadProducts()
        {
            lstProducts.Rows.Clear();
            foreach (var product in posSystem.ProductRepository.GetProducts())
            {
                lstProducts.Rows.Add(
                    product.Id,
                    product.Name,
                    product.Price,
                    product.Stock,
                    product.Barcode,
                    GetCategoryName(product.CategoryId)
                );
            }
        }

        /// <summary>
        /// Angilaliin ID aar neriig butsaana.
        /// </summary>
        /// <param name="categoryId">Angilaliin ID utga</param>
        /// <returns>Angilaliin ner(Oldoogui bol hooson string)</returns>
        private string GetCategoryName(int categoryId)
        {
            var category = posSystem.CategoryRepository.GetCategories().FirstOrDefault(c => c.Id == categoryId);
            return category?.Name ?? "";
        }
        /// <summary>
        /// shine baraa nemeh tovch darahad ded form neej baraag nemne.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddProduct_Click_1(object sender, EventArgs e)
        {
            
            

            AddForm addForm = new AddForm(posSystem, null);
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadProducts();
            }
        }
        /// <summary>
        /// Songoson baraag zasah uildel hiideg
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditProduct_Click_1(object sender, EventArgs e)
        {
            if (lstProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Засах бараагаа сонгоно уу!", "Анхаар", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = lstProducts.SelectedRows[0];
            int productId = Convert.ToInt32(selectedRow.Cells[0].Value);
            var product = posSystem.ProductRepository.GetProductById(productId);

            EditForm editForm = new EditForm(posSystem, product);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadProducts();
            }
        }

        /// <summary>
        /// Songoson baraag ustgah uildel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteProduct_Click_1(object sender, EventArgs e)
        {
            if (lstProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Устгах бараагаа сонгоно уу!", "Анхаар", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Та энэ барааг устгахдаа итгэлтэй байна уу?", "Анхаар", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                var selectedRow = lstProducts.SelectedRows[0];
                int productId = Convert.ToInt32(selectedRow.Cells[0].Value);
                posSystem.ProductRepository.DeleteProduct(productId);
                LoadProducts();
            }
        }

        /// <summary>
        /// Butsah tovch darsan ued formiig haana.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            this.Dispose();
        }

        /// <summary>
        /// Husnegten deer darsan yed tuhain baraag sagsand nemne.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var row = lstProducts.Rows[e.RowIndex];
            int productId = Convert.ToInt32(row.Cells["Id"].Value);
            var product = posSystem.ProductRepository.GetProductById(productId);

            if (product != null)
            {
                var mainForm = this.Owner as MainPosForm;
                if (mainForm != null)
                {
                    mainForm.AddToCart(product);
                    MessageBox.Show($"{product.Name} сагсанд нэмэгдлээ!", "Мэдээлэл", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        /// <summary>
        /// Form achaalahad ajillah event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BaraaniiManagementForm_Load(object sender, EventArgs e)
        {

        }

        
    }
}
