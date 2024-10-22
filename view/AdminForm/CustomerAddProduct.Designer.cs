namespace QuanLyDoDienTu.view.AdminForm
{
    partial class CustomerAddProduct
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            dgv_Product = new Guna.UI2.WinForms.Guna2DataGridView();
            cb_Product = new Guna.UI2.WinForms.Guna2ComboBox();
            label1 = new Label();
            nud = new Guna.UI2.WinForms.Guna2NumericUpDown();
            label2 = new Label();
            btn_add = new Guna.UI2.WinForms.Guna2Button();
            btn_Save = new Guna.UI2.WinForms.Guna2Button();
            btn_Cancel = new Guna.UI2.WinForms.Guna2Button();
            btn_create = new Guna.UI2.WinForms.Guna2Button();
            lb_ano = new Label();
            label3 = new Label();
            cb_app = new Guna.UI2.WinForms.Guna2ComboBox();
            col_Id = new DataGridViewTextBoxColumn();
            col_Name = new DataGridViewTextBoxColumn();
            col_Price = new DataGridViewTextBoxColumn();
            col_Quantity = new DataGridViewTextBoxColumn();
            col_State = new DataGridViewTextBoxColumn();
            col_delete = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)dgv_Product).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud).BeginInit();
            SuspendLayout();
            // 
            // dgv_Product
            // 
            dgv_Product.AllowUserToAddRows = false;
            dgv_Product.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            dgv_Product.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgv_Product.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgv_Product.ColumnHeadersHeight = 22;
            dgv_Product.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgv_Product.Columns.AddRange(new DataGridViewColumn[] { col_Id, col_Name, col_Price, col_Quantity, col_State, col_delete });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgv_Product.DefaultCellStyle = dataGridViewCellStyle3;
            dgv_Product.Dock = DockStyle.Right;
            dgv_Product.GridColor = Color.FromArgb(231, 229, 255);
            dgv_Product.Location = new Point(383, 0);
            dgv_Product.Name = "dgv_Product";
            dgv_Product.ReadOnly = true;
            dgv_Product.RowHeadersVisible = false;
            dgv_Product.RowHeadersWidth = 51;
            dgv_Product.RowTemplate.Height = 29;
            dgv_Product.Size = new Size(499, 453);
            dgv_Product.TabIndex = 28;
            dgv_Product.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgv_Product.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgv_Product.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgv_Product.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgv_Product.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgv_Product.ThemeStyle.BackColor = Color.White;
            dgv_Product.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dgv_Product.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgv_Product.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv_Product.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dgv_Product.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgv_Product.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgv_Product.ThemeStyle.HeaderStyle.Height = 22;
            dgv_Product.ThemeStyle.ReadOnly = true;
            dgv_Product.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgv_Product.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv_Product.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dgv_Product.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgv_Product.ThemeStyle.RowsStyle.Height = 29;
            dgv_Product.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgv_Product.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dgv_Product.CellContentClick += dgv_Product_CellContentClick;
            // 
            // cb_Product
            // 
            cb_Product.BackColor = Color.Transparent;
            cb_Product.CustomizableEdges = customizableEdges1;
            cb_Product.DrawMode = DrawMode.OwnerDrawFixed;
            cb_Product.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_Product.FocusedColor = Color.FromArgb(94, 148, 255);
            cb_Product.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cb_Product.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cb_Product.ForeColor = Color.FromArgb(68, 88, 112);
            cb_Product.ItemHeight = 30;
            cb_Product.Location = new Point(36, 128);
            cb_Product.Name = "cb_Product";
            cb_Product.ShadowDecoration.CustomizableEdges = customizableEdges2;
            cb_Product.Size = new Size(341, 36);
            cb_Product.TabIndex = 29;
            cb_Product.SelectedIndexChanged += cb_Product_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 105);
            label1.Name = "label1";
            label1.Size = new Size(111, 20);
            label1.TabIndex = 30;
            label1.Text = "Chọn sản phẩm";
            // 
            // nud
            // 
            nud.BackColor = Color.Transparent;
            nud.CustomizableEdges = customizableEdges3;
            nud.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            nud.Location = new Point(36, 208);
            nud.Name = "nud";
            nud.ShadowDecoration.CustomizableEdges = customizableEdges4;
            nud.Size = new Size(341, 36);
            nud.TabIndex = 31;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(36, 185);
            label2.Name = "label2";
            label2.Size = new Size(105, 20);
            label2.TabIndex = 32;
            label2.Text = "Chọn số lượng";
            // 
            // btn_add
            // 
            btn_add.BorderRadius = 15;
            btn_add.CustomizableEdges = customizableEdges5;
            btn_add.DisabledState.BorderColor = Color.DarkGray;
            btn_add.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_add.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_add.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_add.FillColor = Color.FromArgb(128, 128, 255);
            btn_add.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btn_add.ForeColor = Color.White;
            btn_add.Location = new Point(134, 289);
            btn_add.Name = "btn_add";
            btn_add.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btn_add.Size = new Size(159, 35);
            btn_add.TabIndex = 33;
            btn_add.Text = "Thêm";
            btn_add.Click += btn_add_Click;
            // 
            // btn_Save
            // 
            btn_Save.BorderRadius = 25;
            btn_Save.CustomizableEdges = customizableEdges7;
            btn_Save.DisabledState.BorderColor = Color.DarkGray;
            btn_Save.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_Save.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_Save.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_Save.FillColor = Color.FromArgb(0, 192, 0);
            btn_Save.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btn_Save.ForeColor = Color.White;
            btn_Save.Location = new Point(216, 351);
            btn_Save.Name = "btn_Save";
            btn_Save.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btn_Save.Size = new Size(124, 48);
            btn_Save.TabIndex = 34;
            btn_Save.Text = "Lưu";
            btn_Save.Click += btn_Save_Click;
            // 
            // btn_Cancel
            // 
            btn_Cancel.BorderColor = Color.Red;
            btn_Cancel.BorderRadius = 25;
            btn_Cancel.BorderThickness = 1;
            btn_Cancel.CustomizableEdges = customizableEdges9;
            btn_Cancel.DisabledState.BorderColor = Color.DarkGray;
            btn_Cancel.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_Cancel.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_Cancel.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_Cancel.FillColor = Color.White;
            btn_Cancel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btn_Cancel.ForeColor = Color.Black;
            btn_Cancel.Location = new Point(86, 351);
            btn_Cancel.Name = "btn_Cancel";
            btn_Cancel.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btn_Cancel.Size = new Size(124, 48);
            btn_Cancel.TabIndex = 35;
            btn_Cancel.Text = "Hủy";
            // 
            // btn_create
            // 
            btn_create.BorderRadius = 25;
            btn_create.CustomizableEdges = customizableEdges11;
            btn_create.DisabledState.BorderColor = Color.DarkGray;
            btn_create.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_create.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_create.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_create.FillColor = Color.FromArgb(128, 128, 255);
            btn_create.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btn_create.ForeColor = Color.White;
            btn_create.Location = new Point(4, 250);
            btn_create.Name = "btn_create";
            btn_create.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btn_create.Size = new Size(124, 48);
            btn_create.TabIndex = 36;
            btn_create.Text = "Tạo đơn hàng";
            btn_create.Visible = false;
            btn_create.Click += btn_create_Click;
            // 
            // lb_ano
            // 
            lb_ano.AutoSize = true;
            lb_ano.Location = new Point(86, 7);
            lb_ano.Name = "lb_ano";
            lb_ano.Size = new Size(50, 20);
            lb_ano.TabIndex = 37;
            lb_ano.Text = "label3";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(36, 40);
            label3.Name = "label3";
            label3.Size = new Size(111, 20);
            label3.TabIndex = 39;
            label3.Text = "Chọn ứng dụng";
            // 
            // cb_app
            // 
            cb_app.BackColor = Color.Transparent;
            cb_app.CustomizableEdges = customizableEdges13;
            cb_app.DrawMode = DrawMode.OwnerDrawFixed;
            cb_app.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_app.FocusedColor = Color.FromArgb(94, 148, 255);
            cb_app.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cb_app.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cb_app.ForeColor = Color.FromArgb(68, 88, 112);
            cb_app.ItemHeight = 30;
            cb_app.Location = new Point(36, 63);
            cb_app.Name = "cb_app";
            cb_app.ShadowDecoration.CustomizableEdges = customizableEdges14;
            cb_app.Size = new Size(341, 36);
            cb_app.TabIndex = 38;
            cb_app.SelectedIndexChanged += cb_app_SelectedIndexChanged;
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
            col_Name.HeaderText = "Tên";
            col_Name.MinimumWidth = 6;
            col_Name.Name = "col_Name";
            col_Name.ReadOnly = true;
            // 
            // col_Price
            // 
            col_Price.FillWeight = 83.728035F;
            col_Price.HeaderText = "Trị giá";
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
            col_State.HeaderText = "Tình trạng";
            col_State.MinimumWidth = 6;
            col_State.Name = "col_State";
            col_State.ReadOnly = true;
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
            // CustomerAddProduct
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(882, 453);
            Controls.Add(label3);
            Controls.Add(cb_app);
            Controls.Add(lb_ano);
            Controls.Add(btn_create);
            Controls.Add(btn_Cancel);
            Controls.Add(btn_Save);
            Controls.Add(btn_add);
            Controls.Add(label2);
            Controls.Add(nud);
            Controls.Add(label1);
            Controls.Add(cb_Product);
            Controls.Add(dgv_Product);
            Name = "CustomerAddProduct";
            Text = "CustomerAddProduct";
            Load += CustomerAddProduct_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_Product).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView dgv_Product;
        private Guna.UI2.WinForms.Guna2ComboBox cb_Product;
        private Label label1;
        private Guna.UI2.WinForms.Guna2NumericUpDown nud;
        private Label label2;
        private Guna.UI2.WinForms.Guna2Button btn_add;
        private Guna.UI2.WinForms.Guna2Button btn_Save;
        private Guna.UI2.WinForms.Guna2Button btn_Cancel;
        private Guna.UI2.WinForms.Guna2Button btn_create;
        private Label lb_ano;
        private Label label3;
        private Guna.UI2.WinForms.Guna2ComboBox cb_app;
        private DataGridViewTextBoxColumn col_Id;
        private DataGridViewTextBoxColumn col_Name;
        private DataGridViewTextBoxColumn col_Price;
        private DataGridViewTextBoxColumn col_Quantity;
        private DataGridViewTextBoxColumn col_State;
        private DataGridViewButtonColumn col_delete;
    }
}