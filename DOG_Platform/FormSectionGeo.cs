using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Xml;
using System.Xml.Linq;
using DOGPlatform.XML;
using DOGPlatform.SVG;
using System.Runtime.InteropServices;
using System.Security.Permissions;

namespace DOGPlatform
{    
    /// <summary>
    /// 本模块主要生成地质静态剖面，不包含动态信息相对于开发剖面来说，层段的尺度大一些，更多针对地层和油层组单元和地层格架的剖面
    /// 基本原则：把用户输入的数据整理到一个剖面xml数据中；然后从数据库中抽析数据成图。是否应该有多个xml文件，一个组织section结构，每个单井也有自己的xml，这样数据会快，更新改的数据也会快很多。
    /// 操作流程 选井-〉选模板 -〉根据模板提取数据 -〉 解析xml绘图
    /// 提取数据流程：选择的模板应该是单井统一模板。需要组合成section模板吗？！！！！
    /// 界面先根据单井模板提取数据。再更新的时候用个性模板。
    /// 数据流程：
    /// 1 读取剖面xml，然后根据单井的xml制作剖面。
    /// 2 读取各剖面井的绘制深度,
    /// 3 根据条件把数据提取到临时目录
    /// 4 解析xmlCss样式和数据，成图
    /// </summary>
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public partial class FormSectionGeo : Form
    {   
        //定义绘图数据的临时目录
        //定义联井剖面井号存储List
        public List<string> ltStrSelectedJH = new List<string>();  
        //定义存储绘图剖面井数据结构
        List<ItemWellSection> listWellsSection = new List<ItemWellSection>();
        static bool bRefreshNow = true;
        //tempXML存储路径
        static string mapID = "sectionGeo" + DateTime.Now.ToString("MMddHHmmss");
        static string dirSectionData = Path.Combine(cProjectManager.dirPathUsedProjectData, mapID);
        string filePathSectionGeoCss = Path.Combine(cProjectManager.dirPathUsedProjectData, mapID + cProjectManager.fileExtensionSectionGeo);
        
        double fVscale = 1000 / 500;  //默认是用1：500比例尺 //是用sunit单位换算过的
        float fWellDistanceHScale =1;
       
        //记录上次页面位置，便于下次定位
        Point PscrollOffset=new Point(0,0);

        int iPageTopElevation = 0;
        string filePathSVG = "";

        int iOperateMode = 0;

        int iSwichHis = 0; //是否备份开关

        string sJH="";
        string sIDcurrentTrack="";
        string sIDcurrentItem="";
        string filePathOper="";
        public FormSectionGeo()
        {
            InitializeComponent();
            InitFormWellsGroupControl();
        }
        public FormSectionGeo(string inputFilepath):this()
        {
            openExistSectionFlow(inputFilepath);
        } 
        //初始化Form页面
        private void InitFormWellsGroupControl()
        {
            this.splitContainerSection.Panel1Collapsed = true;
            lblCrossV.Location = new Point(0, this.webBrowserSVG.Location.Y);
            lblCrossH.Location = new Point(this.webBrowserSVG.Location.X, 0);
            cPublicMethodForm.initialMapScale(tsbcbbVScale);
            this.webBrowserSVG.ContextMenuStrip = cmsWebSVG;
            webBrowserSVG.ObjectForScripting = this;
        }

        List<string> ltSelectID = new List<string>();
        List<PointD> ltMousePos = new List<PointD>();

        //初始化剖面图TreeView
        void updateTVandList()
         {
             tvSectionEdit.Nodes.Clear();
             listWellsSection.Clear();
             XmlNode xnElevationRuler= cXmlBase.GetXmlNodeByXpath(filePathSectionGeoCss,cXETrackRuler.xmlFullPathElevationRuler);
             TreeViewSectionEditView.setupTN_RulerElevation(tvSectionEdit,xnElevationRuler.Attributes["id"].Value);
             listWellsSection = cXmlDocSectionGeo.makeListWellSection(filePathSectionGeoCss);
             //解析sectioncss文件，增加节点
             foreach (ItemWellSection item in  listWellsSection)
             {
                 if (item.sJH != "")
                 {
                     string filePath = Path.Combine(dirSectionData, item.sJH + ".xml");
                     TreeNode tnWell = new TreeNode(item.sJH);
                     tnWell.Tag = item.sJH;
                     tnWell.Text = item.sJH;
                     tnWell.Name = item.sJH;
                     TreeViewSectionEditView.setupWellNode(tnWell, filePath);
                     tvSectionEdit.Nodes.Add(tnWell);
                 }
             }
             foreach (TreeNode tn in tvSectionEdit.Nodes)
                 if (tn.Level  == 1) tn.Expand();
         }

        private void FormWellGeo_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.dirHisUnto = Path.Combine(cProjectManager.dirPathHis, "SectionGeo");
            if (!Directory.Exists(dirHisUnto)) Directory.CreateDirectory(dirHisUnto);
        }

        private void tsmiSave_Click(object sender, EventArgs e)
        {
            //如果用户没有输入文件名时，系统用List中首井和尾井名+井数命名
            string filenameSVGMap = String.Format("地质剖面-{0}_{1}_({2}).svg", ltStrSelectedJH[0], ltStrSelectedJH.LastOrDefault(), ltStrSelectedJH.Count);
            //原分层方案的数据将出清
            FormInputBox inputBox = new FormInputBox("保存到项目图库：", "请输入保存文件名:");
            var result = inputBox.ShowDialog();
            if (result == DialogResult.OK)
            {
                filenameSVGMap = inputBox.ReturnValueStr;            //values preserved after close
            }
        }

        private void tsmiRefresh_Click(object sender, EventArgs e)
        {
            updateTVandList();
            makeSVGmap(); 
        }


