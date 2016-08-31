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
    public partial class FormDataImportLayer : Form
    {
        public FormDataImportLayer()
        {
            InitializeComponent();
            initializeForm();
        }
        DataGridView dgvCurrent;
        string filePathGoal = "";

        void initializeForm()
        {
            dgvCurrent = this.dgvLayerDepth;
            if (cProjectData.ltStrProjectJH.Count > 0)
            {
                foreach (string item in cProjectData.ltStrProjectJH) cbbJH.Items.Add(item);
                cbbJH.SelectedIndex = 0;
            }
            filePathGoal = Path.Combine(cProjectManager.dirPathWellDir, this.cbbJH.SelectedItem.ToString(), cProjectManager.fileNameInputWellPath);
            cPublicMethodForm.read2DataGridViewByTextFile(filePathGoal, dgvCurrent);
        }

        private void tsmiPaste_Click(object sender, EventArgs e)
        {
            cPublicMethodForm.DataGridViewCellPaste(dgvCurrent);
        }

        bool dataImported()
        {
            List<string> lt_dgvStrLine = cPublicMethodForm.readDataGridView2ListLine(dgvCurrent);
            List<string> _ltXCM = cPublicMethodForm.getDataGridViewColumn(dgvCurrent, 0).Distinct().ToList();
            List<string> _ltXCMnotINproject = new List<string>();

            foreach (string _xcm in _ltXCM)
            {
                if (cProjectData.ltStrProjectXCM.IndexOf(_xcm) >= 0)
                {
                    List<string> _listLines = cIOBase.getListStrFromStringListByFirstWord(lt_dgvStrLine, _xcm);
                }
                else _ltXCMnotINproject.Add(_xcm);
            }
            if (_ltXCMnotINproject.Count > 0) MessageBox.Show(string.Join("\t", _ltXCMnotINproject) + "缺失小层信息，请重新加载。");
            return true;

        }
        private void tsmiDataImport_Click(object sender, EventArgs e)
        {
            bool isFull = true;
            for (int j = 0; j < dgvCurrent.RowCount - 1; j++)
            {
                for (int i = 0; i < dgvCurrent.ColumnCount; i++)
                {
                    if (dgvCurrent.Rows[j].Cells[i].Value == null)
                    {
                        MessageBox.Show("表格:行" + (j + 1).ToString() + "列" + (i + 1).ToString() + " 数据缺失");
                        isFull = false;
                        break;
                    }
                }
                if (isFull == false) break;
            }
            if (isFull)
            {
                DialogResult dialogResult = MessageBox.Show("确认数据入库？", "数据导入", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    if (dataImported() == true) MessageBox.Show("数据导入成功");
                    else MessageBox.Show("数据有误");
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        private void tsmiOpenFile_Click(object sender, EventArgs e)
        {
            cPublicMethodForm.read2DataGridViewByTextFile(dgvLayerDepth);
        }

        private void tsmiDeleteCurrentLine_Click(object sender, EventArgs e)
        {
            //int index = dgvDataTable.CurrentCell.RowIndex;
            //dgvDataTable.Rows.RemoveAt(index);
        }
    }
}
