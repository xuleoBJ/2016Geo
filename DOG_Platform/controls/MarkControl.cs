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
    public partial class MarkControl : UserControl
    {

		public MarkControl()
		{		
			InitializeComponent();
			this.BackColor = Color.Red;	
		}

		public Point Center
		{
			get{return new Point(Location.X+4,Location.Y+4);}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
		//
		}

    }
}
