using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DOGPlatform.XML;
using System.Xml;

namespace DOGPlatform
{
    public partial class FormSettingModeIntervalFence : Form
    {
         string filePathSectionGeoCss;
        string dirSectionData;
        List<ItemWellSection> listWellsSection = new List<ItemWellSection>();
        public FormSettingModeIntervalFence(string _filePathSectionGeoCss, string _dirSectionData)
        {
            InitializeComponent();
            filePathSectionGeoCss = _filePathSectionGeoCss;
            dirSectionData = _dirSectionData;
            initialForm();
        }
        public FormSettingModeIntervalFence()
        {
            InitializeComponent();
        }
        void initialForm()
        {
            cPublicMethodForm.inialComboBox(cbbTopXCM, cProjectData.ltStrProjectXCM);
            cPublicMethodForm.inialComboBox(cbbBottomXCM, cProjectData.ltStrProjectXCM);
            foreach (XmlElement elWell in cXmlDocSectionGeo.getWellNodes(filePathSectionGeoCss))
            {
                ItemWellSection item = new ItemWellSection(elWell["JH"].InnerText);
                item.fShowedDepthTop = float.Parse(elWell["fShowTop"].InnerText);
                item.fShowedDepthBase = float.Parse(elWell["fShowBot"].InnerText);
                item.fXview = float.Parse(elWell["Xview"].InnerText);
                item.fYview = float.Parse(elWell["Yview"].InnerText);
                listWellsSection.Add(item);
            }
        }

        private void btnSectionShowDepth_Click(object sender, EventArgs e)
        {
            makeNewShowDepth();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        List<string> getSelectListLayer()
        {
            List<string> ltStrSelectedXCM = new List<string>();
            string sTopXCM = this.cbbTopXCM.SelectedItem.ToString();
            int iTopIndex = cProjectData.ltStrProjectXCM.IndexOf(sTopXCM);
            string sBottomXCM = this.cbbBottomXCM.SelectedItem.ToString();
            int iBottomIndex = cProjectData.ltStrProjectXCM.IndexOf(sBottomXCM);
            if (iBottomIndex - iTopIndex >= 0) ltStrSelectedXCM = cProjectData.ltStrProjectXCM.GetRange(iTopIndex, iBottomIndex - iTopIndex + 1);
            return ltStrSelectedXCM;
        }

        void makeNewShowDepth()
        {
            List<string> ltStrSelectedXCM = getSelectListLayer();
            if (ltStrSelectedXCM.Count > 0)
            {
                int _up = Convert.ToInt16(this.nUDtopDepthUp.Value);
                int _down = Convert.ToInt16(this.nUDbottomDepthDown.Value);
                //重新给显示的顶底赋值
                foreach (ItemWellSection item in listWellsSection)
                {
                    string sJH = item.sJH;
                    //有可能上下层有缺失。。。所以这块的技巧是找出深度序列，取最大最小值
                    cIOinputLayerDepth fileLayerDepth = new cIOinputLayerDepth();
                    List<float> fListDS1Return = fileLayerDepth.selectDepthListFromLayerDepthByJHAndXCMList(sJH, ltStrSelectedXCM);
                    if (fListDS1Return.Count > 0)  //返回值为空 说明所选层段整个缺失！
                    {
                        item.fShowedDepthTop = fListDS1Return.Min() - _up;
                        item.fShowedDepthBase = fListDS1Return.Max() + _down;
                        cXmlBase.setSelectedNodeChildNodeValue(filePathSectionGeoCss, sJH, "fShowTop", item.fShowedDepthTop.ToString("0"));
                        cXmlBase.setSelectedNodeChildNodeValue(filePathSectionGeoCss, sJH, "fShowBot", item.fShowedDepthBase.ToString("0"));
                    }
                }//end foreach
            }//end if
        }
    }
}
