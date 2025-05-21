using System;
using System.Windows.Forms;
using ClassLibrary;
using ClassLibrary.Models;
using ClassLibrary.Repository;
using ClassLibrary.Service;

namespace WinFormsApp
{
    /// <summary>
    /// POS sistem dehi baraanii angilaliig udirdah form.
    /// Angilal nemeh,ustgah,zasah,jagsaah,zereg uildliig guitsgetgene.
    /// </summary>
    public partial class BaraaniiAngilaliinManagementForm : Form
    {
        private POSSystem posSystem;

        /// <summary>
        /// Form-g uusgeh yed POS sistemiin obiekt damjuulj abna.
        /// </summary>
        /// <param name="posSystem">Pos systemiin undsen logic</param>
        public BaraaniiAngilaliinManagementForm(POSSystem posSystem)
        {
            InitializeComponent();
            this.posSystem = posSystem;
            LoadCategories();
        }

        /// <summary>
        /// Angilaliin jagsaaltiig Grid-d achaalj haruulna.
        /// </summary>
        private void LoadCategories()
        {
            lstCategories.Rows.Clear();
            lstCategories.Columns.Clear();

            lstCategories.Columns.Add("Id", "ID");
            lstCategories.Columns.Add("Name", "Ангилалын нэр");

            foreach (var category in posSystem.CategoryRepository.GetCategories())
            {
                lstCategories.Rows.Add(category.Id, category.Name);
            }
        }

        /// <summary>
        /// 
        /// Angilal nemeh tovch daragdah yed hiigdeh uildel.
        /// </summary>
        /// <param name="sender">Tovch obiekt</param>
        /// <param name="e">Event argument</param>
        private void btnAddCategory_Click_1(object sender, EventArgs e)
        {
            string categoryName = txtCategoryName.Text.Trim();
            if (string.IsNullOrEmpty(categoryName))
            {
                MessageBox.Show("Ангилалын нэрийг оруулна уу!", "Анхаар", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            posSystem.CategoryRepository.AddCategory(categoryName);
            txtCategoryName.Clear();
            LoadCategories();
            MessageBox.Show("Ангилал амжилттай нэмэгдлээ!", "Мэдээлэл", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Songoson angilaliig ustgah tovch daragdsan yed ajillana.
        /// </summary>
        /// <param name="sender">Tovch</param>
        /// <param name="e">Event argument</param>
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
                posSystem.CategoryRepository.DeleteCategory(categoryId);
                LoadCategories();
                MessageBox.Show("Ангилал амжилттай устгагдлаа!", "Мэдээлэл", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// lstCategories DataGridView-g butsaadag tuslah funkts.
        /// </summary>
        /// <returns>Angillaliin DataGRidView</returns>
        private DataGridView GetLstCategories()
        {
            return lstCategories;
        }

        /// <summary>
        /// Angilal zasah tovch darah yed shine tsonh neej,neriig zasah bolomj olgodog.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditCategory_Click(object sender, EventArgs e)
        {
            if (lstCategories.SelectedRows.Count == 0)
            {
                MessageBox.Show("Засах ангилалаа сонгоно уу!", "Анхаар", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = lstCategories.SelectedRows[0];
            int categoryId = Convert.ToInt32(selectedRow.Cells[0].Value);
            string currentName = selectedRow.Cells[1].Value.ToString();

            // Засах цонх үүсгэх
            using (var editForm = new Form())
            {
                editForm.Text = "Ангилал засах";
                editForm.Size = new System.Drawing.Size(400, 150);
                editForm.StartPosition = FormStartPosition.CenterParent;

                var label = new Label
                {
                    Text = "Ангилалын нэр:",
                    Location = new System.Drawing.Point(20, 20),
                    AutoSize = true
                };

                var textBox = new TextBox
                {
                    Text = currentName,
                    Location = new System.Drawing.Point(20, 50),
                    Size = new System.Drawing.Size(340, 23)
                };

                var saveButton = new Button
                {
                    Text = "Хадгалах",
                    DialogResult = DialogResult.OK,
                    Location = new System.Drawing.Point(180, 80)
                };

                var cancelButton = new Button
                {
                    Text = "Болих",
                    DialogResult = DialogResult.Cancel,
                    Location = new System.Drawing.Point(280, 80)
                };

                editForm.Controls.AddRange(new Control[] { label, textBox, saveButton, cancelButton });
                editForm.AcceptButton = saveButton;
                editForm.CancelButton = cancelButton;

                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    string newName = textBox.Text.Trim();
                    if (string.IsNullOrEmpty(newName))
                    {
                        MessageBox.Show("Ангилалын нэрийг оруулна уу!", "Анхаар", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    try
                    {
                        posSystem.CategoryRepository.UpdateCategory(categoryId, newName);
                        LoadCategories();
                        MessageBox.Show("Ангилал амжилттай шинэчлэгдлээ!", "Мэдээлэл", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Алдаа гарлаа: {ex.Message}", "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        /// <summary>
        /// Butsah tovch daragdahad formiig haah uildel hiine,
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click_1(object sender, EventArgs e)
        {

            this.Hide();
            this.Dispose();
        }


        /// <summary>
        /// Angilaliin ner bicih talbart oorclolt orson yed,ashiglaagui
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCategoryName_TextChanged(object sender, EventArgs e) { }

        /// <summary>
        /// Angilaliin husnegten deer darsan yed,ashiglaagui.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstCategories_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}
