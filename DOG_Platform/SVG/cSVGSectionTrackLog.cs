using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using DOGPlatform.XML;
using System.IO;

namespace DOGPlatform.SVG
{
    class cSVGSectionTrackLog : cSVGSectionTrack
    {

        public XmlElement gPathTrackLog(string sJH, string sLogName, List<float> fListMD, List<float> fListValue,
           float m_KB, float fLeftValue, float fRightValue, string sColorCurve)
        {
            XmlElement gLogTrack = svgDoc.CreateElement("g");
            gLogTrack.SetAttribute("id", sJH + "#" + sLogName);
            gLogTrack.SetAttribute("stroke", sColorCurve);
            gLogTrack.SetAttribute("stroke-width", "0.5");
            if (sLogName == null || fListMD.Count == 0) return gLogTrack;
            string _points = "";

            List<ItemDicWellPath> listWellPath = cIOinputWellPath.getWellPathItemListByJHAndMDList(sJH, fListMD);
            List<ItemDicWellPath> listWellPathHorzion = new List<ItemDicWellPath>();
            List<float> fListMDHorizina = new List<float>();
            List<float> fListValueHorizina = new List<float>();
            double x0 = listWellPath[0].f_dx;
            double y0 = -m_KB + listWellPath[0].f_TVD;
            for (int i = 0; i < fListMD.Count; i++)
            {
                ItemDicWellPath currentWellPath = listWellPath[i];
                double currentX = currentWellPath.f_dx;
                double currentY = -m_KB + currentWellPath.f_TVD;
                if (currentWellPath.f_incl <= 85)
                {
                    float xViewTrack = 0.0f;
                    if (-500 <= fListValue[i] && fListValue[i] < 1000)
                    {
                        xViewTrack = this.iTrackWidth * (fListValue[i] - fLeftValue) / (fRightValue - fLeftValue);
                        _points = _points + (currentX + xViewTrack).ToString() + ',' + currentY.ToString() + " ";
                    }
                }
                else if (currentWellPath.f_incl >= 85 && i % 3 == 0)
                {
                    listWellPathHorzion.Add(currentWellPath);
                    fListMDHorizina.Add(fListMD[i]);
                    fListValueHorizina.Add(fListValue[i]);
                }
            }
            XmlElement gLogPolygon = svgDoc.CreateElement("polyline");
            gLogPolygon.SetAttribute("fill", "none");
            gLogPolygon.SetAttribute("points", _points);
            gLogTrack.AppendChild(gLogPolygon);

            gLogTrack.AppendChild(gTrackLogHeadText(x0, y0, sLogName, sColorCurve));
            gLogTrack.AppendChild(gTrackLogHeadRuler(x0, y0, sColorCurve));

            return gLogTrack;
        }

