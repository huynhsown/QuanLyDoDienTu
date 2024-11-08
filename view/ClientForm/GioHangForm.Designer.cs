namespace QuanLyDoDienTu.view.ClientForm
{
    partial class GioHangForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvGioHang;
        private TextBox txtSoLuong;
        private TextBox txtTongTien;
        private ComboBox cbUngDung;
        private Button btnThayDoi;
        private Button btnTaoDonHang;
        private Button btnXoa;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dgvGioHang = new DataGridView();
            txtSoLuong = new TextBox();
            txtTongTien = new TextBox();
            cbUngDung = new ComboBox();
            btnThayDoi = new Button();
            btnTaoDonHang = new Button();
            btnXoa = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvGioHang).BeginInit();
            SuspendLayout();
            // 
            // dgvGioHang
            // 
            dgvGioHang.AllowUserToAddRows = false;
            dgvGioHang.AllowUserToDeleteRows = false;
            dgvGioHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvGioHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGioHang.Location = new Point(12, 12);
            dgvGioHang.Name = "dgvGioHang";
            dgvGioHang.ReadOnly = true;
            dgvGioHang.RowHeadersWidth = 51;
            dgvGioHang.Size = new Size(560, 300);
            dgvGioHang.TabIndex = 0;
            // 
            // txtSoLuong
            // 
            txtSoLuong.Location = new Point(12, 330);
            txtSoLuong.Name = "txtSoLuong";
            txtSoLuong.PlaceholderText = "Số lượng";
            txtSoLuong.Size = new Size(200, 27);
            txtSoLuong.TabIndex = 1;
            // 
            // txtTongTien
            // 
            txtTongTien.Location = new Point(12, 380);
            txtTongTien.Name = "txtTongTien";
            txtTongTien.PlaceholderText = "Tổng tiền";
            txtTongTien.ReadOnly = true;
            txtTongTien.Size = new Size(200, 27);
            txtTongTien.TabIndex = 2;
            // 
            // cbUngDung
            // 
            cbUngDung.DropDownStyle = ComboBoxStyle.DropDownList;
            cbUngDung.FormattingEnabled = true;
            cbUngDung.Location = new Point(12, 430);
            cbUngDung.Name = "cbUngDung";
            cbUngDung.Size = new Size(200, 28);
            cbUngDung.TabIndex = 3;
            // 
            // btnThayDoi
            // 
            btnThayDoi.Location = new Point(220, 330);
            btnThayDoi.Name = "btnThayDoi";
            btnThayDoi.Size = new Size(100, 36);
            btnThayDoi.TabIndex = 4;
            btnThayDoi.Text = "Thay đổi";
            btnThayDoi.UseVisualStyleBackColor = true;
            btnThayDoi.Click += btnThayDoi_Click;
            // 
            // btnTaoDonHang
            // 
            btnTaoDonHang.Location = new Point(12, 480);
            btnTaoDonHang.Name = "btnTaoDonHang";
            btnTaoDonHang.Size = new Size(200, 36);
            btnTaoDonHang.TabIndex = 5;
            btnTaoDonHang.Text = "Tạo Đơn Hàng";
            btnTaoDonHang.UseVisualStyleBackColor = true;
            btnTaoDonHang.Click += btnTaoDonHang_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(330, 330);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(100, 36);
            btnXoa.TabIndex = 6;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // GioHangForm
            // 
            BackColor = Color.White;
            ClientSize = new Size(600, 550);
            ControlBox = false;
            Controls.Add(btnXoa);
            Controls.Add(dgvGioHang);
            Controls.Add(txtSoLuong);
            Controls.Add(txtTongTien);
            Controls.Add(cbUngDung);
            Controls.Add(btnThayDoi);
            Controls.Add(btnTaoDonHang);
            FormBorderStyle = FormBorderStyle.None;
            Name = "GioHangForm";
            Text = "Giỏ Hàng";
            Load += GioHangForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvGioHang).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
