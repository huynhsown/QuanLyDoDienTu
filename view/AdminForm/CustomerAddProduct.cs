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
    public partial class CustomerAddProduct : Form
    {
        private int id;
        private int order_id;
        private int app_id;
        private MY_DB myDB = new MY_DB();
        List<Product> products = new List<Product>();
        public CustomerAddProduct(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void CustomerAddProduct_Load(object sender, EventArgs e)
        {
            try
            {
                int staff_job_id;
                SqlConnection connection = myDB.getConnection;

                connection.Open(); // Mở kết nối


                // Query List Job
                using (SqlCommand cmd = new SqlCommand(@"SELECT * FROM SAN_PHAM", connection))
                {
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);

                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        int maSP = Convert.ToInt32(dataTable.Rows[i]["MaSP"]);
                        string tenSP = dataTable.Rows[i]["TenSP"].ToString();
                        int gia = Convert.ToInt32(dataTable.Rows[i]["Gia"]);
                        int soLuong = Convert.ToInt32(dataTable.Rows[i]["SoLuong"]);
                        string tinhTrang = dataTable.Rows[i]["TinhTrang"].ToString();

                        products.Add(new Product(maSP, tenSP, gia, soLuong, tinhTrang));
                    }

                    cb_Product.DataSource = products;
                    cb_Product.DisplayMember = "TenSP"; // Hiển thị tên sản phẩm
                    cb_Product.ValueMember = "MaSP"; // Giá trị của từng mục là mã sản phẩm

                }

                using (SqlCommand cmd = new SqlCommand(@"SELECT * FROM UNG_DUNG", connection))
                {
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);

                    List<App> apps = new List<App>();

                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        int maUngDung = Convert.ToInt32(dataTable.Rows[i]["MaUngDung"]);
                        string tenUngDung = dataTable.Rows[i]["TenUngDung"].ToString();
                        int chietKhau = Convert.ToInt32(dataTable.Rows[i]["ChietKhau"]);

                        // Thêm đối tượng UngDung vào danh sách
                        apps.Add(new App(maUngDung, tenUngDung, chietKhau));
                    }

                    // Thiết lập nguồn dữ liệu cho ComboBox
                    cb_app.DataSource = apps;
                    cb_app.DisplayMember = "TenUngDung"; // Hiển thị tên ứng dụng
                    cb_app.ValueMember = "MaUngDung"; // Giá trị của từng mục là mã ứng dụng
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (nud.Value > 0)
            {
                Product temp = cb_Product.SelectedItem as Product;
                if (temp != null && temp.SoLuong >= nud.Value)
                {
                    // Kiểm tra xem sản phẩm đã tồn tại trong DataGridView chưa
                    bool productExists = false;
                    int existingRowIndex = -1;

                    // Duyệt qua các hàng trong DataGridView để kiểm tra sự tồn tại của sản phẩm
                    foreach (DataGridViewRow row in dgv_Product.Rows)
                    {
                        if (Convert.ToInt32(row.Cells["col_Id"].Value) == temp.MaSP)
                        {
                            productExists = true;
                            existingRowIndex = row.Index;
                            break;
                        }
                    }

                    if (productExists)
                    {
                        // Nếu sản phẩm đã tồn tại, tăng số lượng lên
                        int existingQuantity = Convert.ToInt32(dgv_Product.Rows[existingRowIndex].Cells["col_Num"].Value);
                        dgv_Product.Rows[existingRowIndex].Cells["col_Num"].Value = existingQuantity + Convert.ToInt32(nud.Value);
                    }
                    else
                    {
                        // Nếu sản phẩm không tồn tại, thêm sản phẩm mới vào DataGridView
                        dgv_Product.Rows.Add(temp.MaSP, temp.TenSP, temp.Gia * Convert.ToInt32(nud.Value), Convert.ToInt32(nud.Value), temp.TinhTrang);
                    }

                    // Trừ số lượng sản phẩm trong đối tượng Product
                    temp.SoLuong -= Convert.ToInt32(nud.Value);
                }
                else
                {
                    MessageBox.Show("Khong du so luong");
                }
            }
        }

        private void dgv_Product_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                int id = Convert.ToInt32(dgv_Product.Rows[e.RowIndex].Cells["col_Id"].Value);
                int soLuong = Convert.ToInt32(dgv_Product.Rows[e.RowIndex].Cells["col_Num"].Value);
                if (dgv_Product.Columns[e.ColumnIndex].Name == "col_delete")
                {
                    foreach (Product product in products)
                    {
                        if (product.MaSP == id)
                        {
                            product.SoLuong += soLuong;
                            dgv_Product.Rows.RemoveAt(e.RowIndex);
                            break;
                        }
                    }
                }
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                saveSanPham();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public List<Product> getProducts()
        {
            List<Product> products = new List<Product>();

            foreach (DataGridViewRow row in dgv_Product.Rows)
            {
                // Kiểm tra nếu dòng không phải là dòng trống
                if (row.IsNewRow) continue;

                int maSP = Convert.ToInt32(row.Cells["col_Id"].Value);
                int soLuong = Convert.ToInt32(row.Cells["col_Quantity"].Value);

                Product product = new Product(maSP, soLuong);
                products.Add(product);
            }
            return products;
        }

        public void saveSanPham()
        {
            try
            {
                SqlConnection connection = myDB.getConnection;
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("TaoDonHang", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Thêm tham số đầu vào
                    cmd.Parameters.AddWithValue("@NgayDatHang", DateTime.Now);
                    cmd.Parameters.AddWithValue("@TrangThaiDonHang", "Đang xử lý");
                    cmd.Parameters.AddWithValue("@TriGia", 0);
                    cmd.Parameters.AddWithValue("@MaUngDung", app_id);
                    cmd.Parameters.AddWithValue("@MaKH", id);

                    // Thêm tham số đầu ra
                    SqlParameter maDHParam = new SqlParameter("@MaDH", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(maDHParam);

                    // Thực thi procedure
                    cmd.ExecuteNonQuery();

                    // Lấy giá trị MaDH trả về
                    order_id = (int)maDHParam.Value;
                    btn_create.Visible = false;
                    lb_ano.Text = order_id.ToString();
                }

                List<Product> products = getProducts();
                foreach (var product in products)
                {
                    // Thêm sản phẩm vào SAN_PHAM_DUOC_CHON
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO SAN_PHAM_DUOC_CHON (SoLuong, MaSP, MaDH) VALUES (@SoLuong, @MaSP, @MaDH)", connection))
                    {
                        cmd.Parameters.AddWithValue("@SoLuong", product.SoLuong);
                        cmd.Parameters.AddWithValue("@MaSP", product.MaSP);
                        cmd.Parameters.AddWithValue("@MaDH", order_id);

                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show($"Them san pham {product.TenSP} voi so luong {product.SoLuong} thanh cong");
                        }
                        else
                        {
                            MessageBox.Show($"Them san pham {product.TenSP} voi so luong {product.SoLuong} that bai");
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

        private void btn_create_Click(object sender, EventArgs e)
        {

        }

        private void cb_Product_SelectedIndexChanged(object sender, EventArgs e)
        {
            order_id = Convert.ToInt32(((Product)cb_Product.SelectedItem).MaSP);
        }

        private void cb_app_SelectedIndexChanged(object sender, EventArgs e)
        {
            app_id = Convert.ToInt32(((App)cb_app.SelectedItem).MaUngDung);
        }
    }
}
