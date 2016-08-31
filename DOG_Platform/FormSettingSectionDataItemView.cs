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
using System.Xml;

namespace DOGPlatform
{
    public partial class FormSettingSectionDataItemView : Form
    {
        string filePathTemple = "";
        string sJH = "";
        ItemTrackDrawDataIntervalProperty itemInterval = new ItemTrackDrawDataIntervalProperty();
        public FormSettingSectionDataItemView(string _filePathTemple, string sIDdataItem, string sTypeTrack)
        {
            InitializeComponent();
            this.filePathTemple = _filePathTemple;
            this.sJH = cXmlDocSectionWell.getJH(filePathTemple);
            itemInterval.sID = sIDdataItem;
            this.btnOK.DialogResult = DialogResult.OK;
            this.btnCancel.DialogResult = DialogResult.Cancel;
            this.nTBXTopDepth.Text = cXmlBase.getSelectedNodeChildNodeValue(filePathTemple, sIDdataItem, "top");
            this.nTBXBotDepth.Text = cXmlBase.getSelectedNodeChildNodeValue(filePathTemple, sIDdataItem, "bot");
            if (sTypeTrack == TypeTrack.测井解释.ToString())
            {
                cPublicMethodForm.inialComboBox(this.cbbSelect, codeReplace.ltStrJSJL);
                string sRetJSJL = cXmlBase.getSelectedNodeChildNodeValue(filePathTemple, sIDdataItem, "sProperty");
                cbbSelect.SelectedIndex = codeReplace.codeReplaceJSJL2int(sRetJSJL);
            }
            if (sTypeTrack == TypeTrack.沉积旋回.ToString())
            {
                cPublicMethodForm.inialComboBox(this.cbbSelect, codeReplace.ltStrGeoCycle);
                string sRetJSJL = cXmlBase.getSelectedNodeChildNodeValue(filePathTemple, sIDdataItem, "sProperty");
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            itemInterval.top = float.Parse(nTBXTopDepth.Text);
            itemInterval.bot = float.Parse(nTBXBotDepth.Text);
            itemInterval.calTVD(sJH);
            string sJSJL = "0";
            if (cbbSelect.SelectedItem.ToString() != "") sJSJL = cbbSelect.SelectedItem.ToString();
            itemInterval.sProperty = sJSJL;
            cXmlDocSectionWell.setDataIntervalProperty(filePathTemple, itemInterval);
        }

        private void cbbJSJL_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbxGetLastDepthBot_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxGetLastDepthBot.Checked == true) 
            {
                XmlNode selectedNode = cXmlBase.selectPreNodeByID(filePathTemple, itemInterval.sID);
                if (selectedNode!=null) nTBXTopDepth.Text=selectedNode["bot"].InnerText;
            }
        }

        private void cbxGetNextDepthTop_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxGetNextDepthTop.Checked == true) 
            {
                XmlNode selectNode = cXmlBase.selectNextNodeByID(filePathTemple, itemInterval.sID);
                if(selectNode!=null) nTBXBotDepth.Text=selectNode["top"].InnerText;
            }
        }
    }
}
