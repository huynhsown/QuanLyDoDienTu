using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDoDienTu.entity
{
    public class DonHangChiTiet
    {
        public int MaDH { get; set; }
        public DateTime NgayDatHang { get; set; }
        public string TrangThaiDonHang { get; set; }
        public decimal TriGia { get; set; }
        public int MaUngDung { get; set; }
        public int MaKH { get; set; }

        // Chi tiết sản phẩm đơn hàng
        public List<ChiTietSanPham> SanPhamDonHang { get; set; }

        // Thông tin thanh toán
        public bool DaThanhToan { get; set; }
    }

    public class ChiTietSanPham
    {
        public int MaSPDonHang { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public int MaSP { get; set; }
    }
}

