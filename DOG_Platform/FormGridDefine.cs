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
    public partial class FormGridDefine : Form
    {
        public FormGridDefine()
        {
            InitializeComponent();
        }

        private void btnSettingGrid_Click(object sender, EventArgs e)
        {
            cProjectData.projectMesh.dXstep =Convert.ToDouble( this.tbxXstepIncrement.Text);
            cProjectData.projectMesh.dYstep =Convert.ToDouble(this.tbxYstepIncrement.Text);
  
            double dXmax = 0.0;
            double dYmax = 0.0;
            if (cProjectData.ltProjectWell.Count > 0)
            {
                cProjectData.projectMesh.dXmin = cProjectData.ltProjectWell.Min(p => p.dbX);
                cProjectData.projectMesh.dYmin = cProjectData.ltProjectWell.Min(p => p.dbY);
                dXmax = cProjectData.ltProjectWell.Max(p => p.dbX);
                dYmax = cProjectData.ltProjectWell.Max(p => p.dbY);
                cProjectData.projectMesh.iXsize = Convert.ToInt16((dXmax - cProjectData.projectMesh.dXmin) / cProjectData.projectMesh.dXstep);
                cProjectData.projectMesh.iYsize = Convert.ToInt16((dYmax - cProjectData.projectMesh.dYmin) / cProjectData.projectMesh.dYstep);
            }
            
            

            this.Close();
        }


    }
}
