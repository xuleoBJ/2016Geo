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
    public partial class FormExportLog : Form
    {
        public FormExportLog(List<string> _ltStrJH)
        {
            InitializeComponent();
            this.ltStrJH = _ltStrJH;
            initializeCotrols();
        }

        public List<string> ltStrJH { get; set; }
        void initializeCotrols()
        {
            updateSavePath("c:\\");
            cPublicMethodForm.inialListBox(this.lbxFullLogSeriers, cProjectData.ltStrProjectGlobeLog);
        }
   
        string m_filePathSaveDirection = "c:\\";
        void updateSavePath(string _filePath)
        {
            m_filePathSaveDirection = _filePath;
            this.tbxLogSavePath.Text = m_filePathSaveDirection;
        }

        private void logDirChoose_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog logDirSelect = new FolderBrowserDialog();
            logDirSelect.ShowNewFolderButton = true;
            logDirSelect.Description = "请选择选择测井文件存放路径： ";
            if (logDirSelect.ShowDialog() == DialogResult.OK)
            {
                updateSavePath(logDirSelect.SelectedPath);
            }
        }

        private void btn_addLog_Click(object sender, EventArgs e)
        {
            cPublicMethodForm.transferItemFromleftListBox2rightListBox(lbxFullLogSeriers, lbxLogSeriersSeclected);
        }

        private void btn_deleteLog_Click(object sender, EventArgs e)
        {
            cPublicMethodForm.deleteSlectedItemFromListBox(lbxLogSeriersSeclected);
        }

        private void btn_upLog_Click(object sender, EventArgs e)
        {
            cPublicMethodForm.upItemInListBox(lbxLogSeriersSeclected);
        }

        private void btn_downLog_Click(object sender, EventArgs e)
        {
            cPublicMethodForm.downItemInListBox(lbxLogSeriersSeclected);
        }      
    }
}
