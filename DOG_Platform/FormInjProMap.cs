using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml.Linq;
using System.Xml;
using DOGPlatform.XML;
using DOGPlatform.SVG;

namespace DOGPlatform
{
    public partial class FormInjProMap : Form
    {
        public FormInjProMap()
        {
            InitializeComponent();
            InitFormLayerMapControl();
        }
        private void InitFormLayerMapControl()
        {
            //初始化 小层下拉列表
            cPublicMethodForm.inialComboBox(cbbSelectedTopXCM, cProjectData.ltStrProjectXCM);
            cPublicMethodForm.inialComboBox(cbbSelectedBottomXCM, cProjectData.ltStrProjectXCM);

            cPublicMethodForm.inialComboBox(cbbProjectJH, cProjectData.ltStrProjectJH);
            //初始化显示井名ListBox
            cPublicMethodForm.inialListBox(lbxJH, cProjectData.ltStrProjectJH);
            //初始化显示起始时间
            cPublicMethodForm.inialComboBox(cbbSlectedYM, cProjectData.ltStrProjectYM);


            List<string> ltStrStaticDataChoise = new List<string>();
            ltStrStaticDataChoise.Add("砂厚");
            ltStrStaticDataChoise.Add("有效厚度");
            ltStrStaticDataChoise.Add("孔隙度");
            ltStrStaticDataChoise.Add("渗透率");
            ltStrStaticDataChoise.Add("饱和度");
            List<string> ltStrDynamicDataProduct = new List<string>();
            ltStrDynamicDataProduct.Add("日产油");
            ltStrDynamicDataProduct.Add("日产液");
            ltStrDynamicDataProduct.Add("月产油");
            ltStrDynamicDataProduct.Add("月产液");
            ltStrDynamicDataProduct.Add("累产油");
            ltStrDynamicDataProduct.Add("累产液");
            ltStrDynamicDataProduct.Add("油压");
            ltStrDynamicDataProduct.Add("套压");
            ltStrDynamicDataProduct.Add("流压");
            ltStrDynamicDataProduct.Add("静压");
            List<string> ltStrDynamicDataInject = new List<string>();
            ltStrDynamicDataInject.Add("日注水量");
            ltStrDynamicDataInject.Add("月注水量");
            ltStrDynamicDataInject.Add("累注水量");
            ltStrDynamicDataInject.Add("油压");
            ltStrDynamicDataInject.Add("套压");
            ltStrDynamicDataInject.Add("静压");
            ltStrDynamicDataInject.Add("流压");
            ltStrDynamicDataInject.Add("泵压");


            cPublicMethodForm.inialComboBox(cbbDynamicDataOil, ltStrDynamicDataProduct);
            cPublicMethodForm.inialComboBox(cbbDynamicDataWater, ltStrDynamicDataInject);

        }
        List<string> ltStrWellName = new List<string>();
        List<double> dfListX = new List<double>();
        List<double> dfListY = new List<double>();
        List<float> fListKB = new List<float>();
        List<int> iListWellType = new List<int>();

        List<string> ltStrSelectedJH = new List<string>();
        List<string> ltStrSelectedLayer = new List<string>();
        string sSelectedYYYYMM = "";

        string fileDrawMapSourceInfor = cProjectManager.dirPathTemp + "InjProMap_Infor.txt";
        string fileDrawMapSourceConnect = cProjectManager.dirPathTemp + "InjProMap_Connect.txt";
        string fileDrawMapSourceFault = cProjectManager.dirPathTemp + "InjProMap_FaultLine.txt";
        string fileDrawMapSourceDynamicData = cProjectManager.dirPathTemp + "InjProMap_WellDynamicData.txt";
    
        
        private void updateMapFile()
        {
            if (File.Exists(cProjectManager.xmlConfigProductMap))
            {
                File.Delete(cProjectManager.xmlConfigProductMap);
            }
            cXMLProductMap.generateXmlFile(sSelectedYYYYMM,ltStrSelectedLayer[0],cProjectManager.xmlConfigProductMap);
            List<string> ltStrDrawSectionSourceFiles = new List<string>();
            ltStrDrawSectionSourceFiles.Add(fileDrawMapSourceInfor);
            ltStrDrawSectionSourceFiles.Add(fileDrawMapSourceFault);
            ltStrDrawSectionSourceFiles.Add(fileDrawMapSourceDynamicData);
            foreach (string sItem in ltStrDrawSectionSourceFiles)
            {
                FileStream fs = new FileStream(sItem, FileMode.Create);
                fs.Close();
            }
        }

