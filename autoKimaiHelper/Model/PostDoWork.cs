using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace autoKimaiHelper
{
    public class PostDoWork
    {
        public static string PostDataToKimai(string url, string param, CookieContainer cookie) 
        {
            HttpWebRequest request = HttpWebRequest.Create(url) as HttpWebRequest;
            string result = null;
            request.Method = "POST";
            request.KeepAlive = true;
            request.ContentType = "application/x-www-form-urlencoded";
            request.CookieContainer = cookie;
            byte[] bs = Encoding.ASCII.GetBytes(param);
            using (Stream reqStream = request.GetRequestStream())
            {
                reqStream.Write(bs, 0, bs.Length);
            }
            WebResponse myResponse = request.GetResponse();
            StreamReader sr = new StreamReader(myResponse.GetResponseStream());
            result = sr.ReadToEnd();
            sr.Close();
            myResponse.Close();
            return result;
        }
    }
}
