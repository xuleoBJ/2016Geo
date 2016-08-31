using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DOGPlatform.XML;

namespace DOGPlatform
{
    public partial class FormProjectInfor : Form
    {
       
        public FormProjectInfor()
        {
            InitializeComponent();
            tbxProjectPath.Text = cProjectManager.dirProject;
            cPublicMethodForm.inialComboBox(this.cbbUnit, cProjectManager.ltStrMapSunit);
            cbbUnit.SelectedItem = cProjectData.projectUnit;
            tbxAuthor.Text = cXmlBase.getNodeInnerText(cProjectManager.filePathProject, cfilePathProject.projectAuthor);
            this.tbxProjectComment.Text = cXmlBase.getNodeInnerText(cProjectManager.filePathProject, cfilePathProject.projectComment);
            cXmlBase.addNodeIfNull(cProjectManager.filePathProject, cfilePathProject.projectArea);
            cXmlBase.addNodeIfNull(cProjectManager.filePathProject, cfilePathProject.projectBlock);

            this.tbxProjectAera.Text = cXmlBase.getNodeInnerText(cProjectManager.filePathProject, cfilePathProject.projectArea);
            this.tbxProjectBlock.Text = cXmlBase.getNodeInnerText(cProjectManager.filePathProject, cfilePathProject.projectBlock); 
            this.btnOK.DialogResult = DialogResult.OK;
            this.btnCancel.DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            cProjectData.projectUnit = cbbUnit.SelectedItem.ToString();
            cXmlBase.setNodeInnerText(cProjectManager.filePathProject, cfilePathProject.projectAuthor, tbxAuthor.Text);
            cXmlBase.setNodeInnerText(cProjectManager.filePathProject, cfilePathProject.projectComment, this.tbxProjectComment.Text);
            cXmlBase.setNodeInnerText(cProjectManager.filePathProject, cfilePathProject.projectArea, this.tbxProjectAera.Text);
            cXmlBase.setNodeInnerText(cProjectManager.filePathProject, cfilePathProject.projectBlock, this.tbxProjectBlock.Text);
        }
    }
}
