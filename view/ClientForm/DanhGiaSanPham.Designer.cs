namespace QuanLyDoDienTu.view.ClientForm
{
    partial class DanhGiaSanPham
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
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lbSanPham = new ListBox();
            txtDanhGia = new TextBox();
            numRating = new NumericUpDown();
            btnSubmit = new Button();
            ((System.ComponentModel.ISupportInitialize)numRating).BeginInit();
            SuspendLayout();
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.AutoSize = false;
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Arial", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            guna2HtmlLabel1.Location = new Point(20, 30);
            guna2HtmlLabel1.Margin = new Padding(3, 4, 3, 4);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(300, 25);
            guna2HtmlLabel1.TabIndex = 0;
            guna2HtmlLabel1.Text = "Danh sách sản phẩm đã mua";
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.AutoSize = false;
            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.Font = new Font("Arial", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            guna2HtmlLabel2.Location = new Point(20, 219);
            guna2HtmlLabel2.Margin = new Padding(3, 4, 3, 4);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(300, 25);
            guna2HtmlLabel2.TabIndex = 1;
            guna2HtmlLabel2.Text = "Nhập đánh giá của bạn";
            // 
            // guna2HtmlLabel3
            // 
            guna2HtmlLabel3.AutoSize = false;
            guna2HtmlLabel3.BackColor = Color.Transparent;
            guna2HtmlLabel3.Font = new Font("Arial", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            guna2HtmlLabel3.Location = new Point(20, 401);
            guna2HtmlLabel3.Margin = new Padding(3, 4, 3, 4);
            guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            guna2HtmlLabel3.Size = new Size(300, 25);
            guna2HtmlLabel3.TabIndex = 2;
            guna2HtmlLabel3.Text = "Chọn điểm đánh giá (1-5)";
            // 
            // lbSanPham
            // 
            lbSanPham.FormattingEnabled = true;
            lbSanPham.ItemHeight = 20;
            lbSanPham.Location = new Point(20, 62);
            lbSanPham.Margin = new Padding(3, 4, 3, 4);
            lbSanPham.Name = "lbSanPham";
            lbSanPham.Size = new Size(300, 124);
            lbSanPham.TabIndex = 3;
            // 
            // txtDanhGia
            // 
            txtDanhGia.ForeColor = SystemColors.GrayText;
            txtDanhGia.Location = new Point(20, 251);
            txtDanhGia.Margin = new Padding(3, 4, 3, 4);
            txtDanhGia.Multiline = true;
            txtDanhGia.Name = "txtDanhGia";
            txtDanhGia.Size = new Size(400, 124);
            txtDanhGia.TabIndex = 4;
            txtDanhGia.Text = "Nhập đánh giá của bạn...";
            // 
            // numRating
            // 
            numRating.Location = new Point(20, 438);
            numRating.Margin = new Padding(3, 4, 3, 4);
            numRating.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            numRating.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numRating.Name = "numRating";
            numRating.Size = new Size(50, 27);
            numRating.TabIndex = 5;
            numRating.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnSubmit
            // 
            btnSubmit.BackColor = Color.LightSkyBlue;
            btnSubmit.Location = new Point(20, 494);
            btnSubmit.Margin = new Padding(3, 4, 3, 4);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(107, 35);
            btnSubmit.TabIndex = 6;
            btnSubmit.Text = "Gửi đánh giá";
            btnSubmit.UseVisualStyleBackColor = false;
            // 
            // DanhGiaSanPham
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(682, 566);
            Controls.Add(btnSubmit);
            Controls.Add(numRating);
            Controls.Add(txtDanhGia);
            Controls.Add(lbSanPham);
            Controls.Add(guna2HtmlLabel3);
            Controls.Add(guna2HtmlLabel2);
            Controls.Add(guna2HtmlLabel1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "DanhGiaSanPham";
            Text = "Đánh giá sản phẩm";
            ((System.ComponentModel.ISupportInitialize)numRating).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private System.Windows.Forms.ListBox lbSanPham;
        private System.Windows.Forms.TextBox txtDanhGia;
        private System.Windows.Forms.NumericUpDown numRating;
        private System.Windows.Forms.Button btnSubmit;
    }
}