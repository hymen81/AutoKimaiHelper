using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace autoKimaiHelper
{
    public partial class Form1 : Form
    {

        string kimaiKey = null;
        string kimaiUsr = null;
        protected CookieContainer cookies = new CookieContainer();
        public Form1()
        {
            InitializeComponent();
            postDataButton.Enabled = false;
            manyDays.Enabled = true;

            years.Text = (DateTime.Now.ToString("yyyy"));
            mouth.Text = (DateTime.Now.ToString("MM"));

             //checkBox1.Enabled = false;
        }
        private void RemoveCookies()
        {
            int cookiesmax = Environment.GetFolderPath(Environment.SpecialFolder.Cookies).Length;
            for (int i = 0; i < cookiesmax; i++)
                Environment.GetFolderPath(Environment.SpecialFolder.Cookies).Remove(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
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
            string param = "name=" + name.Text + "&password=" + pass.Text;
            // string param2 = "axAction=bestFittingRate&axValue=0&project_id=548&event_id=451";

            byte[] bs = Encoding.ASCII.GetBytes(param);
            //byte[] bs2 = Encoding.ASCII.GetBytes(param2);

            using (Stream reqStream = request.GetRequestStream())
            {
                reqStream.Write(bs, 0, bs.Length);
            }

            outPutLine.Items.Add("response uri:   " + request.GetResponse().ResponseUri.ToString());

            string Url2 = request.GetResponse().ResponseUri.ToString();
            using (WebResponse response = request.GetResponse())
            {
                StreamReader sr = new StreamReader(response.GetResponseStream());
                result = sr.ReadToEnd();
                outPutLine.Items.Add("");
                foreach (Cookie cook in ((HttpWebResponse)response).Cookies)
                {
                    if (cook.Name == "kimai_key")
                    {
                        kimaiKey = cook.Value;
                        if (kimaiKey == "0")
                        {
                            outPutLine.Items.Add("登入失敗~~~~~~~~~~~~~~");
                            break;
                        }
                        else
                        {
                            outPutLine.Items.Add("kimai_key:   " + cook.Value);
                            loginButton.Enabled = false;
                            postDataButton.Enabled = true;
                            name.Enabled = false;
                            pass.Enabled = false;
                        }
                    }
                    else if (cook.Name == "kimai_usr")
                    {
                        kimaiUsr = cook.Value;
                        outPutLine.Items.Add("kimai_usr:   " + cook.Value);
                    }
                }
                sr.Close();
            }
           

            if (outPutLine.Items.Count > 0)
            {
                outPutLine.SelectedIndex = outPutLine.Items.Count - 1;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
          int days = int.Parse(manyDays.Text);

          while (days-- > 0 && manyDays.Enabled)
          {
              int d = int.Parse(Day.Text) + days;
              int m = int.Parse(this.mouth.Text);
              int y = int.Parse(this.years.Text);

              int w = (d + (int)(2.6 * (float)m - 0.2) + 5 * (y % 4) + 3 * y + 5 * (20 % 4)) % 7;

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

              string param = " pct_ID="+this.pctID.Text+
                  "&filter=gen&evt_ID="+this.evtID.Text+
                  "&filter=&edit_in_day=" + years.Text + 
                  "." + mouth.Text + "." + d.ToString() + 
                  "&edit_out_day=" + years.Text + 
                  "." + mouth.Text + "." + d.ToString() + 
                  "&edit_in_time=00:00:00&edit_out_time=17:24:05&edit_duration=" + hour.Text + 
                  "&rate=&zlocation=&trackingnr=&comment=&comment_type=0&id=0&axAction=add_edit_record";

              outPutLine.Items.Add(param);

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
                  outPutLine.Items.Add(result);
                  if (result == "")
                      outPutLine.Items.Add("成功!!!!!!!!!!");
                  else
                      outPutLine.Items.Add("失敗!!!!!!!!!!");
                  sr.Close();
              }
              if (outPutLine.Items.Count > 0)
              {
                  outPutLine.SelectedIndex = outPutLine.Items.Count - 1;
              }
          }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
                manyDays.Enabled = true;
            else
                manyDays.Enabled = false;
        }

        private void reset_Click(object sender, EventArgs e)
        {
            postDataButton.Enabled = false;
            loginButton.Enabled = true;
            checkBox1.Checked = true;
            manyDays.Enabled = true;

            years.Text = (DateTime.Now.ToString("yyyy"));
            mouth.Text = (DateTime.Now.ToString("MM"));
        }
    }
}
