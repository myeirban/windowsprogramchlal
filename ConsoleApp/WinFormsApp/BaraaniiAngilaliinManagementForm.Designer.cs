namespace WinFormsApp
{
    partial class BaraaniiAngilaliinManagementForm
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
            label2 = new Label();
            labelBaraaniiAngilal = new Label();
            txtCategoryName = new TextBox();
            btnAddCategory = new Button();
            lstCategories = new DataGridView();
            btnBack = new Button();
            btnDeleteCategory = new Button();
            btnEditCategory = new Button();
            txtItemName = new TextBox();
            txtItemPrice = new TextBox();
            ((System.ComponentModel.ISupportInitialize)lstCategories).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label2.BackColor = Color.FromArgb(136, 165, 109);
            label2.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(347, 16);
            label2.Name = "label2";
            label2.Size = new Size(316, 53);
            label2.TabIndex = 18;
            label2.Text = "Baraanii angilal\r\n";
            // 
            // labelBaraaniiAngilal
            // 
            labelBaraaniiAngilal.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelBaraaniiAngilal.BackColor = Color.FromArgb(136, 165, 109);
            labelBaraaniiAngilal.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelBaraaniiAngilal.Location = new Point(25, 12);
            labelBaraaniiAngilal.Name = "labelBaraaniiAngilal";
            labelBaraaniiAngilal.Size = new Size(198, 128);
            labelBaraaniiAngilal.TabIndex = 17;
            labelBaraaniiAngilal.Text = "Baraanii angilaliig oruularai";
            // 
            // txtCategoryName
            // 
            txtCategoryName.Location = new Point(25, 154);
            txtCategoryName.Multiline = true;
            txtCategoryName.Name = "txtCategoryName";
            txtCategoryName.Size = new Size(198, 46);
            txtCategoryName.TabIndex = 16;
            txtCategoryName.TextChanged += txtCategoryName_TextChanged;
            // 
            // btnAddCategory
            // 
            btnAddCategory.BackColor = Color.Red;
            btnAddCategory.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddCategory.Location = new Point(42, 246);
            btnAddCategory.Name = "btnAddCategory";
            btnAddCategory.Size = new Size(181, 43);
            btnAddCategory.TabIndex = 15;
            btnAddCategory.Text = "ADD";
            btnAddCategory.UseVisualStyleBackColor = false;
            btnAddCategory.Click += btnAddCategory_Click_1;
            // 
            // lstCategories
            // 
            lstCategories.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            lstCategories.Location = new Point(254, 90);
            lstCategories.Name = "lstCategories";
            lstCategories.RowHeadersWidth = 51;
            lstCategories.Size = new Size(686, 437);
            lstCategories.TabIndex = 19;
            lstCategories.CellContentClick += lstCategories_CellContentClick;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.Red;
            btnBack.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBack.Location = new Point(786, 12);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(154, 43);
            btnBack.TabIndex = 22;
            btnBack.Text = "Butsah";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click_1;
            // 
            // btnDeleteCategory
            // 
            btnDeleteCategory.BackColor = Color.Red;
            btnDeleteCategory.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDeleteCategory.Location = new Point(42, 439);
            btnDeleteCategory.Name = "btnDeleteCategory";
            btnDeleteCategory.Size = new Size(181, 43);
            btnDeleteCategory.TabIndex = 21;
            btnDeleteCategory.Text = "DELETE";
            btnDeleteCategory.UseVisualStyleBackColor = false;
            btnDeleteCategory.Click += btnDeleteCategory_Click;
            // 
            // btnEditCategory
            // 
            btnEditCategory.BackColor = Color.Red;
            btnEditCategory.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEditCategory.Location = new Point(42, 339);
            btnEditCategory.Name = "btnEditCategory";
            btnEditCategory.Size = new Size(181, 43);
            btnEditCategory.TabIndex = 20;
            btnEditCategory.Text = "EDIT";
            btnEditCategory.UseVisualStyleBackColor = false;
            btnEditCategory.Click += btnEditCategory_Click;
            // 
            // txtItemName
            // 
            txtItemName.Location = new Point(206, 156);
            txtItemName.Multiline = true;
            txtItemName.Name = "txtItemName";
            txtItemName.Size = new Size(198, 46);
            txtItemName.TabIndex = 16;
            // 
            // txtItemPrice
            // 
            txtItemPrice.Location = new Point(206, 156);
            txtItemPrice.Multiline = true;
            txtItemPrice.Name = "txtItemPrice";
            txtItemPrice.Size = new Size(198, 46);
            txtItemPrice.TabIndex = 16;
            // 
            // BaraaniiAngilaliinManagementForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(973, 539);
            Controls.Add(btnBack);
            Controls.Add(btnDeleteCategory);
            Controls.Add(btnEditCategory);
            Controls.Add(lstCategories);
            Controls.Add(label2);
            Controls.Add(labelBaraaniiAngilal);
            Controls.Add(txtCategoryName);
            Controls.Add(btnAddCategory);
            Name = "BaraaniiAngilaliinManagementForm";
            Text = "Angilal";
            ((System.ComponentModel.ISupportInitialize)lstCategories).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Label labelBaraaniiAngilal;
        private TextBox txtCategoryName;
        private Button btnAddCategory;
        private DataGridView lstCategories;
        private Button btnBack;
        private Button btnDeleteCategory;
        private Button btnEditCategory;
        private TextBox txtItemName;
        private TextBox txtItemPrice;
    }
}