using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using DOGPlatform.XML;
using DOGPlatform.SVG;
using System.Drawing;
using System.IO;

namespace DOGPlatform
{
    class makeSectionFence:makeSectionGeo 
    {
        public static string generateFence(string dirSectionData, string pathSectionCss, string filenameSVGMap)
        {
            //定义页面大小 及 纵向平移
            List<ItemWellSection> listWellsSection = cXmlDocSectionGeo.makeListWellSection(pathSectionCss);

            //读取page设置全局类
            cXEGeopage curPage = new cXEGeopage(pathSectionCss);

            cSVGDocSection svgSection = new cSVGDocSection(curPage.PageWidth, curPage.PageHeight, 0, 0, curPage.sUnit);

            //定义返回的xmlElement变量，作为调用各种加入的道的返回值
            XmlElement returnElemment;
            //在listWellSection中循环，一口一口井的加入剖面
            for (int i = 0; i < listWellsSection.Count; i++)
            {
                string sJH = listWellsSection[i].sJH;
                string filePathTemplatOper = Path.Combine(dirSectionData, sJH + ".xml");
                //斜井模式
                cSVGSectionWell currentWell = makePathWell(svgSection, pathSectionCss, filePathTemplatOper,
                listWellsSection[i].fShowedDepthTop, listWellsSection[i].fShowedDepthBase, curPage.fVscale, curPage);

                svgSection.addgElement2BaseLayer(currentWell.gWell, listWellsSection[i].fXview, -listWellsSection[i].fShowedDepthTop*curPage.fVscale);
                //加个井位标识
                returnElemment = cSVGSectionWell.gWellHead(svgSection.svgDoc,sJH, listWellsSection[i].fXview, listWellsSection[i].fYview, 18);
                svgSection.addgElement2BaseLayer(returnElemment, 0, 0);
            }

            string fileSVG = Path.Combine(cProjectManager.dirPathTemp, filenameSVGMap);
            svgSection.makeSVGfile(fileSVG);
            return fileSVG;
        }

        
        //导出带深度范围内的图形图像，这个作为画连井的基础。
        public static cSVGSectionWell makeSectionWellBodyByDepth(cSVGDocSection svgSection, string pathSectionCss, string filePathTemplatOper,float fVScale)
        {
            List<int> iListTrackWidth = new List<int>();
            //从配置文件读取显示深度
            cSVGSectionWell curWell = new cSVGSectionWell(svgSection.svgDoc);
            string sJH = cXmlBase.getNodeInnerText(filePathTemplatOper, cXmlDocSectionWell.fullPathJH);
            string sMapTitle = cXmlBase.getNodeInnerText(filePathTemplatOper, cXEWellPage.fullPathMapTitle);
            //图幅全部用px基本单位，fVScale已经包含了 px-> 到应用单位的转换。
            double dfDS1Show = double.Parse(cXmlBase.getNodeInnerText(filePathTemplatOper, cXEWellPage.fullPathTopDepth));
            double dfDS2Show = double.Parse(cXmlBase.getNodeInnerText(filePathTemplatOper, cXEWellPage.fullPathBotDepth));
            double iDy = -dfDS1Show;

            //这种是上移式图头绘制模式 与 遮盖式图头绘制模式严格位置不同
            int iHeightTrackHead = int.Parse(cXmlBase.getNodeInnerText(filePathTemplatOper, cXEWellPage.fullPathTrackRectHeight));
            double iYpositionTrackHead = dfDS1Show  - iHeightTrackHead;
            int iHeightMapTitle = int.Parse(cXmlBase.getNodeInnerText(filePathTemplatOper, cXEWellPage.fullPathMapTitleRectHeight));
            double iYpositionTitle = iYpositionTrackHead - iHeightMapTitle;
            int iShowMode = int.Parse(cXmlBase.getNodeInnerText(filePathTemplatOper, cXEWellPage.fullPathShowMode));
            //以上代码执行2毫秒，不必优化了

            iListTrackWidth.Clear();
            XmlElement returnElemment;
            foreach (XmlElement el_Track in cXmlDocSectionWell.getTrackNodes(filePathTemplatOper))
            {
                trackDataDraw curTrackDraw = new trackDataDraw(el_Track);
                if (curTrackDraw.iVisible > 0) //判断是否可见，可见才绘制
                {
                    #region 深度道
                    if (curTrackDraw.sTrackType == TypeTrack.深度尺.ToString())
                    {
                        int mainTick = int.Parse(el_Track["mainScale"].InnerText);
                        int minTick = int.Parse(el_Track["minScale"].InnerText);
                        int tickFontSize = int.Parse(el_Track["fontSize"].InnerText);
                        returnElemment = cSVGSectionTrackWellRuler.gMDRuler(svgSection.svgDoc, svgSection.svgDefs, svgSection.svgCss, Convert.ToInt16(dfDS1Show), Convert.ToInt16(dfDS2Show), mainTick, minTick, fVScale, tickFontSize);
                        curWell.addTrack(returnElemment, iListTrackWidth.Sum());
                    }
                    # endregion
                    #region 地层道
                    if (curTrackDraw.sTrackType == TypeTrack.分层.ToString())
                    {
                        XmlNode dataList = el_Track.SelectSingleNode("dataList");
                        if (dataList != null)
                        {
                            XmlNodeList dataItem = dataList.SelectNodes("dataItem");
                            foreach (XmlNode xn in dataItem)
                            {
                                itemDrawDataIntervalValue itemLayer = new itemDrawDataIntervalValue(xn);
                                if (itemLayer.top >= dfDS1Show && itemLayer.bot <= dfDS2Show)
                                {
                                    returnElemment = cSVGSectionTrackLayer.gTrackItemLayer(svgSection.svgDoc, itemLayer, fVScale, curTrackDraw.iTrackFontSize, curTrackDraw.iTrackWidth);
                                    curWell.addTrack(returnElemment, iListTrackWidth.Sum());
                                }
                            }
                        }
                    }
                    #endregion
                    #region 测井解释，岩性，旋回
                    if (cProjectManager.ltStrTrackTypeIntervalProperty.IndexOf(curTrackDraw.sTrackType) >= 0)
                    {
                        XmlNode dataList = el_Track.SelectSingleNode("dataList");
                        if (dataList != null)
                        {
                            XmlNodeList dataItem = dataList.SelectNodes("dataItem");
                            foreach (XmlNode xn in dataItem)
                            {
                                ItemTrackDrawDataIntervalProperty item = new ItemTrackDrawDataIntervalProperty(xn);
                                if (item.top >= dfDS1Show && item.bot <= dfDS2Show)
                                {
                                    returnElemment = cSVGSectionTrackJSJL.gTrackItemJSJL(svgSection.svgDoc, svgSection.svgDefs, item, fVScale, curTrackDraw.iTrackWidth);
                                    if (curTrackDraw.sTrackType == TypeTrack.沉积旋回.ToString()) returnElemment = cSVGSectionTrackCycle.gTrackGeoCycle(svgSection.svgDoc, svgSection.svgDefs, item, fVScale, curTrackDraw.iTrackWidth);
                                    curWell.addTrack(returnElemment, iListTrackWidth.Sum());
                                } 
                            }
                        }
                    }
                    #endregion
                    #region 曲线道
                    List<itemLogHeadInforDraw> ltItemLogHeadInforDraw = new List<itemLogHeadInforDraw>(); //记录绘制道头用，节省重新读取的时间
                    if (curTrackDraw.sTrackType == TypeTrack.曲线道.ToString())
                    {
                        cSVGSectionTrackLogCurveFill.listLogViewData4fill.Clear();
                        XmlNodeList xnList = el_Track.SelectNodes(".//Log");
                        int iLogNum = 0;
                        foreach (XmlElement xnLog in xnList)
                        {
                            iLogNum++;
                            itemLogHeadInforDraw curLogHead = new itemLogHeadInforDraw(xnLog);
                            ltItemLogHeadInforDraw.Add(curLogHead);
                            if (curLogHead.iIsLog > 0)
                            {
                                if (curLogHead.fLeftValue <= 0)
                                {
                                    curLogHead.fLeftValue = 1;
                                    cXmlBase.setSelectedNodeChildNodeValue(filePathTemplatOper, "", "leftValue", "1");
                                }
                                curLogHead.iLogGridGrade = cSVGSectionTrackLog.getNumGridGroupInLog(curLogHead.fLeftValue, curLogHead.fRightValue);
                            }
                            if (curLogHead.iLogCurveVisible > 0)
                            {
                                XmlNode nodeData = xnLog.SelectSingleNode("sData");

                                if (nodeData != null)
                                {
                                    string sData = nodeData.InnerText;
                                    trackDataListLog dlTrackDataListLog = cSVGSectionTrackLog.getLogSeriersFromSectionWell(sData, curLogHead.sLogName, dfDS1Show, dfDS2Show, fVScale);
                                    returnElemment = cSVGSectionTrackLog.gTrackLog(svgSection.svgDoc, curLogHead, curTrackDraw.iTrackWidth, dlTrackDataListLog.fListMD, dlTrackDataListLog.fListValue, fVScale);
                                    curWell.addTrack(returnElemment, iListTrackWidth.Sum());
                                }
                            }//结束曲线循环
                            //绘制填充
                            XmlNodeList xnFillList = el_Track.SelectNodes(".//FillItem");
                            foreach (XmlElement xn in xnFillList)
                            {
                                itemDrawDataTrackFill itemFill = new itemDrawDataTrackFill(xn);
                                trackDataListLog main =cSVGSectionTrackLogCurveFill.listLogViewData4fill.SingleOrDefault(p => p.itemHeadInforDraw.sIDLog == itemFill.sIDmainLog);
                                if (main != null && itemFill.iFillMode == 0)
                                {
                                    string sIDSub = xn["idLogSub"].InnerText;
                                    trackDataListLog sub = cSVGSectionTrackLogCurveFill.listLogViewData4fill.SingleOrDefault(p => p.itemHeadInforDraw.sIDLog == sIDSub);
                                    if (sub != null)
                                    {
                                        returnElemment = cSVGSectionTrackLogCurveFill.gLogCurveFillByLog(svgSection.svgDoc, main, sub, itemFill, fVScale);
                                       curWell.addTrack(returnElemment, iListTrackWidth.Sum());
                                    }
                                }

                                if (main != null && itemFill.iFillMode == 1)
                                {
                                    double fValueCutOff = itemFill.fValueCutoff;
                                    float fLeftValue = main.itemHeadInforDraw.fLeftValue;
                                    double xViewCutOff = curTrackDraw.iTrackWidth * (fValueCutOff - fLeftValue) / (main.itemHeadInforDraw.fRightValue - fLeftValue);
                                    if (main.itemHeadInforDraw.iIsLog == 1) xViewCutOff = curTrackDraw.iTrackWidth * (Math.Log10(fValueCutOff / fLeftValue)) / main.itemHeadInforDraw.iLogGridGrade;
                                    returnElemment = cSVGSectionTrackLogCurveFill.gLogCurveFillByCutOff(svgSection.svgDoc, itemFill.sID, main, xViewCutOff, itemFill, fVScale);
                                   curWell.addTrack(returnElemment, iListTrackWidth.Sum());
                                }

                            }

                        }
                    #endregion 结束曲线道
                    } //if 是否可见

                    #region 增加图道道头及测井曲线头,道头ID 对应节点 后画道头是因为要覆盖。测井头最后画 是因为要放在最上面不被遮盖
                    returnElemment = cSVGSectionTrack.trackHead(svgSection.svgDoc, curTrackDraw.sTrackID, curTrackDraw.sTrackTitle, iYpositionTrackHead, iHeightTrackHead, curTrackDraw.iTrackWidth, curTrackDraw.iTrackHeadFontSize, curTrackDraw.sWriteMode);
                    curWell.addTrack(returnElemment, iListTrackWidth.Sum());
                    #endregion
                  
                    #region 绘制测井图头,测井图信息很重要，图形加载数据要捕捉测井头的ID
                  if (curTrackDraw.sTrackType == TypeTrack.曲线道.ToString())
                    {
                        int iLogNum = 0;
                        foreach (itemLogHeadInforDraw curLogHead in ltItemLogHeadInforDraw)
                        {
                            iLogNum++;
                            if (curLogHead.iIsLog > 0)
                            {
                                if (curLogHead.fLeftValue <= 0) curLogHead.fLeftValue = 1;
                                curLogHead.iLogGridGrade = cSVGSectionTrackLog.getNumGridGroupInLog(curLogHead.fLeftValue, curLogHead.fRightValue);
                            }
                            if (curLogHead.iLogCurveVisible > 0)
                            {
                                //增加测井头
                                int iUpLine = 15; //不同测井曲线间隔距离
                                int iFirstLogheadLinePosition = 3;  //首条logheadLine线距离下边框的距离
                                returnElemment = cSVGSectionTrack.addTrackItemLogHeadInfor(svgSection.svgDoc, curLogHead, iYpositionTrackHead + iHeightTrackHead - iUpLine * (iLogNum - 1) - iFirstLogheadLinePosition, curTrackDraw.iTrackWidth,14);
                              curWell.addTrack(returnElemment, iListTrackWidth.Sum());
                            }
                        }
                    }
                    #endregion

                    # region 绘制道框
                    if (iShowMode == 1)
                    {
                        returnElemment = cSVGSectionTrack.trackRect(svgSection.svgDoc, curTrackDraw.sTrackID, dfDS1Show, dfDS2Show, fVScale, curTrackDraw.iTrackWidth);
                       curWell.addTrack(returnElemment, iListTrackWidth.Sum());
                    }
                    #endregion

                    iListTrackWidth.Add(curTrackDraw.iTrackWidth);
                }
            }//结束图道循环绘制

            //增加图头圆点
            returnElemment = curWell.gWellHead(sJH, Convert.ToInt16(dfDS1Show) - iHeightTrackHead - iHeightMapTitle, Convert.ToInt16(dfDS1Show) - iHeightTrackHead, iHeightMapTitle, iListTrackWidth.Sum(), 18);
            curWell.addTrack(returnElemment, 0);
            return curWell;
        }

