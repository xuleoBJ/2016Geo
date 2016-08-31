using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Xml.Linq;

namespace DOGPlatform.SVG
{
    class cSVGDocLayerMap : cBaseMapSVG
    {
        public cSVGDocLayerMap(int width, int height, int iDX, int iDY, string sUnit)
            : base(width, height, iDX, iDY, sUnit)
        {

        }
        //set defautl xmlConfigPath 
        public string xmlConfigPath = cProjectManager.filePathLayerCss;
        XmlDocument xmlLayerMap = new XmlDocument();
   
        public void delgWellPosition()
        {
            XmlNode gWells =svgRoot.SelectSingleNode("/svg/g/g[@id='idWell']");
            if (gWells != null) gWells.RemoveAll();
        }

        //解析传入的XML中的井坐标，然后成图
        public XmlElement gWellsPosition( XmlDocument svgDoc)
        {
            delgWellPosition();
            string _JHFontSize = xmlLayerMap.SelectSingleNode("/LayerMapConfig/JHText/fontSize").InnerText;
            int _radis = int.Parse(xmlLayerMap.SelectSingleNode("/LayerMapConfig/BaseLayer/r").InnerText);
            int _iCirlceWidth = int.Parse(xmlLayerMap.SelectSingleNode("/LayerMapConfig/BaseLayer/rLineWidth").InnerText);
            string _DX_JHText = xmlLayerMap.SelectSingleNode("LayerMapConfig/JHText/DX_Text").InnerText;

            XmlElement gWellPositon = svgDoc.CreateElement("g");
            gWellPositon.SetAttribute("id", "井");

            foreach (XmlNode xn in xmlLayerMap.SelectNodes("/LayerMapConfig/BaseLayer/Well"))
            {
                string _data = xn.InnerText;
                ItemWellMapPosition item=ItemWellMapPosition.parseLine(_data);
                Point pointConvert2View = cCordinationTransform.transRealPointF2ViewPoint(item.dbX, item.dbY, xRef, yRef, this.dfscale);
                gWellPositon.AppendChild(gWell( svgDoc,item.sJH, pointConvert2View.X, pointConvert2View.Y, item.iWellType, _JHFontSize, _radis, _iCirlceWidth, _DX_JHText)); 
              
            }
          
            return gWellPositon;
        }


        public XmlElement gWellsPositionFromXML(XmlDocument svgDoc,XmlNode xnLayer, string sID, List<ItemWellMapPosition> listWellLayerMap)
        {
            string _JHFontSize ="12";
            int _radis = 2;
            int _iCirlceWidth = 3;
            string _DX_JHText = "12";
            XmlElement gWellPositon = svgDoc.CreateElement("g");
            gWellPositon.SetAttribute("id", sID);
            foreach (ItemWellMapPosition item in listWellLayerMap)
            {
                Point pointConvert2View = cCordinationTransform.transRealPointF2ViewPoint(item.dbX, item.dbY, xRef, yRef, this.dfscale);
                gWellPositon.AppendChild(gWell(svgDoc,item.sJH, pointConvert2View.X, pointConvert2View.Y, item.iWellType, _JHFontSize, _radis, _iCirlceWidth, _DX_JHText)); 
            }

            return gWellPositon;
        }

