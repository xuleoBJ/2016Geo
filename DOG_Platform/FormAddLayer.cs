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
    public partial class FormAddLayer : Form
    {
        public string ReturnLayer { get; set; }
        public FormAddLayer()
        {
            InitializeComponent();
            initialForm();
        }
        void initialForm()
        {
            cbbSelectedXCM.DataSource = cProjectData.ltStrProjectXCM;
            ReturnLayer = cbbSelectedXCM.Items[0].ToString();
            btnOK.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;
        }
        private void cbbSelectedXCM_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReturnLayer = cbbSelectedXCM.SelectedItem.ToString();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }
       
    }
}
