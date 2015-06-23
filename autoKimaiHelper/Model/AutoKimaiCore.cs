using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

using System.Timers;

using MaterialSkin;
using MaterialSkin.Controls;
using System.Diagnostics;


namespace autoKimaiHelper
{
    class AutoKimaiCore
    {
        private static Timer loginTracker;
        string kimaiKey = null;
        string kimaiUsr = null;
        protected CookieContainer cookies = new CookieContainer();
        static private AutoKimaiCore akc;
        static private Form1 ui;

        private delegate void notifyUI();
        notifyUI notify;
       

        AutoKimaiCore()
        {
            loginTracker = new Timer();
            loginTracker.Elapsed += new ElapsedEventHandler(LoginTracker);
            loginTracker.Interval = 5000;
            notify = new notifyUI(ui.LogOutNotify);
        }

        static public AutoKimaiCore getInstance(Form1 f)
        {
            if (ui == null)
                ui = f;
            if (akc == null)
                akc = new AutoKimaiCore();
            return akc;
        }

        void LoginTracker(object source, ElapsedEventArgs e)
        {
            string Url = "http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/processor.php";
            HttpWebRequest request = HttpWebRequest.Create(Url) as HttpWebRequest;
            string result = null;
            request.Method = "POST";

            request.KeepAlive = true;
            request.ContentType = "application/x-www-form-urlencoded";

            cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/processor.php"), "kimai_key=" + kimaiKey);
            cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/processor.php"), "kimai_usr=" + kimaiUsr);
            cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/processor.php"), "reevoo__utma=1.1014704478.1418713151.1423647278.1424863379.4");
            cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/processor.php"), "reevoo__utmz=1.1424863379.4.4.utmcsr=google.com.tw|utmccn=(referral)|utmcmd=referral|utmcct=/");
            cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/processor.php"), "PHPSESSID=fod8hmar66jng6bhmj5oajvdu4");
            cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/processor.php"), "_ga=GA1.3.1782934344.1418608635");

            request.CookieContainer = cookies;


            string param = " axAction=reload_evt_options&axValue=0&id=0&pct=" + "0";

            byte[] bs = Encoding.ASCII.GetBytes(param);
            using (Stream reqStream = request.GetRequestStream())
            {
                reqStream.Write(bs, 0, bs.Length);
            }
            WebResponse myResponse = request.GetResponse();

            StreamReader sr = new StreamReader(myResponse.GetResponseStream());

            result = sr.ReadToEnd();
            //System.Windows.Forms.Clipboard.SetData(System.Windows.Forms.DataFormats.Text, result.ToString());
            sr.Close();
            myResponse.Close();
            //return result;

            

            if (result.IndexOf("logout") != -1)
            {
                Debug.WriteLine(result);

                ui.Invoke(notify);
                //LogOutNotify();
                
            }


        }

      

        private void RemoveCookies()
        {
            int cookiesmax = Environment.GetFolderPath(Environment.SpecialFolder.Cookies).Length;
            for (int i = 0; i < cookiesmax; i++)
                Environment.GetFolderPath(Environment.SpecialFolder.Cookies).Remove(0);
        }

