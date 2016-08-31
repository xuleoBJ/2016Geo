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
    public partial class FormSingleLogImport : Form
    {
        TypeTrack trackType;
        public FormSingleLogImport(string sTrackType)
        {
            InitializeComponent();
            this.trackType = (TypeTrack)Enum.Parse(typeof(TypeTrack), sTrackType);
            initializeMycontrol();
        }

        void initializeMycontrol()
        {
            if (trackType == TypeTrack.岩性层段)
            {
                List<string> ltStrColumnHead = new List<string>();
                ltStrColumnHead.Add("顶深m");
                ltStrColumnHead.Add("底深m");
                ltStrColumnHead.Add("岩性层段");
                dgvDataTable.Rows.Clear();
                foreach (string sItem in ltStrColumnHead)
                {
                    DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                    col.HeaderText = sItem;
                    dgvDataTable.Columns.Add(col);
                }
            }
            if (trackType == TypeTrack.文本道)
            {
                List<string> ltStrColumnHead = new List<string>();
                ltStrColumnHead.Add("顶深m");
                ltStrColumnHead.Add("底深m");
                ltStrColumnHead.Add("文本内容");
                dgvDataTable.Rows.Clear();
                foreach (string sItem in ltStrColumnHead)
                {
                    DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                    col.HeaderText = sItem;
                    dgvDataTable.Columns.Add(col);
                }
            }
             
        }

        private void ToolStripOpenFile_Click(object sender, EventArgs e)
        {
            cPublicMethodForm.read2DataGridViewByTextFile(dgvDataTable);
        }

        private void excel粘贴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cPublicMethodForm.DataGridViewCellPaste(dgvDataTable);
        }

        private void 删除选中行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认删除选择行吗？", "删除", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int index = dgvDataTable.CurrentCell.RowIndex;
                dgvDataTable.Rows.RemoveAt(index);
            }

        }

        private void 数据入库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cProjectData.sTempTrackData = cPublicMethodForm.readDataGridView2string(dgvDataTable);
            if (cProjectData.sErrLineInfor== "")
            {
                MessageBox.Show("数据已导入");
                this.Close();
            }
        }
    }
}
