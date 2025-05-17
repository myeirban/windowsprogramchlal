using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;
using Microsoft.Data.Sqlite;
using ClassLibrary;
using ClassLibrary.Models;
using System.Drawing.Printing;

namespace WinFormsApp
{
    public partial class MainPosForm : Form
    {
        private POSSystem posSystem;
        private User currentUser;
        private List<SaleItem> currentSaleItems = new List<SaleItem>();
        private ErrorProvider errorProvider = new ErrorProvider();

        public MainPosForm(POSSystem posSystem, User user)
        {
            if (user == null)
            {
                MessageBox.Show("User not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            InitializeComponent();
            this.posSystem = posSystem;
            this.currentUser = user;
            lblUsername.Text = $"Кассчин: {user.Username}";

            LoadProducts();
            LoadCategories();
            SetupCartListView();

            // Event handler binding
            btnAddToCart.Click += btnAddToCart_Click;
            btnPay.Click += btnPay_Click;
            btnBaraa.Click += btnBaraa_Click;
            btnAngilal.Click += btnAngilal_Click;
            btnHelp.Click += btnHelp_Click;
            btnLogout.Click += btnLogout_Click;
            btnClose.Click += btnClose_Click;
            
        }


        private void SetupCartListView()
        {
            lstCart.MultiSelect = false;

            lstCart.FullRowSelect = true;
            lstCart.View = View.Details;
            lstCart.Columns.Clear();
            lstCart.Columns.Add("Бараа", 100);
            lstCart.Columns.Add("Тоо", 50);
            lstCart.Columns.Add("Үнэ", 80);
            lstCart.Columns.Add("Нийт", 80);
        }

        private void LoadProducts()
        {
            lstProducts.Controls.Clear();
            var products = posSystem.GetProducts();
            int y = 0;
            foreach (var product in products)
            {
                var button = new Button
                {
                    Text = $"{product.Name}\n{product.Price:C}",
                    Location = new Point(10, y),
                    Size = new Size(200, 50),
                    Tag = product
                };
                button.Click += ProductButton_Click;
                lstProducts.Controls.Add(button);
                y += 60;
            }
        }

        private void LoadCategories()
        {
            lstCategories.Controls.Clear();
            var categories = posSystem.GetCategories();
            int y = 0;
            foreach (var category in categories)
            {
                var button = new Button
                {
                    Text = category.Name,
                    Location = new Point(10, y),
                    Size = new Size(200, 50),
                    Tag = category
                };
                button.Click += CategoryButton_Click;
                lstCategories.Controls.Add(button);
                y += 60;
            }
        }

        private void ProductButton_Click(object? sender, EventArgs e)
        {
            if (sender is Button button && button.Tag is Product product)
            {
                AddToCart(product);
            }
        }

        private void CategoryButton_Click(object? sender, EventArgs e)
        {
            if (sender is Button button && button.Tag is Category category)
            {
                FilterProductsByCategory(category.Id);
            }
        }

        private void FilterProductsByCategory(int categoryId)
        {
            lstProducts.Controls.Clear();
            var products = posSystem.GetProducts().Where(p => p.CategoryId == categoryId);
            int y = 0;
            foreach (var product in products)
            {
                var button = new Button
                {
                    Text = $"{product.Name}\n{product.Price:C}",
                    Location = new Point(10, y),
                    Size = new Size(200, 50),
                    Tag = product
                };
                button.Click += ProductButton_Click;
                lstProducts.Controls.Add(button);
                y += 60;
            }
        }

        private void AddToCart(Product? product)
        {
            if (product == null) return;
            var existingItem = currentSaleItems.FirstOrDefault(item => item.Product.Id == product.Id);
            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                currentSaleItems.Add(new SaleItem { Product = product, Quantity = 1 });
            }
            UpdateCartDisplay();
        }

        private void UpdateCartDisplay()
        {
            lstCart.Items.Clear();
            decimal total = 0;
            int totalCount = 0;
            ListViewItem lastItem = null;
            foreach (var item in currentSaleItems)
            {
                var listViewItem = new ListViewItem(new[]
                {
                    item.Product.Name,
                    item.Quantity.ToString(),
                    item.Product.Price.ToString("C"),
                    item.Total.ToString("C")
                });
                listViewItem.Tag = item;
                lstCart.Items.Add(listViewItem);
                lastItem = listViewItem;
                total += item.Total;
                totalCount += item.Quantity;
            }
            lblNiitTolbor.Text = $"Нийт: {total:C}";
            lblTotalPriceText.Text = $"{total:C}";
            lblTotalItemText.Text = $"{totalCount}";

            // Шинээр нэмсэн барааг автоматаар сонгох
            if (lastItem != null)
                lastItem.Selected = true;
        }

        private void MainPosForm_Load(object sender, EventArgs e)
        {
            // Form load event handler
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Та системээс гарахдаа итгэлтэй байна уу?", "Гарах",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Login формыг нээх
                LoginForm loginForm = new LoginForm();
                loginForm.Show();

                // Одоогийн формыг хаах
                this.Close();
            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Та програмаас гарахдаа итгэлтэй байна уу?", "Гарах",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnAddToCart_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBarcode.Text))
            {
                MessageBox.Show("Барааны бар код оруулна уу!", "Анхаар",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var product = posSystem.GetProducts().FirstOrDefault(p => p.Barcode == txtBarcode.Text);
            if (product == null)
            {
                MessageBox.Show("Бараа олдсонгүй!", "Алдаа",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            AddToCart(product);
            txtBarcode.Clear();
        }

        private void PrintReceipt(List<SaleItem> items, string cashierName, decimal totalAmount, string paymentMethod)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += (sender, e) =>
            {
                Graphics graphics = e.Graphics;
                Font titleFont = new Font("Arial", 14, FontStyle.Bold);
                Font normalFont = new Font("Arial", 10);
                Font boldFont = new Font("Arial", 10, FontStyle.Bold);
                float yPos = 50;
                float leftMargin = e.MarginBounds.Left;
                float topMargin = e.MarginBounds.Top;

                // Print header
                graphics.DrawString("ХУДАЛДААНЫ БАРИМТ", titleFont, Brushes.Black, leftMargin, yPos);
                yPos += 30;
                graphics.DrawString($"Огноо: {DateTime.Now:yyyy-MM-dd HH:mm:ss}", normalFont, Brushes.Black, leftMargin, yPos);
                yPos += 20;
                graphics.DrawString($"Кассчин: {cashierName}", normalFont, Brushes.Black, leftMargin, yPos);
                yPos += 30;

                // Print items
                graphics.DrawString("Бараа", boldFont, Brushes.Black, leftMargin, yPos);
                graphics.DrawString("Тоо", boldFont, Brushes.Black, leftMargin + 150, yPos);
                graphics.DrawString("Үнэ", boldFont, Brushes.Black, leftMargin + 200, yPos);
                graphics.DrawString("Нийт", boldFont, Brushes.Black, leftMargin + 300, yPos);
                yPos += 20;

                foreach (var item in items)
                {
                    graphics.DrawString(item.Product.Name, normalFont, Brushes.Black, leftMargin, yPos);
                    graphics.DrawString(item.Quantity.ToString(), normalFont, Brushes.Black, leftMargin + 150, yPos);
                    graphics.DrawString(item.Product.Price.ToString("C"), normalFont, Brushes.Black, leftMargin + 200, yPos);
                    graphics.DrawString(item.Total.ToString("C"), normalFont, Brushes.Black, leftMargin + 300, yPos);
                    yPos += 20;
                }

                // Print total
                yPos += 20;
                graphics.DrawString("Нийт дүн:", boldFont, Brushes.Black, leftMargin + 200, yPos);
                graphics.DrawString(totalAmount.ToString("C"), boldFont, Brushes.Black, leftMargin + 300, yPos);
                yPos += 20;
                graphics.DrawString($"Төлбөрийн хэлбэр: {paymentMethod}", normalFont, Brushes.Black, leftMargin, yPos);
                yPos += 30;
                graphics.DrawString("Баярлалаа!", titleFont, Brushes.Black, leftMargin, yPos);
            };

            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = pd;
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                pd.Print();
            }
        }

        private void btnPay_Click(object? sender, EventArgs e)
        {
            if (currentSaleItems.Count == 0)
            {
                MessageBox.Show("Сагсанд бараа байхгүй байна!", "Анхаар",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var payForm = new PayForm(posSystem, new List<SaleItem>(currentSaleItems), currentUser.Username);
            if (payForm.ShowDialog() == DialogResult.OK)
            {
                decimal totalAmount = currentSaleItems.Sum(item => item.Total);
                PrintReceipt(currentSaleItems, currentUser.Username, totalAmount, payForm.PaymentMethod);
                currentSaleItems.Clear();
                UpdateCartDisplay();
                MessageBox.Show("Худалдаа амжилттай хийгдлээ!", "Мэдээлэл",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnBaraa_Click(object? sender, EventArgs e)
        {
            if (currentUser.Role != "Admin" && currentUser.Role != "Manager")
            {
                MessageBox.Show("Таны эрх хүрэхгүй байна!", "Алдаа",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var baraaniiManagementForm = new BaraaniiManagementForm(posSystem);
            baraaniiManagementForm.ShowDialog();
            LoadProducts();
        }

        private void btnAngilal_Click(object? sender, EventArgs e)
        {
            if (currentUser.Role != "Admin" && currentUser.Role != "Manager")
            {
                MessageBox.Show("Таны эрх хүрэхгүй байна!", "Алдаа",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var baraaniiAngilaliinManagementForm = new BaraaniiAngilaliinManagementForm(posSystem);
            baraaniiAngilaliinManagementForm.ShowDialog();
            LoadCategories();
        }

        private void btnHelp_Click(object? sender, EventArgs e)
        {
            MessageBox.Show(
                "Тусламж:\n\n" +
                "1. Бараа нэмэх: Барааны бар код оруулж 'Нэмэх' товчлуур дараарай\n" +
                "2. Тоо ширхэг нэмэх/хасах: Сагсан дахь барааг сонгож '+/-' товчлуур дараарай\n" +
                "3. Төлбөр төлөх: 'Төлөх' товчлуур дараарай\n" +
                "4. Бараа/Ангилал удирдах: 'Бараа' эсвэл 'Ангилал' товчлуур дараарай",
                "Тусламж",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void btnAddToCart_Click_1(object sender, EventArgs e)
        {

        }

        private void btnPay_Click_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void lblTotalItemText_Click(object sender, EventArgs e)
        {

        }

        private void btnHelp_Click_1(object sender, EventArgs e)
        {

        }

        private void lblNiitTolbor_Click(object sender, EventArgs e)
        {

        }

        private void lblUsername_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnBaraa_Click_1(object sender, EventArgs e)
        {

        }

        private void lstCart_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnIncreaseQty_Click(object sender, EventArgs e)
        {
            if (lstCart.SelectedItems.Count == 0) return;

            var selectedItem = lstCart.SelectedItems[0];
            var saleItem = selectedItem.Tag as SaleItem;

            if (saleItem != null)
            {
                saleItem.Quantity++;
                UpdateCartDisplay();

                // дахин сонгох
                foreach (ListViewItem item in lstCart.Items)
                {
                    if (item.Tag == saleItem)
                    {
                        item.Selected = true;
                        break;
                    }
                }
            }
        }
        private void btnDecreaseQty_Click(object sender, EventArgs e)
        {
            if (lstCart.SelectedItems.Count == 0) return;

            var selectedItem = lstCart.SelectedItems[0];
            var saleItem = selectedItem.Tag as SaleItem;

            if (saleItem != null)
            {
                if (saleItem.Quantity > 1)
                {
                    saleItem.Quantity--;
                }
                else
                {
                    currentSaleItems.Remove(saleItem);
                }
                UpdateCartDisplay();

                // дахин сонгох
                foreach (ListViewItem item in lstCart.Items)
                {
                    if (item.Tag == saleItem)
                    {
                        item.Selected = true;
                        break;
                    }
                }
            }
        }

        

    }
}
