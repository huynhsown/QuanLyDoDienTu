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
    public partial class StaffWorkShiftManageForm : Form
    {
        private int staffid;
        private MY_DB myDB = new MY_DB();
        public StaffWorkShiftManageForm(int staffid)
        {
            InitializeComponent();
            this.staffid = staffid;

        }



        private void btn_addJob_Click(object sender, EventArgs e)
        {
            StatffWorkshiftInformation workshiftInformation = new StatffWorkshiftInformation(staffid, false);
            workshiftInformation.ShowDialog();
        }

        private void StaffWorkShiftManageForm_Load(object sender, EventArgs e)
        {
            String query = "SELECT CLV.MaCa, CLV.ThoiGianBatDau, CLV.ThoiGianKetThuc, CV.TenCV AS TenCongViec FROM CA_LAM_VIEC CLV JOIN NHAN_VIEN NV ON CLV.MaNV = NV.MaNV JOIN CONG_VIEC CV ON NV.MaCV = CV.MaCV WHERE NV.MaNV = @maNV";

            try
            {
                using (SqlConnection connection = myDB.getConnection)
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@maNV", staffid);
                        SqlDataAdapter adapter = new SqlDataAdapter(command);

                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable); // Fill the DataTable with query result

                        foreach (DataRow row in dataTable.Rows)
                        {
                            object[] rowData = row.ItemArray;




                            dgv_listWorkShift.Rows.Add(rowData); // Thêm vào DataGridView
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgv_listWorkShift_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                int workshiftid = Convert.ToInt32(dgv_listWorkShift.Rows[e.RowIndex].Cells["col_Id"].Value);
                if (dgv_listWorkShift.Columns[e.ColumnIndex].Name == "col_Edit")
                {
                    StatffWorkshiftInformation workshiftInformation = new StatffWorkshiftInformation(workshiftid);
                    workshiftInformation.ShowDialog();

                }
            }
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = myDB.getConnection;
                conn.Open();

                string query = "SELECT * FROM CA_LAM_VIEC WHERE TenCV LIKE '%' + @tencalamviec + '%'";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tencalamviec", tb_search.Text);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();

                // Fill the DataTable with the query result
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    dgv_listWorkShift.Rows.Clear(); // Clear DataGridView rows before adding new ones
                    foreach (DataRow row in dataTable.Rows)
                    {
                        object[] rowData = row.ItemArray;
                        dgv_listWorkShift.Rows.Add(rowData); // Add data to DataGridView
                    }
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu");
                }


                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
