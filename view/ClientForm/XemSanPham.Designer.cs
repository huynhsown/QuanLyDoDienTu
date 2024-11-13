namespace QuanLyDoDienTu.view.ClientForm
{
    partial class XemSanPham
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtTimKiem;
        private ComboBox cbTinhTrang;
        private TextBox txtGiaTu;
        private TextBox txtGiaDen;
        private Button btnTimKiem;
        private DataGridView dgvSanPham;
        private Button btnThemVaoGioHang;

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
            txtTimKiem = new TextBox();
            cbTinhTrang = new ComboBox();
            txtGiaTu = new TextBox();
            txtGiaDen = new TextBox();
            btnTimKiem = new Button();
            dgvSanPham = new DataGridView();
            btnThemVaoGioHang = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvSanPham).BeginInit();
            SuspendLayout();
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(21, 25);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Tìm kiếm sản phẩm theo tên";
            txtTimKiem.Size = new Size(300, 27);
            txtTimKiem.TabIndex = 0;
            // 
            // cbTinhTrang
            // 
            cbTinhTrang.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTinhTrang.FormattingEnabled = true;
            cbTinhTrang.Items.AddRange(new object[] { "Tất cả", "Có sẵn", "Đã hết hàng" });
            cbTinhTrang.Location = new Point(340, 25);
            cbTinhTrang.Name = "cbTinhTrang";
            cbTinhTrang.Size = new Size(150, 28);
            cbTinhTrang.TabIndex = 1;
            // 
            // txtGiaTu
            // 
            txtGiaTu.Location = new Point(510, 25);
            txtGiaTu.Name = "txtGiaTu";
            txtGiaTu.PlaceholderText = "Giá từ";
            txtGiaTu.Size = new Size(100, 27);
            txtGiaTu.TabIndex = 2;
            // 
            // txtGiaDen
            // 
            txtGiaDen.Location = new Point(630, 25);
            txtGiaDen.Name = "txtGiaDen";
            txtGiaDen.PlaceholderText = "Giá đến";
            txtGiaDen.Size = new Size(100, 27);
            txtGiaDen.TabIndex = 3;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(750, 25);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(100, 27);
            btnTimKiem.TabIndex = 4;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += BtnTimKiem_Click;
            // 
            // dgvSanPham
            // 
            dgvSanPham.AllowUserToAddRows = false;
            dgvSanPham.AllowUserToDeleteRows = false;
            dgvSanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSanPham.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSanPham.Location = new Point(20, 100);
            dgvSanPham.Name = "dgvSanPham";
            dgvSanPham.ReadOnly = true;
            dgvSanPham.RowHeadersWidth = 51;
            dgvSanPham.RowTemplate.Height = 24;
            dgvSanPham.Size = new Size(830, 343);
            dgvSanPham.TabIndex = 5;
            // 
            // btnThemVaoGioHang
            // 
            btnThemVaoGioHang.Location = new Point(694, 464);
            btnThemVaoGioHang.Name = "btnThemVaoGioHang";
            btnThemVaoGioHang.Size = new Size(156, 45);
            btnThemVaoGioHang.TabIndex = 6;
            btnThemVaoGioHang.Text = "Thêm vào giỏ hàng";
            btnThemVaoGioHang.UseVisualStyleBackColor = true;
            btnThemVaoGioHang.Click += btnThemVaoGioHang_Click;
            // 
            // XemSanPham
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(882, 542);
            ControlBox = false;
            Controls.Add(dgvSanPham);
            Controls.Add(btnTimKiem);
            Controls.Add(txtGiaDen);
            Controls.Add(txtGiaTu);
            Controls.Add(cbTinhTrang);
            Controls.Add(txtTimKiem);
            Controls.Add(btnThemVaoGioHang);
            FormBorderStyle = FormBorderStyle.None;
            Name = "XemSanPham";
            Text = "Xem và tìm kiếm sản phẩm";
            Load += XemSanPham_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSanPham).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