        public static XmlElement gWell
            (XmlDocument svgDoc, string sJH, int iXview, int iYview, int iWellType, string _JHFontSize, int _radis, int _iCirlceWidth, string _DX_JHText)
        {

            XmlElement gWell = svgDoc.CreateElement("g");
            gWell.SetAttribute("id", sJH);

            string m_colorWell = "none";
            if (iWellType == 3)
            {
                m_colorWell = "red";
            }
            else if (iWellType == 1)
            {
                XmlElement gWellSymbolUse = svgDoc.CreateElement("use");
                gWellSymbolUse.SetAttribute("x", iXview.ToString());
                gWellSymbolUse.SetAttribute("y", iYview.ToString());
                XmlAttribute WellSymbolNode = svgDoc.CreateAttribute("xlink", "href", "http://www.w3.org/1999/xlink");
                WellSymbolNode.Value = "#" + "idOilGasWellSymbol";
                gWellSymbolUse.Attributes.Append(WellSymbolNode);
                gWell.AppendChild(gWellSymbolUse);
                m_colorWell = "red";
            }
            else if (iWellType == 5)
            {
                m_colorWell = "Gold";
            }
            else if (iWellType == 15)
            {
                XmlElement gWellSymbolUse = svgDoc.CreateElement("use");
                gWellSymbolUse.SetAttribute("x", iXview.ToString());
                gWellSymbolUse.SetAttribute("y", iYview.ToString());
                XmlAttribute WellSymbolNode = svgDoc.CreateAttribute("xlink", "href", "http://www.w3.org/1999/xlink");
                WellSymbolNode.Value = "#" + "InjectWellSymbol";
                gWellSymbolUse.Attributes.Append(WellSymbolNode);
                gWell.AppendChild(gWellSymbolUse);
                m_colorWell = "blue";
            }

            else if (iWellType == 8)
            {
                XmlElement gWellSymbolUse = svgDoc.CreateElement("use");
                gWellSymbolUse.SetAttribute("x", iXview.ToString());
                gWellSymbolUse.SetAttribute("y", iYview.ToString());
                XmlAttribute WellSymbolNode = svgDoc.CreateAttribute("xlink", "href", "http://www.w3.org/1999/xlink");
                WellSymbolNode.Value = "#" + "idPlatformWell";
                gWellSymbolUse.Attributes.Append(WellSymbolNode);
                gWell.AppendChild(gWellSymbolUse);
                m_colorWell = "red";
            }
            else
            {
                m_colorWell = "black";
                XmlElement gWellSymbolInner = svgDoc.CreateElement("circle");
                gWellSymbolInner.SetAttribute("x", iXview.ToString());
                gWellSymbolInner.SetAttribute("y", iYview.ToString());
                gWellSymbolInner.SetAttribute("r", "1.5");
                gWellSymbolInner.SetAttribute("stroke", m_colorWell);
                gWellSymbolInner.SetAttribute("stroke-width", _iCirlceWidth.ToString());
                gWellSymbolInner.SetAttribute("fill", "none");
                gWell.AppendChild(gWellSymbolInner);
               
            }
            XmlElement gWellSymbol = svgDoc.CreateElement("circle");
            gWellSymbol.SetAttribute("cx", iXview.ToString());
            gWellSymbol.SetAttribute("cy", iYview.ToString());
            gWellSymbol.SetAttribute("r", _radis.ToString());
            gWellSymbol.SetAttribute("stroke", m_colorWell);
            gWellSymbol.SetAttribute("stroke-width", _iCirlceWidth.ToString());
            gWellSymbol.SetAttribute("fill", "none");
            gWell.AppendChild(gWellSymbol);

            XmlElement gJHText = svgDoc.CreateElement("text");
            gJHText.SetAttribute("x", (iXview - int.Parse(_DX_JHText)).ToString());
            gJHText.SetAttribute("y", (iYview + int.Parse(_DX_JHText)).ToString());
            gJHText.SetAttribute("font-size", _JHFontSize);
            gJHText.SetAttribute("font-style", "normal");
            gJHText.InnerText = sJH;
            gJHText.SetAttribute("fill", m_colorWell);
            gWell.AppendChild(gJHText); 

            return gWell;
        }


