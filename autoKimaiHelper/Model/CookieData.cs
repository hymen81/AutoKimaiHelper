using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace autoKimaiHelper
{
    public class CookieData
    {
        public static CookieContainer SetReloadEVTCookie(CookieContainer cookies, string kimaiKey, string kimaiUsr) 
        {
            cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/processor.php"), "kimai_key=" + kimaiKey);
            cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/processor.php"), "kimai_usr=" + kimaiUsr);
            cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/processor.php"), "reevoo__utma=1.1014704478.1418713151.1423647278.1424863379.4");
            cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/processor.php"), "reevoo__utmz=1.1424863379.4.4.utmcsr=google.com.tw|utmccn=(referral)|utmcmd=referral|utmcct=/");
            cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/processor.php"), "PHPSESSID=fod8hmar66jng6bhmj5oajvdu4");
            cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/processor.php"), "_ga=GA1.3.1782934344.1418608635");
            return cookies;
        }
        public static CookieContainer SetFillDaysCookie(CookieContainer cookies, string kimaiKey, string kimaiUsr)
        {
            cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/processor.php"), "kimai_key=" + kimaiKey);
            cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/processor.php"), "kimai_usr=" + kimaiUsr);
            cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/processor.php"), "reevoomark_marker=411337895");
            cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/processor.php"), "reevoo__utma=1.1014704478.1418713151.1418713151.1418713151.1");
            cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/processor.php"), "reevoo__utmz=1.1418713151.1.1.utmcsr=google.com.tw|utmccn=(referral)|utmcmd=referral|utmcct=/");
            cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/processor.php"), "_ga=GA1.3.1782934344.1418608635");
            cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/processor.php"), "_dbd_session=BAh7BzoQX2NzcmZfdG9rZW4iMUlka3ptWXYyMm11em1CcytneXYzQVNwdVYxdnlkdXNnYVhFZldSQ08zRGM9Og9zZXNzaW9uX2lkIiU1MzNlOGQzZWIyNTZjZjVhYTg4ZmMzMzkwYzYyMzBjOA%3D%3D--489768cc5eabd75f4c040877712973b0e4a78dd8");
            cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/processor.php"), "PHPSESSID=gbospdlq5j0j43q8ko0b55tim6");
            return cookies;
        }

        public static CookieContainer SetDataListCookie(CookieContainer cookies, string kimaiKey, string kimaiUsr) 
        {
            cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/floaters.php"), "kimai_key=" + kimaiKey);
            cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/floaters.php"), "kimai_usr=" + kimaiUsr);
            cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/floaters.php"), "reevoomark_marker=411337895");
            cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/floaters.php"), "reevoo__utmz=1.1418713151.1.1.utmcsr=google.com.tw|utmccn=(referral)|utmcmd=referral|utmcct=/");
            cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/floaters.php"), "_ga=GA1.3.1782934344.1418608635");
            // cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/core/kimai.php"), "_dbd_session=BAh7BzoQX2NzcmZfdG9rZW4iMUlka3ptWXYyMm11em1CcytneXYzQVNwdVYxdnlkdXNnYVhFZldSQ08zRGM9Og9zZXNzaW9uX2lkIiU1MzNlOGQzZWIyNTZjZjVhYTg4ZmMzMzkwYzYyMzBjOA%3D%3D--489768cc5eabd75f4c040877712973b0e4a78dd8");
            cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/floaters.php"), "PHPSESSID=gbospdlq5j0j43q8ko0b55tim6");
            cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/floaters.php"), " _dbd_session=BAh7CDoQX2NzcmZfdG9rZW4iMXRoaUVacWhyaHd2US9tQ2hIUDhrc0ZqUTVsUmFXWCt1SzI4VnluZitOc3c9Ogl1c2VybzoKQ1VzZXIMOg1AYWNjb3VudCIQQmlsbHkuSHVhbmc6CkBtYWlsIhlCaWxseS5IdWFuZ0BhY2VyLmNvbToOQGRlcHRjb2RlIgtLUjI2MzA6C0Bncm91cFsAOgpAbmFtZSIQQmlsbHkgSHVhbmc6DUBpc2FkbWluRjoIQGlkIgwxNDExMDcwOg9zZXNzaW9uX2lkIiU3NDcwNTIwZDUwMjE2MTI2YTJiOGRiNzJlMTA3M2NhZQ%3D%3D--cbfe07b7d0d0d46f240755aa6bed423f02df0a9d");
            return cookies;
        }

        public static CookieContainer SetTimeSheetList(CookieContainer cookies, string kimaiKey, string kimaiUsr)
        {
            cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/processor.php"), "kimai_key=" + kimaiKey);
            cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/processor.php"), "kimai_usr=" + kimaiUsr);
            cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/processor.php"), "reevoo__utma=1.1014704478.1418713151.1423647278.1424863379.4");
            cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/processor.php"), "reevoo__utmz=1.1424863379.4.4.utmcsr=google.com.tw|utmccn=(referral)|utmcmd=referral|utmcct=/");
            cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/processor.php"), "PHPSESSID=fod8hmar66jng6bhmj5oajvdu4");
            cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/processor.php"), "_ga=GA1.3.1782934344.1418608635");
            return cookies;
        }

        public static CookieContainer SetDeleteDay(CookieContainer cookies, string kimaiKey, string kimaiUsr)
        {
            cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/processor.php"), "kimai_key=" + kimaiKey);
            cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/processor.php"), "kimai_usr=" + kimaiUsr);
            cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/processor.php"), "reevoo__utma=1.1014704478.1418713151.1423647278.1424863379.4");
            cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/processor.php"), "reevoo__utmz=1.1424863379.4.4.utmcsr=google.com.tw|utmccn=(referral)|utmcmd=referral|utmcct=/");
            cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/processor.php"), "PHPSESSID=fod8hmar66jng6bhmj5oajvdu4");
            cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/extensions/ki_timesheets/processor.php"), "_ga=GA1.3.1782934344.1418608635");
            return cookies;
        }
    }
}
