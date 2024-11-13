using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyDoDienTu.view.StaffForm
{
    public partial class QL_Khuyen_Mai : Form
    {
        private MY_DB myDb = new MY_DB();
        private int selectedId = -1; // Biến lưu lại ID của khuyến mãi đang được chọn

        public QL_Khuyen_Mai()
        {
            InitializeComponent();
        }

        private void QL_Khuyen_Mai_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM fnGetAllApplications()", myDb.getConnection))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dgKhuyenmai.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xử lý sự kiện CellClick
        private void dgKhuyenmai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgKhuyenmai.Rows[e.RowIndex];
                selectedId = Convert.ToInt32(row.Cells["MaUngDung"].Value);
                txtChietkhau.Text = row.Cells["ChietKhau"].Value.ToString();
            }
        }

        // Xử lý sự kiện btnThaydoi
        private void btnThaydoi_Click(object sender, EventArgs e)
        {
            if (selectedId != -1)
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("UpdateChietKhau", myDb.getConnection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MaUngDung", selectedId);
                        cmd.Parameters.AddWithValue("@ChietKhau", decimal.Parse(txtChietkhau.Text));

                        myDb.openConnection();
                        cmd.ExecuteNonQuery();
                        myDb.closeConnection();

                        MessageBox.Show("Thay đổi chiết khấu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thay đổi chiết khấu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Xử lý sự kiện btnXoa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (selectedId != -1)
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM UNG_DUNG WHERE MaUngDung = @MaUngDung", myDb.getConnection))
                    {
                        cmd.Parameters.AddWithValue("@MaUngDung", selectedId);

                        myDb.openConnection();
                        cmd.ExecuteNonQuery();
                        myDb.closeConnection();

                        MessageBox.Show("Đã xóa ứng dụng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa ứng dụng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
