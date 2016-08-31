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
    public partial class FormLayerGeologicalValue : Form
    {
        string filePathLayerCss = "";
        public FormLayerGeologicalValue(string inputXmlPath)
        {
            InitializeComponent();
            this.btnOK.DialogResult = DialogResult.OK;
            this.btnCancel.DialogResult = DialogResult.Cancel;
            this.filePathLayerCss = inputXmlPath;
            List<string> ltStrStaticDataChoise = new List<string>();
            ltStrStaticDataChoise.Add("砂厚");
            ltStrStaticDataChoise.Add("有效厚度");
            ltStrStaticDataChoise.Add("孔隙度");
            ltStrStaticDataChoise.Add("渗透率");
            ltStrStaticDataChoise.Add("饱和度");
        }
        private void nUDLayerGeologyProperyFontSize_ValueChanged(object sender, EventArgs e)
        {
            cXMLLayerMapGeoproperty.setLayerGeoglogyPropertyTextsize(filePathLayerCss, Convert.ToInt16(nUDLayerGeologyProperyFontSize.Value));
        }

        //增加井点地质属性
        void addLayerWellProperty2Xml()
        {
            //List<string> ltValue = listLayersDataCurrentLayerStatic.Select(p => p.sJH + "\t" + p.dbX + "\t" + p.dbY + "\t" + p.fDCHD.ToString("0.0")
            //    + "\t" + p.fSH.ToString() + "\t" + p.fYXHD.ToString() + "\t" + p.fSTL.ToString()).ToList();
            //cXMLLayerMapGeoproperty.addLayerGeoProperty2XML(filePathLayerCss, "geoLayer", ltValue);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }

       
    }
}
