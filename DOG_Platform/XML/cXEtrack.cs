using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace DOGPlatform.XML
{
    class cXEtrack
    {
        public static void setTrackWidth(string xmlFilePath,string sIDtrack, string sValue)
        {
            cXmlBase.setSelectedNodeChildNodeValue(xmlFilePath,sIDtrack,"trackWidth",sValue);
        }

        public static int getTrackWidth(string xmlFilePath,string sIDtrack)
        {
            return int.Parse(cXmlBase.getSelectedNodeChildNodeValue(xmlFilePath, sIDtrack, "trackWidth")); 
        }

        public static void setTrackHeadHeight(string xmlFilePath, string sIDtrack, string sValue)
        {
            cXmlBase.setSelectedNodeChildNodeValue(xmlFilePath, sIDtrack, "trackHeadRectHeight", sValue);
        }

        public static int getTrackHeadHeight(string xmlFilePath, string sIDtrack)
        {
            return int.Parse(cXmlBase.getSelectedNodeChildNodeValue(xmlFilePath, sIDtrack, "trackHeadRectHeight"));
        }

        public static void setTrackHeadTextWriteMode(string xmlFilePath, string sIDtrack, string sValue)
        {
            cXmlBase.setSelectedNodeChildNodeValue(xmlFilePath, sIDtrack, "writingMode", sValue);
        }
        public static string getTrackHeadTextWriteMode(string xmlFilePath, string sIDtrack)
        {
            return cXmlBase.getSelectedNodeChildNodeValue(xmlFilePath, sIDtrack, "writingMode");
        }
        public static void setTrackFontAlignMode(string xmlFilePath, string sIDtrack, string sValue)
        {
            cXmlBase.setSelectedNodeChildNodeValue(xmlFilePath, sIDtrack, "iAlignMode", sValue);
        } 
        public static void setTrackFontSize(string xmlFilePath, string sIDtrack, string sValue)
        {
            cXmlBase.setSelectedNodeChildNodeValue(xmlFilePath, sIDtrack, "fontSize", sValue);
        }
        public static int getTrackFontSize(string xmlFilePath, string sIDtrack)
        {
            return int.Parse(cXmlBase.getSelectedNodeChildNodeValue(xmlFilePath, sIDtrack, "fontSize"));
        }

        public static void setTrackHeadFontSize(string xmlFilePath, string sIDtrack, string sValue)
        {
            cXmlBase.setSelectedNodeChildNodeValue(xmlFilePath, sIDtrack, "trackHeadFontSize", sValue);
        }
        public static int getTrackHeadFontSize(string xmlFilePath, string sIDtrack)
        {
            return int.Parse(cXmlBase.getSelectedNodeChildNodeValue(xmlFilePath, sIDtrack, "trackHeadFontSize"));
        }

        public static void setTrackTitle(string xmlFilePath, string sIDtrack, string sValue)
        {
            cXmlBase.setSelectedNodeChildNodeValue(xmlFilePath, sIDtrack, "trackTitle", sValue);
        }

        public static string getTrackTitle(string xmlFilePath, string sIDtrack)
        {
            return cXmlBase.getSelectedNodeChildNodeValue(xmlFilePath, sIDtrack, "trackTitle"); 
        }

        public static void setTrackHasGrid(string xmlFilePath, string sIDtrack, int iHasGrid)
        {
            cXmlBase.setSelectedNodeChildNodeValue(xmlFilePath, sIDtrack, "hasGrid", iHasGrid.ToString());
        }

        public static int getTrackHasGrid(string xmlFilePath, string sIDtrack)
        {
            string sRet = cXmlBase.getSelectedNodeChildNodeValue(xmlFilePath, sIDtrack, "hasGrid");
            if (sRet != "") return int.Parse(sRet);
            else return 0;
        }

        public static void setIsLog10(string xmlFilePath, string sIDtrack, int iHasGrid)
        {
            cXmlBase.setSelectedNodeChildNodeValue(xmlFilePath, sIDtrack, "is2Log10", iHasGrid.ToString());

        }

        public static int getIsLog10(string xmlFilePath, string sIDtrack)
        {
            string sRet = cXmlBase.getSelectedNodeChildNodeValue(xmlFilePath, sIDtrack, "is2Log10");
            if (sRet != "") return int.Parse(sRet);
            else return 0;
        }
    }
}
