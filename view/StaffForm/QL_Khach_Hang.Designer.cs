namespace QuanLyDoDienTu.view.StaffForm
{
    partial class QL_Khach_Hang
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
            dgKhachhang = new DataGridView();
            label1 = new Label();
            label3 = new Label();
            label2 = new Label();
            txtSDT = new TextBox();
            btnTimkiem = new Button();
            label4 = new Label();
            txtRSDT = new TextBox();
            btnThaydoi = new Button();
            txtREmail = new TextBox();
            label5 = new Label();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgKhachhang).BeginInit();
            SuspendLayout();
            // 
            // dgKhachhang
            // 
            dgKhachhang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgKhachhang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgKhachhang.Location = new Point(63, 91);
            dgKhachhang.Margin = new Padding(4, 3, 4, 3);
            dgKhachhang.Name = "dgKhachhang";
            dgKhachhang.Size = new Size(835, 340);
            dgKhachhang.TabIndex = 0;
            dgKhachhang.CellClick += dgKhachhang_CellClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 21.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(434, 25);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(373, 32);
            label1.TabIndex = 4;
            label1.Text = "Quản lí thông tin khách hàng";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(995, 91);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(169, 15);
            label3.TabIndex = 7;
            label3.Text = "Tra cứu thông tin khách hàng";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(923, 123);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 8;
            label2.Text = "Nhập SDT";
            // 
            // txtSDT
            // 
            txtSDT.Location = new Point(1004, 120);
            txtSDT.Margin = new Padding(4, 3, 4, 3);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(160, 23);
            txtSDT.TabIndex = 9;
            // 
            // btnTimkiem
            // 
            btnTimkiem.Font = new Font("Microsoft Tai Le", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnTimkiem.Location = new Point(1032, 161);
            btnTimkiem.Margin = new Padding(4, 3, 4, 3);
            btnTimkiem.Name = "btnTimkiem";
            btnTimkiem.Size = new Size(103, 35);
            btnTimkiem.TabIndex = 10;
            btnTimkiem.Text = "Tìm kiếm";
            btnTimkiem.UseVisualStyleBackColor = true;
            btnTimkiem.Click += btnTimkiem_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(1004, 237);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(143, 15);
            label4.TabIndex = 11;
            label4.Text = "Thay đổi SDT hoặc Email";
            // 
            // txtRSDT
            // 
            txtRSDT.Location = new Point(1004, 284);
            txtRSDT.Margin = new Padding(4, 3, 4, 3);
            txtRSDT.Name = "txtRSDT";
            txtRSDT.Size = new Size(160, 23);
            txtRSDT.TabIndex = 12;
            // 
            // btnThaydoi
            // 
            btnThaydoi.Font = new Font("Microsoft Tai Le", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnThaydoi.Location = new Point(1032, 396);
            btnThaydoi.Margin = new Padding(4, 3, 4, 3);
            btnThaydoi.Name = "btnThaydoi";
            btnThaydoi.Size = new Size(101, 35);
            btnThaydoi.TabIndex = 13;
            btnThaydoi.Text = "Thay đổi";
            btnThaydoi.UseVisualStyleBackColor = true;
            btnThaydoi.Click += btnThaydoi_Click;
            // 
            // txtREmail
            // 
            txtREmail.Location = new Point(1004, 345);
            txtREmail.Margin = new Padding(4, 3, 4, 3);
            txtREmail.Name = "txtREmail";
            txtREmail.Size = new Size(160, 23);
            txtREmail.TabIndex = 14;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(949, 288);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(32, 15);
            label5.TabIndex = 15;
            label5.Text = "SDT";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(948, 348);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(38, 15);
            label6.TabIndex = 16;
            label6.Text = "Email";
            // 
            // QL_Khach_Hang
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1225, 502);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(txtREmail);
            Controls.Add(btnThaydoi);
            Controls.Add(txtRSDT);
            Controls.Add(label4);
            Controls.Add(btnTimkiem);
            Controls.Add(txtSDT);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(dgKhachhang);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "QL_Khach_Hang";
            Text = "QL_Khach_Hang";
            Load += QL_Khach_Hang_Load;
            ((System.ComponentModel.ISupportInitialize)dgKhachhang).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgKhachhang;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Button btnTimkiem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRSDT;
        private System.Windows.Forms.Button btnThaydoi;
        private System.Windows.Forms.TextBox txtREmail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}