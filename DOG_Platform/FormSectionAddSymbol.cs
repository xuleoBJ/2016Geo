using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DOGPlatform.XML;
using System.Xml;

namespace DOGPlatform
{
    public partial class FormSectionAddSymbol : Form
    {
        string filePathTemple = "";
        string sIDTrack = "";
        string sJH = "";
        itemDrawDataIntervalValue item = new itemDrawDataIntervalValue();
        public FormSectionAddSymbol(string _filePathTemple, string _sIDTrack, double fTop, double fBot)
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
            this.sIDTrack = _sIDTrack;
            this.btnOK.DialogResult = DialogResult.OK;
            this.btnCancel.DialogResult = DialogResult.Cancel;

            initialCbb(); 
        }

        void initialCbb() 
        {

            string dirName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "pattern", "符号");
            string filePathCodeOrder = Path.Combine(dirName, "codeOrder.txt");
            if (File.Exists(filePathCodeOrder)) 
            {
                using (StreamReader sr = new StreamReader(filePathCodeOrder,System.Text.Encoding.UTF8))
                {
                    String line;
                    while ((line = sr.ReadLine()) != null) //delete the line whose legth is 0
                    {
                        string[] split = line.Trim().Split();
                        if (split.Length>2) this.cbbType.Items.Add(split[1]);
                    }
                }
            }
            else
            {
                string[] fileItems = Directory.GetFiles(dirName, "*.svg");
                foreach (string itemFile in fileItems) this.cbbType.Items.Add(Path.GetFileNameWithoutExtension(itemFile));
            }
            if (cbbType.Items.Count > 0) cbbType.SelectedIndex = 0; 
        }

        public FormSectionAddSymbol(string _filePathTemple, string _sIDTrack, string _sIDdataItem)
        {
            InitializeComponent();
            this.filePathTemple = _filePathTemple;
            this.sJH = cXmlDocSectionWell.getJH(filePathTemple);
            sIDTrack = _sIDTrack;
            item.sID = _sIDdataItem;
            item = cXmlDocSectionWell.getDataItemValueByID(filePathTemple, item.sID);
            this.nTBXTopDepth.Text = item.top.ToString();
            this.nTBXBotDepth.Text = item.bot.ToString();
            initialCbb();

            cbbType.SelectedItem = item.sProperty;
            this.tbxBackText.Text = item.sText;
            this.btnOK.DialogResult = DialogResult.OK;
            this.btnCancel.DialogResult = DialogResult.Cancel; 
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            item.top = float.Parse(this.nTBXTopDepth.Text);
            item.bot = float.Parse(this.nTBXBotDepth.Text);
            item.calTVD(sJH);
            item.sProperty = this.cbbType.SelectedItem.ToString();
            item.sText = this.tbxBackText.Text; 
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
    }
}
