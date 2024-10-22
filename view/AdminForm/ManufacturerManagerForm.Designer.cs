namespace QuanLyDoDienTu.view.AdminForm
{
    partial class ManufacturerManagerForm
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
            dgv_listManufacturer = new Guna.UI2.WinForms.Guna2DataGridView();
            col_Id = new DataGridViewTextBoxColumn();
            col_Name = new DataGridViewTextBoxColumn();
            col_Phone = new DataGridViewTextBoxColumn();
            col_Email = new DataGridViewTextBoxColumn();
            col_Edit = new DataGridViewButtonColumn();
            col_Delete = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)dgv_listManufacturer).BeginInit();
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
            btn_add.Location = new Point(49, 386);
            btn_add.Name = "btn_add";
            btn_add.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btn_add.Size = new Size(159, 35);
            btn_add.TabIndex = 29;
            btn_add.Text = "Thêm nhà sản xuất";
            btn_add.Click += btn_add_Click;
            // 
            // dgv_listManufacturer
            // 
            dgv_listManufacturer.AllowUserToAddRows = false;
            dgv_listManufacturer.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            dgv_listManufacturer.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgv_listManufacturer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgv_listManufacturer.ColumnHeadersHeight = 22;
            dgv_listManufacturer.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgv_listManufacturer.Columns.AddRange(new DataGridViewColumn[] { col_Id, col_Name, col_Phone, col_Email, col_Edit, col_Delete });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgv_listManufacturer.DefaultCellStyle = dataGridViewCellStyle3;
            dgv_listManufacturer.Dock = DockStyle.Top;
            dgv_listManufacturer.GridColor = Color.FromArgb(231, 229, 255);
            dgv_listManufacturer.Location = new Point(0, 0);
            dgv_listManufacturer.Name = "dgv_listManufacturer";
            dgv_listManufacturer.ReadOnly = true;
            dgv_listManufacturer.RowHeadersVisible = false;
            dgv_listManufacturer.RowHeadersWidth = 51;
            dgv_listManufacturer.RowTemplate.Height = 29;
            dgv_listManufacturer.Size = new Size(818, 348);
            dgv_listManufacturer.TabIndex = 28;
            dgv_listManufacturer.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgv_listManufacturer.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgv_listManufacturer.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgv_listManufacturer.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgv_listManufacturer.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgv_listManufacturer.ThemeStyle.BackColor = Color.White;
            dgv_listManufacturer.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dgv_listManufacturer.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgv_listManufacturer.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv_listManufacturer.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dgv_listManufacturer.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgv_listManufacturer.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgv_listManufacturer.ThemeStyle.HeaderStyle.Height = 22;
            dgv_listManufacturer.ThemeStyle.ReadOnly = true;
            dgv_listManufacturer.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgv_listManufacturer.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv_listManufacturer.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dgv_listManufacturer.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgv_listManufacturer.ThemeStyle.RowsStyle.Height = 29;
            dgv_listManufacturer.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgv_listManufacturer.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dgv_listManufacturer.CellContentClick += dgv_listManufacturer_CellContentClick;
            // 
            // col_Id
            // 
            col_Id.FillWeight = 60F;
            col_Id.HeaderText = "Mã nhà sản xuất";
            col_Id.MinimumWidth = 6;
            col_Id.Name = "col_Id";
            col_Id.ReadOnly = true;
            // 
            // col_Name
            // 
            col_Name.FillWeight = 83.728035F;
            col_Name.HeaderText = "Tên nhà sản xuất";
            col_Name.MinimumWidth = 6;
            col_Name.Name = "col_Name";
            col_Name.ReadOnly = true;
            // 
            // col_Phone
            // 
            col_Phone.FillWeight = 83.728035F;
            col_Phone.HeaderText = "Số điện thoại";
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
            // ManufacturerManagerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(818, 465);
            Controls.Add(btn_add);
            Controls.Add(dgv_listManufacturer);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ManufacturerManagerForm";
            Text = "ManufacturerManagerForm";
            Load += ManufacturerManagerForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_listManufacturer).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btn_add;
        private Guna.UI2.WinForms.Guna2DataGridView dgv_listManufacturer;
        private DataGridViewTextBoxColumn col_Id;
        private DataGridViewTextBoxColumn col_Name;
        private DataGridViewTextBoxColumn col_Phone;
        private DataGridViewTextBoxColumn col_Email;
        private DataGridViewButtonColumn col_Edit;
        private DataGridViewButtonColumn col_Delete;
    }
}