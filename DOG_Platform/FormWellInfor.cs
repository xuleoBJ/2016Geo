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
    public partial class FormWellInfor : Form
    {
        public FormWellInfor(string _sJH)
        {
            InitializeComponent();
            InitFormControl(_sJH);
        }
        string sJH="";
        void InitFormControl(string _sJH) 
        {
            this.sJH = _sJH;
           
            List<string> ltStrWellType = new List<string>();
            ltStrWellType.Add("(0)Undefined");
            ltStrWellType.Add("(1)Proposed");
            ltStrWellType.Add("(2)Dry");
            ltStrWellType.Add("(3)Oil");
            ltStrWellType.Add("(4)Minor Oil");
            ltStrWellType.Add("(5)Gas");
            ltStrWellType.Add("(6)Minor gas");
            ltStrWellType.Add("(7)Condensate");
            ltStrWellType.Add("(8)Platform");
            ltStrWellType.Add("(9)Abandoned oil and gas ");
            ltStrWellType.Add("(10)Abandoned oil Minor gas ");
            ltStrWellType.Add("(11)Abandoned oil Condensate ");
            ltStrWellType.Add("(12)Abandoned gas residual oil ");
            ltStrWellType.Add("(13)Abandoned gas condensate ");
            ltStrWellType.Add("(14)Abandoned minor oil and gas ");
            ltStrWellType.Add("(15)Inject water");
            ltStrWellType.Add("(16)Inject gas");
            ltStrWellType.Add("(17)Shallow boreHole");
            ltStrWellType.Add("(18)Drilling well");
            cPublicMethodForm.inialComboBox(cbbWellType, ltStrWellType);
            ItemWellHead itemnew = new ItemWellHead(sJH);
            this.tbxWellName.Text = sJH;
            this.tbxDX.Text = itemnew.dbX.ToString();
            this.tbxDY.Text = itemnew.dbY.ToString();
            this.tbxKB.Text = itemnew.fKB.ToString();
            this.cbbWellType.SelectedIndex = itemnew.iWellType;
            this.tbxWellBase.Text = itemnew.fWellBase.ToString();
        }

        private void btnAddWell_Click(object sender, EventArgs e)
        {
            ItemWellHead sttNewWell = new ItemWellHead();
            sttNewWell.sJH = tbxWellName.Text;
            sttNewWell.dbX = double.Parse(tbxDX.Text);
            sttNewWell.dbY = double.Parse(tbxDY.Text);
            sttNewWell.fKB = float.Parse(tbxKB.Text);
            sttNewWell.iWellType = cbbWellType.SelectedIndex;
            sttNewWell.fWellBase = float.Parse(tbxWellBase.Text);
            cProjectManager.updateWellInfor2Project(sttNewWell);
            this.Close();
        }

        private void tbxDX_TextChanged(object sender, EventArgs e)
        {
            cPublicMethodForm.inputTextBoxPositiveRealOnly(tbxDX);
        }

        private void tbxDY_TextChanged(object sender, EventArgs e)
        {
            cPublicMethodForm.inputTextBoxPositiveRealOnly(tbxDY);
        }

        private void tbxKB_TextChanged(object sender, EventArgs e)
        {
            cPublicMethodForm.inputTextBoxPositiveRealOnly(tbxKB);
        }
    }
}
