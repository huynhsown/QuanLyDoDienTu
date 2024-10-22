namespace QuanLyDoDienTu.view.AdminForm
{
    partial class CustomerHistory
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
            dgv_listOrder = new Guna.UI2.WinForms.Guna2DataGridView();
            col_Id = new DataGridViewTextBoxColumn();
            col_Name = new DataGridViewTextBoxColumn();
            col_State = new DataGridViewTextBoxColumn();
            col_Email = new DataGridViewTextBoxColumn();
            col_Address = new DataGridViewTextBoxColumn();
            col_Edit = new DataGridViewButtonColumn();
            col_delete = new DataGridViewButtonColumn();
            btn_add = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)dgv_listOrder).BeginInit();
            SuspendLayout();
            // 
            // dgv_listOrder
            // 
            dgv_listOrder.AllowUserToAddRows = false;
            dgv_listOrder.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            dgv_listOrder.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgv_listOrder.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgv_listOrder.ColumnHeadersHeight = 22;
            dgv_listOrder.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgv_listOrder.Columns.AddRange(new DataGridViewColumn[] { col_Id, col_Name, col_State, col_Email, col_Address, col_Edit, col_delete });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgv_listOrder.DefaultCellStyle = dataGridViewCellStyle3;
            dgv_listOrder.Dock = DockStyle.Top;
            dgv_listOrder.GridColor = Color.FromArgb(231, 229, 255);
            dgv_listOrder.Location = new Point(0, 0);
            dgv_listOrder.Name = "dgv_listOrder";
            dgv_listOrder.ReadOnly = true;
            dgv_listOrder.RowHeadersVisible = false;
            dgv_listOrder.RowHeadersWidth = 51;
            dgv_listOrder.RowTemplate.Height = 29;
            dgv_listOrder.Size = new Size(1182, 363);
            dgv_listOrder.TabIndex = 26;
            dgv_listOrder.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgv_listOrder.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgv_listOrder.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgv_listOrder.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgv_listOrder.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgv_listOrder.ThemeStyle.BackColor = Color.White;
            dgv_listOrder.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dgv_listOrder.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgv_listOrder.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv_listOrder.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dgv_listOrder.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgv_listOrder.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgv_listOrder.ThemeStyle.HeaderStyle.Height = 22;
            dgv_listOrder.ThemeStyle.ReadOnly = true;
            dgv_listOrder.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgv_listOrder.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv_listOrder.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dgv_listOrder.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgv_listOrder.ThemeStyle.RowsStyle.Height = 29;
            dgv_listOrder.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgv_listOrder.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dgv_listOrder.CellContentClick += dgv_listOrder_CellContentClick;
            // 
            // col_Id
            // 
            col_Id.FillWeight = 60F;
            col_Id.HeaderText = "Mã đơn ";
            col_Id.MinimumWidth = 6;
            col_Id.Name = "col_Id";
            col_Id.ReadOnly = true;
            // 
            // col_Name
            // 
            col_Name.FillWeight = 83.728035F;
            col_Name.HeaderText = "Ngày đặt";
            col_Name.MinimumWidth = 6;
            col_Name.Name = "col_Name";
            col_Name.ReadOnly = true;
            // 
            // col_State
            // 
            col_State.FillWeight = 83.728035F;
            col_State.HeaderText = "Trạng thái";
            col_State.MinimumWidth = 6;
            col_State.Name = "col_State";
            col_State.ReadOnly = true;
            // 
            // col_Email
            // 
            col_Email.FillWeight = 83.728035F;
            col_Email.HeaderText = "Trị giá";
            col_Email.MinimumWidth = 6;
            col_Email.Name = "col_Email";
            col_Email.ReadOnly = true;
            // 
            // col_Address
            // 
            col_Address.FillWeight = 83.728035F;
            col_Address.HeaderText = "Đặt qua";
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
            col_delete.HeaderText = "Hủy đơn";
            col_delete.MinimumWidth = 3;
            col_delete.Name = "col_delete";
            col_delete.ReadOnly = true;
            col_delete.Text = "Hủy";
            col_delete.UseColumnTextForButtonValue = true;
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
            btn_add.Location = new Point(60, 391);
            btn_add.Name = "btn_add";
            btn_add.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btn_add.Size = new Size(159, 35);
            btn_add.TabIndex = 27;
            btn_add.Text = "Thêm đơn hàng";
            btn_add.Click += btn_add_Click;
            // 
            // CustomerHistory
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1182, 653);
            Controls.Add(btn_add);
            Controls.Add(dgv_listOrder);
            Name = "CustomerHistory";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CustomerHistory";
            Load += CustomerHistory_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_listOrder).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView dgv_listOrder;
        private DataGridViewTextBoxColumn col_Id;
        private DataGridViewTextBoxColumn col_Name;
        private DataGridViewTextBoxColumn col_State;
        private DataGridViewTextBoxColumn col_Email;
        private DataGridViewTextBoxColumn col_Address;
        private DataGridViewButtonColumn col_Edit;
        private DataGridViewButtonColumn col_delete;
        private Guna.UI2.WinForms.Guna2Button btn_add;
    }
}