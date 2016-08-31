using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
namespace DOGPlatform
{
    class cIOMapLayer 
    {
         //创建geo文件 首行写 layer类型 layerID

        //从layer文件夹下的小层数据表提取绘制静态井位的cqhk数据文件
        static public void creatLayerDataGeoWellPosition(string sLayer,string sDir)
        {
            string fileName =Path.Combine(sDir, "geoWellPosion.lay");
            StreamWriter sw = new StreamWriter(fileName, false, Encoding.UTF8);
            List<ItemDicLayerDataStatic> listLayerDataSelected = cIODicLayerDataStatic.readDicLayerData2struct().FindAll(p => p.sXCM == sLayer);
            foreach (ItemDicLayerDataStatic item in listLayerDataSelected)
            {
                //由于可能计算小层数据表后又对井做修改 所以 必须判断小层数据表的井是否在项目井范围内
                if (cProjectData.ltStrProjectJH.IndexOf(item.sJH) >= 0)
                {
                    ItemWellMapPosition wellMapLayer = new ItemWellMapPosition(item);
                    sw.WriteLine(ItemWellMapPosition.item2string(wellMapLayer));
                }
            }
            sw.Close();

        }//end 静态井位

        static public List<ItemWellMapPosition> getLayerDataGeoWellPosition(string sLayer, string sDir)
        {
            List<ItemWellMapPosition> ltStrReturn = new List<ItemWellMapPosition>();
            string fileName = Path.Combine(sDir, "geoWellPosion.lay");
            int iLineIndex = 0;
            if (File.Exists(fileName))
            {
                using (StreamReader sr = new StreamReader(cProjectManager.filePathLayerDataDic))
                {
                    String line;
                    while ((line = sr.ReadLine()) != null) //delete the line whose legth is 0
                    {
                        iLineIndex++;
                        if (iLineIndex > 1) ltStrReturn.Add(ItemWellMapPosition.parseLine(line));
                    }
                }
            }
            else MessageBox.Show(fileName+"不存在");
            return ltStrReturn;

        }//end 静态井位


        //从layer文件夹下提取动态井位
        static public void creatLayerDataDynamicWellPosition(string sLayer, string sYMSelect,string sDir)
        {
            string fileName = Path.Combine(sDir, "dynWellPosion.lay");

            StreamWriter sw = new StreamWriter(fileName, false, Encoding.UTF8);
            List<ItemDicLayerDataStatic> listLayerDataSelected = cIODicLayerDataStatic.readDicLayerData2struct().FindAll(p => p.sXCM == sLayer);
            List<string> ltStrJHinjCurrentYM = cIOInputWellInject.getJHInjByYM(sYMSelect);
            List<string> ltStrJHproCurrentYM = cIOinputWellProduct.getJHProductByYM(sYMSelect);
            if (listLayerDataSelected.Count > 0)
            {
                foreach (ItemDicLayerDataStatic item in listLayerDataSelected)
                {
                    //由于可能计算小层数据表后又对井做修改 所以 必须判断小层数据表的井是否在项目井范围内
                    if (cProjectData.ltStrProjectJH.IndexOf(item.sJH) >= 0)
                    {
                        ItemWellMapPosition wellMapLayer = new ItemWellMapPosition(item);
                        if (ltStrJHinjCurrentYM.IndexOf(item.sJH) >= 0) wellMapLayer.iWellType = (int)TypeWell.Injectwater;
                        if (ltStrJHproCurrentYM.IndexOf(item.sJH) >= 0) wellMapLayer.iWellType = (int)TypeWell.Oil;
                        sw.WriteLine(ItemWellMapPosition.item2string(wellMapLayer));
                    }
                }
            }
            sw.Close();

        }//end 静态井位

       

        //从layer文件夹下提取断层数据

        //从layer文件夹下提取等值线数据

        //从layer文件下提取井点属性数据

        //从layer文件夹下的提取Voronio数据

        //从layer文件夹下的小层数据表提取生产现状
    }
}
