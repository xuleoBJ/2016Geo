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
using System.IO;

namespace DOGPlatform
{
    public partial class FormSectionAddNewDataItem : Form
    {
        string filePathTemple = "";
        string sIDTrack = "";
        string strTrackType = "";
        string sJH = "";
        public FormSectionAddNewDataItem(string _filePathTemple, string _sIDTrack, string _typeTrackStr, double fTop, double fBot)
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
            strTrackType = _typeTrackStr;
            this.btnOK.DialogResult = DialogResult.OK;
            this.btnCancel.DialogResult = DialogResult.Cancel;

            initialForm(); 
        }

        void initialForm() 
        {
            if (strTrackType == TypeTrack.测井解释.ToString())
            {
                cbbDirType.Items.Add("解释结论");
                cbbDirType.SelectedIndex = 0;
                cPublicMethodForm.inialComboBox(this.cbbItemSelect, codeReplace.ltStrJSJL);
            }
            if (strTrackType == TypeTrack.沉积旋回.ToString())
            {
                cbbDirType.Items.Add("沉积旋回");
                cbbDirType.SelectedIndex = 0;
                cPublicMethodForm.inialComboBox(this.cbbItemSelect, codeReplace.ltStrGeoCycle);
            }
            if (strTrackType == TypeTrack.描述.ToString())
            {
                string dirName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "pattern", "描述");
                DirectoryInfo dirDescript = new DirectoryInfo(dirName);
                DirectoryInfo[] subDir = dirDescript.GetDirectories();
                foreach (DirectoryInfo item in subDir)
                    this.cbbDirType.Items.Add(item.Name);
                cbbDirType.SelectedIndex = 0;
            }
        }
          private void cbbDirType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (strTrackType == TypeTrack.描述.ToString())
            {
                string selectItemText= cbbDirType.SelectedItem.ToString();
                string selectSubDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "pattern", "描述", selectItemText);
                List<string> ltStrFossil = Directory.GetFiles(selectSubDir, "*.svg").Select(fileName => Path.GetFileNameWithoutExtension(fileName)).ToList();
                cPublicMethodForm.inialComboBox(this.cbbItemSelect, ltStrFossil);
            }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            ItemTrackDataIntervalProperty item = new ItemTrackDataIntervalProperty();
            item.top= float.Parse( this.nTBXTopDepth.Text);
            item.bot=float.Parse(this.nTBXBotDepth.Text);
            item.calTVD(sJH);
            item.sProperty=cbbItemSelect.SelectedItem.ToString();
            item.sText=this.cbbDirType .SelectedItem.ToString();
            if (strTrackType == TypeTrack.描述.ToString()) 
            {
                item.sProperty = this.cbbDirType.SelectedItem.ToString(); 
                item.sText = cbbItemSelect.SelectedItem.ToString();
            }
            if (item.bot > item.top)
            {
                cXmlDocSectionWell.addDataItemIntervalProperty(filePathTemple, sIDTrack, item);
                cXmlDocSectionWell.sortSelectTrackItem(filePathTemple, sIDTrack);
            }
            else 
            {
                MessageBox.Show("顶底深不正确。");
            }
        }

      
    }
}
