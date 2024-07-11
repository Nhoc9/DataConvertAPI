using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataConvertAPI
{
    public class Control
    {
        public class CVAPI
        {
            public string Message;
            public string TrangThai;
            public string PhanQuyen;
            public string Cookie;
            public string CookieValue;
            public string SOC;
            public int Rows;
        }
        
        public class SetPhanQuyen
        {
            public static string PendingInbound = "Pending Inbound";
        }

        public static string Islogin = "Ошибка на стороне клиента. Код состояния: 401";
        public static class ConfigAPI
        {
            public static string Server = "https://apicenter.click/API/view.php?API=";
            public static string CheckAPP = "https://apicenter.click/API/CheckApp.php?IP=";
            public static string UpdateRow = "https://apicenter.click/API/UpdateRow.php?Rows=";
            public static string Version = "2.11";
            public static string CallAPI()
            {
                string Search = Control.GetIP() + "~" + Control.GetUserName() + "~" + FormControl.Key;
                var API = Control.GetAPI(Control.ConfigAPI.Server + Search);
                return API;
            }
            public static string CheckAppV2()
            {
                var API = Control.GetAPI(Control.ConfigAPI.CheckAPP + Control.GetIP());
                return API;
            }

            public static string UpateRows(int Row)
            {
                var Rows = Control.GetAPI(Control.ConfigAPI.UpdateRow + Row);
                return Rows;
            }

        }
        
        public static string GetIP()
        {
            string hostName = Dns.GetHostName();
            string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();
            return myIP;
        }

        public static string GetUserName()
        {
            return System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        }
        public static string GetAPI(string API)
        {
            LoginKey f = new LoginKey();
            return f.GetData(API, "");
        }

    }
}
