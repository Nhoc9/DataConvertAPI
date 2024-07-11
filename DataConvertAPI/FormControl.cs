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
        public static string Key;

        #region PendingInbound
        private void btn_PendingInbound_Click(object sender, EventArgs e)
        {
            // Neu Key con hoat dong thi moi xu ly tiep
            if (JsonCV.CheckAPI(Key))
            {
                // check phan quyen thong tin xuat xe
                if (JsonCV.PhanQuyen.IndexOf(Control.SetPhanQuyen.PendingInbound) >= 0)
                {
                    // xử lý mở form mới
                    PendingInbound fm = new PendingInbound();
                    this.Hide();
                    fm.ShowDialog();
                    this.Show();
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

        #endregion

        private void FormControl_Load(object sender, EventArgs e)
        {

        }
    }
}