        private void tsmiTVEditSetting_Click(object sender, EventArgs e)
        {
            //根据节点的tag里的内容弹出不同的对话框进行节点配置
            switch (this.tvSectionEdit.SelectedNode.Tag.ToString())
            {
                case "Ruler":
                    FormSettingElevationRuler setRuler = new FormSettingElevationRuler(this.filePathSectionGeoCss);
                    if (setRuler.ShowDialog() == DialogResult.OK)
                    {
                    //    showTempSVG(); 
                    }
                    break;
                case "WellConeRuler":
                    FormSettingSectionWellBone setWellCone = new FormSettingSectionWellBone(this.filePathSectionGeoCss);
                    setWellCone.ShowDialog();
                    break;
                case "LogCurve":
                    //FormSettingSectionLog setLogCurve = new FormSettingSectionLog();
                    //setLogCurve.ShowDialog();
                    break;
                default:
                    break;
            }
        }
 
        private void tsmiNew_Click(object sender, EventArgs e)
        {
          createNewFile();
        }
     
        void createNewFile()
        {
            FormSectionAddNewGeo formNew = new FormSectionAddNewGeo(filePathSectionGeoCss, dirSectionData);
            var result = formNew.ShowDialog();
            if (result == DialogResult.OK)
            {
                updateTVandList();
                makeSVGmap();
            }
        }

        void updateSVGMap() 
        {
            Cursor.Current = Cursors.WaitCursor;
            PscrollOffset = cSectionUIoperate.getOffSet(this.webBrowserSVG);
            if (File.Exists(filePathSectionGeoCss))
            {
                fVscale = float.Parse(cXmlBase.getNodeInnerText(this.filePathSectionGeoCss, cXEGeopage.fullPathSacleV));
                fWellDistanceHScale= float.Parse(cXmlBase.getNodeInnerText(filePathSectionGeoCss, cXEGeopage.xmlFullPathPageHorizonWellDistanceScale));
                this.tsbcbbVScale.Text = ((int)(1000 / fVscale)).ToString();
            }
            if (listWellsSection.Count > 0)
            {
                filePathSVG = makeSectionGeo.generateSectionGraph(dirSectionData, this.filePathSectionGeoCss, "test.svg");
                this.webBrowserSVG.Navigate(new Uri(filePathSVG));
            }
            Cursor.Current = Cursors.Default;
        }

        DateTime dtLastStop = DateTime.Now;
        void makeSVGmap()
        {
            if (bRefreshNow)
            {
                updateSVGMap();

                //更新前把 数据备份，copy到历史数据，准备回退。
                if (iSwichHis == 0 && cPublicMethodBase.ExecDateDiff(dtLastStop, DateTime.Now).TotalSeconds >= 2) //0表示重新生成的，1表示回退的 回退的不用备份。
                {
                    string dirPathUndo = Path.Combine(this.dirHisUnto, cIDmake.generateRandomDirName());
                    Directory.CreateDirectory(dirPathUndo);
                    string backFileName = Path.Combine(dirPathUndo, mapID + cProjectManager.fileExtensionSectionGeo);
                    File.Copy(this.filePathSectionGeoCss, backFileName, true);
                    cPublicMethodForm.DirectoryCopy(dirSectionData, dirPathUndo, true);
                    UndoList.Push(dirPathUndo);
                    if (UndoList.Count > 1) this.tsbUndo.Enabled = true;
                    if (RedoList.Count > 1) this.tsbRedo.Enabled = true;
                }
                iSwichHis = 0;
                dtLastStop = DateTime.Now;
                this.lblClick.Visible = false;
                this.iPageTopElevation = int.Parse(cXmlDocSectionGeo.getNodeInnerText(this.filePathSectionGeoCss, cXEGeopage.xmlFullPathPageTopElevation));
            }
        }

         private void tsBtnReflush_Click(object sender, EventArgs e)
         {
             //这里等记录多次刷新的问题 相等表示连续触发刷新选项，
             //不等说明不是从刷新触发的 连续刷新操作如果避免的话 会造成修改后不刷新的问题,逻辑不好控制
             updateTVandList();
             bRefreshNow = true ;
             makeSVGmap();
         }

         private void tsBtnOpenProject_Click(object sender, EventArgs e)
         {
         openExist();
         }

         void openExist()
         {
             OpenFileDialog ofdProjectPath = new OpenFileDialog();

             ofdProjectPath.Title = " 打开文件：";
             ofdProjectPath.Filter =string.Format( "{0}文件|*{0}",cProjectManager.fileExtensionSectionGeo);
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
             filePathSectionGeoCss = Path.Combine(cProjectManager.dirPathUsedProjectData, mapID + cProjectManager.fileExtensionSectionGeo);
             dirSectionData = Path.Combine(cProjectManager.dirPathUsedProjectData, mapID);
             this.tbgViewEdit.Text = mapID;
             updateTVandList();
             makeSVGmap();
         }

         private void tsmiSetPage_Click(object sender, EventArgs e)
         {
             
         }

         private void tsmiOpen_Click(object sender, EventArgs e)
         {
         openExist();
         }

         private void tsBtnNewProject_Click(object sender, EventArgs e)
         {
          createNewFile();
         }

         private void tsmiSettingPage_Click(object sender, EventArgs e)
         {
             
         }

