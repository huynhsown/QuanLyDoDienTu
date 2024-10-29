using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDoDienTu.entity
{
    public class SanPhamTrongGio
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public int Gia { get; set; }
        public int SoLuong { get; set; }
        public int ThanhTien
        {
            get { return Gia * SoLuong; }
        }
    }
}
