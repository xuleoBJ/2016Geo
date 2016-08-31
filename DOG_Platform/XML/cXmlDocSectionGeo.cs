using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Drawing;

namespace DOGPlatform.XML
{   
    /// <summary>
    /// 生存Section剖面设置xml
    /// 节点用大写开头
    /// 内属性用小写开头
    /// </summary>
    class cXmlDocSectionGeo : cXmlBase
    {
        public static void generateSectionCssXML(string xmlPathSection)
        {
            if (File.Exists(xmlPathSection))
            {
                File.Delete(xmlPathSection);
            }
            try
            {
                //定义一个XDocument结构
                XDocument xDoc =
                    new XDocument(
                          new XElement("SectionMap", new XAttribute("id", "idSectionCss"),
                          new XElement("WellCollection"),
                          new XElement("ConnectInfor"),
                          new XElement("FaultInfor")
                            )
                );
                xDoc.Element("SectionMap").Add(cXEGeopage.Page());
                xDoc.Save(xmlPathSection);
                cXETrackRuler.addElevationRuler(xmlPathSection, cIDmake.idTrackRuler(), 30);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            };
        }

        public static void write2css(List<ItemWellSection> listWellsSection, string filePathSectionCss)
        {
            for (int i = 0; i < listWellsSection.Count; i++)
            {
                cXmlDocSectionGeo.updateWell(filePathSectionCss, listWellsSection[i]);
            } //sectionCss模板完成 
        }

        public static List<ItemWellSection> makeListWellSection(string filePathSectionGeoCss)
        {
            List<ItemWellSection> listWellsSection=new List<ItemWellSection>();
            foreach (XmlElement elWell in cXmlDocSectionGeo.getWellNodes(filePathSectionGeoCss))
            {
                ItemWellSection item = new ItemWellSection(elWell["JH"].InnerText);
                item.fShowedDepthTop = float.Parse(elWell["fShowTop"].InnerText); 
                item.fShowedDepthBase = float.Parse(elWell["fShowBot"].InnerText);
                item.fXview = float.Parse(elWell["Xview"].InnerText);
                item.fYview = float.Parse(elWell["Yview"].InnerText);
                listWellsSection.Add(item);
            }
            return listWellsSection; 
    }

        public static void deleteWellSelect(string pathTemplateCss, string sJH)
        {
            //根据sIDtrack查找XML并删除
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(pathTemplateCss);
            string sPath = string.Format("//*[@id='{0}']", sJH);
            XmlNode el = xmlDoc.SelectSingleNode(sPath);
            if (el != null) { el.ParentNode.RemoveChild(el); }
            xmlDoc.Save(pathTemplateCss);
        }

        public static XElement setWellNode(string filePathSelectTemplatelate, ItemWellSection item)
        {
            XElement wellNode = new XElement("well", new XAttribute("id",item.sJH));
            wellNode.Add(new XElement("JH", item.sJH));
            wellNode.Add(new XElement("X", item.dbX));
            wellNode.Add(new XElement("Y", item.dbY));
            wellNode.Add(new XElement("kb", item.fKB));
            wellNode.Add(new XElement("fShowTop", item.fShowedDepthTop));
            wellNode.Add(new XElement("fShowBot", item.fShowedDepthBase));
            wellNode.Add(new XElement("iTypeWell", item.iWellType));
            wellNode.Add(new XElement("fWellBase", item.fWellBase));
            wellNode.Add(new XElement("Xview", item.fXview.ToString()));
            wellNode.Add(new XElement("Yview", item.fYview.ToString()));
            wellNode.Add(new XElement("XviewTrackList")); 
            return wellNode;
        }

        public static void addWellTrackXviewNode(string pathTemplate, string sJH, string sIDTrack, double xViewtrack)
        {
            XmlDocument wellTemplateXML = new XmlDocument();
            wellTemplateXML.Load(pathTemplate);
            string sPath = string.Format("//*[@id='{0}']", sJH);
            XmlNode selectNode = wellTemplateXML.SelectSingleNode(sPath);
            XmlNode trackXviewNode = selectNode.SelectSingleNode("XviewTrackList");

            XmlNode trackNode = trackXviewNode.SelectSingleNode(sIDTrack);
            if (trackNode != null) trackNode.InnerText = xViewtrack.ToString();
            else
            {
                XmlElement newNode = wellTemplateXML.CreateElement(sIDTrack);
                newNode.InnerText = xViewtrack.ToString();
                trackXviewNode.AppendChild(newNode);
            }

            wellTemplateXML.Save(pathTemplate);
        }

