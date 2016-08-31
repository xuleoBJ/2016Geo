using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using DOGPlatform.XML;

namespace DOGPlatform
{
   public  class itemLogHeadInforDraw : ItemLogHeadInfor
    {
        public int iLogCurveVisible = 0;
        public int iHasGrid = 1;
        public int iLogGridGrade = 0;
        public string sIDLog = "";
        public string typeMode = "";
        public int iSparceNum = 2;
        public itemLogHeadInforDraw()
        { }
        public itemLogHeadInforDraw(XmlElement xnLog)
        {
            this.sJH = sJH;
            this.sLogName = xnLog["logName"].InnerText;
            this.sUnit = xnLog["unit"].InnerText;
            this.fLeftValue = float.Parse(xnLog["leftValue"].InnerText);
            this.fRightValue = float.Parse(xnLog["rightValue"].InnerText);
            this.fLineWidth = float.Parse(xnLog["lineWidth"].InnerText);
            this.iIsLog = int.Parse(xnLog["is2Log10"].InnerText);
            this.sLogColor = xnLog["curveColor"].InnerText;
            this.sFill = xnLog["fill"].InnerText;
            this.iLineType = int.Parse(xnLog["lineType"].InnerText);
            this.iLogCurveVisible = int.Parse(xnLog["visible"].InnerText);
            this.iHasGrid = int.Parse(xnLog["hasGrid"].InnerText);
            this.typeMode = xnLog["typeMode"].InnerText;
            this.iLogGridGrade = 0;
            int.TryParse(xnLog["sparsePoint"].InnerText, out this.iSparceNum);
            this.sIDLog = xnLog.Attributes["id"].Value;
            this.sLogText =  xnLog["logText"] != null ? xnLog["logText"].InnerText : ""; 
        }
    }

    class trackDataDraw 
    {
        public string sTrackID ;
        public string sTrackType ;
        public string sTrackTitle;
        public  int iTrackWidth;
        public int iTrackHeadFontSize;
        public int iTrackFontSize;
        public int iVisible;
        public string sWriteMode ;
        
        public trackDataDraw(XmlNode el_Track)
        {
            XmlElement el = (XmlElement)el_Track;
            initialTrackData(el); 
        }

        void initialTrackData(XmlElement el_Track) 
        {
            sTrackID = el_Track.Attributes["id"].Value;
            sTrackType = el_Track["trackType"].InnerText;
            sTrackTitle = el_Track["trackTitle"].InnerText;
            iTrackWidth = int.Parse(el_Track["trackWidth"].InnerText);
            iTrackHeadFontSize = int.Parse(el_Track["trackHeadFontSize"].InnerText);
            iTrackFontSize = int.Parse(el_Track["fontSize"].InnerText);
            iVisible = int.Parse(el_Track["visible"].InnerText);
            sWriteMode = el_Track["writingMode"].InnerText;
        }

        public trackDataDraw(XmlElement el_Track)
        {
           initialTrackData(el_Track) ; 
        }
      
    }

    class itemDrawDataTrackFill 
    {
         public string sID;
         public int iFillMode;
         public string sIDmainLog;
         public string sIDsub;
         public double fValueCutoff; //可以是值id 也可能是 cutOff value
         public string sFill;
         public float fTop;
         public float fBot;
         public float fillOpacity;
         public itemDrawDataTrackFill(XmlNode xn)
         {
             sID = xn.Attributes["id"].Value;
             iFillMode = int.Parse(xn["iModeFill"].InnerText);
             sIDmainLog = xn["idLogMain"].InnerText;
             sIDsub = xn["idLogSub"].InnerText;
             fValueCutoff =float.Parse(xn["fCutoffValue"].InnerText);
             sFill = xn["fill"].InnerText;
             fTop = float.Parse(xn["top"].InnerText);
             fBot = float.Parse(xn["bot"].InnerText);
             fillOpacity = float.Parse(xn["fillOpacity"].InnerText);
         } 
    }

    class trackDataListInterval
    {
        public List<float> fListDS1 = new List<float>();
        public List<float> fListDS2 = new List<float>();
    }

    class trackDataListIntervalText
    {
        public List<float> fListDS1 = new List<float>();
        public List<float> fListDS2 = new List<float>();
        public List<string> ltStrText = new List<string>();
    }

    class trackDataListIntervalValue
    {
        public List<float> fListDS1 = new List<float>();
        public List<float> fListDS2 = new List<float>();
        public List<float> fListValue = new List<float>();
    }

   

    class trackDataListScatterPoint
    {
        public List<double> fListDepth = new List<double>();
        public List<double> fListValue = new List<double>();
    }

    class trackDataListJSJL
    {
        public List<float> fListDS1 = new List<float>();
        public List<float> fListDS2 = new List<float>();
        public List<string> sListJSJL = new List<string>();

        public static trackDataListJSJL setupDataListTrack(string filePath, float fTop, float fBase)
        {
            trackDataListJSJL trackDataListJSJL = new trackDataListJSJL();
            if (!File.Exists(filePath)) return trackDataListJSJL;
            string sData = "";

            using (StreamReader sr = new StreamReader(filePath, System.Text.Encoding.Default))
            {
                sData = sr.ReadToEnd();
            }
            string[] split = sData.Trim().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < split.Length; i = i + 3)
            {
                float fCurrentTop = float.Parse(split[i]);
                float fCurrentBase = float.Parse(split[i + 1]);
                if (fTop <= fCurrentTop && fCurrentBase <= fBase)
                {
                    trackDataListJSJL.fListDS1.Add(fCurrentTop);
                    trackDataListJSJL.fListDS2.Add(fCurrentBase);
                    trackDataListJSJL.sListJSJL.Add(split[i + 2]);
                }
            }
            return trackDataListJSJL;
        }

    }

    class trackDataListProfile
    {
        public List<float> fListDS1 = new List<float>();
        public List<float> fListDS2 = new List<float>();
        public List<float> fListPercent = new List<float>();
        public List<float> fListZRL = new List<float>();


        public static trackDataListProfile setupDataListTrack(string filePath, float fTop, float fBase)
        {
            trackDataListProfile trackDataList = new trackDataListProfile();
            if (File.Exists(filePath))
            {
                string sData = "";
                using (StreamReader sr = new StreamReader(filePath, System.Text.Encoding.Default))
                {
                    sData = sr.ReadToEnd();
                }

                string[] split = sData.Trim().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < split.Length; i = i + 9)
                {
                    string sJH = split[i];
                    float fCurrentTop = float.Parse(split[i + 2]);
                    float fCurrentBase = float.Parse(split[i + 3]);
                    float fZRL = float.Parse(split[i + 4]);
                    float fPercent = float.Parse(split[i + 5]);

                    if (fTop <= fCurrentTop && fCurrentBase <= fBase)
                    {
                        trackDataList.fListDS1.Add(fCurrentTop);
                        trackDataList.fListDS2.Add(fCurrentBase);
                        trackDataList.fListPercent.Add(fPercent);
                        trackDataList.fListZRL.Add(fZRL);
                    }
                }
            }
            return trackDataList;
        }

    }
}
