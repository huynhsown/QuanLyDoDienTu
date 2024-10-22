﻿using System;
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
    public partial class ManufacturerManagerForm : Form
    {
        public ManufacturerManagerForm()
        {
            InitializeComponent();

        }

        private MY_DB myDB = new MY_DB();

        private void ManufacturerManagerForm_Load(object sender, EventArgs e)
        {
            loadManufacturer();
        }

        private void loadManufacturer()
        {
            String query = @"SELECT * FROM NHA_SAN_XUAT";
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
                        dgv_listManufacturer.Rows.Add(rowData); // Thêm vào DataGridView
                    }
                }
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dgv_listManufacturer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                int id = Convert.ToInt32(dgv_listManufacturer.Rows[e.RowIndex].Cells["col_Id"].Value);
                if (dgv_listManufacturer.Columns[e.ColumnIndex].Name == "col_Edit")
                {
                    ManufacturerInformation manuInformation = new ManufacturerInformation(id);
                    manuInformation.ShowDialog();

                }
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            ManufacturerInformation manuInformation = new ManufacturerInformation();
            manuInformation.ShowDialog();
        }
    }
}