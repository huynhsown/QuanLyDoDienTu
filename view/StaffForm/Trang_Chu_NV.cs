using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDoDienTu.view.StaffForm
{
    public partial class Trang_Chu_NV : Form
    {
        public Trang_Chu_NV()
        {
            InitializeComponent();
        }

        // Hàm hiển thị form con trong panelContent
        private void ShowFormInPanel(Form form)
        {
            // Đóng form cũ trong panelContent nếu có
            if (panelContent.Controls.Count > 0)
                panelContent.Controls[0].Dispose();

            // Thiết lập form con
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            panelContent.Controls.Add(form);
            form.Show();
        }

        // Sự kiện khi nhấn nút Thoát
        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Sự kiện khi nhấn nút Quản lý Đơn hàng
        private void btn_QL_Don_Hang_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new QL_Don_Hang());
        }

        // Sự kiện khi nhấn nút Quản lý Hàng tồn kho
        private void btn_QL_Hang_Ton_Kho_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new QL_Hang_Ton_Kho());
        }

        // Sự kiện khi nhấn nút Quản lý Lịch làm việc
        private void btn_QL_Lich_Lam_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new QL_Lich_Lam());
        }

        // Sự kiện khi nhấn nút Quản lý Khách hàng
        private void btn_QL_Khach_Hang_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new QL_Khach_Hang());
        }

        // Sự kiện khi nhấn nút Thanh toán
        private void btn_Thanh_Toan_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new Thanh_Toan());
        }

        // Sự kiện khi nhấn nút Quản lý Khuyến mãi
        private void btn_QL_Khuyen_Mai_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new QL_Khuyen_Mai());
        }

        // Sự kiện khi nhấn nút Quản lý Nhập hàng
        private void btn_QL_Nhap_Hang_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new QL_Nhap_Hang());
        }

        // Sự kiện khi nhấn nút Báo cáo
        private void btn_Bao_Cao_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new Bao_Cao_Su_Co());
        }

        private void Trang_Chu_NV_Load(object sender, EventArgs e)
        {
            // Tải dữ liệu hoặc thiết lập ban đầu
        }

        private void panelContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelContent_Paint_1(object sender, PaintEventArgs e)
        {

        }

      
    }
}
