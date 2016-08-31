using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DOGPlatform.XML;

using System.Drawing.Drawing2D;

using IronPython.Hosting;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;
using System.IO;

namespace DOGPlatform
{
    public partial class FormMakeNewLog : Form
    {
        string filePathOper;
        float fTop = 0;
        float fBot = 0;
        string sJH = "";
        trackDataListLog curLog=new trackDataListLog();
        trackDataListLog newLog = new trackDataListLog();

        public FormMakeNewLog(string _filePathOper, float _fTop, float _fBot)
        {
            InitializeComponent();
            filePathOper = _filePathOper;
            fTop = _fTop;
            fBot = _fBot;
            sJH = cXmlBase.getNodeInnerText(filePathOper, cXmlDocSectionWell.fullPathJH);
            this.nTBXtop.Text = fTop.ToString();
            this.nTBXbot.Text = fBot.ToString();
            initialCbbLog();
        }

        void initialCbbLog()
        {
            this.cbbLog.Items.Clear();
            string _wellDir = Path.Combine(cProjectManager.dirPathWellDir, sJH);
            string[] wellLogItems = Directory.GetFiles(_wellDir, "*" + cProjectManager.fileExtensionWellLog);
            foreach (string strItem in wellLogItems)
            {
                string logName = Path.GetFileNameWithoutExtension(strItem);
                cbbLog.Items.Add(logName);
            }
            if (cbbLog.Items.Count > 0) cbbLog.SelectedIndex = 0;
        }
        public FormMakeNewLog()
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
                outPutCalValue();
            }
            catch (PythonException ex)
            {
                MessageBox.Show(ex.Message, @"Python error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void outPutCalValue()
        {
            for (int i = 0; i < newLog.fListMD.Count(); i++)
            {
                if (i < curLog.fListMD.Count)
                {
                    dgvDataTable.Rows[i].Cells[2].Value = newLog.fListMD[i].ToString();
                    dgvDataTable.Rows[i].Cells[3].Value = newLog.fListValue[i].ToString("0.000");
                }
            }
        }
        private void CalculateFunValues(dynamic calc)
        {
            int xLen = curLog.fListMD.Count;
            //calculate function values
            progressBarCalc.Visible = true;
            progressBarCalc.Maximum = xLen;
            progressBarCalc.Value = 0;

            double x;
            newLog.clearList();
            for (int i = 0; i < xLen; i++)
            {
                newLog.fListMD.Add(curLog.fListMD[i]);
                x = curLog.fListValue[i];
                try
                {
                    double expr = calc.expr(x);
                    newLog.fListValue.Add(expr);
                }
                catch (Exception ex)
                {
                    if (ex is DivideByZeroException || ex is ArgumentException)
                    {
                        newLog.fListValue.Add(-999);  //below display area
                    }
                    else
                    {
                        throw new PythonException(ex);
                    }
                }
                progressBarCalc.Value = i;
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
        private dynamic CreatePyCalculator2()
        {
            //创建读入测井数据的python类
            //根据井号和测井名称，实例化数据
            //按表达式计算
            //写入表格。
            //保存数据库或者显示的算法可以交由表格 控制。
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
            string sFuncName=tbxFunctionName.Text ;
            if (sFuncName != "")
            {
                ListViewItem lvItem = new ListViewItem("常用");
                lvItem.SubItems.Add(sFuncName);
                lvItem.SubItems.Add(textBoxFunction.Text);
                lvItem.SubItems.Add(this.textBoxParameters.Text);
                lvHistory.Items.Add(lvItem);
                SaveToFile();
            }
        }
        private void SaveToFile()
        {
            //var items = new string[listBoxHistory.Items.Count];
            //for (int i = 0; i < listBoxHistory.Items.Count; i++)
            //{
            //    items[i] = listBoxHistory.Items[i].ToString();
            //}
            //File.WriteAllLines("Functions.txt", items);
            File.WriteAllText("Parameters.txt", textBoxParameters.Text);
        }
       

        private void LoadFromFile()
        {
            try
            {
                var items = File.ReadAllLines("Functions.txt");

                //listBoxHistory.Items.Clear();
                //foreach (string item in items)
                //{
                //    listBoxHistory.Items.Add(item);
                //}

                //if (listBoxHistory.Items.Count > 0)
                //{
                //    textBoxFunction.Text = listBoxHistory.Items[listBoxHistory.Items.Count - 1].ToString();
                //}
                textBoxParameters.Text = File.ReadAllText("Parameters.txt");
            }
            catch (FileNotFoundException)
            {
                //ignore
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (lvHistory.Items.Count == 0) return;
            if (lvHistory.SelectedItems.Count > 0)
            {
                lvHistory.SelectedItems[0].Remove();
                SaveToFile();
            }
        }

        private void buttonUse_Click(object sender, EventArgs e)
        {
            if (lvHistory.SelectedItems.Count > 0)
            {
                tbxFunctionName.Text = lvHistory.SelectedItems[1].Text;
                textBoxFunction.Text = lvHistory.SelectedItems[0].SubItems[2].Text;
                textBoxParameters.Text = lvHistory.SelectedItems[0].SubItems[3].Text;
            }
        }

        private void FormMakeNewLog_Load(object sender, EventArgs e)
        {
            LoadFromFile();
        }

        private void btnSelectLog_Click(object sender, EventArgs e)
        {
            fTop = float.Parse(this.nTBXtop.Text);
            fBot = float.Parse(this.nTBXbot.Text);
            if (this.cbbLog.SelectedIndex >= 0)
            {
                string sLogX = cbbLog.SelectedItem.ToString();
                if (sLogX != null) this.curLog = cIOinputLog.getLogSeriersFromSectionWellFromLogFile(sJH, sLogX, fTop, fBot);
            }

            dgvDataTable.Columns.Clear();
            foreach (string headText in new List<string> { "深度", curLog.itemHeadInforDraw.sLogName,"深度","新曲线" })
            {
                DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                col.HeaderText = headText;
                dgvDataTable.Columns.Add(col);
            }

            int iLineMax = curLog.fListMD.Count;

            for (int i = 0; i < iLineMax; i++)
            {
                this.dgvDataTable.Rows.Add();
                if (i < curLog.fListMD.Count)
                {
                    dgvDataTable.Rows[i].Cells[0].Value = curLog.fListMD[i].ToString();
                    dgvDataTable.Rows[i].Cells[1].Value = curLog.fListValue[i].ToString();
                }
            }
        }
    }
}
