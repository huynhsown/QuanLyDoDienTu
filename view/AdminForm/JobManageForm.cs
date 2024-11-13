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
            String query = "select * from fnGetAllJobs()"; // Tên stored procedure
            try
            {
                SqlConnection connection = myDB.getConnection;
                connection.Open(); // Mở kết nối

                using (SqlCommand command = new SqlCommand(query, connection))
                {

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
            cbb_search.Items.Clear();
            cbb_search.Items.Add("Mã công việc");
            cbb_search.Items.Add("Tên công việc");
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
                if (searchColumn == "Mã công việc")
                {
                    query = "select * from dbo.fnGetJobByMaCV(@MaCV)"; 
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaCv", tb_search.Text);
                }
                else if (searchColumn == "Tên công việc")
                {
                    query = "select * from dbo.fnGetJobsByTenCV(@TenCV)"; // Tên Stored Procedure tìm kiếm theo tên khách hàng
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@TenCV", tb_search.Text);
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
                    dgv_listJob.Rows.Clear(); // Xóa các hàng cũ trước khi thêm dữ liệu mới
                    foreach (DataRow row in dataTable.Rows)
                    {
                        object[] rowData = row.ItemArray;
                        dgv_listJob.Rows.Add(rowData); // Thêm dữ liệu vào DataGridView
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
