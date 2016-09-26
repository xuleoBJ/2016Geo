using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using DOGPlatform.XML;
using DOGPlatform.SVG;
using System.Runtime.InteropServices;
using System.Security.Permissions;


namespace DOGPlatform
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [System.Runtime.InteropServices.ComVisibleAttribute(true)] 
    public partial class FormSectionGroup : Form
    {
        //定义绘图数据的临时目录
        //定义联井剖面井号存储List
        public List<string> ltStrSelectedJH = new List<string>();
        //定义存储绘图剖面井数据结构
        List<ItemWellSection> listWellsSection = new List<ItemWellSection>();

        //tempXML存储路径
        static string mapID = DateTime.Now.ToString("MMddHHmmss");
        static string dirSectionData = Path.Combine(cProjectManager.dirPathUsedProjectData, mapID);
        string filePathSectionCss = Path.Combine(cProjectManager.dirPathUsedProjectData, mapID + cProjectManager.fileExtensionSectionFence);
       
        //记录上次页面位置，便于下次定位
        Point PscrollOffset = new Point(0, 0);
        string filePathSVG = "";

        string sJH = "";
        string sIDcurrentTrack = "";
        string sIDcurrentItem = "";
        string filePathOper = "";

        double fMapscale = (float)cProjectData.dfMapScale;

        public FormSectionGroup()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            InitFormWellsGroupControl();
        }
        public FormSectionGroup(string inputFilepath)
            : this()
        {
            openExistSectionFlow(inputFilepath);
        } 
        private void InitFormWellsGroupControl()
        {
            this.webBrowserSVG.ContextMenuStrip = cmsWebSVG;
            webBrowserSVG.ObjectForScripting = this;
        }

        void updateTVandList()
        {
            tvSectionEdit.Nodes.Clear();
            listWellsSection.Clear();
            //解析sectioncss文件，增加节点
            foreach (XmlElement elWell in cXmlDocSectionGeo.getWellNodes(filePathSectionCss))
            {
                ItemWellSection item = new ItemWellSection(elWell["JH"].InnerText);
                item.fShowedDepthTop = float.Parse(elWell["fShowTop"].InnerText);
                item.fShowedDepthBase = float.Parse(elWell["fShowBot"].InnerText);
                item.fXview = float.Parse(elWell["Xview"].InnerText);
                item.fYview = float.Parse(elWell["Yview"].InnerText);
                listWellsSection.Add(item);

                string filePath = Path.Combine(dirSectionData, item.sJH + ".xml");
                TreeNode tnWell = new TreeNode(item.sJH);
                tnWell.Tag = item.sJH;
                tnWell.Text = item.sJH;
                tnWell.Name = item.sJH;
                TreeViewSectionEditView.setupWellNode(tnWell, filePath);
                tvSectionEdit.Nodes.Add(tnWell);
                tnWell.Expand();
            }

        }
        
     
        private void btnScale_Click(object sender, EventArgs e)
        {
            fMapscale = fMapscale * 1.5F;
            MessageBox.Show("当前比例尺:" + fMapscale.ToString());
        }

        private void FormMapFence_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void btnBig_Click(object sender, EventArgs e)
        {
            fMapscale = fMapscale * 1.2F;
        }

        private void tsmiNew_Click(object sender, EventArgs e)
        {
            createNewFile();
        }
        void createNewFile()
        {
            FormSectionAddGroup formNew = new FormSectionAddGroup(filePathSectionCss, dirSectionData);
            var result = formNew.ShowDialog();
            if (result == DialogResult.OK)
            {
                updateTVandList();
                updateSVGmap();
            }
        }
        void updateSVGmap()
        {
            PscrollOffset = cSectionUIoperate.getOffSet(this.webBrowserSVG);
            if (listWellsSection.Count > 0)
            {
                filePathSVG = makeSectionFence.generateFence( dirSectionData, this.filePathSectionCss, "testFence.svg");
                this.webBrowserSVG.Navigate(new Uri(filePathSVG));
            }
        }
        private void webBrowserSVG_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            // 定位上次页面位置
            if (webBrowserSVG.Url == e.Url)
            {
                //记录元素的位置，实现刷新页面自动滚动
                webBrowserSVG.Document.Window.ScrollTo(PscrollOffset);
            }
        }

        private void tsBtnNewProject_Click(object sender, EventArgs e)
        {
            createNewFile(); 
        }

        private void tsmiOpen_Click(object sender, EventArgs e)
        {
            openExist();
        }
        void openExist()
        {
            OpenFileDialog ofdProjectPath = new OpenFileDialog();

            ofdProjectPath.Title = " 打开文件：";
            ofdProjectPath.Filter = string.Format("{0}文件|*{0}", cProjectManager.fileExtensionSectionFence);
            //设置默认文件类型显示顺序 
            ofdProjectPath.FilterIndex = 1;
            //保存对话框是否记忆上次打开的目录 
            ofdProjectPath.RestoreDirectory = true;

            if (ofdProjectPath.ShowDialog() == DialogResult.OK)
            {
                string fileOpen = ofdProjectPath.FileName;
                openExistSectionFlow(fileOpen);
            }
        }
        void openExistSectionFlow(string pathOpenExsitFile)
        {
            mapID = Path.GetFileNameWithoutExtension(pathOpenExsitFile);
            filePathSectionCss = Path.Combine(cProjectManager.dirPathUsedProjectData, mapID + cProjectManager.fileExtensionSectionFence);
            dirSectionData = Path.Combine(cProjectManager.dirPathUsedProjectData, mapID);
            updateTVandList();
            updateSVGmap();
        }

        private void tsBtnOpenProject_Click(object sender, EventArgs e)
        {
            openExist();
        }

        private void tsBtnZoonIn_Click(object sender, EventArgs e)
        {
           scaleMap(0.1F); 
        }

        private void tsBtnZoomOut_Click(object sender, EventArgs e)
        {
            scaleMap(-0.1F); 
        }

        void scaleMap(float fCoeffect) 
        {
            fMapscale = float.Parse(cXmlBase.getNodeInnerText(filePathSectionCss, cXEGeopage.fullPathSacleMap));
            fMapscale = fMapscale + fCoeffect;
            cXmlBase.setNodeInnerText(filePathSectionCss, cXEGeopage.fullPathSacleMap, fMapscale.ToString("0.0"));
            for (int i = 0; i < listWellsSection.Count; i++)
            {
                ItemWellSection itemWell = listWellsSection[i];
                Point currentPositon = cCordinationTransform.getPointViewByJH(itemWell.sJH);
                itemWell.fXview =(float) fMapscale * currentPositon.X;
                itemWell.fYview =(float) fMapscale * currentPositon.Y;
                cXmlDocSectionGeo.setSelectedNodeChildNodeValue(filePathSectionCss, itemWell.sJH, "Xview", itemWell.fXview.ToString());
                cXmlDocSectionGeo.setSelectedNodeChildNodeValue(filePathSectionCss, itemWell.sJH, "Yview", itemWell.fYview.ToString());
            }
        }

        private void tsBtnReflush_Click(object sender, EventArgs e)
        {
            updateTVandList();
            updateSVGmap(); 
        }

        private void tsmiTrackDataImport_Click(object sender, EventArgs e)
        {
            TreeNode currentNode = this.tvSectionEdit.SelectedNode;
            setUpIDByTN(currentNode);
            cSectionUIoperate.updateTrackData(filePathOper, this.sIDcurrentTrack); 
        }

        void setUpIDByTN(TreeNode currentNode)
        {
            if (currentNode != null)
            {
                if (currentNode.Level == 0)
                {
                    sJH = currentNode.Name;
                    this.sIDcurrentTrack = "";
                    this.sIDcurrentItem = "";
                    filePathOper = dirSectionData + "//" + sJH + ".xml";
                }
                else if (currentNode.Level == 1)
                {
                    this.sIDcurrentTrack = currentNode.Name;
                    sJH = currentNode.Parent.Name;
                    this.sIDcurrentItem = "";
                    filePathOper = dirSectionData + "//" + sJH + ".xml";
                }
                else if (currentNode.Level == 2)
                {
                    this.sIDcurrentTrack = currentNode.Parent.Name;
                    this.sIDcurrentItem = currentNode.Name;
                    sJH = currentNode.Parent.Parent.Name;
                    filePathOper = dirSectionData + "//" + sJH + ".xml";
                }
                this.tsslblJH.Text = sJH;
                this.tsslblTrack.Text = sIDcurrentTrack;
                this.tsslblDataItem.Text = sIDcurrentItem;
            }
        }

        private void tsmiLogData_Click(object sender, EventArgs e)
        {
            TreeNode currentNode = tvSectionEdit.SelectedNode;
            setUpIDByTN(currentNode);

            if (sIDcurrentItem.StartsWith("idLog"))
            {
                string sJH = cXmlDocSectionWell.getNodeInnerText(this.filePathOper, cXmlDocSectionWell.fullPathJH);
                string sLogName = sIDcurrentItem.Remove(sIDcurrentItem.Length - 12).Remove(0, 5);
                FormSectionDataLog formInputDataTableSingleWell = new
                         FormSectionDataLog(sJH, sLogName, TypeTrack.曲线道.ToString(), filePathOper, sIDcurrentItem);
                formInputDataTableSingleWell.ShowDialog(); 
               
            } 
        }

        private void tsmiTrackDel_Click(object sender, EventArgs e)
        {
            TreeNode currentNode = this.tvSectionEdit.SelectedNode;
            setUpIDByTN(currentNode);
            cSectionUIoperate.deleteItemByID(currentNode, filePathOper, sIDcurrentTrack);
        }

        private void tsmiTrackUp_Click(object sender, EventArgs e)
        {
            TreeNode currentNode = this.tvSectionEdit.SelectedNode;
            setUpIDByTN(currentNode);
            cSectionUIoperate.selectTrackUp(this.tvSectionEdit, currentNode, filePathOper, sIDcurrentTrack);
        }

        private void tsmiTrackDown_Click(object sender, EventArgs e)
        {
            TreeNode currentNode = this.tvSectionEdit.SelectedNode;
            setUpIDByTN(currentNode);
            cSectionUIoperate.selectTrackDown(this.tvSectionEdit, currentNode, filePathOper, this.sIDcurrentTrack);
        }

        private void tsmiShowState_Click(object sender, EventArgs e)
        {
            TreeNode currentNode = tvSectionEdit.SelectedNode;
            if (currentNode != null)
            {
                setUpIDByTN(currentNode);
                FormSettingSectionGeoShowDepth newset = new FormSettingSectionGeoShowDepth(this.filePathSectionCss,this.sJH);
                newset.ShowDialog();
            }
        }

        private void tsmiTrackSetting_Click(object sender, EventArgs e)
        {
            TreeNode currentNode = this.tvSectionEdit.SelectedNode;
            if (currentNode.Level == 1)
            {
                string sIDtrack = currentNode.Name;
                string sJH = currentNode.Parent.Name;
                string filePathOper = dirSectionData + "//" + sJH + ".xml";
                cSectionUIoperate.setNodeProperty(currentNode, filePathOper);
            }
            if (currentNode.Level == 0)
            {
                //string sIDtrack = currentNode.Name;
                //string sJH = currentNode.Parent.Name;
                //string filePathOper = dirSectionData + "//" + sJH + ".xml";
                //cSectionUIoperate.setTrackProperty(currentNode, filePathOper, sIDtrack);
            }
        }

        private void tsmiInsertTrackLog_Click(object sender, EventArgs e)
        {
            TreeNode currentNode = tvSectionEdit.SelectedNode;
            if (currentNode != null)
            {
                setUpIDByTN(currentNode);
                addTrackCss(TypeTrack.曲线道);
            }
        }
        void addTrackCss(TypeTrack eTypeTrack)
        {
            int iTrackWidth = 50;
            if (eTypeTrack == TypeTrack.曲线道) iTrackWidth = 100;
            cXmlDocSectionWell.addTrackCss(filePathOper, eTypeTrack, iTrackWidth);
            updateTVandList();
        }
        private void tsmiInsertTrackCJSJ_Click(object sender, EventArgs e)
        {
            TreeNode currentNode = tvSectionEdit.SelectedNode;
            if (currentNode != null)
            {
                setUpIDByTN(currentNode);
                addTrackCss(TypeTrack.测井解释);
            }
        }

        private void tsmiInsertTrackText_Click(object sender, EventArgs e)
        {
            TreeNode currentNode = tvSectionEdit.SelectedNode;
            if (currentNode != null)
            {
                setUpIDByTN(currentNode);
                addTrackCss(TypeTrack.文本道);
            }
        }

        private void tvSectionEdit_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode selectNode = this.tvSectionEdit.SelectedNode;
            setUpIDByTN(selectNode);
            if (selectNode != null)
            {
                if (selectNode.Level > 0) cSectionUIoperate.setNodeProperty(selectNode, filePathOper);
            } //end if selectNode
        }

        private void tsmiSaveTemplate_Click(object sender, EventArgs e)
        {

        }

        private void tsmiSave_Click(object sender, EventArgs e)
        {
            cProjectManager.save2ProjectDelEnvent(filePathSVG);
        }

        private void tsmiAddLog_Click(object sender, EventArgs e)
        {
            TreeNode tn = tvSectionEdit.SelectedNode;
            string sJH = tn.Parent.Text;
            if (tn.Tag.ToString() == TypeTrack.曲线道.ToString())
            {
                FormSectionAddWellLog formAddLog = new FormSectionAddWellLog(sJH);
                if (formAddLog.ShowDialog() == DialogResult.OK)
                {
                    ItemLogHeadInfor logHead = formAddLog.logHeadRet;
                    //此处写入配置文件xml,tn.name 是 id
                    cXmlDocSectionWell.addLog(this.filePathOper, tn.Name, logHead);
                }
            }
        }

        private void tsbTreeView_Click(object sender, EventArgs e)
        {
            this.splitContainerSection.Panel1Collapsed = !this.splitContainerSection.Panel1Collapsed;
            if (this.splitContainerSection.Panel1Collapsed == false) updateTVandList();
        }

        private void tsbPageSet_Click(object sender, EventArgs e)
        {
            FormSettingPageFence newSetPage = new FormSettingPageFence(filePathSectionCss);
            if (newSetPage.ShowDialog() == DialogResult.OK) updateSVGmap();
        }

        private void tsmiIntervalMode_Click(object sender, EventArgs e)
        {
            FormSettingModeInterval newSetPage = new FormSettingModeInterval(this.filePathSectionCss, dirSectionData);
            if (newSetPage.ShowDialog() == DialogResult.OK) updateSVGmap();
        }

         
    }
} 
