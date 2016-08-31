using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Windows.Forms;
using System.IO;

namespace DOGPlatform.SVG
{
    class cSVGXEPatternLithoSand : cSVGXEPatternBase
    {
        public Dictionary<string, int> dictionaryPatternSand = new Dictionary<string, int>();

        void initializeDictionaryPatternSand()
        {
            dictionaryPatternSand.Add("粗砂岩", 101);
            dictionaryPatternSand.Add("中砂岩", 102);
            dictionaryPatternSand.Add("细砂岩", 103);
            dictionaryPatternSand.Add("粉砂岩", 104);
            dictionaryPatternSand.Add("中细砂岩", 105);
            dictionaryPatternSand.Add("粉细砂岩", 106);
            dictionaryPatternSand.Add("石英砂岩", 107);
            dictionaryPatternSand.Add("铁质砂岩", 108);
            dictionaryPatternSand.Add("海绿石砂岩", 109);
            dictionaryPatternSand.Add("玄武质砂岩", 127);
        }

        //根据用户设置，形成pattern，存入ink的配置文件内。
        public static void addDef2Ink(string sLithoName, string sURL, int iWidthPattern, int iHeightPattern,int rCircle,
            string sBackColor,string sCircleColor,bool bSplitline)
        {
            XDocument xDoc = XDocument.Load(cProjectManager.filePahtsvgPattern);
            XElement xroot = xDoc.Root;
            if (xroot != null)
            {
                // bool x=xroot.HasElements("defs");
                XElement xdefs = xroot.Element("{http://www.w3.org/2000/svg}" + "defs");
                if (xdefs != null) xdefs.AddFirst(lithoPatternDefsSand(sLithoName, sURL, iWidthPattern, iHeightPattern, rCircle,
                    sBackColor, sCircleColor, bSplitline));
                xDoc.Save(cProjectManager.filePahtsvgPattern);
                MessageBox.Show("图案添加完成");
            }
        }
      
        public static XElement lithoPatternDefsSand(string stockId, string sURL, int iWidthUnit, int iHeightUnit, int rSand, string backColor, string circleInnerColor, bool hasSplitLine)
        {
            int numColumn = 0;
            int numRow = 0;
            string fillColor = backColor;
            string strokeColor = backColor;

            int size = rSand;

            //首先确定格式 单元格数和是否显示 分割线  
            List<XElement> listPatternMark = new List<XElement>();

            numColumn = 2;
            numRow = 2;

            XElement pattern1 = patternElementSand(iWidthUnit, iHeightUnit, 0, 0, size, circleInnerColor);
            listPatternMark.Add(pattern1);
            XElement pattern3 = patternElementSand(iWidthUnit, iHeightUnit, 1, 1, size, circleInnerColor);
            listPatternMark.Add(pattern3);

            XNamespace xn = "http://www.w3.org/2000/svg";
            XNamespace inkscape = "http://www.inkscape.org/namespaces/inkscape";
            XElement lithoPattern = new XElement(xn + "pattern");
            XAttribute stockid = new XAttribute(inkscape + "stockid", stockId);
            lithoPattern.Add(stockid);
            XAttribute collect = new XAttribute(inkscape + "collect", "always");
            lithoPattern.Add(collect);
            lithoPattern.SetAttributeValue("id", sURL);
            lithoPattern.SetAttributeValue("patternUnits", "userSpaceOnUse");
            lithoPattern.SetAttributeValue("x", "0");
            lithoPattern.SetAttributeValue("y", "0");
            lithoPattern.SetAttributeValue("width", (iWidthUnit * numColumn).ToString());
            lithoPattern.SetAttributeValue("height", (iHeightUnit * numRow).ToString());

            XElement gBackRect = backRect(backColor, iWidthUnit, iHeightUnit, numColumn, numRow);
            lithoPattern.Add(gBackRect);

            if (hasSplitLine == true)
            {
                lithoPattern.Add(splitLine(iWidthUnit, iHeightUnit, numColumn, numRow));
            }

            for (int i = 0; i < listPatternMark.Count; i++)
            {
                lithoPattern.Add(listPatternMark[i]);
            }

            return lithoPattern;
        }


        //根据系统定义，形成pattern，存入ink的配置文件内。

