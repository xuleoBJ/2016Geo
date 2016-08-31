using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DOGPlatform.XML;

namespace DOGPlatform
{
    public partial class FormLayerDevelopState : Form
    {
        string filePathOperate;
        List<ItemDicLayerDataDynamic> listLayersDataCurrentLayerDynamic = new List<ItemDicLayerDataDynamic>();
        List<ItemDicLayerDataStatic> listLayersDataCurrentLayerStatic = new List<ItemDicLayerDataStatic>();
        string sSelectLayer = "";
        string sSelectYM = DateTime.Now.ToString("yyyyMM");
        public FormLayerDevelopState()
        {
            InitializeComponent();
            lbxSelectDynamicJH.DataSource = cProjectData.ltStrProjectJH;
        }
        private void lbxJHLayerMap_SelectedValueChanged(object sender, EventArgs e)
        {
            this.lblNumSelectedWells.Text = "选择井数:" + this.lbxSelectDynamicJH.SelectedItems.Count.ToString();
        }

        private void btnSelectWorkWells_Click(object sender, EventArgs e)
        {
            if (rdbALLayer.Checked == true)
                listLayersDataCurrentLayerDynamic = cIODicLayerDataDynamic.readDicLayerData2struct(sSelectYM, cProjectData.sAllLayer);
            else
                listLayersDataCurrentLayerDynamic = cIODicLayerDataDynamic.readDicLayerData2struct(sSelectYM, sSelectLayer);
            //增加当前动态字典数据
            cXMLLayerMapDynamic.addWellDynamicDataDic2XML(filePathOperate, sSelectYM, sSelectLayer, listLayersDataCurrentLayerDynamic);

            List<ItemWellMapPosition> listWellsDynamic = new List<ItemWellMapPosition>();
            foreach (ItemDicLayerDataDynamic itemDynamicLayerData in listLayersDataCurrentLayerDynamic)
            {
                ItemWellMapPosition itemWellDynamic = new ItemWellMapPosition();
                if (itemDynamicLayerData.iWellType != 0) //remove well not work
                {
                    itemWellDynamic.sJH = itemDynamicLayerData.sJH;
                    itemWellDynamic.sXCM = sSelectLayer; //here use globe sSelectLayer because user may select ALLLayerData
                    ItemDicLayerDataStatic itemStaitic = listLayersDataCurrentLayerStatic.Find(p => p.sJH == itemWellDynamic.sJH && p.sXCM == sSelectLayer);
                    itemWellDynamic.dbX = itemStaitic.dbX;
                    itemWellDynamic.dbY = itemStaitic.dbY;

                    itemWellDynamic.iWellType = itemDynamicLayerData.iWellType;

                    listWellsDynamic.Add(itemWellDynamic);
                }
            }
            ////增加当前生产井井位图层
            //cXMLLayerMapStatic.addLayerWellPosition2XML(filePathOperate, sSelectLayer + "_" + sSelectYM, listWellsDynamic);
            ////增加日产日注分析
            //if (listLayersDataCurrentLayerDynamic.Count > 0)
            //    cPublicMethodForm.setListBoxwithltStr(lbxSelectDynamicJH, listWellsDynamic.Select(p => p.sJH).ToList());
        }
        private void btnAddLayerDynamic_Click(object sender, EventArgs e)
        {
            string sIDLayer = "DynamicWells";
            if (tbxLayerIDSelectWellByCondition.Text != "") sIDLayer = tbxLayerIDSelectWellByCondition.Text;
            //增加日产日注分析
            float fVScale = float.Parse(tbxRectWidth.Text);
            cXMLLayerMapDynamic.addLayerDailyProduct2XML(filePathOperate, sIDLayer + TypeLayer.LayerDailyProduct.ToString(), fVScale);
            float fRscale = float.Parse(tbxPieR.Text);
            cXMLLayerMapDynamic.addLayerSumProduct2XML(filePathOperate, sIDLayer + TypeLayer.LayerSumProduct.ToString(), fRscale);
            //增加累产累注分析
        }
    }
}
