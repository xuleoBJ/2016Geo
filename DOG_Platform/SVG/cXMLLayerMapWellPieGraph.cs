using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Drawing;
using DOGPlatform.XML;

namespace DOGPlatform.SVG
{
    class cXMLLayerMapWellPieGraph
    {
        public static void addLayeWellGraph(string filePathLayerCss, string sLayerName,  List<string> ltStrColor, List<string> ltStrRowLine)
        {
            XmlDocument xmlLayerMap = new XmlDocument();
            xmlLayerMap.Load(filePathLayerCss);
            XmlNode LayerListNode = xmlLayerMap.SelectSingleNode("/LayerMapConfig/LayerList");
            if (LayerListNode != null)
            {
                XmlNode nodeLayer = xmlLayerMap.CreateElement("Layer");
                XmlAttribute nodeID = xmlLayerMap.CreateAttribute("id");
                nodeID.Value = cIDmake.idLayer();
                nodeLayer.Attributes.Append(nodeID);

                XmlAttribute nodeName = xmlLayerMap.CreateAttribute("name");
                nodeName.Value = sLayerName;
                nodeLayer.Attributes.Append(nodeName);

                XmlAttribute nodeType = xmlLayerMap.CreateAttribute("layerType");
                nodeType.Value = TypeLayer.LayerPieGraph.ToString();
                nodeLayer.Attributes.Append(nodeType);
                XmlElement eleMent;

                eleMent = xmlLayerMap.CreateElement("sColor");
                eleMent.InnerText = string.Join("\t", ltStrColor);
                nodeLayer.AppendChild(eleMent);

                eleMent = xmlLayerMap.CreateElement("fill-opacity");
                eleMent.InnerText = "0.8";
                nodeLayer.AppendChild(eleMent);

                eleMent = xmlLayerMap.CreateElement("fScaleR");
                eleMent.InnerText = "10";
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

                LayerListNode.AppendChild(nodeLayer);
                xmlLayerMap.Save(filePathLayerCss);
            }
        }

        public static XmlElement gWellPieGraphFromXML(XmlDocument svgDoc, XmlNode xnLayer, string sID, List<ItemWellMapPosition> ltWellPos, cXELayerPage curPage)
        {
            float fR = float.Parse(xnLayer.SelectSingleNode("r").InnerText);
            List<string> listscolor = xnLayer.SelectSingleNode("sColor").InnerText.Split().ToList();
            float fscaleR = float.Parse(xnLayer.SelectSingleNode("fScaleR").InnerText);
            XmlElement gEleWellGraph = svgDoc.CreateElement("g");
            gEleWellGraph.SetAttribute("id", sID);

            XmlNodeList xnList = xnLayer.SelectNodes("data/item");

            foreach (XmlNode item in xnList)
            {
                List<string> listSplitItem = item.InnerText.Split().ToList();
                string jh = listSplitItem[0];
                ItemWellMapPosition itemStaticWellPosi = ltWellPos.Find(p => p.sJH == jh);
                List<float> fListdata = new List<float>();
                for (int i = 1; i < listSplitItem.Count; i++)
                {
                    fListdata.Add(float.Parse(listSplitItem[i]));
                }
                if (itemStaticWellPosi != null)
                {
                    Point PViewWell = cCordinationTransform.transRealPointF2ViewPoint(itemStaticWellPosi.dbX, itemStaticWellPosi.dbY, curPage.xRef, curPage.yRef, curPage.dfscale);
                    gEleWellGraph.AppendChild(cBaseMapSVG.gWellPie(svgDoc,PViewWell, fListdata, listscolor, fscaleR));
                }
            }
            return gEleWellGraph;
        } 
    }
}
