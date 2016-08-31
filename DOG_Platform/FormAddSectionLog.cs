using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DOGPlatform
{   
    //仅仅提供参数返回，不操作读写。
    public partial class FormAddSectionLog : Form
    {
        public FormAddSectionLog(string _sJH, TreeNode _tnNode, string _dirDataDrawing)
        {
            InitializeComponent();
            this.sJH = _sJH;
            this.tnNode = _tnNode;
            this.dirDataDrawing = _dirDataDrawing;
            initializeControls();
        }
        void initializeControls()
        {
            this.tbxJH.Text = sJH;
            string _wellDir = Path.Combine(cProjectManager.dirPathWellDir, sJH);
            List<string> ltStrLogName = new List<string>();
            foreach (string _item in Directory.GetFiles(_wellDir, "*" + cProjectManager.fileExtensionWellLog)) ltStrLogName.Add(Path.GetFileNameWithoutExtension(_item));
            cbbLog.DataSource = ltStrLogName;
        }
        public string sJH { get; set; }
        public TreeNode tnNode { get; set; }
        public string dirDataDrawing { get; set; }
        private void btnAddLog_Click(object sender, EventArgs e)
        {
            string sLogName = cbbLog.SelectedItem.ToString();
            string sLogColor = cPublicMethodBase.getRGB(cbbLogColor.BackColor);
            float fRightValue = Convert.ToSingle(nUDLogRightValue.Value);
            float fLeftValue = Convert.ToSingle(nUDLogLeftValue.Value);
            string filePath = Path.Combine(dirDataDrawing, sLogName + ".txt");
            cIOWellSection.addLog(sJH, sLogName, filePath);
            cIOWellSection.addLogProperty(sLogName, sLogColor, fLeftValue, fRightValue, 0);
            tnNode.Nodes.Add(sLogName);
            this.Close();
        }

        private void cbbLogColor_Click(object sender, EventArgs e)
        {
            cPublicMethodForm.setComboBoxBackColorByColorDialog(cbbLogColor);
        }
    }
}
