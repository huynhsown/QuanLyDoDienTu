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
            String query = @"SELECT MaDH, NgayDatHang, TrangThaiDonHang, TriGia, TenUngDung 
                FROM vw_DonHangByKhachHang 
                WHERE MaKH = @MaKH";  // Sử dụng View với MaKH

            SqlConnection connection = null;

            try
            {
                connection = myDB.getConnection; // Lấy kết nối
                connection.Open(); // Mở kết nối

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaKH", id); // Gán giá trị cho tham số

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable); // Lấy dữ liệu từ view và đưa vào DataTable

                    dgv_listOrder.Rows.Clear(); // Xóa các hàng cũ trong DataGridView

                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Tạo mảng dữ liệu để thêm vào DataGridView
                        object[] rowData = new object[]
                        {
                row["MaDH"],              // Mã đơn hàng
                row["NgayDatHang"],       // Ngày đặt hàng
                row["TrangThaiDonHang"],  // Trạng thái đơn hàng
                row["TriGia"],            // Trị giá
                row["TenUngDung"]         // Tên ứng dụng
                        };

                        dgv_listOrder.Rows.Add(rowData); // Thêm dữ liệu vào DataGridView
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Đảm bảo kết nối luôn được đóng
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
