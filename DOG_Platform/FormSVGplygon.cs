using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DOGPlatform.SVG;
using DOGPlatform.XML;

namespace DOGPlatform
{
    public partial class FormSVGplygon : Form
    {
        ColorDialog colorDialog1 = new ColorDialog();
        string filePathTemple = "";
        string sLogID = "";
        string sJH = "";
        public FormSVGplygon(string _filePathTemple, string _sIDLogtrack)
        {
            InitializeComponent();
            this.filePathTemple = _filePathTemple;
            this.sLogID = _sIDLogtrack;
            this.btnOK.DialogResult = DialogResult.OK;
            this.btnCancel.DialogResult = DialogResult.Cancel;
            sJH = cXmlDocSectionWell.getJH(filePathTemple);
            string sFill = cXmlBase.getSelectedNodeChildNodeValue(filePathTemple, sLogID, "fill");
            if (sFill == "none") sFill = "";
            tbxFillColor.Text = sFill;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string svgFilePath = Path.Combine(cProjectManager.dirPathTemp, sJH + ".svg");
            cSVGoperate.updateXElementValueByID(svgFilePath, sLogID, "fill", tbxFillColor.Text);
        }
    }
}
