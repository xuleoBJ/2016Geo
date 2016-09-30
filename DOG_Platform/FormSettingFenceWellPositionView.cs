using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using DOGPlatform.XML;

namespace DOGPlatform
{
    public partial class FormSettingFenceWellPositionView : Form
    {
         string pathSectionCss = "";
         string sJH;
         public FormSettingFenceWellPositionView(string inputpathSectionCss, string _sJH)
        {
            InitializeComponent();
            this.btnCancel.DialogResult = DialogResult.Cancel;
            this.pathSectionCss = inputpathSectionCss;
            this.sJH = _sJH;
         
        }

         private void btnOK_Click(object sender, EventArgs e)
         {
            
             XmlNode selectWell = cXmlDocSectionGeo.selectNodeByID(this.pathSectionCss, this.sJH);
             if (selectWell != null)
             {
                 float xOffset = (float)this.nUDX.Value;
                 float yOffset = (float)nUDY.Value;

                 float xView = float.Parse(selectWell["Xview"].InnerText) + xOffset;
                 float yView = float.Parse(selectWell["Yview"].InnerText) + yOffset;

                 cXmlBase.setSelectedNodeChildNodeValue(pathSectionCss, sJH, "Xview", xView.ToString());
                 cXmlBase.setSelectedNodeChildNodeValue(pathSectionCss, sJH, "Yview", yView.ToString());
                 this.DialogResult = DialogResult.OK;
                 this.Close();
             }
         }
      
    }
}
