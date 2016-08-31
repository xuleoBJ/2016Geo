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
    public partial class FormVoronoiAna : Form
    {
        List<ItemWellLayerValue> ltWellLayerValueSelected = new List<ItemWellLayerValue>();
        string filePathSelect = "";
        string sDataSelect = "";
        string sLayerSelect = "ALL";
        public FormVoronoiAna()
        {
            InitializeComponent();
            inialForm();
        }
        void inialForm() 
        {
            string[] files = System.IO.Directory.GetFiles(cProjectManager.dirPathUsedProjectData, "*.txt");
            this.cbbFile.DataSource = files;
            initialCbbXCM();
        }

        void initialCbbXCM()
        {
            this.cbbXCM.Items.Clear();
            cbbXCM.Items.Add("ALL");
            foreach (string sItem in cProjectData.ltStrProjectXCM) cbbXCM.Items.Add(sItem);
            cbbXCM.SelectedIndex = 0;
        }


        private void btnReadFileHead_Click(object sender, EventArgs e)
        {
            filePathSelect = cbbFile.SelectedItem.ToString();
            string lineHead;

            using (StreamReader reader = new StreamReader(filePathSelect))
            {
                lineHead = reader.ReadLine();
            }
            cbbData.DataSource = null;
            cbbData.DataSource = lineHead.Split();
        }

        private void panelVoronoi_Paint(object sender, PaintEventArgs e)
        {
            float fMaxValue = 100;
            float.TryParse(this.tbxMax.Text, out fMaxValue);
            float fMinValue = 0;
            float.TryParse(this.tbxMin.Text, out fMinValue);
            cPublicPanel.addVoronoi(e, ltWellLayerValueSelected,fMinValue,fMaxValue,  pnlColor.BackColor);
            cPublicPanel.addWellPosion(e);
        }

        private void pnlColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK) pnlColor.BackColor = colorDialog.Color;
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            cPublicPanel.setPanel(this.panelVoronoi);
        }

        private void btnData_Click(object sender, EventArgs e)
        {
            ltWellLayerValueSelected.Clear();
            filePathSelect = cbbFile.SelectedItem.ToString();
            if (cbbData.SelectedItem == null)
            {
                MessageBox.Show("请选择分析数据项。");
            }
            else
            {
                sDataSelect = cbbData.SelectedItem.ToString();
                sLayerSelect = cbbXCM.SelectedItem.ToString();

                string[] split; ;
                using (StreamReader sr = new StreamReader(filePathSelect, Encoding.UTF8))
                {
                    String line;
                    int _lineindex = 0;
                    int indexData = 0;
                    while ((line = sr.ReadLine()) != null) //delete the line whose legth is 0
                    {
                        _lineindex++;
                        split = line.Trim().Split(new char[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
                        if (_lineindex == 1) indexData = split.ToList().IndexOf(sDataSelect);
                        else if (_lineindex >= 2)
                        {
                            ItemWellLayerValue item = new ItemWellLayerValue();
                            if (split[1] == sLayerSelect)
                            {
                                item.sJH = split[0];
                                item.sXCM = sLayerSelect;
                                item.fValue = 0.0f;
                                float.TryParse(split[indexData], out item.fValue);
                                if (float.IsNaN(item.fValue)) item.fValue = 0.0f;
                                ltWellLayerValueSelected.Add(item);
                            }
                        }
                    }//end while
                }//end using 
                //填充数据表格
                if (ltWellLayerValueSelected.Count > 0)
                {
                    tbxMin.Text = ltWellLayerValueSelected.Select(p => p.fValue).Min().ToString();
                    tbxMax.Text = ltWellLayerValueSelected.Select(p => p.fValue).Max().ToString();
                    if (this.dgv.Rows.Count > 0) { dgv.Rows.Clear(); dgv.Columns[2].HeaderCell.Value = sDataSelect; }
                    foreach (ItemWellLayerValue item in ltWellLayerValueSelected)
                    {
                        int index = this.dgv.Rows.Add();
                        this.dgv.Rows[index].Cells[0].Value = item.sJH;
                        this.dgv.Rows[index].Cells[1].Value = item.sXCM;
                        this.dgv.Rows[index].Cells[2].Value = item.fValue.ToString();
                    }
                }
            }
        }
        Point Opoint = new Point(0, 0);
        private void panelVoronoi_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Opoint.X = e.X;
                this.Opoint.Y = e.Y;
                this.Cursor = Cursors.Hand;
            }
        }

        private void panelVoronoi_MouseUp(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void panelVoronoi_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.panelVoronoi.Left = this.panelVoronoi.Left + e.X - this.Opoint.X;
                this.panelVoronoi.Top = this.panelVoronoi.Top + e.Y - this.Opoint.Y;
            }
        }

        private void tsmiZoomIn_Click(object sender, EventArgs e)
        {
            cProjectData.dfMapScale = cProjectData.dfMapScale * 1.2F;
            cPublicPanel.setPanel(this.panelVoronoi);
        }

        private void tsmiZoomOut_Click(object sender, EventArgs e)
        {
            cProjectData.dfMapScale = cProjectData.dfMapScale * 0.8F;
            cPublicPanel.setPanel(this.panelVoronoi);
        }

      
    }
}
