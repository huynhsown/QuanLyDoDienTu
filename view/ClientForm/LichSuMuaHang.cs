using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyDoDienTu.view.ClientForm
{
    public partial class LichSuMuaHang : Form
    {
        private int maKH;
        private MY_DB db = new MY_DB();

        public LichSuMuaHang(int maKH)
        {
            InitializeComponent();
            this.maKH = maKH;
            LoadLichSuMuaHang();
        }

        private void LoadLichSuMuaHang()
        {
            try
            {
                SqlConnection conn = db.getConnection;
                db.openConnection();

                // Gọi Stored Procedure thay vì dùng truy vấn trực tiếp
                SqlCommand cmd = new SqlCommand("SELECT * FROM fnGetLichSuMuaHang(@maKH)", conn);
                cmd.Parameters.AddWithValue("@maKH", maKH);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvOrderHistory.DataSource = dt;
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

        // Xử lý sự kiện nhấn nút Xem Chi Tiết
        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            if (dgvOrderHistory.SelectedRows.Count > 0)
            {
                int maDH = Convert.ToInt32(dgvOrderHistory.SelectedRows[0].Cells["MaDH"].Value);
                LoadChiTietDonHang(maDH);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một đơn hàng để xem chi tiết.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Hàm load chi tiết đơn hàng
        private void LoadChiTietDonHang(int maDH)
        {
            try
            {
                SqlConnection conn = db.getConnection;
                db.openConnection();

                SqlCommand cmd = new SqlCommand("select * from fnLayChiTietDonHang(@MaDH)", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaDH", maDH);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvOrderDetails.DataSource = dt;
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

        private void LichSuMuaHang_Load(object sender, EventArgs e)
        {

        }
    }
}
