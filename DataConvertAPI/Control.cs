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
        public static class ConfigAPI
        {
            public static string Server = "https://apicenter.click/API/view.php?API=";
            public static string Version = "2.11";
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
        public static string CheckAPI(string API)
        {
            LoginKey f = new LoginKey();
            return f.GetData(API, "");
        }
    }
}
