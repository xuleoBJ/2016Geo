using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using DigRobot;

namespace DigRobot
{
    class cProjectInforManage
    {

        //创建项目信息文件
        //public static bool creatProjectInfor()
        //{

        //    SaveFileDialog projectPath_sfd = new SaveFileDialog();
        //    //设置文件类型 
        //    projectPath_sfd.Title = " 请输入保存数据的位置：";
        //    projectPath_sfd.Filter = "dig文件|*.dig|所有文件|*.*\\";

        //    //设置默认文件类型显示顺序 
        //    projectPath_sfd.FilterIndex = 1;

        //    //保存对话框是否记忆上次打开的目录 
        //    projectPath_sfd.RestoreDirectory = true;

        //    //点了保存按钮进入 
        //    if (projectPath_sfd.ShowDialog() == DialogResult.OK)
        //    {
        //        creatProjectInforXML(projectPath_sfd.FileName.ToString());
        //        MessageBox.Show("Project Created!");
        //        return true;
        //    }
        //    else 
        //    {
        //        return false ;
        //    }
            
        //}

               public static void setPicPath4ProjectXML(string projectXMLpath, string strPicPath)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(projectXMLpath);
            XmlNodeList nodeList = xmlDoc.SelectSingleNode("DigRobotProject").ChildNodes;
            foreach (XmlNode xn in nodeList)
            {
                if (xn.Name == "projectInfor")
                {
                    foreach (XmlElement xe in xn)
                    {
                        if (xe.Name == "picPath")
                        {
                            xe.SetAttribute("filePath", strPicPath);
                        }
                        break;
                    }

                    break;

                }

            }
            xmlDoc.Save(projectXMLpath);//保存。

        }

        public static string getPicPathFromProjectXML(string projectXMLpath)
        {
            string picStrPath = "";
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(projectXMLpath);
            XmlNodeList nodeList = xmlDoc.SelectSingleNode("DigRobotProject").ChildNodes;
            foreach (XmlNode xn in nodeList)
            {
                if (xn.Name == "projectInfor")
                {
                    foreach (XmlElement xe in xn)
                    {
                        if (xe.Name == "picPath")
                        {
                            picStrPath = xe.GetAttribute("filePath");
                        }
                        break;
                    }
                    break;
                }

            }
            return picStrPath;
        }

         public static void updateProjectXML(string projectXMLpath, string strPicPath)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(projectXMLpath);
            XmlNodeList nodeList = xmlDoc.SelectSingleNode("DigRobotProject").ChildNodes;//获取bookstore节点的所有子节点
            foreach (XmlNode xn in nodeList)//遍历所有名字为bookstore的子节点
            {
                if (xn.Name == "projectInfor")
                {
                    foreach (XmlElement xe in xn)
                    {
                        if (xe.Name == "picPath")
                        {
                            xe.SetAttribute("filePath", strPicPath);
                        }
                    }
                    //MessageBox.Show("found");
                    break;

                }

            }
            xmlDoc.Save(projectXMLpath);//保存。

        }

    }
}
