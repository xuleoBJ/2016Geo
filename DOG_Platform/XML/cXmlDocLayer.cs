using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Drawing;

namespace DOGPlatform.XML
{
    /// <summary>
    /// XMLLayerMap类及其继承主要是通过界面生成平面图的数据及样式的XML基础文件，SVG平面图解析器解析这个XML文件形成叠加图层的SVG文件，这样
    /// 成果图的扩展能力变强。
    /// </summary>
    class cXmlDocLayer : cXmlBase
    {
        public static void generateXML(string filePathLayerCss, string sXCM)
        {
            XDocument XDoc = new XDocument(
                new XElement("LayerMapConfig",
                          new XElement("XCM", sXCM),
                          new XElement("YM", ""),
                          new XElement("xRef",cProjectData.dfMapXrealRefer.ToString()),
                          new XElement("YRef",cProjectData.dfMapYrealRefer.ToString()),
                          new XElement("dfMapScale", cProjectData.dfMapScale.ToString("0.00")),
                          new XElement("LayerList")
                    )
                  );
            XDoc.Element("LayerMapConfig").Add(cXELayerPage.PageInfor());
            XDoc.Element("LayerMapConfig").Add(cXELayerPage.Mapframe());
            XDoc.Element("LayerMapConfig").Add(cXELayerPage.ScaleRuler());
            XDoc.Element("LayerMapConfig").Add(cXELayerPage.ComPass());
            XDoc.Element("LayerMapConfig").Add(cXEWellCss.WellCss());
            XDoc.Save(filePathLayerCss);
        }
        public static string fmpXCM = "/LayerMapConfig/XCM";
        public static string fmpYM = "/LayerMapConfig/YM";
        public static string fmpLayerList = "/LayerMapConfig/LayerList";

