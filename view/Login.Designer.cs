namespace QuanLyDoDienTu.view
{
    partial class Login
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            tb_Phone = new Guna.UI2.WinForms.Guna2TextBox();
            label1 = new Label();
            label2 = new Label();
            tb_Password = new Guna.UI2.WinForms.Guna2TextBox();
            btn_Login = new Guna.UI2.WinForms.Guna2Button();
            SuspendLayout();
            // 
            // tb_Phone
            // 
            tb_Phone.CustomizableEdges = customizableEdges7;
            tb_Phone.DefaultText = "";
            tb_Phone.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tb_Phone.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            tb_Phone.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            tb_Phone.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tb_Phone.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            tb_Phone.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            tb_Phone.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            tb_Phone.Location = new Point(93, 79);
            tb_Phone.Name = "tb_Phone";
            tb_Phone.PasswordChar = '\0';
            tb_Phone.PlaceholderText = "";
            tb_Phone.SelectedText = "";
            tb_Phone.ShadowDecoration.CustomizableEdges = customizableEdges8;
            tb_Phone.Size = new Size(250, 45);
            tb_Phone.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(93, 56);
            label1.Name = "label1";
            label1.Size = new Size(97, 20);
            label1.TabIndex = 1;
            label1.Text = "Số điện thoại";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(95, 146);
            label2.Name = "label2";
            label2.Size = new Size(70, 20);
            label2.TabIndex = 3;
            label2.Text = "Mật khẩu";
            // 
            // tb_Password
            // 
            tb_Password.CustomizableEdges = customizableEdges9;
            tb_Password.DefaultText = "";
            tb_Password.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tb_Password.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            tb_Password.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            tb_Password.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tb_Password.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            tb_Password.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            tb_Password.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            tb_Password.Location = new Point(93, 169);
            tb_Password.Name = "tb_Password";
            tb_Password.PasswordChar = '●';
            tb_Password.PlaceholderText = "*";
            tb_Password.SelectedText = "";
            tb_Password.ShadowDecoration.CustomizableEdges = customizableEdges10;
            tb_Password.Size = new Size(252, 45);
            tb_Password.TabIndex = 2;
            tb_Password.UseSystemPasswordChar = true;
            // 
            // btn_Login
            // 
            btn_Login.BorderRadius = 25;
            btn_Login.CustomizableEdges = customizableEdges11;
            btn_Login.DisabledState.BorderColor = Color.DarkGray;
            btn_Login.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_Login.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_Login.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_Login.FillColor = Color.FromArgb(0, 192, 0);
            btn_Login.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btn_Login.ForeColor = Color.White;
            btn_Login.Location = new Point(93, 251);
            btn_Login.Name = "btn_Login";
            btn_Login.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btn_Login.Size = new Size(252, 48);
            btn_Login.TabIndex = 35;
            btn_Login.Text = "Đăng nhập";
            btn_Login.Click += btn_Login_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(429, 337);
            Controls.Add(btn_Login);
            Controls.Add(label2);
            Controls.Add(tb_Password);
            Controls.Add(label1);
            Controls.Add(tb_Phone);
            Name = "Login";
            Text = "Login";
            Load += Login_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox tb_Phone;
        private Label label1;
        private Label label2;
        private Guna.UI2.WinForms.Guna2TextBox tb_Password;
        private Guna.UI2.WinForms.Guna2Button btn_Login;
    }
}