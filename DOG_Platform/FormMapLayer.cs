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
using System.Xml;
using System.Xml.Linq;
using System.IO;
using DOGPlatform.XML;
using DOGPlatform.SVG;

using System.Configuration;
using System.Diagnostics;

using System.Runtime.InteropServices;
using System.Security.Permissions;

namespace DOGPlatform
{
    ///流程设计：通过界面选择形成Layer配置样式及数据， 最后解析器解析xml形成图形。最好能在数据中藏一下原数据文件的位置
    /// 保存小层的静态井位，其它位置及数据位置信息都从这个表中得到。
    /// 原始数据主要是从 静态字典表和动态字典表提取，这两个表的分析计算非常重要。
    /// 
    /// 先准备数据，每个图层数据文件一个文件，便于增加和删除图层，成图，每次成图，重绘即可，图层的样式问题，可以再考虑，先把数据理清楚，不存XML，也不          便于检查错误，先数据，后解析转换坐标，成图。
    /// 每个面板勾选，然后对应的文件夹内对数据文件进行相应的处理
    /// 逻辑顺序：1 选择顶部小层名 2 选择底部显示小层名 3 选择时间（主要考虑不同时间井型的变化）
    /// 根据 小层名 筛选井号 存入listWellsMaper,显示时 应该显示选择层段顶的井位（或者提供可选），需要考虑斜井及断失的情况
    /// 
    /// 井确定后，可以叠加 不同的数据 例如 井点的属性啊，断层信息等。
    /// ！！！！xml文件名必须和SVG一致，要改一起改，这样可以保持图层修改叠加等。
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public partial class FormMapLayer : Form
    {
        //define地质静态井,存所有的井位，动态井位或者其它井位-位置数据都从这里获得
        List<ItemWellMapPosition> listWellsStatic = new List<ItemWellMapPosition>();
        //定义小层数据表链表，存储筛选当前的小层数据
        List<ItemDicLayerDataStatic> listLayersDataCurrentLayerStatic = new List<ItemDicLayerDataStatic>();
        private Stack<string> UndoList = new Stack<string>();
        private Stack<string> RedoList = new Stack<string>();
        private string dirHisUnto = cProjectManager.dirPathHis;
        //定义小层数据表链表，存储筛选当前层当前年月的小层动态数据
        List<string> ltStrSelectedLayers = new List<string>();
        string sSelectLayer="";
        string sSelectYM = DateTime.Now.ToString("yyyyMM");

        string sSelectJH = "";
        List<string> ltSelectJH = new List<string>();
        public PointD pXY = new PointD(0, 0); //记录当前位置
        int PageWidth = 2000;
        int PageHeight = 1500;
        string sUnit = "px";
        //记录上次页面位置，便于下次定位
        Point PscrollOffset = new Point(0, 0);
        //首先初始化一个配置文件，然后具体到小层的时候，再复制这个文件与原文件形成配套配置文件，每次初始化的时候晴空
        string filePathLayerCss;
        string filePathSVGLayerMap;

        string sSelectLayerID;
        string sCurrentID;
        public FormMapLayer()
        {
            InitializeComponent();
            InitFormLayerMap();
        }
        public FormMapLayer(string inputFilePath)
            : this()
        {
            openExistSectionFlow(inputFilePath);
        }
        private void InitFormLayerMap()
        {
            webBrowserSVG.ObjectForScripting = this;
            this.splitContainerLayer.Panel1Collapsed = false ;
            if (cProjectData.ltStrProjectXCM.Count > 0) sSelectLayer = cProjectData.ltStrProjectXCM[0];
        }
        //初始化控件当新建工程或者打开工程时

        void generateSVGfilemapByConfigxml()
        {
            //注意偏移量,偏移主要是为了好看 如果不偏移的话 就会绘到角落上,这时的偏移是整个偏移 后面的不用偏移了，相对偏移0，0
            int idx = 50;
            int idy = 50;
            cSVGDocLayerMap svgLayerMap = new cSVGDocLayerMap( PageWidth, PageHeight, idx, idy, sUnit);
            //add title 
            string sTitle = Path.GetFileNameWithoutExtension(filePathLayerCss);
            svgLayerMap.addMapTitle(sTitle, 50, 20);
            XmlElement returnElemment;
            //svg文件和XML对应的问题还要思考一下
            string filePathSVGLayerMap = Path.Combine(cProjectManager.dirPathTemp, Path.GetFileNameWithoutExtension(filePathLayerCss)+ ".svg");

            //这块需要处理覆盖问题。
            if (File.Exists(filePathSVGLayerMap)) File.Delete(filePathSVGLayerMap);

            //如果顶层面断层数据不为空的话 应该加上断层
            //读取当前顶层的断层数据
            //List<ItemFaultLine> listFaultLine = cIOinputLayerSerier.readInputFaultFile(this.sSelectLayer);
            //foreach (ItemFaultLine line in listFaultLine)
            //{
            //    returnElemment = svgLayerMap.gFaultline(line.ltPoints, "red", 2);
            //    svgLayerMap.addgElement2BaseLayer(returnElemment);
            //}

            //解析当前的XML配置文件，根据每个Layer标签的LayerType生成id为层名的图层，添加到svgLayer中去

            XmlDocument xmlLayerMap = new XmlDocument();
            xmlLayerMap.Load(filePathLayerCss);

            //XmlNode xnBaseLayer = xmlLayerMap.SelectSingleNode("/LayerMapConfig/BaseLayer");
            //returnElemment = svgLayerMap.gWellsPositionFromXML(xnBaseLayer,"井");
            //svgLayerMap.addgElement2BaseLayer(returnElemment);

            XmlNodeList xnList = xmlLayerMap.SelectNodes("/LayerMapConfig/Layer");
            //或许Layer标签的节点
            foreach (XmlNode xn in xnList) 
            {
                string sID = xn.Attributes["id"].Value;
                //建立新层
                XmlElement gXMLLayer = svgLayerMap.gLayerElement(sID);
                svgLayerMap.addgLayer(gXMLLayer,0,0);
                ////井位图层
                //if (xn.Attributes["LayerType"].Value ==TypeLayer.LayerPosition.ToString())
                //    returnElemment = svgLayerMap.gWellsPositionFromXML(xn,sID);
                //地质熟悉数据图层
                if (xn.Attributes["LayerType"].Value == TypeLayer.LayerGeoProperty.ToString())
                    returnElemment = svgLayerMap.gLayerWellsGeologyPropertyFromXML(xn, sID);
                //水平井图层
                if (xn.Attributes["LayerType"].Value == TypeLayer.LayerHorizonalInterval.ToString())
                    returnElemment = svgLayerMap.gHorizonalWellIntervelFromXML(xn, sID);
                ////日产
                //if (xn.Attributes["LayerType"].Value == TypeLayer.LayerDailyProduct.ToString())
                //    returnElemment = svgLayerMap.gDailyProductFromXML(xn, sID, listWellsStatic, listLayersDataCurrentLayerDynamic);
                ////累产饼图图层
                //if (xn.Attributes["LayerType"].Value == TypeLayer.LayerSumProduct.ToString())
                //    returnElemment = svgLayerMap.gSumProductFromXML(xn, sID, listWellsStatic, listLayersDataCurrentLayerDynamic);
                //井位柱状图图层
                if (xn.Attributes["LayerType"].Value == TypeLayer.LayerBarGraph.ToString())
                    returnElemment = svgLayerMap.gWellBarGraphFromXML(xn, sID, listWellsStatic);
                ////井位饼图图层
                //if (xn.Attributes["LayerType"].Value == TypeLayer.LayerPieGraph.ToString())
                //    returnElemment = cXMLLayerMapWellPieGraph.gWellPieGraphFromXML(xn, sID, listWellsStatic); 
                //新层加内容
                //svgLayerMap.addgElement2Layer(gXMLLayer, returnElemment);
            }

            //add voi
            //if (this.cbxVoi.Checked == true)
            //{
            //    XmlElement gVoronoiLayer = svgLayerMap.gLayerElement("voronoi");
            //    svgLayerMap.addgLayer(gVoronoiLayer, svgLayerMap.offsetX_gSVG,svgLayerMap.offsetY_gSVG);
            //    List<itemWellLayerVoi> listVoi = cIOVoronoi.read2Struct();
            //    foreach (itemWellLayerVoi well in listVoi.FindAll(p => p.sXCM == sSelectLayer))
            //    {
            //        returnElemment = svgLayerMap.gVoronoiPolygon(well.sJH, well.ltdpVertex, "red", 2);
            //        svgLayerMap.addgElement2Layer(gVoronoiLayer, returnElemment);
            //    }
            //}

            //add connect
            //if (this.cbxConnect.Checked == true)
            //{
            //    XmlElement gConnectLayer = svgLayerMap.gLayerElement("Connect");
            //    svgLayerMap.addgLayer(gConnectLayer,0,0);
            //    List<ItemConnectInjPro> listConnect = cIODicInjProCon.read2Struct(sSelectYM , sSelectLayer);
            //    foreach (ItemConnectInjPro connect in listConnect)
            //    {
            //        //需要定到层位
            //        ItemWellMapPosition wellInj = listWellsStatic.Find(p => p.sJH == connect.sJHinj);
            //        ItemWellMapPosition wellPro = listWellsStatic.Find(p => p.sJH == connect.sJHpro);
            //        PointD p1 = new PointD(wellInj.dbX, wellInj.dbY);
            //        PointD p2 = new PointD(wellPro.dbX, wellPro.dbY);
            //        returnElemment = svgLayerMap.gConnectLine(p1, p2, "blue", 2);
            //        svgLayerMap.addgElement2Layer(gConnectLayer, returnElemment);
            //    }

            //}

        

            XmlElement gLayerCompass = svgLayerMap.gLayerElement("指南针");
            svgLayerMap.addgLayer(gLayerCompass, svgLayerMap.offsetX_gSVG, svgLayerMap.offsetY_gSVG);
            svgLayerMap.addgElement2Layer(gLayerCompass, svgLayerMap.gCompass(300, 100)); 

            svgLayerMap.makeSVGfile(filePathSVGLayerMap);
            this.webBrowserSVG.Navigate(new Uri(filePathSVGLayerMap));
        }

        private void btnMakeLayerMap_Click(object sender, EventArgs e)
        {
            //用静态数据表，更新静态井位列表
            //静态、动态小层数据分别在tab面板更新。
            listWellsStatic.Clear();
            if (listLayersDataCurrentLayerStatic.Count > 0)
            {
                foreach (ItemDicLayerDataStatic item in listLayersDataCurrentLayerStatic)
                {
                    //由于可能计算小层数据表后又对井做修改 所以 必须判断小层数据表的井是否在项目井范围内
                    if (cProjectData.ltStrProjectJH.IndexOf(item.sJH) >= 0)
                    {
                        ItemWellMapPosition wellMapLayer = new ItemWellMapPosition(item);
                        listWellsStatic.Add(wellMapLayer);
                    }
                }
            }
            addLayerBase2XML(listWellsStatic); 
            generateSVGfilemapByConfigxml();
            this.tbcLayerMap.SelectedTab = this.tbgSVGLayer;
        }
       
       

        private void FormMapLayer_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
        }


