using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace DOGPlatform
{
    class cGeomodel : cCalFileBase
    {
        //对地质模型的第一次生成的层位数据进行处理，在能确认缺失的地层填充数据
        //从第一次数据的末行处理，末行-999不能代表缺失，可能是未钻遇，中间段的-999是缺失，砂厚，有效厚、地层厚0，其它值-999，插值用
        void afterDealGeomodelData()
        {

            List<string> sListLine = new List<string>();
            try
            {
                using (StreamReader sr = new StreamReader(cProject.dirPathUsedProjectData + "geoModelLayerDataStep1.txt"))
                {
                    String line;
                    int iLine = 0;
                    while ((line = sr.ReadLine()) != null) //delete the line whose legth is 0
                    {
                        iLine++;
                        if (iLine > 0)
                        {
                            sListLine.Add(line);
                            
                        }
                    }
                }
                StreamWriter sw = new StreamWriter(cProject.dirPathUsedProjectData + "geoModelLayerData.txt", false, Encoding.UTF8);
                for (int i = sListLine.Count - 1; i >= 0; i = i - 1) 
                {
                    string sLine = sListLine[i];
                    string[] splitCurrent;
                    splitCurrent = sLine.Trim().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    if (splitCurrent.Length <= 4 && i < sListLine.Count - 1) //从后往前找到-999标号的层
                    {
                        string[] splitNextLine = sListLine[i + 1].Trim().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                        if (splitNextLine.Length > 4 && splitNextLine[0] == splitCurrent[0]) 
                        {
                            List<string> sListWrited = new List<string>();
                            sListWrited.Add(splitCurrent[0]);
                            sListWrited.Add(splitCurrent[1]);
                            sListWrited.Add(splitNextLine[2]); //x
                            sListWrited.Add(splitNextLine[3]); //y
                            sListWrited.Add(splitNextLine[4]); //ds1
                            sListWrited.Add(splitNextLine[4]);//ds2
                            sListWrited.Add("0"); //shahou
                            sListWrited.Add("0"); //youxiaohoudu
                            sListWrited.Add("-999"); //kxd
                            sListWrited.Add("-999"); //stl
                            sListWrited.Add("-999"); //bhd
                            sListLine[i] = string.Join("\t", sListWrited.ToArray());
                        }
                        
                    }
                }

                foreach(string sLine in sListLine)
                {
                    sw.WriteLine(sLine);
                }
                sw.Close();
            }

            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }


        }
        //建模地质分层数据
        //public void generateGeomodelLayerData()
        //{
        //    cProject.sErrLineInfor= "";
        //    List<ItemWellHead> listWellHead = cFileOperateInputWellHead.readWellHead2Struct();
        //    readLayerDepth2List();
        //    readJSJL2List();
        //    StreamWriter sw = new StreamWriter(cProject.dirPathUsedProjectData + "geoModelLayerDataStep1.txt", false, Encoding.UTF8);
        //    //List<string> sListFileHead = new List<string>();  //小层数据表头
        //    //sListFileHead.Add("WellName");
        //    //sListFileHead.Add("LayerName");
        //    //sListFileHead.Add("X");
        //    //sListFileHead.Add("Y");
        //    //sListFileHead.Add("TopElevateDepth");
        //    //sListFileHead.Add("BottomElevateDepth");
        //    //sListFileHead.Add("SandThickness");
        //    //sListFileHead.Add("EffectiveThickness");
        //    //sListFileHead.Add("Pore-WeightBySandThickness(%)");
        //    //sListFileHead.Add("Perm-WeightBySandThickness(md)");
        //    //sListFileHead.Add("So-WeightBySandThickness(%)");
        //    //sw.WriteLine(string.Join("\t", sListFileHead.ToArray()));

        //    if (cProject.sListProjectJH.Count > 0 && cProject.sListProjectXCM.Count > 0)
        //    {
        //        for (int i = 0; i < cProject.sListProjectJH.Count; i++)
        //        {
        //            for (int j = 0; j < cProject.sListProjectXCM.Count; j++)
        //            {

        //                string sCurrentJH = cProject.sListProjectJH[i].ToString();
        //                string sCurrentXCM = cProject.sListProjectXCM[j].ToString();

        //                double dfCurrentLayerX = 0;
        //                double dfCurrentLayerY = 0;

        //                float fCurrentLayerKB = 0;//当前层位的补心海拔
        //                float fCurrentLayerDS1 = 0;//当前层位的顶面测深
        //                float fCurrentLayerDS2 = 0;//当前层位的底面测深
        //                float fCurrentLayerDCHD = 0; //当前层位的地层测深 需要测算
        //                float fCurrentLayerSandThickness = 0;//当前层位的砂岩厚度
        //                float fCurrentLayerYXHD = 0;//当前层位的有效厚度
        //                float fCurrentLayerKXD = 0;//当前层位的厚度加权孔隙度
        //                float fCurrentLayerSTL = 0;//当前层位的厚度加权渗透率
        //                float fCurrentLayerBHD = 0;//当前层位的厚度加权饱和度

        //                //根据井位数据，得到fCurrentLayerX，fCurrentLayerY，fCurrentLayerKB
        //                for (int k_wellHead = 0; k_wellHead < wellHeads.sListWellName.Count; k_wellHead++)
        //                {

        //                    if (sCurrentJH == wellHeads.sListWellName[k_wellHead].ToString())
        //                    {
        //                        dfCurrentLayerX = wellHeads.dfListX[k_wellHead];
        //                        dfCurrentLayerY = wellHeads.dfListY[k_wellHead];
        //                        fCurrentLayerKB = wellHeads.fListKB[k_wellHead];
        //                    }
        //                }
        //                //根据层位顶底深，获取fCurrentLayerDS1，fCurrentLayerDS2
        //                bool bFoundInLayerDepth = false;
        //                for (int k_layerDepth = 0; k_layerDepth < this.sListWellName_layerDepth.Count; k_layerDepth++)
        //                {

        //                    if (sCurrentJH == sListWellName_layerDepth[k_layerDepth]
        //                        && sCurrentXCM == sListLayerName_layerDepth[k_layerDepth])
        //                    {
        //                        fCurrentLayerDS1 = this.fListTopDepth_layerDepth[k_layerDepth];
        //                        fCurrentLayerDS2 = this.fListBottomDepth_layerDepth[k_layerDepth];
        //                        bFoundInLayerDepth = true;
        //                        break;
        //                    }

        //                }

        //                //读取JSJL结果链表，获取fCurrentLayerKXD，fCurrentLayerSTL，fCurrentLayerBHD
        //                if (bFoundInLayerDepth == true) //找到小层顶底深，才处理，否则直接跳过
        //                {
        //                    List<float> fListSH_temp = new List<float>();
        //                    List<float> fListYXHD_temp = new List<float>();
        //                    List<float> fListKXD_temp = new List<float>();
        //                    List<float> fListSTL_temp = new List<float>();
        //                    List<float> fListBHD_temp = new List<float>();

        //                    for (int k_JSJL = 0; k_JSJL < this.sListWellName_jsjl.Count; k_JSJL++)
        //                    {

        //                        if (sCurrentJH == sListWellName_jsjl[k_JSJL]
        //                            && fCurrentLayerDS1 <= fListTopDepth_jsjl[k_JSJL] && fCurrentLayerDS2 >= fListBottomDepth_jsjl[k_JSJL])
        //                        {
        //                            fListSH_temp.Add(fListSandHD_jsjl[k_JSJL]);
        //                            fListYXHD_temp.Add(fListSandYXHD_jsjl[k_JSJL]);
        //                            fListKXD_temp.Add(fListPore_jsjl[k_JSJL]);
        //                            fListSTL_temp.Add(fListPerm_jsjl[k_JSJL]);
        //                            fListBHD_temp.Add(fListSo_jsjl[k_JSJL]);
        //                        }

        //                    }


        //                    {
        //                        fCurrentLayerDCHD = fCurrentLayerDS2 - fCurrentLayerDS1;//地层厚度
        //                        fCurrentLayerSandThickness = fListSH_temp.Sum();//当前层位的砂岩厚度
        //                        fCurrentLayerYXHD = fListYXHD_temp.Sum();//当前层位的有效厚度
        //                        fCurrentLayerKXD = weightedBYThickNessWithourInvalidValue(fListKXD_temp, fListSH_temp);//当前层位的厚度加权孔隙度
        //                        fCurrentLayerSTL = weightedBYThickNessWithourInvalidValue(fListSTL_temp, fListSH_temp);//当前层位的厚度加权渗透率
        //                        fCurrentLayerBHD = weightedBYThickNessWithourInvalidValue(fListBHD_temp, fListSH_temp); //当前层位的厚度加权饱和度
        //                    }


        //                }

        //                List<string> sListWrited = new List<string>();
        //                sListWrited.Add(sCurrentJH);
        //                sListWrited.Add(sCurrentXCM);
        //                //未在深度表中找到数据 代表本井本层位缺失
        //                if (bFoundInLayerDepth == true)
        //                {
        //                    sListWrited.Add(dfCurrentLayerX.ToString());
        //                    sListWrited.Add(dfCurrentLayerY.ToString());
        //                    sListWrited.Add((fCurrentLayerKB - fCurrentLayerDS1).ToString()); //顶深海拔
        //                    sListWrited.Add((fCurrentLayerKB - fCurrentLayerDS2).ToString());//底深海拔
        //                    sListWrited.Add(fCurrentLayerSandThickness.ToString());
        //                    sListWrited.Add(fCurrentLayerYXHD.ToString());
        //                    sListWrited.Add(fCurrentLayerKXD.ToString("0.00"));
        //                    sListWrited.Add(fCurrentLayerSTL.ToString("0.00"));
        //                    sListWrited.Add(fCurrentLayerBHD.ToString("0.00"));
        //                }
        //                else
        //                {
        //                    sListWrited.Add("-999");
        //                }

        //                sw.WriteLine(string.Join("\t", sListWrited.ToArray()));
        //            }
        //        }
        //    }
        //    sw.Close();
        //    afterDealGeomodelData();

        //    if (cProject.sErrLineInfor== "")
        //    {
        //        MessageBox.Show("地质模型层位数据计算完毕");
        //    }
        //    else
        //    {
        //        cProject.sErrLineInfor= "地质模型层位数据可能错误：" + " \r\n" + cProject.sErrLineInfor;
        //        MessageBox.Show("计算完成，请查看错误：", "注意！");
        //        cPublicMethodForm.outputErrInfor2Text(cProject.sErrLineInfor);

        //    }
        //}
    }
}
