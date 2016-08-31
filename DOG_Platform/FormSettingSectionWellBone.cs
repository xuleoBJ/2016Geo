using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using DOGPlatform.XML;

namespace DOGPlatform
{
    public partial class FormSettingSectionWellBone : Form
    {
        string xmlPath = "";
        public FormSettingSectionWellBone(string inputXmlPath)
        {
            InitializeComponent();
            this.btnOK.DialogResult = DialogResult.OK;
            this.btnCancel.DialogResult = DialogResult.Cancel;
            this.xmlPath = inputXmlPath;
        }
        private void nUDWellConeWidth_ValueChanged(object sender, EventArgs e)
        {
            XDocument sectionMapXML = XDocument.Load(xmlPath);
            sectionMapXML.Element("SectionMap").Element("WellCone").Element("coneWidth").Value = nUDWellConeWidth.Value.ToString("0");
            sectionMapXML.Save(xmlPath);
        }
        private void nUDWellConeCircle_R_ValueChanged(object sender, EventArgs e)
        {
            XDocument sectionMapXML = XDocument.Load(xmlPath);
            sectionMapXML.Element("SectionMap").Element("WellCone").Element("radisHeadCircle").Value = nUDWellConeCircle_R.Value.ToString("0");
            sectionMapXML.Save(xmlPath);
        }
        private void nUDWellConeFontSize_ValueChanged(object sender, EventArgs e)
        {
            XDocument sectionMapXML = XDocument.Load(cProjectManager.xmlConfigSection);
            sectionMapXML.Element("SectionMap").Element("WellCone").Element("tickTextFontSize").Value = nUDWellConeMinScale.Value.ToString("0");
            sectionMapXML.Save(cProjectManager.xmlConfigSection);
        }
        private void nUDWellConeScale_ValueChanged(object sender, EventArgs e)
        {
            cXETrackWellConeRuler.setMainScale(xmlPath, "1111", nUDWellConeMainScale.Value.ToString("0"));
        }
        private void nUDWellConeJHFontSize_ValueChanged(object sender, EventArgs e)
        {
            XDocument sectionMapXML = XDocument.Load(xmlPath);
            sectionMapXML.Element("SectionMap").Element("WellCone").Element("JHFontSize").Value = nUDWellConeJHFontSize.Value.ToString("0");
            sectionMapXML.Save(xmlPath);
        }

        private void nUDWellConeMinScale_ValueChanged(object sender, EventArgs e)
        {

            cXETrackWellConeRuler.setMinScale(xmlPath, "1111", nUDWellConeMinScale.Value.ToString("0"));
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            cProjectData.iSectionCSSModified = 1; //记录被xml被修改过
            this.Close();
        }
     
    }
}
