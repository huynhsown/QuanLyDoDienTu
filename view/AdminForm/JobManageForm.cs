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
    public partial class JobManageForm : Form
    {
        private MY_DB myDB = new MY_DB();
        public JobManageForm()
        {
            InitializeComponent();

        }

        private void loadJob()
        {
            String query = "sp_GetAllJobs"; // Tên stored procedure
            try
            {
                SqlConnection connection = myDB.getConnection;
                connection.Open(); // Mở kết nối

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.StoredProcedure; // Thiết lập kiểu là stored procedure

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable); // Lấy dữ liệu từ stored procedure vào DataTable

                    foreach (DataRow row in dataTable.Rows)
                    {
                        object[] rowData = row.ItemArray;
                        dgv_listJob.Rows.Add(rowData); // Thêm dữ liệu vào DataGridView
                    }
                }
                connection.Close(); // Đóng kết nối

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void JobManageForm_Load(object sender, EventArgs e)
        {
            loadJob();
        }

        private void dgv_listJob_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                int id = Convert.ToInt32(dgv_listJob.Rows[e.RowIndex].Cells["col_Id"].Value);
                if (dgv_listJob.Columns[e.ColumnIndex].Name == "col_Edit")
                {
                    JobInformation jobInformation = new JobInformation(id);
                    jobInformation.ShowDialog();

                }
                if (dgv_listJob.Columns[e.ColumnIndex].Name == "col_Delete")
                {
                    DialogResult result = MessageBox.Show(
                        "Bạn có chắc chắn muốn xóa công việc này?",
                        "Xác nhận xóa",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (result == DialogResult.Yes)
                    {
                        SqlConnection connection = myDB.getConnection;
                        SqlCommand command = new SqlCommand("XoaCongViec", connection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        // Thêm tham số cho stored procedure
                        command.Parameters.Add(new SqlParameter("@MaCV", id));

                        try
                        {
                            connection.Open();  // Mở kết nối
                            command.ExecuteNonQuery();  // Thực thi stored procedure
                            MessageBox.Show("Xóa thành công.");

                            // Xóa hàng khỏi DataGridView
                            dgv_listJob.Rows.RemoveAt(e.RowIndex);
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
            JobInformation jobInformation = new JobInformation();
            jobInformation.ShowDialog();
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = myDB.getConnection;
                conn.Open();

                // Use the stored procedure instead of inline SQL
                using (SqlCommand cmd = new SqlCommand("spGetJobsByTenCV", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Add parameter for the stored procedure
                    cmd.Parameters.AddWithValue("@TenCV", tb_search.Text.Trim());

                    // Execute the query and fill the DataTable
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Populate the DataGridView with the results
                    if (dataTable.Rows.Count > 0)
                    {
                        dgv_listJob.Rows.Clear(); // Clear existing rows
                        foreach (DataRow row in dataTable.Rows)
                        {
                            dgv_listJob.Rows.Add(row.ItemArray); // Add new rows
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không có dữ liệu"); // No data found
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message); // Display any exceptions
            }
        }
    }
}
