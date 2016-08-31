using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace DOGPlatform
{
    class cIOinputHorizionalWellPath
    {

        //数据采用geoearth 格式 head: JH dbX dby md
        public List<ItemHorizonalWellPath> itemsHorizonalWellPath { get; set; }
       

        public static void readInput2Project(string userInputText, string sProjectInputText)
        {
            //first 需要验证文件格式是否正确，数据格式是否正确，不正确应该放弃


        }

        public static void creatFile(string filePath)
        {
            List<string> ltStrHeadColoum = new List<string>();
            ltStrHeadColoum.Add("井号");
            ltStrHeadColoum.Add("东西X");
            ltStrHeadColoum.Add("南北Y");
            ltStrHeadColoum.Add("海拔");
            string sFirstLine = "#HorizonalWellPath";
            cIOGeoEarthText.creatFileGeoHeadText(filePath, sFirstLine, ltStrHeadColoum);
        }

        public static void write2File(string filePath, List<ItemHorizonalWellPath> listItemHorzinalWellPath)
        {

            if (!File.Exists(filePath))
            {
                creatFile(filePath);
            }
            updateFile(filePath, listItemHorzinalWellPath);
        }

        public static void updateFile(string filePath, List<ItemHorizonalWellPath> listItemHorzinalWellPath)
        {
            List<string> _ltStrJH = listItemHorzinalWellPath.Select(x => x.sJH).Distinct().ToList();
            cIOGeoEarthText.deleteLinesByFirstWordFromGeoEarTxt(filePath, _ltStrJH);
            string _sLines = "";
            foreach (ItemHorizonalWellPath _item in listItemHorzinalWellPath)
            {
                _sLines += _item.sJH + "\t";
                _sLines += _item.dbX.ToString() + "\t";
                _sLines += _item.dbY.ToString() + "\t";
                _sLines += _item.md.ToString() + "\n";
            }

            cIOGeoEarthText.addDataLines2GeoEarTxt(filePath, _sLines);

        }


    }
}