        public List<XmlElement> addgMutiplePolyline(List<int> iListX_FaultSVG, List<int> iListY_FaultSVG, List<string> ltStrFaultName_FaultSVG)
        {
            List<XmlElement> listgPolyline = new List<XmlElement>();
            foreach (string sitem in ltStrFaultName_FaultSVG.Distinct())
            {
                int _indexFirst = ltStrFaultName_FaultSVG.IndexOf(sitem);
                int _count = ltStrFaultName_FaultSVG.LastIndexOf(sitem) - _indexFirst + 1;
                List<int> iCurrentListXFaultscreen = iListX_FaultSVG.GetRange(_indexFirst, _count);
                List<int> iCurrentListYFaultscreen = iListY_FaultSVG.GetRange(_indexFirst, _count);
                listgPolyline.Add(addgSinglePolyline(iCurrentListXFaultscreen, iCurrentListYFaultscreen, "red", 3));
            }

            return listgPolyline;
        }

        public XmlElement gFaultline(List<PointD> ListFaultsLine, string m_Color, int stroke_width)
        {
            List<Point> ListPointView = new List<Point>();

            XmlElement gPolyline = svgDoc.CreateElement("polyline");
            foreach (PointD item in ListFaultsLine)
            {
                Point pointConvert2View = cCordinationTransform.transRealPointF2ViewPoint(item.X, item.Y, xRef, yRef, this.dfscale);
                ListPointView.Add(pointConvert2View);
            }
            gPolyline.SetAttribute("id", "polyline");
            string _points = "";
            for (int i = 0; i < ListPointView.Count; i++)
            {
                _points = _points + ListPointView[i].X.ToString() + ',' + ListPointView[i].Y.ToString() + " ";
            }

            gPolyline.SetAttribute("style", stroke_width.ToString());
            gPolyline.SetAttribute("stroke", m_Color);
            gPolyline.SetAttribute("fill", "none");
            gPolyline.SetAttribute("points", _points);
            return gPolyline;
        }

        public XmlElement gVoronoiPolygon(string sid,List<PointD> ListVoronoiReal, string m_Color, int stroke_width)
        {
            XmlElement gEle = svgDoc.CreateElement("g");
            gEle.SetAttribute("id", "Voi#" + sid);
            if (ListVoronoiReal.Count == 0) return gEle;
            else
            {
                List<Point> ListPointView = new List<Point>();


                XmlElement gPolyline = svgDoc.CreateElement("polygon");
                foreach (PointD item in ListVoronoiReal)
                {
                    Point pointConvert2View = cCordinationTransform.transRealPointF2ViewPoint(item.X, item.Y, xRef, yRef, this.dfscale);
                    ListPointView.Add(pointConvert2View);
                }

                string _points = "";
                for (int i = 0; i < ListPointView.Count; i++)
                {
                    _points = _points + ListPointView[i].X.ToString() + ',' + ListPointView[i].Y.ToString() + " ";
                }
                gPolyline.SetAttribute("style", stroke_width.ToString());
                gPolyline.SetAttribute("stroke", m_Color);
                gPolyline.SetAttribute("fill", "none");
                gPolyline.SetAttribute("points", _points);
                gEle.AppendChild(gPolyline);
                return gEle;
            }
        }
       
        public void delNodeByID(string idPath)
        {
            XmlNode node = svgRoot.SelectSingleNode(idPath);
            if (node != null) node.RemoveAll();
        }

