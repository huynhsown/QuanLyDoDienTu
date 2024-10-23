namespace QuanLyDoDienTu.view.AdminForm
{
    partial class StaffManageForm
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btn_addStaff = new Guna.UI2.WinForms.Guna2Button();
            dgv_listStaff = new Guna.UI2.WinForms.Guna2DataGridView();
            col_Id = new DataGridViewTextBoxColumn();
            col_Name = new DataGridViewTextBoxColumn();
            col_Birth = new DataGridViewTextBoxColumn();
            col_Gender = new DataGridViewTextBoxColumn();
            col_Phone = new DataGridViewTextBoxColumn();
            col_Email = new DataGridViewTextBoxColumn();
            col_Address = new DataGridViewTextBoxColumn();
            col_Job = new DataGridViewTextBoxColumn();
            col_workShift = new DataGridViewButtonColumn();
            col_Edit = new DataGridViewButtonColumn();
            col_delete = new DataGridViewButtonColumn();
            tb_search = new Guna.UI2.WinForms.Guna2TextBox();
            btn_Search = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)dgv_listStaff).BeginInit();
            SuspendLayout();
            // 
            // btn_addStaff
            // 
            btn_addStaff.BorderRadius = 15;
            btn_addStaff.CustomizableEdges = customizableEdges1;
            btn_addStaff.DisabledState.BorderColor = Color.DarkGray;
            btn_addStaff.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_addStaff.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_addStaff.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_addStaff.FillColor = Color.FromArgb(128, 128, 255);
            btn_addStaff.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btn_addStaff.ForeColor = Color.White;
            btn_addStaff.Location = new Point(774, 595);
            btn_addStaff.Name = "btn_addStaff";
            btn_addStaff.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btn_addStaff.Size = new Size(172, 45);
            btn_addStaff.TabIndex = 23;
            btn_addStaff.Text = "Thêm nhân viên";
            btn_addStaff.Click += btn_addStaff_Click;
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
            dgv_listStaff.Columns.AddRange(new DataGridViewColumn[] { col_Id, col_Name, col_Birth, col_Gender, col_Phone, col_Email, col_Address, col_Job, col_workShift, col_Edit, col_delete });
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
            dgv_listStaff.Size = new Size(1164, 525);
            dgv_listStaff.TabIndex = 24;
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
            dgv_listStaff.CellContentClick += dgv_listStaff_CellContentClick_1;
            // 
            // col_Id
            // 
            col_Id.FillWeight = 60F;
            col_Id.HeaderText = "Mã nhân viên";
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
            // col_Birth
            // 
            col_Birth.FillWeight = 83.728035F;
            col_Birth.HeaderText = "Ngày sinh";
            col_Birth.MinimumWidth = 6;
            col_Birth.Name = "col_Birth";
            col_Birth.ReadOnly = true;
            // 
            // col_Gender
            // 
            col_Gender.FillWeight = 40F;
            col_Gender.HeaderText = "Giới tính";
            col_Gender.MinimumWidth = 6;
            col_Gender.Name = "col_Gender";
            col_Gender.ReadOnly = true;
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
            // col_Job
            // 
            col_Job.FillWeight = 83.728035F;
            col_Job.HeaderText = "Công việc";
            col_Job.MinimumWidth = 6;
            col_Job.Name = "col_Job";
            col_Job.ReadOnly = true;
            // 
            // col_workShift
            // 
            col_workShift.FillWeight = 45F;
            col_workShift.HeaderText = "Ca làm ";
            col_workShift.MinimumWidth = 6;
            col_workShift.Name = "col_workShift";
            col_workShift.ReadOnly = true;
            col_workShift.Resizable = DataGridViewTriState.True;
            col_workShift.SortMode = DataGridViewColumnSortMode.Automatic;
            col_workShift.Text = "Xem";
            col_workShift.UseColumnTextForButtonValue = true;
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
            col_delete.FillWeight = 40F;
            col_delete.HeaderText = "Xóa";
            col_delete.MinimumWidth = 6;
            col_delete.Name = "col_delete";
            col_delete.ReadOnly = true;
            col_delete.Text = "Xóa";
            col_delete.UseColumnTextForButtonValue = true;
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
            tb_search.Location = new Point(389, 593);
            tb_search.Name = "tb_search";
            tb_search.PasswordChar = '\0';
            tb_search.PlaceholderText = "";
            tb_search.SelectedText = "";
            tb_search.ShadowDecoration.CustomizableEdges = customizableEdges4;
            tb_search.Size = new Size(250, 45);
            tb_search.TabIndex = 39;
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
            btn_Search.Location = new Point(224, 593);
            btn_Search.Name = "btn_Search";
            btn_Search.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btn_Search.Size = new Size(159, 47);
            btn_Search.TabIndex = 38;
            btn_Search.Text = "Tìm kiếm";
            btn_Search.Click += btn_Search_Click;
            // 
            // StaffManageForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1164, 678);
            Controls.Add(tb_search);
            Controls.Add(btn_Search);
            Controls.Add(dgv_listStaff);
            Controls.Add(btn_addStaff);
            FormBorderStyle = FormBorderStyle.None;
            Name = "StaffManageForm";
            Text = "StaffManageForm";
            Load += StaffManageForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_listStaff).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button btn_addStaff;
        private Guna.UI2.WinForms.Guna2DataGridView dgv_listStaff;
        private DataGridViewTextBoxColumn col_Id;
        private DataGridViewTextBoxColumn col_Name;
        private DataGridViewTextBoxColumn col_Birth;
        private DataGridViewTextBoxColumn col_Gender;
        private DataGridViewTextBoxColumn col_Phone;
        private DataGridViewTextBoxColumn col_Email;
        private DataGridViewTextBoxColumn col_Address;
        private DataGridViewTextBoxColumn col_Job;
        private DataGridViewButtonColumn col_workShift;
        private DataGridViewButtonColumn col_Edit;
        private DataGridViewButtonColumn col_delete;
        private Guna.UI2.WinForms.Guna2TextBox tb_search;
        private Guna.UI2.WinForms.Guna2Button btn_Search;
    }
}