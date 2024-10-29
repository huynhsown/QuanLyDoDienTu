namespace QuanLyDoDienTu.view.ClientForm
{
    partial class ThongBaoKhuyenMaiForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvKhuyenMai;

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
            dgvKhuyenMai = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvKhuyenMai).BeginInit();
            SuspendLayout();
            // 
            // dgvKhuyenMai
            // 
            dgvKhuyenMai.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKhuyenMai.Location = new Point(12, 12);
            dgvKhuyenMai.Name = "dgvKhuyenMai";
            dgvKhuyenMai.RowHeadersWidth = 51;
            dgvKhuyenMai.RowTemplate.Height = 29;
            dgvKhuyenMai.Size = new Size(500, 300);
            dgvKhuyenMai.TabIndex = 0;
            // 
            // ThongBaoKhuyenMaiForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(530, 330);
            ControlBox = false;
            Controls.Add(dgvKhuyenMai);
            Name = "ThongBaoKhuyenMaiForm";
            Text = "Thông Báo Khuyến Mãi";
            Load += ThongBaoKhuyenMaiForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvKhuyenMai).EndInit();
            ResumeLayout(false);
        }
    }
}
