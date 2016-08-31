using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace DOGPlatform.SVG
{
    class cXMLLayerMapWellBarGraph
    {
        public static void addLayerBarGraph2XML(string filePathLayerCss, string sIDLayer, int iWidthRect, string sBarColor, float fVscale, float fOpacity,List<ItemWellValue> ltItem)
        {
            XmlDocument xmlLayerMap = new XmlDocument();
            xmlLayerMap.Load(filePathLayerCss);
            XmlNode currentNode = xmlLayerMap.SelectSingleNode("/LayerMapConfig/LayerList");
            XmlNode nodeLayer = xmlLayerMap.CreateElement("Layer");
            XmlAttribute nodeID = xmlLayerMap.CreateAttribute("id");
            nodeID.Value = sIDLayer;
            nodeLayer.Attributes.Append(nodeID);
            XmlAttribute nodeType = xmlLayerMap.CreateAttribute("LayerType");
            nodeType.Value = TypeLayer.LayerBarGraph.ToString();
            nodeLayer.Attributes.Append(nodeType);
            XmlElement eleMent;

            eleMent = xmlLayerMap.CreateElement("fVScale");
            eleMent.InnerText = fVscale.ToString();
            nodeLayer.AppendChild(eleMent);

            eleMent = xmlLayerMap.CreateElement("sColor");
            eleMent.InnerText = sBarColor;
            nodeLayer.AppendChild(eleMent);

            eleMent = xmlLayerMap.CreateElement("fill-opacity");
            eleMent.InnerText = "0.6";
            nodeLayer.AppendChild(eleMent);
            

            eleMent = xmlLayerMap.CreateElement("fRectWidth");
            eleMent.InnerText = iWidthRect.ToString();
            nodeLayer.AppendChild(eleMent);

            eleMent = xmlLayerMap.CreateElement("textFontSize");
            eleMent.InnerText = "5";
            nodeLayer.AppendChild(eleMent);

            eleMent = xmlLayerMap.CreateElement("DX_Text"); //标注偏移
            eleMent.InnerText = "3";
            nodeLayer.AppendChild(eleMent);

            eleMent = xmlLayerMap.CreateElement("DY_Text"); //标注偏移
            eleMent.InnerText = "-3";
            nodeLayer.AppendChild(eleMent);

            eleMent = xmlLayerMap.CreateElement("data");
            foreach (ItemWellValue item in ltItem)
            {
                XmlElement itemdata = xmlLayerMap.CreateElement("item");
                itemdata.InnerText = ItemWellValue.item2string(item);
                eleMent.AppendChild(itemdata);
            }
            nodeLayer.AppendChild(eleMent);

            currentNode.AppendChild(nodeLayer);
            xmlLayerMap.Save(filePathLayerCss);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePathLayerCss"></param>
        /// <param name="sIDLayer"></param>
        /// <param name="iWidthRect"></param>
        /// <param name="ltStrBarColor"></param>
        /// <param name="fVscale"></param>
        /// <param name="ltStrRowLine">表格的每一行当成数据存起</param>
        public static void addLayerBarGraph2XML(string filePathLayerCss, string sIDLayer, int iWidthRect, List<string> ltStrBarColor, float fVscale, float fOpacity,
            List<string> ltStrRowLine)
        {
            XmlDocument xmlLayerMap = new XmlDocument();
            xmlLayerMap.Load(filePathLayerCss);
            XmlNode currentNode = xmlLayerMap.SelectSingleNode("/LayerMapConfig/LayerList");
            XmlNode nodeLayer = xmlLayerMap.CreateElement("Layer");
            XmlAttribute nodeID = xmlLayerMap.CreateAttribute("id");
            nodeID.Value = sIDLayer;
            nodeLayer.Attributes.Append(nodeID);
            XmlAttribute nodeType = xmlLayerMap.CreateAttribute("LayerType");
            nodeType.Value = TypeLayer.LayerBarGraph.ToString();
            nodeLayer.Attributes.Append(nodeType);
            XmlElement eleMent;

            eleMent = xmlLayerMap.CreateElement("fVScale");
            eleMent.InnerText = fVscale.ToString();
            nodeLayer.AppendChild(eleMent);

            eleMent = xmlLayerMap.CreateElement("sColor");
            eleMent.InnerText = string.Join("\t", ltStrBarColor);
            nodeLayer.AppendChild(eleMent);

            eleMent = xmlLayerMap.CreateElement("fill-opacity");
            eleMent.InnerText = fOpacity.ToString();
            nodeLayer.AppendChild(eleMent); ;

            eleMent = xmlLayerMap.CreateElement("fRectWidth");
            eleMent.InnerText = iWidthRect.ToString();
            nodeLayer.AppendChild(eleMent);

            eleMent = xmlLayerMap.CreateElement("textFontSize");
            eleMent.InnerText = "5";
            nodeLayer.AppendChild(eleMent);

            eleMent = xmlLayerMap.CreateElement("DX_Text"); //标注偏移
            eleMent.InnerText = "3";
            nodeLayer.AppendChild(eleMent);

            eleMent = xmlLayerMap.CreateElement("DY_Text"); //标注偏移
            eleMent.InnerText = "-3";
            nodeLayer.AppendChild(eleMent);

            eleMent = xmlLayerMap.CreateElement("data");
            for (int i = 0; i < ltStrRowLine.Count; i++)
            {
                XmlElement itemdata = xmlLayerMap.CreateElement("item");
                itemdata.InnerText = string.Join("\t", ltStrRowLine[i]);
                eleMent.AppendChild(itemdata);
            }
            nodeLayer.AppendChild(eleMent);

            currentNode.AppendChild(nodeLayer);
            xmlLayerMap.Save(filePathLayerCss);
        }
    }
}
