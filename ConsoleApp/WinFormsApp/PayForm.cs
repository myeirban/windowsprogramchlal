using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary;
using ClassLibrary.Models;

namespace WinFormsApp
{
    public partial class PayForm : Form
    {
        private POSSystem posSystem;
        private List<SaleItem> saleItems;
        private string cashierName;
        private decimal totalAmount;
        private ComboBox cmbPaymentMethod;

        public string PaymentMethod => cmbPaymentMethod.SelectedItem?.ToString() ?? "Cash";

        public PayForm(POSSystem posSystem, List<SaleItem> saleItems, string cashierName)
        {
            InitializeComponent();
            this.posSystem = posSystem;
            this.saleItems = saleItems;
            this.cashierName = cashierName;
            totalAmount = saleItems.Sum(item => item.Total);
            lblTotalAmountText.Text = totalAmount.ToString("C");

            // Add payment method selection
            int totalAmountLabelY = lblTotalAmountText.Location.Y;
            int totalAmountLabelRight = lblTotalAmountText.Location.X + lblTotalAmountText.Width;
            int paymentMethodX = totalAmountLabelRight + 40; // 40px space to the right
            int paymentMethodY = lblTotalAmountText.Location.Y - 3; // align with label

            cmbPaymentMethod = new ComboBox
            {
                Location = new Point(paymentMethodX + 100, paymentMethodY),
                Size = new Size(120, 25),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbPaymentMethod.Items.AddRange(new string[] { "Бэлнээр", "Картаар", "QR код" });
            cmbPaymentMethod.SelectedIndex = 0;
            this.Controls.Add(cmbPaymentMethod);

            Label lblPaymentMethod = new Label
            {
                Text = "Төлбөрийн хэлбэр:",
                Location = new Point(paymentMethodX, paymentMethodY + 4),
                AutoSize = true
            };
            this.Controls.Add(lblPaymentMethod);
        }

        public PayForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtPaidAmount.Text, out decimal paid))
            {
                decimal change = paid - totalAmount;
                lblChangeAmount.Text = change >= 0 ? change.ToString("C") : "-";
            }
            else
            {
                lblChangeAmount.Text = "-";
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblTotalAmountText_Click(object sender, EventArgs e)
        {

        }

        private void lblChangeAmount_Click(object sender, EventArgs e)
        {

        }

        private void btnPayConfirm_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtPaidAmount.Text, out decimal paidAmount))
            {
                MessageBox.Show("Төлөх дүнг зөв оруулна уу!", "Анхаар", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (paidAmount < totalAmount)
            {
                MessageBox.Show("Төлөх дүн хүрэлцэхгүй байна!", "Анхаар", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                posSystem.ProcessSale(saleItems, cashierName, PaymentMethod);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Алдаа гарлаа: {ex.Message}", "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrintBill_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelPay_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
