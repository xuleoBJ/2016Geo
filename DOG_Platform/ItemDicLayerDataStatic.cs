using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DOGPlatform
{
    class ItemDicLayerDataStatic
    {
        public string sJH;
        public string sXCM;
        public double dbX;
        public double dbY;
        public double dbZ;
        public float fDCHD;
        public float fSH;
        public float fYXHD;
        public float fKXD;
        public float fSTL;
        public float fBHD;
        public float fDS1_md;
        public float fDS2_md;
        public float fDS1_TVD;

      public  static string item2string(ItemDicLayerDataStatic item)
        {
            List<string> ltStrWrited = new List<string>();
            ltStrWrited.Add(item.sJH);
            ltStrWrited.Add(item.sXCM);
            ltStrWrited.Add(item.dbX.ToString());
            ltStrWrited.Add(item.dbY.ToString());
            ltStrWrited.Add(item.dbZ.ToString());
            ltStrWrited.Add(item.fDCHD.ToString());
            ltStrWrited.Add(item.fSH.ToString());
            ltStrWrited.Add(item.fYXHD.ToString());
            ltStrWrited.Add(item.fKXD.ToString());
            ltStrWrited.Add(item.fSTL.ToString());
            ltStrWrited.Add(item.fBHD.ToString());
            ltStrWrited.Add(item.fDS1_md.ToString());
            ltStrWrited.Add(item.fDS2_md.ToString());
            ltStrWrited.Add(item.fDS1_TVD.ToString());
            return string.Join("\t", ltStrWrited.ToArray());
        }

      public  static ItemDicLayerDataStatic parseLine(string line)
      {
          string[] split = line.Trim().Split(new char[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
          ItemDicLayerDataStatic item = new ItemDicLayerDataStatic();
          if (split.Count() >= 12)
          {
              item.sJH = split[0];
              item.sXCM = split[1];
              item.dbX = 0.0;
              double.TryParse(split[2], out item.dbX);
              item.dbY = 0;
              double.TryParse(split[3], out item.dbY);
              item.dbZ = 0;
              double.TryParse(split[4], out item.dbZ);
              item.fDCHD = 0.0f;
              float.TryParse(split[5], out item.fDCHD);
              item.fSH = 0.0f;
              float.TryParse(split[6], out item.fSH);
              item.fYXHD = 0.0f;
              float.TryParse(split[7], out item.fYXHD);
              item.fKXD = 0.0f;
              float.TryParse(split[8], out item.fKXD);
              item.fSTL = 0.0f;
              float.TryParse(split[9], out item.fSTL);
              item.fBHD = 0.0f;
              float.TryParse(split[10], out item.fBHD);
              item.fDS1_md = 0.0f;
              float.TryParse(split[11], out item.fDS1_md);
              item.fDS2_md = 0.0f;
              float.TryParse(split[12], out item.fDS2_md);
              item.fDS1_TVD = 0.0f;
              float.TryParse(split[13], out item.fDS1_TVD);
          }
          return item;
      } 

    }

 
}
