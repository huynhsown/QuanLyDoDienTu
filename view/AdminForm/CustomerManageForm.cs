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
            String query = @"SELECT * FROM KHACH_HANG;
";
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
                        dgv_listStaff.Rows.Add(rowData); // Thêm vào DataGridView
                    }
                }
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgv_listStaff_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                int id = Convert.ToInt32(dgv_listStaff.Rows[e.RowIndex].Cells["col_Id"].Value);
                if (dgv_listStaff.Columns[e.ColumnIndex].Name == "col_Edit")                {
                    
                    CustomerInformation customerInformation = new CustomerInformation(id);
                    customerInformation.ShowDialog();
                }
                else if (dgv_listStaff.Columns[e.ColumnIndex].Name == "col_delete")
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
                else if(dgv_listStaff.Columns[e.ColumnIndex].Name == "col_history"){
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
    }
}
