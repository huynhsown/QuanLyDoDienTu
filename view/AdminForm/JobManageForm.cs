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
    public partial class JobManageForm : Form
    {
        private MY_DB myDB = new MY_DB();
        public JobManageForm()
        {
            InitializeComponent();

        }

        private void loadJob()
        {
            String query = @"SELECT * FROM CONG_VIEC";
            try
            {
                SqlConnection connection = myDB.getConnection;
                connection.Open(); // Open the connection

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable); // Fill the DataTable with query result

                    foreach (DataRow row in dataTable.Rows)
                    {
                        object[] rowData = row.ItemArray;
                        dgv_listJob.Rows.Add(rowData); // Thêm vào DataGridView
                    }
                }
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void JobManageForm_Load(object sender, EventArgs e)
        {
            loadJob();
        }

        private void dgv_listJob_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                int id = Convert.ToInt32(dgv_listJob.Rows[e.RowIndex].Cells["col_Id"].Value);
                if (dgv_listJob.Columns[e.ColumnIndex].Name == "col_Edit")
                {
                    JobInformation jobInformation = new JobInformation(id);
                    jobInformation.ShowDialog();

                }
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            JobInformation jobInformation = new JobInformation();
            jobInformation.ShowDialog();
        }
    }
}
