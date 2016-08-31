using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace DOGPlatform.SVG
{
    class cSVGSectionTrackWellBone
    {
        public static XmlElement gTrackItemWellBone(XmlDocument svgDoc, XmlElement svgDefs, ItemTrackDrawDataIntervalProperty item, double fVScale, int iTrackwidth)
        {
            string sID = item.sID;
            double fTop = item.top * fVScale;
            double fBot = item.bot * fVScale;
            string subDir = item.sProperty;
            string sCodeName = item.sText;
            XmlElement eleRect = svgDoc.CreateElement("rect");
            eleRect.SetAttribute("x", "0");
            eleRect.SetAttribute("y", fTop.ToString("0.0"));
            eleRect.SetAttribute("width", iTrackwidth.ToString());
            double height = fBot - fTop;
            eleRect.SetAttribute("height", height.ToString("0.0"));
            eleRect.SetAttribute("id", sID);
            eleRect.SetAttribute("fill", "none");
            eleRect.SetAttribute("fill-opacity", "0.8");
            eleRect.SetAttribute("onclick", "getID(evt)");

            //从目录中查找包含pattern的svg原文件,文件名和sLithoID一致，svgdefs增加定义。？就是多个添加的时候 重复添加定义的问题，是否需要查找是否存在？
            string filePathPatternSVG = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "pattern", "井柱", subDir, sCodeName + ".svg");
            if (File.Exists(filePathPatternSVG))
            {
                cSVGoperate.addSVGpatternDefs(svgDoc, svgDefs, sCodeName, filePathPatternSVG);
                eleRect.SetAttribute("fill", string.Format("url(#{0})", sCodeName));
            }
            else
            {
                eleRect.SetAttribute("fill", "white");
            }
            return eleRect;
        }
    }
}
