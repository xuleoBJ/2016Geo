using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using DOGPlatform.XML;
using DOGPlatform.SVG;

namespace DOGPlatform.XML
{
    class ItemLayerWellPattern
    {
        public string sJH;
        public string sXCM;
        public double X;
        public double Y;
        public string sText;
        public string sProperty="0";
        public object obj;
        public ItemLayerWellPattern(string _sJH,string _sXCM)
        {
            this.sJH = _sJH;
            this.sXCM = _sXCM;
        }
        public ItemLayerWellPattern(string _sJH)
        {
            this.sJH = _sJH;
        }
        public ItemLayerWellPattern(XmlNode xn)
        {
            this.sJH = xn.Attributes["id"].Value;
            this.X = double.Parse(xn["X"].InnerText);
            this.Y  = double.Parse(xn["Y"].InnerText);
            if (xn["sText"] != null) this.sText = xn["sText"].InnerText;
            if (xn["sProperty"] != null) this.sProperty = xn["sProperty"].InnerText;
        }
    }


    class cXMLLayerMapStatic : cXmlDocLayer
    {
        
        public static void addWellPosition2Layer(string filePathLayerCss, string sLayerID,List<ItemDicLayerDataStatic> listItemWell)
        {
            XmlDocument wellTemplateXML = new XmlDocument();
            wellTemplateXML.Load(filePathLayerCss);
            string sPath = string.Format("//*[@id='{0}']", sLayerID);
            XmlNode XselectNode = wellTemplateXML.SelectSingleNode(sPath);

            //先删除原有数据
            XmlNodeList dataListNode = XselectNode.SelectNodes("dataList");
            for (int i = dataListNode.Count - 1; i >= 0; i--) dataListNode[i].ParentNode.RemoveChild(dataListNode[i]);

            //创建一个新的dataList
            XmlElement eleDataList = wellTemplateXML.CreateElement("dataList");
            eleDataList.SetAttribute("id", cIDmake.idDataList()); 

            foreach (ItemDicLayerDataStatic item in listItemWell)
            {
                XmlElement dataItem = wellTemplateXML.CreateElement("dataItem");
                dataItem.SetAttribute("id", item.sJH);

                XmlElement newNode;
                newNode = wellTemplateXML.CreateElement("xcm");
                newNode.InnerText = item.sXCM.ToString();
                dataItem.AppendChild(newNode);

                newNode = wellTemplateXML.CreateElement("X");
                newNode.InnerText = item.dbX.ToString();
                dataItem.AppendChild(newNode);

                newNode = wellTemplateXML.CreateElement("Y");
                newNode.InnerText = item.dbY.ToString();
                dataItem.AppendChild(newNode);

                newNode = wellTemplateXML.CreateElement("wellType");
                newNode.InnerText = "0";
                dataItem.AppendChild(newNode);
                eleDataList.AppendChild(dataItem);
            }

            XselectNode.AppendChild(eleDataList);
            wellTemplateXML.Save(filePathLayerCss);
        }

        public static void addWellStaticDataDic2XML(string filePathLayerCss,  string sXCM, List<ItemDicLayerDataStatic> listItemWell)
        {
            XmlDocument xmlLayerMap = new XmlDocument();
            xmlLayerMap.Load(filePathLayerCss);
            XmlNodeList xnList = xmlLayerMap.SelectNodes("/LayerMapConfig/DataDicStatic");
            //或许Layer标签的节点
            foreach (XmlNode xn in xnList)
            {
                if ( xn.Attributes["XCM"].Value == sXCM) xn.ParentNode.RemoveChild(xn);
            }

            XmlNode currentNode = xmlLayerMap.SelectSingleNode("/LayerMapConfig");
            XmlNode nodeLayer = xmlLayerMap.CreateElement("DataDicStatic");
            XmlAttribute nodeType = xmlLayerMap.CreateAttribute("XCM");
            nodeType.Value = sXCM;
            nodeLayer.Attributes.Append(nodeType);
            XmlElement eleMent;

            eleMent = xmlLayerMap.CreateElement("data");
            foreach (ItemDicLayerDataStatic item in listItemWell)
            {
                XmlElement itemdata = xmlLayerMap.CreateElement("item");
                itemdata.InnerText = ItemDicLayerDataStatic.item2string(item);
                eleMent.AppendChild(itemdata);
            }
            nodeLayer.AppendChild(eleMent);

            currentNode.AppendChild(nodeLayer);
            xmlLayerMap.Save(filePathLayerCss);
        }
      
