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
    public partial class StaffWorkShiftManageForm : Form
    {
        private int staffid;
        private MY_DB myDB = new MY_DB();
        public StaffWorkShiftManageForm(int staffid)
        {
            InitializeComponent();
            this.staffid = staffid;

        }



        private void btn_addJob_Click(object sender, EventArgs e)
        {
            StatffWorkshiftInformation workshiftInformation = new StatffWorkshiftInformation(staffid, false);
            workshiftInformation.ShowDialog();
        }

        private void StaffWorkShiftManageForm_Load(object sender, EventArgs e)
        {
            String query = "SELECT MaCa, ThoiGianBatDau, ThoiGianKetThuc, TenCongViec FROM vw_WorkShiftDetails WHERE MaNV = @maNV";

            SqlConnection connection = myDB.getConnection; // Lấy kết nối từ myDB

            try
            {
                connection.Open(); // Mở kết nối

                SqlCommand command = new SqlCommand(query, connection); // Tạo SqlCommand với truy vấn
                command.Parameters.AddWithValue("@maNV", staffid); // Thêm tham số cho truy vấn

                SqlDataAdapter adapter = new SqlDataAdapter(command); // Tạo SqlDataAdapter
                DataTable dataTable = new DataTable(); // Tạo DataTable để lưu kết quả
                adapter.Fill(dataTable); // Điền DataTable với dữ liệu từ VIEW

                if (dataTable.Rows.Count > 0)
                {
                    dgv_listWorkShift.Rows.Clear(); // Xóa các hàng hiện có trước khi thêm dữ liệu mới

                    foreach (DataRow row in dataTable.Rows)
                    {
                        object[] rowData = row.ItemArray; // Lấy dữ liệu từ hàng
                        dgv_listWorkShift.Rows.Add(rowData); // Thêm dữ liệu vào DataGridView
                    }
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); // Hiển thị thông báo lỗi
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close(); // Đảm bảo kết nối được đóng
                }
            }

        }

        private void dgv_listWorkShift_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                int workshiftid = Convert.ToInt32(dgv_listWorkShift.Rows[e.RowIndex].Cells["col_Id"].Value);

                // Xử lý khi nhấn vào cột "Edit"
                if (dgv_listWorkShift.Columns[e.ColumnIndex].Name == "col_Edit")
                {
                    StatffWorkshiftInformation workshiftInformation = new StatffWorkshiftInformation(workshiftid);
                    workshiftInformation.ShowDialog();
                }

                // Xử lý khi nhấn vào cột "Delete"
                if (dgv_listWorkShift.Columns[e.ColumnIndex].Name == "col_delete")
                {
                    DialogResult result = MessageBox.Show(
                        "Bạn có chắc chắn muốn xóa ca làm việc này?",
                        "Xác nhận xóa",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (result == DialogResult.Yes)
                    {
                        SqlConnection connection = myDB.getConnection;
                        SqlCommand command = new SqlCommand("XoaCaLamViec", connection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        // Thêm tham số cho stored procedure
                        command.Parameters.Add(new SqlParameter("@MaCa", workshiftid));

                        try
                        {
                            connection.Open();  // Mở kết nối
                            command.ExecuteNonQuery();  // Thực thi stored procedure
                            MessageBox.Show("Xóa thành công.");

                            // Xóa hàng khỏi DataGridView
                            dgv_listWorkShift.Rows.RemoveAt(e.RowIndex);
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
                if (dgv_listWorkShift.Columns[e.ColumnIndex].Name == "col_delete")
                {
                    

                }
            }



        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = myDB.getConnection; // Lấy kết nối từ myDB
                conn.Open(); // Mở kết nối

                string procedureName = "sp_SearchWorkShiftByMaCa"; // Tên của Stored Procedure
                SqlCommand cmd = new SqlCommand(procedureName, conn); // Tạo SqlCommand với tên Stored Procedure
                cmd.CommandType = CommandType.StoredProcedure; // Đặt loại lệnh là Stored Procedure

                // Thêm tham số cho Stored Procedure
                cmd.Parameters.AddWithValue("@MaCa", int.Parse(tb_search.Text)); // Giả sử tb_search chứa mã ca

                SqlDataAdapter adapter = new SqlDataAdapter(cmd); // Tạo SqlDataAdapter
                DataTable dataTable = new DataTable(); // Tạo DataTable để lưu kết quả

                // Điền DataTable với kết quả từ Stored Procedure
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    dgv_listWorkShift.Rows.Clear(); // Xóa các hàng hiện có trước khi thêm dữ liệu mới
                    foreach (DataRow row in dataTable.Rows)
                    {
                        object[] rowData = row.ItemArray; // Lấy dữ liệu từ hàng
                        dgv_listWorkShift.Rows.Add(rowData); // Thêm dữ liệu vào DataGridView
                    }
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu"); // Thông báo nếu không có dữ liệu
                }

                conn.Close(); // Đóng kết nối
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); // Hiển thị thông báo lỗi
            }

        }
    }
}