        public void LogIn(string name, string pass, ref List<string> outPut)
        {
            loginTracker.Enabled = true;
            RemoveCookies();
            //   HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create("http://designcenter.acer.com.tw/kimai/index.php?a=logout");
            string Url = "http://designcenter.acer.com.tw/kimai/index.php?a=checklogin";
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(Url);

            string result = null;
            request.Method = "POST";
            request.KeepAlive = true;
            request.ContentType = "application/x-www-form-urlencoded";
            // request.Referer = "http://designcenter.acer.com.tw/kimai/index.php?a=logout";
            // request.CookieContainer = this.cookies;
            // cookies.
            cookies.GetCookieHeader(request.RequestUri);
            request.CookieContainer = cookies;
            request.AllowAutoRedirect = false;
            //request.CookieContainer = new CookieContainer();
            //request.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/39.0.2171.95 Safari/537.36";
            //request.Host = "designcenter.acer.com.tw";
            //request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            //request.ContentLength = 30;
            string param = "name=" + name + "&password=" + pass;
            // string param2 = "axAction=bestFittingRate&axValue=0&project_id=548&event_id=451";

            byte[] bs = Encoding.ASCII.GetBytes(param);
            //byte[] bs2 = Encoding.ASCII.GetBytes(param2);

            using (Stream reqStream = request.GetRequestStream())
            {
                reqStream.Write(bs, 0, bs.Length);
            }

            outPut.Add("response uri:   " + request.GetResponse().ResponseUri.ToString());


            string Url2 = request.GetResponse().ResponseUri.ToString();
            using (WebResponse response = request.GetResponse())
            {
                StreamReader sr = new StreamReader(response.GetResponseStream());
                result = sr.ReadToEnd();
                outPut.Add(((HttpWebResponse)response).ResponseUri.ToString());


                // Clipboard.SetData(System.Windows.Forms.DataFormats.Text, result.ToString());
                foreach (Cookie cook in ((HttpWebResponse)response).Cookies)
                {
                    if (cook.Name == "kimai_key")
                    {
                        kimaiKey = cook.Value;
                        if (kimaiKey == "0")
                        {
                            outPut.Add("登入失敗~~~~~~~~~~~~~~");
                            break;
                        }
                        else
                        {
                            outPut.Add("kimai_key:   " + cook.Value);
                            ui.LoginButton = false;
                            ui.PostDataButton = true;
                            ui.uName = false;
                            ui.Pass = false;
                        }
                    }
                    else if (cook.Name == "kimai_usr")
                    {
                        kimaiUsr = cook.Value;
                        outPut.Add("歡迎:  " + cook.Value);
                    }
                }
                sr.Close();
            }

        }

        private int GetWeekNowDay(int days, string day, string mouth, string years)
        {
           // int days = int.Parse(manyDays);
            int w = -1;
            //if (!manyDays.Enabled)
            // days = 1;
            int d = int.Parse(day) + days;
            int m = int.Parse(mouth);
            int y = int.Parse(years.Substring(2));
            if (m == 1 || m == 2)
            {
                m += 10;
                if (y == 0)
                    y = 99;
                else
                    y -= 1;
            }
            else
            {
                m -= 2;
            }
            w = (d + (int)(2.6 * (float)m - 0.2) + 5 * (y % 4) + 3 * y + 5 * ((21 - 1) % 4)) % 7;
            //if (w == 6 || w == 0)
            // continue;
            return w;
        }

        public void FillDays(string manyDays, string day, string mouth, string years, string hour, string pctID, string evtID, ref List<string> outPut)
        {
            int days = int.Parse(manyDays);
            //if (!manyDays.Enabled)
            // days = 1;
            while (days-- > 0)
            {
                int w = GetWeekNowDay(days, day, mouth, years);
                if (w == 6 || w == 0)
                    continue;

                string Url = "http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/processor.php";
                HttpWebRequest request = HttpWebRequest.Create(Url) as HttpWebRequest;
                string result = null;
                request.Method = "POST";
                request.KeepAlive = true;
                request.ContentType = "application/x-www-form-urlencoded";

                cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/processor.php"), "kimai_key=" + kimaiKey);
                cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/processor.php"), "kimai_usr=" + kimaiUsr);
                cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/processor.php"), "reevoomark_marker=411337895");
                cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/processor.php"), "reevoo__utma=1.1014704478.1418713151.1418713151.1418713151.1");
                cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/processor.php"), "reevoo__utmz=1.1418713151.1.1.utmcsr=google.com.tw|utmccn=(referral)|utmcmd=referral|utmcct=/");
                cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/processor.php"), "_ga=GA1.3.1782934344.1418608635");
                cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/processor.php"), "_dbd_session=BAh7BzoQX2NzcmZfdG9rZW4iMUlka3ptWXYyMm11em1CcytneXYzQVNwdVYxdnlkdXNnYVhFZldSQ08zRGM9Og9zZXNzaW9uX2lkIiU1MzNlOGQzZWIyNTZjZjVhYTg4ZmMzMzkwYzYyMzBjOA%3D%3D--489768cc5eabd75f4c040877712973b0e4a78dd8");
                cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/processor.php"), "PHPSESSID=gbospdlq5j0j43q8ko0b55tim6");

                request.CookieContainer = cookies;

                int d = int.Parse(day) + days;

                string param = " pct_ID=" + pctID +
                    "&filter=gen&evt_ID=" + evtID +
                    "&filter=&edit_in_day=" + years +
                    "." + mouth + "." + d.ToString() +
                    "&edit_out_day=" + years +
                    "." + mouth + "." + d.ToString() +
                    "&edit_in_time=00:00:00&edit_out_time=17:24:05&edit_duration=" + hour +
                    "&rate=&zlocation=&trackingnr=&comment=&comment_type=0&id=0&axAction=add_edit_record";
                outPut.Add(param);

                byte[] bs = Encoding.ASCII.GetBytes(param);
                using (Stream reqStream = request.GetRequestStream())
                {
                    reqStream.Write(bs, 0, bs.Length);
                }

                using (WebResponse response = request.GetResponse())
                {
                    StreamReader sr = new StreamReader(response.GetResponseStream());
                    result = sr.ReadToEnd();
                    //respon
                    outPut.Add(result);

                    if (result == "")
                        outPut.Add("成功!!!!!!!!!!");
                    else
                        outPut.Add("失敗!!!!!!!!!!");
                    sr.Close();
                }

            }

        }

