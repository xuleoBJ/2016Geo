using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;
using DOGPlatform.XML;
using System.Xml;
using DOGPlatform.SVG;

namespace DOGPlatform
{
    public partial class FormSectionDataLog : Form
    {
        string sJH = "";
        string trackTypeStr;
        public List<string> ltWordRet = new List<string>();
        string sLogName;
        string filePathOper;
        string sLogID;

        public FormSectionDataLog()
        {
            InitializeComponent();
        }
        public FormSectionDataLog(string _sJH, string _sLogName, string _trackTypeStr, string _filePathOper, string _sLogID) //测井数据加载
        {
            InitializeComponent();
            sJH = _sJH;
            trackTypeStr = _trackTypeStr.ToString();
            filePathOper = _filePathOper;
            sLogID = _sLogID;
            sLogName = _sLogName;
            initializaForm();
        }
        void initializaForm()
        {
            trackDataListLog dlTrackDataListLog = cSVGSectionTrackLog.getLogSeriersFromLogFile(sJH, sLogName);
            if (trackTypeStr == TypeTrack.曲线道.ToString())
            {
                dgvDataTable.Columns.Clear();
                dgvDataTable.Columns.Add("topDepth", "深度");
                dgvDataTable.Columns.Add("value", "数值");
                dgvDataTable.Rows.Add(dlTrackDataListLog.fListMD.Count);
            }
            int iCount = dgvDataTable.ColumnCount;
            for (int i = 0; i < dlTrackDataListLog.fListMD.Count;i++ )
            {
                dgvDataTable.Rows[i].Cells[0].Value = dlTrackDataListLog.fListMD[i].ToString("0.00");
                dgvDataTable.Rows[i].Cells[1].Value = dlTrackDataListLog.fListValue[i].ToString("0.00");
            }
        } 
        private void tsmiCilpCopy_Click(object sender, EventArgs e)
        {
            cPublicMethodForm.DataGridViewCellPaste(dgvDataTable);
        }

        private void tsmiFromDB_Click(object sender, EventArgs e)
        {
            List<string> listStrLine = new List<string>();
            if (trackTypeStr == TypeTrack.曲线道.ToString())
            {
                cIOinputLog cSelect = new cIOinputLog();
                //根据井号和测井选曲线
                listStrLine = cSelect.selectSectionDrawData2List(sJH, sLogName);
            }
            cPublicMethodForm.read2DataGridViewByListStrLine(listStrLine, this.dgvDataTable);
        }


