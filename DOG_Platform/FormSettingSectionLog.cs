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
using DigRobot;
using DOGPlatform.SVG;
using System.IO;

namespace DOGPlatform
{
    public partial class FormSettingSectionLog : Form
    {

        ColorDialog colorDialog1 = new ColorDialog();
        string filePathTemple = "";
        string sLogID = "";
        string sJH = "";
        public FormSettingSectionLog(string _filePathTemple,string _sIDLogtrack)
        {
            InitializeComponent();
            this.filePathTemple = _filePathTemple;
            this.sLogID = _sIDLogtrack;
            this.btnOK.DialogResult = DialogResult.OK;
            this.btnCancel.DialogResult = DialogResult.Cancel;
            sJH = cXmlDocSectionWell.getJH(filePathTemple);
            cbxGrid.Checked = Convert.ToBoolean(cXEtrack.getTrackHasGrid(filePathTemple, sLogID));
            cbxLog.Checked = Convert.ToBoolean(cXEtrack.getIsLog10(filePathTemple, sLogID));
            this.tbxLogname.Text = cXmlBase.getSelectedNodeChildNodeValue(filePathTemple, sLogID, "logName");
            nTBXleftValue.Text = cXmlBase.getSelectedNodeChildNodeValue(filePathTemple, sLogID, "leftValue");
            nTBXrightValue.Text=cXmlBase.getSelectedNodeChildNodeValue(filePathTemple, sLogID, "rightValue");
            tbxLogSunit.Text = cXmlBase.getSelectedNodeChildNodeValue(filePathTemple, sLogID, "unit");
            nUDDrawInterval.Value = decimal.Parse(cXmlBase.getSelectedNodeChildNodeValue(filePathTemple, sLogID, "sparsePoint"));
            string sFill= cXmlBase.getSelectedNodeChildNodeValue(filePathTemple, sLogID, "fill");

           string sTypeMode=cXmlBase.getSelectedNodeChildNodeValue(filePathTemple, sLogID, "typeMode");
           cbbTypeMode.SelectedItem = sTypeMode;
            if (sFill == "none") sFill = "";
            tbxFillColor.Text = sFill;
        }

        private void nUDLineWidth_ValueChanged(object sender, EventArgs e)
        {
            cXmlBase.setSelectedNodeChildNodeValue(filePathTemple, sLogID, "lineWidth", nUDLineWidth.Value.ToString("0.0"));
        }

        private void cbbLineType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int iLineType = 0;
            if (cbbLineType.SelectedIndex >= 0) iLineType = cbbLineType.SelectedIndex;
            cXmlBase.setSelectedNodeChildNodeValue(filePathTemple, sLogID, "lineType", iLineType.ToString());
        }
        private void cbxGrid_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxGrid.Checked == true) cXEtrack.setTrackHasGrid(filePathTemple, sLogID, 1);
            else cXEtrack.setTrackHasGrid(filePathTemple, sLogID, 0);
        }

        private void cbxLog_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxLog.Checked == true)
            {
                cXEtrack.setIsLog10(filePathTemple, sLogID,  1);
                if (nTBXleftValue.doubleText() < 0) 
                {
                    nTBXleftValue.Text = "1";
                }
            }
            else cXEtrack.setIsLog10(filePathTemple, sLogID,  0);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            cXmlBase.setSelectedNodeChildNodeValue(filePathTemple, sLogID, "leftValue", nTBXleftValue.Text);
            cXmlBase.setSelectedNodeChildNodeValue(filePathTemple, sLogID, "rightValue", nTBXrightValue.Text);
            cXmlBase.setSelectedNodeChildNodeValue(filePathTemple, sLogID, "unit",tbxLogSunit.Text);
            cXmlBase.setSelectedNodeChildNodeValue(filePathTemple, sLogID, "logName",this.tbxLogname.Text );
            setTypeMode();
            if(tbxFillColor.Text=="") cXmlBase.setSelectedNodeChildNodeValue(filePathTemple, sLogID, "fill", "none");
        }

        void setTypeMode() 
        {
           int iMode=cbbTypeMode.SelectedIndex;
           string sTypeMode=TypeTrack.曲线.ToString();
           if(iMode==1) sTypeMode=TypeTrack.散点.ToString();
           if(iMode==2) sTypeMode=TypeTrack.杆状.ToString();
           cXmlBase.setSelectedNodeChildNodeValue(filePathTemple, sLogID, "typeMode", sTypeMode);
        }
       
        private void btnColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                string sHexColor = cPublicMethodBase.HexConverter(colorDialog1.Color);
                this.tbxLogColor.BackColor = colorDialog1.Color;
                this.tbxLogColor.Text = sHexColor;
                cXmlBase.setSelectedNodeChildNodeValue(filePathTemple, sLogID, "curveColor", sHexColor);
            }
        }

        private void btnLeftRightCov_Click(object sender, EventArgs e)
        {
            if (cbxLog.Checked == false)
            {
                string mid = nTBXleftValue.Text;
                nTBXleftValue.Text = nTBXrightValue.Text;
                nTBXrightValue.Text = mid;
            }
        }

        private void btnSeleclFillColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                string sHexColor = cPublicMethodBase.HexConverter(colorDialog1.Color);
                this.tbxFillColor.BackColor = colorDialog1.Color;
                this.tbxFillColor.Text = sHexColor;
                cXmlBase.setSelectedNodeChildNodeValue(filePathTemple, sLogID, "fill", this.tbxFillColor.Text);
            }
            else 
            {
                this.tbxFillColor.BackColor = Color.White ;
                this.tbxFillColor.Text = "";
                cXmlBase.setSelectedNodeChildNodeValue(filePathTemple, sLogID, "fill", "none"); 
            }
        }

        private void nUDDrawInterval_ValueChanged(object sender, EventArgs e)
        {
            cXmlBase.setSelectedNodeChildNodeValue(filePathTemple, sLogID, "sparsePoint", nUDDrawInterval.Value.ToString("0"));
        }

             
    }
}
