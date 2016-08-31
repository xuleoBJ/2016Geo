using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DOGPlatform.controls
{
    class NumericTextBox : TextBox
    {
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            // Check if the pressed character was a backspace or numeric.
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
        }

        public double doubleText() 
        {
            if (this.Text != "")
                return double.Parse(this.Text);
            else return 0;
        }

        
    }
}
