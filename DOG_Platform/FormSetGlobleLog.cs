using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DOGPlatform
{
    public partial class FormSetGlobleLog : Form
    {
        List<ItemDicLogGlobe> logHeadRet = cIODicLogHeadProject.readDicGlobeLog();
        string sIDlogInpuput = "";
        public FormSetGlobleLog(string _sIDlogInput)
        {
            InitializeComponent();
            sIDlogInpuput = _sIDlogInput;
            initialForm();
        }

        void initialForm()
        {
            this.btnOK.DialogResult = DialogResult.OK;
            this.btnCancel.DialogResult = DialogResult.Cancel;
            this.tbxLogname.Text  = sIDlogInpuput;
            ItemDicLogGlobe item = logHeadRet.FirstOrDefault(p => p.sLogID == sIDlogInpuput);
            if (item == null) 
            {
                item = new ItemDicLogGlobe(sIDlogInpuput);
                logHeadRet.Add(item); 
            }

            this.tbxLogSunit.Text = item.sUnit;
            this.tbxLogColor.Text = item.sLogColor;
            this.nUDLineWidth.Value = (decimal)item.fLineWidth;
            this.cbbLineType.SelectedIndex = item.iLineType;
            this.cbxLog.Checked = (item.iIsLog > 0) ? true : false;
            this.nTBXleftValue.Text = item.fLeftValue.ToString();
            this.nTBXrightValue.Text = item.fRightValue.ToString(); 
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ItemDicLogGlobe item = logHeadRet.FirstOrDefault(p => p.sLogID == sIDlogInpuput);
            if (item != null)
            {
                item.sUnit = this.tbxLogSunit.Text;
                item.sLogColor = this.tbxLogColor.Text;
                item.fLineWidth = (float)this.nUDLineWidth.Value;
                item.iLineType = this.cbbLineType.SelectedIndex;
                item.iIsLog = this.cbxLog.Checked == true ? 1 : 0;
                item.fLeftValue = float.Parse(this.nTBXleftValue.Text);
                item.fRightValue = float.Parse(nTBXrightValue.Text);
                cIODicLogHeadProject.writeDicGlobe(logHeadRet);
            }
        }

        ColorDialog colorDialog1 = new ColorDialog();
        private void btnColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                string sHexColor = cPublicMethodBase.HexConverter(colorDialog1.Color);
                this.tbxLogColor.BackColor = colorDialog1.Color;
                this.tbxLogColor.Text = sHexColor;
            }
        }


    }
}
