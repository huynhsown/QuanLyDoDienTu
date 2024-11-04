using System;
using System.Collections;
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
    public partial class AccoutManageForm : Form
    {
        public AccoutManageForm()
        {
            InitializeComponent();
        }

        private MY_DB myDB = new MY_DB();

        private void AccoutManageForm_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connection = myDB.getConnection;
                connection.Open(); // Mở kết nối

                using (SqlCommand command = new SqlCommand("SELECT \r\n    nv.MaNV, \r\n    tk.SDT, \r\n    tk.Password, \r\n    nv.HoTen, \r\n    CASE \r\n        WHEN cv.TenCV = 'Admin' THEN 'Admin' \r\n        ELSE 'Nhân viên' \r\n    END AS TenCV\r\nFROM \r\n    TAI_KHOAN tk \r\nJOIN \r\n    NHAN_VIEN nv ON tk.SDT = nv.SDT \r\nLEFT JOIN \r\n    CONG_VIEC cv ON nv.MaCV = cv.MaCV;\r\n", connection))
                {
                    //command.CommandType = CommandType.StoredProcedure; // Xác định là Stored Procedure

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable); // Lấy dữ liệu từ Stored Procedure và đưa vào DataTable

                    foreach (DataRow row in dataTable.Rows)
                    {
                        object[] rowData = row.ItemArray;
                        dgv_listAccout.Rows.Add(rowData); // Thêm dữ liệu vào DataGridView
                    }
                }

                using (SqlCommand command = new SqlCommand("SELECT \r\n    kh.MaKH, \r\n    tk.SDT, \r\n    tk.Password, \r\n    kh.HoTen,\r\n\tN'Khách hàng' as VaiTro\r\nFROM TAI_KHOAN tk JOIN \r\n    KHACH_HANG kh ON tk.SDT = kh.SDT;\r\n\r\n", connection))
                {
                    //command.CommandType = CommandType.StoredProcedure; // Xác định là Stored Procedure

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable); // Lấy dữ liệu từ Stored Procedure và đưa vào DataTable

                    foreach (DataRow row in dataTable.Rows)
                    {
                        object[] rowData = row.ItemArray;
                        dgv_listAccountCustomer.Rows.Add(rowData); // Thêm dữ liệu vào DataGridView
                    }
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rb_staff_CheckedChanged(object sender, EventArgs e)
        {
            cbb_search.Items.Clear();
            cbb_search.Items.Add("Mã nhân viên");
            cbb_search.Items.Add("Tên nhân viên");
            cbb_search.Items.Add("Số điện thoại");
        }

        private void rb_customer_CheckedChanged(object sender, EventArgs e)
        {
            cbb_search.Items.Clear();
            cbb_search.Items.Add("Mã khách hàng");
            cbb_search.Items.Add("Tên khách hàng");
            cbb_search.Items.Add("Số điện thoại");
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if (!rb_customer.Checked && !rb_staff.Checked)
            {
                MessageBox.Show("Vui long chon radiobutton");
                return;
            }
            if (cbb_search.SelectedIndex == -1)
            {
                MessageBox.Show("Vui long chon combobox");
                return;
            }
            if (rb_staff.Checked)
            {
                String query = "SELECT " +
                            " nv.MaNV, tk.SDT, tk.Password, nv.HoTen, " +
                            " CASE WHEN cv.TenCV = 'Admin' THEN 'Admin' ELSE 'Nhân viên' END AS TenCV " +
                            "FROM " +
                            " TAI_KHOAN tk " +
                            "JOIN " +
                            " NHAN_VIEN nv ON tk.SDT = nv.SDT " +
                            "LEFT JOIN " +
                            " CONG_VIEC cv ON nv.MaCV = cv.MaCV " +
                            "WHERE ";
                if (cbb_search.SelectedIndex == 0)
                {
                    int id;
                    if (int.TryParse(tb_search.Text, out id)) // Kiểm tra nếu id hợp lệ
                    {
                        query += " nv.MaNV = " + id;// Thêm điều kiện tìm kiếm theo MaNV
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng nhập một mã nhân viên hợp lệ."); // Thông báo nếu mã không hợp lệ
                        return; // Thoát ra nếu không hợp lệ
                    }

                }

                else if (cbb_search.SelectedIndex == 1)
                {
                    String name = tb_search.Text.Trim(); // Đảm bảo lấy từ textbox chứ không phải combobox
                    query += " nv.HoTen LIKE '%" + name + "%'";
                }

                else if (cbb_search.SelectedIndex == 2)
                {
                    String sdt = tb_search.Text.Trim();

                    // Kiểm tra nếu SDT có toàn bộ ký tự là số
                    if (sdt.All(char.IsDigit) && sdt.Length > 0)
                    {
                        query += " tk.SDT = '" + sdt + "'"; // Chuyển đổi thành kiểu chuỗi nếu cần
                    }
                    else
                    {
                        MessageBox.Show("Số điện thoại không hợp lệ. Vui lòng nhập lại.");
                        return; // Kết thúc hàm nếu SDT không hợp lệ
                    }
                }




                SqlConnection connection = myDB.getConnection;
                connection.Open();
                dgv_listAccout.Rows.Clear();

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable); // Fill the DataTable with the results

                    foreach (DataRow row in dataTable.Rows)
                    {
                        object[] rowData = row.ItemArray;
                        dgv_listAccout.Rows.Add(rowData); // Add rows to DataGridView
                    }
                }
                connection.Close();

            }

            else
            {
                String query = "SELECT " +
                " kh.MaKH, tk.SDT, tk.Password, kh.HoTen, " +
                " N'Khách hàng' AS VaiTro " +
                " FROM " +
                " TAI_KHOAN tk " +
                " JOIN " +
                " KHACH_HANG kh ON tk.SDT = kh.SDT " +
                " WHERE ";

                SqlConnection connection = myDB.getConnection;
                connection.Open();
                dgv_listAccountCustomer.Rows.Clear();

                // Kiểm tra loại tìm kiếm từ ComboBox
                if (cbb_search.SelectedIndex == 0) // Tìm kiếm theo mã khách hàng
                {
                    int id;
                    if (int.TryParse(tb_search.Text, out id)) // Kiểm tra nếu id hợp lệ
                    {
                        query += " kh.MaKH = " + id; // Thêm điều kiện tìm kiếm theo MaKH
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng nhập một mã khách hàng hợp lệ."); // Thông báo nếu mã không hợp lệ
                        return; // Thoát ra nếu không hợp lệ
                    }
                }
                else if (cbb_search.SelectedIndex == 1) // Tìm kiếm theo họ tên khách hàng
                {
                    String name = tb_search.Text.Trim();
                    query += " kh.HoTen LIKE '%" + name + "%'";
                }
                else if (cbb_search.SelectedIndex == 2) // Tìm kiếm theo số điện thoại khách hàng
                {
                    String sdt = tb_search.Text.Trim();

                    // Kiểm tra nếu SDT có toàn bộ ký tự là số
                    if (sdt.All(char.IsDigit) && sdt.Length > 0)
                    {
                        query += " tk.SDT = '" + sdt + "'"; // Thêm điều kiện tìm kiếm theo SDT
                    }
                    else
                    {
                        MessageBox.Show("Số điện thoại không hợp lệ. Vui lòng nhập lại.");
                        return; // Kết thúc hàm nếu SDT không hợp lệ
                    }
                }

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable); // Fill the DataTable with the results

                    foreach (DataRow row in dataTable.Rows)
                    {
                        object[] rowData = row.ItemArray;
                        dgv_listAccountCustomer.Rows.Add(rowData); // Add rows to DataGridView
                    }
                }

                connection.Close();

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgv_listAccout_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                int id = Convert.ToInt32(dgv_listAccout.Rows[e.RowIndex].Cells["col_Id"].Value);
                int role = -1;
                String phone = dgv_listAccout.Rows[e.RowIndex].Cells["col_Phone"].Value.ToString().Trim();
                String password = dgv_listAccout.Rows[e.RowIndex].Cells["col_Password"].Value.ToString().Trim();

                if (dgv_listAccout.Columns[e.ColumnIndex].Name == "col_Edit")
                {
                    if (dgv_listAccout.Rows[e.RowIndex].Cells["col_Role"].Value.ToString().Equals("Admin"))
                    {
                        role = 1;
                    }
                    else
                    {
                        role = 2;
                    }
                    AccountInformation accountInformation = new AccountInformation(id, role, phone, password);
                    accountInformation.ShowDialog();
                }
            }
        }

        private void dgv_listAccountCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                int id = Convert.ToInt32(dgv_listAccountCustomer.Rows[e.RowIndex].Cells["col_CId"].Value);
                int role = 3;
                String phone = dgv_listAccountCustomer.Rows[e.RowIndex].Cells["col_CPhone"].Value.ToString().Trim();
                String password = dgv_listAccountCustomer.Rows[e.RowIndex].Cells["col_CPassword"].Value.ToString().Trim();

                if (dgv_listAccountCustomer.Columns[e.ColumnIndex].Name == "col_CEdit")
                {
                    AccountInformation accountInformation = new AccountInformation(id, role, phone, password);
                    accountInformation.ShowDialog();
                }
            }
        }
    }
}
