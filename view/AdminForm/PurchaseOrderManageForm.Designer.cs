namespace QuanLyDoDienTu.view.AdminForm
{
    partial class PurchaseOrderManageForm
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
            dgv_listPurchaseOrder = new Guna.UI2.WinForms.Guna2DataGridView();
            col_Id = new DataGridViewTextBoxColumn();
            col_Date = new DataGridViewTextBoxColumn();
            col_Value = new DataGridViewTextBoxColumn();
            col_Quantity = new DataGridViewTextBoxColumn();
            col_Price = new DataGridViewTextBoxColumn();
            col_NameProduct = new DataGridViewTextBoxColumn();
            col_NameManufacturer = new DataGridViewTextBoxColumn();
            col_Edit = new DataGridViewButtonColumn();
            col_delete = new DataGridViewButtonColumn();
            btn_addStaff = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)dgv_listPurchaseOrder).BeginInit();
            SuspendLayout();
            // 
            // dgv_listPurchaseOrder
            // 
            dgv_listPurchaseOrder.AllowUserToAddRows = false;
            dgv_listPurchaseOrder.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            dgv_listPurchaseOrder.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgv_listPurchaseOrder.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgv_listPurchaseOrder.ColumnHeadersHeight = 22;
            dgv_listPurchaseOrder.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgv_listPurchaseOrder.Columns.AddRange(new DataGridViewColumn[] { col_Id, col_Date, col_Value, col_Quantity, col_Price, col_NameProduct, col_NameManufacturer, col_Edit, col_delete });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgv_listPurchaseOrder.DefaultCellStyle = dataGridViewCellStyle3;
            dgv_listPurchaseOrder.Dock = DockStyle.Top;
            dgv_listPurchaseOrder.GridColor = Color.FromArgb(231, 229, 255);
            dgv_listPurchaseOrder.Location = new Point(0, 0);
            dgv_listPurchaseOrder.Name = "dgv_listPurchaseOrder";
            dgv_listPurchaseOrder.ReadOnly = true;
            dgv_listPurchaseOrder.RowHeadersVisible = false;
            dgv_listPurchaseOrder.RowHeadersWidth = 51;
            dgv_listPurchaseOrder.RowTemplate.Height = 29;
            dgv_listPurchaseOrder.Size = new Size(1166, 467);
            dgv_listPurchaseOrder.TabIndex = 26;
            dgv_listPurchaseOrder.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgv_listPurchaseOrder.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgv_listPurchaseOrder.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgv_listPurchaseOrder.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgv_listPurchaseOrder.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgv_listPurchaseOrder.ThemeStyle.BackColor = Color.White;
            dgv_listPurchaseOrder.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dgv_listPurchaseOrder.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgv_listPurchaseOrder.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv_listPurchaseOrder.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dgv_listPurchaseOrder.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgv_listPurchaseOrder.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgv_listPurchaseOrder.ThemeStyle.HeaderStyle.Height = 22;
            dgv_listPurchaseOrder.ThemeStyle.ReadOnly = true;
            dgv_listPurchaseOrder.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgv_listPurchaseOrder.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv_listPurchaseOrder.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dgv_listPurchaseOrder.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgv_listPurchaseOrder.ThemeStyle.RowsStyle.Height = 29;
            dgv_listPurchaseOrder.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgv_listPurchaseOrder.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dgv_listPurchaseOrder.CellContentClick += dgv_listStaff_CellContentClick;
            // 
            // col_Id
            // 
            col_Id.FillWeight = 60F;
            col_Id.HeaderText = "Mã đơn ";
            col_Id.MinimumWidth = 6;
            col_Id.Name = "col_Id";
            col_Id.ReadOnly = true;
            // 
            // col_Date
            // 
            col_Date.FillWeight = 83.728035F;
            col_Date.HeaderText = "Ngày nhập";
            col_Date.MinimumWidth = 6;
            col_Date.Name = "col_Date";
            col_Date.ReadOnly = true;
            // 
            // col_Value
            // 
            col_Value.FillWeight = 83.728035F;
            col_Value.HeaderText = "Giá trị";
            col_Value.MinimumWidth = 6;
            col_Value.Name = "col_Value";
            col_Value.ReadOnly = true;
            // 
            // col_Quantity
            // 
            col_Quantity.FillWeight = 40F;
            col_Quantity.HeaderText = "Số lượng";
            col_Quantity.MinimumWidth = 6;
            col_Quantity.Name = "col_Quantity";
            col_Quantity.ReadOnly = true;
            // 
            // col_Price
            // 
            col_Price.FillWeight = 83.728035F;
            col_Price.HeaderText = "Đơn giá";
            col_Price.MinimumWidth = 6;
            col_Price.Name = "col_Price";
            col_Price.ReadOnly = true;
            // 
            // col_NameProduct
            // 
            col_NameProduct.FillWeight = 83.728035F;
            col_NameProduct.HeaderText = "Tên sản phẩm";
            col_NameProduct.MinimumWidth = 6;
            col_NameProduct.Name = "col_NameProduct";
            col_NameProduct.ReadOnly = true;
            // 
            // col_NameManufacturer
            // 
            col_NameManufacturer.FillWeight = 83.728035F;
            col_NameManufacturer.HeaderText = "Tên nhà sản xuất";
            col_NameManufacturer.MinimumWidth = 6;
            col_NameManufacturer.Name = "col_NameManufacturer";
            col_NameManufacturer.ReadOnly = true;
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
            btn_addStaff.Location = new Point(63, 517);
            btn_addStaff.Name = "btn_addStaff";
            btn_addStaff.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btn_addStaff.Size = new Size(171, 44);
            btn_addStaff.TabIndex = 25;
            btn_addStaff.Text = "Thêm đơn nhập hàng";
            btn_addStaff.Click += btn_addStaff_Click;
            // 
            // PurchaseOrder
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1166, 712);
            Controls.Add(dgv_listPurchaseOrder);
            Controls.Add(btn_addStaff);
            FormBorderStyle = FormBorderStyle.None;
            Name = "PurchaseOrder";
            Text = "PurchaseOrder";
            Load += PurchaseOrder_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_listPurchaseOrder).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView dgv_listPurchaseOrder;
        private DataGridViewTextBoxColumn col_Id;
        private DataGridViewTextBoxColumn col_Date;
        private DataGridViewTextBoxColumn col_Value;
        private DataGridViewTextBoxColumn col_Quantity;
        private DataGridViewTextBoxColumn col_Price;
        private DataGridViewTextBoxColumn col_NameProduct;
        private DataGridViewTextBoxColumn col_NameManufacturer;
        private DataGridViewButtonColumn col_Edit;
        private DataGridViewButtonColumn col_delete;
        private Guna.UI2.WinForms.Guna2Button btn_addStaff;
    }
}