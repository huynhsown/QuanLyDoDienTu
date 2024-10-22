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
                    SPD.MaSPDonHang,
                    SP.MaSP, 
                    SP.TenSP, 
                    (SP.Gia * SPD.SoLuong) as Gia, 
                    SPD.SoLuong
                FROM 
                    SAN_PHAM_DUOC_CHON SPD
                JOIN 
                    SAN_PHAM SP ON SPD.MaSP = SP.MaSP
                WHERE 
                    SPD.MaSPDonHang = @MaSPDH";


            SqlConnection connection = null;

            try
            {
                connection = myDB.getConnection; // Get the connection
                connection.Open(); // Open the connection

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaSPDH", proid); // Set the parameter for the query

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable); // Lấy dữ liệu vào DataTable

                    // Kiểm tra số lượng dòng
                    if (dataTable.Rows.Count != 1)
                    {
                        MessageBox.Show("Không tìm thấy hoặc có nhiều hơn một kết quả.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close(); // Đóng form nếu không tìm thấy dữ liệu
                        return; // Thoát khỏi hàm
                    }

                    // Lấy dữ liệu từ DataTable
                    DataRow dr = dataTable.Rows[0];
                    tb_Id.Text = dr["MaSPDonHang"].ToString(); // Gán giá trị Mã NV vào TextBox
                    tb_Name.Text = dr["TenSP"].ToString();
                    nud_Quantity.Value = Convert.ToInt32(dr["SoLuong"]);




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

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
