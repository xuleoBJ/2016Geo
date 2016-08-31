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
    public partial class FormSettingSectionLayer : Form
    {
        ColorDialog colorDialog1 = new ColorDialog();
        string filePathTemple = "";
        List<string> listLayerColor = cfilePathProject.getProjectLayerColor();
        string sIDTrack = "";
        string sJH = "";
        itemDrawDataIntervalValue item = new itemDrawDataIntervalValue();
        public FormSettingSectionLayer(string _filePathTemple, string _sIDTrack, string _sIDdataItem)
        {
            InitializeComponent();
            this.filePathTemple = _filePathTemple;
            this.sJH = cXmlDocSectionWell.getJH(filePathTemple);
            sIDTrack = _sIDTrack;
            item.sID = _sIDdataItem;
            item = cXmlDocSectionWell.getDataItemValueByID(filePathTemple, item.sID);
            if (item != null)
            {
                int iFindIndexLayer = cProjectData.ltStrProjectXCM.IndexOf(item.sProperty);
                if (iFindIndexLayer >= 0)
                {
                    this.tbxLayerColor.BackColor = System.Drawing.ColorTranslator.FromHtml(listLayerColor[iFindIndexLayer]);
                    this.tbxLayerColor.Text = listLayerColor[iFindIndexLayer];
                }
            }
            cbbConformity.Items.Add(TypeConformity.顶不整合.ToString());
            cbbConformity.Items.Add(TypeConformity.整合.ToString());
            cbbConformity.Items.Add(TypeConformity.底不整合.ToString());
            cbbConformity.Items.Add(TypeConformity.顶底不整合.ToString());
            cbbConformity.SelectedIndex = (int)item.fValue;
            this.btnOK.DialogResult = DialogResult.OK;
            this.btnCancel.DialogResult = DialogResult.Cancel;
            this.nTBXTopDepth.Text = item.top.ToString();
            this.nTBXBotDepth.Text = item.bot.ToString();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            cfilePathProject.setProjectLayerColor(listLayerColor);
            item.top = float.Parse(this.nTBXTopDepth.Text);
            item.bot = float.Parse(this.nTBXBotDepth.Text);
            item.calTVD(sJH);
            item.fValue = cbbConformity.SelectedIndex;
            if (item.bot > item.top)
            {
                //查找是否存在，存在更改，不存在再添加 
                if (item.sID == "")
                {
                    cXmlDocSectionWell.addDataItemIntervalValue(filePathTemple, sIDTrack, item);
                    cXmlDocSectionWell.sortSelectTrackItem(filePathTemple, sIDTrack);
                }
                else
                {
                    cXmlDocSectionWell.setDataItemIntervalValue(filePathTemple, item);
                }
            }
            else
            {
                MessageBox.Show("顶底深不正确。");
            }
        }

        private void btnSeleclFillColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                string sHexColor = cPublicMethodBase.HexConverter(colorDialog1.Color);
                this.tbxLayerColor.BackColor = colorDialog1.Color;
                this.tbxLayerColor.Text = sHexColor;
                //根据id找到item 
                if (item != null)
                {
                    int iFindIndexLayer = cProjectData.ltStrProjectXCM.IndexOf(item.sProperty);
                    if(iFindIndexLayer>=0) listLayerColor[iFindIndexLayer] = sHexColor;
                }
            }
        }

        private void cbxGetLastDepthBot_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxGetLastDepthBot.Checked == true)
            {
                XmlNode selectedNode = cXmlBase.selectPreNodeByID(filePathTemple, item.sID);
                if (selectedNode != null) nTBXTopDepth.Text = selectedNode["bot"].InnerText;
            }
        }

        private void cbxGetNextDepthTop_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxGetNextDepthTop.Checked == true)
            {
                XmlNode selectNode = cXmlBase.selectNextNodeByID(filePathTemple, item.sID);
                if (selectNode != null) nTBXBotDepth.Text = selectNode["top"].InnerText;
            }
        }

        private void cbxUnconformity_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
