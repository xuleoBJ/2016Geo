using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace DOGPlatform.XML
{
    class cXMLLayerMapDynamic
    {
        public static void addWellDynamicDataDic2XML(string filePathLayerCss,string sYM,string sXCM,List<ItemDicLayerDataDynamic> listItemWell)
        {
            XmlDocument xmlLayerMap = new XmlDocument();
            xmlLayerMap.Load(filePathLayerCss);
             XmlNodeList xnList = xmlLayerMap.SelectNodes("/LayerMapConfig/DataDicDynamic");
            //或许Layer标签的节点
            foreach (XmlNode xn in xnList)
            {
                if (xn.Attributes["YM"].Value == sYM && xn.Attributes["XCM"].Value == sXCM ) xn.ParentNode.RemoveChild(xn);
            }

            XmlNode currentNode = xmlLayerMap.SelectSingleNode("/LayerMapConfig");
            XmlNode nodeLayer = xmlLayerMap.CreateElement("DataDicDynamic");
            XmlAttribute nodeID = xmlLayerMap.CreateAttribute("YM");
            nodeID.Value = sYM;
            nodeLayer.Attributes.Append(nodeID);
            XmlAttribute nodeType = xmlLayerMap.CreateAttribute("XCM");
            nodeType.Value = sXCM;
            nodeLayer.Attributes.Append(nodeType);
            XmlElement eleMent;

            eleMent = xmlLayerMap.CreateElement("data");
            foreach (ItemDicLayerDataDynamic item in listItemWell)
            {
                XmlElement itemdata = xmlLayerMap.CreateElement("item");
                itemdata.InnerText = ItemDicLayerDataDynamic.item2string(item);
                eleMent.AppendChild(itemdata);
            }
            nodeLayer.AppendChild(eleMent);

            currentNode.AppendChild(nodeLayer);
            xmlLayerMap.Save(filePathLayerCss);
        }

        public static void delWellDynamicDataDicFromXML(string filePathLayerCss, string sYM, string sXCM)
        {

            XmlDocument xmlLayerMap = new XmlDocument();
            xmlLayerMap.Load(filePathLayerCss);

            XmlNodeList xnList = xmlLayerMap.SelectNodes("/LayerMapConfig/DataDicDynamic");
            //或许Layer标签的节点
            foreach (XmlNode xn in xnList)
            {
                if (xn.Attributes["YM"].Value == sYM && xn.Attributes["XCM"].Value == sXCM ) xn.ParentNode.RemoveChild(xn);
            }
            xmlLayerMap.Save(filePathLayerCss);
        }

        public static void addLayerSumProduct2XML(string filePathLayerCss, string sIDLayer, float fRscale)
        {
            XmlDocument xmlLayerMap = new XmlDocument();
            xmlLayerMap.Load(filePathLayerCss);
            XmlNode currentNode = xmlLayerMap.SelectSingleNode("/LayerMapConfig");
            XmlNode nodeLayer = xmlLayerMap.CreateElement("Layer");
            XmlAttribute nodeID = xmlLayerMap.CreateAttribute("id");
            nodeID.Value = sIDLayer;
            nodeLayer.Attributes.Append(nodeID);
            XmlAttribute nodeType = xmlLayerMap.CreateAttribute("LayerType");
            nodeType.Value = TypeLayer.LayerSumProduct.ToString();
            nodeLayer.Attributes.Append(nodeType);
            XmlElement eleMent;

            eleMent = xmlLayerMap.CreateElement("r");
            eleMent.InnerText = fRscale.ToString();
            nodeLayer.AppendChild(eleMent);

            eleMent = xmlLayerMap.CreateElement("lineWidth");
            eleMent.InnerText = "1";
            nodeLayer.AppendChild(eleMent);

            eleMent = xmlLayerMap.CreateElement("textFontSize");
            eleMent.InnerText = "3";
            nodeLayer.AppendChild(eleMent);

            eleMent = xmlLayerMap.CreateElement("DX_Text"); //标注偏移
            eleMent.InnerText = "3";
            nodeLayer.AppendChild(eleMent);

            eleMent = xmlLayerMap.CreateElement("DY_Text"); //标注偏移
            eleMent.InnerText = "-3";
            nodeLayer.AppendChild(eleMent);

            currentNode.AppendChild(nodeLayer);
            xmlLayerMap.Save(filePathLayerCss);
        }

        public static void addLayerDailyProduct2XML(string filePathLayerCss, string sIDLayer, float fVscale)
        {
            XmlDocument xmlLayerMap = new XmlDocument();
            xmlLayerMap.Load(filePathLayerCss);
            XmlNode currentNode = xmlLayerMap.SelectSingleNode("/LayerMapConfig");
            XmlNode nodeLayer = xmlLayerMap.CreateElement("Layer");
            XmlAttribute nodeID = xmlLayerMap.CreateAttribute("id");
            nodeID.Value = sIDLayer;
            nodeLayer.Attributes.Append(nodeID);
            XmlAttribute nodeType = xmlLayerMap.CreateAttribute("LayerType");
            nodeType.Value = TypeLayer.LayerDailyProduct.ToString();
            nodeLayer.Attributes.Append(nodeType);
            XmlElement eleMent;

            eleMent = xmlLayerMap.CreateElement("fVScale");
            eleMent.InnerText = fVscale.ToString();
            nodeLayer.AppendChild(eleMent);

            eleMent = xmlLayerMap.CreateElement("fRectWidth");
            eleMent.InnerText = "1";
            nodeLayer.AppendChild(eleMent);

            eleMent = xmlLayerMap.CreateElement("textFontSize");
            eleMent.InnerText = "3";
            nodeLayer.AppendChild(eleMent);

            eleMent = xmlLayerMap.CreateElement("DX_Text"); //标注偏移
            eleMent.InnerText = "3";
            nodeLayer.AppendChild(eleMent);

            eleMent = xmlLayerMap.CreateElement("DY_Text"); //标注偏移
            eleMent.InnerText = "-3";
            nodeLayer.AppendChild(eleMent);

            currentNode.AppendChild(nodeLayer);
            xmlLayerMap.Save(filePathLayerCss);
        }
      
    }
}