        //水平井显示模块差好多，需要调整
        public XmlElement gPathHorinzalTrackLog(string sJH, string sLogName, List<float> fListMD, List<float> fListValue,
         float m_KB, float fLeftValue, float fRightValue, string sColorCurve)
        {
            XmlElement gLogTrack = svgDoc.CreateElement("g");
            gLogTrack.SetAttribute("id", sJH + "#" + sLogName);
            gLogTrack.SetAttribute("stroke", sColorCurve);
            gLogTrack.SetAttribute("stroke-width", "0.5");
            if (sLogName == null || fListMD.Count == 0) return gLogTrack;
            string _points = "";

            List<ItemDicWellPath> listWellPath = cIOinputWellPath.getWellPathItemListByJHAndMDList(sJH, fListMD);
            List<ItemDicWellPath> listWellPathHorzion = new List<ItemDicWellPath>();
            List<float> fListMDHorizina = new List<float>();
            List<float> fListValueHorizina = new List<float>();
            double x0 = listWellPath[0].f_dx;
            double y0 = -m_KB + listWellPath[0].f_TVD;
            for (int i = 0; i < fListMD.Count; i++)
            {
                ItemDicWellPath currentWellPath = listWellPath[i];
                double currentX = currentWellPath.f_dx;
                double currentY = -m_KB + currentWellPath.f_TVD;
                if (currentWellPath.f_incl <= 70)
                {
                    float xViewTrack = 0.0f;
                    if (-500 <= fListValue[i] && fListValue[i] < 1000)
                    {
                        xViewTrack = this.iTrackWidth * (fListValue[i] - fLeftValue) / (fRightValue - fLeftValue);
                        _points = _points + (currentX + xViewTrack).ToString() + ',' + currentY.ToString() + " ";
                    }
                }
                else if (currentWellPath.f_incl >= 85 && i % 3 == 0)
                {
                    listWellPathHorzion.Add(currentWellPath);
                    fListMDHorizina.Add(fListMD[i]);
                    fListValueHorizina.Add(fListValue[i]);
                }

            }
            XmlElement gLogPolygon = svgDoc.CreateElement("polyline");
            // gLogPolygon.SetAttribute("style", "stroke-width:1");
            //   gLogPolygon.SetAttribute("stroke", sColorCurve);
            gLogPolygon.SetAttribute("fill", "none");
            gLogPolygon.SetAttribute("points", _points);
            gLogTrack.AppendChild(gLogPolygon);

            string _pointsHorizon = "";
            for (int i = 0; i < listWellPathHorzion.Count; i++)
            {
                ItemDicWellPath currentWellPath = listWellPathHorzion[i];
                double currentDX = currentWellPath.f_dx;
                double currentY = -m_KB + currentWellPath.f_TVD;

                float _yView_f = 0.0f;
                if (-500 <= fListValueHorizina[i] && fListValueHorizina[i] < 1000)
                {
                    _yView_f = this.iTrackWidth * (fListValueHorizina[i] - fLeftValue) / (fRightValue - fLeftValue);
                    _pointsHorizon = _pointsHorizon + currentDX.ToString() + ',' + (currentY - _yView_f).ToString() + " ";
                }
            }
            XmlElement gLogPolygonHorizinal = svgDoc.CreateElement("polyline");
            // gLogPolygon.SetAttribute("style", "stroke-width:1");
            //   gLogPolygon.SetAttribute("stroke", sColorCurve);
            gLogPolygonHorizinal.SetAttribute("fill", "none");
            gLogPolygonHorizinal.SetAttribute("points", _pointsHorizon);
            gLogTrack.AppendChild(gLogPolygonHorizinal);

            gLogTrack.AppendChild(gTrackLogHeadText(x0, y0, sLogName, sColorCurve));
            gLogTrack.AppendChild(gTrackLogHeadRuler(x0, y0, sColorCurve));

            return gLogTrack;
        }
        XmlElement gTrackLogHeadText(double x0, double y0, string sLogName, string sColor)
        {
            //添加道头名，X位置取道宽一半偏左，Y位置去深度最小值对应的海拔更低一些##添加道头名，X位置取道宽一半偏左，Y位置去深度最小值对应的海拔更低一些
            XmlElement logNameText = svgDoc.CreateElement("text");
            logNameText.SetAttribute("x", (x0 + (this.iTrackWidth - 8) * 0.5).ToString());
            logNameText.SetAttribute("y", (y0 - 5).ToString());
            logNameText.SetAttribute("font-size", "6");
            logNameText.SetAttribute("fill", sColor);
            logNameText.InnerText = sLogName;
            return logNameText;
        }

        XmlElement gTrackLogHeadRuler(double x0, double y0, string sColor)
        {
            XmlElement curveHeadInfor = svgDoc.CreateElement("path");
            string sPath = "m " + x0 + " " + (y0 - 2).ToString() + " v2 h " + this.iTrackWidth.ToString() + " v-2";
            curveHeadInfor.SetAttribute("d", sPath);
            curveHeadInfor.SetAttribute("fill", "none");
            return curveHeadInfor;
        }

