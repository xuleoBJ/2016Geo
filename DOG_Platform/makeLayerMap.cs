﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using DOGPlatform.SVG;
using System.Xml;
using System.Drawing;
using DOGPlatform.XML;

namespace DOGPlatform
{
    class makeLayerMap
    {
        public static  string  generateLayerMap(string filePathLayerOperate)
        {
            //注意偏移量,偏移主要是为了好看 如果不偏移的话 就会绘到角落上,这时的偏移是整个偏移 后面的不用偏移了，相对偏移0，0
        
            //svg文件和XML对应的问题还要思考一下
            string filePathSVGLayerMap = Path.Combine(cProjectManager.dirPathTemp, Path.GetFileNameWithoutExtension(filePathLayerOperate) + ".svg");

            //这块需要处理覆盖问题。
            if (File.Exists(filePathSVGLayerMap)) File.Delete(filePathSVGLayerMap);

            //解析当前的XML配置文件，根据每个Layer标签的LayerType生成id为层名的图层，添加到svgLayer中去

            XmlDocument xmlLayerMap = new XmlDocument();
            xmlLayerMap.Load(filePathLayerOperate);
            //获取基本的页面信息及基础配置文件信息

            //获取井位List
            XmlNodeList xnWellDataList = xmlLayerMap.SelectNodes("/LayerMapConfig/DataDicStatic/data/item");
            List<ItemWellMapPosition> listWellLayerMap = new List<ItemWellMapPosition>();
            foreach (XmlNode xn in xnWellDataList)
            {
                ItemWellMapPosition item = ItemWellMapPosition.parseLine(xn.Attributes["LayerDataDicText"].Value);
                listWellLayerMap.Add(item);
            }

            //根据配置文件，读取页面基本配置信息
            cXELayerPage curPage = new cXELayerPage(xmlLayerMap);
           
            int idx = 50;
            int idy = 50;
            int PageWidth = curPage.iPageWidth;
            int PageHeight = curPage.iPageHeight;
            string sUnit = "mm";
            cSVGDocLayerMap svgLayerMap = new cSVGDocLayerMap(PageWidth, PageHeight, idx, idy, sUnit);
            //add title 
            string sTitle = Path.GetFileNameWithoutExtension(filePathLayerOperate);
            svgLayerMap.addMapTitle(sTitle, PageWidth/2, 20);
            XmlElement returnElemment;

            cXEWellCss wellCss = new cXEWellCss(xmlLayerMap);
        
            //从配置文件中 读取图层列表，根据配置绘制图层
            XmlNode xnLayerList = xmlLayerMap.SelectSingleNode("/LayerMapConfig/LayerList");
            //或许Layer标签的节点
            foreach (XmlNode xn in xnLayerList.ChildNodes)
            {
                string sIDLayer = xn.Attributes["id"].Value;
                string sLayerType = xn.Attributes["layerType"].Value;
                string sLayerVisible = xn["visible"].InnerText; 
                //建立新层
                XmlElement gNewLayer = svgLayerMap.gLayerElement(sIDLayer);
                svgLayerMap.addgLayer(gNewLayer, idx, idy);
                //测井曲线图层
                if (sLayerVisible =="1" && sLayerType == TypeLayer.LayerLog.ToString())
                {
                    LayerDataLog layerDataLog = new LayerDataLog(xn);
                    foreach (ItemWellMapPosition itemWell in listWellLayerMap)
                    {
                        Point PViewWell = cCordinationTransform.transRealPointF2ViewPoint(itemWell.dbX, itemWell.dbY, curPage.xRef, curPage.yRef, curPage.dfscale);
                        returnElemment = cXMLLayerMapWellLog.gLayerWellLog(svgLayerMap, itemWell, layerDataLog); 
                        //新层加内容
                        int xViewStart = PViewWell.X;
                        int yViewStart = PViewWell.Y;
                        //如果左值小于右值，就把曲线坐班绘制
                        if (layerDataLog.iLeftDraw==1) xViewStart = xViewStart - layerDataLog.iTrackWidth;
                        svgLayerMap.addgElement2Layer(gNewLayer, returnElemment, xViewStart, yViewStart);
                    }
                }
                if (sLayerVisible == "1" && sLayerType == TypeLayer.LayerSection.ToString())
                {
                    #region 模板图道,利用模板,导入数据分析。
                    //建立新层
                    XmlElement gWellLayer = svgLayerMap.gLayerElement("LayerSection");
                    svgLayerMap.addgLayer(gWellLayer, 0, 0);
                    for (int i = 0; i < listWellLayerMap.Count; i++)
                    {
                        string sCurJH = listWellLayerMap[i].sJH;
                        string sCurXCM = listWellLayerMap[i].sXCM;
                        string dirLayerJH = Path.Combine(cProjectManager.dirPathLayerDir, sCurXCM,sCurJH);
                        string filePathSecitonTemplatOper = Path.Combine(dirLayerJH, sCurJH + "_" + sCurXCM + ".xml");

                        //斜井模式

                        double fVscaleLayerSection = 1;
                        
                        //cSVGSectionWell currentWell = makePathWell(svgLayerMap,sCurJH, filePathLayerOperate, filePathSecitonTemplatOper,
                        //listWellLayerMap[i].dbTop, listWellLayerMap[i].dbBot, fVscaleLayerSection, curPage);

                  //      makeWellLayerSectionGraph(filePathSecitonTemplatOper, listWellLayerMap[i].dbTop, listWellLayerMap[i].dbBot, fVscaleLayerSection);
                        Point PViewWell = cCordinationTransform.transRealPointF2ViewPoint(listWellLayerMap[i].dbX, listWellLayerMap[i].dbY, curPage.xRef, curPage.yRef, curPage.dfscale);
                        //新层加内容
                        int xViewStart = PViewWell.X;
                        int yViewStart = PViewWell.Y;

                      
                    }

                    #endregion
                
                }
                if (sLayerVisible =="1" && sLayerType == TypeLayer.LayerWellPosition.ToString())
                {
                    XmlNode dataList = xn.SelectSingleNode("dataList");
                   
                    if (dataList != null)
                    {
                        XmlNodeList dataItem = dataList.SelectNodes("dataItem");
                        foreach (XmlNode xnWell in dataItem)
                        {
                            ItemLayerWellPattern itemWell = new ItemLayerWellPattern(xnWell);
                            Point PViewWell = cCordinationTransform.transRealPointF2ViewPoint(itemWell.X, itemWell.Y, curPage.xRef, curPage.yRef, curPage.dfscale);
                            returnElemment = cXMLLayerMapStatic.gWellPattern(svgLayerMap, itemWell, 10, 5, 5, 5, 5);
                      
                            //新层加内容
                            svgLayerMap.addgElement2Layer(gNewLayer, returnElemment, PViewWell.X, PViewWell.Y);
                        }
                    }
                   
                }
                //地质属性数据图层
                //if (sLayerType == TypeLayer.LayerGeoProperty.ToString())
                //    returnElemment = svgLayerMap.gLayerWellsGeologyPropertyFromXML(xn, sIDLayer);
                //水平井图层
                //if (xn.Attributes["LayerType"].Value == TypeLayer.LayerHorizonalInterval.ToString())
                //    returnElemment = svgLayerMap.gHorizonalWellIntervelFromXML(xn, sID);
                ////日产
                //if (xn.Attributes["LayerType"].Value == TypeLayer.LayerDailyProduct.ToString())
                //    returnElemment = svgLayerMap.gDailyProductFromXML(xn, sID, listWellsStatic, listLayersDataCurrentLayerDynamic);
                ////累产饼图图层
                //if (xn.Attributes["LayerType"].Value == TypeLayer.LayerSumProduct.ToString())
                //    returnElemment = svgLayerMap.gSumProductFromXML(xn, sID, listWellsStatic, listLayersDataCurrentLayerDynamic);
                //井位柱状图图层
                //if (xn.Attributes["LayerType"].Value == TypeLayer.LayerBarGraph.ToString())
                //    returnElemment = svgLayerMap.gWellBarGraphFromXML(xn, sID, listWellsStatic);
                //井位饼图图层
                if (sLayerType == TypeLayer.LayerPieGraph.ToString())
                {
                    returnElemment = cXMLLayerMapWellPieGraph.gWellPieGraphFromXML(svgLayerMap.svgDoc, xn, sIDLayer, listWellLayerMap, curPage);
                    //新层加内容
                    svgLayerMap.addgElement2Layer(gNewLayer, returnElemment);
                }
            }

            //add voi
            //if (this.cbxVoi.Checked == true)
            //{
            //    XmlElement gVoronoiLayer = svgLayerMap.gLayerElement("voronoi");
            //    svgLayerMap.addgLayer(gVoronoiLayer, svgLayerMap.offsetX_gSVG, svgLayerMap.offsetY_gSVG);
            //    List<itemWellLayerVoi> listVoi = cIOVoronoi.read2Struct();
            //    foreach (itemWellLayerVoi well in listVoi.FindAll(p => p.sXCM == sSelectLayer))
            //    {
            //        returnElemment = svgLayerMap.gVoronoiPolygon(well.sJH, well.ltdpVertex, "red", 2);
            //        svgLayerMap.addgElement2Layer(gVoronoiLayer, returnElemment);
            //    }
            //}

            //add connect
            //if (this.cbxConnect.Checked == true)
            //{
            //    XmlElement gConnectLayer = svgLayerMap.gLayerElement("Connect");
            //    svgLayerMap.addgLayer(gConnectLayer, 0, 0);
            //    List<ItemConnectInjPro> listConnect = cIODicInjProCon.read2Struct(sSelectYM, sSelectLayer);
            //    foreach (ItemConnectInjPro connect in listConnect)
            //    {
            //        //需要定到层位
            //        ItemWellMapPosition wellInj = listWellsStatic.Find(p => p.sJH == connect.sJHinj);
            //        ItemWellMapPosition wellPro = listWellsStatic.Find(p => p.sJH == connect.sJHpro);
            //        PointD p1 = new PointD(wellInj.dbX, wellInj.dbY);
            //        PointD p2 = new PointD(wellPro.dbX, wellPro.dbY);
            //        returnElemment = svgLayerMap.gConnectLine(p1, p2, "blue", 2);
            //        svgLayerMap.addgElement2Layer(gConnectLayer, returnElemment);
            //    }

            //}

            //由于井位图是底图，造成被压在最下面一层。这个问题要解决一下。
            returnElemment = cSVGLayerWellPosition.gWellsPosition(xmlLayerMap, listWellLayerMap, "井位", wellCss, curPage);
            svgLayerMap.addgElement2BaseLayer(returnElemment);

            if (curPage.iShowScaleRuler == 1)
            {
                XmlElement gLayerScaleRuler = svgLayerMap.gLayerElement("比例尺");
                svgLayerMap.addgLayer(gLayerScaleRuler, svgLayerMap.offsetX_gSVG, svgLayerMap.offsetY_gSVG);
                returnElemment = svgLayerMap.gScaleRuler(0, 0, curPage.dfscale);
                svgLayerMap.addgElement2Layer(gLayerScaleRuler, returnElemment, 100, 100);
            }

            if (curPage.iShowMapFrame == 1)
            {
                returnElemment = svgLayerMap.gMapFrame(true,curPage);
                svgLayerMap.addgElement2BaseLayer(returnElemment);
            }

            if (curPage.iShowCompass == 1)
            {
                XmlElement gLayerCompass = svgLayerMap.gLayerElement("指南针");
                svgLayerMap.addgLayer(gLayerCompass, svgLayerMap.offsetX_gSVG, svgLayerMap.offsetY_gSVG);
                svgLayerMap.addgElement2Layer(gLayerCompass, svgLayerMap.gCompass(300, 100));
            }

        

            svgLayerMap.makeSVGfile(filePathSVGLayerMap);

            return filePathSVGLayerMap;
        }


