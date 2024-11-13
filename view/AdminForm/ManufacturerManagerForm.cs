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
    public partial class ManufacturerManagerForm : Form
    {
        public ManufacturerManagerForm()
        {
            InitializeComponent();

        }

        private MY_DB myDB = new MY_DB();

        private void ManufacturerManagerForm_Load(object sender, EventArgs e)
        {
            loadManufacturer();
            cbb_search.Items.Clear();
            cbb_search.Items.Add("Mã nhà sản xuất");
            cbb_search.Items.Add("Tên nhà sản xuất");
            cbb_search.Items.Add("Số điện thoại");
        }

        private void loadManufacturer()
        {
            String query = @"SELECT * FROM NHA_SAN_XUAT";
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
                        dgv_listManufacturer.Rows.Add(rowData); // Thêm vào DataGridView
                    }
                }
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dgv_listManufacturer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                int id = Convert.ToInt32(dgv_listManufacturer.Rows[e.RowIndex].Cells["col_Id"].Value);
                if (dgv_listManufacturer.Columns[e.ColumnIndex].Name == "col_Edit")
                {
                    ManufacturerInformation manuInformation = new ManufacturerInformation(id);
                    manuInformation.ShowDialog();

                }
                if (dgv_listManufacturer.Columns[e.ColumnIndex].Name == "col_Delete")
                {
                    DialogResult result = MessageBox.Show(
                        "Bạn có chắc chắn muốn xóa nhà sản xuất này?",
                        "Xác nhận xóa",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (result == DialogResult.Yes)
                    {
                        SqlConnection connection = myDB.getConnection;
                        SqlCommand command = new SqlCommand("XoaNhaSanXuat", connection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        // Thêm tham số cho stored procedure
                        command.Parameters.Add(new SqlParameter("@MaNSX", id));

                        try
                        {
                            connection.Open();  // Mở kết nối
                            command.ExecuteNonQuery();  // Thực thi stored procedure
                            MessageBox.Show("Xóa thành công.");

                            // Xóa hàng khỏi DataGridView
                            dgv_listManufacturer.Rows.RemoveAt(e.RowIndex);
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
            ManufacturerInformation manuInformation = new ManufacturerInformation();
            manuInformation.ShowDialog();
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

                // Kiểm tra giá trị của ComboBox để tìm kiếm theo tiêu chí
                if (searchColumn == "Mã nhà sản xuất")
                {
                    query = "select * from fnSearchManufacturerByMaNSX(@MaNSX)"; // Tên Stored Procedure tìm kiếm theo mã khách hàng
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaNSX", tb_search.Text);
                }
                else if (searchColumn == "Tên nhà sản xuất")
                {
                    query = "select * from fnSearchManufacturerByName(@TenNSX)"; // Tên Stored Procedure tìm kiếm theo tên khách hàng
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@TenNSX", tb_search.Text);
                }
                else if (searchColumn == "Số điện thoại")
                {
                    query = "select * from fnSearchManufacturerBySDT(@SDT)"; // Tên Stored Procedure tìm kiếm theo số điện thoại
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@SDT", tb_search.Text);
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
                    dgv_listManufacturer.Rows.Clear(); // Xóa các hàng cũ trước khi thêm dữ liệu mới
                    foreach (DataRow row in dataTable.Rows)
                    {
                        object[] rowData = row.ItemArray;
                        dgv_listManufacturer.Rows.Add(rowData); // Thêm dữ liệu vào DataGridView
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
