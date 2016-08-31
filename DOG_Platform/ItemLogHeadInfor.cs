using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
namespace DOGPlatform
{
     public class  ItemLogHeadInfor
    {
            public string sJH;
            public string sLogName;
            public string sLogText;
            public string sUnit;
            public float fLeftValue;
            public float fRightValue;
            public int iIsLog;
            public string sLogColor;
            public string sFill;
            public float fillOpacity;
            public float fLineWidth;
            public int iLineType;
            public object backItem;

            public ItemLogHeadInfor()
            {
                 sLogColor="black";
                 sFill="none";
                 iIsLog = 0;
                 fLineWidth=1.0F;
                 iLineType=0;
                 fillOpacity = 0.8F;
            }

            public ItemLogHeadInfor(string _sJH, string _sLogName) : this(_sJH, _sLogName, 0, 100)
            {

            }

            public ItemLogHeadInfor(string _sJH, string _sLogName, float _fLeftValue, float _fRightValue)
                : this(_sJH, _sLogName, _fLeftValue, _fRightValue,"black")
            {
               
            }

            public ItemLogHeadInfor(string _sJH, string _sLogName, float _fLeftValue, float _fRightValue, string _sLogColor):this()
            {
                this.sJH = _sJH;
                this.sLogName = _sLogName;
                this.fLeftValue = _fLeftValue;
                this.fRightValue = _fRightValue;
                this.sLogColor = _sLogColor;
                this.fLineWidth = 1.0f;
            } 

            public static string item2Line(ItemLogHeadInfor itemLogHeadInfor)
            {
                List<string> ltStrWrited = new List<string>();
                ltStrWrited.Add(itemLogHeadInfor.sJH);
                ltStrWrited.Add(itemLogHeadInfor.sLogName);
                ltStrWrited.Add(itemLogHeadInfor.sUnit);
                ltStrWrited.Add(itemLogHeadInfor.fLeftValue.ToString());
                ltStrWrited.Add(itemLogHeadInfor.fRightValue.ToString());
                ltStrWrited.Add(itemLogHeadInfor.iIsLog.ToString());
                ltStrWrited.Add(itemLogHeadInfor.sLogColor);
                ltStrWrited.Add(itemLogHeadInfor.fLineWidth.ToString());
                ltStrWrited.Add(itemLogHeadInfor.iLineType.ToString());
                return string.Join("\t", ltStrWrited.ToArray());
            }
    }

    
}
