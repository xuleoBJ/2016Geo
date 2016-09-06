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
    public partial class FormSettingShowState : Form
    {
        string xmlPath = "";
        public FormSettingShowState(string inputXmlPath)
        {
            InitializeComponent();
            this.btnOK.DialogResult = DialogResult.OK; 
            this.btnCancel.DialogResult = DialogResult.Cancel;
            this.xmlPath = inputXmlPath;
            tbxTitle.Text = cXmlBase.getNodeInnerText(xmlPath, cXEWellPage.fullPathMapTitle);
            nUDShowedBottom.Value = decimal.Parse(cXmlBase.getNodeInnerText(xmlPath, cXEWellPage.fullPathBotDepth));
            nUDPageWidth.Value = decimal.Parse(cXmlBase.getNodeInnerText(xmlPath, cXEWellPage.fullPathPageWidth));
            nUDPageHeight.Value = decimal.Parse(cXmlBase.getNodeInnerText(xmlPath, cXEWellPage.fullPathPageHeight));
            nUDMapTitleHeight.Value = decimal.Parse(cXmlBase.getNodeInnerText(xmlPath, cXEWellPage.fullPathMapTitleRectHeight));
            nUDTrackHeadHeight.Value = decimal.Parse(cXmlBase.getNodeInnerText(xmlPath, cXEWellPage.fullPathTrackRectHeight));
        }

        private void nUDShowedBottom_ValueChanged(object sender, EventArgs e)
        {
            cXmlBase.setNodeInnerText(xmlPath, cXEWellPage.fullPathBotDepth, nUDShowedBottom.Value.ToString("0"));
            decimal fVScale = decimal.Parse(cXmlBase.getNodeInnerText(xmlPath, cXEWellPage.fullPathVSacle));
            cXmlBase.setNodeInnerText(xmlPath, cXEWellPage.fullPathPageHeight, (nUDShowedBottom.Value * fVScale+50).ToString("0"));
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(tbxTitle.Text!="")
                cXmlBase.setNodeInnerText(xmlPath, cXEWellPage.fullPathMapTitle, tbxTitle.Text);
        }

        private void nUDPageWidth_ValueChanged(object sender, EventArgs e)
        {
            cXmlBase.setNodeInnerText(xmlPath, cXEWellPage.fullPathPageWidth, nUDPageWidth.Value.ToString("0"));
        }

        private void nUDPageHeight_ValueChanged(object sender, EventArgs e)
        {
            cXmlBase.setNodeInnerText(xmlPath, cXEWellPage.fullPathPageHeight, nUDPageHeight.Value.ToString("0"));
        }

        private void nUDTrackHeadHeight_ValueChanged(object sender, EventArgs e)
        {
            cXmlBase.setNodeInnerText(xmlPath, cXEWellPage.fullPathTrackRectHeight, nUDTrackHeadHeight.Value.ToString("0"));
        }

        private void nUDMapTitleHeight_ValueChanged(object sender, EventArgs e)
        {
            cXmlBase.setNodeInnerText(xmlPath, cXEWellPage.fullPathMapTitleRectHeight, nUDMapTitleHeight.Value.ToString("0"));
        }

        private void nUDTrackHeadFontSize_ValueChanged(object sender, EventArgs e)
        {
            foreach (XmlElement el_Track in cXmlDocSectionWell.getTrackNodes(xmlPath))
            {
                trackDataDraw curTrackDraw = new trackDataDraw(el_Track);
                string sIDtrack = curTrackDraw.sTrackID;  //结点name
                cXmlBase.setSelectedNodeChildNodeValue(xmlPath, sIDtrack, "trackHeadFontSize", nUDTrackHeadFontSize.Value.ToString("0"));
            }
        }
   }
}
