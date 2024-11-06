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
    public partial class CustomerManageForm : Form
    {
        public CustomerManageForm()
        {
            InitializeComponent();
        }

        private MY_DB myDB = new MY_DB();

        private void CustomerManageForm_Load(object sender, EventArgs e)
        {
            string query = "GetAllKhachHang"; // Gọi tên Stored Procedure

            try
            {
                SqlConnection connection = myDB.getConnection;
                connection.Open(); // Mở kết nối

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.StoredProcedure; // Xác định là Stored Procedure

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable); // Lấy dữ liệu từ Stored Procedure và đưa vào DataTable

                    foreach (DataRow row in dataTable.Rows)
                    {
                        object[] rowData = row.ItemArray;
                        dgv_listCustomer.Rows.Add(rowData); // Thêm dữ liệu vào DataGridView
                    }
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            cbb_search.Items.Clear();
            cbb_search.Items.Add("Mã khách hàng");
            cbb_search.Items.Add("Tên khách hàng");
            cbb_search.Items.Add("Số điện thoại");


        }

        private void dgv_listStaff_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                int id = Convert.ToInt32(dgv_listCustomer.Rows[e.RowIndex].Cells["col_Id"].Value);
                if (dgv_listCustomer.Columns[e.ColumnIndex].Name == "col_Edit")
                {

                    CustomerInformation customerInformation = new CustomerInformation(id);
                    customerInformation.ShowDialog();
                }
                else if (dgv_listCustomer.Columns[e.ColumnIndex].Name == "col_delete")
                {
                    SqlConnection connection = myDB.getConnection;

                    using (SqlCommand command = new SqlCommand("XoaKhachHang", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Thêm tham số cho stored procedure
                        command.Parameters.Add(new SqlParameter("@MaKH", id));

                        try
                        {
                            // Mở kết nối
                            connection.Open();

                            // Thực thi stored procedure
                            command.ExecuteNonQuery();

                            MessageBox.Show("Xoa thanh cong");
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show($"Có lỗi xảy ra: {ex.Message}");
                        }
                        finally
                        {
                            // Đảm bảo kết nối được đóng
                            if (connection.State == ConnectionState.Open)
                            {
                                connection.Close();
                            }
                        }
                    }

                }
                else if (dgv_listCustomer.Columns[e.ColumnIndex].Name == "col_history")
                {
                    CustomerHistory customerHistory = new CustomerHistory(id);
                    customerHistory.ShowDialog();
                }
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            CustomerInformation customerInformation = new CustomerInformation();
            customerInformation.ShowDialog();
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng đã chọn tiêu chí tìm kiếm và nhập từ khóa
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
                if (searchColumn == "Mã khách hàng")
                {
                    query = "SearchKhachHangByMaKH"; // Tên Stored Procedure tìm kiếm theo mã khách hàng
                    cmd = new SqlCommand(query, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaKH", tb_search.Text);
                }
                else if (searchColumn == "Tên khách hàng")
                {
                    query = "SearchKhachHangByTenKH"; // Tên Stored Procedure tìm kiếm theo tên khách hàng
                    cmd = new SqlCommand(query, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@HoTen", tb_search.Text);
                }
                else if (searchColumn == "Số điện thoại")
                {
                    query = "SearchKhachHangBySDT"; // Tên Stored Procedure tìm kiếm theo số điện thoại
                    cmd = new SqlCommand(query, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
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
                    dgv_listCustomer.Rows.Clear(); // Xóa các hàng cũ trước khi thêm dữ liệu mới
                    foreach (DataRow row in dataTable.Rows)
                    {
                        object[] rowData = row.ItemArray;
                        dgv_listCustomer.Rows.Add(rowData); // Thêm dữ liệu vào DataGridView
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
