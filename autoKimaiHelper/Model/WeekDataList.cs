using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autoKimaiHelper
{
    public class WeekDataList
    {
        public List<WeekDayData> w1;
        public List<WeekDayData> w2;
        public List<WeekDayData> w3;
        public List<WeekDayData> w4;
        public List<WeekDayData> w5;
        public WeekDataList()
        {
            w1 = new List<WeekDayData>();
            w2 = new List<WeekDayData>();
            w3 = new List<WeekDayData>();
            w4 = new List<WeekDayData>();
            w5 = new List<WeekDayData>();
        }
        //List<WeekDayData> w1 = new List<WeekDayData>();
        //List<WeekDayData> w1 = new List<WeekDayData>();
    }

    public class WeekDayData
    {
        string time;
        string pct;
        string evt;
    }
}
