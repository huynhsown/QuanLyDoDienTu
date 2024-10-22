using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDoDienTu.entity
{
    public class App
    {
        public int MaUngDung { get; set; }
        public string TenUngDung { get; set; }
        public int ChietKhau { get; set; }

        // Constructor không tham số (mặc định)
        public App() { }

        // Constructor có tham số
        public App(int maUngDung, string tenUngDung, int chietKhau)
        {
            this.MaUngDung = maUngDung;
            this.TenUngDung = tenUngDung;
            this.ChietKhau = chietKhau;
        }
    }
}
