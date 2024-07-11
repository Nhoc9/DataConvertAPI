using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConvertAPI
{
    public class JsonCV
    {
        
        public static string PhanQuyen;
        // Check API mỗi khi vào các phân vùng
        public static bool CheckAPI(string KeyIP)
        {
            string Search = Control.GetIP() + "~" + Control.GetUserName() + "~" + KeyIP;
            var API = Control.GetAPI(Control.ConfigAPI.Server + Search);
            Control.CVAPI f = JsonConvert.DeserializeObject<Control.CVAPI>(API);
            if (f.Message == "Success" && f.TrangThai == "Active"){
                PhanQuyen = f.PhanQuyen;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
