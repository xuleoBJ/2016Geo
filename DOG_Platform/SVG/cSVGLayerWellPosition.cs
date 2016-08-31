using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml;
using System.Drawing;
using DOGPlatform.XML;
using System.IO;

namespace DOGPlatform.SVG
{
    class cSVGLayerWellPosition
    {
        public static XmlElement gWellsPosition(XmlDocument svgDoc, List<ItemWellMapPosition> listMapLayerWell, string sID, cXEWellCss wellCss, cXELayerPage curPage)
        {

            XmlElement gWellPositon = svgDoc.CreateElement("g");
            gWellPositon.SetAttribute("id", sID);

            foreach (ItemWellMapPosition item in listMapLayerWell)
            {
                Point pointConvert2View = cCordinationTransform.transRealPointF2ViewPoint(item.dbX, item.dbY, curPage.xRef, curPage.yRef, curPage.dfscale);
                gWellPositon.AppendChild(gWell(svgDoc, item.sJH, pointConvert2View.X, pointConvert2View.Y, item.iWellType, 
                    wellCss.iFontSizeJH, wellCss.iRadis, wellCss.iCirlceWidth, wellCss.DX_JHText, wellCss.DY_JHText));
            }
            return gWellPositon;
        }

        public static XmlElement gWell2
      (XmlDocument svgDoc, string sJH, int iXview, int iYview, int iWellType, int JHFontSize, int radis, int iCirlceWidth, int DX_JHText, int DY_JHText)
        {

            XmlElement gWell = svgDoc.CreateElement("g");
            XmlElement wellRect = svgDoc.CreateElement("rect");
            wellRect.SetAttribute("x", (iXview-radis/2).ToString());
            wellRect.SetAttribute("y", (iYview - radis / 2).ToString());
            wellRect.SetAttribute("width", radis.ToString());
            wellRect.SetAttribute("height", radis.ToString("0"));
            wellRect.SetAttribute("id", sJH);
            wellRect.SetAttribute("style", "stroke-width:1");
            wellRect.SetAttribute("stroke", "black");
            wellRect.SetAttribute("fill", "none");
            wellRect.SetAttribute("onclick", "getID(evt)");
            string m_colorWell = "none";
            if (iWellType == 3)
            {
                m_colorWell = "red";
            }
            else if (iWellType == 1)
            {
                XmlElement gWellSymbolUse = svgDoc.CreateElement("use");
                gWellSymbolUse.SetAttribute("x", iXview.ToString());
                gWellSymbolUse.SetAttribute("y", iYview.ToString());
                XmlAttribute WellSymbolNode = svgDoc.CreateAttribute("xlink", "href", "http://www.w3.org/1999/xlink");
                WellSymbolNode.Value = "#" + "idOilGasWellSymbol";
                gWellSymbolUse.Attributes.Append(WellSymbolNode);
                gWell.AppendChild(gWellSymbolUse);
                m_colorWell = "red";
            }
            else if (iWellType == 5)
            {
                m_colorWell = "Gold";
            }
            else if (iWellType == 15)
            {
                XmlElement gWellSymbolUse = svgDoc.CreateElement("use");
                gWellSymbolUse.SetAttribute("x", iXview.ToString());
                gWellSymbolUse.SetAttribute("y", iYview.ToString());
                XmlAttribute WellSymbolNode = svgDoc.CreateAttribute("xlink", "href", "http://www.w3.org/1999/xlink");
                WellSymbolNode.Value = "#" + "InjectWellSymbol";
                gWellSymbolUse.Attributes.Append(WellSymbolNode);
                gWell.AppendChild(gWellSymbolUse);
                m_colorWell = "blue";
            }

            else if (iWellType == 8)
            {
                XmlElement gWellSymbolUse = svgDoc.CreateElement("use");
                gWellSymbolUse.SetAttribute("x", iXview.ToString());
                gWellSymbolUse.SetAttribute("y", iYview.ToString());
                XmlAttribute WellSymbolNode = svgDoc.CreateAttribute("xlink", "href", "http://www.w3.org/1999/xlink");
                WellSymbolNode.Value = "#" + "idPlatformWell";
                gWellSymbolUse.Attributes.Append(WellSymbolNode);
                gWell.AppendChild(gWellSymbolUse);
                m_colorWell = "red";
            }
            else
            {
                m_colorWell = "black";
                XmlElement gWellSymbolInner = svgDoc.CreateElement("circle");
                gWellSymbolInner.SetAttribute("x", iXview.ToString());
                gWellSymbolInner.SetAttribute("y", iYview.ToString());
                gWellSymbolInner.SetAttribute("r", "1.5");
                gWellSymbolInner.SetAttribute("stroke", m_colorWell);
                gWellSymbolInner.SetAttribute("stroke-width", iCirlceWidth.ToString());
                gWellSymbolInner.SetAttribute("fill", "none");
                gWell.AppendChild(gWellSymbolInner);

            }
            XmlElement gWellSymbol = svgDoc.CreateElement("circle");
            gWellSymbol.SetAttribute("cx", iXview.ToString());
            gWellSymbol.SetAttribute("cy", iYview.ToString());
            gWellSymbol.SetAttribute("r", radis.ToString());
            gWellSymbol.SetAttribute("stroke", m_colorWell);
            gWellSymbol.SetAttribute("stroke-width", iCirlceWidth.ToString());
            gWellSymbol.SetAttribute("fill", "none");
            gWell.AppendChild(gWellSymbol);

            XmlElement gJHText = svgDoc.CreateElement("text");
            gJHText.SetAttribute("x", (iXview - DX_JHText).ToString());
            gJHText.SetAttribute("y", (iYview + DX_JHText).ToString());
            gJHText.SetAttribute("font-size", JHFontSize.ToString());
            gJHText.SetAttribute("font-style", "normal");
            gJHText.InnerText = sJH;
            gJHText.SetAttribute("fill", m_colorWell);
            gWell.AppendChild(gJHText);

            return gWell;
        }

