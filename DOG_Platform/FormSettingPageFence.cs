using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DOGPlatform.XML;

namespace DOGPlatform
{
    public partial class FormSettingPageFence : Form
    {
        string xmlPath = "";
        public FormSettingPageFence(string inputXmlPath)
        {
            InitializeComponent();
            this.btnOK.DialogResult = DialogResult.OK;
            this.btnCancel.DialogResult = DialogResult.Cancel;
            this.xmlPath = inputXmlPath;
            InitForm();
        }
        //初始化Form页面
        private void InitForm()
        {
            cXEGeopage curpage = new cXEGeopage(xmlPath);
            nUDPageHeight.Value = (decimal)curpage.PageHeight;
            if (nUDPageHeight.Value <= 200) nUDPageHeight.Value = (decimal)1000.0;
            nUDPageWidth.Value = (decimal)curpage.PageWidth;
            this.cbxTrackRect.Checked = curpage.iShowTrackRect == 1 ? true : false;
            this.cbxTrackHeadRect.Checked = curpage.iShowTrackHeadRect == 1 ? true : false;
            this.cbxTitleRect.Checked = curpage.iShowTitleRect == 1 ? true : false;

        }
        public FormSettingPageFence()
        {
            InitializeComponent();
        }
    }
}
