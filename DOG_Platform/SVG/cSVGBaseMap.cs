#region << 版 本 注 释 >>
/*
 * ========================================================================
 * Copyright(c) 2014 Xuleo,Riped, All Rights Reserved.
 * ========================================================================
 *  许磊，联系电话13581625021，qq：38643987

 * ========================================================================
*/
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;
using DOGPlatform.XML;
using DOGPlatform.SVG;

namespace DOGPlatform.SVG
{
    class cBaseMapSVG:cSVGBase
    {
        public double xRef = 0.0;
        public double yRef = 0.0;
        public float dfscale = 1.0f;


        public cBaseMapSVG( int iDX, int iDY)
            : this(2000, 1500, iDX, iDY,"pt")
        {
        }
        public cBaseMapSVG(int width,int height, int iDX, int iDY)
            : this(width, height, iDX, iDY,"pt")
        {

        }
        public cBaseMapSVG( int width, int height, int iDX, int iDY, string sUnit)
            : base(width, height, iDX, iDY, sUnit)
        {
            addDef();
        }

        void addDef()
        {
            addArrowMarkerDefs();
            addInjectWellSymbolDefs();
            addDrillingPatternDefs();
            addPlatformWellSymbolDefs();
            addOilGasWellSymbolDefs();
        }

        public XmlElement gWellCircle(Point pWell, int r, string fillColor)
        {
            XmlElement gWellSymbol = svgDoc.CreateElement("circle");
            gWellSymbol.SetAttribute("cx", pWell.X.ToString());
            gWellSymbol.SetAttribute("cy", pWell.Y.ToString());
            gWellSymbol.SetAttribute("r", r.ToString());
            gWellSymbol.SetAttribute("stroke", "black");
            gWellSymbol.SetAttribute("stroke-width", "0.1");
            gWellSymbol.SetAttribute("fill", fillColor);
            return gWellSymbol;
        }
        public XmlElement gWellCircle(XmlDocument svgDoc, int cx, int cy, int r, string fillColor)
        { 
            return gWellCircle( svgDoc,cx, cy, r, fillColor,1.0f);
        }
        public XmlElement gWellCircle(XmlDocument svgDoc, int cx, int cy, int r, string fillColor, float fCircleLineWidth)
        {
            XmlElement gWellSymbol = svgDoc.CreateElement("circle");
            gWellSymbol.SetAttribute("cx", cx.ToString());
            gWellSymbol.SetAttribute("cy", cy.ToString());
            gWellSymbol.SetAttribute("r", r.ToString());
            gWellSymbol.SetAttribute("stroke", fillColor);
            gWellSymbol.SetAttribute("stroke-width", fCircleLineWidth.ToString());
            gWellSymbol.SetAttribute("fill", "none");
            return gWellSymbol;
        }

        public void addArrowMarkerDefs()
        {
            XmlElement gMarker = svgDoc.CreateElement("marker");
            gMarker.SetAttribute("id", "markerArrow");

            gMarker.SetAttribute("markerWidth", "13");
            gMarker.SetAttribute("markerHeight", "13");
            gMarker.SetAttribute("refx", "2");
            gMarker.SetAttribute("refy", "6");
            gMarker.SetAttribute("orient", "auto");

            XmlElement gMakerPath = svgDoc.CreateElement("path");
            gMakerPath.SetAttribute("d", "M2,2 L2,11 L10,6 L2,2");
            gMakerPath.SetAttribute("fill", "blue");
            gMakerPath.SetAttribute("stroke", "blue");
            gMakerPath.SetAttribute("style", "stroke-width:1");

            gMarker.AppendChild(gMakerPath);
            svgDefs.AppendChild(gMarker);
        }

