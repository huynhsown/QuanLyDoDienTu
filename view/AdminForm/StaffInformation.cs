using QuanLyDoDienTu.entity;
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
    public partial class StaffInformation : Form
    {
        public StaffInformation()
        {
            InitializeComponent();
        }

        bool isEdit;
        private int id;
        private MY_DB myDB = new MY_DB();

        public StaffInformation(int id)
        {
            InitializeComponent();
            this.id = id;
            this.isEdit = true;
            btn_Add.Visible = false;
        }

        public StaffInformation(bool isEdit)
        {
            InitializeComponent();
            this.isEdit = false;
            btn_Save.Visible = false;
            btn_Add.Location = btn_Save.Location;
        }

        private void StaffInformation_Load(object sender, EventArgs e)
        {
            String query_StaffInfo = @"SELECT NV.MaNV, NV.HoTen, NV.NgaySinh, NV.GioiTinh, NV.SDT, NV.Email, NV.DiaChi, CV.MaCV, CV.TenCV 
                     FROM NHAN_VIEN NV 
                     LEFT JOIN CONG_VIEC CV ON NV.MaCV = CV.MaCV 
                     WHERE NV.MaNV = @MaNV";

            String queryListJob = @"SELECT * FROM CONG_VIEC";

            if (isEdit)
            {

                try
                {
                    int staff_job_id;
                    SqlConnection connection = myDB.getConnection;

                    connection.Open(); // Mở kết nối

                    // Query Staff Infomation
                    using (SqlCommand command = new SqlCommand(query_StaffInfo, connection))
                    {
                        command.Parameters.AddWithValue("@MaNV", id); // Gán giá trị cho tham số

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable); // Lấy dữ liệu vào DataTable

                        // Kiểm tra số lượng dòng
                        if (dataTable.Rows.Count != 1)
                        {
                            MessageBox.Show("Không tìm thấy nhân viên hoặc có nhiều hơn một kết quả.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Close(); // Đóng form nếu không tìm thấy dữ liệu
                            return; // Thoát khỏi hàm
                        }

                        // Lấy dữ liệu từ DataTable
                        DataRow dr = dataTable.Rows[0];
                        tb_Id.Text = dr["MaNV"].ToString(); // Gán giá trị Mã NV vào TextBox
                        tb_Name.Text = dr["HoTen"].ToString();
                        dtp_Date.Value = Convert.ToDateTime(dr["NgaySinh"]);
                        tb_Phone.Text = dr["SDT"].ToString();
                        tb_Email.Text = dr["Email"].ToString();
                        tb_Address.Text = dr["DiaChi"].ToString();
                        staff_job_id = dr["MaCV"] != DBNull.Value ? Convert.ToInt32(dr["MaCV"]) : -1; // hoặc null tùy vào kiểu dữ liệu của staff_job_id


                        if (dr["GioiTinh"].ToString().Equals("Nam"))
                        {
                            rb_male.Checked = true;
                        }
                        else
                        {
                            rb_female.Checked = true;
                        }

                    }

                    // Query List Job
                    using (SqlCommand cmd = new SqlCommand(queryListJob, connection))
                    {

                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        sqlDataAdapter.Fill(dataTable);

                        List<Job> jobs = new List<Job>();
                        jobs.Add(new Job(-1, "Chưa có việc", 0));

                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            int id = Convert.ToInt32(dataTable.Rows[i]["MaCV"]);
                            String name = dataTable.Rows[i]["TenCV"].ToString();
                            long income = Convert.ToInt64(dataTable.Rows[i]["Luong"]);
                            jobs.Add(new Job(id, name, income));
                        }

                        cb_Job.DataSource = jobs;
                        cb_Job.DisplayMember = "Name";
                        cb_Job.ValueMember = "Id";
                        cb_Job.SelectedValue = staff_job_id;

                        tb_Income.Text = ((Job)cb_Job.SelectedItem).Income.ToString();
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    SqlConnection connection = myDB.getConnection;

                    connection.Open(); // Mở kết nối

                    // Query List Job
                    using (SqlCommand cmd = new SqlCommand(queryListJob, connection))
                    {

                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        sqlDataAdapter.Fill(dataTable);

                        List<Job> jobs = new List<Job>();

                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            int id = Convert.ToInt32(dataTable.Rows[i]["MaCV"]);
                            String name = dataTable.Rows[i]["TenCV"].ToString();
                            long income = Convert.ToInt64(dataTable.Rows[i]["Luong"]);
                            jobs.Add(new Job(id, name, income));
                        }

                        cb_Job.DataSource = jobs;
                        cb_Job.DisplayMember = "Name";
                        cb_Job.ValueMember = "Id";

                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cb_Job_SelectedIndexChanged(object sender, EventArgs e)
        {
            tb_Income.Text = ((Job)cb_Job.SelectedItem).Income.ToString();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                String name = tb_Name.Text.Trim();
                DateOnly birth = DateOnly.FromDateTime(dtp_Date.Value);
                String phone = tb_Phone.Text.Trim();
                String email = tb_Email.Text.Trim();
                String address = tb_Address.Text.Trim();
                String gender = rb_female.Checked ? "Nu" : "Nam"; // Ternary operator for gender
                int jobId = Convert.ToInt32(cb_Job.SelectedValue);
                String procedure = "UpdateNhanVien";
                if(jobId == -1)
                {
                    procedure = "UpdateNhanVienWithoutJob";
                }

                SqlConnection connection = myDB.getConnection;
                connection.Open(); // Mở kết nối

                // Use the stored procedure to update staff information
                using (SqlCommand command = new SqlCommand(procedure, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@MaNV", id); // Giá trị Mã NV
                    command.Parameters.AddWithValue("@HoTen", name);
                    command.Parameters.AddWithValue("@NgaySinh", dtp_Date.Value);
                    command.Parameters.AddWithValue("@GioiTinh", gender);
                    command.Parameters.AddWithValue("@SDT", phone);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@DiaChi", address);
                    if(jobId != -1)  command.Parameters.AddWithValue("@MaCV", jobId);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cập nhật thông tin thành công.");
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật không thành công. Vui lòng kiểm tra thông tin.");
                    }
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                String name = tb_Name.Text.Trim();
                DateOnly birth = DateOnly.FromDateTime(dtp_Date.Value);
                String phone = tb_Phone.Text.Trim();
                String email = tb_Email.Text.Trim();
                String address = tb_Address.Text.Trim();
                String gender = rb_female.Checked ? "Nu" : "Nam"; // Set gender based on radio button selection
                int jobId = Convert.ToInt32(cb_Job.SelectedValue); // Get job ID from the selected value

                SqlConnection connection = myDB.getConnection;
                connection.Open(); // Open the connection

                // Use the stored procedure to insert new employee information
                using (SqlCommand command = new SqlCommand("InsertNhanVien", connection))
                {
                    command.CommandType = CommandType.StoredProcedure; // Specify command type

                    command.Parameters.AddWithValue("@HoTen", name);
                    command.Parameters.AddWithValue("@NgaySinh", dtp_Date.Value);
                    command.Parameters.AddWithValue("@GioiTinh", gender);
                    command.Parameters.AddWithValue("@SDT", phone);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@DiaChi", address);
                    command.Parameters.AddWithValue("@MaCV", jobId);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Thêm nhân viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Thêm nhân viên không thành công. Vui lòng kiểm tra thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
