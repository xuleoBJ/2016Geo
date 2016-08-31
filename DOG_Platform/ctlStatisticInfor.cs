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
     
    public partial class ctlStatisticInfor : UserControl
    {
        
        public ctlStatisticInfor()
        {
            InitializeComponent();
        }
        public void initialForm(List<double> listDouble)
        {
            statistics sta = new statistics(listDouble.ToArray());
            lblMean.Text = "均值= " +sta.mean().ToString("0.0");
            lblValueMax.Text ="最大值= "+ sta.max().ToString("0.0");
            lblValueMin.Text = "最小值= " + sta.min().ToString("0.0");
            this.lblDataNum.Text = "数据个数= " + sta.length().ToString("0");
            this.lblSum.Text = "总和= " + listDouble.Sum().ToString("0.0");
            this.lblQ2.Text = "Q2= " + sta.Q2().ToString("0.0");
            this.lblVariance.Text = "方差= " + sta.var().ToString("0.0");
            
        }
    }
}
