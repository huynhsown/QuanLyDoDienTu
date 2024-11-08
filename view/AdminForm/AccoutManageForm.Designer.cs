namespace QuanLyDoDienTu.view.AdminForm
{
    partial class AccoutManageForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            dgv_listAccout = new Guna.UI2.WinForms.Guna2DataGridView();
            dgv_listAccountCustomer = new Guna.UI2.WinForms.Guna2DataGridView();
            panel1 = new Panel();
            btn_search = new Guna.UI2.WinForms.Guna2Button();
            rb_customer = new Guna.UI2.WinForms.Guna2RadioButton();
            rb_staff = new Guna.UI2.WinForms.Guna2RadioButton();
            cbb_search = new Guna.UI2.WinForms.Guna2ComboBox();
            tb_search = new Guna.UI2.WinForms.Guna2TextBox();
            col_Id = new DataGridViewTextBoxColumn();
            col_Phone = new DataGridViewTextBoxColumn();
            col_Password = new DataGridViewTextBoxColumn();
            col_Name = new DataGridViewTextBoxColumn();
            col_Role = new DataGridViewTextBoxColumn();
            col_Edit = new DataGridViewButtonColumn();
            col_CId = new DataGridViewTextBoxColumn();
            col_CPhone = new DataGridViewTextBoxColumn();
            col_CPassword = new DataGridViewTextBoxColumn();
            col_CName = new DataGridViewTextBoxColumn();
            col_CRole = new DataGridViewTextBoxColumn();
            col_CEdit = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)dgv_listAccout).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgv_listAccountCustomer).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgv_listAccout
            // 
            dgv_listAccout.AllowUserToAddRows = false;
            dgv_listAccout.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            dgv_listAccout.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgv_listAccout.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgv_listAccout.ColumnHeadersHeight = 22;
            dgv_listAccout.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgv_listAccout.Columns.AddRange(new DataGridViewColumn[] { col_Id, col_Phone, col_Password, col_Name, col_Role, col_Edit });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgv_listAccout.DefaultCellStyle = dataGridViewCellStyle3;
            dgv_listAccout.Dock = DockStyle.Top;
            dgv_listAccout.GridColor = Color.FromArgb(231, 229, 255);
            dgv_listAccout.Location = new Point(0, 0);
            dgv_listAccout.Name = "dgv_listAccout";
            dgv_listAccout.ReadOnly = true;
            dgv_listAccout.RowHeadersVisible = false;
            dgv_listAccout.RowHeadersWidth = 51;
            dgv_listAccout.RowTemplate.Height = 29;
            dgv_listAccout.Size = new Size(1128, 267);
            dgv_listAccout.TabIndex = 26;
            dgv_listAccout.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgv_listAccout.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgv_listAccout.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgv_listAccout.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgv_listAccout.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgv_listAccout.ThemeStyle.BackColor = Color.White;
            dgv_listAccout.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dgv_listAccout.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgv_listAccout.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv_listAccout.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dgv_listAccout.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgv_listAccout.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgv_listAccout.ThemeStyle.HeaderStyle.Height = 22;
            dgv_listAccout.ThemeStyle.ReadOnly = true;
            dgv_listAccout.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgv_listAccout.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv_listAccout.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dgv_listAccout.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgv_listAccout.ThemeStyle.RowsStyle.Height = 29;
            dgv_listAccout.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgv_listAccout.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dgv_listAccout.CellContentClick += dgv_listAccout_CellContentClick;
            // 
            // dgv_listAccountCustomer
            // 
            dgv_listAccountCustomer.AllowUserToAddRows = false;
            dgv_listAccountCustomer.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = Color.White;
            dgv_listAccountCustomer.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgv_listAccountCustomer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgv_listAccountCustomer.ColumnHeadersHeight = 22;
            dgv_listAccountCustomer.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgv_listAccountCustomer.Columns.AddRange(new DataGridViewColumn[] { col_CId, col_CPhone, col_CPassword, col_CName, col_CRole, col_CEdit });
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.White;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle6.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dgv_listAccountCustomer.DefaultCellStyle = dataGridViewCellStyle6;
            dgv_listAccountCustomer.Dock = DockStyle.Top;
            dgv_listAccountCustomer.GridColor = Color.FromArgb(231, 229, 255);
            dgv_listAccountCustomer.Location = new Point(0, 267);
            dgv_listAccountCustomer.Name = "dgv_listAccountCustomer";
            dgv_listAccountCustomer.ReadOnly = true;
            dgv_listAccountCustomer.RowHeadersVisible = false;
            dgv_listAccountCustomer.RowHeadersWidth = 51;
            dgv_listAccountCustomer.RowTemplate.Height = 29;
            dgv_listAccountCustomer.Size = new Size(1128, 230);
            dgv_listAccountCustomer.TabIndex = 27;
            dgv_listAccountCustomer.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgv_listAccountCustomer.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgv_listAccountCustomer.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgv_listAccountCustomer.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgv_listAccountCustomer.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgv_listAccountCustomer.ThemeStyle.BackColor = Color.White;
            dgv_listAccountCustomer.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dgv_listAccountCustomer.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgv_listAccountCustomer.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv_listAccountCustomer.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dgv_listAccountCustomer.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgv_listAccountCustomer.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgv_listAccountCustomer.ThemeStyle.HeaderStyle.Height = 22;
            dgv_listAccountCustomer.ThemeStyle.ReadOnly = true;
            dgv_listAccountCustomer.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgv_listAccountCustomer.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv_listAccountCustomer.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dgv_listAccountCustomer.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgv_listAccountCustomer.ThemeStyle.RowsStyle.Height = 29;
            dgv_listAccountCustomer.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgv_listAccountCustomer.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dgv_listAccountCustomer.CellContentClick += dgv_listAccountCustomer_CellContentClick;
            // 
            // panel1
            // 
            panel1.Controls.Add(btn_search);
            panel1.Controls.Add(rb_customer);
            panel1.Controls.Add(rb_staff);
            panel1.Controls.Add(cbb_search);
            panel1.Controls.Add(tb_search);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 497);
            panel1.Name = "panel1";
            panel1.Size = new Size(1128, 75);
            panel1.TabIndex = 28;
            panel1.Paint += panel1_Paint;
            // 
            // btn_search
            // 
            btn_search.CustomizableEdges = customizableEdges1;
            btn_search.DisabledState.BorderColor = Color.DarkGray;
            btn_search.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_search.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_search.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_search.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btn_search.ForeColor = Color.White;
            btn_search.Location = new Point(866, 25);
            btn_search.Name = "btn_search";
            btn_search.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btn_search.Size = new Size(128, 36);
            btn_search.TabIndex = 38;
            btn_search.Text = "Tìm";
            btn_search.Click += btn_search_Click;
            // 
            // rb_customer
            // 
            rb_customer.AutoSize = true;
            rb_customer.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
            rb_customer.CheckedState.BorderThickness = 0;
            rb_customer.CheckedState.FillColor = Color.FromArgb(94, 148, 255);
            rb_customer.CheckedState.InnerColor = Color.White;
            rb_customer.CheckedState.InnerOffset = -4;
            rb_customer.Location = new Point(281, 37);
            rb_customer.Name = "rb_customer";
            rb_customer.Size = new Size(107, 24);
            rb_customer.TabIndex = 37;
            rb_customer.Text = "Khách hàng";
            rb_customer.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
            rb_customer.UncheckedState.BorderThickness = 2;
            rb_customer.UncheckedState.FillColor = Color.Transparent;
            rb_customer.UncheckedState.InnerColor = Color.Transparent;
            rb_customer.CheckedChanged += rb_customer_CheckedChanged;
            // 
            // rb_staff
            // 
            rb_staff.AutoSize = true;
            rb_staff.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
            rb_staff.CheckedState.BorderThickness = 0;
            rb_staff.CheckedState.FillColor = Color.FromArgb(94, 148, 255);
            rb_staff.CheckedState.InnerColor = Color.White;
            rb_staff.CheckedState.InnerOffset = -4;
            rb_staff.Location = new Point(166, 37);
            rb_staff.Name = "rb_staff";
            rb_staff.Size = new Size(96, 24);
            rb_staff.TabIndex = 36;
            rb_staff.Text = "Nhân viên";
            rb_staff.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
            rb_staff.UncheckedState.BorderThickness = 2;
            rb_staff.UncheckedState.FillColor = Color.Transparent;
            rb_staff.UncheckedState.InnerColor = Color.Transparent;
            rb_staff.CheckedChanged += rb_staff_CheckedChanged;
            // 
            // cbb_search
            // 
            cbb_search.BackColor = Color.Transparent;
            cbb_search.CustomizableEdges = customizableEdges3;
            cbb_search.DrawMode = DrawMode.OwnerDrawFixed;
            cbb_search.DropDownStyle = ComboBoxStyle.DropDownList;
            cbb_search.FocusedColor = Color.FromArgb(94, 148, 255);
            cbb_search.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cbb_search.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cbb_search.ForeColor = Color.FromArgb(68, 88, 112);
            cbb_search.ItemHeight = 30;
            cbb_search.Location = new Point(394, 25);
            cbb_search.Name = "cbb_search";
            cbb_search.ShadowDecoration.CustomizableEdges = customizableEdges4;
            cbb_search.Size = new Size(175, 36);
            cbb_search.TabIndex = 35;
            cbb_search.SelectedIndexChanged += cbb_search_SelectedIndexChanged;
            // 
            // tb_search
            // 
            tb_search.CustomizableEdges = customizableEdges5;
            tb_search.DefaultText = "";
            tb_search.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tb_search.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            tb_search.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            tb_search.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tb_search.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            tb_search.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            tb_search.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            tb_search.Location = new Point(598, 25);
            tb_search.Name = "tb_search";
            tb_search.PasswordChar = '\0';
            tb_search.PlaceholderText = "";
            tb_search.SelectedText = "";
            tb_search.ShadowDecoration.CustomizableEdges = customizableEdges6;
            tb_search.Size = new Size(250, 36);
            tb_search.TabIndex = 34;
            // 
            // col_Id
            // 
            col_Id.HeaderText = "Mã nhân viên";
            col_Id.MinimumWidth = 6;
            col_Id.Name = "col_Id";
            col_Id.ReadOnly = true;
            // 
            // col_Phone
            // 
            col_Phone.HeaderText = "Số điện thoại";
            col_Phone.MinimumWidth = 6;
            col_Phone.Name = "col_Phone";
            col_Phone.ReadOnly = true;
            // 
            // col_Password
            // 
            col_Password.HeaderText = "Mật khẩu";
            col_Password.MinimumWidth = 6;
            col_Password.Name = "col_Password";
            col_Password.ReadOnly = true;
            // 
            // col_Name
            // 
            col_Name.HeaderText = "Họ tên";
            col_Name.MinimumWidth = 6;
            col_Name.Name = "col_Name";
            col_Name.ReadOnly = true;
            // 
            // col_Role
            // 
            col_Role.HeaderText = "Vai trò";
            col_Role.MinimumWidth = 6;
            col_Role.Name = "col_Role";
            col_Role.ReadOnly = true;
            // 
            // col_Edit
            // 
            col_Edit.FillWeight = 30F;
            col_Edit.HeaderText = "Sửa";
            col_Edit.MinimumWidth = 3;
            col_Edit.Name = "col_Edit";
            col_Edit.ReadOnly = true;
            col_Edit.Text = "Sửa";
            col_Edit.UseColumnTextForButtonValue = true;
            // 
            // col_CId
            // 
            col_CId.HeaderText = "Mã khách hàng";
            col_CId.MinimumWidth = 6;
            col_CId.Name = "col_CId";
            col_CId.ReadOnly = true;
            // 
            // col_CPhone
            // 
            col_CPhone.HeaderText = "Số điện thoại";
            col_CPhone.MinimumWidth = 6;
            col_CPhone.Name = "col_CPhone";
            col_CPhone.ReadOnly = true;
            // 
            // col_CPassword
            // 
            col_CPassword.HeaderText = "Mật khẩu";
            col_CPassword.MinimumWidth = 6;
            col_CPassword.Name = "col_CPassword";
            col_CPassword.ReadOnly = true;
            // 
            // col_CName
            // 
            col_CName.HeaderText = "Họ tên";
            col_CName.MinimumWidth = 6;
            col_CName.Name = "col_CName";
            col_CName.ReadOnly = true;
            // 
            // col_CRole
            // 
            col_CRole.HeaderText = "Vai trò";
            col_CRole.MinimumWidth = 6;
            col_CRole.Name = "col_CRole";
            col_CRole.ReadOnly = true;
            // 
            // col_CEdit
            // 
            col_CEdit.FillWeight = 30F;
            col_CEdit.HeaderText = "Sửa";
            col_CEdit.MinimumWidth = 3;
            col_CEdit.Name = "col_CEdit";
            col_CEdit.ReadOnly = true;
            col_CEdit.Text = "Sửa";
            col_CEdit.UseColumnTextForButtonValue = true;
            // 
            // AccoutManageForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1128, 584);
            Controls.Add(panel1);
            Controls.Add(dgv_listAccountCustomer);
            Controls.Add(dgv_listAccout);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AccoutManageForm";
            Text = "AccoutManageForm";
            Load += AccoutManageForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_listAccout).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgv_listAccountCustomer).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView dgv_listAccout;
        private Guna.UI2.WinForms.Guna2DataGridView dgv_listAccountCustomer;
        private Panel panel1;
        private Guna.UI2.WinForms.Guna2TextBox tb_search;
        private Guna.UI2.WinForms.Guna2RadioButton rb_customer;
        private Guna.UI2.WinForms.Guna2RadioButton rb_staff;
        private Guna.UI2.WinForms.Guna2ComboBox cbb_search;
        private Guna.UI2.WinForms.Guna2Button btn_search;
        private DataGridViewTextBoxColumn col_Id;
        private DataGridViewTextBoxColumn col_Phone;
        private DataGridViewTextBoxColumn col_Password;
        private DataGridViewTextBoxColumn col_Name;
        private DataGridViewTextBoxColumn col_Role;
        private DataGridViewButtonColumn col_Edit;
        private DataGridViewTextBoxColumn col_CId;
        private DataGridViewTextBoxColumn col_CPhone;
        private DataGridViewTextBoxColumn col_CPassword;
        private DataGridViewTextBoxColumn col_CName;
        private DataGridViewTextBoxColumn col_CRole;
        private DataGridViewButtonColumn col_CEdit;
    }
}