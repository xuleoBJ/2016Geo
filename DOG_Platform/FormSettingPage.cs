﻿using System;
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
    public partial class FormSettingPage : Form
    {
        string xmlPath = "";
        public FormSettingPage(string inputXmlPath)
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
            if (nUDPageHeight.Value <= 200) nUDPageHeight.Value  = (decimal) 1000.0;
            nUDPageWidth.Value = (decimal)curpage.PageWidth;
            nUDpageTopElevation.Value = (decimal)curpage.TopElevation;
            nUDFirstWellPosition.Value = (decimal)curpage.iPositionXFirstWell;
            this.cbxTrackRect.Checked = curpage.iShowTrackRect == 1 ? true : false;
            this.cbxTrackHeadRect.Checked = curpage.iShowTrackHeadRect == 1 ? true : false;
            this.cbxTitleRect.Checked = curpage.iShowTitleRect == 1 ? true : false;
            
        }

        private void nUDPageWidth_ValueChanged(object sender, EventArgs e)
        {
            cXmlBase.setNodeInnerText(xmlPath, cXEGeopage.xmlFullPathPageWidth, nUDPageWidth.Value.ToString("0"));
        }

        private void nUDPageHeight_ValueChanged(object sender, EventArgs e)
        {
            cXmlBase.setNodeInnerText(xmlPath, cXEGeopage.xmlFullPathPageHeight, nUDPageHeight.Value.ToString("0"));
        }
        private void nUMScaleVertical_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int iCheck = this.cbxTrackRect.Checked == true ? 1 : 0;
            cXmlBase.setNodeInnerText(xmlPath, cXEGeopage.xmlFullPathPageiShowTrackRect, iCheck.ToString());

            iCheck = this.cbxTrackHeadRect.Checked == true ? 1 : 0;
            cXmlBase.setNodeInnerText(xmlPath, cXEGeopage.xmlFullPathPageiShowTrackHeadRect, iCheck.ToString());

            iCheck = this.cbxTitleRect.Checked == true ? 1 : 0;
            cXmlBase.setNodeInnerText(xmlPath, cXEGeopage.xmlFullPathPageiShowTitleRect, iCheck.ToString());
        }
        private void nUDpageTopElevation_ValueChanged(object sender, EventArgs e)
        {
            cXmlBase.setNodeInnerText(xmlPath, cXEGeopage.xmlFullPathPageTopElevation, nUDpageTopElevation.Value.ToString("0"));
        }

        private void nUDFirstWellPosition_ValueChanged(object sender, EventArgs e)
        {
            cXmlBase.setNodeInnerText(xmlPath, cXEGeopage.xmlFullPathPageFirstWellXposition, nUDFirstWellPosition.Value.ToString("0"));
        }

      

       

             
    }
}
