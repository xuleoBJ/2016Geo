using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
namespace DOGPlatform
{
    class cIODicLogHeadProject 
    {
        public static List<ItemDicLogGlobe> readDicGlobeLog()
        {
            string filePathDic = Path.Combine(cProjectManager.dirPathUserData, "ItemLogHead.txt");
            if (!File.Exists(filePathDic))
                File.Copy(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "code", "ItemLogHead.txt"), filePathDic);
            List<ItemDicLogGlobe> listItemLogHeadInfors = new List<ItemDicLogGlobe>();
            try
            {
                using (StreamReader sr = new StreamReader(filePathDic, System.Text.Encoding.UTF8))
                {
                    String line;
                    while ((line = sr.ReadLine()) != null) //delete the line whose legth is 0
                    {
                        string[] split = line.Trim().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                        if (split.Length >= 9)
                        {
                            ItemDicLogGlobe logItem = new ItemDicLogGlobe(split[0]);
                            logItem.sLogText = split[1];
                            logItem.sUnit = split[2];
                            logItem.sLogColor = split[3];
                            logItem.fLeftValue = float.Parse(split[4]);
                            logItem.fRightValue = float.Parse(split[5]);
                            logItem.iIsLog = int.Parse(split[6]);
                            logItem.fLineWidth = float.Parse(split[7]);
                            logItem.iLineType = int.Parse(split[8]);
                            listItemLogHeadInfors.Add(logItem);
                        }  
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            return listItemLogHeadInfors;
        }
        public static void writeDicGlobe(List<ItemDicLogGlobe> listDicLogGlobe) 
        {
            string filePathDic = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "code", "ItemLogHead.txt");
            List<string> listLine = new List<string>();
            foreach (ItemDicLogGlobe item in listDicLogGlobe) listLine.Add(ItemDicLogGlobe.item2Line(item));
            cIOBase.write2file(listLine, filePathDic);
        }
        public static List<ItemLogHeadInfor> readLogDic2Struct(string filePath) 
        {
            List<ItemLogHeadInfor> listItemLogHeadInfors = new List<ItemLogHeadInfor>();
            try
            {
                using (StreamReader sr = new StreamReader(filePath, System.Text.Encoding.UTF8))
                {
                    String line;
                    while ((line = sr.ReadLine()) != null) //delete the line whose legth is 0
                    {
                        ItemLogHeadInfor logItem = new ItemLogHeadInfor();
                        string[] split = line.Trim().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                        logItem.sJH = split[0];
                        logItem.sLogName = split[2];
                        logItem.sUnit = split[3];
                        logItem.fLeftValue = float.Parse(split[4]);
                        logItem.fRightValue = float.Parse(split[5]);
                        logItem.iIsLog = int.Parse(split[6]);
                        logItem.sLogColor = split[7];
                        logItem.fLineWidth = float.Parse(split[8]);
                        logItem.iLineType = int.Parse(split[9]);
                        listItemLogHeadInfors.Add(logItem);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            return listItemLogHeadInfors;
        }
        public ItemLogHeadInfor selectLogHeadItem(string sJH, string sLogName)
        {
            ItemLogHeadInfor itemHeadInfor = new ItemLogHeadInfor();
            itemHeadInfor.sJH = sJH;
            itemHeadInfor.sLogName = sLogName;
            itemHeadInfor.sLogColor = "red";
            itemHeadInfor.fRightValue = 100.0f;
            itemHeadInfor.fLeftValue = 0.0f;
            return itemHeadInfor;
        }
      
    }
}



