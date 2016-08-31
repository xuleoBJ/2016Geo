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
    public partial class FormSectAddNewWell : Form
    {
        public string ReturnJH { get; set; } 
        public string ReturnFileNameXMT { get; set; }
        string sNullXMT = "New";
        public FormSectAddNewWell()
        {
            InitializeComponent();
            cPublicMethodForm.inialComboBox(cbbJH, cProjectData.ltStrProjectJH);
            cbbJH.Items.Insert(0,"New");
            ReturnFileNameXMT = "";
            List<string> ltFileNameXTM = cProjectManager.getTemplateFileNameList();
            ltFileNameXTM.Insert(0, sNullXMT);
            cPublicMethodForm.inialComboBox(this.cbbSelectWellTemplate,ltFileNameXTM);
            btnOK.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;
        }

        public FormSectAddNewWell(int i):this()
        {
            this.lblJH.Visible = false;
            this.cbbJH.Visible = false; //从主面板来。
            this.lblTemplate.Location = new Point(15, 30);
            this.cbbSelectWellTemplate.Location = new Point(50, 30);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.ReturnJH = this.cbbJH.SelectedItem.ToString();
            string strXMT=cbbSelectWellTemplate.SelectedItem.ToString();
            if (strXMT != sNullXMT)
                this.ReturnFileNameXMT = strXMT;
            else strXMT = "";
        }
    }
}
