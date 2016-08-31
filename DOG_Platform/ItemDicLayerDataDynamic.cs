using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DOGPlatform
{
    class ItemDicLayerDataDynamic
    {
        public string sYM;
        public string sJH;
        public string sXCM;
        public int iWellType;
        public float fSKHD; // she kong hou du
        public float fSCTS;//sheng chan tian shu 
        public float fYCY; //yue chan you
        public float fYCS; //yue chan shui
        public float fYCQ;//yue chan qi 
        public float fLCY; //lei chan you
        public float fLCS; //lei chan shui
        public float fLCQ; //lei chan qi 
        public float fYZS; //yue zhui shui 
        public float fLZS; //lei zhui shui
        public float fTY;  //tao ya
        public float fYY;  // you ya 
        public float fLY;  // liu ya 
        public float fJY;  // jing ya
        public float fPY;  //peng ya
        public float fSH;
        public float fYXHD;
        public float fKXD;
        public float fSTL;
        public float fKHpercent;

        public static string item2string(ItemDicLayerDataDynamic item)
        {
            List<string> ltStrWrited = new List<string>();
            ltStrWrited.Add(item.sYM);
            ltStrWrited.Add(item.sJH);
            ltStrWrited.Add(item.sXCM);
            ltStrWrited.Add(item.iWellType.ToString());
            ltStrWrited.Add(item.fSKHD.ToString("0.0"));
            ltStrWrited.Add(item.fSCTS.ToString());
            ltStrWrited.Add(item.fYCY.ToString());
            ltStrWrited.Add(item.fYCS.ToString());
            ltStrWrited.Add(item.fYCQ.ToString());
            ltStrWrited.Add(item.fLCY.ToString());
            ltStrWrited.Add(item.fLCS.ToString());
            ltStrWrited.Add(item.fLCY.ToString());
            ltStrWrited.Add(item.fYZS.ToString());
            ltStrWrited.Add(item.fLZS.ToString());
            ltStrWrited.Add(item.fTY.ToString());
            ltStrWrited.Add(item.fYY.ToString());
            ltStrWrited.Add(item.fLY.ToString());
            ltStrWrited.Add(item.fJY.ToString());
            ltStrWrited.Add(item.fPY.ToString());
            ltStrWrited.Add(item.fSH.ToString("0.0"));
            ltStrWrited.Add(item.fYXHD.ToString("0.0"));
            ltStrWrited.Add(item.fKXD.ToString("0.0"));
            ltStrWrited.Add(item.fSTL.ToString("0.0"));
            ltStrWrited.Add(item.fKHpercent.ToString("0.000"));

            return string.Join("\t", ltStrWrited.ToArray());
        }

        public static ItemDicLayerDataDynamic parseLine(string line)
        {
            string[] split = line.Trim().Split(new char[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
            ItemDicLayerDataDynamic item = new ItemDicLayerDataDynamic();
            if (split.Count() >= 12)
            {
                item.sYM = split[0];
                item.sJH = split[1];
                item.sXCM = split[2];
                item.iWellType  = 0;
                int.TryParse(split[3], out item.iWellType);
                item.fSKHD = 0.0f;
                float.TryParse(split[4], out item.fSKHD);
                item.fSCTS  = 0.0f;
                float.TryParse(split[5], out item.fSCTS);
                item.fYCY = 0.0f;
                float.TryParse(split[6], out item.fYCY);
                item.fYCS = 0.0f;
                float.TryParse(split[7], out item.fYCS);
                item.fYCQ= 0.0f;
                float.TryParse(split[8], out item.fYCQ);
                item.fLCY = 0.0f;
                float.TryParse(split[9], out item.fLCY);
                item.fLCS = 0.0f;
                float.TryParse(split[10], out item.fLCS);
                item.fLCQ= 0.0f;
                float.TryParse(split[11], out item.fLCQ);
                item.fYZS = 0.0f;
                float.TryParse(split[12], out item.fYZS);
                item.fLZS = 0.0f;
                float.TryParse(split[13], out item.fLZS);
                item.fTY = 0.0f;
                float.TryParse(split[14], out item.fTY);
                item.fYY = 0.0f;
                float.TryParse(split[15], out item.fYY);
                item.fLY = 0.0f;
                float.TryParse(split[16], out item.fLY);
                item.fJY = 0.0f;
                float.TryParse(split[17], out item.fJY);
                item.fPY = 0.0f;
                float.TryParse(split[18], out item.fPY);
                item.fSH = 0.0f;
                float.TryParse(split[19], out item.fSH);
                item.fYXHD = 0.0f;
                float.TryParse(split[20], out item.fYXHD);
                item.fKXD = 0.0f;
                float.TryParse(split[21], out item.fKXD);
                item.fSTL = 0.0f;
                float.TryParse(split[22], out item.fSTL);
                item.fKHpercent = 0.0f;
                float.TryParse(split[22], out item.fKHpercent);
            }
            return item;
        } 
    }
}
