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
    public partial class FormDataTableDeal : Form
    {
        public FormDataTableDeal()
        {
            InitializeComponent();
            for (int i = 1; i < 30; i++)
            {
                DataGridViewColumn col = new DataGridViewTextBoxColumn();
                col.HeaderText = i.ToString();
                dgv.Columns.Add(col);
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            cPublicMethodForm.DataGridViewCellPaste(dgv);
        }

        private void btnDelDgvLine_Click(object sender, EventArgs e)
        {
            Cursor.Current =  Cursors.WaitCursor;
            for (int i = dgv.RowCount - 2; i > 1; i--)
            {
                if (rdb1.Checked == true)
                {
                    if (dgv.Rows[i - 1].Cells[0].Value.ToString() == dgv.Rows[i].Cells[0].Value.ToString()) dgv.Rows.RemoveAt(i); 
                }
                if (rdb2.Checked == true)
                {
                    if (dgv.Rows[i - 1].Cells[0].Value.ToString() == dgv.Rows[i].Cells[0].Value.ToString() && dgv.Rows[i - 1].Cells[1].Value.ToString() == dgv.Rows[i].Cells[1].Value.ToString()) dgv.Rows.RemoveAt(i); 
                }
                if (rdb3.Checked == true)
                {
                    if (dgv.Rows[i - 1].Cells[0].Value.ToString() == dgv.Rows[i].Cells[0].Value.ToString() && dgv.Rows[i - 1].Cells[1].Value.ToString() == dgv.Rows[i].Cells[1].Value.ToString()&& dgv.Rows[i - 1].Cells[2].Value.ToString() == dgv.Rows[i].Cells[2].Value.ToString()) dgv.Rows.RemoveAt(i); 
                }

            }
            Cursor.Current = Cursors.Default;
        }
    }
}
