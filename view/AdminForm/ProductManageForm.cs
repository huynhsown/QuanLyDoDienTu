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
    public partial class ProductManageForm : Form
    {
        public ProductManageForm()
        {
            InitializeComponent();
        }

        private MY_DB myDB = new MY_DB();

        private void ProductManageForm_Load(object sender, EventArgs e)
        {
            loadProduct();
            cbb_search.Items.Clear();
            cbb_search.Items.Add("Mã sản phẩm");
            cbb_search.Items.Add("Tên sản phẩm");
        }

        private void loadProduct()
        {
            String query = @"SELECT * FROM SAN_PHAM";
            try
            {
                SqlConnection connection = myDB.getConnection;
                connection.Open(); // Open the connection

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable); // Fill the DataTable with query result

                    foreach (DataRow row in dataTable.Rows)
                    {
                        object[] rowData = row.ItemArray;
                        dgv_listProduct.Rows.Add(rowData); // Thêm vào DataGridView
                    }
                }
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dgv_listProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                int id = Convert.ToInt32(dgv_listProduct.Rows[e.RowIndex].Cells["col_Id"].Value);
                if (dgv_listProduct.Columns[e.ColumnIndex].Name == "col_Edit")
                {
                    ProductInformation productInformation = new ProductInformation(id);
                    productInformation.ShowDialog();

                }
                if (dgv_listProduct.Columns[e.ColumnIndex].Name == "col_Delete")
                {
                    DialogResult result = MessageBox.Show(
                        "Bạn có chắc chắn muốn xóa sản phẩm này?",
                        "Xác nhận xóa",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (result == DialogResult.Yes)
                    {
                        SqlConnection connection = myDB.getConnection;
                        SqlCommand command = new SqlCommand("XoaSanPham", connection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        // Thêm tham số cho stored procedure
                        command.Parameters.Add(new SqlParameter("@MaSP", id));

                        try
                        {
                            connection.Open();  // Mở kết nối
                            command.ExecuteNonQuery();  // Thực thi stored procedure
                            MessageBox.Show("Xóa thành công.");

                            // Xóa hàng khỏi DataGridView
                            dgv_listProduct.Rows.RemoveAt(e.RowIndex);
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show($"Có lỗi xảy ra: {ex.Message}");
                        }
                        finally
                        {
                            // Đảm bảo đóng kết nối và giải phóng tài nguyên
                            if (connection.State == ConnectionState.Open)
                            {
                                connection.Close();
                            }

                            command.Dispose();  // Giải phóng tài nguyên của SqlCommand
                        }
                    }
                }
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            ProductInformation productInformation = new ProductInformation();
            productInformation.ShowDialog();
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            if (cbb_search.SelectedItem == null || string.IsNullOrWhiteSpace(tb_search.Text))
            {
                MessageBox.Show("Vui lòng chọn tiêu chí tìm kiếm và nhập từ khóa.");
                return;
            }

            string query = string.Empty; // Tên Stored Procedure hoặc câu truy vấn
            string searchColumn = cbb_search.SelectedItem.ToString(); // Lấy giá trị từ ComboBox

            try
            {
                SqlConnection conn = myDB.getConnection;
                conn.Open();

                SqlCommand cmd;

                if (searchColumn == "Mã sản phẩm")
                {
                    query = "select * from fnSearchProductByMaSP(@MaSP)";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaSP", tb_search.Text);
                }
                else if (searchColumn == "Tên sản phẩm")
                {
                    query = "select * from fnSearchProductByName(@TenSP)"; 
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@TenSP", tb_search.Text);
                }
               
                else
                {
                    MessageBox.Show("Không có tiêu chí tìm kiếm phù hợp.");
                    return;
                }


                // Thực hiện truy vấn và hiển thị kết quả
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    dgv_listProduct.Rows.Clear(); // Xóa các hàng cũ trước khi thêm dữ liệu mới
                    foreach (DataRow row in dataTable.Rows)
                    {
                        object[] rowData = row.ItemArray;
                        dgv_listProduct.Rows.Add(rowData); // Thêm dữ liệu vào DataGridView
                    }
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu phù hợp.");
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}



