using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDoDienTu.entity
{
    public class Manufacturer
    {
        public int MaNSX { get; set; } // Mã nhà sản xuất
        public string TenNSX { get; set; } // Tên nhà sản xuất
        public string SDT { get; set; } // Số điện thoại
        public string Email { get; set; } // Địa chỉ email

        // Constructor
        public Manufacturer(int maNSX, string tenNSX, string sdt, string email)
        {
            this.MaNSX = maNSX;
            this.TenNSX = tenNSX;
            this.SDT = sdt;
            this.Email = email;
        }

        // Constructor cho trường hợp không cần mã
        public Manufacturer(string tenNSX, string sdt, string email)
        {
            this.TenNSX = tenNSX;
            this.SDT = sdt;
            this.Email = email;
        }
    }
}
