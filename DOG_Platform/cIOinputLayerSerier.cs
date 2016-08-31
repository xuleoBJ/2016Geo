using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;


namespace DOGPlatform
{
     
    class cIOinputLayerSerier
    {
        //读取Layerseriers
        List<string> ltStrLayerName_layerSeriers = new List<string>();

        public static List<string> getSelectedXCMList(int _indexTopLayer, int _indexBotLayer)
        {
            return cProjectData.ltStrProjectXCM.Skip(_indexTopLayer).Take(_indexBotLayer - _indexTopLayer + 1).ToList();
        }

        public static void creatInputFaultFile(string _xcm, List<string> listLinesInput)
        {
            string filePath = Path.Combine(cProjectManager.dirPathLayerDir, _xcm, cProjectManager.fileNameInputFaults);
            cIOBase.write2file(listLinesInput, filePath);
        }

       
        public static List<ItemFaultLine> readInputFaultFile(string _xcm)
        {
            string filePath = Path.Combine(cProjectManager.dirPathLayerDir, _xcm, cProjectManager.fileNameInputFaults);
            List<ItemFaultLine> listReturn = new List<ItemFaultLine>();
            List<string> listData=cIOBase.readText2StringList(filePath, 0);
            List<ItemFaultPoint> listFaultPoints = new List<ItemFaultPoint>();
            for (int i = 0; i < listData.Count;i++ )
            {
                string[] split=listData[i].Split();
                ItemFaultPoint current = new ItemFaultPoint();
                current.sXCM = split[0];
                current.sFaultName = split[1];
                current.dbx = 0;
                double.TryParse(split[2], out current.dbx);
                current.dby = 0;
                double.TryParse(split[3], out current.dby);
                current.dbz = 0;
                listFaultPoints.Add(current);
            }

            List<string> listFaultNames = listFaultPoints.Select(p => p.sFaultName).ToList();
            foreach (string _faultName in listFaultNames)
            {
                ItemFaultLine currentLine = new ItemFaultLine();
                currentLine.sXCM = _xcm;
                currentLine.sFaultName = _faultName;
                currentLine.ltPoints = new List<PointD>();
                List<ItemFaultPoint> listPoints = listFaultPoints.FindAll(p => p.sFaultName == _faultName);
                foreach (ItemFaultPoint item in listPoints) currentLine.ltPoints.Add(new PointD(item.dbx, item.dby));
                listReturn.Add(currentLine);
            }
            

            return listReturn;
        }

    }
}
