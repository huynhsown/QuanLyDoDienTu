using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDoDienTu.entity
{
    public class Product
    {
        public int MaSP { get; set; } // Mã sản phẩm
        public string TenSP { get; set; } // Tên sản phẩm
        public int Gia { get; set; } // Giá sản phẩm
        public int SoLuong { get; set; } // Số lượng sản phẩm
        public string TinhTrang { get; set; } // Tình trạng sản phẩm

        // Constructor
        public Product(int maSP, string tenSP, int gia, int soLuong, string tinhTrang)
        {
            this.MaSP = maSP;
            this.TenSP = tenSP;
            this.Gia = gia;
            this.SoLuong = soLuong;
            this.TinhTrang = tinhTrang;
        }

        public Product(int maSP,  int soLuong)
        {
            this.MaSP = maSP;
            this.SoLuong = soLuong;
        }
    }
}