        public void FillWeekDays(string manyDays, string day, string mouth, string years, List<MaterialSingleLineTextField> weekDayTimes,List<MaterialSingleLineTextField> weekDayProjects, ref List<string> outPut)
        {
             int days = int.Parse(manyDays);
            //if (!manyDays.Enabled)
            // days = 1;
             while (days-- > 0)
             {
                 int w = GetWeekNowDay(days, day, mouth, years);
                 if (w == 6 || w == 0)
                     continue;

                 for (int i = 0; i < 4; i++)
                 {
                     if (!weekDayTimes[i * 5 + w - 1].Visible)
                         continue;
                     string hours = weekDayTimes[i * 5 + w - 1].Text;
                     string pctevtString = (string)weekDayProjects[i * 5 + w - 1].Tag;

                     if (pctevtString == "-1")
                         continue;

                     int dot = pctevtString.IndexOf(",");

                     string pctID = pctevtString.Substring(0,dot);
                     string evtID = pctevtString.Substring(dot+1, pctevtString.Length - dot-1);

                     //return;

                     string Url = "http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/processor.php";
                     HttpWebRequest request = HttpWebRequest.Create(Url) as HttpWebRequest;
                     string result = null;
                     request.Method = "POST";
                     request.KeepAlive = true;
                     request.ContentType = "application/x-www-form-urlencoded";

                     cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/processor.php"), "kimai_key=" + kimaiKey);
                     cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/processor.php"), "kimai_usr=" + kimaiUsr);
                     cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/processor.php"), "reevoomark_marker=411337895");
                     cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/processor.php"), "reevoo__utma=1.1014704478.1418713151.1418713151.1418713151.1");
                     cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/processor.php"), "reevoo__utmz=1.1418713151.1.1.utmcsr=google.com.tw|utmccn=(referral)|utmcmd=referral|utmcct=/");
                     cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/processor.php"), "_ga=GA1.3.1782934344.1418608635");
                     cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/processor.php"), "_dbd_session=BAh7BzoQX2NzcmZfdG9rZW4iMUlka3ptWXYyMm11em1CcytneXYzQVNwdVYxdnlkdXNnYVhFZldSQ08zRGM9Og9zZXNzaW9uX2lkIiU1MzNlOGQzZWIyNTZjZjVhYTg4ZmMzMzkwYzYyMzBjOA%3D%3D--489768cc5eabd75f4c040877712973b0e4a78dd8");
                     cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/processor.php"), "PHPSESSID=gbospdlq5j0j43q8ko0b55tim6");

                     request.CookieContainer = cookies;

                     int d = int.Parse(day) + days;

                     string param = " pct_ID=" + pctID +
                         "&filter=gen&evt_ID=" + evtID +
                         "&filter=&edit_in_day=" + years +
                         "." + mouth + "." + d.ToString() +
                         "&edit_out_day=" + years +
                         "." + mouth + "." + d.ToString() +
                         "&edit_in_time=00:00:00&edit_out_time=17:24:05&edit_duration=" + hours +
                         "&rate=&zlocation=&trackingnr=&comment=&comment_type=0&id=0&axAction=add_edit_record";
                     outPut.Add(param);

                     byte[] bs = Encoding.ASCII.GetBytes(param);
                     using (Stream reqStream = request.GetRequestStream())
                     {
                         reqStream.Write(bs, 0, bs.Length);
                     }

                     using (WebResponse response = request.GetResponse())
                     {
                         StreamReader sr = new StreamReader(response.GetResponseStream());
                         result = sr.ReadToEnd();
                         //respon
                         outPut.Add(result);

                         if (result == "")
                             outPut.Add("成功!!!!!!!!!!");
                         else
                             outPut.Add("失敗!!!!!!!!!!");
                         sr.Close();
                     }


                 }
                 
                 

             }
        }

