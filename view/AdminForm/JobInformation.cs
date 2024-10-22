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
    public partial class JobInformation : Form
    {
        private int jobid;
        private bool isEdit = false;
        private MY_DB myDB = new MY_DB();
        public JobInformation(int jobid)
        {
            InitializeComponent();
            this.jobid = jobid;
            isEdit = true;
            btn_Add.Visible = false;

        }
        public JobInformation()
        {
            InitializeComponent();
            btn_Edit.Visible = false;

        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            SqlConnection conn = myDB.getConnection;
            myDB.openConnection();
            string query = "UPDATE CONG_VIEC SET TenCV = @name, Luong = @salary WHERE MaCV = @jobid";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@jobid", int.Parse(tb_Id.Text));
            cmd.Parameters.AddWithValue("@name", tb_Name.Text);
            cmd.Parameters.AddWithValue("@salary", int.Parse(tb_Salary.Text));

            cmd.ExecuteNonQuery();
            myDB.closeConnection();
            MessageBox.Show("Cập nhật công việc thành công", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            SqlConnection conn = myDB.getConnection;
            myDB.openConnection();
            string query = "INSERT INTO CONG_VIEC (TenCV, Luong) values (@name, @salary)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@name", tb_Name.Text);
            cmd.Parameters.AddWithValue("@salary", int.Parse(tb_Salary.Text));


            cmd.ExecuteNonQuery();
            myDB.closeConnection();
            MessageBox.Show("Thêm công việc thành công", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void JobInformation_Load(object sender, EventArgs e)
        {
            if (isEdit)
            {
                String query = @"SELECT * FROM CONG_VIEC WHERE MaCV = @maCV";
                try
                {
                    int maSP;
                    SqlConnection connection = myDB.getConnection;

                    connection.Open(); // Mở kết nối

                    // Query Staff Infomation
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@maCV", jobid); // Gán giá trị cho tham số

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
                        tb_Id.Text = dr["MaCV"].ToString(); // Gán giá trị Mã NV vào TextBox
                        tb_Name.Text = dr["TenCV"].ToString();
                        tb_Salary.Text = dr["Luong"].ToString();
                
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
