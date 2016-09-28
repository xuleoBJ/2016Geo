using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using DOGPlatform.XML;
using System.Drawing;

namespace DOGPlatform
{
    class TreeViewProjectData
    {
        public static string xmlTVconfig=Path.Combine(cProjectManager.dirPathUserData,  "tvProjectConfig.xml");
        //装载井文件子菜单
        public static void setupTNwell2TV(TreeView _tv)
        {
            TreeNode tnWells = new TreeNode();
            tnWells.Name = TypeProjectNode.wells.ToString();
            tnWells.Text = "井";
            tnWells.Tag = TypeProjectNode.wells;
            //加载全局测井曲线结点
            setupTNGlobeWellLog(_tv,tnWells);
            foreach (string sJH in cProjectData.ltStrProjectJH)
            {
                TreeNode tnJH = new TreeNode(sJH,3,3);
                tnJH.Name = sJH;
                tnJH.Tag = TypeProjectNode.well;
                //加载单井结点
                setupTNwellChild(tnJH); 
                tnWells.Nodes.Add(tnJH);
            }
            _tv.Nodes.Add(tnWells);
        }
         
        public static void setupTNCalText2TV(TreeView _tv)
        {
          TreeNode tvTextNode = new TreeNode();

            tvTextNode.Name = TypeProjectNode.calResultText.ToString();
            tvTextNode.Tag = TypeProjectNode.calResultText;
            tvTextNode.Text = "计算结果";
            string[] fileItems = Directory.GetFiles(cProjectManager.dirPathUsedProjectData, "*.txt");
            if (fileItems.Count() > 0)
            {
                foreach (string _item in fileItems)
                {
                    string _filename = Path.GetFileNameWithoutExtension(_item);
                    TreeNode tn = new TreeNode(_filename, 6, 6);
                    tn.Name = TypeProjectNode.calResultText.ToString();
                    tn.Tag = TypeProjectNode.calResultText;
                    tvTextNode.Nodes.Add(tn);
                }
            }
            _tv.Nodes.Add(tvTextNode);
          }

        private static TreeNode CreateSVGDirectoryNode(DirectoryInfo directoryInfo)
          {
              TreeNode directoryNode = new TreeNode();
              directoryNode.Name = directoryInfo.Name;
              directoryNode.Tag = TypeProjectNode.svgMapDir;
              directoryNode.Text = directoryInfo.Name;
              foreach (var directory in directoryInfo.GetDirectories())
                  directoryNode.Nodes.Add(CreateSVGDirectoryNode(directory));
              foreach (var file in directoryInfo.GetFiles())
              {
                  if (file.Name.EndsWith(".svg"))
                  {
                      string tnText = file.Name.Substring(0,file.Name.Length-4);
                      TreeNode tnSub = new TreeNode(tnText, 10, 10);
                      tnSub.Name = tnText;
                      tnSub.Tag = TypeProjectNode.svgMap;
                      directoryNode.Nodes.Add(tnSub);
                  }
              }
              return directoryNode;
          }

        public static TreeNode setupTNsvgMap2TV(TreeView _tv)
          {
              var directoryInfo = new DirectoryInfo(cProjectManager.dirPathMap);
              TreeNode tnSVG = CreateSVGDirectoryNode(directoryInfo);
              tnSVG.Text = "成果图";
              _tv.Nodes.Add(tnSVG);
              return tnSVG;
          } 

        public static TreeNode setupTNsvgMapItem(TreeNode tn, string tnText)
         {
             TreeNode tnSub = new TreeNode(tnText, 10, 10);
             tnSub.Name = tnText;
             tnSub.Tag = TypeProjectNode.svgMap;
             tn.Nodes.Insert(0,tnSub);
             return tnSub; 
         }

