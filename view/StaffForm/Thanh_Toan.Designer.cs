namespace QuanLyDoDienTu.view.StaffForm
{
    partial class Thanh_Toan
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
            label1 = new Label();
            dgDonhang = new DataGridView();
            cbbThanhtoan = new ComboBox();
            label3 = new Label();
            btnLoc = new Button();
            btnBaocao = new Button();
            ((System.ComponentModel.ISupportInitialize)dgDonhang).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 21.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(222, 53);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(465, 32);
            label1.TabIndex = 4;
            label1.Text = "Quản lí thanh toán của các đơn hàng";
            // 
            // dgDonhang
            // 
            dgDonhang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgDonhang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgDonhang.Location = new Point(65, 108);
            dgDonhang.Margin = new Padding(4, 3, 4, 3);
            dgDonhang.Name = "dgDonhang";
            dgDonhang.Size = new Size(754, 361);
            dgDonhang.TabIndex = 5;
            dgDonhang.CellClick += dgDonhang_CellClick;
            // 
            // cbbThanhtoan
            // 
            cbbThanhtoan.FormattingEnabled = true;
            cbbThanhtoan.Items.AddRange(new object[] { "Chưa thanh toán", "Đã thanh toán", " " });
            cbbThanhtoan.Location = new Point(912, 166);
            cbbThanhtoan.Margin = new Padding(4, 3, 4, 3);
            cbbThanhtoan.Name = "cbbThanhtoan";
            cbbThanhtoan.Size = new Size(140, 23);
            cbbThanhtoan.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(887, 128);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(177, 22);
            label3.TabIndex = 8;
            label3.Text = "Trạng thái đơn hàng";
            // 
            // btnLoc
            // 
            btnLoc.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnLoc.Location = new Point(933, 246);
            btnLoc.Margin = new Padding(4, 3, 4, 3);
            btnLoc.Name = "btnLoc";
            btnLoc.Size = new Size(88, 40);
            btnLoc.TabIndex = 9;
            btnLoc.Text = "Lọc";
            btnLoc.UseVisualStyleBackColor = true;
            btnLoc.Click += btnLoc_Click;
            // 
            // btnBaocao
            // 
            btnBaocao.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnBaocao.ForeColor = Color.Red;
            btnBaocao.Location = new Point(912, 388);
            btnBaocao.Margin = new Padding(4, 3, 4, 3);
            btnBaocao.Name = "btnBaocao";
            btnBaocao.Size = new Size(140, 46);
            btnBaocao.TabIndex = 10;
            btnBaocao.Text = "Báo cáo";
            btnBaocao.UseVisualStyleBackColor = true;
            btnBaocao.Click += btnBaocao_Click;
            // 
            // Thanh_Toan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1110, 568);
            Controls.Add(btnBaocao);
            Controls.Add(btnLoc);
            Controls.Add(label3);
            Controls.Add(cbbThanhtoan);
            Controls.Add(dgDonhang);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "Thanh_Toan";
            Text = "Thanh_Toan";
            Load += Thanh_Toan_Load;
            ((System.ComponentModel.ISupportInitialize)dgDonhang).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgDonhang;
        private System.Windows.Forms.ComboBox cbbThanhtoan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnLoc;
        private System.Windows.Forms.Button btnBaocao;
    }
}