namespace QuanLyDoDienTu.view.ClientForm
{
    partial class ThanhToanForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvThanhToan;
        private ComboBox cbPhuongThucThanhToan;
        private Label lblPhuongThucThanhToan;
        private GroupBox gbChuyenKhoan;
        private TextBox txtSoTaiKhoan;
        private TextBox txtTenTaiKhoan;
        private TextBox txtNganHang;
        private TextBox txtNoiDungChuyenKhoan;
        private Label lblSoTaiKhoan;
        private Label lblTenTaiKhoan;
        private Label lblNganHang;
        private Label lblNoiDungChuyenKhoan;
        private Button btnThanhToan;

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
            dgvThanhToan = new DataGridView();
            cbPhuongThucThanhToan = new ComboBox();
            lblPhuongThucThanhToan = new Label();
            gbChuyenKhoan = new GroupBox();
            txtSoTaiKhoan = new TextBox();
            txtTenTaiKhoan = new TextBox();
            txtNganHang = new TextBox();
            txtNoiDungChuyenKhoan = new TextBox();
            lblSoTaiKhoan = new Label();
            lblTenTaiKhoan = new Label();
            lblNganHang = new Label();
            lblNoiDungChuyenKhoan = new Label();
            btnThanhToan = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvThanhToan).BeginInit();
            gbChuyenKhoan.SuspendLayout();
            SuspendLayout();
            // 
            // dgvThanhToan
            // 
            dgvThanhToan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvThanhToan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvThanhToan.Location = new Point(12, 12);
            dgvThanhToan.Name = "dgvThanhToan";
            dgvThanhToan.RowHeadersWidth = 51;
            dgvThanhToan.Size = new Size(600, 200);
            dgvThanhToan.TabIndex = 0;
            // 
            // cbPhuongThucThanhToan
            // 
            cbPhuongThucThanhToan.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPhuongThucThanhToan.Items.AddRange(new object[] { "Trả tiền mặt", "Chuyển khoản" });
            cbPhuongThucThanhToan.Location = new Point(200, 230);
            cbPhuongThucThanhToan.Name = "cbPhuongThucThanhToan";
            cbPhuongThucThanhToan.Size = new Size(200, 28);
            cbPhuongThucThanhToan.TabIndex = 1;
            cbPhuongThucThanhToan.SelectedIndexChanged += cbPhuongThucThanhToan_SelectedIndexChanged;
            // 
            // lblPhuongThucThanhToan
            // 
            lblPhuongThucThanhToan.AutoSize = true;
            lblPhuongThucThanhToan.Location = new Point(12, 230);
            lblPhuongThucThanhToan.Name = "lblPhuongThucThanhToan";
            lblPhuongThucThanhToan.Size = new Size(168, 20);
            lblPhuongThucThanhToan.TabIndex = 1;
            lblPhuongThucThanhToan.Text = "Phương thức thanh toán";
            // 
            // gbChuyenKhoan
            // 
            gbChuyenKhoan.Controls.Add(txtSoTaiKhoan);
            gbChuyenKhoan.Controls.Add(txtTenTaiKhoan);
            gbChuyenKhoan.Controls.Add(txtNganHang);
            gbChuyenKhoan.Controls.Add(txtNoiDungChuyenKhoan);
            gbChuyenKhoan.Controls.Add(lblSoTaiKhoan);
            gbChuyenKhoan.Controls.Add(lblTenTaiKhoan);
            gbChuyenKhoan.Controls.Add(lblNganHang);
            gbChuyenKhoan.Controls.Add(lblNoiDungChuyenKhoan);
            gbChuyenKhoan.Location = new Point(12, 270);
            gbChuyenKhoan.Name = "gbChuyenKhoan";
            gbChuyenKhoan.Size = new Size(600, 200);
            gbChuyenKhoan.TabIndex = 2;
            gbChuyenKhoan.TabStop = false;
            gbChuyenKhoan.Text = "Thông tin chuyển khoản";
            gbChuyenKhoan.Visible = false;
            // 
            // txtSoTaiKhoan
            // 
            txtSoTaiKhoan.Location = new Point(189, 30);
            txtSoTaiKhoan.Name = "txtSoTaiKhoan";
            txtSoTaiKhoan.Size = new Size(200, 27);
            txtSoTaiKhoan.TabIndex = 3;
            txtSoTaiKhoan.Text = "0974185296";
            // 
            // txtTenTaiKhoan
            // 
            txtTenTaiKhoan.Location = new Point(189, 70);
            txtTenTaiKhoan.Name = "txtTenTaiKhoan";
            txtTenTaiKhoan.Size = new Size(200, 27);
            txtTenTaiKhoan.TabIndex = 4;
            txtTenTaiKhoan.Text = "No One";
            // 
            // txtNganHang
            // 
            txtNganHang.Location = new Point(189, 110);
            txtNganHang.Name = "txtNganHang";
            txtNganHang.Size = new Size(200, 27);
            txtNganHang.TabIndex = 5;
            txtNganHang.Text = "Agribank";
            // 
            // txtNoiDungChuyenKhoan
            // 
            txtNoiDungChuyenKhoan.Location = new Point(187, 150);
            txtNoiDungChuyenKhoan.Name = "txtNoiDungChuyenKhoan";
            txtNoiDungChuyenKhoan.ReadOnly = true;
            txtNoiDungChuyenKhoan.Size = new Size(400, 27);
            txtNoiDungChuyenKhoan.TabIndex = 6;
            // 
            // lblSoTaiKhoan
            // 
            lblSoTaiKhoan.AutoSize = true;
            lblSoTaiKhoan.Location = new Point(6, 30);
            lblSoTaiKhoan.Name = "lblSoTaiKhoan";
            lblSoTaiKhoan.Size = new Size(91, 20);
            lblSoTaiKhoan.TabIndex = 7;
            lblSoTaiKhoan.Text = "Số tài khoản";
            // 
            // lblTenTaiKhoan
            // 
            lblTenTaiKhoan.AutoSize = true;
            lblTenTaiKhoan.Location = new Point(6, 70);
            lblTenTaiKhoan.Name = "lblTenTaiKhoan";
            lblTenTaiKhoan.Size = new Size(97, 20);
            lblTenTaiKhoan.TabIndex = 8;
            lblTenTaiKhoan.Text = "Tên tài khoản";
            // 
            // lblNganHang
            // 
            lblNganHang.AutoSize = true;
            lblNganHang.Location = new Point(6, 110);
            lblNganHang.Name = "lblNganHang";
            lblNganHang.Size = new Size(82, 20);
            lblNganHang.TabIndex = 9;
            lblNganHang.Text = "Ngân hàng";
            // 
            // lblNoiDungChuyenKhoan
            // 
            lblNoiDungChuyenKhoan.AutoSize = true;
            lblNoiDungChuyenKhoan.Location = new Point(6, 150);
            lblNoiDungChuyenKhoan.Name = "lblNoiDungChuyenKhoan";
            lblNoiDungChuyenKhoan.Size = new Size(165, 20);
            lblNoiDungChuyenKhoan.TabIndex = 10;
            lblNoiDungChuyenKhoan.Text = "Nội dung chuyển khoản";
            // 
            // btnThanhToan
            // 
            btnThanhToan.Location = new Point(420, 230);
            btnThanhToan.Name = "btnThanhToan";
            btnThanhToan.Size = new Size(120, 30);
            btnThanhToan.TabIndex = 7;
            btnThanhToan.Text = "Thanh Toán";
            btnThanhToan.UseVisualStyleBackColor = true;
            btnThanhToan.Click += btnThanhToan_Click;
            // 
            // ThanhToanForm
            // 
            BackColor = Color.White;
            ClientSize = new Size(650, 500);
            ControlBox = false;
            Controls.Add(dgvThanhToan);
            Controls.Add(lblPhuongThucThanhToan);
            Controls.Add(cbPhuongThucThanhToan);
            Controls.Add(gbChuyenKhoan);
            Controls.Add(btnThanhToan);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ThanhToanForm";
            Text = "Thanh Toán";
            Load += ThanhToanForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvThanhToan).EndInit();
            gbChuyenKhoan.ResumeLayout(false);
            gbChuyenKhoan.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
