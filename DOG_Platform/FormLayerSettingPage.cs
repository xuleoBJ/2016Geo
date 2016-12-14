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
        }
        void initialCbbScale()
        {
            cPublicMethodForm.inialComboBox(cbbUnit, new List<string>(new string[] { "px", "pt", "mm", "pc", "cm", "in" }));
        }

        private void nUDiNumExtendGrid_ValueChanged(object sender, EventArgs e)
        {
            cXmlBase.setNodeInnerText(filePathOperate, cXELayerPage.fmpNumExtendGrid, nUDiNumExtendGrid.Value.ToString("0"));
        }

        private void nUDPageWidth_ValueChanged(object sender, EventArgs e)
        {
            cXmlBase.setNodeInnerText(filePathOperate, cXELayerPage.fmpPageWidth, nUDPageWidth.Value.ToString("0"));
        }

        private void nUDPageHeight_ValueChanged(object sender, EventArgs e)
        {
            cXmlBase.setNodeInnerText(filePathOperate, cXELayerPage.fmpPageHeight, nUDPageHeight.Value.ToString("0"));
        }
    }
}
