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
    public partial class PurchaseOrderManageForm : Form
    {
        private MY_DB myDB = new MY_DB();
        public PurchaseOrderManageForm()
        {
            InitializeComponent();
        }

        private void btn_addStaff_Click(object sender, EventArgs e)
        {
            PurchaseOrderInformation purchaseOrderInformation = new PurchaseOrderInformation();
            purchaseOrderInformation.ShowDialog();

        }

        private void dgv_listStaff_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                int id = Convert.ToInt32(dgv_listPurchaseOrder.Rows[e.RowIndex].Cells["col_Id"].Value);

                if (dgv_listPurchaseOrder.Columns[e.ColumnIndex].Name == "col_Edit")
                {
                    PurchaseOrderInformation info = new PurchaseOrderInformation(id);
                    info.ShowDialog();

                }
                if (dgv_listPurchaseOrder.Columns[e.ColumnIndex].Name == "col_delete")
                {
                    DialogResult result = MessageBox.Show(
                        "Bạn có chắc chắn muốn xóa đơn nhập hàng này?",
                        "Xác nhận xóa",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (result == DialogResult.Yes)
                    {
                        SqlConnection connection = myDB.getConnection;
                        SqlCommand command = new SqlCommand("XoaDonNhapHang", connection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        // Thêm tham số cho stored procedure
                        command.Parameters.Add(new SqlParameter("@MaDon", id));

                        try
                        {
                            connection.Open();  // Mở kết nối
                            command.ExecuteNonQuery();  // Thực thi stored procedure
                            MessageBox.Show("Xóa thành công.");

                            // Xóa hàng khỏi DataGridView
                            dgv_listPurchaseOrder.Rows.RemoveAt(e.RowIndex);
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

        private void PurchaseOrder_Load(object sender, EventArgs e)
        {
            string query = "select * from fnGetAllPurchaseOrder()";
            try
            {
                SqlConnection connection = myDB.getConnection;
                connection.Open(); // Open the connection

                SqlCommand command = new SqlCommand(query, connection);
                { 
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable); // Fill the DataTable with query result

                    foreach (DataRow row in dataTable.Rows)
                    {
                        object[] rowData = row.ItemArray;
                        dgv_listPurchaseOrder.Rows.Add(rowData); // Thêm vào DataGridView
                    }
                }
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
