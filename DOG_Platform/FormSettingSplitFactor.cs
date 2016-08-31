using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DOGPlatform
{
    public partial class FormSettingSplitFactor : Form
    {
        public FormSettingSplitFactor()
        {
            InitializeComponent();
            InitControl();
        }
        private void InitControl()
        {
            cProjectData.ltStrProjectJH.Sort();
            cPublicMethodForm.inialComboBox(cbbYM, cProjectData.ltStrProjectYM);
            cPublicMethodForm.inialComboBox(cbbJH, cProjectData.ltStrProjectJH);
            cPublicMethodForm.inialComboBox(cbbJHGroup, cProjectData.ltStrProjectJH);
            cPublicMethodForm.inialComboBox(cbbYMGroup, cProjectData.ltStrProjectYM);
            cPublicMethodForm.inialComboBox(cbbLayerGroup,cProjectData.ltStrProjectXCM);
        }
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnCalSplitFactor_Click(object sender, EventArgs e)
        {
            WaitWindow.Show(this.SplitProductionWorkerMethod);
            MessageBox.Show("劈分系数计算完成。");
        }

        private void SplitProductionWorkerMethod(object sender, WaitWindowEventArgs e)
        {
            List<string> ltStrJH_DicLayerData = new List<string>();
            List<string> ltStrXCM_DicLayerData = new List<string>();
            List<float> fListSandHD_DicLayerData = new List<float>();
            List<float> fListPerm_DicLayerData = new List<float>();
            string[] split;
            int iLineIndex = 0;
            try
            {
                using (StreamReader sr = new StreamReader(cProjectManager.filePathLayerDataDic))
                {
                    String line;

                    while ((line = sr.ReadLine()) != null) //delete the line whose legth is 0
                    {
                        iLineIndex++;
                        split = line.Trim().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                        if (iLineIndex > 1 && split.Count() >= 12)
                        {
                            ltStrJH_DicLayerData.Add(split[0]);
                            ltStrXCM_DicLayerData.Add(split[1]);
                            fListSandHD_DicLayerData.Add(float.Parse(split[7]));
                            fListPerm_DicLayerData.Add(float.Parse(split[10]));
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            StreamWriter sw = new StreamWriter(cProjectManager.filePathLayerSplitFactorDic, false, Encoding.UTF8);
            List<string> ltStrHeadColoum = new List<string>();
            ltStrHeadColoum.Add("JH");
            ltStrHeadColoum.Add("XCM");
            ltStrHeadColoum.Add("YYYYMM");
            ltStrHeadColoum.Add("LayerSplitFactor"); //劈分系数
            sw.WriteLine(string.Join("\t", ltStrHeadColoum.ToArray()));
            //算法 查找射孔井段是否射孔，查找当前井段的根据KH的比值劈分 劈分系数的问题
            //劈分系数字典 JH NY XCM PFXS 这个表可以由KH和射孔数据，由厚度等等得到，各种方法
            if (cProjectData.ltStrProjectJH.Count > 0 && cProjectData.ltStrProjectXCM.Count > 0)
            {
                for (int i = 0; i < cProjectData.ltStrProjectJH.Count; i++)
                    for (int j = 0; j < cProjectData.ltStrProjectXCM.Count; j++)
                        for (int k = 0; k < cProjectData.ltStrProjectYM.Count; k++)
                        {
                            string sJH = cProjectData.ltStrProjectJH[i];
                            string sXCM = cProjectData.ltStrProjectXCM[j];
                            string sYM = cProjectData.ltStrProjectYM[k];

                            List<float> fListSH_temp = new List<float>();
                            int _iJHFirstIndex = ltStrJH_DicLayerData.IndexOf(sJH);
                            int _iCount = ltStrJH_DicLayerData.LastIndexOf(sJH) - _iJHFirstIndex;
                            float _splitfactor = 0.0F;
                            float sumHD = fListSandHD_DicLayerData.GetRange(_iJHFirstIndex, _iCount).Sum();
                            for (int ii = _iJHFirstIndex; ii < _iJHFirstIndex + _iCount; ii++)
                            {
                                if (ltStrXCM_DicLayerData[ii] == sXCM)
                                    _splitfactor = fListSandHD_DicLayerData[ii] / sumHD;

                            }

                            List<string> ltStrSplitDicWrited = new List<string>();
                            ltStrSplitDicWrited.Add(sJH);
                            ltStrSplitDicWrited.Add(sXCM);
                            ltStrSplitDicWrited.Add(sYM);
                            ltStrSplitDicWrited.Add(_splitfactor.ToString("0.00"));
                            sw.WriteLine(string.Join("\t", ltStrSplitDicWrited.ToArray()));
                        }

            }
            sw.Close();
        }

        string fileSelectLayerSplitFactor = cProjectManager.dirPathTemp + "SelectedLayerSplitFator.txt";
        //string fileDrawMapSourceFault = cProject.dirPathTemp + "Map_Fault.txt";
        private void btnSetSelectedJH_Click(object sender, EventArgs e)
        {
            //cSelect4WellSection cSelect = new cSelect4WellSection();
            //List<ItemLayerSplitFactor> listLayerSplitFator = new List<ItemLayerSplitFactor>();
            //listLayerSplitFator =cCalBase.readDicLayerSplitFactor2Struct();

            //string filePathWrited = this.fileSelectLayerSplitFactor;
            //string sJHSelected = this.cbbJH.SelectedItem.ToString();
            //string sYMselected = this.cbbYM.SelectedItem.ToString();
            //StreamWriter sw = new StreamWriter(filePathWrited, false, Encoding.UTF8);
            //for (int i = 0; i < listLayerSplitFator.Count; i++)
            //{
            //    if (listLayerSplitFator[i].sJH == sJHSelected && listLayerSplitFator[i].YYYYMM == sYMselected)
            //    {
            //        List<string> ltStrWrited = new List<string>();
            //        ltStrWrited.Add(sJHSelected);
            //        ltStrWrited.Add(listLayerSplitFator[i].sXCM);
            //        ltStrWrited.Add(sYMselected);
            //        ltStrWrited.Add(listLayerSplitFator[i].fLayerSplitFactor.ToString());
            //        sw.WriteLine(string.Join("\t", ltStrWrited.ToArray()));
            //    }
            //}
            //sw.Close();
            //cPublicMethodForm.read2DataGridViewByTextFile(fileSelectLayerSplitFactor, this.dgvLayerSplitFactor);
        }
    }
}
