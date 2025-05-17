using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ClassLibrary;

namespace WinFormsApp
{
    public partial class BaraaniiManagementForm : Form
    {
        private POSSystem posSystem;

        public BaraaniiManagementForm(POSSystem posSystem)
        {
            InitializeComponent();
            this.posSystem = posSystem;
            SetupProductColumns(); // ← Багануудыг нэмэх
            LoadProducts();        // ← Өгөгдлийг ачаалах
        }

        private void SetupProductColumns()
        {
            lstProducts.Columns.Clear();

            lstProducts.Columns.Add("Id", "ID");
            lstProducts.Columns.Add("Name", "Барааны нэр");
            lstProducts.Columns.Add("Price", "Үнэ");
            lstProducts.Columns.Add("Stock", "Тоо");
            lstProducts.Columns.Add("Barcode", "Баркод");
            lstProducts.Columns.Add("Category", "Ангилал");

            lstProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Автомат багана өргөн
            lstProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;    // Нэг мөр сонгох
            lstProducts.MultiSelect = false; // Зөвхөн 1 мөр сонгоно
            lstProducts.ReadOnly = true;     // Зөвхөн харах (өөрчлөхгүй)
        }

        private void LoadProducts()
        {
            lstProducts.Rows.Clear();
            foreach (var product in posSystem.GetProducts())
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

        private string GetCategoryName(int categoryId)
        {
            var category = posSystem.GetCategories().FirstOrDefault(c => c.Id == categoryId);
            return category?.Name ?? "";
        }

        private void btnAddProduct_Click_1(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm(posSystem);
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadProducts();
            }
        }

        private void btnEditProduct_Click_1(object sender, EventArgs e)
        {
            if (lstProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Засах бараагаа сонгоно уу!", "Анхаар", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = lstProducts.SelectedRows[0];
            int productId = Convert.ToInt32(selectedRow.Cells[0].Value);
            var product = posSystem.GetProductById(productId);

            EditForm editForm = new EditForm(posSystem, product);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadProducts();
            }
        }

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
                posSystem.DeleteProduct(productId);
                LoadProducts();
            }
        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lstProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Хэрэгтэй бол энд засах, устгах товч нэмэж болно
        }
    }
}
