using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DOGPlatform
{
    class cIOGeoEarthText:cIOBase
    {
        public static void creatFileGeoHeadText(string _filePath, string _sFirstLine, List<string> _ltStrHeadColunm)
        {
            StreamWriter sw = new StreamWriter(_filePath, false, Encoding.UTF8);
            sw.WriteLine(_sFirstLine.TrimEnd());
            sw.WriteLine(_ltStrHeadColunm.Count.ToString());
            foreach (string _item in _ltStrHeadColunm)
            {
                sw.WriteLine(_item);
            }
            sw.Close();
        }
        public static void generateFileGeoText(string _filePath, string _sFirstLine, List<string> _ltStrHeadColunm,List<string> _ltStrLine)
        {
            creatFileGeoHeadText(_filePath, _sFirstLine, _ltStrHeadColunm);
            addDataLines2GeoEarTxt(_filePath, _ltStrLine);
        }
     
        public static void deleteLinesByFirstWordFromGeoEarTxt(string filePath, string sFirstWord)
        {
            string _filePathTempWrited = Path.Combine(cProjectManager.dirPathTemp, "_tempt.txt");
            StreamWriter sw = new StreamWriter(_filePathTempWrited, false, Encoding.UTF8);
            int _lineindex = 0;
            string[] split; ;
            using (StreamReader sr = new StreamReader(filePath, Encoding.UTF8))
            {
                String line;
                int _iDataStartLine = 3;
                while ((line= sr.ReadLine()) != null) //delete the line whose legth is 0
                {
                    _lineindex++;
                    split = line.Trim().Split(new char[] { ' ', '\t', ','}, StringSplitOptions.RemoveEmptyEntries);
                    if (_lineindex == 1) sw.WriteLine(line);
                    else if (_lineindex == 2) 
                    {
                        sw.WriteLine(line);
                        _iDataStartLine = int.Parse(split[0]) + 2;
                    }
                    else if (2 < _lineindex && _lineindex<=_iDataStartLine)
                    {
                        sw.WriteLine(line);
                    }
                    else if(_lineindex>_iDataStartLine && split.Length>0)
                    {
                        if (split[0] != sFirstWord) sw.WriteLine(line);
                    }
                }
            }
            sw.Close();
            File.Copy(_filePathTempWrited, filePath, true);

        }
        public static List<string> selectStringListFromGeoText(string filepath, string sFirstWord)
        {
            //起始行设为3
            return getListStrFromTextByFirstWord(filepath, 3, sFirstWord);
        }

        public static void deleteLinesByFirstWordFromGeoEarTxt(string filePath, List<string> ltStr)
        {
            string _filePathTempWrited = Path.Combine(cProjectManager.dirPathTemp, "_tempt.txt");
            StreamWriter sw = new StreamWriter(_filePathTempWrited, false, Encoding.UTF8);
            int _lineindex = 0;
            string[] split;
            using (StreamReader sr = new StreamReader(filePath, Encoding.Default))
            {
                String line;
                while ((line = sr.ReadLine()) != null) //delete the line whose legth is 0
                {
                    _lineindex++;
                    split = line.Trim().Split(new char[] { ' ', '\t', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
                    if (_lineindex < 2) sw.WriteLine(line);
                    if (_lineindex >= 2 && ltStr.Contains(split[0])) sw.WriteLine(line);
                }
            }
            sw.Close();
            File.Copy(_filePathTempWrited, filePath, true);

        }
        
        public static void addDataLines2GeoEarTxt(string filePath, string sLines)
        {
            List<string> ltStrLines=new List<string>();
            ltStrLines.Add(sLines);
          addDataLines2GeoEarTxt( filePath,  ltStrLines); 
        }
        public static void addDataLines2GeoEarTxt(string filePath, List<string> ltStrLines)
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                ltStrLines.Insert(0,sr.ReadToEnd());
            }
             string _filePathTempWrited = Path.Combine(cProjectManager.dirPathTemp, "_tempt.txt");
            StreamWriter sw = new StreamWriter(_filePathTempWrited, false, Encoding.UTF8);
            foreach (string _line in ltStrLines)
            {
                sw.WriteLine(_line.TrimEnd());
            }
            sw.Close();
            File.Copy(_filePathTempWrited, filePath, true);
           
        }
        public static void replaceDataLines2GeoEarTxtByFirstWord(string filePath, List<string> ltStrLines,string sFirstWord) 
        {
            deleteLinesByFirstWordFromGeoEarTxt(filePath, sFirstWord);
            addDataLines2GeoEarTxt(filePath, ltStrLines);
        }
        public static List<string> readColumnFromGerEarthTxt(string filePath)
        {
            List<string> ltStrReturnColumn = new List<string>();


            try
            {
                if (File.Exists(filePath))
                {
                    using (StreamReader sr = new StreamReader(filePath, System.Text.Encoding.UTF8))
                    {
                        String line;
                        int _indexLine = 0;
                        int _dataStartLine = 0;
                        while ((line = sr.ReadLine()) != null) //delete the line whose legth is 0
                        {
                            _indexLine++;
                            string[] split = line.Trim().Split(new char[] { ' ', '\t', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
                            if (_indexLine == 1) { ;} //firstLine is title
                            else if (_indexLine == 2)
                            { _dataStartLine = Convert.ToInt16(split[0]) + 2; }
                            else if (_indexLine <= _dataStartLine && _indexLine >= 3)
                            {
                                ltStrReturnColumn.Add(split[0]);
                            }
                            else { break; }
                        }
                    }
                }

            }
            catch (Exception e)
            {
                // MessageBox.Show(e.ToString());
            }
            return ltStrReturnColumn;

        }
      
        public static List<string> getFileHeadColumnFromGeoText(string filePath)
        {
            List<string> ltStrFileHeadColumn = new List<string>();
            if (File.Exists(filePath))
            {
                using (StreamReader sr = new StreamReader(filePath, System.Text.Encoding.UTF8))
                {
                    String line;
                    int _indexLine = 0;
                    int _dataStartLine = 3;
                    while ((line = sr.ReadLine()) != null) //delete the line whose legth is 0
                    {
                        _indexLine++;
                        string[] split = line.Trim().Split(new char[] { ' ', '\t', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
                        if (_indexLine == 1) continue;
                        else if (_indexLine == 2) _dataStartLine =2+ int.Parse(split[0]);
                        else if (_indexLine <= _dataStartLine)
                        {
                            ltStrFileHeadColumn.Add(split[0]);
                        }
                        else break;
                    }
                }
            }
            return ltStrFileHeadColumn;
        }

        public static List<string> getDataLineListStringFromGeoText(string filePath)
        {
            List<string> ltStrDataLine = new List<string>();
            if (File.Exists(filePath))
            {
                using (StreamReader sr = new StreamReader(filePath, System.Text.Encoding.UTF8))
                {
                    String line;
                    int _indexLine = 0;
                    int _dataStartLine = 3;
                    while ((line = sr.ReadLine()) != null) //delete the line whose legth is 0
                    {
                        _indexLine++;
                        string[] split = line.Trim().Split(new char[] { ' ', '\t', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
                        if (_indexLine == 1) continue; //first comment line
                        else if (_indexLine == 2) _dataStartLine = int.Parse(split[0]);  //second line is number of column,
                        else if (_indexLine <= (2 + _dataStartLine)) 
                        {
                             //this ection is Column
                        }
                        else 
                        {
                            ltStrDataLine.Add(line);                        
                        }
                    }
                }
            }
            return  ltStrDataLine;
        }

        public static List<string> getDataWordsFromGeoText(string filePath)
        {
            
            List<string> ltWord = new List<string>();
            if (File.Exists(filePath))
            {
                using (StreamReader sr = new StreamReader(filePath, System.Text.Encoding.UTF8))
                {
                    String line;
                    int _indexLine = 0;
                    int _dataStartLine = 3;
                    while ((line = sr.ReadLine()) != null) //delete the line whose legth is 0
                    {
                        _indexLine++;
                        string[] split = line.Trim().Split(new char[] { ' ', '\t', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
                        if (_indexLine == 1) continue; //first comment line
                        else if (_indexLine == 2) _dataStartLine = int.Parse(split[0]);  //second line is number of column,
                        else if (_indexLine <= (2 + _dataStartLine))
                        {
                            //this ection is Column
                        }
                        else
                        {
                            foreach(string word in split) ltWord.Add(word);
                        }
                    }
                }
            }
           
            return ltWord;

        }
        public static  void formatGeoText2Text(string geoFilePath,string textFilePath)
        {
            StreamWriter sw = new StreamWriter(textFilePath, false, Encoding.Default);
            List<string> ltStrHeadColumn = getFileHeadColumnFromGeoText(geoFilePath);
            List<string> ltStrDataline = getDataLineListStringFromGeoText(geoFilePath);
            sw.WriteLine(string.Join("\t",ltStrHeadColumn));
            sw.Write(string.Join("\r\n",ltStrDataline));
            sw.Close();
        }
    }
}
