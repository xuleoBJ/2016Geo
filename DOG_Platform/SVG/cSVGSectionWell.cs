using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Drawing;

namespace DOGPlatform.SVG
{
    class cSVGSectionWell :cSVGBaseSection
    {
        public XmlElement gWell { get; set; }
        public cSVGSectionWell(XmlDocument _svgDoc)
        {
            svgDoc = _svgDoc;
           gWell = svgDoc.CreateElement("g");
        }
        public cSVGSectionWell(XmlDocument _svgDoc,string sJH)
        {
            svgDoc = _svgDoc;
            gWell = svgDoc.CreateElement("g");
            gWell.SetAttribute("id", sJH);
        }
       
        public void addTrack(XmlElement gElement, int idx)  //剖面图Y不能移动
        {
            string sTranslate = "translate(" + idx.ToString() + ",0)";
            gElement.SetAttribute("transform", sTranslate);
            XmlNode importNewsItem = svgDoc.ImportNode(gElement, true);
            gWell.AppendChild(importNewsItem);
        }

        public void addTrack(XmlElement gElement, int idx,int idy)  //剖面图Y不能移动
        {
            string sTranslate = string.Format("translate({0},{1})", idx, idy);  
            gElement.SetAttribute("transform", sTranslate);
            XmlNode importNewsItem = svgDoc.ImportNode(gElement, true);
            gWell.AppendChild(importNewsItem);
    
        }

        public static XmlElement gWellHead( XmlDocument svgDoc,string sJH, double xView, double yView,  int iFontSize)
        {
            XmlElement gWellHead = svgDoc.CreateElement("g");

            XmlElement text = svgDoc.CreateElement("text");
            text.SetAttribute("x", xView.ToString());
            text.SetAttribute("y", yView.ToString());
            text.SetAttribute("fill", "black");
            text.SetAttribute("text-anchor", "middle");
            text.SetAttribute("dominant-baseline", "middle");
            text.SetAttribute("font-size", iFontSize.ToString());
            text.SetAttribute("style", "strole-width:1");
            text.InnerText = sJH;
            gWellHead.AppendChild(text);


            //填充颜色
            int iWellType = 0;
            ItemWell curWell = cProjectData.ltProjectWell.Single(p => p.sJH == sJH);
            if (curWell != null) iWellType = curWell.iWellType;
            string m_colorWell = "none";
            switch (iWellType)
            {
                case 1:
                    m_colorWell = "red";
                    break;
                case 3:
                    m_colorWell = "red";
                    break;
                case 5:
                    m_colorWell = "Gold";
                    break;
                case 15:
                    m_colorWell = "blue";
                    break;
                default:
                    break;
            }

            XmlElement circleHead = svgDoc.CreateElement("circle");
            circleHead.SetAttribute("cx", xView.ToString());
            circleHead.SetAttribute("cy", yView.ToString());
            circleHead.SetAttribute("r", "5");
            circleHead.SetAttribute("stroke", "black");
            circleHead.SetAttribute("fill", m_colorWell);
            gWellHead.AppendChild(circleHead);
            return gWellHead;
        }

        public XmlElement gWellHead(string sJH, double iTopPosi, double iBotPosi, int matTitleHeigh, int mapWidth, int iFontSize)
        {
            XmlElement gWellHead = svgDoc.CreateElement("g");
                       
            XmlElement text = svgDoc.CreateElement("text");
            text.SetAttribute("x", (2).ToString());
            text.SetAttribute("y", (iTopPosi * 0.5 + iBotPosi * 0.5 + 2).ToString());
            text.SetAttribute("fill", "black");
            text.SetAttribute("text-anchor", "middle");
            text.SetAttribute("dominant-baseline", "middle");
            text.SetAttribute("font-size", iFontSize.ToString());
            text.SetAttribute("style", "strole-width:1");
            text.InnerText = sJH;
            gWellHead.AppendChild(text);


            //填充颜色
            int iWellType = 0;
            ItemWell curWell = cProjectData.ltProjectWell.Single(p => p.sJH == sJH);
            if (curWell != null) iWellType = curWell.iWellType;
            string m_colorWell = "none";
            switch (iWellType)
            {
                case 1:
                    m_colorWell = "red";
                    break;
                case 3:
                    m_colorWell = "red";
                    break;
                case 5:
                    m_colorWell = "Gold";
                    break;
                case 15:
                    m_colorWell = "blue";
                    break;
                default:
                    break;
            }

            XmlElement circleHead = svgDoc.CreateElement("circle");
            circleHead.SetAttribute("cx", "0");
            circleHead.SetAttribute("cy", iBotPosi.ToString());
            circleHead.SetAttribute("r", "5");
            circleHead.SetAttribute("stroke", "black");
            circleHead.SetAttribute("fill", m_colorWell);
            gWellHead.AppendChild(circleHead);
            return gWellHead;
        }

    }
}
