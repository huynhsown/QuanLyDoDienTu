namespace QuanLyDoDienTu.view.StaffForm
{
    partial class QL_Hang_Ton_Kho
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
            dg_Hang_Ton_Kho = new DataGridView();
            label1 = new Label();
            btnTimKiem = new Button();
            txtSoLuong = new TextBox();
            label2 = new Label();
            label3 = new Label();
            btnThemDNH = new Button();
            ((System.ComponentModel.ISupportInitialize)dg_Hang_Ton_Kho).BeginInit();
            SuspendLayout();
            // 
            // dg_Hang_Ton_Kho
            // 
            dg_Hang_Ton_Kho.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dg_Hang_Ton_Kho.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dg_Hang_Ton_Kho.Location = new Point(52, 107);
            dg_Hang_Ton_Kho.Margin = new Padding(4, 3, 4, 3);
            dg_Hang_Ton_Kho.Name = "dg_Hang_Ton_Kho";
            dg_Hang_Ton_Kho.Size = new Size(758, 370);
            dg_Hang_Ton_Kho.TabIndex = 0;
            dg_Hang_Ton_Kho.CellClick += dg_Hang_Ton_Kho_CellClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 21.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(234, 48);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(438, 32);
            label1.TabIndex = 2;
            label1.Text = "Quản lý sản phẩm và hàng tồn kho";
            // 
            // btnTimKiem
            // 
            btnTimKiem.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnTimKiem.ForeColor = Color.FromArgb(192, 0, 0);
            btnTimKiem.Location = new Point(928, 265);
            btnTimKiem.Margin = new Padding(4, 3, 4, 3);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(111, 41);
            btnTimKiem.TabIndex = 3;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // txtSoLuong
            // 
            txtSoLuong.Location = new Point(928, 197);
            txtSoLuong.Margin = new Padding(4, 3, 4, 3);
            txtSoLuong.Name = "txtSoLuong";
            txtSoLuong.Size = new Size(110, 23);
            txtSoLuong.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.IndianRed;
            label2.Location = new Point(931, 164);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(107, 19);
            label2.TabIndex = 5;
            label2.Text = "Nhập số lượng";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.Transparent;
            label3.Location = new Point(864, 123);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(247, 22);
            label3.TabIndex = 6;
            label3.Text = "Kiểm tra hàng hóa trong kho";
            // 
            // btnThemDNH
            // 
            btnThemDNH.BackColor = Color.Honeydew;
            btnThemDNH.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnThemDNH.ForeColor = Color.Gold;
            btnThemDNH.Location = new Point(878, 390);
            btnThemDNH.Margin = new Padding(4, 3, 4, 3);
            btnThemDNH.Name = "btnThemDNH";
            btnThemDNH.Size = new Size(216, 53);
            btnThemDNH.TabIndex = 7;
            btnThemDNH.Text = "Thêm vào đơn nhập hàng";
            btnThemDNH.UseVisualStyleBackColor = false;
            btnThemDNH.Click += btnThemDNH_Click;
            // 
            // QL_Hang_Ton_Kho
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1145, 598);
            Controls.Add(btnThemDNH);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtSoLuong);
            Controls.Add(btnTimKiem);
            Controls.Add(label1);
            Controls.Add(dg_Hang_Ton_Kho);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "QL_Hang_Ton_Kho";
            Text = "QL_Hang_Ton_Kho";
            Load += QL_Hang_Ton_Kho_Load;
            ((System.ComponentModel.ISupportInitialize)dg_Hang_Ton_Kho).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dg_Hang_Ton_Kho;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnThemDNH;
    }
}