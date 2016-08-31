using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using DOGPlatform.XML;

namespace DOGPlatform
{
    public partial class FormExport2Map : Form
    {
        public float fTopShow { get; set; }
        public float fBotShow { get; set; } 
        string xmlPath = "";
        public FormExport2Map(string inputXmlPath)
        {
            InitializeComponent();
            this.xmlPath = inputXmlPath;
            nUDShowedBottom.Value = decimal.Parse(cXmlBase.getNodeInnerText(xmlPath, cXEWellPage.fullPathBotDepth));
            this.btnOK.DialogResult = DialogResult.OK;
            this.btnCancel.DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            fTopShow = 0;
            fBotShow = 3000;
            fTopShow = (float)nUDShowedTop.Value;
            fBotShow = (float)nUDShowedBottom.Value;
        }

     }
}
