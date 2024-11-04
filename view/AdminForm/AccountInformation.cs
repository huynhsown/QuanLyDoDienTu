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

namespace QuanLyDoDienTu.view.AdminForm
{
    public partial class AccountInformation : Form
    {
        private int userID;
        private int role;
        private String phone;
        private String password;
        private MY_DB myDB = new MY_DB();

        public AccountInformation()
        {
            InitializeComponent();
        }

        public AccountInformation(int userID, int role, string phone, string password)
        {
            InitializeComponent();
            this.userID = userID;
            this.role = role;
            this.phone = phone;
            this.password = password;
        }

        private void AccountInformation_Load(object sender, EventArgs e)
        {
            tb_Id.Text = userID.ToString();
            tb_Phone.Text = phone;
            tb_Password.Text = password;
            if (role == 1 || role == 2)
            {
                label_role.Text = "Mã nhân viên";
                if (role == 1)
                {
                    tb_Role.Text = "Admin";
                }
                else
                {
                    tb_Role.Text = "Nhân viên";
                }
            }
            else
            {
                label_role.Text = "Mã khách hàng";
                tb_Role.Text = "Khách hàng";
            }

        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            string new_phone = tb_Phone.Text.Trim();
            string new_password = tb_Password.Text.Trim();

            try
            {
                SqlConnection con = myDB.getConnection;
                con.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE TAI_KHOAN SET SDT = @SDT, Password = @Password WHERE SDT = @OldSDT", con))
                {
                    cmd.Parameters.Add("@SDT", SqlDbType.NVarChar).Value = new_phone;
                    cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = new_password;
                    cmd.Parameters.Add("@OldSDT", SqlDbType.NVarChar).Value = phone;

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cập nhật thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy số điện thoại cũ để cập nhật.");
                    }
                    con.Close();
                }
                con.Close();
                
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Lỗi cơ sở dữ liệu: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }

        }
    }
}
