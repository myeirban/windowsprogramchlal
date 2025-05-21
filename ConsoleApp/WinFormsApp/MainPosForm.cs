using System.Data;
using ClassLibrary;
using ClassLibrary.Models;

namespace WinFormsApp
{
    /// <summary>
    /// anh nevterch oroh yed haragdah delgets
    /// Kasschin baraa songoh ,sags uusgeh, tolbor hiih ,angilal udirdah zerg uildluudiig hiideg.
    /// </summary>
    public partial class MainPosForm : Form
    {
        private POSSystem posSystem;//sistemiin logic data
        private User currentUser;//nevtersen hereglegchiin medeelel
        private Cart cart;//hereglegchiin sags
        private ClassLibrary.Service.PrintingService printingService;


        private ErrorProvider errorProvider = new ErrorProvider();

        /// <summary>
        /// Hereglegchiin medeelel bolon UI-g achaalj beldene.
        /// </summary>
        /// <param name="posSystem">pos systemin undsen logic</param>
        /// <param name="user">nevtersen herglegchiin medeeel</param>
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
            this.printingService = posSystem.PrintingService;
            lblUsername.Text = $"Кассчин: {user.Username}";

            LoadProducts();
            LoadCategories();
            SetupCartListView();

            // Initialize the cart
            cart = new Cart();

            // Event handler binding
            btnAddToCart.Click += btnAddToCart_Click;
            
            //btnBaraa.Click += btnBaraa_Click_1;
            
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

        /// <summary>
        /// POS delgets deerh baraanuudiin jagsaaltiig tovch helvereer haruulna.
        /// </summary>
        private void LoadProducts()
        {
            lstProducts.Controls.Clear();
            var products = posSystem.ProductRepository.GetProducts();
            int y = 0;
            foreach (var product in products)
            {
                var button = new Button
                {
                    Text = $"{product.Name}\n{product.Price:C}\n{product.Barcode}",
                    Location = new Point(10, y),
                    Size = new Size(200, 70),
                    Tag = product
                };
                button.Click += ProductButton_Click;
                lstProducts.Controls.Add(button);
                y += 80;
            }
        }
        /// <summary>
        /// POS delgets deer buh angilaliig tovch helbereer haruulna.
        /// </summary>
        private void LoadCategories()
        {
            lstCategories.Controls.Clear();
            var categories = posSystem.CategoryRepository.GetCategories();
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
            if (sender is Button { Tag: Product product})
            {
                AddToCart(product);
            }
        }

        private void CategoryButton_Click(object? sender, EventArgs e)
        {
            if (sender is Button{ Tag : Category category})
            {
                FilterProductsByCategory(category.Id);
            }
        }

        /// <summary>
        /// Songoson angilaliin daguu baraanuudiig shuun haruulna
        /// </summary>
        /// <param name="categoryId">ANgilaliin ID</param>
        private void FilterProductsByCategory(int categoryId)
        {
            lstProducts.Controls.Clear();
            var products = posSystem.ProductRepository.GetProducts().Where(p => p.CategoryId == categoryId);
            int y = 0;
            foreach (var p in products)
            {
                var button = new Button
                {
                    Text = $"{p.Name}\n{p.Price:C}",
                    Location = new Point(10, y),
                    Size = new Size(200, 50),
                    Tag = p
                };
                button.Click += ProductButton_Click;
                lstProducts.Controls.Add(button);
                y += 60;
            }
        }

        /// <summary>
        /// baraag sagsand nemne
        /// </summary>
        /// <param name="product">Nemeh gej bui baraanii obiekt</param>
        public void AddToCart(Product? product)
        {
            if (product == null) return;
            cart.AddItem(product);
            UpdateCartDisplay();
        }