        private void tsmiDataImport_Click(object sender, EventArgs e)
        {
            //把表格数据保存到temp文件夹中，测井数据格式
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
                makeSectionWell.deleteWellLogList(sJH, sLogName, makeSectionWell.ltTrackLog);
                makeSectionWell.updateWellLogfile2List(sJH, makeSectionWell.ltTrackLog);
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        List<double> getListDataFromDgvByColomnIndex(DataGridView dgv, int iColumnIndex) 
        {

            List<double> ltDouble = new List<double>();
            for (int j = 0; j < dgv.RowCount - 1; j++)
            {
                var curValue = dgv.Rows[j].Cells[iColumnIndex].Value;
                if (curValue != null) ltDouble.Add(double.Parse(curValue.ToString())); 
            }
           return ltDouble; 
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbcLogDeal.SelectedTab == this.tbgStatics) 
            {
              //读取第二列
                if (dgvDataTable.Rows.Count > 1)
                {
                    List<double> ltValue = getListDataFromDgvByColomnIndex(this.dgvDataTable, 1);
                    this.ctlStatisticInfor1.initialForm(ltValue);
                    List<double> ltDepth = getListDataFromDgvByColomnIndex(this.dgvDataTable, 0);
                    this.ctlLogInforStatistic1.initialForm(ltDepth);

                    nTBXleftValue.Text = ltValue.Min().ToString();
                    nTBXrightValue.Text = ltValue.Max().ToString();
                    updateFrequencyHistogram(ltValue);
                }
            }
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

        void updateFrequencyHistogram(List<double> ltValue) 
        {
            chart1.Series.Clear();
            chart1.Series.Add("值");
            int iNum = (int)this.nUDnum.Value;
            int iLeft = (int)float.Parse(nTBXleftValue.Text);
            chart1.ChartAreas[0].AxisX.Minimum = iLeft;
            int iRight = (int)float.Parse(this.nTBXrightValue.Text);
            chart1.ChartAreas[0].AxisX.Maximum = iRight;
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisX.MinorTickMark.Enabled  = false;
            int interval = (iRight - iLeft) / iNum;
            chart1.ChartAreas[0].AxisX.Interval = interval;
            chart1.ChartAreas[0].AxisY.Title = "%";
            chart1.ChartAreas[0].AxisY.MinorTickMark.Enabled  = true;
            chart1.ChartAreas[0].AxisY.MinorTickMark.Interval = 1;

            chart1.Series[0].BorderColor = Color.Black;
            chart1.Series[0]["PointWidth"] = "1";

            double countSum = ltValue.Count();
            if (countSum > 0)
            {
                for (int i = 0; i <= iNum; i++)
                {
                    double curX = iLeft + i * interval - interval / 2;
                    int iCount = ltValue.Count(p => curX <= p && p < curX + interval);
                    DataPoint dp = new DataPoint(curX, iCount*100 / countSum);

                    chart1.Series[0].Points.Add(dp);
                }
            }
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            List<double> ltValue=getListDataFromDgvByColomnIndex(this.dgvDataTable,1);
            updateFrequencyHistogram(ltValue);
        }

        private void btnDeleteInvalid_Click(object sender, EventArgs e)
        {
                float fLimitMin=float.Parse(nTBXminInvalid.Text);
                float fLimitMax=float.Parse(nTBXmaxInvalid.Text);

                for (int i = this.dgvDataTable.RowCount  - 2; i >= 0; i--)
                {
                    var curValue = dgvDataTable.Rows[i].Cells[1].Value;
                    if (curValue != null)
                    {
                        float fValue = float.Parse(curValue.ToString());
                        if (fValue <= fLimitMin || fValue >= fLimitMax) dgvDataTable.Rows.RemoveAt(i);
                    }
                } 
            MessageBox.Show("操作完成。");
        }

        private void btnResample_Click(object sender, EventArgs e)
        {
            for (int i = this.dgvDataTable.RowCount - 2; i >= 0; i--)
            {
                int iSpar=(int)nUDIntervalResample.Value;
                if (i % iSpar!=0) dgvDataTable.Rows.RemoveAt(i);
            }
            MessageBox.Show("操作完成。");
        }

        private void tsmiCopyData_Click(object sender, EventArgs e)
        {
            cPublicMethodForm.copyDGVselect2Clipboard(this.dgvDataTable);
        }

        private void tsmiExportExcel_Click(object sender, EventArgs e)
        {
            cPublicMethodForm.exportDGV2Excel(this.dgvDataTable); 
        }

        private void tsmiExport2Txt_Click(object sender, EventArgs e)
        {
            cPublicMethodForm.exportDGV2txt(this.dgvDataTable); 
        }

        private void tsmiSelectAllAndCopy_Click(object sender, EventArgs e)
        {
            dgvDataTable.ClearSelection();
            for (int i = 0; i < dgvDataTable.Rows.Count; i++)
                for (int j = 0; j < dgvDataTable.Columns.Count; j++)
                    dgvDataTable.Rows[i].Cells[j].Selected = true;
            cPublicMethodForm.copyDGVselect2Clipboard(this.dgvDataTable);
        }

        private void tsmiSave2Project_Click(object sender, EventArgs e)
        {
            //表格的测井数据读取写入项目数据库

            //把表格数据保存到temp文件夹中，测井数据格式
            string logFilePath = Path.Combine(cProjectManager.dirPathWellDir, sJH, sLogName + cProjectManager.fileExtensionWellLog);
            string filePathTemp = Path.Combine(cProjectManager.dirPathTemp, sJH+sLogName + cProjectManager.fileExtensionWellLog); 
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
}
