using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace DOGPlatform.SVG
{
    class cSVGBasePattern :cSVGBase
    {
       
        public  XmlElement addLithoPattern(string filePath,int iWidthUnit, int iHeightUnit, string backColor, string d)//增加岩石类型
        {
            XmlDocument svgDoc = new XmlDocument();
            svgDoc.Load(filePath);
            XmlElement svgRoot = svgDoc.DocumentElement;

            XmlElement gLithoPattern = svgDoc.CreateElement("g");
            gLithoPattern.SetAttribute("xmlns:svg", "http://www.w3.org/2000/svg");
            gLithoPattern.SetAttribute("xmlns", "http://www.w3.org/2000/svg");

            string sURL = "url(#" + lithoPatternDefs(filePath,"idlitho", iWidthUnit, iHeightUnit, backColor) + ")";

            gLithoPattern.SetAttribute("id", "idLitho");

            XmlElement gLithoPatternPath = svgDoc.CreateElement("path");
            gLithoPatternPath.SetAttribute("d", d);
            gLithoPatternPath.SetAttribute("style", "stroke-width:0.1");
            gLithoPatternPath.SetAttribute("stroke", "black");
            gLithoPatternPath.SetAttribute("fill", sURL);

            gLithoPattern.AppendChild(gLithoPatternPath);
            return gLithoPattern;
        }
        public  string lithoPatternDefs(string filepath, string sIDLithoName, int iWidthUnit, int iHeightUnit, string backColor)
        {
            int numColumn = 2;
            int numRow = 2;
            string fillColor = backColor;
            string strokeColor = backColor;

            int width = iWidthUnit * numColumn;
            int heigth = iHeightUnit * numRow;
            string sIDPattern = sIDLithoName;

            XmlDocument svgDoc = new XmlDocument();
            svgDoc.Load(filepath);
            XmlElement lithoPattern = svgDoc.CreateElement("pattern");
            lithoPattern.SetAttribute("xmlns:svg", "http://www.w3.org/2000/svg");
            lithoPattern.SetAttribute("xmlns", "http://www.w3.org/2000/svg");
            lithoPattern.SetAttribute("id", sIDPattern);
            lithoPattern.SetAttribute("patternUnits", "userSpaceOnUse");
            lithoPattern.SetAttribute("x", "0");
            lithoPattern.SetAttribute("y", "0");
            lithoPattern.SetAttribute("width", width.ToString());
            lithoPattern.SetAttribute("height", heigth.ToString());
            lithoPattern.SetAttribute("viewBox", "0 0 " + width.ToString() + " " + heigth.ToString());

            XmlElement gBackRect = backRect(filepath,backColor, iWidthUnit, iHeightUnit, numColumn, numRow);
            lithoPattern.AppendChild(gBackRect);

            XmlElement gSplitLine = splitLine(filepath, iWidthUnit, iHeightUnit, numColumn, numRow);
            lithoPattern.AppendChild(gSplitLine);

            int size = 5;
            if (size == 5) size = iHeightUnit / 5;

            //XmlElement pattern1 = patternElementSand(filepath, iWidthUnit, iHeightUnit, 0, 0, size, "yellow");
            //lithoPattern.AppendChild(pattern1);
            //XmlElement pattern2 = textPatternElement(filepath, iWidthUnit, iHeightUnit, 0, 1, "Fe");
            //lithoPattern.AppendChild(pattern2);
            //svgDefs.AppendChild(lithoPattern);
            //XmlElement pattern3 = patternElementSand(filepath, iWidthUnit, iHeightUnit, 1, 1, size, "yellow");
            //lithoPattern.AppendChild(pattern3);
            //XmlElement pattern4 = textPatternElement(filepath, iWidthUnit, iHeightUnit, 1, 0, "Fe");
            //lithoPattern.AppendChild(pattern4);
            //svgDefs.AppendChild(lithoPattern);
            return sIDPattern;
        }         
        
       //背景rect
        public XmlElement backRect(string filepath,string backColor, int iWidthUnit, int iHeightUnit, int numColumn, int numRow)
        {
            XmlDocument svgDoc = new XmlDocument();
            svgDoc.Load(filepath);
            XmlElement gBackRect = svgDoc.CreateElement("rect");
            gBackRect.SetAttribute("x", "0");
            gBackRect.SetAttribute("y", "0");
            gBackRect.SetAttribute("width", (iWidthUnit * numColumn).ToString());
            gBackRect.SetAttribute("height", (iHeightUnit * numRow).ToString());
            gBackRect.SetAttribute("stroke", backColor);
            gBackRect.SetAttribute("stroke-width", "1");
            gBackRect.SetAttribute("fill", backColor);
            return gBackRect;
        }
        //分隔线
        public XmlElement splitLine(string filepath, int iWidthUnit, int iHeightUnit, int numColumn, int numRow)
        {
            XmlDocument svgDoc = new XmlDocument();
            svgDoc.Load(filepath);
            XmlElement gSplitLine = svgDoc.CreateElement("g");
            for (int i = 0; i < numRow; i++)
            {
                XmlElement gPath = svgDoc.CreateElement("path");
                string dPath = "M 0 " + (iHeightUnit * i).ToString() + " h" + (iWidthUnit * numColumn).ToString();
                gPath.SetAttribute("d", dPath);
                gPath.SetAttribute("stroke-width", "0.5");
                gPath.SetAttribute("stroke", "black");
                gPath.SetAttribute("fill", "none");
                gSplitLine.AppendChild(gPath);
            }
            return gSplitLine;
        }
        /*
        public XmlElement circleGravel(string filepath, int cx, int cy, float r)//砾岩圈，不填充
        {
            XmlDocument svgDoc = new XmlDocument();
            svgDoc.Load(filepath);
            XmlElement circleConglomerate = svgDoc.CreateElement("circle");
            circleConglomerate.SetAttribute("cx", cx.ToString());
            circleConglomerate.SetAttribute("cy", cy.ToString());
            circleConglomerate.SetAttribute("r", r.ToString());
            circleConglomerate.SetAttribute("stroke", "black");
            circleConglomerate.SetAttribute("stroke-width", "0.5");
            circleConglomerate.SetAttribute("fill", "none");
            return circleConglomerate;
        }
        public XmlElement circleSand(string filepath, int cx, int cy, float r, string fillColor)//砂岩圈，不填充
        {
            XmlDocument svgDoc = new XmlDocument();
            svgDoc.Load(filepath);
            XmlElement circleConglomerate = svgDoc.CreateElement("circle");
            circleConglomerate.SetAttribute("cx", cx.ToString());
            circleConglomerate.SetAttribute("cy", cy.ToString());
            circleConglomerate.SetAttribute("r", r.ToString());
            circleConglomerate.SetAttribute("stroke", "black");
            circleConglomerate.SetAttribute("stroke-width", "0.5");
            circleConglomerate.SetAttribute("fill", fillColor);
            return circleConglomerate;
        }
        public XmlElement textPattern(string filepath, string sText, int x, int y, int fontSize)//文本元素
        {
            XmlDocument svgDoc = new XmlDocument();
            svgDoc.Load(filepath);
            XmlElement textXE = svgDoc.CreateElement("text");
            textXE.SetAttribute("x", x.ToString());
            textXE.SetAttribute("y", (y + fontSize / 2).ToString());
            textXE.SetAttribute("font-size", fontSize.ToString());
            textXE.SetAttribute("fill", "black");
            textXE.InnerText = sText;
            return textXE;
        }

        //砾石符号
        public XmlElement patternElementGravel(string filepath, int iWidthUnit, int iHeightUnit, int orderRow, int orderColumn, float fRadus)
        {
            XmlDocument svgDoc = new XmlDocument();
            svgDoc.Load(filepath);
            int ix = iWidthUnit * orderColumn + iWidthUnit / 2; //元素X位置
            int iy = iHeightUnit * orderRow + iHeightUnit / 2; //元素Y位置
            XmlElement patternElement = circleGravel(ix, iy, fRadus);
            return patternElement;
        }
        //砂符号
        public XmlElement patternElementSand(int iWidthUnit, int iHeightUnit,  int orderRow,int orderColumn, float fRadus, string fillColor)
        {
            int ix = iWidthUnit * orderColumn + iWidthUnit / 2; //元素X位置
            int iy = iHeightUnit * orderRow + iHeightUnit / 2; //元素Y位置
            XmlElement patternElement = circleSand(ix, iy, fRadus, fillColor);
            return patternElement;
        }

        //鲕粒符号
        public XmlElement patternElementOolite(string filepath, int iWidthUnit, int iHeightUnit, int orderRow, int orderColumn)
        {
            XmlDocument svgDoc = new XmlDocument();
            svgDoc.Load(filepath);
            XmlElement gPatternElement = svgDoc.CreateElement("g");
            int ix = iWidthUnit * orderColumn + iWidthUnit / 2; //元素X位置
            int iy = iHeightUnit * orderRow + iHeightUnit / 2; //元素Y位置
            XmlElement patternElementOuter = circleGravel(ix, iy, 3);
            gPatternElement.AppendChild(patternElementOuter);
            XmlElement patternElementInner = circleSand(ix, iy, 1, "black");
            gPatternElement.AppendChild(patternElementInner);
            return gPatternElement;
        }
        //粉沙符号
        public XmlElement patternElementSiltSand(string filepath, int iWidthUnit, int iHeightUnit, int orderRow, int orderColumn, float fRadus, string fillColor)
        {
            XmlDocument svgDoc = new XmlDocument();
            svgDoc.Load(filepath);
            XmlElement gPatternSiltSand = svgDoc.CreateElement("g");
            int ix = iWidthUnit * orderColumn + iWidthUnit *4/10; //元素X位置
            int iy = iHeightUnit * orderRow + iHeightUnit / 2; //元素Y位置
            gPatternSiltSand.AppendChild(circleSand(ix, iy, fRadus, fillColor));
            ix = iWidthUnit * orderColumn + iWidthUnit*6 / 10; //元素X位置
            iy = iHeightUnit * orderRow + iHeightUnit / 2; //元素Y位置
            gPatternSiltSand.AppendChild(circleSand(ix, iy, fRadus, fillColor));
            return gPatternSiltSand;
        }

        //灰质符号
        public XmlElement patternElementLimes(string filepath, int iWidthUnit, int iHeightUnit, int orderRow, int orderColumn)
        {
            XmlDocument svgDoc = new XmlDocument();
            svgDoc.Load(filepath);
            int ix = iWidthUnit * orderColumn + iWidthUnit/2; //元素X位置
            XmlElement patternElement = svgDoc.CreateElement("path");
            string d = "M " + ix.ToString() +" "+(iHeightUnit * orderRow).ToString() + "v" + iHeightUnit.ToString();
            patternElement.SetAttribute("d", d);
            patternElement.SetAttribute("stroke", "gray");
            patternElement.SetAttribute("stroke-width", "0.5");
            patternElement.SetAttribute("fill", "none");
            return patternElement;
        }

        //石膏符号
        public XmlElement patternElementGypsum(string filepath, int iWidthUnit, int iHeightUnit, int orderRow, int orderColumn)
        {
            XmlDocument svgDoc = new XmlDocument();
            svgDoc.Load(filepath);
            XmlElement gPatternElement = svgDoc.CreateElement("g");
            for (int i = 1; i < 4; i++)
            {
                int ix = iWidthUnit * orderColumn + iWidthUnit *i/ 5; //元素X位置
                XmlElement patternElement = svgDoc.CreateElement("path");
                string d = "M " + ix.ToString() + " " + (iHeightUnit * orderRow).ToString() + "v" + iHeightUnit.ToString();
                patternElement.SetAttribute("d", d);
                patternElement.SetAttribute("stroke", "gray");
                patternElement.SetAttribute("stroke-width", "0.5");
                patternElement.SetAttribute("fill", "none");
                gPatternElement.AppendChild(patternElement);
            }
            return gPatternElement;
        }

        //角砾石符号
        public XmlElement patternElementTriGravel(string filepath, int iWidthUnit, int iHeightUnit, int orderRow, int orderColumn)
        {
            XmlDocument svgDoc = new XmlDocument();
            svgDoc.Load(filepath);
            int ix = iWidthUnit * orderColumn + iWidthUnit / 2; //元素X位置
            int iy = iHeightUnit * orderRow + iHeightUnit / 2; //元素Y位置
            XmlElement patternElement = svgDoc.CreateElement("path");
            string d = "M " + ix.ToString() + " " + (iy-2).ToString() + "l -2,4 h 4z";
            patternElement.SetAttribute("d", d);
            patternElement.SetAttribute("stroke", "black");
            patternElement.SetAttribute("stroke-width", "0.5");
            patternElement.SetAttribute("fill", "none");
            return patternElement;
        }

        //沥青符号
        public XmlElement patternElementAsphalt(string filepath, int iWidthUnit, int iHeightUnit, int orderRow, int orderColumn)
        {
            XmlDocument svgDoc = new XmlDocument();
            svgDoc.Load(filepath);
            int ix = iWidthUnit * orderColumn + iWidthUnit / 2; //元素X位置
            int iy = iHeightUnit * orderRow + iHeightUnit / 2; //元素Y位置
            XmlElement patternElement = svgDoc.CreateElement("path");
            string d = "M " + ix.ToString() + " " + (iy-2).ToString() + "l -2,4 h 4z";
            patternElement.SetAttribute("d", d);
            patternElement.SetAttribute("stroke", "black");
            patternElement.SetAttribute("stroke-width", "0.5");
            patternElement.SetAttribute("fill", "black");
            return patternElement;
        }
        
        //凝灰符号
        public XmlElement patternElementTuff(string filepath, int iWidthUnit, int iHeightUnit, int orderRow, int orderColumn)
        {
            XmlDocument svgDoc = new XmlDocument();
            svgDoc.Load(filepath);
            int ix = iWidthUnit * orderColumn + iWidthUnit / 2; //元素X位置
            int iy = iHeightUnit * orderRow + iHeightUnit / 2; //元素Y位置
            XmlElement patternElement = svgDoc.CreateElement("path");
            string d = "M " + (ix-2).ToString() + " " + (iy+2).ToString() + "l 2,-4 l2 4";
            patternElement.SetAttribute("d", d);
            patternElement.SetAttribute("stroke", "black");
            patternElement.SetAttribute("stroke-width", "0.5");
            patternElement.SetAttribute("fill", "none");
            return patternElement;
        }

        //玄武符号
        public XmlElement patternElemenTortoise(string filepath, int iWidthUnit, int iHeightUnit, int orderRow, int orderColumn)
        {
            XmlDocument svgDoc = new XmlDocument();
            svgDoc.Load(filepath);
            int ix = iWidthUnit * orderColumn + iWidthUnit / 2; //元素X位置
            int iy = iHeightUnit * orderRow + iHeightUnit / 2; //元素Y位置
            XmlElement patternElement = svgDoc.CreateElement("path");
            string d = "M " + (ix - 2).ToString() + " " + (iy + 2).ToString() + "v -4 h 4";
            patternElement.SetAttribute("d", d);
            patternElement.SetAttribute("stroke", "black");
            patternElement.SetAttribute("stroke-width", "0.5");
            patternElement.SetAttribute("fill", "none");
            return patternElement;
        }
       
       
        //页岩符号
        public XmlElement patternElementShale(string filepath, int iWidthUnit, int iHeightUnit, int orderRow, int orderColumn)
        {
            XmlDocument svgDoc = new XmlDocument();
            svgDoc.Load(filepath);
            int ix = iWidthUnit * orderColumn; //元素X位置
            XmlElement gPatternElement = svgDoc.CreateElement("g");
            for (int i = 1; i < 2; i++)
            {
                int iy = iHeightUnit * orderRow + iHeightUnit *i/ 2; //元素X位置
                XmlElement patternElement = svgDoc.CreateElement("path");
                string d = "M " + ix.ToString() + " " + iy.ToString() + "h" + iWidthUnit.ToString();
                patternElement.SetAttribute("d", d);
                patternElement.SetAttribute("stroke", "black");
                patternElement.SetAttribute("stroke-width", "0.2");
                patternElement.SetAttribute("fill", "none");
                gPatternElement.AppendChild(patternElement);
            }
            return gPatternElement;
        }
        //泥质符号
        public XmlElement patternElementMud(string filepath,int iWidthUnit, int iHeightUnit, int orderRow, int orderColumn)
        {
            XmlDocument svgDoc = new XmlDocument();
            svgDoc.Load(filepath);
            int ix = iWidthUnit * orderColumn + iWidthUnit / 2; //元素X位置
            int iy = iHeightUnit * orderRow + iHeightUnit / 2; //元素X位置
            XmlElement patternElement = svgDoc.CreateElement("path");
            int iMudLength=8;
            if (iWidthUnit / 2 < iMudLength) iMudLength = iWidthUnit / 2 - 1;
            string d = "M " + (ix - iMudLength / 2).ToString() + " " + iy.ToString() + "h" + iMudLength.ToString();
            patternElement.SetAttribute("d", d);
            patternElement.SetAttribute("stroke", "black");
            patternElement.SetAttribute("stroke-width", "0.5");
            patternElement.SetAttribute("fill", "none");
            return patternElement;
        }

        //白云岩符号
        public XmlElement patternElementDolomite(int iWidthUnit, int iHeightUnit, int orderRow, int orderColumn)
        {
            XmlDocument svgDoc = new XmlDocument();
            svgDoc.Load(filepath);
            int ix1 = iWidthUnit * orderColumn + (iWidthUnit/2+3); //元素X位置
            int ix2 = iWidthUnit * orderColumn + iWidthUnit /2; //元素X位置
            int iy1 = iHeightUnit * orderRow; //元素X位置
            int iy2 = iHeightUnit * (orderRow+1); //元素X位置
            XmlElement patternElement = svgDoc.CreateElement("line");
            patternElement.SetAttribute("x1", ix1.ToString());
            patternElement.SetAttribute("y1", iy1.ToString());
            patternElement.SetAttribute("x2", ix2.ToString());
            patternElement.SetAttribute("y2", iy2.ToString());
            patternElement.SetAttribute("stroke", "gray");
            patternElement.SetAttribute("stroke-width", "0.5");
            patternElement.SetAttribute("fill", "z");
            return patternElement;
        }
        //文本符号
        public XmlElement textPatternElement(int iWidthUnit, int iHeightUnit, int orderRow, int orderColumn, string sText)
        {
            XmlDocument svgDoc = new XmlDocument();
            svgDoc.Load(filepath);
            int ix = iWidthUnit * orderColumn + iWidthUnit / 2; //元素X位置
            int iy = iHeightUnit * orderRow + iHeightUnit*7/10; //元素Y位置

            XmlElement textXE = svgDoc.CreateElement("text");
            textXE.SetAttribute("x", ix.ToString());
            textXE.SetAttribute("y", iy.ToString());

            int fontSize = 6;
            if (iHeightUnit / 2 <= 6) fontSize = iHeightUnit / 2;
            else fontSize = 6;

            textXE.SetAttribute("font-size", fontSize.ToString());
            textXE.SetAttribute("fill", "black");
            textXE.SetAttribute("strole-width", "0.5");
            textXE.InnerText = sText;
            return textXE;
        }
        //Fe符号
        public XmlElement patternElementFe(int iWidthUnit, int iHeightUnit, int orderRow,int orderColumn )
        {
            return textPatternElement(iWidthUnit, iHeightUnit, orderColumn, orderRow,"Fe");
        }
        //Si符号
        public XmlElement patternElementSi(int iWidthUnit, int iHeightUnit, int orderRow, int orderColumn)
        {
            return textPatternElement(iWidthUnit, iHeightUnit, orderColumn, orderRow, "Si");
        }
        //磷符号
        public XmlElement patternElementP(int iWidthUnit, int iHeightUnit, int orderRow, int orderColumn)
        {
            return textPatternElement(iWidthUnit, iHeightUnit, orderColumn, orderRow, "P");
        }
        //碳符号
        public XmlElement patternElementC(int iWidthUnit, int iHeightUnit, int orderRow, int orderColumn)
        {
            return textPatternElement(iWidthUnit, iHeightUnit, orderColumn, orderRow, "C");
        }
        //铝符号
        public XmlElement patternElementAl(int iWidthUnit, int iHeightUnit, int orderRow, int orderColumn)
        {
            return textPatternElement(iWidthUnit, iHeightUnit, orderColumn, orderRow, "Al");
        }
        //花岗岩
        public XmlElement patternElementGranite(int iWidthUnit, int iHeightUnit, int orderRow, int orderColumn)
        {
            return textPatternElement(iWidthUnit, iHeightUnit, orderColumn, orderRow, "+");
        }
        //高岭土符号
        public XmlElement patternElementKaoline(int iWidthUnit, int iHeightUnit, int orderRow, int orderColumn)
        {
            return textPatternElement(iWidthUnit, iHeightUnit, orderColumn, orderRow, "±");
        }
        //长石符号
        public XmlElement patternElementN(int iWidthUnit, int iHeightUnit,  int orderRow,int orderColumn)
        {
            return textPatternElement(iWidthUnit, iHeightUnit, orderColumn, orderRow,"N");
        }
        //海绿石符号
        public XmlElement patternElementGlauconite(int iWidthUnit, int iHeightUnit,  int orderRow,int orderColumn)
        {
            return textPatternElement(iWidthUnit, iHeightUnit, orderColumn, orderRow, "#");
        }
        //石英符号
        public XmlElement patternElementQuartz(int iWidthUnit, int iHeightUnit,  int orderRow,int orderColumn)
        {
            return textPatternElement(iWidthUnit, iHeightUnit, orderColumn, orderRow,"∴");
        }

        */
      
    }
}
