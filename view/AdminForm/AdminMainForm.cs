using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDoDienTu.view.AdminForm
{
    public partial class AdminMainForm : Form
    {

        private Form form;

        public AdminMainForm()
        {
            InitializeComponent();
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

        private void AdminMainForm_Load(object sender, EventArgs e)
        {

        }

        private void staffManage_Click(object sender, EventArgs e)
        {
            loadForm(new StaffManageForm());
        }

        private void kHÁCHHÀNGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadForm(new CustomerManageForm());
        }

        private void cÔNGVIỆCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadForm(new JobManageForm());
        }

        private void nHÀSẢNXUẤTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadForm(new ManufacturerManagerForm());
        }

        private void ứNGDỤNGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadForm(new ApplicationManageForm());
        }

        private void sẢNPHẨMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadForm(new ProductManageForm());
        }

        private void dOANHTHUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadForm(new StatisticManageForm());
        }

        private void đƠNNHẬPHÀNGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadForm(new PurchaseOrderManageForm());
        }
    }
}
