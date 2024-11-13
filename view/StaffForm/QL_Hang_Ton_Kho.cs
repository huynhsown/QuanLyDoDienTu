using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyDoDienTu.view.StaffForm
{
    public partial class QL_Hang_Ton_Kho : Form
    {
        private MY_DB myDb = new MY_DB();

        public QL_Hang_Ton_Kho()
        {
            InitializeComponent();
        }

        private void QL_Hang_Ton_Kho_Load(object sender, EventArgs e)
        {
            LoadData(); // Hiển thị dữ liệu ban đầu
        }

        private void LoadData()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM fnGetAllProducts()", myDb.getConnection))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dg_Hang_Ton_Kho.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dg_Hang_Ton_Kho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dg_Hang_Ton_Kho.Rows[e.RowIndex];
                txtSoLuong.Text = selectedRow.Cells["SoLuong"].Value.ToString();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSoLuong.Text))
            {
                if (int.TryParse(txtSoLuong.Text, out int soLuongNhap))
                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.LaySanPhamSoLuongThapHon(@SoLuongNhap)", myDb.getConnection))
                        {
                            cmd.Parameters.AddWithValue("@SoLuongNhap", soLuongNhap);
                            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                            DataTable dataTable = new DataTable();
                            dataAdapter.Fill(dataTable);
                            dg_Hang_Ton_Kho.DataSource = dataTable;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi tìm kiếm sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập số lượng hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập số lượng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnThemDNH_Click(object sender, EventArgs e)
        {
            // Mở form InputForm để nhập mã nhà sản xuất
            InputForm ip = new InputForm();
            if (ip.ShowDialog() == DialogResult.OK)
            {
                string maNSX = ip.MaNSX; // Lấy giá trị MaNSX từ form InputForm

                if (dg_Hang_Ton_Kho.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dg_Hang_Ton_Kho.SelectedRows[0];
                    int maSP = Convert.ToInt32(selectedRow.Cells["MaSP"].Value);
                    int soLuong = Convert.ToInt32(selectedRow.Cells["SoLuong"].Value);
                    int Gia = Convert.ToInt32(selectedRow.Cells["Gia"].Value);
                    DateTime ngayNhap = DateTime.Now; // Lấy thời gian thực

                    try
                    {
                        using (SqlCommand cmd = new SqlCommand("InsertDonNhapHang", myDb.getConnection))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@NgayNhap", ngayNhap);
                            cmd.Parameters.AddWithValue("@GiaTri", Gia * soLuong);
                            cmd.Parameters.AddWithValue("@SoLuong", soLuong);
                            cmd.Parameters.AddWithValue("@DonGia", Gia);
                            cmd.Parameters.AddWithValue("@MaSP", maSP);
                            cmd.Parameters.AddWithValue("@MaNSX", maNSX);

                            myDb.openConnection();
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Đã thêm đơn nhập hàng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Có lỗi xảy ra khi thêm đơn nhập hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi thêm đơn nhập hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        myDb.closeConnection();
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn sản phẩm để thêm vào đơn nhập hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
