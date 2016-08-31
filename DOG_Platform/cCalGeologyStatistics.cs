using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace DOGPlatform
{
    class cCalGeologyStatistics:cCalBase 
    {
        float fMaxValid_Pore = 40;
         float fMinValid_Pore = 0;
         float fMaxValid_So = 40;
          public float calTk(List<float> fListSTL)
        {
            fListSTL = deleteInvalidValueInList(fListSTL);
            float fReturn = 0;
            if (fListSTL.Count > 0)
            {
                fReturn = fListSTL.Max() / fListSTL.Average();
            }
            return fReturn;
        }
        // 计算渗透率级差 最大渗透率与最小值的比值，去除无效值求平均值
        public float calJk(List<float> fListSTL)
        {
            fListSTL = deleteInvalidValueInList(fListSTL);
            float fReturn = 0;
            if (fListSTL.Count > 0)
            {
                fReturn = fListSTL.Max() / fListSTL.Min();
            }

            return fReturn;

        }
        // 计算变异系数，去除无效值求平均值
        public float calVk(List<float> fListSTL)
        {
            fListSTL = deleteInvalidValueInList(fListSTL);

            float fReturn = 0;
            if (fListSTL.Count > 0)
            {
                fReturn = 0;
                foreach (float fItem in fListSTL)
                {
                    fReturn = (float)(fReturn + Math.Pow((fItem - fListSTL.Average()), 2));
                }
                fReturn = (float)(Math.Pow(fReturn, 0.5) / fListSTL.Average());
            }

            return fReturn;
        }

        //层内非均质计算
        public void calHeterogeneityInnerLayer()
        {
            List<ItemDicLayerDataStatic> listXCSJB = cIODicLayerDataStatic.readDicLayerData2struct();
            StreamWriter sw = new StreamWriter(cProjectManager.filePathInnerLayerHeterogeneity, false, Encoding.UTF8);
            List<string> ltStrHeadColoum = new List<string>();
            //中文表头
            ltStrHeadColoum.Add("层名");
            ltStrHeadColoum.Add("钻遇井数");
            ltStrHeadColoum.Add("钻遇率");
            ltStrHeadColoum.Add("累加砂厚（m）");
            ltStrHeadColoum.Add("层段平均砂厚（m）");
            ltStrHeadColoum.Add("最大钻遇砂厚（m）");
            ltStrHeadColoum.Add("最小钻遇砂厚（m）");
           

            ltStrHeadColoum.Add("累加有效厚度（m）");
            ltStrHeadColoum.Add("层段平均有效砂厚（m）");
            ltStrHeadColoum.Add("最大有效厚度（m）");
            ltStrHeadColoum.Add("最小单层有效厚度（m）");
            

            ltStrHeadColoum.Add("Pore(最大)%");
            ltStrHeadColoum.Add("Pore(最小)%");
            ltStrHeadColoum.Add("Pore(算术平均)%");

            ltStrHeadColoum.Add("Perm最大(md)");
            ltStrHeadColoum.Add("Perm最小(md)");
            ltStrHeadColoum.Add("Perm几何平均(md)");
            ltStrHeadColoum.Add("突进系数Tk");
            ltStrHeadColoum.Add("级差Jk");
            ltStrHeadColoum.Add("变异系数Vk");

            sw.WriteLine(string.Join("\t", ltStrHeadColoum.ToArray()));

            foreach (string sCurrentXCM in cProjectData.ltStrProjectXCM) 
            {

                List<ItemDicLayerDataStatic> listXCSJB_currentLayer = listXCSJB.FindAll(p => p.sXCM == sCurrentXCM);
                int zyjs = listXCSJB_currentLayer.Count(p =>  p.fDCHD > 0);
                 
                List<string> ltStrWrited = new List<string>();
                 ltStrWrited.Add(sCurrentXCM);
                 ltStrWrited.Add(zyjs.ToString());//钻遇总井数
                if (zyjs > 0)
                {
                    float zyl = Convert.ToSingle(zyjs) / cProjectData.ltStrProjectJH.Count;
                    ltStrWrited.Add(zyl.ToString("0.000")); //钻遇率
                    float ljsh = listXCSJB_currentLayer.Sum(p => p.fSH);
                    ltStrWrited.Add(ljsh.ToString("0.00")); //砂岩总厚度
                    float pjsh = ljsh / zyjs;
                    ltStrWrited.Add(pjsh.ToString("0.00")); //平均砂厚


                    float zdzysh = listXCSJB_currentLayer.Max(p => p.fSH);
                    ltStrWrited.Add(zdzysh.ToString("0.00")); //单层砂岩最大

                    float zxzysh = 0.0f;
                    if (listXCSJB_currentLayer.Where(f => f.fSH > 0).ToList().Count > 0) zxzysh = listXCSJB_currentLayer.Where(f => f.fSH > 0).Min(p => p.fSH);
                    ltStrWrited.Add(zxzysh.ToString("0.00")); //单层砂岩最小


                    float ljyxhd = listXCSJB_currentLayer.Sum(p => p.fYXHD);
                    ltStrWrited.Add(ljyxhd.ToString("0.00")); //累积有效砂厚
                    float pjyxhd = ljyxhd / zyjs;
                    ltStrWrited.Add(pjyxhd.ToString("0.00")); //平均有效
                    float zdyxhd = listXCSJB_currentLayer.Max(p => p.fYXHD);
                    ltStrWrited.Add(zdyxhd.ToString("0.00")); //单层有效砂岩最大
                    float zxyxhd=0.0f;
                    if (listXCSJB_currentLayer.Where(f => f.fYXHD > 0).ToList().Count > 0) zxyxhd = listXCSJB_currentLayer.Where(f => f.fYXHD > 0).Min(p => p.fYXHD);
                    ltStrWrited.Add(zxyxhd.ToString("0.00")); //单层有效砂岩最小

                    List<float> fListKXD_temp = listXCSJB_currentLayer.Select(p => p.fKXD).Where(f => f > 0).ToList();
                    float zdkxd = 0.0f;
                    float zxkxd = 0.0f;
                    float pjkxd = 0.0f;
                    if (fListKXD_temp.Count > 0)
                    {
                        zdkxd = maxWithourInvalidValue(fListKXD_temp);
                        zxkxd = fListKXD_temp.Min();
                        pjkxd = meanWithourInvalidValue(fListKXD_temp);
                    }
                    ltStrWrited.Add(zdkxd.ToString("0.00")); //
                    ltStrWrited.Add(zxkxd.ToString("0.00")); //
                    ltStrWrited.Add(pjkxd.ToString("0.00"));

                    List<float> fListSTL_temp = listXCSJB_currentLayer.Select(p => p.fSTL).Where(f => f > 0).ToList();
                          float zdstl =0.0f; 
                    float zxstl =0.0f; 
                    double pjstl =0.0;
                    if (fListSTL_temp.Count > 0)
                    {
                        zdstl = maxWithourInvalidValue(fListSTL_temp);
                        zxstl = fListSTL_temp.Where(f => f > 0).Min();
                        pjstl = meanGeometricWithourInvalidValue(fListSTL_temp);
                    }
                
                    ltStrWrited.Add(zdstl.ToString("0.00")); //
                    ltStrWrited.Add(zxstl.ToString("0.00")); //
                    ltStrWrited.Add(pjstl.ToString("0.00")); //
                    double Tk = calTk(fListSTL_temp);
                    double Jk = calJk(fListSTL_temp);
                    double Vk = calVk(fListSTL_temp);
                    ltStrWrited.Add(Tk.ToString("0.00")); //
                    ltStrWrited.Add(Jk.ToString("0.00")); //
                    ltStrWrited.Add(Vk.ToString("0.00")); //


                }
                else
                {
                    ltStrWrited.Add("-999");
                }
                sw.WriteLine(string.Join("\t", ltStrWrited.ToArray()));
 

            }
            sw.Close();
            MessageBox.Show("层内非均质计算完毕");
        }
        //垂向非均质计算
        public void calHeterogeneityInterLayer()
        {
          
            StreamWriter sw = new StreamWriter(cProjectManager.filePathInterLayerHeterogeneity, false, Encoding.UTF8);
            List<string> ltStrHeadColoum = new List<string>();  
            //中文表头
            ltStrHeadColoum.Add("井名");
            ltStrHeadColoum.Add("层名");
            ltStrHeadColoum.Add("顶深(md)");
            ltStrHeadColoum.Add("底深(md)");
            ltStrHeadColoum.Add("层厚（m）");
            ltStrHeadColoum.Add("砂岩厚度（m）");
            ltStrHeadColoum.Add("有效厚度（m）");
            ltStrHeadColoum.Add("砂地比");
            ltStrHeadColoum.Add("解释砂层个数");
            ltStrHeadColoum.Add("解释油层个数");
            ltStrHeadColoum.Add("加权孔隙度(%)");
            ltStrHeadColoum.Add("孔隙度(max)%");
            ltStrHeadColoum.Add("孔隙度(min)%");
            ltStrHeadColoum.Add("孔隙度(average)%");
            ltStrHeadColoum.Add("加权渗透率(md)");
            ltStrHeadColoum.Add("渗透率(max)");
            ltStrHeadColoum.Add("渗透率(min)");
            ltStrHeadColoum.Add("渗透率(average)");
            ltStrHeadColoum.Add("突进系数Tk");
            ltStrHeadColoum.Add("渗透率级差Jk");
            ltStrHeadColoum.Add("变异系数Vk");
       
            sw.WriteLine(string.Join("\t", ltStrHeadColoum.ToArray()));
            if (cProjectData.ltStrProjectJH.Count > 0 && cProjectData.ltStrProjectXCM.Count > 0)
            {
                for (int i = 0; i < cProjectData.ltStrProjectJH.Count; i++)
                {
                    for (int j = 0; j < cProjectData.ltStrProjectXCM.Count; j++)
                    {

                        string sCurrentJH = cProjectData.ltStrProjectJH[i].ToString();
                        string sCurrentXCM = cProjectData.ltStrProjectXCM[j].ToString();
                        List<ItemDicLayerDepth> listLayerDepth = cIOinputLayerDepth.readLayerDepth2Struct(sCurrentJH);
                        List<ItemJSJL> listJSJL = cIOinputJSJL.readJSJL2Struct(sCurrentJH);

                        float fCurrentLayerDS1 = 0;//当前层位的顶面测深
                        float fCurrentLayerDS2 = 0;//当前层位的底面测深

                        float fCurrentLayerDCHD = 0; //当前层位的地层测深 需要测算

                        float fCurrentLayerSandThickness = 0;//当前层位的砂岩厚度
                        float fCurrentLayerYXHD = 0;//当前层位的有效厚度
                        int iCurrentLayerNumberOfSand = 0;//当前层位的砂层个数
                        int iCurrentLayerNumberOfOilSand = 0;//当前层位的有效砂层个数

                        float fCurrentLayerKXD = 0;//当前层位的厚度加权孔隙度
                        float fCurrentLayerSTL = 0;//当前层位的厚度加权渗透率


                        float fCurrentLayerKXD_mean = 0;//当前层位的算术平均孔隙度
                        float fCurrentLayerKXD_max = 0;//当前层位的最大孔隙度
                        float fCurrentLayerKXD_min = 0;//当前层位的最小孔隙度

                        float fCurrentLayerSTL_mean = 0;//当前层位的算术平均渗透率
                        float fCurrentLayerSTL_max = 0;//当前层位的最大渗透率
                        float fCurrentLayerSTL_min = 0;//当前层位的最小渗透率
                        float fCurrentLayerSTL_Tk = 0;//当前层位的渗透率突进系数
                        float fCurrentLayerSTL_Jk = 0;//当前层位的渗透率级差
                        float fCurrentLayerSTL_Vk = 0;//当前层位的渗透率级差
      
                        ////读取层位顶底深，获取fCurrentLayerDS1，fCurrentLayerDS2
                        bool bFoundInLayerDepth = false;
                        ItemDicLayerDepth currentLayerDepth = listLayerDepth.FirstOrDefault(p => p.sXCM == sCurrentXCM);

                        if (currentLayerDepth.sJH != null)
                        {
                            fCurrentLayerDS1 = currentLayerDepth.fDS1;
                            fCurrentLayerDS2 = currentLayerDepth.fDS2;
                            bFoundInLayerDepth = true;
                        }

                        //读取JSJL结果链表，获取fCurrentLayerKXD，fCurrentLayerSTL，fCurrentLayerBHD
                        if (bFoundInLayerDepth == true) //找到小层顶底深，才处理，否则直接跳过
                        {

                            List<float> fListSH_temp = new List<float>();
                            List<float> fListYXHD_temp = new List<float>();
                            List<float> fListKXD_temp = new List<float>();
                            List<float> fListSTL_temp = new List<float>();
                            List<float> fListBHD_temp = new List<float>();
                            foreach (ItemJSJL jsjlItem in listJSJL)
                            {
                                if (sCurrentJH == jsjlItem.sJH
                                    && fCurrentLayerDS1 <= jsjlItem.fDS1 && fCurrentLayerDS2 >= jsjlItem.fDS2)
                                {
                                    fListSH_temp.Add(jsjlItem.fSandThickness);
                                    fListYXHD_temp.Add(jsjlItem.fNetPaySand);
                                    fListKXD_temp.Add(jsjlItem.fKXD);
                                    fListSTL_temp.Add(jsjlItem.fSTL);
                                }

                            }
                      
                            {
                                fCurrentLayerDCHD = fCurrentLayerDS2 - fCurrentLayerDS1;//地层厚度
                                fCurrentLayerSandThickness = fListSH_temp.Sum();//当前层位的砂岩厚度
                                fCurrentLayerYXHD = fListYXHD_temp.Sum();//当前层位的有效厚度
                                iCurrentLayerNumberOfSand = fListSH_temp.Count;//当前层位的砂层个数
                                iCurrentLayerNumberOfOilSand = fListYXHD_temp.Count;//当前层位的有效砂层厚度
                                if (fListSH_temp.Count > 0)
                                {
                                    fCurrentLayerKXD = weightedBYThickNessWithourInvalidValue(fListKXD_temp, fListSH_temp);//当前层位的厚度加权孔隙度
                                    fCurrentLayerSTL = weightedBYThickNessWithourInvalidValue(fListSTL_temp, fListSH_temp);//当前层位的厚度加权渗透率
                                }


                                fCurrentLayerKXD_max = maxWithourInvalidValue(fListKXD_temp, fMaxValid_Pore, fMinValid_Pore);
                                fCurrentLayerKXD_min = minWithourInvalidValue(fListKXD_temp, fMaxValid_Pore, fMinValid_Pore);
                                fCurrentLayerKXD_mean = meanWithourInvalidValue(fListKXD_temp, fMaxValid_Pore, fMinValid_Pore);

                                fCurrentLayerSTL_max = maxWithourInvalidValue(fListSTL_temp);
                                fCurrentLayerSTL_min = minWithourInvalidValue(fListSTL_temp);
                                fCurrentLayerSTL_mean = meanWithourInvalidValue(fListSTL_temp);
                                fCurrentLayerSTL_Tk = calTk(fListSTL_temp);
                                fCurrentLayerSTL_Jk = calJk(fListSTL_temp);
                                fCurrentLayerSTL_Vk = calVk(fListSTL_temp);

                            }

                        }


                        List<string> ltStrWrited = new List<string>();
                        ltStrWrited.Add(sCurrentJH);
                        ltStrWrited.Add(sCurrentXCM);
                        //未在深度表中找到数据 代表本井本层位缺失
                        if (bFoundInLayerDepth == true)
                        {
                            ltStrWrited.Add(fCurrentLayerDS1.ToString("0.0"));  //顶深MD
                            ltStrWrited.Add(fCurrentLayerDS2.ToString("0.0")); //底深MD

                            ltStrWrited.Add(fCurrentLayerDCHD.ToString("0.0")); //地层厚度
                            ltStrWrited.Add(fCurrentLayerSandThickness.ToString("0.0"));
                            ltStrWrited.Add(fCurrentLayerYXHD.ToString("0.0"));

                            ltStrWrited.Add((fCurrentLayerSandThickness / fCurrentLayerDCHD).ToString("0.00")); //砂底比
                            ltStrWrited.Add(iCurrentLayerNumberOfSand.ToString()); //砂层个数
                            ltStrWrited.Add(iCurrentLayerNumberOfOilSand.ToString()); //油层个数

                            ltStrWrited.Add(fCurrentLayerKXD.ToString("0.00"));
                            ltStrWrited.Add(fCurrentLayerKXD_max.ToString("0.00"));
                            ltStrWrited.Add(fCurrentLayerKXD_min.ToString("0.00"));
                            ltStrWrited.Add(fCurrentLayerKXD_mean.ToString("0.00"));

                            ltStrWrited.Add(fCurrentLayerSTL.ToString("0.00"));
                            ltStrWrited.Add(fCurrentLayerSTL_max.ToString("0.00"));
                            ltStrWrited.Add(fCurrentLayerSTL_min.ToString("0.00"));
                            ltStrWrited.Add(fCurrentLayerSTL_mean.ToString("0.00"));
                            ltStrWrited.Add(fCurrentLayerSTL_Tk.ToString("0.00"));
                            ltStrWrited.Add(fCurrentLayerSTL_Jk.ToString("0.00"));
                            ltStrWrited.Add(fCurrentLayerSTL_Vk.ToString("0.00"));

                        }
                        else
                        {
                            ltStrWrited.Add("Mssing");
                        }

                        sw.WriteLine(string.Join("\t", ltStrWrited.ToArray()));
                    }
                }
            }
            sw.Close();
            MessageBox.Show("层间垂向非均质计算完毕");
        }
        
 
    }
}
        


