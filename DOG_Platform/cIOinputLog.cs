using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace DOGPlatform
{
    class cIOinputLog : ItemLogHeadInfor
    {

        public static void replaceTXTLogInvalidValue(string dirSourcePathLogFiles, string dirGoalPathLogFiles)
        {
            //int iFindErr=0 ;
            try
            {
                string[] fileLogList = System.IO.Directory.GetFileSystemEntries(dirSourcePathLogFiles);
                foreach (string filePathLog in fileLogList)
                {

                    string filenameWrited = Path.Combine(dirGoalPathLogFiles, Path.GetFileName(filePathLog));

                    using (StreamReader sr = new StreamReader(filePathLog, Encoding.Default))
                    {
                        StreamWriter sw = new StreamWriter(filenameWrited, false, Encoding.UTF8);
                        string line;
                        string[] split;
                        int iLineIndex = 0;
                        while ((line = sr.ReadLine()) != null)
                        {
                            iLineIndex++;

                            split = line.Trim().Split(new char[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
                            if (iLineIndex == 1) sw.WriteLine(line);
                            else if (split.Length > 1)
                            {
                                for (int i = 1; i < split.Length; i++)
                                {
                                    float fLogValue = float.Parse(split[i]);
                                    if (fLogValue >= 900 || fLogValue <= -900) split[i] = "-999";
                                }
                                sw.WriteLine(string.Join("\t", split));
                            }
                        }
                        sw.Close();
                    }

                }

            }

            catch (Exception e1)
            {
                MessageBox.Show(e1.ToString());
            }
        }

        static int INVALID_VALUE = -999;

        public static List<string> getLogSerierNamesFromLogForward(string _filePath)
        { //得到是测井头，删除了Depth
            List<string> ltStrReturn = new List<string>();
            using (StreamReader sr = new StreamReader(_filePath, System.Text.Encoding.Default))
            {
                String line;
                string[] split;
                int iLineIndex = 0;
                while ((line = sr.ReadLine()) != null) //delete the line whose legth is 0
                {
                    iLineIndex++;
                    if (iLineIndex == 5)
                    {
                        split = line.Trim().Split(new char[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 2; i < split.Length; i++)
                        {
                            ltStrReturn.Add(split[i]);
                        }
                        break;
                    }

                }
            }
            return ltStrReturn;
        }
        //从TXT格式测井曲线活动曲线系列头
        public static bool checkRenameSameFile(string filePath)
        {
            bool bDelete = true;
            if (File.Exists(filePath))
            {
                DialogResult dialogResult = MessageBox.Show(" 是否覆盖？", "同名文件已存在", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No) bDelete = false;
            }
            return bDelete;
        }

        public static List<string> getLogSerierNamesFromProjectLogGeo(string _sJH)
        {
            string fileNameSourceLog = Path.Combine(cProjectManager.dirPathWellDir, _sJH, cProjectManager.fileNameInputWellLog);
            return cIOGeoEarthText.readColumnFromGerEarthTxt(fileNameSourceLog);
        }

        public static List<string> getLogSerierNamesFromLogGeo(string _filePath)
        {
            return cIOGeoEarthText.readColumnFromGerEarthTxt(_filePath);
        }

        public static List<string> getLogSerierNamesFromTXTLog(string filePathLog)
        {
            List<string> ltStrReturn = new List<string>();
            using (StreamReader sr = new StreamReader(filePathLog, System.Text.Encoding.Default))
            {
                String line;
                string[] split;
                int iLineIndex = 0;
                while ((line = sr.ReadLine()) != null && iLineIndex < 1) //delete the line whose legth is 0
                {
                    iLineIndex++;
                    split = line.Trim().Split(new char[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
                    
                    for (int i=1;i<split.Length;i++) //去掉第一个深度列
                    {
                        ltStrReturn.Add(split[i]);
                    }

                }
            }
            return ltStrReturn;
        }

        public static List<string> getLogSerierNamesFromListLog(string filePathLog)
        {
            List<string> ltStrReturn = new List<string>();
            using (StreamReader sr = new StreamReader(filePathLog, System.Text.Encoding.Default))
            {
                String line;
                string[] split;
                int iLineIndex = 0;
                while ((line = sr.ReadLine()) != null && iLineIndex < 5) //delete the line whose legth is 0
                {
                    iLineIndex++;
                    if (iLineIndex == 4)
                    {
                        split = line.Trim().Split(new char[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);

                        for (int i = 1; i < split.Length; i++) //去掉第一个深度列
                        {
                            ltStrReturn.Add(split[i]);
                        }
                        break;
                    }

                }
            }
            return ltStrReturn;
        }

        public static List<string> getLogSerierNamesFromLasLog(string filePathLogLas)
        {
            List<string> ltLineRet = new List<string>();
            using (StreamReader sr = new StreamReader(filePathLogLas, System.Text.Encoding.Default))
            {
                String line;
                string[] split;
                int iLineIndex = 0;
                bool start = false;
                while ((line = sr.ReadLine()) != null) //delete the line whose legth is 0
                {
                    iLineIndex++;
                    if (!line.StartsWith("#")) // //非注释行
                    {
                        split = line.Trim().Split(new char[] { ' ','\t', ','}, StringSplitOptions.RemoveEmptyEntries);
                        if(split.Length>0)
                        {
                            if (split[0].ToUpper().StartsWith("~C")) start = true;
                            if (start == true && (split[0].ToUpper().StartsWith("~A")
                                || split[0].ToUpper().StartsWith("~P")
                                || split[0].ToUpper().StartsWith("~O"))) break;//start==true and 重新遇到~跳出循环
                            if (start) ltLineRet.Add(line.Trim().Split(new char[] { '.', ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries)[0]); //加入系列，las去掉小数点后面的单位
                        }
                    }
                }
            }
            if (ltLineRet.Count > 0)
            {
                ltLineRet.RemoveAt(0);//删除～C
                ltLineRet.RemoveAt(0);//删除深度
            } 
            return ltLineRet;
        }

        public static List<string> getLogSerierNamesFromLasV2Log(string filePathLog)
        {
           return getLogSerierNamesFromLasLog(filePathLog);
        }

        public static int getDataStartLineOfLasLog(string filePathLog) 
        {
            using (StreamReader sr = new StreamReader(filePathLog, System.Text.Encoding.Default))
            {
                String line;
                string[] split;
                int iLineIndex = 0;
                while ((line = sr.ReadLine()) != null) //delete the line whose legth is 0
                {
                    iLineIndex++;
                    split = line.Trim().Split(new char[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
                    if (split.Length>0 && split[0].ToUpper().StartsWith("~A")) return iLineIndex + 1;
                }
            }
            return 0;
        }

        public static List<string> getLogSerierNamesFromDirTXTLog(string dirPathLogTXT)
        {
            List<string> ltStrLogNames = new List<string>();

            string[] fileLogList = System.IO.Directory.GetFileSystemEntries(dirPathLogTXT);

            foreach (string filePathLog in fileLogList)
            {
                foreach (string sItem in cIOinputLog.getLogSerierNamesFromTXTLog(filePathLog))
                {
                    ltStrLogNames.Add(sItem);
                }
            }

            return ltStrLogNames.Distinct().ToList();
        }

        public static bool isLogFormatTXT(string filePathLog)
        {
            bool bTextLogOK = true;
            List<string> ltStrReturn = new List<string>();
            using (StreamReader sr = new StreamReader(filePathLog, System.Text.Encoding.Default))
            {
                String line;
                int iLineIndex = 0;
                string sLine0 = "";
                string sLine1 = "";
                string sLine2 = "";
                while ((line = sr.ReadLine()) != null) //delete the line whose legth is 0
                {
                    iLineIndex++;
                    if (iLineIndex == 1) sLine0 = line;
                    else if (iLineIndex == 2) sLine1 = line;
                    else if (iLineIndex == 3) sLine2 = line;
                    else break;
                }
                string[] splitLine0 = sLine0.Trim().Split(new char[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
                string[] splitLine1 = sLine1.Trim().Split(new char[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
                string[] splitLine2 = sLine2.Trim().Split(new char[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);

                if (splitLine0.Length != splitLine1.Length || splitLine1.Length != splitLine2.Length)
                {
                    bTextLogOK = false;
                    return false;
                }
                foreach (string sItem in splitLine1)
                {
                    float result;
                    bTextLogOK = float.TryParse(sItem, out result);
                    if (bTextLogOK == false) { return false; }
                }

            }
            return bTextLogOK;
        }

        public static void generateFileJHandLogSeriers(string dirPathLogFiles, string filenameWrited)
        {

            StreamWriter sw = new StreamWriter(filenameWrited, false, Encoding.UTF8);
            string sWrited = "";
            try
            {
                string[] fileLogList = System.IO.Directory.GetFileSystemEntries(dirPathLogFiles);
                foreach (string filePathLog in fileLogList)
                {
                    List<string> ltStrLogNames = new List<string>();
                    foreach (string sItem in cIOinputLog.getLogSerierNamesFromTXTLog(filePathLog))
                    {
                        ltStrLogNames.Add(sItem);
                    }
                    sWrited += Path.GetFileName(filePathLog).Replace(".txt", "") + "\t" + string.Join("\t", ltStrLogNames.ToArray()) + "\r\n";

                }
                sw.Write(sWrited);
                sw.Close();

            }

            catch (Exception e1)
            {
                MessageBox.Show(e1.ToString());
            }
        }
        /// <summary>
        /// 根据井号，传入测井曲线头，选择相对应的测井曲线，曲线系列不存在的用-999无效值填充
        /// </summary>
        /// <param name="_sJH">井号</param>
        /// <param name="ltStrProjectGlobeLogSelected">需要提取的测井系列list</param>
        /// <param name="fileNameGoal">写入的文件名</param>

        public static void selectLogSeriresFromProjectWellLog(string _sJH,List<string> ltStrProjectGlobeLogSelected, string fileNameGoal)
        {
            //获取测井文件在项目中的位置
            string fileNameSourceLog = Path.Combine(cProjectManager.dirPathWellDir, _sJH, cProjectManager.fileNameInputWellLog);
            //从项目文件中得到测井系列头list
            List<string> ltStrCurrentFileLogHead = getLogSerierNamesFromLogGeo(fileNameSourceLog);
            
            // 填充对应提取测井头中在项目测井文件中的列指数，找不到的列存-1
            List<int> ltIndexLogSelected = new List<int>();
            foreach (string _item in ltStrProjectGlobeLogSelected) ltIndexLogSelected.Add(ltStrCurrentFileLogHead.IndexOf(_item));

            //如果文件存在的话
            if (File.Exists(fileNameSourceLog))
            {
                using (StreamReader sr = new StreamReader(fileNameSourceLog, Encoding.Default))
                {
                    StreamWriter sw = new StreamWriter(fileNameGoal, false, Encoding.UTF8);
                    sw.WriteLine(string.Join("\t", ltStrProjectGlobeLogSelected));
                    string line;
                    string[] split;
                    int iLineIndex = 0;
                    List<int> iListIndexSelectedLog = new List<int>();
                    while ((line = sr.ReadLine()) != null)
                    {
                        iLineIndex++;
                        if (iLineIndex > (2 + ltStrCurrentFileLogHead.Count))
                        {
                            split = line.Trim().Split(new char[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
                            List<string> ltStrWrited = new List<string>();
                            //通过列指数填充数据行，列指数为-1的填充无效值
                            foreach (int _indexValue in ltIndexLogSelected)
                            {
                                if (_indexValue < 0) ltStrWrited.Add(INVALID_VALUE.ToString());
                                else ltStrWrited.Add(split[_indexValue]);

                            }

                            sw.WriteLine(string.Join("\t", ltStrWrited));
                        }

                    }
                    sw.Close();
                }
            }
        }
     
        //更新全部曲线？还是只更新部分曲线？同名曲线是否合并？
        //列数不够的删除行，得判断文件是否合法；
        //第一列统统认为是深度列
        //同样las等也支持了。
        //判断文件工程测井目录路径下是否存在同名测井曲线，目前仅支持全部替换
        //将来可以更加系列选择
        //曲线在导入的时候作了分割，曲线头存入字典，曲线数据另外按二维表的形式存入文件，通过文件名关联，这样做到了 信息和数据的分离
        public static List<string> readTextLog2Project(string sJH, string fileNameSourceLog)
        {
            List<string> ltStrLogNames = new List<string>();
            string projectLogFile = Path.Combine(cProjectManager.dirPathLog, sJH + "_$#log");
            bool bImport = false;

            if (File.Exists(projectLogFile))
            {
                DialogResult dialogResult = MessageBox.Show(sJH + " 测井曲线已经存在，是否覆盖？", "导入测井曲线",
                    MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    bImport = true;
                }
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("井号:" + sJH + "\r文件:" + fileNameSourceLog, "导入测井曲线",
                        MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    bImport = true;
                }
            }

            if (bImport == true)
            {
                using (StreamReader sr = new StreamReader(fileNameSourceLog, Encoding.Default))
                {
                    StreamWriter sw = new StreamWriter(projectLogFile, false, Encoding.UTF8);
                    string line;
                    string[] split;
                    int iLineIndex = 0;
                    List<int> iListIndexSelectedLog = new List<int>();
                    int numCol = 999; //定义记录曲线系列数
                    while ((line = sr.ReadLine()) != null)
                    {
                        iLineIndex++;
                        split = line.Trim().Split(new char[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
                        List<string> ltStrWrited = new List<string>();
                        if (iLineIndex == 1)
                        {
                            numCol = split.Length;
                            for (int k = 1; k < split.Length; k++) ltStrLogNames.Add(split[k]);
                        }
                        else
                        {
                            if (split.Length == numCol) //删除不同列的数据
                            {
                                sw.WriteLine(string.Join("\t", split));
                            }
                        }
                    }
                    sw.Close();

                }
            }
            return ltStrLogNames;
        }

        /// <summary>
        /// 从文件中按列指数读取测井数据
        /// 按传入的指数列，读取数据，
        /// 返回list data，
        /// 读取的时候做必要的校验，替换无效值，并删除全部为无效值的行
        /// 
        /// 传入的列指数从00始的，传入一定要注意
        /// </summary>
        /// <param name="fileNameSourceLog">文件路径</param>
        /// <param name="iDataStartLine">数据起始行</param>
        /// <param name="ltIndexLog">列指数</param>
        /// <returns></returns>
        public static List<string> readLogData(string filePathSourceLog, int iDataStartLine, List<int> ltIndexLog)
        {

            List<string> ltStrDataLine = new List<string>();
            using (StreamReader sr = new StreamReader(filePathSourceLog, Encoding.Default))
            {
                string line;
                string[] split;
                int iLineIndex = 0;
                int _iMax= ltIndexLog.Max();//列指数应该大于等于指数的最大
                while ((line = sr.ReadLine()) != null)
                {
                    iLineIndex++;
                    split = line.Trim().Split(new char[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
                    if (iLineIndex > iDataStartLine && split.Length >=_iMax)//忽略头数据，从起始行开始读数据值
                    {
                        List<string> _ltData = new List<string>();

                        foreach (int _index in ltIndexLog)
                        {
                            if(_index==0) _ltData.Add(split[0]); 
                            if (_index >= 1)
                            {
                                float _value = -999;
                                float.TryParse(split[_index],out _value);
                                if (_value > -1000 && _value < 1000) _ltData.Add(_value.ToString());
                                else _ltData.Add("-999");
                            }
                        }
                        ltStrDataLine.Add(string.Join("\t", _ltData));

                    }
                }
            }
            return ltStrDataLine;
        }

        //读取测井列,保留指数列和深度列，iDataStartLine是起始行,为了保证起始行0-1的误差 舍去了一行数据
        public static List<string> readLogData(string filePathSourceLog, int iDataStartLine, int indexLog)
        {
            List<string> ltOutDataLine = new List<string>();

            bool bWrap = cIOlas.checkWrap(filePathSourceLog);
            if(bWrap==false)
            {
                using (StreamReader sr = new StreamReader(filePathSourceLog, Encoding.Default))
                {
                    string line;
                    string[] split;
                    int iLineIndex = 0;
                    while ((line = sr.ReadLine()) != null)
                    {
                        iLineIndex++;
                        split = line.Trim().Split(new char[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
                        if (iLineIndex > iDataStartLine && split.Length>2)//忽略头数据，从起始行开始读数据值
                        {
                            float _value = -999;
                            float.TryParse(split[indexLog],out _value);
                            //根据value判断是否有效值，无效值 行舍去
                            if (_value > -500 && _value < 1000)
                            {
                                List<string> _ltData = new List<string>();
                                _ltData.Add(split[0]);
                                _ltData.Add(_value.ToString());
                                ltOutDataLine.Add(string.Join("\t", _ltData));
                            }
                        }
                    }
                } //end use
            }//end if no wrap
            else 
            {
                using (StreamReader sr = new StreamReader(filePathSourceLog, Encoding.Default))
                {
                    string line;
                    string[] split;
                    int iLineIndex = 0;
                    List<string> ltNewLineData = new List<string>();
                    while ((line = sr.ReadLine()) != null)
                    {
                        iLineIndex++;
                        split = line.Trim().Split(new char[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
                        if (iLineIndex > iDataStartLine)//忽略头数据，从起始行开始读数据值
                        {
                            if (split.Length == 1) //深度行处理
                            {
                                if (indexLog<ltNewLineData.Count)
                                {
                                    float _value = float.Parse(ltNewLineData[indexLog]);
                                    if (_value > -500 && _value < 1000)
                                    {
                                        List<string> _ltData = new List<string>();
                                        _ltData.Add(ltNewLineData[0]);
                                        _ltData.Add(_value.ToString());
                                        ltOutDataLine.Add(string.Join("\t", _ltData));
                                    }
                                }
                                ltNewLineData.Clear();
                                ltNewLineData.Add(split[0]);
                            }
                            else //数据行
                            {
                                foreach (string sValue in split) ltNewLineData.Add(sValue);
                            }
                        }
                    } 
                } //end use
            }
            return ltOutDataLine;
        }

        //读测井曲线到井文件夹下,需要测试修改
        public static List<string> readTextLog2WellDir(string sJH, string fileNameSourceLog)
        {
            //读测井曲线到井文件夹下,需要测试修改
            //读测井曲线到井文件夹下,需要测试修改
            //读测井曲线到井文件夹下,需要测试修改   //读测井曲线到井文件夹下,需要测试修改   //读测井曲线到井文件夹下,需要测试修改
            //读测井曲线到井文件夹下,需要测试修改
            List<string> ltStrLogNames = new List<string>();
            string filePath = Path.Combine(cProjectManager.dirPathWellDir, sJH,cProjectManager.fileNameInputWellLog);
            bool bImport = false;

            if (File.Exists(filePath))
            {
                DialogResult dialogResult = MessageBox.Show(sJH + " 测井曲线已经存在，是否覆盖？", "导入测井曲线",
                    MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    bImport = true;
                }
            }

            if (bImport == true)
            {
                using (StreamReader sr = new StreamReader(fileNameSourceLog, Encoding.Default))
                {
                    string line;
                    string[] split;
                    int iLineIndex = 0;
                    List<string> ltStrLineData = new List<string>();
                    int numCol = 999; //定义记录曲线系列数
                    while ((line = sr.ReadLine()) != null)
                    {
                        iLineIndex++;
                        split = line.Trim().Split(new char[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
                        List<string> ltStrWrited = new List<string>();
                        if (iLineIndex == 1) //读入曲线头
                        {
                            numCol = split.Length;
                            for (int k = 1; k < split.Length; k++) ltStrLogNames.Add(split[k]);
                        }
                        else
                        {
                            if (split.Length == numCol) //删除不同列的数据
                            {
                                ltStrLineData.Add(string.Join("\t", split));
                            }
                        }
                    }
                    cIOGeoEarthText.creatFileGeoHeadText(filePath, sJH, ltStrLogNames);
                    cIOGeoEarthText.addDataLines2GeoEarTxt(filePath, ltStrLineData);

                }
            }
            return ltStrLogNames;
        }

        public static void exportTextLog(string sJH, string filePathGoal)
        {
            Cursor.Current = Cursors.WaitCursor;
         
            string filePathLog =Path.Combine( cProjectManager.dirPathWellDir,  sJH,cProjectManager.fileNameInputWellLog);

            cIOGeoEarthText.formatGeoText2Text(filePathLog, filePathGoal);

            Cursor.Current = Cursors.Default;
        }

        public static void textLogConvertFT2m(string filePath)
        {
            Cursor.Current = Cursors.WaitCursor;
            string oldFileCopy = filePath + "_tmp";
            File.Copy(filePath, oldFileCopy,true);
            StreamWriter sw = new StreamWriter(filePath, false, Encoding.UTF8);
            using (StreamReader sr = new StreamReader(oldFileCopy, Encoding.UTF8))
            {
                string line;
                int lineIndex = 0;
                int _iDataStartLine = 4; //
                while ((line = sr.ReadLine()) != null) 
                {
                    lineIndex++;
                    if (lineIndex <= 4) 
                    {
                        sw.WriteLine(line);
                    }
                    if ( lineIndex > _iDataStartLine) 
                    {
                        string[] split = line.Trim().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                        string depthMstr = (float.Parse(split[0]) / 3.2808).ToString("0.00");
                        string newLine = depthMstr + "\t" + split[1] + "\t\n";
                        sw.WriteLine(newLine);
                    }
                }
            }  
            sw.Close();
            File.Delete(oldFileCopy);
            Cursor.Current = Cursors.Default;
        }

        public static void extractTextLog2File(string sJH, string sLogName, string filePath)
        {
            Cursor.Current = Cursors.WaitCursor;
            StreamWriter sw = new StreamWriter(filePath, false, Encoding.UTF8);
            sw.Write(sLogName + "\t");
            sw.Write(extractTextLog2stringGeo(sJH, sLogName));
            sw.Close();
            Cursor.Current = Cursors.Default;
        }

        public static string extractTextLog2stringGeo(string sJH, string sLogName)
        { 
            Cursor.Current = Cursors.WaitCursor;
            string sReturn = "";
            string _filepath = Path.Combine(cProjectManager.dirPathWellDir, sJH,sLogName+ cProjectManager.fileExtensionWellLog);
            if (!File.Exists(_filepath))
            {
                return "";
            }
            else
            {
                using (StreamReader sr = new StreamReader(_filepath, Encoding.UTF8))
                {
                    string _line;
                    int lineIndex = 0;
                    int _iDataStartLine = 4 ; //
                    while ((_line = sr.ReadLine()) != null) //抽稀
                    {
                        lineIndex++;
                        if (lineIndex % 2 == 0 && lineIndex > _iDataStartLine) //抽稀了一半数据
                        {
                            string[] split = _line.Trim().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                            sReturn += split[0] + "\t" + split[1] + "\t";
                        }
                    }
                }  
            }
            Cursor.Current = Cursors.Default;
            return sReturn;

        }

        public List<string> selectSectionDrawData2List(string _sJH,string _sLogName)
        {
            List<string> listStrRet = new List<string>();
           Cursor.Current = Cursors.WaitCursor;
           string _filepath = Path.Combine(cProjectManager.dirPathWellDir, _sJH, _sLogName + cProjectManager.fileExtensionWellLog);
            if (!File.Exists(_filepath))
            {
                return listStrRet;
            }
            else
            {
                using (StreamReader sr = new StreamReader(_filepath, Encoding.UTF8))
                {
                    string _line;
                    int lineIndex = 0;
                    int _iDataStartLine = 4; //
                    while ((_line = sr.ReadLine()) != null) //抽稀
                    {
                        lineIndex++;
                        if (lineIndex % 2 == 0 && lineIndex > _iDataStartLine) //抽稀了一半数据
                        {
                            string[] split = _line.Trim().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                            listStrRet.Add( split[0] + "\t" + split[1] + "\t");
                        }
                    }
                }
            }
            Cursor.Current = Cursors.Default;
            return listStrRet;
        }

        //按深度段从sectionWell 里得到值
        public static trackDataListLog getLogSeriersFromSectionWellFromLogFile(string sJH, string sLogName, double dfTop, double dfBot)
        {
            trackDataListLog sttTrackLogDataList = new trackDataListLog();
            sttTrackLogDataList.itemHeadInforDraw.sLogName = sLogName;
            string _filepath = Path.Combine(cProjectManager.dirPathWellDir, sJH, sLogName + cProjectManager.fileExtensionWellLog);
            if (!File.Exists(_filepath))
            {
                return sttTrackLogDataList;
            }
            else
            {
                using (StreamReader sr = new StreamReader(_filepath, Encoding.UTF8))
                {
                    string _line;
                    int lineIndex = 0;
                    int _iDataStartLine = 4; //
                    while ((_line = sr.ReadLine()) != null) //抽稀
                    {
                        lineIndex++;
                        if ( lineIndex > _iDataStartLine) //抽稀了一半数据
                        {
                            string[] split = _line.Trim().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                            float top;
                            double value;
                            if (float.TryParse(split[0], out top) && double.TryParse(split[1], out value))
                            {
                                if (dfTop <= top && top <= dfBot)
                                {
                                    sttTrackLogDataList.fListMD.Add(top);
                                    sttTrackLogDataList.fListValue.Add(value);
                                }

                            }
                        }
                    }//end while
                }
            }
            return sttTrackLogDataList;
        }

        public static void renameProjectLogFile(string sJH, string sLogName,string sLogNameNew) 
        {

            string oldfilepath=Path.Combine(cProjectManager.dirPathWellDir,sJH, sLogName + cProjectManager.fileExtensionWellLog) ;
            string newfilepath = Path.Combine(cProjectManager.dirPathWellDir, sJH, sLogNameNew + cProjectManager.fileExtensionWellLog);
            File.Move(oldfilepath, newfilepath);
        }
    }
}
