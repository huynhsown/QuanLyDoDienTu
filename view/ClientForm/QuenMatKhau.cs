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
    public partial class QuenMatKhau : Form
    {
        public QuenMatKhau()
        {
            InitializeComponent();
            //CustomizeComponents();
        }

        MY_DB db = new MY_DB();

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

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string email = txtEmail.Text.Trim();
            string newPassword = txtNewPassword.Text.Trim();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(newPassword))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                SqlConnection conn = db.getConnection;
                db.openConnection();

                string query = @"UPDATE TAI_KHOAN
                               SET Password = @newPassword
                               FROM TAI_KHOAN TK
                               JOIN KHACH_HANG KH ON TK.SDT = KH.SDT
                               WHERE KH.HoTen = @name AND KH.SDT = @phone AND KH.Email = @email";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@newPassword", newPassword);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Đặt lại mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thông tin không chính xác, vui lòng kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.closeConnection();
            }
        }

        private void QuenMatKhau_Load(object sender, EventArgs e)
        {

        }
    }
}
