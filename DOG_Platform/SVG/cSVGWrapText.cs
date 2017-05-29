using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Drawing;

namespace DOGPlatform.SVG
{
    class cSVGWrapText
    {
        public static XmlElement rectWithTextOneLine(XmlDocument svgDoc, string sText, double top, double bottom, double fLimitwidth, string sFontColor, int fontSize, string sRectColor)
        {
            XmlElement gWrapTextWithRect = svgDoc.CreateElement("g");
            XmlElement gTextRect = svgDoc.CreateElement("rect");
            gTextRect.SetAttribute("x", "0");
            gTextRect.SetAttribute("y", (top).ToString());
            gTextRect.SetAttribute("width", fLimitwidth.ToString());
            gTextRect.SetAttribute("height", (bottom - top).ToString());
            gTextRect.SetAttribute("style", "stroke:black;stroke-width:1");
            gTextRect.SetAttribute("fill", sRectColor);
            gWrapTextWithRect.AppendChild(gTextRect);

            XmlElement text = svgDoc.CreateElement("text");
            text.SetAttribute("x", (fLimitwidth * 0.5).ToString());
            text.SetAttribute("y", (top * 0.35 + bottom * 0.65).ToString());
            text.SetAttribute("fill", sFontColor);
            text.SetAttribute("text-anchor", "middle");
            text.SetAttribute("dominant-baseline", "central");
            text.SetAttribute("font-size", fontSize.ToString());
            text.SetAttribute("style", "strole-width:1");
            text.InnerText = sText;
            gWrapTextWithRect.AppendChild(text);
            return gWrapTextWithRect;
        }

        public static XmlElement rectWithText(XmlDocument svgDoc, string sID, string sText, double x, double y, double height, double fLimitwidth, string sFontColor, int fontSize, string sRectColor, string sWriteMode)
        {
            if (sWriteMode == "tb") return rectWithTextVertical(svgDoc,sID, sText, x, y, height, fLimitwidth, sFontColor, fontSize, sRectColor);
            else return rectWithText(svgDoc,sID, sText, x, y, height, fLimitwidth, sFontColor, fontSize, sRectColor); 
        }

        public static XmlElement rectWithText(XmlDocument svgDoc, string sID,string sText, double x, double y, double height, double fLimitwidth, string sFontColor, int fontSize, string sRectColor)
        {
            XmlElement gWrapTextWithRect = svgDoc.CreateElement("g");
            XmlElement gTextRect = svgDoc.CreateElement("rect");
            gTextRect.SetAttribute("id", sID);
            gTextRect.SetAttribute("onclick", "getID(evt)");
            gTextRect.SetAttribute("x", x.ToString());
            gTextRect.SetAttribute("y", y.ToString());
            gTextRect.SetAttribute("width", fLimitwidth.ToString());
            gTextRect.SetAttribute("height", height.ToString());
            gTextRect.SetAttribute("style", "stroke:black;stroke-width:1");
            gTextRect.SetAttribute("fill", sRectColor);
            gWrapTextWithRect.AppendChild(gTextRect);

            //分行处理
            XmlElement text = svgDoc.CreateElement("text");
            text.SetAttribute("x", (fLimitwidth * 0.5).ToString());
            text.SetAttribute("y", (y + height * 0.5).ToString());
            text.SetAttribute("fill", sFontColor);
            text.SetAttribute("text-anchor", "middle");
            text.SetAttribute("dominant-baseline", "text-after-edge");
            text.SetAttribute("font-size", fontSize.ToString());
            text.SetAttribute("style", "strole-width:1");

            List<string> ltBreakText = cPublicMethodBase.splitText2LimitLineWithChangLine(sText, (int)fLimitwidth, SystemFonts.DefaultFont);
            double fStartTextY = y + height * 0.35;
            double fLineHeight = SystemFonts.DefaultFont.Height;
            if (height < (fLineHeight+5)) fStartTextY = y + fLineHeight/2+2;

            int iLineNum= ltBreakText.Count;
            for (int k = 0; k < iLineNum; k++)
            {
                XmlElement tspan = svgDoc.CreateElement("tspan");
                tspan.SetAttribute("x", (fLimitwidth * 0.5).ToString());
                tspan.SetAttribute("y", (fStartTextY  + fLineHeight * k).ToString());
                tspan.InnerText = ltBreakText[k];
                text.AppendChild(tspan);
            }

            gWrapTextWithRect.AppendChild(text);
            return gWrapTextWithRect;
        }

