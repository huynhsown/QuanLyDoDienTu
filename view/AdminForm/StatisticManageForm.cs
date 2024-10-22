using FastReport.DataVisualization.Charting;
using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyDoDienTu.view.AdminForm
{
    public partial class StatisticManageForm : Form
    {
        public StatisticManageForm()
        {
            InitializeComponent();
        }

        private void StatisticManageForm_Load(object sender, EventArgs e)
        {
            LoadChartData();
        }

        private void LoadChartData()
        {
            // Tạo một DataTable và thêm dữ liệu vào nó
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Category", typeof(string));
            dataTable.Columns.Add("Value", typeof(int));

            // Thêm dữ liệu vào DataTable
            dataTable.Rows.Add("Category 1", 10);
            dataTable.Rows.Add("Category 2", 20);
            dataTable.Rows.Add("Category 3", 30);
            dataTable.Rows.Add("Category 4", 25);
            dataTable.Rows.Add("Category 5", 15);

            // Thiết lập biểu đồ
            chartRevenue.Series.Clear();
            chartRevenue.ChartAreas.Clear();

            // Tạo một ChartArea mới
            ChartArea chartArea = new ChartArea();
            chartRevenue.ChartAreas.Add(chartArea);

            // Tạo một Series mới
            Series series = new Series("MySeries")
            {
                ChartType = SeriesChartType.Bar // Thay đổi loại biểu đồ nếu cần
            };

            // Đổ dữ liệu vào Series
            foreach (DataRow row in dataTable.Rows)
            {
                series.Points.AddXY(row["Category"].ToString(), row["Value"]);
            }

            // Thêm Series vào biểu đồ
            chartRevenue.Series.Add(series);

            // Tùy chỉnh biểu đồ
            chartRevenue.Titles.Add("Biểu đồ thống kê");
            chartRevenue.ChartAreas[0].AxisX.Title = "Danh mục";
            chartRevenue.ChartAreas[0].AxisY.Title = "Giá trị";
        }
    }
}
