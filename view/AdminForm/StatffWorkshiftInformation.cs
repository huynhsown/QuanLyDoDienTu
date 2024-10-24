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
    public partial class StatffWorkshiftInformation : Form
    {
        private int workshiftid;
        private int staffid;
        bool isEdit = false;
        private MY_DB myDB = new MY_DB();

        public StatffWorkshiftInformation(int workshiftid)
        {
            InitializeComponent();
            this.workshiftid = workshiftid;
            isEdit = true;
            btn_Add.Visible = false;
        }

        public StatffWorkshiftInformation(int staffid, bool isEdit)
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

            

            if (isEdit)
            {
                try
                {
                    String procedureName = "sp_GetWorkShiftByMaCa"; // Tên của Stored Procedure
                    SqlConnection connection = myDB.getConnection; // Lấy kết nối từ myDB
                    connection.Open(); // Mở kết nối

                    // Sử dụng Stored Procedure
                    using (SqlCommand command = new SqlCommand(procedureName, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure; // Đặt loại lệnh là Stored Procedure
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
                        tb_Id.Text = dr["MaCa"].ToString(); // Gán giá trị Mã Ca vào TextBox

                        DateTime startTime = Convert.ToDateTime(dr["ThoiGianBatDau"]);
                        DateTime endTime = Convert.ToDateTime(dr["ThoiGianKetThuc"]);

                        String startTime_H = startTime.ToString("HH:mm");
                        String endTime_H = endTime.ToString("HH:mm");

                        // Chọn thời gian bắt đầu
                        for (int i = 0; i < combo_startTime.Items.Count; i++)
                        {
                            if (combo_startTime.Items[i].ToString() == startTime_H)
                            {
                                combo_startTime.SelectedIndex = i;  // Chọn item
                                break;
                            }
                        }

                        // Chọn thời gian kết thúc
                        for (int i = 0; i < combo_endTime.Items.Count; i++)
                        {
                            if (combo_endTime.Items[i].ToString() == endTime_H)
                            {
                                combo_endTime.SelectedIndex = i;  // Chọn item
                                break;
                            }
                        }
                    }

                    connection.Close(); // Đóng kết nối
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
                // Open the database connection
                SqlConnection conn = myDB.getConnection;
                
                myDB.openConnection(); // Open connection

                // Define the command for the stored procedure
                using (SqlCommand cmd = new SqlCommand("UpdateCaLamViec", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure; // Specify that it's a stored procedure

                    // Combine date and time to create DateTime objects
                    DateTime startTime = dtp_Date.Value.Date + TimeSpan.Parse(combo_startTime.SelectedItem.ToString());
                    DateTime endTime = dtp_Date.Value.Date + TimeSpan.Parse(combo_endTime.SelectedItem.ToString());

                    // Add parameters for the stored procedure
                    cmd.Parameters.AddWithValue("@maCa", workshiftid);
                    cmd.Parameters.AddWithValue("@starttime", startTime);
                    cmd.Parameters.AddWithValue("@endtime", endTime);

                    // Execute the stored procedure
                    int rowsAffected = cmd.ExecuteNonQuery();

                    // Check if the update was successful
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cập nhật ca làm việc thành công", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy ca làm việc để cập nhật.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    
                }
            }
            catch (FormatException fe)
            {
                MessageBox.Show($"Lỗi định dạng thời gian: {fe.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Lỗi cơ sở dữ liệu: {sqlEx.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                // Open the database connection
                SqlConnection conn = myDB.getConnection;
                
                myDB.openConnection(); // Open connection

                // Define the command for the stored procedure
                using (SqlCommand cmd = new SqlCommand("InsertCaLamViec", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure; // Specify that it's a stored procedure

                    // Combine date and time to create DateTime objects
                    DateTime startTime = dtp_Date.Value.Date + TimeSpan.Parse(combo_startTime.SelectedItem.ToString());
                    DateTime endTime = dtp_Date.Value.Date + TimeSpan.Parse(combo_endTime.SelectedItem.ToString());

                    // Add parameters for start time, end time, and staff ID
                    cmd.Parameters.AddWithValue("@starttime", startTime);
                    cmd.Parameters.AddWithValue("@endtime", endTime);
                    cmd.Parameters.AddWithValue("@maNV", staffid);

                    // Execute the stored procedure
                    int rowsAffected = cmd.ExecuteNonQuery();

                    // Check if the insertion was successful
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Thêm ca làm việc thành công", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Thêm ca làm việc không thành công", "Add Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            
            }
            catch (FormatException fe)
            {
                MessageBox.Show($"Lỗi định dạng thời gian: {fe.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Lỗi cơ sở dữ liệu: {sqlEx.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