        public string GetReloadEVT(string pctID) 
        {
            string Url = "http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/processor.php";
            HttpWebRequest request = HttpWebRequest.Create(Url) as HttpWebRequest;
            string result = null;
            request.Method = "POST";

            request.KeepAlive = true;
            request.ContentType = "application/x-www-form-urlencoded";

            cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/processor.php"), "kimai_key=" + kimaiKey);
            cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/processor.php"), "kimai_usr=" + kimaiUsr);
            cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/processor.php"), "reevoo__utma=1.1014704478.1418713151.1423647278.1424863379.4");
            cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/processor.php"), "reevoo__utmz=1.1424863379.4.4.utmcsr=google.com.tw|utmccn=(referral)|utmcmd=referral|utmcct=/");
            cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/processor.php"), "PHPSESSID=fod8hmar66jng6bhmj5oajvdu4");
            cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/processor.php"), "_ga=GA1.3.1782934344.1418608635");

            request.CookieContainer = cookies;


            string param = " axAction=reload_evt_options&axValue=0&id=0&pct="+pctID;

            byte[] bs = Encoding.ASCII.GetBytes(param);
            using (Stream reqStream = request.GetRequestStream())
            {
                reqStream.Write(bs, 0, bs.Length);
            }
            WebResponse myResponse = request.GetResponse();

            StreamReader sr = new StreamReader(myResponse.GetResponseStream());

            result = sr.ReadToEnd();
            //System.Windows.Forms.Clipboard.SetData(System.Windows.Forms.DataFormats.Text, result.ToString());
            sr.Close();
            myResponse.Close();
            return result;
        }