        void updateSelectedCondition()
        {
            updateSelectedJHByListBox();
            updateSelectedXCMList();
            updateSelectedYM(); 
        }

        void updateSelectedJHByListBox()
        {
            ltStrSelectedJH.Clear();
            foreach (object selecteditem in lbxJH.SelectedItems)
            {
                string strItem = selecteditem as String;
                ltStrSelectedJH.Add(strItem);
            }
      
        }
        void updateSelectedXCMList()
        {
            if (this.cbbSlectedYM.Items.Count > 0) sSelectedYYYYMM = this.cbbSlectedYM.SelectedItem.ToString();
            else sSelectedYYYYMM = "201310";
        }
        void updateSelectedYM()
        {
            ltStrSelectedLayer.Clear();
            string sSelectedTopLayer = this.cbbSelectedTopXCM.SelectedItem.ToString();
            string sSelectedBottomLayer = this.cbbSelectedBottomXCM.SelectedItem.ToString();
            int iIndexTopLayer = cProjectData.ltStrProjectXCM.IndexOf(sSelectedTopLayer);
            int iIndexBottomLayer = cProjectData.ltStrProjectXCM.IndexOf(sSelectedBottomLayer);
            for (int i = iIndexTopLayer; i <= iIndexBottomLayer; i++) ltStrSelectedLayer.Add(cProjectData.ltStrProjectXCM[i]);
        }

