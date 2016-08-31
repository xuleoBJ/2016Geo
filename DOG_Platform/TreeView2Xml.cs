using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using DOGPlatform.XML;

namespace DOGPlatform
{
    class TreeView2Xml
    {
        //记录哪些节点被选中。
        public static void treeview2xml(TreeView tv,string filePathxml)
        {
            XmlDocument xDoc = new XmlDocument();
            foreach (TreeNode tn in tv.Nodes) 
            {
                if (tn.Tag.ToString() == TypeProjectNode.sectionGeoDir.ToString())  //GeoDirNode
                {
                    XmlElement xeNode = xDoc.CreateElement(tn.Name);
                    foreach (TreeNode tSub in tn.Nodes)
                    {
                        XmlElement xeSubNode = xDoc.CreateElement(tn.Name);
                        xeSubNode.SetAttribute("tag", tSub.Tag.ToString());
                        xeSubNode.SetAttribute("text", tSub.Text.ToString());
                        int iChecked = tSub.Checked == true ? 1 : 0;
                        xeSubNode.SetAttribute("iChecked", iChecked.ToString());
                        string filepathGeo = Path.Combine(cProjectManager.dirPathUsedProjectData, tSub.Text + cProjectManager.fileExtensionSectionGeo);
                        List<string> ltJHConnect = cXmlDocSectionGeo.getJHList(filepathGeo);
                        xeSubNode.InnerText = string.Join(cProjectData.splitMark, ltJHConnect);
                        xeNode.AppendChild(xeSubNode);
                    }
                    xDoc.AppendChild(xeNode);
                }
            }  
            xDoc.Save(filePathxml);
        }


        public static void treenode2xml(TreeNode tn, string filePathxml)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement root = doc.CreateElement("root");
            XmlElement xeNode = doc.CreateElement(tn.Name);
            foreach (TreeNode tSub in tn.Nodes)
            {
                XmlElement xeSubNode = doc.CreateElement(tn.Name);
                xeSubNode.SetAttribute("tag", tSub.Tag.ToString());
                xeSubNode.SetAttribute("text", tSub.Text.ToString());
                int iChecked = tSub.Checked == true ? 1 : 0;
                xeSubNode.SetAttribute("iChecked", iChecked.ToString());
                string filepathGeo = Path.Combine(cProjectManager.dirPathUsedProjectData, tSub.Text + cProjectManager.fileExtensionSectionGeo);
                List<string> ltJHConnect = cXmlDocSectionGeo.getJHList(filepathGeo);
                xeSubNode.InnerText = string.Join( cProjectData.splitMark ,ltJHConnect);
                
                xeNode.AppendChild(xeSubNode);
            }
            root.AppendChild(xeNode);
            doc.AppendChild(root);
            doc.Save(filePathxml);
        }
       
    }
 
}
