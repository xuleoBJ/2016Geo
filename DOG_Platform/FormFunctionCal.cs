using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

using IronPython.Hosting;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;
using System.IO;

namespace DOGPlatform
{
    public partial class FormFunctionCal : Form
    {
        private int[] m_FunPx;
        public FormFunctionCal()
        {
            InitializeComponent();
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            PlotFunction();
        }
        private void PlotFunction()
        {
            try
            {
                dynamic calc = CreatePyCalculator();
                AddToHistoryList();
                CalculateFunValues(calc);
                panelPlot.Refresh();
            }
            catch (PythonException ex)
            {
                MessageBox.Show(ex.Message, @"Python error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculateFunValues(dynamic calc)
        {

            // calculate x and y scales
            int scaleX = (int)Math.Pow(2, trackBarX.Value);
            labelScaleX.Text = @"1:" + scaleX;
            double x0 = -scaleX;
            double xn = scaleX;

            int scaleY = (int)Math.Pow(2, trackBarY.Value);
            labelScaleY.Text = @"1:" + scaleY;
            double y0 = -scaleY;
            double yn = scaleY;


            int xLen = panelPlot.Size.Width;
            int yLen = panelPlot.Size.Height;


            //calculate function values
            m_FunPx = new int[xLen];

            progressBarCalc.Visible = true;
            progressBarCalc.Maximum = xLen;
            progressBarCalc.Value = 0;

            double x;
            for (int px = 0; px < xLen; px++)
            {
                x = px * (xn - x0) / xLen + x0;
                try
                {
                    double expr = calc.expr(x);
                    m_FunPx[px] = (int)(yLen * (expr - yn) / (y0 - yn));
                }
                catch (Exception ex)
                {
                    if (ex is DivideByZeroException || ex is ArgumentException)
                    {
                        m_FunPx[px] = -10; //below display area
                    }
                    else
                    {
                        throw new PythonException(ex);
                    }
                }
                progressBarCalc.Value = px;
            }
            progressBarCalc.Visible = false;
        }
        internal class PythonException : Exception
        {
            public PythonException(Exception ex)
                : base(ex.Message, ex)
            {
            }
        }
        private dynamic CreatePyCalculator()
        {
            try
            {
                // Build the python script as a string
                var statements = new StringBuilder();
                statements.AppendLine(@"import math");
                statements.AppendLine(@"from math import *");
                // Include all costatnt parameters
                statements.AppendLine(textBoxParameters.Text);

                // Define python Calculator class
                statements.AppendLine(@"class Calculator:");
                // Define python expresion as function of x
                statements.AppendLine(@"   def expr(self, x):");
                statements.AppendLine(@"      return " + textBoxFunction.Text);

                // Convert the text into python source code
                ScriptEngine engine = Python.CreateEngine();
                engine.CreateScriptSourceFromString(statements.ToString(), SourceCodeKind.Statements);

                // Execute the python source
                dynamic pyScope = engine.CreateScope();
                engine.Execute(statements.ToString(), pyScope);

                // Create instance of python Calculator class
                dynamic calc = pyScope.Calculator();
                return calc;

            }
            catch (Exception ex)
            {
                throw new PythonException(ex);
            }
        }

        private void AddToHistoryList()
        {
            if (listBoxHistory.FindStringExact(textBoxFunction.Text) < 0)
            {
                listBoxHistory.Items.Add(textBoxFunction.Text);
            }

            SaveToFile();
        }
        private void SaveToFile()
        {
            var items = new string[listBoxHistory.Items.Count];
            for (int i = 0; i < listBoxHistory.Items.Count; i++)
            {
                items[i] = listBoxHistory.Items[i].ToString();
            }
            File.WriteAllLines("Functions.txt", items);
            File.WriteAllText("Parameters.txt", textBoxParameters.Text);
        }

        private void listBoxHistory_DoubleClick(object sender, EventArgs e)
        {
            if (listBoxHistory.SelectedItem != null)
            {
                textBoxFunction.Text = listBoxHistory.SelectedItem.ToString();
            }
        }

        private void trackBarY_ValueChanged(object sender, EventArgs e)
        {
            PlotFunction();
        }

        private void trackBarX_ValueChanged(object sender, EventArgs e)
        {
            PlotFunction();
        }

        private void LoadFromFile()
        {
            try
            {
                var items = File.ReadAllLines("Functions.txt");

                listBoxHistory.Items.Clear();
                foreach (string item in items)
                {
                    listBoxHistory.Items.Add(item);
                }

                if (listBoxHistory.Items.Count > 0)
                {
                    textBoxFunction.Text = listBoxHistory.Items[listBoxHistory.Items.Count - 1].ToString();
                }
                textBoxParameters.Text = File.ReadAllText("Parameters.txt");
            }
            catch (FileNotFoundException)
            {
                //ignore
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (listBoxHistory.SelectedIndex >= 0)
            {
                listBoxHistory.Items.RemoveAt(listBoxHistory.SelectedIndex);
            }

            SaveToFile();
        }

        private void buttonDeleteAll_Click(object sender, EventArgs e)
        {
            listBoxHistory.Items.Clear();

            SaveToFile();
        }

        private void buttonUse_Click(object sender, EventArgs e)
        {
            if (listBoxHistory.SelectedItem != null)
            {
                textBoxFunction.Text = listBoxHistory.SelectedItem.ToString();
            }
        }
        private void panelPlot_Paint(object sender, PaintEventArgs e)
        {
            const int numLines = 8;

            Panel p = (Panel)sender;

            Graphics g = e.Graphics;

            using (var penLi = new Pen(Color.Gray))
            {
                penLi.DashStyle = DashStyle.Dot;
                //lines

                for (int i = 0; i < numLines; i++)
                {
                    int x = i * p.Width / numLines;
                    g.DrawLine(penLi, x, 0, x, p.Height);
                    int y = i * p.Height / numLines;
                    g.DrawLine(penLi, 0, y, p.Width, y);
                }
            }

            //axes           
            using (var penAx = new Pen(Color.Black))
            using (var font = new Font("Arial", 12, FontStyle.Bold))
            using (var brush = new SolidBrush(Color.Black))
            {
                //OX
                g.DrawLine(penAx, 0, p.Height / 2, p.Width, p.Height / 2);
                g.DrawString("X", font, brush, p.Width - 20, p.Height / 2 + 5);
                //OY
                g.DrawLine(penAx, p.Width / 2, 0, p.Width / 2, p.Height);
                g.DrawString("Y", font, brush, p.Width / 2 - 20, 5);
                //(0,0) point
                g.DrawString("0", font, brush, p.Width / 2 - 20, p.Height / 2 + 5);

            }

            if (m_FunPx == null)
                return;

            //ploting funtion points
            using (var penPlot = new Pen(Color.Blue))
            {
                for (int px = 0; px < m_FunPx.Length; px++)
                {
                    g.DrawEllipse(penPlot, px, m_FunPx[px], 2, 2);
                }
            }
        }

        private void FormFunctionCal_Load(object sender, EventArgs e)
        {
            LoadFromFile();
        }
    }
}
