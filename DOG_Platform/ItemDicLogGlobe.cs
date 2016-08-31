using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DOGPlatform
{
    class ItemDicLogGlobe
    {
        public string sLogID;
        public string sLogText;
        public string sUnit="none";
        public float fLeftValue=0;
        public float fRightValue=100;
        public int iIsLog=0;
        public string sLogColor="black";
        public float fLineWidth=1;
        public int iLineType=0;
        public ItemDicLogGlobe(string _sLogID)
        {
            this.sLogID = _sLogID;
            this.sLogText = _sLogID;
        }
        public static string item2Line(ItemDicLogGlobe itemLogHeadInfor)
        {
            List<string> ltStrWrited = new List<string>();
            ltStrWrited.Add(itemLogHeadInfor.sLogID);
            ltStrWrited.Add(itemLogHeadInfor.sLogText);
            ltStrWrited.Add(itemLogHeadInfor.sUnit);
            ltStrWrited.Add(itemLogHeadInfor.sLogColor);
            ltStrWrited.Add(itemLogHeadInfor.fLeftValue.ToString());
            ltStrWrited.Add(itemLogHeadInfor.fRightValue.ToString());
            ltStrWrited.Add(itemLogHeadInfor.iIsLog.ToString());
            ltStrWrited.Add(itemLogHeadInfor.fLineWidth.ToString());
            ltStrWrited.Add(itemLogHeadInfor.iLineType.ToString());
            return string.Join("\t", ltStrWrited.ToArray());
        }
    }
}
