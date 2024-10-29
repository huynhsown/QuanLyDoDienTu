using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyDoDienTu.view.ClientForm
{
    public partial class ThongBaoKhuyenMaiForm : Form
    {
        private MY_DB db = new MY_DB();

        public ThongBaoKhuyenMaiForm()
        {
            InitializeComponent();
        }

        private void ThongBaoKhuyenMaiForm_Load(object sender, EventArgs e)
        {
            LoadKhuyenMai();
        }

        private void LoadKhuyenMai()
        {
            try
            {
                // Sử dụng Stored Procedure để lấy thông tin khuyến mãi từ bảng UNG_DUNG
                SqlCommand cmd = new SqlCommand("sp_GetAllApplications", db.getConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Hiển thị dữ liệu lên DataGridView
                dgvKhuyenMai.DataSource = dt;
                dgvKhuyenMai.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin khuyến mãi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.closeConnection();
            }
        }
    }
}
