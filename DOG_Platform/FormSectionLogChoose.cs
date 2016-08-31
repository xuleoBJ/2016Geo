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
    public partial class FormSectionLogChoose : Form
    {
        public FormSectionLogChoose(string _sJH)
        {
            InitializeComponent();
            this.sJH = _sJH;
            initializeControls();
        }
        void initializeControls() 
        {
            this.tbxJH.Text = sJH;
            cPublicMethodForm.inialComboBox(cbbLog,cProjectData.ltStrProjectGlobeLog );
        }
        public string sJH { get; set; }
    }
}
