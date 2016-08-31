using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DOGPlatform
{
    class cIODicLayerDataDynamic
    {
        public static void generateDynamicData()
        {
            //读入工程的全部井全部历史的生产动态数据 
            List<ItemInputWellProduct> listInputItemProduct = cIOinputWellProduct.readProjectFile2Struct();
            //读入工程的注入数据
            List<ItemInputWellInject> listInputItemInject = cIOInputWellInject.readProjectFile2Struct();
            //读入小层数据表数据
            List<ItemDicLayerDataStatic> listItemLayerDataStatic = cIODicLayerDataStatic.readDicLayerData2struct();

           //数据太多，按时间建立文件拆分是最好的解决办法，即避免了井分割 又避免了层分割。
            foreach (string sYM in cProjectData.ltStrProjectYM) 
            {
             //创建文件
                string filePath = Path.Combine(cProjectManager.dirPathUsedProjectData, sYM+ cProjectManager.fileExtensionDynamic);
                StreamWriter swNew = new StreamWriter(filePath, false, Encoding.UTF8);
                //写文件头
                List<string> ltStrHeadColoum = new List<string>();  //小层数据表头
                ltStrHeadColoum.Add("年月");
                ltStrHeadColoum.Add("井号");
                ltStrHeadColoum.Add("小层名");
                ltStrHeadColoum.Add("井型");
                ltStrHeadColoum.Add("射孔厚度（m）");
                ltStrHeadColoum.Add("生产天数（天）");
                ltStrHeadColoum.Add("月产油（吨）");
                ltStrHeadColoum.Add("月产水（吨）"); //顶底深TVD相减得到
                ltStrHeadColoum.Add("月产气（万方）");
                ltStrHeadColoum.Add("累产油（万吨）");
                ltStrHeadColoum.Add("累产油（万方）");
                ltStrHeadColoum.Add("累产气（万方）");
                ltStrHeadColoum.Add("月注水（方）");
                ltStrHeadColoum.Add("累注水（万方）");
                ltStrHeadColoum.Add("套压Mpa");
                ltStrHeadColoum.Add("油压Mpa");
                ltStrHeadColoum.Add("流压Mpa");
                ltStrHeadColoum.Add("静压Mpa");
                ltStrHeadColoum.Add("泵压Mpa");
                ltStrHeadColoum.Add("砂厚");
                ltStrHeadColoum.Add("有效厚度");
                ltStrHeadColoum.Add("加权孔隙度(%)");
                ltStrHeadColoum.Add("加权渗透率(md)");
                ltStrHeadColoum.Add("劈分系数");
                swNew.WriteLine(string.Join("\t", ltStrHeadColoum.ToArray()));

                foreach (string sJH in cProjectData.ltStrProjectJH)
                {
                    ItemInputWellProduct currentWellProduct = listInputItemProduct.Find(p => p.sYM == sYM&&p.sJH==sJH);
                    ItemInputWellInject currentWellInject = listInputItemInject.Find(p => p.sYM == sYM && p.sJH == sJH);
                    List<ItemDicPerforation> currentWellPerforateItems = cIOinputWellPerforation.readPerforateFile(sJH);
                    
                    //先记录未劈分的Alllayer原始数据
                    ItemDicLayerDataDynamic dicDynamicLayeritemOfALLLayer = new ItemDicLayerDataDynamic();
                    dicDynamicLayeritemOfALLLayer.sYM = sYM;
                    dicDynamicLayeritemOfALLLayer.sXCM ="AllLayer";
                    dicDynamicLayeritemOfALLLayer.sJH = sJH;
                    //从射孔中得到射孔厚度
                    dicDynamicLayeritemOfALLLayer.fSKHD = currentWellPerforateItems.FindAll(p=>int.Parse(p.YMstart) <=int.Parse(sYM) && int.Parse(sYM)<=int.Parse(p.YMend)).Select(p => p.fSKHD).Sum();

                    //静态数据表中得到砂厚、孔渗饱等基础数据
                    dicDynamicLayeritemOfALLLayer.fSH = listItemLayerDataStatic.FindAll(p => p.sJH == sJH).Select(p => p.fSH).Sum();
                    dicDynamicLayeritemOfALLLayer.fYXHD = listItemLayerDataStatic.FindAll(p => p.sJH == sJH).Select(p => p.fYXHD).Sum();
                    dicDynamicLayeritemOfALLLayer.fKXD = listItemLayerDataStatic.FindAll(p => p.sJH == sJH).Select(p => p.fKXD).Average();
                    dicDynamicLayeritemOfALLLayer.fSTL = listItemLayerDataStatic.FindAll(p => p.sJH == sJH).Select(p => p.fSTL).Average();

                    //劈分系数 整体给1
                    dicDynamicLayeritemOfALLLayer.fKHpercent = 1;
                    if (currentWellInject.sYM != null) 
                    {
                        dicDynamicLayeritemOfALLLayer.iWellType = (int)TypeWell.Injectwater;
                        dicDynamicLayeritemOfALLLayer.fSCTS = currentWellInject.fZSTS;
                        dicDynamicLayeritemOfALLLayer.fYCQ = 0;
                        dicDynamicLayeritemOfALLLayer.fYCS = 0;
                        dicDynamicLayeritemOfALLLayer.fYCY = 0;
                        dicDynamicLayeritemOfALLLayer.fLCY = 0;
                        dicDynamicLayeritemOfALLLayer.fLCS = 0;
                        dicDynamicLayeritemOfALLLayer.fLCQ = 0;
                        dicDynamicLayeritemOfALLLayer.fYZS=currentWellInject.fYZSL;
                        dicDynamicLayeritemOfALLLayer.fLZS=currentWellInject.fLZSL;
                        dicDynamicLayeritemOfALLLayer.fTY=currentWellInject.fTY;
                        dicDynamicLayeritemOfALLLayer.fLY=currentWellInject.fLY;
                        dicDynamicLayeritemOfALLLayer.fYY=currentWellInject.fYY;
                        dicDynamicLayeritemOfALLLayer.fJY=currentWellInject.fJY;
                        dicDynamicLayeritemOfALLLayer.fPY=currentWellInject.fJY;
                    }
                    else if (currentWellProduct.sYM != null)
                    {
                        dicDynamicLayeritemOfALLLayer.iWellType = (int)TypeWell.Oil;
                        dicDynamicLayeritemOfALLLayer.fSCTS = currentWellProduct.fSCTS;
                        dicDynamicLayeritemOfALLLayer.fYCQ = currentWellProduct.fYC_gas;
                        dicDynamicLayeritemOfALLLayer.fYCS = currentWellProduct.fYC_water;
                        dicDynamicLayeritemOfALLLayer.fYCY = currentWellProduct.fYC_oil;
                        dicDynamicLayeritemOfALLLayer.fLCY = currentWellProduct.fSum_oil;
                        dicDynamicLayeritemOfALLLayer.fLCS = currentWellProduct.fSum_water;
                        dicDynamicLayeritemOfALLLayer.fLCQ = currentWellProduct.fSum_gas;
                        dicDynamicLayeritemOfALLLayer.fYZS=0;
                        dicDynamicLayeritemOfALLLayer.fLZS=0;
                        dicDynamicLayeritemOfALLLayer.fTY=currentWellProduct.fTY;
                        dicDynamicLayeritemOfALLLayer.fLY=currentWellProduct.fLY;
                        dicDynamicLayeritemOfALLLayer.fYY=currentWellProduct.fYY;
                        dicDynamicLayeritemOfALLLayer.fJY=currentWellProduct.fJY;
                        dicDynamicLayeritemOfALLLayer.fPY=0;
                    }
                    else 
                    {
                            dicDynamicLayeritemOfALLLayer.iWellType = 0; //未找到井，可能停产了或者未生产
                            dicDynamicLayeritemOfALLLayer.fSCTS = 0;
                            dicDynamicLayeritemOfALLLayer.fYCQ = 0;
                            dicDynamicLayeritemOfALLLayer.fYCS =0;
                            dicDynamicLayeritemOfALLLayer.fYCY =0;
                            dicDynamicLayeritemOfALLLayer.fLCY =0;
                            dicDynamicLayeritemOfALLLayer.fLCS =0;
                            dicDynamicLayeritemOfALLLayer.fLCQ =0;
                            dicDynamicLayeritemOfALLLayer.fYZS = 0;
                            dicDynamicLayeritemOfALLLayer.fLZS = 0;
                            dicDynamicLayeritemOfALLLayer.fTY =0;
                            dicDynamicLayeritemOfALLLayer.fLY =0;
                            dicDynamicLayeritemOfALLLayer.fYY =0;
                            dicDynamicLayeritemOfALLLayer.fJY =0;
                            dicDynamicLayeritemOfALLLayer.fPY = 0;
                    }
                    swNew.WriteLine(ItemDicLayerDataDynamic.item2string(dicDynamicLayeritemOfALLLayer));

                    //将所有小层的动态字典数据item 初始化 
                    List<ItemDicLayerDataDynamic> listDynamicData = new List<ItemDicLayerDataDynamic>();
                    foreach (string xcm in cProjectData.ltStrProjectXCM)
                    {
                        ItemDicLayerDataDynamic item = new ItemDicLayerDataDynamic();
                        item.sYM = sYM;
                        item.sXCM = xcm;
                        item.sJH = sJH;
                        item.fSCTS = dicDynamicLayeritemOfALLLayer.fSCTS;
                        item.fSKHD =  currentWellPerforateItems.Find(p=>p.sXCM==xcm &&
                            int.Parse(p.YMstart) <=int.Parse(sYM) && int.Parse(sYM)<=int.Parse(p.YMend)).fSKHD;
                        item.fSH = listItemLayerDataStatic.Find(p => p.sJH == sJH && p.sXCM == xcm).fSH;
                        item.fYXHD = listItemLayerDataStatic.Find(p => p.sJH == sJH && p.sXCM == xcm).fYXHD;
                        item.fKXD = listItemLayerDataStatic.Find(p => p.sJH == sJH && p.sXCM == xcm).fKXD;
                        item.fSTL = listItemLayerDataStatic.Find(p => p.sJH == sJH && p.sXCM == xcm).fSTL;
                        item.fKHpercent = item.fSKHD * item.fSTL;
                        item.iWellType = dicDynamicLayeritemOfALLLayer.iWellType ;
                        item.fYCQ = 0;
                        item.fYCS = 0;
                        item.fYCY = 0;
                        item.fLCY = 0;
                        item.fLCS = 0;
                        item.fLCQ = 0;
                        item.fYZS = 0;
                        item.fLZS = 0;
                        item.fTY = 0;
                        item.fLY = 0;
                        item.fYY = 0;
                        item.fJY = 0;
                        item.fPY = 0;
                        listDynamicData.Add(item);
                    }//end of xcm

                    //根据劈分系数和井型 劈分数据
                    float sumKHpercent = listDynamicData.Select(p => p.fKHpercent).Sum();
                    if (sumKHpercent > 0) 
                    {
                        foreach (ItemDicLayerDataDynamic _item in listDynamicData)
                        {
                            _item.fKHpercent = _item.fKHpercent / sumKHpercent;
                            if(_item.iWellType==(int) TypeWell.Oil) 
                            {
                                _item.fYCQ = dicDynamicLayeritemOfALLLayer.fYCQ * _item.fKHpercent;
                                _item.fYCS = dicDynamicLayeritemOfALLLayer.fYCS * _item.fKHpercent;
                                _item.fYCY = dicDynamicLayeritemOfALLLayer.fYCY * _item.fKHpercent; 
                                _item.fLCY = dicDynamicLayeritemOfALLLayer.fLCY * _item.fKHpercent; 
                                _item.fLCS = dicDynamicLayeritemOfALLLayer.fLCS * _item.fKHpercent;
                                _item.fLCQ = dicDynamicLayeritemOfALLLayer.fLCY * _item.fKHpercent;
                            }
                            if (_item.iWellType == (int)TypeWell.Injectwater)
                            {
                                _item.fYZS = dicDynamicLayeritemOfALLLayer.fYZS * _item.fKHpercent;
                                _item.fLZS = dicDynamicLayeritemOfALLLayer.fLZS * _item.fKHpercent;
                            } 
                        }
                    }//end if 
                    //写每个小层的数据
                    foreach (ItemDicLayerDataDynamic _item in listDynamicData) swNew.WriteLine(ItemDicLayerDataDynamic.item2string(_item)); 
                } //end of jh
                swNew.Close();
            }//end of ym
        }
        /// <summary>
        /// 按年月提取动态数据表数据
        /// </summary>
        /// <param name="sYM"></param>
        /// <returns></returns>
        public static List<ItemDicLayerDataDynamic> readDicLayerData2struct(string sYM)
        {
            List<ItemDicLayerDataDynamic> ltReturn = new List<ItemDicLayerDataDynamic>();
            int iLineIndex = 0;
            string filePath = Path.Combine(cProjectManager.dirPathUsedProjectData, sYM + ".dym");
            if (File.Exists(filePath))
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    String line;
                    while ((line = sr.ReadLine()) != null) //delete the line whose legth is 0
                    {
                        iLineIndex++;
                        //首行是headline
                        if (iLineIndex > 1) ltReturn.Add(ItemDicLayerDataDynamic.parseLine(line));
                    }
                }
            }
            return ltReturn;
        }

        public static List<ItemDicLayerDataDynamic> readDicLayerData2struct(string sYM,string sXCM)
        {
            return readDicLayerData2struct(sYM).FindAll(p=>p.sXCM==sXCM);
        }
    }
}
