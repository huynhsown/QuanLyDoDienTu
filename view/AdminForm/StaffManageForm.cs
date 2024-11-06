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
    public partial class StaffManageForm : Form
    {
        private MY_DB myDB = new MY_DB();
        public StaffManageForm()
        {
            InitializeComponent();
        }

        private void StaffManageForm_Load(object sender, EventArgs e)
        {
            string query = @"SELECT * FROM vw_StaffDetails";
            try
            {
                SqlConnection connection = myDB.getConnection;

                connection.Open(); // Mở kết nối

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable); // Điền kết quả vào DataTable

                    foreach (DataRow row in dataTable.Rows)
                    {
                        object[] rowData = row.ItemArray;

                        // Kiểm tra nếu cột "NgaySinh" là kiểu DateTime
                        int birthDateColumnIndex = dataTable.Columns["NgaySinh"].Ordinal;
                        if (rowData[birthDateColumnIndex] is DateTime birthDate)
                        {
                            // Định dạng ngày thành dd/MM/yyyy
                            rowData[birthDateColumnIndex] = birthDate.ToString("dd/MM/yyyy");
                        }
                        dgv_listStaff.Rows.Add(rowData); // Thêm vào DataGridView
                    }
                }
                connection.Close(); // Đóng kết nối

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            cbb_search.Items.Clear();
            cbb_search.Items.Add("Mã nhân viên");
            cbb_search.Items.Add("Tên nhân viên");
            cbb_search.Items.Add("Số điện thoại");


        }

        private void dgv_listStaff_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_addStaff_Click(object sender, EventArgs e)
        {
            StaffInformation staffInformation = new StaffInformation(false);
            staffInformation.ShowDialog();
        }

        private void dgv_listStaff_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (dgv_listStaff.Columns[e.ColumnIndex].Name == "col_Edit")
                {
                    int id = Convert.ToInt32(dgv_listStaff.Rows[e.RowIndex].Cells["col_Id"].Value);
                    StaffInformation staffInformation = new StaffInformation(id);
                    staffInformation.ShowDialog();
                }
                else if (dgv_listStaff.Columns[e.ColumnIndex].Name == "col_delete")
                {
                    int id = Convert.ToInt32(dgv_listStaff.Rows[e.RowIndex].Cells["col_Id"].Value);
                }

                else if (dgv_listStaff.Columns[e.ColumnIndex].Name == "col_workShift")
                {
                    int id = Convert.ToInt32(dgv_listStaff.Rows[e.RowIndex].Cells["col_Id"].Value);

                    StaffWorkShiftManageForm staffWorkShiftManageForm = new StaffWorkShiftManageForm(id);
                    staffWorkShiftManageForm.ShowDialog();
                }
            }
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
                if (searchColumn == "Mã nhân viên")
                {
                    query = "SearchEmployeeByMaNV"; // Tên Stored Procedure tìm kiếm theo mã khách hàng
                    cmd = new SqlCommand(query, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaNV", tb_search.Text);
                }
                else if (searchColumn == "Tên nhân viên")
                {
                    query = "SearchEmployeeByTenNV"; // Tên Stored Procedure tìm kiếm theo tên khách hàng
                    cmd = new SqlCommand(query, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TenNV", tb_search.Text);
                }
                else if (searchColumn == "Số điện thoại")
                {
                    query = "SearchEmployeeBySDT"; // Tên Stored Procedure tìm kiếm theo số điện thoại
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
                    dgv_listStaff.Rows.Clear(); // Xóa các hàng cũ trước khi thêm dữ liệu mới
                    foreach (DataRow row in dataTable.Rows)
                    {
                        object[] rowData = row.ItemArray;
                        dgv_listStaff.Rows.Add(rowData); // Thêm dữ liệu vào DataGridView
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

        private void cbb_search_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
