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

namespace DOGPlatform
{
    //成图方法 
    // 1. 选择井
    // 2. 根据层位或者海拔确定深度段深度
    // 3. 根据深度提取成图原始数据文件，放在临时文件下
    // 4. 读取各个临时文件，成图
    //
    public partial class FormSectionDevelop : Form
    {
        string dirSectionData = Path.Combine(cProjectManager.dirPathTemp, "sectionGeoTemp");
        int ElevationRulerTop = 0;
        int ElevationRulerBase = -2000;
        int PageWidth = 3000;
        int PageHeight = cProjectData.setDefaultPageHeight();
        string sUnit ="px"; 
        string pathSectionCss= cProjectManager.xmlSectionCSS;
      
        List<string> ltStrSelectedJH = new List<string>();  //联井剖面井号
        //存储绘图剖面数据结构
        List<ItemWellSection> listWellsSection = new List<ItemWellSection>();
     
        public FormSectionDevelop()
        {
            InitializeComponent();
        }
        private void FormNewWellSection_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitFormWellsGroupControl();
        }

        private void InitFormWellsGroupControl()
        {
            cPublicMethodForm.inialListBox(lbxJH, cProjectData.ltStrProjectJH);
            cPublicMethodForm.inialComboBox(cbbTopXCM, cProjectData.ltStrProjectXCM);
            cPublicMethodForm.inialComboBox(cbbBottomXCM, cProjectData.ltStrProjectXCM);
            cPublicMethodForm.inialComboBox(cbbLogName, cProjectData.ltStrProjectGlobeLog);
        }

        private void btn_addWell_Click(object sender, EventArgs e)
        {
            cPublicMethodForm.transferItemFromleftListBox2rightListBox(lbxJH, lbxJHSeclected);
        }
        private void btn_deleteWell_Click(object sender, EventArgs e)
        {
            cPublicMethodForm.deleteSlectedItemFromListBox(lbxJHSeclected);
        }
        private void btn_upWell_Click(object sender, EventArgs e)
        {
            cPublicMethodForm.upItemInListBox(lbxJHSeclected);
        }
        private void btn_downWell_Click(object sender, EventArgs e)
        {
            cPublicMethodForm.downItemInListBox(lbxJHSeclected);
        }
        void updateSelectedListJH()
        {
            listWellsSection.Clear();
            ltStrSelectedJH.Clear();
            foreach (object selecteditem in lbxJHSeclected.Items)
            {
                string strItem = selecteditem as String;
                ltStrSelectedJH.Add(strItem);
            }
        }

        private void btnSectionData_Click(object sender, EventArgs e)
        {
            setDepthIntervalShowedBYLayer();
        }

        void initializeTreeViewWellCollection()
        {
            this.tvWellSectionCollection.Nodes.Clear();
            for (int i = 0; i < ltStrSelectedJH.Count; i++)
            {
                TreeNode tnWell = new TreeNode();
                tnWell.Text = ltStrSelectedJH[i];
                tnWell.Name = ltStrSelectedJH[i];
                tnWell.Nodes.Add("左侧曲线");
                tnWell.Nodes.Add("右侧曲线");
                tvWellSectionCollection.Nodes.Add(tnWell);
            }
        }

