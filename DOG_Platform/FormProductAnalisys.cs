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
using DOGPlatform.SVG;

namespace DOGPlatform
{
    public partial class FormProductAnalisys : Form
    {
        public FormProductAnalisys()
        {
            InitializeComponent();
            InitFormLayerMapControl();
        }
        private void InitFormLayerMapControl()
        {
            //初始化 小层下拉列表
            List<string> ltStrXCM = new List<string>();
            ltStrXCM.Add("AllLayer");
            //foreach (string sItem in cProjectManager.ltStrProjectXCM) 
            //{
            //    ltStrXCM.Add(sItem);
            //}
            cPublicMethodForm.inialComboBox(cbbSelectedXCM, ltStrXCM);
            //初始化 小层下拉列表
            cPublicMethodForm.inialComboBox(cbbSelectedTopXCM, cProjectData.ltStrProjectXCM);
            cPublicMethodForm.inialComboBox(cbbSelectedBottomXCM, cProjectData.ltStrProjectXCM);

            List<string> ltJHInjectWell = new List<string>();
            List<string> ltStrInfluencedWell = new List<string>();
            

            for (int i = 0; i < this.ltStrWellName.Count; i++)
            {
                if (this.iListWellType[i] == 15)
                    ltJHInjectWell.Add(ltStrWellName[i]);
                else
                    ltStrInfluencedWell.Add(ltStrWellName[i]);
            }


            //初始化显示井名ListBox
            cPublicMethodForm.inialListBox(lbxJH, cProjectData.ltStrProjectJH);
            //初始化显示起始时间
            cPublicMethodForm.inialComboBox(cbbSlectedYM, cProjectData.ltStrProjectYM);

        }
        List<string> ltStrWellName = new List<string>();
        List<double> dfListX = new List<double>();
        List<double> dfListY = new List<double>();
        List<float> fListKB = new List<float>();
        List<int> iListWellType = new List<int>();

        //List<string> ltStrSelectedJH = new List<string>();
        List<string> ltStrSelectedOilJH = new List<string>();
        List<string> ltStrSelectedWaterJH = new List<string>();
        List<string> ltStrSelectedLayer = new List<string>();


        string sSelectedYYYYMM = "";
        string sSelectedXCM = "";
        string filePathOilProduct="";
        string filePathWaterProduct="";
       
        string fileDrawMapSourceInfor = cProjectManager.dirPathTemp + "productMap_Infor.txt";

        private void updateMapFile()
        {
            if (File.Exists(cProjectManager.xmlConfigProductMap))
            {
                File.Delete(cProjectManager.xmlConfigProductMap);
            }
            cXMLProductMap.generateXmlFile(sSelectedYYYYMM,sSelectedXCM, cProjectManager.xmlConfigProductMap);
            List<string> ltStrDrawSectionSourceFiles = new List<string>();
            ltStrDrawSectionSourceFiles.Add(fileDrawMapSourceInfor);
            foreach (string sItem in ltStrDrawSectionSourceFiles)
            {
                FileStream fs = new FileStream(sItem, FileMode.Create);
                fs.Close();
            }

        }

        void updateSelectedCondition()
        {
            sSelectedXCM = cbbSelectedXCM.SelectedItem.ToString();
            updateSelectedYM();
        }

        
        void updateSelectedYM()
        {
            if (this.cbbSlectedYM.Items.Count > 0) sSelectedYYYYMM = this.cbbSlectedYM.SelectedItem.ToString();
            else sSelectedYYYYMM = "201310";
        }
        
        private void btnSelectedJH_Click(object sender, EventArgs e)
        {
            updateSelectedCondition();
            //此处分油井和水井提取不同的数据资料，油井提取 日产油，日产水，累产油，累产水
            //此处水井提取不同的数据资料，水井提取日注水，累注水
            cIOMapLayer cSelectProductionData = new cIOMapLayer();
              if (File.Exists(filePathOilProduct))
            {
              

                if (File.Exists(cProjectManager.xmlConfigProductMap))
                {
                    File.Delete(cProjectManager.xmlConfigProductMap);
                }
                cXMLProductMap.generateXmlFile(sSelectedYYYYMM, sSelectedXCM, cProjectManager.xmlConfigProductMap);
                cXMLProductMap.addOilWells(ltStrSelectedOilJH, cProjectManager.xmlConfigProductMap);
                cXMLProductMap.addWaterWells(ltStrSelectedWaterJH, cProjectManager.xmlConfigProductMap);
                for (int i = 0; i < lbxJH.Items.Count; i++)
                {
                    lbxJH.SetSelected(i, false);
                    if (ltStrSelectedOilJH.Contains(lbxJH.Items[i].ToString()) ||
                        ltStrSelectedWaterJH.Contains(lbxJH.Items[i].ToString()))
                    {
                        lbxJH.SetSelected(i, true);
                    }
                }

            }
            else
            {
                MessageBox.Show("请先计算油井生产字典表及水井字典表。");
            }
        }

