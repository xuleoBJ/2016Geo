using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DOGPlatform
{
    struct ItemDicInjectProfile
    {
       
            public string sJH;
            public string sYM;
            public float fDS1;
            public float fDS2;
            public float fZRL; //绝对注入量
            public float fPercentZR;//相对注入量%
            public float fXSHD; //吸水厚度
            public float FXSQD; //吸水强度
            public string sXCM;

            public static string item2string(ItemDicInjectProfile item)
            {
                List<string> ltStrWrited = new List<string>();
                ltStrWrited.Add(item.sJH);
                ltStrWrited.Add(item.sYM);
                ltStrWrited.Add(item.fDS1.ToString());
                ltStrWrited.Add(item.fDS2.ToString());
                ltStrWrited.Add(item.fZRL.ToString());
                ltStrWrited.Add(item.fPercentZR.ToString("0.0"));
                ltStrWrited.Add(item.fXSHD.ToString("0.0"));
                ltStrWrited.Add(item.FXSQD.ToString("0.0"));
                ltStrWrited.Add(item.sXCM);
                return string.Join("\t", ltStrWrited.ToArray());
            }

            public static ItemDicInjectProfile parseLine(string line)
            {
                string[] split = line.Trim().Split(new char[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
                ItemDicInjectProfile item = new ItemDicInjectProfile();
                if (split.Length >=9 )
                {
                    item.sJH = split[0];
                    item.sYM = split[1];
                    item.fDS1 = 0.0f;
                    float.TryParse(split[2], out item.fDS1);
                    item.fDS2 = 0.0f;
                    float.TryParse(split[3], out item.fDS2);
                    item.fZRL = 0.0f;
                    float.TryParse(split[4], out item.fZRL);
                    item.fPercentZR = 0.0f;
                    float.TryParse(split[5], out item.fPercentZR);
                    item.fXSHD = 0.0f;
                    float.TryParse(split[6], out item.fXSHD);
                    item.FXSQD = 0.0f;
                    float.TryParse(split[7], out item.FXSQD);
                    item.sXCM = split[8];
                }
                return item;
            }
    }

    

   
}
