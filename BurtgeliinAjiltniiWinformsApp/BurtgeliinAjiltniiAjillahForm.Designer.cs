namespace BurtgeliinAjiltniiWinformsApp
{
    partial class BurtgeliinAjiltniiAjillahForm
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
            btnSave = new Button();
            label3 = new Label();
            burtgeliinAjiltniiAjillahForm_nislegiindugaar = new TextBox();
            BurtgeliinAjiltniiAjillahForm_search_btn = new Button();
            label4 = new Label();
            BurtgeliinAjiltniiAjillahFormiinOdoogiinbaidal = new ComboBox();
            btn_cancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 18);
            label1.Name = "label1";
            label1.Size = new Size(448, 20);
            label1.TabIndex = 0;
            label1.Text = "sain baina uu,Ongotsnii burtgeliin ajiltnii sistemd tavtai morilno uu";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(55, 213);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(151, 29);
            btnSave.TabIndex = 3;
            btnSave.Text = "tolov hadgalah";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(55, 100);
            label3.Name = "label3";
            label3.Size = new Size(122, 20);
            label3.TabIndex = 4;
            label3.Text = "nislegiin dugaar :";
            // 
            // burtgeliinAjiltniiAjillahForm_nislegiindugaar
            // 
            burtgeliinAjiltniiAjillahForm_nislegiindugaar.Location = new Point(196, 102);
            burtgeliinAjiltniiAjillahForm_nislegiindugaar.Name = "burtgeliinAjiltniiAjillahForm_nislegiindugaar";
            burtgeliinAjiltniiAjillahForm_nislegiindugaar.Size = new Size(149, 27);
            burtgeliinAjiltniiAjillahForm_nislegiindugaar.TabIndex = 5;
            // 
            // BurtgeliinAjiltniiAjillahForm_search_btn
            // 
            BurtgeliinAjiltniiAjillahForm_search_btn.Location = new Point(366, 102);
            BurtgeliinAjiltniiAjillahForm_search_btn.Name = "BurtgeliinAjiltniiAjillahForm_search_btn";
            BurtgeliinAjiltniiAjillahForm_search_btn.Size = new Size(94, 27);
            BurtgeliinAjiltniiAjillahForm_search_btn.TabIndex = 6;
            BurtgeliinAjiltniiAjillahForm_search_btn.Text = "search";
            BurtgeliinAjiltniiAjillahForm_search_btn.UseVisualStyleBackColor = true;
            BurtgeliinAjiltniiAjillahForm_search_btn.Click += button1_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(55, 152);
            label4.Name = "label4";
            label4.Size = new Size(116, 20);
            label4.TabIndex = 7;
            label4.Text = "odoogiin baidal";
            // 
            // BurtgeliinAjiltniiAjillahFormiinOdoogiinbaidal
            // 
            BurtgeliinAjiltniiAjillahFormiinOdoogiinbaidal.FormattingEnabled = true;
            BurtgeliinAjiltniiAjillahFormiinOdoogiinbaidal.Items.AddRange(new object[] { "nislegiin huvaaritai", "nislegt suuj bn", "nisleg yavj bn", "nisleg gazardsan ", "nisleg hoishlogdson ", "nisleg tsutslagdsan " });
            BurtgeliinAjiltniiAjillahFormiinOdoogiinbaidal.Location = new Point(196, 149);
            BurtgeliinAjiltniiAjillahFormiinOdoogiinbaidal.Name = "BurtgeliinAjiltniiAjillahFormiinOdoogiinbaidal";
            BurtgeliinAjiltniiAjillahFormiinOdoogiinbaidal.Size = new Size(151, 28);
            BurtgeliinAjiltniiAjillahFormiinOdoogiinbaidal.TabIndex = 8;
            // 
            // btn_cancel
            // 
            btn_cancel.Location = new Point(253, 215);
            btn_cancel.Name = "btn_cancel";
            btn_cancel.Size = new Size(94, 27);
            btn_cancel.TabIndex = 9;
            btn_cancel.Text = "bolih";
            btn_cancel.UseVisualStyleBackColor = true;
            // 
            // BurtgeliinAjiltniiAjillahForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 454);
            Controls.Add(btn_cancel);
            Controls.Add(BurtgeliinAjiltniiAjillahFormiinOdoogiinbaidal);
            Controls.Add(label4);
            Controls.Add(BurtgeliinAjiltniiAjillahForm_search_btn);
            Controls.Add(burtgeliinAjiltniiAjillahForm_nislegiindugaar);
            Controls.Add(label3);
            Controls.Add(btnSave);
            Controls.Add(label1);
            Name = "BurtgeliinAjiltniiAjillahForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BurtgeliinAjiltniiAjillahForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnSave;
        private Label label3;
        private TextBox burtgeliinAjiltniiAjillahForm_nislegiindugaar;
        private Button BurtgeliinAjiltniiAjillahForm_search_btn;
        private Label label4;
        private ComboBox BurtgeliinAjiltniiAjillahFormiinOdoogiinbaidal;
        private Button btn_cancel;
    }
}