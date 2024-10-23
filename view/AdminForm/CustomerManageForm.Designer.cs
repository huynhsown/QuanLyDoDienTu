namespace QuanLyDoDienTu.view.AdminForm
{
    partial class CustomerManageForm
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            dgv_listCustomer = new Guna.UI2.WinForms.Guna2DataGridView();
            btn_add = new Guna.UI2.WinForms.Guna2Button();
            tb_search = new Guna.UI2.WinForms.Guna2TextBox();
            btn_Search = new Guna.UI2.WinForms.Guna2Button();
            col_Id = new DataGridViewTextBoxColumn();
            col_Name = new DataGridViewTextBoxColumn();
            col_Address = new DataGridViewTextBoxColumn();
            col_Phone = new DataGridViewTextBoxColumn();
            col_Email = new DataGridViewTextBoxColumn();
            col_Edit = new DataGridViewButtonColumn();
            col_delete = new DataGridViewButtonColumn();
            col_history = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)dgv_listCustomer).BeginInit();
            SuspendLayout();
            // 
            // dgv_listCustomer
            // 
            dgv_listCustomer.AllowUserToAddRows = false;
            dgv_listCustomer.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            dgv_listCustomer.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgv_listCustomer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgv_listCustomer.ColumnHeadersHeight = 22;
            dgv_listCustomer.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgv_listCustomer.Columns.AddRange(new DataGridViewColumn[] { col_Id, col_Name, col_Address, col_Phone, col_Email, col_Edit, col_delete, col_history });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgv_listCustomer.DefaultCellStyle = dataGridViewCellStyle3;
            dgv_listCustomer.Dock = DockStyle.Top;
            dgv_listCustomer.GridColor = Color.FromArgb(231, 229, 255);
            dgv_listCustomer.Location = new Point(0, 0);
            dgv_listCustomer.Name = "dgv_listCustomer";
            dgv_listCustomer.ReadOnly = true;
            dgv_listCustomer.RowHeadersVisible = false;
            dgv_listCustomer.RowHeadersWidth = 51;
            dgv_listCustomer.RowTemplate.Height = 29;
            dgv_listCustomer.Size = new Size(1146, 525);
            dgv_listCustomer.TabIndex = 25;
            dgv_listCustomer.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgv_listCustomer.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgv_listCustomer.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgv_listCustomer.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgv_listCustomer.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgv_listCustomer.ThemeStyle.BackColor = Color.White;
            dgv_listCustomer.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dgv_listCustomer.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgv_listCustomer.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv_listCustomer.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dgv_listCustomer.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgv_listCustomer.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgv_listCustomer.ThemeStyle.HeaderStyle.Height = 22;
            dgv_listCustomer.ThemeStyle.ReadOnly = true;
            dgv_listCustomer.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgv_listCustomer.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv_listCustomer.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dgv_listCustomer.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgv_listCustomer.ThemeStyle.RowsStyle.Height = 29;
            dgv_listCustomer.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgv_listCustomer.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dgv_listCustomer.CellContentClick += dgv_listStaff_CellContentClick;
            // 
            // btn_add
            // 
            btn_add.BorderRadius = 15;
            btn_add.CustomizableEdges = customizableEdges1;
            btn_add.DisabledState.BorderColor = Color.DarkGray;
            btn_add.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_add.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_add.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_add.FillColor = Color.FromArgb(128, 128, 255);
            btn_add.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btn_add.ForeColor = Color.White;
            btn_add.Location = new Point(795, 557);
            btn_add.Name = "btn_add";
            btn_add.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btn_add.Size = new Size(170, 45);
            btn_add.TabIndex = 26;
            btn_add.Text = "Thêm khách hàng";
            btn_add.Click += btn_add_Click;
            // 
            // tb_search
            // 
            tb_search.CustomizableEdges = customizableEdges3;
            tb_search.DefaultText = "";
            tb_search.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tb_search.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            tb_search.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            tb_search.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tb_search.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            tb_search.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            tb_search.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            tb_search.Location = new Point(355, 557);
            tb_search.Name = "tb_search";
            tb_search.PasswordChar = '\0';
            tb_search.PlaceholderText = "";
            tb_search.SelectedText = "";
            tb_search.ShadowDecoration.CustomizableEdges = customizableEdges4;
            tb_search.Size = new Size(250, 45);
            tb_search.TabIndex = 33;
            // 
            // btn_Search
            // 
            btn_Search.BorderRadius = 15;
            btn_Search.CustomizableEdges = customizableEdges5;
            btn_Search.DisabledState.BorderColor = Color.DarkGray;
            btn_Search.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_Search.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_Search.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_Search.FillColor = Color.FromArgb(128, 128, 255);
            btn_Search.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btn_Search.ForeColor = Color.White;
            btn_Search.Location = new Point(156, 557);
            btn_Search.Name = "btn_Search";
            btn_Search.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btn_Search.Size = new Size(159, 47);
            btn_Search.TabIndex = 32;
            btn_Search.Text = "Tìm kiếm";
            btn_Search.Click += btn_Search_Click;
            // 
            // col_Id
            // 
            col_Id.FillWeight = 60F;
            col_Id.HeaderText = "Mã khách hàng";
            col_Id.MinimumWidth = 6;
            col_Id.Name = "col_Id";
            col_Id.ReadOnly = true;
            // 
            // col_Name
            // 
            col_Name.FillWeight = 83.728035F;
            col_Name.HeaderText = "Họ tên";
            col_Name.MinimumWidth = 6;
            col_Name.Name = "col_Name";
            col_Name.ReadOnly = true;
            // 
            // col_Address
            // 
            col_Address.FillWeight = 83.728035F;
            col_Address.HeaderText = "Địa chỉ";
            col_Address.MinimumWidth = 6;
            col_Address.Name = "col_Address";
            col_Address.ReadOnly = true;
            // 
            // col_Phone
            // 
            col_Phone.FillWeight = 83.728035F;
            col_Phone.HeaderText = "SĐT";
            col_Phone.MinimumWidth = 6;
            col_Phone.Name = "col_Phone";
            col_Phone.ReadOnly = true;
            // 
            // col_Email
            // 
            col_Email.FillWeight = 83.728035F;
            col_Email.HeaderText = "Email";
            col_Email.MinimumWidth = 6;
            col_Email.Name = "col_Email";
            col_Email.ReadOnly = true;
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
            // col_delete
            // 
            col_delete.FillWeight = 30F;
            col_delete.HeaderText = "Xóa";
            col_delete.MinimumWidth = 3;
            col_delete.Name = "col_delete";
            col_delete.ReadOnly = true;
            col_delete.Text = "Xóa";
            col_delete.UseColumnTextForButtonValue = true;
            // 
            // col_history
            // 
            col_history.FillWeight = 30F;
            col_history.HeaderText = "Lịch sử";
            col_history.MinimumWidth = 3;
            col_history.Name = "col_history";
            col_history.ReadOnly = true;
            col_history.Resizable = DataGridViewTriState.True;
            col_history.SortMode = DataGridViewColumnSortMode.Automatic;
            col_history.Text = "Xem";
            col_history.UseColumnTextForButtonValue = true;
            // 
            // CustomerManageForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1146, 631);
            Controls.Add(tb_search);
            Controls.Add(btn_Search);
            Controls.Add(btn_add);
            Controls.Add(dgv_listCustomer);
            FormBorderStyle = FormBorderStyle.None;
            Name = "CustomerManageForm";
            Text = "CustomerManageForm";
            Load += CustomerManageForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_listCustomer).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView dgv_listCustomer;
        private Guna.UI2.WinForms.Guna2Button btn_add;
        private Guna.UI2.WinForms.Guna2TextBox tb_search;
        private Guna.UI2.WinForms.Guna2Button btn_Search;
        private DataGridViewTextBoxColumn col_Id;
        private DataGridViewTextBoxColumn col_Name;
        private DataGridViewTextBoxColumn col_Address;
        private DataGridViewTextBoxColumn col_Phone;
        private DataGridViewTextBoxColumn col_Email;
        private DataGridViewButtonColumn col_Edit;
        private DataGridViewButtonColumn col_delete;
        private DataGridViewButtonColumn col_history;
    }
}