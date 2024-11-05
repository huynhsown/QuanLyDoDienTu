using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;
using static Guna.UI2.WinForms.Suite.Descriptions;
using QuanLyDoDienTu.entity;
//using QuanLyDoDienTu.view.ClientForm;

namespace QuanLyDoDienTu.view.ClientForm
{
    public partial class MainForm : Form
    {
        private int maKH;
        private Form form;
        public MainForm(int maKH)
        {
            InitializeComponent();
            this.maKH = maKH;
        }
        void loadForm(object form)
        {
            if (panel.Controls.Count > 0)
            {
                panel.Controls.RemoveAt(0);
            }
            this.form = (Form)form;
            this.form.TopLevel = false;
            this.form.Dock = DockStyle.Fill;
            panel.Controls.Add(this.form);
            panel.Tag = this.form;
            this.form.Show();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (this.form != null && this.form.Visible)
            {
                if (!form.Bounds.Contains(this.PointToScreen(e.Location)))
                {
                    this.form.Close();
                }
            }
        }
        private void userInformation_Click(object sender, EventArgs e)
        {
            loadForm(new ThongTinCaNhan(maKH));
        }

        private List<SanPhamTrongGio> gioHang = new List<SanPhamTrongGio>();
        private void findProduct_Click(object sender, EventArgs e)
        {
            loadForm(new XemSanPham(maKH, gioHang));
        }

        private void cartNPurchase_Click(object sender, EventArgs e)
        {
            loadForm(new GioHangForm(maKH, gioHang));
        }

        private void purchaseHistory_Click(object sender, EventArgs e)
        {
            loadForm(new LichSuMuaHang(maKH));
        }

        private void salesAnnouncement_Click(object sender, EventArgs e)
        {
            loadForm(new ThongBaoKhuyenMaiForm());
        }

        private void payMent_Click(object sender, EventArgs e)
        {
            loadForm(new ThanhToanForm(maKH));
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
