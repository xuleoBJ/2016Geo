using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using DOGPlatform.XML;

namespace DOGPlatform.SVG
{
    class cSVGSectionTrackLogComposite
    {
        public static XmlElement gTrackCompositeLog(XmlDocument svgDoc,int iTrackwidth,string sData, double fVScale)
        {
            int iCountSparse = cSVGSectionTrackLog.setCountSpare(fVScale);
            string[] splitLine = sData.Trim().Split(new string[] { cProjectData.splitMark }, StringSplitOptions.RemoveEmptyEntries);
            List<double> fListDepthInput = new List<double>();
            List<List<double>> ListltValue = new List<List<double>>();
            XmlElement gLog = svgDoc.CreateElement("g");
            for (int iLine = 0; iLine < splitLine.Length; iLine = iLine + iCountSparse * 2)
            {
                string[] splitValue = splitLine[iLine].Trim().Split();
                List<double> ltLogValue = new List<double>();
                for (int i = 0; i < splitValue.Length; i++ )
                {
                    if (i == 0)
                    { double _depth = 0.0; double.TryParse(splitValue[0], out _depth); fListDepthInput.Add(_depth); }
                    else
                    {
                        double _value = 0.0;
                        double.TryParse(splitValue[i], out _value);
                        ltLogValue.Add(_value);
                    } 
                }
                ListltValue.Add(ltLogValue);
            }
            return gLog;
        }
        public static XmlElement gTrackCompositeLog(XmlDocument svgDoc, itemLogHeadInforDraw item, int iTrackwidth, List<double> fListDepthInput,  List<string> fListStrValue,  double fVScale)
        {
            //传字符串 到这里解析 未知多少个组分
            List<List<double>> ListltValue = new List<List<double>>();
            //将传入的List<string> 变换

            foreach (string strLineValue in fListStrValue) 
            {
                string[] split = strLineValue.Split();
                List<double> ltLogValue = new List<double>();
                foreach (string sValue in split) 
                {
                    double _value = 0.0;
                    double.TryParse(sValue, out _value);
                    ltLogValue.Add(_value);
                }
                ListltValue.Add(ltLogValue);
            }

            //第一条曲线取值字符串的第一个截断 

            string sLogName = item.sLogName;
            double fLeftValue = item.fLeftValue;
            double fRightValue = item.fRightValue;
            string m_sColorCurve = item.sLogColor;
            string sFill = item.sFill;
            float iLinewidth = item.fLineWidth;
            int iLineType = item.iLineType;

            double _xView_f = 0f;

            //新增的曲线拼接上一条曲线

            string _points = "";
            
            XmlElement gLog = svgDoc.CreateElement("g");
            if (fListDepthInput.Count > 0)
            {
                #region loop in mutiLog,循环添加测井曲线 
                for (int k = 0; k < ListltValue[0].Count; k++)
                {
                    for (int i = 0; i < fListDepthInput.Count; i++)
                    {
                        double fDepth = fListDepthInput[i] * fVScale;
                        double fValue = ListltValue[i].GetRange(0, k).Sum();
                        if (0 <= fValue && fValue <= 100)
                        {
                            _xView_f = iTrackwidth * (fValue - 0) / 100;
                            if (_xView_f < 0) _xView_f = 0;
                            else if (_xView_f > iTrackwidth) _xView_f = iTrackwidth;
                            _points += (_xView_f).ToString("0.0") + ',' + fDepth.ToString("0.0") + " ";
                        }
                    }

                    XmlElement gLogPolygon = svgDoc.CreateElement("polygon");
                    gLogPolygon.SetAttribute("id", item.sIDLog);
                    gLogPolygon.SetAttribute("onclick", "getID(evt)");
                    gLogPolygon.SetAttribute("stroke-width", iLinewidth.ToString());
                    gLogPolygon.SetAttribute("stroke", m_sColorCurve);
                    gLogPolygon.SetAttribute("stroke-dasharray", codeReplace.codeReplaceStrokeDashInt2Str(iLineType));
                    gLogPolygon.SetAttribute("fill", sFill);
                    gLogPolygon.SetAttribute("points", _points);
                    gLog.AppendChild(gLogPolygon);
                }
                #endregion 循环添加曲线
            }
            return gLog;
        }
    }
}
