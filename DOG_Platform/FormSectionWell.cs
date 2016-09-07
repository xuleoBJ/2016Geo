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
using System.Configuration;
using System.Diagnostics;

namespace DOGPlatform
{   
    /// <summary>
    ///  绘制单井的地质分析图,成图的方法 样式+数据。
    ///  1 选择井号,创建模板，或者通过选择模板，自动生成。
    ///  3 选择绘制图道类型,增加道只增加空道，不增加数据
    ///  4 从数据库提取数据
    ///  5 点增加图道按钮时，同时确定style和data，从dgv读取数据。需要修改成一个xml文件，同时存样式和数据。保存模板时，修改即可。样式和数据不分离。数据可以从数据库中选 也可以从外部输入。
    ///  6 关于道头显示需要考虑
    ///  7 一开始保存全部数据，绘制时按绘制深度提取显示。
    ///  8 按深度段解析生成图。
    /// </summary>
    public partial class FormSectionWell : Form
    {
        static Point scrollPoint = new Point(0, 0);
        private Stack<string> UndoList = new Stack<string>();
        private Stack<string> RedoList = new Stack<string>();
        private string dirHisUnto = cProjectManager.dirPathHis;

        static bool bRefreshNow = true ;

        double fVscale = 1000 / 500;  //默认是用1：500比例尺 //是用sunit单位换算过的

        //初始化redo
        string sJHSelected = "";  //井号从新建窗口读入,井号可以是new 代表一个新文档。
        double dfDS1Show = 0;   //绘制的顶深
        double dfDS2Show = 5000;  //绘制的底深
   
        List<int> iListTrackWidth = new List<int>();

        string filePathOper = "";

        string filePathSVG = "";

        public delegate void functioncall(int iMode);

        private event functioncall formFunctionPointer;

        public FormSectionWell()
        {
            InitializeComponent();
            initializeMyControl();
        }

        public FormSectionWell(string inputFilePath):this()
        {
            openExistSectionFlow(inputFilePath);
        }

        public FormSectionWell(string inputFilePath,float fTopShow)
            : this(inputFilePath)
        {
            double fVScale = double.Parse(cXmlBase.getNodeInnerText(inputFilePath, cXEWellPage.fullPathVSacle));
            this.wellPanelMain.PscrollOffset =new Point(0, (int)(fTopShow * fVScale));
        }

        public FormSectionWell(string inputFilePath, float fTopShow, float fBotShow)
            : this()
        {
            //浏览模式不用滚动了 只显示选择的深度段
            //double fVScale = double.Parse(cXmlBase.getNodeInnerText(inputFilePath, cXEWellPage.fullPathVSacle));
            //this.wellPanelMain.PscrollOffset = new Point(0, (int)(fTopShow * fVScale));
            filePathOper = inputFilePath;
            this.tbgViewEdit.Text = Path.GetFileNameWithoutExtension(filePathOper);
            viewMode(fTopShow, fBotShow);
        }
       
        void wellPanelCallRefresh(int iMode)
        {
            if (iMode == 0) updateTVandWB();
            if (iMode == 1) makeNewSVG();
        }

        void initializeMyControl() 
        {
            this.wellPanelMain.tsmiLoadSVG.Visible = false;
            List<string> ltStrTrackType = Enum.GetNames(typeof(TypeTrack)).ToList();
            formFunctionPointer += new functioncall(wellPanelCallRefresh);
            this.wellPanelMain.userFunctionPointer = formFunctionPointer;
            this.splitContainerSection.Panel1Collapsed = true;
            cPublicMethodForm.initialMapScale(tsbcbbVScale);
            tsbcbbVScale.SelectedIndex = 0;
        }

        void filePathOperSetup() 
        {
            if (sJHSelected == "New")
                filePathOper = Path.Combine(cProjectManager.dirPathUsedProjectData, sJHSelected + DateTime.Now.ToString("MMddHHmm") + cProjectManager.fileExtensionSectionWell);
            else
                filePathOper = Path.Combine(cProjectManager.dirPathWellDir, sJHSelected, sJHSelected + cProjectManager.fileExtensionSectionWell);
        }

        void initializeSectionFlow(string xtlFileName)
        {
            Cursor.Current = Cursors.WaitCursor;
            tvSectionEdit.Nodes.Clear();
            iListTrackWidth.Clear();
            filePathOperSetup(); 
            if (xtlFileName == "") creatTemplat();  //未选择模板
            else loadTemplat(xtlFileName);
            Cursor.Current = Cursors.Default;
        }

        void createNewFile()
        {
            FormSectAddNewWell formNew = new FormSectAddNewWell();
            var result = formNew.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.sJHSelected = formNew.ReturnJH;            //values preserved after close
                string xtlFileName = formNew.ReturnFileNameXMT;
                tbgViewEdit.Text = this.sJHSelected;
                filePathOperSetup();
                bool bNew = true;
                if (File.Exists(filePathOper))
                {
                    DialogResult dialogResult = MessageBox.Show("是否新建并覆盖？", this.sJHSelected + "单井剖面已存在", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.No) bNew = false;
                }
                if (bNew == true)
                {
                    initializeSectionFlow(xtlFileName);
                    updateTV();
                    makeNewSVG();
                }
            }
        }

