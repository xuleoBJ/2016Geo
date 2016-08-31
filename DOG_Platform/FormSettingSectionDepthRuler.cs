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
    public partial class FormSettingSectionDepthRuler : Form
    {
        string filePathTemple = "";
        string sTrackID = "";
        public FormSettingSectionDepthRuler(string _filePathTemple, string _sIDtrack)
        {
            InitializeComponent();
            this.filePathTemple = _filePathTemple;
            this.sTrackID = _sIDtrack;
            nUDmainTick.Value = decimal.Parse(cXmlBase.getSelectedNodeChildNodeValue(filePathTemple, sTrackID, "mainScale"));
            nUDminTick.Value = decimal.Parse(cXmlBase.getSelectedNodeChildNodeValue(filePathTemple, sTrackID, "minScale"));
            nUDTrackFontSize.Value=decimal.Parse(cXmlBase.getSelectedNodeChildNodeValue(filePathTemple, sTrackID, "fontSize"));
            cPublicMethodForm.inialComboBox(this.cbbRulerType, cProjectManager.ltStrRulerType);
            this.btnOK.DialogResult = DialogResult.OK;
            this.btnCancel.DialogResult = DialogResult.Cancel;
        }

        private void nUDTrackFontSize_ValueChanged(object sender, EventArgs e)
        {
            cXmlBase.setSelectedNodeChildNodeValue(filePathTemple, sTrackID, "fontSize", nUDTrackFontSize.Value.ToString("0"));
        }

        private void nUDMainTick_ValueChanged(object sender, EventArgs e)
        {
            cXmlBase.setSelectedNodeChildNodeValue(filePathTemple, sTrackID, "mainScale", nUDmainTick.Value.ToString("0"));
        }

        private void nUDminTick_ValueChanged(object sender, EventArgs e)
        {
            cXmlBase.setSelectedNodeChildNodeValue(filePathTemple, sTrackID, "minScale", nUDminTick.Value.ToString("0"));
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //单井海拔尺没有多少用处，还很麻烦。单井有垂深和测深就OK。
            int selectIndex=cbbRulerType.SelectedIndex ;
            if (selectIndex>= 0)
            {
                cXmlBase.setSelectedNodeChildNodeValue(filePathTemple, sTrackID, "iTypeRuler", cbbRulerType.SelectedIndex.ToString());
                string depthTrackTitle= cXEtrack.getTrackTitle(filePathTemple, sTrackID);
                if (selectIndex == 1) cXEtrack.setTrackTitle(filePathTemple, sTrackID, "垂深TVD");
                if (selectIndex == 0) cXEtrack.setTrackTitle(filePathTemple, sTrackID, "测深MD"); 
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