        public static void addFaultItem(string pathTemplate, PointD P1, PointD P2, double displacement)
        {
            XmlDocument wellTemplateXML = new XmlDocument();
            wellTemplateXML.Load(pathTemplate);
            string sPath = "SectionMap/FaultInfor";
            XmlNode selectNode = wellTemplateXML.SelectSingleNode(sPath);
            if (selectNode != null)
            {
                XmlElement newNode = wellTemplateXML.CreateElement("FaultItem");
                newNode.SetAttribute("id", cIDmake.idFault());
                newNode.SetAttribute("displacement", displacement.ToString());
                newNode.SetAttribute("x1", P1.X.ToString("0.00"));
                newNode.SetAttribute("y1", P1.Y.ToString("0.00"));
                newNode.SetAttribute("x2", P2.X.ToString("0.00"));
                newNode.SetAttribute("y2", P2.Y.ToString("0.00"));
                selectNode.AppendChild(newNode);
            }
            wellTemplateXML.Save(pathTemplate);
        }

        public static void clearAllConnectDataItem(string pathTemplate)
        {
            XmlDocument wellTemplateXML = new XmlDocument();
            wellTemplateXML.Load(pathTemplate);
            string sPath = "SectionMap/ConnectInfor";
            XmlNode selectNode = wellTemplateXML.SelectSingleNode(sPath);
            selectNode.RemoveAll();
            wellTemplateXML.Save(pathTemplate);
        }
        /// <summary>
        /// 存ID
        /// </summary>
        /// <param name="pathTemplate"></param>
        /// <param name="iShowMode"></param>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        public static void addConnectDataItem(string pathTemplate, int iShowMode, cDataItemConnect item1, cDataItemConnect item2)
        {
            XmlDocument wellTemplateXML = new XmlDocument();
            wellTemplateXML.Load(pathTemplate);
            string sPath = "SectionMap/ConnectInfor";
            XmlNode selectNode = wellTemplateXML.SelectSingleNode(sPath);

            XmlElement newNode = wellTemplateXML.CreateElement("ConnectItem");
            newNode.SetAttribute("id", cIDmake.idConnectItem());
            newNode.SetAttribute("iShowMode", iShowMode.ToString());
            newNode.SetAttribute("trackType", item1.typeTrack);
            newNode.SetAttribute("sFill", item1.sFill);
           
            XmlElement itemRect1 = wellTemplateXML.CreateElement("rect1");
            itemRect1.SetAttribute("wellID", item1.sJH);
            itemRect1.SetAttribute("sIDtrack", item1.sIDTrack);
            itemRect1.SetAttribute("sIDitem", item1.sIDDataItem);
            newNode.AppendChild(itemRect1);

            XmlElement itemRect2 = wellTemplateXML.CreateElement("rect2");
            itemRect2.SetAttribute("wellID", item2.sJH);
            itemRect2.SetAttribute("sIDtrack", item2.sIDTrack);
            itemRect2.SetAttribute("sIDitem", item2.sIDDataItem);
            newNode.AppendChild(itemRect2);
 
            selectNode.AppendChild(newNode); 
            
            wellTemplateXML.Save(pathTemplate);
        }

        public static void addConnectDataItem(string pathTemplate, int iShowMode, cDataItemConnect item1)
        {
            XmlDocument wellTemplateXML = new XmlDocument();
            wellTemplateXML.Load(pathTemplate);
            string sPath = "SectionMap/ConnectInfor";
            XmlNode selectNode = wellTemplateXML.SelectSingleNode(sPath);

            XmlElement newNode = wellTemplateXML.CreateElement("ConnectItem");
            newNode.SetAttribute("id", cIDmake.idConnectItem());
            newNode.SetAttribute("iShowMode", iShowMode.ToString());
            newNode.SetAttribute("trackType", item1.typeTrack);
            newNode.SetAttribute("sFill", item1.sFill);

            XmlElement itemRect1 = wellTemplateXML.CreateElement("rect1");
            itemRect1.SetAttribute("wellID", item1.sJH);
            itemRect1.SetAttribute("sIDtrack", item1.sIDTrack);
            itemRect1.SetAttribute("sIDitem", item1.sIDDataItem);
            newNode.AppendChild(itemRect1);

            selectNode.AppendChild(newNode);

            wellTemplateXML.Save(pathTemplate);
        }
        public static void deleteConnectSelect(string pathTemplate, string sID)
        {
            //根据sIDtrack查找XML并删除
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(pathTemplate);
            string sPath = string.Format("//*[@id='{0}']", sID);
            XmlNode el = xmlDoc.SelectSingleNode(sPath);
            if (el != null) { el.ParentNode.RemoveChild(el); }
            xmlDoc.Save(pathTemplate);

        }

    

