namespace WinFormsApp
{
    partial class AddForm
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
            picItemImage = new PictureBox();
            btnCancel = new Button();
            btnSaveItem = new Button();
            btnUploadPhoto = new Button();
            cmbCategory = new ComboBox();
            txtItemPrice = new TextBox();
            txtItemName = new TextBox();
            txtItemCode = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)picItemImage).BeginInit();
            SuspendLayout();
            // 
            // picItemImage
            // 
            picItemImage.BorderStyle = BorderStyle.FixedSingle;
            picItemImage.Location = new Point(152, 53);
            picItemImage.Name = "picItemImage";
            picItemImage.Size = new Size(166, 174);
            picItemImage.TabIndex = 23;
            picItemImage.TabStop = false;
            picItemImage.Click += picItemImage_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(681, 12);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 22;
            btnCancel.Text = "CANCEL";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSaveItem
            // 
            btnSaveItem.Location = new Point(200, 369);
            btnSaveItem.Name = "btnSaveItem";
            btnSaveItem.Size = new Size(94, 29);
            btnSaveItem.TabIndex = 21;
            btnSaveItem.Text = "SAVE";
            btnSaveItem.UseVisualStyleBackColor = true;
            btnSaveItem.Click += btnSaveItem_Click;
            // 
            // btnUploadPhoto
            // 
            btnUploadPhoto.Location = new Point(270, 263);
            btnUploadPhoto.Name = "btnUploadPhoto";
            btnUploadPhoto.Size = new Size(175, 29);
            btnUploadPhoto.TabIndex = 20;
            btnUploadPhoto.Text = "UPLOAD PHOTO";
            btnUploadPhoto.UseVisualStyleBackColor = true;
            btnUploadPhoto.Click += btnUploadPhoto_Click;
            // 
            // cmbCategory
            // 
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(497, 199);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(151, 28);
            cmbCategory.TabIndex = 19;
            cmbCategory.SelectedIndexChanged += cmbCategory_SelectedIndexChanged;
            // 
            // txtItemPrice
            // 
            txtItemPrice.Location = new Point(497, 150);
            txtItemPrice.Name = "txtItemPrice";
            txtItemPrice.Size = new Size(151, 27);
            txtItemPrice.TabIndex = 18;
            txtItemPrice.TextChanged += txtItemPrice_TextChanged;
            // 
            // txtItemName
            // 
            txtItemName.Location = new Point(497, 103);
            txtItemName.Name = "txtItemName";
            txtItemName.Size = new Size(151, 27);
            txtItemName.TabIndex = 17;
            txtItemName.TextChanged += txtItemName_TextChanged;
            // 
            // txtItemCode
            // 
            txtItemCode.Location = new Point(497, 53);
            txtItemCode.Name = "txtItemCode";
            txtItemCode.Size = new Size(151, 27);
            txtItemCode.TabIndex = 16;
            txtItemCode.TextChanged += txtItemCode_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(362, 150);
            label4.Name = "label4";
            label4.Size = new Size(84, 20);
            label4.TabIndex = 15;
            label4.Text = "ITEM PRICE";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(345, 199);
            label3.Name = "label3";
            label3.Size = new Size(118, 20);
            label3.TabIndex = 14;
            label3.Text = "ITEM CATEGORY";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(360, 103);
            label2.Name = "label2";
            label2.Size = new Size(88, 20);
            label2.TabIndex = 13;
            label2.Text = "ITEM NAME\r\n";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(362, 56);
            label1.Name = "label1";
            label1.Size = new Size(85, 20);
            label1.TabIndex = 12;
            label1.Text = "ITEM CODE";
            label1.Click += label1_Click;
            // 
            // AddForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(picItemImage);
            Controls.Add(btnCancel);
            Controls.Add(btnSaveItem);
            Controls.Add(btnUploadPhoto);
            Controls.Add(cmbCategory);
            Controls.Add(txtItemPrice);
            Controls.Add(txtItemName);
            Controls.Add(txtItemCode);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AddForm";
            Text = "AddForm";
            ((System.ComponentModel.ISupportInitialize)picItemImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picItemImage;
        private Button btnCancel;
        private Button btnSaveItem;
        private Button btnUploadPhoto;
        private ComboBox cmbCategory;
        private TextBox txtItemPrice;
        private TextBox txtItemName;
        private TextBox txtItemCode;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}