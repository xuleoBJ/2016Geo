using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using System.IO;
using System.Xml.Linq;


namespace DOGPlatform.XML
{
    class cXmlBase
    {
        public static void updateNodeValueByAbsPath(string _xmlFilePath, string _nodePath, int _ivalue)
        {
            updateNodeValueByAbsPath(_xmlFilePath, _nodePath, _ivalue.ToString());
        }
        public static void updateNodeValueByAbsPath(string _xmlFilePath, string _nodePath, float _fValue)
        {
            updateNodeValueByAbsPath(_xmlFilePath, _nodePath, _fValue.ToString("0.0"));
        }
        public static void updateNodeValueByAbsPath(string _xmlFilePath, string _nodePath, string _sValue)
        {
            if (File.Exists(_xmlFilePath))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(_xmlFilePath);
                XmlNode currentNode = xmlDoc.SelectSingleNode(_nodePath);
                if (currentNode != null) currentNode.InnerText = _sValue;
                xmlDoc.Save(_xmlFilePath);
            }
        }

        public static XmlNode selectPreNodeByID(string _xmlFilePath, string sIDitem)
        {
            if (sIDitem != "" && File.Exists(_xmlFilePath))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(_xmlFilePath);
                string sPath = string.Format("//*[@id='{0}']", sIDitem);
                return xmlDoc.SelectSingleNode(sPath).PreviousSibling;
            }
            else return null;
        }
        public static XmlNode selectNextNodeByID(string _xmlFilePath, string sIDitem)
        {
            if (sIDitem != ""  && File.Exists(_xmlFilePath))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(_xmlFilePath);
                string sPath = string.Format("//*[@id='{0}']", sIDitem);
                return xmlDoc.SelectSingleNode(sPath).NextSibling;
            }
            else return null;
        }
        public static void setSelectedNodeChildNodeValue(string _xmlFilePath, string sIDitem, string _childTag, string _sValue)
        {
            if (File.Exists(_xmlFilePath))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(_xmlFilePath);
                string sPath = string.Format("//*[@id='{0}']", sIDitem);
                XmlNode selectedNode = xmlDoc.SelectSingleNode(sPath);
                if (selectedNode!=null && selectedNode[_childTag] != null)
                {
                    selectedNode[_childTag].InnerText = _sValue;
                }
                xmlDoc.Save(_xmlFilePath);
            }
        }

        public static string getSelectedNodeChildNodeValue(string _xmlFilePath, string _sID,string _childTag)
        {
            if (File.Exists(_xmlFilePath))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(_xmlFilePath);
                string sPath = string.Format("//*[@id='{0}']", _sID);
                XmlNode selectedNode = xmlDoc.SelectSingleNode(sPath);
                if (selectedNode!=null &&selectedNode[_childTag] != null) return selectedNode[_childTag].InnerText;
                else return "";
            }
            else
                return "";
        }

        public static XmlNode convertXelement2XmlNode(XElement element)
        {
            using (XmlReader xmlReader = element.CreateReader())
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(xmlReader);
                return xmlDoc;
            }
        }

        public static XmlElement convertXelement2XmlElement(XElement el)
        {
            var doc = new XmlDocument();
            doc.Load(el.CreateReader());
            return doc.DocumentElement;
        }

        public static XmlNode selectNodeByID(string pathTemplate, string sID)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(pathTemplate);
            string sPath = string.Format("//*[@id='{0}']", sID);
            XmlNode returnNode = xmlDoc.SelectSingleNode(sPath);
            return returnNode;
        }

        public static XmlNode selectNodeByInnerText(string pathTemplate, string sTag,string sInnerText)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(pathTemplate);
            string sPath = string.Format("//{0}[text()=\"{1}\"]", sTag, sInnerText);
            XmlNode returnNode = xmlDoc.SelectSingleNode(sPath);
            return returnNode;
        }

        public static XmlNode selectNodeInTrackByID(string pathTemplate, string sIDTrack, string sIDitem)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(pathTemplate);
            string sPath = string.Format("//*[@id='{0}']", sIDTrack);
            XmlNode trackNode = xmlDoc.SelectSingleNode(sPath);

            sPath = string.Format(".//*[@id='{0}']", sIDitem);
            if (trackNode != null)
            {
                XmlNode fillItem = trackNode.SelectSingleNode(sPath);
                return fillItem;
            }
            return null;
        }

        public static void addNode(string _xmlFilePath, string _nodePath, XmlNode _ele)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(_xmlFilePath);
            XmlNode currentNode = xmlDoc.SelectSingleNode(_nodePath);
            if (currentNode != null)
            {
                currentNode.AppendChild(_ele);
                xmlDoc.Save(_xmlFilePath);
            }
        }

        public static void addNodeIfNull(string _xmlFilePath, string _nodePath)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(_xmlFilePath);
            XmlNode currentNode = xmlDoc.SelectSingleNode(_nodePath);
            if (currentNode == null)
            {
                XmlNode newNode = xmlDoc.CreateElement(_nodePath);
                currentNode.AppendChild(newNode);
                xmlDoc.Save(_xmlFilePath);
            }
        }

        public static void delNodes(string xmlfilePath, string fullPath, string sTagNameRemoved)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlfilePath);
            XmlNode currentNode = xmlDoc.SelectSingleNode(fullPath);
            if (currentNode != null)
            {
                foreach (XmlNode _node in currentNode.SelectNodes(sTagNameRemoved))
                    currentNode.RemoveChild(_node);
            }
            xmlDoc.Save(xmlfilePath);

        }

        public static void setNodeInnerText(string xmlfilePath, string fullPath, string sInnerText)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlfilePath);
            XmlNode currentNode = xmlDoc.SelectSingleNode(fullPath);
            setNodeInnerText(xmlDoc, fullPath, sInnerText);
            xmlDoc.Save(xmlfilePath); 
        }

        public static void setNodeInnerText(XmlDocument xmlDoc, string fullPath, string sInnerText)
        {
            int _indexSplit = fullPath.LastIndexOf('/');
            string _node = fullPath.Substring(_indexSplit + 1); //+1 delete/
            string _parent = fullPath.Substring(0, _indexSplit);
            XmlNode currentNode = xmlDoc.SelectSingleNode(fullPath);
            if (currentNode != null) currentNode.InnerText = sInnerText;
            else
            {
                //节点没找到，应该插入节点
                XmlNode _parentNode = xmlDoc.SelectSingleNode(_parent);
                currentNode = xmlDoc.CreateNode(XmlNodeType.Element, _node, "");
                _parentNode.AppendChild(currentNode);
            }
        }

        public static string getNodeInnerText(string xmlfilePath, string fullPath)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlfilePath);
            XmlNode currentNode = xmlDoc.SelectSingleNode(fullPath);
            if (currentNode != null)  return currentNode.InnerText;
            else
            {
                //节点没找到，应该插入节点
                return "";
            }
        }

        public static string getNodeInnerText(XmlDocument xmlDoc, string fullPath)
        {
            XmlNode currentNode = xmlDoc.SelectSingleNode(fullPath);
            if (currentNode != null) return currentNode.InnerText;
            else
            {
                //节点没找到，应该插入节点
                return "";
            }
        }

        public static List<string> splitNodeInnerText(string filePathxml, string fullPath)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filePathxml);
            XmlNode currentNode = xmlDoc.SelectSingleNode(fullPath);

            string _data = "";
            if (currentNode != null)
            {
                _data = currentNode.InnerText;
            }
            return _data.Split(new Char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        public static XmlNode setNodeVisibleProperty(XmlDocument xmlDoc ,XmlNode xn, bool bShow)
        {

            var idAttribute = xn.Attributes["id"];
            var styleAttribute = xn.Attributes["style"];
            if (idAttribute != null)
            {
                if ( styleAttribute != null)
                {
                    if (bShow == false) styleAttribute.Value = "display:none;";
                    else styleAttribute.Value = "visibility:visible;";
                }

                if ( styleAttribute == null)
                {
                    styleAttribute = xmlDoc.CreateAttribute("style");
                    if (bShow == false) styleAttribute.Value = "display:none;";
                    else styleAttribute.Value = "visibility:visible;";
                    xn.Attributes.Append(styleAttribute);
                }
            }

            return xn; 
        }
        #region XML文档节点查询和读取
        /// <summary>
        /// 选择匹配XPath表达式的第一个节点XmlNode.
        /// </summary>
        /// <param name="xmlFileName">XML文档完全文件名(包含物理路径)</param>
        /// <param name="xpath">要匹配的XPath表达式(例如:"//节点名//子节点名")</param>
        /// <returns>返回XmlNode</returns>
        public static XmlNode GetXmlNodeByXpath(string xmlFileName, string xpath)
        {
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(xmlFileName); //加载XML文档
                XmlNode xmlNode = xmlDoc.SelectSingleNode(xpath);
                return xmlNode;
            }
            catch (Exception ex)
            {
                return null;
                //throw ex; //这里可以定义你自己的异常处理
            }
        }

        /// <summary>
        /// 选择匹配XPath表达式的节点列表XmlNodeList.
        /// </summary>
        /// <param name="xmlFileName">XML文档完全文件名(包含物理路径)</param>
        /// <param name="xpath">要匹配的XPath表达式(例如:"//节点名//子节点名")</param>
        /// <returns>返回XmlNodeList</returns>
        public static XmlNodeList GetXmlNodeListByXpath(string xmlFileName, string xpath)
        {
            XmlDocument xmlDoc = new XmlDocument();

            try
            {
                xmlDoc.Load(xmlFileName); //加载XML文档
                XmlNodeList xmlNodeList = xmlDoc.SelectNodes(xpath);
                return xmlNodeList;
            }
            catch (Exception ex)
            {
                return null;
                //throw ex; //这里可以定义你自己的异常处理
            }
        }

        /// <summary>
        /// 选择匹配XPath表达式的第一个节点的匹配xmlAttributeName的属性XmlAttribute.
        /// </summary>
        /// <param name="xmlFileName">XML文档完全文件名(包含物理路径)</param>
        /// <param name="xpath">要匹配的XPath表达式(例如:"//节点名//子节点名</param>
        /// <param name="xmlAttributeName">要匹配xmlAttributeName的属性名称</param>
        /// <returns>返回xmlAttributeName</returns>
        public static XmlAttribute GetXmlAttribute(string xmlFileName, string xpath, string xmlAttributeName)
        {
            string content = string.Empty;
            XmlDocument xmlDoc = new XmlDocument();
            XmlAttribute xmlAttribute = null;
            try
            {
                xmlDoc.Load(xmlFileName); //加载XML文档
                XmlNode xmlNode = xmlDoc.SelectSingleNode(xpath);
                if (xmlNode != null)
                {
                    if (xmlNode.Attributes.Count > 0)
                    {
                        xmlAttribute = xmlNode.Attributes[xmlAttributeName];
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex; //这里可以定义你自己的异常处理
            }
            return xmlAttribute;
        }
        #endregion

        #region XML文档创建和节点或属性的添加、修改
        /// <summary>
        /// 创建一个XML文档
        /// </summary>
        /// <param name="xmlFileName">XML文档完全文件名(包含物理路径)</param>
        /// <param name="rootNodeName">XML文档根节点名称(须指定一个根节点名称)</param>
        /// <param name="version">XML文档版本号(必须为:"1.0")</param>
        /// <param name="encoding">XML文档编码方式</param>
        /// <param name="standalone">该值必须是"yes"或"no",如果为null,Save方法不在XML声明上写出独立属性</param>
        /// <returns>成功返回true,失败返回false</returns>
        public static bool CreateXmlDocument(string xmlFileName, string rootNodeName, string version, string encoding, string standalone)
        {
            bool isSuccess = false;
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                XmlDeclaration xmlDeclaration = xmlDoc.CreateXmlDeclaration(version, encoding, standalone);
                XmlNode root = xmlDoc.CreateElement(rootNodeName);
                xmlDoc.AppendChild(xmlDeclaration);
                xmlDoc.AppendChild(root);
                xmlDoc.Save(xmlFileName);
                isSuccess = true;
            }
            catch (Exception ex)
            {
                throw ex; //这里可以定义你自己的异常处理
            }
            return isSuccess;
        }

        /// <summary>
        /// 依据匹配XPath表达式的第一个节点来创建它的子节点(如果此节点已存在则追加一个新的同名节点
        /// </summary>
        /// <param name="xmlFileName">XML文档完全文件名(包含物理路径)</param>
        /// <param name="xpath">要匹配的XPath表达式(例如:"//节点名//子节点名</param>
        /// <param name="xmlNodeName">要匹配xmlNodeName的节点名称</param>
        /// <param name="innerText">节点文本值</param>
        /// <param name="xmlAttributeName">要匹配xmlAttributeName的属性名称</param>
        /// <param name="value">属性值</param>
        /// <returns>成功返回true,失败返回false</returns>
        public static bool CreateXmlNodeByXPath(string xmlFileName, string xpath, string xmlNodeName, string innerText, string xmlAttributeName, string value)
        {
            bool isSuccess = false;
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(xmlFileName); //加载XML文档
                XmlNode xmlNode = xmlDoc.SelectSingleNode(xpath);
                if (xmlNode != null)
                {
                    //存不存在此节点都创建
                    XmlElement subElement = xmlDoc.CreateElement(xmlNodeName);
                    subElement.InnerXml = innerText;

                    //如果属性和值参数都不为空则在此新节点上新增属性
                    if (!string.IsNullOrEmpty(xmlAttributeName) && !string.IsNullOrEmpty(value))
                    {
                        XmlAttribute xmlAttribute = xmlDoc.CreateAttribute(xmlAttributeName);
                        xmlAttribute.Value = value;
                        subElement.Attributes.Append(xmlAttribute);
                    }

                    xmlNode.AppendChild(subElement);
                }
                xmlDoc.Save(xmlFileName); //保存到XML文档
                isSuccess = true;
            }
            catch (Exception ex)
            {
                throw ex; //这里可以定义你自己的异常处理
            }
            return isSuccess;
        }

        /// <summary>
        /// 依据匹配XPath表达式的第一个节点来创建或更新它的子节点(如果节点存在则更新,不存在则创建)
        /// </summary>
        /// <param name="xmlFileName">XML文档完全文件名(包含物理路径)</param>
        /// <param name="xpath">要匹配的XPath表达式(例如:"//节点名//子节点名</param>
        /// <param name="xmlNodeName">要匹配xmlNodeName的节点名称</param>
        /// <param name="innerText">节点文本值</param>
        /// <returns>成功返回true,失败返回false</returns>
        public static bool CreateOrUpdateXmlNodeByXPath(string xmlFileName, string xpath, string xmlNodeName, string innerText)
        {
            bool isSuccess = false;
            bool isExistsNode = false;//标识节点是否存在
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(xmlFileName); //加载XML文档
                XmlNode xmlNode = xmlDoc.SelectSingleNode(xpath);
                if (xmlNode != null)
                {
                    //遍历xpath节点下的所有子节点
                    foreach (XmlNode node in xmlNode.ChildNodes)
                    {
                        if (node.Name.ToLower() == xmlNodeName.ToLower())
                        {
                            //存在此节点则更新
                            node.InnerXml = innerText;
                            isExistsNode = true;
                            break;
                        }
                    }
                    if (!isExistsNode)
                    {
                        //不存在此节点则创建
                        XmlElement subElement = xmlDoc.CreateElement(xmlNodeName);
                        subElement.InnerXml = innerText;
                        xmlNode.AppendChild(subElement);
                    }
                }
                xmlDoc.Save(xmlFileName); //保存到XML文档
                isSuccess = true;
            }
            catch (Exception ex)
            {
                throw ex; //这里可以定义你自己的异常处理
            }
            return isSuccess;
        }

        /// <summary>
        /// 依据匹配XPath表达式的第一个节点来创建或更新它的属性(如果属性存在则更新,不存在则创建)
        /// </summary>
        /// <param name="xmlFileName">XML文档完全文件名(包含物理路径)</param>
        /// <param name="xpath">要匹配的XPath表达式(例如:"//节点名//子节点名</param>
        /// <param name="xmlAttributeName">要匹配xmlAttributeName的属性名称</param>
        /// <param name="value">属性值</param>
        /// <returns>成功返回true,失败返回false</returns>
        public static bool CreateOrUpdateXmlAttributeByXPath(string xmlFileName, string xpath, string xmlAttributeName, string value)
        {
            bool isSuccess = false;
            bool isExistsAttribute = false;//标识属性是否存在
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(xmlFileName); //加载XML文档
                XmlNode xmlNode = xmlDoc.SelectSingleNode(xpath);
                if (xmlNode != null)
                {
                    //遍历xpath节点中的所有属性
                    foreach (XmlAttribute attribute in xmlNode.Attributes)
                    {
                        if (attribute.Name.ToLower() == xmlAttributeName.ToLower())
                        {
                            //节点中存在此属性则更新
                            attribute.Value = value;
                            isExistsAttribute = true;
                            break;
                        }
                    }
                    if (!isExistsAttribute)
                    {
                        //节点中不存在此属性则创建
                        XmlAttribute xmlAttribute = xmlDoc.CreateAttribute(xmlAttributeName);
                        xmlAttribute.Value = value;
                        xmlNode.Attributes.Append(xmlAttribute);
                    }
                }
                xmlDoc.Save(xmlFileName); //保存到XML文档
                isSuccess = true;
            }
            catch (Exception ex)
            {
                throw ex; //这里可以定义你自己的异常处理
            }
            return isSuccess;
        }
        #endregion

        #region XML文档节点或属性的删除
        /// <summary>
        /// 删除匹配XPath表达式的第一个节点(节点中的子元素同时会被删除)
        /// </summary>
        /// <param name="xmlFileName">XML文档完全文件名(包含物理路径)</param>
        /// <param name="xpath">要匹配的XPath表达式(例如:"//节点名//子节点名</param>
        /// <returns>成功返回true,失败返回false</returns>
        public static bool DeleteXmlNodeByXPath(string xmlFileName, string xpath)
        {
            bool isSuccess = false;
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(xmlFileName); //加载XML文档
                XmlNode xmlNode = xmlDoc.SelectSingleNode(xpath);
                if (xmlNode != null)
                {
                    //删除节点
                    xmlNode.ParentNode.RemoveChild(xmlNode);
                }
                xmlDoc.Save(xmlFileName); //保存到XML文档
                isSuccess = true;
            }
            catch (Exception ex)
            {
                throw ex; //这里可以定义你自己的异常处理
            }
            return isSuccess;
        }

        /// <summary>
        /// 删除匹配XPath表达式的第一个节点中的匹配参数xmlAttributeName的属性
        /// </summary>
        /// <param name="xmlFileName">XML文档完全文件名(包含物理路径)</param>
        /// <param name="xpath">要匹配的XPath表达式(例如:"//节点名//子节点名</param>
        /// <param name="xmlAttributeName">要删除的xmlAttributeName的属性名称</param>
        /// <returns>成功返回true,失败返回false</returns>
        public static bool DeleteXmlAttributeByXPath(string xmlFileName, string xpath, string xmlAttributeName)
        {
            bool isSuccess = false;
            bool isExistsAttribute = false;
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(xmlFileName); //加载XML文档
                XmlNode xmlNode = xmlDoc.SelectSingleNode(xpath);
                XmlAttribute xmlAttribute = null;
                if (xmlNode != null)
                {
                    //遍历xpath节点中的所有属性
                    foreach (XmlAttribute attribute in xmlNode.Attributes)
                    {
                        if (attribute.Name.ToLower() == xmlAttributeName.ToLower())
                        {
                            //节点中存在此属性
                            xmlAttribute = attribute;
                            isExistsAttribute = true;
                            break;
                        }
                    }
                    if (isExistsAttribute)
                    {
                        //删除节点中的属性
                        xmlNode.Attributes.Remove(xmlAttribute);
                    }
                }
                xmlDoc.Save(xmlFileName); //保存到XML文档
                isSuccess = true;
            }
            catch (Exception ex)
            {
                throw ex; //这里可以定义你自己的异常处理
            }
            return isSuccess;
        }

        /// <summary>
        /// 删除匹配XPath表达式的第一个节点中的所有属性
        /// </summary>
        /// <param name="xmlFileName">XML文档完全文件名(包含物理路径)</param>
        /// <param name="xpath">要匹配的XPath表达式(例如:"//节点名//子节点名</param>
        /// <returns>成功返回true,失败返回false</returns>
        public static bool DeleteAllXmlAttributeByXPath(string xmlFileName, string xpath)
        {
            bool isSuccess = false;
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(xmlFileName); //加载XML文档
                XmlNode xmlNode = xmlDoc.SelectSingleNode(xpath);
                if (xmlNode != null)
                {
                    //遍历xpath节点中的所有属性
                    xmlNode.Attributes.RemoveAll();
                }
                xmlDoc.Save(xmlFileName); //保存到XML文档
                isSuccess = true;
            }
            catch (Exception ex)
            {
                throw ex; //这里可以定义你自己的异常处理
            }
            return isSuccess;
        }
        #endregion
    }
}
