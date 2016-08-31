using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DOGPlatform
{
    public partial class colorTextBox : UserControl
    {
        public colorTextBox()
        {
            InitializeComponent();
            string sColor=tbxColor.Text ;
            if (sColor != string.Empty && cPublicMethodBase.isValidColor(sColor)) 
            {
             //tbxColor.BackColor=cPublicMethodBase.HexConverter(
            }
        }
    }
}
