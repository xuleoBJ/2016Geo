using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace DOGPlatform
{
    class cIODicLayerDataStatic : cCalBase
    {
        public void generateLayerData()
        {
            //更新算法，保证计算后的数据字典完善：
            //如果这口井有有效厚度而没有孔隙度，渗透率，饱和度，那么找临近的几口井，根据厚度相近的原则，取孔隙度，渗透率
            //数据缺失的先用地层厚度为-999填充标记，然后正着扫一遍，再反着扫一遍 把所有的值填充合理
            List<ItemDicLayerDataStatic> listLayerDataDic = new List<ItemDicLayerDataStatic>();

            if (cProjectData.ltStrProjectJH.Count > 0 && cProjectData.ltStrProjectXCM.Count > 0)
            {
                for (int i = 0; i < cProjectData.ltStrProjectJH.Count; i++)
                {
                    for (int j = 0; j < cProjectData.ltStrProjectXCM.Count; j++)
                    {
                        string sCurrentJH = cProjectData.ltStrProjectJH[i].ToString();
                        string sCurrentXCM = cProjectData.ltStrProjectXCM[j].ToString();
                        ItemWellHead currentWellHead = cIOinputWellHead.getWellHeadByJH(sCurrentJH);
                        List<ItemDicLayerDepth> listLayerDepth = cIOinputLayerDepth.readLayerDepth2Struct(sCurrentJH);
                        List<ItemJSJL> listJSJL = cIOinputJSJL.readJSJL2Struct(sCurrentJH);

                        double dfCurrentLayerX = 0;
                        double dfCurrentLayerY = 0;
                        double dfCurrentLayerZ = 0;

                        float fCurrentLayerDS1 = 0;//当前层位的顶面测深
                        float fCurrentLayerDS2 = 0;//当前层位的底面测深
                        float fCurrentLayerTVD = 0;//顶面TVD
                        float fCurrentLayerDCHD = -999; //当前层位的地层测深 需要测算 -999代表缺失
                        float fCurrentLayerSandThickness = -999;//当前层位的砂岩厚度
                        float fCurrentLayerYXHD = 0;//当前层位的有效厚度

                        float fCurrentLayerKXD = 0;//当前层位的厚度加权孔隙度
                        float fCurrentLayerSTL = 0;//当前层位的厚度加权渗透率
                        float fCurrentLayerBHD = 0;//当前层位的厚度加权饱和度
                                    
                          
                        //读取层位顶底深，获取fCurrentLayerDS1，fCurrentLayerDS2
                        //没找到的情况要重新考虑下！
                       bool bFoundInLayerDepth = false;
                       ItemDicLayerDepth currentLayerDepth = listLayerDepth.Find(p => p.sJH == sCurrentJH && p.sXCM == sCurrentXCM);

                       if (currentLayerDepth.sJH != null && currentLayerDepth.fDS1 <= currentLayerDepth.fDS2)
                       {
                            fCurrentLayerDS1 = currentLayerDepth.fDS1;
                            ItemDicWellPath currentDS1WellPathItem = cIOinputWellPath.getWellPathItemByJHAndMD(sCurrentJH, fCurrentLayerDS1);
                            ItemDicWellPath currentDS2WellPathItem = cIOinputWellPath.getWellPathItemByJHAndMD(sCurrentJH, fCurrentLayerDS2); 
                            fCurrentLayerDS2 = currentLayerDepth.fDS2;
                            dfCurrentLayerX = currentDS1WellPathItem.dbX;
                            dfCurrentLayerY = currentDS1WellPathItem.dbY;
                            dfCurrentLayerZ = currentDS1WellPathItem.dfZ;
                            fCurrentLayerTVD = currentDS1WellPathItem.f_TVD;
                            fCurrentLayerDCHD = currentDS2WellPathItem.f_TVD - currentDS1WellPathItem.f_TVD;
                            bFoundInLayerDepth = true;
                        }
                       
                        //读取JSJL结果链表，获取fCurrentLayerKXD，fCurrentLayerSTL，fCurrentLayerBHD
                        if (bFoundInLayerDepth == true) //找到小层顶底深，才处理，否则直接跳过
                        {
                            List<ItemJSJL> listCurrentWellJSJL = listJSJL.Where(p => p.sJH == sCurrentJH && p.fDS1 >= fCurrentLayerDS1 && p.fDS2 <= fCurrentLayerDS2).ToList();

                            List<float> fListSH_temp = new List<float>();
                            List<float> fListYXHD_temp = new List<float>();
                            List<float> fListKXD_temp = new List<float>();
                            List<float> fListSTL_temp = new List<float>();
                            List<float> fListBHD_temp = new List<float>();

                            foreach (ItemJSJL item in listCurrentWellJSJL)
                            {
                                fListSH_temp.Add(item.fSandThickness);
                                fListYXHD_temp.Add(item.fNetPaySand );
                                fListKXD_temp.Add(item.fKXD);
                                fListSTL_temp.Add(item.fSTL);
                                fListBHD_temp.Add(item.fBHD);
                       
                            }

                            {
                                fCurrentLayerDCHD = fCurrentLayerDS2 - fCurrentLayerDS1;//地层厚度
                                fCurrentLayerSandThickness = fListSH_temp.Sum();//当前层位的砂岩厚度
                                fCurrentLayerYXHD = fListYXHD_temp.Sum();//当前层位的有效厚度

                                fCurrentLayerKXD = weightedBYThickNessWithourInvalidValue(fListKXD_temp, fListSH_temp);//当前层位的厚度加权孔隙度
                                fCurrentLayerSTL = weightedBYThickNessWithourInvalidValue(fListSTL_temp, fListSH_temp);//当前层位的厚度加权渗透率
                                fCurrentLayerBHD = weightedBYThickNessWithourInvalidValue(fListBHD_temp, fListSH_temp); //当前层位的厚度加权饱和度
                            }

                        }

                        //写小层数据表

                        ItemDicLayerDataStatic itemLayerData = new ItemDicLayerDataStatic();
                        itemLayerData.sJH = sCurrentJH;
                        itemLayerData.sXCM = sCurrentXCM;
                       

                        //在LayerDepth表中找到数据层段的顶底
                        if (bFoundInLayerDepth == true)
                        {
                            itemLayerData.dbX = dfCurrentLayerX;
                            itemLayerData.dbY = dfCurrentLayerY;
                            itemLayerData.dfZ = dfCurrentLayerZ;
                            itemLayerData.fDCHD = fCurrentLayerDCHD;
                            itemLayerData.fSH = fCurrentLayerSandThickness;
                            itemLayerData.fYXHD = fCurrentLayerYXHD;
                            itemLayerData.fKXD = fCurrentLayerKXD;
                            itemLayerData.fSTL = fCurrentLayerSTL;
                            itemLayerData.fBHD = fCurrentLayerBHD;
                            itemLayerData.fDS1_md = fCurrentLayerDS1;
                            itemLayerData.fDS2_md = fCurrentLayerDS2;
                            itemLayerData.fDS1_TVD = fCurrentLayerTVD;

                        }
                        else //未在LayerDepth表中找到数据 代表本井本层位缺失
                        {
                            itemLayerData.dbX = 0.0;
                            itemLayerData.dbY = 0.0;
                            itemLayerData.dfZ = 0.0;
                            itemLayerData.fDCHD = -999;
                            itemLayerData.fSH =-999;
                            itemLayerData.fYXHD = 0;
                            itemLayerData.fKXD = -999;
                            itemLayerData.fSTL = -999;
                            itemLayerData.fBHD = -999;
                            itemLayerData.fDS1_md = -999;
                            itemLayerData.fDS2_md = -999;
                            itemLayerData.fDS1_TVD =-999;
                        }
                        listLayerDataDic.Add(itemLayerData);
                    }
                }
            }

            //正一遍 倒一遍，完善小层数据表

            for (int i = 0; i < listLayerDataDic.Count-1; i++) 
            {
                ItemDicLayerDataStatic currentItem = listLayerDataDic[i];
                if (currentItem.fDCHD < 0&&currentItem.sJH==listLayerDataDic[i+1].sJH) 
                {
                    ItemDicLayerDataStatic nextItem=listLayerDataDic[i+1];
                    currentItem.dbX = nextItem.dbX;
                    currentItem.dbY = nextItem.dbY;
                    currentItem.dfZ = nextItem.dfZ+nextItem.fDCHD;
                    currentItem.fDS1_md = nextItem.fDS1_md;
                    currentItem.fDS2_md = nextItem.fDS2_md;
                    currentItem.fDS1_TVD = nextItem.fDS1_TVD;
                    currentItem.fDCHD = 0;
                    currentItem.fSH = 0;
                }
                listLayerDataDic[i] = currentItem;
            }
          
            //完善 小层 孔渗为无效值的情况
            for (int i = 0; i < listLayerDataDic.Count ; i++)
            {
                ItemDicLayerDataStatic currentItem = listLayerDataDic[i];
                if (currentItem.fDCHD < 0 && currentItem.sJH == listLayerDataDic[i + 1].sJH)
                {
                    ItemDicLayerDataStatic nextItem = listLayerDataDic[i + 1];
                    currentItem.dbX = nextItem.dbX;
                    currentItem.dbY = nextItem.dbY;
                    currentItem.dfZ = nextItem.dfZ + nextItem.fDCHD;
                    currentItem.fDS1_md = nextItem.fDS1_md;
                    currentItem.fDS2_md = nextItem.fDS2_md;
                    currentItem.fDS1_TVD = nextItem.fDS1_TVD;
                    currentItem.fDCHD = 0;
                    currentItem.fSH = 0;
                }
                listLayerDataDic[i] = currentItem;
            }
            for (int i = listLayerDataDic.Count - 1; i > 0; i--)
            {
                ItemDicLayerDataStatic currentItem = listLayerDataDic[i];
                if (currentItem.fSH > 0 && (currentItem.fKXD <= 0 || currentItem.fSTL <= 0)) //有砂厚，砂厚大于0的必须有孔隙度和渗透率，用于产量劈分，储量计算
                {
                    //从 listLayerDataDic中选择,无值的取层段平均值
                    List<ItemDicLayerDataStatic> listCurrentLayer = listLayerDataDic.FindAll(p => p.sXCM == currentItem.sXCM).ToList();
                    if (listCurrentLayer.Count > 0)
                    {
                        if (currentItem.fKXD <= 0 && listCurrentLayer.FindAll(p => p.fKXD > 0).Count > 0) currentItem.fKXD = listCurrentLayer.FindAll(p => p.fKXD > 0).Select(p => p.fKXD).Average();
                        if (currentItem.fSTL <= 0 && listCurrentLayer.FindAll(p => p.fSTL > 0).Count > 0) currentItem.fSTL = listCurrentLayer.FindAll(p => p.fSTL > 0).Select(p => p.fSTL).Average();
                    }
                }
                listLayerDataDic[i] = currentItem;
            }

            write2File(cProjectManager.filePathLayerDataDic,listLayerDataDic);
            // Format and display the TimeSpan value.
        }

        public static List<ItemDicLayerDataStatic> readDicLayerData2struct()
        {
            List<ItemDicLayerDataStatic> ltStrReturn = new List<ItemDicLayerDataStatic>();
            int iLineIndex = 0;
            if(File.Exists(cProjectManager.filePathLayerDataDic)){
                using (StreamReader sr = new StreamReader(cProjectManager.filePathLayerDataDic))
                {
                    String line;
                    while ((line = sr.ReadLine()) != null) //delete the line whose legth is 0
                    {
                        iLineIndex++;
                        if (iLineIndex > 1) ltStrReturn.Add(ItemDicLayerDataStatic.parseLine(line));
                    }
                }
            }
            else
            {
                MessageBox.Show("请先计算小层数据表。");
            }
            
            return ltStrReturn;
        }

        public static List<ItemDicLayerDataStatic> getListLayerDataDicItemFromLayerDataDicByXCM(string sXCM)
        {
            List<ItemDicLayerDataStatic> ltStrReturn = new List<ItemDicLayerDataStatic>();
            string[] split;
            int iLineIndex = 0;

            using (StreamReader sr = new StreamReader(cProjectManager.filePathLayerDataDic))
            {
                String line;

                while ((line = sr.ReadLine()) != null) //delete the line whose legth is 0
                {
                    iLineIndex++;
                    ItemDicLayerDataStatic sttLayerDataDicItem = new ItemDicLayerDataStatic();
                    split = line.Trim().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    if (iLineIndex > 1 && split.Count() >= 12 && split[1] == sXCM)
                    {

                        sttLayerDataDicItem.sJH = split[0];
                        sttLayerDataDicItem.sXCM = split[1];

                        sttLayerDataDicItem.dbX = double.Parse(split[2]);
                        sttLayerDataDicItem.dbY = double.Parse(split[3]);
                        sttLayerDataDicItem.dfZ = double.Parse(split[4]);

                        sttLayerDataDicItem.fSH = float.Parse(split[5]);
                        sttLayerDataDicItem.fYXHD = float.Parse(split[6]);

                        sttLayerDataDicItem.fKXD = float.Parse(split[7]);
                        sttLayerDataDicItem.fSTL = float.Parse(split[8]);
                        sttLayerDataDicItem.fBHD = float.Parse(split[9]);
                        sttLayerDataDicItem.fDS1_md = float.Parse(split[10]);
                        sttLayerDataDicItem.fDS2_md = float.Parse(split[11]);
                        sttLayerDataDicItem.fDS1_TVD  = float.Parse(split[12]);

                    }

                }
            }



            return ltStrReturn;
        }

        public static ItemDicLayerDataStatic getLayerDataDicItemFromLayerDataDicByXCMAndJH(string sJH,string sXCM)
        {
            ItemDicLayerDataStatic sttLayerDataDicItem = new ItemDicLayerDataStatic();
            string[] split;
            int iLineIndex = 0;

            using (StreamReader sr = new StreamReader(cProjectManager.filePathLayerDataDic))
            {
                String line;

                while ((line = sr.ReadLine()) != null) //delete the line whose legth is 0
                {
                    iLineIndex++;
                    
                    split = line.Trim().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    if (iLineIndex > 1 && split.Count() >= 12 && split[1] == sXCM && split[0]==sJH)
                    {

                        sttLayerDataDicItem.sJH = split[0];
                        sttLayerDataDicItem.sXCM = split[1];

                        sttLayerDataDicItem.dbX = double.Parse(split[2]);
                        sttLayerDataDicItem.dbY = double.Parse(split[3]);
                        sttLayerDataDicItem.dfZ = double.Parse(split[4]);

                        sttLayerDataDicItem.fSH = float.Parse(split[5]);
                        sttLayerDataDicItem.fYXHD = float.Parse(split[6]);

                        sttLayerDataDicItem.fKXD = float.Parse(split[7]);
                        sttLayerDataDicItem.fSTL = float.Parse(split[8]);
                        sttLayerDataDicItem.fBHD = float.Parse(split[9]);
                        sttLayerDataDicItem.fDS1_md = float.Parse(split[10]);
                        sttLayerDataDicItem.fDS2_md = float.Parse(split[11]);

                    }

                }
            }



            return sttLayerDataDicItem;
        }
        /// <summary>
        /// 根据井号列表和小层名从LayerDateDic中选择数据
        /// </summary>
        /// <param name="sXCM">小层名</param>
        /// <param name="ltStrsJH">井号列表</param>
        /// <param name="filePathWrited">文件路径</param>
        public void selectDataFromDicLayerDataByXCMAndJH(string sXCM, List<string> ltStrsJH, string filePathWrited)
        {
            List<ItemDicLayerDataStatic> listDicLayerData = readDicLayerData2struct();
            List<ItemDicLayerDataStatic> listDicLayerDataSelected = listDicLayerData.Where(p => p.sXCM == sXCM
                && ltStrsJH.Contains(p.sJH)).ToList();
            write2File(filePathWrited, listDicLayerDataSelected);
            
        }

        /// <summary>
        /// 根据井号和小层名从LayerDateDic中选择数据
        /// </summary>
        /// <param name="sJH">井号</param>
        /// <param name="sXCM">小层名</param>
        /// <returns></returns>
        public List<ItemDicLayerDataStatic> selectSingleWellDataFromDicLayerDataByJHAndXCM(string sJH, string sXCM)
        {
            List<ItemDicLayerDataStatic> listDicLayerData = readDicLayerData2struct();
            List<ItemDicLayerDataStatic> listDicLayerDataSelected = listDicLayerData.Where(p => p.sXCM == sXCM
                && p.sJH == sJH).ToList();
            return listDicLayerDataSelected;

        }

        public void write2File(string filePath,List<ItemDicLayerDataStatic> listLayerDataDic)
        {
            StreamWriter sw = new StreamWriter(filePath, false, Encoding.UTF8);
              List<string> ltStrHeadColoum = new List<string>();  //小层数据表头
            ltStrHeadColoum.Add("井号");
            ltStrHeadColoum.Add("小层名");
            ltStrHeadColoum.Add("X");
            ltStrHeadColoum.Add("Y");
            ltStrHeadColoum.Add("Z");
            ltStrHeadColoum.Add("地层垂厚(m)"); //顶底深TVD相减得到
            ltStrHeadColoum.Add("砂厚");
            ltStrHeadColoum.Add("有效厚度");
            ltStrHeadColoum.Add("加权孔隙度(%)");
            ltStrHeadColoum.Add("加权渗透率(md)");
            ltStrHeadColoum.Add("加权饱和度(%)");
            ltStrHeadColoum.Add("顶深md(m)");
            ltStrHeadColoum.Add("底深md(m)");
            ltStrHeadColoum.Add("顶深TVD(m)");
            sw.WriteLine(string.Join("\t", ltStrHeadColoum.ToArray()));
            foreach (ItemDicLayerDataStatic item in listLayerDataDic)
            {
                List<string> ltStrWrited = new List<string>();
                ltStrWrited.Add(item.sJH);
                ltStrWrited.Add(item.sXCM);
                ltStrWrited.Add(item.dbX.ToString("0.0"));
                ltStrWrited.Add(item.dbY.ToString("0.0"));
                ltStrWrited.Add(item.dfZ.ToString("0.0")); //顶深海拔
                ltStrWrited.Add(item.fDCHD.ToString("0.0"));
                ltStrWrited.Add(item.fSH.ToString("0.0"));
                ltStrWrited.Add(item.fYXHD.ToString());
                ltStrWrited.Add(item.fKXD.ToString("0.0"));
                ltStrWrited.Add(item.fSTL.ToString("0.0"));
                ltStrWrited.Add(item.fBHD.ToString("0.0"));

                ltStrWrited.Add(item.fDS1_md.ToString("0.0"));  //顶深MD
                ltStrWrited.Add(item.fDS2_md.ToString("0.0")); //底深MD
                ltStrWrited.Add(item.fDS1_TVD.ToString("0.0")); //底深MD
                sw.WriteLine(string.Join("\t", ltStrWrited.ToArray()));
            }
            sw.Close();
        }
        public  static List<ItemWellLayerGeologyProperty> selectWellLayerGeologyPropery(string sXCM)
        {
            List<ItemWellLayerGeologyProperty> listReturnWellLayerGeologyProperty = new List<ItemWellLayerGeologyProperty>();
            try
            {
                using (StreamReader sr = new StreamReader(cProjectManager.filePathLayerDataDic, Encoding.UTF8))
                {
                    String line;
                    int iLine = 0;
                    while ((line = sr.ReadLine()) != null)  //delete the line whose legth is 0
                    {
                        iLine++;
                        ItemWellLayerGeologyProperty sttWellLayerGeologyProperty = new ItemWellLayerGeologyProperty();
                        string[] split = line.Trim().Split(new char[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
                        if (iLine > 1 && split[1] == sXCM)
                        {
                            sttWellLayerGeologyProperty.sJH = split[0];
                            sttWellLayerGeologyProperty.sXCM = sXCM;
                            sttWellLayerGeologyProperty.fSH = float.Parse(split[5]);
                            sttWellLayerGeologyProperty.fYXHD = float.Parse(split[6]);
                            sttWellLayerGeologyProperty.fSTL = float.Parse(split[8]);
                            listReturnWellLayerGeologyProperty.Add(sttWellLayerGeologyProperty);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            return listReturnWellLayerGeologyProperty;
        }

       
    }
}
