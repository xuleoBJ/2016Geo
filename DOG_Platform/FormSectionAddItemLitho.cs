using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DOGPlatform.XML;
using System.Xml.Linq;
using System.Xml;

namespace DOGPlatform
{
    public partial class FormSectionAddItemLitho : Form
    { 
        // id 是否为 "" 是判断更新还是增加的标致
        string filePathTemple = "";
        string sIDTrack = "";
        string sJH = "";
        itemDrawDataIntervalValue item = new itemDrawDataIntervalValue();
        public FormSectionAddItemLitho(string _filePathTemple, string _sID, string _typeTrackStr, double fTop, double fBot)
        {
            InitializeComponent();

            this.filePathTemple = _filePathTemple;
            this.sJH = cXmlDocSectionWell.getJH(filePathTemple);
            if (fTop > fBot)
            {
                double fMiddle = fTop;
                fTop = fBot;
                fBot = fMiddle;
            }
            this.nTBXTopDepth.Text = fTop.ToString("0.00");
            this.nTBXBotDepth.Text = fBot.ToString("0.00");
            this.sIDTrack = _sID;
            this.btnOK.DialogResult = DialogResult.OK;
            this.btnCancel.DialogResult = DialogResult.Cancel;

            if (_typeTrackStr == TypeTrack.岩性层段.ToString())
            {
                lblProperty.Text = "岩性";
                List<string> ltColor = cProjectManager.dicColor.Keys.ToList();
                cPublicMethodForm.inialComboBox(this.cbbColor, ltColor);
                List<string> ltStrRockType = cProjectManager.ltCodeItem.Select(p => p.codeType).Distinct().ToList();
                cPublicMethodForm.inialComboBox(this.cbbType, ltStrRockType);
                initialCbbRock(cbbType.Items[0].ToString());
                this.nUDGrainSize.Value = 1.00M;
            }
        }

        public FormSectionAddItemLitho(string _filePathTemple, string _sIDTrack, string _sIDdataItem )
        {
            InitializeComponent();
            this.filePathTemple = _filePathTemple;
            this.sJH = cXmlDocSectionWell.getJH(filePathTemple);
            sIDTrack = _sIDTrack;
            item.sID = _sIDdataItem;
            itemDrawDataIntervalValue curItem = cXmlDocSectionWell.getDataItemValueByID(filePathTemple, item.sID);
            this.nTBXTopDepth.Text = curItem.top.ToString();
            this.nTBXBotDepth.Text = curItem.bot.ToString();
            List<string> ltColor = cProjectManager.dicColor.Keys.ToList();
            cPublicMethodForm.inialComboBox(this.cbbColor, ltColor);
            string sHexColor = curItem.sProperty;
            cbbColor.Items.Insert(0, sHexColor);
            cbbColor.SelectedIndex = 0;
            string sLithoName = curItem.sText;
            ItemCode inputCode = cProjectManager.ltCodeItem.FirstOrDefault(p => p.chineseName == sLithoName);
            List<string> ltStrRockType = cProjectManager.ltCodeItem.Select(p => p.codeType).Distinct().ToList();
            cPublicMethodForm.inialComboBox(this.cbbType, ltStrRockType);
            if (inputCode != null)
            {
                cbbType.SelectedItem = inputCode.codeType;
                initialCbbRock(inputCode.codeType);
                cbbItemLitho.SelectedItem = inputCode.chineseName;
            }

            this.filePathTemple = _filePathTemple;

            nUDGrainSize.Value=(decimal)curItem.fValue;
            this.btnOK.DialogResult = DialogResult.OK;
            this.btnCancel.DialogResult = DialogResult.Cancel; 
        }

        void initialCbbRock(string sType)
        {
            List<string> ltStrRock = cProjectManager.ltCodeItem.Where(p => p.codeType == sType).Select(p => p.chineseName).ToList();
                cPublicMethodForm.inialComboBox(this.cbbItemLitho, ltStrRock);
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            item.top = float.Parse(this.nTBXTopDepth.Text);
            item.bot = float.Parse(this.nTBXBotDepth.Text);
            item.calTVD(sJH);
            item.sText = cbbItemLitho.SelectedItem.ToString();
            item.sProperty = cbbColor.SelectedItem.ToString();
            item.fValue= (double)nUDGrainSize.Value;
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
                   cXmlDocSectionWell.setDataItemIntervalValue(filePathTemple,item);
                }
            }
            else
            {
                MessageBox.Show("顶底深不正确。");
            }
        }

        ColorDialog colorDialog1 = new ColorDialog();
        private void btnColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                string sHexColor = cPublicMethodBase.HexConverter(colorDialog1.Color);
                cbbColor.Items.Insert(0, sHexColor);
                cbbColor.SelectedIndex = 0;
            }
        }

        private void cbbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sType = cbbType.SelectedItem.ToString();
            initialCbbRock(sType);
        }

        private void cbbItemLitho_SelectedIndexChanged(object sender, EventArgs e)
        {
              ItemCode inputCode = cProjectManager.ltCodeItem.FirstOrDefault(p => p.chineseName == cbbItemLitho.SelectedItem.ToString());
              this.nUDGrainSize.Value =(decimal) inputCode.scale; 
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

      }
}
