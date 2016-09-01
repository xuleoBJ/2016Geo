using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.IO;

namespace DOGPlatform.XML
{
    class cXmlDocSectionWell : cXmlBase
    {
        public static void generateXML(string pathTemplate, string sJH, double dfTopDepth, double dfBottomDepth, double  fVScale)
        {
            XDocument XDoc = new XDocument(
                new XElement("WellTemplate",
                          new XElement("JH", sJH),
                          new XElement("X", "0"),
                          new XElement("Y", "0"),
                          new XElement("kb", "0"),
                          new XElement("fWellBaseDepth", "0"),
                          new XElement("fHorizonalTopDetph", "9999999"),
                          new XElement("fHorizonalBopDetph", "9999999"),
                          new XElement("TrackCollection"),
                          new XElement("TrackCollectionHorizon")
                    )
                  );
            XDoc.Element("WellTemplate").Add(cXEWellPage.Page(sJH, dfTopDepth, dfBottomDepth, fVScale));
            XDoc.Save(pathTemplate);
        }

        public static string fullPathJH = "WellTemplate/JH";
        public static string fullPathX = "WellTemplate/X";
        public static string fullPathY = "WellTemplate/Y";
        public static string fullPathKB = "WellTemplate/kb";
        public static string fullPathBase = "WellTemplate/dfBaseDetph";
        public static string fullPathTrackCollection = "WellTemplate/TrackCollection";

        public static void save2XTM(string pathTemplate)
        {
            XmlDocument wellTemplateXML = new XmlDocument();
            wellTemplateXML.Load(pathTemplate);
            string sPath = "//sData";
            foreach(XmlNode sDataNode in wellTemplateXML.SelectNodes(sPath))
            {
                sDataNode.InnerText = "";
            }
            sPath = "//dataList";
            foreach (XmlNode dataList in wellTemplateXML.SelectNodes(sPath))
            {
                dataList.ParentNode.RemoveChild(dataList);
            }
            wellTemplateXML.Save(pathTemplate);
        }
     
        public static XmlNodeList  getTrackNodes(string xmlFilePath)
        {
            XmlDocument XmlDocSection = new XmlDocument();
            XmlDocSection.Load(xmlFilePath);
            string pathTrack = "/WellTemplate/TrackCollection/Track";
            return XmlDocSection.SelectNodes(pathTrack);
        }

        public static XmlNodeList getTrackNodes(XmlDocument XmlDocSection)
        {
            string pathTrack = "/WellTemplate/TrackCollection/Track";
            return XmlDocSection.SelectNodes(pathTrack);
        }

        public static XmlNodeList getTrackHorizonNodes(string xmlFilePath)
        {
            XmlDocument XDocSection = new XmlDocument();
            XDocSection.Load(xmlFilePath);
            string pathTrack  = "/WellTemplate/TrackCollectionHorizon/Track";
            return XDocSection.SelectNodes(pathTrack);
        }
        //增加水平段
        public static void addHorizonalWell(string pathTemplate)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(pathTemplate);
            XmlNode root = xmlDoc.DocumentElement;
            XmlElement elem = xmlDoc.CreateElement("TrackCollectionHorizon");
            root.AppendChild(elem);
            xmlDoc.Save(pathTemplate); 
        }

        public static XElement setTrackNode(string filePathSelectTemplatelate, TypeTrack eTypeTrack, int iTrackWidth) 
        {
            string sTrackID = cIDmake.idTrack();  //自动分配一个id,时间是唯一
            string sTrackTitle = eTypeTrack.ToString();
            XElement trackNode = new XElement("Track", new XAttribute("id", sTrackID));

            trackNode.Add(new XElement("visible", "1"));
            trackNode.Add(new XElement("trackType", eTypeTrack.ToString()));
            trackNode.Add(new XElement("trackTitle", sTrackTitle));
            trackNode.Add(new XElement("trackWidth", iTrackWidth.ToString()));
            trackNode.Add(new XElement("hasRect", "0"));
            trackNode.Add(new XElement("fontColor", "black"));
            trackNode.Add(new XElement("trackHeadRectHeight", "60"));
            trackNode.Add(new XElement("trackHeadFontSize", "18"));
            trackNode.Add(new XElement("fontSize", "16")); //道内字体
            trackNode.Add(new XElement("writingMode", "lr"));
            if (eTypeTrack == TypeTrack.深度尺)
            {
                trackNode.Add(new XElement("mainScale", "50"));
                trackNode.Add(new XElement("minScale", "10"));
                trackNode.Add(new XElement("iTypeRuler", "0"));
                trackNode.Add(new XElement("unit", "m"));
            }
            if (eTypeTrack == TypeTrack.分层)
            {
                trackNode.Add(new XElement("autoFill", "true"));
            }
            else if (eTypeTrack == TypeTrack.曲线道)
            {
                
            }
            else if (eTypeTrack == TypeTrack.符号)
            {
                trackNode.Add(new XElement("textFontSize", "10")); //备用
                trackNode.Add(new XElement("textFontColor", "black")); //备用
            }
            else if (eTypeTrack == TypeTrack.文本道)
            {
                trackNode.Add(new XElement("iAlignMode", ((int)textAlignMode.middleMiddle).ToString()));
                trackNode.Add(new XElement("textFontSize", "10")); //备用
                trackNode.Add(new XElement("textFontColor", "black")); //备用
            }
            if (eTypeTrack == TypeTrack.测井解释)
            {

            }
            return trackNode;
        
        } 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePathSelectTemplatelate"></param>
        /// <param name="track"></param>
        /// <param name="sTrackID">与结点的name一致</param>
        /// <param name="sTrackTitle"></param>
        public static void addTrackCss(string filePathSelectTemplatelate, TypeTrack eTypeTrack,int iTrackWidth)
        {
            XElement trackNode = setTrackNode(filePathSelectTemplatelate, eTypeTrack, iTrackWidth);
            XDocument XsingleWellStyleRoot = XDocument.Load(filePathSelectTemplatelate);
            XElement XNode = XsingleWellStyleRoot.Element("WellTemplate").Element("TrackCollection");
            XNode.Add(trackNode);
            XsingleWellStyleRoot.Save(filePathSelectTemplatelate);
        }

