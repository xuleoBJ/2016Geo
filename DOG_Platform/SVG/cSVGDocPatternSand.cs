using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace DOGPlatform.SVG
{
    class cSVGDocPatternSand : cSVGBasePattern
    {
        public List<int> iIndexPatternSand = new List<int>();
        public List<string> sNamePatternSand = new List<string>();
        public Dictionary<string,int> dictionaryPatternSand = new Dictionary<string,int>();
        void initializeDictionaryPatternSand()
        {
            dictionaryPatternSand.Add( "粗砂岩",101);
            dictionaryPatternSand.Add("中砂岩",102);
            dictionaryPatternSand.Add("细砂岩",103);
            dictionaryPatternSand.Add("粉砂岩",104);
            dictionaryPatternSand.Add("中细砂岩", 105);
            dictionaryPatternSand.Add("粉细砂岩", 106);
            dictionaryPatternSand.Add("石英砂岩", 107);
            dictionaryPatternSand.Add("铁质砂岩", 108);
            dictionaryPatternSand.Add("海绿石砂岩", 109);
            dictionaryPatternSand.Add("玄武质砂岩", 127);
        }
        public cSVGDocPatternSand(int iDX, int iDY)
        {
            initializeDictionaryPatternSand();
        }
        //可以设置砂圈半径
        public XmlElement addLithoPatternSand(string sLithoName, int iWidthUnit, int iHeightUnit, int rSand,string d,string backColor,string circleInnerColor,bool hasSplitline )//增加岩石类型
        {
            //根据岩石名称选pattern;
            string sURL = "url(#" + lithoPatternDefsSand(sLithoName, iWidthUnit, iHeightUnit, rSand, backColor, circleInnerColor,hasSplitline) + ")";

            XmlElement gLithoPattern = svgDoc.CreateElement("g");
            gLithoPattern.SetAttribute("ID", "idLitho");

            XmlElement gLithoPatternPath = svgDoc.CreateElement("path");
            gLithoPatternPath.SetAttribute("d", d);
            gLithoPatternPath.SetAttribute("style", "stroke-width:0.1");
            gLithoPatternPath.SetAttribute("stroke", "black");
            gLithoPatternPath.SetAttribute("fill", sURL);

            gLithoPattern.AppendChild(gLithoPatternPath);
            return gLithoPattern;
        }
        public  string lithoPatternDefsSand(string sIDLithoName, int iWidthUnit, int iHeightUnit, int rSand, string backColor, string circleInnerColor, bool hasSplitLine)
        {
            int numColumn = 0;
            int numRow = 0;
            string fillColor = backColor;
            string strokeColor = backColor;

            string sIDPattern = sIDLithoName;
            int size = rSand;
  
            //首先确定格式 单元格数和是否显示 分割线  
            List<XmlElement> listPatternMark = new List<XmlElement>();

            numColumn = 2;
            numRow = 2;

            //XmlElement pattern1 = patternElementSand(iWidthUnit, iHeightUnit, 0, 0, size, circleInnerColor);
            //listPatternMark.Add(pattern1);
            //XmlElement pattern3 = patternElementSand(iWidthUnit, iHeightUnit, 1, 1, size, circleInnerColor);
            //listPatternMark.Add(pattern3);
         

            XmlElement lithoPattern = svgDoc.CreateElement("pattern");
            lithoPattern.SetAttribute("id", sIDPattern);
            lithoPattern.SetAttribute("patternUnits", "userSpaceOnUse");
            lithoPattern.SetAttribute("x", "0");
            lithoPattern.SetAttribute("y", "0");
            lithoPattern.SetAttribute("width", (iWidthUnit * numColumn).ToString());
            lithoPattern.SetAttribute("height", (iHeightUnit * numRow).ToString());
            lithoPattern.SetAttribute("viewBox", "0 0 " + (iWidthUnit * numColumn).ToString() + " " + (iHeightUnit * numRow).ToString());

            //XmlElement gBackRect = backRect(backColor, iWidthUnit, iHeightUnit, numColumn, numRow);
            //lithoPattern.AppendChild(gBackRect);

            //if (hasSplitLine == true)
            //{
            //    XmlElement gSplitLine = splitLine(iWidthUnit, iHeightUnit, numColumn, numRow);
            //    lithoPattern.AppendChild(gSplitLine);
            //}

            for (int i = 0; i < listPatternMark.Count; i++)
            {
                lithoPattern.AppendChild(listPatternMark[i]);
            }

            svgDefs.AppendChild(lithoPattern);

            return sIDPattern;
        }
        //系统设定的砂圈半径
        public XmlElement addLithoPatternSand(string sLithoName, int iWidthUnit, int iHeightUnit, string backColor, string d)//增加岩石类型
        {
            int idLitho=0;
            //根据岩石名称选pattern;
            if (dictionaryPatternSand.ContainsKey(sLithoName)) idLitho = dictionaryPatternSand[sLithoName];
            
            string sURL = "url(#" + lithoPatternDefsSand(idLitho, iWidthUnit, iHeightUnit, backColor) + ")";

            XmlElement gLithoPattern = svgDoc.CreateElement("g");
            gLithoPattern.SetAttribute("ID", "idLitho");

            XmlElement gLithoPatternPath = svgDoc.CreateElement("path");
            gLithoPatternPath.SetAttribute("d", d);
            gLithoPatternPath.SetAttribute("style", "stroke-width:0.1");
            gLithoPatternPath.SetAttribute("stroke", "black");
            gLithoPatternPath.SetAttribute("fill", sURL);
            gLithoPatternPath.SetAttribute("onmouseover","this.style.stroke = '#ff0000'; this.style['stroke-width'] = 0.5;");
            gLithoPatternPath.SetAttribute("onmouseout", "this.style.stroke = 'black'; this.style['stroke-width'] = 0.5;");
 
            gLithoPattern.AppendChild(gLithoPatternPath);
            return gLithoPattern;
        }

        public XmlElement addLithoPatternSand(string sLithoName, int iWidthUnit, int iHeightUnit, string backColor, int ix,int iy,int iWidth,int iheight)//增加岩石类型
        {
            int idLitho = 0;
            //根据岩石名称选pattern;
            if (dictionaryPatternSand.ContainsKey(sLithoName)) idLitho = dictionaryPatternSand[sLithoName];

            string sURL = "url(#" + lithoPatternDefsSand(idLitho, iWidthUnit, iHeightUnit, backColor) + ")";

            XmlElement gLithoPattern = svgDoc.CreateElement("g");
            gLithoPattern.SetAttribute("ID", "idLitho");

            XmlElement gLithoPatternRect = svgDoc.CreateElement("rect");
            gLithoPatternRect.SetAttribute("x", ix.ToString());
            gLithoPatternRect.SetAttribute("y", iy.ToString());
            gLithoPatternRect.SetAttribute("height", iheight.ToString());
            gLithoPatternRect.SetAttribute("width", iWidth.ToString());
            gLithoPatternRect.SetAttribute("style", "stroke-width:1");
            gLithoPatternRect.SetAttribute("stroke", "black");
            gLithoPatternRect.SetAttribute("fill", sURL);
            gLithoPatternRect.SetAttribute("onclick", "xlGetAttribute(evt)");
            gLithoPatternRect.SetAttribute("onmouseover", "this.style.stroke = '#ff0000'; this.style['stroke-width'] = 0.5;");
            gLithoPatternRect.SetAttribute("onmouseout", "this.style.stroke = 'black'; this.style['stroke-width'] = 0.5;");

            gLithoPattern.AppendChild(gLithoPatternRect);
            return gLithoPattern;
        }
        public string lithoPatternDefsSand(int idLitho, int iWidthUnit, int iHeightUnit, string backColor)
        {
            int numColumn=0;
            int numRow =0;
            string fillColor = backColor;
            string strokeColor = backColor;


            float size = 5.0F;
            bool hasSplitLine = true;

        
          //首先确定格式 单元格数和是否显示 分割线  
            List<XmlElement> listPatternMark=new List<XmlElement>();
            if (idLitho == 101) 
            {
                numColumn = 2;
                numRow = 2;
                size = 3;
                //XmlElement pattern1 = patternElementSand(iWidthUnit, iHeightUnit, 0, 0, size, "yellow");
                //listPatternMark.Add(pattern1);
                //XmlElement pattern3 = patternElementSand(iWidthUnit, iHeightUnit, 1, 1, size, "yellow");
                //listPatternMark.Add(pattern3);
            }
            if (idLitho == 102)
            {
                numColumn = 2;
                numRow = 2;
                hasSplitLine = true;
                size = 2;
                //XmlElement pattern1 = patternElementSand(iWidthUnit, iHeightUnit, 0, 0, size, "yellow");
                //listPatternMark.Add(pattern1);
                //XmlElement pattern3 = patternElementSand(iWidthUnit, iHeightUnit, 1, 1, size, "yellow");
                //listPatternMark.Add(pattern3);
            }
            if (idLitho == 103)
            {
                numColumn = 2;
                numRow = 2;
                hasSplitLine = true;
                size = 1;
                //XmlElement pattern1 = patternElementSand(iWidthUnit, iHeightUnit, 0, 0, size, "yellow");
                //listPatternMark.Add(pattern1);
                //XmlElement pattern3 = patternElementSand(iWidthUnit, iHeightUnit, 1, 1, size, "yellow");
                //listPatternMark.Add(pattern3);
            }
            if (idLitho == 104)
            {
                numColumn = 2;
                numRow = 2;
                hasSplitLine = true;
                size = 0.5F;
                //XmlElement pattern1 = patternElementSiltSand(iWidthUnit, iHeightUnit, 0, 0, size, "yellow");
                //listPatternMark.Add(pattern1);
                //XmlElement pattern3 = patternElementSiltSand(iWidthUnit, iHeightUnit, 1, 1, size, "yellow");
                //listPatternMark.Add(pattern3);
            }
            if (idLitho == 105)
            {
                numColumn = 2;
                numRow = 2;
                hasSplitLine = true;
                size = 2.0F;
                //XmlElement pattern1 = patternElementSand(iWidthUnit, iHeightUnit, 0, 0, size, "yellow");
                //listPatternMark.Add(pattern1);
                //XmlElement pattern2 = patternElementSand(iWidthUnit, iHeightUnit, 0, 1, size/2, "yellow");
                //listPatternMark.Add(pattern2);
                //XmlElement pattern3 = patternElementSand(iWidthUnit, iHeightUnit, 1, 0, size/2, "yellow");
                //listPatternMark.Add(pattern3);
                //XmlElement pattern4 = patternElementSand(iWidthUnit, iHeightUnit, 1, 1, size, "yellow");
                //listPatternMark.Add(pattern4);
            }
            if (idLitho == 106)
            {
                numColumn = 2;
                numRow = 2;
                hasSplitLine = true;
                size = 1.0F;
                //XmlElement pattern1 = patternElementSand(iWidthUnit, iHeightUnit, 0, 0, size, "yellow");
                //listPatternMark.Add(pattern1);
                //XmlElement pattern2 = patternElementSiltSand(iWidthUnit, iHeightUnit, 0, 1, size/2, "yellow");
                //listPatternMark.Add(pattern2);
                //XmlElement pattern3 = patternElementSiltSand(iWidthUnit, iHeightUnit, 1, 0, size/2, "yellow");
                //listPatternMark.Add(pattern3);
                //XmlElement pattern4 = patternElementSand(iWidthUnit, iHeightUnit, 1, 1, size, "yellow");
                //listPatternMark.Add(pattern4);
            }

            if (idLitho == 107)
            {
                numColumn = 2;
                numRow = 2;
                hasSplitLine = true;
                size = 3;
                //XmlElement pattern1 = patternElementSand(iWidthUnit, iHeightUnit, 0, 0, size, "yellow");
                //listPatternMark.Add(pattern1);
                //XmlElement pattern2 =  patternElementQuartz( iWidthUnit, iHeightUnit, 0, 1);
                //listPatternMark.Add(pattern2);
                //XmlElement pattern3 = patternElementSand(iWidthUnit, iHeightUnit, 1, 1, size, "yellow");
                //listPatternMark.Add(pattern3);
                //XmlElement pattern4= patternElementQuartz(iWidthUnit, iHeightUnit, 1, 0);
                //listPatternMark.Add(pattern4);
            }
            if (idLitho == 108)
            {
                numColumn = 2;
                numRow = 2;
                hasSplitLine = true;
                size = 3;
                //XmlElement pattern1 = patternElementSand(iWidthUnit, iHeightUnit, 0, 0, size, "yellow");
                //listPatternMark.Add(pattern1);
                //XmlElement pattern2 = patternElementFe(iWidthUnit, iHeightUnit, 0, 1);
                //listPatternMark.Add(pattern2);
                //XmlElement pattern3 = patternElementSand(iWidthUnit, iHeightUnit, 1, 1, size, "yellow");
                //listPatternMark.Add(pattern3);
                //XmlElement pattern4 = patternElementFe(iWidthUnit, iHeightUnit, 1, 0);
                //listPatternMark.Add(pattern4);
            }
            if (idLitho == 109)
            {
                numColumn = 2;
                numRow = 2;
                hasSplitLine = true;
                size = 3;
                //XmlElement pattern1 = patternElementSand(iWidthUnit, iHeightUnit, 0, 0, size, "yellow");
                //listPatternMark.Add(pattern1);
                //XmlElement pattern2 = patternElementGlauconite(iWidthUnit, iHeightUnit, 0, 1);
                //listPatternMark.Add(pattern2);
                //XmlElement pattern3 = patternElementSand(iWidthUnit, iHeightUnit, 1, 1, size, "yellow");
                //listPatternMark.Add(pattern3);
                //XmlElement pattern4 = patternElementGlauconite(iWidthUnit, iHeightUnit, 1, 0);
                //listPatternMark.Add(pattern4);
            }
            if (idLitho == 127)
            {
                numColumn = 3;
                numRow = 2;
                hasSplitLine = true;
                size = 2;
                //XmlElement pattern1 = patternElemenTortoise(iWidthUnit, iHeightUnit, 0, 0);
                //listPatternMark.Add(pattern1);
                //XmlElement pattern2= patternElementSand(iWidthUnit, iHeightUnit, 0, 1, size, "yellow");
                //listPatternMark.Add(pattern2);
                //XmlElement pattern3 = patternElementSand(iWidthUnit, iHeightUnit, 0, 2, size, "yellow");
                //listPatternMark.Add(pattern3);
                //XmlElement pattern4 = patternElementSand(iWidthUnit, iHeightUnit, 1, 0, size, "yellow");
                //listPatternMark.Add(pattern4);
                //XmlElement pattern5 = patternElementSand(iWidthUnit, iHeightUnit, 1, 1, size, "yellow");
                //listPatternMark.Add(pattern5);
                //XmlElement pattern6= patternElemenTortoise(iWidthUnit, iHeightUnit, 1, 2);
                //listPatternMark.Add(pattern6);
            }

            XmlElement lithoPattern = svgDoc.CreateElement("pattern");
            lithoPattern.SetAttribute("id", idLitho.ToString());
            lithoPattern.SetAttribute("patternUnits", "userSpaceOnUse");
            lithoPattern.SetAttribute("x", "0");
            lithoPattern.SetAttribute("y", "0");
            lithoPattern.SetAttribute("width", (iWidthUnit * numColumn).ToString());
            lithoPattern.SetAttribute("height", (iHeightUnit * numRow).ToString());
            lithoPattern.SetAttribute("viewBox", "0 0 " + (iWidthUnit * numColumn).ToString() + " " + (iHeightUnit * numRow).ToString());

            //XmlElement gBackRect = backRect(backColor, iWidthUnit, iHeightUnit, numColumn, numRow);
            //lithoPattern.AppendChild(gBackRect);

            //if (hasSplitLine == true)
            //{
            //    XmlElement gSplitLine = splitLine(iWidthUnit, iHeightUnit, numColumn, numRow);
            //    lithoPattern.AppendChild(gSplitLine);
            //}

            for (int i = 0; i < listPatternMark.Count; i++) 
            {
                lithoPattern.AppendChild(listPatternMark[i]);
            }
        
            svgDefs.AppendChild(lithoPattern);

            return idLitho.ToString();
        }
        
    }
}
