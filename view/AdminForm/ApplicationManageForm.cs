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
    public partial class ApplicationManageForm : Form
    {
        public ApplicationManageForm()
        {
            InitializeComponent();
        }
        private MY_DB myDB = new MY_DB();
        private void btn_add_Click(object sender, EventArgs e)
        {
            ApplicationInformation appInformation = new ApplicationInformation();
            appInformation.ShowDialog();
        }

        private void dgv_listProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                int id = Convert.ToInt32(dgv_listApplication.Rows[e.RowIndex].Cells["col_Id"].Value);
                if (dgv_listApplication.Columns[e.ColumnIndex].Name == "col_Edit")
                {
                    ApplicationInformation appInformation = new ApplicationInformation(id);
                    appInformation.ShowDialog();

                }
            }
        }

        private void ApplicationManageForm_Load(object sender, EventArgs e)
        {
            loadApplication();
        }

        private void loadApplication() {
            String query = @"SELECT * FROM UNG_DUNG";
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
                        dgv_listApplication.Rows.Add(rowData); // Thêm vào DataGridView
                    }
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
