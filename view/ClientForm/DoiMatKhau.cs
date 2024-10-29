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
        MY_DB db = new MY_DB();

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
                
                SqlCommand cmd = new SqlCommand("sp_DoiMatKhau", db.getConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@SDT", phoneNumber);
                cmd.Parameters.AddWithValue("@MatKhauHienTai", currentPassword);
                cmd.Parameters.AddWithValue("@MatKhauMoi", newPassword);

                db.openConnection();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 50000) // Error number for RAISERROR
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                
                db.closeConnection();
            }
        }

    }
}
