using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DOGPlatform
{
    public struct ItemWellValue
    {
        public string sJH;
        public float fValue;

        public static string item2string(ItemWellValue item)
        {
            List<string> ltStrWrited = new List<string>();
            ltStrWrited.Add(item.sJH);
            ltStrWrited.Add(item.fValue.ToString());
            return string.Join("\t", ltStrWrited.ToArray());
        }

        public static ItemWellValue parseLine(string line)
        {
            string[] split = line.Trim().Split(new char[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
            ItemWellValue item = new ItemWellValue();
            if (split.Length >= 2)
            {
                item.sJH = split[0];
                item.fValue = 0.0f;
                float.TryParse(split[1], out item.fValue);
            }
            return item;
        }
    }
    public struct ItemWellLayerValue
    {
        public string sJH;
        public string sXCM;
        public double dX;
        public double dY;
        public float fValue;
    }

}
