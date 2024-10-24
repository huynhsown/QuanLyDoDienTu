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
    public partial class XemSanPham : Form
    {
        private MY_DB db = new MY_DB();
        public XemSanPham(int maKH)
        {
            InitializeComponent();
            //InitializeComponent1();
            LoadSanPham();
        }


        private void LoadSanPham()
        {
            try
            {
                db.openConnection();
                string query = "SELECT TenSP, Gia, TinhTrang, SoLuong FROM SAN_PHAM";
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

        private void BtnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                db.openConnection();

                string query = "SELECT TenSP, Gia, TinhTrang, SoLuong FROM SAN_PHAM WHERE 1=1";
                if (!string.IsNullOrEmpty(txtTimKiem.Text))
                {
                    query += " AND TenSP LIKE @TenSP";
                }
                if (cbTinhTrang.SelectedIndex != 0)
                {
                    query += " AND TinhTrang = @TinhTrang";
                }
                if (!string.IsNullOrEmpty(txtGiaTu.Text))
                {
                    query += " AND Gia >= @GiaTu";
                }
                if (!string.IsNullOrEmpty(txtGiaDen.Text))
                {
                    query += " AND Gia <= @GiaDen";
                }

                SqlCommand cmd = new SqlCommand(query, db.getConnection);
                if (!string.IsNullOrEmpty(txtTimKiem.Text))
                {
                    cmd.Parameters.AddWithValue("@TenSP", "%" + txtTimKiem.Text + "%");
                }
                if (cbTinhTrang.SelectedIndex != 0)
                {
                    cmd.Parameters.AddWithValue("@TinhTrang", cbTinhTrang.SelectedItem.ToString());
                }
                if (!string.IsNullOrEmpty(txtGiaTu.Text))
                {
                    cmd.Parameters.AddWithValue("@GiaTu", Convert.ToInt32(txtGiaTu.Text));
                }
                if (!string.IsNullOrEmpty(txtGiaDen.Text))
                {
                    cmd.Parameters.AddWithValue("@GiaDen", Convert.ToInt32(txtGiaDen.Text));
                }

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
    }
}
