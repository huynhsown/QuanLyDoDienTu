namespace QuanLyDoDienTu.view.StaffForm
{
    partial class QL_Don_Hang
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
            dgDonhang = new DataGridView();
            label1 = new Label();
            cbbTrangthai = new ComboBox();
            label3 = new Label();
            btnCapnhat = new Button();
            btnXemchitiet = new Button();
            btnLienhe = new Button();
            ((System.ComponentModel.ISupportInitialize)dgDonhang).BeginInit();
            SuspendLayout();
            // 
            // dgDonhang
            // 
            dgDonhang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgDonhang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgDonhang.Location = new Point(30, 136);
            dgDonhang.Margin = new Padding(4, 3, 4, 3);
            dgDonhang.Name = "dgDonhang";
            dgDonhang.Size = new Size(842, 411);
            dgDonhang.TabIndex = 0;
            dgDonhang.CellClick += dgDonhang_CellClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 36F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(288, 39);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(380, 55);
            label1.TabIndex = 3;
            label1.Text = "Quản lí đơn hàng";
            // 
            // cbbTrangthai
            // 
            cbbTrangthai.FormattingEnabled = true;
            cbbTrangthai.Items.AddRange(new object[] { "Chờ xác nhận", "Đang giao", "Đã hoàn thành", "Đã hủy" });
            cbbTrangthai.Location = new Point(961, 202);
            cbbTrangthai.Margin = new Padding(4, 3, 4, 3);
            cbbTrangthai.Name = "cbbTrangthai";
            cbbTrangthai.Size = new Size(166, 23);
            cbbTrangthai.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(919, 156);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(251, 22);
            label3.TabIndex = 7;
            label3.Text = "Cập nhật trạng thái đơn hàng";
            // 
            // btnCapnhat
            // 
            btnCapnhat.BackColor = Color.White;
            btnCapnhat.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnCapnhat.ForeColor = Color.FromArgb(0, 192, 0);
            btnCapnhat.Location = new Point(994, 248);
            btnCapnhat.Margin = new Padding(4, 3, 4, 3);
            btnCapnhat.Name = "btnCapnhat";
            btnCapnhat.Size = new Size(104, 32);
            btnCapnhat.TabIndex = 8;
            btnCapnhat.Text = "Cập nhật";
            btnCapnhat.UseVisualStyleBackColor = false;
            btnCapnhat.Click += btnCapnhat_Click;
            // 
            // btnXemchitiet
            // 
            btnXemchitiet.BackColor = Color.FromArgb(224, 224, 224);
            btnXemchitiet.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnXemchitiet.ForeColor = Color.IndianRed;
            btnXemchitiet.Location = new Point(981, 362);
            btnXemchitiet.Margin = new Padding(4, 3, 4, 3);
            btnXemchitiet.Name = "btnXemchitiet";
            btnXemchitiet.Size = new Size(146, 30);
            btnXemchitiet.TabIndex = 9;
            btnXemchitiet.Text = "Xem chi tiết";
            btnXemchitiet.UseVisualStyleBackColor = false;
            btnXemchitiet.Click += btnXemchitiet_Click;
            // 
            // btnLienhe
            // 
            btnLienhe.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnLienhe.ForeColor = Color.FromArgb(192, 64, 0);
            btnLienhe.Location = new Point(947, 475);
            btnLienhe.Margin = new Padding(4, 3, 4, 3);
            btnLienhe.Name = "btnLienhe";
            btnLienhe.Size = new Size(209, 32);
            btnLienhe.TabIndex = 10;
            btnLienhe.Text = "Liên hệ khách hàng";
            btnLienhe.UseVisualStyleBackColor = true;
            btnLienhe.Click += btnLienhe_Click;
            // 
            // QL_Don_Hang
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1193, 613);
            Controls.Add(btnLienhe);
            Controls.Add(btnXemchitiet);
            Controls.Add(btnCapnhat);
            Controls.Add(label3);
            Controls.Add(cbbTrangthai);
            Controls.Add(label1);
            Controls.Add(dgDonhang);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "QL_Don_Hang";
            Text = "QL_Don_Hang";
            Load += QL_Don_Hang_Load;
            ((System.ComponentModel.ISupportInitialize)dgDonhang).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgDonhang;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbTrangthai;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCapnhat;
        private System.Windows.Forms.Button btnXemchitiet;
        private System.Windows.Forms.Button btnLienhe;
    }
}