        public static cSVGSectionWell makeWellsimple(cSVGDocSection svgSection, string pathSectionCss, string filePathTemplatOper, int _iShowMode)
        {
            cSVGSectionWell curWell = new cSVGSectionWell(svgSection.svgDoc);
            List<int> iListTrackWidth = new List<int>();
            //从配置文件读取显示深度
            string sJH = cXmlBase.getNodeInnerText(filePathTemplatOper, cXmlDocSectionWell.fullPathJH);

            double dfDS1Show = double.Parse(cXmlBase.getNodeInnerText(filePathTemplatOper, cXEWellPage.fullPathTopDepth));
            double dfDS2Show = double.Parse(cXmlBase.getNodeInnerText(filePathTemplatOper, cXEWellPage.fullPathBotDepth));
            float fVScale = float.Parse(cXmlBase.getNodeInnerText(filePathTemplatOper, cXEWellPage.fullPathVSacle));
            float fKB = float.Parse(cXmlBase.getNodeInnerText(filePathTemplatOper, cXmlDocSectionWell.fullPathKB));
            double iDy = - dfDS1Show;

            //这块需要加入提升距离代码,100为头遮照距离
            int iHeightMapTitle = 30;
            int iHeightTrackHead = 45; //暂时写固定
            int iShowMode = _iShowMode; //showmode不同 
            iListTrackWidth.Clear();
            XmlElement returnElemment;

            foreach (XmlElement el_Track in cXmlDocSectionWell.getTrackNodes(filePathTemplatOper))
            {
                trackDataDraw curTrackDraw = new trackDataDraw(el_Track);

                //增加道头
                returnElemment = cSVGSectionTrack.trackHead(svgSection.svgDoc, curTrackDraw.sTrackID, curTrackDraw.sTrackTitle, Convert.ToInt16(dfDS1Show) - iHeightTrackHead, iHeightTrackHead, curTrackDraw.iTrackWidth, curTrackDraw.iTrackHeadFontSize, curTrackDraw.sWriteMode);
                curWell.addTrack(returnElemment, iListTrackWidth.Sum());
                //增加距离位置节点
                cXmlDocSectionGeo.addWellTrackXviewNode(pathSectionCss, sJH, curTrackDraw.sTrackID, iListTrackWidth.Sum());
                if (curTrackDraw.iVisible > 0) //判断是否可见，可见才绘制
                {
                    if (el_Track["trackType"].InnerText == TypeTrack.深度尺.ToString())
                    {
                        int mainTick = int.Parse(el_Track["mainScale"].InnerText);
                        int minTick = int.Parse(el_Track["minScale"].InnerText);
                        returnElemment = cSVGSectionTrackWellRuler.gMDRuler(svgSection.svgDoc, svgSection.svgDefs, svgSection.svgCss, Convert.ToInt16(dfDS1Show), Convert.ToInt16(dfDS2Show), mainTick, minTick, 1, curTrackDraw.iTrackFontSize);
                        curWell.addTrack(returnElemment, iListTrackWidth.Sum());
                    }
                    #region 测井解释，岩性，旋回
                    if (cProjectManager.ltStrTrackTypeIntervalProperty.IndexOf(curTrackDraw.sTrackType) >= 0)
                    {
                        XmlNode dataList = el_Track.SelectSingleNode("dataList");
                        if (dataList != null)
                        {
                            XmlNodeList dataItem = dataList.SelectNodes("dataItem");
                            foreach (XmlNode xn in dataItem)
                            {
                                ItemTrackDrawDataIntervalProperty item = new ItemTrackDrawDataIntervalProperty(xn);
                                if (item.top >= dfDS1Show && item.bot <= dfDS2Show)
                                {
                                    returnElemment = cSVGSectionTrackJSJL.gTrackItemJSJL(svgSection.svgDoc, svgSection.svgDefs, item, fVScale, curTrackDraw.iTrackWidth);
                                    if (curTrackDraw.sTrackType == TypeTrack.沉积旋回.ToString()) returnElemment = cSVGSectionTrackCycle.gTrackGeoCycle(svgSection.svgDoc, svgSection.svgDefs, item, fVScale, curTrackDraw.iTrackWidth);
                                    curWell.addTrack(returnElemment, iListTrackWidth.Sum());
                                }
                            }
                        }
                    }
                    #endregion

                    iListTrackWidth.Add(curTrackDraw.iTrackWidth);
                }
            } //end of for add track
            //增加图头圆点
            returnElemment = curWell.gWellHead(sJH, Convert.ToInt16(dfDS1Show) - iHeightTrackHead - iHeightMapTitle, Convert.ToInt16(dfDS1Show) - iHeightTrackHead, iHeightMapTitle, iListTrackWidth.Sum(), 18);
            curWell.addTrack(returnElemment, 0);
            return curWell;
        }

    }
}