        void creatTemplat()
        {
            ItemWell itemWell = cProjectData.ltProjectWell.SingleOrDefault(p => p.sJH == this.sJHSelected);
            if (itemWell!= null) dfDS2Show = itemWell.fWellBase;
            //建立样式模板
            cXmlDocSectionWell.generateXML(filePathOper, this.sJHSelected, dfDS1Show, dfDS2Show, fVscale); 
            addTrackCss(TypeTrack.深度尺);
        }

        void loadTemplat(string xtlFileName)
        {
            //加载模板
            string xtmPath = Path.Combine(cProjectManager.dirPathTemplate, xtlFileName);
            cIOtemplate.copyTemplate(xtmPath, filePathOper, this.sJHSelected);
            updateTV();
            makeNewSVG();
        }

        void openExistSectionFlow(string pathOpenExsitFile)
        {
            filePathOper = pathOpenExsitFile;
            this.tbgViewEdit.Text = Path.GetFileNameWithoutExtension(filePathOper);
            tvSectionEdit.Nodes.Clear();
            iListTrackWidth.Clear();
            sJHSelected =  cXmlBase.getNodeInnerText(filePathOper, cXmlDocSectionWell.fullPathJH);
            dfDS1Show = double.Parse(cXmlBase.getNodeInnerText(filePathOper, cXEWellPage.fullPathTopDepth));
            dfDS2Show = double.Parse(cXmlBase.getNodeInnerText(filePathOper, cXEWellPage.fullPathBotDepth));
            fVscale = double.Parse(cXmlBase.getNodeInnerText(filePathOper, cXEWellPage.fullPathVSacle));
            updateTV();
            makeNewSVG();
        }

        private void tsmiSelectDel_Click(object sender, EventArgs e)
        {
            if (tvSectionEdit.SelectedNode != null )
                cSectionUIoperate.deleteItemByID(tvSectionEdit.SelectedNode, filePathOper, tvSectionEdit.SelectedNode.Name.ToString());
            makeNewSVG();
        }

