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
    public partial class CustomerHistory : Form
    {
        private int id;
        private MY_DB myDB = new MY_DB();
        public CustomerHistory(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void CustomerHistory_Load(object sender, EventArgs e)
        {
            String query = @"
    SELECT 
        DH.MaDH, 
        DH.NgayDatHang, 
        DH.TrangThaiDonHang, 
        DH.TriGia, 
        U.MaUngDung,  
        U.TenUngDung  
    FROM 
        DON_HANG DH
    JOIN 
        UNG_DUNG U ON DH.MaUngDung = U.MaUngDung
    WHERE 
        DH.MaKH = @MaKH;";  // Query for orders based on customer ID

            SqlConnection connection = null;

            try
            {
                connection = myDB.getConnection; // Get the connection
                connection.Open(); // Open the connection

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaKH", id); // Set the parameter for the query

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable); // Fill the DataTable with query result

                    dgv_listOrder.Rows.Clear(); // Clear existing rows in DataGridView

                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create an array without the application ID
                        object[] rowData = new object[]
                        {
                row["MaDH"],              // Order ID
                row["NgayDatHang"],       // Order Date
                row["TrangThaiDonHang"],  // Order Status
                row["TriGia"],            // Total Value
                row["TenUngDung"]         // Application Name
                        };

                        dgv_listOrder.Rows.Add(rowData); // Add to DataGridView
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Ensure the connection is closed
                if (connection != null)
                {
                    connection.Close();
                }
            }

        }

        private void dgv_listOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                int id = Convert.ToInt32(dgv_listOrder.Rows[e.RowIndex].Cells["col_Id"].Value);
                if (dgv_listOrder.Columns[e.ColumnIndex].Name == "col_Edit")
                {
                    CustomerProduct customerProduct = new CustomerProduct(id);
                    customerProduct.ShowDialog();

                }
                else if (dgv_listOrder.Columns[e.ColumnIndex].Name == "col_delete")
                {
                    String state = dgv_listOrder.Rows[e.RowIndex].Cells["col_State"].Value.ToString().Trim();
                    if (state.Equals("Đã giao") || state.Equals("Đã hủy"))
                    {

                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa đơn hàng này?",
                                                    "Xác nhận xóa đơn",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {

                        }
                    }
                }
                else if (dgv_listOrder.Columns[e.ColumnIndex].Name == "col_history")
                {

                }
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            CustomerAddProduct customerAddProduct = new CustomerAddProduct(id);
            customerAddProduct.ShowDialog();
        }
    }
}
