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
    public partial class LoginKey : Form
    {
        public LoginKey()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnInfo.Text = "IP: " + Control.GetIP() + " - User:" + Control.GetUserName();
            Control.CVAPI f = JsonConvert.DeserializeObject<Control.CVAPI>(Control.ConfigAPI.CheckAppV2());
            if (f.Message == "Error")
            {
                Application.Exit();
            }
        }

        #region HttpRequest
        public void TestData(string html)
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

            //http.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/69.0.3497.100 Safari/537.36";
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
                    MessageBox.Show("Vui lòng Nhập đúng Key đưa ra !", "Control");
                }
                else
                {
                    string Search = Control.GetIP() + "~" + Control.GetUserName() + "~" + btnKey.Text;
                    var API = Control.GetAPI(Control.ConfigAPI.Server + Search);
                    Control.CVAPI f = JsonConvert.DeserializeObject<Control.CVAPI>(API);
                    // Nếu đúng Key đưa ra
                    if (f.Message == "Success")
                    {
                        // Check Status của Key xem có bị Block ko
                        if (f.TrangThai == "Active")
                        {
                            // xử lý mở form mới
                            FormControl fm = new FormControl();
                            FormControl.Key = btnKey.Text.ToString();
                            this.Hide();
                            fm.ShowDialog();
                            this.Close();

                        }
                        else
                        {
                            MessageBox.Show("Người dùng đang bị tạm khóa", "Control");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không thể kết nối đến Server, vui lòng kiểm tra và thử lại!", "Control");
                    }




                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            //{
            //    e.Cancel = true;
            //}
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
