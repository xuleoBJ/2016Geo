using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace DOGPlatform.SVG
{
    class cSVGText : cSVGElement
    {
        public XmlElement gElementText(int x, int y, string sText, int font_size, string fillColor)
        {
            XmlElement gText = svgDoc.CreateElement("text");
            gText.SetAttribute("x", x.ToString());
            gText.SetAttribute("y", y.ToString());
            gText.InnerText = sText;
            gText.SetAttribute("font-size", font_size.ToString());
            gText.SetAttribute("stroke", "none");
            //gText.SetAttribute("stroke-width", stroke_width.ToString());
            gText.SetAttribute("fill", fillColor);
            return gText;
        }
    }
}
