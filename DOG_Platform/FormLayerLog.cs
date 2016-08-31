using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using DOGPlatform.XML;

namespace DOGPlatform
{
    public partial class FormLayerLog : Form
    {
        ColorDialog colorDialog1 = new ColorDialog();
        string filePathLayerCss;
        string sLayerID;

        public FormLayerLog()
        {
            InitializeComponent();
        }

        public FormLayerLog(string inputXmlPath,string sinputIDLayer)
        {
            InitializeComponent();
            this.btnOK.DialogResult = DialogResult.OK;
            cPublicMethodForm.inialComboBox(this.cbbLog, cProjectData.ltStrProjectGlobeLog);
            this.btnCancel.DialogResult = DialogResult.Cancel;
            this.filePathLayerCss = inputXmlPath;
            this.sLayerID = sinputIDLayer;

            cbbLog.SelectedItem = cXmlBase.getSelectedNodeChildNodeValue(filePathLayerCss, sLayerID, "logName");
            nTBXleftValue.Text = cXmlBase.getSelectedNodeChildNodeValue(filePathLayerCss, sLayerID, "leftValue");
            nTBXrightValue.Text = cXmlBase.getSelectedNodeChildNodeValue(filePathLayerCss, sLayerID, "rightValue");
            //nUDDrawInterval.Value = decimal.Parse(cXmlBase.getSelectedNodeChildNodeValue(filePathLayerCss, sLayerID, "sparsePoint"));
            nUDTrackWidth.Value = decimal.Parse(cXmlBase.getSelectedNodeChildNodeValue(filePathLayerCss, sLayerID, "trackWidth"));
            nUDfVScale.Value = decimal.Parse(cXmlBase.getSelectedNodeChildNodeValue(filePathLayerCss, sLayerID, "fVScale"));
            string sFill = cXmlBase.getSelectedNodeChildNodeValue(filePathLayerCss, sLayerID, "sFill");
            tbxFillColor.Text = sFill;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string sLog = cbbLog.SelectedItem.ToString();
            //设置测井名
            cXmlDocLayer.setSelectedNodeChildNodeValue(this.filePathLayerCss, sLayerID, "logName", sLog);
            cXmlBase.setSelectedNodeChildNodeValue(filePathLayerCss, sLayerID, "leftValue", nTBXleftValue.Text);
            cXmlBase.setSelectedNodeChildNodeValue(filePathLayerCss, sLayerID, "rightValue", nTBXrightValue.Text);
            cXmlBase.setSelectedNodeChildNodeValue(filePathLayerCss, sLayerID, "trackWidth", nUDTrackWidth.Value.ToString("0"));
            //cXmlBase.setSelectedNodeChildNodeValue(filePathLayerCss, sLayerID, "sparsePoint", nUDDrawInterval.Value.ToString("0"));
            cXmlBase.setSelectedNodeChildNodeValue(filePathLayerCss, sLayerID, "fVScale", nUDfVScale.Value.ToString("0.0"));
            if (tbxFillColor.Text == "") cXmlBase.setSelectedNodeChildNodeValue(filePathLayerCss, sLayerID, "fill", "none");
            //根据井号、层位段，深度段写入 这样 数据量小。
        }

        private void btnSeleclFillColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                string sHexColor = cPublicMethodBase.HexConverter(colorDialog1.Color);
                this.tbxFillColor.BackColor = colorDialog1.Color;
                this.tbxFillColor.Text = sHexColor;
                cXmlBase.setSelectedNodeChildNodeValue(filePathLayerCss, sLayerID, "sFill", this.tbxFillColor.Text);
            }
            else
            {
                this.tbxFillColor.BackColor = Color.White;
                this.tbxFillColor.Text = "";
                cXmlBase.setSelectedNodeChildNodeValue(filePathLayerCss, sLayerID, "sFill", "none");
            }
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                string sHexColor = cPublicMethodBase.HexConverter(colorDialog1.Color);
                this.tbxLogColor.BackColor = colorDialog1.Color;
                this.tbxLogColor.Text = sHexColor;
                cXmlBase.setSelectedNodeChildNodeValue(filePathLayerCss, sLayerID, "curveColor", sHexColor);
            }
        }
     

      
    }
}