        public static void makeWellLayerSectionGraph(string filePathTemplatOper, double fTopShow, double fBotShow, double fVScale)
        {
            string filePathWellsvg = filePathTemplatOper.Replace(".xml", ".svg");
            List<int> iListTrackWidth = new List<int>();
            List<string> ListLegend = new List<string>(); //图例
            XmlDocument curDoc = new XmlDocument();
            curDoc.Load(filePathTemplatOper);
            string sJH = cXmlBase.getNodeInnerText(curDoc, cXmlDocSectionWell.fullPathJH);

            string sMapTitle = cXmlBase.getNodeInnerText(curDoc, cXEWellPage.fullPathMapTitle);
            //图幅全部用px基本单位，fVScale已经包含了 px-> 到应用单位的转换。
            double dfDS1Show = fTopShow;
            double dfDS2Show = fBotShow;
            double iDx = 0;

            //这种是上移式图头绘制模式 与 遮盖式图头绘制模式严格位置不同
            double iYpositionTitle = 0;

            double iDy =  -dfDS1Show * fVScale;

            int iShowMode = int.Parse(cXmlBase.getNodeInnerText(curDoc, cXEWellPage.fullPathShowMode));
            double PageWidth = 1000;
            double PageHeight = (dfDS2Show - dfDS1Show) * fVScale  + 20;
            //以上代码执行2毫秒，不必优化了
            cSVGBaseSection cSingleWell = new cSVGBaseSection(PageWidth, PageHeight, iDx, iDy, "px"); //全部用px 单位转换用算法实现
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
                        cSingleWell.addgElement2BaseLayer(returnElemment, iListTrackWidth.Sum(), 0);
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
                                    cSingleWell.addgElement2BaseLayer(returnElemment, iListTrackWidth.Sum(), 0);
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
                                cSingleWell.addgElement2BaseLayer(returnElemment, iListTrackWidth.Sum(), 0);
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
                                cSingleWell.addgElement2BaseLayer(returnElemment, iListTrackWidth.Sum(), 0);
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
                                    cSingleWell.addgElement2BaseLayer(returnElemment, iListTrackWidth.Sum(), 0);
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
                                cSingleWell.addgElement2BaseLayer(returnElemment, iListTrackWidth.Sum(), 0);
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
                                    cSingleWell.addgElement2BaseLayer(returnElemment, iListTrackWidth.Sum(), 0);
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
                                    cSingleWell.addgElement2BaseLayer(returnElemment, iListTrackWidth.Sum(), 0);
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
                                //画曲线
                                returnElemment = cSVGSectionTrackLog.gTrackLog(cSingleWell.svgDoc, curLogHead, curTrackDraw.iTrackWidth, dlTrackDataListLog.fListMD, dlTrackDataListLog.fListValue, fVScale);
                                cSingleWell.addgElement2BaseLayer(returnElemment, iListTrackWidth.Sum(), 0);

                                XmlNode nodeData = xnLog.SelectSingleNode("sData");
                                
                            }//曲线可见

                        }//结束曲线循环
                    } //结束曲线if
                    #endregion 结束曲线道

                  
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
                        }
                    }
                    #endregion
                 

                    //道宽List
                    iListTrackWidth.Add(curTrackDraw.iTrackWidth);
                } //if 是否可见
            }//结束Foreach图道循环绘制
          
      
            cSingleWell.makeSVGfile(filePathWellsvg);
        }

        public static cSVGSectionWell makePathWell(cSVGDocLayerMap svgSection,string sJH, string pathSectionCss, string filePathTemplatOper, double dfDS1Show, double dfDS2Show, double fVScale, cXELayerPage curPage)
        {
            cSVGSectionWell wellGeoSingle = new cSVGSectionWell(svgSection.svgDoc);
            List<int> iListTrackWidth = new List<int>();
            //从配置文件读取显示深度
            //绝对值不放大fvscale，位置放大。
            ItemWell wellItem = cProjectData.ltProjectWell.FirstOrDefault(p => p.sJH == sJH);
            iListTrackWidth.Clear();
            XmlElement returnElemment;

            float dfDS1ShowTVD = cIOinputWellPath.getTVDByJHAndMD(wellItem, (float)dfDS1Show);

            int iYpositionTrackHead =0;

            foreach (XmlElement el_Track in cXmlDocSectionWell.getTrackNodes(filePathTemplatOper))
            {
                //初始化绘制道的基本信息
                trackDataDraw curTrackDraw = new trackDataDraw(el_Track);

                ////增加距离位置节点
                //cXmlDocSectionGeo.addWellTrackXviewNode(pathSectionCss, sJH, curTrackDraw.sTrackID, iListTrackWidth.Sum());
                #region  判断是否可见，可见才绘制
                if (curTrackDraw.iVisible > 0)
                {
                    #region 地层道
                    if (curTrackDraw.sTrackType == TypeTrack.分层.ToString())
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
                                    returnElemment = cSVGSectionTrackLayer.gTrackItemTVDLayer(svgSection.svgDoc, item, fVScale, curTrackDraw.iTrackFontSize, curTrackDraw.iTrackWidth);
                                    wellGeoSingle.addTrack(returnElemment, iListTrackWidth.Sum());
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
                                ItemTrackDrawDataIntervalProperty item = new ItemTrackDrawDataIntervalProperty(xn);
                                if (item.top >= dfDS1Show && item.bot <= dfDS2Show)
                                {
                                    returnElemment = cSVGSectionTrackJSJL.gTrackItemTVDJSJL(svgSection.svgDoc, svgSection.svgDefs, item, fVScale, curTrackDraw.iTrackWidth);
                                    if (curTrackDraw.sTrackType == TypeTrack.沉积旋回.ToString()) returnElemment = cSVGSectionTrackCycle.gTrackItemTVDGeoCycle(svgSection.svgDoc, svgSection.svgDefs, item, fVScale, curTrackDraw.iTrackWidth);
                                    wellGeoSingle.addTrack(returnElemment, iListTrackWidth.Sum());
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
                                if (item.top >= dfDS1Show && item.bot <= dfDS2Show)
                                {
                                    returnElemment = cSVGSectionTrackLitho.gTrackLithoTVDItem(wellItem, svgSection.svgDoc, svgSection.svgDefs, item, fVScale, curTrackDraw.iTrackWidth);
                                    wellGeoSingle.addTrack(returnElemment, iListTrackWidth.Sum());
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
                                //画曲线
                                returnElemment = cSVGSectionTrackLog.gTrackTVDLog(wellItem, svgSection.svgDoc, curLogHead, curTrackDraw.iTrackWidth, dlTrackDataListLog.fListMD, dlTrackDataListLog.fListValue, fVScale);
                                wellGeoSingle.addTrack(returnElemment, iListTrackWidth.Sum());
                      
                            }//曲线可见

                        }//结束曲线循环
                    } //结束曲线if
                    #endregion 结束曲线道
                    iListTrackWidth.Add(curTrackDraw.iTrackWidth);
                }
                #endregion

            } //end of for add track
            return wellGeoSingle;
        }  
    }
}
