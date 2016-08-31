using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DOGPlatform
{
    public partial class FormInjProAna : Form
    {
        public FormInjProAna()
        {
            InitializeComponent();
            InitControl();
        }
       
        List<string> ltJHProductWell = new List<string>();
        List<string> ltJHInjectWell = new List<string>();
        string sInjectWellSelected;
        List<string> ltJHProductWellSelected = new List<string>();
        string sSelectedLayer;

        private void InitControl()
        {
            cPublicMethodForm.inialComboBox(cbbSelectedLayerName, cProjectData.ltStrProjectXCM);
            cPublicMethodForm.inialComboBox(cbbWellProduct, ltJHProductWell);
            cPublicMethodForm.inialComboBox(cbbWellInject, ltJHInjectWell);
       }

        private void btnCalResult_Click(object sender, EventArgs e)
        {
            sSelectedLayer=cbbSelectedLayerName.SelectedItem.ToString();
            List<ItemDicLayerDataStatic> listDicLayer = cIODicLayerDataStatic.readDicLayerData2struct();
            ItemDicLayerDataStatic wellInjectLayerdata=listDicLayer.Find(p=>p.sJH==this.cbbWellInject.SelectedItem.ToString()
                && p.sXCM==sSelectedLayer);
            for (int i = 0; i < dgvInj2Pro.RowCount-1; i++) 
            {
                string sJHProdcut = dgvInj2Pro.Rows[i].Cells[1].Value.ToString();
                  ItemDicLayerDataStatic wellProductLayerdata=listDicLayer.Find(p=>p.sJH==sJHProdcut
                && p.sXCM==sSelectedLayer);
                //计算井距
                double distance = cCalDistance.calDistance2D(wellInjectLayerdata.dbX, wellInjectLayerdata.dbY, wellProductLayerdata.dbX, wellProductLayerdata.dbY);
                dgvInj2Pro.Rows[i].Cells[2].Value = distance.ToString("0.0");
                //根据井号和小层名查累积射开厚度
                ItemDicPerforation performItem = cIOinputWellPerforation.getItemByJHandXCM(sJHProdcut, sSelectedLayer);
                dgvInj2Pro.Rows[i].Cells[3].Value = performItem.fSKHD.ToString("0.0");
                //根据井号和小层名查吸水比例
                ItemDicInjectProfile profileItem = cIOinputInjectProfile.getItemByJHandXCM(sJHProdcut, sSelectedLayer);
                dgvInj2Pro.Rows[i].Cells[4].Value = profileItem.fPercentZR.ToString("0.0");
                dgvInj2Pro.Rows[i].Cells[5].Value = profileItem.fXSHD.ToString("0.0");
                //小层数据表选项
                  dgvInj2Pro.Rows[i].Cells[6].Value = wellProductLayerdata.fKXD.ToString("0.0");
                dgvInj2Pro.Rows[i].Cells[7].Value = wellProductLayerdata.fSTL.ToString("0.0");
                dgvInj2Pro.Rows[i].Cells[8].Value = sSelectedLayer; 
            }


          //  cCalDistance.calWellHeadWellDistance(sInjectWellSelected, ltStrSelectedJH, fileName);
            //cPublicMethodForm.read2DataGridViewByTextFile(fileName, this.dgvInj2Pro);
        }



        private void btnAddConnectWell_Click(object sender, EventArgs e)
        {
            int index = this.dgvInj2Pro.Rows.Add();
            this.dgvInj2Pro.Rows[index].Cells[0].Value = cbbWellInject.SelectedItem.ToString();
            this.dgvInj2Pro.Rows[index].Cells[1].Value = cbbWellProduct.SelectedItem.ToString();
        }

        private void btnDelConnectJH_Click(object sender, EventArgs e)
        {
            cPublicMethodForm.deleteSelectedCurrentRowDGV(dgvInj2Pro);
        }

        private void btnCalConnectWell_Click(object sender, EventArgs e)
        {
            int index = this.dgvInj2Pro.Rows.Add();
            this.dgvInj2Pro.Rows[index].Cells[0].Value = cbbWellInject.SelectedItem.ToString();
            this.dgvInj2Pro.Rows[index].Cells[1].Value = cbbWellInject.SelectedItem.ToString();
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
         
        }

        private void cbbSelectedLayerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.sSelectedLayer = cbbSelectedLayerName.SelectedItem.ToString();
        }

     

        
    }
}
