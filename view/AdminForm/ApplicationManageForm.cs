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
    public partial class ApplicationManageForm : Form
    {
        public ApplicationManageForm()
        {
            InitializeComponent();
        }
        private MY_DB myDB = new MY_DB();
        private void btn_add_Click(object sender, EventArgs e)
        {
            ApplicationInformation appInformation = new ApplicationInformation();
            appInformation.ShowDialog();
        }

        private void dgv_listProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                int id = Convert.ToInt32(dgv_listApplication.Rows[e.RowIndex].Cells["col_Id"].Value);
                if (dgv_listApplication.Columns[e.ColumnIndex].Name == "col_Edit")
                {
                    ApplicationInformation appInformation = new ApplicationInformation(id);
                    appInformation.ShowDialog();

                }
                if (dgv_listApplication.Columns[e.ColumnIndex].Name == "col_Delete")
                {
                    DialogResult result = MessageBox.Show(
                        "Bạn có chắc chắn muốn xóa ứng dụng này?",
                        "Xác nhận xóa",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (result == DialogResult.Yes)
                    {
                        SqlConnection connection = myDB.getConnection;
                        SqlCommand command = new SqlCommand("XoaUngDung", connection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        // Thêm tham số cho stored procedure
                        command.Parameters.Add(new SqlParameter("@MaUD", id));

                        try
                        {
                            connection.Open();  // Mở kết nối
                            command.ExecuteNonQuery();  // Thực thi stored procedure
                            MessageBox.Show("Xóa thành công.");

                            // Xóa hàng khỏi DataGridView
                            dgv_listApplication.Rows.RemoveAt(e.RowIndex);
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

        private void ApplicationManageForm_Load(object sender, EventArgs e)
        {
            loadApplication();
            cbb_search.Items.Clear();
            cbb_search.Items.Add("Mã ứng dụng");
            cbb_search.Items.Add("Tên ứng dụng");
        }

        private void loadApplication()
        {
            String query = @"SELECT * FROM UNG_DUNG";
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
                        dgv_listApplication.Rows.Add(rowData); // Thêm vào DataGridView
                    }
                }
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            if (cbb_search.SelectedItem == null || string.IsNullOrWhiteSpace(tb_search.Text))
            {
                MessageBox.Show("Vui lòng chọn tiêu chí tìm kiếm và nhập từ khóa.");
                return;
            }

            // Khởi tạo câu truy vấn SQL dựa trên lựa chọn trong ComboBox
            string query = "SELECT * FROM UNG_DUNG WHERE ";
            string searchValue = tb_search.Text;

            if (cbb_search.SelectedItem.ToString() == "Mã ứng dụng")
            {
                query += "MaUngDung = @SearchValue";
            }
            else if (cbb_search.SelectedItem.ToString() == "Tên ứng dụng")
            {
                query += "TenUngDung LIKE '%' + @SearchValue + '%'";
            }

            try
            {
                SqlConnection conn = myDB.getConnection;
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SearchValue", searchValue);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();

                    // Thực hiện truy vấn và điền dữ liệu vào DataTable
                    adapter.Fill(dataTable);

                    // Kiểm tra kết quả tìm kiếm
                    if (dataTable.Rows.Count > 0)
                    {
                        dgv_listApplication.Rows.Clear(); // Xóa các hàng hiện tại trên DataGridView
                        foreach (DataRow row in dataTable.Rows)
                        {
                            object[] rowData = row.ItemArray;
                            dgv_listApplication.Rows.Add(rowData); // Thêm dữ liệu vào DataGridView
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không có dữ liệu phù hợp.");
                    }
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}");
            }

        }

        private void cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
           
          
        }
    }
}
