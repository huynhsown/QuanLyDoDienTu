namespace QuanLyDoDienTu.view.StaffForm
{
    partial class QL_Lich_Lam
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
            dgLichLam = new DataGridView();
            label1 = new Label();
            txtMaNV = new TextBox();
            dateBatdau = new DateTimePicker();
            dateKetthuc = new DateTimePicker();
            label3 = new Label();
            label2 = new Label();
            label4 = new Label();
            btnKetca = new Button();
            btnThem = new Button();
            btnCapnhat = new Button();
            btnXoa = new Button();
            ((System.ComponentModel.ISupportInitialize)dgLichLam).BeginInit();
            SuspendLayout();
            // 
            // dgLichLam
            // 
            dgLichLam.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgLichLam.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgLichLam.Location = new Point(52, 90);
            dgLichLam.Margin = new Padding(4, 3, 4, 3);
            dgLichLam.Name = "dgLichLam";
            dgLichLam.Size = new Size(639, 377);
            dgLichLam.TabIndex = 0;
            dgLichLam.CellClick += dgLichLam_CellClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 21.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(248, 31);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(265, 32);
            label1.TabIndex = 3;
            label1.Text = "Quản lí lịch làm việc";
            // 
            // txtMaNV
            // 
            txtMaNV.Location = new Point(739, 115);
            txtMaNV.Margin = new Padding(4, 3, 4, 3);
            txtMaNV.Name = "txtMaNV";
            txtMaNV.Size = new Size(233, 23);
            txtMaNV.TabIndex = 4;
            // 
            // dateBatdau
            // 
            dateBatdau.Location = new Point(739, 217);
            dateBatdau.Margin = new Padding(4, 3, 4, 3);
            dateBatdau.Name = "dateBatdau";
            dateBatdau.Size = new Size(233, 23);
            dateBatdau.TabIndex = 5;
            // 
            // dateKetthuc
            // 
            dateKetthuc.Location = new Point(739, 311);
            dateKetthuc.Margin = new Padding(4, 3, 4, 3);
            dateKetthuc.Name = "dateKetthuc";
            dateKetthuc.Size = new Size(233, 23);
            dateKetthuc.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(766, 90);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(170, 22);
            label3.TabIndex = 7;
            label3.Text = "Nhập Mã nhân viên";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(774, 178);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(155, 22);
            label2.TabIndex = 8;
            label2.Text = "Thời gian bắt đầu";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(777, 275);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(160, 22);
            label4.TabIndex = 9;
            label4.Text = "Thời gian kết thúc";
            // 
            // btnKetca
            // 
            btnKetca.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnKetca.Location = new Point(259, 494);
            btnKetca.Margin = new Padding(4, 3, 4, 3);
            btnKetca.Name = "btnKetca";
            btnKetca.Size = new Size(224, 61);
            btnKetca.TabIndex = 10;
            btnKetca.Text = "Báo cáo và Kết thúc ca làm việc";
            btnKetca.UseVisualStyleBackColor = true;
            btnKetca.Click += btnKetca_Click;
            // 
            // btnThem
            // 
            btnThem.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnThem.Location = new Point(718, 360);
            btnThem.Margin = new Padding(4, 3, 4, 3);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(122, 37);
            btnThem.TabIndex = 11;
            btnThem.Text = "Thêm ca làm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnCapnhat
            // 
            btnCapnhat.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnCapnhat.Location = new Point(792, 418);
            btnCapnhat.Margin = new Padding(4, 3, 4, 3);
            btnCapnhat.Name = "btnCapnhat";
            btnCapnhat.Size = new Size(122, 37);
            btnCapnhat.TabIndex = 12;
            btnCapnhat.Text = "Cập nhật ca làm";
            btnCapnhat.UseVisualStyleBackColor = true;
            btnCapnhat.Click += btnCapnhat_Click;
            // 
            // btnXoa
            // 
            btnXoa.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnXoa.Location = new Point(863, 361);
            btnXoa.Margin = new Padding(4, 3, 4, 3);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(122, 37);
            btnXoa.TabIndex = 13;
            btnXoa.Text = "Xóa ca làm";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // QL_Lich_Lam
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1011, 588);
            Controls.Add(btnXoa);
            Controls.Add(btnCapnhat);
            Controls.Add(btnThem);
            Controls.Add(btnKetca);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(dateKetthuc);
            Controls.Add(dateBatdau);
            Controls.Add(txtMaNV);
            Controls.Add(label1);
            Controls.Add(dgLichLam);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "QL_Lich_Lam";
            Text = "QL_Lich_Lam";
            Load += QL_Lich_Lam_Load;
            ((System.ComponentModel.ISupportInitialize)dgLichLam).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgLichLam;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.DateTimePicker dateBatdau;
        private System.Windows.Forms.DateTimePicker dateKetthuc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnKetca;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnCapnhat;
        private System.Windows.Forms.Button btnXoa;
    }
}