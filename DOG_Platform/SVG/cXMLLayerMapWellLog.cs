using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Drawing;
using DOGPlatform.XML;

namespace DOGPlatform.SVG
{
    class LayerDataLog:ItemLogHeadInfor
    {
        public string sLayerID;
        public string sLayerType;
        public string sLayerTitle;
        public int iTrackWidth;
        public int iVisible;
        public float fVScale = 1;
        public int iSparceNum = 1;
        public int iHasGrid = 1;
        public int iDx = 5;
        public int iDy = 5;
        public int iLeftDraw = 0;
        public int isPloygon = 0;

        public LayerDataLog(XmlNode el_Layer)
        {
            XmlElement el = (XmlElement)el_Layer;
            initialTrackData(el);
        }

        public LayerDataLog(XmlElement el_Layer)
        {
            initialTrackData(el_Layer);
        }

        void initialTrackData(XmlElement el_Layer)
        {
            sLayerID = el_Layer.Attributes["id"].Value;
            sLayerType = el_Layer.Attributes["layerType"].Value;
            sLayerTitle = el_Layer["title"].InnerText;
            iTrackWidth = int.Parse(el_Layer["trackWidth"].InnerText);
            fVScale = float.Parse(el_Layer["fVScale"].InnerText);
            iVisible = int.Parse(el_Layer["visible"].InnerText);
            this.sLogName = el_Layer["logName"].InnerText;
            this.fLeftValue = float.Parse(el_Layer["leftValue"].InnerText);
            this.fRightValue = float.Parse(el_Layer["rightValue"].InnerText);
            this.fLineWidth = float.Parse(el_Layer["lineWidth"].InnerText);
            this.iIsLog = int.Parse(el_Layer["is2Log10"].InnerText);
            this.sLogColor = el_Layer["curveColor"].InnerText;
            this.sFill = el_Layer["sFill"].InnerText;
            this.iLineType = int.Parse(el_Layer["lineType"].InnerText);
            this.iHasGrid = int.Parse(el_Layer["hasGrid"].InnerText);
            int.TryParse(el_Layer["sparsePoint"].InnerText, out this.iSparceNum);
            int.TryParse(el_Layer["DX_Text"].InnerText, out this.iDx);
            int.TryParse(el_Layer["DY_Text"].InnerText, out this.iDy);
            int.TryParse(el_Layer["iLeftDraw"].InnerText, out this.iLeftDraw);
            int.TryParse(el_Layer["isPloygon"].InnerText, out this.isPloygon);
        }
    }
    class cXMLLayerMapWellLog
    {
        public static XmlElement gWellLogPattern(XmlDocument svgDoc, LayerDataLog logHeadInfor, int iTrackwidth, List<double> fListValue, double fVScale)
        {
            string sLogName = logHeadInfor.sLogName;
            double fLeftValue = logHeadInfor.fLeftValue;
            double fRightValue = logHeadInfor.fRightValue;
            float iLinewidth = logHeadInfor.fLineWidth;
            int iLineType = logHeadInfor.iLineType;
            double xViewTrack = 0f;
            //对大小支进行值域质量控制
            double qcMinValue = Math.Min(fLeftValue, fRightValue) / 2;
            double qcMaxValue = Math.Max(fLeftValue, fRightValue) * 2;

            string _points = "";
            //曲线可能反转，所以一定要加值
            XmlElement gLog = svgDoc.CreateElement("g");
            xViewTrack = cSVGSectionTrackLog.getXview(qcMinValue, fLeftValue, fRightValue, iTrackwidth);
            _points += (xViewTrack).ToString("0.0") + ",0 " ;
            for (int iDepth = 0; iDepth < fListValue.Count; iDepth++)
            {
                #region logCurve
                double fDepth = iDepth * fVScale;
                double fValue = fListValue[iDepth];
                if (qcMinValue <= fValue && fValue <= qcMaxValue)
                {
                    xViewTrack =  iTrackwidth * (fValue - fLeftValue) / (fRightValue - fLeftValue);;
                    _points += (xViewTrack).ToString("0.0") + ',' + fDepth.ToString("0.0") + " ";
                }
            }

            xViewTrack = cSVGSectionTrackLog.getXview(qcMinValue, fLeftValue, fRightValue, iTrackwidth);
            _points += (xViewTrack).ToString("0.0") + ',' + (fListValue.Count * fVScale).ToString("0.0") + " ";
            //平面图用ployLine好看一些
            string sLogDrawPattern = "polyline";
            if (logHeadInfor.isPloygon == 1) sLogDrawPattern = "polygon";
            XmlElement gLogPolygon = svgDoc.CreateElement(sLogDrawPattern);
            //gLogPolygon.SetAttribute("id", logHeadInfor.sIDLog);
            gLogPolygon.SetAttribute("onclick", "getID(evt)");
            gLogPolygon.SetAttribute("stroke-width", iLinewidth.ToString());
            gLogPolygon.SetAttribute("stroke", logHeadInfor.sLogColor);
            gLogPolygon.SetAttribute("stroke-dasharray", codeReplace.codeReplaceStrokeDashInt2Str(iLineType));
            gLogPolygon.SetAttribute("fill", logHeadInfor.sFill);
            gLogPolygon.SetAttribute("ill-opacity", "0.8");
            gLogPolygon.SetAttribute("points", _points);
            gLog.AppendChild(gLogPolygon); 
                #endregion
            return gLog;
        }

        public static XmlElement gLayerWellLog(cSVGDocLayerMap svgLayer, ItemWellMapPosition ltWellPos, LayerDataLog layerDataLog)
        {
            string sJH = ltWellPos.sJH;
            string sLogName = layerDataLog.sLogName;
            int iTrackwidth = layerDataLog.iTrackWidth;
            float fVScale = layerDataLog.fVScale;
            //double fTop = itemStaticWellPosi.dbTop;
            //double fBot = itemStaticWellPosi.dbBot;
            double fTop = 1100;
            double fBot = 1110;
            //获得测井数据
            trackDataListLog dlTrackDataListLog = cSVGSectionTrackLog.getLogSeriersFromLogFile(sJH, sLogName, fTop, fBot);
            XmlElement gEleWellLogPattern = gWellLogPattern(svgLayer.svgDoc, layerDataLog, iTrackwidth, dlTrackDataListLog.fListValue, fVScale);
            return gEleWellLogPattern; 
        } 
    }
}
