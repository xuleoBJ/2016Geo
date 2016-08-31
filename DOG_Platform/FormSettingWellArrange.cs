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
    public partial class FormSettingWellArrange : Form
    {
        string xmlPath = "";
        public FormSettingWellArrange(string inputXmlPath)
        {
            InitializeComponent();
            this.btnOK.DialogResult = DialogResult.OK;
            this.btnCancel.DialogResult = DialogResult.Cancel;
            this.xmlPath = inputXmlPath;
        }

        private void nUDWellDistanceScale_ValueChanged(object sender, EventArgs e)
        {
          cXmlBase.setNodeInnerText(xmlPath, cXEGeopage.xmlFullPathPageHorizonWellDistanceScale, nUDWellDistanceScale.Value.ToString("0"));
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            cProjectData.iSectionCSSModified = 1;
            this.Close();
        }

        //定义 iChoise==1 等间隔排列，iChoise==2 相邻井真实距离缩放 
        private void rdbPlaceBYWellDistance_CheckedChanged(object sender, EventArgs e)
        {
            if(rdbPlaceBYWellDistance.Checked==true)
            cXmlBase.setNodeInnerText(xmlPath, cXEGeopage.xmlFullPathPageWellArrange, "2");
        }

        private void rdbPlaceByEqual_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbPlaceByEqual.Checked == true)
            cXmlBase.setNodeInnerText(xmlPath, cXEGeopage.xmlFullPathPageWellArrange, "1");
        }
      
    }
}
