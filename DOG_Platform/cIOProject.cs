using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace DOGPlatform
{
    class cIOProject 
    {
   
        public static List<ItemLayerSplitFactor> readDicLayerSplitFactor2Struct()
        {
            List<ItemLayerSplitFactor> listLayerSplitFactorDic = new List<ItemLayerSplitFactor>();

            int iLineIndex = 0;
            try
            {
                using (StreamReader sr = new StreamReader(cProjectManager.filePathLayerSplitFactorDic))
                {
                    String line;
                    ItemLayerSplitFactor sttLayerSplitFactor = new ItemLayerSplitFactor();
                    while ((line = sr.ReadLine()) != null) //delete the line whose legth is 0
                    {
                        iLineIndex++;
                        if (iLineIndex > 1)
                        {
                            string[] split = line.Trim().Split(new char[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
                            sttLayerSplitFactor.sJH = split[0];
                            sttLayerSplitFactor.sXCM = split[1];
                            sttLayerSplitFactor.YYYYMM = split[2];
                            sttLayerSplitFactor.fLayerSplitFactor = float.Parse(split[3]);
                            listLayerSplitFactorDic.Add(sttLayerSplitFactor);
                        }

                    }
                }
            }

            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            return listLayerSplitFactorDic;

        }
        public static List<ItemDicWellProduct> readProductionWellDic2Struct(string filePath)
        {
            List<ItemDicWellProduct> listWellProductionDicItem = new List<ItemDicWellProduct>();
            try
            {
                using (StreamReader sr = new StreamReader(filePath, Encoding.UTF8))
                {
                    String line;
                    int iLine = 0;
                    ItemDicWellProduct sttWellProductionDicItem = new ItemDicWellProduct();
                    while ((line = sr.ReadLine()) != null) //delete the line whose legth is 0
                    {
                        iLine++;
                        string[] split = line.Trim().Split(new char[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
                        if (iLine > 1)
                        {
                            sttWellProductionDicItem.sJH = split[0];
                            sttWellProductionDicItem.sYM = split[1];
                            sttWellProductionDicItem.sXCM = split[2];
                            sttWellProductionDicItem.fSCTS = float.Parse(split[3]);
                            sttWellProductionDicItem.fYC_liquid = float.Parse(split[4]);
                            sttWellProductionDicItem.fYC_oil = float.Parse(split[5]);
                            sttWellProductionDicItem.fYC_water = float.Parse(split[6]);
                            sttWellProductionDicItem.fYC_gas = float.Parse(split[7]);
                            sttWellProductionDicItem.fSum_liquid = float.Parse(split[8]);
                            sttWellProductionDicItem.fSum_oil = float.Parse(split[9]);
                            sttWellProductionDicItem.fSum_water = float.Parse(split[10]);
                            sttWellProductionDicItem.fSum_gas = float.Parse(split[11]);
                            sttWellProductionDicItem.fRC_liquid = float.Parse(split[12]);
                            sttWellProductionDicItem.fRC_oil = float.Parse(split[13]);
                            sttWellProductionDicItem.fRC_water = float.Parse(split[14]);
                            sttWellProductionDicItem.fRC_gas = float.Parse(split[15]);
                            sttWellProductionDicItem.fWaterCut = float.Parse(split[16]);
                            sttWellProductionDicItem.fGOR = float.Parse(split[17]);
                            sttWellProductionDicItem.fTY = float.Parse(split[18]);
                            sttWellProductionDicItem.fYY = float.Parse(split[19]);
                            sttWellProductionDicItem.fJY = float.Parse(split[20]);
                            sttWellProductionDicItem.fLY = float.Parse(split[21]);
                            listWellProductionDicItem.Add(sttWellProductionDicItem);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            return listWellProductionDicItem;

        }
        public static List<ItemDicWellInjection> readInjectionWellDic2Struct(string filePath)
        {
            List<ItemDicWellInjection> listWellInjectionItem = new List<ItemDicWellInjection>();
            try
            {
                using (StreamReader sr = new StreamReader(filePath, Encoding.UTF8))
                {
                    String line;
                    int iLine = 0;
                    ItemDicWellInjection sttWellInjectionItem = new ItemDicWellInjection();
                    while ((line = sr.ReadLine()) != null)  //delete the line whose legth is 0
                    {
                        iLine++;
                        string[] split = line.Trim().Split(new char[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
                        if (iLine > 1)
                        {
                            sttWellInjectionItem.sJH = split[0];
                            sttWellInjectionItem.sYM = split[1];
                            sttWellInjectionItem.sXCM = split[2];
                            sttWellInjectionItem.fZSTS = float.Parse(split[3]);
                            sttWellInjectionItem.fRZSL = float.Parse(split[4]);
                            sttWellInjectionItem.fYZSL = float.Parse(split[5]);
                            sttWellInjectionItem.fLZSL = float.Parse(split[6]);
                            sttWellInjectionItem.fLY = float.Parse(split[7]);
                            sttWellInjectionItem.fJY = float.Parse(split[8]);
                            sttWellInjectionItem.fYY = float.Parse(split[9]);
                            sttWellInjectionItem.fTY = float.Parse(split[10]);
                            sttWellInjectionItem.fPY = float.Parse(split[11]);

                            listWellInjectionItem.Add(sttWellInjectionItem);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            return listWellInjectionItem;

        }

        public static bool checkStaticCalInputFiles()
        {
            string sReturnLayerDepth = checkLayerDepthInputFiles();
            string sReturnJSJL= checkJSJLInputFiles();
            if (sReturnLayerDepth + sReturnJSJL != "") { cPublicMethodForm.outputErrInfor2Text(sReturnLayerDepth +"\r\n"+ sReturnJSJL); return false; }
            return true;
        }

        public static string checkLayerDepthInputFiles()
        {
            List<string> listJH = new List<string>();
            foreach (string _sJH in cProjectData.ltStrProjectJH)
            {
                string filePath = Path.Combine(cProjectManager.dirPathWellDir, _sJH, cProjectManager.fileNameInputLayerDepth); 
                if (File.Exists(filePath) == false && listJH.IndexOf(_sJH) <= 0) listJH.Add(_sJH);
             
            }//end for sJH
            if (listJH.Count > 0) return listJH.Count.ToString() + "口井缺失分层数据:" + string.Join("\t", listJH);
            return "";
        }

        public static string checkJSJLInputFiles()
        {
            List<string> listJH = new List<string>();
            foreach (string _sJH in cProjectData.ltStrProjectJH)
            {
                string filePath = Path.Combine(cProjectManager.dirPathWellDir, _sJH, cProjectManager.fileNameInputJSJL);
                if (File.Exists(filePath) == false && listJH.IndexOf(_sJH) <= 0) listJH.Add(_sJH);
            }//end for sJH
            if (listJH.Count > 0) return listJH.Count.ToString() + "口井缺失测井解释:" + string.Join("\t", listJH);
            return "";
        }
      
    }
}
