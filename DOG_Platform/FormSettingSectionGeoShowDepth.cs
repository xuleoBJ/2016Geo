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
    public partial class FormSettingSectionGeoShowDepth : Form
    {
         string pathSectionCss = "";
         string sJH;
         public FormSettingSectionGeoShowDepth(string inputpathSectionCss,string _sJH)
        {
            InitializeComponent();
            this.btnCancel.DialogResult = DialogResult.Cancel;
            this.pathSectionCss = inputpathSectionCss;
            this.sJH = _sJH;
            nUDShowedTop.Value = decimal.Parse(cXmlBase.getSelectedNodeChildNodeValue(pathSectionCss, sJH, "fShowTop"));
            nUDShowedBottom.Value = decimal.Parse(cXmlBase.getSelectedNodeChildNodeValue(pathSectionCss, sJH, "fShowBot"));
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

            float showDepthMDTop =(float) nUDShowedTop.Value;
            float showDepthMDBot = (float)nUDShowedBottom.Value;
            if (rdbEle.Checked == true) 
            {
                ItemWell curWell= cProjectData.ltProjectWell.SingleOrDefault(p => p.sJH == sJH);
                if (curWell != null) 
                {
                    showDepthMDTop = - showDepthMDTop + curWell.fKB;
                    showDepthMDBot = - showDepthMDBot  + curWell.fKB;
                }
 
            }
            if (showDepthMDBot > showDepthMDTop)
            {
                cXmlBase.setSelectedNodeChildNodeValue(pathSectionCss, sJH, "fShowTop", showDepthMDTop.ToString("0"));
                cXmlBase.setSelectedNodeChildNodeValue(pathSectionCss, sJH, "fShowBot", showDepthMDBot.ToString("0"));
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else 
            {
                MessageBox.Show("显示底深必须大于顶深。");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void cbxShowWellBase_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxShowWellBase.Checked == true) 
            {
                 ItemWell curWell= cProjectData.ltProjectWell.SingleOrDefault(p => p.sJH == sJH);
                if (curWell != null) 
                {
                   if(rdbMD.Checked==true) nUDShowedBottom.Value =(decimal) curWell.fWellBase;
                   if (rdbEle.Checked == true) nUDShowedBottom.Value = (decimal)(-curWell.fWellBase +curWell.fKB);
               }
            }
        }
    }
}
