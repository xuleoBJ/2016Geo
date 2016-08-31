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
    public partial class FormInputBox : Form
    {
        public string ReturnValueStr { get; set; } 
        public FormInputBox(string title,string promptText)
        {
            InitializeComponent();
            this.Text = title;
            lblPrompt.Text = promptText;
            btnOK.DialogResult = DialogResult.OK;
            btnCancel.DialogResult=DialogResult.Cancel;
        }

        public FormInputBox(string title,string promptText,string inputText):this(title,promptText)
        {
            this.tbxInput.Text = inputText;
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.ReturnValueStr = this.tbxInput.Text;
        }

        private void tbxInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOK.PerformClick();
            }
        }

        private void FormInputBox_ClientSizeChanged(object sender, EventArgs e)
        {
            this.tbxInput.Width = this.Width - 20;
        }
    }
}
