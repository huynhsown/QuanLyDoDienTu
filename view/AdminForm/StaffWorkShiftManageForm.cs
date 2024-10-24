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
            String query = "SELECT CLV.MaCa, CLV.ThoiGianBatDau, CLV.ThoiGianKetThuc, CV.TenCV AS TenCongViec FROM CA_LAM_VIEC CLV JOIN NHAN_VIEN NV ON CLV.MaNV = NV.MaNV JOIN CONG_VIEC CV ON NV.MaCV = CV.MaCV WHERE NV.MaNV = @maNV";

            try
            {
                SqlConnection connection = myDB.getConnection;
                
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                    
                command.Parameters.AddWithValue("@maNV", staffid);
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable); // Fill the DataTable with query result

                foreach (DataRow row in dataTable.Rows)
                {
                    object[] rowData = row.ItemArray;
                    dgv_listWorkShift.Rows.Add(rowData); // Thêm vào DataGridView
                        
                }
                
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
            }



        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = myDB.getConnection;
                conn.Open();

                string query = "SELECT * FROM CA_LAM_VIEC WHERE TenCV LIKE '%' + @tencalamviec + '%'";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tencalamviec", tb_search.Text);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();

                // Fill the DataTable with the query result
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    dgv_listWorkShift.Rows.Clear(); // Clear DataGridView rows before adding new ones
                    foreach (DataRow row in dataTable.Rows)
                    {
                        object[] rowData = row.ItemArray;
                        dgv_listWorkShift.Rows.Add(rowData); // Add data to DataGridView
                    }
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu");
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
