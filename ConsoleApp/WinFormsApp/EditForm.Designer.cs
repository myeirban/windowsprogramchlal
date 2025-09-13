namespace WinFormsApp
{/// <summary>
/// Edit form ni baraanii medeelliig zasah hereglegchiin interfeisiig todorhoildog.
/// </summary>
    partial class EditForm
    {
        /// <summary>
        /// Dizainer bureldehuunuud hadgalagdah container
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Ashiglagdaj bui nootsiig tseverlene.
        /// </summary>
        /// <param name="disposing">true bol managed nootsuudiig ustgana.</param>
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
        /// formiin UI initsializ hiideg method
        /// controlluudiin bairlal,hemjee,uildel zergiig tohiruulna.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtEditCode = new TextBox();
            txtEditName = new TextBox();
            txtEditPrice = new TextBox();
            cmbEditCategory = new ComboBox();
            btnUpdatePhoto = new Button();
            btnSaveEdit = new Button();
            btnCancelEdit = new Button();
            openFileDialog1 = new OpenFileDialog();
            openFileDialog2 = new OpenFileDialog();
            picEditImage = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)picEditImage).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(352, 110);
            label1.Name = "label1";
            label1.Size = new Size(85, 20);
            label1.TabIndex = 0;
            label1.Text = "ITEM CODE";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(350, 157);
            label2.Name = "label2";
            label2.Size = new Size(88, 20);
            label2.TabIndex = 1;
            label2.Text = "ITEM NAME\r\n";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(335, 253);
            label3.Name = "label3";
            label3.Size = new Size(118, 20);
            label3.TabIndex = 2;
            label3.Text = "ITEM CATEGORY";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(352, 204);
            label4.Name = "label4";
            label4.Size = new Size(84, 20);
            label4.TabIndex = 3;
            label4.Text = "ITEM PRICE";
            // 
            // txtEditCode
            // 
            txtEditCode.Location = new Point(487, 107);
            txtEditCode.Name = "txtEditCode";
            txtEditCode.Size = new Size(151, 27);
            txtEditCode.TabIndex = 4;
            // 
            // txtEditName
            // 
            txtEditName.Location = new Point(487, 157);
            txtEditName.Name = "txtEditName";
            txtEditName.Size = new Size(151, 27);
            txtEditName.TabIndex = 5;
            txtEditName.TextChanged += txtEditName_TextChanged;
            // 
            // txtEditPrice
            // 
            txtEditPrice.Location = new Point(487, 204);
            txtEditPrice.Name = "txtEditPrice";
            txtEditPrice.Size = new Size(151, 27);
            txtEditPrice.TabIndex = 6;
            txtEditPrice.TextChanged += txtEditPrice_TextChanged;
            // 
            // cmbEditCategory
            // 
            cmbEditCategory.FormattingEnabled = true;
            cmbEditCategory.Location = new Point(487, 253);
            cmbEditCategory.Name = "cmbEditCategory";
            cmbEditCategory.Size = new Size(151, 28);
            cmbEditCategory.TabIndex = 7;
            cmbEditCategory.SelectedIndexChanged += cmbEditCategory_SelectedIndexChanged;
            // 
            // btnUpdatePhoto
            // 
            btnUpdatePhoto.Location = new Point(260, 317);
            btnUpdatePhoto.Name = "btnUpdatePhoto";
            btnUpdatePhoto.Size = new Size(175, 29);
            btnUpdatePhoto.TabIndex = 8;
            btnUpdatePhoto.Text = "UPDATE PHOTO";
            btnUpdatePhoto.UseVisualStyleBackColor = true;
            btnUpdatePhoto.Click += btnUpdatePhoto_Click;
            // 
            // btnSaveEdit
            // 
            btnSaveEdit.Location = new Point(300, 368);
            btnSaveEdit.Name = "btnSaveEdit";
            btnSaveEdit.Size = new Size(94, 29);
            btnSaveEdit.TabIndex = 9;
            btnSaveEdit.Text = "SAVE";
            btnSaveEdit.UseVisualStyleBackColor = true;
            btnSaveEdit.Click += btnSaveEdit_Click;
            // 
            // btnCancelEdit
            // 
            btnCancelEdit.Location = new Point(598, 12);
            btnCancelEdit.Name = "btnCancelEdit";
            btnCancelEdit.Size = new Size(94, 29);
            btnCancelEdit.TabIndex = 10;
            btnCancelEdit.Text = "CANCEL";
            btnCancelEdit.UseVisualStyleBackColor = true;
            btnCancelEdit.Click += btnCancelEdit_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileDialog2
            // 
            openFileDialog2.FileName = "openFileDialog1";
            // 
            // picEditImage
            // 
            picEditImage.Location = new Point(135, 110);
            picEditImage.Name = "picEditImage";
            picEditImage.Size = new Size(164, 171);
            picEditImage.TabIndex = 11;
            picEditImage.TabStop = false;
            // 
            // EditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(704, 478);
            Controls.Add(picEditImage);
            Controls.Add(btnCancelEdit);
            Controls.Add(btnSaveEdit);
            Controls.Add(btnUpdatePhoto);
            Controls.Add(cmbEditCategory);
            Controls.Add(txtEditPrice);
            Controls.Add(txtEditName);
            Controls.Add(txtEditCode);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "EditForm";
            Text = "EDITForm";
            ((System.ComponentModel.ISupportInitialize)picEditImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtEditCode;
        private TextBox txtEditName;
        private TextBox txtEditPrice;
        private ComboBox cmbEditCategory;
        private Button btnUpdatePhoto;
        private Button btnSaveEdit;
        private Button btnCancelEdit;
        private OpenFileDialog openFileDialog1;
        private OpenFileDialog openFileDialog2;
        private PictureBox picEditImage;
    }
}