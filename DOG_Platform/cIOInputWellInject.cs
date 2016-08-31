using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DOGPlatform
{
    class cIOInputWellInject 
    {
        public static void creatInputFile(string _sJH, List<string> listLinesInput)
        {
            string filePath = Path.Combine(cProjectManager.dirPathWellDir, _sJH, cProjectManager.fileNameInputWellInject);
            cIOBase.write2file(listLinesInput, filePath);
        }
        public static void joinInputFileFromWellDir()
        {
            //保持合并文件名相同 仅仅是位置不同
            string fileGoalPath = Path.Combine(cProjectManager.dirPathUsedProjectData, cProjectManager.fileNameInputWellInject);
            string headline = "井号 年月 注水天数 月注水量（方） 累注水量（万方） 套压 油压 流压 静压 泵压";
            cIOBase.joinInputFileFromWellDir(fileGoalPath, cProjectManager.fileNameInputWellInject, headline);
        }
        public static List<ItemInputWellInject> readInput2Struct(string _sJH)
        {
            string filePath = Path.Combine(cProjectManager.dirPathWellDir, _sJH, cProjectManager.fileNameInputWellInject);
            List<ItemInputWellInject> listInputReturn = new List<ItemInputWellInject>();
            if (File.Exists(filePath))
            {
                List<string> ltLines = cIOBase.getListStrFromTextByFirstWord(filePath, _sJH);
                foreach (string line in ltLines)
                {
                    if (line.TrimEnd() != "")
                    {
                        ItemInputWellInject item = ItemInputWellInject.parseLine(line);
                        listInputReturn.Add(item);
                    }
                }
            }
            return listInputReturn;
        }

        public static List<ItemInputWellInject> readProjectFile2Struct()
        {
            string filePath = Path.Combine(cProjectManager.dirPathUsedProjectData, cProjectManager.fileNameInputWellInject);
            List<ItemInputWellInject> listInputReturn = new List<ItemInputWellInject>();
            int lineindex = 0;
            string[] split;
            if (File.Exists(filePath))
            {
                using (StreamReader sr = new StreamReader(filePath, Encoding.UTF8))
                {
                    String line;
                    while ((line = sr.ReadLine()) != null) //delete the line whose legth is 0
                    {
                        lineindex++;
                        split = line.Trim().Split(new char[] { ' ', '\t', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
                        if (split.Length > 0 && lineindex >= 2)
                        {
                            ItemInputWellInject item = ItemInputWellInject.parseLine(line);
                            listInputReturn.Add(item);
                        }
                    }
                }
            }//end if
            return listInputReturn;
        }

        public static List<string> getJHInjByYM(string sYM)
        {
            List<ItemInputWellInject> injItem =readProjectFile2Struct();
            return injItem.FindAll(p => p.sYM == sYM).Select(p => p.sJH).ToList();
        }
    }
}
