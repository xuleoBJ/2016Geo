using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq ;
using System.IO;
using System.Windows.Forms;

namespace DOGPlatform.SVG
{
    class cSVGXEPatternGravel : cSVGXEPatternBase
    {
        public Dictionary<string, int> dictionaryPatternGravel = new Dictionary<string, int>();
        void initializedictionaryPatternGravel()
        {
            dictionaryPatternGravel.Add("巨砾岩", 501);
            dictionaryPatternGravel.Add("粗砾岩", 502);
            dictionaryPatternGravel.Add("中砾岩", 503);
            dictionaryPatternGravel.Add("细砾岩", 504);
            dictionaryPatternGravel.Add("泥砾岩", 506);
            dictionaryPatternGravel.Add("角砾岩", 507);
            dictionaryPatternGravel.Add("凝灰质角砾岩", 513);
        }

        public static void addDef2Ink(string sLithoName, string sID, int iWidthPattern, int iHeightPattern, string sBackColor, bool hasSplitLine)
        {
           
            XDocument xDoc = XDocument.Load(cProjectManager.filePahtsvgPattern);
            XElement xroot = xDoc.Root;

            if (xroot != null)
            {
                // bool x=xroot.HasElements("defs");
                XElement xdefs = xroot.Element("{http://www.w3.org/2000/svg}" + "defs");
                if (xdefs != null) xdefs.AddFirst(lithoPatternDefsGravel(sLithoName, sID, iWidthPattern, iHeightPattern, sBackColor, hasSplitLine));
                xDoc.Save(cProjectManager.filePahtsvgPattern);
                MessageBox.Show("图案添加完成");
            }
        }
        public static XElement lithoPatternDefsGravel(string stockId, string sID, int iWidthUnit, int iHeightUnit, string backColor, bool hasSplitLine)
        {
            int numColumn = 0;
            int numRow = 0;
            string fillColor = backColor;
            string strokeColor = backColor;

            //首先确定格式 单元格数和是否显示 分割线  
            List<XElement> listPatternMark = new List<XElement>();
            if (sID == "501")
            {
                numColumn = 2;
                numRow = 2;
                XElement pattern1 = patternElementGravel(iWidthUnit, iHeightUnit, 0, 0, 4);
                listPatternMark.Add(pattern1);
                XElement pattern3 = patternElementGravel(iWidthUnit, iHeightUnit, 1, 1, 4);
                listPatternMark.Add(pattern3);
            }
            if (sID == "502")
            {
                numColumn = 2;
                numRow = 2;
                XElement pattern1 = patternElementGravel(iWidthUnit, iHeightUnit, 0, 0, 2.5F);
                listPatternMark.Add(pattern1);
                XElement pattern3 = patternElementGravel(iWidthUnit, iHeightUnit, 1, 1, 2.5F);
                listPatternMark.Add(pattern3);
            }
            if (sID == "503")
            {
                numColumn = 2;
                numRow = 2;
                XElement pattern1 = patternElementGravel(iWidthUnit, iHeightUnit, 0, 0, 2);
                listPatternMark.Add(pattern1);
                XElement pattern3 = patternElementGravel(iWidthUnit, iHeightUnit, 1, 1, 2);
                listPatternMark.Add(pattern3);
            }
            if (sID == "504")
            {
                numColumn = 2;
                numRow = 2;
                XElement pattern1 = patternElementGravel(iWidthUnit, iHeightUnit, 0, 0, 1);
                listPatternMark.Add(pattern1);
                XElement pattern3 = patternElementGravel(iWidthUnit, iHeightUnit, 1, 1, 1);
                listPatternMark.Add(pattern3);
            }
            if (sID == "506")
            {
                numColumn = 2;
                numRow = 2;

                XElement pattern1 = patternElementGravel(iWidthUnit, iHeightUnit, 0, 0, 1);
                listPatternMark.Add(pattern1);
                XElement pattern2 = patternElementMud(iWidthUnit, iHeightUnit, 0, 0);
                listPatternMark.Add(pattern2);
                XElement pattern3 = patternElementGravel(iWidthUnit, iHeightUnit, 1, 1, 1);
                listPatternMark.Add(pattern3);
                XElement pattern4 = patternElementMud(iWidthUnit, iHeightUnit, 1, 1);
                listPatternMark.Add(pattern4);
            }

            if (sID == "507")
            {
                numColumn = 2;
                numRow = 2;

                XElement pattern1 = patternElementTriGravel(iWidthUnit, iHeightUnit, 0, 0);
                listPatternMark.Add(pattern1);

                XElement pattern3 = patternElementTriGravel(iWidthUnit, iHeightUnit, 1, 1);
                listPatternMark.Add(pattern3);

            }
            if (sID == "513")
            {
                numColumn = 3;
                numRow = 2;
                XElement pattern1 = patternElementTuff(iWidthUnit, iHeightUnit, 0, 0);
                listPatternMark.Add(pattern1);
                XElement pattern2 = patternElementTriGravel(iWidthUnit, iHeightUnit, 0, 1);
                listPatternMark.Add(pattern2);
                XElement pattern3 = patternElementTriGravel(iWidthUnit, iHeightUnit, 0, 2);
                listPatternMark.Add(pattern3);
                XElement pattern4 = patternElementTriGravel(iWidthUnit, iHeightUnit, 1, 0);
                listPatternMark.Add(pattern4);
                XElement pattern5 = patternElementTriGravel(iWidthUnit, iHeightUnit, 1, 1);
                listPatternMark.Add(pattern5);
                XElement pattern6 = patternElementTuff(iWidthUnit, iHeightUnit, 1, 2);
                listPatternMark.Add(pattern6);

            }


            XNamespace xn = "http://www.w3.org/2000/svg";
            XNamespace inkscape = "http://www.inkscape.org/namespaces/inkscape";
            XElement lithoPattern = new XElement(xn + "pattern");
            XAttribute stockid = new XAttribute(inkscape + "stockid", stockId);
            lithoPattern.Add(stockid);
            XAttribute collect = new XAttribute(inkscape + "collect", "always");
            lithoPattern.SetAttributeValue("id", stockId.GetHashCode().ToString().Remove(0,1));
            lithoPattern.SetAttributeValue("patternUnits", "userSpaceOnUse");
            lithoPattern.SetAttributeValue("x", "0");
            lithoPattern.SetAttributeValue("y", "0");
            lithoPattern.SetAttributeValue("width", (iWidthUnit * numColumn).ToString());
            lithoPattern.SetAttributeValue("height", (iHeightUnit * numRow).ToString());

          
            lithoPattern.Add(backRect(backColor, iWidthUnit, iHeightUnit, numColumn, numRow));

            if (hasSplitLine == true) lithoPattern.Add(splitLine(iWidthUnit, iHeightUnit, numColumn, numRow));
            for (int i = 0; i < listPatternMark.Count; i++) lithoPattern.Add(listPatternMark[i]);

            return lithoPattern;
        }

   
    }
}
