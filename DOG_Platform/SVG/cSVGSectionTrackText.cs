using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace DOGPlatform.SVG
{
    class cSVGSectionTrackText 
    {
        public static XmlElement gTrackItemText(XmlDocument svgDoc, string sID, double _top, double _bottom, double fVScale, string sText, int fontSize,int iAlignMode, int iTrackwidth, string sBackColor, string sWriteMode)
        {
            _top *= fVScale;
            _bottom *= fVScale;
            XmlElement gRectText = cSVGWrapText.rectWithText(svgDoc, sID, sText, 0, _top, _bottom - _top, iTrackwidth, "black", fontSize, sBackColor);
         
            if (iAlignMode == 1) gRectText = cSVGWrapText.rectWithTextLeftAlign(svgDoc, sID, sText, 0, _top, _bottom - _top, iTrackwidth, "black", fontSize, sBackColor);
            if (sWriteMode == "tb")
            {
                gRectText = cSVGWrapText.rectWithTextVertical(svgDoc, sID, sText, 0, _top, _bottom - _top, iTrackwidth, "black", fontSize, sBackColor);
                return gRectText;
            }
            return gRectText; 
        }

      
    
    }
}