        public void addInjectWellSymbolDefs()
        {
            XmlElement gWater = svgDoc.CreateElement("g");
            gWater.SetAttribute("id", "InjectWellSymbol");

            //XmlElement gCircle = svgDoc.CreateElement("circle");
            //gCircle.SetAttribute("cx", "0");
            //gCircle.SetAttribute("cy", "0");
            //gCircle.SetAttribute("r", "3");
            //gCircle.SetAttribute("stroke", "blue");
            //gCircle.SetAttribute("style", "stroke-width:1");
            //gCircle.SetAttribute("fill", "none");
            //gWater.AppendChild(gCircle);

            XmlElement path = svgDoc.CreateElement("path");
            path.SetAttribute("d", "M -6 6 h3 h-3 v-3 z  ");
            path.SetAttribute("fill", "blue");
            path.SetAttribute("stroke", "blue");
            path.SetAttribute("style", "stroke-width:1");
            gWater.AppendChild(path);
            XmlElement pathLine = svgDoc.CreateElement("path");
            pathLine.SetAttribute("d", "M -6 6 L6,-6  ");
            pathLine.SetAttribute("fill", "blue");
            pathLine.SetAttribute("stroke", "blue");
            pathLine.SetAttribute("style", "stroke-width:1");
            gWater.AppendChild(pathLine);
            svgDefs.AppendChild(gWater);
        }
        public void addOilGasWellSymbolDefs()
        {
            XmlElement gOilGasWell = svgDoc.CreateElement("g");
            gOilGasWell.SetAttribute("id", "idOilGasWellSymbol");

            XmlElement gCircle = svgDoc.CreateElement("circle");
            gCircle.SetAttribute("cx", "0");
            gCircle.SetAttribute("cy", "0");
            gCircle.SetAttribute("r", "3");
            gCircle.SetAttribute("stroke", "blue");
            gCircle.SetAttribute("style", "stroke-width:1");
            gCircle.SetAttribute("fill", "yellow");
            gOilGasWell.AppendChild(gCircle);

            XmlElement path = svgDoc.CreateElement("path");
            path.SetAttribute("d", "M0 0 h3 A0,0 0 0,1 -3 0 z  ");
            path.SetAttribute("fill", "red");
            path.SetAttribute("stroke", "red");
            path.SetAttribute("style", "stroke-width:1");
            gOilGasWell.AppendChild(path);
            svgDefs.AppendChild(gOilGasWell);
        }
        public void addPlatformWellSymbolDefs()
        {
            XmlElement gPlatformWell = svgDoc.CreateElement("g");
            gPlatformWell.SetAttribute("id", "idPlatformWell");

            XmlElement gRect = svgDoc.CreateElement("rect");
            gRect.SetAttribute("x", "0");
            gRect.SetAttribute("y", "0");
            gRect.SetAttribute("height", "5");
            gRect.SetAttribute("width", "5");
            gRect.SetAttribute("stroke", "red");
            gRect.SetAttribute("style", "stroke-width:1");
            gRect.SetAttribute("fill", "none");
            gPlatformWell.AppendChild(gRect);

            svgDefs.AppendChild(gPlatformWell);
        }
        public void addDrillingPatternDefs()
        {

            XmlElement drillingSymble = svgDoc.CreateElement("pattern");
            drillingSymble.SetAttribute("id", "idDrillingPattern");
            drillingSymble.SetAttribute("patternUnits", "userSpaceOnUse");
            drillingSymble.SetAttribute("x", "0");
            drillingSymble.SetAttribute("y", "0");
            //drillingSymble.SetAttribute("width", "70");
            //drillingSymble.SetAttribute("height", "70");
            //drillingSymble.SetAttribute("viewBox", "0 0 70 70");


            XmlElement drillingPicture = svgDoc.CreateElement("imageDrilling");
            drillingPicture.SetAttribute("x", "0");
            drillingPicture.SetAttribute("y", "0");
            //drillingPicture.SetAttribute("height", "70");
            //drillingPicture.SetAttribute("width", "70");
            XmlAttribute WellSymbol = svgDoc.CreateAttribute("xlink", "href", "http://www.w3.org/1999/xlink");
            WellSymbol.Value = "testOil.png";
            drillingPicture.Attributes.Append(WellSymbol);
            drillingSymble.AppendChild(drillingPicture);

            svgDefs.AppendChild(drillingSymble);
        }
        public XmlElement gScaleRuler(int iDx, int iDY, double m_scale)
        {
            XmlElement gScaleRuler = svgDoc.CreateElement("g");
            string sTranslate = "translate(" + iDx.ToString() + "," + iDY.ToString() + ")";
            gScaleRuler.SetAttribute("transform", sTranslate);
            gScaleRuler.SetAttribute("id", "比例尺");
            double _sacleUnit = 1000.0 * m_scale;
       
            //黑白比例尺
            for (int i = 0; i < 4; i++)
            {
                XmlElement gRect = svgDoc.CreateElement("rect");
                gRect.SetAttribute("x", (_sacleUnit * 0.25 * i).ToString());
                gRect.SetAttribute("y", "0");
                gRect.SetAttribute("width", (_sacleUnit * 0.25).ToString());
                gRect.SetAttribute("height", "2");
                if (i % 2 == 0) gRect.SetAttribute("fill", "black");
                if (i % 2 == 1) gRect.SetAttribute("fill", "none");
                gRect.SetAttribute("stroke-width", "1");
                gRect.SetAttribute("stroke", "black");
                gScaleRuler.AppendChild(gRect);
            }

            //比例尺tick
            for (int i = 0; i < 5; i++)
            {
                XmlElement gLine = svgDoc.CreateElement("line");
                gLine.SetAttribute("x1", (_sacleUnit * 0.25 * i).ToString());
                gLine.SetAttribute("y1", "0");
                gLine.SetAttribute("x2", (_sacleUnit * 0.25 * i).ToString());
                gLine.SetAttribute("y2", "-3");
                gLine.SetAttribute("stroke", "black");
                gLine.SetAttribute("stroke-width", "1");
                gScaleRuler.AppendChild(gLine);
            }

            //比例尺文字
            for (int i = 0; i < 2; i++)
            {
                XmlElement gText = svgDoc.CreateElement("text");
                gText.SetAttribute("x", (_sacleUnit * i - 5).ToString());
                gText.SetAttribute("y", "-4");
                gText.SetAttribute("font-size", "8");
                gText.InnerText = (1000 * i).ToString() + "m";
                gText.SetAttribute("fill", "black");
                gScaleRuler.AppendChild(gText);
            }

            return gScaleRuler;
        }