        private void setDepthIntervalShowedBYLayer()
        {
            updateSelectedListJH();
            List<string> ltStrSelectedXCM = new List<string>();

            string sTopXCM = this.cbbTopXCM.SelectedItem.ToString();
            int iTopIndex = cProjectData.ltStrProjectXCM.IndexOf(sTopXCM);
            string sBottomXCM = this.cbbBottomXCM.SelectedItem.ToString();
            int iBottomIndex = cProjectData.ltStrProjectXCM.IndexOf(sBottomXCM);

            if (iBottomIndex - iTopIndex >= 0)
            {
                ltStrSelectedXCM = cProjectData.ltStrProjectXCM.GetRange(iTopIndex, iBottomIndex - iTopIndex + 1);
                initializeTreeViewWellCollection();
                int _up = Convert.ToInt16(this.nUDtopDepthUp.Value);
                int _down = Convert.ToInt16(this.nUDbottomDepthDown.Value);

                for (int i = 0; i < ltStrSelectedJH.Count; i++)
                {
                    ItemWellSection _wellSection = new ItemWellSection(ltStrSelectedJH[i], 0, 0);
                    //有可能上下层有缺失。。。所以这块的技巧是找出深度序列，取最大最小值
                    cIOinputLayerDepth fileLayerDepth = new cIOinputLayerDepth();
                    List<float> fListDS1Return = fileLayerDepth.selectDepthListFromLayerDepthByJHAndXCMList(ltStrSelectedJH[i], ltStrSelectedXCM);
                    if (fListDS1Return.Count > 0)  //返回值为空 说明所选层段整个缺失！
                    {
                        _wellSection.fShowedDepthTop = fListDS1Return.Min() - _up;
                        _wellSection.fShowedDepthBase = fListDS1Return.Max() + _down;
                    }

                    listWellsSection.Add(_wellSection);
                }
                cXmlDocSectionGeo.generateSectionCssXML(cProjectManager.xmlSectionCSS);
                generateSectionDataDirectory();
            }
            else
            {
                MessageBox.Show("上层应该比下层选择高，请重新选择。");
            }
        }

        void generateSectionDataDirectory()
        {
            if (Directory.Exists(dirSectionData)) Directory.Delete(dirSectionData, true);
            Directory.CreateDirectory(dirSectionData);
            foreach (ItemWellSection item in listWellsSection)
            {
                string jhDir = Path.Combine(dirSectionData, item.sJH);
                Directory.CreateDirectory(jhDir);
                Directory.CreateDirectory(jhDir + "\\left");
                Directory.CreateDirectory(jhDir + "\\right");
            }
        }

        private void btnGenerateDataByInputDepth_Click(object sender, EventArgs e)
        {
            setDepthIntervalShowedBYElevationDepth();
        }

        private void setDepthIntervalShowedBYElevationDepth()
        {
            updateSelectedListJH();
            int iTopElevation = int.Parse(this.tbxTopElevationInput.Text);
            int iBottomElevation = int.Parse(this.tbxBottomElevationInput.Text);

            initializeTreeViewWellCollection();
            for (int i = 0; i < ltStrSelectedJH.Count; i++)
            {
                ItemWellSection _wellSection = new ItemWellSection(ltStrSelectedJH[i], 0, 0);
                //海拔转成md
                _wellSection.fShowedDepthTop = _wellSection.fKB - iTopElevation;
                _wellSection.fShowedDepthBase = _wellSection.fKB - iBottomElevation;
                if (_wellSection.fShowedDepthBase >= _wellSection.fWellBase) _wellSection.fShowedDepthBase = _wellSection.fWellBase;
                listWellsSection.Add(_wellSection);
            }
            cXmlDocSectionGeo.generateSectionCssXML(pathSectionCss);
            generateSectionDataDirectory();
        }

