using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace QuanLyDoDienTu.view.StaffForm
{
    public partial class QL_Don_Hang : Form
    {
        private int selectedMaDH = -1; // Biến để lưu mã đơn hàng được chọn
        private string sdtKH;
        private string emailKH;

        // Khởi tạo đối tượng MY_DB
        private MY_DB myDb = new MY_DB();

        public QL_Don_Hang()
        {
            InitializeComponent();
        }

        private void QL_Don_Hang_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("GetDonHang", myDb.getConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dgDonhang.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgDonhang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Kiểm tra và chuyển đổi MaDH
                this.selectedMaDH = e.RowIndex;
                if (dgDonhang.Rows[e.RowIndex].Cells["MaDH"].Value != null &&
                    int.TryParse(dgDonhang.Rows[e.RowIndex].Cells["MaDH"].Value.ToString(), out int selectedMaDH))
                {
                    // Lấy trạng thái đơn hàng nếu có
                    string trangThaiDonHang = dgDonhang.Rows[e.RowIndex].Cells["TrangThaiDonHang"].Value?.ToString();

                    // Kiểm tra xem MaKH có tồn tại không
                    if (dgDonhang.Rows[e.RowIndex].Cells["MaKH"].Value == null ||
                        !int.TryParse(dgDonhang.Rows[e.RowIndex].Cells["MaKH"].Value.ToString(), out int maKH))
                    {
                        MessageBox.Show("Khách hàng không tồn tại!");
                        return;
                    }

                    // Lấy thông tin nhà sản xuất
                    GetNSXInfo(maKH);

                    // Thiết lập trạng thái cho ComboBox
                    if (!string.IsNullOrEmpty(trangThaiDonHang))
                    {
                        cbbTrangthai.SelectedItem = trangThaiDonHang;
                    }
                }
                else
                {
                    MessageBox.Show("Dữ liệu đơn hàng không hợp lệ.");
                }
            }

        }

        private void GetNSXInfo(int maKH)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("GetKhachHangInfo", myDb.getConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaKH", maKH);

                    myDb.openConnection();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            sdtKH = reader["SDT"].ToString();
                            emailKH = reader["Email"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy thông tin khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                myDb.closeConnection();
            }
        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            if (dgDonhang.SelectedRows.Count > 0)
            {
                int maDonHang = Convert.ToInt32(dgDonhang.SelectedRows[0].Cells["MaDH"].Value);
                string trangThaiMoi = cbbTrangthai.SelectedItem.ToString();

                try
                {
                    using (SqlCommand cmd = new SqlCommand("UpdateTrangThaiDonHang", myDb.getConnection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MaDH", maDonHang);
                        cmd.Parameters.AddWithValue("@TrangThaiDonHang", trangThaiMoi);

                        myDb.openConnection();
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Cập nhật trạng thái thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật trạng thái: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    myDb.closeConnection();
                }
            }
        }

        private void btnXemchitiet_Click(object sender, EventArgs e)
        {
            if (selectedMaDH > 0)
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("GetChiTietSanPhamDonHang", myDb.getConnection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MaDH", selectedMaDH);

                        myDb.openConnection();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                StringBuilder chiTietSanPham = new StringBuilder();
                                chiTietSanPham.AppendLine("Chi tiết sản phẩm cho đơn hàng: " + selectedMaDH.ToString());
                                chiTietSanPham.AppendLine("-------------------------------------------");

                                while (reader.Read())
                                {
                                    string maSP = reader["MaSP"].ToString();
                                    string soLuong = reader["SoLuong"].ToString();
                                    string donGia = reader["DonGia"].ToString();

                                    chiTietSanPham.AppendLine("Mã sản phẩm: " + maSP);
                                    chiTietSanPham.AppendLine("Số lượng: " + soLuong);
                                    chiTietSanPham.AppendLine("Đơn giá: " + donGia);
                                    chiTietSanPham.AppendLine("-------------------------------------------");
                                }

                                MessageBox.Show(chiTietSanPham.ToString(), "Chi tiết sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy chi tiết sản phẩm cho đơn hàng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy chi tiết sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    myDb.closeConnection();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn đơn hàng để xem chi tiết.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLienhe_Click(object sender, EventArgs e)
        {
            if (selectedMaDH > 0)
            {
                if (!string.IsNullOrEmpty(sdtKH) && !string.IsNullOrEmpty(emailKH))
                {
                    Lien_He lienHe = new Lien_He(sdtKH, emailKH);
                    lienHe.Show();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một nhà sản xuất trước.");
                }
            }
        }
    }
}
