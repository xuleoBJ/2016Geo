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
    public partial class FormLayerSettingPage : Form
    {
        string filePathOperate = "";
        public FormLayerSettingPage(string inputFileOper)
        {
            InitializeComponent();
            this.filePathOperate = inputFileOper;
            this.btnOK.DialogResult = DialogResult.OK;
            this.btnCancel.DialogResult = DialogResult.Cancel;
            this.tbxTitle.Text = cXmlBase.getNodeInnerText(filePathOperate, cXELayerPage.fmpMapTitle);
        }
        void initialCbbScale()
        {
            List<string> listScale = new List<string>();
            listScale.Add("10000");
            listScale.Add("20000");
            listScale.Add("25000");
            listScale.Add("50000");
            listScale.Add("5000");
            listScale.Add("2000");
            listScale.Add("1000");
            listScale.Add("500");
            listScale.Add("250");
            listScale.Add("200");
            listScale.Add("100000");
            cbbScale.Items.Clear();
            foreach (string sItem in listScale) cbbScale.Items.Add(sItem);
            this.nUDrefX.Value = decimal.Parse(cProjectData.dfMapXrealRefer.ToString());
            this.nUDrefY.Value = decimal.Parse(cProjectData.dfMapYrealRefer.ToString());
            initialCbbScale();
            this.cbbScale.Text = (1000.0 / cProjectData.dfMapScale).ToString("0");
            cPublicMethodForm.inialComboBox(cbbUnit, new List<string>(new string[] { "px", "pt", "mm", "pc", "cm", "in" }));
        }
    }
}
