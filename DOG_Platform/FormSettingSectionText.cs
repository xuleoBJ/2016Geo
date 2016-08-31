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
using System.Xml;

namespace DOGPlatform
{
    public partial class FormSettingSectionText : Form
    {
        ColorDialog colorDialog1 = new ColorDialog();
        string filePathTemple = "";

        string sIDTrack = ""; //插入道的ID
        string sJH = "";
        ItemTrackDrawDataIntervalProperty itemInterval = new ItemTrackDrawDataIntervalProperty();
        public FormSettingSectionText(string _filePathTemple, string _sID)
        {
            InitializeComponent();
            this.filePathTemple = _filePathTemple;
            itemInterval.sID= _sID;
            this.btnOK.DialogResult = DialogResult.OK;
            this.btnCancel.DialogResult = DialogResult.Cancel;
            this.nTBXTopDepth.Text = cXmlBase.getSelectedNodeChildNodeValue(filePathTemple, itemInterval.sID, "top");
            this.nTBXBotDepth.Text = cXmlBase.getSelectedNodeChildNodeValue(filePathTemple, itemInterval.sID, "bot");
            this.tbxStext.Text = cXmlBase.getSelectedNodeChildNodeValue(filePathTemple, itemInterval.sID, "sText");
            this.tbxBackColor.Text = cXmlBase.getSelectedNodeChildNodeValue(filePathTemple, itemInterval.sID, "sProperty");
        }

        public FormSettingSectionText(string _filePathTemple, string _sIDInsertTrack, string _typeTrackStr, double fTop, double fBot)
        {
            InitializeComponent();
            this.filePathTemple = _filePathTemple;
            sIDTrack = _sIDInsertTrack;
            if (fTop > fBot)
            {
                double fMiddle = fTop;
                fTop = fBot;
                fBot = fMiddle;
            }
            this.btnOK.DialogResult = DialogResult.OK;
            this.btnCancel.DialogResult = DialogResult.Cancel;
            this.nTBXTopDepth.Text = fTop.ToString("0.00");
            this.nTBXBotDepth.Text = fBot.ToString("0.00");
        }
        private void btnOK_Click(object sender, EventArgs e)
        {

            itemInterval.top = float.Parse(nTBXTopDepth.Text);
            itemInterval.bot = float.Parse(nTBXBotDepth.Text);
            itemInterval.calTVD(sJH);
            itemInterval.sText = this.tbxStext.Text;
            itemInterval.sProperty = this.tbxBackColor.Text;
            if (itemInterval.bot > itemInterval.top)
            {
                //查找是否存在，存在更改，不存在再添加 
                if (itemInterval.sID == "")
                {
                    cXmlDocSectionWell.addDataItemIntervalProperty(filePathTemple, sIDTrack, itemInterval);
                    cXmlDocSectionWell.sortSelectTrackItem(filePathTemple, sIDTrack);
                }
                else
                {
                    cXmlDocSectionWell.setDataIntervalProperty(filePathTemple, itemInterval);
                }
            }
            else
            {
                MessageBox.Show("顶底深不正确。");
            }
           
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                string sHexColor = cPublicMethodBase.HexConverter(colorDialog1.Color);
                this.tbxBackColor.BackColor = colorDialog1.Color;
                this.tbxBackColor.Text = sHexColor;
            }
        }

        private void cbbAlign_SelectedIndexChanged(object sender, EventArgs e)
        {
            cXmlBase.setSelectedNodeChildNodeValue(filePathTemple, itemInterval.sID, "sText", this.tbxStext.Text);
        }

        private void tbxBackColor_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbxGetLastDepthBot_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxGetLastDepthBot.Checked == true)
            {
                XmlNode selectedNode = cXmlBase.selectPreNodeByID(filePathTemple, itemInterval.sID);
                if (selectedNode != null) nTBXTopDepth.Text = selectedNode["bot"].InnerText;
            }
        }

        private void cbxGetNextDepthTop_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxGetNextDepthTop.Checked == true)
            {
                XmlNode selectNode = cXmlBase.selectNextNodeByID(filePathTemple, itemInterval.sID);
                if (selectNode != null) nTBXBotDepth.Text = selectNode["top"].InnerText;
            }
        }

           
    }
}
