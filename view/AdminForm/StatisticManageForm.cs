using FastReport.DataVisualization.Charting;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyDoDienTu.view.AdminForm
{
    public partial class StatisticManageForm : Form
    {
        private MY_DB myDB = new MY_DB();

        public StatisticManageForm()
        {
            InitializeComponent();
        }

        private void StatisticManageForm_Load(object sender, EventArgs e)
        {
            // Mặc định hiển thị doanh thu theo ngày dưới dạng biểu đồ cột
            LoadChartData(true);
        }

        // Hàm để tải dữ liệu và hiển thị biểu đồ cột
        private void LoadChartData(bool isRevenue)
        {
            // Xóa các Series và ChartAreas cũ
            chartRevenue.Series.Clear();
            chartRevenue.ChartAreas.Clear();

            // Tạo một ChartArea mới
            ChartArea chartArea = new ChartArea("MainArea");
            chartRevenue.ChartAreas.Add(chartArea);

            // Tạo Series mới
            Series series = new Series(isRevenue ? "DoanhThuTheoNgay" : "DoanhSoSanPham")
            {
                ChartType = SeriesChartType.Column,  // Cả hai đều là biểu đồ cột
                ChartArea = "MainArea"
            };

            // Đổ dữ liệu vào Series
            if (isRevenue)
            {
                DataTable revenueData = GetOrderStatistics("2024-10-01", "2024-10-31");
                foreach (DataRow row in revenueData.Rows)
                {
                    series.Points.AddXY(row["Ngay"].ToString(), Convert.ToInt32(row["TongTriGia"]));
                }
            }
            else
            {
                DataTable productSalesData = GetProductSalesData();
                foreach (DataRow row in productSalesData.Rows)
                {
                    series.Points.AddXY(row["TenSP"].ToString(), Convert.ToInt32(row["TongSoLuong"]));
                }
            }

            // Thêm Series vào biểu đồ
            chartRevenue.Series.Add(series);

            // Tùy chỉnh tiêu đề và trục
            chartRevenue.Titles.Clear();
            chartRevenue.Titles.Add(isRevenue ? "Doanh Thu Theo Ngày" : "Doanh Số Sản Phẩm");

            chartRevenue.ChartAreas["MainArea"].AxisX.Title = isRevenue ? "Ngày" : "Sản Phẩm";
            chartRevenue.ChartAreas["MainArea"].AxisY.Title = "Giá Trị / Số Lượng";
        }

        // Hàm lấy dữ liệu doanh thu theo ngày
        private DataTable GetOrderStatistics(string fromDate, string toDate)
        {
            DataTable dataTable = new DataTable();
            string query = @"SELECT * FROM dbo.ThongKeDonHangTheoNgay(@TuNgay, @DenNgay) ORDER BY Ngay";

            SqlConnection connection = myDB.getConnection;
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@TuNgay", fromDate);
                command.Parameters.AddWithValue("@DenNgay", toDate);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataTable);
            }

            return dataTable;
        }

        // Hàm lấy dữ liệu doanh số bán sản phẩm
        private DataTable GetProductSalesData()
        {
            DataTable dataTable = new DataTable();
            string query = @"
                SELECT sp.TenSP, SUM(sdc.SoLuong) AS TongSoLuong
                FROM SAN_PHAM sp
                JOIN SAN_PHAM_DUOC_CHON sdc ON sp.MaSP = sdc.MaSP
                GROUP BY sp.TenSP";

            SqlConnection connection = myDB.getConnection;
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataTable);
            }

            return dataTable;
        }

        // Sự kiện khi chọn RadioButton biểu đồ cột cho doanh thu theo ngày
        private void radioRevenue_CheckedChanged(object sender, EventArgs e)
        {
            if (radioRevenue.Checked)
            {
                LoadChartData(true);  // Hiển thị doanh thu theo ngày
            }
        }

        // Sự kiện khi chọn RadioButton biểu đồ cột cho doanh số sản phẩm
        private void radioProductSales_CheckedChanged(object sender, EventArgs e)
        {
            if (radioProductSales.Checked)
            {
                LoadChartData(false);  // Hiển thị doanh số sản phẩm
            }
        }

        private void chartRevenue_Click(object sender, EventArgs e)
        {

        }
    }
}
