using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using DOGPlatform.SVG;

namespace DOGPlatform
{
    public partial class FormDataAnalysis : Form
    {
        public FormDataAnalysis()
        {
            InitializeComponent();
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            bool IsDataOK = true; //数据未校验
            //数据校验过程
            cProjectData.sErrLineInfor= "";
            for (int j = 0; j < dgvDataTable.RowCount - 1; j++)
                for (int i = 0; i < dgvDataTable.ColumnCount; i++)
                {   //判读数据是否缺失
                    if (dgvDataTable.Rows[j].Cells[i].Value == null)
                    {
                        String line = "";
                        line = "表格第" + (j + 1).ToString() + "行" + "第" + (i + 1).ToString() + "列数据可能缺失或者有错误，请查看。" + "\r\n";
                        cProjectData.sErrLineInfor+= line;
                        IsDataOK = false;
                    }
                }

            if (IsDataOK == true) //数据通过所有的校验过程，整理成所需要的格式
            {  
                List<string> ltStrcolors = new List<string>();
                ltStrcolors.Add("red");
                ltStrcolors.Add("blue");
                ltStrcolors.Add("yellow");
                ltStrcolors.Add("green");
                List<string> ltStrLable = new List<string>();
                for (int j = 1; j <= dgvDataTable.ColumnCount - 1; j++)
                {
                    ltStrLable.Add(dgvDataTable.Columns[j].HeaderText);
                }

                int r = 30;
            
                string filenameSVGMap = "PieMap.svg";
            cSVGPie cPieMap = new cSVGPie(800,1000, 0, 0);

            
            for (int j = 0; j < dgvDataTable.RowCount - 1; j++)
            {
                string sJH = "";
                List<float> fListData = new List<float>();
               

                for (int i = 0; i < dgvDataTable.ColumnCount; i++)
                {
                    if (i == 0) sJH = dgvDataTable.Rows[j].Cells[i].Value.ToString();
                    if (i > 0) fListData.Add(float.Parse(dgvDataTable.Rows[j].Cells[i].Value.ToString()));
                }
                Point pWell = cCordinationTransform.getPointViewByJH(sJH);
                XmlElement returnXmlElement = cPieMap.gPieChart(fListData, pWell.X, pWell.Y, r, ltStrcolors, ltStrLable, 100, 100);
                cPieMap.addgElement2BaseLayer(returnXmlElement, 0, 0);
                cSVGText svgText = new cSVGText();
                XmlElement returnJHTextXmlElement = svgText.gElementText(pWell.X, pWell.Y + 20, sJH, 15, "black");
                cPieMap.addgElement2BaseLayer(returnJHTextXmlElement, 0, 0);
            }

            XmlElement returnElemment;
            if (this.cbxScaleRulerShowed.Checked == true)
            {
            
            }

          

            if (this.cbxCompassShowed.Checked == true)
            {
                cPieMap.svgRoot.AppendChild(cPieMap.gCompass(100,500));
            }
            cPieMap.makeSVGfile(cProjectManager.dirPathMap + filenameSVGMap);
             FormWebNavigation formSVGView = new FormWebNavigation(cProjectManager.dirPathMap + filenameSVGMap);formSVGView.Show();
            }
            else
            {
                cPublicMethodForm.outputErrInfor2Text(cProjectData.sErrLineInfor);
            }

        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Title = " 打开数据文件：";
            ofd.Filter = "text文件|*.txt|所有文件|*.*\\";

            //设置默认文件类型显示顺序 
            ofd.FilterIndex = 1;

            //保存对话框是否记忆上次打开的目录 
            ofd.RestoreDirectory = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string filepathSourceData = ofd.FileName;
                int lineindex = 0;
                string[] split;
                List<string> ltStrHeadColoum = new List<string>();
                using (StreamReader sr = new StreamReader(filepathSourceData, Encoding.Default))
                {
                    String line;
                    while ((line = sr.ReadLine()) != null && lineindex < 1) //delete the line whose legth is 0
                    {
                        lineindex++;
                        split = line.Trim().Split(new char[] { ' ', '\t', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < split.Length; i++) ltStrHeadColoum.Add(split[i]);
                    }
                }
                for (int i = 0; i < ltStrHeadColoum.Count; i++)
                {
                    DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                    col.HeaderText = ltStrHeadColoum[i];
                    dgvDataTable.Columns.Add(col);
                }
                cPublicMethodForm.read2DataGridViewByTextFile(filepathSourceData, dgvDataTable);
                dgvDataTable.Rows.RemoveAt(0);
            }

            else
            {
                MessageBox.Show("请重新选择数据文件.");
            }
        }
    }
}
