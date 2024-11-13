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
    public partial class DanhGiaSanPham : Form
    {
        private int maKH;
        private MY_DB db = new MY_DB();

        public DanhGiaSanPham(int maKH)
        {
            InitializeComponent();
            this.maKH = maKH;
            CustomizeComponents();
            LoadSanPhamDaMua();
        }

        private void CustomizeComponents()

        {
            txtDanhGia.Enter += (s, e) =>
            {
                if (txtDanhGia.Text == "Nhập đánh giá của bạn...")
                {
                    txtDanhGia.Text = "";
                    txtDanhGia.ForeColor = Color.Black;
                }
            };

            txtDanhGia.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtDanhGia.Text))
                {
                    txtDanhGia.Text = "Nhập đánh giá của bạn...";
                    txtDanhGia.ForeColor = Color.Gray;
                }
            };

            // Create and setup Button for submitting review

            btnSubmit.Click += (s, e) => SubmitDanhGia(lbSanPham.SelectedValue?.ToString(), txtDanhGia.Text, (int)numRating.Value);
        }
        private void LoadSanPhamDaMua()
        {
            try
            {
                SqlConnection conn = db.getConnection;
                db.openConnection();

                string query = @"select * from dbo.GetSanPhamDaGiao(@maKH)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@maKH", maKH);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Find the ListBox by name and set its data source
                ListBox lbSanPham = (ListBox)this.Controls.Find("lbSanPham", true).FirstOrDefault();
                if (lbSanPham != null)
                {
                    lbSanPham.DataSource = dt;
                    lbSanPham.DisplayMember = "TenSP";
                    lbSanPham.ValueMember = "MaSP";
                }
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

        private void SubmitDanhGia(string maSP, string danhGia, int diemDanhGia)
        {
            if (string.IsNullOrEmpty(maSP))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm để đánh giá!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                SqlConnection conn = db.getConnection;
                db.openConnection();

                string query = @"INSERT INTO DANH_GIA (MaSP, MaKH, DiemDanhGia, NoiDungDanhGia, NgayDanhGia) 
                                VALUES (@maSP, @maKH, @diemDanhGia, @noiDungDanhGia, GETDATE())";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@maSP", maSP);
                cmd.Parameters.AddWithValue("@maKH", maKH);
                cmd.Parameters.AddWithValue("@diemDanhGia", diemDanhGia);
                cmd.Parameters.AddWithValue("@noiDungDanhGia", danhGia);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Đánh giá đã được gửi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void DanhGiaSanPham_Load(object sender, EventArgs e)
        {

        }
    }
}
