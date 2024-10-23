namespace QuanLyDoDienTu.view.AdminForm
{
    partial class ApplicationManageForm
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
            btn_add = new Guna.UI2.WinForms.Guna2Button();
            dgv_listApplication = new Guna.UI2.WinForms.Guna2DataGridView();
            col_Id = new DataGridViewTextBoxColumn();
            col_Name = new DataGridViewTextBoxColumn();
            col_Discount = new DataGridViewTextBoxColumn();
            col_Edit = new DataGridViewButtonColumn();
            col_Delete = new DataGridViewButtonColumn();
            btn_Search = new Guna.UI2.WinForms.Guna2Button();
            tb_search = new Guna.UI2.WinForms.Guna2TextBox();
            ((System.ComponentModel.ISupportInitialize)dgv_listApplication).BeginInit();
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
            btn_add.Location = new Point(843, 515);
            btn_add.Name = "btn_add";
            btn_add.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btn_add.Size = new Size(159, 47);
            btn_add.TabIndex = 29;
            btn_add.Text = "Thêm ứng dụng";
            btn_add.Click += btn_add_Click;
            // 
            // dgv_listApplication
            // 
            dgv_listApplication.AllowUserToAddRows = false;
            dgv_listApplication.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            dgv_listApplication.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgv_listApplication.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgv_listApplication.ColumnHeadersHeight = 22;
            dgv_listApplication.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgv_listApplication.Columns.AddRange(new DataGridViewColumn[] { col_Id, col_Name, col_Discount, col_Edit, col_Delete });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgv_listApplication.DefaultCellStyle = dataGridViewCellStyle3;
            dgv_listApplication.Dock = DockStyle.Top;
            dgv_listApplication.GridColor = Color.FromArgb(231, 229, 255);
            dgv_listApplication.Location = new Point(0, 0);
            dgv_listApplication.Name = "dgv_listApplication";
            dgv_listApplication.ReadOnly = true;
            dgv_listApplication.RowHeadersVisible = false;
            dgv_listApplication.RowHeadersWidth = 51;
            dgv_listApplication.RowTemplate.Height = 29;
            dgv_listApplication.Size = new Size(1111, 416);
            dgv_listApplication.TabIndex = 28;
            dgv_listApplication.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgv_listApplication.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgv_listApplication.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgv_listApplication.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgv_listApplication.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgv_listApplication.ThemeStyle.BackColor = Color.White;
            dgv_listApplication.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dgv_listApplication.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgv_listApplication.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv_listApplication.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dgv_listApplication.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgv_listApplication.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgv_listApplication.ThemeStyle.HeaderStyle.Height = 22;
            dgv_listApplication.ThemeStyle.ReadOnly = true;
            dgv_listApplication.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgv_listApplication.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv_listApplication.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dgv_listApplication.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgv_listApplication.ThemeStyle.RowsStyle.Height = 29;
            dgv_listApplication.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgv_listApplication.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dgv_listApplication.CellContentClick += dgv_listProduct_CellContentClick;
            // 
            // col_Id
            // 
            col_Id.FillWeight = 60F;
            col_Id.HeaderText = "Mã ứng dụng";
            col_Id.MinimumWidth = 6;
            col_Id.Name = "col_Id";
            col_Id.ReadOnly = true;
            // 
            // col_Name
            // 
            col_Name.FillWeight = 83.728035F;
            col_Name.HeaderText = "Tên ứng dụng";
            col_Name.MinimumWidth = 6;
            col_Name.Name = "col_Name";
            col_Name.ReadOnly = true;
            // 
            // col_Discount
            // 
            col_Discount.FillWeight = 83.728035F;
            col_Discount.HeaderText = "Chiết khấu";
            col_Discount.MinimumWidth = 6;
            col_Discount.Name = "col_Discount";
            col_Discount.ReadOnly = true;
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
            // btn_Search
            // 
            btn_Search.BorderRadius = 15;
            btn_Search.CustomizableEdges = customizableEdges3;
            btn_Search.DisabledState.BorderColor = Color.DarkGray;
            btn_Search.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_Search.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_Search.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_Search.FillColor = Color.FromArgb(128, 128, 255);
            btn_Search.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btn_Search.ForeColor = Color.White;
            btn_Search.Location = new Point(76, 517);
            btn_Search.Name = "btn_Search";
            btn_Search.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btn_Search.Size = new Size(159, 47);
            btn_Search.TabIndex = 30;
            btn_Search.Text = "Tìm kiếm";
            btn_Search.Click += btn_Search_Click;
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
            tb_search.Location = new Point(275, 517);
            tb_search.Name = "tb_search";
            tb_search.PasswordChar = '\0';
            tb_search.PlaceholderText = "";
            tb_search.SelectedText = "";
            tb_search.ShadowDecoration.CustomizableEdges = customizableEdges6;
            tb_search.Size = new Size(250, 45);
            tb_search.TabIndex = 31;
            // 
            // ApplicationManageForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1111, 640);
            Controls.Add(tb_search);
            Controls.Add(btn_Search);
            Controls.Add(btn_add);
            Controls.Add(dgv_listApplication);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ApplicationManageForm";
            Text = "ApplicationManageForm";
            Load += ApplicationManageForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_listApplication).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btn_add;
        private Guna.UI2.WinForms.Guna2DataGridView dgv_listApplication;
        private DataGridViewTextBoxColumn col_Id;
        private DataGridViewTextBoxColumn col_Name;
        private DataGridViewTextBoxColumn col_Discount;
        private DataGridViewButtonColumn col_Edit;
        private DataGridViewButtonColumn col_Delete;
        private Guna.UI2.WinForms.Guna2Button btn_Search;
        private Guna.UI2.WinForms.Guna2TextBox tb_search;
    }
}