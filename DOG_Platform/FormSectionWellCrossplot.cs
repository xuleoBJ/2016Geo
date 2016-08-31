using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DOGPlatform.XML;
using System.Xml;
using System.Windows.Forms.DataVisualization.Charting;
using Excel = Microsoft.Office.Interop.Excel;

namespace DOGPlatform
{
    public partial class FormSectionWellCrossplot : Form
    {
        string filePathOper;
        string sIDTrack = "";
        float fTop = 0;
        float fBot = 0;
        string sJH = "";
        trackDataListLog logX, logY;
        XmlNode curTrack ;
        trackDataDraw curTrackDraw ;
        public FormSectionWellCrossplot(string _filePathOper,string _sIDTrack,float _fTop, float _fBot)
        {
            InitializeComponent();
            filePathOper = _filePathOper;
            sIDTrack = _sIDTrack;
            fTop = _fTop;
            fBot = _fBot;
            sJH = cXmlBase.getNodeInnerText(filePathOper, cXmlDocSectionWell.fullPathJH);
            this.nTBXtop.Text = fTop.ToString();
            this.nTBXbot.Text = fBot.ToString();
            if (sIDTrack != "")
            {
                curTrack = cXmlDocSectionWell.getTrackByTrackID(this.filePathOper, sIDTrack);
                if (curTrack != null)
                {
                    curTrackDraw = new trackDataDraw(curTrack);
                    rdbTypeValue.Text = curTrackDraw.sTrackTitle;
                }
                else rdbTypeValue.Enabled = false;
            }
            else
            {
                rdbTypeValue.Enabled = false;
            }
            initialCbbLog();
        }

        void initialCbbLog()
        {
            this.cbbXLog.Items.Clear();
            this.cbbYLog.Items.Clear();
            string _wellDir = Path.Combine(cProjectManager.dirPathWellDir, sJH);
            string[] wellLogItems = Directory.GetFiles(_wellDir, "*" + cProjectManager.fileExtensionWellLog);
            foreach (string strItem in wellLogItems)
            {
                string logName = Path.GetFileNameWithoutExtension(strItem);
                cbbXLog.Items.Add(logName);
                cbbYLog.Items.Add(logName);
            }
            if (cbbXLog.Items.Count > 0) cbbXLog.SelectedIndex = 0;
            if (cbbYLog.Items.Count > 0) cbbYLog.SelectedIndex = 0; 
        }

        void setUpDataList() 
        {
            fTop = float.Parse(this.nTBXtop.Text);
            fBot = float.Parse(this.nTBXbot.Text);
            if (cbbXLog.SelectedIndex>=0)
            {
                string sLogX = cbbXLog.SelectedItem.ToString();
                if (sLogX!= null) logX = cIOinputLog.getLogSeriersFromSectionWellFromLogFile(sJH, sLogX, fTop, fBot);
            }
            if (cbbYLog.SelectedIndex >= 0)
            {
                string sLogY = cbbYLog.SelectedItem.ToString();
                if(sLogY!=null) logY = cIOinputLog.getLogSeriersFromSectionWellFromLogFile(sJH, sLogY, fTop, fBot);
            }
        }

        #region 数据表格tbgData
        void updateTable(trackDataListLog logX, trackDataListLog logY)
        {

            dgvDataTable.Columns.Clear();
            foreach (string headText in new List<string>
            { "深度", logX.itemHeadInforDraw.sLogName, "深度", logY.itemHeadInforDraw.sLogName ,"plotX","plotY"})
            {
                DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                col.HeaderText = headText;
                dgvDataTable.Columns.Add(col);
            }

            int iLineMax = logX.fListMD.Count;
            if (logY.fListMD.Count > logX.fListMD.Count) iLineMax = logY.fListMD.Count;

            for (int i = 0; i < iLineMax; i++)
            {
                this.dgvDataTable.Rows.Add();
                if (i < logX.fListMD.Count)
                {
                    dgvDataTable.Rows[i].Cells[0].Value = logX.fListMD[i].ToString();
                    dgvDataTable.Rows[i].Cells[1].Value = logX.fListValue[i].ToString();
                }
                if (i < logY.fListMD.Count)
                {
                    dgvDataTable.Rows[i].Cells[2].Value = logY.fListMD[i].ToString();
                    dgvDataTable.Rows[i].Cells[3].Value = logY.fListValue[i].ToString();
                }
            }


        }
        #endregion

