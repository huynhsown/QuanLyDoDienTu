
namespace QuanLyDoDienTu.view.ClientForm
{
    partial class MainForm
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
            userInformation = new ToolStripMenuItem();
            findProduct = new ToolStripMenuItem();
            cartNPurchase = new ToolStripMenuItem();
            purchaseHistory = new ToolStripMenuItem();
            payMent = new ToolStripMenuItem();
            salesAnnouncement = new ToolStripMenuItem();
            panel = new Panel();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { userInformation, findProduct, cartNPurchase, purchaseHistory, payMent, salesAnnouncement });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1182, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // userInformation
            // 
            userInformation.Name = "userInformation";
            userInformation.Size = new Size(145, 24);
            userInformation.Text = "Thông tin cá nhân ";
            userInformation.Click += userInformation_Click;
            // 
            // findProduct
            // 
            findProduct.Name = "findProduct";
            findProduct.Size = new Size(152, 24);
            findProduct.Text = "Tìm kiếm sản phẩm";
            findProduct.Click += findProduct_Click;
            // 
            // cartNPurchase
            // 
            cartNPurchase.Name = "cartNPurchase";
            cartNPurchase.Size = new Size(165, 24);
            cartNPurchase.Text = "Giỏ hàng và đặt hàng";
            cartNPurchase.Click += cartNPurchase_Click;
            // 
            // purchaseHistory
            // 
            purchaseHistory.Name = "purchaseHistory";
            purchaseHistory.Size = new Size(138, 24);
            purchaseHistory.Text = "Lịch sử mua hàng";
            purchaseHistory.Click += purchaseHistory_Click;
            // 
            // payMent
            // 
            payMent.Name = "payMent";
            payMent.Size = new Size(97, 24);
            payMent.Text = "Thanh toán";
            payMent.Click += payMent_Click;
            // 
            // salesAnnouncement
            // 
            salesAnnouncement.Name = "salesAnnouncement";
            salesAnnouncement.Size = new Size(174, 24);
            salesAnnouncement.Text = "Thông báo khuyến mãi";
            salesAnnouncement.Click += salesAnnouncement_Click;
            // 
            // panel
            // 
            panel.Dock = DockStyle.Fill;
            panel.Location = new Point(0, 28);
            panel.Margin = new Padding(3, 2, 3, 2);
            panel.Name = "panel";
            panel.Size = new Size(1182, 724);
            panel.TabIndex = 1;
            panel.Paint += panel_Paint;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 752);
            Controls.Add(panel);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 2, 3, 2);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem userInformation;
        private Panel panel;
        private ToolStripMenuItem findProduct;
        private ToolStripMenuItem cartNPurchase;
        private ToolStripMenuItem purchaseHistory;
        private ToolStripMenuItem salesAnnouncement;
        private ToolStripMenuItem payMent;
    }
}

