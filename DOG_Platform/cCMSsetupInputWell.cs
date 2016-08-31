using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DOGPlatform
{
    class cCMSsetupInputWell : cCMSsetupBaseWell
    {
        ToolStripMenuItem tsmiImportWellInfor = new ToolStripMenuItem();
        ToolStripMenuItem tsmiDataView = new ToolStripMenuItem();
        ToolStripMenuItem tsmiImportDel = new ToolStripMenuItem();
        ToolStripMenuItem tsmiImportLog = new ToolStripMenuItem();
        ToolStripMenuItem tsmiImportInjectionProfile = new ToolStripMenuItem();
        ToolStripMenuItem tsmiImportData = new ToolStripMenuItem();
        ToolStripMenuItem tsmiDataImport = new ToolStripMenuItem();

        public cCMSsetupInputWell(ContextMenuStrip _cms, TreeNode _tnSelected, string _sJH)
            : base(_cms, _tnSelected, _sJH)
        {
            tsmiImportWellInfor.Text = "井信息";
            tsmiImportWellInfor.Click += new System.EventHandler(tsmiImportWellInfor_Click);
            tsmiDataView.Text = "查看井数据";
            tsmiDataView.Click += new System.EventHandler(tsmiDataView_Click);
            tsmiImportLog.Text = "曲线导入";
            tsmiImportLog.Click += new System.EventHandler(tsmiImportLog_Click);
            tsmiImportDel.Text = "删除井";
            tsmiImportDel.Click += new System.EventHandler(tsmiImportDel_Click);
            tsmiDataImport.Text = "导入井数据";
            tsmiDataImport.DropDownItems.Add(tsmiImportLog);
        }
        private void tsmiImportWellInfor_Click(object sender, EventArgs e)
        {
            FormWellInfor form = new FormWellInfor(this.sJH);
            form.ShowDialog();
        }
         private void tsmiDataView_Click(object sender, EventArgs e)
        {
            FormDataViewProjectSingleWell formDataView = new FormDataViewProjectSingleWell(this.sJH);
            formDataView.Show();
        }

        public void setupTsmi()
         {
             cms.Items.Add(tsmiImportWellInfor);
             cms.Items.Add(tsmiDataView);
             cms.Items.Add(tsmiDataImport);
             cms.Items.Add(tsmiImportDel);
        }


        private void tsmiImportLog_Click(object sender, EventArgs e)
        {
            FormDataImportLog frmImportLog = new FormDataImportLog(this.tnSelected.Text);
            frmImportLog.ShowDialog();
            TreeViewProjectData.setupTNwellChild(this.tnSelected);
            this.tnSelected.TreeView.Refresh();
        }

        private void tsmiImportDel_Click(object sender, EventArgs e)
        {
            cProjectManager.delWellFromProject(sJH);
            this.tnSelected.Remove();
        }



    }
}
