namespace WinFormsApp
{
    partial class BaraaniiManagementForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            lstProducts = new DataGridView();
            btnEditProduct = new Button();
            btnAddProduct = new Button();
            btnDeleteProduct = new Button();
            label2 = new Label();
            btnBack = new Button();
            ((System.ComponentModel.ISupportInitialize)lstProducts).BeginInit();
            SuspendLayout();
            // 
            // lstProducts
            // 
            lstProducts.BackgroundColor = Color.White;
            lstProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            lstProducts.Location = new Point(0, 55);
            lstProducts.Name = "lstProducts";
            lstProducts.RowHeadersWidth = 51;
            lstProducts.Size = new Size(864, 383);
            lstProducts.TabIndex = 0;
            lstProducts.CellContentClick += lstProducts_CellContentClick;
            // 
            // btnEditProduct
            // 
            btnEditProduct.BackColor = Color.Red;
            btnEditProduct.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEditProduct.Location = new Point(893, 249);
            btnEditProduct.Name = "btnEditProduct";
            btnEditProduct.Size = new Size(181, 43);
            btnEditProduct.TabIndex = 4;
            btnEditProduct.Text = "EDIT";
            btnEditProduct.UseVisualStyleBackColor = false;
            btnEditProduct.Click += btnEditProduct_Click_1;
            // 
            // btnAddProduct
            // 
            btnAddProduct.BackColor = Color.Red;
            btnAddProduct.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddProduct.Location = new Point(893, 146);
            btnAddProduct.Name = "btnAddProduct";
            btnAddProduct.Size = new Size(181, 43);
            btnAddProduct.TabIndex = 5;
            btnAddProduct.Text = "ADD";
            btnAddProduct.UseVisualStyleBackColor = false;
            btnAddProduct.Click += btnAddProduct_Click_1;
            // 
            // btnDeleteProduct
            // 
            btnDeleteProduct.BackColor = Color.Red;
            btnDeleteProduct.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDeleteProduct.Location = new Point(893, 355);
            btnDeleteProduct.Name = "btnDeleteProduct";
            btnDeleteProduct.Size = new Size(181, 43);
            btnDeleteProduct.TabIndex = 6;
            btnDeleteProduct.Text = "DELETE";
            btnDeleteProduct.UseVisualStyleBackColor = false;
            btnDeleteProduct.Click += btnDeleteProduct_Click_1;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label2.BackColor = Color.FromArgb(136, 165, 109);
            label2.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(320, 2);
            label2.Name = "label2";
            label2.Size = new Size(246, 50);
            label2.TabIndex = 14;
            label2.Text = "Baraanii jagsaalt";
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.Red;
            btnBack.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBack.Location = new Point(903, 12);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(181, 43);
            btnBack.TabIndex = 17;
            btnBack.Text = "Butsah";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click_1;
            // 
            // BaraaniiManagementForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(84, 126, 190);
            ClientSize = new Size(1096, 450);
            Controls.Add(btnBack);
            Controls.Add(label2);
            Controls.Add(btnDeleteProduct);
            Controls.Add(btnAddProduct);
            Controls.Add(btnEditProduct);
            Controls.Add(lstProducts);
            Name = "BaraaniiManagementForm";
            Text = "Baraa";
            ((System.ComponentModel.ISupportInitialize)lstProducts).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView lstProducts;
        private Button btnEditProduct;
        private Button btnAddProduct;
        private Button btnDeleteProduct;
        private Label label2;
        private Button btnBack;
    }
}