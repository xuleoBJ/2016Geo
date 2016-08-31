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
    public partial class FormLayerSettingWell : Form
    {
        string filePathOperate = "";
        public FormLayerSettingWell(string inputFileOper)
        {
            InitializeComponent();
            this.filePathOperate = inputFileOper;
            this.btnOK.DialogResult = DialogResult.OK;
            this.btnCancel.DialogResult = DialogResult.Cancel;
            nUDJHFontSize.Value=decimal.Parse(cXmlBase.getNodeInnerText(filePathOperate,cXEWellCss.fmpJHFontSize));
            nUDWellCircle_R.Value = decimal.Parse(cXmlBase.getNodeInnerText(filePathOperate, cXEWellCss.fmpiR));
            this.nUDCirleLineWidth.Value = decimal.Parse(cXmlBase.getNodeInnerText(filePathOperate, cXEWellCss.fmpRlineWidth));
            this.nUDJHtext_DX.Value = decimal.Parse(cXmlBase.getNodeInnerText(filePathOperate, cXEWellCss.fmpDX));
            this.nUDJHtext_DY.Value = decimal.Parse(cXmlBase.getNodeInnerText(filePathOperate, cXEWellCss.fmpDY));
        }
        private void nUDWellCircle_R_ValueChanged(object sender, EventArgs e)
        {
            cXEWellCss.setRdiusValueWellCircle(filePathOperate, Convert.ToInt16(nUDWellCircle_R.Value));
        }

        private void nUDJHtext_DX_ValueChanged(object sender, EventArgs e)
        {
            cXEWellCss.setJH_Dxoffset(filePathOperate, Convert.ToInt16(nUDJHtext_DX.Value));
        }
     
        private void nUDJHFontSize_ValueChanged(object sender, EventArgs e)
        {
            cXEWellCss.setJHsize(filePathOperate, Convert.ToInt16(nUDJHFontSize.Value));
        }
        private void nUDCirleLineWidth_ValueChanged(object sender, EventArgs e)
        {
            cXEWellCss.setLineWidthWellCircle(filePathOperate, Convert.ToInt16(this.nUDCirleLineWidth.Value));
        }

        private void nUDJHtext_DY_ValueChanged(object sender, EventArgs e)
        {
            cXmlBase.updateNodeValueByAbsPath(filePathOperate, cXEWellCss.fmpDY, nUDJHtext_DY.Value.ToString());
        }
    }
}
