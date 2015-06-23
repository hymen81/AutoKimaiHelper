using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MaterialSkin;
using MaterialSkin.Controls;

namespace autoKimaiHelper
{
    public partial class ProjectTaskSelect  : MaterialForm
    {
        TextBox inTb;
        List<ProjectData> projectData = new List<ProjectData>();
        List<ProjectData> pctSearchedList = new List<ProjectData>();
        List<string> evtSearchedList = new List<string>();
        AutoKimaiCore akc;
        private readonly MaterialSkinManager materialSkinManager;
        public ProjectTaskSelect(List<ProjectData> pd, Form1 f, TextBox tb) 
        {
            InitializeComponent();
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            projectData = pd;
            inTb = tb;
            foreach (ProjectData p in projectData)
            {
                pctList.Items.Add(p.VALUE);
                pctSearchedList.Add(p);
            }
            this.akc = AutoKimaiCore.getInstance(f);
        }
     
        

        private void pctList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pctList.SelectedIndex == -1)
                return;
            //string pctListString = pctList.Items[pctList.SelectedIndex].ToString();
            //pctID.Text = pctListString.Substring(pctListString.IndexOf('=') + 1, pctListString.Length - pctListString.IndexOf('=') - 1);
            pctID.Text = pctSearchedList[pctList.SelectedIndex].PCTID;
            pctIDString.Text = pctSearchedList[pctList.SelectedIndex].VALUE;
           // taskLabel.Text = "";
           // projectLabel.Text = pctSearchedList[pctList.SelectedIndex].VALUE;
            evtList.Items.Clear();
            evtSearchedList.Clear();
            string evtData = akc.GetReloadEVT(pctID.Text);
            int index = 0;
            int indexEnd = 0;
            do
            {
                if (indexEnd == -1)
                    break;
                try
                {
                    index = evtData.IndexOf("<option value=\"", index) + 15;
                    indexEnd = evtData.IndexOf("</option>", indexEnd);
                }
                catch { break; }
                //if (index == -1 || indexEnd == -1)
                //  break;
                if (index != -1 && indexEnd != -1)
                {
                    string evtId = evtData.Substring(index, indexEnd - index);
                    evtId = evtId.Replace("\">", "=");
                    evtList.Items.Add(evtId);
                    evtSearchedList.Add(evtId);
                    indexEnd++;
                    index++;
                }
            } while (index != -1);
        }

        private void evtList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (evtList.SelectedIndex == -1)
                return;
            string evtListString = evtList.Items[evtList.SelectedIndex].ToString();
            // evtID.Text = evtListString.Substring(evtListString.IndexOf('=') + 1, evtListString.Length - evtListString.IndexOf('=') - 1);
            int equPos = evtListString.IndexOf('=');
            evtID.Text = evtListString.Substring(0, equPos);
            evtIDString.Text = evtListString.Substring(equPos + 1, evtListString.Length - equPos - 1);
            //taskLabel.Text = evtListString.Substring(equPos + 1, evtListString.Length - equPos - 1);
        }

        private void pctSearchText_TextChanged(object sender, EventArgs e)
        {
            pctList.Items.Clear();
            pctSearchedList.Clear();
            foreach (ProjectData pd in projectData)
            {
                if (pd.VALUE.ToUpper().IndexOf(pctSearchText.Text.ToUpper()) != -1)
                {
                    pctSearchedList.Add(pd);
                    pctList.Items.Add(pd.VALUE);
                }
            }
        }

        private void evtSearchText_TextChanged(object sender, EventArgs e)
        {
            evtList.Items.Clear();
            foreach (string evt in evtSearchedList)
            {
                if (evt.ToUpper().IndexOf(evtSearchText.Text.ToUpper()) != -1)
                {
                    //pctSearchedList.Add(pd);
                    evtList.Items.Add(evt);
                }
            }
        }

        private void ProjectTaskSelect_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            inTb.Text = pctIDString.Text + "," + evtIDString.Text;
            inTb.Tag = pctID.Text + "," + evtID.Text;
            this.Close();
        }
    }
}
