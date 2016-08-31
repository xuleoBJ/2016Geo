using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Drawing;
using System.Xml.Linq;

namespace DOGPlatform.SVG
{
    class cSVGDocLayerMapProduction : cBaseMapSVG
    {
        //定义全部井
     
        public List<float> fListValue1_ProductionSVG = new List<float>();
        public List<float> fListValue2_ProductionSVG = new List<float>();

        public cSVGDocLayerMapProduction(int width,int height, int iDX, int iDY)
            : base( width, height, iDX, iDY)
        {
        initializeMapInfor();
        }

        public void initializeMapInfor()
        {

        }

        public void initializeMapInforByFile(string fileName)
        {
           

        }

        public void addInjectWellInProductionMapSymbolDefs(int r)
        {
            XmlElement gWater = svgDoc.CreateElement("g");
            gWater.SetAttribute("id", "InjectWellSymbol");

            XmlElement gCircle = svgDoc.CreateElement("circle");
            gCircle.SetAttribute("cx", "0");
            gCircle.SetAttribute("cy", "0");
            gCircle.SetAttribute("r", r.ToString());
            gCircle.SetAttribute("stroke", "black");
            gCircle.SetAttribute("style", "stroke-width:1");
            gCircle.SetAttribute("fill", "none");
            gWater.AppendChild(gCircle);

            XmlElement path = svgDoc.CreateElement("path");
            path.SetAttribute("d", "M -4 4 h2 h-2 v-2 z  ");
            path.SetAttribute("fill", "black");
            path.SetAttribute("stroke", "black");
            path.SetAttribute("style", "stroke-width:1");
            gWater.AppendChild(path);
            XmlElement pathLine = svgDoc.CreateElement("path");
            pathLine.SetAttribute("d", "M -4 4 L4,-4  ");
            pathLine.SetAttribute("fill", "black");
            pathLine.SetAttribute("stroke", "black");
            pathLine.SetAttribute("style", "stroke-width:1");
            gWater.AppendChild(pathLine);
            svgDefs.AppendChild(gWater);
        }

