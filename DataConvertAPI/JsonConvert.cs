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
        public class CVAPI
        {
            public string Message;
            public string Status;
            public string PhanQuyen;
        }

        public static string PhanQuyen;
        // Check API mỗi khi vào các phân vùng
        public static bool CheckAPI(string KeyIP)
        {
            string Search = Control.GetIP() + "~" + Control.GetUserName() + "~" + KeyIP;
            var API = Control.CheckAPI(Control.ConfigAPI.Server + Search);
            JsonCV.CVAPI f = JsonConvert.DeserializeObject<JsonCV.CVAPI>(API);
            if (f.Message == "Success" && f.Status == "Active"){
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
