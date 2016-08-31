using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace DOGPlatform
{
    class cCMSsetupSVGGraph : cCMSsetupTreeNodeBase
    {
        public cCMSsetupSVGGraph(ContextMenuStrip _cms, TreeNode _tnSelected, string _sFileName)
            : base(_cms, _tnSelected, _sFileName)
        {

        }

        public void setupTsmiRename()
        {
            ToolStripMenuItem tsmiRename = new ToolStripMenuItem();
            tsmiRename.Text = "重命名";
            tsmiRename.Click += new System.EventHandler(tsmiRename_Click);
            cms.Items.Add(tsmiRename);
        }

        private void tsmiRename_Click(object sender, EventArgs e)
        {
            if (!this.tnSelected.IsEditing)
            {
                tnSelected.BeginEdit();
            } 
        }
        public void setupTsmiOpenInInkscape()
        {
            ToolStripMenuItem tsmiImportOpenedInkscaple = new ToolStripMenuItem();
            tsmiImportOpenedInkscaple.Text = "编辑";
            tsmiImportOpenedInkscaple.Click += new System.EventHandler(tsmiImportOpenedInkscaple_Click);
            cms.Items.Add(tsmiImportOpenedInkscaple);
        }
        private void tsmiImportOpenedInkscaple_Click(object sender, EventArgs e)
        {
            string svgfilepath = Path.Combine(cProjectManager.dirPathMap, this.sFileName);
            cCallInkscape.callInk(svgfilepath);
        }

        public void setupTsmiOpenIE()
        {
            ToolStripMenuItem tsmiOpenedIE = new ToolStripMenuItem();
            tsmiOpenedIE.Text = "窗口打开";
            tsmiOpenedIE.Click += new System.EventHandler(tsmiOpenedIE_Click);
            cms.Items.Add(tsmiOpenedIE);
        }
        private void tsmiOpenedIE_Click(object sender, EventArgs e)
        {
            string svgfilepath = Path.Combine(cProjectManager.dirPathMap, this.sFileName);
            FormWebNavigation formSVGView = new FormWebNavigation(svgfilepath);
            formSVGView.Show();
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
            string _filename=this.tnSelected.Text+".svg";
            string svgfilepath = Path.Combine(cProjectManager.dirPathMap,_filename ); 
            if (File.Exists(svgfilepath))
            {
                DialogResult dialogResult = MessageBox.Show(_filename+" 确认删除？", "删除文件", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    File.Delete(svgfilepath);
                     
                    string _fileXML=svgfilepath.Replace(".svg",".xml");
                    if (File.Exists(_fileXML)) File.Delete(_fileXML);
                    tnSelected.Remove();
                }
            }
        }

    }
}
