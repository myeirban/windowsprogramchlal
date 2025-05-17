namespace WinFormsApp
{
    partial class PayForm
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
            label1 = new Label();
            label2 = new Label();
            lblChangeText = new Label();
            lblTotalAmountText = new Label();
            txtPaidAmount = new TextBox();
            lblChangeAmount = new Label();
            btnCancelPay = new Button();
            btnPayConfirm = new Button();
            btnPrintBill = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(159, 78);
            label1.Name = "label1";
            label1.Size = new Size(105, 20);
            label1.TabIndex = 0;
            label1.Text = "Niit Toloh Dun";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 135);
            label2.Name = "label2";
            label2.Size = new Size(230, 20);
            label2.TabIndex = 1;
            label2.Text = "HereglegchiinOgsonBelenMongo";
            // 
            // lblChangeText
            // 
            lblChangeText.AutoSize = true;
            lblChangeText.Location = new Point(159, 186);
            lblChangeText.Name = "lblChangeText";
            lblChangeText.Size = new Size(102, 20);
            lblChangeText.TabIndex = 2;
            lblChangeText.Text = "HariultMongo";
            // 
            // lblTotalAmountText
            // 
            lblTotalAmountText.AutoSize = true;
            lblTotalAmountText.Location = new Point(281, 78);
            lblTotalAmountText.Name = "lblTotalAmountText";
            lblTotalAmountText.Size = new Size(110, 20);
            lblTotalAmountText.TabIndex = 3;
            lblTotalAmountText.Text = "lbltotalAmount";
            lblTotalAmountText.Click += lblTotalAmountText_Click;
            // 
            // txtPaidAmount
            // 
            txtPaidAmount.Location = new Point(283, 135);
            txtPaidAmount.Name = "txtPaidAmount";
            txtPaidAmount.Size = new Size(125, 27);
            txtPaidAmount.TabIndex = 4;
            txtPaidAmount.TextChanged += textBox1_TextChanged;
            // 
            // lblChangeAmount
            // 
            lblChangeAmount.AutoSize = true;
            lblChangeAmount.Location = new Point(281, 186);
            lblChangeAmount.Name = "lblChangeAmount";
            lblChangeAmount.Size = new Size(127, 20);
            lblChangeAmount.TabIndex = 5;
            lblChangeAmount.Text = "lblchangeAmount";
            lblChangeAmount.Click += lblChangeAmount_Click;
            // 
            // btnCancelPay
            // 
            btnCancelPay.BackColor = Color.FromArgb(210, 176, 38);
            btnCancelPay.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelPay.Location = new Point(650, 12);
            btnCancelPay.Name = "btnCancelPay";
            btnCancelPay.Size = new Size(129, 43);
            btnCancelPay.TabIndex = 18;
            btnCancelPay.Text = "CANCEL";
            btnCancelPay.UseVisualStyleBackColor = false;
            btnCancelPay.Click += btnCancelPay_Click;
            // 
            // btnPayConfirm
            // 
            btnPayConfirm.BackColor = Color.FromArgb(210, 176, 38);
            btnPayConfirm.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPayConfirm.Location = new Point(180, 241);
            btnPayConfirm.Name = "btnPayConfirm";
            btnPayConfirm.Size = new Size(181, 43);
            btnPayConfirm.TabIndex = 17;
            btnPayConfirm.Text = "PAY";
            btnPayConfirm.UseVisualStyleBackColor = false;
            btnPayConfirm.Click += btnPayConfirm_Click;
            // 
            // btnPrintBill
            // 
            btnPrintBill.BackColor = Color.FromArgb(210, 176, 38);
            btnPrintBill.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPrintBill.Location = new Point(367, 241);
            btnPrintBill.Name = "btnPrintBill";
            btnPrintBill.Size = new Size(181, 43);
            btnPrintBill.TabIndex = 19;
            btnPrintBill.Text = "Print Bill";
            btnPrintBill.UseVisualStyleBackColor = false;
            btnPrintBill.Click += btnPrintBill_Click;
            // 
            // PayForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnPrintBill);
            Controls.Add(btnCancelPay);
            Controls.Add(btnPayConfirm);
            Controls.Add(lblChangeAmount);
            Controls.Add(txtPaidAmount);
            Controls.Add(lblTotalAmountText);
            Controls.Add(lblChangeText);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "PayForm";
            Text = "PayForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label lblChangeText;
        private Label lblTotalAmountText;
        private TextBox txtPaidAmount;
        private Label lblChangeAmount;
        private Button btnCancelPay;
        private Button btnPayConfirm;
        private Button btnPrintBill;
    }
}