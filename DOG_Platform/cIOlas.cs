using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DOGPlatform
{
    class cIOlas
    {
         public static bool checkWrap(string filePathSourceLog)
        {
            bool bWrap = false; 
            if (filePathSourceLog.ToLower().EndsWith(".las")) 
            {
                using (StreamReader sr = new StreamReader(filePathSourceLog, Encoding.Default))
                {
                    string line;
                    string[] split;
                    int iLineIndex = 0;
                    bool start = false;
                    while ((line = sr.ReadLine()) != null)
                    {
                        iLineIndex++;
                        split = line.Trim().Split(new char[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
                        if (!line.StartsWith("#"))
                        {
                            if (split[0].ToUpper().StartsWith("~V")) start = true;
                            if (start == true && split[0].ToUpper().IndexOf("WRAP")>=0)
                            {
                                if (split[1].ToUpper().IndexOf("YES") >= 0) bWrap= true;
                                return bWrap;
                            }
                        }
                    }//end while
                } //end use 
            } //检测是否多行封装
            return bWrap;
         }

       
    }
}
