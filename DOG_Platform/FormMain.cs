#region << 版 本 注 释 >>
/*
 * ========================================================================
 * Copyright(c) 2014 Xuleo,Riped, All Rights Reserved.
 * ========================================================================
 *  许磊，联系电话13581625021，qq：38643987

 * ========================================================================
*/
#endregion
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using DOGPlatform;
using DOGPlatform.XML;
using System.Xml.Linq;
using System.Diagnostics;
using DigRobot;

using IronPython.Hosting;
using Microsoft.Scripting.Hosting;

namespace DOGPlatform
{
    /// <summary>
    /// 1-采用一套井结构，一套分层方案的设计，如果多套分层方案，那么建议复制多个项目
    /// 2-软件设计一定采用一切从简的风格
    /// </summary>
    public partial class FormMain : Form
    {
        //定义list存储treeviewProject选中的井
        public static List<string> ltSelectedJH_tvProject = new List<string>();
        //定义list存储treeviewProject选中的测井曲线
        public static List<string> ltSelectedLongName_tvProject = new List<string>();

        //定义存储mainForm Web中的文件路径
        public static string filePathWebSVG = "";
        //定义存储mainForm Data中的文件路径
        public static string filepathTableData = "";
         
        string sJHselectedOnPanel = "";

        List<TabPage> listTabpageMain = new List<TabPage>(); //主面板
        List<ToolStripButton> listToolStripButtonsDraw = new List<ToolStripButton>();//动态添加菜单

        OpreateMode currentOpreateMode = OpreateMode.Initial;
        public FormMain()
        {
            InitializeComponent();
            intializeMyForm();
            softRightLimited();
        }

        void softRightLimited() 
        {
            if (cSoftwareLimited.limitedDay() == false)
            {
                MessageBox.Show("软件已经过期，请联系软件作者: 13581625021.", "提示");
                System.Environment.Exit(0);
            }
            // iCase=0 debug,iCase=1 release
            int iCase = 0;
            if (iCase == 1)
            {
            }
        }

        void enableMenu() 
        {
            tsmiData.Enabled = true;
            tsmiStatisticsCal.Enabled = true;
            tsmiGeologyLayer.Enabled = true;
            tsmiGeologySection.Enabled = true;
            tsmiSaveAnotherProject.Enabled = true;
            tsmiSaveProject.Enabled = true;
            tsmiProfileDecision.Enabled = true;
        }

        private void intializeMyForm()
        {
            tvProjectData.ImageList = this.imageListMain;
            splitContainerLeft.Panel2Collapsed = true;
            listTabpageMain.Add(tbgMainWellNavigation);
            listTabpageMain.Add(tbgMainIE);
            listTabpageMain.Add(tbgMainTable);
            listTabpageMain.Add(tbgWellHead);
            listTabpageMain.Add(tbgLayerSeriers);
            for (int i = 4; i >= 3; i--)
            {
                this.tbcMain.TabPages.Remove(tbcMain.TabPages[i]);
            }
            initialCbbScale();
            tslblLayer.Visible = false; 
            tscbbLayer.Visible = false;

            tsmiProfileDecision.Visible = false;  //调驱菜单
        }

        //初始化控件当新建工程或者打开工程时
        void initialCbbScale()
        {
            cPublicMethodForm.initialMapScale(tscbbScale);
            tscbbScale.SelectedIndex = 0;
        }

        void updateDatable()
        {
            if (File.Exists(filepathTableData))
            {
                dgvDataTable.Columns.Clear();
                int lineindex = 0;
                string[] split;
                List<string> ltStrHeadColoum = new List<string>();
                using (StreamReader sr = new StreamReader(filepathTableData, Encoding.Default))
                {
                    String line;
                    while ((line = sr.ReadLine()) != null && lineindex < 1) //delete the line whose legth is 0
                    {
                        lineindex++;
                        split = line.Trim().Split(new char[] { ' ', '\t', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < split.Length; i++) ltStrHeadColoum.Add(split[i]);
                    }
                }
                for (int i = 0; i < ltStrHeadColoum.Count; i++)
                {
                    DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                    col.HeaderText = ltStrHeadColoum[i];
                    dgvDataTable.Columns.Add(col);
                }
                this.tbcMain.SelectedTab = tbgMainTable;
                cPublicMethodForm.read2DataGridViewByTextFile(filepathTableData, dgvDataTable);
                dgvDataTable.Rows.RemoveAt(0);
            }
        }
        /// <summary>
        /// 更新主面井导航面板，树导航
        /// </summary>
        private void updateTreeViewProject()
        {
            tvProjectData.CheckBoxes = true;
            //清空tv
            tvProjectData.Nodes.Clear();
            //加载井结点
            TreeViewProjectData.setupTNwell2TV(tvProjectData);
            //加载层结点
            TreeViewProjectData.setupTNLayer2TV(tvProjectData);
            //柱状剖面
            TreeViewProjectData.setupTNsectionWell2TV(tvProjectData);
            //联井剖面
            TreeViewProjectData.setupTNsectionGeo2TV(tvProjectData);
            //栅状图
            TreeViewProjectData.setupTNsectionFence2TV(tvProjectData);
            //计算结果
            TreeViewProjectData.setupTNCalText2TV(tvProjectData);
            //成果图
            TreeViewProjectData.setupTNsvgMap2TV(tvProjectData);
            //只展开第一层井菜单
            foreach (TreeNode tn in tvProjectData.Nodes) if (tn.Level == 0 && tn.Index==0) tn.Expand();

        }
      
        #region 工程管理
        bool createNewProject()
        {
            bool bCreated = false;
            if (cProjectManager.creatProject())
            {
                cProjectData.clearProjectData();
                showInputStaticGeologyTabpage();
                tvProjectData.Nodes.Clear();
                tbcMain.SelectedTab = tbgWellHead;
                this.tsslblProjectionInfor.Text = "工程路径：" + cProjectManager.dirPathUserData;
                bCreated = true;
            }
            return bCreated;
        }
        /// <summary>
        /// 工具栏新建工程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsBtnNewProject_Click(object sender, EventArgs e)
        {
            if (createNewProject()) { enableMenu(); updateTreeViewProject(); }
        }

        void openExistProject(string projectFilePath)
        {
            if (cProjectManager.loadProject(projectFilePath))
                {
                    this.tsslblProjectionInfor.Text = "工程路径：" + cProjectManager.dirProject;
                    updateTreeViewProject();
                    tscbbScale.Text = ((int)(1000 / cProjectData.dfMapScale)).ToString();
                    WellNavitationInvalidate();
                    this.webBrowserIE.Navigate("about:blank");
                    filePathWebSVG = "";
                    enableMenu(); 
                }
        }

        private void tsmiNewProject_Click(object sender, EventArgs e)
        {
            if (createNewProject()) { enableMenu();  }
        }
        /// <summary>
        /// 选择项目文件.xl,xl是个xml文件，从文件中load 数据
        /// </summary>
        /// <returns></returns>
        bool openProject()
        {
            bool opened = false;
             if (cProjectManager.loadProject())
            {
                this.tsslblProjectionInfor.Text = "工程路径：" + cProjectManager.dirProject;
                updateTreeViewProject();
                tscbbScale.Text = ((int)(1000 / cProjectData.dfMapScale)).ToString();
                WellNavitationInvalidate();
                opened = true;
                this.webBrowserIE.Navigate("about:blank");
                filePathWebSVG = "";
            }
             return opened;
        }
        private void tsmiOpenProject_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdProjectPath = new OpenFileDialog();

            ofdProjectPath.Title = " 打开项目：";
            ofdProjectPath.Filter = "xl文件|*.xl";
            //设置默认文件类型显示顺序 
            ofdProjectPath.FilterIndex = 1;
            //保存对话框是否记忆上次打开的目录 
            ofdProjectPath.RestoreDirectory = true;

            if (ofdProjectPath.ShowDialog() == DialogResult.OK)
            {
                string projectFilePath = ofdProjectPath.FileName;
                openExistProject(projectFilePath);
            }
        }
        private void tsmSaveProject_Click(object sender, EventArgs e)
        {
            cProjectManager.saveProject();
        }
        private void tsmiExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void tsBtnSaveProject_Click(object sender, EventArgs e)
        {
            if (cProjectManager.dirProject != Path.GetTempPath())
            {
                cProjectManager.saveProject();
                TreeView2Xml.treeview2xml(tvProjectData, TreeViewProjectData.xmlTVconfig);
            }
        }
        #endregion

        #region  输入数据
        private void importDataGridView(DataGridView dgv, string filepath)
        {
            cPublicMethodForm.readDataGridView2TXTFile(dgv, filepath);
            cPublicMethodForm.read2DataGridViewByTextFile(filepath, dgv);
        }
        private void showInputStaticGeologyTabpage()
        {
            List<TabPage> listTabPageStaticData = new List<TabPage>();

            listTabPageStaticData.Add(this.tbgWellHead);
            listTabPageStaticData.Add(this.tbgLayerSeriers);

            foreach (TabPage tg in listTabPageStaticData)
            {
                if (tg.Parent == null && tbcMain.Contains(tg)==false)
                {
                    tbcMain.TabPages.Add(tg);
                }
            }
        }
        private void updateInputData(DataGridView dgv, string inputFilepath)
        {
            cPublicMethodForm.updateInputStartWithJH(inputFilepath, dgv);
            cPublicMethodForm.read2DataGridViewByTextFile(inputFilepath, dgv);
        }

        private void btnOpenWellHead_Click(object sender, EventArgs e)
        {
            cPublicMethodForm.read2DataGridViewByTextFile(dgvWellHead);
        }
        private void btnImportWellHead_Click(object sender, EventArgs e)
        {
            cIOinputWellHead.readWellHead2Project(this.dgvWellHead, cProjectManager.filePathInputWellhead);
            cIOinputWellHead.codeReplaceWellHead();

            cProjectData.ltStrProjectJH.Clear();
            foreach (string _sJH in cIOinputWellHead.getLtStrJH())
            {
                cProjectData.ltStrProjectJH.Add(_sJH);
                cProjectManager.createWellDir(_sJH);
            }
            cProjectData.setProjectWellsInfor();
            this.tbcMain.SelectedIndex = 0;
            updateTreeViewProject();
        }

        private void btnOpenLayerSeriers_Click(object sender, EventArgs e)
        {
            cPublicMethodForm.read2DataGridViewByTextFile(dgvLayerSeriers);
        }
        /// <summary>
        /// 采用保留一种分层方案的设计，所以更新时要提示是否有原方案并修改。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImportLayerSeriers_Click(object sender, EventArgs e)
        {
            //原分层方案的数据将出清
            FormInputBox inputBox = new FormInputBox("请输入新分层方案名称：","确认后请计算全部层位相关数据:");
            var result = inputBox.ShowDialog();
            if (result == DialogResult.OK)
            {   
                foreach(string _sJH in cProjectData.ltStrProjectJH) { cIOinputLayerDepth.deleteFile(_sJH);}
                string strFCFA = inputBox.ReturnValueStr;            //分层方案名 作为id 存values preserved after close
                cProjectData.ltStrProjectXCM.Clear();
                cProjectData.ltStrProjectXCM = cPublicMethodForm.getDataGridViewColumn(dgvLayerSeriers, 0);
                if (strFCFA != "" && cProjectData.ltStrProjectXCM.Count > 0)
                {
                    cProjectData.setProjectXCM2XML(strFCFA);
                    cProjectData.getProjectXCMFromXML();
                    cProjectManager.createLayerDir();
                    updateTreeViewProject();
                }
                else 
                {
                    MessageBox.Show("至少包括一个分层方案名称。");
                }
            }
           
        }

