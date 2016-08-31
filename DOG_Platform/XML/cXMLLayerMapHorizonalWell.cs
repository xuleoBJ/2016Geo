using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml;

namespace DOGPlatform.XML
{
    class cXMLLayerMapHorizonalWell:cXmlBase 
    { 
        public static void delHorizonalWellIntervalNode(string xmlLayerMap)
        {
            string parentNodePath=@"/LayerMapConfig/HorizonalWell";
            string _tagName = "WellIntervel";
            delNodes(xmlLayerMap,parentNodePath,_tagName);
        }

        public static XmlNodeList getHorizonalWellIntervalNodeList(string filePathLayerCss)
        {
            XmlDocument xmlLayerMap = new XmlDocument();
            xmlLayerMap.Load(filePathLayerCss);
            return   xmlLayerMap.SelectNodes("/LayerMapConfig/HorizonalWell/WellIntervel");
        }


        public static void setLineWidthHorzionalInterval(string _xmlFilePath, float _fLineWidth)
        {
            string _nodePath = "/LayerMapConfig/HorizonalWell/lineWidth";
            updateNodeValueByAbsPath(_xmlFilePath, _nodePath, _fLineWidth);
        }
        public static void setColorHorionalInterval(string _xmlFilePath, string _sColorName)
        {
            string _nodePath = "/LayerMapConfig/HorizonalWell/lineColor";
            updateNodeValueByAbsPath(_xmlFilePath, _nodePath, _sColorName);
        }

        public static void addLayerWellHorizonalInterval2XML(string filePathLayerCss, string sIDLayer,string  strNode)
        { // 井号+ 井型 + 井口view坐标 + head view 坐标 + tail view 坐标 
            XmlDocument xmlLayerMap = new XmlDocument();
            xmlLayerMap.Load(filePathLayerCss);
            XmlNode currentNode = xmlLayerMap.SelectSingleNode("/LayerMapConfig");
            XmlNode nodeLayer = xmlLayerMap.CreateElement("Layer");
            XmlAttribute nodeID = xmlLayerMap.CreateAttribute("id");
            nodeID.Value = sIDLayer;
            nodeLayer.Attributes.Append(nodeID);
            XmlAttribute nodeType = xmlLayerMap.CreateAttribute("LayerType");
            nodeType.Value = TypeLayer.LayerHorizonalInterval.ToString();
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
            nodeLayer.AppendChild(eleMent); ;

            currentNode.AppendChild(nodeLayer);
            xmlLayerMap.Save(filePathLayerCss);
        }
    }
}
