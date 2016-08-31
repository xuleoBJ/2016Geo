using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml;
using System.Windows.Forms;
using System.Drawing;

namespace DOGPlatform.SVG
{
    class cSVGBaseSection:cSVGBase
    {
        public cSVGBaseSection()
            : base()
        {

        }

        public cSVGBaseSection(double width, double height, double iDX, double iDY, string sUnit)
            : base(width, height, iDX, iDY, sUnit)
        {

        }
        public XmlElement gScaleRuler(float m_scale)
        {
            XmlElement gScaleRuler = svgDoc.CreateElement("g");
            gScaleRuler.SetAttribute("id", "ScaleRuler");
            float _sacleUnit = Convert.ToSingle(1000.0 * m_scale);

            for (int i = 0; i < 4; i++)
            {
                XmlElement gRect = svgDoc.CreateElement("rect");
                gRect.SetAttribute("x", (_sacleUnit * 0.25 * i).ToString());
                gRect.SetAttribute("y", "0");
                gRect.SetAttribute("width", (_sacleUnit * 0.25).ToString());
                gRect.SetAttribute("height", "2");
                if (i % 2 == 0) gRect.SetAttribute("fill", "black");
                if (i % 2 == 1) gRect.SetAttribute("fill", "none");
                gRect.SetAttribute("stroke-width", "1");
                gRect.SetAttribute("stroke", "black");
                gScaleRuler.AppendChild(gRect);
            }
            for (int i = 0; i < 5; i++)
            {
                XmlElement gLine = svgDoc.CreateElement("line");
                gLine.SetAttribute("x1", (_sacleUnit * 0.25 * i).ToString());
                gLine.SetAttribute("y1", "0");
                gLine.SetAttribute("x2", (_sacleUnit * 0.25 * i).ToString());
                gLine.SetAttribute("y2", "-3");
                gLine.SetAttribute("stroke", "black");
                gLine.SetAttribute("stroke-width", "1");
                gScaleRuler.AppendChild(gLine);
            }

            for (int i = 0; i < 5; i++)
            {
                XmlElement gText = svgDoc.CreateElement("text");
                gText.SetAttribute("x", (_sacleUnit * 0.25 * i - 5).ToString());
                gText.SetAttribute("y", "-4");
                gText.SetAttribute("font-size", "8");
                gText.InnerText = (250 * i).ToString() + "m";
                gText.SetAttribute("fill", "black");
                gScaleRuler.AppendChild(gText);
            }

            return gScaleRuler;
        }

        public XmlElement mapHeadTitle(string sTitle, double iTopPosi,double iBotPosi, int mapTitleHeight, int mapWidth, int iFontSize)
        {
            XmlElement gTrackHead = svgDoc.CreateElement("g");
            XmlElement gRectText = cSVGWrapText.rectWithTextOneLine(svgDoc, sTitle, iTopPosi, iBotPosi, mapWidth, "black", iFontSize,"#ffffff");
            gTrackHead.AppendChild(gRectText);
            return gTrackHead;
        }


        public XmlElement mapLegend(string sTitle, double iTopPosi, double iBotPosi, int matTitleHeigh, int mapWidth, int iFontSize)
        {
            XmlElement gTrackHead = svgDoc.CreateElement("g");
            XmlElement gRectText = cSVGWrapText.rectWithTextOneLine(svgDoc, sTitle, iTopPosi, iBotPosi, mapWidth, "black", iFontSize, "#ffffff");
            gTrackHead.AppendChild(gRectText);
            return gTrackHead;
        }
        public void addgElement2BaseLayer(XmlElement gElement, double iDx)  //剖面图Y不能移动
        {
            string sTranslate = "translate(" + (iDx + offsetX_gSVG).ToString() + " " + offsetY_gSVG.ToString() + ")";
            gElement.SetAttribute("transform", sTranslate);
            this.gBaseLayer.AppendChild(gElement);
        }
     
    }
}
