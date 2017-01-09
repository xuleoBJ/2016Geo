using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DOGPlatform
{
    public partial class FormCalArea : Form
    {
        public FormCalArea()
        {
            InitializeComponent();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            cPublicMethodForm.DataGridViewCellPaste(dgv);
        }

        private void btnDelDgvLine_Click(object sender, EventArgs e)
        {
            cPublicMethodForm.deleteSelectedCurrentRowDGV(dgv);
        }

        private void btnCal_Click(object sender, EventArgs e)
        {
            List<PointF> points = new List<PointF>();

            for (int j = 0; j < dgv.RowCount - 1; j++)
            {
                PointF _pf = new PointF();
                _pf.X = float.Parse(dgv.Rows[j].Cells[0].Value.ToString());
                _pf.Y = float.Parse(dgv.Rows[j].Cells[1].Value.ToString());
                points.Add(_pf);
            }
            MessageBox.Show("面积= " + cCalBase.calArea(points).ToString("0.000") + " \r\n" + "长度= " + cCalBase.calLength(points).ToString("0.000"),"计算结果");
        }
    }
}