        public static void addStaticWellPos2XML(string filePathLayerCss, string sXCM, List<ItemWellMapPosition> listItemWell)
        {
            XmlDocument xmlLayerMap = new XmlDocument();
            xmlLayerMap.Load(filePathLayerCss);
            XmlNodeList xnList = xmlLayerMap.SelectNodes("/LayerMapConfig/DataWellPositionStatic");
            //或许Layer标签的节点
            foreach (XmlNode xn in xnList)
            {
                if (xn.Attributes["XCM"].Value == sXCM) xn.ParentNode.RemoveChild(xn);
            }

            XmlNode currentNode = xmlLayerMap.SelectSingleNode("/LayerMapConfig");
            XmlNode nodeLayer = xmlLayerMap.CreateElement("DataWellPositionStatic");
            XmlAttribute nodeID = xmlLayerMap.CreateAttribute("XCM");
            nodeID.Value = sXCM;
            nodeLayer.Attributes.Append(nodeID);

            XmlElement eleMent;

            eleMent = xmlLayerMap.CreateElement("data");
            foreach (ItemWellMapPosition item in listItemWell)
            {
                XmlElement itemdata = xmlLayerMap.CreateElement("item");
                itemdata.InnerText = ItemWellMapPosition.item2string(item);
                eleMent.AppendChild(itemdata);
            }

            currentNode.AppendChild(nodeLayer);
            xmlLayerMap.Save(filePathLayerCss);
        }

        public static string wellPatternCode(string sProperty) 
        {
            if (sProperty == "0") return "10基础井网采油井";
          return "0井";
        }
        public static XmlElement gWellPattern
     (cSVGDocLayerMap svgLayer,  ItemLayerWellPattern itemWell , int JHFontSize, int radis, int iCirlceWidth, int DX_JHText, int DY_JHText)
        {
            XmlDocument svgDoc = svgLayer.svgDoc;
            XmlElement svgDefs = svgLayer.svgDefs;
            XmlElement gWellItem = svgDoc.CreateElement("g");

            XmlElement gWellRect = svgDoc.CreateElement("rect");
            gWellRect.SetAttribute("id", itemWell.sJH);
            gWellRect.SetAttribute("onclick", "getID(evt)");

            gWellRect.SetAttribute("x", "0");
            gWellRect.SetAttribute("y", "0");
            gWellRect.SetAttribute("width", (radis * 2).ToString());
            gWellRect.SetAttribute("height", (radis * 2).ToString());
            gWellRect.SetAttribute("style", "stroke-width:0");
            gWellRect.SetAttribute("stroke", "black");
            gWellRect.SetAttribute("fill", "none");
            gWellRect.SetAttribute("fill-opacity", "1");


            string sPatterID = wellPatternCode(itemWell.sProperty);
            string filePathPatternSVG = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "pattern", "wellChinese", "开发井", sPatterID + ".svg");
            //按照井别配置井符号填充rect
            if (File.Exists(filePathPatternSVG))//需要查找井pattern存在
            {
                cSVGoperate.addSVGpatternDefs(svgDoc, svgDefs, sPatterID, filePathPatternSVG);
                gWellRect.SetAttribute("fill", string.Format("url(#{0})", sPatterID));
            }
            else //不存在默认填充井pattern
            {
                gWellRect.SetAttribute("fill", "none");
            }
            gWellItem.AppendChild(gWellRect);

            XmlElement gJHText = svgDoc.CreateElement("text");
            gJHText.SetAttribute("x", (-DX_JHText).ToString());
            gJHText.SetAttribute("y", (+DY_JHText).ToString());
            gJHText.SetAttribute("font-size", JHFontSize.ToString());
            gJHText.SetAttribute("font-style", "normal");
            gJHText.InnerText = itemWell.sJH;
            gWellItem.AppendChild(gJHText);

            return gWellItem;
        }
    }
}
