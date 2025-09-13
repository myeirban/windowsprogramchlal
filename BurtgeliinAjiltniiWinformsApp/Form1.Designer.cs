namespace BurtgeliinAjiltniiWinformsApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            Loginform_login_btn = new Button();
            loginform_username_txt = new TextBox();
            loginform_pass_txt = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            loginform_register_btn = new Button();
            loginform_close_btn = new Label();
            label5 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 32);
            label1.Name = "label1";
            label1.Size = new Size(285, 20);
            label1.TabIndex = 0;
            label1.Text = "Burtgeliin Ajiltnii Form App-d tavtai moril";
            // 
            // Loginform_login_btn
            // 
            Loginform_login_btn.Location = new Point(493, 294);
            Loginform_login_btn.Name = "Loginform_login_btn";
            Loginform_login_btn.Size = new Size(122, 47);
            Loginform_login_btn.TabIndex = 1;
            Loginform_login_btn.Text = "LOGIN";
            Loginform_login_btn.UseVisualStyleBackColor = true;
            Loginform_login_btn.Click += Loginform_login_btn_Click;
            // 
            // loginform_username_txt
            // 
            loginform_username_txt.Location = new Point(457, 112);
            loginform_username_txt.Multiline = true;
            loginform_username_txt.Name = "loginform_username_txt";
            loginform_username_txt.Size = new Size(203, 46);
            loginform_username_txt.TabIndex = 2;
            // 
            // loginform_pass_txt
            // 
            loginform_pass_txt.Location = new Point(457, 198);
            loginform_pass_txt.Multiline = true;
            loginform_pass_txt.Name = "loginform_pass_txt";
            loginform_pass_txt.Size = new Size(203, 43);
            loginform_pass_txt.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(462, 89);
            label2.Name = "label2";
            label2.Size = new Size(78, 20);
            label2.TabIndex = 4;
            label2.Text = "Username:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(462, 175);
            label3.Name = "label3";
            label3.Size = new Size(73, 20);
            label3.TabIndex = 5;
            label3.Text = "Password:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(124, 321);
            label4.Name = "label4";
            label4.Size = new Size(128, 20);
            label4.TabIndex = 7;
            label4.Text = "Create an account";
            // 
            // loginform_register_btn
            // 
            loginform_register_btn.Location = new Point(124, 356);
            loginform_register_btn.Name = "loginform_register_btn";
            loginform_register_btn.Size = new Size(122, 47);
            loginform_register_btn.TabIndex = 8;
            loginform_register_btn.Text = "REGISTER";
            loginform_register_btn.UseVisualStyleBackColor = true;
            loginform_register_btn.Click += loginform_register_btn_Click;
            // 
            // loginform_close_btn
            // 
            loginform_close_btn.AutoSize = true;
            loginform_close_btn.Location = new Point(750, 32);
            loginform_close_btn.Name = "loginform_close_btn";
            loginform_close_btn.Size = new Size(18, 20);
            loginform_close_btn.TabIndex = 9;
            loginform_close_btn.Text = "X";
            loginform_close_btn.Click += loginform_close_btn_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(457, 57);
            label5.Name = "label5";
            label5.Size = new Size(51, 20);
            label5.TabIndex = 10;
            label5.Text = "LOGIN";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label5);
            Controls.Add(loginform_close_btn);
            Controls.Add(loginform_register_btn);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(loginform_pass_txt);
            Controls.Add(loginform_username_txt);
            Controls.Add(Loginform_login_btn);
            Controls.Add(label1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button Loginform_login_btn;
        private TextBox loginform_username_txt;
        private TextBox loginform_pass_txt;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button loginform_register_btn;
        private Label loginform_close_btn;
        private Label label5;
    }
}