        private void 选中道上移ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tvSectionEdit.SelectedNode != null && tvSectionEdit.SelectedNode.Level == 1)
            {
                cSectionUIoperate.selectTrackUp(this.tvSectionEdit, tvSectionEdit.SelectedNode, filePathOper, tvSectionEdit.SelectedNode.Name.ToString());
                makeNewSVG();
            }
        }

        private void 选中道下移ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tvSectionEdit.SelectedNode != null && tvSectionEdit.SelectedNode.Level == 1)
            {
                cSectionUIoperate.selectTrackDown(this.tvSectionEdit, tvSectionEdit.SelectedNode, filePathOper, tvSectionEdit.SelectedNode.Name.ToString());
                makeNewSVG();
            }
        }

        private void tsmiSaveTemplate_Click(object sender, EventArgs e)
        {
            SaveFileDialog modelFileSaveDialog = new SaveFileDialog();
            modelFileSaveDialog.Filter = "模板文件 | *" + cProjectManager.fileExtensionTemplate;
            modelFileSaveDialog.DefaultExt = cProjectManager.fileExtensionTemplate;
            modelFileSaveDialog.InitialDirectory = cProjectManager.dirPathTemplate;
            if (modelFileSaveDialog.ShowDialog()==DialogResult.OK)
            {
                string xtlFilePath = modelFileSaveDialog.FileName;
                File.Copy(this.filePathOper, xtlFilePath, true);
                cXmlDocSectionWell.save2XTM(xtlFilePath);
            }
            
        }

        private void tsmiNew_Click(object sender, EventArgs e)
        {
            createNewFile();
        }

        private void tsBtnNewProject_Click(object sender, EventArgs e)
        {
            createNewFile();
        }
       
        /// <summary>
        ///增加道有2部分，一是增加xml文件
        ///treeview根据xml生成？？？？
        /// </summary>
        /// <param name="trackName"></param>
        /// <param name="eTypeTrack"></param>
        void addTrackCss(TypeTrack eTypeTrack)
        {
            int iTrackWidth = 60;
            if (cProjectManager.ltStrTrackTypeIntervalProperty.IndexOf(eTypeTrack.ToString())>=0) iTrackWidth = 50;
            if (eTypeTrack == TypeTrack.曲线道 || eTypeTrack == TypeTrack.岩性层段) iTrackWidth = 120;
            if(this.wellPanelMain.sIDcurrentTrack!="")
                cXmlDocSectionWell.addTrackCss(filePathOper, this.wellPanelMain.sIDcurrentTrack,eTypeTrack, iTrackWidth);
            else cXmlDocSectionWell.addTrackCss(filePathOper, eTypeTrack, iTrackWidth);
            updateTV();
            makeNewSVG();
        }

        void updateTV()
        {
            if (this.splitContainerSection.Panel1Collapsed == false)
            {
                tvSectionEdit.Nodes.Clear();
                TreeNode tnPage = new TreeNode();
                tnPage.Text = "页面";
                tnPage.Name = "page";  //结点name
                tnPage.Tag = "page";
                TreeViewSectionEditView.setupWellNode(tnPage, this.filePathOper);
                tvSectionEdit.Nodes.Add(tnPage);
                tnPage.Expand();
            }
        }

        private void tsmiInsertLayer_Click(object sender, EventArgs e)
        {
            addTrackCss(TypeTrack.分层);
        }

        private void tsmiInsertDepthRuler_Click(object sender, EventArgs e)
        { 
            addTrackCss(TypeTrack.深度尺);
        }

        private void tsmiInsertText_Click(object sender, EventArgs e)
        {
            addTrackCss(TypeTrack.文本道);
        }

        private void tsmiInsertTrackLog_Click(object sender, EventArgs e)
        {
            addTrackCss(TypeTrack.曲线道);
        }

        private void tsmiInsertLitho_Click(object sender, EventArgs e)
        {
            addTrackCss(TypeTrack.岩性层段); 
        }

        private void tsmiInsert_I_Click(object sender, EventArgs e)
        {
            addTrackCss(TypeTrack.符号);
        }
      
        private void tsmiInsertRatioRect_Click(object sender, EventArgs e)
        {
            addTrackCss(TypeTrack.比例条);
        }
     
        private void tsmiInsertJSJ_Click(object sender, EventArgs e)
        {
            addTrackCss(TypeTrack.测井解释);
        }

        private void tsmiGeologicalCycle_Click(object sender, EventArgs e)
        {
            addTrackCss(TypeTrack.沉积旋回);
        }

        private void tsmiSetting_Click(object sender, EventArgs e)
        {
            TreeNode selectNode = tvSectionEdit.SelectedNode;
            if (selectNode != null && selectNode.Level == 1)
            {
                FormSettingSectionTrack newForm = new FormSettingSectionTrack(this.filePathOper, tvSectionEdit.SelectedNode.Name);
                newForm.ShowDialog();
                makeNewSVG();
            }
        }

        private void tsmiRefresh_Click(object sender, EventArgs e)
        {
            updateTV();
            makeNewSVG();
        }

        private void tsmiAddLog_Click(object sender, EventArgs e)
        {
            TreeNode tn=tvSectionEdit.SelectedNode;
            if (tn.Tag.ToString() == TypeTrack.曲线道.ToString())
            {
                FormSectionAddWellLog formAddLog = new FormSectionAddWellLog(this.sJHSelected);
                if (formAddLog.ShowDialog() == DialogResult.OK)
                {
                    ItemLogHeadInfor logHead = formAddLog.logHeadRet  ;
                    //此处写入配置文件xml,tn.name 是 id
                    cXmlDocSectionWell.addLog(this.filePathOper, tn.Name, logHead);
                }
                updateTV();
                makeNewSVG();
            }
        }

        private void tsmiOpen_Click(object sender, EventArgs e)
        {
            openExist();
        }
       
        void openExist() 
        {
            OpenFileDialog ofdProjectPath = new OpenFileDialog();

            ofdProjectPath.Title = " 打开文件：";
            ofdProjectPath.Filter = string.Format("{0}文件|*{0}",cProjectManager.fileExtensionSectionWell);
            //设置默认文件类型显示顺序 
            ofdProjectPath.FilterIndex = 1;
            //保存对话框是否记忆上次打开的目录 
            ofdProjectPath.RestoreDirectory = true;

            if (ofdProjectPath.ShowDialog() == DialogResult.OK)
            {
                string fileOpen = ofdProjectPath.FileName;
                this.tbgViewEdit.Text = Path.GetFileNameWithoutExtension(fileOpen);
                openExistSectionFlow(fileOpen);
            }
        }

        public void setViewMode() 
        {
            this.menuStripMain.Visible = false;
            this.toolStripSectionWellMain.Visible = false;
        }

        private void tsmiPageSetting_Click(object sender, EventArgs e)
        {
            FormSettingShowState wellShowSetting = new FormSettingShowState(filePathOper);
            wellShowSetting.ShowDialog();
            makeNewSVG();
        }

        private void tsmiShowedDepth_Click(object sender, EventArgs e)
        {
            FormSettingShowState newSet = new FormSettingShowState(this.filePathOper);
            if (newSet.ShowDialog() == DialogResult.OK) makeNewSVG(); 
        }

        void tvSelectInfor(TreeNode tn) 
        {
            if (tn.Level >= 1) tssTVSelectItem.Text = tn.Parent.Text;
            tsslTVlbl.Text = tn.Text;
        }
        private void tvSectionEdit_MouseUp(object sender, MouseEventArgs e)
        {
            TreeNode selectedNode = tvSectionEdit.GetNodeAt(e.X, e.Y);
            tsslTVlbl.Text = "未选中对象";
            if (selectedNode != null)
            {
                tvSelectInfor(selectedNode); 
                //处理是否隐藏
                if (selectedNode.Level > 0) // level 0 是页面
                {
                    int iCheck = 1;
                    if (selectedNode.Checked == false) iCheck = 0;
                    if (selectedNode.Checked == true) iCheck = 1;
                    string sIDtrack = selectedNode.Name;
                    //为了阻止不改变状态就刷新，必须记录原状态
                    int iCurrentVisible = cXmlDocSectionWell.getTrackVisible(this.filePathOper, sIDtrack);
                    if (iCurrentVisible != iCheck) //状态改变
                    {
                        cXmlDocSectionWell.setTrackVisible(this.filePathOper, sIDtrack, iCheck);
                        makeNewSVG();
                    }
                }

                if (selectedNode.Level==1) // level 1 把道Id传给wellPanelMain
                {
                    this.wellPanelMain.sIDcurrentTrack = selectedNode.Name;
                    this.wellPanelMain.ShowMessage("");
                }
                if (selectedNode.Level == 2) // level 1 把道Id传给wellPanelMain
                {
                    this.wellPanelMain.sIDcurrentTrack = selectedNode.Parent.Name;
                    this.wellPanelMain.sIDcurrentItem = selectedNode.Name;
                    this.wellPanelMain.ShowMessage("");
                }
                //右键弹出菜单
                if (e.Button == MouseButtons.Right) controlTVcms(selectedNode); 
                   
            } 
        }
                //右键弹出菜单
        void controlTVcms(TreeNode selectedNode) 
        {
            // Select the clicked node
            foreach (ToolStripMenuItem item in this.cmsTVedit.Items) item.Visible = false;
            if (selectedNode.Level == 0)
            {
                tsmiPageSetting.Visible = true;
            }
            else 
            {
                tsmiTrackSet.Visible = true;
            }
            if (selectedNode.Level == 1)
            {
                tsmiSelectDel.Visible = true;
                tsmiTrackDown.Visible = true;
                tsmiTrackUp.Visible = true;
                tsmiTrackSetting.Visible = true;
                tsmiTrackData.Visible = true;

                if (selectedNode.Tag.ToString() == TypeTrack.曲线道.ToString()) 
                { 
                    tsmiTrackLogSub.Visible = true; 
                    tsmiTrackData.Visible = false;
                }
                if (selectedNode.Tag.ToString() == TypeTrack.测井解释.ToString()
                   || selectedNode.Tag.ToString() == TypeTrack.岩性层段.ToString())
                {
                    tsmiNewItemAdd.Visible = true;
                }

            } 
            if (selectedNode.Level == 2)
            {
                if (selectedNode.Parent.Tag.ToString() == TypeTrack.曲线道.ToString())
                {
                    tsmiTrackData.Visible = true;
                    tsmiTrackLogSub.Visible = true;
                }

                if (selectedNode.Parent.Tag.ToString() == TypeTrack.测井解释.ToString() 
                    || selectedNode.Parent.Tag.ToString() == TypeTrack.岩性层段.ToString())
                {
                    tsmiSelectDel.Visible = true;
                    tsmiNewItemAdd.Visible = true;
                }

            }
        
        }

        private void tsmiDelLog_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = tvSectionEdit.SelectedNode;
            if (selectedNode != null)
            {
                string sID = tvSectionEdit.SelectedNode.Name.ToString();
                cSectionUIoperate.deleteItemByID(selectedNode, filePathOper, sID);
                makeNewSVG();
            }
        }

        public void updateTVandWB() 
        {
            updateTV();
            makeNewSVG(); 
        }

        private void tsBtnReflush_Click(object sender, EventArgs e)
        {
            bRefreshNow = true;
            updateTVandWB(); 
        }

        private void tsBtnOpenProject_Click(object sender, EventArgs e)
        {
            openExist();
        }

        private void 简化ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cXmlBase.setNodeInnerText(filePathOper, cXEWellPage.fullPathShowMode, "2");
            makeNewSVG();
        }

        void updateSVG()
        {
            Cursor.Current = Cursors.WaitCursor;
            this.Text ="剖面综合:\t"+filePathOper;
            filePathSVG = makeSectionWell.makeSectionWellBody(filePathOper, sJHSelected + ".svg");
            //string sUnit = cXmlBase.getNodeInnerText(this.filePathOper, cXEWellPage.fullPathPageUnit);
            //double fUnitConvert = cPublicMethodBase.unitPxScale(sUnit);
            fVscale = float.Parse(cXmlBase.getNodeInnerText(this.filePathOper, cXEWellPage.fullPathVSacle));
            this.tsslTVlbl.Text = " zoom x " + fVscale.ToString(".00");
            this.tsbcbbVScale.Text = (1000*3.78 / fVscale).ToString("0");

            wellPanelMain.filePathTemple = filePathOper;
            this.wellPanelMain.filePathSVG = filePathSVG;
            this.wellPanelMain.filePathHeadSVG = filePathSVG;
            this.wellPanelMain.RefreshSVG();
            Cursor.Current = Cursors.Default;
        }

        DateTime dtLastStop = DateTime.Now;
        void makeNewSVG() //makeNewOne 需要备份数据，刷新，不备份。
        {
            //备份数据需要时间和空间，用户会连续刷新。
            if (bRefreshNow == true)
            {
                string filePathHis = Path.Combine(this.dirHisUnto, cIDmake.generateRandomFileNameID());
                if (cPublicMethodBase.ExecDateDiff(dtLastStop, DateTime.Now).TotalSeconds >= 1.5)
                {
                    File.Copy(filePathOper, filePathHis, true);
                    UndoList.Push(filePathHis);
                    setUnDoRedoEnable();
                }
                dtLastStop = DateTime.Now;
                updateSVG();
            }
        }

        private void tvSectionEdit_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode selectNode = this.tvSectionEdit.SelectedNode;
            if (selectNode != null)
            {
                tvSelectInfor(selectNode);
                cSectionUIoperate.setNodeProperty(selectNode, filePathOper);
                makeNewSVG(); 
            } //end if selectNode
        }

        wellPanel WellPanelCompare;

        private void 增加井ToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void tsmiSettingPage_Click(object sender, EventArgs e)
        {
            FormSettingShowState wellShowSetting = new FormSettingShowState(this.filePathOper);
            wellShowSetting.ShowDialog();
        }

        private void tsmiSave_Click(object sender, EventArgs e)
        {
            //保存到项目用户目录下文件
            FormInputBox inputBox = new FormInputBox("保存入项目用户目录：", "请输入保存文件名");
            var result = inputBox.ShowDialog();
            if (result == DialogResult.OK)
            {
              string strFileName = inputBox.ReturnValueStr;            //分层方案名 作为id 存values preserved after close
                if (strFileName != "" )
                {
                    string newSaveFile = Path.Combine(cProjectManager.dirPathUsedProjectData, strFileName+cProjectManager.fileExtensionSectionWell);
                    if (File.Exists(newSaveFile))
                    {
                        DialogResult dialogResult = MessageBox.Show("文件已存在，是否覆盖保存", "警告", MessageBoxButtons.YesNo);

                        if (dialogResult == DialogResult.Yes)
                        {
                            File.Copy(this.filePathOper, newSaveFile, true);
                            MessageBox.Show("保存至用户库：" + strFileName);
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            MessageBox.Show("未覆盖保存。" );
                            //do something else
                        }
                    }
                    else
                    {
                        File.Copy(this.filePathOper, newSaveFile, true);
                        MessageBox.Show("保存至用户库：" + strFileName);
                    }
                } 
            } 
        }

        private void tsmiTreeviewShow_Click(object sender, EventArgs e)
        {
            this.splitContainerSection.Panel1Collapsed = false;
            updateTV();
        }

        private void tsmiTreeviewHide_Click(object sender, EventArgs e)
        {
            this.splitContainerSection.Panel1Collapsed = true ;
        }

        private void tsUndo_Click(object sender, EventArgs e)
        {
            undo();
        }

        private void FormSectionWell_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            cPublicMethodBase.DirectoryDelAllFiles(dirHisUnto);
        }
        void redo() 
        {
            if (RedoList.Count >= 0)
            {
                UndoList.Push(RedoList.Pop());
                string redoFileName = UndoList.Peek();
                File.Copy(redoFileName, this.filePathOper, true);
                updateTV();
                updateSVG();//更新不备份
            }
            setUnDoRedoEnable();
        }
        void undo()
        {
            if (UndoList.Count >1)
            {
                RedoList.Push(UndoList.Pop());
                string curFileName = UndoList.Peek();
                File.Copy(curFileName, this.filePathOper, true);
                updateTV();
                updateSVG();//更新不备份
            }
            setUnDoRedoEnable();
        }

        void setUnDoRedoEnable() 
        {
            if (RedoList.Count == 0)
            {
                this.tsbRedo.Enabled = false;
                this.tsmiRedo.Enabled = false;
            }
            else 
            {
                this.tsbRedo.Enabled = true;
                this.tsmiRedo.Enabled = true;
            }
            if (UndoList.Count == 0)
            {
                this.tsbUndo.Enabled = false;
                this.tsmiUndo.Enabled = false;
            }
            else
            {
                this.tsbUndo.Enabled = true;
                this.tsmiUndo.Enabled = true;
            }
        }

        private void tsRedo_Click(object sender, EventArgs e)
        {
            redo();
        }

        private void tsmiUndo_Click(object sender, EventArgs e)
        {
            undo();
        }

        private void tsmiRedo_Click(object sender, EventArgs e)
        {
            redo();
        }

        private void FormSectionWell_Load(object sender, EventArgs e)
        {
            this.dirHisUnto = Path.Combine(cProjectManager.dirPathHis, "SectionWell",sJHSelected);
            if (!Directory.Exists(dirHisUnto)) Directory.CreateDirectory(dirHisUnto);
        }

        void zoomDepth(double inputUpVscale) 
        {
            if (File.Exists(this.filePathOper))
            {
                fVscale = inputUpVscale * float.Parse(cXmlBase.getNodeInnerText(this.filePathOper, cXEWellPage.fullPathVSacle));
                changeVsacle(fVscale); 
            }
        }

        void changeVsacle(double _fVscale) 
        {
            if (File.Exists(filePathOper))
            {
                cXmlBase.setNodeInnerText(this.filePathOper, cXEWellPage.fullPathVSacle, _fVscale.ToString("0.00"));
                double depthShowBot = double.Parse(cXmlBase.getNodeInnerText(filePathOper, cXEWellPage.fullPathBotDepth));
                cXmlBase.setNodeInnerText(this.filePathOper, cXEWellPage.fullPathPageHeight, ((depthShowBot + 50) * _fVscale).ToString("0.00"));
                makeNewSVG();
                this.wellPanelMain.Focus();
            }
        }

        private void tsBtnZoonIn_Click(object sender, EventArgs e)
        {
          zoomDepth(1.1) ; 
        }

        private void tsBtnZoomOut_Click(object sender, EventArgs e)
        {
           zoomDepth(0.9) ; 
        }

        private void tsmiWellCompareAdd_Click(object sender, EventArgs e)
        {
            if (splitContainerSection.Panel2.Contains(WellPanelCompare) == false)
            {
                WellPanelCompare = new wellPanel(this.filePathOper, this.wellPanelMain.filePathSVG);
                splitContainerSection.Panel2.Controls.Add(WellPanelCompare);
                wellPanelMain.Dock = System.Windows.Forms.DockStyle.Left;
                WellPanelCompare.Dock = System.Windows.Forms.DockStyle.Right;
                wellPanelMain.Width = Convert.ToInt16(this.splitContainerSection.Panel2.Width * 0.49);
                WellPanelCompare.Width = wellPanelMain.Width;
                WellPanelCompare.Location = new Point(wellPanelMain.Location.X + this.splitContainerSection.Panel2.Width/2 , wellPanelMain.Location.Y);
            }
        }

        private void tsmiWellCompareDel_Click(object sender, EventArgs e)
        {
            if (splitContainerSection.Panel2.Contains(WellPanelCompare) == true)
            {
            splitContainerSection.Panel2.Controls.Remove(WellPanelCompare);
            wellPanelMain.Dock = System.Windows.Forms.DockStyle.Fill ;}
        }

        private void tsBtnSaveProject_Click(object sender, EventArgs e)
        {
            this.UndoList.Clear();
            this.RedoList.Clear();
            this.tsmiUndo.Enabled = false;
            this.tsmiRedo.Enabled = false;
            this.tsbUndo.Enabled = false;
            this.tsbRedo.Enabled = false;
            cPublicMethodBase.DirectoryDelAllFiles(dirHisUnto);
        }

        private void tsmiNewItemAdd_Click(object sender, EventArgs e)
        {
            TreeNode tnSelect=tvSectionEdit.SelectedNode;
             if (tnSelect != null )
             {
                 //输入道id,插入item
                 string sTrackID = tnSelect.Name;
                 string sTrackType=tnSelect.Tag.ToString();
                 if (tnSelect.Level == 2)
                 {
                     sTrackID=tnSelect.Parent.Name;
                     sTrackType=tnSelect.Parent.Tag.ToString();
                 }

                 FormSectionAddNewDataItem newItem = new FormSectionAddNewDataItem(this.filePathOper, sTrackID, sTrackType,0,100);
                 if(newItem.ShowDialog()==DialogResult.OK)
                 {
                     updateTV();
                     makeNewSVG();
                 }
            }
        }
      
         void clearMap() 
         {
             this.wellPanelMain.pDepth = new PointF(0, 0);
             this.wellPanelMain.sIDcurrentTrack = "";
             this.wellPanelMain.sIDcurrentItem = "";
             this.tsslTVlbl.Text = "请选择对象,进行操作。";
             updateSVG();
         }

         private void tsbDataItemInsert_Click(object sender, EventArgs e)
         {
             this.wellPanelMain.InsertDataItem();
         }

         private void tsbIntervalDel_Click(object sender, EventArgs e)
         {
             cXmlDocSectionWell.deleteItemByID(filePathOper, this.wellPanelMain.sIDcurrentItem);
             makeNewSVG();
         }

         private void tsbDataItemSet_Click(object sender, EventArgs e)
         {
             this.wellPanelMain.setDataItem();
         }

         private void tsmiIntervalInforView_Click(object sender, EventArgs e)
         {
             this.wellPanelMain.setDataItem();
         }

         private void tsmiIntervalInsert_Click(object sender, EventArgs e)
         {
             this.wellPanelMain.InsertDataItem();
         }

         private void tsmiIntervalDel_Click(object sender, EventArgs e)
         {
             cXmlDocSectionWell.deleteItemByID(filePathOper, this.wellPanelMain.sIDcurrentItem);
             makeNewSVG();
         }

         void trackWidthAdjust(int iValueAdjust)
         {
             if (wellPanelMain.sIDcurrentTrack.StartsWith("idTrack"))
             {
                 int trackWidth = cXEtrack.getTrackWidth(this.filePathOper, wellPanelMain.sIDcurrentTrack);
                 if ((trackWidth + iValueAdjust) > 5) cXEtrack.setTrackWidth(this.filePathOper, wellPanelMain.sIDcurrentTrack, (trackWidth + iValueAdjust).ToString());
                 makeNewSVG();
             }
         }


         private void tsmiTrackWidthAdd_Click(object sender, EventArgs e)
         {
             trackWidthAdjust(5);
         }

         private void 移除ToolStripMenuItem_Click(object sender, EventArgs e)
         {
             if (wellPanelMain.sIDcurrentTrack.StartsWith("idTrack"))
             {
                 cXmlDocSectionWell.deleteItemByID(filePathOper, wellPanelMain.sIDcurrentTrack);
                 updateTVandWB();
             }
         }

         private void 隐藏ToolStripMenuItem_Click(object sender, EventArgs e)
         {
             if (wellPanelMain.sIDcurrentTrack.StartsWith("idTrack"))
             {
                 cXmlDocSectionWell.setTrackVisible(filePathOper, wellPanelMain.sIDcurrentTrack,0);
                 updateTVandWB();
             }
         }

         private void tsmiTrackDataLoad_Click(object sender, EventArgs e)
         {
             //点击数据按钮后 弹出数据导入对话框，
             //两种数据方法，一种是直接加载，另一种是从数据中提取
             //数据都是提取到绘图数据目录中，作为中间数据存储
             TreeNode currentNode = tvSectionEdit.SelectedNode;
             if (currentNode != null)
             {
                 cSectionUIoperate.updateTrackData(sJHSelected, currentNode, this.filePathOper);
                 updateTVandWB();
             }
         }

         private void tsbcbbVScale_SelectedIndexChanged(object sender, EventArgs e)
         {
             if (File.Exists(this.filePathOper) && tsbcbbVScale.SelectedIndex >= 0)
             {  
                 double fUnitConvert=3.78;
                 if (cProjectData.projectUnit == typeUnit.Field.ToString()) fUnitConvert = 9.6;
                 fVscale =fUnitConvert*1000 / float.Parse(tsbcbbVScale.SelectedItem.ToString());
                 changeVsacle(fVscale); 
             }
         }

         private Stack<string> copyIDList = new Stack<string>();
        
         private void tsmiCopyLog_Click(object sender, EventArgs e)
         {
             TreeNode selectedNode = tvSectionEdit.SelectedNode;
             if(selectedNode!=null && selectedNode.Parent.Tag.ToString() == TypeTrack.曲线道.ToString())
             {
                 this.wellPanelMain.sIDcurrentItem = selectedNode.Name;
                 copyCurve();
             }
         }

         private void tsmiPasteLog_Click(object sender, EventArgs e)
         {
             TreeNode selectedNode = tvSectionEdit.SelectedNode;
             if (selectedNode.Level == 1 && selectedNode.Tag.ToString() == TypeTrack.曲线道.ToString() && copyIDList.Count>0)
             {
                 cXmlDocSectionWell.pasteLogCurveByID(this.filePathOper, copyIDList.Pop(), selectedNode.Name);
                 updateTVandWB();
                 tsmiPasteLog.Enabled = false;
             }
         }

         void copyCurve() 
         {
             if (this.wellPanelMain.sIDcurrentItem.StartsWith("idLog"))
             {
                 copyIDList.Push(this.wellPanelMain.sIDcurrentItem);
                 this.tsslTVlbl.Text = "曲线已经复制,请选择道进行粘贴";
                 this.tsbLogPaste.Enabled = true;
                 tsmiPasteLog.Enabled = true;
             }

           
         }
         private void tsbLogCopy_Click(object sender, EventArgs e)
         {
              copyCurve() ; 
         }

         private void tsbLogPaste_Click(object sender, EventArgs e)
         {
             string sIDTrackCur=wellPanelMain.sIDcurrentTrack;
             if (sIDTrackCur.StartsWith("idTrack") && copyIDList.Count>0)
             {
                 if (cXmlDocSectionWell.getTrackTypeByID(this.filePathOper, sIDTrackCur) == TypeTrack.曲线道.ToString())
                 {
                     cXmlDocSectionWell.pasteLogCurveByID(this.filePathOper, copyIDList.Pop(), sIDTrackCur);
                     updateTVandWB();
                     this.tsbLogPaste.Enabled = false;
                 }
             }
         }

         void logCurveSet() 
         {
             if (this.wellPanelMain.sIDcurrentItem.StartsWith("idLog"))
             {
                 FormSettingSectionLog setLogCurve = new FormSettingSectionLog(filePathOper, wellPanelMain.sIDcurrentItem);
                 if (setLogCurve.ShowDialog() == DialogResult.OK) makeNewSVG();
             }
         }

         private void tsmiLogEdit_Click(object sender, EventArgs e)
         {
             logCurveSet();
         }

         private void tsmiTrackSet_Click(object sender, EventArgs e)
         {
             if (wellPanelMain.sIDcurrentTrack.StartsWith("idTrack"))
             {
                 FormSettingSectionTrack newForm = new FormSettingSectionTrack(this.filePathOper, wellPanelMain.sIDcurrentTrack);
                 if (newForm.ShowDialog() == DialogResult.OK)        makeNewSVG();
             }
         }

         private void tsbTrackMoveLeft_Click(object sender, EventArgs e)
         {
             if (wellPanelMain.sIDcurrentTrack.StartsWith("idTrack"))
             {
                 cXmlDocSectionWell.upSelectTrack(filePathOper, this.wellPanelMain.sIDcurrentTrack);
                 updateTVandWB();
             }
         }

         private void tsbTrackMoveRight_Click(object sender, EventArgs e)
         {
             if (wellPanelMain.sIDcurrentTrack.StartsWith("idTrack"))
             {
                 cXmlDocSectionWell.downSelectTrack(filePathOper, this.wellPanelMain.sIDcurrentTrack);
                 updateTVandWB();
             }
         }

         private void tsmiDel_Click(object sender, EventArgs e)
         {
             cXmlDocSectionWell.deleteItemByID(filePathOper, this.wellPanelMain.sIDcurrentItem);
             makeNewSVG();
         }

         private void tsmiSelect_Click(object sender, EventArgs e)
         {
             clearMap();
         }

         private void tsmiInsertimage_Click(object sender, EventArgs e)
         {
            addTrackCss(TypeTrack.图片道);
         }

         private void tsmiSave2Project_Click(object sender, EventArgs e)
         {
             FormInputBox newEx = new FormInputBox("成果图输出","请输入文件名");
             if (newEx.ShowDialog() == DialogResult.OK)
             {
                 string sMapName = newEx.ReturnValueStr; 
                 cProjectManager.save2ProjectDelEnvent(filePathSVG,sMapName);
             }
         }

         private void tsbTreeView_Click(object sender, EventArgs e)
         {
             this.splitContainerSection.Panel1Collapsed = !this.splitContainerSection.Panel1Collapsed;
             if (this.splitContainerSection.Panel1Collapsed == false) updateTV();
         }

         private void tsmiFossil_Click(object sender, EventArgs e)
         {
             addTrackCss(TypeTrack.描述);
         }

         private void tsmiTest_Click(object sender, EventArgs e)
         {
           
         }

         private void tsmiTrackData_Click(object sender, EventArgs e)
         {
             TreeNode currentNode = tvSectionEdit.SelectedNode;
             if (currentNode != null)
             {
                if( cSectionUIoperate.updateTrackData(sJHSelected, currentNode, this.filePathOper)==DialogResult.OK)
                 updateTVandWB();
             }
         }

         private void tlsbTrackCopy_Click(object sender, EventArgs e)
         {
             this.wellPanelMain.trackCopy();
         }

         private void tlsbPageSet_Click(object sender, EventArgs e)
         {
             FormSettingShowState wellShowSetting = new FormSettingShowState(filePathOper);
             if(wellShowSetting.ShowDialog()==DialogResult.OK) updateSVG();
         }

         void viewChange(bool bShow) 
         {
             this.toolStripSectionWellMain.Visible = bShow;
             this.wellPanelMain.webBrowserHead.Visible = bShow;
             this.wellPanelMain.lblCrossH.Visible = bShow;
             this.wellPanelMain.lblCrossV.Visible = bShow;
             this.wellPanelMain.statusStripWellPanel.Visible = bShow;

             if(bShow==false) this.wellPanelMain.webBrowserBody.ContextMenuStrip = null;
             else this.wellPanelMain.webBrowserBody.ContextMenuStrip = this.wellPanelMain.cmsWBBody; 
         }
         
         void  viewMode(float fTopshow, float fBotShow)
         {
               filePathSVG = makeSectionWell.makeResultGraph(filePathOper, sJHSelected + ".svg", fTopshow, fBotShow);
               string sUnit = cXmlBase.getNodeInnerText(this.filePathOper, cXEWellPage.fullPathPageUnit);
               double fUnitConvert = cPublicMethodBase.unitPxScale(sUnit);
               fVscale = float.Parse(cXmlBase.getNodeInnerText(this.filePathOper, cXEWellPage.fullPathVSacle));
               this.tsslTVlbl.Text = "unit " + sUnit + " zoom x " + (fVscale / fUnitConvert).ToString(".00");
               this.tsbcbbVScale.Text = (1000 * fUnitConvert / fVscale).ToString("0");

               wellPanelMain.filePathTemple = filePathOper;
               this.wellPanelMain.filePathSVG = filePathSVG;
               this.wellPanelMain.filePathHeadSVG = filePathSVG;
               this.wellPanelMain.RefreshSVG();
         }
         
         private void tsmiModelResult_Click(object sender, EventArgs e)
         {
           FormExport2Map newEx = new FormExport2Map(this.filePathOper);
           if (newEx.ShowDialog() == DialogResult.OK)
           {
               float fTopshow = newEx.fTopShow;
               float fBotShow = newEx.fBotShow;
               viewMode(fTopshow, fBotShow);
               viewChange(false) ;
           }

          
         }
         private void 普通ToolStripMenuItem_Click(object sender, EventArgs e)
         {
             viewChange(true);
             cXmlBase.setNodeInnerText(filePathOper, cXEWellPage.fullPathShowMode, "1");
             makeNewSVG();
         }

         private void tsbcbbVScale_Click(object sender, EventArgs e)
         {

         }

         private void tsmiAdjustHead_Click(object sender, EventArgs e)
         {
             this.wellPanelMain.setTrackIntervalEditMode();
         }

         private void tsmiTrackWidthMinus_Click(object sender, EventArgs e)
         {
             trackWidthAdjust(-5);
         }

         private void tsmiInsertWellBone_Click(object sender, EventArgs e)
         {
             addTrackCss(TypeTrack.管柱);
         }

         private void tsmiInsertCompositon_Click(object sender, EventArgs e)
         {
             addTrackCss(TypeTrack.组分);
         }

         private void tsmiCloseRefresh_Click(object sender, EventArgs e)
         {
             bRefreshNow = false ;
         }
     
    }
}
