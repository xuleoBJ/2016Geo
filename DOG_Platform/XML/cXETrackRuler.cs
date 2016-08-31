using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace DOGPlatform.XML
{
    class cXETrackRuler
    {
        public static XElement ElevationRuler(string id, int iTrackWidth)
        {
            return new XElement("ElevationRuler", new XAttribute("id", id),
                                            new XElement("visible", "1"),
                                            new XElement("trackWidth", iTrackWidth.ToString()),
                                            new XElement("topElevationDepth", "0"),
                                            new XElement("bottomElevationDepth", "-2000"),
                                            new XElement("mainScale", "50"),
                                            new XElement("minScale", "10"),
                                            new XElement("iFontSize", "14")
                                        );
        }
        public static void addElevationRuler(string xmlFilePath, string id, int iTrackWidth)
        {
            XDocument xDoc = XDocument.Load(xmlFilePath);
            xDoc.Element("SectionMap").Add(cXETrackRuler.ElevationRuler(id, iTrackWidth));
            xDoc.Save(xmlFilePath);
        }

        public static string xmlFullPathElevationRuler = "SectionMap/ElevationRuler";
        public static string xmlFullPathTopElevationDepth = "SectionMap/ElevationRuler/topElevationDepth";
        public static string xmlFullPathBotElevationDepth = "SectionMap/ElevationRuler/bottomElevationDepth";
        public static string xmlFullPathMainScale = "SectionMap/ElevationRuler/mainScale";
        public static string xmlFullPathMinScale = "SectionMap/ElevationRuler/minScale";
        public static string xmlFullPathiFontSize = "SectionMap/ElevationRuler/iFontSize";
        public static string xmlFullPathiVisible = "SectionMap/ElevationRuler/visible";


        public static void updateElevationRuler(int iElevationTop, int iElevationBottom, int iScale, string xmlPathSectionConfig)
        {
            XDocument sectionMapXML = XDocument.Load(xmlPathSectionConfig);
            sectionMapXML.Element("SectionMap").Element("ElevationRuler").Element("topElevationDepth").Value = iElevationTop.ToString("0");
            sectionMapXML.Element("SectionMap").Element("ElevationRuler").Element("bottomElevationDepth").Value = iElevationBottom.ToString("0");
            sectionMapXML.Element("SectionMap").Element("ElevationRuler").Element("MainScale").Value = iScale.ToString("0");
            sectionMapXML.Save(xmlPathSectionConfig);
        }
    }
}
