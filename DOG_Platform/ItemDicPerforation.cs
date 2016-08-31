using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DOGPlatform
{
    struct ItemDicPerforation
    {
        public string sJH;
        public string sXCM;
        public string YMstart; //射孔开始时间
        public string YMend;  //堵孔时间
        public float fSKHD; //射开厚度

        public static string item2string(ItemDicPerforation item)
        {
            List<string> ltStrWrited = new List<string>();
            ltStrWrited.Add(item.sJH);
            ltStrWrited.Add(item.sXCM);
            ltStrWrited.Add(item.YMstart);
            ltStrWrited.Add(item.YMend);
            ltStrWrited.Add(item.fSKHD.ToString());
            return string.Join("\t", ltStrWrited.ToArray());
        }
        public static ItemDicPerforation parseLine(string line)
        {
            string[] split = line.Trim().Split(new char[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
            ItemDicPerforation item = new ItemDicPerforation();
            if (split.Length >= 4)
            {
                item.sJH = split[0];
                item.sXCM = split[1];
                item.YMstart = split[2];
                item.YMend = split[3];
                item.fSKHD = 0.0f;
                float.TryParse(split[4], out item.fSKHD);
            }
            return item;
        }
    }

    struct ItemInputPerforate
    {
        public string sJH;
        public string sYM;
        public float fDS1;
        public float fDS2;

        public static ItemInputPerforate parseLine(string line)
        {
            string[] split = line.Trim().Split(new char[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
            ItemInputPerforate item = new ItemInputPerforate();
            if (split.Length >= 4)
            {
                item.sJH = split[0];
                item.sYM = split[1];
                item.fDS1 = 0.0f;
                float.TryParse(split[2], out item.fDS1);
                item.fDS2 = 0.0f;
                float.TryParse(split[3], out item.fDS2);
            }
            return item;
        }

        public static string item2string(ItemInputPerforate item)
        {
            List<string> ltStrWrited = new List<string>();
            ltStrWrited.Add(item.sJH);
            ltStrWrited.Add(item.sYM);
            ltStrWrited.Add(item.fDS1.ToString());
            ltStrWrited.Add(item.fDS2.ToString());
            return string.Join("\t", ltStrWrited.ToArray());
        }

    }
}
