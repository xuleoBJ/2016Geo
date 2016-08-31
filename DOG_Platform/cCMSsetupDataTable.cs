using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms; 

namespace DOGPlatform
{
    class cCMSsetupDataTable : cCMSsetupTreeNodeBase
    {
        public cCMSsetupDataTable(ContextMenuStrip _cms, TreeNode _tnSelected, string _sFileName)
            : base(_cms, _tnSelected, _sFileName)
        {

        }

        public void setupTsmiOpenNewWindow()
        {
            ToolStripMenuItem tsmiOpenedNewWin = new ToolStripMenuItem();
            tsmiOpenedNewWin.Text = "窗口打开";
            tsmiOpenedNewWin.Click += new System.EventHandler(tsmiOpenedNewWin_Click);
            cms.Items.Add(tsmiOpenedNewWin);
        }
        private void tsmiOpenedNewWin_Click(object sender, EventArgs e)
        {
              FormDataTable formDatatable = new FormDataTable(this.sFileName);
              formDatatable.Show();
        }

        public void setupTsmiDeleteFile()
        {
            ToolStripMenuItem tsmiDelete = new ToolStripMenuItem();
            tsmiDelete.Text = "删除";
            tsmiDelete.Click += new System.EventHandler(tsmiDelete_Click);
            cms.Items.Add(tsmiDelete);
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            string _filename = this.tnSelected.Text + ".txt";
            string svgfilepath = Path.Combine(cProjectManager.dirPathUsedProjectData, _filename);
            if (File.Exists(svgfilepath))
            {
                DialogResult dialogResult = MessageBox.Show(_filename + " 确认删除？", "删除文件", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    File.Delete(svgfilepath);
                    tnSelected.Remove();
                }
            }
        }
    }
}
