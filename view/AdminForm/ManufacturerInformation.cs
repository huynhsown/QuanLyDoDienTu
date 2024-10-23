using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDoDienTu.view.AdminForm
{
    public partial class ManufacturerInformation : Form
    {
        private int manuid;
        bool isEdit = false;
        private MY_DB myDB = new MY_DB();
        public ManufacturerInformation(int manuid)
        {
            InitializeComponent();
            this.manuid = manuid;
            isEdit = true;
            btn_Add.Visible = false;

        }

        public ManufacturerInformation()
        {
            InitializeComponent();
            btn_Edit.Visible = false;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            try
            {
                // Retrieve and trim input values
                String name = tb_Name.Text.Trim();
                String phone = tb_Phone.Text.Trim();
                String email = tb_Email.Text.Trim();

                // Get the database connection
                using (SqlConnection conn = myDB.getConnection)
                {
                    myDB.openConnection(); // Open connection

                    // Create the SqlCommand for the stored procedure
                    using (SqlCommand cmd = new SqlCommand("UpdateNhaSanXuat", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure; // Specify that we're using a stored procedure

                        // Add parameters for the stored procedure
                        cmd.Parameters.AddWithValue("@MaNSX", int.Parse(tb_Id.Text));
                        cmd.Parameters.AddWithValue("@TenNSX", name);
                        cmd.Parameters.AddWithValue("@SDT", phone);
                        cmd.Parameters.AddWithValue("@Email", email);

                        // Execute the command
                        int rowsAffected = cmd.ExecuteNonQuery();

                        // Provide feedback based on the result
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Cập nhật nhà sản xuất thành công", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật không thành công. Vui lòng kiểm tra thông tin.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Show error message
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                // Retrieve and trim input values
                String name = tb_Name.Text.Trim();
                String phone = tb_Phone.Text.Trim();
                String email = tb_Email.Text.Trim();

                // Get the database connection
                using (SqlConnection conn = myDB.getConnection)
                {
                    myDB.openConnection(); // Open connection

                    // Create the SqlCommand for the stored procedure
                    using (SqlCommand cmd = new SqlCommand("InsertNhaSanXuat", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure; // Specify that we're using a stored procedure

                        // Add parameters for the stored procedure
                        cmd.Parameters.AddWithValue("@TenNSX", name);
                        cmd.Parameters.AddWithValue("@SDT", phone);
                        cmd.Parameters.AddWithValue("@Email", email);

                        // Execute the command
                        int rowsAffected = cmd.ExecuteNonQuery();

                        // Provide feedback based on the result
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Thêm nhà sản xuất thành công", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Thêm nhà sản xuất không thành công. Vui lòng kiểm tra thông tin.", "Add", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Show error message
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ManufacturerInformation_Load(object sender, EventArgs e)
        {
            if (isEdit)
            {
                String query = @"SELECT * FROM NHA_SAN_XUAT WHERE MaNSX = @maNSX";
                try
                {
                    int maSP;
                    SqlConnection connection = myDB.getConnection;

                    connection.Open(); // Mở kết nối

                    // Query Staff Infomation
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@maNSX", manuid); // Gán giá trị cho tham số

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
                        tb_Id.Text = dr["MaNSX"].ToString(); // Gán giá trị Mã NV vào TextBox
                        tb_Name.Text = dr["TenNSX"].ToString();
                        tb_Phone.Text = dr["SDT"].ToString();
                        tb_Email.Text = dr["Email"].ToString();
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
