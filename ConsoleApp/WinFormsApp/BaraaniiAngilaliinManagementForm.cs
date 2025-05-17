using System;
using System.Windows.Forms;
using ClassLibrary;


namespace WinFormsApp
{
    public partial class BaraaniiAngilaliinManagementForm : Form
    {
        private POSSystem posSystem;

        public BaraaniiAngilaliinManagementForm(POSSystem posSystem)
        {
            InitializeComponent();
            this.posSystem = posSystem;
            LoadCategories();
        }

        private void LoadCategories()
        {
            lstCategories.Rows.Clear();
            lstCategories.Columns.Clear();

            lstCategories.Columns.Add("Id", "ID");
            lstCategories.Columns.Add("Name", "Ангилалын нэр");

            foreach (var category in posSystem.GetCategories())
            {
                lstCategories.Rows.Add(category.Id, category.Name);
            }
        }

        // Ангилал нэмэх
        private void btnAddCategory_Click_1(object sender, EventArgs e)
        {
            string categoryName = txtCategoryName.Text.Trim();
            if (string.IsNullOrEmpty(categoryName))
            {
                MessageBox.Show("Ангилалын нэрийг оруулна уу!", "Анхаар", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            posSystem.AddCategory(categoryName);
            txtCategoryName.Clear();
            LoadCategories();
            MessageBox.Show("Ангилал амжилттай нэмэгдлээ!", "Мэдээлэл", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Ангилал устгах
        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            if (lstCategories.SelectedRows.Count == 0)
            {
                MessageBox.Show("Устгах ангилалаа сонгоно уу!", "Анхаар", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Та энэ ангилалыг устгахдаа итгэлтэй байна уу?\nЭнэ ангилалд байгаа бүх бараа мөн устгагдана!", 
                "Анхаар", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            
            if (result == DialogResult.Yes)
            {
                var selectedRow = lstCategories.SelectedRows[0];
                int categoryId = Convert.ToInt32(selectedRow.Cells[0].Value);
                posSystem.DeleteCategory(categoryId);
                LoadCategories();
                MessageBox.Show("Ангилал амжилттай устгагдлаа!", "Мэдээлэл", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Back clicked");
            this.Close();
        }

        // Хоосон эвэнтүүд
        private void txtCategoryName_TextChanged(object sender, EventArgs e) { }
        private void btnEditCategory_Click(object sender, EventArgs e) { }
        private void lstCategories_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}
