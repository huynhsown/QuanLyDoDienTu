using QuanLyDoDienTu.entity;
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

namespace QuanLyDoDienTu.view.AdminForm
{
    public partial class PurchaseOrderInformation : Form
    {
        private int id;

        bool isEdit = false;
        private MY_DB myDB = new MY_DB();
        List<Product> products = new List<Product>();
        List<Manufacturer> manufacturers = new List<Manufacturer>();

        public PurchaseOrderInformation(int id)
        {
            InitializeComponent();
            this.id = id;
            isEdit = true;
            btn_Add.Visible = false;
        }

        public PurchaseOrderInformation()
        {
            InitializeComponent();
            btn_Edit.Visible = false;
        }

        private void PurchaseOrderInformation_Load(object sender, EventArgs e)
        {

            try
            {
                SqlConnection connection = myDB.getConnection;

                connection.Open();
                using (SqlCommand cmd = new SqlCommand(@"SELECT * FROM SAN_PHAM", connection))
                {
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sqlDataAdapter.Fill(dt); // Fill the second DataTable (dt instead of dataTable)

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int MaSanPham = Convert.ToInt32(dt.Rows[i]["MaSP"]);
                        string tenSP = dt.Rows[i]["TenSP"].ToString();
                        int gia = Convert.ToInt32(dt.Rows[i]["Gia"]);
                        int soLuong = Convert.ToInt32(dt.Rows[i]["SoLuong"]);
                        string tinhTrang = dt.Rows[i]["TinhTrang"].ToString();

                        products.Add(new Product(MaSanPham, tenSP, gia, soLuong, tinhTrang));
                    }

                    cb_NameProduct.DataSource = products;
                    cb_NameProduct.DisplayMember = "TenSP"; // Hiển thị tên sản phẩm
                    cb_NameProduct.ValueMember = "MaSP"; // Giá trị của từng mục là mã sản phẩm
                }

                using (SqlCommand cmd = new SqlCommand(@"SELECT * FROM NHA_SAN_XUAT", connection))
                {
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sqlDataAdapter.Fill(dt); // Fill the second DataTable (dt instead of dataTable)

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int maNSX = Convert.ToInt32(dt.Rows[i]["MaNSX"]);
                        string tenNSX = dt.Rows[i]["TenNSX"].ToString();
                        string sdt = dt.Rows[i]["SDT"].ToString();
                        string email = dt.Rows[i]["Email"].ToString();

                        manufacturers.Add(new Manufacturer(maNSX, tenNSX, sdt, email));
                    }

                    cb_NameManufacturer.DataSource = manufacturers;
                    cb_NameManufacturer.DisplayMember = "TenNSX"; // Hiển thị tên sản phẩm
                    cb_NameManufacturer.ValueMember = "MaNSX"; // Giá trị của từng mục là mã sản phẩm
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (isEdit)
            {
                String query = @"SELECT * FROM DON_NHAP_HANG WHERE MaDon = @maDon";
                try
                {
                    SqlConnection connection = myDB.getConnection;

                    connection.Open(); // Mở kết nối

                    // Query Staff Information
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@maDon", id); // Gán giá trị cho tham số

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable); // Lấy dữ liệu vào DataTable

                        // Kiểm tra số lượng dòng
                        if (dataTable.Rows.Count != 1)
                        {
                            MessageBox.Show("Không tìm thấy hoặc có nhiều hơn một kết quả.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Close(); // Đóng form nếu không tìm thấy dữ liệu
                            return; // Thoát khỏi hàm
                        }

                        // Lấy dữ liệu từ DataTable
                        DataRow dr = dataTable.Rows[0]; // Đảm bảo rằng DataTable có ít nhất 1 hàng
                        tb_Id.Text = dr["MaDon"].ToString(); // Gán giá trị Mã NV vào TextBox
                        dtp_Date.Value = Convert.ToDateTime(dr["NgayNhap"]);
                        tb_Quantity.Text = dr["SoLuong"].ToString();
                        int maSP = Convert.ToInt32(dr["MaSP"]);
                        int maNSX = Convert.ToInt32(dr["MaNSX"]);

                        foreach (var item in cb_NameProduct.Items)
                        {
                            // Assuming the item is of a custom type with an Id property
                            if (((Product)item).MaSP == maSP)
                            {
                                cb_NameProduct.SelectedItem = item;
                                break;
                            }
                        }

                        foreach (var item in cb_NameManufacturer.Items)
                        {
                            // Assuming the item is of a custom type with an Id property
                            if (((Manufacturer)item).MaNSX == maNSX)
                            {
                                cb_NameManufacturer.SelectedItem = item;
                                break;
                            }
                        }

                    }

                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }






        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }




        private void btn_Add_Click_1(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connection = myDB.getConnection;
                connection.Open();

                using (SqlCommand command = new SqlCommand("InsertDonNhapHang", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@NgayNhap", dtp_Date.Value);
                    command.Parameters.AddWithValue("@GiaTri", 0); // Assuming you want to set this to 0 as in your original code
                    command.Parameters.AddWithValue("@SoLuong", Convert.ToInt32(tb_Quantity.Text));
                    command.Parameters.AddWithValue("@DonGia", 0); // Assuming you want to set this to 0 as in your original code
                    command.Parameters.AddWithValue("@MaSP", Convert.ToInt32(cb_NameProduct.SelectedValue));
                    command.Parameters.AddWithValue("@MaNSX", Convert.ToInt32(cb_NameManufacturer.SelectedValue));

                    int result = command.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Thêm đơn nhập hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Thêm đơn nhập hàng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connection = myDB.getConnection;
                connection.Open();

                using (SqlCommand command = new SqlCommand("UpdateDonNhapHang", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@MaDon", Convert.ToInt32(tb_Id.Text));
                    command.Parameters.AddWithValue("@NgayNhap", dtp_Date.Value);
                    command.Parameters.AddWithValue("@SoLuong", Convert.ToInt32(tb_Quantity.Text));
                    command.Parameters.AddWithValue("@MaSP", Convert.ToInt32(cb_NameProduct.SelectedValue));
                    command.Parameters.AddWithValue("@MaNSX", Convert.ToInt32(cb_NameManufacturer.SelectedValue));

                    int result = command.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Cập nhật đơn nhập hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật đơn nhập hàng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
