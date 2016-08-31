using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Drawing;
namespace DOGPlatform.SVG
{
    class cSVGElement : cSVGBase
    {
        public XmlElement gElementRect(int x, int y, int width, int height,
     string strokeColor, float stroke_width, string fillColor)
        {
            XmlElement gRect = svgDoc.CreateElement("rect");
            gRect.SetAttribute("x", x.ToString());
            gRect.SetAttribute("y", y.ToString());
            gRect.SetAttribute("width", width.ToString());
            gRect.SetAttribute("height", height.ToString());
            gRect.SetAttribute("stroke", strokeColor);
            gRect.SetAttribute("stroke-width", stroke_width.ToString());
            gRect.SetAttribute("fill", fillColor);
            return gRect;
        }

        

        public XmlElement gElementCircle()
        {
            XmlElement gCircle = svgDoc.CreateElement("circle");
            gCircle.SetAttribute("cx", "2");
            gCircle.SetAttribute("cy", "2");
            gCircle.SetAttribute("r", "0.4");
            gCircle.SetAttribute("stroke", "black");
            gCircle.SetAttribute("style", "stroke-width:0.1");
            gCircle.SetAttribute("fill", "yellow");
            return gCircle;
        }

        public XmlElement gElementLine(Point pWell1view, Point pWell2view,
          string strokeColor, float stroke_width, string fillColor)
        {
            XmlElement gLine = svgDoc.CreateElement("line");
            gLine.SetAttribute("x1", pWell1view.X.ToString());
            gLine.SetAttribute("y1", pWell1view.Y.ToString());
            gLine.SetAttribute("x2", pWell2view.X.ToString());
            gLine.SetAttribute("y2", pWell2view.Y.ToString());
            gLine.SetAttribute("stroke", strokeColor);
            gLine.SetAttribute("stroke-width", stroke_width.ToString());
            gLine.SetAttribute("fill", fillColor);
            return gLine;
        }
    }
}
