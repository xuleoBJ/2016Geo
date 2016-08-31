using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace DOGPlatform
{
    class cCMSsetupTreeNodeBase
    {
        public ContextMenuStrip cms { get; set; }
       
        public cCMSsetupTreeNodeBase(ContextMenuStrip _cms)
        {
            this.cms = _cms;
        }

        public cCMSsetupTreeNodeBase(ContextMenuStrip _cms, TreeNode _tnSelected, string _sFileName):this(_cms)
        {
            this.sFileName = _sFileName;
            this.tnSelected = _tnSelected;
        }
        public TreeNode tnSelected { get; set; }
        public string sFileName { get; set; }
    }
}