        void addLayerBase2XML(List<ItemWellMapPosition> listStaticWellPos)
        {
            cXmlDocLayer.delBaseLayer(filePathLayerCss);
            //xml文件中加入BaseLayer绘图信息
            cXmlDocLayer.addBaseLayer2XML(filePathLayerCss, listStaticWellPos);
        }

        void initialDataFromXMLfile() 
        {
            XmlDocument xmlLayerMap = new XmlDocument();
            xmlLayerMap.Load(filePathLayerCss);
            XmlNode xnLayer = xmlLayerMap.SelectSingleNode("/LayerMapConfig/BaseInfor/XCM");
            if(xnLayer!=null) sSelectLayer = xnLayer.InnerText;
            XmlNode xnYM = xmlLayerMap.SelectSingleNode("/LayerMapConfig/BaseInfor/YM");
             if (xnYM != null) sSelectYM = xnYM.InnerText;

            //如果存在 静态数据节点 赋值
            
            XmlNode xnStatic = xmlLayerMap.SelectSingleNode("/LayerMapConfig/DataDicStatic");
            if (xnStatic!=null && xnStatic.Attributes["XCM"].Value == sSelectLayer) 
            {
                XmlNodeList xnlist = xnStatic.SelectNodes("data/item");
                //解析进List
                listLayersDataCurrentLayerStatic.Clear();
                foreach (XmlNode xn in xnlist)
                {
                    listLayersDataCurrentLayerStatic.Add(ItemDicLayerDataStatic.parseLine(xn.InnerText));
                }
            }

            //如果存在 存在动态数据节点 赋值
            XmlNode xnDynamic = xmlLayerMap.SelectSingleNode("/LayerMapConfig/DataDicDynamic");
            if (xnDynamic != null && xnDynamic.Attributes["XCM"].Value == sSelectLayer && xnDynamic.Attributes["YM"].Value == sSelectYM)
            {
                XmlNodeList xnlist = xnStatic.SelectNodes("item");
                //解析进List
                //listLayersDataCurrentLayerDynamic.Clear();
                //foreach (XmlNode xn in xnlist)
                //{
                //    listLayersDataCurrentLayerDynamic.Add(ItemDicLayerDataDynamic.parseLine(xn.InnerText));
                //}
            }
            
        }

