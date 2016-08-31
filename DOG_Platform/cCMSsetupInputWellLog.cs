using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DOGPlatform
{
    class cCMSsetupInputWellLog : cCMSsetupInputWell
    {
        public cCMSsetupInputWellLog(ContextMenuStrip _cms, TreeNode _tnSelected, string _sJH)
            : base(_cms, _tnSelected, _sJH)
        {
            
        }

        public void setupContextMenuStripWellLog()
        {
            setupTsmiExportSingleLog();
            setupTsmiDeleteLog();
        }


        public void setupTsmiExportSingleLog()
        {
            ToolStripMenuItem tsmiExportWellLog = new ToolStripMenuItem();
            tsmiExportWellLog.Text = "导出曲线";
            tsmiExportWellLog.Click += new System.EventHandler(tsmiExportWellLog_Click);
            cms.Items.Add(tsmiExportWellLog);
        }
        private void tsmiExportWellLog_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                cIOinputLog.exportTextLog(tnSelected.Parent.Text,saveFileDialog1.FileName);
                MessageBox.Show("导出曲线完成。");
            }
        }
        public void setupTsmiDeleteLog()
        {

            ToolStripMenuItem tsmiDeleteLogItem = new ToolStripMenuItem();
            tsmiDeleteLogItem.Text = "删除全部曲线";
            tsmiDeleteLogItem.Click += new System.EventHandler(tsmiDeleteLogItem_Click);
            cms.Items.Add(tsmiDeleteLogItem);
        }
        private void tsmiDeleteLogItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("注意：此操作不可恢复，确认删除本井全部曲线？", "提示", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string _wellDir = Path.Combine(cProjectManager.dirPathWellDir, sJH);
                foreach (string _item in Directory.GetFiles(_wellDir, "*" + cProjectManager.fileExtensionWellLog)) File.Delete(_item);
                this.tnSelected.Nodes.Clear();
            }

        }

          public void setupTsmiExportManyWellsLog()
        {
            ToolStripMenuItem tsmiExportBatchWellLog = new ToolStripMenuItem();
            tsmiExportBatchWellLog.Text = "导出多井曲线";
            tsmiExportBatchWellLog.Click += new System.EventHandler(tsmiExportBatchWellLog_Click);
            cms.Items.Add(tsmiExportBatchWellLog);
        }
          private void tsmiExportBatchWellLog_Click(object sender, EventArgs e)
          {
              DialogResult dialogResult = MessageBox.Show("请勾选所有需要导出的井号，勾选全局测井中需要导出的曲线 ", "批量导出曲线", MessageBoxButtons.YesNo);
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