        public void addArrowMark()
        {
            XmlElement gArrowMark = svgDoc.CreateElement("marker");
            gArrowMark.SetAttribute("id", "idMarkerArrow");
            gArrowMark.SetAttribute("markerWidth", "4");
            gArrowMark.SetAttribute("markerHeight", "4");
            //gArrowMark.SetAttribute("refx", "0");
            //gArrowMark.SetAttribute("refy", "0");
            gArrowMark.SetAttribute("orient", "auto");

            XmlElement path = svgDoc.CreateElement("path");
            path.SetAttribute("d", "M0,0 L4,2 L0,4 z");
            path.SetAttribute("fill", "blue");
            path.SetAttribute("stroke", "blue");
            path.SetAttribute("style", "stroke-width:1");
            gArrowMark.AppendChild(path);
            svgDefs.AppendChild(gArrowMark);
        }
        public XmlElement addgConnectLine(Point pWell1view, Point pWell2view,
          string strokeColor, float stroke_width, string fillColor)
        {
            
            XmlElement gArrow = svgDoc.CreateElement("line");
            XmlElement gLine = svgDoc.CreateElement("line");
            gLine.SetAttribute("x1", pWell1view.X.ToString());
            gLine.SetAttribute("y1", pWell1view.Y.ToString());
            gLine.SetAttribute("x2", pWell2view.X.ToString());
            gLine.SetAttribute("y2", pWell2view.Y.ToString());
            gLine.SetAttribute("stroke", strokeColor);
            gLine.SetAttribute("stroke-width", stroke_width.ToString());
            gLine.SetAttribute("fill", fillColor);
            // 由于不同软件支持的marker不同，这个不用了
         //   gLine.SetAttribute("marker-end", "url(#idMarkerArrow)");
            return gLine;
        }
        public XmlElement gWellPosition(List<string> ltStrJH, List<int> iListWellType, List<int> iListXview, List<int> iListYview)
        {
            XDocument xmlLayerMap = XDocument.Load(cProjectManager.filePathLayerCss);
            string _JHFontSize = xmlLayerMap.Element("LayerMapConfig").Element("JHText").Element("fontSize").Value;
            int _radis = int.Parse(xmlLayerMap.Element("LayerMapConfig").Element("WellSymbol").Element("r").Value);
            string _DX_JHText = xmlLayerMap.Element("LayerMapConfig").Element("JHText").Element("DX_Text").Value;

            addInjectWellSymbolDefs();
            addDrillingPatternDefs();
            addPlatformWellSymbolDefs();
            addOilGasWellSymbolDefs();
            XmlElement gWellPositon = svgDoc.CreateElement("g");
            gWellPositon.SetAttribute("ID", "wellPosion");

            for (int i = 0; i < ltStrJH.Count; i++)
            {
                string m_colorWell = "none";
                if (iListWellType[i] == 3)
                {
                    m_colorWell = "red";
                }
                else if (iListWellType[i] == 1)
                {
                    XmlElement gWellSymbolUse = svgDoc.CreateElement("use");
                    gWellSymbolUse.SetAttribute("x", iListXview[i].ToString());
                    gWellSymbolUse.SetAttribute("y", iListYview[i].ToString());
                    XmlAttribute WellSymbolNode = svgDoc.CreateAttribute("xlink", "href", "http://www.w3.org/1999/xlink");
                    WellSymbolNode.Value = "#" + "idOilGasWellSymbol";
                    gWellSymbolUse.Attributes.Append(WellSymbolNode);
                    gWellPositon.AppendChild(gWellSymbolUse);
                    m_colorWell = "red";
                }
                else if (iListWellType[i] == 5)
                {
                    m_colorWell = "Gold";
                }
                else if (iListWellType[i] == 15)
                {
                    XmlElement gWellSymbolUse = svgDoc.CreateElement("use");
                    gWellSymbolUse.SetAttribute("x", iListXview[i].ToString());
                    gWellSymbolUse.SetAttribute("y", iListYview[i].ToString());
                    XmlAttribute WellSymbolNode = svgDoc.CreateAttribute("xlink", "href", "http://www.w3.org/1999/xlink");
                    WellSymbolNode.Value = "#" + "InjectWellSymbol";
                    gWellSymbolUse.Attributes.Append(WellSymbolNode);
                    gWellPositon.AppendChild(gWellSymbolUse);
                    m_colorWell = "blue";
                }

                else if (iListWellType[i] == 8)
                {
                    XmlElement gWellSymbolUse = svgDoc.CreateElement("use");
                    gWellSymbolUse.SetAttribute("x", iListXview[i].ToString());
                    gWellSymbolUse.SetAttribute("y", iListYview[i].ToString());
                    XmlAttribute WellSymbolNode = svgDoc.CreateAttribute("xlink", "href", "http://www.w3.org/1999/xlink");
                    WellSymbolNode.Value = "#" + "idPlatformWell";
                    gWellSymbolUse.Attributes.Append(WellSymbolNode);
                    gWellPositon.AppendChild(gWellSymbolUse);
                    m_colorWell = "red";
                }
                else
                {
                    m_colorWell = "black";
                    XmlElement gWellSymbolInner = svgDoc.CreateElement("circle");
                    gWellSymbolInner.SetAttribute("cx", iListXview[i].ToString());
                    gWellSymbolInner.SetAttribute("cy", iListYview[i].ToString());
                    gWellSymbolInner.SetAttribute("r", "1.5");
                    gWellSymbolInner.SetAttribute("stroke", m_colorWell);
                    gWellSymbolInner.SetAttribute("stroke-width", "0.1");
                    gWellSymbolInner.SetAttribute("fill", "none");
                    gWellPositon.AppendChild(gWellSymbolInner);

                }
                XmlElement gWellSymbol = gWellCircle( svgDoc, iListXview[i], iListYview[i], _radis, m_colorWell);
                gWellPositon.AppendChild(gWellSymbol);


                XmlElement gJHText = svgDoc.CreateElement("text");
                gJHText.SetAttribute("x", (iListXview[i] - int.Parse(_DX_JHText)).ToString());
                gJHText.SetAttribute("y", (iListYview[i] + int.Parse(_DX_JHText)).ToString());
                gJHText.SetAttribute("font-size", _JHFontSize);
                gJHText.SetAttribute("font-style", "normal");
                gJHText.InnerText = ltStrJH[i];
                gJHText.SetAttribute("fill", m_colorWell);
                gWellPositon.AppendChild(gJHText);

            }
            return gWellPositon;
        }
        public XmlElement gWellPosition(List<string> ltStrJH, List<int> iListWellType, List<int> iListXview, List<int> iListYview, int r)
        {
            addInjectWellInProductionMapSymbolDefs(r);
            addDrillingPatternDefs();
            addPlatformWellSymbolDefs();
            addOilGasWellSymbolDefs();
            XmlElement gWellPositon = svgDoc.CreateElement("g");
            gWellPositon.SetAttribute("ID", "wellPosion");

            for (int i = 0; i < ltStrJH.Count; i++)
            {
                string m_colorWell = "none";
                if (iListWellType[i] == 3)
                {
                    m_colorWell = "red";
                }
                else if (iListWellType[i] == 1)
                {
                    XmlElement gWellSymbolUse = svgDoc.CreateElement("use");
                    gWellSymbolUse.SetAttribute("x", iListXview[i].ToString());
                    gWellSymbolUse.SetAttribute("y", iListYview[i].ToString());
                    XmlAttribute WellSymbolNode = svgDoc.CreateAttribute("xlink", "href", "http://www.w3.org/1999/xlink");
                    WellSymbolNode.Value = "#" + "idOilGasWellSymbol";
                    gWellSymbolUse.Attributes.Append(WellSymbolNode);
                    gWellPositon.AppendChild(gWellSymbolUse);
                    m_colorWell = "red";
                }
                else if (iListWellType[i] == 5)
                {
                    m_colorWell = "Gold";
                }
                else if (iListWellType[i] == 15)
                {
                    XmlElement gWellSymbolUse = svgDoc.CreateElement("use");
                    gWellSymbolUse.SetAttribute("x", iListXview[i].ToString());
                    gWellSymbolUse.SetAttribute("y", iListYview[i].ToString());
                    XmlAttribute WellSymbolNode = svgDoc.CreateAttribute("xlink", "href", "http://www.w3.org/1999/xlink");
                    WellSymbolNode.Value = "#" + "InjectWellSymbol";
                    gWellSymbolUse.Attributes.Append(WellSymbolNode);
                    gWellPositon.AppendChild(gWellSymbolUse);
                    m_colorWell = "blue";
                }

                else if (iListWellType[i] == 8)
                {
                    XmlElement gWellSymbolUse = svgDoc.CreateElement("use");
                    gWellSymbolUse.SetAttribute("x", iListXview[i].ToString());
                    gWellSymbolUse.SetAttribute("y", iListYview[i].ToString());
                    XmlAttribute WellSymbolNode = svgDoc.CreateAttribute("xlink", "href", "http://www.w3.org/1999/xlink");
                    WellSymbolNode.Value = "#" + "idPlatformWell";
                    gWellSymbolUse.Attributes.Append(WellSymbolNode);
                    gWellPositon.AppendChild(gWellSymbolUse);
                    m_colorWell = "red";
                }
                else
                {
                    m_colorWell = "black";
                    XmlElement gWellSymbolInner = svgDoc.CreateElement("circle");
                    gWellSymbolInner.SetAttribute("cx", iListXview[i].ToString());
                    gWellSymbolInner.SetAttribute("cy", iListYview[i].ToString());
                    gWellSymbolInner.SetAttribute("r", "1.5");
                    gWellSymbolInner.SetAttribute("stroke", m_colorWell);
                    gWellSymbolInner.SetAttribute("stroke-width", "0.1");
                    gWellSymbolInner.SetAttribute("fill", "none");
                    gWellPositon.AppendChild(gWellSymbolInner);

                }
                XmlElement gWellSymbol = gWellCircle(svgDoc,iListXview[i], iListYview[i], r, m_colorWell);
                gWellPositon.AppendChild(gWellSymbol);
                XmlElement gJHText = svgDoc.CreateElement("text");
                gJHText.SetAttribute("x", (iListXview[i] - 10).ToString());
                gJHText.SetAttribute("y", (iListYview[i] + 10).ToString());
                gJHText.SetAttribute("font-size", "8");
                gJHText.SetAttribute("font-style", "normal");
                gJHText.InnerText = ltStrJH[i];
                gJHText.SetAttribute("fill", m_colorWell);
                gWellPositon.AppendChild(gJHText);

            }
            return gWellPositon;
        }
       
