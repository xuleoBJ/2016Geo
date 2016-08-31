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
    public partial class FormWellJobBat : Form
    {
        public FormWellJobBat()
        {
            InitializeComponent();
            setupTNwell2TV(this.tvProjectData);
        }

        public static void setupTNwell2TV(TreeView _tv)
        {
            _tv.Nodes.Clear();
            TreeNode tnWells = new TreeNode();
            tnWells.Name = TypeGeoFile.projectDir.ToString();
            tnWells.Text = "工区";
            tnWells.Tag = TypeGeoFile.projectDir;
            foreach (string sJH in cProjectData.ltStrProjectJH)
            {
                TreeNode tnJH = new TreeNode(sJH, 0, 1);
                tnJH.Name = sJH;
                tnJH.Tag = TypeGeoFile.well;
                tnWells.Nodes.Add(tnJH);
            }
            _tv.Nodes.Add(tnWells);
        }
    }
}
