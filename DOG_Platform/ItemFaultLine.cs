using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using DOGPlatform.XML;
using DOGPlatform.SVG;
using System.Xml;
using System.Xml.Linq;

namespace DOGPlatform
{
    class ItemFaultLine
    {
        public string sXCM;
        public string sFaultName;
        public List<PointD> ltPoints=new List<PointD>();
        public int iFaultType;
        public int lineWidth=2;
        public string lineColor = "red";


        public ItemFaultLine(XmlNode xn)
        {
            this.sFaultName = xn["faultName"].InnerText;
            this.iFaultType = int.Parse(xn["faultType"].InnerText);
            this.lineWidth = int.Parse(xn["lineWidth"].InnerText);
            this.lineColor = xn["lineColor"].InnerText;
            char[] delimiterChars = { ' ', ',', '\t' };
            if (xn["data"] != null) 
            {
                string[] splitData = (xn["data"].InnerText).Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
                for(int i=0;i<splitData.Length;i=i+2)
                {
                    PointD pd = new PointD(double.Parse(splitData[i]), double.Parse(splitData[i+1]));
                    ltPoints.Add(pd);
                }

            }
         
        }
    }

    struct ItemFaultPoint
    {
        public string sXCM;
        public string sFaultName;
        public double dbx;
        public double dby;
        public double dbz;
    }
}
