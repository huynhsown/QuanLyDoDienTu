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
    public partial class PurchaseOrderManageForm : Form
    {
        private MY_DB myDB = new MY_DB();
        public PurchaseOrderManageForm()
        {
            InitializeComponent();
        }

        private void btn_addStaff_Click(object sender, EventArgs e)
        {
            PurchaseOrderInformation purchaseOrderInformation = new PurchaseOrderInformation();
            purchaseOrderInformation.ShowDialog();

        }

        private void dgv_listStaff_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                int id = Convert.ToInt32(dgv_listPurchaseOrder.Rows[e.RowIndex].Cells["col_Id"].Value);
               
                if (dgv_listPurchaseOrder.Columns[e.ColumnIndex].Name == "col_Edit")
                {
                    PurchaseOrderInformation info = new PurchaseOrderInformation(id);
                    info.ShowDialog();

                }
            }

        }

        private void PurchaseOrder_Load(object sender, EventArgs e)
        {
            string query = @"SELECT 
                     dnh.MaDon ,
                     dnh.NgayNhap,
                     dnh.GiaTri,
                     dnh.SoLuong ,
                     dnh.DonGia,
                     sp.TenSP,
                     nsx.TenNSX
                 FROM 
                     DON_NHAP_HANG dnh
                 JOIN 
                     SAN_PHAM sp ON dnh.MaSP = sp.MaSP
                 JOIN 
                     NHA_SAN_XUAT nsx ON dnh.MaNSX = nsx.MaNSX";
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
                        dgv_listPurchaseOrder.Rows.Add(rowData); // Thêm vào DataGridView
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
