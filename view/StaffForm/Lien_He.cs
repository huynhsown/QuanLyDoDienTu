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
    public partial class Lien_He : Form
    {
        private string sdtLH;
        private string emailLH;

        // Constructor nhận thông tin số điện thoại và email
        public Lien_He(string sdt, string email)
        {
            InitializeComponent();
            sdtLH = sdt;
            emailLH = email;
        }

        // Sự kiện load form
        private void Lien_He_Load(object sender, EventArgs e)
        {
            // Gán giá trị số điện thoại và email vào các textbox
            txtSDT.Text = sdtLH;
            txtEmail.Text = emailLH;
        }
    }
}
