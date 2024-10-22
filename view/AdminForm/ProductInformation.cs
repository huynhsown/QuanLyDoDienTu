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
    public partial class ProductInformation : Form
    {
        private int proid;
        private bool isEdit = false;
        private MY_DB myDB = new MY_DB();
        public ProductInformation(int proid)
        {
            InitializeComponent();
            this.proid = proid;
            isEdit = true;
            btn_Add.Visible = false;
        }

        public ProductInformation()
        {
            InitializeComponent();
            btn_Edit.Visible = false;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            SqlConnection conn = myDB.getConnection;
            myDB.openConnection();
            string query = "INSERT INTO SAN_PHAM (TenSP, Gia, SoLuong, TinhTrang) values (@name, @price, @quantity, @state)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@name", tb_Name.Text);
            cmd.Parameters.AddWithValue("@price", int.Parse(tb_Price.Text));
            cmd.Parameters.AddWithValue("@quantity", int.Parse(tb_Quantity.Text));
            cmd.Parameters.AddWithValue("@state", tb_State.Text);

            cmd.ExecuteNonQuery();
            myDB.closeConnection();
            MessageBox.Show("Thêm sản phẩm thành công", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            SqlConnection conn = myDB.getConnection;
            myDB.openConnection();
            string query = "UPDATE SAN_PHAM SET TenSP = @name, Gia = @price, SoLuong = @quantity, TinhTrang = @state WHERE MaSP = @proid";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@proid", int.Parse(tb_Id.Text));
            cmd.Parameters.AddWithValue("@name", tb_Name.Text);
            cmd.Parameters.AddWithValue("@price", int.Parse(tb_Price.Text));
            cmd.Parameters.AddWithValue("@quantity", int.Parse(tb_Quantity.Text));
            cmd.Parameters.AddWithValue("@state", tb_State.Text);

            cmd.ExecuteNonQuery();
            myDB.closeConnection();
            MessageBox.Show("Cập nhật sản phẩm thành công", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        

        private void ProductInformation_Load(object sender, EventArgs e)
        {
            if (isEdit)
            {
                String query = @"SELECT * FROM SAN_PHAM WHERE MaSP = @maSP";
                try
                {
                    int maSP;
                    SqlConnection connection = myDB.getConnection;

                    connection.Open(); // Mở kết nối

                    // Query Staff Infomation
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@maSP", proid); // Gán giá trị cho tham số

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable); // Lấy dữ liệu vào DataTable

                        // Kiểm tra số lượng dòng
                        if (dataTable.Rows.Count != 1)
                        {
                            MessageBox.Show("Không tìm thấy hoặc có nhiều hơn một kết quả.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Close(); // Đóng form nếu không tìm thấy dữ liệu
                            return; // Thoát khỏi hàm
                        }

                        // Lấy dữ liệu từ DataTable
                        DataRow dr = dataTable.Rows[0];
                        tb_Id.Text = dr["MaSP"].ToString(); // Gán giá trị Mã NV vào TextBox
                        tb_Name.Text = dr["TenSP"].ToString();
                        tb_Price.Text = dr["Gia"].ToString();
                        tb_Quantity.Text = dr["SoLuong"].ToString();
                        tb_State.Text = dr["TinhTrang"].ToString();
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
}