        private void btnDraw_Click(object sender, EventArgs e)
        {
            //获取绘制各个类别的数据系列，根据 sID 和 文件名 获取道内数据
            if (this.rdbTypeValue.Checked == true)
            {
                trackDataDraw curTrackDraw = new trackDataDraw(curTrack);
                XmlNode dataList = curTrack.SelectSingleNode("dataList");
                //按类别 选择的测井系列 动态增加数据
                List<ItemTrackDrawDataIntervalProperty> ltDataItem = new List<ItemTrackDrawDataIntervalProperty>();
                if (dataList != null)
                {
                    XmlNodeList dataItem = dataList.SelectNodes("dataItem");
                    foreach (XmlNode xn in dataItem)
                    {
                        ItemTrackDrawDataIntervalProperty item = new ItemTrackDrawDataIntervalProperty(xn);
                        if (item.top >= fTop && item.bot <= fBot) ltDataItem.Add(item);
                    }
                }
                updateCrossPlot(logX, logY,  ltDataItem);
            }
            if (rdbLogValue.Checked == true)
            {
                updateTable(logX, logY);
                //首先得判断对数坐标，左值，右值都能大于0
                if (checkAxieScale()) updateCrossPlot(logX, logY);
                else MessageBox.Show("坐标轴范围不正确。");
            }
        }


        double getIntervalLogValue(trackDataListLog logDataList,ItemTrackDrawDataIntervalProperty dataItem) 
        {
            List<double> ltCurDouble = new List<double>();
            for (int i = 0; i < logDataList.fListMD.Count; i++)
            {
                if (logDataList.fListMD[i] >= dataItem.top && logDataList.fListMD[i] <= dataItem.bot)
                    ltCurDouble.Add(logDataList.fListValue[i]);
            }
            return ltCurDouble.Average(); 
        }

        void updateCrossPlot(trackDataListLog logX, trackDataListLog logY, List<ItemTrackDrawDataIntervalProperty> ltDataItem)
        {
            chart1.Titles.Clear();
            string sTitle = logX.itemHeadInforDraw.sLogName + "-" + logY.itemHeadInforDraw.sLogName + "交汇图";
            chart1.Titles.Add(sTitle);
            chart1.Series.Clear(); 
            chart1.Legends.Clear();
            List<string> ltStrType = ltDataItem.Select(p => p.sProperty).Distinct().ToList();
            foreach (string sType in ltStrType)
            {
                chart1.Series.Add(sType);
                chart1.Series[sType].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
               
                chart1.Series[sType].IsVisibleInLegend = true;
                chart1.Legends.Add(new Legend(sType));
                chart1.Series[sType].Legend = sType;
                chart1.Legends[sType].Docking   = Docking.Bottom ;
                chart1.Legends[sType].IsDockedInsideChartArea = false; 
                chart1.Legends[sType].IsEquallySpacedItems  = true; 

                chart1.Legends[sType].LegendStyle = LegendStyle.Row ;
                chart1.Legends[sType].Alignment = System.Drawing.StringAlignment.Center;

                chart1.Series[sType].MarkerSize = 6;
                chart1.Series[sType].MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
                List<double> listDoubleX = new List<double>();
                List<double> listDoubleY = new List<double>();
                foreach(ItemTrackDrawDataIntervalProperty dataItem in ltDataItem)
                {
                    if (dataItem.sProperty == sType)
                    {
                        listDoubleX.Add(getIntervalLogValue(logX, dataItem));
                        listDoubleY.Add(getIntervalLogValue(logY, dataItem));
                    }
                    chart1.Series[sType].Points.DataBindXY(listDoubleX.ToArray(), listDoubleY.ToArray());
                }
            }
           
            //刻度值
            int iLeftX = (int)float.Parse(ntbxXLeft.Text);
            chart1.ChartAreas[0].AxisX.Minimum = iLeftX;
            int iRightX = (int)float.Parse(ntbxXRight.Text);
            chart1.ChartAreas[0].AxisX.Maximum = iRightX;


            int iLeftY = (int)float.Parse(ntbxYLeft.Text);
            chart1.ChartAreas[0].AxisY.Minimum = iLeftY;
            int iRightY = (int)float.Parse(ntbxYRight.Text);
            chart1.ChartAreas[0].AxisY.Maximum = iRightY;

            //网格
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = this.cbxGridMainX.Checked;
            chart1.ChartAreas[0].AxisX.MinorGrid.Enabled = this.cbxGridMinX.Checked;
            chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = this.cbxGridMainY.Checked;
            chart1.ChartAreas[0].AxisY.MinorGrid.Enabled = this.cbxGridMinY.Checked;

            //tickMark interval
            float fXinterval = 1;
            chart1.ChartAreas[0].AxisX.MinorTickMark.Enabled = true;
            if (this.ntbxXInterval.Text != "") float.TryParse(this.ntbxXInterval.Text, out fXinterval);
            chart1.ChartAreas[0].AxisX.MinorTickMark.Interval = fXinterval;
            float fYinterval = 1;
            chart1.ChartAreas[0].AxisY.MinorTickMark.Enabled = true;
            if (this.ntbxYInterval.Text != "") float.TryParse(this.ntbxYInterval.Text, out fYinterval);
            chart1.ChartAreas[0].AxisY.MinorTickMark.Interval = fYinterval;

            //标题
            chart1.ChartAreas[0].AxisX.Title = logX.itemHeadInforDraw.sLogName;
            chart1.ChartAreas[0].AxisY.Title = logY.itemHeadInforDraw.sLogName;
            chart1.ChartAreas[0].AxisX.IsLogarithmic = cbxXlog.Checked;
            chart1.ChartAreas[0].AxisY.IsLogarithmic = cbxYlog.Checked;

           
            chart1.Show();
        }
        bool checkAxieScale() 
        {
            bool bCheck = true;
            if (cbxXlog.Checked == true)
            {
                int iLeftX = (int)float.Parse(ntbxXLeft.Text);
                int iRightX = (int)float.Parse(ntbxXRight.Text);
                if (iLeftX < 0 || iRightX < 0) return false;
            }
            if (cbxYlog.Checked == true)
            {
                int iLeftY = (int)float.Parse(ntbxYLeft.Text);
                int iRightY = (int)float.Parse(ntbxYRight.Text);
                if (iLeftY < 0 || iRightY < 0) return false;
            }

            return bCheck;
        }