        public void readWellHead()
        {
            string[] split;
            try
            {
                using (StreamReader sr = new StreamReader(cProjectManager.filePathInputWellhead, System.Text.Encoding.Default))
                {
                    String line;
                    while ((line = sr.ReadLine()) != null) //delete the line whose legth is 0
                    {
                        split = line.Trim().Split(new char[] { ' ', '\t', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
                        ltStrWellName.Add(split[0]);
                        dfListX.Add(double.Parse(split[1]));
                        dfListY.Add(double.Parse(split[2]));
                        fListKB.Add(float.Parse(split[3]));
                        iListWellType.Add(int.Parse(split[4]));
                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
 
        
        private void btnMakeLayerMap_Click(object sender, EventArgs e)
        {

        }
        private void btnSelectAllJH_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lbxJH.Items.Count; i++)
            {
                lbxJH.SetSelected(i, true); 
            }
        }
        private void btnSelectNoWell_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lbxJH.Items.Count; i++)
            {
                lbxJH.SetSelected(i, false);  
            }
        }
        private void ListBoxWellName_layerMap_SelectedValueChanged(object sender, EventArgs e)
        {
            this.lbl_ShowSelectedNumber.Text = "显示井("+this.lbxJH.SelectedItems.Count.ToString()+")";
        }
      
        private void btnSelectPerforatedWellByContition_Click(object sender, EventArgs e)
        {
            ltStrSelectedJH.Clear();
            updateSelectedXCMList();
            updateSelectedYM(); 

            cIOinputWellPerforation cTest = new cIOinputWellPerforation();
            if(File.Exists(cProjectManager.filePathPerforationDic))
            {
                
                foreach (string sItemXCM in ltStrSelectedLayer) 
                {
                    //List<string> ltStrJHPerfotatedByLayer = cTest.selectJHFromDicPerforationByYMLayerName(sItemXCM, sSelectedYYYYMM);
                    //foreach (string sJHtemp in ltStrJHPerfotatedByLayer) 
                    //{
                    //if(!ltStrSelectedJH.Contains(sJHtemp)) ltStrSelectedJH.Add(sJHtemp);
                    //}
                }

                for (int i = 0; i < lbxJH.Items.Count; i++)
                {
                    lbxJH.SetSelected(i, false);
                    if (ltStrSelectedJH.Contains(lbxJH.Items[i].ToString()))
                        lbxJH.SetSelected(i, true);
                }

 
            }
            else
            {
                MessageBox.Show("请先计算射孔数据字典，或者手动选择。");
            }
         

        }

        private void btnShowSelectedJH_Click(object sender, EventArgs e)
        {
      
            ltStrSelectedJH.Clear();
            foreach (object selecteditem in lbxJH.SelectedItems)
            {
                string strItem = selecteditem as String;
                ltStrSelectedJH.Add(strItem);
            }

            MessageBox.Show(string.Join("\t", ltStrSelectedJH.ToArray()), "Num="+ltStrSelectedJH.Count.ToString());
        }

        private void btnCalConnection_Click(object sender, EventArgs e)
        {
            cCalConnectionInject2Production cCalConnect = new cCalConnectionInject2Production();

            List<string> ltStrJHoil = cCalConnect.get_ltStrJHByWellType(ltStrSelectedJH, sSelectedYYYYMM,3);
            List<string> ltStrJHwater = cCalConnect.get_ltStrJHByWellType(ltStrSelectedJH, sSelectedYYYYMM,15);
            //初始化注入井号cbb
            cPublicMethodForm.inialComboBox(cbbJHWater,ltStrJHwater );
            //初始化受效井号cbb
            cPublicMethodForm.inialComboBox(cbbJHOil, ltStrJHoil);

  //          cCalConnect.generateConnectFile(ltStrJHwater, ltStrJHoil, ltStrSelectedLayer[0], sSelectedYYYYMM, fileDrawMapSourceConnect);
                    
        }

        private void btnAddPosition_Click(object sender, EventArgs e)
        {
            generateWellLayerPositonDrawData();
            lbxProducttLayerCollection.Items.Add("层段井位");
        }

        void generateWellLayerPositonDrawData()
        {
            updateSelectedCondition();
            lbxProducttLayerCollection.Items.Clear();
            updateMapFile();

            string filePathWrited = fileDrawMapSourceInfor;

            List<ItemWellHead> listWellHeadItemSelect = cIOinputWellHead.readWellHead2Struct().FindAll(p => ltStrSelectedJH.IndexOf(p.sJH) >= 0);
            
            StreamWriter sw = new StreamWriter(filePathWrited, false, Encoding.UTF8);

            cIOinputWellHead cSelectWellHead = new cIOinputWellHead();
            if (File.Exists(cProjectManager.fileExtensionConnect) && File.Exists(cProjectManager.filePathLayerDataDic))  //进入生产状态，计算了井型代码
            {
        //     //   cSelectWellHead.readDicWellType2List();
        //        for (int i = 0; i < ltStrSelectedJH.Count; i++)
        //        {
        //            string sJH = ltStrSelectedJH[i];
        //            List<string> ltStrWellHeadReturn = cSelectWellHead.selectDataFromWellHeadByJH(sJH);
        //            Point pointConvert2View = new Point();
        //            double dbX = 0, dbY = 0;
        //            float fKB = 0;
        //            int iWellType = 0;

        //            dbX = double.Parse(ltStrWellHeadReturn[1]);
        //            dbY = double.Parse(ltStrWellHeadReturn[2]);
        //            fKB = float.Parse(ltStrWellHeadReturn[3]);
        //            iWellType = int.Parse(ltStrWellHeadReturn[4]);

        //            //从小层数据字典中替换X，Y
        //            ItemLayerDataDic sttLayerDataDicItem = cIODicLayerData.getLayerDataDicItemFromLayerDataDicByXCMAndJH(sJH, ltStrSelectedLayer[0]);
        //            dbX = sttLayerDataDicItem.dbX;
        //            dbY = sttLayerDataDicItem.dbY;

        //            pointConvert2View = cPublicMethodCordinationTransform.transRealPointF2ViewPoint(dbX, dbY,
        //cProjectData.dfMapXrealRefer, cProjectData.dfMapYrealRefer, cProjectData.dfMapScale);
        //            List<string> ltStrWrited = new List<string>();
        //            ltStrWrited.Add(sJH);
        //            ltStrWrited.Add(pointConvert2View.X.ToString());
        //            ltStrWrited.Add(pointConvert2View.Y.ToString());
        //            ltStrWrited.Add(fKB.ToString());
        //            ltStrWrited.Add(iWellType.ToString());
        //            sw.WriteLine(string.Join("\t", ltStrWrited.ToArray()));
        //        }
            }
            else//原始设计井生产，未计算井型代码
            {
                MessageBox.Show("请先根据生产数据计算不同时间步井型代码和小层字典表。");
            }

            sw.Close();
        }

        private void btnSetConnectWells_Click(object sender, EventArgs e)
        {

            updateSelectedCondition();
            cCalConnectionInject2Production ctest = new cCalConnectionInject2Production();
            List<string> ltStrJHoil = ctest.get_ltStrJHByWellType(this.ltStrSelectedJH, sSelectedYYYYMM,3);
            List<string> ltStrJHwater = ctest.get_ltStrJHByWellType(this.ltStrSelectedJH, sSelectedYYYYMM,15);
            cPublicMethodForm.inialComboBox(this.cbbJHWater, ltStrJHwater);
            cPublicMethodForm.inialComboBox(this.cbbJHOil, ltStrJHoil);
            this.lblJHWater.Text = "注入井(" + this.cbbJHWater.Items.Count.ToString() + ")";
            this.lblJHoil.Text = "生产井(" + this.cbbJHOil.Items.Count.ToString() + ")";
        }

        

        private void btnSelectWells_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSaveSetting_Click(object sender, EventArgs e)
        {

        }

        private void btnWellNameFont_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            if (fontDialog.ShowDialog() != DialogResult.Cancel)
            {
                this.lbl_JMFont.ForeColor = fontDialog.Color;
                this.lbl_JMFont.Font = fontDialog.Font;
            }

        }

        private void btnDrawByxmlConfig_Click(object sender, EventArgs e)
        {
         MessageBox.Show(DateTime.Now.ToString("yyyyMM"));
        }

        private void tabControlLayerMap_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void btnAddDynamicData_Click(object sender, EventArgs e)
        {
            updateSelectedCondition();

            string sXCM = "";
            if (rdbAllLayerDynamic.Checked == true) sXCM = "ALLLayer";
            //if (rdbLayerDelectedDynamic.Checked == true) sXCM = this.sSelectedLayer;
            string sTypeShow = "";
            if (this.rdbPieDynamic.Checked == true) sTypeShow = "Pie";
            if (this.rdbRectDynamic.Checked == true) sTypeShow = "Rect";

            StreamWriter swDynamicData = new StreamWriter(fileDrawMapSourceDynamicData, false, Encoding.UTF8);

            string fileNameOilProduct = Path.Combine(cProjectManager.fileNameInputWellProduct, sSelectedYYYYMM + sXCM + ".txt");
            if (File.Exists(fileNameOilProduct))
            {
                int iIndex = 3;
                string sItem = cbbDynamicDataOil.SelectedItem.ToString();
                if (sItem == "日产油") iIndex = 13;
                if (sItem == "月产油") iIndex = 6;
                if (sItem == "累产油") iIndex = 9;
                if (sItem == "油压") iIndex = 18;
                if (sItem == "套压") iIndex = 19;
                if (sItem == "流压") iIndex = 20;
                if (sItem == "静压") iIndex = 21;
                lbxProducttLayerCollection.Items.Add(sItem);

                List<ItemWellLayerYMValue> listWellDynamicValue = new List<ItemWellLayerYMValue>(); 

                for (int i = 0; i < listWellDynamicValue.Count; i++)
                {

                    string sCurrentJH = listWellDynamicValue[i].sJH;
                    float fValue = listWellDynamicValue[i].fValue;

                    if (ltStrSelectedJH.Contains(sCurrentJH) == true)
                    {
                        List<string> ltStrWrited = new List<string>();
                        ltStrWrited.Add(sCurrentJH);
                        Point pointConvert2View =cCordinationTransform.getPointViewByJH(sCurrentJH);
                        ltStrWrited.Add(pointConvert2View.X.ToString());
                        ltStrWrited.Add(pointConvert2View.Y.ToString());
                        ltStrWrited.Add(fValue.ToString());
                        swDynamicData.WriteLine(string.Join("\t", ltStrWrited.ToArray()));
                    }
                }
               
            }
            else
            {
                MessageBox.Show("请先计算油井生产字典表。");
            }

            string fileNameWaterInject = Path.Combine(cProjectManager.fileNameInputWellInject, sSelectedYYYYMM + ".txt");
            if (File.Exists(fileNameWaterInject))
            {
                int iIndex = 3;
                string sItem = cbbDynamicDataWater.SelectedItem.ToString();
                if (sItem == "日注水") iIndex = 4;
                if (sItem == "月注水") iIndex = 5;
                if (sItem == "累注水") iIndex = 6;
                if (sItem == "油压") iIndex = 7;
                if (sItem == "套压") iIndex = 8;
                if (sItem == "流压") iIndex = 9;
                if (sItem == "静压") iIndex = 10;
                if (sItem == "泵压") iIndex = 11;
                lbxProducttLayerCollection.Items.Add(sItem);

                List<ItemWellLayerValue> listWellDynamicValue = new List<ItemWellLayerValue>();
                    //cSelectProductionData.selectWellLayerValueFromFileByIndex(fileNameWaterInject, sXCM,2, iIndex);


                for (int i = 0; i < listWellDynamicValue.Count; i++)
                {
                    string sCurrentJH = listWellDynamicValue[i].sJH;
                    float fValue = listWellDynamicValue[i].fValue;

                    if (ltStrSelectedJH.Contains(sCurrentJH) == true )
                    {
                        List<string> ltStrWrited = new List<string>();
                        ltStrWrited.Add(sCurrentJH);
                        Point pointConvert2View =cCordinationTransform.getPointViewByJH(sCurrentJH);
                        ltStrWrited.Add(pointConvert2View.X.ToString());
                        ltStrWrited.Add(pointConvert2View.Y.ToString());
                        ltStrWrited.Add(fValue.ToString());
                        swDynamicData.WriteLine(string.Join("\t", ltStrWrited.ToArray()));
                    }
                }

            }
            else
            {
                MessageBox.Show("请先计算水井生产字典表。");
            }
            swDynamicData.Close();
        }

        private void nUDWellCircle_R_ValueChanged(object sender, EventArgs e)
        {
            XDocument xmlLayerMap = XDocument.Load(cProjectManager.filePathLayerCss);
            xmlLayerMap.Element("LayerMapConfig").Element("WellSymbol").Element("r").Value = nUDWellCircle_R.Value.ToString("0");
            xmlLayerMap.Save(cProjectManager.filePathLayerCss);
        }

        private void nUDWellCircle_DX_ValueChanged(object sender, EventArgs e)
        {
            XDocument xmlLayerMap = XDocument.Load(cProjectManager.filePathLayerCss);
            xmlLayerMap.Element("LayerMapConfig").Element("JHText").Element("DX_Text").Value = nUDWellCircle_DX.Value.ToString("0");
            xmlLayerMap.Save(cProjectManager.filePathLayerCss);
        }

        private void nUDJHFontSize_ValueChanged(object sender, EventArgs e)
        {
            XDocument xmlLayerMap = XDocument.Load(cProjectManager.filePathLayerCss);
            xmlLayerMap.Element("LayerMapConfig").Element("JHText").Element("fontSize").Value = nUDJHFontSize.Value.ToString("0");
            xmlLayerMap.Save(cProjectManager.filePathLayerCss);
        }

        private void nUDFaultLineWidth_ValueChanged(object sender, EventArgs e)
        {
            XDocument xmlLayerMap = XDocument.Load(cProjectManager.filePathLayerCss);
            xmlLayerMap.Element("LayerMapConfig").Element("FaultLine").Element("lineWidth").Value = nUDFaultLineWidth.Value.ToString("0");
            xmlLayerMap.Save(cProjectManager.filePathLayerCss);
        }

        private void btnLayerWellPosition_Click(object sender, EventArgs e)
        {
            generateWellLayerPositonDrawData();
            lbxProducttLayerCollection.Items.Add("地层井位");
        }

        private void cbxFaultLine_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxFaultLine.Checked == true)
            {
               
                this.lbxProducttLayerCollection.Items.Add("断层");
            }
            else 
            {
                MessageBox.Show("取消断层线过程需要编写。");
            }
        }

