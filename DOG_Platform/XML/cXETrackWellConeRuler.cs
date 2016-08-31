using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace DOGPlatform.XML
{
    class cXETrackWellConeRuler
    {
        public static XElement trackWellConeRuler(string id, int iTrackWidth)
        {
            return new XElement("TrackWellConeRuler", new XAttribute("id", id),
                                            new XElement("trackWidth", iTrackWidth.ToString()),
                                            new XElement("topDepth", "0"),
                                            new XElement("bottomDepth", "-2000"),
                                            new XElement("mainScale", "50"),
                                            new XElement("minScale", "10"),
                                            new XElement("coneWidth", "3"),
                                            new XElement("coneColor", "black"),
                                            new XElement("radisHeadCircle", "4"),
                                            new XElement("JHFontSize", "10"),
                                            new XElement("JHFontColor", "red"),
                                            new XElement("tickTextFontSize", "5"),
                                            new XElement("tickTextFontColor", "black")
                                        );
        }

        static string xmlFullPathTopDepth = "SectionMap/TrackWellConeRuler/topDepth";
        public static void setTopDepth(string xmlFilePath, string sID, string sValue)
        {
            cXmlBase.setNodeInnerText(xmlFilePath, xmlFullPathTopDepth, sValue);
        }
        public static int getTopDepth(string xmlFilePath, string sID)
        {
            return Convert.ToInt16(cXmlBase.getNodeInnerText(xmlFilePath, xmlFullPathTopDepth));
        }

        static string xmlFullPathBotElevationDepth = "SectionMap/TrackWellConeRuler/bottomDepth";
        public static void setBottomElevationDepth(string xmlFilePath, string sID, string sValue)
        {
            cXmlBase.setNodeInnerText(xmlFilePath, xmlFullPathBotElevationDepth, sValue);
        }
        public static int getBottomElevationDepth(string xmlFilePath, string sID)
        {
            return Convert.ToInt16(cXmlBase.getNodeInnerText(xmlFilePath, xmlFullPathBotElevationDepth));
        }

        static string xmlFullPathMainScale = "SectionMap/TrackWellConeRuler/mainScale";
        public static int getMainScale(string xmlFilePath, string sID)
        {
            return Convert.ToInt16(cXmlBase.getNodeInnerText(xmlFilePath, xmlFullPathMainScale));
        }
        public static void setMainScale(string xmlFilePath, string sID, string sValue)
        {
            cXmlBase.setNodeInnerText(xmlFilePath, xmlFullPathMainScale, sValue);
        }

        static string xmlFullPathMinScale = "SectionMap/TrackWellConeRuler/minScale";
        public static int getMinScale(string xmlFilePath, string sID)
        {
            return Convert.ToInt16(cXmlBase.getNodeInnerText(xmlFilePath, xmlFullPathMinScale));
        }
        public static void setMinScale(string xmlFilePath, string sID, string sValue)
        {
            cXmlBase.setNodeInnerText(xmlFilePath, xmlFullPathMinScale, sValue);
        }
    }
}
