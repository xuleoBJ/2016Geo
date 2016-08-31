using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using DOGPlatform.XML;
using System.IO;

namespace DOGPlatform.SVG
{
    class cSVGSectionTrackLitho 
    {
        public static XmlElement gTrackLithoTVDItem(ItemWell curWell, XmlDocument svgDoc, XmlElement svgDefs, itemDrawDataIntervalValue item, double fVScale, int iTrackwidth)
        { 
          item.calTVD(curWell);
          string sID = item.sID;
          double fTop = item.topTVD * fVScale;
          double fBot = item.botTVD * fVScale;
          string backColor = "none";
          string sColorText = item.sProperty;
          double grainSize = item.fValue;
          if (cProjectManager.dicColor.ContainsKey(sColorText))
              backColor = cProjectManager.dicColor[item.sProperty];
          else if (cProjectManager.dicColor.ContainsValue(sColorText)) backColor = sColorText;
          else if (cPublicMethodBase.isValidColor(sColorText)) backColor = sColorText;
          double width = iTrackwidth * grainSize;

          string sLithoCode = "none";
          string fileNamePattern = "";
          ItemCode codeItem = cProjectManager.ltCodeItem.FirstOrDefault(p => p.chineseName == item.sText);
          if (codeItem != null)
          {
              fileNamePattern = codeItem.fileName + ".svg";
              sLithoCode = codeItem.sCode;
          }
          XmlElement gLithoItem = svgDoc.CreateElement("g");
          XmlElement gRectBack = svgDoc.CreateElement("rect");
          gRectBack.SetAttribute("onclick", "getID(evt)");
          gRectBack.SetAttribute("id", sID);
          gRectBack.SetAttribute("x", "0");
          gRectBack.SetAttribute("y", fTop.ToString());
          gRectBack.SetAttribute("width", (width).ToString());
          gRectBack.SetAttribute("height", (fBot - fTop).ToString());
          gRectBack.SetAttribute("style", "stroke-width:0.5");
          gRectBack.SetAttribute("stroke", "black");
          gRectBack.SetAttribute("fill", backColor);
          XmlElement gLithoRect = svgDoc.CreateElement("rect");
          gLithoRect.SetAttribute("onclick", "getID(evt)");
          gLithoRect.SetAttribute("id", sID);
          gLithoRect.SetAttribute("x", "0");
          gLithoRect.SetAttribute("y", fTop.ToString());
          gLithoRect.SetAttribute("width", (width).ToString());
          gLithoRect.SetAttribute("height", (fBot - fTop).ToString());
          gLithoRect.SetAttribute("style", "stroke-width:0.5");
          gLithoRect.SetAttribute("stroke", "black");
          //从目录中查找包含pattern的svg原文件,文件名和sLithoID一致，svgdefs增加定义。
          if (codeItem != null)
          {
              string filePathPatternSVG = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "pattern", "rock", codeItem.codeType, fileNamePattern);
              if (File.Exists(filePathPatternSVG))
              {
                  cSVGoperate.addSVGpatternDefs(svgDoc, svgDefs, sLithoCode, filePathPatternSVG);
                  gLithoRect.SetAttribute("fill", string.Format("url(#{0})", sLithoCode));
              }
          }
          else
          {
              gLithoRect.SetAttribute("fill", "white");
          }
          gLithoItem.AppendChild(gRectBack);
          gLithoItem.AppendChild(gLithoRect);
          return gLithoItem;
        }
      
        public static XmlElement gTrackLitho(XmlDocument svgDoc, XmlElement svgDefs, itemDrawDataIntervalValue  item, double fVScale, int iTrackwidth)
        {
            string sID = item.sID;
            double fTop = item.top * fVScale;
            double fBot = item.bot * fVScale;
            string backColor ="none" ;
            string sColorText = item.sProperty;
            double grainSize = item.fValue;
            if (cProjectManager.dicColor.ContainsKey(sColorText))
                backColor = cProjectManager.dicColor[item.sProperty];
            else if (cProjectManager.dicColor.ContainsValue(sColorText)) backColor = sColorText;
            else if (cPublicMethodBase.isValidColor(sColorText)) backColor = sColorText;
            double width = iTrackwidth * grainSize;
          
            string sLithoCode ="none";
            string fileNamePattern = "";
            ItemCode codeItem = cProjectManager.ltCodeItem.FirstOrDefault(p => p.chineseName == item.sText);
            if (codeItem != null) 
            { 
                fileNamePattern = codeItem.fileName+ ".svg";
                sLithoCode = codeItem.sCode;
            }
            XmlElement gLithoItem = svgDoc.CreateElement("g");
            XmlElement gRectBack = svgDoc.CreateElement("rect");
            gRectBack.SetAttribute("onclick", "getID(evt)");
            gRectBack.SetAttribute("id", sID);
            gRectBack.SetAttribute("x", "0");
            gRectBack.SetAttribute("y", fTop.ToString());
            gRectBack.SetAttribute("width", (width).ToString());
            gRectBack.SetAttribute("height", (fBot - fTop).ToString());
            gRectBack.SetAttribute("style", "stroke-width:0.5");
            gRectBack.SetAttribute("stroke", "black");
            gRectBack.SetAttribute("fill", backColor);
            XmlElement gLithoRect = svgDoc.CreateElement("rect");
            gLithoRect.SetAttribute("onclick", "getID(evt)");
            gLithoRect.SetAttribute("id", sID);
            gLithoRect.SetAttribute("x", "0");
            gLithoRect.SetAttribute("y", fTop.ToString());
            gLithoRect.SetAttribute("width", (width).ToString());
            gLithoRect.SetAttribute("height", (fBot - fTop).ToString());
            gLithoRect.SetAttribute("style", "stroke-width:0.5");
            gLithoRect.SetAttribute("stroke", "black");
            //从目录中查找包含pattern的svg原文件,文件名和sLithoID一致，svgdefs增加定义。
            if (codeItem!=null)
            {
                string filePathPatternSVG = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "pattern", "rock", codeItem.codeType, fileNamePattern );
                if (File.Exists(filePathPatternSVG))
                {
                    cSVGoperate.addSVGpatternDefs(svgDoc, svgDefs, sLithoCode, filePathPatternSVG);
                    gLithoRect.SetAttribute("fill", string.Format("url(#{0})", sLithoCode));
                }
            }
            else
            {
                gLithoRect.SetAttribute("fill", "white");
            }
            gLithoItem.AppendChild(gRectBack);
            gLithoItem.AppendChild(gLithoRect);
            return gLithoItem;
        }
    }
}
