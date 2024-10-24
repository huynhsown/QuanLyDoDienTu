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

                string query = @"SELECT MaDH, NgayDatHang, TrangThaiDonHang, TriGia FROM DON_HANG WHERE MaKH = @maKH";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@maKH", maKH);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Create and setup DataGridView to display order history
                DataGridView dgvOrderHistory = new DataGridView();
                dgvOrderHistory.DataSource = dt;
                dgvOrderHistory.Location = new Point(20, 20);
                dgvOrderHistory.Size = new Size(600, 300);
                dgvOrderHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Add DataGridView to the form
                this.Controls.Add(dgvOrderHistory);
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
    }
}
