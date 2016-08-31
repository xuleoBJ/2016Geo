using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DOGPlatform.XML;
using DOGPlatform.SVG;
using System.IO;

namespace DOGPlatform
{
    public partial class FormSectionAddGroup : Form
    {
        //定义绘图数据的临时目录
        string dirSectionData = Path.Combine(cProjectManager.dirPathTemp, "sectionTemp");
        //定义联井剖面井号存储List
        List<string> ltStrSelectedJH = new List<string>();
        //定义存储绘图剖面井数据结构
        List<ItemWellSection> listWellsSection = new List<ItemWellSection>();

        public string filepathSVGRet = "";

        string filePathSectionCss = Path.Combine(cProjectManager.dirPathTemp, "sectionGeo" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xml");


        public FormSectionAddGroup(string _pathSectionCss, string _dirSectionData)
        {
            InitializeComponent();
            dirSectionData = _dirSectionData;
            filePathSectionCss = _pathSectionCss;
            InitFormWellsGroupControl();
        }

        private void InitFormWellsGroupControl()
        {
            cPublicMethodForm.inialListBox(lbxJH, cProjectData.ltStrProjectJH);
            cPublicMethodForm.inialComboBox(cbbTopXCM, cProjectData.ltStrProjectXCM);
            cPublicMethodForm.inialComboBox(cbbBottomXCM, cProjectData.ltStrProjectXCM);
            List<string> ltFileNameXMT = cProjectManager.getTemplateFileNameList();
            cPublicMethodForm.inialComboBox(this.cbbSelectTemplate, ltFileNameXMT);
            cbbSelectTemplate.SelectedIndex = 0;
        }

        private void btn_addWell_Click(object sender, EventArgs e)
        {
            cPublicMethodForm.transferItemFromleftListBox2rightListBox(lbxJH, lbxJHSeclected);
        }
        private void btn_deleteWell_Click(object sender, EventArgs e)
        {
            cPublicMethodForm.deleteSlectedItemFromListBox(lbxJHSeclected);
        }
        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            cPublicMethodForm.inialListBox(lbxJHSeclected, cProjectData.ltStrProjectJH);
        }
        private void btnSelectNone_Click(object sender, EventArgs e)
        {
            lbxJHSeclected.Items.Clear();
        }
       
        private void btnCollectWells_Click(object sender, EventArgs e)
        {
            listWellsSection.Clear();
            ltStrSelectedJH.Clear();
            foreach (object selecteditem in lbxJHSeclected.Items)
            {
                string strItem = selecteditem as String;
                ltStrSelectedJH.Add(strItem);
            }

            //创建模板，2个模板 一个是描述整体布局的模板，每个单井又是一个模板。

            //不同的模式，初始化不同的 listWellSection
            List<ItemWellHead> listWellHead = cIOinputWellHead.readWellHead2Struct();
            cXmlDocSectionGeo.generateSectionCssXML(filePathSectionCss);
            //初始化 ItemWellSection
            string sTopXCM = this.cbbTopXCM.SelectedItem.ToString();
            int iTopIndex = cProjectData.ltStrProjectXCM.IndexOf(sTopXCM);
            string sBottomXCM = this.cbbBottomXCM.SelectedItem.ToString();
            int iBottomIndex = cProjectData.ltStrProjectXCM.IndexOf(sBottomXCM);
            if (iBottomIndex - iTopIndex >= 0)
            {
                List<string> ltStrSelectedXCM = cProjectData.ltStrProjectXCM.GetRange(iTopIndex, iBottomIndex - iTopIndex + 1);
                int _up = Convert.ToInt16(this.nUDtopDepthUp.Value);
                int _down = Convert.ToInt16(this.nUDbottomDepthDown.Value);

                for (int i = 0; i < ltStrSelectedJH.Count; i++)
                {
                    ItemWellSection _wellSection = new ItemWellSection(ltStrSelectedJH[i], 0, 0);
                    //有可能上下层有缺失。。。所以这块的技巧是找出深度序列，取最大最小值
                    cIOinputLayerDepth fileLayerDepth = new cIOinputLayerDepth();
                    List<float> fListDS1Return = fileLayerDepth.selectDepthListFromLayerDepthByJHAndXCMList(ltStrSelectedJH[i], ltStrSelectedXCM);
                    if (fListDS1Return.Count > 0)  //返回值为空 说明所选层段整个缺失！
                    {
                        _wellSection.fShowedDepthTop = fListDS1Return.Min() - _up;
                        _wellSection.fShowedDepthBase = fListDS1Return.Max() + _down;
                    }
                    else 
                    {
                        _wellSection.fShowedDepthTop = 0;
                        _wellSection.fShowedDepthBase = _wellSection.fWellBase;
                    }
                    listWellsSection.Add(_wellSection);
                }
            }
            else
            {
                MessageBox.Show("上层应该比下层选择高，请重新选择。");
            }
            cXmlDocSectionGeo.write2css(listWellsSection, filePathSectionCss);
        }

        private void cbbTopXCM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbBottomXCM.Items.Count > 0)
                this.cbbBottomXCM.SelectedIndex = cbbTopXCM.SelectedIndex + 1;
        }

        private void btnDataPre_Click(object sender, EventArgs e)
        {
            if (listWellsSection.Count > 0)
            {
                if (Directory.Exists(dirSectionData)) Directory.Delete(dirSectionData, true);
                Directory.CreateDirectory(dirSectionData);
                //插入数据
                if (cbbSelectTemplate.SelectedIndex < 0) cbbSelectTemplate.SelectedIndex = 0;
                string fileNameSelectTemplate = this.cbbSelectTemplate.SelectedItem.ToString();
                foreach (ItemWellSection item in listWellsSection)
                {
                    string filePathGoal = Path.Combine(dirSectionData, item.sJH + ".xml");
                    cIOtemplate.copyTemplate(fileNameSelectTemplate, filePathGoal, item.sJH, item.fShowedDepthTop, item.fShowedDepthBase);
                    //在道中循环插入道数据
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else 
            {
                MessageBox.Show("请先选择层段。");
            }
        }
    }
}
