using QuanLyDoDienTu.view.AdminForm;
using QuanLyDoDienTu.view.ClientForm;
using QuanLyDoDienTu.view.StaffForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDoDienTu.view
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private MY_DB myDB = new MY_DB();

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            string sdt = tb_Phone.Text.Trim();
            string pw = tb_Password.Text.Trim();
            var (result, userId) = CheckAccount(sdt, pw); // Gọi hàm CheckAccount và lấy tuple

            switch (result)
            {
                case 1:
                    MessageBox.Show("Đăng nhập thành công với quyền admin.");
                    // Chuyển đến form admin hoặc thực hiện hành động admin
                    AdminMainForm adminForm = new AdminMainForm(Convert.ToInt32(userId));
                    adminForm.ShowDialog();
                    break;
                case 2:
                    MessageBox.Show("Đăng nhập thành công với quyền nhân viên.");
                    // Chuyển đến form nhân viên
                    Trang_Chu_NV trang_Chu_NV = new Trang_Chu_NV();
                    trang_Chu_NV.ShowDialog();
                    break;
                case 3:
                    MessageBox.Show("Đăng nhập thành công với tư cách khách hàng.");
                    // Chuyển đến form khách hàng
                    MainForm clientForm = new MainForm(Convert.ToInt32(userId));
                    clientForm.ShowDialog();
                    break;
                case -1:
                    MessageBox.Show("Số điện thoại hoặc mật khẩu không đúng.");
                    break;
                default:
                    MessageBox.Show("Đã xảy ra lỗi. Vui lòng kiểm tra lại.");
                    break;
            }
        }


        private (int result, int? userId) CheckAccount(string sdt, string password)
        {
            int result = -1; // Mặc định trả về -1
            int? userId = null; // Khởi tạo userId với giá trị null

            try
            {
                SqlConnection con = myDB.getConnection;
                
                using (SqlCommand cmd = new SqlCommand("SELECT Result, UserID FROM dbo.fn_KiemTraTaiKhoan(@SDT, @Password)", con))
                {
                    cmd.Parameters.AddWithValue("@SDT", sdt);
                    cmd.Parameters.AddWithValue("@Password", password);

                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) // Kiểm tra xem có kết quả trả về không
                        {
                            result = reader.GetInt32(0); // Kết quả
                            userId = reader.IsDBNull(1) ? (int?)null : reader.GetInt32(1); // ID người dùng
                        }
                    }
                    con.Close();
                }
                
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            return (result, userId); // Trả về tuple
        }

    }
}
