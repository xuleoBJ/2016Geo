using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using DOGPlatform.XML;
using DOGPlatform.SVG;
using System.Diagnostics;
using System.Drawing;
using ClipperLib;

namespace DOGPlatform
{
    using Path = List<IntPoint>;
    using Paths = List<List<IntPoint>>;

    class makeSectionWell
    {
        public static List<trackDataListLog> ltTrackLog = new List<trackDataListLog>();
        public static void loadWellLogfile2List(string sJHinput, List<trackDataListLog> ltTrackLog)
        {
            ltTrackLog.Clear();
            string _wellDir = System.IO.Path.Combine(cProjectManager.dirPathWellDir, sJHinput);
            string[] wellLogItems = Directory.GetFiles(_wellDir, "*" + cProjectManager.fileExtensionWellLog);
            if (wellLogItems.Count() > 0)
            {
                foreach (string _item in wellLogItems)
                {
                    string sLogName = System.IO.Path.GetFileNameWithoutExtension(_item);
                    trackDataListLog dlTrackDataListLog = cSVGSectionTrackLog.getLogSeriersFromLogFile(sJHinput, sLogName, 0, 9999999);
                    ltTrackLog.Add(dlTrackDataListLog);
                }
            }
        }
        //查看是否有新增加的曲线
        public static void updateWellLogfile2List(string sJHinput, List<trackDataListLog> ltTrackLog)
        {
            ltTrackLog.Clear();
            string _wellDir = System.IO.Path.Combine(cProjectManager.dirPathWellDir, sJHinput);
            string[] wellLogItems = Directory.GetFiles(_wellDir, "*" + cProjectManager.fileExtensionWellLog);
            if (wellLogItems.Count() > 0)
            {
                foreach (string _item in wellLogItems)
                {
                    string sLogName = System.IO.Path.GetFileNameWithoutExtension(_item);
                    updateWellLogList(sJHinput, sLogName, ltTrackLog);
                }
            }
        }
        public static void deleteWellLogList(string sJHinput,string sLogName,  List<trackDataListLog> ltTrackLog)
        {
                  var itemToRemove = ltTrackLog.SingleOrDefault(r => r.itemHeadInforDraw.sJH == sJHinput && r.itemHeadInforDraw.sLogName == sLogName);
                    if (itemToRemove != null) ltTrackLog.Remove(itemToRemove);  
        }

        public static void updateWellLogList(string sJH, string sLogName, List<trackDataListLog> ltTrackLog)
        {
            //先在 lt 里面找，找不到再到系统文件找，加快速度
            bool bFind = false;
            foreach (trackDataListLog itemLog in ltTrackLog)
            {
                if (itemLog.itemHeadInforDraw.sLogName == sLogName && itemLog.itemHeadInforDraw.sJH == sJH)
                {
                    bFind = true;
                    break;
                }

            }
            if (bFind == false)
            {
                trackDataListLog dlTrackDataListLog = cSVGSectionTrackLog.getLogSeriersFromLogFile(sJH, sLogName, 0, 9999999);
                ltTrackLog.Add(dlTrackDataListLog);
            }
        }

        public static trackDataListLog getTrackDataListLog(string sJH, string sLogName, double dfTop, double dfBot, List<trackDataListLog> ltTrackLog)
        {
            trackDataListLog sttTrackLogDataList = new trackDataListLog();
            sttTrackLogDataList.itemHeadInforDraw.sLogName = sLogName;
            sttTrackLogDataList.itemHeadInforDraw.sJH = sJH;
            //先在 lt 里面找，找不到再到系统文件找，加快速度
            foreach (trackDataListLog itemLog in ltTrackLog)
            {
                if (itemLog.itemHeadInforDraw.sLogName == sLogName && itemLog.itemHeadInforDraw.sJH == sJH)
                {
                    for (int i = 0; i < itemLog.fListMD.Count; i++)
                    {
                        double top = itemLog.fListMD[i];
                        double value = itemLog.fListValue[i];
                        if (dfTop <= top && top <= dfBot)
                        {
                            sttTrackLogDataList.fListMD.Add(top);
                            sttTrackLogDataList.fListValue.Add(value);
                        }
                    }
                    break;
                }

            } //end foreach;
            return sttTrackLogDataList;
        }