        public static TreeNode setupTNSectionFenceItem(TreeNode tn, string tnText)
        {
            TreeNode tnSub = new TreeNode(tnText, 9, 9);
            tnSub.Name = tnText;
            tnSub.Tag = TypeProjectNode.sectionFence;
            tn.Nodes.Insert(0, tnSub);
            return tnSub;
        }
        public static TreeNode setupTNSectionGeoItem(TreeNode tn, string tnText)
        {
            TreeNode tnSub = new TreeNode(tnText, 9, 9);
            tnSub.Name = tnText;
            tnSub.Tag = TypeProjectNode.sectionGeo;
            tn.Nodes.Insert(0, tnSub);
            return tnSub; 
        }
        public static TreeNode setupTNgraphWellSectionItem(TreeNode tn, string tnText)
         {
             TreeNode tnSub = new TreeNode(tnText, 2, 2);
             tnSub.Name = tnText;
             tnSub.Tag = TypeProjectNode.sectionWell;
             tn.Nodes.Insert(0,tnSub);
             return tnSub;
         }
       
        public static void setupTNsectionWell2TV(TreeView _tv)
        {
            TreeNode tnSectionNode = new TreeNode();

            tnSectionNode.Name = TypeProjectNode.sectionWellDir.ToString();
            tnSectionNode.Tag = TypeProjectNode.sectionWellDir;
            tnSectionNode.Text = "柱状剖面";
            string[] fileItems = Directory.GetFiles(cProjectManager.dirPathUsedProjectData, "*" + cProjectManager.fileExtensionSectionWell);
            if (fileItems.Count() > 0)
            {
                foreach (string _item in fileItems)
                {
                    string tnText = Path.GetFileNameWithoutExtension(_item);
                    setupTNgraphWellSectionItem(tnSectionNode, tnText);
                }
            }
            _tv.Nodes.Add(tnSectionNode);
        }

        public static void setupTNsectionGeo2TV(TreeView _tv)
        {
            TreeNode tnSectionNode= new TreeNode();

            tnSectionNode.Name = TypeProjectNode.sectionGeoDir.ToString();
            tnSectionNode.Tag = TypeProjectNode.sectionGeoDir;
            tnSectionNode.Text = "联井分析";
            string[] fileItems = Directory.GetFiles(cProjectManager.dirPathUsedProjectData, "*" + cProjectManager.fileExtensionSectionGeo);
            if (fileItems.Count() > 0)
            {
                foreach (string _item in fileItems)
                {
                    string _filename = Path.GetFileNameWithoutExtension(_item);
                    TreeNode tn = new TreeNode(_filename,9,9);
                    tn.Name = _filename;
                    tn.Tag = TypeProjectNode.sectionGeo;
                    List<ItemWellSection> listWellsSection = cXmlDocSectionGeo.makeListWellSection(_item);
                    //解析sectioncss文件，增加节点
                    foreach (ItemWellSection item in listWellsSection)
                    {
                        if (item.sJH != "")
                        {
                            TreeNode tnWell = new TreeNode(item.sJH,12,12);
                            tnWell.Tag = item.sJH;
                            tnWell.Text = item.sJH;
                            tnWell.Name = item.sJH;
                            tn.Nodes.Add(tnWell);
                        }
                    }
                    tnSectionNode.Nodes.Add(tn);
                }
            }
            _tv.Nodes.Add(tnSectionNode);
        }

        public static void setupTNsectionFence2TV(TreeView _tv)
        {
            TreeNode tnSectionNode = new TreeNode();

            tnSectionNode.Name = TypeProjectNode.sectionFenceDir.ToString();
            tnSectionNode.Tag = TypeProjectNode.sectionFenceDir;
            tnSectionNode.Text = "井组25D";
            string[] fileItems = Directory.GetFiles(cProjectManager.dirPathUsedProjectData, "*" + cProjectManager.fileExtensionSectionFence);
            if (fileItems.Count() > 0)
            {
                foreach (string _item in fileItems)
                {
                    string _filename = Path.GetFileNameWithoutExtension(_item);
                    TreeNode tn = new TreeNode(_filename, 9, 9);
                    tn.Name = _filename;
                    tn.Tag = TypeProjectNode.sectionFence;
                    List<ItemWellSection> listWellsSection = cXmlDocSectionGeo.makeListWellSection(_item);
                    //解析sectioncss文件，增加节点
                    foreach (ItemWellSection item in listWellsSection)
                    {
                        if (item.sJH != "")
                        {
                            TreeNode tnWell = new TreeNode(item.sJH, 12, 12);
                            tnWell.Tag = item.sJH;
                            tnWell.Text = item.sJH;
                            tnWell.Name = item.sJH;
                            tn.Nodes.Add(tnWell);
                        }
                    }
                    tnSectionNode.Nodes.Add(tn);
                }
            }
            _tv.Nodes.Add(tnSectionNode);
        }

