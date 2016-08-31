using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;


namespace DOGPlatform.SVG
{
    class cSVGSectionTrackImage
    {
        public static XmlElement gTrackImage(XmlDocument svgDoc, XmlElement svgDefs, string sJH, itemDrawDataIntervalValue item, double fVScale, int iTrackWidth)
        {
            return gTrackImage(svgDoc, svgDefs, sJH, item.sID, item.top, item.bot, item.sProperty, item.fValue,  fVScale, iTrackWidth);
        }
        
        public static XmlElement gTrackImage(XmlDocument svgDoc, XmlElement svgDefs, string sJH, string sID, double fTop, double fBot, string imagePath, double percentWitdh,  double fVScale, int iTrackWidth)
        {
            fTop *= fVScale;
            fBot *= fVScale;
            string sImgID = Path.GetFileNameWithoutExtension(imagePath);
          
            imagePath = Path.Combine(cProjectManager.dirPathWellDir, sJH, imagePath);
         
            XmlElement eImage = svgDoc.CreateElement("image");
            eImage.SetAttribute("onclick", "getID(evt)");
            eImage.SetAttribute("id", sID);
            double heightImage = fBot - fTop;
            double widthImage= iTrackWidth * percentWitdh/100;
            eImage.SetAttribute("x", ((iTrackWidth - widthImage)*0.5).ToString("0"));
            eImage.SetAttribute("y", fTop.ToString("0.0"));
            eImage.SetAttribute("width", widthImage.ToString("0"));
            eImage.SetAttribute("height", heightImage.ToString("0.0"));
            eImage.SetAttribute("preserveAspectRatio", "none");
            eImage.SetAttribute("href", cSVGBase.svgNS, imagePath);
            return eImage;
        }
    }
}
