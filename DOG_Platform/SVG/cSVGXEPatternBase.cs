using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace DOGPlatform.SVG
{
    class cSVGXEPatternBase
    {
        public static XElement circleGravel(int cx, int cy, float r)//砾岩圈，不填充
        {
            XNamespace xn = "http://www.w3.org/2000/svg";
            XElement circleConglomerate = new XElement(xn + "circle");
            circleConglomerate.SetAttributeValue("cx", cx.ToString());
            circleConglomerate.SetAttributeValue("cy", cy.ToString());
            circleConglomerate.SetAttributeValue("r", r.ToString());
            circleConglomerate.SetAttributeValue("stroke", "black");
            circleConglomerate.SetAttributeValue("stroke-width", "0.5");
            circleConglomerate.SetAttributeValue("fill", "none");
            return circleConglomerate;
        }
       
        public XElement textPattern(string sText, int x, int y, int fontSize)//文本元素
        {
            XNamespace xn = "http://www.w3.org/2000/svg";
            XElement textXE = new XElement(xn + "text");
            textXE.SetAttributeValue("x", x.ToString());
            textXE.SetAttributeValue("y", (y + fontSize / 2).ToString());
            textXE.SetAttributeValue("font-size", fontSize.ToString());
            textXE.SetAttributeValue("fill", "black");
            textXE.Value = sText;
            return textXE;
        }

        //砾石符号
        public static XElement patternElementGravel(int iWidthUnit, int iHeightUnit, int orderRow, int orderColumn, float fRadus)
        {
            XNamespace xn = "http://www.w3.org/2000/svg";
            XElement textXE = new XElement(xn + "text");
            int ix = iWidthUnit * orderColumn + iWidthUnit / 2; //元素X位置
            int iy = iHeightUnit * orderRow + iHeightUnit / 2; //元素Y位置
            XElement patternElement = circleGravel(ix, iy, fRadus);
            return patternElement;
        }
       
        //灰质符号
        public static XElement patternElementLimes( int iWidthUnit, int iHeightUnit, int orderRow, int orderColumn)
        {
            XNamespace xn = "http://www.w3.org/2000/svg";
            XElement patternElement = new XElement(xn + "path");
            int ix = iWidthUnit * orderColumn + iWidthUnit / 2; //元素X位置
           
            string d = "M " + ix.ToString() + " " + (iHeightUnit * orderRow).ToString() + "v" + iHeightUnit.ToString();
            patternElement.SetAttributeValue("d", d);
            patternElement.SetAttributeValue("stroke", "black");
            patternElement.SetAttributeValue("stroke-width", "1");
            patternElement.SetAttributeValue("fill", "none");
            return patternElement;
        }

        //鲕粒符号
        public static XElement patternElementOolite(int iWidthUnit, int iHeightUnit, int orderRow, int orderColumn)
        {
            XNamespace xn = "http://www.w3.org/2000/svg";
            XElement gPatternElement = new XElement(xn + "g");
            int ix = iWidthUnit * orderColumn + iWidthUnit / 2; //元素X位置
            int iy = iHeightUnit * orderRow + iHeightUnit / 2; //元素Y位置
            XElement patternElementOuter = circleGravel(ix, iy, 3);
            gPatternElement.Add(patternElementOuter);
            XElement patternElementInner = circleSand(ix, iy, 1, "black");
            gPatternElement.Add(patternElementInner);
            return gPatternElement;
        }


        //砂符号
        public static XElement patternElementSand(int iWidthUnit, int iHeightUnit, int orderRow, int orderColumn, float fRadus, string fillColor)
        {
            int ix = iWidthUnit * orderColumn + iWidthUnit / 2; //元素X位置
            int iy = iHeightUnit * orderRow + iHeightUnit / 2; //元素Y位置
            XElement patternElement = circleSand(ix, iy, fRadus, fillColor);
            return patternElement;
        }

        public static XElement circleSand(int cx, int cy, float r, string fillColor)//砂岩圈，不填充
        {
            XNamespace xn = "http://www.w3.org/2000/svg";
            XElement circleConglomerate = new XElement(xn + "circle");

            circleConglomerate.SetAttributeValue("cx", cx.ToString());
            circleConglomerate.SetAttributeValue("cy", cy.ToString());
            circleConglomerate.SetAttributeValue("r", r.ToString());
            circleConglomerate.SetAttributeValue("stroke", "black");
            circleConglomerate.SetAttributeValue("stroke-width", "0.5");
            circleConglomerate.SetAttributeValue("fill", fillColor);
            return circleConglomerate;
        }

       
        //粉沙符号
        public static XElement patternElementSiltSand(int iWidthUnit, int iHeightUnit, int orderRow, int orderColumn, float fRadus, string fillColor)
        {
            XNamespace xn = "http://www.w3.org/2000/svg";
            XElement gPatternSiltSand = new XElement(xn + "g");
            int ix = iWidthUnit * orderColumn + iWidthUnit * 4 / 10; //元素X位置
            int iy = iHeightUnit * orderRow + iHeightUnit / 2; //元素Y位置
            gPatternSiltSand.Add(circleSand(ix, iy, fRadus, fillColor));
            ix = iWidthUnit * orderColumn + iWidthUnit * 6 / 10; //元素X位置
            iy = iHeightUnit * orderRow + iHeightUnit / 2; //元素Y位置
            gPatternSiltSand.Add(circleSand(ix, iy, fRadus, fillColor));
            return gPatternSiltSand;
        }
      
        //分隔线
        public static XElement splitLine(int iWidthUnit, int iHeightUnit, int numColumn, int numRow)
        {
            XNamespace xn = "http://www.w3.org/2000/svg";
            XElement circleConglomerate = new XElement(xn + "circle");
            XElement gSplitLine = new XElement(xn + "g");
            for (int i = 0; i < numRow; i++)
            {
                XElement gPath = new XElement(xn + "path");
                string dPath = "M 0 " + (iHeightUnit * i).ToString() + " h" + (iWidthUnit * numColumn).ToString();
                gPath.SetAttributeValue("d", dPath);
                gPath.SetAttributeValue("stroke-width", "0.5");
                gPath.SetAttributeValue("stroke", "black");
                gPath.SetAttributeValue("fill", "none");
                gSplitLine.Add(gPath);
            }
            return gSplitLine;
        }

        //背景rect
        public static XElement backRect(string backColor, int iWidthUnit, int iHeightUnit, int numColumn, int numRow)
        {
            XNamespace xn = "http://www.w3.org/2000/svg";
            XElement gBackRect = new XElement(xn + "rect");
            gBackRect.SetAttributeValue("x", "0");
            gBackRect.SetAttributeValue("y", "0");
            gBackRect.SetAttributeValue("width", (iWidthUnit * numColumn).ToString());
            gBackRect.SetAttributeValue("height", (iHeightUnit * numRow).ToString());
            gBackRect.SetAttributeValue("stroke", backColor);
            gBackRect.SetAttributeValue("stroke-width", "1");
            gBackRect.SetAttributeValue("fill", backColor);
            return gBackRect;
        }

        public static XElement lithoPattern(string sURL)
        {
            XNamespace xn = "http://www.w3.org/2000/svg";
            XElement pattern = new XElement(xn + "g");

            //pattern.SetAttributeValue("id", "idLithonSand");
            pattern.SetAttributeValue("stroke", "black");
            XElement gPath = new XElement(xn + "path");

            gPath.SetAttributeValue("stroke", "black");
            gPath.SetAttributeValue("d", "M5,5 c500,150 400,150 400,0  Z");
            gPath.SetAttributeValue("style", "stroke-width:1");
            gPath.SetAttributeValue("fill", "url(#" + sURL + ")");
            pattern.Add(gPath);
            return pattern;
        }

        //石膏符号
        public static XElement patternElementGypsum( int iWidthUnit, int iHeightUnit, int orderRow, int orderColumn)
        {
            XNamespace xn = "http://www.w3.org/2000/svg";
            XElement gPatternElement = new XElement(xn + "g");
            for (int i = 1; i < 4; i++)
            {
                int ix = iWidthUnit * orderColumn + iWidthUnit * i / 5; //元素X位置
                XElement patternElement = new XElement(xn + "path");
                string d = "M " + ix.ToString() + " " + (iHeightUnit * orderRow).ToString() + "v" + iHeightUnit.ToString();
                patternElement.SetAttributeValue("d", d);
                patternElement.SetAttributeValue("stroke", "gray");
                patternElement.SetAttributeValue("stroke-width", "0.5");
                patternElement.SetAttributeValue("fill", "none");
                gPatternElement.Add(patternElement);
            }
            return gPatternElement;
        }

        //角砾石符号
        public static XElement patternElementTriGravel( int iWidthUnit, int iHeightUnit, int orderRow, int orderColumn)
        {
            
            XNamespace xn = "http://www.w3.org/2000/svg";
            XElement patternElement = new XElement(xn + "path");

            int ix = iWidthUnit * orderColumn + iWidthUnit / 2; //元素X位置
            int iy = iHeightUnit * orderRow + iHeightUnit / 2; //元素Y位置
            string d = "M " + ix.ToString() + " " + (iy - 2).ToString() + "l -2,4 h 4z";
            patternElement.SetAttributeValue("d", d);
            patternElement.SetAttributeValue("stroke", "black");
            patternElement.SetAttributeValue("stroke-width", "0.5");
            patternElement.SetAttributeValue("fill", "none");
            return patternElement;
        }

        //沥青符号
        public static XElement patternElementAsphalt(int iWidthUnit, int iHeightUnit, int orderRow, int orderColumn)
        {
           
            XNamespace xn = "http://www.w3.org/2000/svg";
            XElement patternElement = new XElement(xn + "path");

            int ix = iWidthUnit * orderColumn + iWidthUnit / 2; //元素X位置
            int iy = iHeightUnit * orderRow + iHeightUnit / 2; //元素Y位置
            string d = "M " + ix.ToString() + " " + (iy - 2).ToString() + "l -2,4 h 4z";
            patternElement.SetAttributeValue("d", d);
            patternElement.SetAttributeValue("stroke", "black");
            patternElement.SetAttributeValue("stroke-width", "0.5");
            patternElement.SetAttributeValue("fill", "black");
            return patternElement;
        }

        //凝灰符号
        public static XElement patternElementTuff(int iWidthUnit, int iHeightUnit, int orderRow, int orderColumn)
        {
            
            XNamespace xn = "http://www.w3.org/2000/svg";
            XElement patternElement = new XElement(xn + "path");

            int ix = iWidthUnit * orderColumn + iWidthUnit / 2; //元素X位置
            int iy = iHeightUnit * orderRow + iHeightUnit / 2; //元素Y位置
            string d = "M " + (ix - 2).ToString() + " " + (iy + 2).ToString() + "l 2,-4 l2 4";
            patternElement.SetAttributeValue("d", d);
            patternElement.SetAttributeValue("stroke", "black");
            patternElement.SetAttributeValue("stroke-width", "0.5");
            patternElement.SetAttributeValue("fill", "none");
            return patternElement;
        }

        //玄武符号
        public static XElement patternElemenTortoise(int iWidthUnit, int iHeightUnit, int orderRow, int orderColumn)
        {
            XNamespace xn = "http://www.w3.org/2000/svg";
            XElement patternElement = new XElement(xn + "path");
            int ix = iWidthUnit * orderColumn + iWidthUnit / 2; //元素X位置
            int iy = iHeightUnit * orderRow + iHeightUnit / 2; //元素Y位置
            string d = "M " + (ix - 2).ToString() + " " + (iy + 2).ToString() + "v -4 h 4";
            patternElement.SetAttributeValue("d", d);
            patternElement.SetAttributeValue("stroke", "black");
            patternElement.SetAttributeValue("stroke-width", "0.5");
            patternElement.SetAttributeValue("fill", "none");
            return patternElement;
        }


        //页岩符号
        public static XElement patternElementShale( int iWidthUnit, int iHeightUnit, int orderRow, int orderColumn)
        {
          
            XNamespace xn = "http://www.w3.org/2000/svg";

            int ix = iWidthUnit * orderColumn; //元素X位置
            XElement gPatternElement = new XElement(xn + "g");
            for (int i = 1; i < 2; i++)
            {
                int iy = iHeightUnit * orderRow + iHeightUnit * i / 2; //元素X位置
            XElement patternElement = new XElement(xn + "path");
                string d = "M " + ix.ToString() + " " + iy.ToString() + "h" + iWidthUnit.ToString();
                patternElement.SetAttributeValue("d", d);
                patternElement.SetAttributeValue("stroke", "black");
                patternElement.SetAttributeValue("stroke-width", "0.2");
                patternElement.SetAttributeValue("fill", "none");
                gPatternElement.Add(patternElement);
            }
            return gPatternElement;
        }

        //泥质符号
        public static XElement patternElementMud( int iWidthUnit, int iHeightUnit, int orderRow, int orderColumn)
        {
         
            XNamespace xn = "http://www.w3.org/2000/svg";
            XElement patternElement = new XElement(xn + "path");

            int ix = iWidthUnit * orderColumn + iWidthUnit / 2; //元素X位置
            int iy = iHeightUnit * orderRow + iHeightUnit / 2; //元素X位置
            int iMudLength = 8;
            if (iWidthUnit / 2 < iMudLength) iMudLength = iWidthUnit / 2 - 1;
            string d = "M " + (ix - iMudLength / 2).ToString() + " " + iy.ToString() + "h" + iMudLength.ToString();
            patternElement.SetAttributeValue("d", d);
            patternElement.SetAttributeValue("stroke", "black");
            patternElement.SetAttributeValue("stroke-width", "0.5");
            patternElement.SetAttributeValue("fill", "none");
            return patternElement;
        }

        //白云岩符号
        public static XElement patternElementDolomite(int iWidthUnit, int iHeightUnit, int orderRow, int orderColumn)
        {
           
            XNamespace xn = "http://www.w3.org/2000/svg";
            XElement patternElement = new XElement(xn + "line", new XAttribute("xmlns", "http://www.w3.org/2000/svg"));

            int ix1 = iWidthUnit * orderColumn + (iWidthUnit / 2 + 3); //元素X位置
            int ix2 = iWidthUnit * orderColumn + iWidthUnit / 2; //元素X位置
            int iy1 = iHeightUnit * orderRow; //元素X位置
            int iy2 = iHeightUnit * (orderRow + 1); //元素X位置
            patternElement.SetAttributeValue("x1", ix1.ToString());
            patternElement.SetAttributeValue("y1", iy1.ToString());
            patternElement.SetAttributeValue("x2", ix2.ToString());
            patternElement.SetAttributeValue("y2", iy2.ToString());
            patternElement.SetAttributeValue("stroke", "gray");
            patternElement.SetAttributeValue("stroke-width", "0.5");
            patternElement.SetAttributeValue("fill", "z");
            return patternElement;
        }
        //文本符号
        public static XElement textPatternElement(int iWidthUnit, int iHeightUnit, int orderRow, int orderColumn, string sText)
        {
            XNamespace xn = "http://www.w3.org/2000/svg";
            XElement textXE = new XElement(xn + "text");

            int ix = iWidthUnit * orderColumn + iWidthUnit / 2; //元素X位置
            int iy = iHeightUnit * orderRow + iHeightUnit * 7 / 10; //元素Y位置

            textXE.SetAttributeValue("x", ix.ToString());
            textXE.SetAttributeValue("y", iy.ToString());

            int fontSize = 6;
            if (iHeightUnit / 2 <= 6) fontSize = iHeightUnit / 2;
            else fontSize = 6;

            textXE.SetAttributeValue("font-size", fontSize.ToString());
            textXE.SetAttributeValue("fill", "black");
            textXE.SetAttributeValue("strole-width", "0.5");
            textXE.Value = sText;
            return textXE;
        }
        //Fe符号
        public static XElement patternElementFe(int iWidthUnit, int iHeightUnit, int orderRow, int orderColumn)
        {
            return textPatternElement(iWidthUnit, iHeightUnit, orderColumn, orderRow, "Fe");
        }
        //Si符号
        public static XElement patternElementSi(int iWidthUnit, int iHeightUnit, int orderRow, int orderColumn)
        {
            return textPatternElement(iWidthUnit, iHeightUnit, orderColumn, orderRow, "Si");
        }
        //磷符号
        public static XElement patternElementP(int iWidthUnit, int iHeightUnit, int orderRow, int orderColumn)
        {
            return textPatternElement(iWidthUnit, iHeightUnit, orderColumn, orderRow, "P");
        }
        //碳符号
        public static XElement patternElementC(int iWidthUnit, int iHeightUnit, int orderRow, int orderColumn)
        {
            return textPatternElement(iWidthUnit, iHeightUnit, orderColumn, orderRow, "C");
        }
        //铝符号
        public static XElement patternElementAl(int iWidthUnit, int iHeightUnit, int orderRow, int orderColumn)
        {
            return textPatternElement(iWidthUnit, iHeightUnit, orderColumn, orderRow, "Al");
        }
        //花岗岩
        public static XElement patternElementGranite(int iWidthUnit, int iHeightUnit, int orderRow, int orderColumn)
        {
            return textPatternElement(iWidthUnit, iHeightUnit, orderColumn, orderRow, "+");
        }
        //高岭土符号
        public static XElement patternElementKaoline(int iWidthUnit, int iHeightUnit, int orderRow, int orderColumn)
        {
            return textPatternElement(iWidthUnit, iHeightUnit, orderColumn, orderRow, "±");
        }
        //长石符号
        public static XElement patternElementN(int iWidthUnit, int iHeightUnit, int orderRow, int orderColumn)
        {
            return textPatternElement(iWidthUnit, iHeightUnit, orderColumn, orderRow, "N");
        }
        //海绿石符号
        public static XElement patternElementGlauconite(int iWidthUnit, int iHeightUnit, int orderRow, int orderColumn)
        {
            return textPatternElement(iWidthUnit, iHeightUnit, orderColumn, orderRow, "#");
        }
        //石英符号
        public static XElement patternElementQuartz(int iWidthUnit, int iHeightUnit, int orderRow, int orderColumn)
        {
            return textPatternElement(iWidthUnit, iHeightUnit, orderColumn, orderRow, "∴");
        }
    }
}
