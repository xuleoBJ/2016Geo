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
    public partial class FormSectionLogInforByDepth : Form
    {
        public FormSectionLogInforByDepth()
        {
            InitializeComponent();
        }
        public FormSectionLogInforByDepth(double fDepth)
        {
            InitializeComponent();
            initialForm(fDepth);
            this.Text = "深度 = "+fDepth.ToString("0.00");
        }
        void initialForm(double fDepth) 
        {
            for (int kk = 0; kk < makeSectionWell.ltTrackLog.Count; kk++)
            {
                trackDataListLog itemLog =makeSectionWell.ltTrackLog[kk];
                Label newLogInfor = new Label();
                newLogInfor.Text = itemLog.itemHeadInforDraw.sLogName;
                double fValue=-999;
                for (int i = 0; i < itemLog.fListMD.Count-1;i++ )
                {
                   if(itemLog.fListMD[i]<=fDepth && itemLog.fListMD[i+1]>=fDepth)
                   {
                       fValue=(float)itemLog.fListValue[i];
                       break;
                   }
                }
                newLogInfor.Text +=" = "+ fValue.ToString("0.00");
                newLogInfor.Location = new Point(10, 20*kk);
                newLogInfor.AutoSize = true;
                this.Controls.Add(newLogInfor);
            }
            this.Height = 50 + makeSectionWell.ltTrackLog.Count * 20;
        
        }
    }
}
