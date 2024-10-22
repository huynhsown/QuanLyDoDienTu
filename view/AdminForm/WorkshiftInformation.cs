using QuanLyDoDienTu.entity;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyDoDienTu.view.AdminForm
{
    public partial class WorkshiftInformation : Form
    {
        private int workshiftid;
        private int staffid;
        bool isEdit = false;
        private MY_DB myDB = new MY_DB();

        public WorkshiftInformation(int workshiftid)
        {
            InitializeComponent();
            this.workshiftid = workshiftid;
            isEdit = true;
            btn_Add.Visible = false;
        }

        public WorkshiftInformation(int staffid, bool isEdit)
        {
            InitializeComponent();
            this.isEdit = isEdit;
            this.staffid = staffid;
            btn_Edit.Visible = false;

        }





        private void WorkshiftInformation_Load(object sender, EventArgs e)
        {
            startTime();
            endTime();

            String queryListWorkShift = @"SELECT * FROM CA_LAM_VIEC WHERE MaCa = @maCa";

            if (isEdit)
            {

                try
                {
                    int staff_job_id;
                    SqlConnection connection = myDB.getConnection;

                    connection.Open(); // Mở kết nối

                    // Query Staff Infomation
                    using (SqlCommand command = new SqlCommand(queryListWorkShift, connection))
                    {
                        command.Parameters.AddWithValue("@maCa", workshiftid); // Gán giá trị cho tham số

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable); // Lấy dữ liệu vào DataTable

                        // Kiểm tra số lượng dòng
                        if (dataTable.Rows.Count != 1)
                        {
                            MessageBox.Show("Không tìm thấy ca làm việc", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Close(); // Đóng form nếu không tìm thấy dữ liệu
                            return; // Thoát khỏi hàm
                        }

                        // Lấy dữ liệu từ DataTable
                        DataRow dr = dataTable.Rows[0];
                        tb_Id.Text = dr["MaCa"].ToString(); // Gán giá trị Mã NV vào TextBox

                        DateTime startTime = Convert.ToDateTime(dr["ThoiGianBatDau"]);
                        DateTime endTime = Convert.ToDateTime(dr["ThoiGianKetThuc"]);



                        String startTime_H = startTime.ToString("HH:mm");
                        String endTime_H = endTime.ToString("HH:mm");

                        for (int i = 0; i < combo_startTime.Items.Count; i++)
                        {

                            if (combo_startTime.Items[i].ToString() == startTime_H)
                            {
                                combo_startTime.SelectedIndex = i;  // Chọn item
                                break;
                            }
                        }

                        for (int i = 0; i < combo_endTime.Items.Count; i++)
                        {
                            if (combo_endTime.Items[i].ToString() == endTime_H)
                            {
                                combo_endTime.SelectedIndex = i;  // Chọn item
                                break;
                            }
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

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = myDB.getConnection;
                myDB.openConnection();
                string query = "UPDATE CA_LAM_VIEC SET ThoiGianBatDau = @starttime, ThoiGianKetThuc = @endtime WHERE MaCa = @maCa";
                SqlCommand cmd = new SqlCommand(query, conn);

                // Add parameters
                cmd.Parameters.AddWithValue("@maCa", workshiftid);

                // Combine date and time to create a DateTime object
                DateTime startTime = dtp_Date.Value.Date + TimeSpan.Parse(combo_startTime.SelectedItem.ToString());
                DateTime endTime = dtp_Date.Value.Date + TimeSpan.Parse(combo_endTime.SelectedItem.ToString());


                // Add parameters for start and end time
                cmd.Parameters.AddWithValue("@starttime", startTime);
                cmd.Parameters.AddWithValue("@endtime", endTime);

                cmd.ExecuteNonQuery();


                myDB.closeConnection();
                MessageBox.Show("Cập nhật ca làm việc thành công", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void startTime()
        {
            combo_startTime.Items.Clear();

            for (int hour = 7; hour <= 11; hour++)
            {
                combo_startTime.Items.Add("0" + hour + ":00");
                combo_startTime.Items.Add("0" + hour + ":30");
            }

            combo_startTime.SelectedIndex = 0;
        }

        private void endTime()
        {
            combo_endTime.Items.Clear();

            for (int hour = 13; hour <= 17; hour++)
            {
                combo_endTime.Items.Add(hour + ":00");
                combo_endTime.Items.Add(hour + ":30");
            }

            combo_endTime.SelectedIndex = 0;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                
                SqlConnection conn = myDB.getConnection;
                myDB.openConnection();
                string query = "INSERT INTO CA_LAM_VIEC (ThoiGianBatDau , ThoiGianKetThuc, MaNV)   values (@starttime, @endtime, @maNV)";
                SqlCommand cmd = new SqlCommand(query, conn);

                // Add parameters
                cmd.Parameters.AddWithValue("@maCa", workshiftid);

                // Combine date and time to create a DateTime object
                DateTime startTime = dtp_Date.Value.Date + TimeSpan.Parse(combo_startTime.SelectedItem.ToString());
                DateTime endTime = dtp_Date.Value.Date + TimeSpan.Parse(combo_endTime.SelectedItem.ToString());


                // Add parameters for start and end time
                cmd.Parameters.AddWithValue("@starttime", startTime);
                cmd.Parameters.AddWithValue("@endtime", endTime);
                cmd.Parameters.AddWithValue("@maNV", staffid);
                
                cmd.ExecuteNonQuery();


                myDB.closeConnection();
                MessageBox.Show("Thêm ca làm việc thành công", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