        public XmlElement addgOilWellProductionGraph(string sJH, int iXview, int iYview,
          float fOilDay, float fWaterDay, float fOilSum, float fWaterSum,float fPieRScale,int iRectWidth)
        {

            XmlElement gWellProductionGraph = svgDoc.CreateElement("g");
            gWellProductionGraph.SetAttribute("ID", "idWellProductionGraph");

            Point PViewWell = new Point(iXview, iYview);
            List<float> fListdata = new List<float>();
            fListdata.Add(fOilSum);
            fListdata.Add(fWaterSum);
            List<string> ltStrColors = new List<string>();
            ltStrColors.Add("red");
            ltStrColors.Add("blue");
            XmlElement gSemiPie = addgSemiPie(PViewWell, fListdata, ltStrColors, fPieRScale);
            gWellProductionGraph.AppendChild(gSemiPie);


            int width = iRectWidth;

            float heightOil = fOilDay / width;
            XmlElement gRectOil = svgDoc.CreateElement("rect");
            gRectOil.SetAttribute("x", (PViewWell.X - width).ToString());
            gRectOil.SetAttribute("y", (PViewWell.Y - heightOil).ToString());
            gRectOil.SetAttribute("width", width.ToString());
            gRectOil.SetAttribute("height", heightOil.ToString());
            gRectOil.SetAttribute("fill", "red");
            gRectOil.SetAttribute("stroke-width", "0.1");
            gRectOil.SetAttribute("stroke", "black");
            gWellProductionGraph.AppendChild(gRectOil);

            float heightWater = fWaterDay / width;
            XmlElement gRectWater = svgDoc.CreateElement("rect");
            gRectWater.SetAttribute("x", (PViewWell.X).ToString());
            gRectWater.SetAttribute("y", (PViewWell.Y - heightWater).ToString());
            gRectWater.SetAttribute("width", width.ToString());
            gRectWater.SetAttribute("height", heightWater.ToString());
            gRectWater.SetAttribute("fill", "blue");
            gRectWater.SetAttribute("stroke-width", "0.1");
            gRectWater.SetAttribute("stroke", "black");
            gWellProductionGraph.AppendChild(gRectWater);

            //XmlElement gText = svgDoc.CreateElement("text");
            //gText.SetAttribute("x", (PViewWell.X + 3).ToString());
            //gText.SetAttribute("y", (PViewWell.Y - 5).ToString());
            //gText.SetAttribute("font-size", "3");
            //gText.InnerText = fValue.ToString();
            //gText.SetAttribute("fill", "black");
            //gHistogram.AppendChild(gText);
            
            return gWellProductionGraph;
        }

