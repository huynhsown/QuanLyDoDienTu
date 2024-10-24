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
    public partial class CustomerEditProduct : Form
    {
        private int proid;
        public CustomerEditProduct(int proid)
        {
            InitializeComponent();
            this.proid = proid;
        }

        private MY_DB myDB = new MY_DB();
        private void CustomerEditProduct_Load(object sender, EventArgs e)
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
                    MaSPDonHang = @MaSPDH";  // Sử dụng View với MaSPDonHang

            SqlConnection connection = null;

            try
            {
                connection = myDB.getConnection; // Lấy kết nối
                connection.Open(); // Mở kết nối

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaSPDH", proid); // Gán giá trị cho tham số MaSPDonHang

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable); // Lấy dữ liệu từ view và đưa vào DataTable

                    // Kiểm tra số lượng dòng
                    if (dataTable.Rows.Count != 1)
                    {
                        MessageBox.Show("Không tìm thấy hoặc có nhiều hơn một kết quả.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close(); // Đóng form nếu không tìm thấy dữ liệu
                        return; // Thoát khỏi hàm
                    }

                    // Lấy dữ liệu từ DataTable
                    DataRow dr = dataTable.Rows[0];
                    tb_Id.Text = dr["MaSPDonHang"].ToString(); // Gán giá trị Mã SP Đơn Hàng vào TextBox
                    tb_Name.Text = dr["TenSP"].ToString(); // Gán tên sản phẩm vào TextBox
                    nud_Quantity.Value = Convert.ToInt32(dr["SoLuong"]); // Gán số lượng vào NumericUpDown

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

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {

        }
    }
}