        private void btnCopyFromExcelWellHead_Click(object sender, EventArgs e)
        {
            cPublicMethodForm.DataGridViewCellPaste(dgvWellHead);
        }

        private void btnCopyFromExcelLayerSeriers_Click(object sender, EventArgs e)
        {
            cPublicMethodForm.DataGridViewCellPaste(dgvLayerSeriers);
        }

        #endregion

        #region  地质
        private void tsmiLayerGeology_Click(object sender, EventArgs e)
        {
            FormMapLayer formLayerMap = new FormMapLayer();
            formLayerMap.Show();
        }

        private void tsmiSectionReservior_Click(object sender, EventArgs e)
        {
            FormSectionGeo FormWellsGroup = new FormSectionGeo();
            FormWellsGroup.ShowDialog();
        }

        private void ToolStripStatusLabelProjectionInfor_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", cProjectManager.dirProject);
        }

        private void calHeterogeneityInterLayerWorkerMethod(object sender, WaitWindowEventArgs e)
        {
            cCalGeologyStatistics cCalHeterogeneity = new cCalGeologyStatistics();
            cCalHeterogeneity.calHeterogeneityInterLayer();
        }

        private void calHeterogeneityInnerLayerWorkerMethod(object sender, WaitWindowEventArgs e)
        {
            cCalGeologyStatistics cCalHeterogeneity = new cCalGeologyStatistics();
            cCalHeterogeneity.calHeterogeneityInnerLayer();
        }

