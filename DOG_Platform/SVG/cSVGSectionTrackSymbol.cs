using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace DOGPlatform.SVG
{
    class cSVGSectionTrackSymbol
    {
        public static XmlElement gTrackIntervalSymbol(XmlDocument svgDoc, XmlElement svgDefs, ItemTrackDrawDataIntervalProperty item, double fVScale, int iTrackwidth)
        {
            string sID = item.sID;
            double fTop = item.top * fVScale;
            double fBot = item.bot * fVScale;
            string sCodeName = item.sProperty;
            string sText = item.sText;
            XmlElement gSymbolItem = svgDoc.CreateElement("g");
            XmlElement eleRect = svgDoc.CreateElement("rect");
            eleRect.SetAttribute("x", "0");
            eleRect.SetAttribute("y", fTop.ToString("0.0"));
            eleRect.SetAttribute("width", (iTrackwidth*0.3).ToString());
            double height = fBot - fTop;
            eleRect.SetAttribute("height", height.ToString("0.0"));
            eleRect.SetAttribute("id", sID);
            eleRect.SetAttribute("fill", "none");
            eleRect.SetAttribute("fill-opacity", "0.8");
            eleRect.SetAttribute("onclick", "getID(evt)");

            //从目录中查找包含pattern的svg原文件,文件名和sLithoID一致，svgdefs增加定义。？就是多个添加的时候 重复添加定义的问题，是否需要查找是否存在？
            string filePathPatternSVG = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "pattern", "符号", sCodeName + ".svg");
            if (File.Exists(filePathPatternSVG))
            {
                cSVGoperate.addSVGpatternDefs(svgDoc, svgDefs, sCodeName, filePathPatternSVG);
                eleRect.SetAttribute("fill", string.Format("url(#{0})", sCodeName));
            }
            else
            {
                eleRect.SetAttribute("fill", "white");
            }

            gSymbolItem.AppendChild(eleRect);

            XmlElement textRect = cSVGWrapText.rectWithTextLeftAlignWithoutRect(svgDoc, sID, sText, iTrackwidth * 0.3, fTop, height, iTrackwidth * 0.7, "black", 12);
            gSymbolItem.AppendChild(textRect);
            return gSymbolItem;
        }
 
      

        public static XmlElement gTrackRatioRect(XmlDocument svgDoc, string sID,double fTop, double fBottom, double fPercent, double fVScale, int iTrackWidth, string sColor)
        {
            fTop *= fVScale;
            fBottom *= fVScale;
            XmlElement gTrack = svgDoc.CreateElement("g");
            gTrack.SetAttribute("id", sID);
            XmlElement eRect = svgDoc.CreateElement("rect");
            eRect.SetAttribute("x", "0");
            eRect.SetAttribute("y", fTop.ToString());
            double fEndWidthPosition = iTrackWidth * fPercent * 0.01;
            eRect.SetAttribute("width", fEndWidthPosition.ToString());
            eRect.SetAttribute("height", (fBottom - fTop).ToString());
            eRect.SetAttribute("stroke-width", "0.1");
            eRect.SetAttribute("stroke", "none");
            eRect.SetAttribute("fill", sColor);

            XmlElement eText = svgDoc.CreateElement("text");
            eText.SetAttribute("x", (fEndWidthPosition + 1).ToString());
            eText.SetAttribute("y", (fTop * 0.5 + fBottom * 0.5).ToString());
            eText.SetAttribute("fill", "black");
            eText.SetAttribute("text-anchor", "start");
            eText.SetAttribute("font-size", "10");
            eText.SetAttribute("style", "strole-width:1");
            eText.SetAttribute("dominant-baseline", "central");
            eText.InnerText = fPercent.ToString() + "%";

            gTrack.AppendChild(eRect); 
            gTrack.AppendChild(eText);
            return gTrack;
        } 
    }
}
