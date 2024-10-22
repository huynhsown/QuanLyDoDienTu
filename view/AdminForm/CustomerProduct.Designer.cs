namespace QuanLyDoDienTu.view.AdminForm
{
    partial class CustomerProduct
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
            dgv_listOrder = new Guna.UI2.WinForms.Guna2DataGridView();
            col_selectedPro = new DataGridViewTextBoxColumn();
            col_Id = new DataGridViewTextBoxColumn();
            col_Name = new DataGridViewTextBoxColumn();
            col_Phone = new DataGridViewTextBoxColumn();
            col_Email = new DataGridViewTextBoxColumn();
            col_Edit = new DataGridViewButtonColumn();
            col_Delete = new DataGridViewButtonColumn();
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
            dgv_listOrder.Columns.AddRange(new DataGridViewColumn[] { col_selectedPro, col_Id, col_Name, col_Phone, col_Email, col_Edit, col_Delete });
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
            dgv_listOrder.Size = new Size(800, 363);
            dgv_listOrder.TabIndex = 27;
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
            // col_selectedPro
            // 
            col_selectedPro.HeaderText = "SPDC";
            col_selectedPro.MinimumWidth = 6;
            col_selectedPro.Name = "col_selectedPro";
            col_selectedPro.ReadOnly = true;
            col_selectedPro.Visible = false;
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
            // col_Phone
            // 
            col_Phone.FillWeight = 83.728035F;
            col_Phone.HeaderText = "Giá";
            col_Phone.MinimumWidth = 6;
            col_Phone.Name = "col_Phone";
            col_Phone.ReadOnly = true;
            // 
            // col_Email
            // 
            col_Email.FillWeight = 83.728035F;
            col_Email.HeaderText = "Số lượng";
            col_Email.MinimumWidth = 6;
            col_Email.Name = "col_Email";
            col_Email.ReadOnly = true;
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
            // col_Delete
            // 
            col_Delete.FillWeight = 30F;
            col_Delete.HeaderText = "Xóa";
            col_Delete.MinimumWidth = 3;
            col_Delete.Name = "col_Delete";
            col_Delete.ReadOnly = true;
            col_Delete.Text = "Xóa";
            col_Delete.UseColumnTextForButtonValue = true;
            // 
            // CustomerProduct
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 450);
            Controls.Add(dgv_listOrder);
            Name = "CustomerProduct";
            Text = "CustomerProduct";
            Load += CustomerProduct_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_listOrder).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView dgv_listOrder;
        private DataGridViewTextBoxColumn col_selectedPro;
        private DataGridViewTextBoxColumn col_Id;
        private DataGridViewTextBoxColumn col_Name;
        private DataGridViewTextBoxColumn col_Phone;
        private DataGridViewTextBoxColumn col_Email;
        private DataGridViewButtonColumn col_Edit;
        private DataGridViewButtonColumn col_Delete;
    }
}