        public static void updateTNwellLogDir(TreeNode tnLogDir) 
        {
            if (tnLogDir.Tag.ToString() == TypeProjectNode.wellLogDir.ToString())
            {
                tnLogDir.Nodes.Clear();
                string sJH = tnLogDir.Parent.Text;
                string _wellDir = Path.Combine(cProjectManager.dirPathWellDir, sJH);
                string[] wellLogItems = Directory.GetFiles(_wellDir, "*" + cProjectManager.fileExtensionWellLog);
                if (wellLogItems.Count() > 0)
                {
                    foreach (string _item in wellLogItems)
                    {
                        string _log = Path.GetFileNameWithoutExtension(_item);
                        setupTNLogItem(tnLogDir, _log);
                    }
                }
            }
        }

        //装载井菜单下的测井treenote
        public static void setupTNwellChild(TreeNode tnWell) 
        {
            //删除原来的welllogNode
            foreach (TreeNode subNode in tnWell.Nodes)
            {
                if (subNode.Tag.ToString() == TypeProjectNode.wellLogDir.ToString()) subNode.Remove();
            }

            string sJH = tnWell.Text;
            TreeNode tnWellLogDir = new TreeNode("well logs", 0, 1);
            tnWellLogDir.Name = TypeProjectNode.wellLogDir.ToString();
            tnWellLogDir.Tag = TypeProjectNode.wellLogDir;
            tnWell.Nodes.Add(tnWellLogDir);
            updateTNwellLogDir(tnWellLogDir); 
          
            string filePathWellSection = Path.Combine(cProjectManager.dirPathWellDir, sJH, sJH + cProjectManager.fileExtensionSectionWell);
            //加入测井图
            if (File.Exists(filePathWellSection))
            {
                TreeNode tnSectionWell = new TreeNode("单井综合图", 2, 2);
                tnSectionWell.Name = TypeProjectNode.sectionWell.ToString();
                tnSectionWell.Tag = TypeProjectNode.sectionWell;
                tnWell.Nodes.Add(tnSectionWell);
                //读单井综合图，增加图道节点
                setupSectionWellChildNode(tnSectionWell, filePathWellSection, sJH);
            }
        }


        public static void setupSectionWellChildNode(TreeNode tn, string filePathOper, string sJHSelected)
        {
            //read xml and treeview
            foreach (XmlElement el_Track in cXmlDocSectionWell.getTrackNodes(filePathOper))
            {
                trackDataDraw curTrackDraw = new trackDataDraw(el_Track);
                TreeNode tnode = new TreeNode(curTrackDraw.sTrackType,12,12);
                tnode.Text = curTrackDraw.sTrackTitle;
                tnode.Name = curTrackDraw.sTrackID;  //结点name
                tnode.Tag = curTrackDraw.sTrackType;
                tn.Nodes.Add(tnode);
                if (curTrackDraw.iVisible > 0) tnode.Checked = true;
                else tnode.Checked = false;
                if (curTrackDraw.sTrackType == TypeTrack.曲线道.ToString())
                {
                    //继续读取曲线
                    XmlNodeList xnList = el_Track.SelectNodes(".//Log");
                    foreach (XmlElement xnLog in xnList)
                    {
                        string sLogName = xnLog["logName"].InnerText;
                        TreeNode tnLog = new TreeNode(sLogName, 5, 5);
                        tnLog.Name = xnLog.Attributes["id"].Value;
                        tnLog.Text = sLogName ;
                        tnLog.Tag = sLogName ;
                       
                        string sColor = xnLog["curveColor"].InnerText;
                        tnLog.ForeColor = Color.FromName(sColor);
                        tnode.Nodes.Add(tnLog);
                    }
                }
            }

        }