        public static string makeSectionWellBody(string filePathTemplatOper, string fileName)
        {
            List<int> iListTrackWidth = new List<int>();
            //从配置文件读取显示深度
            XmlDocument curDoc = new XmlDocument();
            curDoc.Load(filePathTemplatOper);
            string sJH = cXmlBase.getNodeInnerText(curDoc, cXmlDocSectionWell.fullPathJH);
            ItemWell curWell =  cProjectData.ltProjectWell.SingleOrDefault(p => p.sJH == sJH);

            //记录所有的测井曲线，便于数据分析
            //当记录为0时，需要更新所有测井曲线
            if (ltTrackLog.Count == 0 || ltTrackLog[0].itemHeadInforDraw.sJH != sJH)
            {
                ltTrackLog.Clear();
                loadWellLogfile2List(sJH, ltTrackLog);
            }
            //当记录不为0时需要更新,在列表循环下，看看有没有新增加的曲线，注意修改测井曲线后 需要更新；
            else 
            {
                updateWellLogfile2List(sJH,ltTrackLog);
            }

            cXEWellPage curPage = new cXEWellPage(filePathTemplatOper);

            //图幅全部用px基本单位，fVScale已经包含了 px-> 到应用单位的转换。
            double iDx = 0;
            double iDy = -curPage.dfDS1Show;
            double iYpositionTitle = curPage.dfDS1Show;
            double iYpositionTrackHead = curPage.dfDS1Show + curPage.iHeightMapTitle;

            //以上代码执行2毫秒，不必优化了
            cSVGBaseSection cSingleWell = new cSVGBaseSection(curPage.PageWidth, curPage.PageHeight, iDx, iDy, "px"); //全部用px 单位转换用算法实现
            iListTrackWidth.Clear();
            XmlElement returnElemment;
            foreach (XmlElement el_Track in cXmlDocSectionWell.getTrackNodes(curDoc))
            {
                //初始化绘制道的基本信息
                trackDataDraw curTrackDraw = new trackDataDraw(el_Track);

                //定义一个新层 装道。 但是 也有问题，会有下面的遮盖问题。
                XmlElement gTrackLayer = cSingleWell.gLayerElement(curTrackDraw.sTrackTitle);
                cSingleWell.addgLayer(gTrackLayer, iDx, iDy);

                //先画曲线，再画道头和道框，这样好看
                if (curTrackDraw.iVisible > 0) //判断是否可见，可见才绘制
                {
                    #region 深度道
                    if (curTrackDraw.sTrackType == TypeTrack.深度尺.ToString())
                    {
                        itemDrawDataDepthRuler itemRuler = new itemDrawDataDepthRuler(el_Track);
                        returnElemment = cSVGSectionTrackWellRuler.gWellSecionRuler(curWell, cSingleWell, Convert.ToInt16(curPage.dfDS1Show), Convert.ToInt16(curPage.dfDS2Show), curPage.fVScale, itemRuler); ;
                        cSingleWell.addgElement2BaseLayer(returnElemment, iListTrackWidth.Sum());
                    }
                    # endregion
                    # region 文本道
                    if (curTrackDraw.sTrackType == TypeTrack.文本道.ToString())
                    {
                        int iAlignMode = 0;
                        if (el_Track["iAlignMode"] != null) iAlignMode = int.Parse(el_Track["iAlignMode"].InnerText);
                        XmlNode dataList = el_Track.SelectSingleNode("dataList");
                        if (dataList != null)
                        {
                            XmlNodeList dataItem = dataList.SelectNodes("dataItem");
                            foreach (XmlNode xn in dataItem)
                            {
                                ItemTrackDrawDataIntervalProperty item = new ItemTrackDrawDataIntervalProperty(xn);
                                if (item.top >= curPage.dfDS1Show && item.bot <= curPage.dfDS2Show)
                                {
                                    returnElemment = cSVGSectionTrackText.gTrackItemText(cSingleWell.svgDoc, item.sID, item.top, item.bot, curPage.fVScale, item.sText, curTrackDraw.iTrackFontSize, iAlignMode, curTrackDraw.iTrackWidth, item.sProperty, curTrackDraw.sWriteMode);
                                    cSingleWell.addgElement2Layer(gTrackLayer, returnElemment, iListTrackWidth.Sum());
                                }
                            }
                        }
                    }
                    #endregion
                    #region 工字道
                    if (curTrackDraw.sTrackType == TypeTrack.符号.ToString())
                    {
                        XmlNode dataList = el_Track.SelectSingleNode("dataList");
                        if (dataList != null)
                        {
                            XmlNodeList dataItem = dataList.SelectNodes("dataItem");
                            foreach (XmlNode xn in dataItem)
                            {
                                ItemTrackDrawDataIntervalProperty item = new ItemTrackDrawDataIntervalProperty(xn);
                                if (item.top >= curPage.dfDS1Show && item.bot <= curPage.dfDS2Show)
                                {
                                    returnElemment = cSVGSectionTrackSymbol.gTrackIntervalSymbol(cSingleWell.svgDoc, cSingleWell.svgDefs, item, curPage.fVScale, curTrackDraw.iTrackWidth);
                                    cSingleWell.addgElement2Layer(gTrackLayer, returnElemment, iListTrackWidth.Sum());
                                }
                            }
                        }
                    }
                    #endregion
                    #region 比例条
                    if (curTrackDraw.sTrackType == TypeTrack.比例条.ToString())
                    {
                        XmlNode dataList = el_Track.SelectSingleNode("dataList");
                        if (dataList != null)
                        {
                            XmlNodeList dataItem = dataList.SelectNodes("dataItem");
                            foreach (XmlNode xn in dataItem)
                            {
                                ItemTrackDrawDataIntervalProperty item = new ItemTrackDrawDataIntervalProperty(xn);
                                returnElemment = cSVGSectionTrackSymbol.gTrackRatioRect(cSingleWell.svgDoc, item.sID, item.top, item.bot, float.Parse(item.sText), curPage.fVScale, curTrackDraw.iTrackWidth, "blue");
                                cSingleWell.addgElement2Layer(gTrackLayer, returnElemment, iListTrackWidth.Sum());
                            }
                        }
                    }
                    #endregion
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
                                if (itemLayer.top >= curPage.dfDS1Show && itemLayer.bot <= curPage.dfDS2Show)
                                {
                                    returnElemment = cSVGSectionTrackLayer.gTrackItemLayer(cSingleWell.svgDoc, itemLayer, curPage.fVScale, curTrackDraw.iTrackFontSize, curTrackDraw.iTrackWidth);
                                    cSingleWell.addgElement2Layer(gTrackLayer, returnElemment, iListTrackWidth.Sum());
                                }
                            }
                        }
                    }
                    #endregion
                    #region 图片道
                    if (curTrackDraw.sTrackType == TypeTrack.图片道.ToString())
                    {
                        XmlNode dataList = el_Track.SelectSingleNode("dataList");
                        if (dataList != null)
                        {
                            XmlNodeList dataItem = dataList.SelectNodes("dataItem");
                            foreach (XmlNode xn in dataItem)
                            {
                                itemDrawDataIntervalValue item = new itemDrawDataIntervalValue(xn);
                                if (item.top >= curPage.dfDS1Show && item.bot <= curPage.dfDS2Show)
                                {
                                    returnElemment = cSVGSectionTrackImage.gTrackImage(cSingleWell.svgDoc, cSingleWell.svgDefs, sJH, item, curPage.fVScale, curTrackDraw.iTrackWidth);
                                    cSingleWell.addgElement2Layer(gTrackLayer, returnElemment, iListTrackWidth.Sum());
                                }
                            }
                        }
                    }
                    #endregion
                    #region 岩性
                    if (curTrackDraw.sTrackType == TypeTrack.岩性层段.ToString())
                    {
                        XmlNode dataList = el_Track.SelectSingleNode("dataList");
                        if (dataList != null)
                        {
                            XmlNodeList dataItem = dataList.SelectNodes("dataItem");
                            foreach (XmlNode xn in dataItem)
                            {
                                itemDrawDataIntervalValue item = new itemDrawDataIntervalValue(xn);
                                if (item.top >= curPage.dfDS1Show && item.bot <=curPage.dfDS2Show)
                                {
                                    returnElemment = cSVGSectionTrackLitho.gTrackLitho(cSingleWell.svgDoc, cSingleWell.svgDefs, item, curPage.fVScale, curTrackDraw.iTrackWidth);
                                    cSingleWell.addgElement2Layer(gTrackLayer, returnElemment, iListTrackWidth.Sum());
                                }
                            }
                        }
                    }
                    #endregion
                    #region 测井解释，旋回, 地质描述
                    if (cProjectManager.ltStrTrackTypeIntervalProperty.IndexOf(curTrackDraw.sTrackType) >= 0 )
                    {
                        XmlNode dataList = el_Track.SelectSingleNode("dataList");
                        if (dataList != null)
                        {
                            XmlNodeList dataItem = dataList.SelectNodes("dataItem");
                            foreach (XmlNode xn in dataItem)
                            {
                                ItemTrackDrawDataIntervalProperty item = new ItemTrackDrawDataIntervalProperty(xn);
                                if (item.top >= curPage.dfDS1Show && item.bot <= curPage.dfDS2Show)
                                {
                                    returnElemment = cSVGSectionTrackJSJL.gTrackItemJSJL(cSingleWell.svgDoc, cSingleWell.svgDefs, item, curPage.fVScale, curTrackDraw.iTrackWidth);
                                    if (curTrackDraw.sTrackType == TypeTrack.沉积旋回.ToString()) returnElemment = cSVGSectionTrackCycle.gTrackGeoCycle(cSingleWell.svgDoc, cSingleWell.svgDefs, item, curPage.fVScale, curTrackDraw.iTrackWidth);
                                    if (curTrackDraw.sTrackType == TypeTrack.描述.ToString()) returnElemment = cSVGSectionTrackDes.gTrackItemFossil(cSingleWell.svgDoc, cSingleWell.svgDefs, item, curPage.fVScale, curTrackDraw.iTrackWidth);
                                    if (curTrackDraw.sTrackType == TypeTrack.管柱.ToString()) returnElemment = cSVGSectionTrackWellBone.gTrackItemWellBone(cSingleWell.svgDoc, cSingleWell.svgDefs, item, curPage.fVScale, curTrackDraw.iTrackWidth);
                                    cSingleWell.addgElement2Layer(gTrackLayer, returnElemment, iListTrackWidth.Sum());
                                }
                            }
                        }
                    }
                    #endregion
                    #region 组分图道
                    List<itemLogHeadInforDraw> ltItemComPositionLogHeadInforDraw = new List<itemLogHeadInforDraw>(); //记录绘制道头用，节省重新读取的时间
                    if (curTrackDraw.sTrackType == TypeTrack.组分.ToString())
                    {
                        XmlNodeList xnList = el_Track.SelectNodes(".//Log");
                        int iLogNum = 0;
                        bool bGrid = false; //记录网格是否绘制过。
                        foreach (XmlElement xnLog in xnList)
                        {
                            iLogNum++;
                            itemLogHeadInforDraw curLogHead = new itemLogHeadInforDraw(xnLog);
                            ltItemComPositionLogHeadInforDraw.Add(curLogHead);
                            if (curLogHead.iIsLog > 0)
                            {
                                if (curLogHead.fLeftValue <= 0)
                                {
                                    curLogHead.fLeftValue = 1;
                                    cXmlBase.setSelectedNodeChildNodeValue(filePathTemplatOper, "", "leftValue", "1");
                                }
                                curLogHead.iLogGridGrade = cSVGSectionTrackLog.getNumGridGroupInLog(curLogHead.fLeftValue, curLogHead.fRightValue);
                            }

                            //曲线是否可见
                            if (curLogHead.iLogCurveVisible > 0)
                            {
                                XmlNode nodeData = xnLog.SelectSingleNode("sData");

                                if (nodeData != null)
                                {
                                    string sData = nodeData.InnerText;
                                    trackDataListLog dlTrackDataListLog = cSVGSectionTrackLog.getLogSeriersFromSectionWell(sData, curLogHead.sLogName, curPage.dfDS1Show, curPage.dfDS2Show, curPage.fVScale);
                                    //画网格,这块 一套曲线画了一套网格，不太好。
                                    if (curPage.iShowMode == 1 && curLogHead.iHasGrid == 1 && bGrid == false)
                                    {
                                        returnElemment = cSVGSectionTrack.trackHorizonalGrid(cSingleWell.svgDoc, cSingleWell.svgDefs, curPage.dfDS1Show, curPage.dfDS2Show, curPage.fVScale, curTrackDraw.iTrackWidth);
                                        cSingleWell.addgElement2BaseLayer(returnElemment, iListTrackWidth.Sum());
                                        if (curLogHead.iIsLog == 0) returnElemment = cSVGSectionTrack.trackVerticalGrid(cSingleWell.svgDoc, cSingleWell.svgDefs, 0, curPage.dfDS1Show, curPage.fVScale, curTrackDraw.iTrackWidth, curPage.dfDS2Show - curPage.dfDS1Show);
                                        else returnElemment = cSVGSectionTrack.trackVerticalGridLog(cSingleWell.svgDoc, cSingleWell.svgDefs, 0, curPage.dfDS1Show, curPage.fVScale, curTrackDraw.iTrackWidth, curPage.dfDS2Show - curPage.dfDS1Show, curLogHead.iLogGridGrade);
                                        cSingleWell.addgElement2BaseLayer(returnElemment, iListTrackWidth.Sum());
                                        bGrid = true; //一个道 只绘制一套网格
                                    }
                                    //画曲线
                                    returnElemment = cSVGSectionTrackLog.gTrackLog(cSingleWell.svgDoc, curLogHead, curTrackDraw.iTrackWidth, dlTrackDataListLog.fListMD, dlTrackDataListLog.fListValue, curPage.fVScale);
                                    cSingleWell.addgElement2BaseLayer(returnElemment, iListTrackWidth.Sum());
                                }
                            }//曲线可见
                     
                        }//结束曲线循环
                    } //结束曲线if
                    #endregion
                    #region 曲线道
                    List<itemLogHeadInforDraw> ltItemLogHeadInforDraw = new List<itemLogHeadInforDraw>(); //记录绘制道头用，节省重新读取的时间
                    if (curTrackDraw.sTrackType == TypeTrack.曲线道.ToString())
                    {
                        cSVGSectionTrackLogCurveFill.listLogViewData4fill.Clear();
                        XmlNodeList xnList = el_Track.SelectNodes(".//Log");
                        int iLogNum = 0;
                        bool bGrid = false; //记录网格是否绘制过。
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
                            //曲线是否可见
                            if (curLogHead.iLogCurveVisible > 0)
                            {
                                //trackDataListLog dlTrackDataListLog = cSVGSectionTrackLog.getLogSeriersFromLogFile(sJH, curLogHead.sLogName, curPage.dfDS1Show, curPage.dfDS2Show);

                                trackDataListLog dlTrackDataListLog = getTrackDataListLog(sJH, curLogHead.sLogName, curPage.dfDS1Show, curPage.dfDS2Show, ltTrackLog);
                               
                                //画网格,这块 一套曲线画了一套网格，不太好。
                                if (curPage.iShowMode == 1 && curLogHead.iHasGrid == 1 && bGrid == false)
                                {
                                    returnElemment = cSVGSectionTrack.trackHorizonalGrid(cSingleWell.svgDoc, cSingleWell.svgDefs, curPage.dfDS1Show, curPage.dfDS2Show, curPage.fVScale, curTrackDraw.iTrackWidth);
                                    cSingleWell.addgElement2BaseLayer(returnElemment, iListTrackWidth.Sum());
                                    if (curLogHead.iIsLog == 0) returnElemment = cSVGSectionTrack.trackVerticalGrid(cSingleWell.svgDoc, cSingleWell.svgDefs, 0, curPage.dfDS1Show, curPage.fVScale, curTrackDraw.iTrackWidth, curPage.dfDS2Show - curPage.dfDS1Show);
                                    else returnElemment = cSVGSectionTrack.trackVerticalGridLog(cSingleWell.svgDoc, cSingleWell.svgDefs, 0, curPage.dfDS1Show, curPage.fVScale, curTrackDraw.iTrackWidth, curPage.dfDS2Show - curPage.dfDS1Show, curLogHead.iLogGridGrade);
                                    cSingleWell.addgElement2BaseLayer(returnElemment, iListTrackWidth.Sum());
                                    bGrid = true; //一个道 只绘制一套网格
                                }
                                //画曲线
                                returnElemment = cSVGSectionTrackLog.gTrackLog(cSingleWell.svgDoc, curLogHead, curTrackDraw.iTrackWidth, dlTrackDataListLog.fListMD, dlTrackDataListLog.fListValue, curPage.fVScale);
                                cSingleWell.addgElement2BaseLayer(returnElemment, iListTrackWidth.Sum());
                                
                            }//曲线可见

                            #region 绘制填充
                            XmlNodeList xnFillList = el_Track.SelectNodes(".//FillItem");
                            foreach (XmlElement xn in xnFillList)
                            {
                                itemDrawDataTrackFill itemFill = new itemDrawDataTrackFill(xn);
                                trackDataListLog main = cSVGSectionTrackLogCurveFill.listLogViewData4fill.SingleOrDefault(p => p.itemHeadInforDraw.sIDLog == itemFill.sIDmainLog);
                                if (main != null && itemFill.iFillMode == 0)
                                {
                                    string sIDSub = xn["idLogSub"].InnerText;
                                    trackDataListLog sub = cSVGSectionTrackLogCurveFill.listLogViewData4fill.SingleOrDefault(p => p.itemHeadInforDraw.sIDLog == sIDSub);
                                    if (sub != null)
                                    {
                                        returnElemment = cSVGSectionTrackLogCurveFill.gLogCurveFillByLog(cSingleWell.svgDoc, main, sub, itemFill, curPage.fVScale);
                                        cSingleWell.addgElement2BaseLayer(returnElemment, iListTrackWidth.Sum());
                                    }
                                }

                                if (main != null && itemFill.iFillMode == 1)
                                {
                                    double fValueCutOff = itemFill.fValueCutoff;
                                    float fLeftValue = main.itemHeadInforDraw.fLeftValue;
                                    double xViewCutOff = curTrackDraw.iTrackWidth * (fValueCutOff - fLeftValue) / (main.itemHeadInforDraw.fRightValue - fLeftValue);
                                    if (main.itemHeadInforDraw.iIsLog == 1) xViewCutOff = curTrackDraw.iTrackWidth * (Math.Log10(fValueCutOff / fLeftValue)) / main.itemHeadInforDraw.iLogGridGrade;
                                    returnElemment = cSVGSectionTrackLogCurveFill.gLogCurveFillByCutOff(cSingleWell.svgDoc, itemFill.sID, main, xViewCutOff, itemFill, curPage.fVScale);
                                    cSingleWell.addgElement2BaseLayer(returnElemment, iListTrackWidth.Sum());
                                }

                            }
                            #endregion foreach 填充循环结束
                        }//结束曲线循环
                    } //结束曲线if
                    #endregion 结束曲线道
                    #region 增加图道道头及测井曲线头,道头ID 对应节点 后画道头是因为要覆盖。测井头最后画 是因为要放在最上面不被遮盖
                    returnElemment = cSVGSectionTrack.trackHead(cSingleWell.svgDoc, curTrackDraw.sTrackID, curTrackDraw.sTrackTitle, iYpositionTrackHead, curPage.iHeightTrackHead, curTrackDraw.iTrackWidth, curTrackDraw.iTrackHeadFontSize, curTrackDraw.sWriteMode);
                    cSingleWell.addgElement2Layer(gTrackLayer, returnElemment, iListTrackWidth.Sum());
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
                                int iUpLine = 20; //不同测井曲线间隔距离
                                int iFirstLogheadLinePosition = 3;  //首条logheadLine线距离下边框的距离
                                returnElemment = cSVGSectionTrack.addTrackItemLogHeadInfor(cSingleWell.svgDoc, curLogHead, iYpositionTrackHead + curPage.iHeightTrackHead - iUpLine * (iLogNum - 1) - iFirstLogheadLinePosition, curTrackDraw.iTrackWidth, 14);
                                cSingleWell.addgElement2Layer(gTrackLayer, returnElemment, iListTrackWidth.Sum());
                            }
                        }
                    }
                    if (curTrackDraw.sTrackType == TypeTrack.组分.ToString())
                    {
                        int iLogNum = 0;
                        foreach (itemLogHeadInforDraw curLogHead in ltItemComPositionLogHeadInforDraw)
                        {
                            iLogNum++;
                            if (curLogHead.iLogCurveVisible > 0)
                            {
                                //增加测井头
                                int iUpLine = 20; //不同测井曲线间隔距离
                                int iFirstLogheadLinePosition = 3;  //首条logheadLine线距离下边框的距离
                                returnElemment = cSVGSectionTrack.addTrackItemLogHeadInfor(cSingleWell.svgDoc, curLogHead, iYpositionTrackHead + curPage.iHeightTrackHead - iUpLine * (iLogNum - 1) - iFirstLogheadLinePosition, curTrackDraw.iTrackWidth, 14);
                                cSingleWell.addgElement2Layer(gTrackLayer, returnElemment, iListTrackWidth.Sum());
                            }
                        }
                    }
                    #endregion
                    # region 绘制道框
                    returnElemment = cSVGSectionTrack.trackRect(cSingleWell.svgDoc, curTrackDraw.sTrackID, curPage.dfDS1Show, curPage.dfDS2Show, curPage.fVScale, curTrackDraw.iTrackWidth);
                    cSingleWell.addgElement2BaseLayer(returnElemment, iListTrackWidth.Sum());
                    #endregion

                    //道宽List
                    iListTrackWidth.Add(curTrackDraw.iTrackWidth);
                } //if 是否可见
            }//结束Foreach图道循环绘制

            # region 增加图头
            returnElemment = cSingleWell.mapHeadTitle(curPage.sMapTitle, iYpositionTitle, iYpositionTitle + curPage.iHeightMapTitle, curPage.iHeightMapTitle, iListTrackWidth.Sum(), curPage.iHeightMapTitle * 2 / 3);
            cSingleWell.addgElement2BaseLayer(returnElemment, iDx);
            #endregion

            # region 增加图例
            //先创建一个rect，里面横向添加图例
            #endregion
            string svgFilePath = cProjectManager.dirPathTemp + "\\" + fileName;
            cSingleWell.makeSVGfile(svgFilePath);
            return svgFilePath;
        }
        //成果图要加图例，要把图头不遮盖，要截断顶底深
        public static string makeResultGraph(string filePathTemplatOper, string fileName,float fTopShow,float fBotShow)
        {
            List<int> iListTrackWidth = new List<int>();
            List<string> ListLegend = new List<string>(); //图例
            XmlDocument curDoc = new XmlDocument();
            curDoc.Load(filePathTemplatOper);
            string sJH = cXmlBase.getNodeInnerText(curDoc, cXmlDocSectionWell.fullPathJH);

            string sMapTitle = cXmlBase.getNodeInnerText(curDoc, cXEWellPage.fullPathMapTitle);
            //图幅全部用px基本单位，fVScale已经包含了 px-> 到应用单位的转换。
            double fVScale = double.Parse(cXmlBase.getNodeInnerText(curDoc, cXEWellPage.fullPathVSacle));
            double dfDS1Show = fTopShow ;
            double dfDS2Show = fBotShow ;
            double iDx = 0;

            //这种是上移式图头绘制模式 与 遮盖式图头绘制模式严格位置不同
            int iHeightMapTitle = int.Parse(cXmlBase.getNodeInnerText(filePathTemplatOper, cXEWellPage.fullPathMapTitleRectHeight));
            double iYpositionTitle = 0;
            int iHeightTrackHead = int.Parse(cXmlBase.getNodeInnerText(filePathTemplatOper, cXEWellPage.fullPathTrackRectHeight));
            double iYpositionTrackHead = iHeightMapTitle;

            double iDy = -fTopShow * fVScale + iYpositionTrackHead + iHeightTrackHead;

            int iShowMode = int.Parse(cXmlBase.getNodeInnerText(curDoc, cXEWellPage.fullPathShowMode));
            double PageWidth = double.Parse(cXmlBase.getNodeInnerText(curDoc, cXEWellPage.fullPathPageWidth));
            double PageHeight = (dfDS2Show-dfDS1Show) * fVScale +iYpositionTrackHead + iHeightTrackHead+20 ;
            //以上代码执行2毫秒，不必优化了
            cSVGBaseSection cSingleWell = new cSVGBaseSection(PageWidth, PageHeight, iDx, 0, "px"); //全部用px 单位转换用算法实现
            iListTrackWidth.Clear();
            XmlElement returnElemment;
            foreach (XmlElement el_Track in cXmlDocSectionWell.getTrackNodes(curDoc))
            {
                //初始化绘制道的基本信息
                trackDataDraw curTrackDraw = new trackDataDraw(el_Track);

                //定义一个新层 装道。 但是 也有问题，会有下面的遮盖问题。

                //先画曲线，再画道头和道框，这样好看
                if (curTrackDraw.iVisible > 0) //判断是否可见，可见才绘制
                {
                    #region 深度道
                    if (curTrackDraw.sTrackType == TypeTrack.深度尺.ToString())
                    {
                        int mainTick = int.Parse(el_Track["mainScale"].InnerText);
                        int minTick = int.Parse(el_Track["minScale"].InnerText);
                        int tickFontSize = int.Parse(el_Track["fontSize"].InnerText);
                        returnElemment = cSVGSectionTrackWellRuler.gMDRuler(cSingleWell.svgDoc, cSingleWell.svgDefs, cSingleWell.svgCss, Convert.ToInt16(dfDS1Show), Convert.ToInt16(dfDS2Show), mainTick, minTick, fVScale, tickFontSize);
                        cSingleWell.addgElement2BaseLayer(returnElemment, iListTrackWidth.Sum(),iDy);
                    }
                    # endregion
                    # region 文本道
                    if (curTrackDraw.sTrackType == TypeTrack.文本道.ToString())
                    {
                        int iAlignMode = 0;
                        if (el_Track["iAlignMode"] != null) iAlignMode = int.Parse(el_Track["iAlignMode"].InnerText);
                        XmlNode dataList = el_Track.SelectSingleNode("dataList");
                        if (dataList != null)
                        {
                            XmlNodeList dataItem = dataList.SelectNodes("dataItem");
                            foreach (XmlNode xn in dataItem)
                            {
                                    ItemTrackDrawDataIntervalProperty item = new ItemTrackDrawDataIntervalProperty(xn);
                                    if (item.top >= dfDS1Show && item.bot <= dfDS2Show)
                                    {
                                    returnElemment = cSVGSectionTrackText.gTrackItemText(cSingleWell.svgDoc, item.sID, item.top, item.bot, fVScale, item.sText, curTrackDraw.iTrackFontSize, iAlignMode, curTrackDraw.iTrackWidth, item.sProperty, curTrackDraw.sWriteMode);
                                    cSingleWell.addgElement2BaseLayer(returnElemment, iListTrackWidth.Sum(),iDy);
                                }
                            }
                        }
                    }
                    #endregion
                    #region 符号图道
                    if (curTrackDraw.sTrackType == TypeTrack.符号.ToString())
                    {
                        XmlNode dataList = el_Track.SelectSingleNode("dataList");
                        if (dataList != null)
                        {
                            XmlNodeList dataItem = dataList.SelectNodes("dataItem");
                            foreach (XmlNode xn in dataItem)
                            {
                                ItemTrackDrawDataIntervalProperty item = new ItemTrackDrawDataIntervalProperty(xn);
                                returnElemment = cSVGSectionTrackSymbol.gTrackIntervalSymbol(cSingleWell.svgDoc,cSingleWell.svgDefs ,  item, fVScale, curTrackDraw.iTrackWidth);
                                cSingleWell.addgElement2BaseLayer(returnElemment, iListTrackWidth.Sum(),iDy);
                            }
                        }
                    }
                    #endregion
                    #region 比例条
                    if (curTrackDraw.sTrackType == TypeTrack.比例条.ToString())
                    {
                        XmlNode dataList = el_Track.SelectSingleNode("dataList");
                        if (dataList != null)
                        {
                            XmlNodeList dataItem = dataList.SelectNodes("dataItem");
                            foreach (XmlNode xn in dataItem)
                            {
                                ItemTrackDrawDataIntervalProperty item = new ItemTrackDrawDataIntervalProperty(xn);
                                returnElemment = cSVGSectionTrackSymbol.gTrackRatioRect(cSingleWell.svgDoc, item.sID, item.top, item.bot, float.Parse(item.sText), fVScale, curTrackDraw.iTrackWidth, "blue");
                                cSingleWell.addgElement2BaseLayer(returnElemment, iListTrackWidth.Sum(),iDy);
                            }
                        }
                    }
                    #endregion
                    #region 地层道
                    if (curTrackDraw.sTrackType == TypeTrack.分层.ToString())
                    {
                        XmlNode dataList = el_Track.SelectSingleNode("dataList");
                        if (dataList != null)
                        {
                            XmlNodeList dataItem = dataList.SelectNodes("dataItem");
                            foreach (XmlNode xn in dataItem)
                            {
                                itemDrawDataIntervalValue item = new itemDrawDataIntervalValue(xn);
                                if (item.top >= dfDS1Show && item.bot <= dfDS2Show)
                                {
                                    returnElemment = cSVGSectionTrackLayer.gTrackItemLayer(cSingleWell.svgDoc, item, fVScale, curTrackDraw.iTrackFontSize, curTrackDraw.iTrackWidth);
                                    cSingleWell.addgElement2BaseLayer(returnElemment, iListTrackWidth.Sum(),iDy);
                                }
                            }
                        }
                    }
                    #endregion
                    #region 图片道
                    if (curTrackDraw.sTrackType == TypeTrack.图片道.ToString())
                    {
                        XmlNode dataList = el_Track.SelectSingleNode("dataList");
                        if (dataList != null)
                        {
                            XmlNodeList dataItem = dataList.SelectNodes("dataItem");
                            foreach (XmlNode xn in dataItem)
                            {
                                itemDrawDataIntervalValue item = new itemDrawDataIntervalValue(xn);
                                returnElemment = cSVGSectionTrackImage.gTrackImage(cSingleWell.svgDoc, cSingleWell.svgDefs, sJH, item, fVScale, curTrackDraw.iTrackWidth);
                                cSingleWell.addgElement2BaseLayer(returnElemment, iListTrackWidth.Sum(),iDy);
                            }
                        }
                    }
                    #endregion
                    #region 岩性
                    if (curTrackDraw.sTrackType == TypeTrack.岩性层段.ToString())
                    {
                        XmlNode dataList = el_Track.SelectSingleNode("dataList");
                        if (dataList != null)
                        {
                            XmlNodeList dataItem = dataList.SelectNodes("dataItem");
                            foreach (XmlNode xn in dataItem)
                            {
                                itemDrawDataIntervalValue item = new itemDrawDataIntervalValue(xn);
                                if (item.top >= dfDS1Show && item.bot <= dfDS2Show)
                                {
                                    returnElemment = cSVGSectionTrackLitho.gTrackLitho(cSingleWell.svgDoc, cSingleWell.svgDefs, item, fVScale, curTrackDraw.iTrackWidth);
                                    cSingleWell.addgElement2BaseLayer(returnElemment, iListTrackWidth.Sum(),iDy);
                                }
                            }
                        }
                    }
                    #endregion
                    #region 测井解释，旋回,化石道
                    if (cProjectManager.ltStrTrackTypeIntervalProperty.IndexOf(curTrackDraw.sTrackType) >= 0)
                    {
                        XmlNode dataList = el_Track.SelectSingleNode("dataList");
                        if (dataList != null)
                        {
                            XmlNodeList dataItem = dataList.SelectNodes("dataItem");
                            foreach (XmlNode xn in dataItem)
                            {
                                ItemTrackDrawDataIntervalProperty item = new ItemTrackDrawDataIntervalProperty(xn); if (item.top >= dfDS1Show && item.bot <= dfDS2Show)
                                {
                                    returnElemment = cSVGSectionTrackJSJL.gTrackItemJSJL(cSingleWell.svgDoc, cSingleWell.svgDefs, item, fVScale, curTrackDraw.iTrackWidth);
                                    if (curTrackDraw.sTrackType == TypeTrack.沉积旋回.ToString()) returnElemment = cSVGSectionTrackCycle.gTrackGeoCycle(cSingleWell.svgDoc, cSingleWell.svgDefs, item, fVScale, curTrackDraw.iTrackWidth);
                                    if (curTrackDraw.sTrackType == TypeTrack.描述.ToString()) returnElemment = cSVGSectionTrackDes.gTrackItemFossil(cSingleWell.svgDoc, cSingleWell.svgDefs, item, fVScale, curTrackDraw.iTrackWidth);
                                    cSingleWell.addgElement2BaseLayer(returnElemment, iListTrackWidth.Sum(),iDy);
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
                        bool bGrid = false; //记录网格是否绘制过。
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

                            //曲线是否可见
                            if (curLogHead.iLogCurveVisible > 0)
                            {
                                trackDataListLog dlTrackDataListLog = cSVGSectionTrackLog.getLogSeriersFromLogFile(sJH, curLogHead.sLogName, dfDS1Show, dfDS2Show);
                                //画网格,这块 一套曲线画了一套网格，不太好。
                                if (iShowMode == 1 && curLogHead.iHasGrid == 1 && bGrid == false)
                                {
                                    returnElemment = cSVGSectionTrack.trackHorizonalGrid(cSingleWell.svgDoc, cSingleWell.svgDefs, dfDS1Show, dfDS2Show, fVScale, curTrackDraw.iTrackWidth);
                                    cSingleWell.addgElement2BaseLayer(returnElemment, iListTrackWidth.Sum(), iDy);
                                    if (curLogHead.iIsLog == 0) returnElemment = cSVGSectionTrack.trackVerticalGrid(cSingleWell.svgDoc, cSingleWell.svgDefs, 0, dfDS1Show, fVScale, curTrackDraw.iTrackWidth, dfDS2Show - dfDS1Show);
                                    else returnElemment = cSVGSectionTrack.trackVerticalGridLog(cSingleWell.svgDoc, cSingleWell.svgDefs, 0, dfDS1Show, fVScale, curTrackDraw.iTrackWidth, dfDS2Show - dfDS1Show, curLogHead.iLogGridGrade);
                                    cSingleWell.addgElement2BaseLayer(returnElemment, iListTrackWidth.Sum(), iYpositionTrackHead + iHeightTrackHead);
                                    bGrid = true; //一个道 只绘制一套网格
                                }
                                //画曲线
                                returnElemment = cSVGSectionTrackLog.gTrackLog(cSingleWell.svgDoc, curLogHead, curTrackDraw.iTrackWidth, dlTrackDataListLog.fListMD, dlTrackDataListLog.fListValue, fVScale);
                                cSingleWell.addgElement2BaseLayer(returnElemment, iListTrackWidth.Sum(), iDy); 

                                XmlNode nodeData = xnLog.SelectSingleNode("sData");
                                //从xml读取
                                //if (nodeData != null)
                                //{
                                //    string sData = nodeData.InnerText;
                                //    trackDataListLog dlTrackDataListLog = cSVGSectionTrackLog.getLogSeriersFromSectionWell(sData, curLogHead.sLogName, dfDS1Show, dfDS2Show, fVScale);

                                //    //画网格,这块 一套曲线画了一套网格，不太好。
                                //    if (iShowMode == 1 && curLogHead.iHasGrid == 1 && bGrid == false)
                                //    {
                                //        returnElemment = cSVGSectionTrack.trackHorizonalGrid(cSingleWell.svgDoc, cSingleWell.svgDefs, dfDS1Show, dfDS2Show, fVScale, curTrackDraw.iTrackWidth);
                                //        cSingleWell.addgElement2BaseLayer(returnElemment, iListTrackWidth.Sum(),iDy);
                                //        if (curLogHead.iIsLog == 0) returnElemment = cSVGSectionTrack.trackVerticalGrid(cSingleWell.svgDoc, cSingleWell.svgDefs, 0, dfDS1Show, fVScale, curTrackDraw.iTrackWidth, dfDS2Show - dfDS1Show);
                                //        else returnElemment = cSVGSectionTrack.trackVerticalGridLog(cSingleWell.svgDoc, cSingleWell.svgDefs, 0, dfDS1Show, fVScale, curTrackDraw.iTrackWidth, dfDS2Show - dfDS1Show, curLogHead.iLogGridGrade);
                                //        cSingleWell.addgElement2BaseLayer(returnElemment, iListTrackWidth.Sum(), iYpositionTrackHead+iHeightTrackHead);
                                //        bGrid = true; //一个道 只绘制一套网格
                                //    }
                                //    //画曲线
                                //    returnElemment = cSVGSectionTrackLog.gTrackLog(cSingleWell.svgDoc, curLogHead, curTrackDraw.iTrackWidth, dlTrackDataListLog.fListMD, dlTrackDataListLog.fListValue, fVScale);
                                //    cSingleWell.addgElement2BaseLayer(returnElemment, iListTrackWidth.Sum(),iDy);
                                //}
                            }//曲线可见

                            #region 绘制填充
                            XmlNodeList xnFillList = el_Track.SelectNodes(".//FillItem");
                            foreach (XmlElement xn in xnFillList)
                            {
                                itemDrawDataTrackFill itemFill = new itemDrawDataTrackFill(xn);
                                trackDataListLog main = cSVGSectionTrackLogCurveFill.listLogViewData4fill.SingleOrDefault(p => p.itemHeadInforDraw.sIDLog == itemFill.sIDmainLog);
                                if (main != null && itemFill.iFillMode == 0)
                                {
                                    string sIDSub = xn["idLogSub"].InnerText;
                                    trackDataListLog sub = cSVGSectionTrackLogCurveFill.listLogViewData4fill.SingleOrDefault(p => p.itemHeadInforDraw.sIDLog == sIDSub);
                                    if (sub != null)
                                    {
                                        returnElemment = cSVGSectionTrackLogCurveFill.gLogCurveFillByLog(cSingleWell.svgDoc, main, sub, itemFill, fVScale);
                                        cSingleWell.addgElement2BaseLayer(returnElemment, iListTrackWidth.Sum(),iDy);
                                    }
                                }

                                if (main != null && itemFill.iFillMode == 1)
                                {
                                    double fValueCutOff = itemFill.fValueCutoff;
                                    float fLeftValue = main.itemHeadInforDraw.fLeftValue;
                                    double xViewCutOff = curTrackDraw.iTrackWidth * (fValueCutOff - fLeftValue) / (main.itemHeadInforDraw.fRightValue - fLeftValue);
                                    if (main.itemHeadInforDraw.iIsLog == 1) xViewCutOff = curTrackDraw.iTrackWidth * (Math.Log10(fValueCutOff / fLeftValue)) / main.itemHeadInforDraw.iLogGridGrade;
                                    returnElemment = cSVGSectionTrackLogCurveFill.gLogCurveFillByCutOff(cSingleWell.svgDoc, itemFill.sID, main, xViewCutOff, itemFill, fVScale);
                                    cSingleWell.addgElement2BaseLayer(returnElemment, iListTrackWidth.Sum(),iDy);
                                }

                            }
                            #endregion foreach 填充循环结束
                        }//结束曲线循环
                    } //结束曲线if
                    #endregion 结束曲线道

                    #region 增加图道道头及测井曲线头,道头ID 对应节点 后画道头是因为要覆盖。测井头最后画 是因为要放在最上面不被遮盖
                    returnElemment = cSVGSectionTrack.trackHead(cSingleWell.svgDoc, curTrackDraw.sTrackID, curTrackDraw.sTrackTitle,
                        iYpositionTrackHead, iHeightTrackHead, curTrackDraw.iTrackWidth, curTrackDraw.iTrackHeadFontSize, curTrackDraw.sWriteMode);
                    cSingleWell.addgElement2BaseLayer(returnElemment, iListTrackWidth.Sum(),0);
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
                                int iUpLine = cSVGSectionTrack.iHeightLogHeadItem; //不同测井曲线间隔距离
                                int iFirstLogheadLinePosition = 3;  //首条logheadLine线距离下边框的距离
                                returnElemment = cSVGSectionTrack.addTrackItemLogHeadInfor(cSingleWell.svgDoc, curLogHead, iYpositionTrackHead + iHeightTrackHead - iUpLine * (iLogNum - 1) - iFirstLogheadLinePosition, curTrackDraw.iTrackWidth, 14);
                                cSingleWell.addgElement2BaseLayer(returnElemment, iListTrackWidth.Sum(), 0);
                            }
                        }
                    }
                    #endregion
                    # region 绘制道框
                    if (iShowMode == 1)
                    {
                        returnElemment = cSVGSectionTrack.trackRect(cSingleWell.svgDoc, curTrackDraw.sTrackID, dfDS1Show, dfDS2Show, fVScale, curTrackDraw.iTrackWidth);
                        cSingleWell.addgElement2BaseLayer(returnElemment, iListTrackWidth.Sum(),iDy);
                    }
                    #endregion

                    //道宽List
                    iListTrackWidth.Add(curTrackDraw.iTrackWidth);
                } //if 是否可见
            }//结束Foreach图道循环绘制
            # region 增加图头
            returnElemment = cSingleWell.mapHeadTitle(sMapTitle, iYpositionTitle, iYpositionTitle + iHeightMapTitle, iHeightMapTitle, iListTrackWidth.Sum(), iHeightMapTitle * 2 / 3);
            cSingleWell.addgElement2BaseLayer(returnElemment, iDx,0);
            #endregion

            # region 增加图例
            //先创建一个rect，里面横向添加图例
            #endregion
            string svgFilePath = cProjectManager.dirPathTemp + "\\" + fileName;
            cSingleWell.makeSVGfile(svgFilePath);
            return svgFilePath;
        }

        //画斜井样式的成果剖面
        public static string makeResultWellPathGraph(string filePathTemplatOper, string fileName, float fTopShow, float fBotShow)
        {
            List<int> iListTrackWidth = new List<int>();
            List<string> ListLegend = new List<string>(); //图例
            XmlDocument curDoc = new XmlDocument();
            curDoc.Load(filePathTemplatOper);
            string sJH = cXmlBase.getNodeInnerText(curDoc, cXmlDocSectionWell.fullPathJH);

            string sMapTitle = cXmlBase.getNodeInnerText(curDoc, cXEWellPage.fullPathMapTitle);
            //图幅全部用px基本单位，fVScale已经包含了 px-> 到应用单位的转换。
            double fVScale = double.Parse(cXmlBase.getNodeInnerText(curDoc, cXEWellPage.fullPathVSacle));
            double dfDS1Show = fTopShow;
            double dfDS2Show = fBotShow;
            double iDx = 0;

            //这种是上移式图头绘制模式 与 遮盖式图头绘制模式严格位置不同
            int iHeightMapTitle = int.Parse(cXmlBase.getNodeInnerText(filePathTemplatOper, cXEWellPage.fullPathMapTitleRectHeight));
            double iYpositionTitle = 0;
            int iHeightTrackHead = int.Parse(cXmlBase.getNodeInnerText(filePathTemplatOper, cXEWellPage.fullPathTrackRectHeight));
            double iYpositionTrackHead = iHeightMapTitle;

            double iDy = -fTopShow * fVScale + iYpositionTrackHead + iHeightTrackHead;

            int iShowMode = int.Parse(cXmlBase.getNodeInnerText(curDoc, cXEWellPage.fullPathShowMode));
            double PageWidth = double.Parse(cXmlBase.getNodeInnerText(curDoc, cXEWellPage.fullPathPageWidth));
            double PageHeight = (dfDS2Show - dfDS1Show) * fVScale + iYpositionTrackHead + iHeightTrackHead + 20;
            //以上代码执行2毫秒，不必优化了
            cSVGBaseSection cSingleWell = new cSVGBaseSection(PageWidth, PageHeight, iDx, 0, "px"); //全部用px 单位转换用算法实现
            iListTrackWidth.Clear();
            XmlElement returnElemment;
            foreach (XmlElement el_Track in cXmlDocSectionWell.getTrackNodes(curDoc))
            {
                //初始化绘制道的基本信息
                trackDataDraw curTrackDraw = new trackDataDraw(el_Track);

                //定义一个新层 装道。 但是 也有问题，会有下面的遮盖问题。

                //先画曲线，再画道头和道框，这样好看
                if (curTrackDraw.iVisible > 0) //判断是否可见，可见才绘制
                {
                    #region 深度道
                    if (curTrackDraw.sTrackType == TypeTrack.深度尺.ToString())
                    {
                        int mainTick = int.Parse(el_Track["mainScale"].InnerText);
                        int minTick = int.Parse(el_Track["minScale"].InnerText);
                        int tickFontSize = int.Parse(el_Track["fontSize"].InnerText);
                        returnElemment = cSVGSectionTrackWellRuler.gMDRuler(cSingleWell.svgDoc, cSingleWell.svgDefs, cSingleWell.svgCss, Convert.ToInt16(dfDS1Show), Convert.ToInt16(dfDS2Show), mainTick, minTick, fVScale, tickFontSize);
                        cSingleWell.addgElement2BaseLayer(returnElemment, iListTrackWidth.Sum(), iDy);
                    }
                    # endregion
                    # region 文本道
                    if (curTrackDraw.sTrackType == TypeTrack.文本道.ToString())
                    {
                        int iAlignMode = 0;
                        if (el_Track["iAlignMode"] != null) iAlignMode = int.Parse(el_Track["iAlignMode"].InnerText);
                        XmlNode dataList = el_Track.SelectSingleNode("dataList");
                        if (dataList != null)
                        {
                            XmlNodeList dataItem = dataList.SelectNodes("dataItem");
                            foreach (XmlNode xn in dataItem)
                            {
                                ItemTrackDrawDataIntervalProperty item = new ItemTrackDrawDataIntervalProperty(xn);
                                if (item.top >= dfDS1Show && item.bot <= dfDS2Show)
                                {
                                    returnElemment = cSVGSectionTrackText.gTrackItemText(cSingleWell.svgDoc, item.sID, item.top, item.bot, fVScale, item.sText, curTrackDraw.iTrackFontSize, iAlignMode, curTrackDraw.iTrackWidth, item.sProperty, curTrackDraw.sWriteMode);
                                    cSingleWell.addgElement2BaseLayer(returnElemment, iListTrackWidth.Sum(), iDy);
                                }
                            }
                        }
                    }
                    #endregion
                    #region 符号图道
                    if (curTrackDraw.sTrackType == TypeTrack.符号.ToString())
                    {
                        XmlNode dataList = el_Track.SelectSingleNode("dataList");
                        if (dataList != null)
                        {
                            XmlNodeList dataItem = dataList.SelectNodes("dataItem");
                            foreach (XmlNode xn in dataItem)
                            {
                                ItemTrackDrawDataIntervalProperty item = new ItemTrackDrawDataIntervalProperty(xn);
                                returnElemment = cSVGSectionTrackSymbol.gTrackIntervalSymbol(cSingleWell.svgDoc, cSingleWell.svgDefs, item, fVScale, curTrackDraw.iTrackWidth);
                                cSingleWell.addgElement2BaseLayer(returnElemment, iListTrackWidth.Sum(), iDy);
                            }
                        }
                    }
                    #endregion
                    #region 比例条
                    if (curTrackDraw.sTrackType == TypeTrack.比例条.ToString())
                    {
                        XmlNode dataList = el_Track.SelectSingleNode("dataList");
                        if (dataList != null)
                        {
                            XmlNodeList dataItem = dataList.SelectNodes("dataItem");
                            foreach (XmlNode xn in dataItem)
                            {
                                ItemTrackDrawDataIntervalProperty item = new ItemTrackDrawDataIntervalProperty(xn);
                                returnElemment = cSVGSectionTrackSymbol.gTrackRatioRect(cSingleWell.svgDoc, item.sID, item.top, item.bot, float.Parse(item.sText), fVScale, curTrackDraw.iTrackWidth, "blue");
                                cSingleWell.addgElement2BaseLayer(returnElemment, iListTrackWidth.Sum(), iDy);
                            }
                        }
                    }
                    #endregion
                    #region 地层道
                    if (curTrackDraw.sTrackType == TypeTrack.分层.ToString())
                    {
                        XmlNode dataList = el_Track.SelectSingleNode("dataList");
                        if (dataList != null)
                        {
                            XmlNodeList dataItem = dataList.SelectNodes("dataItem");
                            foreach (XmlNode xn in dataItem)
                            {
                                itemDrawDataIntervalValue item = new itemDrawDataIntervalValue(xn);
                                if (item.top >= dfDS1Show && item.bot <= dfDS2Show)
                                {
                                    returnElemment = cSVGSectionTrackLayer.gTrackItemLayer(cSingleWell.svgDoc, item, fVScale, curTrackDraw.iTrackFontSize, curTrackDraw.iTrackWidth);
                                    cSingleWell.addgElement2BaseLayer(returnElemment, iListTrackWidth.Sum(), iDy);
                                }
                            }
                        }
                    }
                    #endregion
                    #region 图片道
                    if (curTrackDraw.sTrackType == TypeTrack.图片道.ToString())
                    {
                        XmlNode dataList = el_Track.SelectSingleNode("dataList");
                        if (dataList != null)
                        {
                            XmlNodeList dataItem = dataList.SelectNodes("dataItem");
                            foreach (XmlNode xn in dataItem)
                            {
                                itemDrawDataIntervalValue item = new itemDrawDataIntervalValue(xn);
                                returnElemment = cSVGSectionTrackImage.gTrackImage(cSingleWell.svgDoc, cSingleWell.svgDefs, sJH, item, fVScale, curTrackDraw.iTrackWidth);
                                cSingleWell.addgElement2BaseLayer(returnElemment, iListTrackWidth.Sum(), iDy);
                            }
                        }
                    }
                    #endregion
                    #region 岩性
                    if (curTrackDraw.sTrackType == TypeTrack.岩性层段.ToString())
                    {
                        XmlNode dataList = el_Track.SelectSingleNode("dataList");
                        if (dataList != null)
                        {
                            XmlNodeList dataItem = dataList.SelectNodes("dataItem");
                            foreach (XmlNode xn in dataItem)
                            {
                                itemDrawDataIntervalValue item = new itemDrawDataIntervalValue(xn);
                                if (item.top >= dfDS1Show && item.bot <= dfDS2Show)
                                {
                                    returnElemment = cSVGSectionTrackLitho.gTrackLitho(cSingleWell.svgDoc, cSingleWell.svgDefs, item, fVScale, curTrackDraw.iTrackWidth);
                                    cSingleWell.addgElement2BaseLayer(returnElemment, iListTrackWidth.Sum(), iDy);
                                }
                            }
                        }
                    }
                    #endregion
                    #region 测井解释，旋回,化石道
                    if (cProjectManager.ltStrTrackTypeIntervalProperty.IndexOf(curTrackDraw.sTrackType) >= 0)
                    {
                        XmlNode dataList = el_Track.SelectSingleNode("dataList");
                        if (dataList != null)
                        {
                            XmlNodeList dataItem = dataList.SelectNodes("dataItem");
                            foreach (XmlNode xn in dataItem)
                            {
                                ItemTrackDrawDataIntervalProperty item = new ItemTrackDrawDataIntervalProperty(xn); if (item.top >= dfDS1Show && item.bot <= dfDS2Show)
                                {
                                    returnElemment = cSVGSectionTrackJSJL.gTrackItemJSJL(cSingleWell.svgDoc, cSingleWell.svgDefs, item, fVScale, curTrackDraw.iTrackWidth);
                                    if (curTrackDraw.sTrackType == TypeTrack.沉积旋回.ToString()) returnElemment = cSVGSectionTrackCycle.gTrackGeoCycle(cSingleWell.svgDoc, cSingleWell.svgDefs, item, fVScale, curTrackDraw.iTrackWidth);
                                    if (curTrackDraw.sTrackType == TypeTrack.描述.ToString()) returnElemment = cSVGSectionTrackDes.gTrackItemFossil(cSingleWell.svgDoc, cSingleWell.svgDefs, item, fVScale, curTrackDraw.iTrackWidth);
                                    cSingleWell.addgElement2BaseLayer(returnElemment, iListTrackWidth.Sum(), iDy);
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
                        bool bGrid = false; //记录网格是否绘制过。
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

                            //曲线是否可见
                            if (curLogHead.iLogCurveVisible > 0)
                            {
                                trackDataListLog dlTrackDataListLog = cSVGSectionTrackLog.getLogSeriersFromLogFile(sJH, curLogHead.sLogName, dfDS1Show, dfDS2Show);
                                //画网格,这块 一套曲线画了一套网格，不太好。
                                if (iShowMode == 1 && curLogHead.iHasGrid == 1 && bGrid == false)
                                {
                                    returnElemment = cSVGSectionTrack.trackHorizonalGrid(cSingleWell.svgDoc, cSingleWell.svgDefs, dfDS1Show, dfDS2Show, fVScale, curTrackDraw.iTrackWidth);
                                    cSingleWell.addgElement2BaseLayer(returnElemment, iListTrackWidth.Sum(), iDy);
                                    if (curLogHead.iIsLog == 0) returnElemment = cSVGSectionTrack.trackVerticalGrid(cSingleWell.svgDoc, cSingleWell.svgDefs, 0, dfDS1Show, fVScale, curTrackDraw.iTrackWidth, dfDS2Show - dfDS1Show);
                                    else returnElemment = cSVGSectionTrack.trackVerticalGridLog(cSingleWell.svgDoc, cSingleWell.svgDefs, 0, dfDS1Show, fVScale, curTrackDraw.iTrackWidth, dfDS2Show - dfDS1Show, curLogHead.iLogGridGrade);
                                    cSingleWell.addgElement2BaseLayer(returnElemment, iListTrackWidth.Sum(), iYpositionTrackHead + iHeightTrackHead);
                                    bGrid = true; //一个道 只绘制一套网格
                                }
                                //画曲线
                                returnElemment = cSVGSectionTrackLog.gTrackLog(cSingleWell.svgDoc, curLogHead, curTrackDraw.iTrackWidth, dlTrackDataListLog.fListMD, dlTrackDataListLog.fListValue, fVScale);
                                cSingleWell.addgElement2BaseLayer(returnElemment, iListTrackWidth.Sum(), iDy);

                                XmlNode nodeData = xnLog.SelectSingleNode("sData");
                                //从xml读取
                                //if (nodeData != null)
                                //{
                                //    string sData = nodeData.InnerText;
                                //    trackDataListLog dlTrackDataListLog = cSVGSectionTrackLog.getLogSeriersFromSectionWell(sData, curLogHead.sLogName, dfDS1Show, dfDS2Show, fVScale);

                                //    //画网格,这块 一套曲线画了一套网格，不太好。
                                //    if (iShowMode == 1 && curLogHead.iHasGrid == 1 && bGrid == false)
                                //    {
                                //        returnElemment = cSVGSectionTrack.trackHorizonalGrid(cSingleWell.svgDoc, cSingleWell.svgDefs, dfDS1Show, dfDS2Show, fVScale, curTrackDraw.iTrackWidth);
                                //        cSingleWell.addgElement2BaseLayer(returnElemment, iListTrackWidth.Sum(),iDy);
                                //        if (curLogHead.iIsLog == 0) returnElemment = cSVGSectionTrack.trackVerticalGrid(cSingleWell.svgDoc, cSingleWell.svgDefs, 0, dfDS1Show, fVScale, curTrackDraw.iTrackWidth, dfDS2Show - dfDS1Show);
                                //        else returnElemment = cSVGSectionTrack.trackVerticalGridLog(cSingleWell.svgDoc, cSingleWell.svgDefs, 0, dfDS1Show, fVScale, curTrackDraw.iTrackWidth, dfDS2Show - dfDS1Show, curLogHead.iLogGridGrade);
                                //        cSingleWell.addgElement2BaseLayer(returnElemment, iListTrackWidth.Sum(), iYpositionTrackHead+iHeightTrackHead);
                                //        bGrid = true; //一个道 只绘制一套网格
                                //    }
                                //    //画曲线
                                //    returnElemment = cSVGSectionTrackLog.gTrackLog(cSingleWell.svgDoc, curLogHead, curTrackDraw.iTrackWidth, dlTrackDataListLog.fListMD, dlTrackDataListLog.fListValue, fVScale);
                                //    cSingleWell.addgElement2BaseLayer(returnElemment, iListTrackWidth.Sum(),iDy);
                                //}
                            }//曲线可见

                            #region 绘制填充
                            XmlNodeList xnFillList = el_Track.SelectNodes(".//FillItem");
                            foreach (XmlElement xn in xnFillList)
                            {
                                itemDrawDataTrackFill itemFill = new itemDrawDataTrackFill(xn);
                                trackDataListLog main = cSVGSectionTrackLogCurveFill.listLogViewData4fill.SingleOrDefault(p => p.itemHeadInforDraw.sIDLog == itemFill.sIDmainLog);
                                if (main != null && itemFill.iFillMode == 0)
                                {
                                    string sIDSub = xn["idLogSub"].InnerText;
                                    trackDataListLog sub = cSVGSectionTrackLogCurveFill.listLogViewData4fill.SingleOrDefault(p => p.itemHeadInforDraw.sIDLog == sIDSub);
                                    if (sub != null)
                                    {
                                        returnElemment = cSVGSectionTrackLogCurveFill.gLogCurveFillByLog(cSingleWell.svgDoc, main, sub, itemFill, fVScale);
                                        cSingleWell.addgElement2BaseLayer(returnElemment, iListTrackWidth.Sum(), iDy);
                                    }
                                }

                                if (main != null && itemFill.iFillMode == 1)
                                {
                                    double fValueCutOff = itemFill.fValueCutoff;
                                    float fLeftValue = main.itemHeadInforDraw.fLeftValue;
                                    double xViewCutOff = curTrackDraw.iTrackWidth * (fValueCutOff - fLeftValue) / (main.itemHeadInforDraw.fRightValue - fLeftValue);
                                    if (main.itemHeadInforDraw.iIsLog == 1) xViewCutOff = curTrackDraw.iTrackWidth * (Math.Log10(fValueCutOff / fLeftValue)) / main.itemHeadInforDraw.iLogGridGrade;
                                    returnElemment = cSVGSectionTrackLogCurveFill.gLogCurveFillByCutOff(cSingleWell.svgDoc, itemFill.sID, main, xViewCutOff, itemFill, fVScale);
                                    cSingleWell.addgElement2BaseLayer(returnElemment, iListTrackWidth.Sum(), iDy);
                                }

                            }
                            #endregion foreach 填充循环结束
                        }//结束曲线循环
                    } //结束曲线if
                    #endregion 结束曲线道

                    #region 增加图道道头及测井曲线头,道头ID 对应节点 后画道头是因为要覆盖。测井头最后画 是因为要放在最上面不被遮盖
                    returnElemment = cSVGSectionTrack.trackHead(cSingleWell.svgDoc, curTrackDraw.sTrackID, curTrackDraw.sTrackTitle,
                        iYpositionTrackHead, iHeightTrackHead, curTrackDraw.iTrackWidth, curTrackDraw.iTrackHeadFontSize, curTrackDraw.sWriteMode);
                    cSingleWell.addgElement2BaseLayer(returnElemment, iListTrackWidth.Sum(), 0);
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
                                int iUpLine = cSVGSectionTrack.iHeightLogHeadItem; //不同测井曲线间隔距离
                                int iFirstLogheadLinePosition = 3;  //首条logheadLine线距离下边框的距离
                                returnElemment = cSVGSectionTrack.addTrackItemLogHeadInfor(cSingleWell.svgDoc, curLogHead, iYpositionTrackHead + iHeightTrackHead - iUpLine * (iLogNum - 1) - iFirstLogheadLinePosition, curTrackDraw.iTrackWidth, 14);
                                cSingleWell.addgElement2BaseLayer(returnElemment, iListTrackWidth.Sum(), 0);
                            }
                        }
                    }
                    #endregion
                    # region 绘制道框
                    if (iShowMode == 1)
                    {
                        returnElemment = cSVGSectionTrack.trackRect(cSingleWell.svgDoc, curTrackDraw.sTrackID, dfDS1Show, dfDS2Show, fVScale, curTrackDraw.iTrackWidth);
                        cSingleWell.addgElement2BaseLayer(returnElemment, iListTrackWidth.Sum(), iDy);
                    }
                    #endregion

                    //道宽List
                    iListTrackWidth.Add(curTrackDraw.iTrackWidth);
                } //if 是否可见
            }//结束Foreach图道循环绘制
            # region 增加图头
            returnElemment = cSingleWell.mapHeadTitle(sMapTitle, iYpositionTitle, iYpositionTitle + iHeightMapTitle, iHeightMapTitle, iListTrackWidth.Sum(), iHeightMapTitle * 2 / 3);
            cSingleWell.addgElement2BaseLayer(returnElemment, iDx, 0);
            #endregion

            # region 增加图例
            //先创建一个rect，里面横向添加图例
            #endregion
            string svgFilePath = cProjectManager.dirPathTemp + "\\" + fileName;
            cSingleWell.makeSVGfile(svgFilePath);
            return svgFilePath;
        }

        public static void calInterStastics(string filePathTemplatOper, string sTrackID)
        {
            List<string> listResultLine = intervalStastics(filePathTemplatOper, sTrackID);
            openResult(listResultLine);
        }
        public static List<string> intervalStastics(string filePathTemplatOper, string sTrackID)
        {
            List<string> listResultLine = new List<string>();
            XmlNode el_Track = cXmlDocSectionWell.getTrackByTrackID(filePathTemplatOper,sTrackID);
            if (el_Track != null)
            {
                //初始化绘制道的基本信息
                trackDataDraw curTrackDraw = new trackDataDraw(el_Track);
                #region 按层段统计数据
                if (
                    curTrackDraw.sTrackType == TypeTrack.分层.ToString() ||
                    curTrackDraw.sTrackType == TypeTrack.岩性层段.ToString()||
                    curTrackDraw.sTrackType == TypeTrack.测井解释.ToString() ||
                    curTrackDraw.sTrackType == TypeTrack.符号.ToString() 
                  )
                {
                    XmlNode dataList = el_Track.SelectSingleNode("dataList");
                    if (dataList != null)
                    {
                        XmlNodeList dataItem = dataList.SelectNodes("dataItem");
                        foreach (XmlNode xn in dataItem)
                        {
                            ItemTrackDrawDataIntervalProperty item = new ItemTrackDrawDataIntervalProperty(xn);
                            listResultLine.AddRange(intervalStastics(filePathTemplatOper, item));  
                        }
                    }
                }
                #endregion
            }
            return listResultLine; 
        }
        public static void openResult(List<string> listLineWrited) 
        {
            //把dicStatic写入text 然后调用表单读取
            string filePathDicstastic = System.IO.Path.Combine(cProjectManager.dirPathTemp, "wellSectionStastics.txt");
            using (StreamWriter sw = new StreamWriter(filePathDicstastic, false, Encoding.UTF8))
            {
                if (listLineWrited.Count > 1)
                {
                    sw.WriteLine(listLineWrited[0]);
                    for (int i = 1; i < listLineWrited.Count; i++) 
                    {
                        //只保留一个headLine 删除相同行headLine
                        if (listLineWrited[i] != listLineWrited[0]) sw.WriteLine(listLineWrited[i]);
                    }
                }
            }
            FormDataTable newDataTable = new FormDataTable(filePathDicstastic);
            newDataTable.Show();
        }
        public static void calInterStastics(string filePathTemplatOper, ItemTrackDataIntervalProperty itemDataItem) 
        {
          openResult(intervalStastics(filePathTemplatOper, itemDataItem)); 
        }
        public static List<string> intervalStastics(string filePathTemplatOper, ItemTrackDataIntervalProperty itemDataItem)
        {
            float fTopInfor = itemDataItem.top;
            float fBotInfor = itemDataItem.bot;
            //在所有道循环，截取深度段信息组合成表
            List<string> ltHeadLine = new List<string>();
            List<string> ltStasticsValueStr = new List<string>();
            ltHeadLine.Add("顶深md");
            ltStasticsValueStr.Add(itemDataItem.top.ToString("0.0"));
            ltHeadLine.Add("底深md");
            ltStasticsValueStr.Add(itemDataItem.bot.ToString("0.0"));
            if (itemDataItem.sText != "")
            {
                ltHeadLine.Add("文本");
                ltStasticsValueStr.Add(itemDataItem.sText);
            }
            if (itemDataItem.sProperty != "")
            {
                ltHeadLine.Add("属性");
                ltStasticsValueStr.Add(itemDataItem.sProperty);
            }
            ltHeadLine.Add("顶深TVD");
            ltStasticsValueStr.Add(itemDataItem.topTVD.ToString("0.0"));
            ltHeadLine.Add("低深TVD");
            ltStasticsValueStr.Add(itemDataItem.botTVD.ToString("0.0"));
            ltHeadLine.Add("垂直厚度");
            ltStasticsValueStr.Add((itemDataItem.botTVD - itemDataItem.topTVD).ToString("0.0"));
             foreach(trackDataListLog dlTrackDataListLog in makeSectionWell.ltTrackLog)
             {
                                List<double> ltRangeValue = dlTrackDataListLog.getListValueRangeByDepth(fTopInfor, fBotInfor);
                               string sLogName = dlTrackDataListLog.itemHeadInforDraw.sLogName;
                               if (ltRangeValue.Count > 0)
                                {
                                    ltHeadLine.Add(sLogName + "最大值");
                                    ltStasticsValueStr.Add(ltRangeValue.Max().ToString("0.00"));
                                    ltHeadLine.Add(sLogName + "最小值");
                                    ltStasticsValueStr.Add(ltRangeValue.Min().ToString("0.00"));
                                    ltHeadLine.Add(sLogName + "平均值");
                                    ltStasticsValueStr.Add(ltRangeValue.Average().ToString("0.00"));
                                }
 
            }//end foreach

            //组合成字符串line 返回
            List<string> ltLineRet = new List<string>();
            ltLineRet.Add(string.Join("\t", ltHeadLine));
            ltLineRet.Add(string.Join("\t", ltStasticsValueStr));
            return ltLineRet;
            
        }

    }
}
