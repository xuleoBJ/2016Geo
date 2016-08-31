using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DOGPlatform
{
    class cIOinputWellProduct : cIOBase
    {
        public static void creatInputFile(string _sJH, List<string> listLinesInput)
        {
            string filePath = Path.Combine(cProjectManager.dirPathWellDir, _sJH, cProjectManager.fileNameInputWellProduct);
            cIOBase.write2file(listLinesInput, filePath);
        }

        public static void joinInputFileFromWellDir()
        {
            string fileGoalPath = Path.Combine(cProjectManager.dirPathUsedProjectData, cProjectManager.fileNameInputWellProduct);
            string headline = "井号 年月 生产天数 月产油（吨） 月产水（方）月产气（万方）累产油（万吨） 累产水（万方） 累产气（万方） 套压 油压 流压 静压";
            cIOBase.joinInputFileFromWellDir(fileGoalPath, cProjectManager.fileNameInputWellProduct,headline);
        }

        public static List<ItemInputWellProduct> readInput2Struct(string _sJH)
        {
            string filePath = Path.Combine(cProjectManager.dirPathWellDir, _sJH, cProjectManager.fileNameInputWellProduct);
            List<ItemInputWellProduct> listInputReturn = new List<ItemInputWellProduct>();
            if (File.Exists(filePath))
            {
                List<string> ltLines = cIOBase.getListStrFromTextByFirstWord(filePath, _sJH);
                foreach (string line in ltLines)
                {
                    if (line.TrimEnd() != "")
                    {
                        ItemInputWellProduct item = ItemInputWellProduct.parseLine(line);
                       listInputReturn.Add(item);
                    }
                }
            }
            return listInputReturn;
        }

        public static List<ItemInputWellProduct> readProjectFile2Struct()
        {
            string filePath = Path.Combine(cProjectManager.dirPathUsedProjectData, cProjectManager.fileNameInputWellProduct);
            List<ItemInputWellProduct> listInputReturn = new List<ItemInputWellProduct>();
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
                            ItemInputWellProduct item = ItemInputWellProduct.parseLine(line);
                            listInputReturn.Add(item); 
                        }
                    }
                }
            }//end if
            return listInputReturn;
        }

        public static List<string> getJHProductByYM(string sYM) 
        {
            List<ItemInputWellProduct> productItem = cIOinputWellProduct.readProjectFile2Struct();
            return productItem.FindAll(p => p.sYM == sYM).Select(p => p.sJH).ToList();
        }
    }
}
