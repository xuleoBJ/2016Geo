using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace DOGPlatform
{
    class cIOGridEcl
    {
        public static List<string> readGridEcl(string filePath)
        {
            List<string> ltStrLine=new List<string>();
            if (!File.Exists(filePath))  return ltStrLine;
            using (StreamReader sr = new StreamReader(filePath, System.Text.Encoding.UTF8))
            {
                String line;
                while ((line = sr.ReadLine()) != null) //delete the line whose legth is 0
                {
                    if (!line.StartsWith("--")) ltStrLine.Add(line);
                }
            } //end using
            return ltStrLine;
        } //end readGrid

        public static void getGridNum(List<string> listLine)
        {
            //读取图头获取网格参数
                foreach(string line in listLine)
                { 
                    string[] split = line.Trim().Split(new char[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
                    //读取图头获取网格参数
                    if (split.Length > 0)
                    {
                        string kWord = split[0];
                        //if (kWord == "SPECGRID") ltStrLine.Add(kWord);
                    }
                }
        } //end re
    }
}
