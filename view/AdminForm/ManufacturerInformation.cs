using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDoDienTu.view.AdminForm
{
    public partial class ManufacturerInformation : Form
    {
        private int manuid;
        bool isEdit = false;
        private MY_DB myDB = new MY_DB();
        public ManufacturerInformation(int manuid)
        {
            InitializeComponent();
            this.manuid = manuid;
            isEdit = true;
            btn_Add.Visible = false;

        }

        public ManufacturerInformation()
        {
            InitializeComponent();
            btn_Edit.Visible = false;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            SqlConnection conn = myDB.getConnection;
            myDB.openConnection();
            string query = "UPDATE NHA_SAN_XUAT SET TenNSX = @name, SDT = @phone, Email = @email WHERE MaNSX = @manuid";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@manuid", int.Parse(tb_Id.Text));
            cmd.Parameters.AddWithValue("@name", tb_Name.Text);
            cmd.Parameters.AddWithValue("@phone", tb_Phone.Text);
            cmd.Parameters.AddWithValue("@email", tb_Email.Text);


            cmd.ExecuteNonQuery();
            myDB.closeConnection();
            MessageBox.Show("Cập nhật nhà sản xuất thành công", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            SqlConnection conn = myDB.getConnection;
            myDB.openConnection();
            string query = "INSERT INTO NHA_SAN_XUAT (TenNSX, SDT, Email) values (@name, @phone, @email)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@name", tb_Name.Text);
            cmd.Parameters.AddWithValue("@phone", tb_Phone.Text);
            cmd.Parameters.AddWithValue("@email", tb_Email.Text);

            cmd.ExecuteNonQuery();
            myDB.closeConnection();
            MessageBox.Show("Thêm nhà sản xuất thành công", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ManufacturerInformation_Load(object sender, EventArgs e)
        {
            if (isEdit)
            {
                String query = @"SELECT * FROM NHA_SAN_XUAT WHERE MaNSX = @maNSX";
                try
                {
                    int maSP;
                    SqlConnection connection = myDB.getConnection;

                    connection.Open(); // Mở kết nối

                    // Query Staff Infomation
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@maNSX", manuid); // Gán giá trị cho tham số

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
                        tb_Id.Text = dr["MaNSX"].ToString(); // Gán giá trị Mã NV vào TextBox
                        tb_Name.Text = dr["TenNSX"].ToString();
                        tb_Phone.Text = dr["SDT"].ToString();
                        tb_Email.Text = dr["Email"].ToString();
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
}