        public static XmlNodeList getWellNodes(string xmlFilePath)
        {
            if (File.Exists(xmlFilePath))
            {
                XmlDocument XDocSection = new XmlDocument();
                XDocSection.Load(xmlFilePath);
                string pathTrack = "/SectionMap/WellCollection/well";
                return XDocSection.SelectNodes(pathTrack);
            }
            else { return null; }
        }


        public static List<string> getJHList(string xmlFilePath)
        {
            List<string> ltStrJH = new List<string>();
            if (File.Exists(xmlFilePath))
            {
                XmlDocument XDocSection = new XmlDocument();
                XDocSection.Load(xmlFilePath);
                string pathTrack = "/SectionMap/WellCollection/well";
                foreach(XmlNode xn in XDocSection.SelectNodes(pathTrack))
                {
                  ltStrJH.Add(xn["JH"].InnerText);
                } 
            }
            
            return ltStrJH;
        }

        public static void updateWell(string filePathSelectTemplatelate, ItemWellSection item)
        {
            XElement wellNode = setWellNode(filePathSelectTemplatelate, item);
            XDocument XsingleWellStyleRoot = XDocument.Load(filePathSelectTemplatelate);
            XElement wellCol = XsingleWellStyleRoot.Element("SectionMap").Element("WellCollection");
            //判断是否存在，存在删除
            var  currentNode = wellCol.Elements("well").SingleOrDefault(x => x.Attribute("id").Value== item.sJH);
            if (currentNode != null) currentNode.Remove();
            wellCol.Add(wellNode);
            XsingleWellStyleRoot.Save(filePathSelectTemplatelate);
        }

        public static void insertWell(string filePathSelectTemplatelate, string sJH,ItemWellSection itemInsert, int iBefore)
        {
            XElement wellNode = setWellNode(filePathSelectTemplatelate, itemInsert);
            XDocument XsingleWellStyleRoot = XDocument.Load(filePathSelectTemplatelate);
            XElement wellCol = XsingleWellStyleRoot.Element("SectionMap").Element("WellCollection");
            //判断是否存在，存在删除
            var currentNode = wellCol.Elements("well").SingleOrDefault(x => x.Attribute("id").Value == sJH);
            if (currentNode != null)
            {
                if (iBefore == 0) currentNode.AddAfterSelf(wellNode);
                else currentNode.AddBeforeSelf(wellNode);
            }
            else wellCol.Add(wellNode);
            XsingleWellStyleRoot.Save(filePathSelectTemplatelate);
        }

        public static void addWellCone(string xmlFilePath, string id, int iTrackWidth)
        {
            XDocument xDoc = XDocument.Load(xmlFilePath);
            xDoc.Element("SectionMap").Add(cXETrackWellConeRuler.trackWellConeRuler(id, iTrackWidth));
            xDoc.Save(xmlFilePath);
        }

        public static void addPage(string xmlFilePath)
        {
            XDocument xDoc = XDocument.Load(xmlFilePath);
            xDoc.Element("SectionMap").Add(cXEGeopage.Page());
            xDoc.Save(xmlFilePath);
        }

    

        public static void addTrackText(string xmlFilePath, string id,int iTrackWidth)
        {
            XDocument xDoc = XDocument.Load(xmlFilePath);
            xDoc.Element("SectionMap").Add(cXETrackText.trackText(id, iTrackWidth));
            xDoc.Save(xmlFilePath);
        }

        public static void addTrackLog(string xmlFilePath, string id, int iTrackWidth, int iLeftorRight, string sLogName, double fLeftValue, double fRightValue, string sColor)
        {
            XDocument xDoc = XDocument.Load(xmlFilePath);
            xDoc.Element("SectionMap").Add(cXETrackLog.trackLog(id, iTrackWidth,  iLeftorRight,sLogName, fLeftValue, fRightValue, sColor));
            xDoc.Save(xmlFilePath);
        }

        public static void addTrackPerfoation(string xmlFilePath, string id, int iTrackWidth)
        {
            XDocument xDoc = XDocument.Load(xmlFilePath);
            xDoc.Element("SectionMap").Add(cXETrackPerforation.trackPerfoation(id, iTrackWidth));
            xDoc.Save(xmlFilePath);
        }

        public static void addTrackJSJL(string xmlFilePath, string id, int iTrackWidth)
        {
            XDocument xDoc = XDocument.Load(xmlFilePath);
            xDoc.Element("SectionMap").Add(cXETrackJSJL.trackJSJL(id, iTrackWidth));
            xDoc.Save(xmlFilePath);
        }

        public static void addTrackLayer(string xmlFilePath, string id, int iTrackWidth)
        {
            XDocument xDoc = XDocument.Load(xmlFilePath);
            xDoc.Element("SectionMap").Add(cXETrackLayer.trackLayer(id, iTrackWidth));
            xDoc.Save(xmlFilePath);

        }

    }


}
