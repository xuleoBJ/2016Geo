using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using System.Drawing;

namespace DOGPlatform.XML
{
    class cXMLLayerMapFaultLine
    {
        public static void addLayerFaults2XML(string filePathLayerCss, string sIDLayer)
        {
            XmlDocument xmlLayerMap = new XmlDocument();
            xmlLayerMap.Load(filePathLayerCss);
            XmlNode currentNode = xmlLayerMap.SelectSingleNode("/LayerMapConfig");
            XmlNode nodeLayer = xmlLayerMap.CreateElement("Layer");
            XmlAttribute nodeID = xmlLayerMap.CreateAttribute("id");
            nodeID.Value = sIDLayer;
            nodeLayer.Attributes.Append(nodeID);
            XmlAttribute nodeType = xmlLayerMap.CreateAttribute("LayerType");
            nodeType.Value = TypeLayer.LayerPolyline.ToString();
            nodeLayer.Attributes.Append(nodeType);
            XmlElement eleMent;

            eleMent = xmlLayerMap.CreateElement("lineColor");
            eleMent.InnerText = "red";
            nodeLayer.AppendChild(eleMent);
            eleMent = xmlLayerMap.CreateElement("lineWidth");
            eleMent.InnerText = "2";
            nodeLayer.AppendChild(eleMent);

            eleMent = xmlLayerMap.CreateElement("data");
            string sData = "";
            eleMent.InnerText = string.Join("\t", sData);
            nodeLayer.AppendChild(eleMent);

            currentNode.AppendChild(nodeLayer);
            xmlLayerMap.Save(filePathLayerCss);
        
        }
    }
}
