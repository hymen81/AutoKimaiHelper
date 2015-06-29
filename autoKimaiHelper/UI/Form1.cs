using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Linq;

using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.IO;

using MaterialSkin;
using MaterialSkin.Controls;
using System.Threading;
using System.Diagnostics;


namespace autoKimaiHelper
{
    public partial class Form1 : MaterialForm
    {
        static bool firstUse = true;

        private readonly MaterialSkinManager materialSkinManager;
        AutoKimaiCore akc;
        int zefId = 0;
        const int NOTFOUND = -1;
        //public string GOBELTIME = "";
        private TimeSelecter timeSelectStack = null;
        private YearSelecter yearSelect = null;
        private MouthSelecter mouthSelect = null;
        private DaySelecter daySelect = null;
        

        List<ProjectData> projectData = new List<ProjectData>();
        List<ProjectData> pctSearchedList = new List<ProjectData>();
        List<string> evtSearchedList = new List<string>();
        WeekDataList wdList = new WeekDataList();   
        private List<MaterialSingleLineTextField> weekDayTimes = new List<MaterialSingleLineTextField>();
        private List<MaterialSingleLineTextField> weekDayProjects = new List<MaterialSingleLineTextField>();
        static private LogOut lo = null;

        public Form1()
        {
            InitializeComponent();
            postDataButton.Enabled = false;
            manyDays.Enabled = true;
            years.Text = (DateTime.Now.ToString("yyyy"));
            mouth.Text = (DateTime.Now.ToString("MM"));
            yearsWeek.Text = (DateTime.Now.ToString("yyyy"));
            mouthWeek.Text = (DateTime.Now.ToString("MM"));
            akc = AutoKimaiCore.getInstance(this);
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            weekDayTimes.Add(w1t1);
            weekDayTimes.Add(w2t1);
            weekDayTimes.Add(w3t1);
            weekDayTimes.Add(w4t1);
            weekDayTimes.Add(w5t1);

            weekDayTimes.Add(w1t2);
            weekDayTimes.Add(w2t2);
            weekDayTimes.Add(w3t2);
            weekDayTimes.Add(w4t2);
            weekDayTimes.Add(w5t2);

            weekDayTimes.Add(w1t3);
            weekDayTimes.Add(w2t3);
            weekDayTimes.Add(w3t3);
            weekDayTimes.Add(w4t3);
            weekDayTimes.Add(w5t3);

            weekDayTimes.Add(w1t4);
            weekDayTimes.Add(w2t4);
            weekDayTimes.Add(w3t4);
            weekDayTimes.Add(w4t4);
            weekDayTimes.Add(w5t4);

            weekDayProjects.Add(w1t1project);
            weekDayProjects.Add(w2t1project);
            weekDayProjects.Add(w3t1project);
            weekDayProjects.Add(w4t1project);
            weekDayProjects.Add(w5t1project);

            weekDayProjects.Add(w1t2project);
            weekDayProjects.Add(w2t2project);
            weekDayProjects.Add(w3t2project);
            weekDayProjects.Add(w4t2project);
            weekDayProjects.Add(w5t2project);

            weekDayProjects.Add(w1t3project);
            weekDayProjects.Add(w2t3project);
            weekDayProjects.Add(w3t3project);
            weekDayProjects.Add(w4t3project);
            weekDayProjects.Add(w5t3project);

            weekDayProjects.Add(w1t4project);
            weekDayProjects.Add(w2t4project);
            weekDayProjects.Add(w3t4project);
            weekDayProjects.Add(w4t4project);
            weekDayProjects.Add(w5t4project);

            foreach (MaterialSingleLineTextField wt in weekDayTimes) 
            {
                wt.Tag = wt.Name;
                wt.Click += new System.EventHandler(this.weekTme_Click);
                wt.KeyPress += new KeyPressEventHandler(this.keyPress);
            }

            foreach (MaterialSingleLineTextField wp in weekDayProjects)
            {
                wp.Tag = "-1";
                wp.Click += new System.EventHandler(this.weekProject_Click);
                wp.KeyPress += new KeyPressEventHandler(this.keyPress);
            }

            NetWorkCheck nwc = new NetWorkCheck();
            materialLabel2.Text = nwc.dnsName;

            if (materialLabel2.Text.IndexOf("acer") == NOTFOUND)
            {
                NetWorkError nwe = new NetWorkError();
                nwe.Show();
            }

            lo = new LogOut(this);

           

            //checkBox1.Enabled = false;
                      
        }

