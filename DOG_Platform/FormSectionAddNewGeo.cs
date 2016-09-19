using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using DOGPlatform.XML;
using DOGPlatform.SVG;

namespace DOGPlatform
{
    public partial class FormSectionAddNewGeo : Form
    {
        //定义绘图数据的临时目录
        string dirSectionData = Path.Combine(cProjectManager.dirPathTemp, "sectionTemp");
        //定义联井剖面井号存储List
        List<string> ltStrSelectedJH = new List<string>();
        //定义存储绘图剖面井数据结构
        List<ItemWellSection> listWellsSection = new List<ItemWellSection>();

        public string filepathSVGRet = "";

        string filePathSectionCss = Path.Combine(cProjectManager.dirPathTemp, "新联井剖面" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xml");

        public FormSectionAddNewGeo(string _pathSectionCss, string _dirSectionData)
        {
            InitializeComponent();
            dirSectionData = _dirSectionData;
            filePathSectionCss = _pathSectionCss;
            InitFormControl();
        }

        //初始化Form页面
        private void InitFormControl()
        {
            cPublicMethodForm.inialListBox(lbxJH, cProjectData.ltStrProjectJH);
         
            List<string> ltFileNameXMT = cProjectManager.getTemplateFileNameList();
            cPublicMethodForm.inialComboBox(this.cbbSelectTemplate, ltFileNameXMT);
            if(cbbSelectTemplate.Items.Count>0) cbbSelectTemplate.SelectedIndex = 0;
        }

        private void btn_addWell_Click(object sender, EventArgs e)
        {
            cPublicMethodForm.transferItemFromleftListBox2rightListBox(lbxJH, lbxJHSeclected);
        }

        private void btn_deleteWell_Click(object sender, EventArgs e)
        {
            cPublicMethodForm.deleteSlectedItemFromListBox(lbxJHSeclected);
        }

        private void btn_upWell_Click(object sender, EventArgs e)
        {
            cPublicMethodForm.upItemInListBox(lbxJHSeclected);
        }

        private void btn_downWell_Click(object sender, EventArgs e)
        {
            cPublicMethodForm.downItemInListBox(lbxJHSeclected);
        }


        //从lbx中读取选取的井号，选取的即为剖面图组合的井号。

        void initialSectionData() 
        {
            listWellsSection.Clear();
            ltStrSelectedJH.Clear();

            //从cblist加入jh
            foreach (object selecteditem in lbxJHSeclected.Items)
            {
                string strItem = selecteditem as String;
                ltStrSelectedJH.Add(strItem);
            }
            //创建模板，2个模板 一个是描述整体布局的模板，每个单井又是一个模板。
          //  if (ltStrSelectedJH.Count > 0) filePathSectionCss = Path.Combine(cProjectManager.dirPathTemp, ltStrSelectedJH[0] + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xml");
            cXmlDocSectionGeo.generateSectionCssXML(filePathSectionCss);
        }
       
        void inintialSectionFlow()
        {
            initialSectionData(); 
            //初始化 ItemWellSection
            //全井井段绘制
            for (int i = 0; i < ltStrSelectedJH.Count; i++)
            {
                ItemWellSection _wellSection = new ItemWellSection(ltStrSelectedJH[i], 0, 0);
                //海拔转成md
                _wellSection.fShowedDepthTop =0;
                _wellSection.fShowedDepthBase = _wellSection.fWellBase;
                if (_wellSection.fShowedDepthBase >= _wellSection.fWellBase) _wellSection.fShowedDepthBase = _wellSection.fWellBase;
                listWellsSection.Add(_wellSection);
            }

            makeSectionGeo.setXPositionView(filePathSectionCss, listWellsSection);

            cXmlDocSectionGeo.write2css(listWellsSection, filePathSectionCss);

        }

        private void setDepthIntervalShowedBYBaseDepth()
        {
            inintialSectionFlow();
        }


        private void btnDataPre_Click(object sender, EventArgs e)
        {
            if (cbbSelectTemplate.Items.Count == 0) { MessageBox.Show("请自定义模板。"); return; }
            initialSectionData();
            //全井井段绘制
            for (int i = 0; i < ltStrSelectedJH.Count; i++)
            {
                ItemWellSection _wellSection = new ItemWellSection(ltStrSelectedJH[i], 0, 0);
                //默认把显示深度设为全井段
                _wellSection.fShowedDepthTop = 0;
                _wellSection.fShowedDepthBase = _wellSection.fWellBase;
                if (_wellSection.fShowedDepthBase >= _wellSection.fWellBase) _wellSection.fShowedDepthBase = _wellSection.fWellBase;
                listWellsSection.Add(_wellSection);
            }

            makeSectionGeo.setXPositionView(filePathSectionCss, listWellsSection);
            makeSectionGeo.setYPositionView(filePathSectionCss, listWellsSection);
            cXmlDocSectionGeo.write2css(listWellsSection, filePathSectionCss); 

            if (Directory.Exists(dirSectionData)) Directory.Delete(dirSectionData, true);
            Directory.CreateDirectory(dirSectionData);
            //插入数据
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
      
    }
}