        // iNumExpandGrid是扩编的网格，网格算法取井位置最大和最小值作为区域，为了显示美观， 
        public XmlElement gMapFrame(bool bShowGrid,cXELayerPage curPage)
        {
            XmlElement gMapFrame = svgDoc.CreateElement("g");
            gMapFrame.SetAttribute("id", "图框");
            List<string> ltStrWellName = new List<string>();
            List<double> dfListX = new List<double>();
            List<double> dfListY = new List<double>();
            List<float> fListKB = new List<float>();
            List<int> iListWellType = new List<int>();

            string[] split;
            try
            {
                using (StreamReader sr = new StreamReader(cProjectManager.filePathInputWellhead, System.Text.Encoding.UTF8))
                {
                    String line;
                    while ((line = sr.ReadLine()) != null) //delete the line whose legth is 0
                    {
                        split = line.Trim().Split(new char[] { ' ', '\t', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
                        ltStrWellName.Add(split[0]);
                        dfListX.Add(double.Parse(split[1]));
                        dfListY.Add(double.Parse(split[2]));
                        fListKB.Add(float.Parse(split[3]));
                        iListWellType.Add(int.Parse(split[4]));
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            float dfscale = this.dfscale;
            double xMax = dfListX.Max() - dfListX.Min();
            double yMax = dfListY.Max() - dfListY.Min();
            int iSacleUnit = 500; //定义网格单位
            int iPanelWidth = Convert.ToInt32((int)(xMax / iSacleUnit + curPage.iNumExtendGrid) * iSacleUnit * curPage.dfscale);
            int iPanelHeight = Convert.ToInt32((int)(yMax / iSacleUnit + curPage.iNumExtendGrid) * iSacleUnit * curPage.dfscale);
            XmlElement gRectInner = svgDoc.CreateElement("rect");
            gRectInner.SetAttribute("x", "0");
            gRectInner.SetAttribute("y", "0");
            gRectInner.SetAttribute("width", iPanelWidth.ToString());
            gRectInner.SetAttribute("height", iPanelHeight.ToString());
            gRectInner.SetAttribute("fill", "none");
            gRectInner.SetAttribute("stroke-width", "1");
            gRectInner.SetAttribute("stroke", "black");
            gMapFrame.AppendChild(gRectInner);
            XmlElement gRectOuter = svgDoc.CreateElement("rect");
            int iDistance = 10;//定义内外框距离
            gRectOuter.SetAttribute("x", (-iDistance).ToString());
            gRectOuter.SetAttribute("y", (-iDistance).ToString());
            gRectOuter.SetAttribute("width", (iPanelWidth + iDistance*2).ToString());
            gRectOuter.SetAttribute("height", (iPanelHeight + iDistance * 2).ToString());
            gRectOuter.SetAttribute("fill", "none");
            gRectOuter.SetAttribute("stroke-width", "2");
            gRectOuter.SetAttribute("stroke", "black");
            gMapFrame.AppendChild(gRectOuter);


            XmlElement gGridLine = svgDoc.CreateElement("g");
            gGridLine.SetAttribute("id", "网格线");
            gGridLine.SetAttribute("stroke", "black");
            gGridLine.SetAttribute("style", "stroke-width:0.5");
            gGridLine.SetAttribute("fill", "none");
            gGridLine.SetAttribute("fill-opacity", "0.8");

            XmlElement gGridText = svgDoc.CreateElement("g");
            gGridText.SetAttribute("id", "idRulerTextBig");
            gGridText.SetAttribute("font-size", "8");
            gGridText.SetAttribute("font-style", "normal");
            gGridText.SetAttribute("fill", "black");

            XmlElement gGridText2 = svgDoc.CreateElement("g");
            gGridText2.SetAttribute("id", "idRulerTextSmall");
            gGridText2.SetAttribute("font-size", "6");
            gGridText2.SetAttribute("font-style", "normal");
            gGridText2.SetAttribute("fill", "black");

            for (int i = 1; i * iSacleUnit * curPage.dfscale<= iPanelWidth; i++)
            {
                int iXCurrentView = Convert.ToInt32(i * 500 * curPage.dfscale);
                Point point1 = new Point(iXCurrentView, 0);
                Point point2;
                if (bShowGrid == true) point2 = new Point(iXCurrentView, iPanelHeight);
                else point2 = new Point(iXCurrentView, iDistance);

                XmlElement gLine = svgDoc.CreateElement("line");
                gLine.SetAttribute("x1", point1.X.ToString());
                gLine.SetAttribute("y1", (point1.Y - iDistance).ToString());
                gLine.SetAttribute("x2", point2.X.ToString());
                gLine.SetAttribute("y2", (point2.Y+iDistance).ToString());
                gGridLine.AppendChild(gLine);

                //应该写的数值是 cProject.dfMapXrealRefer + i * 500
                XmlElement gXText = svgDoc.CreateElement("text");
                gXText.SetAttribute("x", (iXCurrentView - 13).ToString());
                gXText.SetAttribute("y", "-1");
                gXText.InnerText = ((cProjectData.dfMapXrealRefer + i * 500)/100000).ToString("0");
                gGridText.AppendChild(gXText);

                XmlElement gXText2 = svgDoc.CreateElement("text");
                gXText2.SetAttribute("x", (iXCurrentView+2).ToString());
                gXText2.SetAttribute("y", "-1");
                gXText2.InnerText = (((cProjectData.dfMapXrealRefer + i * 500)%100000)/100).ToString("0");
                gGridText2.AppendChild(gXText2);

                XmlElement gXTextDown = svgDoc.CreateElement("text");
                gXTextDown.SetAttribute("x", (iXCurrentView - 13).ToString());
                gXTextDown.SetAttribute("y", (point2.Y + 7).ToString());
                gXTextDown.InnerText = ((cProjectData.dfMapXrealRefer + i * 500) / 100000).ToString("0");
                gGridText.AppendChild(gXTextDown);

                XmlElement gXText2Down = svgDoc.CreateElement("text");
                gXText2Down.SetAttribute("x", (iXCurrentView + 2).ToString());
                gXText2Down.SetAttribute("y", (point2.Y + 7).ToString());
                gXText2Down.InnerText = (((cProjectData.dfMapXrealRefer + i * 500) % 100000) / 100).ToString("0");
                gGridText2.AppendChild(gXText2Down);

            }

            //应该写的数值是 cProject.dfMapXrealRefer + i * 500
            for (int i = 1; i * iSacleUnit * curPage.dfscale<= iPanelHeight; i++)
            {
                int iYCurrentView = Convert.ToInt32(i * 500 * curPage.dfscale);
                Point point3 = new Point(0, iYCurrentView);
                Point point4;
                if (bShowGrid == true) point4 = new Point(iPanelWidth, iYCurrentView);
                else point4 = new Point(iDistance, iYCurrentView);
                XmlElement gLine = svgDoc.CreateElement("line");
                gLine.SetAttribute("x1", (point3.X - iDistance).ToString());
                gLine.SetAttribute("y1", point3.Y.ToString());
                gLine.SetAttribute("x2", (point4.X+ iDistance).ToString());
                gLine.SetAttribute("y2", point4.Y.ToString());
                gGridLine.AppendChild(gLine);

                XmlElement gYText = svgDoc.CreateElement("text");
                gYText.SetAttribute("x", (-iDistance+1).ToString());
                gYText.SetAttribute("y", (iYCurrentView-1).ToString());
                gYText.InnerText = ((cProjectData.dfMapYrealRefer - i * 500)/100000).ToString("0");
                gGridText.AppendChild(gYText);

                XmlElement gYText2= svgDoc.CreateElement("text");
                gYText2.SetAttribute("x", (-iDistance + 1).ToString());
                gYText2.SetAttribute("y", (iYCurrentView+5).ToString());
                gYText2.InnerText = (((cProjectData.dfMapYrealRefer - i * 500) %100000)/100).ToString("0");
                gGridText2.AppendChild(gYText2);

                XmlElement gXTextRight = svgDoc.CreateElement("text");
                gXTextRight.SetAttribute("x", point4.X .ToString());
                gXTextRight.SetAttribute("y", (iYCurrentView - 1).ToString());
                gXTextRight.InnerText = ((cProjectData.dfMapYrealRefer - i * 500) / 100000).ToString("0");
                gGridText.AppendChild(gXTextRight);

                XmlElement gXText2Right = svgDoc.CreateElement("text");
                gXText2Right.SetAttribute("x", point4.X .ToString());
                gXText2Right.SetAttribute("y", (iYCurrentView + 5).ToString());
                gXText2Right.InnerText = (((cProjectData.dfMapYrealRefer - i * 500) % 100000) / 100).ToString("0");
                gGridText2.AppendChild(gXText2Right);

            }

            gMapFrame.AppendChild(gGridLine);
            gMapFrame.AppendChild(gGridText);
            gMapFrame.AppendChild(gGridText2);
            return gMapFrame;
        }

        public XmlElement gCompass(int iDx, int iDY)
        {
            XmlElement gCompass = svgDoc.CreateElement("g");
            string sTranslate = "translate(" + iDx.ToString() + "," + iDY.ToString() + ")";
            gCompass.SetAttribute("transform", sTranslate);
            gCompass.SetAttribute("id", "idCompass");
            XmlElement gPolygon1 = svgDoc.CreateElement("polygon");
            gPolygon1.SetAttribute("points", "16,0 32,50 0,50");
            gPolygon1.SetAttribute("fill", "black");
            gPolygon1.SetAttribute("stroke", "black");
            gPolygon1.SetAttribute("stroke-width", "1");
            gCompass.AppendChild(gPolygon1);

            XmlElement gPolygon2 = svgDoc.CreateElement("polygon");
            gPolygon2.SetAttribute("points", "16,100 32,50 0,50");
            gPolygon2.SetAttribute("fill", "none");
            gPolygon2.SetAttribute("stroke", "black");
            gPolygon2.SetAttribute("stroke-width", "1");
            gCompass.AppendChild(gPolygon2);
            XmlElement gText1 = svgDoc.CreateElement("text");
            gText1.SetAttribute("x", "12");
            gText1.SetAttribute("y", "-6");
            gText1.SetAttribute("font-size", "16");
            gText1.InnerText = "N";
            gText1.SetAttribute("stroke", "black");
            gCompass.AppendChild(gText1);
            XmlElement gText2 = svgDoc.CreateElement("text");
            gText2.SetAttribute("x", "12");
            gText2.SetAttribute("y", "118");
            gText2.SetAttribute("font-size", "16");
            gText2.InnerText = "S";
            gText2.SetAttribute("stroke", "black");
            gCompass.AppendChild(gText2);

            return gCompass;

        }

        public XmlElement addgRoseMap()
        {
            XmlElement gRoseMap = svgDoc.CreateElement("g");
            gRoseMap.SetAttribute("ID", "idRoseMap");

            int x0 = 0;
            int y0 = 0;
            int r = 100;
            XmlElement gMainCircle = svgDoc.CreateElement("circle");
            gMainCircle.SetAttribute("cx", x0.ToString());
            gMainCircle.SetAttribute("cy", y0.ToString());
            gMainCircle.SetAttribute("r", r.ToString());
            gMainCircle.SetAttribute("stroke", "black");
            gMainCircle.SetAttribute("stroke-width", "0.1");
            gMainCircle.SetAttribute("fill", "none");
            gRoseMap.AppendChild(gMainCircle);

            XmlElement gMainCrossPath = svgDoc.CreateElement("path");
            string d = "M " + x0.ToString() + " " + y0.ToString() + "h -" + r.ToString()
                + "h " + (2 * r).ToString() + "h -" + r.ToString() + "v -" + r.ToString() + "v" + (2 * r).ToString();
            gMainCrossPath.SetAttribute("d", d);
            gMainCrossPath.SetAttribute("fill", "none");
            gMainCrossPath.SetAttribute("stroke-width", "0.1");
            gMainCrossPath.SetAttribute("stroke", "red");
            gRoseMap.AppendChild(gMainCrossPath);



            int r1 = r + 2;
            int r2 = r - 2;
            for (int i = 1; i <= 36; i++)
            {
                double dgree = (2 * Math.PI) * i / 36.0;
                double x1 = x0 + r1 * Math.Sin(dgree);
                double y1 = y0 + r1 * Math.Cos(dgree);
                double x2 = x0 + r2 * Math.Sin(dgree);
                double y2 = y0 + r2 * Math.Cos(dgree);
                XmlElement gLine = svgDoc.CreateElement("line");
                gLine.SetAttribute("x1", x1.ToString());
                gLine.SetAttribute("y1", y1.ToString());
                gLine.SetAttribute("x2", x2.ToString());
                gLine.SetAttribute("y2", y2.ToString());
                gLine.SetAttribute("stroke", "red");
                gLine.SetAttribute("stroke-width", "0.3");
                gRoseMap.AppendChild(gLine);


                double xText = x0 + (r + 5) * Math.Sin(dgree) - 3;
                double yText = y0 - (r + 5) * Math.Cos(dgree) + 2;
                XmlElement gText = svgDoc.CreateElement("text");
                gText.SetAttribute("x", xText.ToString());
                gText.SetAttribute("y", yText.ToString());
                gText.SetAttribute("font-size", "5");
                gText.InnerText = (10 * i).ToString();
                gText.SetAttribute("font-family", "Arial");
                gText.SetAttribute("stroke", "none");
                gLine.SetAttribute("stroke-width", "0.1");
                gText.SetAttribute("fill", "black");
                gRoseMap.AppendChild(gText);
            }

            return gRoseMap;

        }
        public XmlElement addgSinglePolyline(List<int> iListViewX, List<int> iListViewY, string m_Color, int stroke_width)
        {
            XmlElement gPolyline = svgDoc.CreateElement("polyline");
            gPolyline.SetAttribute("ID", "polyline");
            string _points = "";
            for (int i = 0; i < iListViewX.Count; i++)
            {
                _points = _points + iListViewX[i].ToString() + ',' + iListViewY[i].ToString() + " ";
            }

            gPolyline.SetAttribute("style", stroke_width.ToString());
            gPolyline.SetAttribute("stroke", m_Color);
            gPolyline.SetAttribute("fill", "none");
            gPolyline.SetAttribute("points", _points);
            return gPolyline;
        }

        public void addBodysandBodyPatternDefs()
        {

            XmlElement sandBodyPattern = svgDoc.CreateElement("pattern");
            sandBodyPattern.SetAttribute("id", "SandBody");
            sandBodyPattern.SetAttribute("patternUnits", "userSpaceOnUse");
            sandBodyPattern.SetAttribute("x", "0");
            sandBodyPattern.SetAttribute("y", "0");
            sandBodyPattern.SetAttribute("width", "7");
            sandBodyPattern.SetAttribute("height", "7");
            sandBodyPattern.SetAttribute("viewBox", "0 0 7 7");
            XmlElement gSandCircle = svgDoc.CreateElement("circle");
            gSandCircle.SetAttribute("cx", "2.5");
            gSandCircle.SetAttribute("cy", "2.5");
            gSandCircle.SetAttribute("r", "0.5");
            //gSandCircle.SetAttribute("stroke", "black");
            //gSandCircle.SetAttribute("style", "stroke-width:0.1");
            gSandCircle.SetAttribute("fill", "yellow");
            sandBodyPattern.AppendChild(gSandCircle);
            svgDefs.AppendChild(sandBodyPattern);
        }
        
        public XmlElement MarkerArrow(float m_scale)
        {
            XmlElement markerArrow = svgDoc.CreateElement("marker");
            markerArrow.SetAttribute("id", "idArrow");
            markerArrow.SetAttribute("viewBox", "0 0 20 20");
            markerArrow.SetAttribute("refX", "0");
            markerArrow.SetAttribute("refY", "10");
            markerArrow.SetAttribute("markerUnits", "strokeWidth");
            markerArrow.SetAttribute("markerWidth", "3");
            markerArrow.SetAttribute("markerHeight", "10");
            markerArrow.SetAttribute("orient", "auto");

            XmlElement path = svgDoc.CreateElement("path");
            path.SetAttribute("d", "M 0 0 L 20 10 L 0 20 z");
            path.SetAttribute("fill", "purple");
            path.SetAttribute("stroke", "black");
            return markerArrow;
        }

        public XmlElement addgPie(Point PViewWell, List<float> fListdata,  List<string> ltStrColors)
        {

            XmlElement gPie = svgDoc.CreateElement("g");
            // Add up the data values so we know how big the pie is
            float total = fListdata.Sum();
            // Now figure out how big each slice of pie is. Angles in radians.
            List<double> angles = new List<double>();
            for (int i = 0; i < fListdata.Count; i++)
                angles.Add(fListdata[i] / total * Math.PI * 2);

            int r = Convert.ToInt16(Math.Sqrt(total / Math.PI));
            int cx = PViewWell.X;
            int cy = PViewWell.Y;
            // Loop through each slice of pie.
            
            if (r > 0)
            {
                double startangle = 0;
                for (int i = 0; i < fListdata.Count; i++)
                {
                    // This is where the wedge ends
                    double endangle = startangle + angles[i];

                    // Compute the two points where our wedge intersects the circle
                    // These formulas are chosen so that an angle of 0 is at 12 o'clock
                    // and positive angles increase clockwise.
                    var x1 = cx + r * Math.Sin(startangle);
                    var y1 = cy - r * Math.Cos(startangle);
                    var x2 = cx + r * Math.Sin(endangle);
                    var y2 = cy - r * Math.Cos(endangle);

                    // This is a flag for angles larger than than a half circle
                    // It is required by the SVG arc drawing component
                    var big = 0;
                    if (endangle - startangle > Math.PI) big = 1;

                    // We describe a wedge with an <svg:path> element

                    XmlElement gPath = svgDoc.CreateElement("path");
                    // This string holds the path details
                    string d = "M " + cx + "," + cy +  // Start at circle center
                        " L " + x1 + "," + y1 +     // Draw line to (x1,y1)
                        " A " + r + "," + r +       // Draw an arc of radius r
                        " 0 " + big + " 1 " +       // Arc details...
                        x2 + "," + y2 +             // Arc goes to to (x2,y2)
                        " Z";                       // Close path back to (cx,cy)

                    // Now set attributes on the <svg:path> element
                    gPath.SetAttribute("d", d);              // Set this path 
                    gPath.SetAttribute("fill", ltStrColors[i]);   // Set wedge color
                    gPath.SetAttribute("stroke", "black");   // Outline wedge in black
                    gPath.SetAttribute("stroke-width", "0.1"); // 2 units thick
                    gPie.AppendChild(gPath);                // Add wedge to chart

                    // The next wedge begins where this one ends
                    startangle = endangle;
                }
            
            }
         

            return gPie;
        }
        public XmlElement addgPie(Point PViewWell, List<float> fListdata, List<string> ltStrColors,float dfscale)
        {

            XmlElement gPie = svgDoc.CreateElement("g");
            // Add up the data values so we know how big the pie is
            float total = fListdata.Sum();
            // Now figure out how big each slice of pie is. Angles in radians.
            List<double> angles = new List<double>();
            for (int i = 0; i < fListdata.Count; i++)
                angles.Add(fListdata[i] / total * Math.PI * 2);

            int r = Convert.ToInt16(Math.Sqrt(total / Math.PI) * dfscale);
            int cx = PViewWell.X;
            int cy = PViewWell.Y;
            // Loop through each slice of pie.


            if (r > 0)
            {
                double startangle = 0;
                for (int i = 0; i < fListdata.Count; i++)
                {
                    // This is where the wedge ends
                    double endangle = startangle + angles[i];

                    // Compute the two points where our wedge intersects the circle
                    // These formulas are chosen so that an angle of 0 is at 12 o'clock
                    // and positive angles increase clockwise.
                    var x1 = cx + r * Math.Sin(startangle);
                    var y1 = cy - r * Math.Cos(startangle);
                    var x2 = cx + r * Math.Sin(endangle);
                    var y2 = cy - r * Math.Cos(endangle);

                    // This is a flag for angles larger than than a half circle
                    // It is required by the SVG arc drawing component
                    var big = 0;
                    if (endangle - startangle > Math.PI) big = 1;

                    // We describe a wedge with an <svg:path> element

                    XmlElement gPath = svgDoc.CreateElement("path");
                    // This string holds the path details
                    string d = "M " + cx + "," + cy +  // Start at circle center
                        " L " + x1 + "," + y1 +     // Draw line to (x1,y1)
                        " A " + r + "," + r +       // Draw an arc of radius r
                        " 0 " + big + " 1 " +       // Arc details...
                        x2 + "," + y2 +             // Arc goes to to (x2,y2)
                        " Z";                       // Close path back to (cx,cy)

                    // Now set attributes on the <svg:path> element
                    gPath.SetAttribute("d", d);              // Set this path 
                    gPath.SetAttribute("fill", ltStrColors[i]);   // Set wedge color
                    gPath.SetAttribute("stroke", "black");   // Outline wedge in black
                    gPath.SetAttribute("stroke-width", "0.1"); // 2 units thick
                    gPie.AppendChild(gPath);                // Add wedge to chart

                    // The next wedge begins where this one ends
                    startangle = endangle;
                }

            }

            return gPie;
        }

        public XmlElement gWellPie(Point PViewWell, List<float> fListdata, List<string> ltStrColors, float fscale)
        {

            XmlElement gPie = svgDoc.CreateElement("g");
            // Add up the data values so we know how big the pie is
            float total = fListdata.Sum();
            // Now figure out how big each slice of pie is. Angles in radians.
            List<double> angles = new List<double>();
            for (int i = 0; i < fListdata.Count; i++)
                angles.Add(fListdata[i] / total * Math.PI * 2);

            int r = Convert.ToInt16(Math.Sqrt(total / Math.PI) * fscale);
            int cx = PViewWell.X;
            int cy = PViewWell.Y;
            // Loop through each slice of pie.
            if (r > 0)
            {
                double startangle = 0;
                for (int i = 0; i < fListdata.Count; i++)
                {
                    // This is where the wedge ends
                    double endangle = startangle + angles[i];

                    // Compute the two points where our wedge intersects the circle
                    // These formulas are chosen so that an angle of 0 is at 12 o'clock
                    // and positive angles increase clockwise.
                    var x1 = cx + r * Math.Sin(startangle);
                    var y1 = cy - r * Math.Cos(startangle);
                    var x2 = cx + r * Math.Sin(endangle);
                    var y2 = cy - r * Math.Cos(endangle);

                    // This is a flag for angles larger than than a half circle
                    // It is required by the SVG arc drawing component
                    var big = 0;
                    if (endangle - startangle > Math.PI) big = 1;

                    // We describe a wedge with an <svg:path> element

                    XmlElement gPath = svgDoc.CreateElement("path");
                    // This string holds the path details
                    string d = "M " + cx + "," + cy +  // Start at circle center
                        " L " + x1 + "," + y1 +     // Draw line to (x1,y1)
                        " A " + r + "," + r +       // Draw an arc of radius r
                        " 0 " + big + " 1 " +       // Arc details...
                        x2 + "," + y2 +             // Arc goes to to (x2,y2)
                        " Z";                       // Close path back to (cx,cy)

                    // Now set attributes on the <svg:path> element
                    gPath.SetAttribute("d", d);              // Set this path 
                    gPath.SetAttribute("fill", ltStrColors[i]);   // Set wedge color
                    gPath.SetAttribute("fill-opacity", "0.6");
                    gPath.SetAttribute("stroke", "black");   // Outline wedge in black
                    gPath.SetAttribute("stroke-width", "0.1"); // 2 units thick
                    gPie.AppendChild(gPath);                // Add wedge to chart

                    // The next wedge begins where this one ends
                    startangle = endangle;
                }

            }
            XmlElement gText = svgDoc.CreateElement("text");
            gText.SetAttribute("x", (PViewWell.X + 3).ToString());
            gText.SetAttribute("y", (PViewWell.Y - 5).ToString());
            gText.SetAttribute("font-size", "6");
            gText.InnerText = string.Join("/", fListdata.ConvertAll(item => item.ToString("0.0")));
            gText.SetAttribute("fill", "black");
            gPie.AppendChild(gText);

            return gPie;
        }

        public static XmlElement gWellPie(XmlDocument svgDoc, Point PViewWell, List<float> fListdata, List<string> ltStrColors, float fscale)
        {

            XmlElement gPie = svgDoc.CreateElement("g");
            // Add up the data values so we know how big the pie is
            float total = fListdata.Sum();
            // Now figure out how big each slice of pie is. Angles in radians.
            List<double> angles = new List<double>();
            for (int i = 0; i < fListdata.Count; i++)
                angles.Add(fListdata[i] / total * Math.PI * 2);

            int r = Convert.ToInt16(Math.Sqrt(total / Math.PI) * fscale);
            int cx = PViewWell.X;
            int cy = PViewWell.Y;
            // Loop through each slice of pie.
            if (r > 0)
            {
                double startangle = 0;
                for (int i = 0; i < fListdata.Count; i++)
                {
                    // This is where the wedge ends
                    double endangle = startangle + angles[i];

                    // Compute the two points where our wedge intersects the circle
                    // These formulas are chosen so that an angle of 0 is at 12 o'clock
                    // and positive angles increase clockwise.
                    var x1 = cx + r * Math.Sin(startangle);
                    var y1 = cy - r * Math.Cos(startangle);
                    var x2 = cx + r * Math.Sin(endangle);
                    var y2 = cy - r * Math.Cos(endangle);

                    // This is a flag for angles larger than than a half circle
                    // It is required by the SVG arc drawing component
                    var big = 0;
                    if (endangle - startangle > Math.PI) big = 1;

                    // We describe a wedge with an <svg:path> element

                    XmlElement gPath = svgDoc.CreateElement("path");
                    // This string holds the path details
                    string d = "M " + cx + "," + cy +  // Start at circle center
                        " L " + x1 + "," + y1 +     // Draw line to (x1,y1)
                        " A " + r + "," + r +       // Draw an arc of radius r
                        " 0 " + big + " 1 " +       // Arc details...
                        x2 + "," + y2 +             // Arc goes to to (x2,y2)
                        " Z";                       // Close path back to (cx,cy)

                    // Now set attributes on the <svg:path> element
                    gPath.SetAttribute("d", d);              // Set this path 
                    gPath.SetAttribute("fill", ltStrColors[i]);   // Set wedge color
                    gPath.SetAttribute("fill-opacity", "0.6");
                    gPath.SetAttribute("stroke", "black");   // Outline wedge in black
                    gPath.SetAttribute("stroke-width", "0.1"); // 2 units thick
                    gPie.AppendChild(gPath);                // Add wedge to chart

                    // The next wedge begins where this one ends
                    startangle = endangle;
                }

            }
            XmlElement gText = svgDoc.CreateElement("text");
            gText.SetAttribute("x", (PViewWell.X + 3).ToString());
            gText.SetAttribute("y", (PViewWell.Y - 5).ToString());
            gText.SetAttribute("font-size", "6");
            gText.InnerText = string.Join("/", fListdata.ConvertAll(item => item.ToString("0.0")));
            gText.SetAttribute("fill", "black");
            gPie.AppendChild(gText);

            return gPie;
        }

        public XmlElement gWellBarGraph(Point PViewWell, List<float> fListdata, List<string> ltStrColors, float fscale)
        {
            XmlElement gHistogram = svgDoc.CreateElement("g");
            gHistogram.SetAttribute("id", "gHistogram");
            int width = 3;
            List<float> ltHeight = new List<float>();
            for (int i = 0; i < fListdata.Count; i++)
            {
               
                float height = fscale * fListdata[i];
                XmlElement gRect = svgDoc.CreateElement("rect");
                gRect.SetAttribute("x", (PViewWell.X + 3).ToString());
                gRect.SetAttribute("y", (PViewWell.Y - 3-ltHeight.Sum()).ToString());
                gRect.SetAttribute("width", width.ToString());
                gRect.SetAttribute("height", height.ToString());
                gRect.SetAttribute("fill", ltStrColors[i]);
                gRect.SetAttribute("stroke-width", "0.1");
                gRect.SetAttribute("stroke", "black");
                gHistogram.AppendChild(gRect);
                ltHeight.Add(height);
            }
            XmlElement gText = svgDoc.CreateElement("text");
            gText.SetAttribute("x", (PViewWell.X + 3).ToString());
            gText.SetAttribute("y", (PViewWell.Y - 5).ToString());
            gText.SetAttribute("font-size", "6");
            gText.InnerText = string.Join("/", fListdata.ConvertAll(item => item.ToString("0.0"))); 
            gText.SetAttribute("fill", "black");
            gHistogram.AppendChild(gText);
            return gHistogram;
        }

        public XmlElement gWellBarGraph(Point PViewWell, List<float> fListdata, List<string> ltStrColors, int width, float fscale)
        {
            XmlElement gHistogram = svgDoc.CreateElement("g");
            gHistogram.SetAttribute("id", "gBarGraph");
            List<float> ltHeight = new List<float>();//store value to height to sum
            for (int i = 0; i < fListdata.Count; i++)
            {
                float height = fscale * fListdata[i];
                ltHeight.Add(height);
                XmlElement gRect = svgDoc.CreateElement("rect");
                gRect.SetAttribute("x", (PViewWell.X + 3).ToString());
                gRect.SetAttribute("y", (PViewWell.Y - 3 - ltHeight.Sum()).ToString());
                gRect.SetAttribute("width", width.ToString());
                gRect.SetAttribute("height", height.ToString());
                gRect.SetAttribute("fill", ltStrColors[i]);
                gRect.SetAttribute("stroke-width", "0.1");
                gRect.SetAttribute("stroke", "black");
                gHistogram.AppendChild(gRect);
            }
            XmlElement gText = svgDoc.CreateElement("text");
            gText.SetAttribute("x", (PViewWell.X + 3).ToString());
            gText.SetAttribute("y", (PViewWell.Y - 5 - ltHeight.Sum()).ToString());
            gText.SetAttribute("font-size", "6");
            gText.InnerText = string.Join("/", fListdata.ConvertAll(item => item.ToString("0.0")));
            gText.SetAttribute("fill", "black");
            gHistogram.AppendChild(gText);
            return gHistogram;
        }

        public XmlElement gWellBarGraph(Point PViewWell, float fValue, string sColor, int width ,float fscale)
        {
            XmlElement gHistogram = svgDoc.CreateElement("g");
            gHistogram.SetAttribute("id", "gHistogram");

            float height = fscale * fValue;
            XmlElement gRect = svgDoc.CreateElement("rect");
            gRect.SetAttribute("x", (PViewWell.X + 3).ToString());
            gRect.SetAttribute("y", (PViewWell.Y - 3 - height).ToString());
            gRect.SetAttribute("width", width.ToString());
            gRect.SetAttribute("height", height.ToString());
            gRect.SetAttribute("fill", sColor);
            gRect.SetAttribute("stroke-width", "0.1");
            gRect.SetAttribute("stroke", "black");
            gHistogram.AppendChild(gRect);
           
            XmlElement gText = svgDoc.CreateElement("text");
            gText.SetAttribute("x", (PViewWell.X + 3).ToString());
            gText.SetAttribute("y", (PViewWell.Y-5 - height).ToString());
            gText.SetAttribute("font-size", "6");
            gText.InnerText = fValue.ToString("0.0");
            gText.SetAttribute("fill", "black");
            gHistogram.AppendChild(gText);
            return gHistogram; 
        }

        public XmlElement addgPieByxmlConfig(Point PViewWell, float fPieSum, float fSection)
        {
            XDocument xmlLayerMap = XDocument.Load(cProjectManager.filePathLayerCss);
            double _sizeScale = double.Parse(xmlLayerMap.Element("LayerMapConfig").Element("BubbleMap").Element("SizeScale").Value);

            double r = _sizeScale * Math.Sqrt(fPieSum / Math.PI);
            XmlElement gPie = svgDoc.CreateElement("g");
            gPie.SetAttribute("id", "gPie");

            if (r > 0)
            {
                XmlElement gLinque = svgDoc.CreateElement("circle");
                gLinque.SetAttribute("cx", PViewWell.X.ToString());
                gLinque.SetAttribute("cy", PViewWell.Y.ToString());
                gLinque.SetAttribute("r", r.ToString());
                gLinque.SetAttribute("stroke", "black");
                gLinque.SetAttribute("stroke-width", "0.1");

                gLinque.SetAttribute("fill", "blue");
                gPie.AppendChild(gLinque);
                double degree = 360 * fSection / fPieSum;
                float dx = Convert.ToInt32(-r * Math.Cos(degree * Math.PI / 180));
                float dy = Convert.ToInt32(-r * Math.Sin(degree * Math.PI / 180));

                XmlElement gSector = svgDoc.CreateElement("path");
                string d = "M" + PViewWell.X.ToString() + " " + PViewWell.Y.ToString()
                    + "h " + r.ToString() + "A" + r.ToString() + "," + r.ToString();
                if (degree <= 180) d += " 0 0,0 ";
                if (degree >= 180) d += " 0 1,0 ";
                d += (PViewWell.X + dx).ToString() + "," + (PViewWell.Y + dy).ToString() + " z";
                gSector.SetAttribute("d", d);
                gSector.SetAttribute("fill", "red");
                gSector.SetAttribute("stroke", "black");
                gSector.SetAttribute("stroke-linejoin", "round");
                gSector.SetAttribute("stroke-width", "0.1");
                gPie.AppendChild(gSector);
            }

            return gPie;
        }
        public XmlElement gHistogram(Point PViewWell, float fValue, float dfscale, string fillColor)
        {
            XmlElement gHistogram = svgDoc.CreateElement("g");
            gHistogram.SetAttribute("id", "gHistogram");
            int width = 3;
            float height =dfscale* fValue / width;

            XmlElement gRect = svgDoc.CreateElement("rect");
            gRect.SetAttribute("x", (PViewWell.X + 3).ToString());
            gRect.SetAttribute("y", (PViewWell.Y - 3).ToString());
            gRect.SetAttribute("width", width.ToString());
            gRect.SetAttribute("height", height.ToString());
            gRect.SetAttribute("fill", fillColor);
            gRect.SetAttribute("fill-opacity", "0.6");
            gRect.SetAttribute("stroke-width", "0.1");
            gRect.SetAttribute("stroke", "black");
            gHistogram.AppendChild(gRect);

            XmlElement gText = svgDoc.CreateElement("text");
            gText.SetAttribute("x", (PViewWell.X + 3).ToString());
            gText.SetAttribute("y", (PViewWell.Y - 5).ToString());
            gText.SetAttribute("font-size", "3");
            gText.InnerText = fValue.ToString();
            gText.SetAttribute("fill", "black");
            gHistogram.AppendChild(gText);

            return gHistogram;
        }
        public XmlElement gValueCircle(Point pViewWell, float fValue, float fPieRScale, string fillColor)
        {
            XmlElement gValueCirle = svgDoc.CreateElement("g");
            gValueCirle.SetAttribute("id", "gValueCircle");
            int r = Convert.ToInt16(Math.Sqrt(fValue / Math.PI) * fPieRScale);
            XmlElement gCircle = svgDoc.CreateElement("circle");
            gCircle.SetAttribute("cx", pViewWell.X.ToString());
            gCircle.SetAttribute("cy", pViewWell.Y.ToString());
            gCircle.SetAttribute("r", r.ToString());
            gCircle.SetAttribute("stroke", "black");
            gCircle.SetAttribute("stroke-width", "0.5");
            gCircle.SetAttribute("fill", fillColor);
            gCircle.SetAttribute("fill-opacity", "0.6");
            
            gValueCirle.AppendChild(gCircle);

            XmlElement gText = svgDoc.CreateElement("text");
            gText.SetAttribute("x", (pViewWell.X + 3).ToString());
            gText.SetAttribute("y", (pViewWell.Y - 5).ToString());
            gText.SetAttribute("font-size", "5");
            gText.InnerText = fValue.ToString();
            gText.SetAttribute("fill", "black");
            gValueCirle.AppendChild(gText);
            return gValueCirle;
        }
        public XmlElement gHistogramByxmlConfig(Point PViewWell, float fValue)
        {
            XDocument xmlLayerMap = XDocument.Load(cProjectManager.filePathLayerCss);
            int width = int.Parse(xmlLayerMap.Element("LayerMapConfig").Element("Histogram").Element("width").Value);
            string _fontSize = xmlLayerMap.Element("LayerMapConfig").Element("Histogram").Element("textFontSize").Value;
            string _fillColor = xmlLayerMap.Element("LayerMapConfig").Element("Histogram").Element("fillColor").Value;

            XmlElement gHistogram = svgDoc.CreateElement("g");
            gHistogram.SetAttribute("id", "g");
            float height = fValue / width;

            XmlElement gRect = svgDoc.CreateElement("rect");
            gRect.SetAttribute("x", (PViewWell.X + 3).ToString());
            gRect.SetAttribute("y", (PViewWell.Y - 3).ToString());
            gRect.SetAttribute("width", width.ToString());
            gRect.SetAttribute("height", height.ToString());
            gRect.SetAttribute("fill", _fillColor);
            gRect.SetAttribute("stroke-width", "0.1");
            gRect.SetAttribute("stroke", "black");
            gHistogram.AppendChild(gRect);

            XmlElement gText = svgDoc.CreateElement("text");
            gText.SetAttribute("x", (PViewWell.X + 3).ToString());
            gText.SetAttribute("y", (PViewWell.Y - 5).ToString());
            gText.SetAttribute("font-size", _fontSize);
            gText.InnerText = fValue.ToString();
            gText.SetAttribute("fill", _fillColor);
            gHistogram.AppendChild(gText);

            return gHistogram;
        }
    }
}