         private void tvEditSection_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
         {
             TreeNode selectNode = this.tvSectionEdit.SelectedNode;
             setUpIDByTN(selectNode);
             DialogResult result = DialogResult.Cancel;
             if (selectNode != null)
             {
                 if (selectNode.Level == 2)
                 {
                     result = cSectionUIoperate.setNodeProperty(selectNode, filePathOper);
                 } 
                 if (selectNode.Level == 1) 
                 {
                     //这里与右键设置不同 ，特别针对井的深度道之类的多个设置过程
                     FormSettingSectionTrack newForm = new FormSettingSectionTrack(filePathOper, selectNode.Name);
                     result = newForm.ShowDialog();
                 } 
                 if (selectNode.Level == 0) 
                 {
                     if(selectNode.Tag.ToString()==TypeTrack.海拔尺.ToString())
                     {
                         FormSettingElevationRuler newRuler = new FormSettingElevationRuler(this.filePathSectionGeoCss);
                         result = newRuler.ShowDialog();
                     }
                 }
             } //end if selectNode
             if(result==DialogResult.OK)   makeSVGmap();
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

         private void tsmiTrackDataImport_Click(object sender, EventArgs e)
         {
             TreeNode currentNode = tvSectionEdit.SelectedNode;
             setUpIDByTN(currentNode);
             if (currentNode != null)
             {
                 if (cSectionUIoperate.updateTrackData(this.sJH, currentNode, this.filePathOper) == DialogResult.OK) 
                 {
                     TreeViewSectionEditView.updateWellNode(currentNode, this.filePathOper);
                     makeSVGmap(); 
                 }
             }
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

         private void tsmiTrackDel_Click(object sender, EventArgs e)
         {
             TreeNode currentNode = this.tvSectionEdit.SelectedNode;
             setUpIDByTN(currentNode);
             cSectionUIoperate.deleteItemByID(currentNode, filePathOper, sIDcurrentTrack);
         }

         public void ShowMessage(object obj)
         {
             string sID = obj.ToString();
             if (sID != "")
             {  
                 if(ltSelectID.Count==0)ltSelectID.Add(obj.ToString()); //空串+
                 else if (sID != ltSelectID.Last()) ltSelectID.Add(obj.ToString()); //避免双击 
                 if (ltSelectID.Count == 2 && iOperateMode == (int)TypeModeGeoOperate.connectTwo)
                 {
                     connectSelectItem();
                     makeSVGmap();
                     ltMousePos.Clear();
                     iOperateMode = 0;
                 }
                 if (ltSelectID.Count == 1 && iOperateMode >1)
                 {
                     connectSelectItem();
                     makeSVGmap();
                     ltMousePos.Clear();
                     iOperateMode = 0;
                 }
                 this.tsslblIDinfor.Text = string.Format("已选择{0}个对象,当前对象id:{1},操作模式{2}", ltSelectID.Count, sID, (TypeModeGeoOperate)iOperateMode);
             }
             
             else 
             {
                 this.tsslblIDinfor.Text = "未选择对象";
             }
         }

         private void tsmiConnectJSJL_Click(object sender, EventArgs e)
         {
             connectSelectItem();
         }

         cDataItemConnect getDataNodeById(string sIDSelect)
         {
             XmlNode dataNode;
             cDataItemConnect dataItemConnect = new cDataItemConnect();
             dataItemConnect.sIDDataItem = sIDSelect;
             foreach (ItemWellSection itemWell in listWellsSection)
             {
                  string filePathOper = dirSectionData + "//" + itemWell.sJH + ".xml";
                 
                  XmlDocument wellTemplateXML = new XmlDocument();
                  wellTemplateXML.Load(filePathOper);

                  string sPath = string.Format("//*[@id='{0}']", sIDSelect);
                  dataNode = wellTemplateXML.SelectSingleNode(sPath);

                  if (dataNode != null)
                  {
                      string sIDtrack = dataNode.ParentNode.ParentNode.Attributes["id"].Value;
                      dataItemConnect.sIDTrack = sIDtrack;
                      dataItemConnect.sJH = itemWell.sJH;
                      dataItemConnect.sFill = dataNode["sProperty"].InnerText;
                      dataItemConnect.typeTrack = cXmlDocSectionWell.getTrackTypeByID(filePathOper, sIDtrack);
                  
                      return dataItemConnect; 
                  }
             }
             return dataItemConnect;
         }
         
         HtmlDocument htmlDoc;
         private void webBrowserSVG_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
         {
             htmlDoc = webBrowserSVG.Document;
             if (htmlDoc != null)
             {
                 // 定位上次页面位置
                 if (webBrowserSVG.Url == e.Url)
                 {
                     //记录元素的位置，实现刷新页面自动滚动
                     webBrowserSVG.Document.Window.ScrollTo(PscrollOffset);
                 }
                 htmlDoc.MouseDown -= htmlDoc_MouseDown;
                 htmlDoc.MouseDown += htmlDoc_MouseDown;
                 htmlDoc.MouseMove -= htmlDoc_MouseMove;
                 htmlDoc.MouseMove += htmlDoc_MouseMove;
             }
         }

         PointD docCoord = new PointD();
         void htmlDoc_MouseMove(object sender, HtmlElementEventArgs e)
         {
             lblCrossH.Width = webBrowserSVG.Width;
             lblCrossV.Height = this.webBrowserSVG.Height;
             lblCrossV.Location = new Point(e.MousePosition.X - 5, this.webBrowserSVG.Location.Y);
             lblCrossH.Location = new Point(this.webBrowserSVG.Location.X, e.MousePosition.Y + 5);
         }

          void getDocCorord(object sender, HtmlElementEventArgs e) 
         {
             PscrollOffset = cSectionUIoperate.getOffSet(this.webBrowserSVG);
             Point ScreenCoord = new Point(e.MousePosition.X, e.MousePosition.Y);
             double currentX = (ScreenCoord.X + PscrollOffset.X - makeSectionGeo.iPositionXFirstWell) / fWellDistanceHScale + makeSectionGeo.iPositionXFirstWell;
             double currentDepth = (ScreenCoord.Y + PscrollOffset.Y) / fVscale - iPageTopElevation;
             docCoord = new PointD(currentX, currentDepth);
         }

         void htmlDoc_MouseDown(object sender, HtmlElementEventArgs e)
         {
             PscrollOffset = cSectionUIoperate.getOffSet(this.webBrowserSVG);
             Point ScreenCoord = new Point(e.MousePosition.X, e.MousePosition.Y);
             double currentX = (ScreenCoord.X + PscrollOffset.X - makeSectionGeo.iPositionXFirstWell) / fWellDistanceHScale + makeSectionGeo.iPositionXFirstWell;
             double currentDepth=(ScreenCoord.Y + PscrollOffset.Y)/fVscale-iPageTopElevation;
             PointD docCoord = new PointD(currentX, currentDepth);
             lblClick.Location = ScreenCoord;
             ltMousePos.Add(docCoord);
            // Point BrowserCoord = webBrowserSVG.PointToClient(ScreenCoord);
            this.tsslblWb.Text ="记录点数=" +ltMousePos.Count.ToString()+" X=" +docCoord.X.ToString("0.00") + " Y=" + docCoord.Y.ToString("0.00");
            if (iOperateMode == (int)TypeModeGeoOperate.fault || iOperateMode == (int)TypeModeGeoOperate.revertFault)
            { 
                if(ltMousePos.Count == 1)
                {
                    tsslblWb.Text = "正等待点击确认第二个断点位置。";
                } 
                if(ltMousePos.Count == 2)
                {
                    faultMode(iOperateMode);
                    ltMousePos.Clear();
                    iOperateMode = 0; 
                }
            }
         }

         void faultMode(int iOperateMode) 
         {
             double displacement = 1.0;
             string strRet = tsTextFaultDisplacement.Text;
             double.TryParse(strRet, out displacement); 
             cXmlDocSectionGeo.addFaultItem(this.filePathSectionGeoCss, ltMousePos[0], ltMousePos[1], displacement);
             tsTextFaultDisplacement.Visible = false ;
             tslblFaulDisplacement.Visible = false;
             makeSVGmap(); 
         }

         private void tsBtnZoonIn_Click(object sender, EventArgs e)
         {
             webBrowserSVG.Focus();
             SendKeys.Send("^{+}");
         }

         private void tsBtnZoomOut_Click(object sender, EventArgs e)
         {
             webBrowserSVG.Focus();
             SendKeys.Send("^{-}");
         }

         private void tsmiTrackSetting_Click(object sender, EventArgs e)
         {
             TreeNode currentNode = this.tvSectionEdit.SelectedNode;
             if (currentNode.Level == 1)
             {
                 setUpIDByTN(currentNode);
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

         private void tsmiSelect_Click(object sender, EventArgs e)
         {
             ltSelectID.Clear();
             makeSVGmap();
         }

         private void tsmiConnectLayer_Click(object sender, EventArgs e)
         {
             //
             if (ltSelectID.Count >= 2)
             {
                 cDataItemConnect selectItem1 = getDataNodeById(ltSelectID[0]);
                 cDataItemConnect selectItem2 = getDataNodeById(ltSelectID[1]);

                 cXmlDocSectionGeo.addConnectDataItem(this.filePathSectionGeoCss, 0,selectItem1,selectItem2 ); 
             }
             makeSVGmap(); 
         }

         private void tsmiSelectDel_Click(object sender, EventArgs e)
         {
             deleteSelectItem(); 
         }

         void deleteSelectItem() 
         {
             if (ltSelectID.Count > 0)
             {
                 string sIDlast = ltSelectID.Last();
                 cXmlDocSectionGeo.deleteConnectSelect(this.filePathSectionGeoCss, sIDlast);
                 if(sJH!="") cXmlDocSectionGeo.deleteConnectSelect(this.filePathOper, sIDlast);
                 ltSelectID.Clear();
                 makeSVGmap();
             }
         }

         private void tsbSelect_Click(object sender, EventArgs e)
         {
             clearMap();
         }

         void clearMap() 
         {
             ltSelectID.Clear();
             ltMousePos.Clear();
             this.lblClick.Visible = false;
             this.tsslblIDinfor.Text = "请选择对象,进行操作。";
             this.tsslblWb.Text = "";
             updateSVGMap();
         }

         private void tsbDelSelect_Click(object sender, EventArgs e)
         {
             deleteSelectItem(); 
         }

         void connectSelectItem()
         {
             if (ltSelectID.Count == 2)
             {
                 cDataItemConnect selectItem1 = getDataNodeById(ltSelectID[0]);
                 cDataItemConnect selectItem2 = getDataNodeById(ltSelectID[1]);

                 cXmlDocSectionGeo.addConnectDataItem(this.filePathSectionGeoCss, iOperateMode, selectItem1, selectItem2);
             }
             if (ltSelectID.Count == 1)
             {
                 cDataItemConnect selectItem1 = getDataNodeById(ltSelectID[0]);
                 cXmlDocSectionGeo.addConnectDataItem(this.filePathSectionGeoCss, iOperateMode  , selectItem1);
             } 
             makeSVGmap(); 
             ltSelectID.Clear();
         }

         void selectConnectMode(int iOption) 
         {
             ltSelectID.Clear();
             iOperateMode = iOption;
             this.tsslblIDinfor.Text = string.Format("已选择{0}个对象,操作模式{1}", ltSelectID.Count,(TypeModeGeoOperate)iOperateMode);
         }

         private void tsbConnectLayer_Click(object sender, EventArgs e)
         {
             selectConnectMode((int)TypeModeGeoOperate.connectTwo);
         }

         private void tsbConnectRightChannel_Click(object sender, EventArgs e)
         {
             selectConnectMode((int)TypeModeGeoOperate.channelRight);
         }

         private void tsbConnectLeftChannel_Click(object sender, EventArgs e)
         {
             selectConnectMode((int)TypeModeGeoOperate.channelLeft);
         }

         private void tsbFaultReverse_Click(object sender, EventArgs e)
         {
             tsTextFaultDisplacement.Visible = true;
             tslblFaulDisplacement.Visible = true;
             ltMousePos.Clear();
             lblClick.Visible = true;
             lblClick.Location = new Point(0, 0);
             iOperateMode = (int)TypeModeGeoOperate.revertFault ; //逆断层模式
             tsslblWb.Text = "开启逆断层模式，请点击确认2个断点。"; //方法在 webdocument的 mousedown事件内
         }

         private Stack<string> UndoList = new Stack<string>();
         private Stack<string> RedoList = new Stack<string>();
         private string dirHisUnto = cProjectManager.dirPathHis;

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
             if (UndoList.Count <= 1)
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

         private void tsbUndo_Click(object sender, EventArgs e)
         {
             undo();
         }

         private void tsbRedo_Click(object sender, EventArgs e)
         {
             redo();
         }
        
        void redo() 
        {
            if (RedoList.Count > 0)
            {
                iSwichHis = 1;
                UndoList.Push(RedoList.Pop());
                string curHisDir = UndoList.Peek();
                //文件还原
                // 还原联井文件
                string sectionHisCss = Path.Combine(curHisDir, Path.GetFileName(this.filePathSectionGeoCss));
                File.Copy(sectionHisCss, this.filePathSectionGeoCss, true);
                string[] filePaths = Directory.GetFiles(curHisDir, "*.xml");
                foreach (string filePath in filePaths) 
                {
                    string newFilePath = Path.Combine(dirSectionData, Path.GetFileName(filePath));
                    File.Copy(filePath, newFilePath, true);
                }
                updateTVandList();
                makeSVGmap();
            }
            setUnDoRedoEnable();
        }
        
        void undo()
        {
            if (UndoList.Count > 1)
            {
                iSwichHis = 1;
                RedoList.Push(UndoList.Pop());
                if (RedoList.Count > 0)
                {
                    this.tsbRedo.Enabled = true;
                    this.tsmiUndo.Enabled = true;
                }
                string curHisDir = UndoList.Peek();
                //文件还原
                // 还原联井文件
                string sectionCss = Path.Combine(curHisDir, Path.GetFileName(this.filePathSectionGeoCss));
                File.Copy(sectionCss, this.filePathSectionGeoCss, true);
                //还原各井文件
                string[] filePaths = Directory.GetFiles(curHisDir, "*.xml");
                foreach (string filePath in filePaths)
                {
                    string newFilePath = Path.Combine(dirSectionData, Path.GetFileName(filePath));
                    File.Copy(filePath, newFilePath, true);
                }
                updateTVandList();
                makeSVGmap();
            }
            setUnDoRedoEnable();
        }

        private void FormSectionGeo_FormClosed(object sender, FormClosedEventArgs e)
        {
            cPublicMethodBase.DirectoryDelAllFiles(dirHisUnto);
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

        private void tsmiAncorClose_Click(object sender, EventArgs e)
        {
            closeAncor();
        }

        void closeAncor() 
        {
            this.lblClick.Visible = false;
            this.lblCrossH.Visible = false;
            this.lblCrossV.Visible = false;
        }

        private void tsmiAncorPoint_Click(object sender, EventArgs e)
        {
            this.lblCrossH.Visible = true;
            this.lblCrossV.Visible = true;
            this.lblClick.Visible = true;
            this.lblClick.Height = 5;
            this.lblClick.Width = 5;
            this.lblClick.BackColor = Color.Red;
        }

        private void tsmiMarkRulerLine_Click(object sender, EventArgs e)
        {
            this.lblClick.Visible = true;
            this.lblClick.Height = 1;
            this.lblClick.Width = 200;
            this.lblClick.BackColor = Color.Black;
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
             deleteSelectItem(); 
        }

        private void temiReselect_Click(object sender, EventArgs e)
        {
             clearMap();
        }

        private void tsmiUndo_Click(object sender, EventArgs e)
        {
             undo();
        }

        private void tsmiRedo_Click(object sender, EventArgs e)
        {
            redo();
        }

        private void tsbFault_Click(object sender, EventArgs e)
        {
            tsTextFaultDisplacement.Visible = true;
            tslblFaulDisplacement.Visible = true;
            ltMousePos.Clear();
            lblClick.Visible = true;
            lblClick.Location = new Point(0, 0);
            iOperateMode = (int)TypeModeGeoOperate.fault; //正断层模式
            tsslblWb.Text = "开启正断层模式，请点击确认2个断点。"; //方法在 webdocument的 mousedown事件内
        }

        private void tsbConnectRightBar_Click(object sender, EventArgs e)
        {
            selectConnectMode((int)TypeModeGeoOperate.barRight);
        }

        private void tsbConnectLeftBar_Click(object sender, EventArgs e)
        {
            selectConnectMode((int)TypeModeGeoOperate.barLeft);
        }

        private void tsbConnectRightPinout_Click(object sender, EventArgs e)
        {
            selectConnectMode((int)TypeModeGeoOperate.pinchOutRight);
        }

        private void tsbConnectLeftPinout_Click(object sender, EventArgs e)
        {
            selectConnectMode((int)TypeModeGeoOperate.pinchOutLeft);
        }

        private void tsmiSave2Project_Click(object sender, EventArgs e)
        {
            cProjectManager.save2ProjectDelEnvent(filePathSVG);
        }

        private void tsmiAddLog_Click(object sender, EventArgs e)
        {
            TreeNode currentNode = tvSectionEdit.SelectedNode;
            if (currentNode.Tag.ToString() == TypeTrack.曲线道.ToString())
            {
                setUpIDByTN(currentNode);
                FormSectionAddWellLog formAddLog = new FormSectionAddWellLog(sJH);
                if (formAddLog.ShowDialog() == DialogResult.OK)
                {
                    ItemLogHeadInfor logHead = formAddLog.logHeadRet;
                    cXmlDocSectionWell.addLog(filePathOper, sIDcurrentTrack, logHead);
                     TreeViewSectionEditView.updateWellNode(currentNode, this.filePathOper);
                    makeSVGmap();
                }
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
                List<string> listSdataWord = new List<string>();
                FormSectionDataLog formInputDataTableSingleWell = new
                         FormSectionDataLog(sJH, sLogName, TypeTrack.曲线道.ToString(), filePathOper, sIDcurrentItem);
                formInputDataTableSingleWell.ShowDialog();
           
            } 
        }

        private void tsmiInsertTrackLog_Click(object sender, EventArgs e)
        {
            TreeNode currentNode = tvSectionEdit.SelectedNode;
            if (currentNode != null)
            {
                setUpIDByTN(currentNode);
                addTrackCss(currentNode,TypeTrack.曲线道);
            }
        }

        void addTrackCss(TreeNode currentNode,TypeTrack eTypeTrack)
        {
            int iTrackWidth = 50;
            if (eTypeTrack == TypeTrack.曲线道) iTrackWidth = 100;
            cXmlDocSectionWell.addTrackCss(filePathOper, eTypeTrack, iTrackWidth);
            TreeViewSectionEditView.updateWellNode(currentNode, this.filePathOper);
        }

        private void tvSectionEdit_MouseUp(object sender, MouseEventArgs e)
        {
            TreeNode selectedNode = tvSectionEdit.GetNodeAt(e.X, e.Y);
          
            if (selectedNode != null)
            {
                if (selectedNode.Tag.ToString() == TypeTrack.海拔尺.ToString()) this.tvSectionEdit.ContextMenuStrip = null;
                else this.tvSectionEdit.ContextMenuStrip = cmsTVedit; 
                setUpIDByTN(selectedNode);
            }
            //右键弹出菜单
            if (e.Button == MouseButtons.Right)
            {
                controlTVcms(selectedNode);
            }
        }

        void controlTVcms(TreeNode selectedNode)
        {
            // Select the clicked node
            foreach (ToolStripMenuItem item in this.cmsTVedit.Items) item.Visible = false;
            if (selectedNode.Level == 0)
            {
                tsmiPageSetting.Visible = true;
                tsmiInsertTrack.Visible = true;
                tsmiInsertWellAfter.Visible = true;
                tsmiInsertWellBefore.Visible = true;
                tsmiRemoveWell.Visible = true;
                tsmiEditWell.Visible = true;
                tsmiAdjustShowDepth.Visible = true;
            }
            if (selectedNode.Level == 1)
            {
                tsmiTrackDown.Visible = true;
                tsmiTrackUp.Visible = true;
                tsmiTrackSetting.Visible = true;
                tsmiTrackDel.Visible = true;
                tsmiTrackDataImport.Visible = true;
                tsmiTrackWidthAdd.Visible = true;
                tsmiTrackWidthMinus.Visible = true;

                if (selectedNode.Tag.ToString() == TypeTrack.曲线道.ToString())
                {
                    tsmiTrackLogSub.Visible = true;
                    tsmiTrackDataImport.Visible = false;
                }
                if (selectedNode.Tag.ToString() == TypeTrack.测井解释.ToString()
                   || selectedNode.Tag.ToString() == TypeTrack.岩性层段.ToString())
                {
                    tsmiTrackDataImport.Visible = true;
                }

            }
            if (selectedNode.Level == 2)
            {
                if (selectedNode.Parent.Tag.ToString() == TypeTrack.曲线道.ToString())
                {
                    tsmiTrackDataImport.Visible = true;
                    tsmiTrackLogSub.Visible = true;
                }

                if (selectedNode.Parent.Tag.ToString() == TypeTrack.测井解释.ToString()
                    || selectedNode.Parent.Tag.ToString() == TypeTrack.岩性层段.ToString())
                {
                   // tsmiSelectDel.Visible = true;
                    tsmiTrackDataImport.Visible = true;
                }
            }

        }

        private void tsmiInsertTrackText_Click(object sender, EventArgs e)
        {
            TreeNode currentNode = tvSectionEdit.SelectedNode;
            if (currentNode != null)
            {
                setUpIDByTN(currentNode);
                addTrackCss(currentNode,TypeTrack.文本道);
            }
        }

        private void tsmiInsertTrackCJSJ_Click(object sender, EventArgs e)
        {
            TreeNode currentNode = tvSectionEdit.SelectedNode;
            if (currentNode != null)
            {
                setUpIDByTN(currentNode);
                addTrackCss(currentNode,TypeTrack.测井解释);
            }
        }

        private void tsmiInsertTrackLitho_Click(object sender, EventArgs e)
        {
            TreeNode currentNode = tvSectionEdit.SelectedNode;
            if (currentNode != null)
            {
                setUpIDByTN(currentNode);
                addTrackCss(currentNode,TypeTrack.岩性层段);
            }
        }

        private void tsmiShowState_Click(object sender, EventArgs e)
        {
            TreeNode currentNode = tvSectionEdit.SelectedNode;
            if (currentNode != null)
            {
                setUpIDByTN(currentNode);
                FormSettingSectionGeoShowDepth newset = new FormSettingSectionGeoShowDepth(this.filePathSectionGeoCss,this.sJH);
                if (newset.ShowDialog() == DialogResult.OK) makeSVGmap();
            }
        }

        private void 地层道ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode currentNode = tvSectionEdit.SelectedNode;
            if (currentNode != null)
            {
                setUpIDByTN(currentNode);
                addTrackCss(currentNode,TypeTrack.分层);
            }
        }

        private void tsBtnZoonInVertical_Click(object sender, EventArgs e)
        {
            zoomDepth(1.1); 
        }

        void zoomDepth(double inputUpVscale)
        {
            if (File.Exists(this.filePathSectionGeoCss))
            {
                fVscale = inputUpVscale * float.Parse(cXmlBase.getNodeInnerText(this.filePathSectionGeoCss, cXEGeopage.fullPathSacleV));
                cXmlBase.setNodeInnerText(this.filePathSectionGeoCss, cXEGeopage.fullPathSacleV, fVscale.ToString("0.00"));
                this.tssTVInfor.Text = "垂直方向 zoom x " + fVscale.ToString(".00");
                this.tsbcbbVScale.Text = (1000 / fVscale).ToString("0");
                makeSVGmap();
            }
        }

        private void tsBtnZoonOutVertical_Click(object sender, EventArgs e)
        {
            zoomDepth(0.9); 
        }

        private void statusStripTV_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void 井等距ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cXmlBase.setNodeInnerText(filePathSectionGeoCss, cXEGeopage.xmlFullPathPageWellArrange,"1");
        }

        void setXYview( float inputHscale)
        {
            fWellDistanceHScale =inputHscale*float.Parse(cXmlBase.getNodeInnerText(filePathSectionGeoCss, cXEGeopage.xmlFullPathPageHorizonWellDistanceScale));
            cXmlBase.setNodeInnerText(this.filePathSectionGeoCss, cXEGeopage.xmlFullPathPageHorizonWellDistanceScale, fWellDistanceHScale.ToString("0.00"));
            this.tssTVInfor.Text = " 水平方向 zoom x " + fWellDistanceHScale.ToString(".00");
            makeSVGmap();
        }

        private void tsBtnZoonOutH_Click(object sender, EventArgs e)
        {
            setXYview(1.1F);
        }

        private void 等井距ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cXmlBase.setNodeInnerText(filePathSectionGeoCss, cXEGeopage.xmlFullPathPageWellArrange,"1");
            makeSVGmap();
        }

        private void tsBtnZoonInH_Click(object sender, EventArgs e)
        {
            setXYview(0.9F);
        }

        private void 实际井距比ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cXmlBase.setNodeInnerText(filePathSectionGeoCss, cXEGeopage.xmlFullPathPageWellArrange,"2");
            makeSVGmap();
        }


        private void tsbcbbVScale_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (File.Exists(this.filePathSectionGeoCss) && tsbcbbVScale.SelectedIndex >= 0)
            {
                fVscale = 1000 / float.Parse(tsbcbbVScale.SelectedItem.ToString());
                cXmlBase.setNodeInnerText(this.filePathSectionGeoCss, cXEGeopage.fullPathSacleV, fVscale.ToString("0.00"));
                this.tssTVInfor.Text = "垂直方向 zoom x " + fVscale.ToString(".00");
                this.webBrowserSVG.Focus();
                makeSVGmap();
            }
        }