        void generateWellLayerPositonDrawData()
        {
            updateSelectedCondition();
            updateMapFile();


        }

        void addOilWellPieMap(cIOMapLayer cSelectProductionData,   int iValue1OilColumnIndex,
            int iValue2OilColumnIndex, cSVGDocLayerMapProduction cLayerProductionMap ,string filePathOilProduct)
        {
            List<float> fListOilValue = new List<float>();
            List<float> fListWaterValue = new List<float>();
         
            List<int> iListXview = new List<int>();
            List<int> iListYview = new List<int>();
            for(int i=0;i<ltStrSelectedOilJH.Count;i++)
            {
                Point pWellView = cCordinationTransform.getPointViewByJH(ltStrSelectedOilJH[i]);
                iListXview.Add(pWellView.X);
                iListYview.Add(pWellView.Y);
            }
            float dfscale = float.Parse(tbxPieR.Text);
 //           XmlElement returnElemment = cLayerProductionMap.addgOilWellProductionPie(ltStrSelectedOilJH, iListXview, iListYview,
 //fListOilValue, fListWaterValue, dfscale);
            //cLayerProductionMap.addgElement2BaseLayer(returnElemment, 0, 0); 
        }

        void addWaterWellPieMap(cIOMapLayer cSelectProductionData, int iValueWaterColumnIndex,
         cSVGDocLayerMapProduction cLayerProductionMap, string filePathWaterProduct)
        {

            List<float> fListWaterValue = new List<float>();
   
          

            //fListWaterValue = cSelectProductionData.selectWellLayerYMValue2fListFromFileByLayerColumIndexAndYMColumIndex
           //(filePathWaterProduct, iValueWaterColumnIndex);

            List<int> iListXview = new List<int>();
            List<int> iListYview = new List<int>();
            for (int i = 0; i < ltStrSelectedWaterJH.Count; i++)
            {
                Point pWellView = cCordinationTransform.getPointViewByJH(ltStrSelectedWaterJH[i]);
                iListXview.Add(pWellView.X);
                iListYview.Add(pWellView.Y);
            }
            float dfscale = float.Parse(tbxPieR.Text);
            //XmlElement returnElemment = cLayerProductionMap.addgWaterWellProductionPie(ltStrSelectedWaterJH,iListXview,
            //    iListYview, fListWaterValue, dfscale);
            //cLayerProductionMap.addgElement2BaseLayer(returnElemment, 0, 0);

        }