        private void calStaticWorkerMethod(object sender, WaitWindowEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Stopwatch stopWatch = new Stopwatch();
            //检查每口井数据文件是否有计算所需要的数据文件，数据不完整的需要补全数据，这个需要重新考虑
            bool bFileFull=cIOProject.checkStaticCalInputFiles() ;
            if (bFileFull== false) 
            {
                DialogResult dialogResult = MessageBox.Show("有井数据缺失，是否继续计算？", "提示", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes) bFileFull = true; 
            }
            if (bFileFull == true)
            {
                stopWatch.Start();
                //根据用户输入层顶数据，计算单井的分层数据
                cIOinputLayerDepth.creatWellGeoFile();

                //根据用户输入的测井解释，计算单井的测井解释
                cIOinputJSJL.creatWellGeoFile();

                //计算小层数据字典
                cIODicLayerDataStatic cCalLayerData = new cIODicLayerDataStatic();
                cCalLayerData.generateLayerData();

                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                   ts.Hours, ts.Minutes, ts.Seconds,
                   ts.Milliseconds / 10);
                MessageBox.Show("计算完成。消耗时间：" + elapsedTime);
            }
            Cursor.Current = Cursors.Default;
        }

        private void calMatchJSJLWorkerMethod(object sender, WaitWindowEventArgs e)
        {
            foreach (string _sJH in cProjectData.ltStrProjectJH) cIOinputJSJL.matchJSJL2Layer(_sJH);
            cIOBase.joinGeoFileFromWellDir(Path.Combine(cProjectManager.dirPathUsedProjectData,"测井解释归小层.txt"),cProjectManager.fileNameWellJSJL);
        }

        private void calSplitJSJLWorkerMethod(object sender, WaitWindowEventArgs e)
        {
            foreach (string _sJH in cProjectData.ltStrProjectJH) cIOinputJSJL.splitJSJL2Layer(_sJH);
        }
        #endregion

        private void tsmiCalWellDistance_Click(object sender, EventArgs e)
        {
            FormCalWellDistance formCalDistance = new FormCalWellDistance();
            formCalDistance.Show();
        }
    
        private void tsmi注采关系分析_Click(object sender, EventArgs e)
        {
            FormInjProAna forminjectProductAna = new FormInjProAna();
            forminjectProductAna.Show();
        }

        private void calDynamicWorkerMethod(object sender, WaitWindowEventArgs e)
        {
            //主要分析计算在生产过程中，本井在一定历史时期内的井型，可能为水井，也可能为油井。
            // 井号 小层名 时间 射孔厚度 砂厚 渗透率 孔隙度 吸水(产液)厚度 吸水%
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            //合并井文件夹下的动态数据到统一文件，这是基本的数据库视图管理
            cIOinputWellPerforation.creatWellGeoFile();
            cIOinputInjectProfile.creatWellGeoFile();
            cIOinputWellProduct.joinInputFileFromWellDir();
            cIOInputWellInject.joinInputFileFromWellDir();
            cIODicLayerDataDynamic.generateDynamicData();
         
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
               ts.Hours, ts.Minutes, ts.Seconds,
               ts.Milliseconds / 10);
            MessageBox.Show("计算完成。消耗时间：" + elapsedTime);
        }

        private void calWellConnectWorkerMethod(object sender, WaitWindowEventArgs e)
        {
            //主要分析计算在生产过程中，本井在一定历史时期内的井型，可能为水井，也可能为油井。
            // 井号 小层名 时间 射孔厚度 砂厚 渗透率 孔隙度 吸水(产液)厚度 吸水%
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            cIODicInjProCon.updateWellConnect();
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
               ts.Hours, ts.Minutes, ts.Seconds,
               ts.Milliseconds / 10);
            MessageBox.Show("计算完成。消耗时间：" + elapsedTime);
        }

        private void tsmiCalWellTypeDictionary_Click(object sender, EventArgs e)
        {
            WaitWindow.Show(this.calDynamicWorkerMethod);
        }

        private void tsmiSectionWellPattern_Click(object sender, EventArgs e)
        {
            FormSectionGroup formFD = new FormSectionGroup();
            formFD.Show();
        }

        private void tsmiCalProductionFoctor_Click(object sender, EventArgs e)
        {
            FormSettingSplitFactor formSplitFactor = new FormSettingSplitFactor();
            formSplitFactor.ShowDialog();
        }

        private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.tbcMain.SelectedTab.Name == this.tbgWellHead.Name)
            {
                this.dgvWellHead.Height = this.tbcMain.Height - 120;
                if (File.Exists(cProjectManager.filePathInputWellhead))
                    cPublicMethodForm.read2DataGridViewByTextFile(cProjectManager.filePathInputWellhead, dgvWellHead);
            }

            if (this.tbcMain.SelectedTab.Name == this.tbgLayerSeriers.Name)
            {
                this.dgvLayerSeriers.Height = this.tbcMain.Height - 100;
            }
        }

        private void tsmiDeleteSelectedWellInPanel_Click(object sender, EventArgs e)
        {
            if (sJHselectedOnPanel != "")
            {
                cProjectManager.delWellFromProject(sJHselectedOnPanel);
                updateTreeViewProject(); 
            }
        }

        private void tsmiCalLayerHeterogeneityInner_Click(object sender, EventArgs e)
        {
            WaitWindow.Show(this.calHeterogeneityInnerLayerWorkerMethod);
        }

        private void tsmiShowLayerHeterogeneityInner_Click(object sender, EventArgs e)
        {
            FormDataTable formDatatable = new FormDataTable(cProjectManager.filePathInnerLayerHeterogeneity);
            formDatatable.Show();
        }

        private void tsmiShowLayerHeterogeneityInner1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", cProjectManager.filePathInterLayerHeterogeneity);
        }

        private void tsmiCalXCSJB_Click(object sender, EventArgs e)
        {
            WaitWindow.Show(this.calStaticWorkerMethod);
        }

        private void tsmiLayerInjectProductSystem_Click(object sender, EventArgs e)
        {
            FormInjProMap formInjProSystemMap = new FormInjProMap();
            formInjProSystemMap.Show();
        }

        private void btnInputWellheaddelDgvLine_Click(object sender, EventArgs e)
        {
            cPublicMethodForm.deleteSelectedCurrentRowDGV(dgvWellHead);
        }

        private void btnInputLayerSerieresdelDgvLine_Click(object sender, EventArgs e)
        {
            cPublicMethodForm.deleteSelectedCurrentRowDGV(dgvLayerSeriers);
        }

        private void tsmiLayerProductionState_Click(object sender, EventArgs e)
        {

        }

        private void tabControlMain_DoubleClick(object sender, EventArgs e)
        {
            if (tbcMain.SelectedIndex > 1)
            {
                TabPage currentPage = tbcMain.SelectedTab;
                if( currentPage.Text == this.tbgWellHead.Text || currentPage.Text==this.tbgLayerSeriers.Text) tbcMain.TabPages.Remove(currentPage);
            
            }
        }


    

        void addTreeViewSVGNode(XmlNode xn, TreeNode tn,int iLever) 
        {
            iLever--;
            if(iLever>=0){
            XmlNodeList listXNchilds = xn.ChildNodes;
            foreach (XmlNode xnChild in listXNchilds)
            {
                if (xnChild.Name == "g")
                {
                    var childIDAttribute = xnChild.Attributes["id"];
                    if (childIDAttribute != null)
                    {
                        TreeNode tnChild = new TreeNode(xnChild.Attributes["id"].Value);
                        tnChild.Checked = true;
                        if (xnChild.Name == "g") 
                        {
                            addTreeViewSVGNode(xnChild, tnChild, iLever);
                            tn.Nodes.Add(tnChild);
                        }
                    }
                }
            }}
        
        }

        private void updateTreeViewSVGLayer()
        {
            if (filePathWebSVG.EndsWith(".svg"))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(filePathWebSVG);
                XmlNodeList listXN = xmlDoc.DocumentElement.ChildNodes;
                this.tvSVGLayer.Nodes.Clear();
                tvSVGLayer.CheckBoxes = true;
                foreach (XmlNode xn in listXN)
                {
                    var nameAttribute = xn.Attributes["id"];
                    if (nameAttribute != null)
                    {
                        TreeNode tn = new TreeNode(xn.Attributes["id"].Value);
                        tn.Checked = true;
                        if (xn.Name == "g") 
                        {   
                            //此处递归增加图层
                            addTreeViewSVGNode(xn, tn,2);
                            tvSVGLayer.Nodes.Add(tn);
                        }
                    }
                }
            }
               
        }

        void updateWebSVG()
        {
            this.tbcMain.SelectedTab = tbgMainIE;
            try
            {
                if (filePathWebSVG.EndsWith(".svg"))
                {
                    this.webBrowserIE.Navigate(new Uri(filePathWebSVG));
                    this.tbgMainIE.Text =Path.GetFileNameWithoutExtension(filePathWebSVG);
                   
                }
                else
                {
                    this.tbcMain.SelectedTab = tbgMainWellNavigation;
                }
            }
            catch (System.UriFormatException)
            {
                MessageBox.Show("UriFormatException error.");
            }

        }

        private void tsBtnZoonIn_Click(object sender, EventArgs e)
        {
            if (tbcMain.SelectedIndex == 0)
            {
                cProjectData.dfMapScale = cProjectData.dfMapScale * 1.2F;
                tscbbScale.Text = (1000.0 / cProjectData.dfMapScale).ToString("0");
                WellNavitationInvalidate();
            }
            if (tbcMain.SelectedIndex == 1)
            {
                webBrowserIE.Focus();
                SendKeys.Send("^{+}");
            }
        }

        private void tsBtnZoomOut_Click(object sender, EventArgs e)
        {
            if (tbcMain.SelectedIndex == 0)
            {
                cProjectData.dfMapScale = cProjectData.dfMapScale * 0.8F;
                tscbbScale.Text = (1000.0 / cProjectData.dfMapScale).ToString("0");
                WellNavitationInvalidate();
            }
            if (tbcMain.SelectedIndex == 1)
            {
                webBrowserIE.Focus();
                SendKeys.Send("^{-}");
            }
        }

        private void tsCbbScale_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tscbbScale.SelectedIndex >= 0)
            {
                float dfscale = float.Parse(tscbbScale.SelectedItem.ToString());
                cProjectData.dfMapScale = 1000 / dfscale;
                WellNavitationInvalidate();
            }
        }

        private void tvProjectData_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectNode = tvProjectData.SelectedNode;
            if (selectNode != null) makeupProjectTVCMS(selectNode) ;
        }

        void makeupProjectTVCMS(TreeNode selectNode) 
        {
            this.tvProjectData.ContextMenuStrip = this.cmsDefaultProjectTV;
            tsmiMakeWellSection.Visible = false; 
            switch (selectNode.Level)
            {
                case 0: //第一级菜单
                    if (selectNode.Tag.ToString() == TypeProjectNode.wells.ToString())  
                        tsmiMakeWellSection.Visible = true;
                    if (selectNode.Tag.ToString() == TypeProjectNode.wellTopDir.ToString())
                            this.tvProjectData.ContextMenuStrip = this.cmsTNprojectLayer;
                    break;
                case 1://第2级菜单
                    if (selectNode.Parent.Text == "井" && selectNode.Index > 0) //当前选中井，index=0 是全局测井曲线
                        this.tvProjectData.ContextMenuStrip = this.cmsTNinputWell;
                    if (selectNode.Tag.ToString()  == TypeProjectNode.globalLogDir.ToString())  //当前 全局测井曲线
                        makeCMSGlobleLog(selectNode);
                    if (selectNode.Parent.Tag.ToString() == TypeProjectNode.wellTopDir.ToString())  //
                        this.tvProjectData.ContextMenuStrip = this.cmsTNlayerItem;
                    if (selectNode.Parent.Tag.ToString() == TypeProjectNode.sectionWellDir.ToString() )  //柱状剖面菜单
                        this.tvProjectData.ContextMenuStrip = this.cmsSectionWell;
                    if (selectNode.Parent.Tag.ToString() == TypeProjectNode.sectionGeoDir.ToString())  //联井剖面菜单
                        this.tvProjectData.ContextMenuStrip = this.cmsTNsectionGeo;
                    if (selectNode.Parent.Tag.ToString() == TypeProjectNode.sectionFenceDir.ToString())  //栅状图菜单
                        this.tvProjectData.ContextMenuStrip = this.cmsTNSectionFence;
                    if (selectNode.Tag.ToString() == TypeProjectNode.svgMap.ToString())  //成果图
                        this.tvProjectData.ContextMenuStrip = this.cmsTNprojectGrapthSVG;
                    break;
                case 2://第3级菜单，右键快捷菜单配置
                    if (selectNode.Text == "well logs")
                        this.tvProjectData.ContextMenuStrip = this.cmsTNwellLogNode;
                    if (selectNode.Tag.ToString() == TypeProjectNode.globalLog.ToString())  //全局菜单的测井曲线
                        makeCMSGlobleLog(selectNode);
                    if ( selectNode.Tag.ToString() == TypeProjectNode.sectionWell.ToString()) //当前选中井，index=0 是全局测井曲线
                        this.tvProjectData.ContextMenuStrip = this.cmsTNdataSectionWell;
                    if (selectNode.Parent.Tag.ToString() == TypeProjectNode.wellTop.ToString())  //
                        this.tvProjectData.ContextMenuStrip = this.cmsTNlayerItem;
                        break;
                case 3://第4级菜单，右键快捷菜单配置
                    if (selectNode.Parent.Text == "well logs")
                        this.tvProjectData.ContextMenuStrip = this.cmsTNwellLogItem;
                    if (selectNode.Parent.Tag.ToString()== TypeProjectNode.sectionWell.ToString())
                        this.tvProjectData.ContextMenuStrip = this.cmsTNdataSectionWellChildItem;
                    break;

                default:
                    break;
            }
          
        }

        void makeCMSGlobleLog(TreeNode selectNode)
        {
            foreach (ToolStripMenuItem item in cmsTNglobalLog.Items) item.Visible = false;
            if (selectNode.Tag.ToString() == TypeProjectNode.globalLogDir.ToString())
                cmsTNglobalLog.Items[0].Visible = true;
            if (selectNode.Tag.ToString() == TypeProjectNode.globalLog.ToString())
            {
                cmsTNglobalLog.Items[1].Visible = true;
                cmsTNglobalLog.Items[2].Visible = true;
                cmsTNglobalLog.Items[3].Visible = true;
                cmsTNglobalLog.Items[4].Visible = true;
            }
            this.tvProjectData.ContextMenuStrip = this.cmsTNglobalLog;
        }
        
        private void 动态地质分析ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormProductAnalisys formProductionMap = new FormProductAnalisys();
            formProductionMap.Show();
        }

        public void showGrpah(string filepathGrpath)
        {
            this.tbcMain.SelectedIndex = 1;
            this.webBrowserIE.Navigate(new Uri(filepathGrpath));
        }

        private void tsmiWellPosition4Petrel_Click(object sender, EventArgs e)
        {
            cExportData4Petrel.exportWellHead();
        }


        int iNumClickLineDraw = 0;
        Point pLinePoint1 = new Point(-1, -1);
        Point pLinePoint2 = new Point(-1, -1);
        List<Point> listPointPolygon = new List<Point>();
        bool bEndDrawPolygon = true;
       
        Point Opoint = new Point(0, 0);

        private void panelWellNavigation_Paint(object sender, PaintEventArgs e)
        {
            addGrid(e);
            addWellPosion(e);
        }

        void addWellSectionLine(PaintEventArgs e)
        {
            if (File.Exists(TreeViewProjectData.xmlTVconfig)) 
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(TreeViewProjectData.xmlTVconfig);
                Pen blackPen = new Pen(Color.Black, 1);
                Graphics dc = e.Graphics;
                dc.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                Font font = new Font("黑体", 12);
               Brush redBrush = Brushes.Red;
                string sPath = string.Format("//*[@tag='{0}']", TypeProjectNode.sectionGeo.ToString());
                XmlNodeList xnSection = xmlDoc.SelectNodes(sPath);
                foreach (XmlNode xn in xnSection)
                {
                    int iChecked=0;
                    int.TryParse(xn.Attributes["iChecked"].Value, out iChecked);
                    if(iChecked==1)
                    {
                    List<string> ltJH = xn.InnerText.Split(new string[] { cProjectData.splitMark }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    List<Point> points = new List<Point>();
                    foreach (string _sJH in ltJH)
                    {
                        ItemWell itemWell = cProjectData.ltProjectWell.SingleOrDefault(p => p.sJH == _sJH);
                        if (itemWell != null)
                        {
                            Point pView = cCordinationTransform.transRealPointF2ViewPoint(
                              itemWell.dbX, itemWell.dbY, cProjectData.dfMapXrealRefer, cProjectData.dfMapYrealRefer, cProjectData.dfMapScale);
                            points.Add(pView);
                        }
                    }//end foreach JHList
                    if (points.Count > 1) 
                    {
                        dc.DrawLines(blackPen, points.ToArray());
                        dc.DrawString(xn.Attributes["text"].Value, font, redBrush, points[0].X - 10, points[0].Y - 20);
                    }

                    } 
                } //end foreach
            
            }// end if
     
            base.OnPaint(e);
        } 

        void addGrid(PaintEventArgs e)
        {
            Graphics dc = e.Graphics;
            Font font = new Font("黑体", 8);
            Brush blueBrush = Brushes.Blue;
            Pen pen = new Pen(Color.LightBlue, 0.5F);
            for (int i = 1; i * 500 * cProjectData.dfMapScale < this.panelWellNavigation.Width; i++)
            {
                int iXCurrentView = Convert.ToInt32(i * 500 * cProjectData.dfMapScale);
                Point point1 = new Point(iXCurrentView, 0);
                Point point2 = new Point(iXCurrentView, this.panelWellNavigation.Height);
                dc.DrawLine(pen, point1, point2);
                dc.DrawString((cProjectData.dfMapXrealRefer + i * 500).ToString(), font, blueBrush, iXCurrentView, 0);
            }

            for (int i = 1; i * 500 * cProjectData.dfMapScale < this.panelWellNavigation.Height; i++)
            {
                int iYCurrentView = Convert.ToInt32(i * 500 * cProjectData.dfMapScale);
                Point point3 = new Point(0, iYCurrentView);
                Point point4 = new Point(this.panelWellNavigation.Width, iYCurrentView);
                dc.DrawLine(pen, point3, point4);
                dc.DrawString((cProjectData.dfMapYrealRefer - i * 500).ToString(), font, blueBrush, 0, iYCurrentView);
            }

            base.OnPaint(e);
        }

        void addWellPosion(PaintEventArgs e)
        {
            if (cProjectData.ltProjectWell.Count > 0)
            {
                Graphics dc = e.Graphics;
                dc.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                Font font = new Font("黑体", 8);
                foreach (ItemWell itemWell in cProjectData.ltProjectWell)
                {
                    Pen wellPen = new Pen(Color.Black, 2);
                    if (itemWell.iWellType == 3) wellPen = new Pen(Color.Red, 2);
                    else if (itemWell.iWellType == 5) wellPen = new Pen(Color.Green, 2);
                    else if (itemWell.iWellType == 15) wellPen = new Pen(Color.Blue, 2);

                    Pen blackPen = new Pen(Color.Black, 1);
                    List<ItemDicWellPath> currentWellPath = itemWell.WellPathList;
                    Point headView = cCordinationTransform.transRealPointF2ViewPoint(
                     currentWellPath[0].dbX, currentWellPath[0].dbY, cProjectData.dfMapXrealRefer, cProjectData.dfMapYrealRefer, cProjectData.dfMapScale);
                    dc.DrawEllipse(wellPen, headView.X-3, headView.Y-3, 6, 6);

                    int iCount = currentWellPath.Count;
                    if (iCount > 2)
                    {
                        List<Point> points = new List<Point>();
                        for (int k = 0; k < iCount; k++)
                        {
                            Point tailView = cCordinationTransform.transRealPointF2ViewPoint(
                            currentWellPath[k].dbX, currentWellPath[k].dbY, cProjectData.dfMapXrealRefer, cProjectData.dfMapYrealRefer, cProjectData.dfMapScale);
                            points.Add(tailView);
                        }
                        dc.DrawLines(blackPen, points.ToArray());
                    }
                    Brush blackBrush = Brushes.Black;
                    dc.DrawString(itemWell.sJH, font, blackBrush,
                                   headView.X + 3, headView.Y);
                }

            }
            base.OnPaint(e);
        }
        
        private string getWellNameByScreenPoint(Point pScreen)
        {
            foreach(ItemWell item in cProjectData.ltProjectWell)
            {
                Point  itemView = cCordinationTransform.transRealPointF2ViewPoint(
                     item.dbX, item.dbY, cProjectData.dfMapXrealRefer, cProjectData.dfMapYrealRefer, cProjectData.dfMapScale);
                if (Math.Abs(pScreen.X - itemView.X) <= 5 && Math.Abs(pScreen.Y - itemView.Y) <= 5) return item.sJH; 
            }
            return "";
        }
      
        void WellNavitationInvalidate()
        {
            if (cProjectData.ltStrProjectJH.Count > 0)
            {
                int iSacleUnit = 500; //定义网格单位
                if (cProjectData.dfMapScale == 0) cProjectData.dfMapScale =0.1;
                cProjectData.dfMapXrealRefer = Math.Floor(cProjectData.ltProjectWell.Min(p => p.dbX) / iSacleUnit - 1) * iSacleUnit;
                cProjectData.dfMapYrealRefer = (Math.Ceiling(cProjectData.ltProjectWell.Max(p => p.dbY) / iSacleUnit) + 1) * iSacleUnit; 

                double xMaxDistance = cProjectData.ltProjectWell.Max(p => p.dbX) - cProjectData.ltProjectWell.Min(p => p.dbX);
                double yMaxDistance = cProjectData.ltProjectWell.Max(p => p.dbY) - cProjectData.ltProjectWell.Min(p => p.dbY);

                int iPanelWidth = Convert.ToInt32((int)(xMaxDistance / iSacleUnit + 6) * iSacleUnit * cProjectData.dfMapScale);//显示好看pannel比最大大4个网格
                int iPanelHeight = Convert.ToInt32((int)(yMaxDistance / iSacleUnit + 6) * iSacleUnit*cProjectData.dfMapScale);//显示好看pannel比最大大4个网格
                panelWellNavigation.Dock = System.Windows.Forms.DockStyle.None;

                panelWellNavigation.Width = iPanelWidth;
                panelWellNavigation.Height = iPanelHeight;
                panelWellNavigation.Location = new Point(3, 3);

                this.panelWellNavigation.Invalidate();
                this.panelWellNavigation.Focus();
            }

        }

        private void tabPageWellNavigation_Click(object sender, EventArgs e)
        {
            WellNavitationInvalidate();
        }

        private void panelWellNavigation_MouseClick(object sender, MouseEventArgs e)
        {
            switch (currentOpreateMode)
            {
                case OpreateMode.Initial:
                    double xReal = cCordinationTransform.transXview2Xreal(e.X, cProjectData.dfMapXrealRefer, cProjectData.dfMapScale);
                    double yReal = cCordinationTransform.transYview2Yreal(e.Y, cProjectData.dfMapYrealRefer, cProjectData.dfMapScale);
                    Point pScreen = new Point(e.X, e.Y);
                    sJHselectedOnPanel = getWellNameByScreenPoint(pScreen);
                    this.tssLabelPosition.Text = sJHselectedOnPanel + " X=" + xReal.ToString("0.0") + " Y=" + yReal.ToString("0.0");
                    break;
                case OpreateMode.DrawLine:
                    iNumClickLineDraw++;
                    if (iNumClickLineDraw > 0 && iNumClickLineDraw % 2 == 1)
                    {
                        pLinePoint1.X = e.X;
                        pLinePoint1.Y = e.Y;
                    }
                    else if (iNumClickLineDraw > 0 && iNumClickLineDraw % 2 == 0)
                    {
                        pLinePoint2.X = e.X;
                        pLinePoint2.Y = e.Y;
                    }
                    this.panelWellNavigation.Invalidate();
                    break;
                case OpreateMode.DrawPolygon:
                    if (bEndDrawPolygon == false)
                        listPointPolygon.Add(new Point(e.X, e.Y));
                    this.panelWellNavigation.Invalidate();
                    break;
            }

        }
        private void panelWellNavigation_MouseDown(object sender, MouseEventArgs e)
        {
            switch (currentOpreateMode)
            {
                case OpreateMode.Initial:
                    if (e.Button == MouseButtons.Left)
                    {
                        this.Opoint.X = e.X;
                        this.Opoint.Y = e.Y;
                        this.Cursor = Cursors.Hand;
                    }
                    break;
                case OpreateMode.DrawLine:
                    //MessageBox.Show("DrawLine MouseMove");
                    break;
            }

        }
        private void panelWellNavigation_MouseMove(object sender, MouseEventArgs e)
        {
            switch (currentOpreateMode)
            {
                case OpreateMode.Initial:
                    if (e.Button == MouseButtons.Left)
                    {
                        this.panelWellNavigation.Left = this.panelWellNavigation.Left + e.X - this.Opoint.X;
                        this.panelWellNavigation.Top = this.panelWellNavigation.Top + e.Y - this.Opoint.Y;
                    }
                    break;
                case OpreateMode.DrawLine:
                    //MessageBox.Show("DrawLine MouseMove");
                    break;
            }

        }
        private void panelWellNavigation_MouseUp(object sender, MouseEventArgs e)
        {
            switch (currentOpreateMode)
            {
                case OpreateMode.Initial:
                    this.Cursor = Cursors.Default;
                    break;
                case OpreateMode.DrawLine:
                    //MessageBox.Show("DrawLine MouseMove");
                    break;
            }

        }
        private void panelWellNavigation_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            switch (currentOpreateMode)
            {
                case OpreateMode.Initial:
                    this.Cursor = Cursors.Default;
                    break;
                case OpreateMode.DrawPolygon:
                    bEndDrawPolygon = true;
                    this.panelWellNavigation.Invalidate();
                    break;
            }
        }

        private void tvProjectData_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level == 0 && e.Node.Text == "井")
            {
                ltSelectedJH_tvProject.Clear();
                if (e.Node.Checked == true)
                {
                    foreach (TreeNode _tn in e.Node.Nodes)
                    {
                        _tn.Checked = true;
                        if (_tn.Index > 0) ltSelectedJH_tvProject.Add(_tn.Text);  //0是global well log
                    }
                }
                if (e.Node.Checked == false)
                {
                    foreach (TreeNode _tn in e.Node.Nodes) _tn.Checked = false;
                }
            };
            if (e.Node.Level == 1 && e.Node.Parent.Text == "井" && e.Node.Index == 0)
            {
                ltSelectedLongName_tvProject.Clear();
                if (e.Node.Checked == true)
                {
                    foreach (TreeNode _tn in e.Node.Nodes)
                    {
                        _tn.Checked = true;
                        ltSelectedLongName_tvProject.Add(_tn.Text);
                    }
                }
                if (e.Node.Checked == false)
                {
                    foreach (TreeNode _tn in e.Node.Nodes) _tn.Checked = false;
                }
            }
            //选择的井号
            if (e.Node.Level == 1 && e.Node.Parent.Text == "井" && e.Node.Index > 0)
            {
                string _sJH = e.Node.Text;
                if (e.Node.Checked == true)
                {
                    if (ltSelectedJH_tvProject.IndexOf(_sJH) < 0) ltSelectedJH_tvProject.Add(_sJH);
                }
                else
                { if (ltSelectedJH_tvProject.IndexOf(_sJH) >= 0) ltSelectedJH_tvProject.Remove(_sJH); }
            }
            if (e.Node.Level == 2 && e.Node.Parent.Index == 0 && e.Node.Parent.Parent.Text == "井")
            {
                string _logName = e.Node.Text;
                if (e.Node.Checked == true)
                {
                    if (ltSelectedLongName_tvProject.IndexOf(_logName) < 0) ltSelectedLongName_tvProject.Add(_logName);
                }
                else
                { if (ltSelectedLongName_tvProject.IndexOf(_logName) >= 0) ltSelectedLongName_tvProject.Remove(_logName); }

            }
        }
   

        private void tsmiWells_Click(object sender, EventArgs e)
        {
            if (tbcMain.TabPages.Contains(tbgWellHead) == false) tbcMain.TabPages.Add(tbgWellHead);
            tbcMain.SelectedTab = tbgWellHead;
        }

        private void tsmiSaveAnotherProject_Click(object sender, EventArgs e)
        {
            cProjectManager.saveProeject2otherDirectionary();
        }

        private void tsmiPetrelWellTops_Click(object sender, EventArgs e)
        {
            cExportData4Petrel.exportWellTops();
        }

        private void tsmiWellTops_Click(object sender, EventArgs e)
        {
           
            if (tbcMain.TabPages.Contains(tbgLayerSeriers) == false)
            {
                tbcMain.TabPages.Add(tbgLayerSeriers);
            }
            tbcMain.SelectedTab = tbgLayerSeriers;
        }

        private void tsmi4petrelproductLog_Click(object sender, EventArgs e)
        {
            cExportData4Petrel.exportWellInterpretation();
        }

        private void tsmiFence_Click(object sender, EventArgs e)
        {
            FormSectionGroup formFD = new FormSectionGroup();
            formFD.Show();
        }

        private void tsmiSectionDevelop_Click(object sender, EventArgs e)
        {
            FormSectionDevelop formReserviorSection = new FormSectionDevelop();
            formReserviorSection.Show();
        }

        private void tsmiSectionGeology_Click(object sender, EventArgs e)
        {
            FormSectionGeo FormWellsGroup = new FormSectionGeo();
            FormWellsGroup.Show();
        }

        private void tsmiJSJLmatch_Click(object sender, EventArgs e)
        {
            WaitWindow.Show(this.calMatchJSJLWorkerMethod);
            MessageBox.Show("计算完成。");
            filepathTableData = Path.Combine(cProjectManager.dirPathUsedProjectData,cProjectManager.fileNameWellJSJL);
            updateDatable();
        }

        private void tsmiJSJLsplit_Click(object sender, EventArgs e)
        {
            WaitWindow.Show(this.calSplitJSJLWorkerMethod);
            MessageBox.Show("计算完成。");
        }

        private void tvProjectData_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            string oldNoteText = e.Node.Text;  //原来的测井名
            string sJH = e.Node.Parent.Parent.Text;
            this.BeginInvoke(new Action(() => afterAfterEditLogName(sJH, oldNoteText, e.Node)));
        }

        private void afterAfterEditLogName(string sJH,string oldNoteText, TreeNode node)
        {
            cIOinputLog.renameProjectLogFile(sJH, oldNoteText, node.Text);
        }

        private void tvProjectData_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            e.CancelEdit = true;
            if (e.Node.Level == 3) e.CancelEdit = false;
        }

        private void tvProjectGraph_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            e.CancelEdit = true;
            if (e.Node.Level >= 0) e.CancelEdit = false;
        }

        private void tsmiAdjustProfile_Click(object sender, EventArgs e)
        {
            FormProfileSelectWells _form = new FormProfileSelectWells();
            _form.Show();
        }

        private void tsmiSectionFence_Click(object sender, EventArgs e)
        {
            FormSectionGroup _form = new FormSectionGroup();
            _form.Show();
        }

        /// <summary>
        /// 通过Form增加新井
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiNewWell_Click(object sender, EventArgs e)
        {
            FormWellInfor form = new FormWellInfor("newWell");
            form.ShowDialog();
        }

        private void updateMainPanel() 
        {
            if (cProjectManager.dirProject != Path.GetTempPath())
            {
                updateTreeViewProject();
                if (tbcMain.SelectedTab == tbgMainWellNavigation)
                {
                    WellNavitationInvalidate();
                }
                if (tbcMain.SelectedTab == tbgMainIE) this.webBrowserIE.Refresh();
            }
        }

        private void tsBtnReflush_Click(object sender, EventArgs e)
        {
            updateMainPanel(); 
        }

        void inputProjectDataOpen() 
        {
            if (cProjectManager.dirProject != Path.GetTempPath())
            {
                FormDataImportWells frmImportProject = new FormDataImportWells(0);
                frmImportProject.ShowDialog();
                cProjectData.setProjectWellsInfor();
            }
        }

        private void tsBtnDataManager_Click(object sender, EventArgs e)
        {
            inputProjectDataOpen(); 
        }

        void viewProjectDataOpen() 
        {
            if (cProjectManager.dirProject != Path.GetTempPath())
            {
                FormDataViewProjectSingleWell formDataView = new FormDataViewProjectSingleWell(cProjectData.ltStrProjectJH[0]);
                formDataView.Show();
            }
        }

        private void tsBtnDataView_Click(object sender, EventArgs e)
        {
            viewProjectDataOpen(); 
        }

        private void tsmiPIcal_Click(object sender, EventArgs e)
        {
            FormProfilePIcal form = new FormProfilePIcal();
            form.Show();
        }

        private void tsmiCloseInput_Click(object sender, EventArgs e)
        {
            tbcMain.TabPages.Remove(tbgWellHead);
            tbcMain.TabPages.Remove(tbgLayerSeriers);
        }

        private void tsmiConnectCal_Click(object sender, EventArgs e)
        {
            FormInjProAna form = new FormInjProAna();
            form.Show();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cProjectData.ltStrProjectJH.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Yes 保存工程并关闭，No 放弃关闭", "关闭工程", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes) { cProjectManager.saveProject(); Application.ExitThread(); }
                else e.Cancel = true; 
            }
        }

        private void tvSVGLayer_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (filePathWebSVG.EndsWith(".svg") )
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(filePathWebSVG);
                XmlNodeList listXN = xmlDoc.DocumentElement.ChildNodes;
                tvSVGLayer.CheckBoxes = true;
                if(e.Node.Level==0) //0的处理
                {
                    if (setPropery(xmlDoc, xmlDoc.DocumentElement, e.Node.Text, e.Node.Checked)) goto Outer;
                    //foreach (XmlNode xn in listXN) if (setPropery(xmlDoc, xn, e.Node.Text, e.Node.Checked)) goto Outer;
                }
                if (e.Node.Level == 1) //1级的处理
                {
                    foreach (XmlNode xn in listXN) if (setPropery(xmlDoc, xn, e.Node.Text, e.Node.Checked)) goto Outer;
                }
                if (e.Node.Level == 2) //1级的处理
                {
                    foreach (XmlNode xn in listXN)
                    {
                        XmlNodeList xnChildList = xn.ChildNodes;
                        foreach (XmlNode xnChild in xnChildList)
                        {
                            XmlNodeList xnChild2List = xn.ChildNodes;
                            foreach (XmlNode xnChild2 in xnChild2List) if (setPropery(xmlDoc, xnChild2, e.Node.Text, e.Node.Checked)) goto Outer;
                        }
                    }
                }
            Outer:
                xmlDoc.Save(filePathWebSVG);
                updateWebSVG();
            }
        }

        bool  setPropery(XmlDocument xmlDoc ,XmlNode xn,string sID,bool bChecked) 
        {
            XmlNodeList xnChildList = xn.ChildNodes;
            foreach (XmlNode xnChild in xnChildList)
            {
                if (xnChild.Name == "g")
                {
                    var idAttribute = xnChild.Attributes["id"];
                    if (idAttribute==null ) return false ;
                    if (idAttribute.Value == sID)
                    {
                        cXmlBase.setNodeVisibleProperty(xmlDoc, xnChild, bChecked);
                        return true;
                    }
                }
            }
            return false; 
        }

        private void tsmiCalRes_Click(object sender, EventArgs e)
        {
            FormCalReservor _form = new FormCalReservor();
            _form.Show();
        }


        private void tsmiCalVoronoi_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            cIOVoronoi.calVoiAndwrite2File();
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
               ts.Hours, ts.Minutes, ts.Seconds,
               ts.Milliseconds / 10);
            MessageBox.Show("计算完成。消耗时间：" + elapsedTime);
            Cursor.Current = Cursors.Default;
        }

        private void tsmiVoronoical_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            cIOVoronoi.calVoiAndwrite2File();
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
               ts.Hours, ts.Minutes, ts.Seconds,
               ts.Milliseconds / 10);
            MessageBox.Show("计算完成。消耗时间：" + elapsedTime);
            Cursor.Current = Cursors.Default;
        }

        private void tsmiHeterogeneityLayerInner_Click(object sender, EventArgs e)
        {
            WaitWindow.Show(this.calHeterogeneityInnerLayerWorkerMethod);
            filepathTableData = cProjectManager.filePathInnerLayerHeterogeneity;
            updateDatable();
        }

        private void tsmiHeterogeneityLayerInter_Click(object sender, EventArgs e)
        {
            WaitWindow.Show(this.calHeterogeneityInterLayerWorkerMethod);
            filepathTableData = cProjectManager.filePathInterLayerHeterogeneity;
            updateDatable();
        }

        private void tsmiProjectDataInput_Click(object sender, EventArgs e)
        {
            inputProjectDataOpen();
        }

        private void tsmiProjectDataView_Click(object sender, EventArgs e)
        {
            viewProjectDataOpen(); 
        }

        private void tsmiVoronoiAna_Click(object sender, EventArgs e)
        {
            FormVoronoiAna _form = new FormVoronoiAna();
            _form.Show();
        }

        private void tsmiVorReserver_Click(object sender, EventArgs e)
        {
            FormCalReservor _form = new FormCalReservor();
            _form.ShowDialog();
            filepathTableData = cProjectManager.filePathReserver;
            updateDatable();
        }

        private void tsmiCalconnect_Click(object sender, EventArgs e)
        {
            WaitWindow.Show(this.calWellConnectWorkerMethod);
        }

        private void 动态计算ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WaitWindow.Show(this.calDynamicWorkerMethod);
        }

        private void 计算ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WaitWindow.Show(this.calWellConnectWorkerMethod);
        }

        private void 调整ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSettingSplitFactor form = new FormSettingSplitFactor();
            form.Show();
        }

        private void tsmiRefresh_Click(object sender, EventArgs e)
        {
            updateMainPanel();
        }

        private void tsmiCalVoro_Click(object sender, EventArgs e)
        {
            cIOVoronoi.calVoiAndwrite2File();
        }

        private void tsmiSectionSingleWell_Click(object sender, EventArgs e)
        {
            FormSectionWell formSingleWell = new FormSectionWell();
            formSingleWell.Show();
        }

        private void tsmiLayerDataImport_Click(object sender, EventArgs e)
        {
            FormDataImportWells frmImportProject = new FormDataImportWells(2);
            frmImportProject.ShowDialog();
        }

        private void tsmiLayerColorSetting_Click(object sender, EventArgs e)
        {
            FormSettingLayerColor newSetting = new FormSettingLayerColor();
            System.Diagnostics.Process.Start("explorer.exe", cProjectManager.dirProject);
            newSetting.ShowDialog();
        }

        private void tsmiPicTool_Click(object sender, EventArgs e)
        {
            FormDigRobot _formDig = new FormDigRobot();
            _formDig.Show();
        }

        private void tsmiLiotho_Click(object sender, EventArgs e)
        {
            FormPatternElement fpe = new FormPatternElement();
            fpe.Show();
        }

        private void tsmiDataPole_Click(object sender, EventArgs e)
        {
            FormDataAnalysis formRoseMap = new FormDataAnalysis();
            formRoseMap.ShowDialog();
        }

        private void tsmiCalAera_Click(object sender, EventArgs e)
        {
            FormCalArea _form = new FormCalArea();
            _form.Show();
        }

        private void 数据处理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDataTableDeal _form = new FormDataTableDeal();
            _form.Show();
        }

        private void tsmiVersion_Click(object sender, EventArgs e)
        {
            FormCopyRight formCP = new FormCopyRight();
            formCP.ShowDialog();
        }

        private void configToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //copy 文件到 调试文件夹
            string dirApp=AppDomain.CurrentDomain.BaseDirectory;
            int indexChar = dirApp.IndexOf("DOG_Platform");
            string dirPath =   dirApp.Substring(0,indexChar);
            string dirPathHtml = dirPath+"html";
            cPublicMethodBase.DirectoryCopy(dirPathHtml, dirApp + "//html", true);
            string dirPathScript = dirPath + "Script";
            cPublicMethodBase.DirectoryCopy(dirPathScript, dirApp + "//Script", true);
            string dirPathPattern = dirPath + "pattern";
            cPublicMethodBase.DirectoryCopy(dirPathPattern, dirApp + "//Pattern", true);
            string dirPathCode = dirPath + "code";
            cPublicMethodBase.DirectoryCopy(dirPathCode, dirApp + "//code", true);
            string dirPathLib = dirPath + "lib";
            cPublicMethodBase.DirectoryCopy(dirPathLib, dirApp + "//lib", true);
            cProjectManager.initialCodeList();
            MessageBox.Show("配置文件导入完成。");
        }

        private void tvProjectData_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode selectNode = this.tvProjectData.SelectedNode;
            if (selectNode != null)
            {
               
                if (selectNode.Level == 2 && selectNode.Tag.ToString() == TypeProjectNode.layerMap.ToString())
                {
                    string sLayer = selectNode.Parent.Name;
                    string filePathOper = Path.Combine(cProjectManager.dirPathLayerDir, sLayer, sLayer + cProjectManager.fileExtensionLayerMap);
                    FormMapLayer newSection = new FormMapLayer(filePathOper);
                    newSection.Show();
                } //end
                else if (selectNode.Level == 1 && selectNode.Tag.ToString() == TypeProjectNode.sectionGeo.ToString())
                {
                   
                }
                else if (selectNode.Level == 1 && selectNode.Tag.ToString() == TypeProjectNode.sectionFence.ToString())
                {
                   
                }
                else if (selectNode.Level == 1 && selectNode.Tag.ToString() == TypeProjectNode.calResultText.ToString()) 
                {
                    filepathTableData = Path.Combine(cProjectManager.dirPathUsedProjectData, selectNode.Text + ".txt");
                    Cursor.Current = Cursors.WaitCursor;
                    tbcMain.SelectedTab = tbgMainTable;
                    tbgMainTable.Text = selectNode.Text;
                    this.updateDatable();
                    Cursor.Current = Cursors.Default;
                }
                else if (selectNode.Level >= 1 && selectNode.Tag.ToString() == TypeProjectNode.svgMap.ToString())
                {
                    filePathWebSVG = Path.Combine(cProjectManager.dirPathMap, getSelectSVGGraphtNodePath(selectNode) + ".svg");
                    updateWebSVG();
                }
            }
        }

        string getSelectSVGGraphtNodePath(TreeNode selectNode) 
        {
            string curfilePath = selectNode.Text ;
            TreeNode parentNode = selectNode.Parent;
            while (parentNode.Level >= 1)
            {
                curfilePath = Path.Combine(parentNode.Text, curfilePath);
                parentNode = parentNode.Parent;
            }
            return curfilePath;
        }

        private void tsmiSelectAllWells_Click(object sender, EventArgs e)
        {
            foreach (TreeNode tn in this.tvProjectData.Nodes) tn.Checked = true;
        }

        private void tsmiUnSelectAllWells_Click(object sender, EventArgs e)
        {
            foreach (TreeNode tn in tvProjectData.Nodes) tn.Checked = false;
        }

        private void tsmiColapseAll_Click(object sender, EventArgs e)
        {
            tvProjectData.CollapseAll();
        }

        private void tsmiExpandAll_Click(object sender, EventArgs e)
        {
            this.tvProjectData.ExpandAll();
        }

        private void 井数据输入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDataImportWells frmImportProject = new FormDataImportWells(1);
            frmImportProject.ShowDialog();
            cProjectData.setProjectWellsInfor();
        }

        private void 导出数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            if(result==DialogResult.OK){
            string[] files = Directory.GetFiles(fbd.SelectedPath);

            foreach (string svgFile in files)
            {
                XDocument doc = XDocument.Load(svgFile);
                XNamespace xn = "http://www.w3.org/2000/svg";
                var defNode = doc.Descendants(xn + "defs").FirstOrDefault();
                var node = doc.Descendants(xn + "path").FirstOrDefault();
                XElement lithoPattern = new XElement(xn + "pattern");
                lithoPattern.SetAttributeValue("width", "1");
                lithoPattern.SetAttributeValue("height", "1");
                lithoPattern.SetAttributeValue("id", Path.GetFileNameWithoutExtension(svgFile));
                lithoPattern.SetAttributeValue("patternContentUnits", "objectBoundingBox");
                var newNode = new XElement(node);
                lithoPattern.Add(newNode);
                if (defNode != null)
                {
                    defNode.Add(lithoPattern);
                    doc.Save(svgFile);
                }
            } 
            MessageBox.Show("转换成功");
            }
        }

        private void tsmiSVGedit_Click(object sender, EventArgs e)
        {
            if (filePathWebSVG.EndsWith(".svg"))
                cCallInkscape.callInk(filePathWebSVG);
        }

        private void 窗口打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (filePathWebSVG.EndsWith(".svg"))
            {
                FormWebNavigation formSVGView = new FormWebNavigation(filePathWebSVG);
                formSVGView.Show();
            }
        }

        private void 导出多井曲线ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("请勾选所有需要导出的井号，勾选全局测井中需要导出的曲线 ", "批量导出曲线", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                FolderBrowserDialog folderDlg = new FolderBrowserDialog();
                folderDlg.ShowDialog();
                FormMain.ltSelectedLongName_tvProject.Insert(0, "DEPTH");
                foreach (string _sJH in FormMain.ltSelectedJH_tvProject)
                {
                    string _saveLogFilePath = Path.Combine(folderDlg.SelectedPath, _sJH + ".txt");
                    cIOinputLog.selectLogSeriresFromProjectWellLog(_sJH, FormMain.ltSelectedLongName_tvProject, _saveLogFilePath);
                    MessageBox.Show(_sJH + "导出完成。");
                }
            }
        }

        private void tsmiWellInfor_Click(object sender, EventArgs e)
        {
            TreeNode tnSelect = tvProjectData.SelectedNode;
            string sJH = tnSelect.Text;
            FormWellInfor form = new FormWellInfor(sJH);
            form.ShowDialog();
        }

        private void tsmiWellData_Click(object sender, EventArgs e)
        {
            TreeNode tnSelect = tvProjectData.SelectedNode;
            string sJH = tnSelect.Text;
            FormDataViewProjectSingleWell formDataView = new FormDataViewProjectSingleWell(sJH);
            formDataView.Show();
        }

        private void tsmiDeleteWell_Click(object sender, EventArgs e)
        {
            TreeNode tnSelect = tvProjectData.SelectedNode;
            string sJH = tnSelect.Text;
            cProjectManager.delWellFromProject(sJH);
            tnSelect.Remove();
        }

        private void tsmiLogdataInput_Click(object sender, EventArgs e)
        {
            TreeNode tnSelected = tvProjectData.SelectedNode;
            string sJH = tnSelected.Parent.Text;
            FormDataImportLog frmImportLog = new FormDataImportLog(sJH);
            if (frmImportLog.ShowDialog() == DialogResult.OK)
                TreeViewProjectData.updateTNwellLogDir(tnSelected);
        }

        private void tsmiDeleAllLog_Click(object sender, EventArgs e)
        {
            TreeNode tnSelect = tvProjectData.SelectedNode;
            string sJH = tnSelect.Parent.Text;
            DialogResult dialogResult = MessageBox.Show("注意：此操作不可恢复，确认删除本井全部曲线？", "提示", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string _wellDir = Path.Combine(cProjectManager.dirPathWellDir, sJH);
                foreach (string _item in Directory.GetFiles(_wellDir, "*" + cProjectManager.fileExtensionWellLog)) File.Delete(_item);
                tnSelect.Nodes.Clear();
            }
        }

        private void tsmiExportAllLog_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("请勾选所有需要导出的井号，勾选全局测井中需要导出的曲线 ", "批量导出曲线", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                FolderBrowserDialog folderDlg = new FolderBrowserDialog();
                folderDlg.ShowDialog();
                FormMain.ltSelectedLongName_tvProject.Insert(0, "DEPTH");
                foreach (string _sJH in FormMain.ltSelectedJH_tvProject)
                {
                    string _saveLogFilePath = Path.Combine(folderDlg.SelectedPath, _sJH + ".txt");
                    cIOinputLog.selectLogSeriresFromProjectWellLog(_sJH, FormMain.ltSelectedLongName_tvProject, _saveLogFilePath);
                    MessageBox.Show(_sJH + "导出完成。");
                }
            }
        }

        private void 导出曲线ToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void tsmiExportWellLog_Click(object sender, EventArgs e)
        {
            TreeNode tnSelect = tvProjectData.SelectedNode;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                cIOinputLog.exportTextLog(tnSelect.Parent.Text, saveFileDialog1.FileName);
                MessageBox.Show("导出曲线完成。");
            }
        }

        private void tsmiLogItemDel_Click(object sender, EventArgs e)
        {
            TreeNode tnSelected = tvProjectData.SelectedNode;
            string sJH = tnSelected.Parent.Parent.Text;
            DialogResult dialogResult = MessageBox.Show("当前曲线：" + tnSelected.Text + "，确认删除？", "提示", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string filePath = Path.Combine(cProjectManager.dirPathWellDir, sJH, tnSelected.Text + cProjectManager.fileExtensionWellLog);
                File.Delete(filePath);
                tnSelected.Remove();
            }
        }

        private void tsmiLogItemData_Click(object sender, EventArgs e)
        {
            TreeNode tnSelected = tvProjectData.SelectedNode;
            string sJH = tnSelected.Parent.Parent.Text;
            string filePath = Path.Combine(cProjectManager.dirPathWellDir, sJH, tnSelected.Text + cProjectManager.fileExtensionWellLog);
            System.Diagnostics.Process.Start("notepad.exe", filePath);
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            TreeNode tnSelected = tvProjectData.SelectedNode;
            string _filename = getSelectSVGGraphtNodePath(tnSelected) + ".svg";
            string svgfilepath = Path.Combine(cProjectManager.dirPathMap, _filename);
            if (File.Exists(svgfilepath))
            {
                DialogResult dialogResult = MessageBox.Show(_filename + " 确认删除？", "删除文件", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    this.webBrowserIE.Navigate("about:blank");
                    File.Delete(svgfilepath);
                    tnSelected.Remove();
                }
            }
        }

        private void tsmiGraphRename_Click(object sender, EventArgs e)
        {
            TreeNode tnSelected = tvProjectData.SelectedNode;
            string subFileName = getSelectSVGGraphtNodePath(tnSelected);
             //原分层方案的数据将出清
            FormInputBox inputBox = new FormInputBox("新文件名：", "请输入：",tnSelected.Text);
            var result = inputBox.ShowDialog();
            if (result == DialogResult.OK)
            {
                string newInputFileName = inputBox.ReturnValueStr;
                string filepath = Path.Combine(cProjectManager.dirPathMap, subFileName);
                string newfilepath = filepath.Replace(tnSelected.Text,newInputFileName);
                bool bDelete = cPublicMethodForm.checkRenameSameFile(newfilepath);
                if (bDelete == true)
                {
                    File.Copy(filepath + ".svg", newfilepath + ".svg");
                    File.Delete(filepath);
                    TreeNode tnNew = TreeViewProjectData.setupTNsvgMapItem(tnSelected.Parent, newInputFileName);
                    tnSelected.Remove();
                    tnNew.TreeView.SelectedNode = tnNew;
                    filePathWebSVG = Path.Combine(cProjectManager.dirPathMap, newfilepath + ".svg");
                    updateWebSVG();
                }
            }
        }

        private void tsmiGraphCopy_Click(object sender, EventArgs e)
        {
            TreeNode tnSelected = tvProjectData.SelectedNode;
            string subFileName = getSelectSVGGraphtNodePath(tnSelected);
            string filepath = Path.Combine(cProjectManager.dirPathMap, subFileName);
            string newfilepath = Path.Combine(cProjectManager.dirPathMap, subFileName + "copy");
            File.Copy(filepath+".svg", newfilepath+".svg");
            TreeViewProjectData.setupTNsvgMapItem(tnSelected.Parent, tnSelected.Text + "copy");
        }

        private void tsmiSectionCopy_Click(object sender, EventArgs e)
        {
            TreeNode tnSelected = tvProjectData.SelectedNode;
            string _filename = tnSelected.Text + cProjectManager.fileExtensionSectionWell;
            string filepath = Path.Combine(cProjectManager.dirPathUsedProjectData, _filename);
            string newfilepath = Path.Combine(cProjectManager.dirPathUsedProjectData, tnSelected.Text + "copy" + cProjectManager.fileExtensionSectionWell);
            File.Copy(filepath, newfilepath);
            TreeViewProjectData.setupTNgraphWellSectionItem(tnSelected.Parent, tnSelected.Text + "copy");
        }

        private void tsmiSectionDel_Click(object sender, EventArgs e)
        {
            deleteFileFromDirProjectDataByTreeNodeText(cProjectManager.dirPathUsedProjectData, cProjectManager.fileExtensionSectionWell);
        }


        private void tsmiSectionWellRename_Click(object sender, EventArgs e)
        {
            TreeNode tnSelected = tvProjectData.SelectedNode;
            //原分层方案的数据将出清
            FormInputBox inputBox = new FormInputBox("新文件名：", "请输入：", tnSelected.Text);
            var result = inputBox.ShowDialog();
            if (result == DialogResult.OK)
            {
                string newInputFileName = inputBox.ReturnValueStr;
                string filepath = Path.Combine(cProjectManager.dirPathUsedProjectData, tnSelected.Text + cProjectManager.fileExtensionSectionWell);
                string newfilepath = Path.Combine(cProjectManager.dirPathUsedProjectData, newInputFileName + cProjectManager.fileExtensionSectionWell);
                bool bDelete = cPublicMethodForm.checkRenameSameFile(newfilepath);
                if (bDelete == true)
                {
                    File.Copy(filepath, newfilepath, bDelete);
                    File.Delete(filepath);
                    TreeNode tnNew =  TreeViewProjectData.setupTNgraphWellSectionItem(tnSelected.Parent, newInputFileName);
                    tnSelected.Remove();
                    tnNew.TreeView.SelectedNode = tnNew;
                }
            }
        }

        private void tsmiSectionGeoDel_Click(object sender, EventArgs e)
        {
            deleteFileFromDirProjectDataByTreeNodeText( cProjectManager.dirPathUsedProjectData, cProjectManager.fileExtensionSectionGeo);
        }

        private void 全局设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sLogID = tvProjectData.SelectedNode.Text;
            FormSetGlobleLog newSet = new FormSetGlobleLog(sLogID);
            newSet.ShowDialog();
        }

        private void tsmiSectionGeoRename_Click(object sender, EventArgs e)
        {
            TreeNode tnSelected = tvProjectData.SelectedNode;
            string originalFileName = tnSelected.Text;
            string originalFilePath = Path.Combine(cProjectManager.dirPathUsedProjectData, originalFileName + cProjectManager.fileExtensionSectionGeo);
            string originalDir = Path.Combine(cProjectManager.dirPathUsedProjectData, originalFileName);
            FormInputBox inputBox = new FormInputBox("新文件名：", "请输入：", originalFileName);
            var result = inputBox.ShowDialog();
            if (result == DialogResult.OK)
            {
                string newInputFileName = inputBox.ReturnValueStr;
                string newfilepath = originalFilePath.Replace(originalFileName, newInputFileName);
                File.Copy(originalFilePath, newfilepath); 
                cPublicMethodBase.DirectoryCopy(originalDir, Path.Combine(cProjectManager.dirPathUsedProjectData, newInputFileName), true);
                File.Delete(originalFilePath);
                if (Directory.Exists(originalDir)) Directory.Delete(originalDir, true);
                TreeNode tnNew = TreeViewProjectData.setupTNSectionGeoItem(tnSelected.Parent, newInputFileName);
                tnSelected.Remove(); 
                tnNew.TreeView.SelectedNode = tnNew; 
            }
        }
        void deleteFileAndRemoveTreeNode(TreeNode tnSelected, string filepathDel, string dirpathDel) 
        {
            File.Delete(filepathDel);
            if (Directory.Exists(dirpathDel)) Directory.Delete(dirpathDel, true);
            tnSelected.Remove(); 
        }

        void deleteFileFromDirProjectDataByTreeNodeText(string dir,string fileExtensionName) 
        {
            TreeNode tnSelected = tvProjectData.SelectedNode;
            string filepathDel = Path.Combine(dir, tnSelected.Text + fileExtensionName);
            string dirpathDel = Path.Combine(dir, tnSelected.Text);
            if (File.Exists(filepathDel))
            {
                DialogResult dialogResult = MessageBox.Show(tnSelected.Text + " 确认删除？", "删除文件", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes) deleteFileAndRemoveTreeNode(tnSelected, filepathDel, dirpathDel);
            }
        }

        private void tsmiSectionFenceDel_Click(object sender, EventArgs e)
        {
            deleteFileFromDirProjectDataByTreeNodeText(cProjectManager.dirPathUsedProjectData,cProjectManager.fileExtensionSectionFence); 
        }

              private void calFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormFunctionCal newFunction = new FormFunctionCal();
            newFunction.Show();
        }

        private void tsmiLogItemCal_Click(object sender, EventArgs e)
        {
            TreeNode tnSelected = tvProjectData.SelectedNode;
            string sJH = tnSelected.Parent.Text;
            FormLogEditor newEditor = new FormLogEditor(sJH);
            newEditor.Show();
        }

        private void eclipseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormEclipsePaser newEcl = new FormEclipsePaser();
            newEcl.Show();
        }

        private void tsmiLogItemRename_Click(object sender, EventArgs e)
        {
            TreeNode tnSelected = tvProjectData.SelectedNode;
            string sJH = tnSelected.Parent.Parent.Text;
            string filePath = Path.Combine(cProjectManager.dirPathWellDir, sJH, tnSelected.Text + cProjectManager.fileExtensionWellLog);
            FormInputBox inputBox = new FormInputBox("新名称：", "请输入：", tnSelected.Text);
            var result = inputBox.ShowDialog();
            if (result == DialogResult.OK)
            {
                string newInputFileName = inputBox.ReturnValueStr;
                string newfilepath = Path.Combine(cProjectManager.dirPathWellDir, sJH, newInputFileName + cProjectManager.fileExtensionWellLog);
                bool bDelete = cPublicMethodForm.checkRenameSameFile(newfilepath);
                if (bDelete == true)
                {
                    File.Copy(filePath, newfilepath, bDelete); //用新文件名保存，
                    File.Delete(filePath);  //删除原文件
                    TreeNode tnNew = TreeViewProjectData.setupTNLogItem(tnSelected.Parent, newInputFileName);
                    tnSelected.Remove();
                    tnNew.TreeView.SelectedNode = tnNew;
                }
            }
        }

     

        private void tsmiSetProject_Click(object sender, EventArgs e)
        {
            FormProjectInfor newProject = new FormProjectInfor();
            newProject.ShowDialog();
        }

        private void 文件管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormFileManagerGeo newFileManager = new FormFileManagerGeo();
            newFileManager.Show();
        }

        private void FormMain_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void FormMain_DragDrop(object sender, DragEventArgs e)
        {
            string[] fileList = e.Data.GetData(DataFormats.FileDrop) as string[];
            //get all files inside folder     
            foreach (string filePath in fileList)
            {
                if (filePath.EndsWith(".xl")) { openExistProject(filePath); break; } 
            }
           
        }

        private void tsbtnFileDataManager_Click(object sender, EventArgs e)
        {
            FormFileManagerGeo newFileManager = new FormFileManagerGeo();
            newFileManager.Show();
        }


        private void tsmiMakeWellSection_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            TreeNode tnSelect = tvProjectData.SelectedNode;
            //在选中的井号内循环。
            if(tnSelect!=null && tnSelect.Tag.ToString()==TypeProjectNode.wells.ToString())
            {
                FormSectAddNewWell formNew = new FormSectAddNewWell(1); //与单井剖面新建区分开
                var result = formNew.ShowDialog();
                if (result == DialogResult.OK)
                {
                    foreach (TreeNode tn in tnSelect.Nodes)
                    {
                        if (tn.Level == 1 && tn.Checked == true && tn.Tag.ToString() == TypeProjectNode.well.ToString())
                        {
                            string sCurrentJH = tn.Name;

                            string filePathOper = Path.Combine(cProjectManager.dirPathWellDir, sCurrentJH, sCurrentJH + cProjectManager.fileExtensionSectionWell);
                            string xtlFileName = formNew.ReturnFileNameXMT;
                            bool bNew = true;
                            if (File.Exists(filePathOper))
                            {
                                DialogResult dialogResult = MessageBox.Show("是否新建并覆盖？", sCurrentJH + "单井综合图已存在", MessageBoxButtons.YesNo);
                                if (dialogResult == DialogResult.No) bNew = false;
                            }
                            if (bNew == true)
                            {
                                string xtmPath = Path.Combine(cProjectManager.dirPathTemplate, xtlFileName);
                                cIOtemplate.copyTemplate(xtmPath, filePathOper, sCurrentJH);
                                this.tsslableProjectInfor.Text = sCurrentJH + "单井剖面创建完成";
                            }
                        } //end if 判断是否井号节点 
                    } //end foreach node 循环

                    updateTreeViewProject();
                }//end if 打开模板
            }

            this.tsslableProjectInfor.Text = "单井剖面创建完成";
            Cursor.Current = Cursors.Default;
        }

        private void tsmiOpenFileDir_Click(object sender, EventArgs e)
        {
            if (filePathWebSVG.EndsWith(".svg"))
            {
                string dirSVG = Path.GetDirectoryName(filePathWebSVG);
                System.Diagnostics.Process.Start(dirSVG);
            }
        }

        private void tsmiSectionGeoCopy_Click(object sender, EventArgs e)
        {
            TreeNode tnSelected = tvProjectData.SelectedNode;
            string originalFileName = tnSelected.Text;
            string originalFilePath = Path.Combine(cProjectManager.dirPathUsedProjectData, originalFileName + cProjectManager.fileExtensionSectionGeo);
            string originalDir = Path.Combine(cProjectManager.dirPathUsedProjectData, originalFileName);

            string newfilepath = Path.Combine(cProjectManager.dirPathUsedProjectData, originalFileName + "copy" + cProjectManager.fileExtensionSectionGeo);
            string newDir = Path.Combine(cProjectManager.dirPathUsedProjectData, originalFileName + "copy"); 
            File.Copy(originalFilePath, newfilepath);
            cPublicMethodBase.DirectoryCopy(originalDir, newDir, true);
            TreeNode tnNew = TreeViewProjectData.setupTNSectionGeoItem(tnSelected.Parent, originalFileName + "copy");
            tnNew.TreeView.SelectedNode = tnNew; 
        }

        private void tsmiGraphEdit_Click(object sender, EventArgs e)
        {
            TreeNode tnSelected = tvProjectData.SelectedNode;
            string _filename = getSelectSVGGraphtNodePath(tnSelected) + ".svg";
            string svgfilepath = Path.Combine(cProjectManager.dirPathMap, _filename);
            if (File.Exists(svgfilepath)) cCallInkscape.callInk(svgfilepath);
        }

        private void tsmiSectionWellOpen_Click(object sender, EventArgs e)
        {
            TreeNode tnSelected = tvProjectData.SelectedNode;
            string sJH = tnSelected.Parent.Name;
            string filePathOper = Path.Combine(cProjectManager.dirPathWellDir, sJH, sJH + cProjectManager.fileExtensionSectionWell);
            if (tnSelected.Parent.Tag.ToString() == TypeProjectNode.sectionWellDir.ToString())
                filePathOper = Path.Combine(cProjectManager.dirPathUsedProjectData, tnSelected.Name + cProjectManager.fileExtensionSectionWell);
            FormSectionWell newSection = new FormSectionWell(filePathOper);
            newSection.Show(); 
        }

        private void tsmiDataSectionWellChildItemImport_Click(object sender, EventArgs e)
        {
            TreeNode currentNode = tvProjectData.SelectedNode;
            if (currentNode != null)
            {
                string sJHSelected = currentNode.Parent.Parent.Text;
                string filePathOper = Path.Combine(cProjectManager.dirPathWellDir, sJHSelected, sJHSelected + cProjectManager.fileExtensionSectionWell);
                if (sJHSelected != "")
                {
                    string typeTrackstr = currentNode.Tag.ToString();
                    string sTrackID = currentNode.Name;
                    FormDataImportWell formInputDataTableSingleWell = new
                          FormDataImportWell(sJHSelected, typeTrackstr, filePathOper, sTrackID);
                    formInputDataTableSingleWell.ShowDialog();
                }
            }

        }

        private void tsmiSectionSingleOpen_Click(object sender, EventArgs e)
        {
            TreeNode tnSelected = tvProjectData.SelectedNode;
            if (tnSelected != null)
            {
                string filePathOper = Path.Combine(cProjectManager.dirPathUsedProjectData, tnSelected.Text + cProjectManager.fileExtensionSectionWell);
                FormSectionWell newSection = new FormSectionWell(filePathOper);
                newSection.Show();
            }
        }

        private void tsmiSectionGeoOpen_Click(object sender, EventArgs e)
        {
            TreeNode tnSelected = tvProjectData.SelectedNode;
            string fileName = tnSelected.Text;
            string filePathOper = Path.Combine(cProjectManager.dirPathUsedProjectData, fileName + cProjectManager.fileExtensionSectionGeo);
            FormSectionGeo newSection = new FormSectionGeo(filePathOper);
            newSection.Show();
        }

        private void tsmiOpenAppSectionGeo_Click(object sender, EventArgs e)
        {
            FormSectionGeo FormWellsGroup = new FormSectionGeo();
            FormWellsGroup.Show();
        }

        private void tsmiOpenAppSectionFence_Click(object sender, EventArgs e)
        {
            FormSectionGroup formFD = new FormSectionGroup();
            formFD.Show();
        }

        private void tsmiSectionFenceOpen_Click(object sender, EventArgs e)
        {
            TreeNode tnSelected = tvProjectData.SelectedNode;
            string fileName = tnSelected.Text;
            string filePathOper = Path.Combine(cProjectManager.dirPathUsedProjectData, fileName + cProjectManager.fileExtensionSectionFence);
            FormSectionGroup newSection = new FormSectionGroup(filePathOper);
            newSection.Show();
        }

        private void tsmiSectionFenceRename_Click(object sender, EventArgs e)
        {
            TreeNode tnSelected = tvProjectData.SelectedNode;
            string originalFileName = tnSelected.Text;
            string originalFilePath = Path.Combine(cProjectManager.dirPathUsedProjectData, originalFileName + cProjectManager.fileExtensionSectionFence);
            string originalDir = Path.Combine(cProjectManager.dirPathUsedProjectData, originalFileName);
            FormInputBox inputBox = new FormInputBox("新文件名：", "请输入：", originalFileName);
            var result = inputBox.ShowDialog();
            if (result == DialogResult.OK)
            {
                string newInputFileName = inputBox.ReturnValueStr;
                string newfilepath = originalFilePath.Replace(originalFileName, newInputFileName);
                File.Copy(originalFilePath, newfilepath);
                cPublicMethodBase.DirectoryCopy(originalDir, Path.Combine(cProjectManager.dirPathUsedProjectData, newInputFileName), true);
                File.Delete(originalFilePath);
                if (Directory.Exists(originalDir)) Directory.Delete(originalDir, true);
                TreeNode tnNew = TreeViewProjectData.setupTNSectionFenceItem(tnSelected.Parent, newInputFileName);
                tnSelected.Remove();
                tnNew.TreeView.SelectedNode = tnNew;
            }
        }

        private void tsmiSectionFenceCopy_Click(object sender, EventArgs e)
        {
            TreeNode tnSelected = tvProjectData.SelectedNode;
            string originalFileName = tnSelected.Text;
            string originalFilePath = Path.Combine(cProjectManager.dirPathUsedProjectData, originalFileName + cProjectManager.fileExtensionSectionFence);
            string originalDir = Path.Combine(cProjectManager.dirPathUsedProjectData, originalFileName);

            string newfilepath = Path.Combine(cProjectManager.dirPathUsedProjectData, originalFileName + "copy" + cProjectManager.fileExtensionSectionFence);
            string newDir = Path.Combine(cProjectManager.dirPathUsedProjectData, originalFileName + "copy");
            File.Copy(originalFilePath, newfilepath);
            cPublicMethodBase.DirectoryCopy(originalDir, newDir, true);
            TreeNode tnNew = TreeViewProjectData.setupTNSectionFenceItem(tnSelected.Parent, originalFileName + "copy");
            tnNew.TreeView.SelectedNode = tnNew; 
        }

        private void FormMain_HelpButtonClicked(object sender, CancelEventArgs e)
        {

        }

        private void tsmiGlobeRenameLogName_Click(object sender, EventArgs e)
        {
            TreeNode tnSelected = tvProjectData.SelectedNode;
            FormInputBox inputBox = new FormInputBox("注意：本操作不可逆！", "新名称请输入：", tnSelected.Text);
            string strLogItem = tnSelected.Text;

            var result = inputBox.ShowDialog();
            if (result == DialogResult.OK)
            {
                cProjectData.ltStrProjectGlobeLog.Remove(strLogItem);
                Cursor.Current = Cursors.WaitCursor;
                foreach (string sCurrentJH in cProjectData.ltStrProjectJH)
                {
                    string filePath = Path.Combine(cProjectManager.dirPathWellDir, sCurrentJH, strLogItem + cProjectManager.fileExtensionWellLog);
                    string newInputStrLogItem = inputBox.ReturnValueStr;
                    string newfilepath = Path.Combine(cProjectManager.dirPathWellDir, sCurrentJH, newInputStrLogItem + cProjectManager.fileExtensionWellLog);
                    bool bDelete = true;
                    if (File.Exists(filePath))
                    {
                        if (File.Exists(newfilepath)) //需要判断新文件是否存在
                        {
                            DialogResult dialogResult = MessageBox.Show(" 是否覆盖？", sCurrentJH + " 同名曲线 " + newInputStrLogItem + " 已存在", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.No) bDelete = false;
                        }
                        if (bDelete == true)
                        {
                            File.Copy(filePath, newfilepath, bDelete); //用新文件名保存，
                            File.Delete(filePath);  //删除原文件
                        }
                    } 
                } 
  
                updateTreeViewProject();
                Cursor.Current = Cursors.Default;
            }
        }

        private void tsmiGlobeDeleteLogFile_Click(object sender, EventArgs e)
        {
            TreeNode tnSelected = tvProjectData.SelectedNode;
            DialogResult dialogResult = MessageBox.Show("当前操作确认将删除所有井的同名曲线，且不可恢复？", "删除曲线 " + tnSelected, MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                foreach (string sJH in cProjectData.ltStrProjectJH)
                {
                    string filePath = Path.Combine(cProjectManager.dirPathWellDir, sJH, tnSelected.Text + cProjectManager.fileExtensionWellLog);
                    if (File.Exists(filePath)) File.Delete(filePath);  //删除原文件
                }
                //从字典中删除
                List<ItemDicLogGlobe> logHeadRet = cIODicLogHeadProject.readDicGlobeLog();
                ItemDicLogGlobe item = logHeadRet.FirstOrDefault(p => p.sLogID == tnSelected.Text);
                if (item != null)
                {
                    logHeadRet.Remove(item);
                    cIODicLogHeadProject.writeDicGlobe(logHeadRet);
                }
                tnSelected.Remove();
            }
            MessageBox.Show("删除完成");
        }

        private void cmsTNglobalLog_Opening(object sender, CancelEventArgs e)
        {

        }

        private void tsmiWellSectionMake_Click(object sender, EventArgs e)
        {
            FormSectionWell formSingleWell = new FormSectionWell();
            formSingleWell.Show();
        }

        private void tsmiGlobeLogExport_Click(object sender, EventArgs e)
        {
            TreeNode tnSelected = tvProjectData.SelectedNode;
            string sLogName = tnSelected.Text;
            FolderBrowserDialog brwsr = new FolderBrowserDialog();

            //Check to see if the user clicked the cancel button
            if (brwsr.ShowDialog() == DialogResult.Cancel)
                return;
            else
            {
                string dirSelect = brwsr.SelectedPath;
                //Do whatever with the new path
                foreach (string sJH in cProjectData.ltStrProjectJH)
                {
                    string filePath = Path.Combine(cProjectManager.dirPathWellDir, sJH, sLogName + cProjectManager.fileExtensionWellLog);
                    string newFilePath = Path.Combine(dirSelect, sJH + "_" + sLogName + ".txt");
                    if (File.Exists(filePath)) File.Copy(filePath,newFilePath,true);  
                }
            }//end else
            MessageBox.Show("导出完成");
        }

        private void tsmiItemLayerDelete_Click(object sender, EventArgs e)
        {
            TreeNode tnSelected = tvProjectData.SelectedNode;
            string sXCM = tnSelected.Parent.Text;
            DialogResult dialogResult = MessageBox.Show("当前操作确认将不可恢复？", "删除小层平面图: " + sXCM, MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string filePath = Path.Combine(cProjectManager.dirPathLayerDir, sXCM, sXCM + ".xml");
                if (File.Exists(filePath)) File.Delete(filePath);
                tnSelected.Remove();
            }
            MessageBox.Show("删除完成");
        }

        private void tscbbScale_Click(object sender, EventArgs e)
        {

        }

        private void tsmiGraphOpenDir_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", cProjectManager.dirPathMap);
        }

        private void tsmiExportLayerDepth_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "文本|*.txt|其它|*.*";
            saveFileDialog1.Title = "保存分层顶底深数据";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);

                foreach (string sJH in cProjectData.ltStrProjectJH)
                {
                    string filePath = Path.Combine(cProjectManager.dirPathWellDir, sJH, "#layerDepth#");
                    if (File.Exists(filePath)) 
                    {
                        StreamReader sr = File.OpenText(filePath);
                        string nextLine;
                        int lineIndex = 0;
                        int startLine = 6;
                        while ((nextLine = sr.ReadLine()) != null)
                        {
                            lineIndex++;
                            if (lineIndex == 2) startLine =2+ int.Parse( nextLine.Trim());
                            else if (lineIndex > startLine)
                            {
                                sw.WriteLine(nextLine);
                            }
                        }
                        sr.Close();
                    }
                } //end foreach
                sw.Close();
            MessageBox.Show("导出完成");
            }
        } 
     
    }
}