        private void btnMap_Click(object sender, EventArgs e)
        {
            string filenameSVGMap;
            if (this.tbxMapTitleName.Text == "")
            { filenameSVGMap = sSelectedYYYYMM + "-InjectProductMap.svg"; }
            else
            {
                filenameSVGMap = this.tbxMapTitleName.Text + ".svg";
            }

            cSVGDocLayerMapProduction cLayerProductionMap = new cSVGDocLayerMapProduction( 800,1000,0, 0);
            XmlElement returnElemment;

            if (this.cbxAddWellConnect.Checked == true)
            {
                using (StreamReader sr = new StreamReader(fileDrawMapSourceConnect, Encoding.UTF8))
                {
                    String line;
                    string[] split;
                    while ((line = sr.ReadLine()) != null) //delete the line whose legth is 0
                    {
                        split = line.Trim().Split(new char[] { ' ', '\t', }, StringSplitOptions.RemoveEmptyEntries);
                        string sWellInject=split[0];
                        string sWellProduct = split[1];
                        cIOinputWellHead fileWellHead = new cIOinputWellHead();
                        ItemWellHead WellHeadItemJH1 = fileWellHead.listWellHead.Find(p=>p.sJH==sWellInject);
                        ItemWellHead WellHeadItemJH2 = fileWellHead.listWellHead.Find(p => p.sJH == sWellProduct); 
                        Point point1Convert2View = cCordinationTransform.transRealPointF2ViewPoint(WellHeadItemJH1.dbX, WellHeadItemJH1.dbY,
                            cProjectData.dfMapXrealRefer, cProjectData.dfMapYrealRefer, cProjectData.dfMapScale);
                        Point point2Convert2View = cCordinationTransform.transRealPointF2ViewPoint(WellHeadItemJH2.dbX, WellHeadItemJH2.dbY,
                            cProjectData.dfMapXrealRefer, cProjectData.dfMapYrealRefer, cProjectData.dfMapScale);
                        returnElemment = cLayerProductionMap.addgConnectLine(point1Convert2View, point2Convert2View,
                           Color.RoyalBlue.Name, 2, Color.RoyalBlue.Name);
                        cLayerProductionMap.addgElement2BaseLayer(returnElemment, 0, 0);
                    }
                }

            }

            if (this.cbxScaleRulerShowed.Checked == true)
            {
;
            }

        
            if (this.cbxCompassShowed.Checked == true)
            {
                cLayerProductionMap.svgRoot.AppendChild(cLayerProductionMap.gCompass(300, 100));
            }
        }

        private void addProductionData_Click(object sender, EventArgs e)
        {
            
        }

        private void cbbSelectedTopXCM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbSelectedBottomXCM.SelectedIndex>=0)
            cbbSelectedBottomXCM.SelectedIndex = cbbSelectedTopXCM.SelectedIndex;
        }

        private void btntest_Click(object sender, EventArgs e)
        {
            string sJH = cbbProjectJH.SelectedItem.ToString();
            MessageBox.Show(string.Join("\t", cCalDistance.getNearWells(sJH, 5)));
        }

         

       



  

    

     

    }
}
