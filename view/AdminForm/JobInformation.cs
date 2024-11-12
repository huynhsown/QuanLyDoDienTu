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
            try
            {
                // Retrieve and trim input values
                String name = tb_Name.Text.Trim();
                String salaryText = tb_Salary.Text.Trim();
                int salary;

                // Try parsing the salary input
                if (!int.TryParse(salaryText, out salary))
                {
                    MessageBox.Show("Lỗi: Mức lương không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Exit the method if parsing fails
                }

                // Get the database connection
                SqlConnection conn = myDB.getConnection;
                
                myDB.openConnection(); // Open connection

                // Create the SqlCommand for the stored procedure
                using (SqlCommand cmd = new SqlCommand("UpdateCongViec", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure; // Specify that we're using a stored procedure

                    // Add parameters for the stored procedure
                    cmd.Parameters.AddWithValue("@MaCV", int.Parse(tb_Id.Text));
                    cmd.Parameters.AddWithValue("@TenCV", name);
                    cmd.Parameters.AddWithValue("@Luong", salary);

                    // Execute the command
                    int rowsAffected = cmd.ExecuteNonQuery();

                    // Provide feedback based on the result
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cập nhật công việc thành công", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật không thành công. Vui lòng kiểm tra thông tin.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    
                }
            }
            catch (Exception ex)
            {
                // Show error message
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                // Retrieve and trim input values
                String name = tb_Name.Text.Trim();
                String salaryText = tb_Salary.Text.Trim();
                int salary;

                // Try parsing the salary input
                if (!int.TryParse(salaryText, out salary))
                {
                    MessageBox.Show("Lỗi: Mức lương không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Exit the method if parsing fails
                }

                // Get the database connection
                using (SqlConnection conn = myDB.getConnection)
                {
                    myDB.openConnection(); // Open connection

                    // Create the SqlCommand for the stored procedure
                    using (SqlCommand cmd = new SqlCommand("InsertCongViec", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure; // Specify that we're using a stored procedure

                        // Add parameters for the stored procedure
                        cmd.Parameters.AddWithValue("@TenCV", name);
                        cmd.Parameters.AddWithValue("@Luong", salary);

                        // Execute the command
                        int rowsAffected = cmd.ExecuteNonQuery();

                        // Provide feedback based on the result
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Thêm công việc thành công", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Thêm công việc không thành công. Vui lòng kiểm tra thông tin.", "Add", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Show error message
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void JobInformation_Load(object sender, EventArgs e)
        {
            if (isEdit)
            {
                try
                {
                    // Get a connection to the database
                    SqlConnection connection = myDB.getConnection;
                    
                    connection.Open(); // Open the connection

                    // Use the stored procedure
                    string query = "SELECT * FROM dbo.fnGetJobByMaCV(@MaCV)"; // Stored procedure name

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {// Set command type to stored procedure

                        // Assign value to the parameter
                        command.Parameters.AddWithValue("@MaCV", jobid);

                        // Execute the query and fill the DataTable
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Check if exactly one row is returned
                        if (dataTable.Rows.Count != 1)
                        {
                            MessageBox.Show("Không tìm thấy hoặc có nhiều hơn một kết quả.",
                                            "Lỗi",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                            this.Close(); // Close the form if no or multiple results found
                            return; // Exit the method
                        }

                        // Retrieve data from the DataTable
                        DataRow dr = dataTable.Rows[0];
                        tb_Id.Text = dr["MaCV"].ToString();  // Assign MaCV to the TextBox
                        tb_Name.Text = dr["TenCV"].ToString(); // Assign TenCV to the TextBox
                        tb_Salary.Text = dr["Luong"].ToString(); // Assign Luong to the TextBox
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message); // Show any exceptions
                }
            }
        }
    }
}
