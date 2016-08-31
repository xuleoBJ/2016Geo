using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DOGPlatform.XML;
using DOGPlatform.SVG;

namespace DOGPlatform
{
    public partial class FormLayerWellValue : Form
    {
        string filePathOperate;
        public FormLayerWellValue()
        {
            InitializeComponent();
        }
        public FormLayerWellValue(string inputFile)
        {
            InitializeComponent();
            filePathOperate = inputFile;
        }
        private void btnAddWellValueLayer_Click(object sender, EventArgs e)
        {
            List<string> listColor = new List<string>() { "blue", "red", "green", "#FFFF66", "#FF99FF", "#FFE4C4", "#FFEBCD", "#F5DEB3", "#FF8C00", "#FFFACD", "#FFE4B5", "#FFDAB9", "#FF83FA", "#FF8C00", "#FF6EB4", "#FF7F50", "#F7F7F7", "#F5DEB3", "#F0FFF0", "#EEEEE0", "#EEE685", "#EEB422", "#F2F2F2", "#FFA07A", "#7CFC00", "#ADFF2F", "#AFEEEE", "#87CEEB", "#FFF68F", "#FFEFD5", "#FFE4E1", "#FFDEAD", "#FFC1C1", "#FFD700", "#FFBBFF", "#FFAEB9", "#FF83FA", "#FFE1FF", "#FCFCFC", "#FAFAD2", "#F7F7F7", "#F5DEB3", "#F0FFF0", "#EEEEE0", "#EEE685", "#EEB422", "#F2F2F2", "#E0FFFF", "#FFFF66", "#FF99FF", "#FFE4C4", "#FFEBCD", "#F5DEB3", "#FF8C00", "#FFFACD", "#FFE4B5", "#FFDAB9", "#FF83FA", "#FF8C00", "#FF6EB4", "#FF7F50", "#F7F7F7", "#F5DEB3", "#F0FFF0", "#EEEEE0", "#EEE685", "#EEB422", "#F2F2F2", "#FFA07A", "#7CFC00", "#ADFF2F", "#AFEEEE", "#87CEEB", "#FFF68F", "#FFEFD5", "#FFE4E1", "#FFDEAD", "#FFC1C1", "#FFD700", "#FFBBFF", "#FFAEB9", "#FF83FA", "#FFE1FF", "#FCFCFC", "#FAFAD2", "#F7F7F7", "#F5DEB3", "#F0FFF0", "#EEEEE0", "#EEE685", "#EEB422", "#F2F2F2", "#E0FFFF", "#FFFF66", "#FF99FF", "#FFE4C4", "#FFEBCD", "#F5DEB3", "#FF8C00", "#FFFACD", "#FFE4B5", "#FFDAB9", "#FF83FA", "#FF8C00", "#FF6EB4", "#FF7F50", "#F7F7F7", "#F5DEB3", "#F0FFF0", "#EEEEE0", "#EEE685", "#EEB422", "#F2F2F2", "#FFA07A", "#7CFC00", "#ADFF2F", "#AFEEEE", "#87CEEB", "#FFF68F", "#FFEFD5", "#FFE4E1", "#FFDEAD", "#FFC1C1", "#FFD700", "#FFBBFF", "#FFAEB9", "#FF83FA", "#FFE1FF", "#FCFCFC", "#FAFAD2", "#F7F7F7", "#F5DEB3", "#F0FFF0", "#EEEEE0", "#EEE685", "#EEB422", "#F2F2F2", "#E0FFFF" };

            List<string> listColorUser = new List<string>(); //设置用户颜色值
            for (int col = 1; col < dgvOuterDataLayerWellValues.Columns.Count; col++)//first column is wellname so start to get from
            {
                string curColBackColor = cPublicMethodBase.getRGB(dgvOuterDataLayerWellValues.Columns[col].DefaultCellStyle.BackColor);
                if (curColBackColor != "rgb(0,0,0)") listColorUser.Add(curColBackColor);
                else
                {
                    listColorUser.Add(listColor[col - 1]);
                }
            }

            List<string> listRowString = new List<string>();
            if (cPublicMethodForm.chekDataGridViewHasNullValue(dgvOuterDataLayerWellValues))
            {
                for (int rows = 0; rows < dgvOuterDataLayerWellValues.Rows.Count - 1; rows++)
                {
                    List<string> ltStrCell = new List<string>();
                    for (int col = 0; col < dgvOuterDataLayerWellValues.Rows[rows].Cells.Count; col++)
                    {
                        ltStrCell.Add(dgvOuterDataLayerWellValues.Rows[rows].Cells[col].Value.ToString());
                    }
                    listRowString.Add(string.Join("\t", ltStrCell));
                }//end for read datagridview data

                string sLayerName = "LayerNew";
                if (tbxDataLayerID.Text != "") sLayerName = tbxDataLayerID.Text;
                //add bar data 2 layer
                //if (rdbOuterDataLayerRect.Checked == true)
                //{
                //    cXMLLayerMapWellBarGraph.addLayerBarGraph2XML(filePathOperate, sIDLayer, int.Parse(nUDOuterDataLayerRectWidth.Value.ToString("0")), listColorUser, float.Parse(tbxOutLayerfVscale.Text), Convert.ToSingle(nUDLayerOpcity.Value), listRowString);
                //}
                cXMLLayerMapWellPieGraph.addLayeWellGraph(filePathOperate, sLayerName, listColorUser, listRowString);

            }// end if
            this.Close();
        }

        private void btnOuterDataLayerAddCol_Click(object sender, EventArgs e)
        {
            this.dgvOuterDataLayerWellValues.Columns.Add("Column", "数值");
        }

        private void btnOuterDataLayerDelCol_Click(object sender, EventArgs e)
        {
            if (dgvOuterDataLayerWellValues.ColumnCount > 2)
                dgvOuterDataLayerWellValues.Columns.RemoveAt(dgvOuterDataLayerWellValues.ColumnCount - 1);
        }

        private void btnCellColor_Click(object sender, EventArgs e)
        {
            int idCol = dgvOuterDataLayerWellValues.SelectedCells[0].ColumnIndex;
            if (idCol >= 1)
            {
                ColorDialog colorDialog1 = new ColorDialog();
                if (colorDialog1.ShowDialog() == DialogResult.OK)
                {
                    dgvOuterDataLayerWellValues.Columns[idCol].DefaultCellStyle.BackColor = colorDialog1.Color;
                }
            }
        }

        private void btnOuterDataLayerCopyFromExcel_Click(object sender, EventArgs e)
        {
            cPublicMethodForm.DataGridViewCellPaste(dgvOuterDataLayerWellValues);
        }

        
    }
}
