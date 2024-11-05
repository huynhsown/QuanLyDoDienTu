using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Xceed.Words.NET;
namespace QuanLyDoDienTu.view.StaffForm
{
    public partial class Bao_Cao_Su_Co : Form
    {
        public Bao_Cao_Su_Co()
        {
            InitializeComponent();
        }

        private void Bao_Cao_Su_Co_Load(object sender, EventArgs e)
        {

        }

        private void btnXuatBaoCao_Click(object sender, EventArgs e)
        {
            // Tạo tên file Word với định dạng ngày và giờ
            string fileName = "Bao_Cao_Su_Co_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".docx";
            string folderPath = @"C:\He_Quan_Tri_CSDL\Project\Project_Heqtcsdl\Bao_Cao"; // Đường dẫn lưu file
            string filePath = Path.Combine(folderPath, fileName);

            // Kiểm tra và tạo thư mục nếu không tồn tại
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // Tạo tài liệu Word và thêm nội dung
            using (DocX document = DocX.Create(filePath))
            {
                // Thêm tiêu đề báo cáo với cỡ chữ và in đậm
                var title = document.InsertParagraph("Báo cáo sự cố")
                                    .FontSize(20)
                                    .Bold()
                                    .SpacingAfter(20);
                title.Alignment = Xceed.Document.NET.Alignment.center; // Căn giữa

                // Thêm nội dung chi tiết vào tài liệu
                document.InsertParagraph("Tiêu đề: " + txtTieuDe.Text)
                        .FontSize(14)
                        .SpacingAfter(10);

                document.InsertParagraph("Mô tả: " + txtMoTa.Text)
                        .FontSize(12)
                        .SpacingAfter(10);

                document.InsertParagraph("Ngày và giờ: " + dtpThoiGian.Value.ToString())
                        .FontSize(12)
                        .SpacingAfter(10);

                document.InsertParagraph("Phân loại: " + (cbbPhanLoai.SelectedItem ?? "N/A").ToString())
                        .FontSize(12)
                        .SpacingAfter(10);

                document.InsertParagraph("Tên nhân viên: " + txtTenNhanVien.Text)
                        .FontSize(12)
                        .SpacingAfter(10);

                // Lưu tài liệu
                document.Save();
            }

            // Hiển thị thông báo cho người dùng
            MessageBox.Show("Báo cáo đã được xuất ra: " + filePath);
        }
    }
}
