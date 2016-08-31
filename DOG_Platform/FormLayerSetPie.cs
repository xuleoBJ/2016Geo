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
    public partial class FormLayerSetPie : Form
    {
        string xmlPath = "";
        string sIDLayer = "";
        public FormLayerSetPie(string _inputXmlPath, string _sIDLayer)
        {
            InitializeComponent();
            this.xmlPath = _inputXmlPath;
            this.sIDLayer = _sIDLayer;
            this.btnOK.DialogResult = DialogResult.OK;
            this.btnCancel.DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string sValue = tbxOuterDataLayerPiefR.Text;
            cXmlBase.setSelectedNodeChildNodeValue(xmlPath, sIDLayer, "fScaleR", sValue);
        }

        private void nUDLayerOpcity_ValueChanged(object sender, EventArgs e)
        {
            cXmlBase.setSelectedNodeChildNodeValue(xmlPath, sIDLayer, "fill-opacity", nUDLayerOpcity.Value.ToString());
        }
    }
}
