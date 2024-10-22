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
    public partial class CustomerInformation : Form
    {
        public CustomerInformation()
        {
            InitializeComponent();
            btn_Save.Visible = false;
            btn_Add.Location = btn_Save.Location;
        }

        private int id;
        private bool isEdit = false;
        private MY_DB myDB = new MY_DB();
        public CustomerInformation(int id)
        {
            InitializeComponent();
            this.id = id;
            isEdit = true;
            btn_Add.Visible = false;
        }

        private void CustomerInformation_Load(object sender, EventArgs e)
        {
            if (isEdit)
            {
                String query = @"SELECT * FROM KHACH_HANG WHERE MaKH = @id";
                try
                {
                    int staff_job_id;
                    SqlConnection connection = myDB.getConnection;

                    connection.Open(); // Mở kết nối

                    // Query Staff Infomation
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id); // Gán giá trị cho tham số

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable); // Lấy dữ liệu vào DataTable

                        // Kiểm tra số lượng dòng
                        if (dataTable.Rows.Count != 1)
                        {
                            MessageBox.Show("Không tìm thấy hoặc có nhiều hơn một kết quả.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Close(); // Đóng form nếu không tìm thấy dữ liệu
                            return; // Thoát khỏi hàm
                        }

                        // Lấy dữ liệu từ DataTable
                        DataRow dr = dataTable.Rows[0];
                        tb_Id.Text = dr["MaKH"].ToString(); // Gán giá trị Mã NV vào TextBox
                        tb_Name.Text = dr["HoTen"].ToString();
                        tb_Phone.Text = dr["SDT"].ToString();
                        tb_Email.Text = dr["Email"].ToString();
                        tb_Address.Text = dr["DiaChi"].ToString();
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                String name = tb_Name.Text.Trim();
                String phone = tb_Phone.Text.Trim();
                String email = tb_Email.Text.Trim();
                String address = tb_Address.Text.Trim();

                string queryUpdate = @"UPDATE KHACH_HANG
                           SET 
                               HoTen = @HoTen,
                               SDT = @SDT,
                               Email = @Email,
                               DiaChi = @DiaChi
                           WHERE 
                               MaKH = @MaKH";

                SqlConnection connection = myDB.getConnection;

                connection.Open(); // Mở kết nối

                // Query Staff Infomation
                using (SqlCommand command = new SqlCommand(queryUpdate, connection))
                {
                    command.Parameters.AddWithValue("@MaKH", id); // Giá trị Mã NV
                    command.Parameters.AddWithValue("@HoTen", tb_Name.Text);
                    command.Parameters.AddWithValue("@SDT", tb_Phone.Text);
                    command.Parameters.AddWithValue("@Email", tb_Email.Text);
                    command.Parameters.AddWithValue("@DiaChi", tb_Address.Text);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cập nhật thông tin thành công.");
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật không thành công. Vui lòng kiểm tra thông tin.");
                    }

                }
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {

            try
            {
                String name = tb_Name.Text.Trim();
                String phone = tb_Phone.Text.Trim();
                String email = tb_Email.Text.Trim();
                String address = tb_Address.Text.Trim();

                // Update the SQL query to match the KHACH_HANG table structure
                string queryInsert = @"INSERT INTO KHACH_HANG (HoTen, DiaChi, SDT, Email) 
                           VALUES (@HoTen, @DiaChi, @SDT, @Email);";

                SqlConnection connection = myDB.getConnection;

                connection.Open(); // Mở kết nối

                // Query Customer Information
                using (SqlCommand command = new SqlCommand(queryInsert, connection))
                {
                    command.Parameters.AddWithValue("@HoTen", name); // Giá trị Họ tên
                    command.Parameters.AddWithValue("@SDT", phone);   // Giá trị SĐT
                    command.Parameters.AddWithValue("@Email", email); // Giá trị Email
                    command.Parameters.AddWithValue("@DiaChi", address); // Giá trị Địa chỉ

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Thêm khách hàng thành công.");
                    }
                    else
                    {
                        MessageBox.Show("Thêm khách hàng không thành công. Vui lòng kiểm tra thông tin.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