        void openExitGraph()
        {
            XDocument sectionMapXML = XDocument.Load(cProjectManager.xmlSectionCSS);
            XElement XWellCollect = sectionMapXML.Element("SectionMap").Element("WellCollection");

            foreach (XElement el in XWellCollect.Elements())
            {
                string sJH = el.Attribute("id").Value;
                double dbX = double.Parse(el.Element("X").Value);
                double dbY = double.Parse(el.Element("Y").Value);
                float fKB = float.Parse(el.Element("KB").Value);
                float fTopShowed = float.Parse(el.Element("fShowedTop").Value);
                float fBaseShowed = float.Parse(el.Element("fShowedBottom").Value);
            }
        }

       
        void generateSectionGraph( string filenameSVGMap,bool bView)
        {
            
            //xml存数据不合适 因为会有大量的井数据，但是可以存个样式，样式搭配数据，样式里可以有道宽，这样做到数据和样式的分离，成图解析器解析样式就OK。

            //定义每口井绘制的位置坐标，剖面图y=0，井组分析x，y是井点坐标变换值
            //定义 iChoise==1 等间隔排列，iChoise==2 相邻井真实距离缩放 
            int iChoise = 2;
            if (rdbPlaceByEqual.Checked == true) iChoise = 1;
            List<Point> PListWellPositon = new List<Point>(); 
            
            
            //根据默认值定义section的页面大小及标题,根据海拔确定纵向的平移高度
            int iDY = (int)listWellsSection.Select(p => p.fKB).ToList().Max() + 100;
            cSVGDocSection svgSection = new cSVGDocSection(PageWidth, PageHeight, 0, iDY, sUnit);
            string sTitle=string.Join("-", listWellsSection.Select(p => p.sJH).ToList()) + "开发剖面图";
            svgSection.addMapTitle(sTitle, 100, 100); 

            XmlElement returnElemment;
            //画井距尺
            for (int i = 0; i < this.listWellsSection.Count-1; i++)
            {
                if (rdbPlaceBYWellDistance.Checked == true)
                {
                    //距离是2口相邻井的距离
                    int iDistance = Convert.ToInt16(c2DGeometryAlgorithm.calDistance2D(listWellsSection[i].dbX, listWellsSection[i].dbY, listWellsSection[i+1].dbX, listWellsSection[i+1].dbY));
                    returnElemment = svgSection.gWellDistanceRuler(iDistance, PListWellPositon[i + 1].X - PListWellPositon[i].X);
                    svgSection.addgElement2BaseLayer(returnElemment, PListWellPositon[i].X, (int)listWellsSection[0].fYview);//拉到同一水平线
                    //画井距尺
                }
            }

            ElevationRulerBase = -PageHeight/100*100;
            //海拔深度时 增加海拔尺，拉平不要海拔尺
      
                int iScaleElevationRuler = 50;
                returnElemment = cSVGSectionTrackWellRuler.gElevationRuler(svgSection.svgDoc,ElevationRulerTop, ElevationRulerBase, iScaleElevationRuler);
                svgSection.addgElement2BaseLayer(returnElemment, 10);

            //根据井序列循环添加井剖面
            for (int i = 0; i < listWellsSection.Count; i++)
            {
                string sJH = listWellsSection[i].sJH;

                List<ItemDicWellPath> currentWellPathList = cProjectData.ltProjectWell.Find(p => p.sJH == sJH).WellPathList;
                float fTopShowed = listWellsSection[i].fShowedDepthTop;
                float fBaseShowed = listWellsSection[i].fShowedDepthBase;
                float fDepthFlatted = listWellsSection[i].fYview;

                cSVGSectionWell currentWell = new cSVGSectionWell(svgSection.svgDoc,sJH);


                //增加地层道
                trackDataListLayerDepth getTrackDataListLayerDepth = cIOWellSection.getTrackDataListLayerDepth(sJH, dirSectionData, fTopShowed, fBaseShowed);
                int iTrackWidth = 15;
                cSVGSectionTrackLayer layerTrack = new cSVGSectionTrackLayer(iTrackWidth);
                layerTrack.iTextSize = 6;
                if (rdbDepthModelTVD.Checked == true && currentWellPathList.Count > 2)
                    returnElemment = layerTrack.gXieTrack2VerticalLayerDepth(sJH, getTrackDataListLayerDepth, fDepthFlatted); 
                else returnElemment = layerTrack.gTrackLayerDepth(sJH,getTrackDataListLayerDepth, fDepthFlatted);
                currentWell.addTrack(returnElemment, iTrackWidth);

                //增加联井的view
                              //增加测井解释
                trackDataListJSJL trackDataListJSJL = cIOWellSection.getTrackDataListJSJL(sJH,dirSectionData, fTopShowed, fBaseShowed);
                iTrackWidth = 15;
                cSVGSectionTrackJSJL JSJLTrack = new cSVGSectionTrackJSJL(iTrackWidth);
                if (rdbDepthModelTVD.Checked == true && currentWellPathList.Count > 2) 
                    returnElemment = JSJLTrack.gXieTrack2VerticalJSJL(sJH, trackDataListJSJL, fDepthFlatted);
                 else returnElemment = JSJLTrack.gTrackJSJL(sJH,trackDataListJSJL, fDepthFlatted);
                currentWell.addTrack(returnElemment, -iTrackWidth);

                //增加射孔道
                trackInputPerforationDataList getTrackDataListPerforation =cIOWellSection.getTrackDataListPerforation(sJH,dirSectionData,  fTopShowed, fBaseShowed);
                iTrackWidth = 15;
                cSVGSectionTrackPeforation perforationTrack = new cSVGSectionTrackPeforation(iTrackWidth);
                if (rdbDepthModelTVD.Checked == true && currentWellPathList.Count > 2)
                    returnElemment = perforationTrack.gXieTrack2VerticalPerforation(sJH, getTrackDataListPerforation, fDepthFlatted);
                 else returnElemment = perforationTrack.gTrackPerforation(sJH,getTrackDataListPerforation, fDepthFlatted);
                currentWell.addTrack(returnElemment, -2 * iTrackWidth);

                //增加吸水剖面
                trackDataListProfile trackDataListProfile = cIOWellSection.getTrackDataListProfile(sJH,dirSectionData, fTopShowed, fBaseShowed);
                iTrackWidth = 15;
                cSVGSectionTrackProfile profileTrack = new cSVGSectionTrackProfile(iTrackWidth);
                returnElemment = profileTrack.gTrackProfile(sJH, trackDataListProfile, fDepthFlatted);
                if (currentWellPathList.Count > 2)
                    returnElemment = profileTrack.gXieTrack2VerticalProfile(sJH, trackDataListProfile, fDepthFlatted);
                else returnElemment = profileTrack.gTrackProfile(sJH, trackDataListProfile, fDepthFlatted);
                currentWell.addTrack(returnElemment, 15);

                //增加左边曲线
                string fileLeftLogScrPath = Path.Combine(dirSectionData, sJH + "\\left");
                foreach (string fileLog in Directory.GetFileSystemEntries(fileLeftLogScrPath))
                {
                    //trackDataListLog trackDataListLeftLog = trackDataListLog.setupDataListTrackLog(fileLog, fTopShowed, fBaseShowed);
                    iTrackWidth = 15;

                    //cSVGSectionTrackLog logTrack = new cSVGSectionTrackLog(iTrackWidth);
                    //if (rdbDepthModelTVD.Checked == true && currentWellPathList.Count > 2)
                    //    returnElemment = logTrack.gXieTrack2VerticalLog(sJH, trackDataListLeftLog, fDepthFlatted);
                    //else returnElemment = logTrack.gTrackLog(sJH, trackDataListLeftLog, fDepthFlatted);
                    //currentWell.addTrack(returnElemment, -30);
                }

                //增加右边曲线
                string fileRightLogScrPath = Path.Combine(dirSectionData, sJH + "\\right");
                foreach (string fileLog in Directory.GetFileSystemEntries(fileRightLogScrPath))
                {
                    //trackDataListLog trackDataListRightLog = trackDataListLog.setupDataListTrackLog(fileLog, fTopShowed, fBaseShowed);
                    iTrackWidth = 15;
                    //cSVGSectionTrackLog logTrack = new cSVGSectionTrackLog(iTrackWidth);
                    //if (rdbDepthModelTVD.Checked == true && currentWellPathList.Count > 2)
                    //    returnElemment = logTrack.gXieTrack2VerticalLog(sJH, trackDataListRightLog, fDepthFlatted);
                    //else returnElemment = logTrack.gTrackLog(sJH,  trackDataListRightLog, fDepthFlatted);

                    //currentWell.addTrack(returnElemment, iTrackWidth);
                } 
                svgSection.addgElement2BaseLayer(currentWell.gWell,  PListWellPositon[i].X);
            }

            //同名小层连线的实现 在绘制小层layertrack的时候，把小层的顶底深的绘制点记录，然后此处当做polyline绘制
            bool bConnect = this.cbxConnectSameLayerName.Checked;

            string fileSVG = Path.Combine(cProjectManager.dirPathMap, filenameSVGMap);
            svgSection.makeSVGfile(fileSVG);
            if (bView == false)
            {
                FormMain.filePathWebSVG = fileSVG;
                this.Close();
            }

        }
      
