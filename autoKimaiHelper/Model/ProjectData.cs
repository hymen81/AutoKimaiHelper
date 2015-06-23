using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autoKimaiHelper
{
    public class ProjectData
    {
        private string pctId;
        private string value;
        public ProjectData(string pct, string v)
        {
            pctId = pct;
            value = v;
        }
        public string PCTID
        {
            get { return pctId; }
        }
        public string VALUE
        {
            get { return value; }
        }

    }
}
