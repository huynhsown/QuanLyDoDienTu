﻿namespace QuanLyDoDienTu.view.StaffForm
{
    partial class QL_Nhap_Hang
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
            dgDonnhaphang = new DataGridView();
            label1 = new Label();
            btnLienhe = new Button();
            ((System.ComponentModel.ISupportInitialize)dgDonnhaphang).BeginInit();
            SuspendLayout();
            // 
            // dgDonnhaphang
            // 
            dgDonnhaphang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgDonnhaphang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgDonnhaphang.Location = new Point(48, 152);
            dgDonnhaphang.Margin = new Padding(5, 4, 5, 4);
            dgDonnhaphang.Name = "dgDonnhaphang";
            dgDonnhaphang.RowHeadersWidth = 51;
            dgDonnhaphang.Size = new Size(902, 473);
            dgDonnhaphang.TabIndex = 0;
            dgDonnhaphang.CellClick += dgDonnhaphang_CellClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 21.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(210, 62);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(581, 42);
            label1.TabIndex = 5;
            label1.Text = "Quản lí nhập hàng và Nhà sản xuất";
            // 
            // btnLienhe
            // 
            btnLienhe.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnLienhe.Location = new Point(424, 672);
            btnLienhe.Margin = new Padding(5, 4, 5, 4);
            btnLienhe.Name = "btnLienhe";
            btnLienhe.Size = new Size(152, 85);
            btnLienhe.TabIndex = 6;
            btnLienhe.Text = "Liên Hệ";
            btnLienhe.UseVisualStyleBackColor = true;
            btnLienhe.Click += btnLienhe_Click;
            // 
            // QL_Nhap_Hang
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1001, 800);
            Controls.Add(btnLienhe);
            Controls.Add(label1);
            Controls.Add(dgDonnhaphang);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(5, 4, 5, 4);
            Name = "QL_Nhap_Hang";
            Text = "QL_Nhap_Hang";
            Load += QL_Nhap_Hang_Load;
            ((System.ComponentModel.ISupportInitialize)dgDonnhaphang).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgDonnhaphang;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLienhe;
    }
}