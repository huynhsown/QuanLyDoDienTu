namespace QuanLyDoDienTu.view.StaffForm
{
    partial class QL_Khuyen_Mai
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
            dgKhuyenmai = new DataGridView();
            label1 = new Label();
            txtChietkhau = new TextBox();
            label2 = new Label();
            btnThaydoi = new Button();
            btnXoa = new Button();
            ((System.ComponentModel.ISupportInitialize)dgKhuyenmai).BeginInit();
            SuspendLayout();
            // 
            // dgKhuyenmai
            // 
            dgKhuyenmai.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgKhuyenmai.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgKhuyenmai.Location = new Point(39, 105);
            dgKhuyenmai.Margin = new Padding(4, 3, 4, 3);
            dgKhuyenmai.Name = "dgKhuyenmai";
            dgKhuyenmai.Size = new Size(609, 350);
            dgKhuyenmai.TabIndex = 0;
            dgKhuyenmai.CellClick += dgKhuyenmai_CellClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 21.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(143, 38);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(423, 32);
            label1.TabIndex = 5;
            label1.Text = "Quản lí khuyến mãi và ứng dựng ";
            // 
            // txtChietkhau
            // 
            txtChietkhau.Location = new Point(733, 178);
            txtChietkhau.Margin = new Padding(4, 3, 4, 3);
            txtChietkhau.Name = "txtChietkhau";
            txtChietkhau.Size = new Size(116, 23);
            txtChietkhau.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(706, 141);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(172, 22);
            label2.TabIndex = 9;
            label2.Text = "Thay đổi chiết khấu";
            // 
            // btnThaydoi
            // 
            btnThaydoi.Font = new Font("Microsoft Tai Le", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnThaydoi.Location = new Point(746, 245);
            btnThaydoi.Margin = new Padding(4, 3, 4, 3);
            btnThaydoi.Name = "btnThaydoi";
            btnThaydoi.Size = new Size(88, 41);
            btnThaydoi.TabIndex = 10;
            btnThaydoi.Text = "Thay đổi";
            btnThaydoi.UseVisualStyleBackColor = true;
            btnThaydoi.Click += btnThaydoi_Click;
            // 
            // btnXoa
            // 
            btnXoa.Font = new Font("Microsoft Tai Le", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnXoa.ForeColor = Color.Red;
            btnXoa.Location = new Point(722, 359);
            btnXoa.Margin = new Padding(4, 3, 4, 3);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(143, 48);
            btnXoa.TabIndex = 11;
            btnXoa.Text = "Xóa ứng dụng";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // QL_Khuyen_Mai
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(933, 519);
            Controls.Add(btnXoa);
            Controls.Add(btnThaydoi);
            Controls.Add(label2);
            Controls.Add(txtChietkhau);
            Controls.Add(label1);
            Controls.Add(dgKhuyenmai);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "QL_Khuyen_Mai";
            Text = "QL_Khuyen_Mai";
            Load += QL_Khuyen_Mai_Load;
            ((System.ComponentModel.ISupportInitialize)dgKhuyenmai).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgKhuyenmai;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtChietkhau;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnThaydoi;
        private System.Windows.Forms.Button btnXoa;
    }
}