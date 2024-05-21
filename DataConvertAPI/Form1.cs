using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using xNet;
using Newtonsoft.Json;

namespace DataConvertAPI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnInfo.Text = "IP: " + Control.GetIP() + " - User:" + Control.GetUserName();
        }

        #region HttpRequest
        void TestData(string html)
        {
            File.WriteAllText("res.html", html);
            Process.Start("res.html");
        }
        void AddCookie(HttpRequest http, string cookie)
        {
            var temp = cookie.Split(';');
            foreach (var item in temp)
            {
                var temp2 = item.Split('=');
                if (temp2.Count() > 1)
                {
                    http.Cookies.Add(temp2[0], temp2[1]);
                }
            }
        }
        public string GetData(string url, string cookie = null)
        {
            HttpRequest http = new HttpRequest();
            http.Cookies = new CookieDictionary();


            if (!string.IsNullOrEmpty(cookie))
            {
                AddCookie(http, cookie);
            }

            http.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/69.0.3497.100 Safari/537.36";
            string html = http.Get(url).ToString();
            return html;
        }
        #endregion
        private void bntKey_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (btnKey.Text.Length < 10)
                {
                    MessageBox.Show("Vui lòng Nhập đúng Key đưa ra !", "Data");
                }
                else
                {

                    var API = Control.CheckAPI(Control.Server + "192.168.0.108HAI\admin");
                    JsonCV.CVAPI f = JsonConvert.DeserializeObject<JsonCV.CVAPI>(API);

                    MessageBox.Show(f.Message);



                }
            }
        }
    }
}
