using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using DOGPlatform.XML;
using System.Xml;
using System.IO;
using DOGPlatform.SVG;

namespace DOGPlatform
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
       public partial class wellPanel : UserControl
    {
        public string filePathSVG = "";
        public string filePathHeadSVG = "";
        public string filePathTemple = "";
        
        HtmlDocument htmlDocWebBody;
        HtmlDocument htmlDocWebHead;
        public string sIDcurrentTrack = "";  //记录当前道
        public string sIDcurrentItem = "";    //记录当前item
        public PointF pDepth = new PointF(0, 0); //记录2个深度
        //记录上次页面位置，便于下次定位
        public Point PscrollOffset = new Point(0, 0);
        float fVscale = 2;
        float fCurrentMD = 0;
        float fCurrentTVD = 0;
        ItemWell curWell = new ItemWell();
        cXEWellPage curPage =new cXEWellPage();
        public Delegate userFunctionPointer;
        public wellPanel()
        {
            InitializeComponent();
            this.lblCrossH.Width = this.webBrowserBody.Width;
            this.lblCrossH.Location = new Point(0, 0);
            this.lblCrossV.Height = this.webBrowserBody.Height;
            this.lblCrossV.Location = new Point(0, 0);
            webBrowserBody.ObjectForScripting = this;
            this.webBrowserHead .ObjectForScripting = this;
        }


        public wellPanel(string inputfileNameTemplate,string inputFilepathSVG):this()
        {
            filePathSVG = inputFilepathSVG;
            filePathHeadSVG = inputFilepathSVG;
            filePathTemple = inputfileNameTemplate;
            RefreshSVG();
        }

        private void tsmiRefresh_Click(object sender, EventArgs e)
        {
            RefreshSVG(); 
        }

        Dictionary<string, int> dicTrack = new Dictionary<string, int>();
        public void RefreshSVG()
        {
            dicTrack.Clear();
            PscrollOffset=cSectionUIoperate.getOffSet(this.webBrowserBody);
            double xMarkrulerLength = 0;
            foreach (XmlElement el_Track in cXmlDocSectionWell.getTrackNodes(filePathTemple))
            {
                int iTrackWidth = int.Parse(el_Track["trackWidth"].InnerText);
                string sIDtrack=el_Track.Attributes["id"].Value;
                int iVisible = int.Parse(el_Track["visible"].InnerText);
                if (iVisible > 0) //判断是否可见，获取长度
                {
                    dicTrack.Add(sIDtrack, iTrackWidth);
                    xMarkrulerLength += iTrackWidth;
                }
            }
            this.lblCrossH.Width = (int) xMarkrulerLength;
            int iTrackRactHeight = int.Parse(cXmlBase.getNodeInnerText(filePathTemple, cXEWellPage.fullPathTrackRectHeight));
            int iTrackTitleHeight = int.Parse(cXmlBase.getNodeInnerText(filePathTemple, cXEWellPage.fullPathMapTitleRectHeight));
            this.webBrowserHead.Height = iTrackRactHeight + iTrackTitleHeight+1;
           
            this.webBrowserBody.Navigate(new Uri(filePathSVG));
            this.webBrowserHead.Navigate(new Uri(filePathHeadSVG));
        }

        private void tsmiPageSetting_Click(object sender, EventArgs e)
        {

        }

        private void tsmiShowedDepth_Click(object sender, EventArgs e)
        {
            FormSettingShowState newSet = new FormSettingShowState(this.filePathTemple);
            if (newSet.ShowDialog() == DialogResult.OK) RefreshSVG(); 
        }
    
        //页面横向托滚动条 道头同步方法
        public void OnScrollEventHandler(object sender, EventArgs e)
        {
            PscrollOffset = cSectionUIoperate.getOffSet(this.webBrowserBody);
            webBrowserHead.Document.Window.ScrollTo(PscrollOffset.X, 0);
        }
    
        private void tsmiLoadSVG_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdProjectPath = new OpenFileDialog();

            ofdProjectPath.Title = " 打开井：";
            ofdProjectPath.Filter = string.Format("{0}文件|*{0}", cProjectManager.fileExtensionSectionWell);
            //设置默认文件类型显示顺序 
            ofdProjectPath.FilterIndex = 1;
            //保存对话框是否记忆上次打开的目录 
            ofdProjectPath.RestoreDirectory = true;

            if (ofdProjectPath.ShowDialog() == DialogResult.OK)
            {
                this.filePathTemple = ofdProjectPath.FileName;
                filePathSVG = makeSectionWell.makeSectionWellBody(filePathTemple, "compareWell" + ".svg"); 
                filePathHeadSVG = filePathSVG; 
                RefreshSVG(); 
            }
        }

        private void webBrowserBody_SizeChanged(object sender, EventArgs e)
        {
        }

        private void tsmiIEOpen_Click(object sender, EventArgs e)
        {
            //转成html
            string pathHtmlMap = cSVG2Html.svg2htmlByObject(filePathSVG);
            System.Diagnostics.Process.Start("IExplore.exe", pathHtmlMap);
        }

        public void ShowMessage(object obj)
        {
           string sIDret=obj.ToString();
           if (sIDret.StartsWith("idTrack"))
           {
               sIDcurrentTrack = sIDret;
               this.tssCurTrack.Text = "图道=" + cXmlDocSectionWell.getTrackTitleByID(this.filePathTemple, sIDcurrentTrack);
               string strTypeTrack = cXmlDocSectionWell.getTrackTypeByID(this.filePathTemple, sIDcurrentTrack);
               //head右键菜单显示 default
               this.tsmiHeadTrackDataLoad.Visible = true;
               this.tsmiHeadTrackHide.Visible = true;
               this.tsmiHeadTrackRemove.Visible = true;
               this.tsmiHeadTrackSet.Visible = true;
               this.tsmiHeadLogSet.Visible = false;
               this.tsmiHeadLogDataLoad.Visible = false;
               this.tsmiHeadLogTrackFill.Visible = false;
               this.tsmiHeadTrackAddLogCurve.Visible = false;
               this.tsmiHeadLogRemove.Visible = false;
               if(strTypeTrack == TypeTrack.曲线道.ToString())
               {
                   this.tsmiHeadTrackAddLogCurve.Visible = true;
                   this.tsmiHeadLogTrackFill.Visible = true;
                   this.tsmiHeadLogRemove.Visible = true;
               }
               else if (strTypeTrack == TypeTrack.深度尺.ToString() ||
                   strTypeTrack == TypeTrack.图片道.ToString())
               {
                   this.tsmiHeadTrackDataLoad.Visible = false;
               }
             
           }
           else if (sIDret.StartsWith("idDataItem"))
           {
               sIDcurrentItem = sIDret; string sTop = "";
               string sBot = "";
               cXmlDocSectionWell.getDataItemTopBotByID(filePathTemple, sIDcurrentItem, out sTop, out sBot);
               this.tssCurItem.Text = "层段=" + sIDcurrentItem + " 顶深=" + sTop + " 底深=" + sBot;
               if (sTop != "") this.tssCurItem.Text += " 厚度=" + Math.Abs(float.Parse(sTop) - float.Parse(sBot)).ToString("0.00");
               this.tsmiDataItemAdjustBot.Visible = true;
               this.tsmiDataItemAdjustTop.Visible = true;
               this.tsmiDataItemInsert.Visible = true;
               this.tsmiDataItemSet.Visible = true;
               this.tsmiBodyLogSet.Visible = false;
           }
           else if (sIDret.StartsWith("idLog"))
           {
               sIDcurrentItem = sIDret;
               this.tssCurItem.Text = "曲线=" + sIDcurrentItem;
               //head右键菜单显示
               this.tsmiHeadTrackDataLoad.Visible = false;
               this.tsmiHeadTrackHide.Visible = false;
               this.tsmiHeadTrackRemove.Visible = false;
               this.tsmiHeadTrackSet.Visible = false;

               //body右键菜单显示设置
               this.tsmiDataItemAdjustBot.Visible = false;
               this.tsmiDataItemAdjustTop.Visible = false;
               this.tsmiDataItemInsert.Visible = true;
               this.tsmiDataItemSet.Visible = false;
               this.tsmiBodyLogSet.Visible = true;
               this.tsmiHeadLogSet.Visible = true;
               this.tsmiHeadLogDataLoad.Visible = true;
           }
           else 
           {
               this.tsmiDataItemInsert.Visible = true;
           }

        }

        private void tsmiRulerMarkShow_Click(object sender, EventArgs e)
        {
            this.lblCrossV.Visible = true;
            this.lblCrossH.Visible=true;
            this.lblmarker.Visible = true;
        }

        private void tsmiRulerMarkHide_Click(object sender, EventArgs e)
        {
            this.lblCrossV.Visible = false; 
            this.lblCrossH.Visible = false;
            this.lblmarker.Visible = false;
        }

        public void setDataItem() 
        {
            bool bSeletctDataItemInSelectTrack = cXmlDocSectionWell.isItemINtrackByID(filePathTemple, sIDcurrentTrack, sIDcurrentItem);
            if (bSeletctDataItemInSelectTrack == false)
            {
                MessageBox.Show("操作数据项不在选择图道内。","提示");
            }
            else
            {
                string strTrackType = cXmlDocSectionWell.getTrackTypeByID(this.filePathTemple, sIDcurrentTrack);
                if (cProjectManager.ltStrTrackTypeIntervalProperty.IndexOf(strTrackType) >= 0)
                {
                    FormSettingSectionDataItemView setDataItem = new FormSettingSectionDataItemView(this.filePathTemple, this.sIDcurrentItem, strTrackType);
                    if (setDataItem.ShowDialog() == DialogResult.OK) userFunctionPointer.DynamicInvoke(0);
                }
                else if (strTrackType == TypeTrack.文本道.ToString())
                {
                    FormSettingSectionText setText = new FormSettingSectionText(this.filePathTemple, this.sIDcurrentItem);
                    if (setText.ShowDialog() == DialogResult.OK) userFunctionPointer.DynamicInvoke(0);
                }
                else if (strTrackType == TypeTrack.岩性层段.ToString())
                {
                    FormSectionAddItemLitho setLitho = new FormSectionAddItemLitho(this.filePathTemple, sIDcurrentTrack, this.sIDcurrentItem);
                    if (setLitho.ShowDialog() == DialogResult.OK) userFunctionPointer.DynamicInvoke(0);
                }
                else if (strTrackType == TypeTrack.图片道.ToString())
                {
                    FormSectionAddImageItem setImage = new FormSectionAddImageItem(this.filePathTemple, sIDcurrentTrack, this.sIDcurrentItem);
                    if (setImage.ShowDialog() == DialogResult.OK) userFunctionPointer.DynamicInvoke(0);
                }
                else if (strTrackType == TypeTrack.符号.ToString())
                {
                    FormSectionAddSymbol newSymbol = new FormSectionAddSymbol(this.filePathTemple, sIDcurrentTrack, this.sIDcurrentItem);
                    if (newSymbol.ShowDialog() == DialogResult.OK) userFunctionPointer.DynamicInvoke(0);
                }
                if (strTrackType == TypeTrack.分层.ToString())
                {
                    FormSettingSectionLayer setLayer = new FormSettingSectionLayer(filePathTemple, sIDcurrentTrack, this.sIDcurrentItem);
                    if (setLayer.ShowDialog() == DialogResult.OK) userFunctionPointer.DynamicInvoke(0);
                }
            }  
        }

        private void tsmiTrackSetting_Click(object sender, EventArgs e)
        {
            if (sIDcurrentTrack.StartsWith("idTrack"))
            {
                FormSettingSectionTrack newForm = new FormSettingSectionTrack(this.filePathTemple, sIDcurrentTrack);
                if (newForm.ShowDialog() == DialogResult.OK) userFunctionPointer.DynamicInvoke(1);
            }
        }

        private void tsmiTrackWidthplus_Click(object sender, EventArgs e)
        {
            if (sIDcurrentTrack.StartsWith("idTrack"))
            {
                int trackWidth= cXEtrack.getTrackWidth( this.filePathTemple,sIDcurrentTrack);
                cXEtrack.setTrackWidth(this.filePathTemple, sIDcurrentTrack, (trackWidth + 5).ToString());
                userFunctionPointer.DynamicInvoke(1);
            }
        }

        private void tsmiTrackWidthMinus_Click(object sender, EventArgs e)
        {
            if (sIDcurrentTrack.StartsWith("idTrack"))
            {
                int trackWidth = cXEtrack.getTrackWidth(this.filePathTemple, sIDcurrentTrack);
                cXEtrack.setTrackWidth(this.filePathTemple, sIDcurrentTrack, (trackWidth - 5).ToString());
                userFunctionPointer.DynamicInvoke(1);
            }
        }

        private void tsmiTrackRemove_Click(object sender, EventArgs e)
        {
            if (sIDcurrentTrack.StartsWith("idTrack"))
            {
                cXmlDocSectionWell.deleteItemByID(filePathTemple, sIDcurrentTrack);
                userFunctionPointer.DynamicInvoke(0);
            }
        }

        private void tsmiTrackHide_Click(object sender, EventArgs e)
        {
            if (sIDcurrentTrack.StartsWith("idTrack"))
            {
                cXmlDocSectionWell.setTrackVisible(filePathTemple, sIDcurrentTrack,0);
                userFunctionPointer.DynamicInvoke(0);
            }
        }

        private void tsmiTrackLogSet_Click(object sender, EventArgs e)
        {
            if (sIDcurrentTrack.StartsWith("idLog"))
            {
                FormSettingSectionLog setLogCurve = new FormSettingSectionLog(filePathTemple, sIDcurrentTrack);
                if (setLogCurve.ShowDialog() == DialogResult.OK) userFunctionPointer.DynamicInvoke(1);
            }
        }

        void logCurveSet() 
        {
            if (sIDcurrentItem.StartsWith("idLog"))
            {
                FormSettingSectionLog setLogCurve = new FormSettingSectionLog(filePathTemple, sIDcurrentItem);
                if (setLogCurve.ShowDialog() == DialogResult.OK) userFunctionPointer.DynamicInvoke(1);
            }
        }

        private void tsmiLogSet_Click(object sender, EventArgs e)
        {
            logCurveSet();
        }

        private void tsmiSelectDel_Click(object sender, EventArgs e)
        {
            if (sIDcurrentItem != "")
            {
                cXmlDocSectionWell.deleteItemByID(filePathTemple, sIDcurrentItem);
                userFunctionPointer.DynamicInvoke(0);
            }
        }

        private void tsmiTrackAddLogCurve_Click(object sender, EventArgs e)
        {
            if (sIDcurrentTrack.StartsWith("idTrack"))
            {
                if (cXmlDocSectionWell.getTrackTypeByID(filePathTemple,sIDcurrentTrack) == TypeTrack.曲线道.ToString())
                {
                    string sJH = cXmlDocSectionWell.getNodeInnerText(this.filePathTemple, cXmlDocSectionWell.fullPathJH);
                    FormSectionAddWellLog formAddLog = new FormSectionAddWellLog(sJH);
                    if (formAddLog.ShowDialog() == DialogResult.OK)
                    {
                        ItemLogHeadInfor logHead = formAddLog.logHeadRet;
                        //此处写入配置文件xml,tn.name 是 id
                        string sLogID=cXmlDocSectionWell.addLog(this.filePathTemple, sIDcurrentTrack, logHead);
                        string sLogName = cIDmake.getLogNameByID(sLogID);
                        //如果测井文件存在，自动加载数据
                        //cIOtemplate.addLogData2Track(filePathSVG, sJH, sLogName, sLogID); 
                    }
                    userFunctionPointer.DynamicInvoke(0);
                }
            }
        }

        private void tsmiTrackDataLoad_Click(object sender, EventArgs e)
        {
            if (sIDcurrentTrack.StartsWith("idTrack"))
            {
             if (cSectionUIoperate.updateTrackData(this.filePathTemple, sIDcurrentTrack)==DialogResult.OK)
                userFunctionPointer.DynamicInvoke(0);
            }
        }

        private void tsmiLogDataLoad_Click(object sender, EventArgs e)
        {
            XmlNode selectTrack = cXmlBase.selectNodeByID(filePathTemple, sIDcurrentTrack);
            string typeTrackstr = cXmlDocSectionWell.getTrackTypeByID(filePathTemple, sIDcurrentTrack);
            if (typeTrackstr == TypeTrack.曲线道.ToString() && sIDcurrentItem.StartsWith("idLog"))
            {
                string sJH = cXmlDocSectionWell.getNodeInnerText(this.filePathTemple, cXmlDocSectionWell.fullPathJH);
                string sLogName = sIDcurrentItem.Remove(sIDcurrentItem.Length - 12).Remove(0, 5);
                FormSectionDataLog formInputDataTableSingleWell = new
                         FormSectionDataLog(sJH, sLogName, TypeTrack.曲线道.ToString(), filePathTemple, sIDcurrentItem);
                if (formInputDataTableSingleWell.ShowDialog() == DialogResult.OK)
                {
                    userFunctionPointer.DynamicInvoke(0); //0全刷，1只刷树
                }
            } 
            
        }

        private void tsmiIntervalDepthAdjust_Click(object sender, EventArgs e)
        {
            if (sIDcurrentItem.StartsWith("idDataItem"))
            {
                cXmlDocSectionWell.setSelectedNodeChildNodeValue(filePathTemple, sIDcurrentItem, "top", this.fCurrentMD.ToString("0.00"));
                userFunctionPointer.DynamicInvoke(0);
            }
        }

        private void tsmiDataAdjustProperty_Click(object sender, EventArgs e)
        {
            setDataItem();
        }

        private void tsmiDataItemAdjustTop_Click(object sender, EventArgs e)
        {
            if (sIDcurrentItem.StartsWith("idDataItem"))
            {    
                //获取当前选中id的底深，如果 新的设定顶深大于原底深 设置无效
                 float fBot = float.Parse(cXmlDocSectionWell.getSelectedNodeChildNodeValue(filePathTemple, sIDcurrentItem, "bot"));
                 if (fCurrentMD < fBot)
                 {
                     //设置新顶深的top和topTVD
                     cXmlDocSectionWell.setSelectedNodeChildNodeValue(filePathTemple, sIDcurrentItem, "top", this.fCurrentMD.ToString("0.00"));
                     cXmlDocSectionWell.setSelectedNodeChildNodeValue(filePathTemple, sIDcurrentItem, "topTVD", this.fCurrentTVD.ToString("0.00"));

                     //如果设置的新顶深超过了prenode的底深，需要重新设置prenode的底深
                     float fPreTop = -999;
                     string sIDpre = "";
                     XmlNode selectNode = cXmlBase.selectPreNodeByID(filePathTemple, sIDcurrentItem);
                     if (selectNode != null)
                     {
                         float.TryParse(selectNode["bot"].InnerText, out fPreTop);
                         sIDpre = selectNode.Attributes["id"].Value;
                     }
                     if (fCurrentMD < fPreTop && sIDpre != "")
                     {
                         cXmlDocSectionWell.setSelectedNodeChildNodeValue(filePathTemple, sIDpre, "bot", this.fCurrentMD.ToString("0.00"));
                         cXmlDocSectionWell.setSelectedNodeChildNodeValue(filePathTemple, sIDpre, "botTVD", this.fCurrentTVD.ToString("0.00"));
                     }
                     userFunctionPointer.DynamicInvoke(0);
                 }
                 else
                     MessageBox.Show("底深必须大于顶深");
            }
        }

        private void tsmiDataItemAdjustBot_Click(object sender, EventArgs e)
        {
            if (sIDcurrentItem.StartsWith("idDataItem"))
            {
                float fTop = float.Parse(cXmlDocSectionWell.getSelectedNodeChildNodeValue(filePathTemple, sIDcurrentItem, "top"));
                if (fCurrentMD > fTop)
                {
                    cXmlDocSectionWell.setSelectedNodeChildNodeValue(filePathTemple, sIDcurrentItem, "bot", this.fCurrentMD.ToString("0.00"));
                    cXmlDocSectionWell.setSelectedNodeChildNodeValue(filePathTemple, sIDcurrentItem, "botTVD", this.fCurrentTVD.ToString("0.00"));

                    float fNextTop = 999999;
                    string sIDnext="";
                    XmlNode selectNode = cXmlBase.selectNextNodeByID(filePathTemple, sIDcurrentItem);
                    if (selectNode != null)
                    {
                        float.TryParse(selectNode["top"].InnerText, out fNextTop);
                        sIDnext=selectNode.Attributes["id"].Value;
                    }
                    if (fCurrentMD > fNextTop && sIDnext!="") 
                    {
                        cXmlDocSectionWell.setSelectedNodeChildNodeValue(filePathTemple, sIDnext, "top", this.fCurrentMD.ToString("0.00"));
                        cXmlDocSectionWell.setSelectedNodeChildNodeValue(filePathTemple, sIDnext, "topTVD", this.fCurrentTVD.ToString("0.00"));
                    }
                    userFunctionPointer.DynamicInvoke(0);
                }
                else
                    MessageBox.Show("底深必须大于顶深");
            }
        }

        private void tsmiDataItemInsert_Click(object sender, EventArgs e)
        {
             InsertDataItem();
        }

        public void InsertDataItem()
        {
            string strTrackType = cXmlDocSectionWell.getTrackTypeByID(this.filePathTemple, sIDcurrentTrack);
            if (strTrackType == TypeTrack.沉积旋回.ToString() || strTrackType == TypeTrack.测井解释.ToString() || strTrackType == TypeTrack.描述.ToString())
            {
                FormSectionAddNewDataItem newItem = new FormSectionAddNewDataItem(this.filePathTemple, sIDcurrentTrack, strTrackType, pDepth.X, pDepth.Y);
                if (newItem.ShowDialog() == DialogResult.OK) userFunctionPointer.DynamicInvoke(0);
            }

            if (strTrackType == TypeTrack.文本道.ToString())
            {
                FormSettingSectionText setText = new FormSettingSectionText(this.filePathTemple, sIDcurrentTrack, strTrackType, pDepth.X, pDepth.Y);
                if (setText.ShowDialog() == DialogResult.OK) userFunctionPointer.DynamicInvoke(0);
            }

            if (strTrackType == TypeTrack.符号.ToString())
            {
                FormSectionAddSymbol newSymbol = new FormSectionAddSymbol(this.filePathTemple, sIDcurrentTrack, pDepth.X, pDepth.Y);
                if (newSymbol.ShowDialog() == DialogResult.OK) userFunctionPointer.DynamicInvoke(0);
            }

            if (strTrackType == TypeTrack.岩性层段.ToString())
            {
                FormSectionAddItemLitho newLitho = new FormSectionAddItemLitho(this.filePathTemple, sIDcurrentTrack, strTrackType, pDepth.X, pDepth.Y);
                if (newLitho.ShowDialog() == DialogResult.OK) userFunctionPointer.DynamicInvoke(0);
            }

            if (strTrackType == TypeTrack.图片道.ToString()) 
            {
                FormSectionAddImageItem newItemImage = new FormSectionAddImageItem(this.filePathTemple, sIDcurrentTrack,  pDepth.X, pDepth.Y);
                if (newItemImage.ShowDialog() == DialogResult.OK) userFunctionPointer.DynamicInvoke(0);
            }
        }

        private void tsmiDataItemSet_Click(object sender, EventArgs e)
        {
            setDataItem();
        }

        private void tsmiTrackSetLogCurve_Click(object sender, EventArgs e)
        {
            logCurveSet();
        }

        private void tsmiHeadLogTrackFill_Click(object sender, EventArgs e)
        {
            XmlNode selectTrack = cXmlBase.selectNodeByID(filePathTemple, sIDcurrentTrack);
            string typeTrackstr = cXmlDocSectionWell.getTrackTypeByID(filePathTemple, sIDcurrentTrack);
            if (sIDcurrentTrack != "" && File.Exists(filePathTemple))
            {
                if (typeTrackstr == TypeTrack.曲线道.ToString())
                {
                    FormSectionCurveFill newFill = new FormSectionCurveFill(this.filePathTemple, sIDcurrentTrack);
                    if (newFill.ShowDialog() == DialogResult.OK) userFunctionPointer.DynamicInvoke(1);
                }

            }
           
        }

        public void trackCopy() 
        {
            if (this.sIDcurrentTrack.StartsWith("idTrack"))
            {
                cXmlDocSectionWell.pasteTrackByID(this.filePathTemple, sIDcurrentTrack);
                userFunctionPointer.DynamicInvoke(0);
            }
        }

        private void tsmiHeadTrackCopy_Click(object sender, EventArgs e)
        {
            trackCopy();
        }

        private void webBrowserHead_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            // 定位上次页面位置
            htmlDocWebHead = webBrowserHead.Document;

            if (htmlDocWebHead != null)
            {
                htmlDocWebHead.MouseMove -= htmlDocHead_MouseMove;
                htmlDocWebHead.MouseMove += htmlDocHead_MouseMove;

                htmlDocWebHead.MouseDown -= htmlDocHead_MouseDown;
                htmlDocWebHead.MouseDown += htmlDocHead_MouseDown;

                htmlDocWebHead.MouseUp -= htmlDocHead_MouseUp;
                htmlDocWebHead.MouseUp += htmlDocHead_MouseUp; 
            }
        }

        private  int isDragging = 0;  //1 拖动列 2 拖动 标题下
        private int clickOffSetX, clickOffSetY;
        public int iModeOperation = 0;

        void htmlDocHead_MouseDown(object sender, HtmlElementEventArgs e)
        {
            //清除webBody的所有事件
            htmlDocWebBody.MouseMove -= htmlDocBody_MouseMove;
            htmlDocWebBody.MouseDown -= htmlDocBody_MouseDown;
            this.lblCrossH.Visible = false;
            this.lblCrossV.Visible = false;
            isDragging = 0;
            int indexTrack = this.dicTrack.Keys.ToList().IndexOf(sIDcurrentTrack);
            if (indexTrack >= 0)
            {
                int curTrackXstart = this.dicTrack.Values.ToList().GetRange(0, indexTrack).Sum();
                int curTrackXend = curTrackXstart + dicTrack[sIDcurrentTrack];
                this.lblDrawMove.Location = new Point(curTrackXend,curPage.iHeightMapTitle);
                //先把lable放到边界
                if (Math.Abs(e.MousePosition.X - curTrackXend) <= 2)
                {
                    isDragging = 1;
                    this.lblDrawMove.Focus();
                    this.lblDrawMove.Visible = true;
                    lblDrawMove.Height = this.webBrowserHead.Height - curPage.iHeightMapTitle;
                    clickOffSetX = curTrackXend;
                }
                else if (Math.Abs(e.MousePosition.Y - curPage.iHeightMapTitle) <= 2)
                {
                    isDragging = 2;
                    this.lblCrossH.Visible = true;
                    this.lblCrossH.Focus();
                    this.lblCrossH.Location = new Point(0, curPage.iHeightMapTitle);
                    clickOffSetY = curPage.iHeightMapTitle;
                }
                else if (Math.Abs(e.MousePosition.Y - (curPage.iHeightMapTitle+curPage.iHeightTrackHead)) <= 2)
                {
                    isDragging = 3;
                    this.lblCrossH.Visible = true;
                    this.lblCrossH.Focus();
                    this.lblCrossH.Location = new Point(0, curPage.iHeightMapTitle + curPage.iHeightTrackHead);
                    clickOffSetY = curPage.iHeightMapTitle + curPage.iHeightTrackHead;
                }
            }
        }
        void htmlDocHead_MouseUp(object sender, HtmlElementEventArgs e)
        {
            Cursor.Current = Cursors.Default;
            int iOffDisX = lblDrawMove.Left - clickOffSetX;
            int iOffDisY = lblCrossH.Top - clickOffSetY;     //注意用的lbl不同
            if (isDragging == 1 && sIDcurrentTrack != "" && iOffDisX != 0)
            {
                int iNewTrackWidth = dicTrack[sIDcurrentTrack] + iOffDisX;
                if (iNewTrackWidth >= 5)
                {
                    cXEtrack.setTrackWidth(this.filePathTemple, sIDcurrentTrack, iNewTrackWidth.ToString());
                    userFunctionPointer.DynamicInvoke(1);
                }
            }
            else if (isDragging == 2 && iOffDisY != 0)
            {
                int iNewTitleHeigh = curPage.iHeightMapTitle + iOffDisY;
                if (iNewTitleHeigh >= 10)
                {
                    cXmlBase.setNodeInnerText(filePathTemple, cXEWellPage.fullPathMapTitleRectHeight, iNewTitleHeigh.ToString());
                    userFunctionPointer.DynamicInvoke(1);
                } 
            }
            else if (isDragging == 3 && iOffDisY != 0)
            {
                int iNewHeadRectHeigh =curPage.iHeightTrackHead + iOffDisY;
                if (iNewHeadRectHeigh >= 10)
                {
                    cXmlBase.setNodeInnerText(filePathTemple, cXEWellPage.fullPathTrackRectHeight, iNewHeadRectHeigh.ToString());
                    userFunctionPointer.DynamicInvoke(1);
                }
            }
            isDragging = 0;
            this.lblDrawMove.Visible = false;
            this.lblCrossH.Visible = false;
            Cursor.Current = Cursors.Default;
        }

        void htmlDocHead_MouseMove(object sender, HtmlElementEventArgs e)
        {
            int indexTrack = this.dicTrack.Keys.ToList().IndexOf(sIDcurrentTrack);
            if (indexTrack >= 0)
            {
                int curTrackXstart = this.dicTrack.Values.ToList().GetRange(0, indexTrack).Sum();
                int curTrackXend = curTrackXstart + dicTrack[sIDcurrentTrack];
                if (Math.Abs(e.MousePosition.X - curTrackXend) <= 2)
                {
                    Cursor.Current = Cursors.SizeWE;
                    this.lblDrawMove.Focus();
                    //保存上个一个clickX
                }
                else if (Math.Abs(e.MousePosition.Y - curPage.iHeightMapTitle) <= 2)
                {
                    Cursor.Current = Cursors.SizeNS;
                    this.lblCrossH.Focus();
                }
                else if (Math.Abs(e.MousePosition.Y - (curPage.iHeightMapTitle + curPage.iHeightTrackHead)) <= 2)
                {
                    Cursor.Current = Cursors.SizeNS;
                    this.lblCrossH.Focus();
                }
                else
                {
                    Cursor.Current = Cursors.Default;
                }
            }
            if (isDragging == 1 && e.MouseButtonsPressed == MouseButtons.Left)
            {
                Cursor.Current = Cursors.SizeWE;
                lblDrawMove.Left = e.MousePosition.X - 1;
            }
            else if (isDragging == 2&& e.MouseButtonsPressed == MouseButtons.Left)
            {
                Cursor.Current = Cursors.SizeNS;
                lblCrossH.Top = e.MousePosition.Y + 1;
            }
            else if (isDragging == 3&& e.MouseButtonsPressed == MouseButtons.Left)
            {
                Cursor.Current = Cursors.SizeNS;
                this.webBrowserHead.Height += 30;
                lblCrossH.Top = e.MousePosition.Y + 1;
            } 
            else
                this.lblDrawMove.Visible = false; 
            
        }

        private void webBrowserBody_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            // 定位上次页面位置
            htmlDocWebBody = webBrowserBody.Document;
            if (htmlDocWebBody != null)
            {
                curPage.initial(this.filePathTemple);
                fVscale = float.Parse(cXmlBase.getNodeInnerText(this.filePathTemple, cXEWellPage.fullPathVSacle));
                string sJH = cXmlBase.getNodeInnerText(filePathTemple, cXmlDocSectionWell.fullPathJH);
                curWell = cProjectData.ltProjectWell.FirstOrDefault(p => p.sJH == sJH);
                if (webBrowserBody.Url == e.Url)
                {
                    //记录元素的位置，实现刷新页面自动滚动
                    webBrowserBody.Document.Window.ScrollTo(PscrollOffset);
                    //Head 水平相同，
                    webBrowserHead.Document.Window.ScrollTo(PscrollOffset.X, 0);
                }

                //清除webHead的所有事件
                if (htmlDocWebHead != null)
                {
                    htmlDocWebHead.MouseMove -= htmlDocHead_MouseMove;
                    htmlDocWebHead.MouseDown -= htmlDocHead_MouseDown;
                    htmlDocWebHead.MouseUp -= htmlDocHead_MouseUp;
                }

                htmlDocWebBody.Window.DetachEventHandler("onscroll", OnScrollEventHandler);
                htmlDocWebBody.Window.AttachEventHandler("onscroll", OnScrollEventHandler);

                htmlDocWebBody.MouseMove -= htmlDocBody_MouseMove;
                htmlDocWebBody.MouseMove += htmlDocBody_MouseMove;

                htmlDocWebBody.MouseDown -= htmlDocBody_MouseDown;
                htmlDocWebBody.MouseDown += htmlDocBody_MouseDown;
            }
        }

        public int iCountClick = 0;

        public void setTrackIntervalEditMode() 
        {
            htmlDocWebBody.MouseMove -= htmlDocBody_MouseMove;
            htmlDocWebBody.MouseMove += htmlDocBody_MouseMove;

            htmlDocWebBody.MouseDown -= htmlDocBody_MouseDown;
            htmlDocWebBody.MouseDown += htmlDocBody_MouseDown;


            this.lblCrossH.Visible = true;
            this.lblCrossV.Visible = true;
            this.lblmarker.Visible = true;
       
        }
        void htmlDocBody_MouseDown(object sender, HtmlElementEventArgs e)
        {
            if (e.MouseButtonsPressed == MouseButtons.Left)
            {
                iCountClick++;
                if (iCountClick % 2 == 0)
                {
                    pDepth.X = (6 + PscrollOffset.Y + e.MousePosition.Y) / fVscale;
                    lblmarker.Text = "<=" + pDepth.X.ToString("0.00");
                }

                if (iCountClick % 2 == 1)
                {
                    pDepth.Y = (6 + PscrollOffset.Y + e.MousePosition.Y) / fVscale;
                    lblmarker.Text = "<=" + pDepth.Y.ToString("0.00");
                } 
                lblmarker.Location = new Point(0, e.MousePosition.Y - lblmarker.Height/2);
            }
            tsslblAna.Text = "分析 y1=" + pDepth.X.ToString("0.00")
                + " y2=" + pDepth.Y.ToString("0.00")
                + " 厚度=" + Math.Abs(pDepth.X - pDepth.Y).ToString("0.00");
        }

        void htmlDocBody_MouseMove(object sender, HtmlElementEventArgs e)
        {
            fCurrentMD = (6 + PscrollOffset.Y + e.MousePosition.Y) / fVscale;
            fCurrentTVD = cIOinputWellPath.getTVDByJHAndMD(curWell, fCurrentMD);
            if (e.MousePosition.X <= lblCrossH.Width + 3) lblCrossV.Location = new Point(e.MousePosition.X - 5, this.webBrowserBody.Location.Y + this.webBrowserHead.Height);
            lblCrossV.Height = this.webBrowserBody.Height - this.webBrowserHead.Height;
            lblCrossH.Location = new Point(this.webBrowserBody.Location.X, e.MousePosition.Y + 5);
            this.tsslblDepth.Text = "测深=" + fCurrentMD.ToString("0.00") + " 垂深=" + fCurrentTVD.ToString("0.00");
        }

      

        private void tsmiIntervalStastics_Click(object sender, EventArgs e)
        {
            float fTopInfor = Math.Min(pDepth.X, pDepth.Y);
            float fBotInfor = Math.Max(pDepth.X, pDepth.Y);
            ItemTrackDataIntervalProperty itemDepth = new ItemTrackDataIntervalProperty(fTopInfor,fBotInfor);
            itemDepth.calTVD(curWell);
            makeSectionWell.calInterStastics(filePathTemple, itemDepth); 
        }

        private void tsmiLayerStastics_Click(object sender, EventArgs e)
        {
            if (sIDcurrentTrack != "")
                makeSectionWell.calInterStastics(filePathTemple, sIDcurrentTrack);
        }

        private void tsmiCrossPlot_Click(object sender, EventArgs e)
        {
            float fTopInfor = Math.Min(pDepth.X, pDepth.Y);
            float fBotInfor = Math.Max(pDepth.X, pDepth.Y);
            FormSectionWellCrossplot newCrossPlot = new FormSectionWellCrossplot(filePathTemple, this.sIDcurrentTrack, fTopInfor, fBotInfor);
            newCrossPlot.Show();
        }

        private void tsmiLogCal_Click(object sender, EventArgs e)
        {
            float fTopInfor = Math.Min(pDepth.X, pDepth.Y);
            float fBotInfor = Math.Max(pDepth.X, pDepth.Y);
            FormMakeNewLog newLog = new FormMakeNewLog(filePathTemple, fTopInfor, fBotInfor);
            newLog.Show();
        }

        private void tsmiBodyLogValue_Click(object sender, EventArgs e)
        {
            FormSectionLogInforByDepth newInforLog = new FormSectionLogInforByDepth(fCurrentMD);
            newInforLog.ShowDialog();
        }

        private void tsmiHeadLogRemove_Click(object sender, EventArgs e)
        {
            XmlNode selectTrack = cXmlBase.selectNodeByID(filePathTemple, sIDcurrentTrack);
            string typeTrackstr = cXmlDocSectionWell.getTrackTypeByID(filePathTemple, sIDcurrentTrack);
            if (typeTrackstr == TypeTrack.曲线道.ToString() && sIDcurrentItem.StartsWith("idLog"))
            {
                cXmlDocSectionWell.deleteItemByID(filePathTemple, sIDcurrentItem);
                userFunctionPointer.DynamicInvoke(0); //0全刷，1只刷树
            } 
        }

        private void tsmiHeadRefresh_Click(object sender, EventArgs e)
        {
            this.RefreshSVG();
        }
       

        } //end class
}//end 
