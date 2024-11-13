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
    public partial class ThongTinCaNhan : Form
    {
        MY_DB db = new MY_DB();
        private int maKH;
        public ThongTinCaNhan(int maKH)
        {
            InitializeComponent();
            this.maKH = maKH;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadThongTin();
        }

        private void LoadThongTin()
        {
            
            string query = "select * from fnGetThongTinKhachHang(@MaKH)";
            SqlCommand cmd = new SqlCommand(query, db.getConnection);

            db.openConnection();

            // Thêm tham số cho procedure
            cmd.Parameters.AddWithValue("@MaKH", maKH);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                txtName.Text = reader["HoTen"].ToString();
                txtSDT.Text = reader["SDT"].ToString();
                txtDiaChi.Text = reader["DiaChi"].ToString();
                txtEmail.Text = reader["Email"].ToString();
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin khách hàng!");
            }

            reader.Close();
            db.closeConnection();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_CapNhatThongTinNguoiDung", db.getConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                // Set the parameters
                cmd.Parameters.AddWithValue("@MaKH", maKH);
                cmd.Parameters.AddWithValue("@HoTen", string.IsNullOrEmpty(txtName.Text.Trim()) ? (object)DBNull.Value : txtName.Text.Trim());
                cmd.Parameters.AddWithValue("@SDT", string.IsNullOrEmpty(txtSDT.Text.Trim()) ? (object)DBNull.Value : txtSDT.Text.Trim());
                cmd.Parameters.AddWithValue("@DiaChi", string.IsNullOrEmpty(txtDiaChi.Text.Trim()) ? (object)DBNull.Value : txtDiaChi.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(txtEmail.Text.Trim()) ? (object)DBNull.Value : txtEmail.Text.Trim());

                db.openConnection();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cập nhật thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadThongTin();
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

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            DoiMatKhau doiMatKhauForm = new DoiMatKhau(maKH);
            doiMatKhauForm.Show();
        }


    }
}
