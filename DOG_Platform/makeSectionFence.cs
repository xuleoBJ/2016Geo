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
    class makeSectionFence
    {
        public static int iPositionXFirstWell = 200;
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
                //按显示的顶深拉高
                svgSection.addgElement2BaseLayer(currentWell.gWell, listWellsSection[i].fXview, listWellsSection[i].fYview - listWellsSection[i].fShowedDepthTop*curPage.fVscale);
                //加个井位标识
                returnElemment = cSVGSectionWell.gWellHead(svgSection.svgDoc,sJH, listWellsSection[i].fXview, listWellsSection[i].fYview, 18);
                svgSection.addgElement2BaseLayer(returnElemment, 0, 0);
            }

            string fileSVG = Path.Combine(cProjectManager.dirPathTemp, filenameSVGMap);
            svgSection.makeSVGfile(fileSVG);
            return fileSVG;
        }

        //设置well的摆放位置
        public static void setXYPositionViewFence(string pathSectionCss, List<ItemWellSection> listWellsSection)
        {
            float fHScale = float.Parse(cXmlBase.getNodeInnerText(pathSectionCss, cXEGeopage.xmlFullPathPageHorizonWellDistanceScale));
            //设置拉平高度 就是 给 fxview和fyview 赋值
            //第一口井默认位置,乘以水平系数 为了连接层；
            for (int i = 0; i < listWellsSection.Count; i++)
            {
                ItemWellSection itemWell = listWellsSection[i];
                Point headView = cCordinationTransform.transRealPointF2ViewPoint(
                   listWellsSection[i].WellPathList[0].dbX,  listWellsSection[i].WellPathList[0].dbY, cProjectData.dfMapXrealRefer, cProjectData.dfMapYrealRefer, cProjectData.dfMapScale);
                itemWell.fXview = headView.X;
                itemWell.fYview = headView.Y;
            }
        }

        public static void makeNewShowDepth(string pathSectionCss, List<ItemWellSection> listWellsSection)
        {
            List<string> ltStrSelectedXCM = cProjectData.ltStrProjectXCM;
            int _up = 10;
            int _down = 10;
            if (ltStrSelectedXCM.Count > 0)
            {
                //重新给显示的顶底赋值
                foreach (ItemWellSection item in listWellsSection)
                {
                    string sJH = item.sJH;
                    //有可能上下层有缺失。。。所以这块的技巧是找出深度序列，取最大最小值
                    cIOinputLayerDepth fileLayerDepth = new cIOinputLayerDepth();
                    List<float> fListDS1Return = fileLayerDepth.selectDepthListFromLayerDepthByJHAndXCMList(sJH, ltStrSelectedXCM);
                    if (fListDS1Return.Count > 0)  //返回值为空 说明所选层段整个缺失！
                    {
                        item.fShowedDepthTop = fListDS1Return.Min() - _up;
                        item.fShowedDepthBase = fListDS1Return.Max() + _down;
                        cXmlBase.setSelectedNodeChildNodeValue(pathSectionCss, sJH, "fShowTop", item.fShowedDepthTop.ToString("0"));
                        cXmlBase.setSelectedNodeChildNodeValue(pathSectionCss, sJH, "fShowBot", item.fShowedDepthBase.ToString("0"));
                    }
                }//end foreach
            }//end if
        }
        public static cSVGSectionWell makePathWell(cSVGDocSection svgSection, string pathSectionCss, string filePathTemplatOper, double dfDS1Show, double dfDS2Show, float fVScale, cXEGeopage curPage)
        {
            cSVGSectionWell wellGeoSingle = new cSVGSectionWell(svgSection.svgDoc);
            List<int> iListTrackWidth = new List<int>();
            //从配置文件读取显示深度
            string sJH = cXmlBase.getNodeInnerText(filePathTemplatOper, cXmlDocSectionWell.fullPathJH);
            //绝对值不放大fvscale，位置放大。
            ItemWell wellItem = cProjectData.ltProjectWell.FirstOrDefault(p => p.sJH == sJH);
            int iHeightMapTitle = int.Parse(cXmlBase.getNodeInnerText(filePathTemplatOper, cXEWellPage.fullPathMapTitleRectHeight));
            int iHeightTrackHead = int.Parse(cXmlBase.getNodeInnerText(filePathTemplatOper, cXEWellPage.fullPathTrackRectHeight));
            iListTrackWidth.Clear();
            XmlElement returnElemment;

            float dfDS1ShowTVD = cIOinputWellPath.getTVDByJHAndMD(wellItem, (float)dfDS1Show);

            int iYpositionTrackHead = Convert.ToInt16(dfDS1ShowTVD * fVScale) - iHeightTrackHead;

            foreach (XmlElement el_Track in cXmlDocSectionWell.getTrackNodes(filePathTemplatOper))
            {
                //初始化绘制道的基本信息
                trackDataDraw curTrackDraw = new trackDataDraw(el_Track);
                //增加道头
                returnElemment = cSVGSectionTrack.trackHead(svgSection.svgDoc, curTrackDraw.sTrackID, curTrackDraw.sTrackTitle, iYpositionTrackHead, iHeightTrackHead, curTrackDraw.iTrackWidth, curTrackDraw.iTrackHeadFontSize, curTrackDraw.sWriteMode);
                wellGeoSingle.addTrack(returnElemment, iListTrackWidth.Sum());

                //增加距离位置节点
                cXmlDocSectionGeo.addWellTrackXviewNode(pathSectionCss, sJH, curTrackDraw.sTrackID, iListTrackWidth.Sum());
                //先画曲线，再画道头和道框，这样好看
                #region  判断是否可见，可见才绘制
                if (curTrackDraw.iVisible > 0)
                {
                    #region 井深结构尺
                    if (el_Track["trackType"].InnerText == TypeTrack.深度尺.ToString())
                    {
                        itemDrawDataDepthRuler itemRuler = new itemDrawDataDepthRuler(el_Track);
                        //测试斜井gPathWellCone
                        returnElemment = cSVGSectionTrackWellRuler.gPathWellRuler(wellItem, svgSection, Convert.ToInt16(dfDS1Show), Convert.ToInt16(dfDS2Show), fVScale, itemRuler);
                        wellGeoSingle.addTrack(returnElemment, iListTrackWidth.Sum());
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
                                ItemTrackDrawDataIntervalProperty item = new ItemTrackDrawDataIntervalProperty(xn); if (item.top >= dfDS1Show && item.bot <= dfDS2Show)
                                {
                                    returnElemment = cSVGSectionTrackJSJL.gTrackItemTVDJSJL(svgSection.svgDoc, svgSection.svgDefs, item, fVScale, curTrackDraw.iTrackWidth);
                                    if (curTrackDraw.sTrackType == TypeTrack.沉积旋回.ToString()) returnElemment = cSVGSectionTrackCycle.gTrackItemTVDGeoCycle(svgSection.svgDoc, svgSection.svgDefs, item, fVScale, curTrackDraw.iTrackWidth);
                                    //     if (curTrackDraw.sTrackType == TypeTrack.描述.ToString()) returnElemment = cSVGSectionTrackDes.gTrackItemFossil(svgSection.svgDoc, svgSection.svgDefs, item, fVScale, curTrackDraw.iTrackWidth);
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
                                int iHeadLogSize = 14;
                                returnElemment = cSVGSectionTrack.addTrackItemLogHeadInfor(svgSection.svgDoc, curLogHead, iYpositionTrackHead + iHeightTrackHead, iLogNum, curTrackDraw.iTrackWidth, iHeadLogSize);
                                wellGeoSingle.addTrack(returnElemment, iListTrackWidth.Sum());
                            }
                        }
                    }
                    #endregion
                    //绘制道框
                    if (curPage.iShowTrackRect == 1)
                    {
                        returnElemment = cSVGSectionTrack.trackRect(svgSection.svgDoc, curTrackDraw.sTrackID, dfDS1ShowTVD, dfDS2Show, fVScale, curTrackDraw.iTrackWidth);
                        wellGeoSingle.addTrack(returnElemment, iListTrackWidth.Sum());
                    }
                    iListTrackWidth.Add(curTrackDraw.iTrackWidth);
                }
                #endregion

            } //end of for add track
            //增加图头
            returnElemment = wellGeoSingle.mapHeadTitle(sJH, iYpositionTrackHead - iHeightMapTitle, iYpositionTrackHead, iHeightMapTitle, iListTrackWidth.Sum(), iHeightMapTitle * 2 / 3);
            wellGeoSingle.addTrack(returnElemment, 0);
            return wellGeoSingle;
        }  
        

    }
}
