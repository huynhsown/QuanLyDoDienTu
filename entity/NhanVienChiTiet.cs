using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDoDienTu.entity
{
    public class NhanVienChiTiet
    {
        public int MaNV { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }

        // Thông tin công việc
        public CongViec CongViecHienTai { get; set; }

        // Lịch làm việc
        public List<CaLamViec> CaLamViec { get; set; }
    }

    public class CongViec
    {
        public int MaCV { get; set; }
        public string TenCV { get; set; }
        public decimal Luong { get; set; }
    }

    public class CaLamViec
    {
        public int MaCa { get; set; }
        public DateTime ThoiGianBatDau { get; set; }
        public DateTime ThoiGianKetThuc { get; set; }
    }
}
