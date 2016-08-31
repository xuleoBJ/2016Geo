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
    public partial class ctlLogInforStatistic : UserControl
    {
        public ctlLogInforStatistic()
        {
            InitializeComponent();
        }
        public void initialForm(List<double> listDouble)
        {
            if (listDouble.Count > 2)
            {
                this.lblDepthTop.Text = "顶深= " + listDouble[0].ToString("0.00");
                this.lblDepthBot.Text = "底深= " + listDouble.Last().ToString("0.00");
                this.lblInterval.Text = "采样间隔= " + (listDouble[1] - listDouble[0]).ToString("0.00");
            }
        }
    }
}
