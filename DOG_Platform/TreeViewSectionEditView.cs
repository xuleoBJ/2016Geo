using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Drawing;
using DOGPlatform.XML;

namespace DOGPlatform
{
    class TreeViewSectionEditView
    {
        //装载井文件子菜单
        public static void setupTN_page(TreeView tv)
        {
            TreeNode tnPage = new TreeNode("Page");
            tnPage.Tag = TypeSectionTreeNode.Page;
            tv.Nodes.Add(tnPage);
        }

        public static void setupTN_RulerElevation(TreeView tv,string sTrackID)
        {
            TreeNode tnode = new TreeNode();
            tnode.Text = TypeTrack.海拔尺.ToString();
            tnode.Name = sTrackID;
            tnode.Tag = TypeTrack.海拔尺;
            tv.Nodes.Add(tnode);
        }

        public static void setupTN_TrackDepth(TreeView tv, string sTrackID)
        {
            TreeNode tnode = new TreeNode();
            tnode.Text = TypeTrack.深度尺.ToString();
            tnode.Name = sTrackID;
            tnode.Tag = TypeTrack.深度尺;
            tv.Nodes.Add(tnode);
        }

        public static void setupTN_wellLog(TreeView tv,string sLogName,Color logColor)
      {
            foreach (TreeNode wellNote in tv.Nodes)
            {
                if (wellNote.Tag.ToString() == TypeSectionTreeNode.WellName.ToString())
                {
                    TreeNode tnLog = new TreeNode();
                    tnLog.Tag = TypeSectionTreeNode.LogCurve;
                    tnLog.Text = sLogName;
                    tnLog.ForeColor = logColor;
                    wellNote.Nodes.Add(tnLog);
                }
            }
    }

        public static void setupTN_trackJH(TreeView tv,string sJH)
        {
            TreeNode tnWell = new TreeNode();
            tnWell.Text = sJH;
            tnWell.Name = sJH;
            tnWell.Tag = TypeSectionTreeNode.WellName;
            TreeNode tnWellCone = new TreeNode();
            tnWellCone.Text = "井深尺";
            tnWellCone.Tag = TypeSectionTreeNode.WellConeRuler;
            tnWell.Nodes.Add(tnWellCone);
            tv.Nodes.Add(tnWell);
        }

        public static void setupTN_trackLayer(TreeView tv,string sJH)
        {
            foreach (TreeNode wellNote in tv.Nodes)
            {
                if (wellNote.Text==sJH && wellNote.Tag.ToString() == TypeSectionTreeNode.WellName.ToString())
                {
                    TreeNode tnLayer = new TreeNode("地层");
                    tnLayer.Tag = TypeSectionTreeNode.Layer;
                    wellNote.Nodes.Add(tnLayer);
                    break;
                }
            }
        }

        public static void setupTN_trackJSJL(TreeView tv,string sJH)
        {
            foreach (TreeNode wellNote in tv.Nodes)
            {
                if (wellNote.Text==sJH && wellNote.Tag.ToString() == TypeSectionTreeNode.WellName.ToString())
                {
                    TreeNode tnJSJL = new TreeNode("测井解释");
                    tnJSJL.Tag = TypeSectionTreeNode.JSJL;
                    wellNote.Nodes.Add(tnJSJL);
                }
            }
        }

        public static void setupWellNode(TreeNode tn, string filePathOper)
        {
            //read xml and treeview
            string sJHSelected = cXmlBase.getNodeInnerText(filePathOper, cXmlDocSectionWell.fullPathJH);  //井号从新建窗口读入
            foreach (XmlElement el_Track in cXmlDocSectionWell.getTrackNodes(filePathOper))
            {
                trackDataDraw curTrackDraw = new trackDataDraw(el_Track);
                TreeNode tnode = new TreeNode();
                tnode.Text = curTrackDraw.sTrackTitle;
                tnode.Name = curTrackDraw.sTrackID;  //结点name
                tnode.Tag = curTrackDraw.sTrackType;
                tn.Nodes.Add(tnode);
                if (curTrackDraw.iVisible > 0) tnode.Checked = true;
                else tnode.Checked = false;

                if (curTrackDraw.sTrackType == TypeTrack.分层.ToString())
                {
                    //继续读取曲线
                    XmlNodeList xnList = el_Track.SelectNodes(".//dataList/dataItem");
                    foreach (XmlElement xnLayer in xnList)
                    {
                        TreeNode tnLayer = new TreeNode();
                        tnLayer.Name = xnLayer.Attributes["id"].Value;
                        tnLayer.Text = xnLayer["sProperty"].InnerText;
                        tnLayer.Tag = xnLayer["sProperty"].InnerText;
                        tnLayer.Checked = true; 
                        tnode.Nodes.Add(tnLayer);
                    }
                }
                if (curTrackDraw.sTrackType == TypeTrack.文本道.ToString())
                {
                    XmlNodeList xnList = el_Track.SelectNodes(".//dataList/dataItem");
                    foreach (XmlElement xn in xnList)
                    {
                        TreeNode tnText = new TreeNode();
                        tnText.Name = xn.Attributes["id"].Value;
                        tnText.Text = xn["sText"].InnerText;
                        tnText.Tag = xn["sText"].InnerText;
                        tnText.Checked = true; 
                        tnode.Nodes.Add(tnText);
                    }
                }
                if (cProjectManager.ltStrTrackTypeIntervalProperty.IndexOf(curTrackDraw.sTrackType) >= 0)
                {
                    //继续读取曲线
                    XmlNodeList xnJSJL = el_Track.SelectNodes(".//dataList/dataItem");
                    foreach (XmlElement xn in xnJSJL)
                    {
                        TreeNode tnJSJL = new TreeNode();
                        tnJSJL.Name = xn.Attributes["id"].Value;
                        tnJSJL.Text = xn["top"].InnerText + "-" + xn["bot"].InnerText;
                        tnJSJL.Tag = xn["top"].InnerText + "-" + xn["bot"].InnerText;
                        tnJSJL.Checked = true; 
                        tnode.Nodes.Add(tnJSJL);
                    }
                }
                if (curTrackDraw.sTrackType == TypeTrack.曲线道.ToString())
                {
                    //继续读取曲线
                    XmlNodeList xnList = el_Track.SelectNodes(".//Log");
                    foreach (XmlElement xnLog in xnList)
                    {
                        TreeNode tnLog = new TreeNode();
                        tnLog.Name = xnLog.Attributes["id"].Value;
                        tnLog.Text = xnLog["logName"].InnerText;
                        tnLog.Tag = xnLog["logName"].InnerText; ;
                        string sColor = xnLog["curveColor"].InnerText;
                        int iLogVisible = int.Parse(xnLog["visible"].InnerText);
                        tnLog.ForeColor = Color.FromName(sColor);
                        tnode.Nodes.Add(tnLog);
                        if (iLogVisible > 0) tnLog.Checked = true;
                        else tnLog.Checked = false;
                    }
                }
            }

        }
     
    }
}
