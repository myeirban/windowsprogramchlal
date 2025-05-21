namespace WinFormsApp
{
    partial class MainPosForm
    {
        /// <summary>
        /// shaardlagatai dizainer huvsagch.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Ashiglaj bui buh nootsiig tseverle.
        /// </summary>
        /// <param name="disposing">udirdaj baigaa nootsiig zahiran zartsuulah shaardlagatai bol unen.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnLogout = new Button();
            btnClose = new Button();
            btnAddToCart = new Button();
            lstCategories = new Panel();
            txtBarcode = new TextBox();
            label1 = new Label();
            btnHelp = new Button();
            btnBaraa = new Button();
            lstCart = new ListView();
            label2 = new Label();
            label3 = new Label();
            btnPay = new Button();
            lblUsername = new Label();
            btnIncreaseQty = new Button();
            btnDecreaseQty = new Button();
            lblTotalPriceText = new Label();
            lblTotalItemText = new Label();
            btnAngilal = new Button();
            label8 = new Label();
            lblNiitTolbor = new Label();
            btnBack = new Button();
            lstProducts = new Panel();
            SuspendLayout();
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(210, 176, 38);
            btnLogout.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.Location = new Point(1095, 603);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(181, 43);
            btnLogout.TabIndex = 0;
            btnLogout.Text = "LOG OUT";
            btnLogout.UseVisualStyleBackColor = false;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Red;
            btnClose.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.Location = new Point(1392, 15);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(59, 43);
            btnClose.TabIndex = 6;
            btnClose.Text = "X";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // btnAddToCart
            // 
            btnAddToCart.BackColor = Color.Red;
            btnAddToCart.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddToCart.Location = new Point(454, 203);
            btnAddToCart.Name = "btnAddToCart";
            btnAddToCart.Size = new Size(198, 75);
            btnAddToCart.TabIndex = 3;
            btnAddToCart.Text = "Baraag Oruulah";
            btnAddToCart.UseVisualStyleBackColor = false;
            btnAddToCart.Click += btnAddToCart_Click;
            // 
            // lstCategories
            // 
            lstCategories.AutoScroll = true;
            lstCategories.BackColor = Color.FromArgb(95, 126, 146);
            lstCategories.Location = new Point(658, 69);
            lstCategories.Name = "lstCategories";
            lstCategories.Size = new Size(246, 482);
            lstCategories.TabIndex = 2;
            // 
            // txtBarcode
            // 
            txtBarcode.Location = new Point(454, 151);
            txtBarcode.Multiline = true;
            txtBarcode.Name = "txtBarcode";
            txtBarcode.Size = new Size(198, 46);
            txtBarcode.TabIndex = 7;
            txtBarcode.TextChanged += txtBarcode_TextChanged;
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(136, 165, 109);
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(454, 13);
            label1.Name = "label1";
            label1.Size = new Size(198, 128);
            label1.TabIndex = 8;
            label1.Text = "Baraanii bar kodiig oruularai";
            // 
            // btnHelp
            // 
            btnHelp.BackColor = Color.Red;
            btnHelp.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHelp.Location = new Point(12, 603);
            btnHelp.Name = "btnHelp";
            btnHelp.Size = new Size(83, 43);
            btnHelp.TabIndex = 9;
            btnHelp.Text = "Help";
            btnHelp.UseVisualStyleBackColor = false;
            btnHelp.Click += btnHelp_Click_1;
            // 
            // btnBaraa
            // 
            btnBaraa.BackColor = Color.Red;
            btnBaraa.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBaraa.Location = new Point(12, 12);
            btnBaraa.Name = "btnBaraa";
            btnBaraa.Size = new Size(87, 43);
            btnBaraa.TabIndex = 11;
            btnBaraa.Text = "Baraa";
            btnBaraa.UseVisualStyleBackColor = false;
            btnBaraa.Click += btnBaraa_Click_1;
            // 
            // lstCart
            // 
            lstCart.Location = new Point(4, 92);
            lstCart.Name = "lstCart";
            lstCart.Size = new Size(444, 432);
            lstCart.TabIndex = 12;
            lstCart.UseCompatibleStateImageBehavior = false;
            lstCart.SelectedIndexChanged += lstCart_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.BackColor = Color.FromArgb(136, 165, 109);
            label2.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(658, 13);
            label2.Name = "label2";
            label2.Size = new Size(246, 50);
            label2.TabIndex = 13;
            label2.Text = "Baraanii angilal\r\n";
            // 
            // label3
            // 
            label3.BackColor = Color.FromArgb(136, 165, 109);
            label3.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(925, 12);
            label3.Name = "label3";
            label3.Size = new Size(461, 50);
            label3.TabIndex = 14;
            label3.Text = "Butegdeehuunii Jagsaalt\r\n";
            // 
            // btnPay
            // 
            btnPay.BackColor = Color.FromArgb(210, 176, 38);
            btnPay.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPay.Location = new Point(262, 572);
            btnPay.Name = "btnPay";
            btnPay.Size = new Size(133, 43);
            btnPay.TabIndex = 15;
            btnPay.Text = "PAY";
            btnPay.UseVisualStyleBackColor = false;
            btnPay.Click += btnPay_Click;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(17, 69);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(126, 20);
            lblUsername.TabIndex = 16;
            lblUsername.Text = "HereglegchiinNer";
            lblUsername.Click += lblUsername_Click;
            // 
            // btnIncreaseQty
            // 
            btnIncreaseQty.BackColor = Color.Red;
            btnIncreaseQty.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnIncreaseQty.Location = new Point(321, 30);
            btnIncreaseQty.Name = "btnIncreaseQty";
            btnIncreaseQty.Size = new Size(59, 43);
            btnIncreaseQty.TabIndex = 17;
            btnIncreaseQty.Text = "+";
            btnIncreaseQty.UseVisualStyleBackColor = false;
            btnIncreaseQty.Click += btnIncreaseQty_Click;
            // 
            // btnDecreaseQty
            // 
            btnDecreaseQty.BackColor = Color.Red;
            btnDecreaseQty.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDecreaseQty.Location = new Point(386, 30);
            btnDecreaseQty.Name = "btnDecreaseQty";
            btnDecreaseQty.Size = new Size(59, 43);
            btnDecreaseQty.TabIndex = 18;
            btnDecreaseQty.Text = "-";
            btnDecreaseQty.UseVisualStyleBackColor = false;
            btnDecreaseQty.Click += btnDecreaseQty_Click;
            // 
            // lblTotalPriceText
            // 
            lblTotalPriceText.AutoSize = true;
            lblTotalPriceText.Location = new Point(128, 290);
            lblTotalPriceText.Name = "lblTotalPriceText";
            lblTotalPriceText.Size = new Size(0, 20);
            lblTotalPriceText.TabIndex = 19;
            // 
            // lblTotalItemText
            // 
            lblTotalItemText.AutoSize = true;
            lblTotalItemText.Location = new Point(162, 572);
            lblTotalItemText.Name = "lblTotalItemText";
            lblTotalItemText.Size = new Size(45, 20);
            lblTotalItemText.TabIndex = 20;
            lblTotalItemText.Text = "None";
            lblTotalItemText.Click += lblTotalItemText_Click;
            // 
            // btnAngilal
            // 
            btnAngilal.BackColor = Color.Red;
            btnAngilal.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAngilal.Location = new Point(105, 12);
            btnAngilal.Name = "btnAngilal";
            btnAngilal.Size = new Size(102, 43);
            btnAngilal.TabIndex = 21;
            btnAngilal.Text = "Angilal";
            btnAngilal.UseVisualStyleBackColor = false;
            btnAngilal.Click += btnAngilal_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(17, 572);
            label8.Name = "label8";
            label8.Size = new Size(120, 20);
            label8.TabIndex = 23;
            label8.Text = "Niit Baraanii Too";
            label8.Click += label8_Click;
            // 
            // lblNiitTolbor
            // 
            lblNiitTolbor.AutoSize = true;
            lblNiitTolbor.Location = new Point(283, 618);
            lblNiitTolbor.Name = "lblNiitTolbor";
            lblNiitTolbor.Size = new Size(80, 20);
            lblNiitTolbor.TabIndex = 24;
            lblNiitTolbor.Text = "Niit Tolbor";
            lblNiitTolbor.Click += lblNiitTolbor_Click;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.Red;
            btnBack.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBack.Location = new Point(1392, 15);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(59, 43);
            btnBack.TabIndex = 25;
            btnBack.Text = "X";
            btnBack.UseVisualStyleBackColor = false;
            // 
            // lstProducts
            // 
            lstProducts.AutoScroll = true;
            lstProducts.BackColor = Color.White;
            lstProducts.Location = new Point(925, 72);
            lstProducts.Name = "lstProducts";
            lstProducts.Size = new Size(461, 479);
            lstProducts.TabIndex = 26;
            lstProducts.Paint += lstProducts_Paint_1;
            // 
            // MainPosForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(194, 158, 190);
            ClientSize = new Size(1463, 653);
            Controls.Add(lstCart);
            Controls.Add(lstProducts);
            Controls.Add(lblNiitTolbor);
            Controls.Add(label8);
            Controls.Add(btnAngilal);
            Controls.Add(btnLogout);
            Controls.Add(lblTotalItemText);
            Controls.Add(lblTotalPriceText);
            Controls.Add(btnDecreaseQty);
            Controls.Add(btnIncreaseQty);
            Controls.Add(lblUsername);
            Controls.Add(btnPay);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnBaraa);
            Controls.Add(btnHelp);
            Controls.Add(label1);
            Controls.Add(txtBarcode);
            Controls.Add(btnClose);
            Controls.Add(lstCategories);
            Controls.Add(btnAddToCart);
            Controls.Add(btnBack);
            Name = "MainPosForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainPos_view";
            Load += MainPosForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private void lstProducts_Paint(object sender, PaintEventArgs e)
        {
            //throw new NotImplementedException();

        }

        #endregion

        private Button btnLogout;
        private Button btnClose;
        private Panel lstCategories;
        private Button btnAddToCart;
        private TextBox txtBarcode;
        private Label label1;
        private Button btnHelp;
        private Button btnBaraa;
        private ListView lstCart;
        private Label label2;
        private Label label3;
        private Button btnPay;
        private Label lblUsername;
        private Button btnIncreaseQty;
        private Button btnDecreaseQty;
        private Label lblTotalPriceText;
        private Label lblTotalItemText;
        private Button btnAngilal;
        private Label label8;
        private Label lblNiitTolbor;
        private Button btnBack;
        private Panel lstProducts;
    }
}