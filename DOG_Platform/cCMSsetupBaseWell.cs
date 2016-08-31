using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DOGPlatform
{
    class cCMSsetupBaseWell
    {
        public ContextMenuStrip cms { get; set; }
       
        public cCMSsetupBaseWell(ContextMenuStrip _cms)
        {
            this.cms = _cms;
        }

        public cCMSsetupBaseWell(ContextMenuStrip _cms, TreeNode _tnSelected)
            : this(_cms)
        {
            this.tnSelected = _tnSelected;
        }

        public cCMSsetupBaseWell(ContextMenuStrip _cms, TreeNode _tnSelected, string _sJH):this(_cms)
        {
            this.sJH = _sJH;
            this.tnSelected = _tnSelected;
        }
        public TreeNode tnSelected { get; set; }
        public string sJH { get; set; }
 
    }
}
