using System;
using System.Collections;
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
    public partial class CustomerProduct : Form
    {
        private int id;
        public CustomerProduct(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private MY_DB myDB = new MY_DB();

        private void CustomerProduct_Load(object sender, EventArgs e)
        {
            String query = @"
    SELECT 
        MaSPDonHang,
        MaSP, 
        TenSP, 
        Gia, 
        SoLuong
    FROM 
        vw_SanPhamDonHang
    WHERE 
        MaDH = @MaDH";  // Sử dụng View với MaDH

            SqlConnection connection = null;

            try
            {
                connection = myDB.getConnection; // Lấy kết nối
                connection.Open(); // Mở kết nối

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaDH", id); // Gán giá trị cho tham số MaDH

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable); // Lấy dữ liệu từ view và đưa vào DataTable

                    dgv_listOrder.Rows.Clear(); // Xóa các hàng cũ trong DataGridView

                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Tạo mảng dữ liệu để thêm vào DataGridView
                        object[] rowData = row.ItemArray;

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
                int pro_id = Convert.ToInt32(dgv_listOrder.Rows[e.RowIndex].Cells["col_selectedPro"].Value);
                if (dgv_listOrder.Columns[e.ColumnIndex].Name == "col_Edit")
                {
                    CustomerEditProduct customerEditProduct = new CustomerEditProduct(pro_id);
                    customerEditProduct.ShowDialog();
                }
                else if (dgv_listOrder.Columns[e.ColumnIndex].Name == "col_Delete")
                {

                    deleteProductFromOrder(pro_id);
                }
            }
        }

        public void deleteProductFromOrder(int pro_id)
        {
            try
            {
                // Hiển thị hộp thoại xác nhận xóa
                DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm đã chọn không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dr == DialogResult.Yes)
                {
                    SqlConnection connection = myDB.getConnection;
                    
                    connection.Open(); // Mở kết nối

                    using (SqlCommand command = new SqlCommand("DELETE FROM SAN_PHAM_DUOC_CHON WHERE MaSPDonHang = @MaSPDonHang", connection))
                    {
                        // Thêm tham số vào câu lệnh SQL
                        command.Parameters.AddWithValue("@MaSPDonHang", pro_id);

                        // Thực thi câu lệnh xóa
                        int rowsAffected = command.ExecuteNonQuery();

                        // Kiểm tra số dòng bị ảnh hưởng
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Xóa sản phẩm thành công.");
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy sản phẩm để xóa.");
                        }
                    }
                    
                }
                else
                {
                    MessageBox.Show("Hành động xóa đã bị hủy.");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