        private void tsbTreeView_Click(object sender, EventArgs e)
        {
            this.splitContainerLayer.Panel1Collapsed =!this.splitContainerLayer.Panel1Collapsed ;
            if (this.splitContainerLayer.Panel1Collapsed==false) updateTV();
        }

        private void tsBtnZoonIn_Click(object sender, EventArgs e)
        {
            this.webBrowserSVG.Focus();
            SendKeys.Send("^{+}");
        }

        private void tsBtnZoomOut_Click(object sender, EventArgs e)
        {
            this.webBrowserSVG.Focus();
            SendKeys.Send("^{-}");
        }

        private void tsBtnNewProject_Click(object sender, EventArgs e)
        {
            createNewFile();
        }
        
        void createNewFile()
        {
            FormAddLayer formNew = new FormAddLayer();
            var result = formNew.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.sSelectLayer = formNew.ReturnLayer;
                filePathLayerCss = Path.Combine(cProjectManager.dirPathLayerDir, sSelectLayer, sSelectLayer+".xml");
                cXmlDocLayer.generateXML(filePathLayerCss, sSelectLayer);
                if (File.Exists(filePathLayerCss))
                {
                    listLayersDataCurrentLayerStatic = cIODicLayerDataStatic.readDicLayerData2struct().FindAll(p => p.sXCM == sSelectLayer);
                    cXMLLayerMapStatic.addWellStaticDataDic2XML(filePathLayerCss, sSelectLayer, listLayersDataCurrentLayerStatic);
                    //DialogResult dialogResult = MessageBox.Show("是否新建并覆盖？", "文件已存在", MessageBoxButtons.YesNo);
                    //if (dialogResult == DialogResult.No) bNew = false;
                }
               updateSVG();
            }
        }

        private void tsBtnOpenProject_Click(object sender, EventArgs e)
        {
            openExist();
        }
        void openExist()
        {
            OpenFileDialog ofdProjectPath = new OpenFileDialog();

            ofdProjectPath.Title = " 打开文件：";
            ofdProjectPath.Filter = string.Format("{0}文件|*{0}", ".xml");
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
            filePathLayerCss = pathOpenExsitFile;
            sSelectLayer = cXmlBase.getNodeInnerText(filePathLayerCss, cXmlDocLayer.fmpXCM);
            listLayersDataCurrentLayerStatic = cIODicLayerDataStatic.readDicLayerData2struct().FindAll(p => p.sXCM == sSelectLayer);
            tvEdit.Nodes.Clear();
            updateTV();
            updateSVG();
        }

        void updateTV() 
        {
            if (this.splitContainerLayer.Panel1Collapsed == false)
            {
                this.tvEdit.Nodes.Clear();
                TreeNode tnPage = new TreeNode();
                tnPage.Text = "页面";
                tnPage.Name = "page";  //结点name
                tnPage.Tag = "page";
                TreeViewMapLayer.setupLayerNode(tnPage, this.filePathLayerCss);
                tvEdit.Nodes.Add(tnPage);
                tnPage.Expand();
            }
        }

        void updateSVG()
        {
            PscrollOffset = cSectionUIoperate.getOffSet(this.webBrowserSVG);
            string filePathHis = Path.Combine(this.dirHisUnto, cIDmake.generateRandomFileNameID());
            File.Copy(filePathLayerCss, filePathHis, true);
            UndoList.Push(filePathHis);
            setUnDoRedoEnable();
            filePathSVGLayerMap = makeLayerMap.generateLayerMap(this.filePathLayerCss);
            this.webBrowserSVG.Navigate(new Uri(filePathSVGLayerMap));
            this.tbcLayerMap.SelectedTab = this.tbgSVGLayer;
            this.tbgSVGLayer.Text = filePathLayerCss;
        }

        private void tsBtnReflush_Click(object sender, EventArgs e)
        {
            updateTV();
            updateSVG();
        }

        private void 井点设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLayerSettingWell setWell = new FormLayerSettingWell(this.filePathLayerCss);
            setWell.ShowDialog();
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
                //htmlDoc.MouseMove -= htmlDoc_MouseMove;
                //htmlDoc.MouseMove += htmlDoc_MouseMove;
            }
        }
        int iCountClick = 0;
        void htmlDoc_MouseDown(object sender, HtmlElementEventArgs e)
        {
            if (e.MouseButtonsPressed == MouseButtons.Left)
            {
                iCountClick++;
                pXY.X =  PscrollOffset.X + e.MousePosition.X;
                pXY.Y = PscrollOffset.Y + e.MousePosition.Y;
            }
            this.tsslblWb.Text = "分析 x=" + pXY.X.ToString("0.00")
                + " y=" + pXY.Y.ToString("0.00");
                
        }
        void htmlDocBody_MouseMove(object sender, HtmlElementEventArgs e)
        {
            //fCurrentMD = (6 + PscrollOffset.Y + e.MousePosition.Y) / fVscale;
            //fCurrentTVD = cIOinputWellPath.getTVDByJHAndMD(curWell, fCurrentMD);
            //if (e.MousePosition.X <= lblCrossH.Width + 3) lblCrossV.Location = new Point(e.MousePosition.X - 5, this.webBrowserBody.Location.Y + this.webBrowserHead.Height);
            //lblCrossV.Height = this.webBrowserBody.Height - this.webBrowserHead.Height;
            //lblCrossH.Location = new Point(this.webBrowserBody.Location.X, e.MousePosition.Y + 5);
            //this.tsslblDepth.Text = "测深=" + fCurrentMD.ToString("0.00") + " 垂深=" + fCurrentTVD.ToString("0.00");
        }

        private void tsmiSave2Project_Click(object sender, EventArgs e)
        {
            cProjectManager.save2ProjectResultMap(this.filePathSVGLayerMap);
        }

        private void 井点属性ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cXmlDocLayer.addLayerCss(this.filePathLayerCss, TypeLayer.LayerGeoProperty);
            updateTV();
        }

        private void 井点值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cXmlDocLayer.addLayerCss(this.filePathLayerCss, TypeLayer.LayerPieGraph);
            updateTV();
        }

        private void 页面设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLayerSettingPage newPage = new FormLayerSettingPage(this.filePathLayerCss);
            newPage.ShowDialog();
        }

        public void ShowMessage(object obj)
        {
            sCurrentID = obj.ToString();
            this.tsslblDataItem.Text = sCurrentID;
        }

        private void 查看剖面ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sSelectJH = sCurrentID;
            ItemDicLayerDataStatic curItem= listLayersDataCurrentLayerStatic.SingleOrDefault(p => p.sJH == sSelectJH && p.sXCM == sSelectLayer);
            float fTop = 0;
            float fBot = 5000;
            if (curItem != null) 
            {
                fTop = curItem.fDS1_md;
                fBot = curItem.fDS2_md;
            }
            string filePathOper = Path.Combine(cProjectManager.dirPathWellDir, sSelectJH, sSelectJH + cProjectManager.fileExtensionSectionWell);
            if (File.Exists(filePathOper))
            {
                FormSectionWell newSectionWeb = new FormSectionWell(filePathOper, fTop, fBot);
                newSectionWeb.WindowState = FormWindowState.Normal;
                newSectionWeb.Size = new Size(300, 300);
                //newSectionWeb.StartPosition = FormStartPosition.Manual;
                newSectionWeb.Location = pXY.ToPoint();
                newSectionWeb.setViewMode();
                newSectionWeb.FormBorderStyle = FormBorderStyle.SizableToolWindow;
                newSectionWeb.TopLevel = true;
                newSectionWeb.wellPanelMain.webBrowserHead.Visible = false;
                newSectionWeb.wellPanelMain.lblCrossV.Visible = false;
                newSectionWeb.wellPanelMain.lblCrossH.Visible = false;
                newSectionWeb.wellPanelMain.lblmarker.Visible = false;
                newSectionWeb.wellPanelMain.statusStripWellPanel.Visible = false;
                newSectionWeb.Show();
            }
            else 
            {
                MessageBox.Show("单井综合图不存在。");
            }
        }

        private void tsmiLayerSetting_Click(object sender, EventArgs e)
        {
            TreeNode selectNode = this.tvEdit.SelectedNode;
            if (selectNode != null && selectNode.Level == 1)
            {
                sSelectLayerID = selectNode.Name;
                if (selectNode.Tag.ToString() == TypeLayer.LayerPieGraph.ToString())
                {
                    FormLayerSetPie newForm = new FormLayerSetPie(this.filePathLayerCss, sSelectLayerID);
                    newForm.ShowDialog();
                }
            }
        }

        private void 测井曲线ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cXmlDocLayer.addLayerCss(this.filePathLayerCss, TypeLayer.LayerLog);
            updateTV();
        }

        void getLayerInforBySelectTNnode(TreeNode currentNode)
        {
            if (currentNode != null)
            {
                string strLayerType = currentNode.Tag.ToString();
                this.sSelectLayerID = currentNode.Name;
            }
        }
        private void tsmiLayerData_Click(object sender, EventArgs e)
        {
             TreeNode currentNode = this.tvEdit.SelectedNode;
             if (currentNode != null)
             {
                 string strLayerType = currentNode.Tag.ToString();
                 this.sSelectLayerID = currentNode.Name;
                 if (strLayerType == TypeLayer.LayerLog.ToString())
                 {
                     FormLayerLog newLogLayer = new FormLayerLog(this.filePathLayerCss, sSelectLayerID);
                     newLogLayer.ShowDialog();
                 }
                 if (strLayerType == TypeLayer.LayerGeoProperty.ToString())
                 {
                     FormLayerGeologicalValue newGeoLayer = new FormLayerGeologicalValue(this.filePathLayerCss);
                     newGeoLayer.ShowDialog();
                 }
                  if (strLayerType == TypeLayer.LayerPieGraph.ToString())
                 {
                     FormLayerWellValue newLayer = new FormLayerWellValue(this.filePathLayerCss);
                     newLayer.ShowDialog();
                 }
                  if (strLayerType == TypeLayer.LayerWellPosition.ToString())
                  {
                      cXMLLayerMapStatic.addWellPosition2Layer(filePathLayerCss,sSelectLayerID, listLayersDataCurrentLayerStatic);
                  }

             }
        }

        private void tsmiSelectDel_Click(object sender, EventArgs e)
        {
            TreeNode currentNode = this.tvEdit.SelectedNode;
            if (currentNode != null)
                {
                    DialogResult dialogResult = MessageBox.Show("将删除选中:" + currentNode.Text + "，确认删除？", "删除选中", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        cXmlDocLayer.deleteItemByLayerID(filePathLayerCss, currentNode.Name.ToString());
                        currentNode.Remove();
                    }
                }
            if (currentNode.Parent != null) currentNode.Parent.Expand();
        }

        private void tsbUndo_Click(object sender, EventArgs e)
        {
            undo();
        }

        void redo()
        {
            if (RedoList.Count >= 0)
            {
                UndoList.Push(RedoList.Pop());
                string redoFileName = UndoList.Peek();
                File.Copy(redoFileName, this.filePathLayerCss, true);
                updateTV();
                updateSVG();//更新不备份
            }
            setUnDoRedoEnable();
        }
        void undo()
        {
            if (UndoList.Count > 1)
            {
                RedoList.Push(UndoList.Pop());
                string curFileName = UndoList.Peek();
                File.Copy(curFileName, this.filePathLayerCss, true);
                updateTV();
                updateSVG();//更新不备份
            }
            setUnDoRedoEnable();
        }

        private void tsbRedo_Click(object sender, EventArgs e)
        {
            redo();
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

        private void tsmiInsertWellPoint_Click(object sender, EventArgs e)
        {
            cXmlDocLayer.addLayerCss(this.filePathLayerCss, TypeLayer.LayerWellPosition);
        }

        private void tsbPageSet_Click(object sender, EventArgs e)
        {
            FormLayerSettingPage newPage = new FormLayerSettingPage(this.filePathLayerCss);
            newPage.ShowDialog();
        }

        private void tsmiAllProjectJH_Click(object sender, EventArgs e)
        {
            cXmlBase.setNodeInnerText(this.filePathLayerCss, cXELayerPage.fmpShowJHgroup, "1");
            updateSVG();
        }

        private void tsmiCurrentLayerJH_Click(object sender, EventArgs e)
        {
            cXmlBase.setNodeInnerText(this.filePathLayerCss, cXELayerPage.fmpShowJHgroup, "0");
            updateSVG();
        }

        private void tsmiLayerUp_Click(object sender, EventArgs e)
        {

        }

        private void tsmiLayerRename_Click(object sender, EventArgs e)
        {
            TreeNode tnSelected = this.tvEdit.SelectedNode;
            getLayerInforBySelectTNnode(tnSelected);
            string originalTitle = tnSelected.Text;
            FormInputBox inputBox = new FormInputBox("新层名：", "请输入：", originalTitle);
            var result = inputBox.ShowDialog();
            if (result == DialogResult.OK)
            {
                string newTitle = inputBox.ReturnValueStr;
                cXmlDocLayer.reNameLayer(this.filePathLayerCss, this.sSelectLayerID, newTitle);
            } 
        }

        private void tvEdit_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
        }

        private void tvEdit_MouseUp(object sender, MouseEventArgs e)
        {
            TreeNode selectedNode = tvEdit.GetNodeAt(e.X, e.Y);
            if (selectedNode != null)
            {
                //处理是否隐藏
                if (selectedNode.Level == 1) // level 0 是页面 level 1 是layer
                {
                    int iCheck = selectedNode.Checked == true ? 1 : 0;
                    this.sSelectLayerID = selectedNode.Name;
                    //为了阻止不改变状态就刷新，必须记录原状态
                    cXmlDocLayer.setLayerVisible(this.filePathLayerCss, sSelectLayerID, iCheck);
                }
            }
        }

        private void tsmiInsertLayerJSJL_Click(object sender, EventArgs e)
        {
            cXmlDocLayer.addLayerCss(this.filePathLayerCss, TypeLayer.LayerJSJL);
            updateTV();
        }
    }
}
