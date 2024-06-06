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
    public partial class ThongTinXuatXe : Form
    {
        public ThongTinXuatXe()
        {
            InitializeComponent();
        }

        private void ThongTinXuatXe_Load(object sender, EventArgs e)
        {
            JsonCV.CVAPI f = JsonConvert.DeserializeObject<JsonCV.CVAPI>(Control.ConfigAPI.CallAPI());
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
                MessageBox.Show(loi.Message);
            }
           
        }
    }
}