        public static void updateTN_GlobeWellLog(TreeView _tv)
        {
            TreeNode tnGlobeWellLogs = _tv.Nodes[0].Nodes.Cast<TreeNode>().First(r => r.Name == "tnGlobalLogs" || r.Text == "global well logs");
            tnGlobeWellLogs.Nodes.Clear();
            foreach (string item in cProjectData.ltStrProjectGlobeLog)
                tnGlobeWellLogs.Nodes.Add(tnGlobeNode(item));
        }

        static TreeNode tnGlobeNode(string tnText) 
        {
            TreeNode _tn = new TreeNode(tnText, 5, 5);
            _tn.Name = tnText;
            _tn.Tag = TypeProjectNode.globalLog;
            return _tn;
        }
        public static void setupTNGlobeWellLog(TreeView _tv,TreeNode td)
        {
            TreeNode tnGlobeWellLogs = new TreeNode("global well logs");
            tnGlobeWellLogs.Name = TypeProjectNode.globalLogDir.ToString();
            tnGlobeWellLogs.Tag=TypeProjectNode.globalLogDir;
            foreach (string item in cProjectData.ltStrProjectGlobeLog)
                tnGlobeWellLogs.Nodes.Add(tnGlobeNode(item));
            td.Nodes.Add(tnGlobeWellLogs);
        }
        /// <summary>
        /// 从工程xml文件中读取分层信息，加载到工程目录树上。
        /// </summary>
        /// <param name="_tv"></param>
        public static void setupTNLayer2TV(TreeView _tv)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(cProjectManager.filePathProject);
            string sPath = "/Project/LayerSeriers";
            XmlNodeList nodeList = xmlDoc.SelectNodes(sPath);
            foreach(XmlNode currentNode in nodeList )
            {
                List<string> listStr = currentNode.InnerText.Split(new Char[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                string sID = currentNode.Attributes["id"].Value; 
                TreeNode tn = new TreeNode(sID, 4, 4);
                tn.Name = "tnWellTops";
                tn.Tag = TypeProjectNode.wellTopDir.ToString();
                foreach (string _layer in listStr)
                {
                    TreeNode _tnLayer = new TreeNode(_layer,8,8);
                    _tnLayer.Name = _layer;
                    _tnLayer.Tag = TypeProjectNode.wellTop.ToString();
                    tn.Nodes.Add(_tnLayer);
                    setupLayer(_tnLayer);
                }
                _tv.Nodes.Add(tn);
            }
        }

        public static void setupLayer(TreeNode tnLayer)
        {
            string sLayer = tnLayer.Text;
            string filePathLayerMap = Path.Combine(cProjectManager.dirPathLayerDir, sLayer, sLayer +cProjectManager.fileExtensionLayerMap);
            //加入测井图
            if (File.Exists(filePathLayerMap))
            {
                TreeNode tnlayerMap = new TreeNode("小层平面图", 11, 11);
                tnlayerMap.Name = TypeProjectNode.layerMap.ToString();
                tnlayerMap.Tag = TypeProjectNode.layerMap;
                tnLayer.Nodes.Add(tnlayerMap);
            }
        }


        public static TreeNode setupTNLogItem(TreeNode tn, string tnText)
        {
            TreeNode tnSub = new TreeNode(tnText, 5, 5);
            tnSub.Name = tnText;
            tnSub.Tag = TypeProjectNode.logItem;
            tn.Nodes.Insert(0, tnSub);
            return tnSub;
        }

        public static void setupTNWellLog(TreeNode tnWellLogDir, string sJH)
        {
            tnWellLogDir.Nodes.Clear();
            string _wellDir = Path.Combine(cProjectManager.dirPathWellDir, sJH);

            foreach (string _item in Directory.GetFiles(_wellDir, "*" + cProjectManager.fileExtensionWellLog))
            {
                string _log = Path.GetFileNameWithoutExtension(_item);
                setupTNLogItem(tnWellLogDir, _log);
            }

        }
    }
}