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
    public partial class FormLayerSettingPage : Form
    {
        string filePathOperate = "";
        public FormLayerSettingPage(string inputFileOper)
        {
            InitializeComponent();
            this.filePathOperate = inputFileOper;
            this.btnOK.DialogResult = DialogResult.OK;
            this.btnCancel.DialogResult = DialogResult.Cancel;
            this.tbxTitle.Text = cXmlBase.getNodeInnerText(filePathOperate, cXELayerPage.fmpMapTitle);
            nUDPageWidth.Value = decimal.Parse(cXmlBase.getNodeInnerText(filePathOperate, cXELayerPage.fmpPageWidth));
            nUDPageHeight.Value = decimal.Parse(cXmlBase.getNodeInnerText(filePathOperate, cXELayerPage.fmpPageHeight));
            nUDiNumExtendGrid.Value = decimal.Parse(cXmlBase.getNodeInnerText(filePathOperate, cXELayerPage.fmpGridNumExtend));
            string strGridSize = cXmlBase.getNodeInnerText(filePathOperate, cXELayerPage.fmpGridSize);
            if (strGridSize != "") nUDGridSize.Value = decimal.Parse(strGridSize);
            else nUDGridSize.Value = 500;
        }
        void initialCbbScale()
        {
            cPublicMethodForm.inialComboBox(cbbUnit, new List<string>(new string[] { "px", "pt", "mm", "pc", "cm", "in" }));
        }

        private void nUDiNumExtendGrid_ValueChanged(object sender, EventArgs e)
        {
            cXmlBase.setNodeInnerText(filePathOperate, cXELayerPage.fmpGridNumExtend, nUDiNumExtendGrid.Value.ToString("0"));
        }

        private void nUDPageWidth_ValueChanged(object sender, EventArgs e)
        {
            cXmlBase.setNodeInnerText(filePathOperate, cXELayerPage.fmpPageWidth, nUDPageWidth.Value.ToString("0"));
        }

        private void nUDPageHeight_ValueChanged(object sender, EventArgs e)
        {
            cXmlBase.setNodeInnerText(filePathOperate, cXELayerPage.fmpPageHeight, nUDPageHeight.Value.ToString("0"));
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }

        private void nUDGridSize_ValueChanged(object sender, EventArgs e)
        {
            cXmlBase.setNodeInnerText(filePathOperate, cXELayerPage.fmpGridSize, nUDGridSize.Value.ToString("0"));
        }

        private void cbxGrid_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxGrid.Checked == true) cXmlBase.setNodeInnerText(filePathOperate, cXELayerPage.fmpShowGrid, "1");
            else cXmlBase.setNodeInnerText(filePathOperate, cXELayerPage.fmpShowGrid, "0");
        }
    }
}