        public static void addLayerLogData(string pathTemplate, string sTrackID, List<ItemLayerDataProperty> listItem)
        {
            //传入一个参数， sIDTrack 根据 sIDTrack 找到插入的位置，关键 当前测井道sID如何定义
            try
            {
                XmlDocument wellTemplateXML = new XmlDocument();
                wellTemplateXML.Load(pathTemplate);
                string sPath = string.Format("//*[@id='{0}']", sTrackID);
                XmlNode XNode = wellTemplateXML.SelectSingleNode(sPath);

                //先删除原有数据
                XmlNodeList dataListNode = XNode.SelectNodes("dataList");
                for (int i = dataListNode.Count - 1; i >= 0; i--) dataListNode[i].ParentNode.RemoveChild(dataListNode[i]);

                //创建一个新的dataList
                XmlElement eleDataList = wellTemplateXML.CreateElement("dataList");
                eleDataList.SetAttribute("id", cIDmake.idDataList());

                string strTrackType = cXmlDocSectionWell.getTrackTypeByID(pathTemplate, sTrackID);
                foreach (ItemLayerDataProperty itemData in listItem)
                {

                    XmlElement dataItem = wellTemplateXML.CreateElement("dataItem");
                    dataItem.SetAttribute("id", cIDmake.idDataItem());

                    XmlElement newNode;
                    newNode = wellTemplateXML.CreateElement("sJH");
                    newNode.InnerText = itemData.sJH;
                    dataItem.AppendChild(newNode);

                    //newNode = wellTemplateXML.CreateElement("bot");
                    //newNode.InnerText = bot.ToString();
                    //dataItem.AppendChild(newNode);

                    eleDataList.AppendChild(dataItem);
                }

                XNode.AppendChild(eleDataList);

                wellTemplateXML.Save(pathTemplate);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static XmlNodeList getLayerNodes(string filePathLayerCss)
        {
            XmlDocument XmlDocSection = new XmlDocument();
            XmlDocSection.Load(filePathLayerCss);
            string pathLayer = "/LayerMapConfig/LayerList/Layer";
            return XmlDocSection.SelectNodes(pathLayer);
        }
        //增加图层，先增加样式，再增加数据
        public static void addLayerCss(string filePathLayerCss, TypeLayer eTypeTrack)
        {
            XElement layerNode = setLayerNode(filePathLayerCss, eTypeTrack);
            XDocument XsingleWellStyleRoot = XDocument.Load(filePathLayerCss);
            XElement layerList = XsingleWellStyleRoot.Element("LayerMapConfig").Element("LayerList");
            layerList.Add(layerNode);
            XsingleWellStyleRoot.Save(filePathLayerCss);
        }

        public static XElement setLayerNode(string filePathLayerCss, TypeLayer eTypeLayer)
        {
            string sLayerID =  cIDmake.idLayer();  //自动分配一个id,时间是唯一
            string sTitle = eTypeLayer.ToString();
            XElement layerNode = new XElement("Layer", new XAttribute("id", sLayerID));
            layerNode.Add(new XAttribute("layerType", eTypeLayer.ToString()));
            layerNode.Add(new XElement("visible", "1"));
            layerNode.Add(new XElement("title", sTitle));
            layerNode.Add(new XElement("fill-opacity", "0.8"));
            layerNode.Add(new XElement("fontColor", "black"));
            layerNode.Add(new XElement("fontSize", "16")); 
            if (eTypeLayer == TypeLayer.LayerGeoProperty)
            {

            }
            else if (eTypeLayer == TypeLayer.LayerLog)
            {
                layerNode.Add(new XElement("logName", ""));
                layerNode.Add(new XElement("fVScale", "1"));
                layerNode.Add(new XElement("trackWidth", "100"));
                layerNode.Add(new XElement("showValue", "1"));
                layerNode.Add(new XElement("is2Log10", "1"));
                layerNode.Add(new XElement("hasGrid", "1"));
                layerNode.Add(new XElement("sparsePoint", "1"));
                layerNode.Add(new XElement("curveColor", "black"));
                layerNode.Add(new XElement("lineWidth", "1"));
                layerNode.Add(new XElement("lineType", "1"));
                layerNode.Add(new XElement("leftValue", "0"));
                layerNode.Add(new XElement("rightValue", "100"));
                layerNode.Add(new XElement("sFill", "red"));
                layerNode.Add(new XElement("DX_Text", "5"));
                layerNode.Add(new XElement("DY_Text", "5")); 
            }
            else if (eTypeLayer == TypeLayer.LayerPieGraph)
            {
                layerNode.Add(new XElement("fill-opacity", "0.8"));
                layerNode.Add(new XElement("showValue", "1"));
                layerNode.Add(new XElement("sColor", "0.8"));
                layerNode.Add(new XElement("fScaleR", "10"));
                layerNode.Add(new XElement("textFontSize", "5"));
                layerNode.Add(new XElement("DX_Text", "5"));
                layerNode.Add(new XElement("DY_Text", "5")); 
            }
            else if (eTypeLayer == TypeLayer.LayerWellPosition)
            {
                layerNode.Add(new XElement("fill-opacity", "0.8"));
                layerNode.Add(new XElement("showValue", "1"));
                layerNode.Add(new XElement("sColor", "0.8"));
                layerNode.Add(new XElement("fScaleR", "10"));
                layerNode.Add(new XElement("textFontSize", "5"));
                layerNode.Add(new XElement("DX_Text", "5"));
                layerNode.Add(new XElement("DY_Text", "5"));
            }
           
            return layerNode;
        }

        public static void deleteItemByLayerID(string filePathSelectTemplatelate, string sID)
        {
            //根据sIDtrack查找XML并删除
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filePathSelectTemplatelate);
            string sPath = string.Format("//*[@id='{0}']", sID);
            XmlNode el = xmlDoc.SelectSingleNode(sPath);
            if (el != null) { el.ParentNode.RemoveChild(el); }
            xmlDoc.Save(filePathSelectTemplatelate);
        }

        public static void delBaseLayer(string filePathLayerCss)
        {
            XmlDocument xmlLayerMap = new XmlDocument();
            xmlLayerMap.Load(filePathLayerCss);

            XmlNodeList xnList = xmlLayerMap.SelectNodes("/LayerMapConfig/BaseLayer");
            //或许Layer标签的节点
            foreach (XmlNode xn in xnList) xn.ParentNode.RemoveChild(xn);
           
            xmlLayerMap.Save(filePathLayerCss);
        }

        public static void addBaseLayer2XML(string filePathLayerCss, List<ItemWellMapPosition> listItemWell)
        {
            XmlDocument xmlLayerMap = new XmlDocument();
            xmlLayerMap.Load(filePathLayerCss);
            XmlNode currentNode = xmlLayerMap.SelectSingleNode("/LayerMapConfig");
            XmlNode nodeLayer = xmlLayerMap.CreateElement("BaseLayer");
            XmlAttribute nodeID = xmlLayerMap.CreateAttribute("id");
            nodeID.Value = "BaseLayer";
            nodeLayer.Attributes.Append(nodeID);
            XmlElement eleMent;

            //定制井位图属性
            //是否显示
            eleMent = xmlLayerMap.CreateElement("r");
            eleMent.InnerText = "4";
            nodeLayer.AppendChild(eleMent);

            eleMent = xmlLayerMap.CreateElement("rLineWidth");
            eleMent.InnerText = "1";
            nodeLayer.AppendChild(eleMent);
            //定制井数据
            //是否显示
            eleMent = xmlLayerMap.CreateElement("JHIsShow");
            eleMent.SetAttribute("value", "1");
            nodeLayer.AppendChild(eleMent);

            eleMent = xmlLayerMap.CreateElement("fontColor");
            eleMent.SetAttribute("value", "black");
            nodeLayer.AppendChild(eleMent);

            eleMent = xmlLayerMap.CreateElement("fontSize");
            eleMent.InnerText = "10";
            nodeLayer.AppendChild(eleMent);

            eleMent = xmlLayerMap.CreateElement("DX_Text"); //标注偏移
            eleMent.InnerText = "12";
            nodeLayer.AppendChild(eleMent);

            eleMent = xmlLayerMap.CreateElement("data"); //标注偏移
            foreach (ItemWellMapPosition item in listItemWell)
            {
                XmlElement itemdata = xmlLayerMap.CreateElement("item");
                itemdata.InnerText = ItemWellMapPosition.item2string(item);
                eleMent.AppendChild(itemdata);
            }
            nodeLayer.AppendChild(eleMent);

            currentNode.AppendChild(nodeLayer);
            xmlLayerMap.Save(filePathLayerCss);
        }

        public static void delLayerFromXML(string filePathLayerCss,string sID) 
        {

            XmlDocument xmlLayerMap = new XmlDocument();
            xmlLayerMap.Load(filePathLayerCss);

            XmlNodeList xnList = xmlLayerMap.SelectNodes("/LayerMapConfig/Layer");
            //或许Layer标签的节点
            foreach (XmlNode xn in xnList)
            {
                if (xn.Attributes["id"].Value == sID) xn.ParentNode.RemoveChild(xn);
            }
            xmlLayerMap.Save(filePathLayerCss);
        }

        public static void addHorizonal(string filePathLayerCss)
        {
            XmlDocument xmlLayerMap = new XmlDocument();
            xmlLayerMap.Load(filePathLayerCss);
            XmlNode currentNode = xmlLayerMap.SelectSingleNode("/LayerMapConfig/HorizonalWell");
            XmlNodeList listIntervel = currentNode.SelectNodes("WellIntervel");

            for (int i = 0; i < listIntervel.Count; i++)
            {
                string _sInnerText = listIntervel[i].InnerText;
                string[] splitInnerText = _sInnerText.Split();
                string _sJH = splitInnerText[0];
                int _iWellType = int.Parse(splitInnerText[1]);

                Point pWellHead = new Point(int.Parse(splitInnerText[2]), int.Parse(splitInnerText[3]));
                Point pA = new Point(int.Parse(splitInnerText[4]), int.Parse(splitInnerText[5]));
                Point pB = new Point(int.Parse(splitInnerText[6]), int.Parse(splitInnerText[7]));
            }
        }
    }

    class layerDataDraw
    {
        public string sLayerID;
        public string sLayerType;
        public string sLayerTitle;
        public int iVisible=1;

        public layerDataDraw(XmlNode el_Layer)
        {
            XmlElement el = (XmlElement)el_Layer;
            initialLayerData(el);
        }
        void initialLayerData(XmlElement el_Layer)
        {
            sLayerID = el_Layer.Attributes["id"].Value;
            sLayerType = el_Layer.Attributes["layerType"].Value;
            sLayerTitle = el_Layer["title"].InnerText;
 //           iVisible = int.Parse(el_Layer["visible"].InnerText);
        }

        public layerDataDraw(XmlElement el_Layer)
        {
            initialLayerData(el_Layer);
        }

    }
}
