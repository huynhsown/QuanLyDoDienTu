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
            MY_DB db = new MY_DB();

            string query = "SELECT HoTen, SDT, DiaChi, Email FROM KHACH_HANG WHERE MaKH = @maKH";
            SqlCommand cmd = new SqlCommand(query, db.getConnection);

            db.openConnection();

            cmd.Parameters.AddWithValue("@maKH", maKH);
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
            MY_DB db = new MY_DB();

            // Bắt đầu câu lệnh SQL cho việc cập nhật
            string query = "UPDATE KHACH_HANG SET ";

            List<string> updates = new List<string>();
            if (!string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                updates.Add("HoTen = @name");
            }
            if (!string.IsNullOrEmpty(txtSDT.Text.Trim()))
            {
                updates.Add("SDT = @phone");
            }
            if (!string.IsNullOrEmpty(txtDiaChi.Text.Trim()))
            {
                updates.Add("DiaChi = @address");
            }
            if (!string.IsNullOrEmpty(txtEmail.Text.Trim()))
            {
                updates.Add("Email = @email");
            }

            // Nếu không có thuộc tính nào cần cập nhật, thoát khỏi hàm
            if (updates.Count == 0)
            {
                MessageBox.Show("Không có thông tin nào để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Ghép các phần cập nhật lại thành câu lệnh
            query += string.Join(", ", updates) + " WHERE MaKH = @maKH";

            SqlCommand cmd = new SqlCommand(query, db.getConnection);

            // Thêm giá trị cho các tham số
            if (updates.Contains("HoTen = @name"))
            {
                cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
            }
            if (updates.Contains("SDT = @phone"))
            {
                cmd.Parameters.AddWithValue("@phone", txtSDT.Text.Trim());
            }
            if (updates.Contains("DiaChi = @address"))
            {
                cmd.Parameters.AddWithValue("@address", txtDiaChi.Text.Trim());
            }
            if (updates.Contains("Email = @email"))
            {
                cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
            }

            // Thêm giá trị cho MaKH
            cmd.Parameters.AddWithValue("@maKH", maKH);

            try
            {
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
