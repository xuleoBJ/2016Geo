using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DOGPlatform.XML;

namespace DOGPlatform
{
    public partial class FormSettingLayerColor : Form
    {
        List<string> listLayerColor = new List<string>();
        public FormSettingLayerColor()
        {
            InitializeComponent();
            dgvLayerColorSetting.Columns.Add("Layer", "小层名");
            dgvLayerColorSetting.Columns.Add("Color", "颜色");
            listLayerColor = cfilePathProject.getProjectLayerColor();
            for (int i = 0; i < cProjectData.ltStrProjectXCM.Count; i++)
            {
                string _sItem = cProjectData.ltStrProjectXCM[i];
                dgvLayerColorSetting.Rows.Add(_sItem);
                if (listLayerColor[i].StartsWith("#"))
                    dgvLayerColorSetting.Rows[i].Cells[1].Style.BackColor = System.Drawing.ColorTranslator.FromHtml(listLayerColor[i]);
                
            }
            this.btnOK.DialogResult = DialogResult.OK;
            this.btnCancel.DialogResult = DialogResult.Cancel;
        }

        private void dgvLayerColorSetting_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvLayerColorSetting.CurrentCell.ColumnIndex == 1)
            {
                ColorDialog colorDialog1 = new ColorDialog();
                if (colorDialog1.ShowDialog() == DialogResult.OK)
                {
                    dgvLayerColorSetting.CurrentCell.Style.BackColor = colorDialog1.Color;
                    string hexColor = cPublicMethodBase.HexConverter(colorDialog1.Color);
                    listLayerColor[e.RowIndex] = hexColor;
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            cfilePathProject.setProjectLayerColor(listLayerColor);
        }

     
    }
}