        public static XmlElement gWell
         (XmlDocument svgDoc, string sJH, int iXview, int iYview, int iWellType, int  JHFontSize, int radis, int iCirlceWidth, int DX_JHText, int DY_JHText)
        {

            XmlElement gWell = svgDoc.CreateElement("g");
            gWell.SetAttribute("id", sJH);
            gWell.SetAttribute("onclick", "getID(evt)");
            string m_colorWell = "none";
            if (iWellType == 3)
            {
                m_colorWell = "red";
            }
            else if (iWellType == 1)
            {
                XmlElement gWellSymbolUse = svgDoc.CreateElement("use");
                gWellSymbolUse.SetAttribute("x", iXview.ToString());
                gWellSymbolUse.SetAttribute("y", iYview.ToString());
                XmlAttribute WellSymbolNode = svgDoc.CreateAttribute("xlink", "href", "http://www.w3.org/1999/xlink");
                WellSymbolNode.Value = "#" + "idOilGasWellSymbol";
                gWellSymbolUse.Attributes.Append(WellSymbolNode);
                gWell.AppendChild(gWellSymbolUse);
                m_colorWell = "red";
            }
            else if (iWellType == 5)
            {
                m_colorWell = "Gold";
            }
            else if (iWellType == 15)
            {
                XmlElement gWellSymbolUse = svgDoc.CreateElement("use");
                gWellSymbolUse.SetAttribute("x", iXview.ToString());
                gWellSymbolUse.SetAttribute("y", iYview.ToString());
                XmlAttribute WellSymbolNode = svgDoc.CreateAttribute("xlink", "href", "http://www.w3.org/1999/xlink");
                WellSymbolNode.Value = "#" + "InjectWellSymbol";
                gWellSymbolUse.Attributes.Append(WellSymbolNode);
                gWell.AppendChild(gWellSymbolUse);
                m_colorWell = "blue";
            }

            else if (iWellType == 8)
            {
                XmlElement gWellSymbolUse = svgDoc.CreateElement("use");
                gWellSymbolUse.SetAttribute("x", iXview.ToString());
                gWellSymbolUse.SetAttribute("y", iYview.ToString());
                XmlAttribute WellSymbolNode = svgDoc.CreateAttribute("xlink", "href", "http://www.w3.org/1999/xlink");
                WellSymbolNode.Value = "#" + "idPlatformWell";
                gWellSymbolUse.Attributes.Append(WellSymbolNode);
                gWell.AppendChild(gWellSymbolUse);
                m_colorWell = "red";
            }
            else
            {
                m_colorWell = "black";
                XmlElement gWellSymbolInner = svgDoc.CreateElement("circle");
                gWellSymbolInner.SetAttribute("id", sJH);
                gWellSymbolInner.SetAttribute("x", iXview.ToString());
                gWellSymbolInner.SetAttribute("y", iYview.ToString());
                gWellSymbolInner.SetAttribute("r", "1.5");
                gWellSymbolInner.SetAttribute("stroke", m_colorWell);
                gWellSymbolInner.SetAttribute("stroke-width", iCirlceWidth.ToString());
                gWellSymbolInner.SetAttribute("fill", "none");
                gWell.AppendChild(gWellSymbolInner);

            }
            XmlElement gWellSymbol = svgDoc.CreateElement("circle");
            gWellSymbol.SetAttribute("id", sJH);
            gWellSymbol.SetAttribute("cx", iXview.ToString());
            gWellSymbol.SetAttribute("cy", iYview.ToString());
            gWellSymbol.SetAttribute("r", radis.ToString());
            gWellSymbol.SetAttribute("stroke", m_colorWell);
            gWellSymbol.SetAttribute("stroke-width", iCirlceWidth.ToString());
            gWellSymbol.SetAttribute("fill", "none");
            gWell.AppendChild(gWellSymbol);

            XmlElement gJHText = svgDoc.CreateElement("text");
            gJHText.SetAttribute("x", (iXview - DX_JHText).ToString());
            gJHText.SetAttribute("y", (iYview + DY_JHText).ToString());
            gJHText.SetAttribute("font-size", JHFontSize.ToString());
            gJHText.SetAttribute("font-style", "normal");
            gJHText.InnerText = sJH;
            gJHText.SetAttribute("fill", m_colorWell);
            gWell.AppendChild(gJHText);

            return gWell;
        }


      


    }
}