        XmlElement gTrackLogCurve(double x0, double y0, List<float> fListTVD, List<float> fListValue, double fLeftValue, double fRightValue, string sColor)
        {
            string _points = "";
            for (int i = 0; i < fListTVD.Count; i++)
            {
                double currentX = x0;
                double currentY = y0 + fListTVD[i] - fListTVD[0];
                if (fLeftValue <= fListValue[i] && fListValue[i] <= fRightValue)
                {
                    currentX = x0 + this.iTrackWidth * (fListValue[i] - fLeftValue) / (fRightValue - fLeftValue);
                    _points = _points + currentX.ToString() + ',' + currentY.ToString() + " ";
                }
            }
            XmlElement gLogPolygon = svgDoc.CreateElement("polyline");
            gLogPolygon.SetAttribute("style", "stroke-width:1");
            gLogPolygon.SetAttribute("stroke", sColor);
            gLogPolygon.SetAttribute("fill", "none");
            gLogPolygon.SetAttribute("points", _points);
            return gLogPolygon;
        }
       
        public static XmlElement gTrackTVDLog(ItemWell curWell, XmlDocument svgDoc, itemLogHeadInforDraw item, int iTrackwidth, List<double> fListDepthInput, List<double> fListValue, double fVScale)
        {
            List<double> fListDepthTVD = new List<double>();
            for (int i = 0; i < fListDepthInput.Count; i++) 
            {
              fListDepthTVD.Add(cIOinputWellPath.getTVDByJHAndMD(curWell,(float)fListDepthInput[i]));
            }
            return gTrackLog(svgDoc, item, iTrackwidth, fListDepthTVD, fListValue, fVScale);
        }

        public static double getXview(double fValue, double fLeftValue, double fRightValue, double iTrackwidth)
       {
           double xView_f = iTrackwidth * (fValue - fLeftValue) / (fRightValue - fLeftValue);
           if (xView_f < 0) xView_f = 0;
           else if (xView_f > iTrackwidth) xView_f = iTrackwidth;
           return xView_f; 
       }

