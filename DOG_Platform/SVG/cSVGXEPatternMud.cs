using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Windows.Forms;
using System.IO;

namespace DOGPlatform.SVG
{
    class cSVGXEPatternMud : cSVGXEPatternBase
    {
        public Dictionary<string, int> dictionaryPatternMud = new Dictionary<string, int>();
        void initializeDictionaryPatternMud()
        {
            dictionaryPatternMud.Add("泥岩", 401);
            dictionaryPatternMud.Add("粉砂质泥岩", 402);
            dictionaryPatternMud.Add("砂质泥岩", 403);
            dictionaryPatternMud.Add("灰质泥岩", 406);
            dictionaryPatternMud.Add("石膏质泥岩", 409);
        }

        //根据用户设置，形成pattern，存入ink的配置文件内。
        public static void addDef2Ink(string sLithoName, string sURL, int iWidthPattern, int iHeightPattern, string sBackColor, bool hasSplitLine)
        {

            string filePathInk = cProjectManager.filePahtsvgPattern;
            XDocument xDoc = XDocument.Load(filePathInk);
            XElement xroot = xDoc.Root;
            if (xroot != null)
            {
                // bool x=xroot.HasElements("defs");
                XElement xdefs = xroot.Element("{http://www.w3.org/2000/svg}" + "defs");
                if (xdefs != null) xdefs.AddFirst(lithoPatternDefsMud(sLithoName, sURL, iWidthPattern, iHeightPattern, sBackColor, hasSplitLine));
                xDoc.Save(filePathInk);
                MessageBox.Show("图案添加完成");
            }
        }

        public static XElement lithoPatternDefsMud(string stockId, string sID, int iWidthUnit, int iHeightUnit, string backColor, bool hasSplitLine)
        {

            int numColumn = 0;
            int numRow = 0;
            //首先确定格式 单元格数和是否显示 分割线  
            List<XElement> listPatternMark = new List<XElement>();
            if (sID  == "401")
            {
                numColumn = 2;
                numRow = 2;
                XElement pattern1 = patternElementMud(iWidthUnit, iHeightUnit, 0, 0);
                listPatternMark.Add(pattern1);
                XElement pattern3 = patternElementMud(iWidthUnit, iHeightUnit, 1, 1);
                listPatternMark.Add(pattern3);
            }
            if (sID  == "402")
            {
                numColumn = 2;
                numRow = 2;
                XElement pattern1 = patternElementMud(iWidthUnit, iHeightUnit, 0, 0);
                listPatternMark.Add(pattern1);
                XElement pattern2 = patternElementSiltSand(iWidthUnit, iHeightUnit, 0, 1, 0.5F, "yellow");
                listPatternMark.Add(pattern2);
                XElement pattern3 = patternElementMud(iWidthUnit, iHeightUnit, 1, 1);
                listPatternMark.Add(pattern3);
                XElement pattern4 = patternElementSiltSand(iWidthUnit, iHeightUnit, 1, 0, 0.5F, "yellow");
                listPatternMark.Add(pattern4);
            }
            if (sID  == "403")
            {
                numColumn = 3;
                numRow = 2;
                XElement pattern1 = patternElementSand(iWidthUnit, iHeightUnit, 0, 0, 1F, "yellow");
                listPatternMark.Add(pattern1);
                XElement pattern2 = patternElementMud(iWidthUnit, iHeightUnit, 0, 1);
                listPatternMark.Add(pattern2);
                XElement pattern3 = patternElementMud(iWidthUnit, iHeightUnit, 0, 2);
                listPatternMark.Add(pattern3);
                XElement pattern4 = patternElementMud(iWidthUnit, iHeightUnit, 1, 0);
                listPatternMark.Add(pattern4);
                XElement pattern5 = patternElementMud(iWidthUnit, iHeightUnit, 1, 1);
                listPatternMark.Add(pattern5);
                XElement pattern6 = patternElementSand(iWidthUnit, iHeightUnit, 1, 2, 1F, "yellow");
                listPatternMark.Add(pattern6);
            }
            if (sID  == "406")
            {
                numColumn = 3;
                numRow = 2;
                XElement pattern1 = patternElementLimes(iWidthUnit, iHeightUnit, 0, 0);
                listPatternMark.Add(pattern1);
                XElement pattern2 = patternElementMud(iWidthUnit, iHeightUnit, 0, 1);
                listPatternMark.Add(pattern2);
                XElement pattern3 = patternElementMud(iWidthUnit, iHeightUnit, 0, 2);
                listPatternMark.Add(pattern3);
                XElement pattern4 = patternElementMud(iWidthUnit, iHeightUnit, 1, 0);
                listPatternMark.Add(pattern4);
                XElement pattern5 = patternElementMud(iWidthUnit, iHeightUnit, 1, 1);
                listPatternMark.Add(pattern5);
                XElement pattern6 = patternElementLimes(iWidthUnit, iHeightUnit, 1, 2);
                listPatternMark.Add(pattern6);
            }
            if (sID  == "409")
            {
                numColumn = 3;
                numRow = 2;
                XElement pattern1 = patternElementGypsum(iWidthUnit, iHeightUnit, 0, 0);
                listPatternMark.Add(pattern1);
                XElement pattern2 = patternElementMud(iWidthUnit, iHeightUnit, 0, 1);
                listPatternMark.Add(pattern2);
                XElement pattern3 = patternElementMud(iWidthUnit, iHeightUnit, 0, 2);
                listPatternMark.Add(pattern3);
                XElement pattern4 = patternElementMud(iWidthUnit, iHeightUnit, 1, 0);
                listPatternMark.Add(pattern4);
                XElement pattern5 = patternElementMud(iWidthUnit, iHeightUnit, 1, 1);
                listPatternMark.Add(pattern5);
                XElement pattern6 = patternElementGypsum(iWidthUnit, iHeightUnit, 1, 2);
                listPatternMark.Add(pattern6);
            }
          
            string fillColor = backColor;
            string strokeColor = backColor;
            
            XNamespace xn = "http://www.w3.org/2000/svg";
            XNamespace inkscape = "http://www.inkscape.org/namespaces/inkscape";
            XElement lithoPattern = new XElement(xn + "pattern");
            XAttribute stockid = new XAttribute(inkscape + "stockid", stockId);
            lithoPattern.Add(stockid);
            lithoPattern.SetAttributeValue("id", stockId.GetHashCode().ToString().Remove(0,1));
             XAttribute collect = new XAttribute(inkscape + "collect", "always");
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
