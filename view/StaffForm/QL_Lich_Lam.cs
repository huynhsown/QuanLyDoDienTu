using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyDoDienTu.view.StaffForm
{
    public partial class QL_Lich_Lam : Form
    {
        private MY_DB myDb = new MY_DB();

        public QL_Lich_Lam()
        {
            InitializeComponent();
        }

        private void QL_Lich_Lam_Load(object sender, EventArgs e)
        {
            LoadData(); // Hiển thị dữ liệu ban đầu
        }

        private void LoadData()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("GetLichLamData", myDb.getConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dgLichLam.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DateTime thoiGianBatDau = dateBatdau.Value;
            DateTime thoiGianKetThuc = dateKetthuc.Value;

            if (thoiGianBatDau >= thoiGianKetThuc)
            {
                MessageBox.Show("Thời gian bắt đầu phải nhỏ hơn thời gian kết thúc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO CA_LAM_VIEC (MaNV, ThoiGianBatDau, ThoiGianKetThuc) VALUES (@MaNV, @ThoiGianBatDau, @ThoiGianKetThuc)", myDb.getConnection))
                {
                    cmd.Parameters.AddWithValue("@MaNV", txtMaNV.Text);
                    cmd.Parameters.AddWithValue("@ThoiGianBatDau", thoiGianBatDau);
                    cmd.Parameters.AddWithValue("@ThoiGianKetThuc", thoiGianKetThuc);

                    myDb.openConnection();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm ca làm việc thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData(); // Cập nhật DataGridView
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi khi thêm ca làm việc: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                myDb.closeConnection();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgLichLam.CurrentRow != null)
            {
                int maNV = Convert.ToInt32(dgLichLam.CurrentRow.Cells["MaNV"].Value);

                try
                {
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM CA_LAM_VIEC WHERE MaNV = @MaNV", myDb.getConnection))
                    {
                        cmd.Parameters.AddWithValue("@MaNV", maNV);

                        myDb.openConnection();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Xóa ca làm việc thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData(); // Cập nhật lại DataGridView
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa ca làm việc: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    myDb.closeConnection();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một ca làm việc để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMaNV.Text))
            {
                int maNV = Convert.ToInt32(txtMaNV.Text);

                try
                {
                    using (SqlCommand cmd = new SqlCommand("UPDATE CA_LAM_VIEC SET ThoiGianBatDau = @ThoiGianBatDau, ThoiGianKetThuc = @ThoiGianKetThuc WHERE MaNV = @MaNV", myDb.getConnection))
                    {
                        cmd.Parameters.AddWithValue("@MaNV", maNV);
                        cmd.Parameters.AddWithValue("@ThoiGianBatDau", dateBatdau.Value);
                        cmd.Parameters.AddWithValue("@ThoiGianKetThuc", dateKetthuc.Value);

                        myDb.openConnection();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Cập nhật ca làm việc thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData(); // Cập nhật lại DataGridView
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật ca làm việc: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    myDb.closeConnection();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một ca làm việc để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgLichLam_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgLichLam.Rows[e.RowIndex];
                txtMaNV.Text = row.Cells["MaNV"].Value.ToString();
                dateBatdau.Value = Convert.ToDateTime(row.Cells["ThoiGianBatDau"].Value);
                dateKetthuc.Value = Convert.ToDateTime(row.Cells["ThoiGianKetThuc"].Value);
            }
        }

        private void btnKetca_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO CA_LAM_VIEC (MaNV, ThoiGianBatDau, ThoiGianKetThuc) VALUES (@MaNV, @ThoiGianBatDau, @ThoiGianKetThuc)", myDb.getConnection))
                {
                    cmd.Parameters.AddWithValue("@MaNV", txtMaNV.Text);
                    cmd.Parameters.AddWithValue("@ThoiGianBatDau", dateBatdau.Value);
                    cmd.Parameters.AddWithValue("@ThoiGianKetThuc", dateKetthuc.Value);

                    myDb.openConnection();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Báo cáo kết thúc ca làm việc thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData(); // Cập nhật DataGridView
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi báo cáo kết thúc ca làm việc: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                myDb.closeConnection();
            }
        }
    }
}