        private void tsmiIntervalMode_Click(object sender, EventArgs e)
        {
            FormSettingModeInterval newSetPage = new FormSettingModeInterval(this.filePathSectionGeoCss,dirSectionData);
            if (newSetPage.ShowDialog() == DialogResult.OK) makeSVGmap();
        }

        private void tsmiPositionRuler_Click(object sender, EventArgs e)
        {

        }

        private void tsmiInsertTrackDepthRuler_Click(object sender, EventArgs e)
        {
            TreeNode currentNode = tvSectionEdit.SelectedNode;
            if (currentNode != null)
            {
                setUpIDByTN(currentNode);
                addTrackCss(currentNode,TypeTrack.深度尺);
            }
        }

        private void tsmiEditWell_Click(object sender, EventArgs e)
        {
            TreeNode currentNode = tvSectionEdit.SelectedNode;
            if (currentNode != null)
            {
                setUpIDByTN(currentNode);
                float fTopShow = 0;
                XmlNode selectWell = cXmlDocSectionGeo.selectNodeByID(filePathSectionGeoCss,this.sJH);
                if(selectWell!=null) fTopShow = float.Parse(selectWell["fShowTop"].InnerText);
                FormSectionWell editWell = new FormSectionWell(this.filePathOper, fTopShow);
                if (editWell.ShowDialog() == DialogResult.OK)
                {
                    updateTVandList();
                    makeSVGmap();
                }
            }
        }

