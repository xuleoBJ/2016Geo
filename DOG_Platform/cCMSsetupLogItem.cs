using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DOGPlatform
{
    class cCMSsetupLogItem : cCMSsetupInputWellLog
    {       
        public cCMSsetupLogItem(ContextMenuStrip _cms, TreeNode _tnSelected, string _sJH)
            : base(_cms, _tnSelected, _sJH)
        {
            
        }

        public void setupLogItem()
        {
            ToolStripMenuItem tsmiSetting = new ToolStripMenuItem();
            tsmiSetting.Text = "数据";
            tsmiSetting.Click += new System.EventHandler(tsmiSetting_Click);
            cms.Items.Add(tsmiSetting);
            ToolStripMenuItem tsmiDelete = new ToolStripMenuItem();
            tsmiDelete.Text = "删除";
            tsmiDelete.Click += new System.EventHandler(tsmiDelete_Click);
            cms.Items.Add(tsmiDelete);
        }
        public void tsmiSetting_Click(object sender, EventArgs e)
        {
            string filePath=Path.Combine(cProjectManager.dirPathWellDir,sJH,tnSelected.Text+cProjectManager.fileExtensionWellLog);
            System.Diagnostics.Process.Start("notepad.exe", filePath);
         }
        public void tsmiDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("当前曲线：" + tnSelected.Text + "，确认删除？", "提示", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string filePath=Path.Combine(cProjectManager.dirPathWellDir,sJH, tnSelected.Text+cProjectManager.fileExtensionWellLog);
                File.Delete(filePath);
                    this.tnSelected.Remove();
            }

        }
    }
}
