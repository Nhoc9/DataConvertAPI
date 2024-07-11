using Newtonsoft.Json;
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
    public partial class PendingInbound : Form
    {
        public PendingInbound()
        {
            InitializeComponent();
        }

        private void PendingInbound_Load(object sender, EventArgs e)
        {
            if (JsonCV.CheckAPI(FormControl.Key))
            {
                Application.Exit();
            }
                Control.CVAPI f = JsonConvert.DeserializeObject<Control.CVAPI>(Control.ConfigAPI.CallAPI());
            if (f.Cookie != "Yes")
            {
                MessageBox.Show("Không thể kết nối đến Server. Vui lòng thử lại sau (Mã lỗi: 900)", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btn_Load_Click(object sender, EventArgs e)
        {
            Control.CVAPI f = JsonConvert.DeserializeObject<Control.CVAPI>(Control.ConfigAPI.CallAPI());
            string cookie = f.CookieValue;
            LoginKey fm = new LoginKey();
            var url = "https://spx.shopee.vn/api/in-station/general_to/outbound/search?pageno=1&count=24&ctime=1717088400,1717693199";
            try
            {
                var html = fm.GetData(url, cookie);
                fm.TestData(html);
            }
            catch (Exception loi)
            {
                if (loi.Message == Control.Islogin)
                {
                    Control.ConfigAPI.UpateRows(f.Rows);
                    MessageBox.Show("Không thể kết nối đến Server. Vui lòng thử lại sau (Mã lỗi: 999)", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
        }
    }
}