        public static XmlElement rectWithTextLeftAlignWithoutRect(XmlDocument svgDoc, string sID, string sText, double x, double y, double height, double fLimitwidth, string sFontColor, int fontSize )
        {
            XmlElement gWrapTextWithRect = svgDoc.CreateElement("g");
            //分行处理
            XmlElement text = svgDoc.CreateElement("text");
            text.SetAttribute("x", (fLimitwidth * 0.5).ToString());
            text.SetAttribute("y", (y + height * 0.5).ToString());
            text.SetAttribute("fill", sFontColor);
            text.SetAttribute("text-anchor", "start");
            text.SetAttribute("dominant-baseline", "text-after-edge");
            text.SetAttribute("font-size", fontSize.ToString());
            text.SetAttribute("style", "strole-width:1");

            List<string> ltBreakText = cPublicMethodBase.splitText2LimitLineWithChangLine(sText, (int)fLimitwidth, SystemFonts.DefaultFont);
            double fLineHeight = SystemFonts.DefaultFont.Height;
            double fStartTextY = y + 2 + fLineHeight;
            int iLineNum = ltBreakText.Count;
            for (int k = 0; k < iLineNum; k++)
            {
                XmlElement tspan = svgDoc.CreateElement("tspan");
                tspan.SetAttribute("x", (x+2).ToString());
                tspan.SetAttribute("y", (fStartTextY + k * fLineHeight).ToString());
                tspan.InnerText = ltBreakText[k];
                text.AppendChild(tspan);
            }

            gWrapTextWithRect.AppendChild(text);
            return gWrapTextWithRect;
        }

        public static XmlElement rectWithTextLeftAlign(XmlDocument svgDoc, string sID, string sText, double x, double y, double height, double fLimitwidth, string sFontColor, int fontSize, string sRectColor)
        {
            XmlElement gWrapTextWithRect = svgDoc.CreateElement("g");
            XmlElement gTextRect = svgDoc.CreateElement("rect");
            gTextRect.SetAttribute("id", sID);
            gTextRect.SetAttribute("onclick", "getID(evt)");
            gTextRect.SetAttribute("x", x.ToString());
            gTextRect.SetAttribute("y", y.ToString());
            gTextRect.SetAttribute("width", fLimitwidth.ToString());
            gTextRect.SetAttribute("height", height.ToString());
            gTextRect.SetAttribute("style", "stroke:black;stroke-width:1");
            gTextRect.SetAttribute("fill", sRectColor);
            gWrapTextWithRect.AppendChild(gTextRect);

            double fLineHeight = SystemFonts.DefaultFont.Height;
            //分行处理
            XmlElement text = svgDoc.CreateElement("text");
            text.SetAttribute("x", (fLimitwidth * 0.5).ToString());
            text.SetAttribute("y", (y + height * 0.5 + fontSize).ToString());
            text.SetAttribute("fill", sFontColor);
            text.SetAttribute("text-anchor", "start");
            text.SetAttribute("dominant-baseline", "text-after-edge");
            text.SetAttribute("font-size", fontSize.ToString());
            text.SetAttribute("style", "strole-width:1");

            List<string> ltBreakText = cPublicMethodBase.splitText2LimitLineWithChangLine(sText, (int)fLimitwidth, SystemFonts.DefaultFont);

            double fStartTextY = y+ 2 + fLineHeight;
            int iLineNum = ltBreakText.Count;
            for (int k = 0; k < iLineNum; k++)
            {
                XmlElement tspan = svgDoc.CreateElement("tspan");
                tspan.SetAttribute("x", (x+2).ToString());
                tspan.SetAttribute("y", (fStartTextY + k* fLineHeight).ToString());
                tspan.InnerText = ltBreakText[k];
                text.AppendChild(tspan);
            }

            gWrapTextWithRect.AppendChild(text);
            return gWrapTextWithRect;
        }
        //带垂直文本的,不分行处理
        public static XmlElement rectWithTextVertical(XmlDocument svgDoc,string sID, string sText, double x, double y, double height, double fLimitwidth, string sFontColor, int fontSize, string sRectColor)
        {
            XmlElement gWrapTextWithRect = svgDoc.CreateElement("g");
            XmlElement gTextRect = svgDoc.CreateElement("rect");
            gTextRect.SetAttribute("id", sID);
            gTextRect.SetAttribute("onclick", "getID(evt)");
            gTextRect.SetAttribute("x", x.ToString());
            gTextRect.SetAttribute("y", y.ToString());
            gTextRect.SetAttribute("width", fLimitwidth.ToString());
            gTextRect.SetAttribute("height", height.ToString());
            gTextRect.SetAttribute("style", "stroke:black;stroke-width:0.5");
            gTextRect.SetAttribute("fill", sRectColor);
            gWrapTextWithRect.AppendChild(gTextRect);

            XmlElement text = svgDoc.CreateElement("text");
            text.SetAttribute("x", (fLimitwidth * 0.4).ToString());
            text.SetAttribute("y", (y+height*0.5).ToString());
            text.SetAttribute("fill", sFontColor);
            text.SetAttribute("text-anchor", "middle");
            text.SetAttribute("dominant-baseline", "middle");
            text.SetAttribute("font-size", fontSize.ToString());
            text.SetAttribute("style", "strole-width:1");
            text.SetAttribute("writing-mode", "tb");
            text.InnerText = sText;
            gWrapTextWithRect.AppendChild(text);
            return gWrapTextWithRect;
        }
    
    }
  
}
