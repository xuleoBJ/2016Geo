using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace DOGPlatform.SVG
{
    class cSVGSectionTrack : cSVGBase
    {
        public cSVGSectionTrack() 
        {
            this.iTrackWidth = 15;
        }
        public cSVGSectionTrack(int _iTrackWidth)
        {
            this.iTrackWidth = _iTrackWidth;
        }
        public int iTrackWidth { get; set; }

        public static XmlElement trackHead(XmlDocument svgDoc, string sID,string sTitle, double iTopDepth,int iTrackHeadHeigh, int width,int iFontSize,string sWriteMode)
        {
            XmlElement gRectText = cSVGWrapText.rectWithText(svgDoc, sID,sTitle, 0, iTopDepth, iTrackHeadHeigh, width, "black", iFontSize, "#ffffff", sWriteMode);
            return gRectText;
        }
        public static XmlElement trackRect(XmlDocument svgDoc, string sID,double iTopDepth, double iBottomDepth, double fVScale, int width)
        {
            iTopDepth *= fVScale;
            iBottomDepth *= fVScale;
            double height = iBottomDepth - iTopDepth;
            XmlElement gTrackRect = svgDoc.CreateElement("rect");
            gTrackRect.SetAttribute("id", sID);
         //   gTrackRect.SetAttribute("onclick", "getID(evt)");
            gTrackRect.SetAttribute("x", "0");
            gTrackRect.SetAttribute("y", iTopDepth.ToString());
            gTrackRect.SetAttribute("width", width.ToString());
            gTrackRect.SetAttribute("height", height.ToString());
            gTrackRect.SetAttribute("class", "TrackRectCss");
            return gTrackRect;
        }

        public static XmlElement trackVerticalGrid(XmlDocument svgDoc, XmlElement svgDefs, double x, double y, double fVScale, double width, double height)
        {
             addVerticalLine2Def(svgDoc,svgDefs,  fVScale, height);
            XmlElement gVerticalGrid = svgDoc.CreateElement("g");
            for (int i = 1; i <= 10; i++)
            {
                XmlElement gUse = svgDoc.CreateElement("use");
                gUse.SetAttribute("x", (width * 0.1 * i).ToString());
                gUse.SetAttribute("y", "0");
                gUse.SetAttribute("xlink:href", "#" + cIDmake.idGridVertical);
                gVerticalGrid.AppendChild(gUse);
            }
            return gVerticalGrid;
        }
       
        public static int getNumGridGroupInLog(double leftValue,double rightValue) 
        {
            int logGridGroup = 1; //定义画的网格组数
            if (leftValue <= 0) logGridGroup = (int)Math.Ceiling(Math.Log10(rightValue));
            else logGridGroup = (int)Math.Ceiling(Math.Log10(rightValue / leftValue));
            return logGridGroup;
        }

        public static XmlElement trackVerticalGridLog(XmlDocument svgDoc, XmlElement svgDefs, double x, double y, double fVScale, int iTrackWidth, double height, double leftValue, double rightValue)
        {
            int logGridGroup = getNumGridGroupInLog(leftValue, rightValue);
            return trackVerticalGridLog(svgDoc,svgDefs, x, y,fVScale, iTrackWidth, height, logGridGroup);
        }

       static void addVerticalLine2Def(XmlDocument svgDoc, XmlElement svgDefs,  double fVScale, double height)
        {
             string sPath = string.Format("//*[@id='{0}']", cIDmake.idGridVertical);
            XmlNode selectedNode = svgDefs.SelectSingleNode(sPath);
            if (selectedNode == null)
            {
                XmlElement gSubVerticalGrid = svgDoc.CreateElement("line");
                gSubVerticalGrid.SetAttribute("id", cIDmake.idGridVertical);
                gSubVerticalGrid.SetAttribute("x1", "0");
                gSubVerticalGrid.SetAttribute("y1", "0");
                gSubVerticalGrid.SetAttribute("x2", "0");
                gSubVerticalGrid.SetAttribute("y2", (height * fVScale).ToString());
                gSubVerticalGrid.SetAttribute("style", "stroke-width:0.5");
                gSubVerticalGrid.SetAttribute("stroke", "gray");
                gSubVerticalGrid.SetAttribute("fill", "none");
                svgDefs.AppendChild(gSubVerticalGrid);
            } 
        
        }

        public static XmlElement trackVerticalGridLog(XmlDocument svgDoc, XmlElement svgDefs, double x, double y, double fVScale, int iTrackWidth, double height, int iGridGroup)
        {

             addVerticalLine2Def(svgDoc,svgDefs,  fVScale, height);
            //分的对数网格数
            XmlElement gVerticalGrid = svgDoc.CreateElement("g");
            x *= fVScale;
            y *= fVScale;
            height *= fVScale;
            double widthLogGrid = iTrackWidth / iGridGroup;
            for (int j = 0; j < iGridGroup; j++)
            {
                x = (int)widthLogGrid * j;
                for (int i = 1; i <= 10; i++)
                {
                    XmlElement gUse = svgDoc.CreateElement("use");
                    gUse.SetAttribute("x", (x+widthLogGrid * Math.Log10(i)).ToString());
                    gUse.SetAttribute("y", "0");
                    gUse.SetAttribute("xlink:href", "#" + cIDmake.idGridVertical);
                    gVerticalGrid.AppendChild(gUse);
                }
            }
            return gVerticalGrid;
        }

        public static XmlElement trackHorizonalGrid(XmlDocument svgDoc, XmlElement svgDefs, double dfDS1Show, double dfDS2Show, double fVScale, int iTrackWidth)
        {
            dfDS1Show *= fVScale;
            dfDS2Show *= fVScale;
            string sID = cIDmake.idGridLineHorizonal();

            XmlElement gSubHorizonalGrid = svgDoc.CreateElement("line");
            gSubHorizonalGrid.SetAttribute("id", sID);
            gSubHorizonalGrid.SetAttribute("x1", "0");
            gSubHorizonalGrid.SetAttribute("y1", "0");
            gSubHorizonalGrid.SetAttribute("x2", iTrackWidth.ToString());
            gSubHorizonalGrid.SetAttribute("y2", "0");
            gSubHorizonalGrid.SetAttribute("style", "stroke-width:0.5");
            gSubHorizonalGrid.SetAttribute("stroke", "gray");
            gSubHorizonalGrid.SetAttribute("fill", "none");
            svgDefs.AppendChild(gSubHorizonalGrid); 

            XmlElement gHorizonalGrid = svgDoc.CreateElement("g");
            int iStartY = Convert.ToInt16(Math.Ceiling(Convert.ToDouble(dfDS1Show) / 10)) * 10;
            while (iStartY <= dfDS2Show)
            {
                XmlElement gUse = svgDoc.CreateElement("use");
                gUse.SetAttribute("x", "0");
                gUse.SetAttribute("y", iStartY.ToString());
                gUse.SetAttribute("xlink:href", "#"+sID);
                gHorizonalGrid.AppendChild(gUse);
                iStartY += 10;
            }
            return gHorizonalGrid;
        }

        public static XmlElement textLogHead(XmlDocument svgDoc, double ix, double iy, string sText, string sColor, int fontSize,string textAnchor)
        {
            XmlElement textValue = svgDoc.CreateElement("text");
            int iFontSize = fontSize;
            textValue.SetAttribute("x", ix.ToString());
            textValue.SetAttribute("y", (iy - iFontSize / 2).ToString());
            textValue.SetAttribute("font-size", iFontSize.ToString());
            textValue.SetAttribute("text-anchor", textAnchor);
            textValue.SetAttribute("tdominant-baseline", "ideographic");
            textValue.SetAttribute("fill", sColor);
            textValue.InnerText = sText;
            return textValue;
        }

        public static XmlElement addTrackItemLogHeadInfor(XmlDocument svgDoc, itemLogHeadInforDraw item, double iYPotionBot,int iLogNum, int width, int iFontSize)
        {
            int iUpLine = iFontSize+10; //不同测井曲线间隔距离
            int iFirstLogheadLinePosition = 3;  //首条logheadLine线距离下边框的距离
            double iYPotion = iYPotionBot - iUpLine * (iLogNum - 1) - iFirstLogheadLinePosition;
            return addTrackItemLogHeadInfor(svgDoc, item.sIDLog, item.sLogName, item.sUnit,
            iYPotion, width, item.fLeftValue, item.fRightValue, item.sLogColor, item.sFill, codeReplace.codeReplaceStrokeDashInt2Str(item.iLineType), iFontSize);
        }


        public static XmlElement addTrackItemLogHeadInfor(XmlDocument svgDoc, itemLogHeadInforDraw item, double iYPotion, int width,int iFontSize)
        {
            return addTrackItemLogHeadInfor(svgDoc, item.sIDLog, item.sLogName, item.sUnit,
            iYPotion, width,item.fLeftValue, item.fRightValue , item.sLogColor,item.sFill, codeReplace.codeReplaceStrokeDashInt2Str(item.iLineType),iFontSize );
        }

        static string getValueStr(double _value)
        {
            string strValue = _value.ToString();
            if ((_value % 1) != 0) strValue = _value.ToString("0.00");
            return strValue;
        }

        //分割线上下分割的测井头，iYPosition是从下面起始的位置
        public static XmlElement addTrackItemLogHeadInfor2(XmlDocument svgDoc, string sIDlog, string sLogName, string sUnit,
        double iYPotion, int trackWidth, double valueLeft, double valueRight, string sColorCurve, string sBackFill, string strokeDashArray, int iFontSize)
        {
            XmlElement gItemLogHeadInfor = svgDoc.CreateElement("g");
            XmlElement gLogHeadRect = svgDoc.CreateElement("rect");
            gLogHeadRect.SetAttribute("id", sIDlog);
            gLogHeadRect.SetAttribute("onclick", "getID(evt)");
            gLogHeadRect.SetAttribute("x", "1");
            gLogHeadRect.SetAttribute("y", (iYPotion - iHeightLogHeadItem).ToString());
            gLogHeadRect.SetAttribute("width", (trackWidth - 2).ToString());
            gLogHeadRect.SetAttribute("height", (iHeightLogHeadItem).ToString());
            if (sBackFill == "none") sBackFill = "white"; //充填白色背景便于点击
            gLogHeadRect.SetAttribute("fill", sBackFill);
            gLogHeadRect.SetAttribute("stroke", "white");
            gItemLogHeadInfor.AppendChild(gLogHeadRect);
            string sLogHeadText = sLogName;
            if (sUnit != "") sLogHeadText += "(" + sUnit + ")";
            XmlElement headRectText = textLogHead(svgDoc, trackWidth * 0.5, iYPotion - iHeightLogHeadItem / 2, sLogHeadText, sColorCurve, iFontSize, "middle");
            gItemLogHeadInfor.AppendChild(headRectText);
            int iSpace = 2;
            XmlElement leftValueText = textLogHead(svgDoc, iSpace, iYPotion, getValueStr(valueLeft), sColorCurve, iFontSize, "start");
            gItemLogHeadInfor.AppendChild(leftValueText);
            XmlElement rightValueText = textLogHead(svgDoc, trackWidth - iSpace, iYPotion, getValueStr(valueRight), sColorCurve, iFontSize, "end");
            gItemLogHeadInfor.AppendChild(rightValueText);

            //添加道头刻度标尺，X位置取道宽一半偏左，Y位置去深度最小值对应的海拔更低一些
            XmlElement logHeadLine = svgDoc.CreateElement("path");
            string sPath = "m2 " + (iYPotion - iHeightLogHeadItem / 2 - 1).ToString() + " h " + (trackWidth - 4).ToString();
            logHeadLine.SetAttribute("d", sPath);
            logHeadLine.SetAttribute("style", "stroke-width:1");
            logHeadLine.SetAttribute("stroke", sColorCurve);
            logHeadLine.SetAttribute("stroke-dasharray", strokeDashArray);
            logHeadLine.SetAttribute("fill", "none");
            logHeadLine.SetAttribute("id", sIDlog); //sID存入sIDLog,为了点击捕捉
            logHeadLine.SetAttribute("onclick", "getID(evt)");
            gItemLogHeadInfor.AppendChild(logHeadLine);
            return gItemLogHeadInfor;
        }

        public static int iHeightLogHeadItem = 20;
        public static XmlElement addTrackItemLogHeadInfor(XmlDocument svgDoc, string sIDlog,string sLogName,string sUnit,
         double iYPotion, int trackWidth, double valueLeft, double valueRight, string sColorCurve,string sBackFill, string strokeDashArray, int iFontSize)
        {
            XmlElement gItemLogHeadInfor = svgDoc.CreateElement("g");
            XmlElement gLogHeadRect = svgDoc.CreateElement("rect");
            gLogHeadRect.SetAttribute("id", sIDlog);
            gLogHeadRect.SetAttribute("onclick", "getID(evt)");
            gLogHeadRect.SetAttribute("x", "1");
            gLogHeadRect.SetAttribute("y", (iYPotion - iHeightLogHeadItem).ToString());
            gLogHeadRect.SetAttribute("width", (trackWidth - 2).ToString());
            gLogHeadRect.SetAttribute("height", iHeightLogHeadItem.ToString());
            if (sBackFill == "none") sBackFill = "white"; //充填白色背景便于点击
           gLogHeadRect.SetAttribute("fill", sBackFill);
            gLogHeadRect.SetAttribute("stroke", "white");
            gItemLogHeadInfor.AppendChild(gLogHeadRect);
            string sLogHeadText=sLogName;
            if(sUnit!="")  sLogHeadText+= "(" + sUnit+")" ;
            XmlElement headRectText = textLogHead(svgDoc, trackWidth * 0.5, iYPotion, sLogHeadText, sColorCurve, iFontSize, "middle");
            gItemLogHeadInfor.AppendChild(headRectText);
            int iSpace = 2;
            XmlElement leftValueText = textLogHead(svgDoc, iSpace, iYPotion, getValueStr(valueLeft), sColorCurve, iFontSize, "start");
            gItemLogHeadInfor.AppendChild(leftValueText);
            XmlElement rightValueText = textLogHead(svgDoc, trackWidth - iSpace, iYPotion, getValueStr(valueRight), sColorCurve, iFontSize, "end");
            gItemLogHeadInfor.AppendChild(rightValueText);

            //添加道头刻度标尺，X位置取道宽一半偏左，Y位置去深度最小值对应的海拔更低一些
            XmlElement logHeadLine = svgDoc.CreateElement("path");
            string sPath = "m2 " + (iYPotion - 1).ToString() + " h " + (trackWidth - 4).ToString();
            logHeadLine.SetAttribute("d", sPath);
            logHeadLine.SetAttribute("style", "stroke-width:1");
            logHeadLine.SetAttribute("stroke", sColorCurve);
            logHeadLine.SetAttribute("stroke-dasharray", strokeDashArray);
            logHeadLine.SetAttribute("fill", "none");
            logHeadLine.SetAttribute("id", sIDlog); //sID存入sIDLog,为了点击捕捉
            logHeadLine.SetAttribute("onclick", "getID(evt)");
            gItemLogHeadInfor.AppendChild(logHeadLine);
            return gItemLogHeadInfor;
        }
    }
}