        public static void addTrackCss(string filePathSelectTemplatelate, string strackID,TypeTrack eTypeTrack, int iTrackWidth)
        {
            XElement trackNode = setTrackNode(filePathSelectTemplatelate, eTypeTrack, iTrackWidth);
            XDocument XsingleWellStyleRoot = XDocument.Load(filePathSelectTemplatelate);
            XElement xCurTrack = XsingleWellStyleRoot.Element("WellTemplate").Element("TrackCollection").
                Elements("Track").SingleOrDefault(x => x.Attribute("id").Value == strackID) ;
            if (xCurTrack != null) xCurTrack.AddAfterSelf(trackNode);
            else
            {
                xCurTrack = XsingleWellStyleRoot.Element("WellTemplate").Element("TrackCollection");
                xCurTrack.Add(trackNode);
            }
            XsingleWellStyleRoot.Save(filePathSelectTemplatelate);
        }

        public static void addTrackHorizonCss(string filePathSelectTemplatelate, TypeTrack track)
        {
            XElement trackNode = setTrackNode(filePathSelectTemplatelate, track,50);
            XDocument XsingleWellStyleRoot = XDocument.Load(filePathSelectTemplatelate);
            XElement XNode = XsingleWellStyleRoot.Element("WellTemplate").Element("TrackCollectionHorizon");
            XNode.Add(trackNode);
            XsingleWellStyleRoot.Save(filePathSelectTemplatelate);
        }

        public static List<itemLogHeadInforDraw> getTrackLogHeadList(string pathTemplate, string sIDTrack)
        {
            List<itemLogHeadInforDraw> ltItemLogHeadInforDraw = new List<itemLogHeadInforDraw>(); //记录绘制道头用，节省重新读取的时间
            XmlDocument wellTemplateXML = new XmlDocument();
            wellTemplateXML.Load(pathTemplate);
            string sPath = string.Format("//*[@id='{0}']", sIDTrack);
            XmlNode el_Track = wellTemplateXML.SelectSingleNode(sPath);
            XmlNodeList xnList = el_Track.SelectNodes(".//Log");
            foreach (XmlElement xnLog in xnList)
            {
                itemLogHeadInforDraw curLogHead = new itemLogHeadInforDraw(xnLog);
                ltItemLogHeadInforDraw.Add(curLogHead);
            }
            return ltItemLogHeadInforDraw; 
        }

        public static List<string> getTrackLogListIDFillItem(string pathTemplate, string sIDTrack)
        {
            List<string> ltStrID = new List<string>();
            XmlDocument wellTemplateXML = new XmlDocument();
            wellTemplateXML.Load(pathTemplate);
            string sPath = string.Format("//*[@id='{0}']", sIDTrack);
            XmlNode el_Track = wellTemplateXML.SelectSingleNode(sPath);
            XmlNodeList xnList = el_Track.SelectNodes(".//FillItem");
            foreach (XmlElement xn in xnList) ltStrID.Add(xn.Attributes["id"].Value);
            return ltStrID;
        }
        //sTrackID 是 曲线道
        public static string addLog(string pathTemplate, string sTrackID, ItemLogHeadInfor logHead)
        {
            //传入一个参数， sIDTrack 根据 sIDTrack 找到插入的位置，
           
                XmlDocument wellTemplateXML = new XmlDocument();
                wellTemplateXML.Load(pathTemplate);
                string sPath = string.Format("//*[@id='{0}']", sTrackID);
                XmlNode XNode = wellTemplateXML.SelectSingleNode(sPath);

                string sLogID = cIDmake.idLogCurve(logHead.sLogName);
                XmlElement eleLogTrack = wellTemplateXML.CreateElement("Log");
                eleLogTrack.SetAttribute("id", sLogID);

                XmlElement newNode;

                newNode = wellTemplateXML.CreateElement("visible");
                newNode.InnerText = "1";
                eleLogTrack.AppendChild(newNode);

                newNode = wellTemplateXML.CreateElement("hasGrid");
                newNode.InnerText = "1";
                eleLogTrack.AppendChild(newNode);

                newNode = wellTemplateXML.CreateElement("is2Log10");
                newNode.InnerText = "0";
                eleLogTrack.AppendChild(newNode);

                newNode = wellTemplateXML.CreateElement("sparsePoint");
                newNode.InnerText = "2";
                eleLogTrack.AppendChild(newNode);

                newNode = wellTemplateXML.CreateElement("gridLineWidth");
                newNode.InnerText = "0.5";
                eleLogTrack.AppendChild(newNode);

                newNode = wellTemplateXML.CreateElement("typeMode");
                newNode.InnerText = TypeTrack.曲线.ToString();
                eleLogTrack.AppendChild(newNode);

                newNode = wellTemplateXML.CreateElement("fill");
                newNode.InnerText = logHead.sFill;
                eleLogTrack.AppendChild(newNode);

                newNode = wellTemplateXML.CreateElement("fill-rule");
                newNode.InnerText = "nonzero";
                eleLogTrack.AppendChild(newNode);

                newNode = wellTemplateXML.CreateElement("logName");
                newNode.InnerText = logHead.sLogName;
                eleLogTrack.AppendChild(newNode);

                newNode = wellTemplateXML.CreateElement("logText");
                newNode.InnerText = logHead.sLogName;
                eleLogTrack.AppendChild(newNode);
                
                newNode = wellTemplateXML.CreateElement("unit");
                newNode.InnerText = logHead.sUnit;
                eleLogTrack.AppendChild(newNode);

                newNode = wellTemplateXML.CreateElement("lineWidth");
                newNode.InnerText = logHead.fLineWidth.ToString();
                eleLogTrack.AppendChild(newNode);

                newNode = wellTemplateXML.CreateElement("lineType");
                newNode.InnerText = logHead.iLineType.ToString();
                eleLogTrack.AppendChild(newNode);

                newNode = wellTemplateXML.CreateElement("curveColor");
                newNode.InnerText = logHead.sLogColor;
                eleLogTrack.AppendChild(newNode);

                newNode = wellTemplateXML.CreateElement("leftValue");
                newNode.InnerText = logHead.fLeftValue.ToString();
                eleLogTrack.AppendChild(newNode);

                newNode = wellTemplateXML.CreateElement("rightValue");
                newNode.InnerText = logHead.fRightValue.ToString();
                eleLogTrack.AppendChild(newNode);

                XNode.AppendChild(eleLogTrack);

                wellTemplateXML.Save(pathTemplate);

         
            return sLogID;
        }

