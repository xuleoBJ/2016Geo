using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace DOGPlatform.SVG
{
    class cSVGRoseMap:cBaseMapSVG
    {
        public cSVGRoseMap( int iDX, int iDY)
            : base(800,1000, iDX, iDY)
        {
        
        }
        public XmlElement addgPoleBaseMap(int x0, int y0,int r)
        {
            XmlElement gPoleMap = svgDoc.CreateElement("g");
            gPoleMap.SetAttribute("ID", "idPoleMap");


            for (int i = 1; i <= 9; i++)
            {
                XmlElement gMainCircle = svgDoc.CreateElement("circle");
                gMainCircle.SetAttribute("cx", x0.ToString());
                gMainCircle.SetAttribute("cy", y0.ToString());
                gMainCircle.SetAttribute("r", (r * i).ToString());
                gMainCircle.SetAttribute("stroke", "blue");
                gMainCircle.SetAttribute("stroke-width", "0.1");
                gMainCircle.SetAttribute("fill", "none");
                gPoleMap.AppendChild(gMainCircle);
                if (i < 9)
                {
                    XmlElement gTickText = svgDoc.CreateElement("text");
                    gTickText.SetAttribute("x", (x0 + r * i).ToString());
                    gTickText.SetAttribute("y", (y0+2).ToString());
                    gTickText.SetAttribute("font-size", "6");
                    gTickText.InnerText = (10 * i).ToString();
                    gTickText.SetAttribute("font-family", "Arial");
                    gTickText.SetAttribute("stroke", "none");
                    gTickText.SetAttribute("stroke-width", "0.1");
                    gTickText.SetAttribute("fill", "black");
                    gPoleMap.AppendChild(gTickText);


                    XmlElement gYTickText = svgDoc.CreateElement("text");
                    gYTickText.SetAttribute("x", (x0-2) .ToString());
                    gYTickText.SetAttribute("y", (y0 - r * i).ToString());
                    gYTickText.SetAttribute("font-size", "6");
                    gYTickText.InnerText = (10 * i).ToString();
                    gYTickText.SetAttribute("font-family", "Arial");
                    gYTickText.SetAttribute("stroke", "none");
                    gYTickText.SetAttribute("stroke-width", "0.1");
                    gYTickText.SetAttribute("fill", "black");
                    gPoleMap.AppendChild(gYTickText);
                }
            }


            int r2 = r * 9;
            for (int i = 1; i <= 24; i++)
            {
                double dgree = (2 * Math.PI) * i *15/ 360.0;
                double x2 = x0 + r2 * Math.Sin(dgree);
                double y2 = y0 + r2 * Math.Cos(dgree);
                XmlElement gLine = svgDoc.CreateElement("line");
                gLine.SetAttribute("x1", x0.ToString());
                gLine.SetAttribute("y1", y0.ToString());
                gLine.SetAttribute("x2", x2.ToString());
                gLine.SetAttribute("y2", y2.ToString());
                
              
                gLine.SetAttribute("stroke", "blue");
                gLine.SetAttribute("stroke-width", "1");

                gPoleMap.AppendChild(gLine);


                double xText = x0 + (r2 + 8) * Math.Sin(dgree) - 8;
                double yText = y0 - (r2 + 8) * Math.Cos(dgree) + 4;
                XmlElement gText = svgDoc.CreateElement("text");
                gText.SetAttribute("x", xText.ToString());
                gText.SetAttribute("y", yText.ToString());
                gText.SetAttribute("font-size", "10");
                gText.InnerText = (15 * i).ToString();
                gText.SetAttribute("font-family", "Arial");
                gText.SetAttribute("stroke", "none");
                gLine.SetAttribute("stroke-width", "0.1");
                gText.SetAttribute("fill", "black");
                gPoleMap.AppendChild(gText);
            }

            return gPoleMap;

        }

        public XmlElement addgPoint(int x0,int y0,int r,float fAzim, float fDig)
        {
            double cx= x0 + fDig*r/10 *Math.Sin(Math.PI*fAzim/180) ;
            double cy = y0 - fDig * r / 10 * Math.Cos(Math.PI * fAzim / 180);
            XmlElement gPointSymbol = svgDoc.CreateElement("circle");
            gPointSymbol.SetAttribute("cx", cx.ToString());
            gPointSymbol.SetAttribute("cy", cy.ToString());
            gPointSymbol.SetAttribute("r", "3");
            gPointSymbol.SetAttribute("stroke", "black");
            gPointSymbol.SetAttribute("stroke-width", "0.1");
            gPointSymbol.SetAttribute("fill", "red");
            return gPointSymbol;
        }

        public XmlElement addgPoleMap(List<float> fListAzim,List<float> fListDip)
        {
            XmlElement gPoleMap = svgDoc.CreateElement("g");

            int x0 = 0;
            int y0 = 0;
            int r = 20;
            gPoleMap.AppendChild(addgPoleBaseMap(x0,y0,r));
            if(fListAzim.Count>0)
            {
                for (int i = 0; i < fListAzim.Count; i++) 
                {
                    gPoleMap.AppendChild(addgPoint(x0, y0,r, fListAzim[i], fListDip[i]));
                
                }
            }

            return gPoleMap;
        }
    }
}
