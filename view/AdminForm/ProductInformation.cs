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
    public partial class ProductInformation : Form
    {
        private int proid;
        private bool isEdit = false;
        private MY_DB myDB = new MY_DB();
        public ProductInformation(int proid)
        {
            InitializeComponent();
            this.proid = proid;
            isEdit = true;
            btn_Add.Visible = false;
        }

        public ProductInformation()
        {
            InitializeComponent();
            btn_Edit.Visible = false;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                // Input validation
                if (string.IsNullOrWhiteSpace(tb_Name.Text) || string.IsNullOrWhiteSpace(tb_State.Text))
                {
                    MessageBox.Show("Tên sản phẩm và trạng thái không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(tb_Price.Text, out int price))
                {
                    MessageBox.Show("Giá sản phẩm không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Get the database connection
                using (SqlConnection conn = myDB.getConnection)
                {
                    myDB.openConnection(); // Open connection

                    // Create the SqlCommand for the stored procedure
                    using (SqlCommand cmd = new SqlCommand("InsertSanPham", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Add parameters
                        cmd.Parameters.AddWithValue("@TenSP", tb_Name.Text);
                        cmd.Parameters.AddWithValue("@Gia", price);
                        cmd.Parameters.AddWithValue("@TinhTrang", tb_State.Text);

                        // Execute the command
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Thêm sản phẩm thành công", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Show error message
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            try
            {
                // Input validation
                if (string.IsNullOrWhiteSpace(tb_Name.Text) || string.IsNullOrWhiteSpace(tb_State.Text))
                {
                    MessageBox.Show("Tên sản phẩm và trạng thái không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(tb_Id.Text, out int productId))
                {
                    MessageBox.Show("Mã sản phẩm không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(tb_Price.Text, out int price))
                {
                    MessageBox.Show("Giá sản phẩm không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(tb_Quantity.Text, out int quantity))
                {
                    MessageBox.Show("Số lượng sản phẩm không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Get the database connection
                using (SqlConnection conn = myDB.getConnection)
                {
                    myDB.openConnection(); // Open connection

                    // Create the SqlCommand for the stored procedure
                    using (SqlCommand cmd = new SqlCommand("UpdateSanPham", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Add parameters
                        cmd.Parameters.AddWithValue("@MaSP", productId);
                        cmd.Parameters.AddWithValue("@TenSP", tb_Name.Text);
                        cmd.Parameters.AddWithValue("@Gia", price);
                        cmd.Parameters.AddWithValue("@SoLuong", quantity);
                        cmd.Parameters.AddWithValue("@TinhTrang", tb_State.Text);

                        // Execute the command
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Cập nhật sản phẩm thành công", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        private void ProductInformation_Load(object sender, EventArgs e)
        {
            if (isEdit)
            {
                String query = @"SELECT * FROM SAN_PHAM WHERE MaSP = @maSP";
                try
                {
                    int maSP;
                    SqlConnection connection = myDB.getConnection;

                    connection.Open(); // Mở kết nối

                    // Query Staff Infomation
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@maSP", proid); // Gán giá trị cho tham số

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
                        tb_Id.Text = dr["MaSP"].ToString(); // Gán giá trị Mã NV vào TextBox
                        tb_Name.Text = dr["TenSP"].ToString();
                        tb_Price.Text = dr["Gia"].ToString();
                        tb_Quantity.Text = dr["SoLuong"].ToString();
                        tb_State.Text = dr["TinhTrang"].ToString();
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