        public XmlElement addgOilWellProductionGraph(List<string> ltStrJH, List<int> iListXview, List<int> iListYview,
         List<float> fListOilDay, List<float> fListWaterDay, List<float> fListOilSum, List<float> fListWaterSum,
            float fPieRScale,int iRectWidth)
        {

            XmlElement gWellProductionGraph = svgDoc.CreateElement("g");
            gWellProductionGraph.SetAttribute("ID", "idWellProductionGraph");
            for (int i = 0; i < ltStrJH.Count; i++)
            {
                Point PViewWell = new Point(iListXview[i], iListYview[i]);
                List<float> fListdata = new List<float>();
                fListdata.Add(fListOilSum[i]);
                fListdata.Add(fListWaterSum[i]);
                List<string> ltStrColors = new List<string>();
                ltStrColors.Add("red");
                ltStrColors.Add("blue");
                XmlElement gSemiPie = addgSemiPie(PViewWell, fListdata, ltStrColors, fPieRScale);
                gWellProductionGraph.AppendChild(gSemiPie);


                int width = iRectWidth;

                float heightOil = fListOilDay[i] / width;
                XmlElement gRectOil = svgDoc.CreateElement("rect");
                gRectOil.SetAttribute("x", (PViewWell.X - width).ToString());
                gRectOil.SetAttribute("y", (PViewWell.Y - heightOil).ToString());
                gRectOil.SetAttribute("width", width.ToString());
                gRectOil.SetAttribute("height", heightOil.ToString());
                gRectOil.SetAttribute("fill", "red");
                gRectOil.SetAttribute("stroke-width", "0.1");
                gRectOil.SetAttribute("stroke", "black");
                gWellProductionGraph.AppendChild(gRectOil);

                float heightWater = fListWaterDay[i] / width;
                XmlElement gRectWater = svgDoc.CreateElement("rect");
                gRectWater.SetAttribute("x", (PViewWell.X).ToString());
                gRectWater.SetAttribute("y", (PViewWell.Y - heightWater).ToString());
                gRectWater.SetAttribute("width", width.ToString());
                gRectWater.SetAttribute("height", heightWater.ToString());
                gRectWater.SetAttribute("fill", "blue");
                gRectWater.SetAttribute("stroke-width", "0.1");
                gRectWater.SetAttribute("stroke", "black");
                gWellProductionGraph.AppendChild(gRectWater);

                //XmlElement gText = svgDoc.CreateElement("text");
                //gText.SetAttribute("x", (PViewWell.X + 3).ToString());
                //gText.SetAttribute("y", (PViewWell.Y - 5).ToString());
                //gText.SetAttribute("font-size", "3");
                //gText.InnerText = fValue.ToString();
                //gText.SetAttribute("fill", "black");
                //gHistogram.AppendChild(gText);
            }

            return gWellProductionGraph;
        }

