using QuanLyDoDienTu.entity;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyDoDienTu.view.ClientForm
{
    public partial class XemSanPham : Form
    {
        private MY_DB db = new MY_DB();
        private int maKH;

        public XemSanPham(int maKH, List<SanPhamTrongGio> gioHang)
        {
            InitializeComponent();
            this.gioHang = gioHang;
            LoadSanPham();
            //SetupDataGridViewColumns(); // Thiết lập tiêu đề cột
        }

        // Load sản phẩm từ cơ sở dữ liệu lên DataGridView
        private void LoadSanPham()
        {
            try
            {
                db.openConnection();

                // Gọi stored procedure sp_GetSanPham
                string query = "select * from fnGetSanPham()";
                SqlCommand cmd = new SqlCommand(query, db.getConnection);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvSanPham.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.closeConnection();
            }
        }

        // Xử lý tìm kiếm sản phẩm
        private void BtnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                db.openConnection();
                SqlCommand cmd = new SqlCommand("select * from fnTimKiemSanPham(@TenSP, @TinhTrang, @GiaTu, @GiaDen)", db.getConnection);

                // Truyền tham số cho stored procedure
                cmd.Parameters.AddWithValue("@TenSP", string.IsNullOrEmpty(txtTimKiem.Text) ? (object)DBNull.Value : txtTimKiem.Text);
                cmd.Parameters.AddWithValue("@TinhTrang", cbTinhTrang.SelectedIndex != 0 ? cbTinhTrang.SelectedItem.ToString() : (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@GiaTu", string.IsNullOrEmpty(txtGiaTu.Text) ? (object)DBNull.Value : Convert.ToInt32(txtGiaTu.Text));
                cmd.Parameters.AddWithValue("@GiaDen", string.IsNullOrEmpty(txtGiaDen.Text) ? (object)DBNull.Value : Convert.ToInt32(txtGiaDen.Text));

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvSanPham.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.closeConnection();
            }
        }

        private List<SanPhamTrongGio> gioHang = new List<SanPhamTrongGio>();

        // Thêm sản phẩm vào giỏ hàng khi người dùng click vào nút Thêm Vào Giỏ Hàng
        private void btnThemVaoGioHang_Click(object sender, EventArgs e)
        {
            if (dgvSanPham.SelectedRows.Count > 0)
            {
                int maSP = Convert.ToInt32(dgvSanPham.SelectedRows[0].Cells["MaSP"].Value);
                string tenSP = dgvSanPham.SelectedRows[0].Cells["TenSP"].Value.ToString();
                int gia = Convert.ToInt32(dgvSanPham.SelectedRows[0].Cells["Gia"].Value);

                // Kiểm tra nếu sản phẩm đã tồn tại trong giỏ hàng
                var sanPhamTonTai = gioHang.FirstOrDefault(sp => sp.MaSP == maSP);
                if (sanPhamTonTai != null)
                {
                    MessageBox.Show("Sản phẩm đã tồn tại trong giỏ hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Nếu chưa tồn tại, thêm sản phẩm vào giỏ hàng
                SanPhamTrongGio sanPham = new SanPhamTrongGio
                {
                    MaSP = maSP,
                    TenSP = tenSP,
                    Gia = gia,
                    SoLuong = 1 // Hoặc có thể cho người dùng chọn số lượng ở đây
                };

                gioHang.Add(sanPham);
                MessageBox.Show("Đã thêm sản phẩm vào giỏ hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để thêm vào giỏ hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SetupDataGridViewColumns()
        {
            dgvSanPham.AutoGenerateColumns = false; // Tắt tự động tạo cột
            //dgvSanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; // Tự động điều chỉnh kích thước cột theo nội dung

            // Xóa các cột cũ nếu có
            dgvSanPham.Columns.Clear();

            // Thêm cột MaSP
            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MaSP",
                HeaderText = "Mã Sản Phẩm",
                Name = "MaSPColumn"
            });

            // Thêm cột TenSP
            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TenSP",
                HeaderText = "Tên Sản Phẩm",
                Name = "TenSPColumn"
            });

            // Thêm cột Gia
            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Gia",
                HeaderText = "Giá",
                Name = "GiaColumn"
            });

            // Thêm cột SoLuong
            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SoLuong",
                HeaderText = "Số Lượng",
                Name = "SoLuongColumn"
            });

            // Thêm cột TinhTrang
            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TinhTrang",
                HeaderText = "Tình Trạng",
                Name = "TinhTrangColumn"
            });

            // Tự động điều chỉnh chiều cao hàng nếu cần
            dgvSanPham.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void XemSanPham_Load(object sender, EventArgs e)
        {

        }
    }
}
