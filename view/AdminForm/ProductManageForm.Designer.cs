namespace QuanLyDoDienTu.view.AdminForm
{
    partial class ProductManageForm
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            dgv_listProduct = new Guna.UI2.WinForms.Guna2DataGridView();
            col_Id = new DataGridViewTextBoxColumn();
            col_Name = new DataGridViewTextBoxColumn();
            col_Price = new DataGridViewTextBoxColumn();
            col_Quantity = new DataGridViewTextBoxColumn();
            col_State = new DataGridViewTextBoxColumn();
            col_Edit = new DataGridViewButtonColumn();
            col_Delete = new DataGridViewButtonColumn();
            btn_add = new Guna.UI2.WinForms.Guna2Button();
            tb_search = new Guna.UI2.WinForms.Guna2TextBox();
            btn_Search = new Guna.UI2.WinForms.Guna2Button();
            cbb_search = new Guna.UI2.WinForms.Guna2ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgv_listProduct).BeginInit();
            SuspendLayout();
            // 
            // dgv_listProduct
            // 
            dgv_listProduct.AllowUserToAddRows = false;
            dgv_listProduct.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            dgv_listProduct.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgv_listProduct.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgv_listProduct.ColumnHeadersHeight = 22;
            dgv_listProduct.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgv_listProduct.Columns.AddRange(new DataGridViewColumn[] { col_Id, col_Name, col_Price, col_Quantity, col_State, col_Edit, col_Delete });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgv_listProduct.DefaultCellStyle = dataGridViewCellStyle3;
            dgv_listProduct.Dock = DockStyle.Top;
            dgv_listProduct.GridColor = Color.FromArgb(231, 229, 255);
            dgv_listProduct.Location = new Point(0, 0);
            dgv_listProduct.Name = "dgv_listProduct";
            dgv_listProduct.ReadOnly = true;
            dgv_listProduct.RowHeadersVisible = false;
            dgv_listProduct.RowHeadersWidth = 51;
            dgv_listProduct.RowTemplate.Height = 29;
            dgv_listProduct.Size = new Size(959, 525);
            dgv_listProduct.TabIndex = 26;
            dgv_listProduct.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgv_listProduct.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgv_listProduct.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgv_listProduct.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgv_listProduct.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgv_listProduct.ThemeStyle.BackColor = Color.White;
            dgv_listProduct.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dgv_listProduct.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgv_listProduct.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv_listProduct.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dgv_listProduct.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgv_listProduct.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgv_listProduct.ThemeStyle.HeaderStyle.Height = 22;
            dgv_listProduct.ThemeStyle.ReadOnly = true;
            dgv_listProduct.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgv_listProduct.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv_listProduct.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dgv_listProduct.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgv_listProduct.ThemeStyle.RowsStyle.Height = 29;
            dgv_listProduct.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgv_listProduct.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dgv_listProduct.CellContentClick += dgv_listProduct_CellContentClick;
            // 
            // col_Id
            // 
            col_Id.FillWeight = 60F;
            col_Id.HeaderText = "Mã sản phẩm";
            col_Id.MinimumWidth = 6;
            col_Id.Name = "col_Id";
            col_Id.ReadOnly = true;
            // 
            // col_Name
            // 
            col_Name.FillWeight = 83.728035F;
            col_Name.HeaderText = "Tên sản phẩm";
            col_Name.MinimumWidth = 6;
            col_Name.Name = "col_Name";
            col_Name.ReadOnly = true;
            // 
            // col_Price
            // 
            col_Price.FillWeight = 83.728035F;
            col_Price.HeaderText = "Giá";
            col_Price.MinimumWidth = 6;
            col_Price.Name = "col_Price";
            col_Price.ReadOnly = true;
            // 
            // col_Quantity
            // 
            col_Quantity.FillWeight = 83.728035F;
            col_Quantity.HeaderText = "Số lượng";
            col_Quantity.MinimumWidth = 6;
            col_Quantity.Name = "col_Quantity";
            col_Quantity.ReadOnly = true;
            // 
            // col_State
            // 
            col_State.FillWeight = 83.728035F;
            col_State.HeaderText = "Tình trạng";
            col_State.MinimumWidth = 6;
            col_State.Name = "col_State";
            col_State.ReadOnly = true;
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
            btn_add.Location = new Point(733, 558);
            btn_add.Name = "btn_add";
            btn_add.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btn_add.Size = new Size(204, 47);
            btn_add.TabIndex = 27;
            btn_add.Text = "Thêm sản phẩm";
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
            tb_search.Location = new Point(385, 560);
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
            btn_Search.Location = new Point(29, 558);
            btn_Search.Name = "btn_Search";
            btn_Search.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btn_Search.Size = new Size(159, 47);
            btn_Search.TabIndex = 38;
            btn_Search.Text = "Tìm kiếm";
            btn_Search.Click += btn_Search_Click;
            // 
            // cbb_search
            // 
            cbb_search.BackColor = Color.Transparent;
            cbb_search.CustomizableEdges = customizableEdges7;
            cbb_search.DrawMode = DrawMode.OwnerDrawFixed;
            cbb_search.DropDownStyle = ComboBoxStyle.DropDownList;
            cbb_search.FocusedColor = Color.FromArgb(94, 148, 255);
            cbb_search.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cbb_search.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cbb_search.ForeColor = Color.FromArgb(68, 88, 112);
            cbb_search.ItemHeight = 30;
            cbb_search.Location = new Point(194, 560);
            cbb_search.Name = "cbb_search";
            cbb_search.ShadowDecoration.CustomizableEdges = customizableEdges8;
            cbb_search.Size = new Size(175, 36);
            cbb_search.TabIndex = 40;
            // 
            // ProductManageForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(959, 661);
            Controls.Add(cbb_search);
            Controls.Add(tb_search);
            Controls.Add(btn_Search);
            Controls.Add(btn_add);
            Controls.Add(dgv_listProduct);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ProductManageForm";
            Text = "ProductManageForm";
            Load += ProductManageForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_listProduct).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView dgv_listProduct;
        private Guna.UI2.WinForms.Guna2Button btn_add;
        private DataGridViewTextBoxColumn col_Id;
        private DataGridViewTextBoxColumn col_Name;
        private DataGridViewTextBoxColumn col_Price;
        private DataGridViewTextBoxColumn col_Quantity;
        private DataGridViewTextBoxColumn col_State;
        private DataGridViewButtonColumn col_Edit;
        private DataGridViewButtonColumn col_Delete;
        private Guna.UI2.WinForms.Guna2TextBox tb_search;
        private Guna.UI2.WinForms.Guna2Button btn_Search;
        private Guna.UI2.WinForms.Guna2ComboBox cbb_search;
    }
}