        void updateCrossPlot(trackDataListLog logX, trackDataListLog logY)
        {
            List<double> listDoubleX = new List<double>();
            List<double> listDoubleY = new List<double>();

            int iLineMax = logX.fListMD.Count;
            if (logY.fListMD.Count == logX.fListMD.Count)  //MD个数相同
            {
                listDoubleX = logX.fListValue;
                listDoubleY = logY.fListValue;
            }
            else  //MDList个数不同，找个数少的，这块误差可能选取的深度段 高低不同，如果 深度段无交叉是个要考虑的问题
            {
                if (logY.fListMD.Count < logX.fListMD.Count)
                {
                    iLineMax = logY.fListMD.Count;
                    int jStart = 0;
                    for (int i = 0; i < iLineMax; i++)
                    {
                        listDoubleY.Add(logY.fListValue[i]);
                        //为了保证序列个数相同，fValue给个初始值。不科学 需要改进
                        double fValue = logX.fListValue[i];
                        //由于深度序列是上升的，上次结束位置作为此次的开始位置。
                        for (int j = jStart; j < logX.fListMD.Count; j++)
                        {
                            //深度绝对值误差小于0.125 赋值 下次循环的起始位置改变，跳出赋值循环
                            if (Math.Abs(logX.fListMD[j] - logY.fListMD[i]) < 0.125)
                            {
                                fValue = logX.fListValue[j];
                                jStart = j;
                                break;
                            }
                        }
                        listDoubleX.Add(fValue);
                    }
                }
                if (logY.fListMD.Count > logX.fListMD.Count)
                {
                    iLineMax = logX.fListMD.Count;
                    int jStart = 0;
                    for (int i = 0; i < iLineMax; i++)
                    {
                        listDoubleX.Add(logX.fListValue[i]);
                        double fValue = logY.fListValue[i];
                        for (int j = jStart; j < logY.fListMD.Count; j++)
                        {
                            if (Math.Abs(logY.fListMD[j] - logX.fListMD[i]) < 0.125)
                            {
                                fValue = logY.fListValue[j];
                                jStart = j;
                                break;
                            }
                        }
                        listDoubleY.Add(fValue);
                    }
                }

            }

            chart1.Titles.Clear();
            string sTitle = logX.itemHeadInforDraw.sLogName + "-" + logY.itemHeadInforDraw.sLogName + "交汇图";
            chart1.Titles.Add(sTitle);

            //刻度值
            int iLeftX = (int)float.Parse(ntbxXLeft.Text);
            chart1.ChartAreas[0].AxisX.Minimum = iLeftX;
            int iRightX = (int)float.Parse(ntbxXRight.Text);
            chart1.ChartAreas[0].AxisX.Maximum = iRightX;


            int iLeftY = (int)float.Parse(ntbxYLeft.Text);
            chart1.ChartAreas[0].AxisY.Minimum = iLeftY;
            int iRightY = (int)float.Parse(ntbxYRight.Text);
            chart1.ChartAreas[0].AxisY.Maximum = iRightY;

            //网格
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = this.cbxGridMainX.Checked;
            chart1.ChartAreas[0].AxisX.MinorGrid.Enabled = this.cbxGridMinX.Checked;
            chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = this.cbxGridMainY.Checked;
            chart1.ChartAreas[0].AxisY.MinorGrid.Enabled = this.cbxGridMinY.Checked;

            //tickMark interval
            float fXinterval = 1;
            chart1.ChartAreas[0].AxisX.MinorTickMark.Enabled = true;
            if (this.ntbxXInterval.Text != "") float.TryParse(this.ntbxXInterval.Text, out fXinterval);
            chart1.ChartAreas[0].AxisX.MinorTickMark.Interval = fXinterval;
            float fYinterval = 1;
            chart1.ChartAreas[0].AxisY.MinorTickMark.Enabled = true;
            if (this.ntbxYInterval.Text != "") float.TryParse(this.ntbxYInterval.Text, out fYinterval);
            chart1.ChartAreas[0].AxisY.MinorTickMark.Interval = fYinterval;

            //标题
            chart1.ChartAreas[0].AxisX.Title = logX.itemHeadInforDraw.sLogName;
            chart1.ChartAreas[0].AxisY.Title = logY.itemHeadInforDraw.sLogName;
            chart1.ChartAreas[0].AxisX.IsLogarithmic = cbxXlog.Checked;
            chart1.ChartAreas[0].AxisY.IsLogarithmic = cbxYlog.Checked;
           
            //绘图数据写入表格第5列 第6列
            for (int i = 0; i < listDoubleX.Count; i++)
            {
                dgvDataTable.Rows[i].Cells[4].Value = listDoubleX[i].ToString();
                dgvDataTable.Rows[i].Cells[5].Value = listDoubleY[i].ToString(); 
            }
            chart1.Series["Series1"].Points.DataBindXY(listDoubleX.ToArray(), listDoubleY.ToArray());
            chart1.Show(); 
        }

