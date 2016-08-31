using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DOGPlatform.XML;
using System.Xml;


namespace DOGPlatform
{
    public partial class FormSectionDataLogComposition : Form
    {
        string sJH = "";
        string trackTypeStr;
        public List<string> ltWordRet = new List<string>();
        string filePathOper;
        string sTrackID;
        public FormSectionDataLogComposition(string _sJH, string _trackTypeStr, string _filePathOper, string _sTrackID) //测井数据加载
        {
            InitializeComponent();
            sJH = _sJH;
            trackTypeStr = _trackTypeStr.ToString();
            filePathOper = _filePathOper;
            sTrackID = _sTrackID;
            initializaForm();
        }
        void initializaForm()
        {
            dgvDataTable.Columns.Clear();
            dgvDataTable.Columns.Add("topDepth", "深度");
            dgvDataTable.Columns.Add("value", "曲线值");
            int iCount = dgvDataTable.ColumnCount;
            if (iCount > 0)
            {
                int jCount = ltWordRet.Count / iCount;
                for (int j = 0; j < jCount; j++) dgvDataTable.Rows.Add(ltWordRet.GetRange(j * iCount, iCount).ToArray());
            } 
        } 
        private void tsmiAddColum_Click(object sender, EventArgs e)
        {
            this.dgvDataTable.Columns.Add("Column", "数值");
        }

        private void tsmiDelColumn_Click(object sender, EventArgs e)
        {
            if (dgvDataTable.ColumnCount > 2)
                dgvDataTable.Columns.RemoveAt(dgvDataTable.ColumnCount - 1);
        }

        private void tsmiCilpCopy_Click(object sender, EventArgs e)
        {
            cPublicMethodForm.DataGridViewCellPaste(dgvDataTable);
        }

        private void tsmiDeleteCurrentLine_Click(object sender, EventArgs e)
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

        private void tsmiSelectAllAndCopy_Click(object sender, EventArgs e)
        {
            dgvDataTable.ClearSelection();
            for (int i = 0; i < dgvDataTable.Rows.Count; i++)
                for (int j = 0; j < dgvDataTable.Columns.Count; j++)
                    dgvDataTable.Rows[i].Cells[j].Selected = true;
            cPublicMethodForm.copyDGVselect2Clipboard(this.dgvDataTable);
        }

        private void tsmiDataImport_Click(object sender, EventArgs e)
        {
            //先写入测井头，再写入数据
            for (int i = dgvDataTable.ColumnCount-1; i > 0;i-- )
            {
                string sLogName = dgvDataTable.Rows[0].Cells[i].Value.ToString();
                ItemLogHeadInfor logHead = new ItemLogHeadInfor(this.sJH, sLogName);
                Random random = new Random();
                string sHexColor = cPublicMethodBase.HexConverter(Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255)));
                logHead.sFill = sHexColor;
                //此处写入配置文件xml,tn.name 是 id
                string sLogID = cXmlDocSectionWell.addLog(this.filePathOper, sTrackID, logHead);
                ltWordRet.Clear();
                for (int jLine = 1; jLine < dgvDataTable.RowCount - 1; jLine++)
                {
                    ltWordRet.Add(dgvDataTable.Rows[jLine].Cells[0].Value.ToString()); //加深度；
                    float fValue = 0;
                    for (int k = 1; k <= i; k++) //数值相加求和
                    {
                        float fCurCellValue = 0;
                        float.TryParse(dgvDataTable.Rows[jLine].Cells[k].Value.ToString(), out fCurCellValue);
                        fValue = fValue + fCurCellValue;
                    }
                    ltWordRet.Add(fValue.ToString());
                }
                cXmlDocSectionWell.updateTrackData(filePathOper, sLogID, string.Join(cProjectData.splitMark, ltWordRet));
            }
            //数据写人对应的道
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
