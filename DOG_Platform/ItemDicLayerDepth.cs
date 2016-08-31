using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DOGPlatform
{
    struct ItemLayerDepth
    {
        public float fDS1;
        public float fDS2;
        public string sXCM;
    }

    struct ItemLayerDepthInput
    {
        public string sJH;
        public string sXCM;
        public float fTop;
    }
    struct ItemDicLayerDepth
    {
        public string sJH;
        public string sXCM;
        public float fDS1;
        public float fDS2;
        public float fTVD_DS1;
        public float fTVD_DS2;


        public ItemDicLayerDepth(string _sJH, string _xcm)
        {
            sJH = _sJH;
            this.sXCM = _xcm;
            this.fDS1 = 0.0f;
            this.fDS2 = 0.0f;
            fTVD_DS1 = 0.0f;
            fTVD_DS2 = 0.0f;
        } 

        public static string item2string(ItemDicLayerDepth item)
        {
            List<string> ltStrWrited = new List<string>();
            ltStrWrited.Add(item.sJH);
            ltStrWrited.Add(item.sXCM);
            ltStrWrited.Add(item.fDS1.ToString());
            ltStrWrited.Add(item.fDS2.ToString());
            ltStrWrited.Add(item.fTVD_DS1.ToString());
            ltStrWrited.Add(item.fTVD_DS2.ToString());
            return string.Join("\t", ltStrWrited.ToArray());
        }

        public static ItemDicLayerDepth parseLine(string line)
        {
            string[] split = line.Trim().Split(new char[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
            ItemDicLayerDepth item = new ItemDicLayerDepth();
            if (split.Length >= 4)
            {
                item.sJH = split[0];
                item.sXCM = split[1];
                item.fDS1 = 0.0f;
                float.TryParse(split[2], out item.fDS1);
                item.fDS2 = 0.0f;
                float.TryParse(split[3], out item.fDS2);
                
            }
            return item;
        }
    }
 
}
