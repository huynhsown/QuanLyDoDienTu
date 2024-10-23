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
    public partial class ApplicationInformation : Form
    {
        private int appid;
        private bool isEdit = false;
        private MY_DB myDB = new MY_DB();
        public ApplicationInformation(int appid)
        {
            InitializeComponent();
            this.appid = appid;
            isEdit = true;
            btn_Add.Visible = false;
        }
        public ApplicationInformation()
        {
            InitializeComponent();
            btn_Edit.Visible = false;
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the database connection
                SqlConnection conn = myDB.getConnection;
                myDB.openConnection();

                // Create the SqlCommand for the stored procedure
                SqlCommand cmd = new SqlCommand("UpdateUngDung", conn);
                cmd.CommandType = CommandType.StoredProcedure; // Specify that we're using a stored procedure

                // Add parameters for the stored procedure
                cmd.Parameters.AddWithValue("@MaUngDung", int.Parse(tb_Id.Text));
                cmd.Parameters.AddWithValue("@TenUngDung", tb_Name.Text);
                cmd.Parameters.AddWithValue("@ChietKhau", int.Parse(tb_Discount.Text));

                // Execute the command
                int rowsAffected = cmd.ExecuteNonQuery();

                // Close the connection
                myDB.closeConnection();

                MessageBox.Show("Cập nhật sản phẩm thành công", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                // Show error message
                MessageBox.Show("Lỗi: " + ex.Message);
            }


        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the database connection
                SqlConnection conn = myDB.getConnection;
                myDB.openConnection();

                // Create the SqlCommand for the stored procedure
                SqlCommand cmd = new SqlCommand("InsertUngDung", conn);
                cmd.CommandType = CommandType.StoredProcedure; // Specify that we're using a stored procedure

                // Add parameters for the stored procedure
                cmd.Parameters.AddWithValue("@TenUngDung", tb_Name.Text);
                cmd.Parameters.AddWithValue("@ChietKhau", int.Parse(tb_Discount.Text));

                // Execute the command
                cmd.ExecuteNonQuery();

                // Close the connection
                myDB.closeConnection();

                // Show success message
                MessageBox.Show("Thêm ứng dụng thành công", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Show error message
                MessageBox.Show("Lỗi: " + ex.Message);
            }

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ApplicationInformation_Load(object sender, EventArgs e)
        {
            if (isEdit)
            {
                String query = @"SELECT * FROM UNG_DUNG WHERE MaUngDung = @maUD";
                try
                {
                    int maSP;
                    SqlConnection connection = myDB.getConnection;

                    connection.Open(); // Mở kết nối

                    // Query Staff Infomation
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@maUD", appid); // Gán giá trị cho tham số

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
                        tb_Id.Text = dr["MaUngDung"].ToString(); // Gán giá trị Mã NV vào TextBox
                        tb_Name.Text = dr["TenUngDung"].ToString();
                        tb_Discount.Text = dr["ChietKhau"].ToString();
            
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
