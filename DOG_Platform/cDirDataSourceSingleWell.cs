using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DOGPlatform
{
    class cDirDataSourceSingleWell
    {
        static string sLayDepthFileMark = "#$LayerDepthTrack";
        static string sJSJLFileMark = "#$JSJLTrack";
        static string sPerforationFileMark = "#$PerforationTrack";
        static string sLithoFileMark = "#$LithoTrack";
        static string sTextFileMark = "#$TextTrack";
        public static int addJSJL(string sJHSelected, int dfDS1Show,int dfDS2Show,int iIndexTrack,string filePath) 
        {
            string sContent = cIOinputJSJL.selectIntervalDataFromJSJLByJHAndDepth(sJHSelected, dfDS1Show, dfDS2Show);
            write2File(iIndexTrack, sContent, filePath, sJSJLFileMark);
            return iIndexTrack++;
        }

        public static int addJSJL(string sJHSelected, int iIndexTrack, string filePath)
        {
            string sContent = cIOinputJSJL.selectIntervalDataFromJSJLByJHAndDepth(sJHSelected, 0, 10000);
            write2File(iIndexTrack, sContent, filePath, sJSJLFileMark);
            return iIndexTrack++;
        }
        public static int addText(string filepathSource, int iIndexTrack, string filePath)
        {
            string sContent = "";
            using (StreamReader sr = new StreamReader(filepathSource, Encoding.Default))
            {
                String line;
                int iLineindex = 0;
                while ((line = sr.ReadLine()) != null) //delete the line whose legth is 0
                {
                    iLineindex++;
                    sContent+=line+"\r\n";
                }
            }

            write2File(iIndexTrack, sContent, filePath, sTextFileMark);
            return iIndexTrack++;
        }

        public static int addLitho(string filepathSource, int iIndexTrack, string filePath)
        {
            string sContent = "";
            using (StreamReader sr = new StreamReader(filepathSource, Encoding.Default))
            {
                String line;
                int iLineindex = 0;
                while ((line = sr.ReadLine()) != null) //delete the line whose legth is 0
                {
                    iLineindex++;
                    sContent += line + "\r\n";
                }
            }

            write2File(iIndexTrack, sContent, filePath, sLithoFileMark);
            return iIndexTrack++;
        }

        public static int addLayerDepth(string sJHSelected, int dfDS1Show, int dfDS2Show, int iIndexTrack,  string filePath)
        {
            cIOinputLayerDepth cSelectLayerDepth = new cIOinputLayerDepth();
            string sContent = cSelectLayerDepth.selectIntervalDataFromLayerDepthByJHAndDepth(sJHSelected, dfDS1Show, dfDS2Show);
            write2File( iIndexTrack, sContent, filePath, sLayDepthFileMark);
            return iIndexTrack++;
        }

        public static int addLayerDepth(string sJHSelected,  int iIndexTrack, string filePath)
        {
            cIOinputLayerDepth cSelectLayerDepth = new cIOinputLayerDepth();
            string sContent = cSelectLayerDepth.selectIntervalDataFromLayerDepthByJHAndDepth(sJHSelected, 0, 10000);
            write2File(iIndexTrack, sContent, filePath, sLayDepthFileMark);
            return iIndexTrack++;
        }

        public static int addPerforation(string sJHSelected, int dfDS1Show, int dfDS2Show, int iIndexTrack, string filePath)
        {
            string sContent = cIOinputWellPerforation.selectPerforation2String(sJHSelected);
             write2File(iIndexTrack, sContent, filePath, sPerforationFileMark);
             return iIndexTrack++;
        }

        private static void write2File(int iIndexTrack, string sContent, string filePath, string sMark) 
        {
            StreamWriter sw = new StreamWriter(filePath, true, Encoding.UTF8);
            sw.WriteLine(sMark + "\t" + "Track" + iIndexTrack.ToString());
            sw.Write(sContent);
            sw.WriteLine("#$End" + sMark);
            sw.Close();
        }

        public static trackDataListLayerDepth getTrackDataLayerDepth(string filePath)
        {
            trackDataListLayerDepth sttLayerDepth = new trackDataListLayerDepth();
          
            using (StreamReader sr = new StreamReader(filePath, Encoding.UTF8))
            {
                String line;
                string[] split;
                int iReadIndex = 0;
                while ((line = sr.ReadLine()) != null) //delete the line whose legth is 0
                {
                    if (line.StartsWith(sLayDepthFileMark) == true) iReadIndex = 1;
                    else if (line.StartsWith("#$End" + sLayDepthFileMark) == true) iReadIndex = 2;
                    else if (iReadIndex >= 2) break;
                    else if (iReadIndex == 1)
                    {
                        split = line.Trim().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                        sttLayerDepth.ltStrXCM.Add(split[1]);
                        sttLayerDepth.fListDS1.Add(float.Parse(split[2]));
                        sttLayerDepth.fListDS2.Add(float.Parse(split[3]));

                    }

                }
            }
            return sttLayerDepth;
        }

        public static trackDataListLayerDepth getTrackDataLayerDepth(string filePath, string sIDTrack)
        {
            trackDataListLayerDepth sttLayerDepth = new trackDataListLayerDepth();

            using (StreamReader sr = new StreamReader(filePath, Encoding.UTF8))
            {
                String line;
                string[] split;
                int iReadIndex = 0;
                while ((line = sr.ReadLine()) != null) //delete the line whose legth is 0
                {
                    split = line.Trim().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    if (line.StartsWith(sLayDepthFileMark) == true && split[1] == sIDTrack) iReadIndex = 1;
                    else if (line.StartsWith("#$End" + sLayDepthFileMark) == true) iReadIndex = 2;
                    else if (iReadIndex >= 2) break;
                    else if (iReadIndex == 1)
                    {
                        
                        sttLayerDepth.ltStrXCM.Add(split[1]);
                        sttLayerDepth.fListDS1.Add(float.Parse(split[2]));
                        sttLayerDepth.fListDS2.Add(float.Parse(split[3]));

                    }

                }
            }
            return sttLayerDepth;
        }

        public static trackDataListJSJL getTrackDataJSJL(string filePath)
        {
            trackDataListJSJL sttJSJL = new trackDataListJSJL();

            using (StreamReader sr = new StreamReader(filePath, Encoding.UTF8))
            {
                String line;
                string[] split;
                int iReadIndex = 0;
                while ((line = sr.ReadLine()) != null) //delete the line whose legth is 0
                {
                    if (line.StartsWith(sJSJLFileMark) == true) iReadIndex = 1;
                    else if (line.StartsWith("#$End" + sJSJLFileMark) == true) iReadIndex = 2;
                    else if (iReadIndex >= 2) break;
                    else if (iReadIndex == 1)
                    {
                        split = line.Trim().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                        sttJSJL.fListDS1.Add(float.Parse(split[1]));
                        sttJSJL.fListDS2.Add(float.Parse(split[2]));
                        sttJSJL.sListJSJL.Add(split[3]);
                    }
                }
            }
            return sttJSJL;
        }

        public static trackDataListJSJL getTrackDataJSJL(string filePath,string sIDTrack)
        {
            trackDataListJSJL sttJSJL = new trackDataListJSJL();
            using (StreamReader sr = new StreamReader(filePath, Encoding.UTF8))
            {
                String line;
                string[] split;
                int iReadIndex = 0;
                while ((line = sr.ReadLine()) != null) //delete the line whose legth is 0
                {
                    split = line.Trim().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    if (line.StartsWith(sJSJLFileMark) == true && split[1] == sIDTrack) iReadIndex = 1;
                    else if (line.StartsWith("#$End" + sJSJLFileMark) == true) iReadIndex = 2;
                    else if (iReadIndex >= 2) break;
                    else if (iReadIndex == 1)
                    {
                        sttJSJL.fListDS1.Add(float.Parse(split[1]));
                        sttJSJL.fListDS2.Add(float.Parse(split[2]));
                        sttJSJL.sListJSJL.Add(split[3]);

                    }

                }
            }
            return sttJSJL;
        }

        public static trackDataListJSJL getTrackDataJSJL(string filePath, int dfDS1Show, int dfDS2Show)
        {
            trackDataListJSJL sttJSJL = new trackDataListJSJL();
            using (StreamReader sr = new StreamReader(filePath, Encoding.UTF8))
            {
                String line;
                string[] split;
                int iReadIndex = 0;
                while ((line = sr.ReadLine()) != null) //delete the line whose legth is 0
                {
                    if (line.StartsWith(sJSJLFileMark) == true) iReadIndex = 1;
                    else if (line.StartsWith("#$End" + sJSJLFileMark) == true) iReadIndex = 2;
                    else if (iReadIndex >= 2) break;
                    else if (iReadIndex == 1)
                    {
                        split = line.Trim().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                        float _top = float.Parse(split[1]);
                        float _bottom = float.Parse(split[2]);

                        if (!(dfDS2Show <= _top || dfDS1Show >= _bottom))
                        {
                            sttJSJL.fListDS1.Add(float.Parse(split[1]));
                            sttJSJL.fListDS2.Add(float.Parse(split[2]));
                            sttJSJL.sListJSJL.Add(split[3]);
                        }
                    }

                }
            }
            return sttJSJL;
        }

        public static trackInputPerforationDataList getTrackDataPerforation(string filePath)
        {
            trackInputPerforationDataList sttPeforation = new trackInputPerforationDataList();
            using (StreamReader sr = new StreamReader(filePath, Encoding.UTF8))
            {
                String line;
                string[] split;
                int iReadIndex = 0;
                while ((line = sr.ReadLine()) != null) //delete the line whose legth is 0
                {
                    if (line.StartsWith(sPerforationFileMark) == true) iReadIndex = 1;
                    else if (line.StartsWith("#$End" + sPerforationFileMark) == true) iReadIndex = 2;
                    else if (iReadIndex >= 2) break;
                    else if (iReadIndex == 1)
                    {
                        split = line.Trim().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                        sttPeforation.fListDS1.Add(float.Parse(split[1]));
                        sttPeforation.fListDS2.Add(float.Parse(split[2]));
                    }

                }
            }
            return sttPeforation;
        }

        public static trackInputPerforationDataList getTrackDataPerforation(string filePath, string sIDTrack)
        {
            trackInputPerforationDataList sttPeforation = new trackInputPerforationDataList();
            using (StreamReader sr = new StreamReader(filePath, Encoding.UTF8))
            {
                String line;
                string[] split;
                int iReadIndex = 0;
                while ((line = sr.ReadLine()) != null) //delete the line whose legth is 0
                {
                    split = line.Trim().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    if (line.StartsWith(sPerforationFileMark) == true && split[1] == sIDTrack) iReadIndex = 1;
                    else if (line.StartsWith("#$End" + sPerforationFileMark) == true) iReadIndex = 2;
                    else if (iReadIndex >= 2) break;
                    else if (iReadIndex == 1)
                    {
                        sttPeforation.fListDS1.Add(float.Parse(split[1]));
                        sttPeforation.fListDS2.Add(float.Parse(split[2]));
                    }

                }
            }
            return sttPeforation;
        }

        public static trackInputPerforationDataList getTrackDataPerforation(string filePath, int dfDS1Show, int dfDS2Show)
        {
            trackInputPerforationDataList sttPeforation = new trackInputPerforationDataList();

            using (StreamReader sr = new StreamReader(filePath, Encoding.UTF8))
            {
                String line;
                string[] split;
                int iReadIndex = 0;
                while ((line = sr.ReadLine()) != null) //delete the line whose legth is 0
                {
                    if (line.StartsWith(sPerforationFileMark) == true) iReadIndex = 1;
                    else if (line.StartsWith("#$End" + sPerforationFileMark) == true) iReadIndex = 2;
                    else if (iReadIndex >= 2) break;
                    else if (iReadIndex == 1)
                    {
                        split = line.Trim().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                        float _top = float.Parse(split[1]);
                        float _bottom = float.Parse(split[2]);

                        if (!(dfDS2Show <= _top || dfDS1Show >= _bottom))
                        {
                            sttPeforation.fListDS1.Add(float.Parse(split[1]));
                            sttPeforation.fListDS2.Add(float.Parse(split[2]));
                        }
                    }
                }
            }
            return sttPeforation;
        }


        public static trackDataListIntervalValue getTrackDataIntervalValue(string sData, double dfDS1Show, double  dfDS2Show)
        {
            trackDataListIntervalValue curDataList = new trackDataListIntervalValue();

            string[] split = sData.Trim().Split(new string[] { cProjectData.splitMark }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < split.Length; i = i + 3)
            {
                float top = float.Parse(split[i]);
                float bottom = float.Parse(split[i + 1]);
                float fValue = float.Parse(split[i + 2]);
                if (dfDS1Show <= top && bottom <= dfDS2Show)
                {
                    curDataList.fListDS1.Add(top);
                    curDataList.fListDS2.Add(bottom);
                    curDataList.fListValue.Add(fValue);
                }
            }
            return curDataList;
        }

        public static trackDataListInterval getTrackDataInterval(string sData, double dfDS1Show, double  dfDS2Show)
        {
            trackDataListInterval curDataList = new trackDataListInterval();

            string[] split = sData.Trim().Split(new string[] { cProjectData.splitMark }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < split.Length; i = i + 2)
            {  
                float top= float.Parse(split[i]);
                float bottom=float.Parse(split[i + 1]);
                if ( dfDS1Show<=top &&bottom<= dfDS2Show)
                {
                    curDataList.fListDS1.Add(top);
                    curDataList.fListDS2.Add(bottom);
                }
            }
            return curDataList;
        }

        public static trackDataListScatterPoint getTrackDataScatter(string sData, double dfDS1Show, double dfDS2Show)
        {
            trackDataListScatterPoint stt = new trackDataListScatterPoint();

            string[] split = sData.Trim().Split(new string[] { cProjectData.splitMark }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < split.Length; i = i + 2)
            {
                double top = double.Parse(split[i]);
                float value = float.Parse(split[i + 1]);
                if (dfDS1Show <= top && top <= dfDS2Show)
                {
                    stt.fListDepth.Add(top);
                    stt.fListValue.Add(value);
                }
            }
            return stt;
        }

        public static trackDataListIntervalText getTrackDataIntervalText(string sData, double dfDS1Show, double dfDS2Show)
        {
            trackDataListIntervalText curDataList = new trackDataListIntervalText();
            string[] split = sData.Trim().Split(new string[] { cProjectData.splitMark }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < split.Length; i = i + 3)
            {  
                float top= float.Parse(split[i]);
                float bottom=float.Parse(split[i + 1]);
                if ( dfDS1Show<=top &&bottom<= dfDS2Show)
                {
                    curDataList.fListDS1.Add(top);
                    curDataList.fListDS2.Add(bottom);
                    curDataList.ltStrText.Add(split[i + 2]);
                }
            }
            return curDataList;
        }

     
        public static trackDataListLog getLogSeriersFromSectionWell(string sJHSelected, string sLogname, int dfDS1Show, int dfDS2Show) 
        {
            trackDataListLog sttTrackLogDataList = new trackDataListLog();
            
            string filePathLogTXT = Path.Combine(cProjectManager.dirPathLog, sJHSelected + "_$#log");
            if (File.Exists(filePathLogTXT))
            {

                using (StreamReader sr = new StreamReader(filePathLogTXT, Encoding.UTF8))
                {
                    String line;
                    string[] split;
                    int iLineIndex = 0;
                    int iIndex = 0;
                    while ((line = sr.ReadLine()) != null) //delete the line whose legth is 0
                    {
                        iLineIndex++;
                        split = line.Trim().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                        if (iLineIndex == 1)
                        {
                           
                            iIndex = split.ToList().IndexOf(sLogname);
                        }
                        else if (iLineIndex % 2 == 0 ) //抽稀一半点数。 
                        {
                            float fDepth = float.Parse(split[0]);
                            if (fDepth >= dfDS1Show && fDepth <= dfDS2Show)
                            {
                                sttTrackLogDataList.fListMD.Add(fDepth);
                                if (iIndex >= 0)
                                    sttTrackLogDataList.fListValue.Add(float.Parse(split[iIndex]));
                                else
                                    sttTrackLogDataList.fListValue.Add(-999);
                            }
                        }
                    }
                }
            }
            return sttTrackLogDataList;
        }

        public static trackDataListJSJL getTrackJSJLDataList(string sData, double  dfDS1Show, double dfDS2Show)
        {
            trackDataListJSJL sttTrackDataList = new trackDataListJSJL();

            string[] split = sData.Trim().Split(new string[] { cProjectData.splitMark }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < split.Length; i = i + 3)
            {  
                float top= float.Parse(split[i]);
                float bottom=float.Parse(split[i + 1]);
                if ( dfDS1Show<=top &&bottom<= dfDS2Show)
                {
                    sttTrackDataList.fListDS1.Add(top);
                    sttTrackDataList.fListDS2.Add(bottom);
                    sttTrackDataList.sListJSJL.Add(split[i + 2]);
                }
            }
            return sttTrackDataList;
        }

        public static trackInputPerforationDataList gettrackInputPerforationDataList(string sData, int dfDS1Show, int dfDS2Show)
        {
            trackInputPerforationDataList sttTrackDataList = new trackInputPerforationDataList();

            string[] split = sData.Trim().Split(new string[] { cProjectData.splitMark }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < split.Length; i = i + 3)
            {  
                float top= float.Parse(split[i]);
                float bottom=float.Parse(split[i + 1]);
                if (!(dfDS2Show <= top || dfDS1Show >= bottom))
                {
                    sttTrackDataList.fListDS1.Add(top);
                    sttTrackDataList.fListDS2.Add(bottom);
                }
            }
            return sttTrackDataList;
        }


        public static trackDataListIntervalText getTrackTextDataList(string sData, int dfDS1Show, int dfDS2Show)
        {
            trackDataListIntervalText sttTrackDataList = new trackDataListIntervalText();

            string[] split = sData.Trim().Split(new char[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < split.Length; i = i + 3)
            {
                float top = float.Parse(split[i]);
                float bottom = float.Parse(split[i + 1]);
                if (!(dfDS2Show <= top || dfDS1Show >= bottom))
                {
                    sttTrackDataList.fListDS1.Add(top);
                    sttTrackDataList.fListDS2.Add(bottom);
                    sttTrackDataList.ltStrText.Add(split[i + 2]);
                }
            }
            return sttTrackDataList;
        }

        public static trackScatterDataList getTrackScatterDataList(string sData, int dfDS1Show, int dfDS2Show)
        {
            trackScatterDataList sttTrackDataList = new trackScatterDataList();
            sttTrackDataList.fListDS1 = new List<float>();
            sttTrackDataList.fListValue = new List<float>();

            string[] split = sData.Trim().Split(new char[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < split.Length; i = i + 2)
            {
                float top = float.Parse(split[i]);
                float value = float.Parse(split[i + 1]);
                if (dfDS1Show <= top && top <= dfDS2Show)
                {
                    sttTrackDataList.fListDS1.Add(top);
                    sttTrackDataList.fListValue.Add(value);
                }
            }
            return sttTrackDataList;
        }
       
        
    }
}