        public static XmlElement gTrackLog(XmlDocument svgDoc, itemLogHeadInforDraw item, int iTrackwidth, List<double> fListDepthInput, List<double> fListValue, double fVScale)
        {
            trackDataListLog trackDataView = new trackDataListLog(); //保存每条曲线绘制的ViewPoint 为了绘制填充使用。
            trackDataView.itemHeadInforDraw = item;

            string sLogName = item.sLogName;
            double fLeftValue = item.fLeftValue;
            double fRightValue = item.fRightValue;
            string m_sColorCurve = item.sLogColor;
            string sFill = item.sFill;
            float iLinewidth = item.fLineWidth;
            int iLineType = item.iLineType;
            int iNumSpare = 2;
            if (item.iSparceNum > 0) iNumSpare = item.iSparceNum; 
            double xViewTrack = 0f;
            //对大小支进行值域质量控制
            double qcMinValue = Math.Min(fLeftValue, fRightValue);
            double qcMaxValue = Math.Max(fLeftValue, fRightValue);

            if (qcMinValue <= 0) qcMinValue *= 2;
            else qcMinValue *= 0.5;

            if (qcMaxValue <= 0) qcMaxValue *= 0.5;
            else qcMaxValue *= 2 ;

            string _points = "";
            //曲线可能反转，所以一定要加值
            XmlElement gLog = svgDoc.CreateElement("g");
            if (fListDepthInput.Count > 0)
            {
                #region logCurve
                if (item.typeMode == TypeTrack.曲线.ToString())
                {
                    xViewTrack = getXview(qcMinValue, fLeftValue, fRightValue, iTrackwidth);
                    _points += (xViewTrack).ToString("0.0") + ',' + (fListDepthInput[0] * fVScale).ToString("0.0") + " ";
                 
                    if (item.iIsLog == 0) //非对数
                    {
                       
                        for (int i = 0; i < fListDepthInput.Count; i =i+iNumSpare)
                        {
                            double fDepthView = fListDepthInput[i] * fVScale;
                            double fValue = fListValue[i];
                            if (qcMinValue <= fValue && fValue <= qcMaxValue)
                            {
                                xViewTrack = getXview(fValue, fLeftValue, fRightValue, iTrackwidth);
                                _points += (xViewTrack).ToString("0.0") + ',' + fDepthView.ToString("0.0") + " ";
                                trackDataView.fListMD.Add(fDepthView);
                                trackDataView.fListValue.Add(xViewTrack);
                            }
                        }
                       
                    }
                    else
                    {
                        for (int i = 0; i < fListDepthInput.Count; i = i + iNumSpare)
                        {
                            double fDepthView = fListDepthInput[i] * fVScale;
                            double fValue = fListValue[i];
                            //if (i == 0 || i == (fListDepthInput.Count - 1)) fValue = fLeftValue;
                            if (fLeftValue <= fValue && fLeftValue > 0)
                            {
                                xViewTrack = iTrackwidth * (Math.Log10(fValue / fLeftValue)) / item.iLogGridGrade;
                                if (xViewTrack < 0) xViewTrack = 0;
                                else if (xViewTrack > iTrackwidth) xViewTrack = iTrackwidth;
                                _points = _points + (xViewTrack).ToString("0.0") + ',' + fDepthView.ToString("0.0") + " ";
                                trackDataView.fListMD.Add(fDepthView);
                                trackDataView.fListValue.Add(xViewTrack);
                            }
                        }
                    }
                    xViewTrack = getXview(qcMinValue, fLeftValue, fRightValue, iTrackwidth);
                    _points += (xViewTrack).ToString("0.0") + ',' + (fListDepthInput.Last() * fVScale).ToString("0.0") + " ";

                    trackDataView.fListMD.Insert(0,fListDepthInput[0] * fVScale);
                    trackDataView.fListValue.Insert(0,xViewTrack);
                    trackDataView.fListMD.Add(fListDepthInput.Last() * fVScale);
                    trackDataView.fListValue.Add(xViewTrack);
                    XmlElement gLogPolygon = svgDoc.CreateElement("polygon");
                    gLogPolygon.SetAttribute("id", item.sIDLog);
                    gLogPolygon.SetAttribute("onclick", "getID(evt)");
                    gLogPolygon.SetAttribute("stroke-width", iLinewidth.ToString());
                    gLogPolygon.SetAttribute("stroke", m_sColorCurve);
                    gLogPolygon.SetAttribute("stroke-dasharray", codeReplace.codeReplaceStrokeDashInt2Str(iLineType));
                    gLogPolygon.SetAttribute("fill", sFill);
                    gLogPolygon.SetAttribute("points", _points);
                    cSVGSectionTrackLogCurveFill.listLogViewData4fill.Add(trackDataView);
                    gLog.AppendChild(gLogPolygon);
                }
                #endregion
                #region scatterPoint
                if (item.typeMode == TypeTrack.散点.ToString())
                {
                    for (int i = 0; i < fListDepthInput.Count; i++)
                    {
                        double fDepth = fListDepthInput[i] * fVScale;
                        double fValue = fListValue[i];
                        if (item.iIsLog == 0)
                        {
                            if (qcMinValue <= fValue && fValue <= qcMaxValue)
                            {
                                xViewTrack = iTrackwidth * (fValue - fLeftValue) / (fRightValue - fLeftValue);
                                if (xViewTrack < 0) xViewTrack = 0;
                                else if (xViewTrack > iTrackwidth) xViewTrack = iTrackwidth;
                            }
                        }
                        else if (fLeftValue <= fValue && fLeftValue > 0)
                        {
                            xViewTrack = iTrackwidth * (Math.Log10(fValue / fLeftValue)) / item.iLogGridGrade;
                            if (xViewTrack < 0) xViewTrack = 0;
                            else if (xViewTrack > iTrackwidth) xViewTrack = iTrackwidth;
                        }

                        XmlElement eCircle = svgDoc.CreateElement("circle");
                        eCircle.SetAttribute("cx", xViewTrack.ToString());
                        eCircle.SetAttribute("cy", fDepth.ToString());
                        eCircle.SetAttribute("r", "3");
                        eCircle.SetAttribute("fill", m_sColorCurve);
                        gLog.AppendChild(eCircle);
                    }

                }
                #endregion
                #region 杆状
                if (item.typeMode == TypeTrack.杆状.ToString())
                {
                    for (int i = 0; i < fListDepthInput.Count; i++)
                    {
                        double fDepth = fListDepthInput[i] * fVScale;
                        double fValue = fListValue[i];
                        if (item.iIsLog == 0)
                        {
                            if (qcMinValue <= fValue && fValue <= qcMaxValue)
                            {
                                xViewTrack = iTrackwidth * (fValue - fLeftValue) / (fRightValue - fLeftValue);
                                if (xViewTrack < 0) xViewTrack = 0;
                                else if (xViewTrack > iTrackwidth) xViewTrack = iTrackwidth;

                            }
                        }
                        else if (fLeftValue <= fValue && fLeftValue > 0)
                        {
                            xViewTrack = iTrackwidth * (Math.Log10(fValue / fLeftValue)) / item.iLogGridGrade;
                            if (xViewTrack < 0) xViewTrack = 0;
                            else if (xViewTrack > iTrackwidth) xViewTrack = iTrackwidth;
                        }

                        string d = "M0 " + fDepth.ToString() + " h" + xViewTrack;
                        XmlElement gLogPath = svgDoc.CreateElement("path");
                        gLogPath.SetAttribute("stroke-widt", iLinewidth.ToString());
                        gLogPath.SetAttribute("stroke", m_sColorCurve);
                        gLogPath.SetAttribute("fill", "none");
                        gLogPath.SetAttribute("d", d);
                        gLog.AppendChild(gLogPath);
                        XmlElement eCircle = svgDoc.CreateElement("circle");
                        eCircle.SetAttribute("cx", xViewTrack.ToString());
                        eCircle.SetAttribute("cy", fDepth.ToString());
                        eCircle.SetAttribute("r", "2");
                        eCircle.SetAttribute("fill", "red");
                        gLog.AppendChild(eCircle);
                    }
                }
                #endregion
            }
            return gLog;
        }

