using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml.Linq;
using System.Xml;
using System.IO;
using DOGPlatform.XML;

namespace DOGPlatform.SVG
{
    class cSVGoperate
    {
        //为了从一个svg查找def插入另一个svg中，用了xElement 到 xmlELement的变换，xElemnt的命名空间查找是调试成功的
        public static void addSVGpatternDefs(XmlDocument svgDoc, XmlElement svgDefs, string sIDPattern, string filePathPatternSVG)
        {
            string sPath = string.Format("//*[@id='{0}']", sIDPattern);
            XmlNode selectedNode = svgDefs.SelectSingleNode(sPath);
            if (selectedNode == null)
            {
                XDocument doc = XDocument.Load(filePathPatternSVG);
                XNamespace ns1 = "http://www.w3.org/2000/svg";
                var defNode = doc.Descendants(ns1 + "defs").FirstOrDefault();
                //判断类型是否存在   
                IEnumerable<XElement> patternXElist = defNode.Elements();

                foreach (XElement xe in patternXElist)
                {
                    var cloneEntries = cXmlBase.convertXelement2XmlElement(xe);
                    //svg换文件导入要变换
                    XmlNode patternNode = svgDoc.ImportNode(cloneEntries, true);
                    svgDefs.AppendChild(patternNode);
                }
            }
        }

        //public static string getSelectedNodeChildNodeValue(string svgFilePath, string sEleID, string _childTag)
        //{
        //    if (File.Exists(svgFilePath))
        //    {
        //        XDocument doc = XDocument.Load(svgFilePath);
        //        XNamespace ns1 = "http://www.w3.org/2000/svg";
        //        var defNode = doc.Descendants(ns1 + "defs").FirstOrDefault(p => p.Attribute("id").Value == sEleID);
        //        string sPath = string.Format("//*[@id='{0}']", _sID);
        //        XmlNode selectedNode = xmlDoc.SelectSingleNode(sPath);
        //        if (selectedNode != null && selectedNode[_childTag] != null) return selectedNode[_childTag].InnerText;
        //        else return "";
        //    }
        //    else
        //        return "";
        //}

        public static XElement selectXElementByID(string svgFilePath, string sEleID)
        {
            XDocument doc = XDocument.Load(svgFilePath);
            XNamespace ns1 = "http://www.w3.org/2000/svg";
            var returnNode = doc.Descendants(ns1 + "polygon").SingleOrDefault(p => p.Attribute("id").Value == sEleID);
            return returnNode;
        }

        public static void  updateXElementValueByID(string svgFilePath, string sEleID, string strPropertyName,string sValue )
        {
            XDocument xDoc = XDocument.Load(svgFilePath);
            XNamespace ns1 = "http://www.w3.org/2000/svg";
            var selectXEle = xDoc.Descendants(ns1 + "polygon").SingleOrDefault(p => p.Attribute("id").Value == sEleID);
            if (selectXEle != null) selectXEle.Attribute(strPropertyName).Value = sValue;
            xDoc.Save(svgFilePath);
        }
    }
}
