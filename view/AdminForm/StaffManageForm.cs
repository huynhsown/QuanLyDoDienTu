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
            string query = @"SELECT NV.MaNV, NV.HoTen, FORMAT(NV.NgaySinh, 'dd/MM/yyyy') AS NgaySinh, NV.GioiTinh, NV.SDT, NV.Email, NV.DiaChi, CV.TenCV FROM NHAN_VIEN NV JOIN CONG_VIEC CV ON NV.MaCV = CV.MaCV;";
            try
            {
                using (SqlConnection connection = myDB.getConnection)
                {
                    connection.Open(); // Open the connection

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable); // Fill the DataTable with query result

                        foreach (DataRow row in dataTable.Rows)
                        {
                            object[] rowData = row.ItemArray;

                            // Kiểm tra nếu cột "NgàySinh" là kiểu DateTime
                            int birthDateColumnIndex = dataTable.Columns["NgaySinh"].Ordinal;
                            if (rowData[birthDateColumnIndex] is DateTime birthDate)
                            {
                                // Chuyển định dạng ngày thành dd/MM/yyyy
                                rowData[birthDateColumnIndex] = birthDate.ToString("dd/MM/yyyy");
                            }

                            dgv_listStaff.Rows.Add(rowData); // Thêm vào DataGridView
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
            try
            {
                SqlConnection conn = myDB.getConnection;
                conn.Open();

                string query = "SELECT * FROM NHAN_VIEN  WHERE TenNV LIKE '%' + @tennv + '%'";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tennv", tb_search.Text);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();

                // Fill the DataTable with the query result
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    dgv_listStaff.Rows.Clear(); // Clear DataGridView rows before adding new ones
                    foreach (DataRow row in dataTable.Rows)
                    {
                        object[] rowData = row.ItemArray;
                        dgv_listStaff.Rows.Add(rowData); // Add data to DataGridView
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
