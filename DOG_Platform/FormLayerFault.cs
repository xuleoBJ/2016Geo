using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
namespace DOGPlatform
{
    public partial class FormLayerFault : Form
    {
        public FormLayerFault()
        {
            InitializeComponent();
        }
        private void nUDFaultLineWidth_ValueChanged(object sender, EventArgs e)
        {
            XDocument filePathOperate = XDocument.Load(cProjectManager.filePathLayerCss);
            filePathOperate.Element("LayerMapConfig").Element("FaultLine").Element("lineWidth").Value = nUDFaultLineWidth.Value.ToString("0");
            filePathOperate.Save(cProjectManager.filePathLayerCss);
        }
    }
}