        private void btnMakeSection_Click(object sender, EventArgs e)
        {
            string filenameSVGMap = (this.tbxTitle.Text == "") ? (String.Format("开发剖面-{0}_{1}_({2}).svg",ltStrSelectedJH[0],ltStrSelectedJH.LastOrDefault(),ltStrSelectedJH.Count)):(this.tbxTitle.Text + ".svg"); 
            generateSectionGraph( filenameSVGMap,false ) ; 
        }

        private void btnAddLayerDepth_Click(object sender, EventArgs e)
        {
            if (ltStrSelectedJH.Count > 0)
            {
                foreach (string sJH in ltStrSelectedJH) cIOWellSection.addSectionDataLayerDepth(sJH, dirSectionData); //提取所选井段数据存入绘图目录下保存
                addTreeViewWellSectionCollection("地层");
                cXmlDocSectionGeo.addTrackLayer(cProjectManager.xmlSectionCSS, "idLayer",20);
            }
            else
            {
                MessageBox.Show("请先确认深度段。");
            }
        }

        private void btnAddJSJLTrack_Click(object sender, EventArgs e)
        {
            if (listWellsSection.Count > 0)
            {
                foreach (string sJH in ltStrSelectedJH) cIOWellSection.addSectionDataJSJL(sJH, dirSectionData); //提取所选井段数据存入绘图目录下保存 
                addTreeViewWellSectionCollection("测井解释");
             
                cXmlDocSectionGeo.addTrackJSJL(cProjectManager.xmlSectionCSS, "idJSJL", 20);
            }
            else
            {
                MessageBox.Show("请先确认深度段。");
            }
        }

