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
using System.Drawing.Printing;
using ClassLibrary.Service;
namespace WinFormsApp
{
    public partial class PayForm : Form
    {
        /// <summary>
        /// POS sistemii tolbor toloh form.
        /// Kasschin baraag borluulj,tolbor huleen avch ,barimt hevledeg
        /// </summary>
        private POSSystem posSystem;
        private List<ClassLibrary.Models.SaleItem> saleItems;
        private string cashierName;
        private decimal totalAmount;
        private ComboBox cmbPaymentMethod;
        private PrintingService printingService;
       

        public string PaymentMethod => cmbPaymentMethod.SelectedItem?.ToString() ?? "Cash";
        /// <summary>
        /// Pay formiig uusgej,niit tolbor bolon tolboriin torliig tohiruulna.
        /// </summary>
        /// <param name="posSystem">POS systemiin undsen logic</param>
        /// <param name="saleItems">Sgsand baigaa baraanuudiin jagsaalt</param>
        /// <param name="cashierName">Kasschin hereglegchiin ner</param>
        /// <param name="printingService">barim hevleh uilchilgee</param>
        public PayForm(POSSystem posSystem, List<ClassLibrary.Models.SaleItem> saleItems, string cashierName, PrintingService printingService)
        {
            InitializeComponent();

            this.posSystem = posSystem;
            this.saleItems = saleItems;
            this.cashierName = cashierName;
            totalAmount = saleItems.Sum(item => item.Total);
            lblTotalAmountText.Text = totalAmount.ToString("C");
            this.printingService = printingService;

            // Динамикаар ComboBox үүсгэх
            int totalAmountLabelY = lblTotalAmountText.Location.Y;
            int totalAmountLabelRight = lblTotalAmountText.Location.X + lblTotalAmountText.Width;
            int paymentMethodX = totalAmountLabelRight + 40;
            int paymentMethodY = lblTotalAmountText.Location.Y - 3;

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

        /// <summary>
        /// Hereglegch toloh dun oruulsan yed tootsolj,hariult haruulna.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Toloh tovch darsan yed baraag borluulj,barimt hevlene.
        /// </summary>
        /// <param name="sender">tovch </param>
        /// <param name="e">event argument</param>
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
                // Process the sale first
                posSystem.ProcessSale(saleItems, cashierName, PaymentMethod);

                // Now generate and show the print dialog
                PrintDocument pd = printingService.CreateReceiptPrintDocument(saleItems, cashierName, totalAmount, PaymentMethod);
                PrintDialog printDialog = new PrintDialog();
                printDialog.Document = pd;

                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    pd.Print();
                }

                // After successful processing and printing (or user cancels printing), close the form
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Алдаа гарлаа: {ex.Message}", "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Abort; // Indicate failure
            }
        }
        /// <summary>
        /// barimt hevlej ogoh tovch 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrintBill_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// bolih tovch darsan yed form-g haaj,dialog result -cancel bolgoj butsaana.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelPay_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
