using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyDoDienTu.view.StaffForm
{
    public partial class QL_Nhap_Hang : Form
    {
        private MY_DB myDb = new MY_DB();
        private string sdtNSX;
        private string emailNSX;

        public QL_Nhap_Hang()
        {
            InitializeComponent();
        }

        private void QL_Nhap_Hang_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM DON_NHAP_HANG", myDb.getConnection))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dgDonnhaphang.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgDonnhaphang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int maNSX = Convert.ToInt32(dgDonnhaphang.Rows[e.RowIndex].Cells["MaNSX"].Value);
                GetNSXInfo(maNSX);
            }
        }

        private void GetNSXInfo(int maNSX)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("SELECT SDT, Email FROM NHA_SAN_XUAT WHERE MaNSX = @MaNSX", myDb.getConnection))
                {
                    cmd.Parameters.AddWithValue("@MaNSX", maNSX);

                    myDb.openConnection();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            sdtNSX = reader["SDT"].ToString();
                            emailNSX = reader["Email"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy thông tin nhà sản xuất: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                myDb.closeConnection();
            }
        }

        private void btnLienhe_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(sdtNSX) && !string.IsNullOrEmpty(emailNSX))
            {
                Lien_He lienHe = new Lien_He(sdtNSX, emailNSX);
                lienHe.Show();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhà sản xuất trước.");
            }
        }
    }
}