        void addLogData(int iLeftOrRight, string sSelectedLogName)
        {
            //iLeftOrRight, 0 左 1 右
            foreach (string sJH in ltStrSelectedJH)
            {
                string filePath = Path.Combine(dirSectionData, sJH + "\\left\\" + sSelectedLogName + ".txt");
                if (iLeftOrRight == 1)
                {
                    filePath = Path.Combine(dirSectionData, sJH + "\\right\\" + sSelectedLogName + ".txt");
                }
                cIOWellSection.addLog(sJH, sSelectedLogName, filePath);
            }
            foreach (TreeNode wellNote in tvWellSectionCollection.Nodes)
            {
                TreeNode tnLog = new TreeNode();
                tnLog.Text = sSelectedLogName;
                wellNote.Nodes[iLeftOrRight].Nodes.Add(tnLog);
            }

            tvWellSectionCollection.ExpandAll();
           
            string sLogName=this.cbbLogName.SelectedItem.ToString();
            string sLogColor=cPublicMethodBase.getRGB(cbbLogColor.BackColor);
            float fRightValue=Convert.ToSingle(nUDLogRightValue.Value);
            float fLeftValue=Convert.ToSingle(nUDLogLeftValue.Value);
            cIOWellSection.addLogProperty(sLogName, sLogColor,fLeftValue, fRightValue, iLeftOrRight);
        }
        