        private void cbbXLog_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbXLog.SelectedIndex >= 0) 
            {
                setUpDataList();
                if (logX != null && logX.fListValue.Count>0)
                {
                    ntbxXLeft.Text = logX.fListValue.Min().ToString();
                    ntbxXRight.Text = logX.fListValue.Max().ToString();
                }
            }
        }

        private void cbbYLog_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbYLog.SelectedIndex >= 0)
            {
                setUpDataList();
                if (logY != null && logY.fListValue.Count > 0)
                {
                    ntbxYLeft.Text = logY.fListValue.Min().ToString();
                    ntbxYRight.Text = logY.fListValue.Max().ToString();
                }
            }
        }

        private void btnCrossPlotExcle_Click(object sender, EventArgs e)
        {
            Excel.Application  xlApp = new Microsoft.Office.Interop.Excel.Application();
            if (xlApp == null) 
            {
                MessageBox.Show("Excel is not installed.");
                return;
            }

            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            //add data 
            xlWorkSheet.Cells[1, 1] = "";
            xlWorkSheet.Cells[1, 2] = "Student1";
            xlWorkSheet.Cells[1, 3] = "Student2";
            xlWorkSheet.Cells[1, 4] = "Student3";

            xlWorkSheet.Cells[2, 1] = "Term1";
            xlWorkSheet.Cells[2, 2] = "80";
            xlWorkSheet.Cells[2, 3] = "65";
            xlWorkSheet.Cells[2, 4] = "45";

            xlWorkSheet.Cells[3, 1] = "Term2";
            xlWorkSheet.Cells[3, 2] = "78";
            xlWorkSheet.Cells[3, 3] = "72";
            xlWorkSheet.Cells[3, 4] = "60";

            xlWorkSheet.Cells[4, 1] = "Term3";
            xlWorkSheet.Cells[4, 2] = "82";
            xlWorkSheet.Cells[4, 3] = "80";
            xlWorkSheet.Cells[4, 4] = "65";

            xlWorkSheet.Cells[5, 1] = "Term4";
            xlWorkSheet.Cells[5, 2] = "75";
            xlWorkSheet.Cells[5, 3] = "82";
            xlWorkSheet.Cells[5, 4] = "68";

            Excel.Range chartRange;

            Excel.ChartObjects xlCharts = (Excel.ChartObjects)xlWorkSheet.ChartObjects(Type.Missing);
            Excel.ChartObject myChart = (Excel.ChartObject)xlCharts.Add(10, 80, 300, 250);
            Excel.Chart chartPage = myChart.Chart;

            chartRange = xlWorkSheet.get_Range("A1", "d5");
            chartPage.SetSourceData(chartRange, misValue);
            chartPage.ChartType = Excel.XlChartType.xlColumnClustered;

            xlWorkBook.SaveAs("D:\\1.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);

        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