        /// <summary>
        /// Sagsnii medeelliig delgets deer shinecilj haruulna.
        /// </summary>
        private void UpdateCartDisplay()
        {
            lstCart.Items.Clear();
            decimal total = 0;
            int totalCount = 0;
            ListViewItem lastItem = null;
            foreach (var item in cart.Items)
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
            LoadProducts();
        }
        /// <summary>
        /// hereglegch sistemees garahdaa batalgaajuulalt hiine.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Та системээс гарахдаа итгэлтэй байна уу?", "Гарах",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close(); //  Зөв! Шууд формоо хаагаад л LoginForm гарч ирнэ
            }
        }



        /// <summary>
        /// hereglegch sistemees garah huseltei baival x tovch deer darj programmiig bur mson haah uildel yum
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Та програмаас гарахдаа итгэлтэй байна уу?", "Гарах",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        /// <summary>
        /// Barkodiin daguu baraa haij,oldvol sagsand nemne.
        /// Mon UI deer tuhai baraag tovch helbereer haruulna.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddToCart_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBarcode.Text))
            {
                MessageBox.Show("Барааны бар код оруулна уу!", "Анхаар",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var product = posSystem.ProductRepository.GetProducts()
                .FirstOrDefault(p => p.Barcode == txtBarcode.Text);

            if (product == null)
            {
                MessageBox.Show("Baraa duussan hudaldah bolomjgui!", "Алдаа",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //  Шинэ Button үүсгээд "Бүтээгдэхүүний жагсаалт" руу нэмэх
            var productButton = new Button
            {
                Text = $"{product.Name}\n{product.Price:C}\n{product.Barcode}",
                Size = new Size(200, 70),
                Tag = product,
                BackColor = Color.LightGreen
            };

            // товчийг дарахад сагсанд нэмэх
            productButton.Click += (s, ev) => AddToCart(product);

            // Бүтээгдэхүүн хэд дэх нь болохыг тооцож байрлуулах
            int y = lstProducts.Controls.Count * 80;
            productButton.Location = new Point(10, y);

            lstProducts.Controls.Add(productButton);
            txtBarcode.Clear();
        }

        /// <summary>
        /// tolboriin tsonh neej,tolbor hiisnii daraa sagsiig tseberlene.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPay_Click(object? sender, EventArgs e)
        {
            if (cart.Items.Count == 0)
            {
                MessageBox.Show("Сагсанд бараа байхгүй байна!", "Анхаар",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            System.Diagnostics.Debug.WriteLine($"Cart item count before opening PayForm: {cart.Items.Count}");
            var payForm = new PayForm(posSystem, cart.Items.ToList(), currentUser.Username, posSystem.PrintingService);

            if (payForm.ShowDialog() == DialogResult.OK)
            {
                cart.ClearCart();
                UpdateCartDisplay();
                MessageBox.Show("Худалдаа амжилттай хийгдлээ!", "Мэдээлэл",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Baraanii managementiin tsonhiig neeh,zovhon admin bolon manager nevtersen yed neegdene.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBaraa_Click_1(object? sender, EventArgs e)
        {
            if (currentUser.Role != "Admin" && currentUser.Role != "Manager")
            {
                MessageBox.Show("Таны эрх хүрэхгүй байна!", "Алдаа",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var baraaniiManagementForm = new BaraaniiManagementForm(posSystem, this);
            baraaniiManagementForm.ShowDialog();
            LoadProducts();
        }

        /// <summary>
        /// Baraanii angilaliin udirdlagiin tsonhiig neeh.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAngilal_Click(object? sender, EventArgs e)
        {
            if (currentUser.Role != "Admin" && currentUser.Role != "Manager")
            {
                MessageBox.Show("Таны эрх хүрэхгүй байна!", "Алдаа",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var form = new BaraaniiAngilaliinManagementForm(posSystem);
            form.ShowDialog();
        }


        /// <summary>
        /// POS systemiiin heregleenii tuslamj tailbar haruulna.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        //baraag oruulah tovch
        private void btnAddToCart_Click_1(object sender, EventArgs e)
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


        private void lstCart_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Songoson baraanii too hemjeeg 1 eer nemegduulne.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIncreaseQty_Click(object sender, EventArgs e)
        {
            if (lstCart.SelectedItems.Count == 0) return;

            var selectedItem = lstCart.SelectedItems[0];
            var saleItem = selectedItem.Tag as ClassLibrary.Models.SaleItem;

            if (saleItem != null)
            {
                cart.AddItem(saleItem.Product, 1); // Add one more of the existing product
                UpdateCartDisplay();

                // дахин сонгох
                foreach (ListViewItem item in lstCart.Items)
                {
                    if (item.Tag == saleItem) // Find the updated item in the list view
                    {
                        item.Selected = true;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Songoson baraanii too hemjeeg negeer buruulna.Herbee 1 baival ustgana.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDecreaseQty_Click(object sender, EventArgs e)
        {
            if (lstCart.SelectedItems.Count == 0) return;

            var selectedItem = lstCart.SelectedItems[0];
            var saleItem = selectedItem.Tag as ClassLibrary.Models.SaleItem;

            if (saleItem != null)
            {
                if (saleItem.Quantity > 1)
                {
                    cart.UpdateItemQuantity(saleItem.Product.Id, saleItem.Quantity - 1); // Decrease quantity by one
                }
                else
                {
                    cart.RemoveItem(saleItem.Product.Id); // Remove the item if quantity is 1
                }
                UpdateCartDisplay();

                // Optionally re-select an item after decreasing or removing
                if (cart.Items.Any())
                {
                    // Re-select the item if it still exists, or the last item if removed.
                    var itemToSelect = lstCart.Items.Cast<ListViewItem>().FirstOrDefault(item => (item.Tag as ClassLibrary.Models.SaleItem)?.Product.Id == saleItem.Product.Id) ?? lstCart.Items.Cast<ListViewItem>().LastOrDefault();
                    if (itemToSelect != null) itemToSelect.Selected = true;
                }
            }
        }

        private void lstProducts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {

        }


       

        private void lstProducts_Paint_1(object sender, PaintEventArgs e)
        {
            
        }
    }
}
