using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DOGPlatform
{
    struct ItemDicWellInjection
    {
        public string sJH;
        public string sYM;
        public string sXCM;
        public float fZSTS; //注水天数
        public float fRZSL; //日注水量
        public float fYZSL; //月注水量
        public float fLZSL;  //累注水量
        public float fTY;
        public float fYY;
        public float fLY;
        public float fJY;
        public float fPY;
    }

    struct ItemInputWellInject
    {
        public string sJH;
        public string sYM;
        public float fZSTS; //注水天数
        public float fYZSL; //月注水量
        public float fLZSL;  //累注水量
        public float fTY;
        public float fYY;
        public float fLY;
        public float fJY;
        public float fPY;
        public static string item2string(ItemInputWellInject item)
        {
            List<string> ltStrWrited = new List<string>();
            ltStrWrited.Add(item.sJH);
            ltStrWrited.Add(item.sYM);
            ltStrWrited.Add(item.fZSTS.ToString());
            ltStrWrited.Add(item.fYZSL.ToString());
            ltStrWrited.Add(item.fLZSL.ToString());
            ltStrWrited.Add(item.fTY.ToString());
            ltStrWrited.Add(item.fYY.ToString());
            ltStrWrited.Add(item.fLY.ToString());
            ltStrWrited.Add(item.fJY.ToString());
            ltStrWrited.Add(item.fPY.ToString());
            return string.Join("\t", ltStrWrited.ToArray());
        }

        public static ItemInputWellInject parseLine(string line)
        {
            string[] split = line.Trim().Split(new char[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
            ItemInputWellInject item = new ItemInputWellInject();
            if (split.Count() >= 10)
            {

                item.sJH = split[0];
                item.sYM = split[1];
                item.fZSTS = 0.0f;
                float.TryParse(split[2], out item.fZSTS);
                item.fYZSL = 0.0f;
                float.TryParse(split[3], out item.fYZSL);
                item.fLZSL = 0.0f;
                float.TryParse(split[4], out item.fLZSL);
                item.fTY = 0.0f;
                float.TryParse(split[5], out item.fTY);
                item.fYY  = 0.0f;
                float.TryParse(split[6], out item.fYY);
                item.fLY = 0.0f;
                float.TryParse(split[7], out item.fLY);
                item.fJY = 0.0f;
                float.TryParse(split[8], out item.fJY);
                item.fPY = 0.0f;
                float.TryParse(split[9], out item.fPY);
            }
            return item;
        } 
    }
}
