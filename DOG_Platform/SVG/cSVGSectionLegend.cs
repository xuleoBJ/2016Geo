using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DOGPlatform.XML;
using System.Xml;
using System.IO;

namespace DOGPlatform.SVG
{
    class cSVGSectionLegend
    {
        public static XmlElement gItemLegend(XmlDocument svgDoc, XmlElement svgDefs, itemDrawDataIntervalValue item, double fVScale, int iTrackwidth)
        {
            string sID = item.sID;
            double fTop = item.top * fVScale;
            double fBot = item.bot * fVScale;
            string backColor = "none";
            string sColorText = item.sProperty;
            double grainSize = item.fValue;
            if (cProjectManager.dicColor.ContainsKey(sColorText))
                backColor = cProjectManager.dicColor[item.sProperty];
            else if (cProjectManager.dicColor.ContainsValue(sColorText)) backColor = sColorText;
            else if (cPublicMethodBase.isValidColor(sColorText)) backColor = sColorText;
            double width = iTrackwidth * grainSize;

            string sLithoCode = "none";
            ItemCode codeItem = cProjectManager.ltCodeItem.FirstOrDefault(p => p.chineseName == item.sText);
            if (codeItem != null) { sLithoCode = codeItem.fileName; }
            XmlElement gItem = svgDoc.CreateElement("g");
            XmlElement gLegendRect = svgDoc.CreateElement("rect");
            gLegendRect.SetAttribute("onclick", "getID(evt)");
            gLegendRect.SetAttribute("id", sID);
            gLegendRect.SetAttribute("x", "0");
            gLegendRect.SetAttribute("y", fTop.ToString());
            gLegendRect.SetAttribute("width", (width).ToString());
            gLegendRect.SetAttribute("height", (fBot - fTop).ToString());
            gLegendRect.SetAttribute("style", "stroke-width:0.5");
            gLegendRect.SetAttribute("stroke", "black");
            XmlElement gText = svgDoc.CreateElement("text");
            gText.SetAttribute("x", 100.ToString());
            gText.SetAttribute("y", (fBot+100).ToString());
            gText.InnerText = "sText";
            gText.SetAttribute("font-size", "14");
            gText.SetAttribute("stroke", "none");
            //gText.SetAttribute("stroke-width", stroke_width.ToString());
            gText.SetAttribute("fill", "red");
            //从目录中查找包含pattern的svg原文件,文件名和sLithoID一致，svgdefs增加定义。？就是多个添加的时候 重复添加定义的问题，是否需要查找是否存在？
            if (codeItem != null)
              gLegendRect.SetAttribute("fill", string.Format("url(#{0})", sLithoCode));
            else
                gLegendRect.SetAttribute("fill", "white");
            
            gItem.AppendChild(gText);
            gItem.AppendChild(gLegendRect);
            return gItem;
        }
    }
}
