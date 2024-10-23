namespace QuanLyDoDienTu.view.AdminForm
{
    partial class AdminMainForm
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
            menuStrip1 = new MenuStrip();
            staffManage = new ToolStripMenuItem();
            kHÁCHHÀNGToolStripMenuItem = new ToolStripMenuItem();
            cÔNGVIỆCToolStripMenuItem = new ToolStripMenuItem();
            nHÀSẢNXUẤTToolStripMenuItem = new ToolStripMenuItem();
            ứNGDỤNGToolStripMenuItem = new ToolStripMenuItem();
            sẢNPHẨMToolStripMenuItem = new ToolStripMenuItem();
            dOANHTHUToolStripMenuItem = new ToolStripMenuItem();
            panel = new Panel();
            đƠNNHẬPHÀNGToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { staffManage, kHÁCHHÀNGToolStripMenuItem, cÔNGVIỆCToolStripMenuItem, nHÀSẢNXUẤTToolStripMenuItem, ứNGDỤNGToolStripMenuItem, sẢNPHẨMToolStripMenuItem, dOANHTHUToolStripMenuItem, đƠNNHẬPHÀNGToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1182, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // staffManage
            // 
            staffManage.Name = "staffManage";
            staffManage.Size = new Size(102, 24);
            staffManage.Text = "NHÂN VIÊN";
            staffManage.Click += staffManage_Click;
            // 
            // kHÁCHHÀNGToolStripMenuItem
            // 
            kHÁCHHÀNGToolStripMenuItem.Name = "kHÁCHHÀNGToolStripMenuItem";
            kHÁCHHÀNGToolStripMenuItem.Size = new Size(119, 24);
            kHÁCHHÀNGToolStripMenuItem.Text = "KHÁCH HÀNG";
            kHÁCHHÀNGToolStripMenuItem.Click += kHÁCHHÀNGToolStripMenuItem_Click;
            // 
            // cÔNGVIỆCToolStripMenuItem
            // 
            cÔNGVIỆCToolStripMenuItem.Name = "cÔNGVIỆCToolStripMenuItem";
            cÔNGVIỆCToolStripMenuItem.Size = new Size(98, 24);
            cÔNGVIỆCToolStripMenuItem.Text = "CÔNG VIỆC";
            cÔNGVIỆCToolStripMenuItem.Click += cÔNGVIỆCToolStripMenuItem_Click;
            // 
            // nHÀSẢNXUẤTToolStripMenuItem
            // 
            nHÀSẢNXUẤTToolStripMenuItem.Name = "nHÀSẢNXUẤTToolStripMenuItem";
            nHÀSẢNXUẤTToolStripMenuItem.Size = new Size(129, 24);
            nHÀSẢNXUẤTToolStripMenuItem.Text = "NHÀ SẢN XUẤT";
            nHÀSẢNXUẤTToolStripMenuItem.Click += nHÀSẢNXUẤTToolStripMenuItem_Click;
            // 
            // ứNGDỤNGToolStripMenuItem
            // 
            ứNGDỤNGToolStripMenuItem.Name = "ứNGDỤNGToolStripMenuItem";
            ứNGDỤNGToolStripMenuItem.Size = new Size(101, 24);
            ứNGDỤNGToolStripMenuItem.Text = "ỨNG DỤNG";
            ứNGDỤNGToolStripMenuItem.Click += ứNGDỤNGToolStripMenuItem_Click;
            // 
            // sẢNPHẨMToolStripMenuItem
            // 
            sẢNPHẨMToolStripMenuItem.Name = "sẢNPHẨMToolStripMenuItem";
            sẢNPHẨMToolStripMenuItem.Size = new Size(98, 24);
            sẢNPHẨMToolStripMenuItem.Text = "SẢN PHẨM";
            sẢNPHẨMToolStripMenuItem.Click += sẢNPHẨMToolStripMenuItem_Click;
            // 
            // dOANHTHUToolStripMenuItem
            // 
            dOANHTHUToolStripMenuItem.Name = "dOANHTHUToolStripMenuItem";
            dOANHTHUToolStripMenuItem.Size = new Size(110, 24);
            dOANHTHUToolStripMenuItem.Text = "DOANH THU";
            dOANHTHUToolStripMenuItem.Click += dOANHTHUToolStripMenuItem_Click;
            // 
            // panel
            // 
            panel.Dock = DockStyle.Fill;
            panel.Location = new Point(0, 28);
            panel.Name = "panel";
            panel.Size = new Size(1182, 725);
            panel.TabIndex = 1;
            // 
            // đƠNNHẬPHÀNGToolStripMenuItem
            // 
            đƠNNHẬPHÀNGToolStripMenuItem.Name = "đƠNNHẬPHÀNGToolStripMenuItem";
            đƠNNHẬPHÀNGToolStripMenuItem.Size = new Size(146, 24);
            đƠNNHẬPHÀNGToolStripMenuItem.Text = "ĐƠN NHẬP HÀNG";
            đƠNNHẬPHÀNGToolStripMenuItem.Click += đƠNNHẬPHÀNGToolStripMenuItem_Click;
            // 
            // AdminMainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 753);
            Controls.Add(panel);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "AdminMainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý";
            Load += AdminMainForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem staffManage;
        private Panel panel;
        private ToolStripMenuItem kHÁCHHÀNGToolStripMenuItem;
        private ToolStripMenuItem cÔNGVIỆCToolStripMenuItem;
        private ToolStripMenuItem nHÀSẢNXUẤTToolStripMenuItem;
        private ToolStripMenuItem ứNGDỤNGToolStripMenuItem;
        private ToolStripMenuItem sẢNPHẨMToolStripMenuItem;
        private ToolStripMenuItem dOANHTHUToolStripMenuItem;
        private ToolStripMenuItem đƠNNHẬPHÀNGToolStripMenuItem;
    }
}