        public static void addLogTrackFill(string pathTemplate, string sTrackID, string sIDFillItem, int iModeFill, string sIDLogmain, string sIDLogSub, float fValueCutoff, string sFill, string sTop, string sBot, float fillOpacity)
        {
            //传入一个参数， sIDTrack 根据 sIDTrack 找到插入的位置，
            try
            {
                XmlDocument wellTemplateXML = new XmlDocument();
                wellTemplateXML.Load(pathTemplate);
                string sPath = string.Format("//*[@id='{0}']", sTrackID);
                XmlNode XNode = wellTemplateXML.SelectSingleNode(sPath);
                if (XNode["FillCollection"] == null)
                {
                    XmlElement fillCollection = wellTemplateXML.CreateElement("FillCollection");
                    fillCollection.SetAttribute("id", cIDmake.idFillLog());
                    XNode.AppendChild(fillCollection);
                }


                XmlElement eleItem = wellTemplateXML.CreateElement("FillItem");
                eleItem.SetAttribute("id", sIDFillItem);

                XmlElement newNode;

                newNode = wellTemplateXML.CreateElement("idLogMain");
                newNode.InnerText = sIDLogmain;
                eleItem.AppendChild(newNode);

                newNode = wellTemplateXML.CreateElement("iModeFill");
                newNode.InnerText = iModeFill.ToString();
                eleItem.AppendChild(newNode);

                newNode = wellTemplateXML.CreateElement("idLogSub");
                newNode.InnerText = sIDLogSub;
                eleItem.AppendChild(newNode);

                newNode = wellTemplateXML.CreateElement("fCutoffValue");
                newNode.InnerText = fValueCutoff.ToString();
                eleItem.AppendChild(newNode);

                newNode = wellTemplateXML.CreateElement("fill");
                newNode.InnerText = sFill;
                eleItem.AppendChild(newNode);

                newNode = wellTemplateXML.CreateElement("fillOpacity");
                newNode.InnerText = fillOpacity.ToString("0.0");
                eleItem.AppendChild(newNode);

                newNode = wellTemplateXML.CreateElement("top");
                newNode.InnerText = sTop;
                eleItem.AppendChild(newNode);

                newNode = wellTemplateXML.CreateElement("bot");
                newNode.InnerText = sBot;
                eleItem.AppendChild(newNode);

                XNode["FillCollection"].AppendChild(eleItem);

                wellTemplateXML.Save(pathTemplate);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
       
        public static void updateLogTrackFill(string pathTemplate, string sTrackID, string sIDFillItem, int iModeFill,string sIDLogmain,string sIDLogSub,float fValueCutoff,string sFill,string sTop,string sBot,float fillOpacity)
        {
            //传入一个参数， sIDTrack 根据 sIDTrack 找到插入的位置，
            try
            {
                XmlDocument wellTemplateXML = new XmlDocument();
                wellTemplateXML.Load(pathTemplate);
                string sPath = string.Format("//*[@id='{0}']", sTrackID);
                XmlNode XNode = wellTemplateXML.SelectSingleNode(sPath);
                if (XNode["FillCollection"] == null)
                {
                    XmlElement fillCollection = wellTemplateXML.CreateElement("FillCollection");
                    fillCollection.SetAttribute("id", cIDmake.idFillLog());
                    XNode.AppendChild(fillCollection);
                }

                string sPathItem = string.Format(".//*[@id='{0}']", sIDFillItem);
                XmlNode selectItem = XNode["FillCollection"] .SelectSingleNode(sPathItem);
                if (selectItem != null)
                {
                    selectItem["idLogMain"].InnerText = sIDLogmain;
                    selectItem["iModeFill"].InnerText = iModeFill.ToString();
                    selectItem["idLogSub"].InnerText = sIDLogSub;
                    selectItem["fCutoffValue"].InnerText = fValueCutoff.ToString();
                    selectItem["fill"].InnerText = sFill;
                    selectItem["top"].InnerText = sTop;
                    selectItem["bot"].InnerText = sBot;
                    selectItem["fillOpacity"].InnerText = fillOpacity.ToString("0.0");
                    wellTemplateXML.Save(pathTemplate);
                }
                else 
                {
                    addLogTrackFill(pathTemplate, sTrackID, sIDFillItem, iModeFill, sIDLogmain, sIDLogSub, fValueCutoff, sFill, sTop, sBot, fillOpacity);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void addDataItemListIntervaProperty(string pathTemplate, string sTrackID, List<itemDrawDataIntervalValue> listItem)
        {
            //传入一个参数， sIDTrack 根据 sIDTrack 找到插入的位置，关键 当前测井道sID如何定义
            try
            {
                XmlDocument wellTemplateXML = new XmlDocument();
                wellTemplateXML.Load(pathTemplate);
                string sPath = string.Format("//*[@id='{0}']", sTrackID);
                XmlNode XselectNode = wellTemplateXML.SelectSingleNode(sPath);

                //先删除原有数据
                XmlNodeList dataListNode = XselectNode.SelectNodes("dataList");
                for (int i = dataListNode.Count - 1; i >= 0; i--) dataListNode[i].ParentNode.RemoveChild(dataListNode[i]);

                //创建一个新的dataList
                XmlElement eleDataList = wellTemplateXML.CreateElement("dataList");
                eleDataList.SetAttribute("id", cIDmake.idDataList());

                string strTrackType=cXmlDocSectionWell.getTrackTypeByID(pathTemplate,sTrackID);
                foreach (ItemTrackDataIntervalProperty itemTextPro in listItem)
                {
                    float top = itemTextPro.top;
                    float bot = itemTextPro.bot;
                    float topTVD = itemTextPro.topTVD;
                    float botTVD = itemTextPro.botTVD;
                    string sText = itemTextPro.sText;
                    string sProperty = itemTextPro.sProperty;

                    XmlElement dataItem = wellTemplateXML.CreateElement("dataItem");
                    dataItem.SetAttribute("id", cIDmake.idDataItem());

                    XmlElement newNode;
                    newNode = wellTemplateXML.CreateElement("top");
                    newNode.InnerText = top.ToString();
                    dataItem.AppendChild(newNode);

                    newNode = wellTemplateXML.CreateElement("bot");
                    newNode.InnerText = bot.ToString();
                    dataItem.AppendChild(newNode);

                    newNode = wellTemplateXML.CreateElement("topTVD");
                    newNode.InnerText = topTVD.ToString();
                    dataItem.AppendChild(newNode);

                    newNode = wellTemplateXML.CreateElement("botTVD");
                    newNode.InnerText = botTVD.ToString();
                    dataItem.AppendChild(newNode);

                    newNode = wellTemplateXML.CreateElement("sText");
                    newNode.InnerText = sText;
                    dataItem.AppendChild(newNode);

                    newNode = wellTemplateXML.CreateElement("sProperty");
                    newNode.InnerText = sProperty;
                    dataItem.AppendChild(newNode);

                    newNode = wellTemplateXML.CreateElement("fValue");
                    ItemCode inputCode = cProjectManager.ltCodeItem.FirstOrDefault(p => p.chineseName == sText);
                    newNode.InnerText = "1";
                    if (inputCode != null) newNode.InnerText = inputCode.scale.ToString("0.00");
                    dataItem.AppendChild(newNode); 

                    eleDataList.AppendChild(dataItem);
                }

                XselectNode.AppendChild(eleDataList);

                wellTemplateXML.Save(pathTemplate);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static List<ItemTrackDataIntervalProperty> getListDataItemIntervalProperty(string pathTemplate, string sTrackID)
        {
            List<ItemTrackDataIntervalProperty> listItem = new List<ItemTrackDataIntervalProperty>();
        
                XmlDocument wellTemplateXML = new XmlDocument();
                wellTemplateXML.Load(pathTemplate);
                string sPath = string.Format("//*[@id='{0}']", sTrackID);
                XmlNode XTrackNode = wellTemplateXML.SelectSingleNode(sPath);

                XmlNode dataListNode = XTrackNode.SelectSingleNode("dataList");

                if (dataListNode == null) return listItem;

                XmlNodeList dataItem = dataListNode.SelectNodes("dataItem");
                foreach (XmlNode xn in dataItem)
                {
                    ItemTrackDrawDataIntervalProperty item = new ItemTrackDrawDataIntervalProperty(xn);
                    listItem.Add(item);
                }

                return listItem;

        }

        public static List<itemDrawDataIntervalValue> getListDataItemIntervalPropertyValue(string pathTemplate, string sTrackID)
        {
            List<itemDrawDataIntervalValue> listItem = new List<itemDrawDataIntervalValue>();

            XmlDocument wellTemplateXML = new XmlDocument();
            wellTemplateXML.Load(pathTemplate);
            string sPath = string.Format("//*[@id='{0}']", sTrackID);
            XmlNode XTrackNode = wellTemplateXML.SelectSingleNode(sPath);

            XmlNode dataListNode = XTrackNode.SelectSingleNode("dataList");

            if (dataListNode == null) return listItem;

            XmlNodeList dataItem = dataListNode.SelectNodes("dataItem");
            foreach (XmlNode xn in dataItem)
            {
                itemDrawDataIntervalValue item = new itemDrawDataIntervalValue(xn);
                listItem.Add(item);
            }

            return listItem;

        }

        public static void addDataItemIntervalValue(string pathTemplate, string sTrackID, itemDrawDataIntervalValue item)
        {
            //传入一个参数， sIDTrack 根据 sIDTrack 找到插入的位置，关键 当前测井道sID如何定义
            try
            {
                XmlDocument wellTemplateXML = new XmlDocument();
                wellTemplateXML.Load(pathTemplate);
                string sPath = string.Format("//*[@id='{0}']", sTrackID);
                XmlNode XTrackNode = wellTemplateXML.SelectSingleNode(sPath);

                XmlNode dataListNode = XTrackNode.SelectSingleNode("dataList");

                if (dataListNode == null)
                {
                    XmlElement ele = wellTemplateXML.CreateElement("dataList");
                    ele.SetAttribute("id", cIDmake.idDataList());
                    XTrackNode.AppendChild(ele);
                    dataListNode = XTrackNode.SelectSingleNode("dataList");
                }

                XmlElement dataItem = creatDataItemIntervalValue(wellTemplateXML, item);

                dataListNode.AppendChild(dataItem);

                wellTemplateXML.Save(pathTemplate);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static string getJH(string pathTemplate) 
        {
            return cXmlBase.getNodeInnerText(pathTemplate, cXmlDocSectionWell.fullPathJH); 
        }

        public static void setDataIntervalProperty(string pathTemplate, ItemTrackDrawDataIntervalProperty itemInterval)
        {
            if (File.Exists(pathTemplate))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(pathTemplate);
                string sPath = string.Format("//*[@id='{0}']", itemInterval.sID);
                XmlNode selectedNode = xmlDoc.SelectSingleNode(sPath);
                if (selectedNode != null)
                {
                    selectedNode["top"].InnerText = itemInterval.top.ToString();
                    selectedNode["bot"].InnerText = itemInterval.bot.ToString();
                    selectedNode["topTVD"].InnerText = itemInterval.topTVD.ToString();
                    selectedNode["botTVD"].InnerText = itemInterval.botTVD.ToString();
                    selectedNode["sProperty"].InnerText = itemInterval.sProperty.ToString();
                    selectedNode["sText"].InnerText = itemInterval.sText.ToString();
                }
                xmlDoc.Save(pathTemplate);
            }
        }

        public static void setDataItemIntervalValue(string pathTemplate, itemDrawDataIntervalValue itemInterval)
        {
            if (File.Exists(pathTemplate))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(pathTemplate);
                string sPath = string.Format("//*[@id='{0}']", itemInterval.sID);
                XmlNode selectedNode = xmlDoc.SelectSingleNode(sPath);
                if (selectedNode != null)
                {
                    selectedNode["top"].InnerText = itemInterval.top.ToString();
                    selectedNode["bot"].InnerText = itemInterval.bot.ToString();
                    selectedNode["topTVD"].InnerText = itemInterval.topTVD.ToString();
                    selectedNode["botTVD"].InnerText = itemInterval.botTVD.ToString();
                    selectedNode["sProperty"].InnerText = itemInterval.sProperty.ToString();
                    selectedNode["sText"].InnerText = itemInterval.sText.ToString();
                    if (selectedNode["fValue"]!=null) selectedNode["fValue"].InnerText = itemInterval.fValue.ToString();
                }
                xmlDoc.Save(pathTemplate);
            }
        }
        //在已有的dataList上插入新节点
        public static XmlElement creatDataItemIntervalValue(XmlDocument wellTemplateXML, itemDrawDataIntervalValue item)
        {
            XmlElement dataItem = wellTemplateXML.CreateElement("dataItem");
            dataItem.SetAttribute("id", cIDmake.idDataItem());

            XmlElement newNode;

            newNode = wellTemplateXML.CreateElement("top");
            newNode.InnerText = item.top.ToString();
            dataItem.AppendChild(newNode);

            newNode = wellTemplateXML.CreateElement("bot");
            newNode.InnerText = item.bot.ToString();
            dataItem.AppendChild(newNode);

            newNode = wellTemplateXML.CreateElement("topTVD");
            newNode.InnerText = item.topTVD.ToString();
            dataItem.AppendChild(newNode);

            newNode = wellTemplateXML.CreateElement("botTVD");
            newNode.InnerText = item.botTVD.ToString();
            dataItem.AppendChild(newNode);

            newNode = wellTemplateXML.CreateElement("sText");
            newNode.InnerText = item.sText;
            dataItem.AppendChild(newNode);

            newNode = wellTemplateXML.CreateElement("sProperty");
            newNode.InnerText = item.sProperty;
            dataItem.AppendChild(newNode);


            newNode = wellTemplateXML.CreateElement("fValue");
            newNode.InnerText = item.fValue.ToString();
            dataItem.AppendChild(newNode);

            return dataItem;
        }

        public static XmlElement creatDataItemIntervalProperty(XmlDocument wellTemplateXML, ItemTrackDataIntervalProperty item)
        {
            XmlElement dataItem = wellTemplateXML.CreateElement("dataItem");
            dataItem.SetAttribute("id", cIDmake.idDataItem());

            XmlElement newNode;

            newNode = wellTemplateXML.CreateElement("top");
            newNode.InnerText = item.top.ToString();
            dataItem.AppendChild(newNode);

            newNode = wellTemplateXML.CreateElement("bot");
            newNode.InnerText = item.bot.ToString();
            dataItem.AppendChild(newNode);

            newNode = wellTemplateXML.CreateElement("topTVD");
            newNode.InnerText = item.topTVD.ToString();
            dataItem.AppendChild(newNode);

            newNode = wellTemplateXML.CreateElement("botTVD");
            newNode.InnerText = item.botTVD.ToString();
            dataItem.AppendChild(newNode);

            newNode = wellTemplateXML.CreateElement("sText");
            newNode.InnerText = item.sText;
            dataItem.AppendChild(newNode);

            newNode = wellTemplateXML.CreateElement("sProperty");
            newNode.InnerText = item.sProperty;
            dataItem.AppendChild(newNode);


            return dataItem;
        }

        public static void addDataItemIntervalProperty(string pathTemplate, string sTrackID, ItemTrackDataIntervalProperty item)
        {
            //传入一个参数， sIDTrack 根据 sIDTrack 找到插入的位置，关键 当前测井道sID如何定义
            try
            {
                XmlDocument wellTemplateXML = new XmlDocument();
                wellTemplateXML.Load(pathTemplate);
                string sPath = string.Format("//*[@id='{0}']", sTrackID);
                XmlNode XTrackNode = wellTemplateXML.SelectSingleNode(sPath);

                XmlNode dataListNode = XTrackNode.SelectSingleNode("dataList");

                if (dataListNode == null)
                {
                    XmlElement ele = wellTemplateXML.CreateElement("dataList");
                    ele.SetAttribute("id", cIDmake.idDataList());
                    XTrackNode.AppendChild(ele);
                    dataListNode = XTrackNode.SelectSingleNode("dataList");
                }


                XmlElement dataItem = creatDataItemIntervalProperty(wellTemplateXML, item);

                dataListNode.AppendChild(dataItem);

                wellTemplateXML.Save(pathTemplate);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
     
        public static void updateTrackData(string pathTemplate, string sIDTrack, string sData)
        {
            XmlDocument wellTemplateXML = new XmlDocument();
            wellTemplateXML.Load(pathTemplate);
            string sPath = string.Format("//*[@id='{0}']", sIDTrack);
            XmlNode XNode = wellTemplateXML.SelectSingleNode(sPath);
            if (XNode["sData"] != null)
            {
                XNode["sData"].InnerText = sData; 
            }
            else
            {
                XmlElement newNode = wellTemplateXML.CreateElement("sData");
                newNode.InnerText = sData;
                XNode.AppendChild(newNode);
            }
            wellTemplateXML.Save(pathTemplate);
        }

        public static void updateTrackLogData(string pathTemplate, string sIDLog, string sData)
        {
            //XmlDocument wellTemplateXML = new XmlDocument();
            //wellTemplateXML.Load(pathTemplate);
            //string sPath = string.Format("//*[@id='{0}']", sIDLog);
            //XmlNode XNode = wellTemplateXML.SelectSingleNode(sPath);
            //if (XNode["sData"] != null)
            //{
            //    XNode["sData"].InnerText = sData;
            //}
            //else
            //{
            //    XmlElement newNode = wellTemplateXML.CreateElement("sData");
            //    newNode.InnerText = sData;
            //    XNode.AppendChild(newNode);
            //}
            //wellTemplateXML.Save(pathTemplate);
        }

        public string getTrackData(string pathTemplate, string sIDTrack)
        {
            XmlDocument wellTemplateXML = new XmlDocument();
            wellTemplateXML.Load(pathTemplate);
            string sPath = string.Format("//*[@id='{0}']", sIDTrack);
            XmlNode XNode = wellTemplateXML.SelectSingleNode(sPath);
            return XNode.SelectSingleNode("sData").InnerText;
        }

        public static int getTrackVisible(string pathTemplate, string sIDTrack)
        {
            XmlDocument wellTemplateXML = new XmlDocument();
            wellTemplateXML.Load(pathTemplate);
            string sPath = string.Format("//*[@id='{0}']", sIDTrack);
            XmlNode XNode = wellTemplateXML.SelectSingleNode(sPath);
            if (XNode!=null && XNode.SelectSingleNode("visible") != null) return int.Parse(XNode.SelectSingleNode("visible").InnerText);
            else return -1;
        }

        public static void setTrackVisible(string pathTemplate, string sIDTrack, int iVisible)
        {
            XmlDocument wellTemplateXML = new XmlDocument();
            wellTemplateXML.Load(pathTemplate);
            string sPath = string.Format("//*[@id='{0}']", sIDTrack);
            XmlNode XNode = wellTemplateXML.SelectSingleNode(sPath);
            if (XNode!=null)
            {
                if (XNode["visible"] != null)
                XNode["visible"].InnerText = iVisible.ToString();
                else
                {
                    XmlElement newNode = wellTemplateXML.CreateElement("visible");
                    newNode.InnerText = iVisible.ToString();
                    XNode.AppendChild(newNode);
                }
            }
            
            wellTemplateXML.Save(pathTemplate);
        }

        public static void deleteItemByID(string filePathSelectTemplatelate, string sID)
        {
            //根据sIDtrack查找XML并删除
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filePathSelectTemplatelate);
            string sPath = string.Format("//*[@id='{0}']", sID);
            XmlNode el = xmlDoc.SelectSingleNode(sPath);
            if (el != null) { el.ParentNode.RemoveChild(el); }
            xmlDoc.Save(filePathSelectTemplatelate); 
        }

       public static bool isItemINtrackByID(string filePathSelectTemplatelate, string sIDtrack, string sIDItem) 
        {
          XmlDocument xmlDoc = new XmlDocument();
           xmlDoc.Load(filePathSelectTemplatelate);
           string sPath = string.Format("//*[@id='{0}']", sIDtrack);
           XmlNode elTrack= xmlDoc.SelectSingleNode(sPath);
           if (elTrack != null)
           {
               sPath = string.Format(".//*[@id='{0}']", sIDItem);
               XmlNode elItem = elTrack.SelectSingleNode(sPath);
               if (elItem != null) return true;
           }
           return false;
        }
      
        public static void deleteItemInTrackByID(string filePathSelectTemplatelate, string sIDtrack, string sIDItem)
       {
           XmlDocument xmlDoc = new XmlDocument();
           xmlDoc.Load(filePathSelectTemplatelate);
           string sPath = string.Format("//*[@id='{0}']", sIDtrack);
           XmlNode elTrack= xmlDoc.SelectSingleNode(sPath);
           if (elTrack != null)
           {
               sPath = string.Format(".//*[@id='{0}']", sIDItem);
               XmlNode elItem = elTrack.SelectSingleNode(sPath);
               if (elItem != null) elItem.ParentNode.RemoveChild(elItem);
           }
           xmlDoc.Save(filePathSelectTemplatelate);
       }

       public static itemDrawDataIntervalValue getDataItemValueByID(string filePathSelectTemplatelate, string sIDdataItem)
       {
           XmlDocument xmlDoc = new XmlDocument();
           xmlDoc.Load(filePathSelectTemplatelate);
           string sPath = string.Format("//*[@id='{0}']", sIDdataItem);
           XmlNode el = xmlDoc.SelectSingleNode(sPath);
           itemDrawDataIntervalValue item = new itemDrawDataIntervalValue(el);
           return item;
       }

       public static ItemTrackDrawDataIntervalProperty getDataItemByID(string filePathSelectTemplatelate, string sIDdataItem)
       {
           XmlDocument xmlDoc = new XmlDocument();
           xmlDoc.Load(filePathSelectTemplatelate);
           string sPath = string.Format("//*[@id='{0}']", sIDdataItem);
           XmlNode el = xmlDoc.SelectSingleNode(sPath);
           ItemTrackDrawDataIntervalProperty item = new ItemTrackDrawDataIntervalProperty(el);
           return item;
       }
      
        public static void getDataItemTopBotByID(string filePathSelectTemplatelate, string sIDdataItem,out string sTop,out string sBot)
       {
           XmlDocument xmlDoc = new XmlDocument();
           xmlDoc.Load(filePathSelectTemplatelate);
           string sPath = string.Format("//*[@id='{0}']", sIDdataItem);
           XmlNode el = xmlDoc.SelectSingleNode(sPath);
           sTop = "";
           sBot = "";
           if (el != null) { sTop = el["top"].InnerText;sBot=el["bot"].InnerText; }
       }

        public static XmlNode getTrackByTrackID(string filePathSelectTemplatelate, string sIDtrack)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filePathSelectTemplatelate);
            string sPath = string.Format("//*[@id='{0}']", sIDtrack);
            XmlNode elTrack = xmlDoc.SelectSingleNode(sPath);
            return elTrack;
        }
       public static string getTrackTitleByID(string filePathSelectTemplatelate, string sIDtrack)
       {
           string sTag="trackTitle";
           return getTrackChildInforByID(filePathSelectTemplatelate, sIDtrack, sTag);
       }

       public static string getTrackTypeByID(string filePathSelectTemplatelate, string sIDtrack)
       {
           string sTag="trackType";
           return getTrackChildInforByID(filePathSelectTemplatelate, sIDtrack, sTag);
       }

       public static string getTrackChildInforByID(string filePathSelectTemplatelate, string sIDtrack,string sTag)
       {
           //根据sIDtrack查找XML并删除
           string sRet = "";
           if(File.Exists(filePathSelectTemplatelate))
           {
           XmlDocument xmlDoc = new XmlDocument();
           xmlDoc.Load(filePathSelectTemplatelate);
           string sPath = string.Format("//*[@id='{0}']", sIDtrack);
           XmlNode el = xmlDoc.SelectSingleNode(sPath);
           if (el != null && el[sTag] != null) sRet = el[sTag].InnerText;
           } 
           return sRet;
       }

        public static void deleteSelectLogCurve(string filePathSelectTemplatelate, string sIDtrack, string sLogName)
        {
            //根据sIDtrack查找XML并删除
            XDocument XsingleWellStyleRoot = XDocument.Load(filePathSelectTemplatelate);

            XElement XTrackStyleCollect = XsingleWellStyleRoot.Element("WellTemplate").Element("TrackCollection");
            IEnumerable<XElement> trackStyleElements =
                                                     from el_Track in XTrackStyleCollect.Elements()
                                                     where el_Track.Element("trackID").Value.Equals(sIDtrack)
                                                     select el_Track;

            foreach (XElement trackXL in trackStyleElements)
            {
                IEnumerable<XElement> logXL =
                                           from xl in trackXL.Descendants("Log")
                                           where xl.Element("LogName").Value.Equals(sLogName)
                                           select xl;
                logXL.Remove();
            }

            XsingleWellStyleRoot.Save(filePathSelectTemplatelate);
        }

        public static void sortSelectTrackItem(string filePathSelectTemplatelate, string sIDtrack)
        {
            //根据sIDtrack查找XML并上移
            XDocument XsingleWellStyleRoot = XDocument.Load(filePathSelectTemplatelate);

            XElement XTrack = XsingleWellStyleRoot.Element("WellTemplate").Element("TrackCollection").Elements("Track").Single(x => x.Attribute("id").Value == sIDtrack);
            XElement XTrackDataList = XTrack.Element("dataList");
            if (XTrackDataList!=null &&XTrackDataList.Elements("dataItem") != null)
            {
                List<XElement> listdataItem = XTrackDataList.Elements("dataItem").ToList();
                var orderedtabs = XTrackDataList.Elements("dataItem")
                          .OrderBy(dataItem => (float)dataItem.Element("top"))
                          .ToArray();

                XTrackDataList.RemoveAll();
                foreach (XElement tab in orderedtabs)
                    XTrackDataList.Add(tab);
                XsingleWellStyleRoot.Save(filePathSelectTemplatelate);
            }
        }

        public static void upSelectFill(string filePathSelectTemplatelate,string sTrackID, string sIDFill)
        {
            //根据sIDtrack查找XML并上移
            XDocument XsingleWellStyleRoot = XDocument.Load(filePathSelectTemplatelate);
            
            XElement XTrack = XsingleWellStyleRoot.Element("WellTemplate").Element("TrackCollection").Elements("Track").Single(p=>p.Attribute("id").Value==sTrackID);
            XElement XFillCollection = XTrack.Element("FillCollection");
            List<XElement> listXTrackStyleCollect = XFillCollection.Elements("FillItem").ToList();
            int indexXE = 0;
            for (int i = 0; i < listXTrackStyleCollect.Count; i++)
            {
                if (listXTrackStyleCollect[i].Attribute("id").Value.Equals(sIDFill))
                {
                    indexXE = i;
                    break;
                }
            }
            if (indexXE > 0)
            {
                XElement tempXE = listXTrackStyleCollect[indexXE];
                listXTrackStyleCollect[indexXE] = listXTrackStyleCollect[indexXE - 1];
                listXTrackStyleCollect[indexXE - 1] = tempXE;
            }
            XFillCollection.Elements().Remove();
            for (int i = 0; i < listXTrackStyleCollect.Count; i++)
            {
                XFillCollection.Add(listXTrackStyleCollect[i]);
            }
            XsingleWellStyleRoot.Save(filePathSelectTemplatelate);
        }

        public static void downSelectFill(string filePathSelectTemplatelate, string sTrackID, string sIDFill)
        {
            XDocument XsingleWellStyleRoot = XDocument.Load(filePathSelectTemplatelate);

            XElement XTrack = XsingleWellStyleRoot.Element("WellTemplate").Element("TrackCollection").Elements("Track").Single(p => p.Attribute("id").Value == sTrackID);
            XElement XFillCollection = XTrack.Element("FillCollection");
            List<XElement> listXTrackStyleCollect = XFillCollection.Elements("FillItem").ToList();
            int indexXE = listXTrackStyleCollect.Count - 1;
            for (int i = 0; i < listXTrackStyleCollect.Count; i++)
            {
                if (listXTrackStyleCollect[i].Attribute("id").Value.Equals(sIDFill))
                {
                    indexXE = i;
                    break;
                }
            }
            if (indexXE < listXTrackStyleCollect.Count - 1)
            {
                XElement tempXE = listXTrackStyleCollect[indexXE];
                listXTrackStyleCollect[indexXE] = listXTrackStyleCollect[indexXE + 1];
                listXTrackStyleCollect[indexXE + 1] = tempXE;
            }
            XFillCollection.Elements().Remove();
            for (int i = 0; i < listXTrackStyleCollect.Count; i++)
            {
                XFillCollection.Add(listXTrackStyleCollect[i]);
            }
            XsingleWellStyleRoot.Save(filePathSelectTemplatelate);
        }

        public static void upSelectTrack(string filePathSelectTemplatelate, string sIDtrack)
        {
            //根据sIDtrack查找XML并上移
            XDocument XsingleWellStyleRoot = XDocument.Load(filePathSelectTemplatelate);

            XElement XTrackStyleCollect = XsingleWellStyleRoot.Element("WellTemplate").Element("TrackCollection");

            List<XElement> listXTrackStyleCollect = XTrackStyleCollect.Elements().ToList();
            int indexXE = 0;
            for (int i = 0; i < listXTrackStyleCollect.Count; i++)
            {
                if (listXTrackStyleCollect[i].Attribute("id").Value.Equals(sIDtrack))
                {
                    indexXE = i;
                    break;
                }
            }
            if (indexXE > 0)
            {
                XElement tempXE = listXTrackStyleCollect[indexXE];
                listXTrackStyleCollect[indexXE] = listXTrackStyleCollect[indexXE - 1];
                listXTrackStyleCollect[indexXE - 1] = tempXE;
            }
            XTrackStyleCollect.Elements().Remove();
            for (int i = 0; i < listXTrackStyleCollect.Count; i++)
            {
                XTrackStyleCollect.Add(listXTrackStyleCollect[i]);
            }
            XsingleWellStyleRoot.Save(filePathSelectTemplatelate);
        }

        public static void downSelectTrack(string filePathSelectTemplatelate, string sIDtrack)
        {
            //根据sIDtrack查找XML并上移
            XDocument XsingleWellStyleRoot = XDocument.Load(filePathSelectTemplatelate);

            XElement XTrackStyleCollect = XsingleWellStyleRoot.Element("WellTemplate").Element("TrackCollection");

            List<XElement> listXTrackStyleCollect = XTrackStyleCollect.Elements().ToList();
            int indexXE = listXTrackStyleCollect.Count - 1;
            for (int i = 0; i < listXTrackStyleCollect.Count; i++)
            {
                if (listXTrackStyleCollect[i].Attribute("id").Value.Equals(sIDtrack))
                {
                    indexXE = i;
                    break;
                }
            }
            if (indexXE < listXTrackStyleCollect.Count - 1)
            {
                XElement tempXE = listXTrackStyleCollect[indexXE];
                listXTrackStyleCollect[indexXE] = listXTrackStyleCollect[indexXE + 1];
                listXTrackStyleCollect[indexXE + 1] = tempXE;
            }
            XTrackStyleCollect.Elements().Remove();
            for (int i = 0; i < listXTrackStyleCollect.Count; i++)
            {
                XTrackStyleCollect.Add(listXTrackStyleCollect[i]);
            }
            XsingleWellStyleRoot.Save(filePathSelectTemplatelate);
        }

        public static void pasteTrackByID(string filePathSelectTemplatelate, string sIDTrack)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filePathSelectTemplatelate);

            string sPathSource = string.Format("//*[@id='{0}']", sIDTrack);
            XmlNode elSource = xmlDoc.SelectSingleNode(sPathSource);
            XmlNode xmlNodeCopy = elSource.CloneNode(true);
            //这里要处理所有的ID
            xmlNodeCopy.Attributes["id"].Value = cIDmake.reMakeID(xmlNodeCopy.Attributes["id"].Value);
            remakeIDofNode(xmlNodeCopy);
            if (elSource.ParentNode != null && xmlNodeCopy != null) elSource.ParentNode.InsertAfter(xmlNodeCopy, elSource);
            xmlDoc.Save(filePathSelectTemplatelate);
        }

        //迭代更换nodeID。
        public static void remakeIDofNode(XmlNode node)
        {
            if (node.Attributes!=null && node.Attributes["id"] != null) node.Attributes["id"].Value = cIDmake.reMakeID(node.Attributes["id"].Value);
            if (node.ChildNodes.Count > 0)
            {
                foreach (XmlNode xnItem in node.ChildNodes)
                {
                    remakeIDofNode(xnItem);
                }
            }
        }

        public static void pasteLogCurveByID(string filePathSelectTemplatelate,string sIDLogCopy,string sIDTrackGoal) 
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filePathSelectTemplatelate);

            string sPathSource = string.Format("//*[@id='{0}']", sIDLogCopy);
            XmlNode elSource = xmlDoc.SelectSingleNode(sPathSource);
            XmlNode xmlNodeCopy = elSource.CloneNode(true);
            xmlNodeCopy.Attributes["id"].Value = cIDmake.idLogCurve(xmlNodeCopy["logName"].InnerText);

            string sPath = string.Format("//*[@id='{0}']", sIDTrackGoal);
            XmlNode el = xmlDoc.SelectSingleNode(sPath);
            if (el != null && xmlNodeCopy != null)
            {
                el.AppendChild(xmlNodeCopy);
            }
            xmlDoc.Save(filePathSelectTemplatelate);
        }
    }
}
