using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DOGPlatform
{
    struct ItemDicWellProduct
    {
        public string sJH;
        public string sYM;
        public string sXCM;
        public float fSCTS; //生产天数
        public float fYC_liquid;
        public float fYC_oil;
        public float fYC_water;
        public float fYC_gas;
        public float fSum_liquid;
        public float fSum_oil;
        public float fSum_water;
        public float fSum_gas;
        public float fRC_liquid;
        public float fRC_oil;
        public float fRC_water;
        public float fRC_gas;
        public float fWaterCut;
        public float fGOR;
        public float fTY;
        public float fYY;
        public float fLY;
        public float fJY;

    
    }
    struct ItemInputWellProduct
    {
        public string sJH;
        public string sYM;
        public float fSCTS; //生产天数
        public float fYC_oil;
        public float fYC_water;
        public float fYC_gas;
        public float fSum_oil;
        public float fSum_water;
        public float fSum_gas;
        public float fTY;
        public float fYY;
        public float fLY;
        public float fJY;

        public static string item2string(ItemInputWellProduct item)
        {
            List<string> ltStrWrited = new List<string>();
            ltStrWrited.Add(item.sJH);
            ltStrWrited.Add(item.sYM);
            ltStrWrited.Add(item.fSCTS.ToString());
            ltStrWrited.Add(item.fYC_oil.ToString());
            ltStrWrited.Add(item.fYC_water.ToString());
            ltStrWrited.Add(item.fYC_gas.ToString());
            ltStrWrited.Add(item.fSum_oil.ToString());
            ltStrWrited.Add(item.fSum_water.ToString());
            ltStrWrited.Add(item.fSum_gas.ToString());
            ltStrWrited.Add(item.fTY.ToString());
            ltStrWrited.Add(item.fYY.ToString());
            ltStrWrited.Add(item.fLY.ToString());
            ltStrWrited.Add(item.fJY.ToString());
            return string.Join("\t", ltStrWrited.ToArray());
        }

        public static ItemInputWellProduct parseLine(string line)
        {
            string[] split = line.Trim().Split(new char[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
            ItemInputWellProduct item = new ItemInputWellProduct();
            if (split.Count() >= 13)
            {

                item.sJH = split[0];
                item.sYM= split[1];
                item.fSCTS = 0.0f;
                float.TryParse(split[2], out item.fSCTS);
                item.fYC_oil = 0.0f;
                float.TryParse(split[3], out item.fYC_oil);
                item.fYC_water = 0.0f;
                float.TryParse(split[4], out item.fYC_water);
                item.fYC_gas   = 0.0f;
                float.TryParse(split[5], out item.fYC_gas);
                item.fSum_oil = 0.0f;
                float.TryParse(split[6], out item.fSum_oil);
                item.fSum_water = 0.0f;
                float.TryParse(split[7], out item.fSum_water);
                item.fSum_gas = 0.0f;
                float.TryParse(split[8], out item.fSum_gas);
                item.fTY = 0.0f;
                float.TryParse(split[9], out item.fTY);
                item.fYY = 0.0f;
                float.TryParse(split[10], out item.fYY);
                item.fLY = 0.0f;
                float.TryParse(split[11], out item.fLY);
                item.fJY = 0.0f;
                float.TryParse(split[12], out item.fJY);
            }
            return item;
        } 
    }
}
