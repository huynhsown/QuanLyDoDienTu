namespace QuanLyDoDienTu.view.ClientForm
{
    partial class LichSuMuaHang
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvOrderHistory;
        private DataGridView dgvOrderDetails;
        private Button btnXemChiTiet;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            dgvOrderHistory = new DataGridView();
            dgvOrderDetails = new DataGridView();
            btnXemChiTiet = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvOrderHistory).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvOrderDetails).BeginInit();
            SuspendLayout();
            // 
            // dgvOrderHistory
            // 
            dgvOrderHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrderHistory.ColumnHeadersHeight = 29;
            dgvOrderHistory.Location = new Point(20, 20);
            dgvOrderHistory.Name = "dgvOrderHistory";
            dgvOrderHistory.RowHeadersWidth = 51;
            dgvOrderHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrderHistory.Size = new Size(740, 200);
            dgvOrderHistory.TabIndex = 0;
            // 
            // dgvOrderDetails
            // 
            dgvOrderDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrderDetails.ColumnHeadersHeight = 29;
            dgvOrderDetails.Location = new Point(20, 280);
            dgvOrderDetails.Name = "dgvOrderDetails";
            dgvOrderDetails.RowHeadersWidth = 51;
            dgvOrderDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrderDetails.Size = new Size(740, 200);
            dgvOrderDetails.TabIndex = 2;
            // 
            // btnXemChiTiet
            // 
            btnXemChiTiet.Location = new Point(20, 230);
            btnXemChiTiet.Name = "btnXemChiTiet";
            btnXemChiTiet.Size = new Size(120, 40);
            btnXemChiTiet.TabIndex = 1;
            btnXemChiTiet.Text = "Xem Chi Tiết";
            btnXemChiTiet.Click += btnXemChiTiet_Click;
            // 
            // LichSuMuaHang
            // 
            BackColor = Color.White;
            ClientSize = new Size(800, 500);
            ControlBox = false;
            Controls.Add(dgvOrderHistory);
            Controls.Add(btnXemChiTiet);
            Controls.Add(dgvOrderDetails);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LichSuMuaHang";
            Text = "Lịch Sử Mua Hàng";
            Load += LichSuMuaHang_Load;
            ((System.ComponentModel.ISupportInitialize)dgvOrderHistory).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvOrderDetails).EndInit();
            ResumeLayout(false);
        }

        #endregion
    }
}
