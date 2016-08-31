using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DOGPlatform.XML;
using System.IO;

namespace DOGPlatform
{
    public partial class FormSectionAddImageItem : Form
    {
        string filePathTemple = "";
        string sIDTrack = "";
        string sJH = "";
        itemDrawDataIntervalValue item = new itemDrawDataIntervalValue();
        public FormSectionAddImageItem(string _filePathTemple, string _sIDTrack, double fTop, double fBot)
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
        }

        public FormSectionAddImageItem(string _filePathTemple, string _sIDTrack, string _sIDdataItem)
        {
            InitializeComponent();
            this.filePathTemple = _filePathTemple;
            this.sJH = cXmlDocSectionWell.getJH(filePathTemple);
            sIDTrack = _sIDTrack;
            item.sID = _sIDdataItem;
            item = cXmlDocSectionWell.getDataItemValueByID(filePathTemple, item.sID);
            this.nTBXTopDepth.Text = item.top.ToString();
            this.nTBXBotDepth.Text = item.bot.ToString();
            this.nUDWidthPercent .Value = (decimal)item.fValue;
            this.tbxImageFilePath.Text = item.sText;
            this.btnOK.DialogResult = DialogResult.OK;
            this.btnCancel.DialogResult = DialogResult.Cancel; 
          }

        private void btnSelectImage_Click(object sender, EventArgs e)
        {
           
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "\\\\";
            openFileDialog.Filter = "png文件|*.png|jpg文件|*.jpg|bmp文件|*.bmp|GIF文件|*.gif|所有文件|*.*";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                this.tbxImageFilePath.Text = openFileDialog.FileName;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string sJH = cXmlDocSectionWell.getNodeInnerText(filePathTemple, cXmlDocSectionWell.fullPathJH);
            string dirWell = Path.Combine(cProjectManager.dirPathWellDir, sJH);
            if (!Directory.Exists(dirWell)) Directory.CreateDirectory(dirWell);
            string filePathsour=this.tbxImageFilePath.Text;
            if (filePathsour != item.sText)  //图片换了再复制更新
            {
                string fileNameNew = cIDmake.generateID() + Path.GetExtension(filePathsour);
                if (File.Exists(filePathsour))
                {
                    File.Copy(filePathsour, Path.Combine(dirWell, Path.Combine(dirWell, fileNameNew)));
                }
                item.sText = filePathsour;
                item.sProperty = fileNameNew;
            }

            item.top = float.Parse(this.nTBXTopDepth.Text);
            item.bot = float.Parse(this.nTBXBotDepth.Text);
            item.calTVD(sJH);
            item.fValue = (float) nUDWidthPercent.Value;
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
