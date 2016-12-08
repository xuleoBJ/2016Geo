using System;
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
        public static  string  generateLayerMap(string filePathOperate)
        {
            //注意偏移量,偏移主要是为了好看 如果不偏移的话 就会绘到角落上,这时的偏移是整个偏移 后面的不用偏移了，相对偏移0，0
        
            //svg文件和XML对应的问题还要思考一下
            string filePathSVGLayerMap = Path.Combine(cProjectManager.dirPathTemp, Path.GetFileNameWithoutExtension(filePathOperate) + ".svg");

            //这块需要处理覆盖问题。
            if (File.Exists(filePathSVGLayerMap)) File.Delete(filePathSVGLayerMap);

            //解析当前的XML配置文件，根据每个Layer标签的LayerType生成id为层名的图层，添加到svgLayer中去

            XmlDocument xmlLayerMap = new XmlDocument();
            xmlLayerMap.Load(filePathOperate);
            //获取基本的页面信息及基础配置文件信息

            //获取井位List
            XmlNodeList xnWellDataList = xmlLayerMap.SelectNodes("/LayerMapConfig/DataDicStatic/data/item");
            List<ItemWellMapPosition> listWellLayerMap = new List<ItemWellMapPosition>();
            foreach (XmlNode xn in xnWellDataList)
            {
                ItemWellMapPosition item = ItemWellMapPosition.parseLine(xn.InnerText);
                listWellLayerMap.Add(item);
            }

            int idx = 50;
            int idy = 50;
            int PageWidth = 1500;
            int PageHeight = 1500;
            string sUnit = "mm";
            cSVGDocLayerMap svgLayerMap = new cSVGDocLayerMap(PageWidth, PageHeight, idx, idy, sUnit);
            //add title 
            string sTitle = Path.GetFileNameWithoutExtension(filePathOperate);
            svgLayerMap.addMapTitle(sTitle, PageWidth/2, 20);
            XmlElement returnElemment;
            //画井位

            cXEWellCss wellCss = new cXEWellCss(xmlLayerMap);
            
            //根据配置文件，读取页面基本配置信息
            cXELayerPage curPage = new cXELayerPage(xmlLayerMap);
           
            //从配置文件中 读取图层列表，根据配置绘制图层
            XmlNode xnLayerList = xmlLayerMap.SelectSingleNode("/LayerMapConfig/LayerList");
            //或许Layer标签的节点
            foreach (XmlNode xn in xnLayerList.ChildNodes)
            {
                string sIDLayer = xn.Attributes["id"].Value;
                string sLayerType = xn.Attributes["layerType"].Value;
                //建立新层
                XmlElement gNewLayer = svgLayerMap.gLayerElement(sIDLayer);
                svgLayerMap.addgLayer(gNewLayer, idx, idy);
                //测井曲线图层
                if (sLayerType == TypeLayer.LayerLog.ToString())
                {
                    LayerDataLog layDataLog = new LayerDataLog(xn);
                    foreach (ItemWellMapPosition itemWell in listWellLayerMap)
                    {
                        Point PViewWell = cCordinationTransform.transRealPointF2ViewPoint(itemWell.dbX, itemWell.dbY, curPage.xRef, curPage.yRef, curPage.dfscale);
                        returnElemment = cXMLLayerMapWellLog.gLayerWellLog(svgLayerMap, itemWell, layDataLog); 
                        //新层加内容
                        svgLayerMap.addgElement2Layer(gNewLayer, returnElemment, PViewWell.X, PViewWell.Y);
                    }
                }
                if (sLayerType == TypeLayer.LayerWellPosition.ToString())
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
                returnElemment = svgLayerMap.gMapFrame(true,curPage.iNumExtendGrid);
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
    }
}
