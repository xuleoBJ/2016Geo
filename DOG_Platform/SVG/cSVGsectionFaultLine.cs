using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace DOGPlatform.SVG
{
    class itemDrawDataFaultItem
    {
        public string sID;
        public double x1;
        public double y1;
        public double x2;
        public double y2;
        public double displacement;
        public double x1View;
        public double y1View;
        public double x2View;
        public double y2View;
        public double displacementView;  
        public itemDrawDataFaultItem(XmlNode xn)
        {
            sID = xn.Attributes["id"].Value;
            x1 = double.Parse( xn.Attributes["x1"].Value);
            y1 = double.Parse( xn.Attributes["y1"].Value);
            x2 = double.Parse( xn.Attributes["x2"].Value);
            y2 = double.Parse( xn.Attributes["y2"].Value);
            displacement = double.Parse(xn.Attributes["displacement"].Value);
        }

        

    }
    class cSVGsectionFaultLine
    {
    }
}
