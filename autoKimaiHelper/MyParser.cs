using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autoKimaiHelper
{
    public class MyParser 
    {
        private static MyParser instance = null;
        private  Form1 ui = null;
        List<ProjectData> projectData = new List<ProjectData>();
        AutoKimaiCore akc;

        MyParser() { }

        public void SetUI(Form1 f)
        {
            ui = f;
            akc = AutoKimaiCore.getInstance(ui);
           // f.Invoke((sender, args) => (sender as TextBox).Text = "text");
        }

        public static MyParser GetInstance() 
        {
            if (null == instance)
                instance = new MyParser();
            return instance;
        }

        public void ParserProjectListString(string s)
        {
          /*  projectData.Clear();
            string result = akc.GetDataList();
            outPutLine.Items.Add(result);
          //  Clipboard.SetData(System.Windows.Forms.DataFormats.Text, result.ToString());

          
            string p = "option";
           

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
            }*/
        }



    }
}
