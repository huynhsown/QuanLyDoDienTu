using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDoDienTu.view.ClientForm
{
    public partial class MainForm : Form
    {
        private int maKH;
        public MainForm(int maKH)
        {
            InitializeComponent();
            this.maKH = maKH;
        }


        // Event handler for ThongTinCaNhan button click
        private void BtnThongTinCaNhan_Click(object sender, EventArgs e)
        {
            ThongTinCaNhan thongTinCaNhanForm = new ThongTinCaNhan(maKH); // Replace 1 with appropriate customer ID
            thongTinCaNhanForm.Show();
        }

        // Event handler for GioHangVaDatHang button click
        private void BtnGioHangVaDatHang_Click(object sender, EventArgs e)
        {
            GioHangVaDatHang gioHangVaDatHangForm = new GioHangVaDatHang(maKH); // Replace 1 with appropriate customer ID
            gioHangVaDatHangForm.Show();
        }

        // Event handler for LichSuMuaHang button click
        private void BtnLichSuMuaHang_Click(object sender, EventArgs e)
        {
            LichSuMuaHang lichSuMuaHangForm = new LichSuMuaHang(maKH); // Replace 1 with appropriate customer ID
            lichSuMuaHangForm.Show();
        }

        // Event handler for DanhGiaSanPham button click
        private void BtnDanhGiaSanPham_Click(object sender, EventArgs e)
        {
            DanhGiaSanPham danhGiaSanPhamForm = new DanhGiaSanPham(maKH); // Replace 1 with appropriate customer ID
            danhGiaSanPhamForm.Show();
        }


        private void btnXemvaDanhgia_Click(object sender, EventArgs e)
        {
            DanhGiaSanPham danhGiaSanPhamForm = new DanhGiaSanPham(maKH); // Replace 1 with appropriate customer ID
            danhGiaSanPhamForm.Show();
        }

        private void btnXemvaTimkiem_Click(object sender, EventArgs e)
        {
            XemSanPham xenSamphamform = new XemSanPham(maKH);
            xenSamphamform.Show();
        }

        private void btnThongBao_Click(object sender, EventArgs e)
        {
        }
    }
}
