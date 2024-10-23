namespace QuanLyDoDienTu.view.AdminForm
{
    partial class StaffWorkShiftManageForm
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
            dgv_listWorkShift = new Guna.UI2.WinForms.Guna2DataGridView();
            col_Id = new DataGridViewTextBoxColumn();
            col_startTime = new DataGridViewTextBoxColumn();
            col_endTime = new DataGridViewTextBoxColumn();
            col_Job = new DataGridViewTextBoxColumn();
            col_Edit = new DataGridViewButtonColumn();
            col_delete = new DataGridViewButtonColumn();
            btn_addJob = new Guna.UI2.WinForms.Guna2Button();
            tb_search = new Guna.UI2.WinForms.Guna2TextBox();
            btn_Search = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)dgv_listWorkShift).BeginInit();
            SuspendLayout();
            // 
            // dgv_listWorkShift
            // 
            dgv_listWorkShift.AllowUserToAddRows = false;
            dgv_listWorkShift.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            dgv_listWorkShift.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgv_listWorkShift.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgv_listWorkShift.ColumnHeadersHeight = 22;
            dgv_listWorkShift.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgv_listWorkShift.Columns.AddRange(new DataGridViewColumn[] { col_Id, col_startTime, col_endTime, col_Job, col_Edit, col_delete });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgv_listWorkShift.DefaultCellStyle = dataGridViewCellStyle3;
            dgv_listWorkShift.Dock = DockStyle.Right;
            dgv_listWorkShift.GridColor = Color.FromArgb(231, 229, 255);
            dgv_listWorkShift.Location = new Point(412, 0);
            dgv_listWorkShift.Name = "dgv_listWorkShift";
            dgv_listWorkShift.ReadOnly = true;
            dgv_listWorkShift.RowHeadersVisible = false;
            dgv_listWorkShift.RowHeadersWidth = 51;
            dgv_listWorkShift.RowTemplate.Height = 29;
            dgv_listWorkShift.Size = new Size(918, 386);
            dgv_listWorkShift.TabIndex = 25;
            dgv_listWorkShift.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgv_listWorkShift.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgv_listWorkShift.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgv_listWorkShift.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgv_listWorkShift.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgv_listWorkShift.ThemeStyle.BackColor = Color.White;
            dgv_listWorkShift.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dgv_listWorkShift.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgv_listWorkShift.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv_listWorkShift.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dgv_listWorkShift.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgv_listWorkShift.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgv_listWorkShift.ThemeStyle.HeaderStyle.Height = 22;
            dgv_listWorkShift.ThemeStyle.ReadOnly = true;
            dgv_listWorkShift.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgv_listWorkShift.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv_listWorkShift.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dgv_listWorkShift.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgv_listWorkShift.ThemeStyle.RowsStyle.Height = 29;
            dgv_listWorkShift.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgv_listWorkShift.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dgv_listWorkShift.CellContentClick += dgv_listWorkShift_CellContentClick;
            // 
            // col_Id
            // 
            col_Id.FillWeight = 60F;
            col_Id.HeaderText = "Mã ca";
            col_Id.MinimumWidth = 6;
            col_Id.Name = "col_Id";
            col_Id.ReadOnly = true;
            // 
            // col_startTime
            // 
            col_startTime.FillWeight = 83.728035F;
            col_startTime.HeaderText = "Thời gian bắt đầu";
            col_startTime.MinimumWidth = 6;
            col_startTime.Name = "col_startTime";
            col_startTime.ReadOnly = true;
            // 
            // col_endTime
            // 
            col_endTime.FillWeight = 83.728035F;
            col_endTime.HeaderText = "Thời gian kết thúc";
            col_endTime.MinimumWidth = 6;
            col_endTime.Name = "col_endTime";
            col_endTime.ReadOnly = true;
            // 
            // col_Job
            // 
            col_Job.FillWeight = 40F;
            col_Job.HeaderText = "Công việc";
            col_Job.MinimumWidth = 6;
            col_Job.Name = "col_Job";
            col_Job.ReadOnly = true;
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
            // btn_addJob
            // 
            btn_addJob.BorderRadius = 15;
            btn_addJob.CustomizableEdges = customizableEdges1;
            btn_addJob.DisabledState.BorderColor = Color.DarkGray;
            btn_addJob.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_addJob.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_addJob.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_addJob.FillColor = Color.FromArgb(128, 128, 255);
            btn_addJob.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btn_addJob.ForeColor = Color.White;
            btn_addJob.Location = new Point(89, 179);
            btn_addJob.Name = "btn_addJob";
            btn_addJob.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btn_addJob.Size = new Size(199, 53);
            btn_addJob.TabIndex = 26;
            btn_addJob.Text = "Thêm ca công việc";
            btn_addJob.Click += btn_addJob_Click;
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
            tb_search.Location = new Point(151, 57);
            tb_search.Name = "tb_search";
            tb_search.PasswordChar = '\0';
            tb_search.PlaceholderText = "";
            tb_search.SelectedText = "";
            tb_search.ShadowDecoration.CustomizableEdges = customizableEdges4;
            tb_search.Size = new Size(217, 45);
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
            btn_Search.Location = new Point(9, 55);
            btn_Search.Name = "btn_Search";
            btn_Search.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btn_Search.Size = new Size(126, 47);
            btn_Search.TabIndex = 38;
            btn_Search.Text = "Tìm kiếm";
            btn_Search.Click += btn_Search_Click;
            // 
            // StaffWorkShiftManageForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1330, 386);
            Controls.Add(tb_search);
            Controls.Add(btn_Search);
            Controls.Add(btn_addJob);
            Controls.Add(dgv_listWorkShift);
            Name = "StaffWorkShiftManageForm";
            Text = "StaffWorkShiftManageForm";
            Load += StaffWorkShiftManageForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_listWorkShift).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView dgv_listWorkShift;
        private Guna.UI2.WinForms.Guna2Button btn_addJob;
        private DataGridViewTextBoxColumn col_Id;
        private DataGridViewTextBoxColumn col_startTime;
        private DataGridViewTextBoxColumn col_endTime;
        private DataGridViewTextBoxColumn col_Job;
        private DataGridViewButtonColumn col_Edit;
        private DataGridViewButtonColumn col_delete;
        private Guna.UI2.WinForms.Guna2TextBox tb_search;
        private Guna.UI2.WinForms.Guna2Button btn_Search;
    }
}