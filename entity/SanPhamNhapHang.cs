using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDoDienTu.entity
{
    public class SanPhamNhapHang
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public decimal Gia { get; set; }
        public int SoLuong { get; set; }
        public string TinhTrang { get; set; }

        // Thông tin đơn nhập hàng
        public List<DonNhap> DonNhapHang { get; set; }
    }

    public class DonNhap
    {
        public int MaDon { get; set; }
        public DateTime NgayNhap { get; set; }
        public decimal GiaTri { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public int MaNSX { get; set; }
    }
}
