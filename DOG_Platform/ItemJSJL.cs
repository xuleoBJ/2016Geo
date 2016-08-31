using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DOGPlatform
{
     struct ItemJSJL
    {
        public string sJH;
        public float fDS1;
        public float fDS2;
        public float fSandThickness;
        public float fNetPaySand;
        public float fKXD;
        public float fSTL;
        public float fBHD;
        public int iJSJL;

        public static string item2string(ItemJSJL item)
        {
            List<string> ltStrWrited = new List<string>();
            ltStrWrited.Add(item.sJH);
            ltStrWrited.Add(item.fDS1.ToString());
            ltStrWrited.Add(item.fDS2.ToString());
            ltStrWrited.Add(item.fSandThickness.ToString());
            ltStrWrited.Add(item.fNetPaySand.ToString());
            ltStrWrited.Add(item.fKXD.ToString());
            ltStrWrited.Add(item.fSTL.ToString());
            ltStrWrited.Add(item.fBHD.ToString());
            ltStrWrited.Add(item.iJSJL.ToString());
            return string.Join("\t", ltStrWrited.ToArray());
        }

        public static ItemJSJL parseLine(string line)
        {
            string[] split = line.Trim().Split(new char[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
            ItemJSJL item = new ItemJSJL();
            if (split.Length >= 9)
            {
                item.sJH = split[0];
                item.fDS1 = 0.0f;
                float.TryParse(split[1], out item.fDS1);
                item.fDS2 = 0.0f;
                float.TryParse(split[2], out item.fDS2);
                item.fSandThickness = 0.0f;
                float.TryParse(split[3], out item.fSandThickness);
                item.fNetPaySand = 0.0f;
                float.TryParse(split[4], out item.fNetPaySand);
                item.fKXD = -999.0f;
                float.TryParse(split[5], out item.fKXD);
                item.fSTL = -999.0f;
                float.TryParse(split[6], out item.fSTL);
                item.fBHD = -999.0f;
                float.TryParse(split[7], out item.fBHD);
                string _sJSJL = split[8];
                item.iJSJL = codeReplace.codeReplaceJSJL2int(_sJSJL);
            }
            return item;
        }

        
    }
}
