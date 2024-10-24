using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDoDienTu.view.ClientForm
{
    public partial class GioHangVaDatHang : Form
    {
        private int maKH;
        public GioHangVaDatHang(int maKH)
        {
            InitializeComponent();
            this.maKH = maKH;
        }

        private void GioHangVaDatHang_Load(object sender, EventArgs e)
        {
            loadProducts();
            setUpTable();
        }

        private MY_DB db = new MY_DB();
        DataTable dtAddSP = new DataTable();
        private void loadProducts()
        {
            SqlConnection conn = db.getConnection;
            db.openConnection();
            string query = "SELECT MaSP, TenSP, Gia, SoLuong, TinhTrang FROM SAN_PHAM WHERE SoLuong > 0";
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridViewProducts.DataSource = dt;
        }

        private void setUpTable()
        {
            dtAddSP.Columns.Add("MaSP", typeof(int));
            dtAddSP.Columns.Add("TenSP", typeof(string));
            dtAddSP.Columns.Add("SoLuong", typeof(int));
            dtAddSP.Columns.Add("DonGia", typeof(decimal));
            dtAddSP.Columns.Add("ThanhTien", typeof(decimal), "SoLuong * DonGia");
            dataGridViewCart.DataSource = dtAddSP;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dataGridViewProducts.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewProducts.SelectedRows[0];
                int masp = Convert.ToInt32(selectedRow.Cells["MaSP"].Value);
                string tensp = selectedRow.Cells["TenSP"].Value.ToString();
                decimal gia = Convert.ToDecimal(selectedRow.Cells["Gia"].Value);
                int soluong = Convert.ToInt32(txtQuantity.Text);

                // Kiem tra so luong
                if (soluong > Convert.ToInt32(selectedRow.Cells["SoLuong"].Value))
                {
                    MessageBox.Show("Số lượng không đủ!");
                    return;
                }
                else
                {
                    dtAddSP.Rows.Add(masp, tensp, gia, soluong);
                    updateTongGiaTriGiohang();
                }
            }
        }

        private void updateTongGiaTriGiohang()
        {
            decimal total = 0;
            foreach (DataRow row in dtAddSP.Rows)
            {
                total += Convert.ToDecimal(row["ThanhTien"]);
            }

            txtTotal.Text = $"Tổng tiền: {total:C}";
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            SqlConnection conn = db.getConnection;
            db.openConnection();

            SqlTransaction transaction = conn.BeginTransaction();
            try
            {
                // Tạo nội dung đơn hàng
                string queryInsert = "INSERT DON_HANG (MaKH, NgayDatHang, TrangThaiDonHang, TriGia) OUTPUT INSERTED.MaDH Values (@MaKH, GETDATE(), 'Chờ xác nhận', @total)";
                SqlCommand cmdOrder = new SqlCommand(queryInsert, conn, transaction);
                cmdOrder.Parameters.AddWithValue("@MaKH", GetKHid());
                cmdOrder.Parameters.AddWithValue("@total", CaculateTotal());
                int orderid = (int)cmdOrder.ExecuteScalar();

                // Lưu vào CSDL
                foreach (DataRow row in dtAddSP.Rows)
                {
                    string queryInsertDetails = "INSERT INTO SAN_PHAM_DUOC_CHON (MaSP, MaDH, SoLuong, DonGia) values (@proid, @orderid, @quantity, @price)";
                    SqlCommand cmdDetails = new SqlCommand(queryInsertDetails, conn, transaction);
                    cmdDetails.Parameters.AddWithValue("@proid", row["MaSP"]);
                    cmdDetails.Parameters.AddWithValue("@orderid", orderid);
                    cmdDetails.Parameters.AddWithValue("@quantity", row["SoLuong"]);
                    cmdDetails.Parameters.AddWithValue("@price", row["DonGia"]);
                    cmdDetails.ExecuteNonQuery();
                }

                transaction.Commit();
                MessageBox.Show("Đặt hàng thành công");
                dtAddSP.Clear();
                updateTongGiaTriGiohang();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                MessageBox.Show("Có lỗi xảy ra khi đặt hàng: " + ex.Message);
            }
        }

        private int GetKHid()
        {
            return maKH;
        }

        private decimal CaculateTotal()
        {
            decimal total = 0;
            foreach (DataRow row in dtAddSP.Rows)
            {
                total += Convert.ToDecimal(row["ThanhTien"]);
            }
            return total;
        }
    }
}
