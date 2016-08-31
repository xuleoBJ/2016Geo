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
    public partial class FormSettingElevationRuler : Form
    {
        string xmlPath = "";
        public FormSettingElevationRuler(string inputXmlPath)
        {
            InitializeComponent();
            this.xmlPath = inputXmlPath;
            nUDElevationRulerTop.Value = decimal.Parse( cXmlBase.getNodeInnerText(xmlPath, cXETrackRuler.xmlFullPathTopElevationDepth));
            nUDElevationRulerBottom.Value=Decimal.Parse(cXmlBase.getNodeInnerText(xmlPath, cXETrackRuler.xmlFullPathBotElevationDepth));
            nUDElevationScale.Value =decimal.Parse( cXmlBase.getNodeInnerText(xmlPath, cXETrackRuler.xmlFullPathMainScale));
            nUDElevationFontSize.Value = decimal.Parse(cXmlBase.getNodeInnerText(xmlPath, cXETrackRuler.xmlFullPathiFontSize));
            int iVisible = int.Parse( cXmlBase.getNodeInnerText(xmlPath, cXETrackRuler.xmlFullPathiVisible));
            cbxRulerElavationVisible.Checked =   iVisible==1 ? true : false;
            this.btnOK.DialogResult = DialogResult.OK; 
            this.btnCancel.DialogResult = DialogResult.Cancel;
        }

        private void nUDElevationScale_ValueChanged(object sender, EventArgs e)
        {
            cXmlBase.setNodeInnerText(xmlPath, cXETrackRuler.xmlFullPathMainScale, nUDElevationScale.Value.ToString("0"));
        }
        private void nUDElevationFontSize_ValueChanged(object sender, EventArgs e)
        {
            cXmlBase.setNodeInnerText(xmlPath, cXETrackRuler.xmlFullPathiFontSize, nUDElevationFontSize.Value.ToString("0"));
        }
       
        private void nUDElevationRulerTop_ValueChanged(object sender, EventArgs e)
        {
            cXmlBase.setNodeInnerText(xmlPath, cXETrackRuler.xmlFullPathTopElevationDepth, nUDElevationRulerTop.Value.ToString("0"));
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            cProjectData.iSectionCSSModified = 1; //记录被xml被修改过
            this.Close();
        }

        private void nUDElevationRulerBottom_ValueChanged(object sender, EventArgs e)
        {
            cXmlBase.setNodeInnerText(xmlPath, cXETrackRuler.xmlFullPathBotElevationDepth, nUDElevationRulerBottom.Value.ToString("0"));
        }

        private void cbxRulerElavationVisible_CheckedChanged(object sender, EventArgs e)
        {
            int iVisible = cbxRulerElavationVisible.Checked == true ? 1 : 0;
            cXmlBase.setNodeInnerText(xmlPath, cXETrackRuler.xmlFullPathiVisible, iVisible.ToString());
        }

     

      

      

       

       
    }
}
