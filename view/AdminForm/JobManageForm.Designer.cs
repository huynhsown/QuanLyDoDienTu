﻿namespace QuanLyDoDienTu.view.AdminForm
{
    partial class JobManageForm
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
            btn_add = new Guna.UI2.WinForms.Guna2Button();
            dgv_listJob = new Guna.UI2.WinForms.Guna2DataGridView();
            col_Id = new DataGridViewTextBoxColumn();
            col_Name = new DataGridViewTextBoxColumn();
            col_Salary = new DataGridViewTextBoxColumn();
            col_Edit = new DataGridViewButtonColumn();
            col_Delete = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)dgv_listJob).BeginInit();
            SuspendLayout();
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
            btn_add.Location = new Point(48, 545);
            btn_add.Name = "btn_add";
            btn_add.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btn_add.Size = new Size(159, 35);
            btn_add.TabIndex = 29;
            btn_add.Text = "Thêm công việc";
            btn_add.Click += btn_add_Click;
            // 
            // dgv_listJob
            // 
            dgv_listJob.AllowUserToAddRows = false;
            dgv_listJob.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            dgv_listJob.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgv_listJob.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgv_listJob.ColumnHeadersHeight = 22;
            dgv_listJob.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgv_listJob.Columns.AddRange(new DataGridViewColumn[] { col_Id, col_Name, col_Salary, col_Edit, col_Delete });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgv_listJob.DefaultCellStyle = dataGridViewCellStyle3;
            dgv_listJob.Dock = DockStyle.Top;
            dgv_listJob.GridColor = Color.FromArgb(231, 229, 255);
            dgv_listJob.Location = new Point(0, 0);
            dgv_listJob.Name = "dgv_listJob";
            dgv_listJob.ReadOnly = true;
            dgv_listJob.RowHeadersVisible = false;
            dgv_listJob.RowHeadersWidth = 51;
            dgv_listJob.RowTemplate.Height = 29;
            dgv_listJob.Size = new Size(842, 525);
            dgv_listJob.TabIndex = 28;
            dgv_listJob.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgv_listJob.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgv_listJob.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgv_listJob.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgv_listJob.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgv_listJob.ThemeStyle.BackColor = Color.White;
            dgv_listJob.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dgv_listJob.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgv_listJob.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv_listJob.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dgv_listJob.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgv_listJob.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgv_listJob.ThemeStyle.HeaderStyle.Height = 22;
            dgv_listJob.ThemeStyle.ReadOnly = true;
            dgv_listJob.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgv_listJob.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv_listJob.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dgv_listJob.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgv_listJob.ThemeStyle.RowsStyle.Height = 29;
            dgv_listJob.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgv_listJob.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dgv_listJob.CellContentClick += dgv_listJob_CellContentClick;
            // 
            // col_Id
            // 
            col_Id.FillWeight = 60F;
            col_Id.HeaderText = "Mã công việc";
            col_Id.MinimumWidth = 6;
            col_Id.Name = "col_Id";
            col_Id.ReadOnly = true;
            // 
            // col_Name
            // 
            col_Name.FillWeight = 83.728035F;
            col_Name.HeaderText = "Tên công việc";
            col_Name.MinimumWidth = 6;
            col_Name.Name = "col_Name";
            col_Name.ReadOnly = true;
            // 
            // col_Salary
            // 
            col_Salary.FillWeight = 83.728035F;
            col_Salary.HeaderText = "Lương";
            col_Salary.MinimumWidth = 6;
            col_Salary.Name = "col_Salary";
            col_Salary.ReadOnly = true;
            // 
            // col_Edit
            // 
            col_Edit.FillWeight = 30F;
            col_Edit.HeaderText = "Sửa";
            col_Edit.MinimumWidth = 6;
            col_Edit.Name = "col_Edit";
            col_Edit.ReadOnly = true;
            col_Edit.Resizable = DataGridViewTriState.True;
            col_Edit.SortMode = DataGridViewColumnSortMode.Automatic;
            col_Edit.Text = "Sửa";
            col_Edit.UseColumnTextForButtonValue = true;
            // 
            // col_Delete
            // 
            col_Delete.FillWeight = 30F;
            col_Delete.HeaderText = "Xóa";
            col_Delete.MinimumWidth = 6;
            col_Delete.Name = "col_Delete";
            col_Delete.ReadOnly = true;
            col_Delete.Text = "Xóa";
            col_Delete.UseColumnTextForButtonValue = true;
            // 
            // JobManageForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(842, 616);
            Controls.Add(btn_add);
            Controls.Add(dgv_listJob);
            FormBorderStyle = FormBorderStyle.None;
            Name = "JobManageForm";
            Text = "JobManageForm";
            Load += JobManageForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_listJob).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btn_add;
        private Guna.UI2.WinForms.Guna2DataGridView dgv_listJob;
        private DataGridViewTextBoxColumn col_Id;
        private DataGridViewTextBoxColumn col_Name;
        private DataGridViewTextBoxColumn col_Salary;
        private DataGridViewButtonColumn col_Edit;
        private DataGridViewButtonColumn col_Delete;
    }
}