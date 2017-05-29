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
        public static void addLayerFaults2XML(string filePathLayerCss, string sLayerID, string fileName)
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

          
            //按断层名和数据把数据读入配置文件
            List<string> listFaultLineData = cIOBase.readText2StringList(fileName, 0);
            string strFaultNum = "1";
            string sData = "";
            for (int i = 0; i < listFaultLineData.Count - 1;i++ )
            {
                string curLine = listFaultLineData[i];
                string nextLine = listFaultLineData[i + 1];
                char[] delimiterChars = { ' ', ',', '\t' };
                string[] curLineSplit = curLine.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
                string[] nextLineSplit = nextLine.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
                if (i == 0 && curLineSplit.Length >= 3) strFaultNum = curLineSplit[2];
                sData += curLineSplit[0] + "\t" + curLineSplit[1]+"\t";
                if ((curLineSplit[2] != nextLineSplit[2]) || (i +1== listFaultLineData.Count - 1)) 
                {
                    XmlElement dataItem = wellTemplateXML.CreateElement("dataItem");
                    dataItem.SetAttribute("id", cIDmake.idDataItem());
                    XmlElement eleMent;
                    eleMent = wellTemplateXML.CreateElement("lineColor");
                    eleMent.InnerText = "red";
                    dataItem.AppendChild(eleMent);
                    eleMent = wellTemplateXML.CreateElement("lineWidth");
                    eleMent.InnerText = "2";
                    dataItem.AppendChild(eleMent);
                    eleMent = wellTemplateXML.CreateElement("faultName");
                    eleMent.InnerText = strFaultNum;
                    dataItem.AppendChild(eleMent);

                    eleMent = wellTemplateXML.CreateElement("faultType");
                    eleMent.InnerText = "1";
                    dataItem.AppendChild(eleMent);

                    eleMent = wellTemplateXML.CreateElement("data");
                    eleMent.InnerText = string.Join("\t", sData);
                    dataItem.AppendChild(eleMent);

                    eleDataList.AppendChild(dataItem);

                    sData = "";
                    strFaultNum = nextLineSplit[2];
                }
                
            }
          

            XselectNode.AppendChild(eleDataList);
            wellTemplateXML.Save(filePathLayerCss);
        
        }
    }
}
