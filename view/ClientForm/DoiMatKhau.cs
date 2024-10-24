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

namespace QuanLyDoDienTu.view.ClientForm
{
    public partial class DoiMatKhau : Form
    {
        private int maKH;

        public DoiMatKhau(int maKH)
        {
            InitializeComponent();
            this.maKH = maKH;
        }

        private void btnShowCurrentPassword_Click(object sender, EventArgs e)
        {
            if (txtCurrentPassword.PasswordChar == '*')
            {
                txtCurrentPassword.PasswordChar = '\0';
            }
            else
            {
                txtCurrentPassword.PasswordChar = '*';
            }
        }

        private void btnShowNewPassword_Click(object sender, EventArgs e)
        {
            if (txtNewPassword.PasswordChar == '*')
            {
                txtNewPassword.PasswordChar = '\0';
            }
            else
            {
                txtNewPassword.PasswordChar = '*';
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            string phoneNumber = txtPhoneNumber.Text.Trim();
            string currentPassword = txtCurrentPassword.Text.Trim();
            string newPassword = txtNewPassword.Text.Trim();

            if (string.IsNullOrEmpty(phoneNumber) || string.IsNullOrEmpty(currentPassword) || string.IsNullOrEmpty(newPassword))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                MY_DB db = new MY_DB();
                db.openConnection();

                string queryCheckPassword = "SELECT COUNT(*) FROM TAI_KHOAN WHERE SDT = @phone AND Password = @currentPassword";
                using (SqlCommand cmdCheckPassword = new SqlCommand(queryCheckPassword, db.getConnection))
                {
                    cmdCheckPassword.Parameters.AddWithValue("@phone", phoneNumber);
                    cmdCheckPassword.Parameters.AddWithValue("@currentPassword", currentPassword);

                    int count = (int)cmdCheckPassword.ExecuteScalar();
                    if (count == 1)
                    {
                        string queryUpdatePassword = "UPDATE TAI_KHOAN SET Password = @newPassword WHERE SDT = @phone";
                        using (SqlCommand cmdUpdatePassword = new SqlCommand(queryUpdatePassword, db.getConnection))
                        {
                            cmdUpdatePassword.Parameters.AddWithValue("@newPassword", newPassword);
                            cmdUpdatePassword.Parameters.AddWithValue("@phone", phoneNumber);

                            cmdUpdatePassword.ExecuteNonQuery();

                            MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu hiện tại không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                db.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }
    }
}
