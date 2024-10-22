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
    public partial class ProductManageForm : Form
    {
        public ProductManageForm()
        {
            InitializeComponent();
        }

        private MY_DB myDB = new MY_DB();

        private void ProductManageForm_Load(object sender, EventArgs e)
        {
            loadProduct();
        }

        private void loadProduct()
        {
            String query = @"SELECT * FROM SAN_PHAM";
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
                        dgv_listProduct.Rows.Add(rowData); // Th�m v�o DataGridView
                    }
                }
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dgv_listProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                int id = Convert.ToInt32(dgv_listProduct.Rows[e.RowIndex].Cells["col_Id"].Value);
                if (dgv_listProduct.Columns[e.ColumnIndex].Name == "col_Edit")
                {
                    ProductInformation productInformation = new ProductInformation(id);
                    productInformation.ShowDialog();

                }
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            ProductInformation productInformation = new ProductInformation();
            productInformation.ShowDialog();
        }
    }
}