        private void keyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            

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
            //login.Enabled = true;
            checkBox1.Checked = true;
            manyDays.Enabled = true;

            years.Text = (DateTime.Now.ToString("yyyy"));
            mouth.Text = (DateTime.Now.ToString("MM"));

            pctList.Items.Clear();
            evtList.Items.Clear();
            outPutLine.Items.Clear();
        }

        private void displayDate_Click(object sender, EventArgs e)
        {
            /*string Url = "http://designcenter.acer.com.tw/kimai/core/kimai.php";
            HttpWebRequest request = HttpWebRequest.Create(Url) as HttpWebRequest;
            string result = null;
            request.Method = "GET";
            // request.KeepAlive = true;
            // request.ContentType = "application/x-www-form-urlencoded";

            request.KeepAlive = true;
            request.ContentType = "application/x-www-form-urlencoded";

            cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/core/kimai.php"), "kimai_key=" + kimaiKey);
            cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/core/kimai.php"), "kimai_usr=" + kimaiUsr);

            cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/core/kimai.php"), "_dc_gtm_UA-18261064-1=1");
            cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/core/kimai.php"), "_gat_UA-18261064-1=1");

            cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/core/kimai.php"), "_ga=GA1.3.1337881219.1421046788");
            // cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/core/kimai.php"), "_dbd_session=BAh7BzoQX2NzcmZfdG9rZW4iMUlka3ptWXYyMm11em1CcytneXYzQVNwdVYxdnlkdXNnYVhFZldSQ08zRGM9Og9zZXNzaW9uX2lkIiU1MzNlOGQzZWIyNTZjZjVhYTg4ZmMzMzkwYzYyMzBjOA%3D%3D--489768cc5eabd75f4c040877712973b0e4a78dd8");
            cookies.SetCookies(new Uri("http://designcenter.acer.com.tw/kimai/core/kimai.php"), "PHPSESSID=gbospdlq5j0j43q8ko0b55tim6");

            request.CookieContainer = cookies;
            */
            /* string param = " axAction=reload_zef&axValue=|||&id=0&first_day=14120604q0&last_day=1425110400";
               

             outPutLine.Items.Add(param);

             byte[] bs = Encoding.ASCII.GetBytes(param);
             using (Stream reqStream = request.GetRequestStream())
             {
                 reqStream.Write(bs, 0, bs.Length);
             }*/

            /*
            //取得WebRequest的回覆
            WebResponse myResponse = request.GetResponse();

            //Streamreader讀取回覆
            StreamReader sr = new StreamReader(myResponse.GetResponseStream());

            //將全文轉成string
            result = sr.ReadToEnd();
            Clipboard.SetData(System.Windows.Forms.DataFormats.Text, result.ToString());

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(result);
            string p = "option";
            HtmlAgilityPack.HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("/html/body/div[@class='lists']/div[@id='pct']/table/tbody/tr /td[@class='projects']");

            foreach (HtmlAgilityPack.HtmlNode node in nodes)
            {
                pctList
               .Items.Add(node.InnerText.Replace(" ", "") + ":" + node.OuterHtml.ToString().Substring(node.OuterHtml.ToString().IndexOf("pct") + 5, 4).Replace(",", ""));

            }

            nodes = doc.DocumentNode.SelectNodes("/html/body/div[@class='lists']/div[@id='evt']/table/tbody//td[@class='events']");
            foreach (HtmlAgilityPack.HtmlNode node in nodes)
            {
                evtList
               .Items.Add(node.InnerText.ToString().Replace(" ", "") + ":" + node.OuterHtml.ToString().Substring(node.OuterHtml.ToString().IndexOf("evt") + 5, 4).Replace(",", ""));

            }
            //關掉StreamReader
            sr.Close();

            //關掉WebResponse
            myResponse.Close();


            outPutLine.Items.Add(result);
            if (outPutLine.Items.Count > 0)
            {
                outPutLine.SelectedIndex = outPutLine.Items.Count - 1;
            }*/
        }