        void addOilWellProductPieGraph(cIOMapLayer cSelectProductionData,cSVGDocLayerMapProduction cLayerProductionMap, string filePathOilProduct)
        {
            List<float> fListOilValueDay = new List<float>();
            List<float> fListWaterValueDay = new List<float>();
            List<float> fListOilValueSum = new List<float>();
            List<float> fListWaterValueSum = new List<float>();
            //ltStrSelectedOilJH = cSelectProductionData.selectJH2ltStrFromProductFile(filePathOilProduct);
//            fListOilValueDay = cSelectProductionData.selectWellLayerYMValue2fListFromFileByLayerColumIndexAndYMColumIndex
// (filePathOilProduct, 13);
//            fListWaterValueDay = cSelectProductionData.selectWellLayerYMValue2fListFromFileByLayerColumIndexAndYMColumIndex
//(filePathOilProduct, 14);
//            fListOilValueSum = cSelectProductionData.selectWellLayerYMValue2fListFromFileByLayerColumIndexAndYMColumIndex
// (filePathOilProduct, 9);
//            fListWaterValueSum = cSelectProductionData.selectWellLayerYMValue2fListFromFileByLayerColumIndexAndYMColumIndex
//(filePathOilProduct, 10);
            List<int> iListXviewOilWell = new List<int>();
            List<int> iListYviewOilWell = new List<int>();
            for (int i = 0; i < ltStrSelectedOilJH.Count; i++)
            {
                Point pWellView = cCordinationTransform.getPointViewByJH(ltStrSelectedOilJH[i]);
                iListXviewOilWell.Add(pWellView.X);
                iListYviewOilWell.Add(pWellView.Y);
            }
            float fPieScale = float.Parse(tbxPieR.Text);
            int iRectWidth = int.Parse(this.tbxRectWidth.Text);
            XmlElement returnElemment = cLayerProductionMap.addgOilWellProductionGraph(ltStrSelectedOilJH,
                iListXviewOilWell, iListYviewOilWell,
                fListOilValueDay, fListWaterValueDay, fListOilValueSum, fListWaterValueDay, fPieScale, iRectWidth);
            cLayerProductionMap.addgElement2BaseLayer(returnElemment, 0, 0);
        }
        void addWaterWellProductPieGraph(cIOMapLayer cSelectProductionData, cSVGDocLayerMapProduction cLayerProductionMap, string filePathWaterProduct)
        {
            List<float> fListWaterValueDay = new List<float>();
            List<float> fListWaterValueSum = new List<float>();
            //ltStrSelectedWaterJH = cSelectProductionData.selectJH2ltStrFromProductFile(filePathWaterProduct);

//            fListWaterValueDay = cSelectProductionData.selectWellLayerYMValue2fListFromFileByLayerColumIndexAndYMColumIndex
//(filePathWaterProduct, 4);

//            fListWaterValueSum = cSelectProductionData.selectWellLayerYMValue2fListFromFileByLayerColumIndexAndYMColumIndex
//(filePathWaterProduct, 5);
            List<int> iListXviewWaterWell = new List<int>();
            List<int> iListYviewWaterWell = new List<int>();
            for (int i = 0; i < ltStrSelectedWaterJH.Count; i++)
            {
                Point pWellView = cCordinationTransform.getPointViewByJH(ltStrSelectedWaterJH[i]);
                iListXviewWaterWell.Add(pWellView.X);
                iListYviewWaterWell.Add(pWellView.Y);
            }
            float fPieScale = float.Parse(tbxPieR.Text);
            int iRectWidth = int.Parse(this.tbxRectWidth.Text);
            XmlElement returnElemment = cLayerProductionMap.addgWaterWellProductionGraph(ltStrSelectedWaterJH,
                iListXviewWaterWell, iListYviewWaterWell, fListWaterValueDay, fListWaterValueDay,fPieScale, iRectWidth);
              
            cLayerProductionMap.addgElement2BaseLayer(returnElemment, 0, 0);
        }
        private void btnMap_Click(object sender, EventArgs e)
        {
     
            //此处分油井和水井提取不同的数据资料，油井提取 日产油，日产水，累产油，累产水
            //此处水井提取不同的数据资料，水井提取日注水，累注水

            cIOMapLayer cSelectProductionData = new cIOMapLayer();
           
            string filenameSVGMap;
            if (this.tbxMapTitleName.Text == "")
            { filenameSVGMap = sSelectedYYYYMM + "-ProductionMap.svg"; }
            else
            {
                filenameSVGMap = this.tbxMapTitleName.Text + ".svg";
            }
            cSVGDocLayerMapProduction cLayerProductionMap = 
                new cSVGDocLayerMapProduction( 800,1000,0, 0);
    
            XmlElement returnElemment;
            if (this.rdbPieMapDay.Checked == true)
            {   //日产 日注
                addOilWellPieMap(cSelectProductionData, 13, 14, cLayerProductionMap, filePathOilProduct);
                addWaterWellPieMap(cSelectProductionData, 4, cLayerProductionMap, filePathWaterProduct);
            }
            if (this.rdbPieMapMonth.Checked == true)
            {   //月产 月注
                addOilWellPieMap(cSelectProductionData, 5, 6, cLayerProductionMap, filePathOilProduct);
                addWaterWellPieMap(cSelectProductionData, 5, cLayerProductionMap, filePathWaterProduct);
            }
            if (this.rdbPieMapSum.Checked == true) 
            {   //累产 累注
                addOilWellPieMap(cSelectProductionData, 9, 10, cLayerProductionMap, filePathOilProduct);
                addWaterWellPieMap(cSelectProductionData, 6, cLayerProductionMap, filePathWaterProduct);
            }
            if (this.rdbProductMap.Checked == true)
            {
                addOilWellProductPieGraph(cSelectProductionData,cLayerProductionMap, filePathOilProduct);
                addWaterWellProductPieGraph(cSelectProductionData, cLayerProductionMap, filePathWaterProduct);
    
            }

         

            if (this.checkScaleRulerShowed.Checked == true)
            {
 
            }

        
            if (this.checkCompassShowed.Checked == true)
            {
                cLayerProductionMap.svgRoot.AppendChild(cLayerProductionMap.gCompass(100, 400));
            }
            cLayerProductionMap.makeSVGfile(cProjectManager.dirPathMap + filenameSVGMap);
             FormWebNavigation formSVGView = new FormWebNavigation(cProjectManager.dirPathMap + filenameSVGMap);formSVGView.Show();
        }

        private void tbxR_TextChanged(object sender, EventArgs e)
        {
            cPublicMethodForm.inputTextBoxPositiveRealOnly(tbxPieR);
        }


        private void tbxRectWidth_TextChanged(object sender, EventArgs e)
        {
            cPublicMethodForm.inputTextBoxIntOnly(tbxRectWidth);
        }

        private void trackBarTectWidth_Scroll(object sender, EventArgs e)
        {
            this.tbxRectWidth.Text = trackBarTectWidth.Value.ToString("0");
        }

        private void trackBarPieRValue_Scroll(object sender, EventArgs e)
        {
            tbxPieR.Text = (trackBarPieRValue.Value * 0.1).ToString();
        }

  
    }
}
