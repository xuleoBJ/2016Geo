using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DOGPlatform
{
    class trackInputPerforationDataList
    {
        public List<float> fListDS1=new List<float>();
        public List<float> fListDS2=new List<float>();
        public List<string> ltStrYYYYMM=new List<string>();

        public static trackInputPerforationDataList setupDataListTrack(string filePath, float fTop, float fBase)
        {
            trackInputPerforationDataList getTrackDataListPerforation = new trackInputPerforationDataList();
            if (File.Exists(filePath))
            {
                string sData = "";
                using (StreamReader sr = new StreamReader(filePath, System.Text.Encoding.Default))
                {
                    sData = sr.ReadToEnd();
                }

                string[] split = sData.Trim().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < split.Length; i = i + 4)
                {
                    string sJH = split[i];
                    string iYYYYMM = split[i + 1];
                    float fCurrentTop = float.Parse(split[i + 2]);
                    float fCurrentBase = float.Parse(split[i + 3]);

                    if (fTop <= fCurrentTop && fCurrentBase <= fBase)
                    {
                        getTrackDataListPerforation.fListDS1.Add(fCurrentTop);
                        getTrackDataListPerforation.fListDS2.Add(fCurrentBase);
                        getTrackDataListPerforation.ltStrYYYYMM.Add(iYYYYMM);
                    }
                }
            }
            return getTrackDataListPerforation;
        }
    }
}
