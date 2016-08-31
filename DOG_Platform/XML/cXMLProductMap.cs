using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace DOGPlatform
{
    class cXMLProductMap
    {
        public static void generateXmlFile(string seletedYM,string selectXCM,string xmlPath)
        {
            try
            {
                //定义一个XDocument结构
                XDocument XDoc = new XDocument(
                new XElement("ProductionMap",
                new XElement("x0RealRefer", cProjectData.dfMapXrealRefer.ToString()),
                new XElement("y0RealRefer", cProjectData.dfMapYrealRefer.ToString()),
                new XElement("Scale", cProjectData.dfMapScale.ToString()),
                new XElement("SlectedYM", seletedYM),
                new XElement("SlectedXCM", selectXCM),
                new XElement("Title","ProductionMap"),
                new XElement("OilWellCollection"),
                new XElement("WaterWellCollection"),
                new XElement("FaultLine",
                     new XElement("IsShow","1"),
                     new XElement("color","red"),
                     new XElement("lineWidth","2")
                    ),
                new XElement("MapFrameIsShowed", "1"),
                new XElement("ScaleRulerIsShowed", "1"),
                new XElement("CompassIsShowed", "1")
                )
                );
                XDoc.Save(xmlPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }

        public static void addWell(string sJH, string xmlPathSectionConfig)
        {
            XElement XSectionRoot = XElement.Load(xmlPathSectionConfig);
            XElement XNode = XSectionRoot.Element("WellCollection");
            XNode.Add(wellNode(sJH));
            XSectionRoot.Save(xmlPathSectionConfig);
        }

        public static void addWells(List<string> ltStrJH, string xmlPathSectionConfig)    
        {
            XElement XSectionRoot = XElement.Load(xmlPathSectionConfig);
            XElement XNode = XSectionRoot.Element("WellCollection");
            for (int i = 0; i < ltStrJH.Count; i++)
            {
                XNode.Add(wellNode(ltStrJH[i]));
            }
            XSectionRoot.Save(xmlPathSectionConfig);
        }

        public static XElement wellNode(string _sJH) 
        {
            ItemWellHead WellHeadItem =   cIOinputWellHead.readWellHead2Struct().Find(p => p.sJH == _sJH); ;
            Point pWellView = cCordinationTransform.transRealPointF2ViewPointByCurrentSystemSetting
                        (WellHeadItem.dbX, WellHeadItem.dbY);
            XElement newWellNode = new XElement("Well", new XAttribute("id", _sJH),
                                     new XElement("X", WellHeadItem.dbX.ToString()),
                  new XElement("Y", WellHeadItem.dbY.ToString()),
                  new XElement("KB",WellHeadItem.fKB.ToString()),
                  new XElement("TypeWell", WellHeadItem.iWellType.ToString()),
                  new XElement("Xview", pWellView.X.ToString()),
                  new XElement("Yview", pWellView.Y.ToString())
                   );
            return newWellNode;
        }
        public static void addOilWells(List<string> ltStrOilJH, string xmlPathSectionConfig)        
        {
            XElement XSectionRoot = XElement.Load(xmlPathSectionConfig);
            XElement XNode = XSectionRoot.Element("OilWellCollection");
            for (int i = 0; i < ltStrOilJH.Count; i++)
            {
                XNode.Add(wellNode(ltStrOilJH[i]));
            }
            XSectionRoot.Save(xmlPathSectionConfig);
        }
        public static void addOilWell(string sJH, string xmlPathSectionConfig)
        { 
            XElement XSectionRoot = XElement.Load(xmlPathSectionConfig);
            XElement XNode = XSectionRoot.Element("OilWellCollection");
            XNode.Add(wellNode(sJH));
            XSectionRoot.Save(xmlPathSectionConfig);
        }
        public static void addWaterWells(List<string> ltStrWaterJH,string xmlPathSectionConfig)           
        {
           
            XElement XSectionRoot = XElement.Load(xmlPathSectionConfig);
            XElement XNode = XSectionRoot.Element("WaterWellCollection");
            for (int i = 0; i < ltStrWaterJH.Count; i++)
            {
                XNode.Add(wellNode(ltStrWaterJH[i]));
            }
            XSectionRoot.Save(xmlPathSectionConfig);
        }
        public static void addWaterWell(string sJH, string xmlPathSectionConfig)
        {
            XElement XSectionRoot = XElement.Load(xmlPathSectionConfig);
            XElement XNode = XSectionRoot.Element("WaterWellCollection");
            XNode.Add(wellNode(sJH));
            XSectionRoot.Save(xmlPathSectionConfig);
        }

     
    }
}
