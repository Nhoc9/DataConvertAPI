using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataConvertAPI
{
    public partial class FormControl : Form
    {
        public FormControl()
        {
            InitializeComponent();
        }
        public string Key;
        private void btnTTXX_Click(object sender, EventArgs e)
        {
            string PQ = "TTXX";
            // Neu Key con hoat dong thi moi xu ly tiep
            if (JsonCV.CheckAPI(Key))
            {
                // check phan quyen thong tin xuat xe
                if (JsonCV.PhanQuyen.IndexOf(PQ) >= 0)
                {
                    MessageBox.Show("ok cho ti");
                }
                else
                {
                    MessageBox.Show("Bạn không có quyền truy cập vào phân vùng này!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                this.Close();
            }
        }

        private void FormControl_Load(object sender, EventArgs e)
        {

        }
    }
}