        public XmlElement addgWaterWellProductionGraph(string sJH, int iXview, int iYview, float fWaterDay, float fWaterSum,
            float fPieRScale,int iRectWidth)
        {

            XmlElement gWellProductionGraph = svgDoc.CreateElement("g");
            gWellProductionGraph.SetAttribute("ID", "idWaterWellProductionGraph");

            Point PViewWell = new Point(iXview, iYview);
            List<float> fListdata = new List<float>();
            fListdata.Add(0.0F);
            fListdata.Add(fWaterSum);
            List<string> ltStrColors = new List<string>();
            ltStrColors.Add("red");
            ltStrColors.Add("Cyan");
            XmlElement gSemiPie = addgSemiPie(PViewWell, fListdata, ltStrColors, fPieRScale);
            gWellProductionGraph.AppendChild(gSemiPie);


            int width = iRectWidth;

            float heightWater = fWaterDay / width;
            XmlElement gRectWater = svgDoc.CreateElement("rect");
            gRectWater.SetAttribute("x", (PViewWell.X - 0.5 * width).ToString());
            gRectWater.SetAttribute("y", (PViewWell.Y - heightWater).ToString());
            gRectWater.SetAttribute("width", width.ToString());
            gRectWater.SetAttribute("height", heightWater.ToString());
            gRectWater.SetAttribute("fill", "blue");
            gRectWater.SetAttribute("stroke-width", "0.1");
            gRectWater.SetAttribute("stroke", "black");
            gWellProductionGraph.AppendChild(gRectWater);

            //XmlElement gText = svgDoc.CreateElement("text");
            //gText.SetAttribute("x", (PViewWell.X + 3).ToString());
            //gText.SetAttribute("y", (PViewWell.Y - 5).ToString());
            //gText.SetAttribute("font-size", "3");
            //gText.InnerText = fValue.ToString();
            //gText.SetAttribute("fill", "black");
            //gHistogram.AppendChild(gText);

            return gWellProductionGraph;
        }

