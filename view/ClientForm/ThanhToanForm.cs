using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyDoDienTu.view.ClientForm
{
    public partial class ThanhToanForm : Form
    {
        private int maKH;
        private MY_DB db = new MY_DB();
        public ThanhToanForm(int maKH)
        {
            InitializeComponent();
            this.maKH = maKH;
            LoadThanhToan();
            cbPhuongThucThanhToan.SelectedIndex = 0; // Mặc định là Trả tiền mặt
        }

        private void LoadThanhToan()
        {
            try
            {
                // Sử dụng Stored Procedure thay vì truy vấn trực tiếp
                SqlCommand cmd = new SqlCommand("sp_LoadThanhToan", db.getConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaKH", this.maKH);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Thêm cột hiển thị trạng thái thanh toán dưới dạng chuỗi
                dt.Columns.Add("TrangThaiThanhToan", typeof(string));

                foreach (DataRow row in dt.Rows)
                {
                    bool daThanhToan = (bool)row["DaThanhToan"];
                    row["TrangThaiThanhToan"] = daThanhToan ? "Đã thanh toán" : "Chưa thanh toán";
                }

                // Hiển thị dữ liệu trong DataGridView
                dgvThanhToan.DataSource = dt;
                dgvThanhToan.Columns["DaThanhToan"].Visible = false; // Ẩn cột Boolean gốc nếu không cần thiết
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu thanh toán: " + ex.Message);
            }
        }


        private void cbPhuongThucThanhToan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPhuongThucThanhToan.SelectedItem.ToString() == "Chuyển khoản")
            {
                gbChuyenKhoan.Visible = true;

                // Lấy tên khách hàng từ CSDL dựa trên MaKH
                string tenKhachHang = LayTenKhachHang(maKH);

                // Kiểm tra xem người dùng đã chọn đơn hàng nào chưa
                if (dgvThanhToan.SelectedRows.Count > 0)
                {
                    var maDonHang = dgvThanhToan.SelectedRows[0].Cells["MaDH"].Value.ToString();
                    var soTien = dgvThanhToan.SelectedRows[0].Cells["TriGia"].Value.ToString();

                    txtNoiDungChuyenKhoan.Text = $"{tenKhachHang} - ĐH {maDonHang} - {soTien} VND";
                }
            }
            else
            {
                gbChuyenKhoan.Visible = false;
            }
        }

        // Phương thức để lấy tên khách hàng từ MaKH
        private string LayTenKhachHang(int maKH)
        {
            string tenKhachHang = "Tên khách hàng không tìm thấy";
            try
            {
                string query = "SELECT HoTen FROM KHACH_HANG WHERE MaKH = @MaKH";
                SqlCommand cmd = new SqlCommand(query, db.getConnection);
                cmd.Parameters.AddWithValue("@MaKH", maKH);

                db.openConnection();
                var result = cmd.ExecuteScalar();
                if (result != null)
                {
                    tenKhachHang = result.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy tên khách hàng: " + ex.Message);
            }
            finally
            {
                db.closeConnection();
            }
            return tenKhachHang;
        }


        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (dgvThanhToan.SelectedRows.Count > 0)
            {
                var selectedRow = dgvThanhToan.SelectedRows[0];
                var maDonHang = selectedRow.Cells["MaDH"].Value.ToString();
                var soTien = selectedRow.Cells["TriGia"].Value.ToString(); // Lấy giá trị TriGia

                if (cbPhuongThucThanhToan.SelectedItem.ToString() == "Trả tiền mặt")
                {
                    MessageBox.Show("Đã xác thực thanh toán cho đơn hàng " + maDonHang, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (cbPhuongThucThanhToan.SelectedItem.ToString() == "Chuyển khoản")
                {
                    MessageBox.Show("Nội dung chuyển khoản:\n" + txtNoiDungChuyenKhoan.Text, "Thông tin chuyển khoản", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một đơn hàng để thanh toán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}
