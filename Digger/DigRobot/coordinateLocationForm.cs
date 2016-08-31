using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DigRobot;


namespace DigRobot
{
    public partial class coordinateLocationForm : Form
    {
        
        public coordinateLocationForm()
        {
            InitializeComponent();
            MyInitial();
        }

         void MyInitial()
        {
            tbxScreenPositionX.Text = cRef3Points.tempPointScreen.X.ToString();
            tbxScreenPositionY.Text = cRef3Points.tempPointScreen.Y.ToString();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            if (tbxRealPositionX.Text != "" && tbxRealPositionX.Text != "")
            {

                cRef3Points.tempPointReal.X = float.Parse(tbxRealPositionX.Text);
                cRef3Points.tempPointReal.Y = float.Parse(tbxRealPositionY.Text);
            }
            else 
            {
                MessageBox.Show("文本框数据有问题");
            }


        }



    }
}
