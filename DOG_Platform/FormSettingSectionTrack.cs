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
    public partial class FormSettingSectionTrack : Form
    {
        string xmlPath = "";
        string sIDtrack = "";
        public FormSettingSectionTrack(string _inputXmlPath,string _sIDtrack)
        {
            InitializeComponent();
            this.btnOK.DialogResult = DialogResult.OK;
            this.btnCancel.DialogResult = DialogResult.Cancel;
            this.xmlPath = _inputXmlPath;
            this.sIDtrack = _sIDtrack;
            this.tbxTrackTitle.Text = cXEtrack.getTrackTitle(xmlPath, sIDtrack);
            this.cbxTextWriteMode.Checked =  cXEtrack.getTrackHeadTextWriteMode(xmlPath, sIDtrack)=="tb" ? true : false;
            nUDTrackWidth.Value = cXEtrack.getTrackWidth(xmlPath, sIDtrack);
            nUDTrackHeadFontSize.Value=cXEtrack.getTrackHeadFontSize(xmlPath, sIDtrack);
            this.nUDTrackTextFontSize.Value=cXEtrack.getTrackFontSize(xmlPath, sIDtrack);
            this.cbbAlign.SelectedIndex = 0;
        }

        private void nUDTrackWidth_ValueChanged(object sender, EventArgs e)
        {
            cXEtrack.setTrackWidth(xmlPath, sIDtrack, nUDTrackWidth.Value.ToString("0"));
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (tbxTrackTitle.Text != "") cXEtrack.setTrackTitle(xmlPath, sIDtrack, tbxTrackTitle.Text);
        }

        private void nUDTrackHeadFontSize_ValueChanged(object sender, EventArgs e)
        {
            cXEtrack.setTrackHeadFontSize(xmlPath, sIDtrack, nUDTrackHeadFontSize.Value.ToString("0"));
        }

        private void cbxTextVertical_CheckedChanged(object sender, EventArgs e)
        {
                string sWriteMode= cbxTextWriteMode.Checked == true?"tb":"lr";
                cXEtrack.setTrackHeadTextWriteMode(xmlPath, sIDtrack, sWriteMode);
        }

        private void nUDTrackTextFontSize_ValueChanged(object sender, EventArgs e)
        {
            cXEtrack.setTrackFontSize(xmlPath, sIDtrack, nUDTrackTextFontSize.Value.ToString("0"));
        }

        private void cbbAlign_SelectedIndexChanged(object sender, EventArgs e)
        {
            cXEtrack.setTrackFontAlignMode(xmlPath, sIDtrack, cbbAlign.SelectedIndex.ToString());
        }
    }
}
