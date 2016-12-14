using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace DOGPlatform
{
    class ItemWellMapPosition 
    {
        public string sJH;
        public string sXCM;
        public double dbX;
        public double dbY;
        public double dbZ;
        public double dbTop;
        public double dbBot;
        public double dbTopTVD;
        public double dbBotTVD;
        public int iWellType;

        public ItemWellMapPosition()
        {
           
        }
        public ItemWellMapPosition(ItemDicLayerDataStatic item)
        {
            this.sJH = item.sJH;
            this.sXCM = item.sXCM;
            this.dbX = item.dbX;
            this.dbY = item.dbY;
            this.dbTop = item.fDS1_md;
            this.dbBot = item.fDS2_md;
            this.iWellType = cProjectData.ltProjectWell.Find(p => p.sJH == item.sJH).iWellType;
        }

        public ItemWellMapPosition(string sJH)
        {
            ItemWellHead item = cIOinputWellHead.getWellHeadByJH(sJH); 
            this.sJH = sJH;
            this.sXCM = "0";
            this.dbX = item.dbX;
            this.dbY = item.dbY;
            this.iWellType = item.iWellType;
            this.iWellType = cProjectData.ltProjectWell.Find(p => p.sJH == item.sJH).iWellType;
        }

        public static string item2string(ItemWellMapPosition item)
        {
            List<string> ltStrWrited = new List<string>();
            ltStrWrited.Add(item.sJH);
            ltStrWrited.Add(item.sXCM);
            ltStrWrited.Add(item.dbX.ToString());
            ltStrWrited.Add(item.dbY.ToString());
            ltStrWrited.Add(item.iWellType.ToString());
            return string.Join("\t", ltStrWrited.ToArray());
        }

        public static ItemWellMapPosition parseLine(string line)
        {
            string[] split = line.Trim().Split(new char[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
            ItemWellMapPosition item = new ItemWellMapPosition();
            if (split.Count() >= 5)
            {
                item.sJH = split[0];
                item.sXCM = split[1]; 
                item.dbX = 0.0;
                double.TryParse(split[2], out item.dbX);
                item.dbY = 0.0;
                double.TryParse(split[3], out item.dbY);
                item.dbZ = 0.0;
                double.TryParse(split[4], out item.dbZ);
                item.dbTop = 0.0;
                double.TryParse(split[11], out item.dbTop);
                item.dbBot = 0.0;
                double.TryParse(split[12], out item.dbBot);
            }
            return item;
        } 
    }
}