        public static int setCountSpare(double fVScale)
        {
            if (cProjectData.projectUnit == typeUnit.Field.ToString()) return 1;
            else
            {
                int iCountSparse = 4;
                if (fVScale >= 15) iCountSparse = 1;
                if (fVScale >= 10) iCountSparse = 2;
                else if (fVScale >= 3.7) iCountSparse = 3;
                return iCountSparse;
            }
        }

        //按深度段从sectionWell 里得到值
         public static trackDataListLog getLogSeriersFromSectionWell(string sData, string sLogName, double dfTop, double dfBot)
        {
            trackDataListLog sttTrackLogDataList = new trackDataListLog();
            sttTrackLogDataList.itemHeadInforDraw.sLogName = sLogName;
            string[] split = sData.Trim().Split(new string[] { cProjectData.splitMark }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < split.Length; i=i+2)
            {
                float top;
                double value;
                if (float.TryParse(split[i], out top)&& double.TryParse(split[i+1], out value))
                {
                    if (dfTop <= top && top <= dfBot)
                    {
                        sttTrackLogDataList.fListMD.Add(top);
                        sttTrackLogDataList.fListValue.Add(value);
                    } 
                    
                }
            }
            return sttTrackLogDataList;
        }

         public static trackDataListLog getLogSeriersFromLogFile(string sJH, string sLogName)
         {
             return getLogSeriersFromLogFile(sJH, sLogName, 0, 999999); 
         }
        //根据fVScale抽析
        public static trackDataListLog getLogSeriersFromLogFile(string sJH,string sLogName, double dfTop, double dfBot)
         {
             trackDataListLog sttTrackLogDataList = new trackDataListLog();
             sttTrackLogDataList.itemHeadInforDraw.sJH = sJH;
             sttTrackLogDataList.itemHeadInforDraw.sLogName = sLogName;
             string logFilePath = Path.Combine(cProjectManager.dirPathWellDir, sJH, sLogName + cProjectManager.fileExtensionWellLog);
             if (File.Exists(logFilePath))
             {
                 using (StreamReader sr = new StreamReader(logFilePath, System.Text.Encoding.UTF8))
                 {
                     String line;
                     int _indexLine = 0;
                     int _dataStartLine = 3;
                     while ((line = sr.ReadLine()) != null) //delete the line whose legth is 0
                     {
                         _indexLine++;
                         string[] split = line.Trim().Split(new char[] { ' ', '\t', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
                         if (_indexLine == 1) continue; //first comment line
                         else if (_indexLine == 2) _dataStartLine = int.Parse(split[0]);  //second line is number of column,
                         else if (_indexLine <= (2 + _dataStartLine))
                         {
                             //this ection is Column
                         }
                         else
                         {
                             float top;
                             double value;
                             if (split.Length==2 && float.TryParse(split[0], out top) && double.TryParse(split[1], out value))
                             {
                                 if (dfTop <= top && top <= dfBot)
                                 {
                                     sttTrackLogDataList.fListMD.Add(top);
                                     sttTrackLogDataList.fListValue.Add(value);
                                 }
                             }
                         }
                     }
                 }
             }

             if (sttTrackLogDataList.fListMD.Count > 2) 
             {
                 if (sttTrackLogDataList.fListMD[2] < sttTrackLogDataList.fListMD[0])
                 {
                     sttTrackLogDataList.fListMD.Reverse();
                     sttTrackLogDataList.fListValue.Reverse();
                 }
             }

             return sttTrackLogDataList;
         }

        //根据fVScale抽析
        public static trackDataListLog getLogSeriersFromSectionWell(string sData, string sLogName, double dfTop, double dfBot, double fVScale)
        {
            int iCountSparse = setCountSpare(fVScale);
            trackDataListLog sttTrackLogDataList = new trackDataListLog();
            sttTrackLogDataList.itemHeadInforDraw.sLogName = sLogName;
            string[] split = sData.Trim().Split(new string[] { cProjectData.splitMark }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < split.Length; i = i + iCountSparse * 2)
            {
                float top;
                double value;
                if (float.TryParse(split[i], out top)&&double.TryParse(split[i + 1], out value))
                {
                    if (dfTop <= top && top <= dfBot)
                    {
                        sttTrackLogDataList.fListMD.Add(top);
                        sttTrackLogDataList.fListValue.Add(value);
                    } 
                }
            }
            return sttTrackLogDataList;
        }
        
        public static XmlElement gTrackLogPoint(XmlDocument svgDoc, itemLogHeadInforDraw item, int iTrackwidth, List<double> fListDepthInput, List<double> fListValue, double fVScale)
        {
            string sLogName = item.sLogName;
            double fLeftValue = item.fLeftValue;
            double fRightValue = item.fRightValue;
            string m_sColorCurve = item.sLogColor;
            string sFill = item.sFill;
            float iLinewidth = item.fLineWidth;
            int iLineType = item.iLineType;

            double xViewTrack = 0f;
            //对大小支进行值域质量控制
            double qcMinValue = Math.Min(fLeftValue, fRightValue) - 100;
            double qcMaxValue = Math.Max(fLeftValue, fRightValue) + 100;

            //曲线可能反转，所以一定要加值
            XmlElement gLog = svgDoc.CreateElement("g");
            gLog.SetAttribute("id", item.sIDLog);
            gLog.SetAttribute("onclick", "getID(evt)");
            gLog.SetAttribute("stroke-width", iLinewidth.ToString());
            gLog.SetAttribute("stroke", m_sColorCurve);
            gLog.SetAttribute("fill", sFill);
            if (fListDepthInput.Count > 0)
            {
                for (int i = 0; i < fListDepthInput.Count; i++)
                {
                    double fDepth = fListDepthInput[i] * fVScale;
                    double fValue = fListValue[i];
                    if (i == 0 || (i == fListDepthInput.Count - 1)) fValue = Math.Min(fLeftValue, fRightValue);
                    if (qcMinValue <= fValue && fValue <= qcMaxValue)
                    {
                        xViewTrack = iTrackwidth * (fValue - fLeftValue) / (fRightValue - fLeftValue);
                        if (xViewTrack < 0) xViewTrack = 0;
                        else if (xViewTrack > iTrackwidth) xViewTrack = iTrackwidth;
                        XmlElement eCircle = svgDoc.CreateElement("circle");
                        eCircle.SetAttribute("cx", xViewTrack.ToString());
                        eCircle.SetAttribute("cy", fDepth.ToString());
                        eCircle.SetAttribute("r", "2");
                        eCircle.SetAttribute("fill", m_sColorCurve);
                        gLog.AppendChild(eCircle);
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            return gLog;
        }
    }
}
