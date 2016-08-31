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
    public partial class FormSectionCurveFill : Form
    {
        string xmlPath = "";
        string sIDtrack = "";
        List<itemLogHeadInforDraw> ltItemLogHeadInforDraw = new List<itemLogHeadInforDraw>();
        public FormSectionCurveFill(string _inputXmlPath, string _sIDtrack)
        {
            InitializeComponent();
            this.btnOK.DialogResult = DialogResult.OK;
            this.btnCancel.DialogResult = DialogResult.Cancel;
            this.xmlPath = _inputXmlPath;
            this.sIDtrack = _sIDtrack;
            InitFormControl();
        }

       

        void InitFormControl() 
        {
            if (sIDtrack != "" && File.Exists(xmlPath))  //在调用前外部加了保护和判断
            {
              //读取文件，获取测井曲线道头,初始化测井cbb
               ltItemLogHeadInforDraw = cXmlDocSectionWell.getTrackLogHeadList(xmlPath,sIDtrack);
                cbbLogSub.Items.Clear();
                cbbLogMain.Items.Clear();
               for (int i=0;i< ltItemLogHeadInforDraw.Count;i++) 
               {
                   this.cbbLogSub.Items.Add(ltItemLogHeadInforDraw[i].sLogName);
                   this.cbbLogMain.Items.Add(ltItemLogHeadInforDraw[i].sLogName);
                   ltItemLogHeadInforDraw[i].backItem=i;
               }
                //初始化listbox fillItem
               List<string> ltStrId = cXmlDocSectionWell.getTrackLogListIDFillItem(xmlPath, sIDtrack);
               foreach (string idStr in ltStrId) lbxFillItems.Items.Add(idStr);
               tbxIDTrackFill.Text = "填充方案" + (ltStrId.Count+1).ToString();
               this.nTBXBotDepth.Text = cXmlBase.getNodeInnerText(xmlPath, cXEWellPage.fullPathBotDepth);
            }
        }

        private void btn_addItem_Click(object sender, EventArgs e)
        {
            string sFillItem = tbxIDTrackFill.Text;
            lbxFillItems.Items.Add(sFillItem);
            lbxFillItems.SelectedIndex = lbxFillItems.Items.Count - 1;
        }

        private void btn_deleteItem_Click(object sender, EventArgs e)
        {
            cXmlDocSectionWell.deleteItemInTrackByID(this.xmlPath,  sIDtrack  , lbxFillItems.SelectedItem.ToString());
            cPublicMethodForm.deleteSlectedItemFromListBox(lbxFillItems);
        }

        private void btn_upItem_Click(object sender, EventArgs e)
        {
            cPublicMethodForm.upItemInListBox(lbxFillItems);
            cXmlDocSectionWell.upSelectFill(this.xmlPath, sIDtrack, lbxFillItems.SelectedItem.ToString());
        }

        private void btn_downItem_Click(object sender, EventArgs e)
        {
            cPublicMethodForm.downItemInListBox(lbxFillItems);
            cXmlDocSectionWell.downSelectFill(this.xmlPath, sIDtrack, lbxFillItems.SelectedItem.ToString());
        }


        void saveFillItem() 
        {

            if (cbbLogMain.SelectedIndex < 0 || this.lbxFillItems.SelectedIndex < 0) MessageBox.Show("填充方案和填充曲线不能空选。");
            else
            {
                string sIDfill = this.lbxFillItems.SelectedItem.ToString();
                int iMainLog = cbbLogMain.SelectedIndex;
                string sMainLogID = ltItemLogHeadInforDraw[iMainLog].sIDLog;
                string sFill = this.tbxFillColor.Text;
                string sTop = this.nTBXTopDepth.Text;
                string sBot = this.nTBXBotDepth.Text;
                float fCutoff = 0;
                float fFillOpacity = (float)nUDFillOpacity.Value;
                if (this.nTBXcutOffvalue.Text != "") fCutoff = float.Parse(this.nTBXcutOffvalue.Text);
                if (lbxFillItems.SelectedIndex >= 0 && cbbLogMain.SelectedIndex >= 0 && rdbSubLog.Checked == true)
                {
                    int isubLog = this.cbbLogSub.SelectedIndex;
                    string sSubLogID = ltItemLogHeadInforDraw[isubLog].sIDLog;
                    cXmlDocSectionWell.updateLogTrackFill(this.xmlPath, sIDtrack, sIDfill, (int)typeLogFillMode.log, sMainLogID, sSubLogID, -999, sFill, sTop, sBot, fFillOpacity);
                }

                else if (lbxFillItems.SelectedIndex >= 0 && cbbLogMain.SelectedIndex >= 0 && this.rdbCutOff.Checked == true)
                {
                    cXmlDocSectionWell.updateLogTrackFill(this.xmlPath, sIDtrack, sIDfill, (int)typeLogFillMode.cutoff, sMainLogID, "", fCutoff, sFill, sTop, sBot, fFillOpacity);
                }
            }
        }
        private void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            saveFillItem(); 
        }

        ColorDialog colorDialog1 = new ColorDialog();
        private void btnSeleclFillColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                string sHexColor = cPublicMethodBase.HexConverter(colorDialog1.Color);
                this.tbxFillColor.BackColor = colorDialog1.Color;
                this.tbxFillColor.Text = sHexColor;
            }
        }

        private void rdbCutOff_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbCutOff.Checked == true) { nTBXcutOffvalue.Enabled = true; cbbLogSub.Enabled = false; }
        }

        private void rdbSubLog_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbSubLog.Checked == true) { nTBXcutOffvalue.Enabled = false; cbbLogSub.Enabled = true; }
        }

        private void lbxFillItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxFillItems.SelectedIndex >= 0)
            {
                XmlNode xnFillItem = cXmlDocSectionWell.selectNodeInTrackByID(this.xmlPath, sIDtrack, lbxFillItems.SelectedItem.ToString());
                if (xnFillItem != null)
                {
                    itemDrawDataTrackFill itemFill = new itemDrawDataTrackFill(xnFillItem);
                    nTBXTopDepth.Text = itemFill.fTop.ToString();
                    nTBXBotDepth.Text = itemFill.fBot.ToString();
                    tbxFillColor.Text = itemFill.sFill;
                    var mainLog = ltItemLogHeadInforDraw.SingleOrDefault(p => p.sIDLog == itemFill.sIDmainLog);
                    if (mainLog != null) cbbLogMain.SelectedItem = mainLog.sLogName;
                    if (itemFill.iFillMode == 0)
                    {
                        this.rdbSubLog.Checked = true;
                        var subLog = ltItemLogHeadInforDraw.SingleOrDefault(p => p.sIDLog == itemFill.sIDsub);
                        if (subLog != null) this.cbbLogSub.SelectedItem = subLog.sLogName;
                    }
                    if (itemFill.iFillMode == 1) { rdbCutOff.Checked = true; this.nTBXcutOffvalue.Text = itemFill.fValueCutoff.ToString(); }
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            saveFillItem();
        }//end indexChange
    }
}
