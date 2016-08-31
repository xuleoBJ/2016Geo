using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DOGPlatform
{
    class cIODicInjProCon 
    {
        public static void updateWellConnect() 
        {
            //读入生产和注入数据
            List<ItemInputWellProduct> productItem = cIOinputWellProduct.readProjectFile2Struct();
            List<ItemInputWellInject> injectItem = cIOInputWellInject.readProjectFile2Struct();

            //读入小层数据字典
            List<ItemDicLayerDataStatic> listLayerData = cIODicLayerDataStatic.readDicLayerData2struct();

            //读入射孔字典

            //获得年月
            string minYM = productItem.Select(p => p.sYM).Min();
            string maxYM = productItem.Select(p => p.sYM).Max();
            cProjectData.setProjectYM(minYM, maxYM);
           
            foreach(string sYM in cProjectData.ltStrProjectYM)
            {
                //按年月获得水井号，油井号
                List<ItemConnectInjPro> listItemConnect = new List<ItemConnectInjPro>();
                List<string> ltJHCurrentYMinj  = injectItem.FindAll(p => p.sYM == sYM).Select(p => p.sJH).ToList();
                List<string> ltJHCurrentYMpro = productItem.FindAll(p => p.sYM == sYM).Select(p => p.sJH).ToList();
                if ( ltJHCurrentYMinj.Count > 0)
                {  // 分析在不同层注入井和生产井的连接关系
                    foreach (string _sxcm in cProjectData.ltStrProjectXCM)
                    {
                        List<GraphEdge> listCurrentGE = cIOVoronoi.readLayerGE(_sxcm);
                        foreach (string sJHinj in ltJHCurrentYMinj)
                        {
                            //找到sJHinj的相邻井
                            int indexInjWell = cProjectData.ltStrProjectJH.IndexOf(sJHinj);
                            List<int> ltIndexProWell = new List<int>();
                            foreach (GraphEdge ge in listCurrentGE) 
                            {
                                if (ge.site1 == indexInjWell) ltIndexProWell.Add(ge.site2);
                                if (ge.site2 == indexInjWell) ltIndexProWell.Add(ge.site1); 
                            }
                            foreach (string sJHpro in ltJHCurrentYMpro)
                            {
                                ItemConnectInjPro newItem = new ItemConnectInjPro();
                                newItem.sYM = sYM;
                                newItem.sXCM = _sxcm;
                                newItem.sJHinj = sJHinj;
                                newItem.sJHpro = sJHpro;
                                newItem.factorSplit = 0.0f;
                                int indexProWell = cProjectData.ltStrProjectJH.IndexOf(sJHpro);
                                // 是否临井，voronoi图中分析，找出共边的井号
                                if (ltIndexProWell.IndexOf(indexProWell) >= 0)
                                {
                                    // 是否地质同层,在小层数据表中查找
                                    ItemDicLayerDataStatic layerDataInj = listLayerData.Find(p => p.sJH == sJHinj && p.sXCM == _sxcm);
                                    ItemDicLayerDataStatic layerDataPro = listLayerData.Find(p => p.sJH == sJHpro && p.sXCM == _sxcm);
                                    if (layerDataInj.fSH > 0 && layerDataPro.fSH > 0) newItem.factorSplit = 1.0f;
                                    // 是否同层射开

                                    //连线是否过断层
                                }
                                if (newItem.factorSplit == 1.0f) listItemConnect.Add(newItem); //只写有值的
                            }
                        }
                    } 
                }
                List<string> listLine = new List<string>();
                listLine.Add("年月 注入井号 生产井号 分配系数");
                foreach (ItemConnectInjPro item in listItemConnect) listLine.Add(ItemConnectInjPro.item2string(item));
                string fileOut = Path.Combine(cProjectManager.dirPathUsedProjectData, sYM + cProjectManager.fileExtensionConnect);
                cIOBase.write2file(listLine, fileOut);
                //输入文件
            }
        }

        public static List<ItemConnectInjPro> read2Struct(string sYM,string sXCM) 
        {
             List<ItemConnectInjPro> listReturn = new List<ItemConnectInjPro>();
             string filepath = Path.Combine(cProjectManager.dirPathUsedProjectData, sYM+ cProjectManager.fileExtensionConnect);
             foreach (string sLine in cIOBase.readText2StringList(filepath, 2)) 
             {
                 listReturn.Add(ItemConnectInjPro.parseLine(sLine));
             } 
            return listReturn.FindAll(p=>p.sXCM==sXCM);
        }

        public static List<string> getJHListProduct(string sYM, string sXCM) 
        {
          return read2Struct(sYM,sXCM).Select(p => p.sJHpro).Distinct().ToList();
        }

        public static List<string> getJHListInject(string sYM, string sXCM)
        {
            return read2Struct(sYM, sXCM).Select(p => p.sJHinj).Distinct().ToList();
        }

        
    }
}