        public  bool uName
        {
            set{name.Enabled=value;}
        }

        public bool Pass
        {
            set{pass.Enabled=value;}
        }

        public bool LoginButton
        {
            set
            {
                logInMButton.Enabled = value;
            }
        }

        public bool PostDataButton
        {
        set{postDataButton.Enabled=value;}
        }

        public int TabIndex 
        {
            set 
            {
                materialTabControl1.SelectedIndex = value;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            

        }
    
        private void evtList_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        public void LogOutNotify()
        {
            this.Enabled = false;
            lo.Show();
         
        }

        private void outPutLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string sheetData = outPutLine.Items[outPutLine.SelectedIndex].ToString();
                sheetData = sheetData.Substring(0, sheetData.IndexOf(" "));
                outPutLine.Items.Add(sheetData);
                this.zefId = int.Parse(sheetData);
            }
            catch
            {
            }
            // pctID.Text = pctListString.Substring(pctListString.IndexOf('=') + 1, pctListString.Length - pctListString.IndexOf('=') - 1);
        }

        private void logInMButton_Click(object sender, EventArgs e)
        {
            List<string> outPut = new List<string>();
          //Thread workerThread = new Thread(akc.LogIn);
            akc.LogIn(name.Text, pass.Text, ref outPut);        
            foreach (string s in outPut)
            {
                outPutLine.Items.Add(s);
            }
            if (outPutLine.Items.Count > 0)
            {
                outPutLine.SelectedIndex = outPutLine.Items.Count - 1;
            }
          //  ListViewItem a = new ListViewItem();
          //  a.SubItems.Add("GG");
           // a.Text = "dasd";
            //this.materialListView1.Items.Add(a);
            this.materialTabControl1.SelectedIndex = 1;
            getProjectListString();
        }

        private void getProjectList_Click(object sender, EventArgs e)
        {
            string result = akc.GetDataList();
            outPutLine.Items.Add(result);
            Clipboard.SetData(System.Windows.Forms.DataFormats.Text, result.ToString());
            // HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            // doc.LoadHtml(result);
          //  string p = "option";
            // HtmlAgilityPack.HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("/html/body/div[@id='floater_innerwrap']/div[@id='floater_content']/div[@id='floater_dimensions']");
            bool changeFlag = false;

            int index = 0;
            int indexEnd = 0;
            do
            {
                index = result.IndexOf("<option label=", index);
                indexEnd = result.IndexOf("</option>", indexEnd);
                if (index != NOTFOUND)
                {
                    string noOp = result.Substring(index + 15, indexEnd - index - 15);

                    string name = noOp.Substring(0, noOp.IndexOf('"'));

                    int startValue = noOp.IndexOf("value=");
                    int endValue = noOp.LastIndexOf('"');
                    string value = noOp.Substring(startValue + 7, endValue - startValue - 7);

                    if (name.Equals("3G, LTE"))
                        changeFlag = true;
                    if (!changeFlag)
                        pctList.Items.Add(name + "=" + value);
                    else
                        break;
                    //evtList.Items.Add(name + "=" + value);

                    //  outPutLine.Items.Add(name+value);
                    index++;
                    indexEnd++;
                }
            } while (index != NOTFOUND);

            outPutLine.Items.Add(result);
            if (outPutLine.Items.Count > 0)
            {
                outPutLine.SelectedIndex = outPutLine.Items.Count - 1;
            }
        }

        private void analyticsPage() 
        {
            //Thread.Sleep(5000);
            //materialTabControl1.SelectedIndex = 2;            
        }

        private void materialTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (materialTabControl1.SelectedIndex) 
            {
                case 0:
                    
                    //t1Pic.Location = new Point(0, 0);
                   // t1Pic.SizeMode = PictureBoxSizeMode.AutoSize;
                    
                    break;
                  //  PictureBox p = new PictureBox();
                   
                        /*  this.pictureBox1.Image = global::autoKimaiHelper.Properties.Resources.loading_gallery;
            this.pictureBox1.Location = new System.Drawing.Point(110, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(315, 289);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;*/
            }
            if (materialTabControl1.SelectedIndex == 1)
            {
                pictureBox1.Visible = true;
                analyticsPage();
            }
            else
                pictureBox1.Visible = false;
        }

        private void getProjectListString() 
        {
            projectData.Clear();
            string result = akc.GetDataList();
            outPutLine.Items.Add(result);
            Clipboard.SetData(System.Windows.Forms.DataFormats.Text, result.ToString());

            // HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            // doc.LoadHtml(result);
            string p = "option";
            // HtmlAgilityPack.HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("/html/body/div[@id='floater_innerwrap']/div[@id='floater_content']/div[@id='floater_dimensions']");

            bool changeFlag = false;

            int index = 0;
            int indexEnd = 0;
            do
            {
                index = result.IndexOf("<option label=", index);
                indexEnd = result.IndexOf("</option>", indexEnd);
                if (index != NOTFOUND)
                {
                    string noOp = result.Substring(index + 15, indexEnd - index - 15);

                    string name = noOp.Substring(0, noOp.IndexOf('"'));

                    int startValue = noOp.IndexOf("value=");
                    int endValue = noOp.LastIndexOf('"');
                    string value = noOp.Substring(startValue + 7, endValue - startValue - 7);

                    if (name.Equals("3G, LTE"))
                        changeFlag = true;
                    if (!changeFlag)
                    {
                        //pctList.Items.Add(name + "=" + value);
                        ProjectData pd = new ProjectData(value, name);
                        projectData.Add(pd);
                        pctSearchedList.Add(pd);
                        pctList.Items.Add(pd.VALUE);
                    }
                    else
                        break;
                    //evtList.Items.Add(name + "=" + value);

                    //  outPutLine.Items.Add(name+value);
                    index++;
                    indexEnd++;
                }
            } while (index != NOTFOUND);

            outPutLine.Items.Add(result);
            if (outPutLine.Items.Count > 0)
            {
                outPutLine.SelectedIndex = outPutLine.Items.Count - 1;
            }
        }

        private void getProjectList_Click_1(object sender, EventArgs e)
        {
            getProjectListString();
        }

        private void pctList_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (pctList.SelectedIndex == NOTFOUND)
                return;
            //string pctListString = pctList.Items[pctList.SelectedIndex].ToString();
            //pctID.Text = pctListString.Substring(pctListString.IndexOf('=') + 1, pctListString.Length - pctListString.IndexOf('=') - 1);
            pctID.Text = pctSearchedList[pctList.SelectedIndex].PCTID;
            taskLabel.Text = "";
            projectLabel.Text = pctSearchedList[pctList.SelectedIndex].VALUE;
            evtList.Items.Clear();
            evtSearchedList.Clear();
            string evtData = akc.GetReloadEVT(pctID.Text);
            int index = 0;
            int indexEnd = 0;
            do
            {
                if (indexEnd == NOTFOUND)
                    break;
                try
                {
                    index = evtData.IndexOf("<option value=\"", index) + 15;
                    indexEnd = evtData.IndexOf("</option>", indexEnd);
                }
                catch { break; }
                //if (index == -1 || indexEnd == -1)
                //  break;
                if (index != NOTFOUND && indexEnd != NOTFOUND)
                {
                    string evtId = evtData.Substring(index, indexEnd - index);
                    evtId = evtId.Replace("\">", "=");
                    evtList.Items.Add(evtId);
                    evtSearchedList.Add(evtId);
                    indexEnd++;
                    index++;
                }
            } while (index != NOTFOUND);
        }

        private void postDataButton_Click_1(object sender, EventArgs e)
        {
            List<string> outPut = new List<string>();
            if (materialTabControl2.SelectedIndex == 0)
            {
                akc.FillDays(manyDays.Text, Day.Text, mouth.Text, years.Text, hour.Text, pctID.Text, evtID.Text, ref outPut);
        
            }
            else if (materialTabControl2.SelectedIndex == 1) 
            {
                akc.FillWeekDays(manyDaysWeek.Text, DayWeek.Text, mouthWeek.Text, yearsWeek.Text, weekDayTimes, weekDayProjects, ref outPut);
            }
            foreach (string s in outPut)
            {
                outPutLine.Items.Add(s);
            }
            if (outPutLine.Items.Count > 0)
            {
                outPutLine.SelectedIndex = outPutLine.Items.Count - 1;
            }
        }

        void updateTimeSheet() 
        {
        
        }

        private void pctSearchText_TextChanged(object sender, EventArgs e)
        {
            pctList.Items.Clear();
            pctSearchedList.Clear();
            foreach (ProjectData pd in projectData)
            {
                if (pd.VALUE.ToUpper().IndexOf(pctSearchText.Text.ToUpper()) != NOTFOUND)
                {
                    pctSearchedList.Add(pd);
                    pctList.Items.Add(pd.VALUE);
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           // zefId = int.Parse();
            Debug.WriteLine(listView1.SelectedItems[0].Text);
        }

        private void deleteMaterialRaisedButton_Click(object sender, EventArgs e)
        {
            outPutLine.Items.Clear();
            //this.Text = listView1.SelectedItems[0].Text;
            Debug.WriteLine(zefId);
            int selectItemsCount = listView1.SelectedItems.Count;
            //int firstIndex = listView1.SelectedItems[0].Index;
            for (int i = 0; i < selectItemsCount; i++)
            {
                string result = akc.deleteDay(int.Parse(listView1.SelectedItems[0].Text));
                listView1.Items.Remove(listView1.SelectedItems[0]);
                outPutLine.Items.Add(result);
            }
        }

        private void timeSheetMaterialRaisedButton_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            outPutLine.Items.Clear();
            string result = akc.GetTimeSheetList();
            outPutLine.Items.Add(result);
            int index = 0;
            int indexEnd = 0;
            do
            {
                index = result.IndexOf("<tr id=", index); // <tr id="zefEntry
                indexEnd = result.IndexOf("</tr>", indexEnd);
                if (index != NOTFOUND)
                {
                    string zef = result.Substring(index, indexEnd - index);
                    index++;
                    indexEnd++;
                    if (zef.IndexOf("zef", 0) == NOTFOUND)
                        continue;
                    // int dateIndex =  zef.IndexOf("<td class=\"date",0);

                    zef = zef.Replace(" ", "");

                    int zefIdIndex = zef.IndexOf("zefEntry");
                    int zefIdEndIndex = zef.IndexOf("\"class=\"", zefIdIndex);
                    string zefId = zef.Substring(zefIdIndex, zefIdEndIndex - zefIdIndex);
                    zefId = zefId.Replace("zefEntry", "");

                    int zefDateIndex = zef.IndexOf("<tdclass=\"date");
                    int zefDateEndIndex = zef.IndexOf("</td>", zefDateIndex);
                    string zefDate = zef.Substring(zefDateIndex, zefDateEndIndex - zefDateIndex);
                    zefDate = zefDate.Replace("<tdclass=\"date\nbreak_day\">\n", "");
                    zefDate = zefDate.Replace("<tdclass=\"date\n\">", "");


                    int zefTimeIndex = zef.IndexOf("<tdclass=\"time");
                    int zefTimeEndIndex = zef.IndexOf("</td>", zefTimeIndex);
                    string zefTime = zef.Substring(zefTimeIndex, zefTimeEndIndex - zefTimeIndex);
                    //zefTime	"<tdclass=\"time\nbreak_day\">\n\n\n<atitle='10:00:00'>\n10:00\n</a>\n\n"	string

                    zefTime = zefTime.Replace("<tdclass=\"time\nbreak_day\">\n\n\n<atitle=", "");
                    zefTime = zefTime.Replace("<tdclass=\"time\n\">\n\n\n<atitle=", "");
                    zefTimeEndIndex = zefTime.IndexOf("'>");
                    zefTime = zefTime.Substring(1, zefTimeEndIndex - 1);

                    int zefPctIndex = zef.IndexOf("buzzer_preselect(") + 17;
                    int zefPctEndIndex = zef.IndexOf(");", zefPctIndex);
                    string zefPct = zef.Substring(zefPctIndex, zefPctEndIndex - zefPctIndex);
                    //zefPct=zefPct.Replace(" ", "");

                    System.Windows.Forms.Clipboard.SetData(System.Windows.Forms.DataFormats.Text, zef.ToString());
                    outPutLine.Items.Add(zefId + " " + zefDate + " " + zefTime + " " + zefPct);
                    ListViewItem item = new ListViewItem();
                    item.Text = zefId;
                    item.SubItems.Add(zefDate);
                    item.SubItems.Add(zefTime);
                    item.SubItems.Add(zefPct);
                    item.SubItems.Add("sdasd");
                    listView1.Items.Add(item);

                    //index = indexEnd;

                }
            } while (index != NOTFOUND);
        }

        private void weekTme_Click(object sender, EventArgs e)
        {
            TextBox wt = (TextBox)sender;
            pctID.Text = wt.Tag.ToString();
            if (timeSelectStack == null)
                timeSelectStack = new TimeSelecter(wt);
            else 
            {
                timeSelectStack.Dispose();
                timeSelectStack = new TimeSelecter(wt);
            }
            timeSelectStack.Location = new Point(wt.Location.X, wt.Location.Y);
            timeSelectStack.Show();           
        }

        private void evtList_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (evtList.SelectedIndex == NOTFOUND)
                return;
            string evtListString = evtList.Items[evtList.SelectedIndex].ToString();
            // evtID.Text = evtListString.Substring(evtListString.IndexOf('=') + 1, evtListString.Length - evtListString.IndexOf('=') - 1);
            int equPos = evtListString.IndexOf('=');
            evtID.Text = evtListString.Substring(0, equPos);
            taskLabel.Text = evtListString.Substring(equPos+1,evtListString.Length-equPos-1);
        }

        private void evtSearchText_TextChanged(object sender, EventArgs e)
        {
            evtList.Items.Clear();
            //evtSearchedList.Clear();
            foreach (string evt in evtSearchedList)
            {
                if (evt.ToUpper().IndexOf(evtSearchText.Text.ToUpper()) != NOTFOUND)
                {
                    //pctSearchedList.Add(pd);
                    evtList.Items.Add(evt);
                    //evtSearchedList.Add(evt);
                }
            }
        }

        private void weekProject_Click(object sender, EventArgs e)
        {
            //ProjectTaskSelect.getInstance().setData(projectData, this);
            TextBox tb = (TextBox)sender;         
            ProjectTaskSelect pts = new ProjectTaskSelect(projectData, this, tb);
            pts.Show();
        }

        static int startPos = 0;
        static int endPos = 5;
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Point now = pictureBox2.Location;
            if (now.Y < 350)
            {
                pictureBox2.Location = new Point(now.X, now.Y + 80);
                pictureBox3.Location = new Point(now.X - 40, now.Y + 80);
                startPos += 5;
                endPos += 5;
                for (int i = startPos; i < endPos; i++)
                {
                    weekDayTimes[i].Visible = true;
                    weekDayProjects[i].Visible = true;
                }
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Point now = pictureBox3.Location;
            if (now.Y > 110)
            {
                pictureBox3.Location = new Point(now.X, now.Y - 80);
                pictureBox2.Location = new Point(now.X + 40, now.Y - 80);
                for (int i = startPos; i < endPos; i++)
                {
                    weekDayTimes[i].Visible = false;
                    weekDayProjects[i].Visible = false;
                }
                startPos -= 5;
                endPos -= 5;
            }
        }

        private void pctList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pctList.SelectedIndex == NOTFOUND)
                return;
            //string pctListString = pctList.Items[pctList.SelectedIndex].ToString();
            //pctID.Text = pctListString.Substring(pctListString.IndexOf('=') + 1, pctListString.Length - pctListString.IndexOf('=') - 1);
            pctID.Text = pctSearchedList[pctList.SelectedIndex].PCTID;
            taskLabel.Text = "";
            projectLabel.Text = pctSearchedList[pctList.SelectedIndex].VALUE;
            evtList.Items.Clear();
            evtSearchedList.Clear();
            string evtData = akc.GetReloadEVT(pctID.Text);
            int index = 0;
            int indexEnd = 0;
            do
            {
                if (indexEnd == NOTFOUND)
                    break;
                try
                {
                    index = evtData.IndexOf("<option value=\"", index) + 15;
                    indexEnd = evtData.IndexOf("</option>", indexEnd);
                }
                catch { break; }
                //if (index == -1 || indexEnd == -1)
                //  break;
                if (index != NOTFOUND && indexEnd != NOTFOUND)
                {
                    string evtId = evtData.Substring(index, indexEnd - index);
                    evtId = evtId.Replace("\">", "=");
                    evtList.Items.Add(evtId);
                    evtSearchedList.Add(evtId);
                    indexEnd++;
                    index++;
                }
            } while (index != NOTFOUND);
        }

        private void evtList_SelectedIndexChanged_2(object sender, EventArgs e)
        {
            if (evtList.SelectedIndex == NOTFOUND)
                return;
            string evtListString = evtList.Items[evtList.SelectedIndex].ToString();
            // evtID.Text = evtListString.Substring(evtListString.IndexOf('=') + 1, evtListString.Length - evtListString.IndexOf('=') - 1);
            int equPos = evtListString.IndexOf('=');
            evtID.Text = evtListString.Substring(0, equPos);
            taskLabel.Text = evtListString.Substring(equPos + 1, evtListString.Length - equPos - 1);
        }

        private void evtSearchText_TextChanged_1(object sender, EventArgs e)
        {
            evtList.Items.Clear();
            //evtSearchedList.Clear();
            foreach (string evt in evtSearchedList)
            {
                if (evt.ToUpper().IndexOf(evtSearchText.Text.ToUpper()) != NOTFOUND)
                {
                    //pctSearchedList.Add(pd);
                    evtList.Items.Add(evt);
                    //evtSearchedList.Add(evt);
                }
            }
        }

        private void pctSearchText_TextChanged_1(object sender, EventArgs e)
        {
            pctList.Items.Clear();
            pctSearchedList.Clear();
            foreach (ProjectData pd in projectData)
            {
                if (pd.VALUE.ToUpper().IndexOf(pctSearchText.Text.ToUpper()) != NOTFOUND)
                {
                    pctSearchedList.Add(pd);
                    pctList.Items.Add(pd.VALUE);
                }
            }
        }

        private void yearsWeek_Click(object sender, EventArgs e)
        {
            TextBox wt = (TextBox)sender;
            if (yearSelect == null)
            {
                yearSelect = new YearSelecter(wt);
            }
            else
            {
                yearSelect.Dispose();
                yearSelect = new YearSelecter(wt);
            }
            yearSelect.Location = new Point(wt.Location.X, wt.Location.Y);
            yearSelect.Show();     
        }

        private void mouthWeek_Click(object sender, EventArgs e)
        {
            TextBox wt = (TextBox)sender;
            if (mouthSelect == null)
            {
                mouthSelect = new MouthSelecter(wt);
            }
            else
            {
                mouthSelect.Dispose();
                mouthSelect = new MouthSelecter(wt);
            }
            mouthSelect.Location = new Point(wt.Location.X, wt.Location.Y);
            mouthSelect.Show();  
        }

        private void DayWeek_Click(object sender, EventArgs e)
        {
            TextBox wt = (TextBox)sender;
            if (daySelect == null)
            {
                daySelect = new DaySelecter(wt, Int16.Parse(yearsWeek.Text), Int16.Parse(mouthWeek.Text));
            }
            else
            {
                daySelect.Dispose();
                daySelect = new DaySelecter(wt, Int16.Parse(yearsWeek.Text), Int16.Parse(mouthWeek.Text));
            }
            daySelect.Location = new Point(wt.Location.X, wt.Location.Y);
            daySelect.Show();
        }

  

    

    }
}