        private void tsmiRemoveWell_Click(object sender, EventArgs e)
        {
            TreeNode currentNode = tvSectionEdit.SelectedNode;
            if (currentNode != null)
            {
                setUpIDByTN(currentNode);
                DialogResult dialogResult = MessageBox.Show( "确认移除: "+this.sJH, "移除井", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    cXmlDocSectionGeo.deleteWellSelect(this.filePathSectionGeoCss, this.sJH);
                    File.Delete(this.filePathOper);
                    updateTVandList();
                    makeSVGmap(); 
                }
            }

        }

        private void tsmiInsertWell_Click(object sender, EventArgs e)
        {
            TreeNode currentNode = tvSectionEdit.SelectedNode;
            if (currentNode != null)
            {
                setUpIDByTN(currentNode);
                insertWell(0);  
            }
        }

        private void tsmiInsertWellBefore_Click(object sender, EventArgs e)
        {
            TreeNode currentNode = tvSectionEdit.SelectedNode;
            if (currentNode != null)
            {
                setUpIDByTN(currentNode);
                insertWell(1);
            }
        }

        void insertWell(int iBefore) 
        {
            FormSectAddNewWell formNew = new FormSectAddNewWell();
            var result = formNew.ShowDialog();
            if (result == DialogResult.OK)
            {
                string sJHInsert = formNew.ReturnJH;            //values preserved after close
                string xtlFileName = formNew.ReturnFileNameXMT;
                bool bNew = true;
                filePathOper = dirSectionData + "//" + sJHInsert + ".xml";
                if (File.Exists(filePathOper))
                {
                    DialogResult dialogResult = MessageBox.Show("是否新建并覆盖？", "文件已存在", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.No) bNew = false;
                }
                if (bNew == true)
                {
                    ItemWellSection wellSectionInsert = new ItemWellSection(sJHInsert, 0, 0);
                    //默认把显示深度设为全井段
                    wellSectionInsert.fShowedDepthTop = 0;
                    wellSectionInsert.fShowedDepthBase = wellSectionInsert.fWellBase;
                    //fxview 根据井径自动算的。
                    wellSectionInsert.fYview = -wellSectionInsert.fKB;
                    //CSS的加入井 
                    cXmlDocSectionGeo.insertWell(this.filePathSectionGeoCss, this.sJH, wellSectionInsert,iBefore);
                    //copy文件到目录
                    cIOtemplate.copyTemplate(xtlFileName, filePathOper, wellSectionInsert.sJH, wellSectionInsert.fShowedDepthTop, wellSectionInsert.fShowedDepthBase);
                    updateTVandList();
                    makeSVGmap();
                }
            }
        }