        public string GetDataList()
        {
            string Url = "http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/floaters.php";
            HttpWebRequest request = HttpWebRequest.Create(Url) as HttpWebRequest;
            string result = null;
            request.Method = "POST";

            request.KeepAlive = true;
            request.ContentType = "application/x-www-form-urlencoded";

            cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/floaters.php"), "kimai_key=" + kimaiKey);
            cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/floaters.php"), "kimai_usr=" + kimaiUsr);

            cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/floaters.php"), "reevoomark_marker=411337895");
            cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/floaters.php"), "reevoo__utmz=1.1418713151.1.1.utmcsr=google.com.tw|utmccn=(referral)|utmcmd=referral|utmcct=/");

            cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/floaters.php"), "_ga=GA1.3.1782934344.1418608635");
            // cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/core/kimai.php"), "_dbd_session=BAh7BzoQX2NzcmZfdG9rZW4iMUlka3ptWXYyMm11em1CcytneXYzQVNwdVYxdnlkdXNnYVhFZldSQ08zRGM9Og9zZXNzaW9uX2lkIiU1MzNlOGQzZWIyNTZjZjVhYTg4ZmMzMzkwYzYyMzBjOA%3D%3D--489768cc5eabd75f4c040877712973b0e4a78dd8");
            cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/floaters.php"), "PHPSESSID=gbospdlq5j0j43q8ko0b55tim6");

            cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/floaters.php"), " _dbd_session=BAh7CDoQX2NzcmZfdG9rZW4iMXRoaUVacWhyaHd2US9tQ2hIUDhrc0ZqUTVsUmFXWCt1SzI4VnluZitOc3c9Ogl1c2VybzoKQ1VzZXIMOg1AYWNjb3VudCIQQmlsbHkuSHVhbmc6CkBtYWlsIhlCaWxseS5IdWFuZ0BhY2VyLmNvbToOQGRlcHRjb2RlIgtLUjI2MzA6C0Bncm91cFsAOgpAbmFtZSIQQmlsbHkgSHVhbmc6DUBpc2FkbWluRjoIQGlkIgwxNDExMDcwOg9zZXNzaW9uX2lkIiU3NDcwNTIwZDUwMjE2MTI2YTJiOGRiNzJlMTA3M2NhZQ%3D%3D--cbfe07b7d0d0d46f240755aa6bed423f02df0a9d");

            request.CookieContainer = cookies;
            string param = " axAction=add_edit_record&axValue=1435|445&id=0";

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

        public string GetTimeSheetList()
        {
            string Url = "http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/processor.php";
            HttpWebRequest request = HttpWebRequest.Create(Url) as HttpWebRequest;
            string result = null;
            request.Method = "POST";

            request.KeepAlive = true;
            request.ContentType = "application/x-www-form-urlencoded";

            cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/processor.php"), "kimai_key=" + kimaiKey);
            cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/processor.php"), "kimai_usr=" + kimaiUsr);
            cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/processor.php"), "reevoo__utma=1.1014704478.1418713151.1423647278.1424863379.4");
            cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/processor.php"), "reevoo__utmz=1.1424863379.4.4.utmcsr=google.com.tw|utmccn=(referral)|utmcmd=referral|utmcct=/");
            cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/processor.php"), "PHPSESSID=fod8hmar66jng6bhmj5oajvdu4");
            cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/processor.php"), "_ga=GA1.3.1782934344.1418608635");

            request.CookieContainer = cookies;

            DateTime fd = new DateTime(2015, 1, 1);
            DateTime ld = new DateTime(2015, 8, 1);


           // Int32 firstDayInt = (Int32)(fd.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            Int32 lastDayInt = (Int32)(ld.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

            Int32 firstDayInt = 1420041600;

            string param = " axAction=reload_zef&axValue=|||&id=0&first_day=" + firstDayInt.ToString() + "&last_day=" + lastDayInt.ToString();

            byte[] bs = Encoding.ASCII.GetBytes(param);
           using (Stream reqStream = request.GetRequestStream())
            {
                reqStream.Write(bs, 0, bs.Length);
            }
            WebResponse myResponse = request.GetResponse();

            StreamReader sr = new StreamReader(myResponse.GetResponseStream());

            result = sr.ReadToEnd();
            System.Windows.Forms.Clipboard.SetData(System.Windows.Forms.DataFormats.Text, result.ToString());
            sr.Close();
            myResponse.Close();
            return result;
        }
        public string deleteDay(int id) 
        {
            string Url = "http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/processor.php";
            HttpWebRequest request = HttpWebRequest.Create(Url) as HttpWebRequest;
            string result = null;
            request.Method = "POST";

            request.KeepAlive = true;
            request.ContentType = "application/x-www-form-urlencoded";

            cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/processor.php"), "kimai_key=" + kimaiKey);
            cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/processor.php"), "kimai_usr=" + kimaiUsr);
            cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/processor.php"), "reevoo__utma=1.1014704478.1418713151.1423647278.1424863379.4");
            cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/processor.php"), "reevoo__utmz=1.1424863379.4.4.utmcsr=google.com.tw|utmccn=(referral)|utmcmd=referral|utmcct=/");
            cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/processor.php"), "PHPSESSID=fod8hmar66jng6bhmj5oajvdu4");
            cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/processor.php"), "_ga=GA1.3.1782934344.1418608635");

            request.CookieContainer = cookies;
            string param = " axAction=quickdelete&axValue=&id=" + id;

            byte[] bs = Encoding.ASCII.GetBytes(param);
            using (Stream reqStream = request.GetRequestStream())
            {
                reqStream.Write(bs, 0, bs.Length);
            }
            WebResponse myResponse = request.GetResponse();

            StreamReader sr = new StreamReader(myResponse.GetResponseStream());

            result = sr.ReadToEnd();
            //System.Windows.Forms.Clipboard.SetData(System.Windows.Forms.DataFormats.Text, result.ToString());
            sr.Close();
            myResponse.Close();
            return result;
        } 



    }
}