        void deleteLogData(int iLeftOrRight, string sSelectedLogName)
        {

            foreach (string sJH in ltStrSelectedJH)
            {
                string filePath = Path.Combine(dirSectionData, sJH + "\\leftLog.txt");
                if (iLeftOrRight == (int)LeftOrRight.right)
                {
                    filePath = Path.Combine(dirSectionData, sJH + "\\rightLog.txt");
                }

            }
            foreach (TreeNode wellNote in tvWellSectionCollection.Nodes)
            {
                if (iLeftOrRight == (int)LeftOrRight.left)
                {
                    TreeNode tnLeftLog = new TreeNode();
                    tnLeftLog.Text = "左侧曲线";
                    tnLeftLog.Name = LeftOrRight.left.ToString();
                    tnLeftLog.Nodes.Add(sSelectedLogName);
                    wellNote.Nodes.Add(tnLeftLog);
                }
                else
                {
                    TreeNode tnRightLog = new TreeNode();
                    tnRightLog.Text = "右侧曲线";
                    tnRightLog.Name = LeftOrRight.right.ToString();
                    tnRightLog.Nodes.Add(sSelectedLogName);
                    wellNote.Nodes.Add(tnRightLog);
                }
            }
            tvWellSectionCollection.ExpandAll();
        }
        private void btnAddLeftLogTrack_Click(object sender, EventArgs e)
        {
            if (ltStrSelectedJH.Count > 0 && cbbLogName.SelectedIndex >= 0)
            {
                string sSelectedLogName = this.cbbLogName.SelectedItem.ToString();
                if(rdbLeft.Checked==true) addLogData(0, sSelectedLogName);
                else addLogData(1, sSelectedLogName); 
            }
            else
            {
                MessageBox.Show("请先确认深度段。");
            }

        }
        private void cbbLeftLogColor_Click(object sender, EventArgs e)
        {
            cPublicMethodForm.setComboBoxBackColorByColorDialog(cbbLogColor);
        }

        private void tvwWellSectionCollection_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectNode = tvWellSectionCollection.SelectedNode;
            ContextMenuStrip cmsSection = new System.Windows.Forms.ContextMenuStrip();
            tvWellSectionCollection.ContextMenuStrip = cmsSection;
            string _sJH = "";
            string _fileLogScrPath = "";
            string _sLogName = "";
            cCMSsetupWellSection cCMSsetup;

