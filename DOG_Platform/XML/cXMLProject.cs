using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml;
using System.Windows.Forms;

namespace DOGPlatform.XML
{
    class cfilePathProject : cXmlBase
    {
       public static string projectAuthor = "Project/ProjectInfor/Author";
       public static string projectComment = "Project/ProjectInfor/comment";
       public static string projectArea = "Project/ProjectInfor/ProjectArea";
       public static string projectBlock = "Project/ProjectInfor/ProjectBlock";
        public static void creatProjectInforXML(string xmlPathProject)
        {
            try
            {
                //定义一个XDocument结构
                XDocument XDoc = new XDocument(
                new XElement("Project",
                new XElement("ProjectInfor",
                new XElement("Author", ""),
                new XElement("Country", ""),
                new XElement("Area", ""),
                new XElement("Block", ""),
                new XElement("CreatedTime", DateTime.Now.ToShortDateString()),
                new XElement("comment", "")
                ),
                new XElement("ProjectJH"
                ),
                new XElement("ProjectLogSeriers"
                ),
                   new XElement("ProductYM"
                ),
                new XElement("WorkFlow",
                new XElement("ReadData", "1"),
                new XElement("DataVerify", "1"),
                new XElement("comment", "comment")
                )

                )
                );
                XDoc.Save(xmlPathProject);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public static void setProjectRefPointNode() //更新参考点
        {   
            setNodeInnerText(cProjectManager.filePathProject, "/Project/refY", cProjectData.dfMapYrealRefer.ToString());
            setNodeInnerText(cProjectManager.filePathProject, "/Project/refX", cProjectData.dfMapXrealRefer.ToString());
            setNodeInnerText(cProjectManager.filePathProject, "/Project/scale", cProjectData.dfMapScale.ToString("0.000"));
        }
        public static void getProjectRefPointNode() //更新参考点
        {
            double.TryParse(getNodeInnerText(cProjectManager.filePathProject, "/Project/refY"), out  cProjectData.dfMapYrealRefer);
            double.TryParse(getNodeInnerText(cProjectManager.filePathProject, "/Project/refX"), out  cProjectData.dfMapXrealRefer);
            double.TryParse(getNodeInnerText(cProjectManager.filePathProject, "/Project/scale"), out  cProjectData.dfMapScale); 
        }
        public static void setProjectJHNode() 
        {
            string sPath ="/Project/ProjectJH";
            string _data = string.Join(" ", cProjectData.ltStrProjectJH);
            setNodeInnerText(cProjectManager.filePathProject, sPath, _data);
        }
        public static void getProjectJHFromNode()
        {
            string sPath = "/Project/ProjectJH";
            cProjectData.ltStrProjectJH = splitNodeInnerText(cProjectManager.filePathProject, sPath);
            //增加代码，没有井资料文件夹，就把工程井号删除
        }

        public static void setProjectLayerSeriersNode(string sNameFCFA)
        {
            string sTagName = "LayerSeriers";
            string sData = string.Join(" ", cProjectData.ltStrProjectXCM);
            string sParentPath = "/Project";
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(cProjectManager.filePathProject);

            XmlElement newNode = xmlDoc.CreateElement(sTagName);
            newNode.InnerText = sData;
            newNode.SetAttribute("id", sNameFCFA);
            XmlNode fatherNode = xmlDoc.SelectSingleNode(sParentPath);
            if (fatherNode != null)
            {
                foreach (XmlNode _node in fatherNode.SelectNodes(sTagName))
                    fatherNode.RemoveChild(_node);
                fatherNode.AppendChild(newNode);
            }
            xmlDoc.Save(cProjectManager.filePathProject); 
        }

        public static void setProjectNode(string sTagName, string sData) 
        {
            string sParentPath = "/Project";
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(cProjectManager.filePathProject);

            XmlElement newNode = xmlDoc.CreateElement(sTagName);
            newNode.InnerText = sData;
            XmlNode fatherNode = xmlDoc.SelectSingleNode(sParentPath);
            if (fatherNode != null)
            {
                foreach (XmlNode _node in fatherNode.SelectNodes(sTagName))
                    fatherNode.RemoveChild(_node);
                fatherNode.AppendChild(newNode);
            }
            xmlDoc.Save(cProjectManager.filePathProject); 
        
        }

        public static void getProjectLayerSeriersFromNode()
        {
            string sPath = "/Project/LayerSeriers";
            cProjectData.ltStrProjectXCM = splitNodeInnerText(cProjectManager.filePathProject, sPath);
        }

        public static void setProjectLogSeriersNode()
        {
             string sPath="/Project/ProjectLogSeriers";
              string _data = string.Join(" ", cProjectData.ltStrProjectGlobeLog);
              setNodeInnerText(cProjectManager.filePathProject, sPath, _data);
        }
        public static void getProjectLogSeriersFromNode()
        {
            string sPath = "/Project/ProjectLogSeriers";
            cProjectData.ltStrProjectGlobeLog = splitNodeInnerText(cProjectManager.filePathProject, sPath);
        }
        public static void setProjectUnitNode()
        {
            string sPath = "/Project/Unit";
            setNodeInnerText(cProjectManager.filePathProject, sPath, cProjectData.projectUnit);
        }

        public static void getProjectUnitNode()
        {
            cProjectData.projectUnit = typeUnit.Metric.ToString(); 
            string sPath = "/Project/Unit";
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(cProjectManager.filePathProject);
            XmlNode currentNode = xmlDoc.SelectSingleNode(sPath);
            if (currentNode != null && currentNode.InnerText!=string.Empty) cProjectData.projectUnit = currentNode.InnerText;
        }

        public static void setProjectYMNode()
        {
              string sPath = "/Project/ProductYM";
              string _data = string.Join(" ", cProjectData.ltStrProjectYM); 
              setNodeInnerText(cProjectManager.filePathProject, sPath, _data);
        }

        public static void getProjectYMFromNode()
        {
            string sPath = "/Project/ProductYM";
            cProjectData.ltStrProjectYM = splitNodeInnerText(cProjectManager.filePathProject, sPath);
        }

        
        static string sPathLayerColor = "/Project/LayerColor";
        public static void  setProjectLayerColor(List<string> ltLayerColor)
        {
            string _data = string.Join(" ", ltLayerColor);
            setNodeInnerText(cProjectManager.filePathProject, sPathLayerColor, _data);
        }


        public static List<string> getProjectLayerColor() 
        {
            List<string> ltLayerColor = new List<string>();
            ltLayerColor = splitNodeInnerText(cProjectManager.filePathProject, sPathLayerColor);
            if (ltLayerColor.Count==0 || ltLayerColor.Count < cProjectData.ltStrProjectXCM.Count) 
            {
                ltLayerColor = new List<string>() { "#FFFF66", "#FF99FF", "#bfff00", "#40E0D0", "#F5DEB3", "#FF8C00", "#FFFACD", "#FFE4B5", "#FFDAB9", "#FF83FA", "#FF8C00", "#FF6EB4", "#FF7F50", "#F7F7F7", "#F5DEB3", "#F0FFF0", "#EEEEE0", "#EEE685", "#EEB422", "#F2F2F2", "#FFA07A", "#7CFC00", "#ADFF2F", "#AFEEEE", "#87CEEB", "#FFF68F", "#FFEFD5", "#FFE4E1", "#FFDEAD", "#FFC1C1", "#FFD700", "#FFBBFF", "#FFAEB9", "#FF83FA", "#FFE1FF", "#FCFCFC", "#FAFAD2", "#F7F7F7", "#F5DEB3", "#F0FFF0", "#EEEEE0", "#EEE685", "#EEB422", "#F2F2F2", "#E0FFFF", "#FFFF66", "#FF99FF", "#FFE4C4", "#FFEBCD", "#F5DEB3", "#FF8C00", "#FFFACD", "#FFE4B5", "#FFDAB9", "#FF83FA", "#FF8C00", "#FF6EB4", "#FF7F50", "#F7F7F7", "#F5DEB3", "#F0FFF0", "#EEEEE0", "#EEE685", "#EEB422", "#F2F2F2", "#FFA07A", "#7CFC00", "#ADFF2F", "#AFEEEE", "#87CEEB", "#FFF68F", "#FFEFD5", "#FFE4E1", "#FFDEAD", "#FFC1C1", "#FFD700", "#FFBBFF", "#FFAEB9", "#FF83FA", "#FFE1FF", "#FCFCFC", "#FAFAD2", "#F7F7F7", "#F5DEB3", "#F0FFF0", "#EEEEE0", "#EEE685", "#EEB422", "#F2F2F2", "#E0FFFF", "#FFFF66", "#FF99FF", "#FFE4C4", "#FFEBCD", "#F5DEB3", "#FF8C00", "#FFFACD", "#FFE4B5", "#FFDAB9", "#FF83FA", "#FF8C00", "#FF6EB4", "#FF7F50", "#F7F7F7", "#F5DEB3", "#F0FFF0", "#EEEEE0", "#EEE685", "#EEB422", "#F2F2F2", "#FFA07A", "#7CFC00", "#ADFF2F", "#AFEEEE", "#87CEEB", "#FFF68F", "#FFEFD5", "#FFE4E1", "#FFDEAD", "#FFC1C1", "#FFD700", "#FFBBFF", "#FFAEB9", "#FF83FA", "#FFE1FF", "#FCFCFC", "#FAFAD2", "#F7F7F7", "#F5DEB3", "#F0FFF0", "#EEEEE0", "#EEE685", "#EEB422", "#F2F2F2", "#E0FFFF" };
                for (int i = ltLayerColor.Count-1; i < cProjectData.ltStrProjectXCM.Count; i++)
                {
                    int r = 255 - (i % 5) * 50;
                    int g = (i % 5) * 50;
                    int b = (i % 20) * 12;
                    string hex = "#"+r.ToString("X2") + g.ToString("X2") + b.ToString("X2");
                    ltLayerColor.Add(hex);
                }
            }
            setProjectLayerColor(ltLayerColor.GetRange(0, cProjectData.ltStrProjectXCM.Count));
            return ltLayerColor;

        }
    }
}
