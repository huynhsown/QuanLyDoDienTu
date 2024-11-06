using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDoDienTu.entity
{
    public class LienHe
    {
        public int MaLienHe { get; set; }  // MaKH hoặc MaNSX
        public string HoTenTenNSX { get; set; }  // HoTen hoặc TenNSX
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public string LoaiLienHe { get; set; }  // "KhachHang" hoặc "NhaSanXuat"
    }
}