        private void tsmiTreeviewShow_Click(object sender, EventArgs e)
        {
            this.splitContainerSection.Panel1Collapsed = false;
        }

        private void tsmiTreeviewHide_Click(object sender, EventArgs e)
        {
            this.splitContainerSection.Panel1Collapsed = true;
        }

        private void tsmiDelLog_Click(object sender, EventArgs e)
        {
            TreeNode currentNode = tvSectionEdit.SelectedNode;
            if (currentNode != null)
            {
                setUpIDByTN(currentNode);
                string sID = tvSectionEdit.SelectedNode.Name.ToString();
                cSectionUIoperate.deleteItemByID(currentNode, filePathOper, sID);
                updateTVandList();
                makeSVGmap();
            }
        }

        private void tsbTreeView_Click(object sender, EventArgs e)
        {
            this.splitContainerSection.Panel1Collapsed = !this.splitContainerSection.Panel1Collapsed;
            if (this.splitContainerSection.Panel1Collapsed == false) updateTVandList();
        }

        private void tsbPageSet_Click(object sender, EventArgs e)
        {
            FormSettingPage newSetPage = new FormSettingPage(filePathSectionGeoCss);
            if (newSetPage.ShowDialog() == DialogResult.OK) makeSVGmap();
        }

        private void tsmiTrackWidthAdd_Click(object sender, EventArgs e)
        {
            TreeNode currentNode = this.tvSectionEdit.SelectedNode;
            setUpIDByTN(currentNode);
            trackWidthAdjust(this.filePathOper, this.sIDcurrentTrack, 5);
            updateSVGMap();
        }