        public XmlElement gLayerWellsGeologyPropertyFromXML(XmlNode xnLayer, string sID)
        {
            string JHFontSize = xnLayer.SelectSingleNode("textFontSize").InnerText;
            string DX_JHText = xnLayer.SelectSingleNode("DX_Text").InnerText;
            string DY_JHText = xnLayer.SelectSingleNode("DY_Text").InnerText;
            XmlElement gWellsProperty = svgDoc.CreateElement("g");
            gWellsProperty.SetAttribute("id", sID);
            string sData = xnLayer.SelectSingleNode("data").InnerText;
            string sFontSize = "6";
            string[] splitData = sData.Split(new char[] { '\r', '\n',' ','\t' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < splitData.Length ; i=i+7)
            {
                string jh = splitData[i];
                Point pointConvert2View = cCordinationTransform.transRealPointF2ViewPoint(
                        double.Parse(splitData[i+1]), double.Parse(splitData[i+2]), xRef, yRef, this.dfscale);
                int iXview = pointConvert2View.X;
                int iYview = pointConvert2View.Y;
                string sDCHD = splitData[i+3];
                string SH = splitData[i+4];
                string sYXHD = splitData[i + 5];
                string STL = splitData[i+6];
                gWellsProperty.AppendChild(gProperty(iXview, iYview, sDCHD, SH, sYXHD, STL, sFontSize));
            }
            return gWellsProperty;
        }

        public XmlElement gProperty( int iXview, int iYview, string sDCHD,string SH,string sYXHD,string STL,string sFontSize)
        {

            XmlElement gWellLayerProperty = svgDoc.CreateElement("g");

            XmlElement gSHText = svgDoc.CreateElement("text");
            gSHText.SetAttribute("x", (iXview + 5).ToString());
            gSHText.SetAttribute("y", (iYview + 6).ToString());
            gSHText.SetAttribute("font-size", sFontSize);
            gSHText.SetAttribute("font-style", "normal");
            gSHText.SetAttribute("fill", "black");
            gWellLayerProperty.AppendChild(gSHText);
            if (float.Parse(sDCHD) > 0)
            {
                gSHText.InnerText = SH;

                XmlElement gYXHDText = svgDoc.CreateElement("text");
                gYXHDText.SetAttribute("x", (iXview +5).ToString());
                gYXHDText.SetAttribute("y", (iYview-1).ToString());
                gYXHDText.SetAttribute("font-size", sFontSize);
                gYXHDText.SetAttribute("font-style", "normal");
               // gYXHDText.SetAttribute("style", "text-decoration: underline;");
                gYXHDText.InnerText =" "+ sYXHD+" ";
                gYXHDText.SetAttribute("fill", "black");
                gWellLayerProperty.AppendChild(gYXHDText);

                XmlElement spliLine = svgDoc.CreateElement("path");
                string d = "M " + (iXview+5).ToString() + " " + iYview.ToString() + "h10" ;
                spliLine.SetAttribute("d", d);
                spliLine.SetAttribute("stroke", "black");
                spliLine.SetAttribute("stroke-width", "0.6");
                spliLine.SetAttribute("fill", "none");
                gWellLayerProperty.AppendChild(spliLine);

                XmlElement gSTLText = svgDoc.CreateElement("text");
                gSTLText.SetAttribute("x", (iXview + 16).ToString());
                gSTLText.SetAttribute("y", (iYview + 2).ToString());
                gSTLText.SetAttribute("font-size", sFontSize);
                gSTLText.SetAttribute("font-style", "normal");
                gSTLText.InnerText = STL;
                gSTLText.SetAttribute("fill", "black");
                gWellLayerProperty.AppendChild(gSTLText);
            }
            else
            {
                gSHText.InnerText = "△";
            }

            return gWellLayerProperty;
        }

        public XmlElement gConnectLine(PointD p1, PointD p2, string sColor,int iStrokeWidth)
        {
            XmlElement gConnect = svgDoc.CreateElement("line");
            gConnect.SetAttribute("id", "gConnect");
            
            Point pView1 = cCordinationTransform.transRealPointF2ViewPoint( p1.X, p1.Y, cProjectData.dfMapXrealRefer, cProjectData.dfMapYrealRefer, cProjectData.dfMapScale);
            Point pView2 = cCordinationTransform.transRealPointF2ViewPoint(p2.X, p2.Y, cProjectData.dfMapXrealRefer, cProjectData.dfMapYrealRefer, cProjectData.dfMapScale);
            gConnect.SetAttribute("x1", pView1.X.ToString());
            gConnect.SetAttribute("y1", pView1.Y.ToString());
            gConnect.SetAttribute("x2", pView2.X.ToString());
            gConnect.SetAttribute("y2", pView2.Y.ToString());
            gConnect.SetAttribute("stroke", sColor);
            gConnect.SetAttribute("stroke-width", iStrokeWidth.ToString());
            gConnect.SetAttribute("marker-end", "url(#markerArrow)");
            return gConnect;
        }

        public XmlElement gHorizonalWellIntervelFromXML(XmlNode xnLayer, string sID)
        {
            string lineColor = xnLayer.SelectSingleNode("lineColor").InnerText;
            string lineWidth =xnLayer.SelectSingleNode("lineWidth").InnerText;

            XmlElement gHorizonalWellIntervel = svgDoc.CreateElement("g");
            gHorizonalWellIntervel.SetAttribute("id", sID);
            // 井号+ 井型 + 井口view坐标 + top view 坐标 + tail view 坐标 
            string sData = xnLayer.SelectSingleNode("data").InnerText;
            int _iNoteFontSize = 8;
            string[] splitData = sData.Split(new char[] { '\r', '\n', ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < splitData.Length; i = i + 7)
            {
                string jh = splitData[i];
                Point headView = cCordinationTransform.transRealPointF2ViewPoint(double.Parse(splitData[i + 2]), double.Parse(splitData[i + 3]), xRef, yRef, this.dfscale);
                Point topView = cCordinationTransform.transRealPointF2ViewPoint(double.Parse(splitData[i + 4]), double.Parse(splitData[i + 5]), cProjectData.dfMapXrealRefer, cProjectData.dfMapYrealRefer, cProjectData.dfMapScale);
                Point tailView = cCordinationTransform.transRealPointF2ViewPoint(double.Parse(splitData[i + 6]), double.Parse(splitData[i + 7]), cProjectData.dfMapXrealRefer, cProjectData.dfMapYrealRefer, cProjectData.dfMapScale);
               
                XmlElement gHorizonWellIntervel = svgDoc.CreateElement("g");
                gHorizonWellIntervel.SetAttribute("id", "idHorizonWellLine");
                gHorizonWellIntervel.SetAttribute("stroke", lineColor);
                XmlElement gLine1 = svgDoc.CreateElement("line");
                gLine1.SetAttribute("x1", headView.X.ToString());
                gLine1.SetAttribute("y1", headView.Y.ToString());
                gLine1.SetAttribute("x2", topView.X.ToString());
                gLine1.SetAttribute("y2", topView.Y.ToString());
                gLine1.SetAttribute("stroke-dasharray", "3");
                gLine1.SetAttribute("stroke-width", lineWidth);
                gHorizonWellIntervel.AppendChild(gLine1);

                XmlElement gLine2 = svgDoc.CreateElement("line");
                gLine2.SetAttribute("x1", topView.X.ToString());
                gLine2.SetAttribute("y1", topView.Y.ToString());
                gLine2.SetAttribute("x2", tailView.X.ToString());
                gLine2.SetAttribute("y2", tailView.Y.ToString());
                gLine2.SetAttribute("stroke-dasharray", "0");
                gLine2.SetAttribute("stroke", lineColor);
                gLine2.SetAttribute("stroke-width", lineWidth);
                gHorizonWellIntervel.AppendChild(gLine2);

                XmlElement gA = svgDoc.CreateElement("text");
                gA.SetAttribute("x", (topView.X + 2).ToString());
                gA.SetAttribute("y", (topView.Y - 2).ToString());
                gA.InnerText = "A";
                gA.SetAttribute("font-size", _iNoteFontSize.ToString());
                gHorizonWellIntervel.AppendChild(gA);

                XmlElement gB = svgDoc.CreateElement("text");
                gB.SetAttribute("x", (tailView.X + 2).ToString());
                gB.SetAttribute("y", (tailView.Y - 2).ToString());
                gB.SetAttribute("font-size", _iNoteFontSize.ToString());
                //gB.SetAttribute("font-style", "normal");
                gB.InnerText = "B";
                //gB.SetAttribute("fill", m_colorWell);
                gHorizonWellIntervel.AppendChild(gB);
            }

        
            return gHorizonalWellIntervel;
        }
        /// <summary>
        /// add horizonalWellInterval 
        /// </summary>
        /// <param name="p0">wellhead view position</param>
        /// <param name="p1">A view position</param>
        /// <param name="p2">B view positon</param>
        /// <returns></returns>
        public XmlElement gHorizonalWellIntervelLine(Point p0, Point p1, Point p2)
        {
            XDocument xeLayerMap = XDocument.Load(this.xmlConfigPath);
            string _sLineWidth = xeLayerMap.Element("LayerMapConfig").Element("HorizonalWell").Element("lineWidth").Value;
            string _sLineColor = xeLayerMap.Element("LayerMapConfig").Element("HorizonalWell").Element("lineColor").Value;
            if (_sLineColor == "") _sLineColor = "black";
            int _iNoteFontSize = 8;

            XmlElement gHorizonWellIntervel = svgDoc.CreateElement("g");
            gHorizonWellIntervel.SetAttribute("id", "idHorizonWellLine");
            gHorizonWellIntervel.SetAttribute("stroke", _sLineColor);
            XmlElement gLine1 = svgDoc.CreateElement("line");
            gLine1.SetAttribute("x1", p0.X.ToString());
            gLine1.SetAttribute("y1", p0.Y.ToString());
            gLine1.SetAttribute("x2", p1.X.ToString());
            gLine1.SetAttribute("y2", p1.Y.ToString());
            gLine1.SetAttribute("stroke-dasharray", "3");
            gLine1.SetAttribute("stroke-width", _sLineWidth);
            gHorizonWellIntervel.AppendChild(gLine1);
          
            XmlElement gLine2 = svgDoc.CreateElement("line");
            gLine2.SetAttribute("x1", p1.X.ToString());
            gLine2.SetAttribute("y1", p1.Y.ToString());
            gLine2.SetAttribute("x2", p2.X.ToString());
            gLine2.SetAttribute("y2", p2.Y.ToString());
            gLine2.SetAttribute("stroke-dasharray", "0");
            gLine2.SetAttribute("stroke", _sLineColor);
            gLine2.SetAttribute("stroke-width", _sLineWidth);
            gHorizonWellIntervel.AppendChild(gLine2);

            XmlElement gA = svgDoc.CreateElement("text");
            gA.SetAttribute("x", (p1.X + 2).ToString());
            gA.SetAttribute("y", (p1.Y - 2).ToString());
            gA.InnerText = "A";
            gA.SetAttribute("font-size", _iNoteFontSize.ToString());
            gHorizonWellIntervel.AppendChild(gA);

            XmlElement gB = svgDoc.CreateElement("text");
            gB.SetAttribute("x", (p2.X + 2).ToString());
            gB.SetAttribute("y", (p2.Y - 2).ToString());
            gB.SetAttribute("font-size", _iNoteFontSize.ToString());
            //gB.SetAttribute("font-style", "normal");
            gB.InnerText = "B";
            //gB.SetAttribute("fill", m_colorWell);
            gHorizonWellIntervel.AppendChild(gB);

            return gHorizonWellIntervel;
        }

        public XmlElement gHorizonalWellIntervelLine(XmlNode horizinalNode)
        {
            string[] splitInnerText = horizinalNode.InnerText.Split();
            Point p0 = new Point(int.Parse(splitInnerText[2]), int.Parse(splitInnerText[3]));
            Point p1 = new Point(int.Parse(splitInnerText[4]), int.Parse(splitInnerText[5]));
            Point p2 = new Point(int.Parse(splitInnerText[6]), int.Parse(splitInnerText[7]));
            return  gHorizonalWellIntervelLine(p0, p1, p2);
        }

        public XmlElement gWellBarGraphFromXML(XmlNode xnLayer, string sID, List<ItemWellMapPosition> ltWellPos)
        {
            float fVscale = float.Parse(xnLayer.SelectSingleNode("fVScale").InnerText);
            List<string> listscolor=xnLayer.SelectSingleNode("sColor").InnerText.Split().ToList();
            int width=int.Parse(xnLayer.SelectSingleNode("fRectWidth").InnerText);
            float fOpacity = float.Parse(xnLayer.SelectSingleNode("fill-opacity").InnerText);

            XmlElement gEleWellGraph = svgDoc.CreateElement("g");
            gEleWellGraph.SetAttribute("id", sID);

            XmlNodeList xnList=xnLayer.SelectNodes("data/item");

            foreach (XmlNode  item in xnList)
            {  
                List<string> listSplitItem=item.InnerText.Split().ToList();
                string jh = listSplitItem[0];
                ItemWellMapPosition itemStaticWellPosi = ltWellPos.Find(p => p.sJH == jh);
                List<float> fListdata = new List<float>();
                for (int i = 1; i < listSplitItem.Count; i++) 
                {
                    fListdata.Add(float.Parse(listSplitItem[i]));
                }
                if (itemStaticWellPosi != null)
                {
                    Point PViewWell = cCordinationTransform.transRealPointF2ViewPoint(itemStaticWellPosi.dbX, itemStaticWellPosi.dbY, xRef, yRef, this.dfscale);
                    //gEleWellGraph.AppendChild(gWellBarGraph(PViewWell, wellValue.fValue, listscolor[0], width, fVscale));
                    gEleWellGraph.AppendChild(gWellBarGraph(PViewWell, fListdata, listscolor, width, fVscale));
                } 
            }
            return gEleWellGraph;
        }

        public XmlElement gDailyProductFromXML(XmlNode xnLayer, string sID, List<ItemWellMapPosition> ltWellPos, List<ItemDicLayerDataDynamic> listItemWellDynamic)
        {
            float fVscale = float.Parse(xnLayer.SelectSingleNode("fVScale").InnerText);
            XmlElement gLayerDaily = svgDoc.CreateElement("g");
            gLayerDaily.SetAttribute("id", sID);
            foreach (ItemDicLayerDataDynamic item in listItemWellDynamic)
            {
                ItemWellMapPosition itemStaticWellPosi = ltWellPos.Find(p => p.sJH == item.sJH);
                if (item.iWellType == (int)TypeWell.Oil) gLayerDaily.AppendChild(addgOilWellProductionRect(itemStaticWellPosi, item, fVscale));
                if (item.iWellType == (int)TypeWell.Injectwater) gLayerDaily.AppendChild(addgWaterWellInjectRect(itemStaticWellPosi, item, fVscale)); 
            }
            return gLayerDaily;
        }

        public XmlElement gSumProductFromXML(XmlNode xnLayer, string sID, List<ItemWellMapPosition> ltWellPos, List<ItemDicLayerDataDynamic> listItemWellDynamic)
        {
            float fR = float.Parse(xnLayer.SelectSingleNode("r").InnerText);
            XmlElement gLayerSum = svgDoc.CreateElement("g");
            gLayerSum.SetAttribute("id", sID);
            foreach (ItemDicLayerDataDynamic item in listItemWellDynamic)
            {
                ItemWellMapPosition itemStaticWellPosi = ltWellPos.Find(p => p.sJH == item.sJH);
                if (item.iWellType == (int)TypeWell.Oil) gLayerSum.AppendChild(addgOilWellProductionPie(itemStaticWellPosi, item, fR));
                if (item.iWellType == (int)TypeWell.Injectwater) gLayerSum.AppendChild(addgWaterWellProductionPie(itemStaticWellPosi, item, fR));
            }
            return gLayerSum;
        }

        public XmlElement gWellBarGraph(ItemWellMapPosition itemWellPos, List<float> ltfValue ,List<string> ltStrColors, float fVscale)
        {
            XmlElement gWellProduct = svgDoc.CreateElement("g");
            gWellProduct.SetAttribute("id", itemWellPos.sJH+"bar");
            Point PViewWell = cCordinationTransform.transRealPointF2ViewPoint(itemWellPos.dbX, itemWellPos.dbY, xRef, yRef, this.dfscale);
            XmlElement gRect = gWellBarGraph(PViewWell, ltfValue, ltStrColors, fVscale);
            gWellProduct.AppendChild(gRect);

            return gWellProduct;
        }

        public XmlElement addgOilWellProductionRect(ItemWellMapPosition itemWellPos, ItemDicLayerDataDynamic itemDicDynamic, float fVscale)
        {
            XmlElement gWellProduct = svgDoc.CreateElement("g");
            gWellProduct.SetAttribute("id", "idWellProductionRect");

            Point PViewWell = cCordinationTransform.transRealPointF2ViewPoint(itemWellPos.dbX, itemWellPos.dbY, xRef, yRef, this.dfscale);
            List<float> fListdata = new List<float>();

            fListdata.Add(itemDicDynamic.fSCTS > 0 ? itemDicDynamic.fYCY / itemDicDynamic.fSCTS : 0);
            fListdata.Add(itemDicDynamic.fSCTS > 0 ? itemDicDynamic.fYCS / itemDicDynamic.fSCTS : 0);
            List<string> ltStrColors = new List<string>();
            ltStrColors.Add("red");
            ltStrColors.Add("blue");
            XmlElement gRect = gWellBarGraph(PViewWell, fListdata, ltStrColors, fVscale);
            gWellProduct.AppendChild(gRect);

            return gWellProduct;
        }

        public XmlElement addgWaterWellInjectRect(ItemWellMapPosition itemWellPos, ItemDicLayerDataDynamic itemDicDynamic, float fVscale)
        {
            XmlElement gWellProduct = svgDoc.CreateElement("g");
            gWellProduct.SetAttribute("id", "idWellProductionRect");

            Point PViewWell = cCordinationTransform.transRealPointF2ViewPoint(itemWellPos.dbX, itemWellPos.dbY, xRef, yRef, this.dfscale);

            float fValue= itemDicDynamic.fSCTS > 0 ? float.Parse((itemDicDynamic.fYZS / itemDicDynamic.fSCTS).ToString("0.0")) : 0;
          
            gWellProduct.AppendChild(gHistogram(PViewWell, fValue, fVscale, "blue"));

            return gWellProduct;
        }

        public XmlElement addgOilWellProductionPie(ItemWellMapPosition itemWellPos,ItemDicLayerDataDynamic itemDicDynamic,float fscaleR)
        {
            XmlElement gWellProductionPie = svgDoc.CreateElement("g");
            gWellProductionPie.SetAttribute("id", "idWellProductionPie");

            Point PViewWell = cCordinationTransform.transRealPointF2ViewPoint(itemWellPos.dbX, itemWellPos.dbY, xRef, yRef, this.dfscale);
            List<float> fListdata = new List<float>();
         
             fListdata.Add(itemDicDynamic.fSCTS>0?itemDicDynamic.fYCY/itemDicDynamic.fSCTS:0);
             fListdata.Add(itemDicDynamic.fSCTS > 0 ? itemDicDynamic.fYCS / itemDicDynamic.fSCTS : 0);
            List<string> ltStrColors = new List<string>();
            ltStrColors.Add("red");
            ltStrColors.Add("blue");
            gWellProductionPie.AppendChild(gWellPie(PViewWell, fListdata, ltStrColors, fscaleR)); 
          
            return gWellProductionPie;
        }

        public XmlElement addgWaterWellProductionPie(ItemWellMapPosition itemWellPos,ItemDicLayerDataDynamic itemDicDynamic,float fscaleR)
        {
            XmlElement gWellProductionPie = svgDoc.CreateElement("g");
            gWellProductionPie.SetAttribute("id", "idWellInjectPie");
            Point pViewWell = cCordinationTransform.transRealPointF2ViewPoint(itemWellPos.dbX, itemWellPos.dbY, xRef, yRef, this.dfscale);

            float fValue =itemDicDynamic.fLZS ;

            gWellProductionPie.AppendChild(gValueCircle(pViewWell, fValue, fscaleR, "blue"));

            return gWellProductionPie; 
        } 
      

    }
}
