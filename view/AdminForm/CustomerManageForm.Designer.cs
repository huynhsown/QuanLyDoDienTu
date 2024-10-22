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
            dgv_listStaff = new Guna.UI2.WinForms.Guna2DataGridView();
            btn_add = new Guna.UI2.WinForms.Guna2Button();
            col_Id = new DataGridViewTextBoxColumn();
            col_Name = new DataGridViewTextBoxColumn();
            col_Phone = new DataGridViewTextBoxColumn();
            col_Email = new DataGridViewTextBoxColumn();
            col_Address = new DataGridViewTextBoxColumn();
            col_Edit = new DataGridViewButtonColumn();
            col_delete = new DataGridViewButtonColumn();
            col_history = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)dgv_listStaff).BeginInit();
            SuspendLayout();
            // 
            // dgv_listStaff
            // 
            dgv_listStaff.AllowUserToAddRows = false;
            dgv_listStaff.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            dgv_listStaff.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgv_listStaff.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgv_listStaff.ColumnHeadersHeight = 22;
            dgv_listStaff.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgv_listStaff.Columns.AddRange(new DataGridViewColumn[] { col_Id, col_Name, col_Phone, col_Email, col_Address, col_Edit, col_delete, col_history });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgv_listStaff.DefaultCellStyle = dataGridViewCellStyle3;
            dgv_listStaff.Dock = DockStyle.Top;
            dgv_listStaff.GridColor = Color.FromArgb(231, 229, 255);
            dgv_listStaff.Location = new Point(0, 0);
            dgv_listStaff.Name = "dgv_listStaff";
            dgv_listStaff.ReadOnly = true;
            dgv_listStaff.RowHeadersVisible = false;
            dgv_listStaff.RowHeadersWidth = 51;
            dgv_listStaff.RowTemplate.Height = 29;
            dgv_listStaff.Size = new Size(1146, 525);
            dgv_listStaff.TabIndex = 25;
            dgv_listStaff.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgv_listStaff.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgv_listStaff.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgv_listStaff.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgv_listStaff.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgv_listStaff.ThemeStyle.BackColor = Color.White;
            dgv_listStaff.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dgv_listStaff.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgv_listStaff.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv_listStaff.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dgv_listStaff.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgv_listStaff.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgv_listStaff.ThemeStyle.HeaderStyle.Height = 22;
            dgv_listStaff.ThemeStyle.ReadOnly = true;
            dgv_listStaff.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgv_listStaff.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv_listStaff.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dgv_listStaff.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgv_listStaff.ThemeStyle.RowsStyle.Height = 29;
            dgv_listStaff.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgv_listStaff.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dgv_listStaff.CellContentClick += dgv_listStaff_CellContentClick;
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
            btn_add.Location = new Point(46, 569);
            btn_add.Name = "btn_add";
            btn_add.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btn_add.Size = new Size(159, 35);
            btn_add.TabIndex = 26;
            btn_add.Text = "Thêm khách hàng";
            btn_add.Click += btn_add_Click;
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
            // col_Address
            // 
            col_Address.FillWeight = 83.728035F;
            col_Address.HeaderText = "Địa chỉ";
            col_Address.MinimumWidth = 6;
            col_Address.Name = "col_Address";
            col_Address.ReadOnly = true;
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
            Controls.Add(btn_add);
            Controls.Add(dgv_listStaff);
            FormBorderStyle = FormBorderStyle.None;
            Name = "CustomerManageForm";
            Text = "CustomerManageForm";
            Load += CustomerManageForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_listStaff).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView dgv_listStaff;
        private Guna.UI2.WinForms.Guna2Button btn_add;
        private DataGridViewTextBoxColumn col_Id;
        private DataGridViewTextBoxColumn col_Name;
        private DataGridViewTextBoxColumn col_Phone;
        private DataGridViewTextBoxColumn col_Email;
        private DataGridViewTextBoxColumn col_Address;
        private DataGridViewButtonColumn col_Edit;
        private DataGridViewButtonColumn col_delete;
        private DataGridViewButtonColumn col_history;
    }
}