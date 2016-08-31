using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;
using System.Windows.Forms;

namespace DOGPlatform.SVG
{
    class cSVGXEPatternCarbonatie : cSVGXEPatternBase
    {
        public Dictionary<string, int> dictionaryPatternCarbonatite = new Dictionary<string, int>();
        void initializeDictionaryPatternCarbonatite()
        {
            dictionaryPatternCarbonatite.Add("石灰岩", 201);
            dictionaryPatternCarbonatite.Add("白云岩", 202);
            dictionaryPatternCarbonatite.Add("鲕粒灰岩", 224);
        }

        public static void addDef2Ink(string sLithoName, string sID, int iWidthPattern, int iHeightPattern, string sBackColor)
        {

            XDocument xDoc = XDocument.Load(cProjectManager.filePahtsvgPattern);
            XElement xroot = xDoc.Root;

            if (xroot != null)
            {
                // bool x=xroot.HasElements("defs");
                XElement xdefs = xroot.Element("{http://www.w3.org/2000/svg}" + "defs");
                if (xdefs != null) xdefs.AddFirst(lithoPatternLimesDefs(sLithoName, sID, iWidthPattern, iHeightPattern));
                xDoc.Save(cProjectManager.filePahtsvgPattern);
                MessageBox.Show("图案添加完成");
            }
        }


        public  static XElement lithoPatternLimesDefs(string stockId, string sID,  int iWidthUnit, int iHeightUnit)
        {  
            int numColumn = 0;
            int numRow = 0;

            XNamespace xn = "http://www.w3.org/2000/svg";
            XNamespace inkscape = "http://www.inkscape.org/namespaces/inkscape";
            //首先确定格式 单元格数和是否显示 分割线  
            List<XElement> listPatternMark = new List<XElement>();
            if (sID  == "201")
            {
                listPatternMark.Clear();
                numColumn = 4;
                numRow = 2;
                XElement pattern1 = patternElementLimes(iWidthUnit, iHeightUnit, 0, 0);
                listPatternMark.Add(pattern1);
                XElement pattern2 = patternElementLimes(iWidthUnit, iHeightUnit, 0, 2);
                listPatternMark.Add(pattern2);
                XElement pattern3 = patternElementLimes(iWidthUnit, iHeightUnit, 1, 1);
                listPatternMark.Add(pattern3);
                XElement pattern4 = patternElementLimes(iWidthUnit, iHeightUnit, 1, 3);
                listPatternMark.Add(pattern4);
            }
            if (sID  == "202")
            {
                listPatternMark.Clear();
                numColumn = 4;
                numRow = 2;
                XElement pattern1 = patternElementDolomite(iWidthUnit, iHeightUnit, 0, 0);
                listPatternMark.Add(pattern1);
                XElement pattern2 = patternElementDolomite(iWidthUnit, iHeightUnit, 0, 2);
                listPatternMark.Add(pattern2);
                XElement pattern3 = patternElementDolomite(iWidthUnit, iHeightUnit, 1, 1);
                listPatternMark.Add(pattern3);
                XElement pattern4 = patternElementDolomite(iWidthUnit, iHeightUnit, 1, 3);
                listPatternMark.Add(pattern4);
            }

            if (sID  == "224")
            {
                listPatternMark.Clear();
                numColumn = 4;
                numRow = 2;
                XElement pattern1 = patternElementOolite(iWidthUnit, iHeightUnit, 0, 0);
                listPatternMark.Add(pattern1);
                XElement pattern2 = patternElementLimes(iWidthUnit, iHeightUnit, 0, 1);
                listPatternMark.Add(pattern2);
                XElement pattern3 = patternElementOolite(iWidthUnit, iHeightUnit, 0, 2);
                listPatternMark.Add(pattern3);
                XElement pattern4 = patternElementLimes(iWidthUnit, iHeightUnit, 0, 3);
                listPatternMark.Add(pattern4);
                XElement pattern5 = patternElementLimes(iWidthUnit, iHeightUnit, 1, 0);
                listPatternMark.Add(pattern5);
                XElement pattern6 = patternElementOolite(iWidthUnit, iHeightUnit, 1, 1);
                listPatternMark.Add(pattern6);
                XElement pattern7 = patternElementLimes(iWidthUnit, iHeightUnit, 1, 2);
                listPatternMark.Add(pattern7);
                XElement pattern8 = patternElementOolite(iWidthUnit, iHeightUnit, 1, 3);
                listPatternMark.Add(pattern8);
            }

            XElement lithoPattern = new XElement(xn + "pattern");
            XAttribute stockid = new XAttribute(inkscape + "stockid", stockId);
            lithoPattern.Add(stockid);
            lithoPattern.SetAttributeValue("id", stockId.GetHashCode().ToString().Remove(0, 1));
            XAttribute collect = new XAttribute(inkscape + "collect", "always");
            lithoPattern.Add(collect);
            lithoPattern.SetAttributeValue("patternUnits", "userSpaceOnUse");
            lithoPattern.SetAttributeValue("x", "0");
            lithoPattern.SetAttributeValue("y", "0");
            lithoPattern.SetAttributeValue("width", (iWidthUnit * numColumn).ToString());
            lithoPattern.SetAttributeValue("height", (iHeightUnit * numRow).ToString());

            for (int i = 0; i < listPatternMark.Count; i++) lithoPattern.Add(listPatternMark[i]);
            lithoPattern.Add(splitLine(iWidthUnit, iHeightUnit, numColumn, numRow));
            return lithoPattern;
          
        }
    }
}
