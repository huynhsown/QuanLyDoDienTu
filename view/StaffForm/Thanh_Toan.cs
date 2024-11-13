using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyDoDienTu.view.StaffForm
{
    public partial class Thanh_Toan : Form
    {
        private MY_DB myDb = new MY_DB();
        private int selectedOrderId; // Biến để lưu ID của đơn hàng được chọn

        public Thanh_Toan()
        {
            InitializeComponent();
        }

        private void Thanh_Toan_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM DON_HANG", myDb.getConnection))
                {
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

        private void btnLoc_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbbThanhtoan.SelectedItem?.ToString()))
            {
                LoadData();
                return;
            }

            string selectedStatus = cbbThanhtoan.SelectedItem.ToString();
            bool isPaid = selectedStatus == "Đã thanh toán";

            try
            {
                using (SqlCommand cmd = new SqlCommand("select * from fnLayDonHangTheoTrangThaiThanhToan(@DaThanhToan)", myDb.getConnection))
                {
                    cmd.Parameters.AddWithValue("@DaThanhToan", isPaid);

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dgDonhang.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lọc đơn hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgDonhang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgDonhang.Rows[e.RowIndex];
                selectedOrderId = Convert.ToInt32(row.Cells["MaDH"].Value);
            }
        }

        private void btnBaocao_Click(object sender, EventArgs e)
        {
            if (selectedOrderId > 0)
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(@"
                        SELECT dh.MaDH, dh.NgayDatHang, dh.TrangThaiDonHang, dh.TriGia, kh.MaKH, kh.HoTen
                        FROM DON_HANG dh
                        LEFT JOIN KHACH_HANG kh ON dh.MaKH = kh.MaKH
                        LEFT JOIN THANH_TOAN tt ON dh.MaDH = tt.MaDH
                        WHERE dh.MaDH = @MaDH AND (tt.DaThanhToan IS NULL OR tt.DaThanhToan = 0)", myDb.getConnection))
                    {
                        cmd.Parameters.AddWithValue("@MaDH", selectedOrderId);

                        SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);

                        if (dataTable.Rows.Count > 0)
                        {
                            string report = "Đơn hàng chưa thanh toán:\n";
                            report += "Mã ĐH: " + dataTable.Rows[0]["MaDH"] + "\n";
                            report += "Ngày đặt hàng: " + Convert.ToDateTime(dataTable.Rows[0]["NgayDatHang"]).ToString("dd/MM/yyyy") + "\n";
                            report += "Trạng thái: " + dataTable.Rows[0]["TrangThaiDonHang"] + "\n";
                            report += "Giá trị: " + dataTable.Rows[0]["TriGia"] + " VNĐ\n";
                            report += "Mã KH: " + dataTable.Rows[0]["MaKH"] + "\n";
                            report += "Tên KH: " + dataTable.Rows[0]["HoTen"] + "\n";

                            MessageBox.Show(report, "Báo cáo Đơn hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy thông tin đơn hàng chưa thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tạo báo cáo: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một đơn hàng trước khi báo cáo!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
