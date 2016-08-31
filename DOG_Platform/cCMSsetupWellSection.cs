using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using System.Windows.Forms;
namespace DOGPlatform
{
    class cCMSsetupWellSection : cCMSsetupBaseWell
    {
        public delegate void WellSectionChange();
        public event WellSectionChange WellSectionChanged;

        public cCMSsetupWellSection(ContextMenuStrip _cms, TreeNode _tnSelected)
            : base(_cms, _tnSelected)
        {

        }
        public cCMSsetupWellSection(ContextMenuStrip _cms, TreeNode _tnSelected, string _sJH)
            : base(_cms, _tnSelected,_sJH)
        {
  
        }

        public cCMSsetupWellSection(ContextMenuStrip _cms, TreeNode _tnSelected, string _sJH,
            string _sLogName,string _srcDir)
            : base(_cms, _tnSelected, _sJH)
        {
            this.srcDir = _srcDir;
            this.sLogName = _sLogName;
        }
        public string sLogName { get; set; }
        public string srcDir { get; set; }

        public void setupTsmiLogDelete()
        {
            ToolStripMenuItem tsmiDeletLog = new ToolStripMenuItem();
            tsmiDeletLog.Text = "删除曲线";
            tsmiDeletLog.Click += new System.EventHandler(tsmiDeletLog_Click);
            cms.Items.Add(tsmiDeletLog);
        }
        private void tsmiDeletLog_Click(object sender, EventArgs e)
        {
            cIOWellSection.delLog(srcDir, sLogName);
            this.tnSelected.Remove(); 
        }

        public void setupTsmiLogSetting()
        {
            ToolStripMenuItem tsmiSetLog = new ToolStripMenuItem();
            tsmiSetLog.Text = "设置曲线";
            tsmiSetLog.Click += new System.EventHandler(tsmiSetLog_Click);
            cms.Items.Add(tsmiSetLog);
        }
        private void tsmiSetLog_Click(object sender, EventArgs e)
        {
            FormSectionLogChoose formLog = new FormSectionLogChoose(this.sJH);
            formLog.ShowDialog();
        }

        public void setupTsmiLogAdd()
        {
            ToolStripMenuItem tsmiAddLog = new ToolStripMenuItem();
            tsmiAddLog.Text = "增加曲线";
            tsmiAddLog.Click += new System.EventHandler(tsmiAddLog_Click);
            cms.Items.Add(tsmiAddLog);
        }
        private void tsmiAddLog_Click(object sender, EventArgs e)
        {
            FormAddSectionLog formLog = new FormAddSectionLog(this.sJH,this.tnSelected,this.srcDir);
            formLog.ShowDialog();
        }
        
     
    }
}