            switch (selectNode.Level)
            {
                case 0:
                    break;
                case 1:
                    _sJH = selectNode.Parent.Text;
                    switch (selectNode.Text)
                    {
                        case "左侧曲线":
                            _fileLogScrPath = Path.Combine(dirSectionData, _sJH + "\\left");
                            cCMSsetup = new cCMSsetupWellSection
                                            (cmsSection, selectNode, _sJH, _sLogName, _fileLogScrPath);
                            cCMSsetup.setupTsmiLogAdd();
                            cmsSection = cCMSsetup.cms;
                            break;
                        case "右侧曲线":
                            _fileLogScrPath = Path.Combine(dirSectionData, _sJH + "\\right");
                            cCMSsetup = new cCMSsetupWellSection
                                            (cmsSection, selectNode, _sJH, _sLogName, _fileLogScrPath);
                            cCMSsetup.setupTsmiLogAdd();
                            cmsSection = cCMSsetup.cms;
                            break;
                        default:
                            break;
                    }
                    break;
                case 2:
                    _sJH = selectNode.Parent.Parent.Text;
                    _sLogName = selectNode.Text;
                    _fileLogScrPath = Path.Combine(dirSectionData, _sJH + "\\right");
                    if (selectNode.Parent.Parent.Text == "左侧曲线")
                    {
                        _fileLogScrPath = Path.Combine(dirSectionData, _sJH + "\\left");
                    }

                    cCMSsetup = new cCMSsetupWellSection
                         (cmsSection, selectNode, _sJH, _sLogName, _fileLogScrPath);
                    cCMSsetup.setupTsmiLogDelete();
                    cCMSsetup.setupTsmiLogSetting();
                    cmsSection = cCMSsetup.cms;
                    break;
                case 3:
                    MessageBox.Show(selectNode.Text);
                    break;
                default:
                    break;
            }
        }

        void addTreeViewWellSectionCollection(string treenodeText)
        {
            foreach (TreeNode wellNote in tvWellSectionCollection.Nodes)
            {
                TreeNode tn = new TreeNode(treenodeText);
                if (!cPublicMethodForm.NodeExists(wellNote, treenodeText)) wellNote.Nodes.Add(tn);
            }
            tvWellSectionCollection.ExpandAll();
        }

        private void btnAddPeforation_Click(object sender, EventArgs e)
        {
            if (ltStrSelectedJH.Count > 0)
            {
                foreach (string sJH in ltStrSelectedJH) cIOWellSection.addSectionDataPerforation(sJH, dirSectionData); //提取所选井段数据存入绘图目录下保存
                addTreeViewWellSectionCollection("射孔");
            }
            else
            {
                MessageBox.Show("请先确认深度段。");
            }
        }

        private void cbbBottomXCM_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbbTopXCM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbBottomXCM.Items.Count > 0)
                this.cbbBottomXCM.SelectedIndex = cbbTopXCM.SelectedIndex;
        }

        private void btnAddProfile_Click(object sender, EventArgs e)
        {
            if (ltStrSelectedJH.Count > 0)
            {
                foreach (string sJH in ltStrSelectedJH) cIOWellSection.addSectionDataProfile(sJH, dirSectionData); //提取所选井段数据存入绘图目录下保存 
                addTreeViewWellSectionCollection("吸水");
            }
            else MessageBox.Show("请先确认深度段。");
        }

        private void btnGenerateDataByBaseDepth_Click(object sender, EventArgs e)
        {
            setDepthIntervalShowedBYBaseDepth();
        }

        private void setDepthIntervalShowedBYBaseDepth()
        {
            updateSelectedListJH();

            initializeTreeViewWellCollection();
            List<ItemWellHead> listWellHead= cIOinputWellHead.readWellHead2Struct();
           for (int i = 0; i < ltStrSelectedJH.Count; i++)
            {
                ItemWellSection _wellSection = new ItemWellSection(ltStrSelectedJH[i], 0, 0);
                _wellSection.fShowedDepthTop = 0;
                _wellSection.fShowedDepthBase = listWellHead.Find(p => p.sJH == ltStrSelectedJH[i]).fWellBase;
                listWellsSection.Add(_wellSection); 
            }
           cXmlDocSectionGeo.generateSectionCssXML(pathSectionCss);
            generateSectionDataDirectory(); 
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            string tempSVGViewfilepath = Path.Combine(cProjectManager.dirPathTemp, "#view.svg");
            if (rdbFlattedByDepth.Checked == true) generateSectionGraph( tempSVGViewfilepath, true);
            else if (rdbFlattedByTopDepth.Checked == true) generateSectionGraph( tempSVGViewfilepath, true);
            else if (rdbFlattedByBaseDepth.Checked == true) generateSectionGraph( tempSVGViewfilepath, true);
            this.webBrowserSVG.Navigate(new Uri(tempSVGViewfilepath));
            this.tbcSectionDev.SelectedTab = this.tbgViewEdit;
        }
        
        private void btnDeleteLog_Click(object sender, EventArgs e)
        {
            if (ltStrSelectedJH.Count > 0 && cbbLogName.SelectedIndex >= 0)
            {
                string sSelectedLogName = this.cbbLogName.SelectedItem.ToString();
                foreach (string _sJH in ltStrSelectedJH)
                {
                    string _fileLogScrPath = "";
                    if (rdbLeft.Checked == true) _fileLogScrPath = Path.Combine(dirSectionData, _sJH + "\\left");
                    else _fileLogScrPath = Path.Combine(dirSectionData, _sJH + "\\right");
                    cIOWellSection.delLog(_fileLogScrPath, sSelectedLogName);
                }
                foreach (TreeNode wellNote in tvWellSectionCollection.Nodes)
                {
                    TreeNode tnRet = null;
                    foreach (TreeNode tn in wellNote.Nodes)
                    {
                        tnRet = cPublicMethodForm.FindNode(tn, sSelectedLogName);
                        if (tnRet != null) { tnRet.Remove(); break; }
                    }
                }

                tvWellSectionCollection.ExpandAll();
            }

        }

        private void btnData_Click(object sender, EventArgs e)
        {

        }

        private void btnAddTrack_Click(object sender, EventArgs e)
        {

        }

        private void tvSectionEdit_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void tvSectionEdit_DoubleClick(object sender, EventArgs e)
        {

        }

        private void tvSectionEdit_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void btnSaveModel_Click(object sender, EventArgs e)
        {

        }

        private void btnAddLogTrack_Click(object sender, EventArgs e)
        {

        }

        private void cbbLogColor_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void tbxBottomInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbxTopInput_TextChanged(object sender, EventArgs e)
        {

        }

      

      


    }
}
