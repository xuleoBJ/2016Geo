using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DOGPlatform
{
    class cIOinputInjectProfile
    {
        /// <summary>
        /// 
        /// </summary>

        public static List<ItemDicInjectProfile> readInjectionProfile2Struct(string sJH)
        {
            List<ItemDicInjectProfile> listItems = new List<ItemDicInjectProfile>();
            string inputFilePath = Path.Combine(cProjectManager.dirPathWellDir, sJH, cProjectManager.fileNameWellProfile);
            if (File.Exists(inputFilePath))
            {

                List<string> ltLines = cIOGeoEarthText.getDataLineListStringFromGeoText(inputFilePath);
                foreach (string line in ltLines)
                {
                    if (line.TrimEnd() != "")
                    {
                        ItemDicInjectProfile item = ItemDicInjectProfile.parseLine(line);
                        listItems.Add(item);
                    }
                } 

            }
 
            return listItems;
        }

        public static ItemDicInjectProfile getItemByJHandXCM(string _sJH, string _xcm)
        {
            ItemDicInjectProfile itemReturn = new ItemDicInjectProfile();
            string filePath = Path.Combine(cProjectManager.dirPathWellDir, _sJH, cProjectManager.fileNameWellPerforation);
            if (File.Exists(filePath))
            {
                using (StreamReader sr = new StreamReader(filePath, Encoding.UTF8))
                {
                    String line;
                    int iLine = 0;
                    while ((line = sr.ReadLine()) != null) //delete the line whose legth is 0
                    {
                        iLine++;
                        if (iLine > 10) //geofile 从8开始
                        {
                            if (line.TrimEnd() != "")
                            {
                                ItemDicInjectProfile sttItem = ItemDicInjectProfile.parseLine(line);
                                if (sttItem.sJH != null) { if (sttItem.sJH == _sJH && sttItem.sXCM == _xcm) return sttItem; }
                            }
                        }
                    }
                }
            }
            return itemReturn;
        } 

        public static void creatFile(string filePath)
        {
            List<string> ltStrHeadColoum = new List<string>();
            ltStrHeadColoum.Add("井号");
            ltStrHeadColoum.Add("年月YYYYMM");
            ltStrHeadColoum.Add("吸水段顶深m");
            ltStrHeadColoum.Add("吸水段底深m");
            ltStrHeadColoum.Add("绝对吸水量(方)");
            string sFirstLine = DateTime.Today.ToString()+ "#InjectProFile";
            cIOGeoEarthText.creatFileGeoHeadText(filePath, sFirstLine, ltStrHeadColoum);
        }

        public static void creatInputFile(string _sJH, List<string> listLinesInput)
        {
            string filePath = Path.Combine(cProjectManager.dirPathWellDir, _sJH, cProjectManager.fileNameInputWellProfile);
            cIOBase.write2file(listLinesInput, filePath);
        }

        struct itemInputProfile 
        {
            public string sJH;
            public string sYM;
            public float fDS1;
            public float fDS2;
            public float fZRL; 
        }


         static List<itemInputProfile> readInputFile(string _sJH) 
        {
            List<itemInputProfile> listInputItem = new List<itemInputProfile>();

            string inputFilePath =
                      Path.Combine(cProjectManager.dirPathWellDir, _sJH, cProjectManager.fileNameInputWellProfile);
            if (File.Exists(inputFilePath))
            {
                using (StreamReader sr = new StreamReader(inputFilePath))
                {
                    String line;
                    int _indexLine = 0;
                    while ((line = sr.ReadLine()) != null) //delete the line whose legth is 0
                    {
                        _indexLine++;
                        itemInputProfile currentItem = new itemInputProfile();
                        string[] split = line.Trim().Split(new char[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
                        if (_indexLine >= 1)
                        {
                            currentItem.sJH = split[0];
                            currentItem.sYM = split[1];
                            currentItem.fDS1 = 0.0f;
                            float.TryParse(split[2], out currentItem.fDS1);
                            currentItem.fDS2 = 0.0f;
                            float.TryParse(split[3], out currentItem.fDS2);
                            currentItem.fZRL = 0.0f;
                            float.TryParse(split[4], out currentItem.fZRL);
                            listInputItem.Add(currentItem);
                        }
                    }
                }
            }
            return listInputItem;
        }
        public static void creatWellGeoFile(string _sJH)
        {
            creatWellGeoHeadFile(_sJH);
            List<ItemDicInjectProfile> listInjectionProfile = new List<ItemDicInjectProfile>();
            List<itemInputProfile> listInputProfile = readInputFile(_sJH);
            foreach (string _YM in listInputProfile.Select(p=>p.sYM).Distinct()) 
            {
                List<itemInputProfile> listInputCurrentYM = listInputProfile.FindAll(p => p.sYM == _YM);
                float fZZRL = listInputCurrentYM.Sum(p => p.fZRL); ; //当前年月总注入量
                foreach (itemInputProfile _item in listInputCurrentYM) 
                { 
                    ItemDicInjectProfile itemOut = new ItemDicInjectProfile();
                    itemOut.sJH = _item.sJH;
                    itemOut.sYM = _item.sYM;
                    itemOut.fDS1 = _item.fDS1;
                    itemOut.fDS2 = _item.fDS2;
                    itemOut.fZRL = _item.fZRL;
                    itemOut.fPercentZR = (_item.fZRL / fZZRL)*100;
                    itemOut.fXSHD = _item.fDS2 - _item.fDS1;
                    itemOut.FXSQD = _item.fZRL / itemOut.fXSHD;
                    itemOut.sXCM = cIOinputLayerDepth.getXCMByJHAndDepthInterval(_sJH, _item.fDS1, _item.fDS2);
                    listInjectionProfile.Add(itemOut);
                }

            }
            List<string> ltStrLine = new List<string>();
            foreach (ItemDicInjectProfile _item in listInjectionProfile)
            {
                ltStrLine.Add(ItemDicInjectProfile.item2string(_item));
            }
            string filePath = Path.Combine(cProjectManager.dirPathWellDir, _sJH, cProjectManager.fileNameWellProfile);
            cIOGeoEarthText.addDataLines2GeoEarTxt(filePath, ltStrLine); 
        }
        public static void creatWellGeoFile()
        {
            foreach (string _sJH in cProjectData.ltStrProjectJH) creatWellGeoFile(_sJH);
        }
        public static void creatWellGeoHeadFile(string sJH)
        {
            string inputFilepath = Path.Combine(cProjectManager.dirPathWellDir, sJH, cProjectManager.fileNameWellProfile);
            List<string> ltStrHeadColoum = new List<string>();
            ltStrHeadColoum.Add("井号");
            ltStrHeadColoum.Add("年月");
            ltStrHeadColoum.Add("顶深m");
            ltStrHeadColoum.Add("底深m");
            ltStrHeadColoum.Add("绝对吸水量(方)");
            ltStrHeadColoum.Add("相对注入%");
            ltStrHeadColoum.Add("吸水厚度");
            ltStrHeadColoum.Add("吸水强度");
            ltStrHeadColoum.Add("小层");
            string sFirstLine = DateTime.Today.ToString()+"$WellProfile";
            cIOGeoEarthText.creatFileGeoHeadText(inputFilepath, sFirstLine, ltStrHeadColoum);
        }

        public static void selectSectionDrawData2File(string sJH, string filePath)
        {
            StreamWriter sw = new StreamWriter(filePath, false, Encoding.UTF8);
            string sReturn = "";
            foreach (var item in readInjectionProfile2Struct(sJH))
                sReturn += ItemDicInjectProfile.item2string(item) + "\t";
            sw.Write(sReturn);
            sw.Close();
        }


        public void selectSection2File(string sJH, string filePath)
        {
            StreamWriter sw = new StreamWriter(filePath, false, Encoding.UTF8);
            string sReturn = ""; 
              foreach (var item in readInjectionProfile2Struct(sJH))
             {
                 sReturn = sReturn +" "+ ItemDicInjectProfile.item2string(item);
             }

              sw.Write(sReturn);
            sw.Close();
        }

      
    }
}
