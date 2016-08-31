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
    public partial class FormSectionHorizonSetting : Form
    {
        
          string xmlPath = "";
          public FormSectionHorizonSetting(string inputXmlPath)
        {
            InitializeComponent();
            this.btnOK.DialogResult = DialogResult.OK; 
            this.btnCancel.DialogResult = DialogResult.Cancel;
            this.xmlPath = inputXmlPath;
        }
    }
}
