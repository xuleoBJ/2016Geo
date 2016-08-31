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
    public partial class FormDataTable : Form
    {
        string filepathSourceData;
        public FormDataTable(string filepath)
        {
            InitializeComponent();

            this.filepathSourceData=filepath;
            this.Text = filepath;
            initializeMycontrol();
        }
        void initializeMycontrol() 
        {
            if (File.Exists(filepathSourceData))
            {
                int lineindex = 0;
                string[] split;
                List<string> ltStrHeadColoum = new List<string>();
                using (StreamReader sr = new StreamReader(filepathSourceData, Encoding.Default))
                {
                    String line;
                    while ((line = sr.ReadLine()) != null&&lineindex<1) //delete the line whose legth is 0
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
                if (dgvDataTable.ColumnCount>0) dgvDataTable.Rows.RemoveAt(0);
            }
        }

        private void 修改数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cPublicMethodForm.readDataGridView2TXTFileWithColoumHead(dgvDataTable, filepathSourceData);
            cPublicMethodForm.read2DataGridViewByTextFile(filepathSourceData, dgvDataTable);
            MessageBox.Show("数据保存完毕");
        }

        private void ToCsV(DataGridView dGV, string filename)
        {
            string stOutput = "";
            // Export titles:
            string sHeaders = "";

            for (int j = 0; j < dGV.Columns.Count; j++)
                sHeaders = sHeaders.ToString() + Convert.ToString(dGV.Columns[j].HeaderText) + "\t";
            stOutput += sHeaders + "\r\n";
            // Export data.
            for (int i = 0; i < dGV.RowCount - 1; i++)
            {
                string stLine = "";
                for (int j = 0; j < dGV.Rows[i].Cells.Count; j++)
                    stLine = stLine.ToString() + Convert.ToString(dGV.Rows[i].Cells[j].Value) + "\t";
                stOutput += stLine + "\r\n";
            }
            Encoding utf16 = Encoding.GetEncoding(1254);
            byte[] output = utf16.GetBytes(stOutput);
            FileStream fs = new FileStream(filename, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(output, 0, output.Length); //write the encoded file
            bw.Flush();
            bw.Close();
            fs.Close();
        }  

        private void 导入ExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "export.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //ToCsV(dataGridView1, @"c:\export.xls");
                ToCsV(dgvDataTable, sfd.FileName); // Here dataGridview1 is your grid view name 
            } 
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void 导出数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "文本文件(*.txt)|*.txt";
            sfd.FileName = "export.txt";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                cPublicMethodForm.readDataGridView2TXTFileWithColoumHead(dgvDataTable, sfd.FileName);
            } 
        }

        private void 打开文件ToolStripMenuItem_Click(object sender, EventArgs e)
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
                this.filepathSourceData = ofd.FileName;
                initializeMycontrol();
            }
            else
            {
                MessageBox.Show("请重新选择数据文件.");
            }
        }

        private void tsmiExportExcel_Click(object sender, EventArgs e)
        {
            cPublicMethodForm.exportDGV2Excel(this.dgvDataTable); 
        }
    }
}
