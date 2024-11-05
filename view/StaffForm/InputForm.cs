using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDoDienTu.view.StaffForm
{
    public partial class InputForm : Form
    {
        public string MaNSX { get; private set; }
        public string InputValue { get; set; }

        public InputForm()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            MaNSX = txtInput.Text;

            // Đóng form
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void InputForm_Load(object sender, EventArgs e)
        {

        }
    }
}
