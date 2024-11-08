using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyDoDienTu.view.StaffForm
{
    public partial class QL_Khach_Hang : Form
    {
        private MY_DB myDb = new MY_DB();

        public QL_Khach_Hang()
        {
            InitializeComponent();
        }

        private void QL_Khach_Hang_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM KHACH_HANG", myDb.getConnection))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dgKhachhang.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSDT.Text))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("GetKhachHangInfo", myDb.getConnection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SDT", txtSDT.Text);
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);

                        if (dataTable.Rows.Count > 0)
                        {
                            dgKhachhang.DataSource = dataTable;
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            LoadData();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tìm kiếm khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập số điện thoại để tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LoadData();
            }
        }

        private void dgKhachhang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgKhachhang.Rows[e.RowIndex];
                txtRSDT.Text = row.Cells["SDT"].Value.ToString();
                txtREmail.Text = row.Cells["Email"].Value.ToString();
            }
        }

        private void btnThaydoi_Click(object sender, EventArgs e)
        {
            try
            {
                myDb.openConnection();

                if (dgKhachhang.CurrentRow != null)
                {
                    int maKH = Convert.ToInt32(dgKhachhang.CurrentRow.Cells["maKH"].Value);
                    string newSDT = txtRSDT.Text.Trim();
                    string newEmail = txtREmail.Text.Trim();

                    // Kiểm tra xem số điện thoại mới đã tồn tại trong cơ sở dữ liệu hay chưa
                    string queryCheckSDT = "SELECT COUNT(*) FROM KHACH_HANG WHERE SDT = @NewSDT AND maKH <> @MaKH";
                    SqlCommand cmdCheckSDT = new SqlCommand(queryCheckSDT, myDb.getConnection);
                    cmdCheckSDT.Parameters.AddWithValue("@NewSDT", newSDT);
                    cmdCheckSDT.Parameters.AddWithValue("@MaKH", maKH);
                    int countSDT = (int)cmdCheckSDT.ExecuteScalar();

                    // Kiểm tra xem email mới đã tồn tại trong cơ sở dữ liệu hay chưa
                    string queryCheckEmail = "SELECT COUNT(*) FROM KHACH_HANG WHERE Email = @NewEmail AND maKH <> @MaKH";
                    SqlCommand cmdCheckEmail = new SqlCommand(queryCheckEmail, myDb.getConnection);
                    cmdCheckEmail.Parameters.AddWithValue("@NewEmail", newEmail);
                    cmdCheckEmail.Parameters.AddWithValue("@MaKH", maKH);
                    int countEmail = (int)cmdCheckEmail.ExecuteScalar();

                    if (countSDT > 0)
                    {
                        MessageBox.Show("Số điện thoại đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (countEmail > 0)
                    {
                        MessageBox.Show("Email đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Truy vấn SQL để cập nhật SDT và Email
                    string queryUpdate = "UPDATE KHACH_HANG SET SDT = @NewSDT, Email = @NewEmail WHERE maKH = @MaKH";
                    SqlCommand cmdUpdate = new SqlCommand(queryUpdate, myDb.getConnection);
                    cmdUpdate.Parameters.AddWithValue("@NewSDT", newSDT);
                    cmdUpdate.Parameters.AddWithValue("@NewEmail", newEmail);
                    cmdUpdate.Parameters.AddWithValue("@MaKH", maKH);

                    int rowsAffected = cmdUpdate.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy khách hàng để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn khách hàng để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                myDb.closeConnection();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgKhachhang.CurrentRow != null)
            {
                int maKH = Convert.ToInt32(dgKhachhang.CurrentRow.Cells["maKH"].Value);

                DialogResult confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlCommand cmdDelete = new SqlCommand("DeleteKhachHang", myDb.getConnection))
                        {
                            cmdDelete.CommandType = CommandType.StoredProcedure;
                            cmdDelete.Parameters.AddWithValue("@MaKH", maKH);

                            myDb.openConnection();
                            int rowsAffected = cmdDelete.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadData();
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy khách hàng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        myDb.closeConnection();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn khách hàng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
