using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DOGPlatform
{
    class cCMSsetupInputWellsManager : cCMSsetupBaseWell
    {
        public cCMSsetupInputWellsManager(ContextMenuStrip _cms, TreeNode _tnSelected)
            : base(_cms)
        {
             this.tnSelected = _tnSelected;
        }
 
        public void setupContextMenuWellMangager()
        {
            setupTsmiExportData();
          
        }
        private void tsmiManager_Click(object sender, EventArgs e)
        {
            FormWellManager formDataInput = new FormWellManager();
            formDataInput.ShowDialog();
        }
      

        public void setupTsmiExportData()
        {
            ToolStripMenuItem tsmiExportAllWells = new ToolStripMenuItem();
            tsmiExportAllWells.Text = "导出数据";
            cms.Items.Add(tsmiExportAllWells);
        }
        private void tsmiExportLog_Click(object sender, EventArgs e)
        {
            List<string> ltStrSelectJH = new List<string>();
            foreach (TreeNode tn in tnSelected.Nodes)
            {
                if (tn.Checked == true)
                {
                    ltStrSelectJH.Add(tn.Text);
                }
            }
            FormExportLog formExportlog = new FormExportLog(ltStrSelectJH);
            formExportlog.ShowDialog();
        }

        public void setupTsmiExportManyWellsLog()
        {
            ToolStripMenuItem tsmiExportBatchWellLog = new ToolStripMenuItem();
            tsmiExportBatchWellLog.Text = "导出多井曲线";
            tsmiExportBatchWellLog.Click += new System.EventHandler(tsmiExportBatchWellLog_Click);
            cms.Items.Add(tsmiExportBatchWellLog);
        }
        private void tsmiExportBatchWellLog_Click(object sender, EventArgs e)
        {DialogResult dialogResult = MessageBox.Show("请勾选所有需要导出的井号，勾选全局测井中需要导出的曲线 ", "批量导出曲线", MessageBoxButtons.YesNo);
        if (dialogResult == DialogResult.Yes)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowDialog();
            FormMain.ltSelectedLongName_tvProject.Insert(0, "DEPTH");
            foreach (string _sJH in FormMain.ltSelectedJH_tvProject)
            {
                string _saveLogFilePath = Path.Combine(folderDlg.SelectedPath, _sJH + ".txt");
                cIOinputLog.selectLogSeriresFromProjectWellLog(_sJH, FormMain.ltSelectedLongName_tvProject, _saveLogFilePath);
                MessageBox.Show(_sJH + "导出完成。");
            }
        }

        }
    }
}
