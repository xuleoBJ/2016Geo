using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
        

namespace DOGPlatform
{
    public partial class FormLogEditor : Form
    {
        private ScriptHost _host;

        string sJH = "";
        string filePathLogTemp = Path.Combine(cProjectManager.dirPathTemp, "tempLog.txt");

        public ScriptHost Host
        {
            get { return _host; }
        }

        public FormLogEditor(string _sJH)
            : this(new ScriptHost())
        {
            sJH = _sJH;
        }

        public FormLogEditor(ScriptHost host)
        {
            _host = host;
            InitializeComponent();
        }

        private void _miRunScript_Click(object sender, EventArgs e)
        {
            RunScript();
        }

        private void _miLoadScript_Click(object sender, EventArgs e)
        {
            LoadScript();
        }

        private void _miSaveScript_Click(object sender, EventArgs e)
        {
            SaveScript();
        }

        private void _miClearScript_Click(object sender, EventArgs e)
        {
            ClearOutput();
        }

        private void _miClearOutput_Click(object sender, EventArgs e)
        {
            ClearScript();
        }

        private void _btnRunScript_Click(object sender, EventArgs e)
        {
            RunScript();
        }

        private void ScriptEditor_Load(object sender, EventArgs e)
        {
            _host.RegisterVariable("scriptEditor", this);
        }

        public string Script
        {
            get
            {
                return this._scriptEditor.Text;
            }
            set
            {
                this._scriptEditor.Text = value;
            }
        }

        private void RunScript()
        {
            ClearOutput();
            string script = this.Script;
            _host.RegisterVariable("sProjectWellPath", cProjectManager.dirPathWellDir);
            _host.RegisterVariable("filePathLogTemp", filePathLogTemp);
            _host.RegisterVariable("sJH", this.sJH);
            var res = _host.Execute(script);
            _output.Text = _host.GetOutput();
            if (File.Exists(filePathLogTemp)) cPublicMethodForm.read2DataGridViewByTextFile(filePathLogTemp, this.dgvDataTable);
        }

        private void ClearOutput()
        {
            _output.Clear();
            _host.ClearOutput();
        }

        private void ClearScript()
        {
            _scriptEditor.Clear();
        }

        private void SaveScript()
        {
            if (_saveScriptDlg.ShowDialog() == DialogResult.OK)
            {
                string file = _saveScriptDlg.FileName;
                File.WriteAllText(file, _scriptEditor.Text);
            }
        }

        private void LoadScript()
        {
            if (_openScriptDlg.ShowDialog() == DialogResult.OK)
            {
                string file = _openScriptDlg.FileName;
                var lines = File.ReadAllLines(file);
                _scriptEditor.Lines = lines;
            }
        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {

            RunScript();
        }

        private void tsmiAdd2Project_Click(object sender, EventArgs e)
        {
            //把表格数据保存到temp文件夹中，测井数据格式
            FormInputBox inputBox = new FormInputBox("请输入系列名称：","新系列名称:");
            var result = inputBox.ShowDialog();
            if (result == DialogResult.OK)
            {
                foreach (string _sJH in cProjectData.ltStrProjectJH) { cIOinputLayerDepth.deleteFile(_sJH); }
                string sLogName = inputBox.ReturnValueStr;            //分层方案名 作为id 存values preserved after close
                string logFilePath = Path.Combine(cProjectManager.dirPathWellDir, sJH, sLogName + cProjectManager.fileExtensionWellLog);
                string filePathTemp = Path.Combine(cProjectManager.dirPathTemp, sJH + sLogName + cProjectManager.fileExtensionWellLog);
                string _firstLine = sJH + " " + sLogName + " source:" + " " + DateTime.Now.ToString();
                List<string> _ltLogFileHead = new List<string>();
                _ltLogFileHead.Add("Depth");
                _ltLogFileHead.Add(sLogName);
                cIOGeoEarthText.creatFileGeoHeadText(filePathTemp, _firstLine, _ltLogFileHead);
                List<string> ltLineWrited = cPublicMethodForm.readDataGridView2ListLine(dgvDataTable);
                cIOGeoEarthText.addDataLines2GeoEarTxt(filePathTemp, ltLineWrited);
                // 检查是否有同名的测井数据文件，如果有让用户确认是否覆盖，不存在的话直接
                bool bDelete = cIOinputLog.checkRenameSameFile(logFilePath);
                if (bDelete == true)
                {
                    File.Copy(filePathTemp, logFilePath, bDelete);
                    MessageBox.Show("导出完成。");
                }
            }
        }

        private void tsmiDelectSelected_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount = dgvDataTable.SelectedRows.Count;
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {
                    if (dgvDataTable.SelectedRows[0].Cells[0].Value != null)
                        dgvDataTable.Rows.RemoveAt(dgvDataTable.SelectedRows[0].Index);
                }
            }
        }

        
    }
}