        public XmlElement addgWaterWellProductionGraph(List<string> ltStrJH, List<int> iListXview, List<int> iListYview,
 List<float> fListWaterDay, List<float> fListWaterSum, float fPieRScale, int iRectWidth)
        {

            XmlElement gWellProductionGraph = svgDoc.CreateElement("g");
            gWellProductionGraph.SetAttribute("ID", "idWellProductionGraph");
            for (int i = 0; i < ltStrJH.Count; i++)
            {
                Point PViewWell = new Point(iListXview[i], iListYview[i]);
                List<float> fListdata = new List<float>();
                fListdata.Add(0.0F);
                fListdata.Add(fListWaterSum[i]);
                List<string> ltStrColors = new List<string>();
                ltStrColors.Add("red");
                ltStrColors.Add("Cyan");
                XmlElement gSemiPie = addgSemiPie(PViewWell, fListdata, ltStrColors , fPieRScale);
                gWellProductionGraph.AppendChild(gSemiPie);


                int width =iRectWidth;

                float heightWater = fListWaterDay[i] / width;
                XmlElement gRectWater = svgDoc.CreateElement("rect");
                gRectWater.SetAttribute("x", (PViewWell.X - 0.5 * width).ToString());
                gRectWater.SetAttribute("y", (PViewWell.Y - heightWater).ToString());
                gRectWater.SetAttribute("width", width.ToString());
                gRectWater.SetAttribute("height", heightWater.ToString());
                gRectWater.SetAttribute("fill", "blue");
                gRectWater.SetAttribute("stroke-width", "0.1");
                gRectWater.SetAttribute("stroke", "black");
                gWellProductionGraph.AppendChild(gRectWater);

                //XmlElement gText = svgDoc.CreateElement("text");
                //gText.SetAttribute("x", (PViewWell.X + 3).ToString());
                //gText.SetAttribute("y", (PViewWell.Y - 5).ToString());
                //gText.SetAttribute("font-size", "3");
                //gText.InnerText = fValue.ToString();
                //gText.SetAttribute("fill", "black");
                //gHistogram.AppendChild(gText);
            }

            return gWellProductionGraph;
        }
        public XmlElement addgSemiPie(Point PViewWell, List<float> fListdata, List<string> ltStrColors, float fPieRScale)
        {

            XmlElement gPie = svgDoc.CreateElement("g");
            // Add up the data values so we know how big the pie is
            float total = fListdata.Sum();
            // Now figure out how big each slice of pie is. Angles in radians.
            List<double> angles = new List<double>();
            for (int i = 0; i < fListdata.Count; i++)
                angles.Add(fListdata[i] / total * Math.PI);
            int r = 10 * Convert.ToInt16(Math.Sqrt(total / Math.PI) * fPieRScale);
         
            int cx = PViewWell.X;
            int cy = PViewWell.Y;
            // Loop through each slice of pie.
            double startangle = Math.PI/2;
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

            return gPie;
        }
    }
}
