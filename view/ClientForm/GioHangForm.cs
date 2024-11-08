using QuanLyDoDienTu.entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyDoDienTu.view.ClientForm
{
    public partial class GioHangForm : Form
    {
        private List<SanPhamTrongGio> gioHang;
        private MY_DB db = new MY_DB();
        private int maKH;

        public GioHangForm(int maKH, List<SanPhamTrongGio> sanPhams)
        {
            InitializeComponent();
            gioHang = sanPhams;
            dgvGioHang.DataSource = gioHang;
            SetupDataGridViewColumns(); // Thiết lập tiêu đề cột
            LoadUngDung();
            UpdateTongTien();
            this.maKH = maKH;
        }

        // Tải dữ liệu từ bảng UNG_DUNG vào ComboBox cbUngDung
        private void LoadUngDung()
        {
            try
            {
                db.openConnection();
                // Gọi procedure sp_GetUngDung
                SqlCommand cmd = new SqlCommand("sp_GetAllApplications", db.getConnection);
                cmd.CommandType = CommandType.StoredProcedure; // Thiết lập loại là Stored Procedure

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                cbUngDung.DataSource = dt;
                cbUngDung.DisplayMember = "TenUngDung";
                cbUngDung.ValueMember = "MaUngDung";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                db.closeConnection();
            }
        }

        // Tính và cập nhật tổng tiền
        private void UpdateTongTien()
        {
            int tongTien = gioHang.Sum(sp => sp.ThanhTien);
            txtTongTien.Text = tongTien.ToString();
        }

        // Xử lý sự kiện thay đổi số lượng
        private void btnThayDoi_Click(object sender, EventArgs e)
        {
            if (dgvGioHang.SelectedRows.Count > 0 && int.TryParse(txtSoLuong.Text, out int soLuongMoi))
            {
                int selectedRowIndex = dgvGioHang.SelectedRows[0].Index;
                int maSP = gioHang[selectedRowIndex].MaSP;

                // Kết nối đến cơ sở dữ liệu để lấy số lượng hiện có trong SAN_PHAM
                int soLuongHienCo = 0;

                try
                {
                    db.openConnection(); // Mở kết nối cơ sở dữ liệu từ MY_DB

                    string query = "SELECT SoLuong FROM SAN_PHAM WHERE MaSP = @MaSP";
                    SqlCommand cmd = new SqlCommand(query, db.getConnection);
                    cmd.Parameters.AddWithValue("@MaSP", maSP);

                    soLuongHienCo = (int)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                finally
                {
                    db.closeConnection(); // Đóng kết nối sau khi thực hiện truy vấn
                }

                // Kiểm tra số lượng mới có lớn hơn số lượng hiện có không
                if (soLuongMoi > soLuongHienCo)
                {
                    MessageBox.Show($"Số lượng yêu cầu vượt quá số lượng hiện có ({soLuongHienCo}). Vui lòng nhập lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Nếu số lượng hợp lệ, cập nhật số lượng trong giỏ hàng
                gioHang[selectedRowIndex].SoLuong = soLuongMoi;

                // Cập nhật lại DataGridView và tổng tiền
                dgvGioHang.Refresh();
                UpdateTongTien();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm và nhập số lượng hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Xử lý sự kiện tạo đơn hàng
        private void btnTaoDonHang_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = null;

            try
            {
                // Chuẩn bị danh sách sản phẩm
                DataTable sanPhamDonHang = new DataTable();
                sanPhamDonHang.Columns.Add("MaSP", typeof(int));
                sanPhamDonHang.Columns.Add("SoLuong", typeof(int));

                foreach (var sanPham in gioHang)
                {
                    sanPhamDonHang.Rows.Add(sanPham.MaSP, sanPham.SoLuong);
                }

                // Khởi tạo SqlCommand
                cmd = new SqlCommand("sp_TaoDonHang", db.getConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaKH", this.maKH);
                cmd.Parameters.AddWithValue("@MaUngDung", cbUngDung.SelectedValue);
                cmd.Parameters.AddWithValue("@TrangThai", "Chờ xác nhận");
                cmd.Parameters.AddWithValue("@TriGia", Convert.ToInt32(txtTongTien.Text));

                // Truyền bảng dữ liệu sản phẩm vào parameter
                SqlParameter tvpParam = cmd.Parameters.AddWithValue("@SanPhamDonHang", sanPhamDonHang);
                tvpParam.SqlDbType = SqlDbType.Structured;

                // Mở kết nối qua MY_DB và thực thi command
                db.openConnection();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Đơn hàng đã được tạo thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                // Đảm bảo đóng kết nối và giải phóng tài nguyên
                if (cmd != null)
                {
                    cmd.Dispose();
                }
                db.closeConnection();
            }
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvGioHang.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dgvGioHang.SelectedRows[0].Index;
                gioHang.RemoveAt(selectedRowIndex);

                // Cập nhật lại DataGridView và tổng tiền
                dgvGioHang.DataSource = null; // Bỏ dữ liệu cũ
                dgvGioHang.DataSource = gioHang; // Gán lại dữ liệu đã cập nhật
                UpdateTongTien();

                MessageBox.Show("Đã xóa sản phẩm khỏi giỏ hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SetupDataGridViewColumns()
        {
            dgvGioHang.AutoGenerateColumns = false; // Tắt tự động tạo cột
            //dgvGioHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; // Tự động điều chỉnh kích thước cột theo nội dung

            // Xóa các cột cũ nếu có
            dgvGioHang.Columns.Clear();

            // Thêm cột MaSP
            dgvGioHang.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MaSP",
                HeaderText = "Mã Sản Phẩm",
                Name = "MaSPColumn"
            });

            // Thêm cột TenSP
            dgvGioHang.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TenSP",
                HeaderText = "Tên Sản Phẩm",
                Name = "TenSPColumn"
            });

            // Thêm cột Gia
            dgvGioHang.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Gia",
                HeaderText = "Giá",
                Name = "GiaColumn"
            });

            // Thêm cột SoLuong
            dgvGioHang.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SoLuong",
                HeaderText = "Số Lượng",
                Name = "SoLuongColumn"
            });

            // Thêm cột ThanhTien
            dgvGioHang.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ThanhTien",
                HeaderText = "Thành Tiền",
                Name = "ThanhTienColumn"
            });

            // Tự động điều chỉnh chiều cao hàng
            dgvGioHang.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void GioHangForm_Load(object sender, EventArgs e)
        {

        }
    }
}
