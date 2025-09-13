namespace BurtgeliinAjiltniiWinformsApp
{
    partial class RegisterForm
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
            registerform_signin_btn = new Button();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            registerform_password_txt = new TextBox();
            registerform_username_txt = new TextBox();
            registerform_signup_btn = new Button();
            label1 = new Label();
            registerform_confirmpass_txt = new TextBox();
            label5 = new Label();
            registerform_close_btn = new Label();
            label6 = new Label();
            SuspendLayout();
            // 
            // registerform_signin_btn
            // 
            registerform_signin_btn.Location = new Point(168, 363);
            registerform_signin_btn.Name = "registerform_signin_btn";
            registerform_signin_btn.Size = new Size(122, 47);
            registerform_signin_btn.TabIndex = 17;
            registerform_signin_btn.Text = "SIGNIN";
            registerform_signin_btn.UseVisualStyleBackColor = true;
            registerform_signin_btn.Click += registerform_signin_btn_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(145, 342);
            label4.Name = "label4";
            label4.Size = new Size(178, 20);
            label4.TabIndex = 16;
            label4.Text = "Already have an account?";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(511, 136);
            label3.Name = "label3";
            label3.Size = new Size(73, 20);
            label3.TabIndex = 14;
            label3.Text = "Password:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(511, 64);
            label2.Name = "label2";
            label2.Size = new Size(78, 20);
            label2.TabIndex = 13;
            label2.Text = "Username:";
            // 
            // registerform_password_txt
            // 
            registerform_password_txt.Location = new Point(501, 159);
            registerform_password_txt.Multiline = true;
            registerform_password_txt.Name = "registerform_password_txt";
            registerform_password_txt.Size = new Size(203, 43);
            registerform_password_txt.TabIndex = 12;
            registerform_password_txt.TextChanged += registerform_password_txt_TextChanged;
            // 
            // registerform_username_txt
            // 
            registerform_username_txt.Location = new Point(501, 87);
            registerform_username_txt.Multiline = true;
            registerform_username_txt.Name = "registerform_username_txt";
            registerform_username_txt.Size = new Size(203, 46);
            registerform_username_txt.TabIndex = 11;
            registerform_username_txt.TextChanged += registerform_username_txt_TextChanged;
            // 
            // registerform_signup_btn
            // 
            registerform_signup_btn.Location = new Point(537, 315);
            registerform_signup_btn.Name = "registerform_signup_btn";
            registerform_signup_btn.Size = new Size(122, 47);
            registerform_signup_btn.TabIndex = 10;
            registerform_signup_btn.Text = "SIGNUP";
            registerform_signup_btn.UseVisualStyleBackColor = true;
            registerform_signup_btn.Click += registerform_signup_btn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(73, 39);
            label1.Name = "label1";
            label1.Size = new Size(285, 20);
            label1.TabIndex = 9;
            label1.Text = "Burtgeliin Ajiltnii Form App-d tavtai moril";
            // 
            // registerform_confirmpass_txt
            // 
            registerform_confirmpass_txt.Location = new Point(501, 228);
            registerform_confirmpass_txt.Multiline = true;
            registerform_confirmpass_txt.Name = "registerform_confirmpass_txt";
            registerform_confirmpass_txt.Size = new Size(203, 43);
            registerform_confirmpass_txt.TabIndex = 18;
            registerform_confirmpass_txt.TextChanged += registerform_confirmpass_txt_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(511, 205);
            label5.Name = "label5";
            label5.Size = new Size(130, 20);
            label5.TabIndex = 19;
            label5.Text = "Confirm Password:";
            // 
            // registerform_close_btn
            // 
            registerform_close_btn.AutoSize = true;
            registerform_close_btn.Location = new Point(756, 39);
            registerform_close_btn.Name = "registerform_close_btn";
            registerform_close_btn.Size = new Size(18, 20);
            registerform_close_btn.TabIndex = 20;
            registerform_close_btn.Text = "X";
            registerform_close_btn.Click += registerform_close_btn_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(501, 39);
            label6.Name = "label6";
            label6.Size = new Size(73, 20);
            label6.TabIndex = 21;
            label6.Text = "REGISTER";
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label6);
            Controls.Add(registerform_close_btn);
            Controls.Add(label5);
            Controls.Add(registerform_confirmpass_txt);
            Controls.Add(registerform_signin_btn);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(registerform_password_txt);
            Controls.Add(registerform_username_txt);
            Controls.Add(registerform_signup_btn);
            Controls.Add(label1);
            Name = "RegisterForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RegisterForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button registerform_signin_btn;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox registerform_password_txt;
        private TextBox registerform_username_txt;
        private Button registerform_signup_btn;
        private Label label1;
        private TextBox registerform_confirmpass_txt;
        private Label label5;
        private Label registerform_close_btn;
        private Label label6;
    }
}