        public static void addDef2Ink(string sLithoName, string sID, int iWidthPattern, int iHeightPattern, string sBackColor, string sCircleColor, bool hasSplitLine)
        {
           
            XDocument xDoc = XDocument.Load(cProjectManager.filePahtsvgPattern);
            XElement xroot = xDoc.Root;
            if (xroot != null)
            {
                // bool x=xroot.HasElements("defs");
                XElement xdefs = xroot.Element("{http://www.w3.org/2000/svg}" + "defs");
                if (xdefs != null) xdefs.AddFirst(lithoPatternDefsSand(sLithoName, sID, iWidthPattern, iHeightPattern, sBackColor, sCircleColor, hasSplitLine));
                xDoc.Save(cProjectManager.filePahtsvgPattern);
                MessageBox.Show("图案添加完成");
            }
        }

        public static XElement lithoPatternDefsSand(string stockId, string sID, int iWidthUnit, int iHeightUnit, string _sBackColor, string _cirleColor, bool hasSplitLine)
        {
            
            int numColumn = 0;
            int numRow = 0;
            string sBackColor = _sBackColor;
            string cirleColor = _cirleColor;
            float size = 1.0F;

            //首先确定格式 单元格数和是否显示 分割线  
            List<XElement> listPatternMark = new List<XElement>();
            if (sID  == "101")
            {
                numColumn = 2;
                numRow = 2;
                size = 3;
                XElement pattern1 = patternElementSand(iWidthUnit, iHeightUnit, 0, 0, size, cirleColor);
                listPatternMark.Add(pattern1);
                XElement pattern3 = patternElementSand(iWidthUnit, iHeightUnit, 1, 1, size, cirleColor);
                listPatternMark.Add(pattern3);
            }
            if (sID  == "102")
            {
                numColumn = 2;
                numRow = 2;
                size = 2;
                XElement pattern1 = patternElementSand(iWidthUnit, iHeightUnit, 0, 0, size, cirleColor);
                listPatternMark.Add(pattern1);
                XElement pattern3 = patternElementSand(iWidthUnit, iHeightUnit, 1, 1, size, cirleColor);
                listPatternMark.Add(pattern3);
            }
            if (sID  == "103")
            {
                numColumn = 2;
                numRow = 2;
                size = 1;
                XElement pattern1 = patternElementSand(iWidthUnit, iHeightUnit, 0, 0, size, cirleColor);
                listPatternMark.Add(pattern1);
                XElement pattern3 = patternElementSand(iWidthUnit, iHeightUnit, 1, 1, size, cirleColor);
                listPatternMark.Add(pattern3);
            }
            if (sID  == "104")
            {
                numColumn = 2;
                numRow = 2;
                size = 0.5F;
                XElement pattern1 = patternElementSiltSand(iWidthUnit, iHeightUnit, 0, 0, size, cirleColor);
                listPatternMark.Add(pattern1);
                XElement pattern3 = patternElementSiltSand(iWidthUnit, iHeightUnit, 1, 1, size, cirleColor);
                listPatternMark.Add(pattern3);
            }
            if (sID  == "105")
            {
                numColumn = 2;
                numRow = 2;
                hasSplitLine = true;
                size = 2.0F;
                XElement pattern1 = patternElementSand(iWidthUnit, iHeightUnit, 0, 0, size, cirleColor);
                listPatternMark.Add(pattern1);
                XElement pattern2 = patternElementSand(iWidthUnit, iHeightUnit, 0, 1, size / 2, cirleColor);
                listPatternMark.Add(pattern2);
                XElement pattern3 = patternElementSand(iWidthUnit, iHeightUnit, 1, 0, size / 2, cirleColor);
                listPatternMark.Add(pattern3);
                XElement pattern4 = patternElementSand(iWidthUnit, iHeightUnit, 1, 1, size, cirleColor);
                listPatternMark.Add(pattern4);
            }
            if (sID  == "106")
            {
                numColumn = 2;
                numRow = 2;
                size = 1.0F;
                XElement pattern1 = patternElementSand(iWidthUnit, iHeightUnit, 0, 0, size, cirleColor);
                listPatternMark.Add(pattern1);
                XElement pattern2 = patternElementSiltSand(iWidthUnit, iHeightUnit, 0, 1, size / 2, cirleColor);
                listPatternMark.Add(pattern2);
                XElement pattern3 = patternElementSiltSand(iWidthUnit, iHeightUnit, 1, 0, size / 2, cirleColor);
                listPatternMark.Add(pattern3);
                XElement pattern4 = patternElementSand(iWidthUnit, iHeightUnit, 1, 1, size, cirleColor);
                listPatternMark.Add(pattern4);
            }

            if (sID  == "107")
            {
                numColumn = 2;
                numRow = 2;
                size = 3;
                XElement pattern1 = patternElementSand(iWidthUnit, iHeightUnit, 0, 0, size, cirleColor);
                listPatternMark.Add(pattern1);
                XElement pattern2 = patternElementQuartz(iWidthUnit, iHeightUnit, 0, 1);
                listPatternMark.Add(pattern2);
                XElement pattern3 = patternElementSand(iWidthUnit, iHeightUnit, 1, 1, size, cirleColor);
                listPatternMark.Add(pattern3);
                XElement pattern4 = patternElementQuartz(iWidthUnit, iHeightUnit, 1, 0);
                listPatternMark.Add(pattern4);
            }
            if (sID  == "108")
            {
                numColumn = 2;
                numRow = 2;
                size = 3;
                XElement pattern1 = patternElementSand(iWidthUnit, iHeightUnit, 0, 0, size, cirleColor);
                listPatternMark.Add(pattern1);
                XElement pattern2 = patternElementFe(iWidthUnit, iHeightUnit, 0, 1);
                listPatternMark.Add(pattern2);
                XElement pattern3 = patternElementSand(iWidthUnit, iHeightUnit, 1, 1, size, cirleColor);
                listPatternMark.Add(pattern3);
                XElement pattern4 = patternElementFe(iWidthUnit, iHeightUnit, 1, 0);
                listPatternMark.Add(pattern4);
            }
            if (sID  == "109")
            {
                numColumn = 2;
                numRow = 2;
                size = 3;
                XElement pattern1 = patternElementSand(iWidthUnit, iHeightUnit, 0, 0, size, cirleColor);
                listPatternMark.Add(pattern1);
                XElement pattern2 = patternElementGlauconite(iWidthUnit, iHeightUnit, 0, 1);
                listPatternMark.Add(pattern2);
                XElement pattern3 = patternElementSand(iWidthUnit, iHeightUnit, 1, 1, size, cirleColor);
                listPatternMark.Add(pattern3);
                XElement pattern4 = patternElementGlauconite(iWidthUnit, iHeightUnit, 1, 0);
                listPatternMark.Add(pattern4);
            }
            if (sID  == "127")
            {
                numColumn = 3;
                numRow = 2;
                size = 2;
                XElement pattern1 = patternElemenTortoise(iWidthUnit, iHeightUnit, 0, 0);
                listPatternMark.Add(pattern1);
                XElement pattern2 = patternElementSand(iWidthUnit, iHeightUnit, 0, 1, size, cirleColor);
                listPatternMark.Add(pattern2);
                XElement pattern3 = patternElementSand(iWidthUnit, iHeightUnit, 0, 2, size, cirleColor);
                listPatternMark.Add(pattern3);
                XElement pattern4 = patternElementSand(iWidthUnit, iHeightUnit, 1, 0, size, cirleColor);
                listPatternMark.Add(pattern4);
                XElement pattern5 = patternElementSand(iWidthUnit, iHeightUnit, 1, 1, size, cirleColor);
                listPatternMark.Add(pattern5);
                XElement pattern6 = patternElemenTortoise(iWidthUnit, iHeightUnit, 1, 2);
                listPatternMark.Add(pattern6);
            }
 
            XNamespace xn = "http://www.w3.org/2000/svg";
            XNamespace inkscape = "http://www.inkscape.org/namespaces/inkscape";
            XElement lithoPattern = new XElement(xn + "pattern");
            XAttribute stockid = new XAttribute(inkscape + "stockid", stockId);
            lithoPattern.Add(stockid);
            lithoPattern.SetAttributeValue("id", stockId.GetHashCode().ToString().Remove(0,1));
            lithoPattern.SetAttributeValue("patternUnits", "userSpaceOnUse");
            lithoPattern.SetAttributeValue("x", "0");
            lithoPattern.SetAttributeValue("y", "0");
            lithoPattern.SetAttributeValue("width", (iWidthUnit * numColumn).ToString());
            lithoPattern.SetAttributeValue("height", (iHeightUnit * numRow).ToString());

            lithoPattern.Add(backRect(sBackColor, iWidthUnit, iHeightUnit, numColumn, numRow));

            if (hasSplitLine == true) lithoPattern.Add(splitLine(iWidthUnit, iHeightUnit, numColumn, numRow));
            for (int i = 0; i < listPatternMark.Count; i++) lithoPattern.Add(listPatternMark[i]);
            return lithoPattern;
        }

       

     
       

       
    }
}
