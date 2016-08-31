using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Windows.Forms;
using System.IO;

namespace DOGPlatform.SVG
{
    class cSVGXEPatternShale : cSVGXEPatternBase
    {
       
        public Dictionary<string, int> dictionaryPatternShale = new Dictionary<string, int>();
        void initializeDictionaryPatternShale()
        {
            dictionaryPatternShale.Add("页岩", 301);
            dictionaryPatternShale.Add("砂质页岩", 302);
            dictionaryPatternShale.Add("沥青质页岩", 305);
        }

       public  static void addDef2Ink(string sLithoName, string sID, int iWidthPattern, int iHeightPattern, string sBackColor)
        {
            string filePathInk = cProjectManager.filePahtsvgPattern;
            XDocument xDoc = XDocument.Load(filePathInk);
            XElement xroot = xDoc.Root;
            if (xroot != null)
            {
                // bool x=xroot.HasElements("defs");
                XElement xdefs = xroot.Element("{http://www.w3.org/2000/svg}" + "defs");
                if (xdefs != null) xdefs.AddFirst(lithoPatternShaleDefs(sLithoName, sID, iWidthPattern, iHeightPattern, sBackColor));
                xDoc.Save(filePathInk);
                MessageBox.Show("图案添加完成");
            }
        }


       public static XElement lithoPatternShaleDefs(string stockId, string sID, int iWidthUnit, int iHeightUnit, string backColor)
        {
            int numColumn = 0;
            int numRow = 0;
            //首先确定格式 单元格数和是否显示 分割线  
            List<XElement> listPatternMark = new List<XElement>();
            if (sID == "301")
            {
                listPatternMark.Clear();
                numColumn = 1;
                numRow = 1;
                //XElement pattern1 = patternElementShale(iWidthUnit, iHeightUnit, 0, 0);
                //listPatternMark.Add(pattern1);
            }
            if (sID == "302")
            {
                listPatternMark.Clear();
                numColumn = 2;
                numRow = 2;
              
                XElement pattern2 = patternElementShale(iWidthUnit, iHeightUnit, 0, 1);
                listPatternMark.Add(pattern2);
                XElement pattern3 = patternElementShale(iWidthUnit, iHeightUnit, 1, 0);
                listPatternMark.Add(pattern3);
                XElement pattern5 = patternElementShale(iWidthUnit, iHeightUnit, 0, 0);
                listPatternMark.Add(pattern5);
                XElement pattern6 = patternElementShale(iWidthUnit, iHeightUnit, 1, 1);
                listPatternMark.Add(pattern6);
                XElement pattern1 = patternElementSand(iWidthUnit, iHeightUnit, 0, 0, 1, "yellow");
                listPatternMark.Add(pattern1);
                XElement pattern4 = patternElementSand(iWidthUnit, iHeightUnit, 1, 1, 1, "yellow");
                listPatternMark.Add(pattern4);
            }

            if (sID == "305")
            {
                listPatternMark.Clear();
                numColumn = 2;
                numRow = 2;

                XElement pattern2 = patternElementShale(iWidthUnit, iHeightUnit, 0, 1);
                listPatternMark.Add(pattern2);
                XElement pattern3 = patternElementShale(iWidthUnit, iHeightUnit, 1, 0);
                listPatternMark.Add(pattern3);
                XElement pattern5 = patternElementShale(iWidthUnit, iHeightUnit, 0, 0);
                listPatternMark.Add(pattern5);
                XElement pattern6 = patternElementShale(iWidthUnit, iHeightUnit, 1, 1);
                listPatternMark.Add(pattern6);
                XElement pattern1 = patternElementAsphalt(iWidthUnit, iHeightUnit, 0, 0);
                listPatternMark.Add(pattern1);
                XElement pattern4 = patternElementAsphalt(iWidthUnit, iHeightUnit, 1, 1);
                listPatternMark.Add(pattern4);
            }


        
            string fillColor = backColor;
            string strokeColor = backColor;
            bool hasSplitLine = true;
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


            lithoPattern.Add(backRect(backColor, iWidthUnit, iHeightUnit, numColumn, numRow));

            if (hasSplitLine == true) lithoPattern.Add(splitLine(iWidthUnit, iHeightUnit, numColumn, numRow));
            for (int i = 0; i < listPatternMark.Count; i++) lithoPattern.Add(listPatternMark[i]);

            return lithoPattern;
        }


    }
}