        void trackWidthAdjust(string filePathOper,string sIDTrack,int iValueAdjust)
        {
            if (sIDTrack.StartsWith("idTrack"))
            {
                int trackWidth = cXEtrack.getTrackWidth(filePathOper, sIDTrack);
                if ((trackWidth + iValueAdjust) >5) cXEtrack.setTrackWidth(filePathOper, sIDTrack, (trackWidth + iValueAdjust).ToString());
            }
        }

        private void tsmiTrackWidthMinus_Click(object sender, EventArgs e)
        {
            TreeNode currentNode = this.tvSectionEdit.SelectedNode;
            setUpIDByTN(currentNode);
            trackWidthAdjust(this.filePathOper, this.sIDcurrentTrack, -5);
            updateSVGMap();
        }

        private void tsBtnZoonOutHItem1_5_Click(object sender, EventArgs e)
        {
            setXYview(1.5F);
        }

        private void tsBtnZoonOutHItem2_Click(object sender, EventArgs e)
        {
            setXYview(2.0F);
        }

        private void tsBtnZoonOutHItem1_2_Click(object sender, EventArgs e)
        {
            setXYview(1.2F);
        }

        private void tsBtnZoonOutHItem1_1_Click(object sender, EventArgs e)
        {
            setXYview(1.1F);
        }

        private void tsBtnZoonOutHItem0_9_Click(object sender, EventArgs e)
        {
            setXYview(0.9F);
        }

        private void tsBtnZoonOutHItem0_8_Click(object sender, EventArgs e)
        {
            setXYview(0.8F);
        }

        private void tsBtnZoonOutHItem0_5_Click(object sender, EventArgs e)
        {
            setXYview(0.5F);
        }

        private void tsBtnZoonInV1_1_Click(object sender, EventArgs e)
        {
            zoomDepth(1.1); 
        }

        private void tsBtnZoonInV1_2_Click(object sender, EventArgs e)
        {
            zoomDepth(1.2); 
        }

        private void tsBtnZoonInV1_5_Click(object sender, EventArgs e)
        {
            zoomDepth(1.5); 
        }

        private void tsBtnZoonInV2_Click(object sender, EventArgs e)
        {
            zoomDepth(2); 
        }

        private void tsBtnZoonOutHItem2_Click_1(object sender, EventArgs e)
        {
            setXYview(2.0F);
        }

        private void 井排列ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tsmiCloseRefresh_Click(object sender, EventArgs e)
        {
            bRefreshNow = false;
            closeAncor();
        }

       

    }
}
