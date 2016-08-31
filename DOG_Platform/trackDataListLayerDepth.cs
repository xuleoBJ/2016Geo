using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DOGPlatform
{
    class trackDataListLayerDepth
    {
        public List<string> ltStrXCM=new List<string>();
        public List<float> fListDS1=new List<float>();
        public List<float> fListDS2 =new List<float>();

        public static trackDataListLayerDepth setupDataListTrackLayerDepth(string filePath, float fTop, float fBase)
        {
            trackDataListLayerDepth getTrackDataListLayerDepth = new trackDataListLayerDepth();

            string sData = "";
            if (Directory.Exists( filePath))
            {
                using (StreamReader sr = new StreamReader(filePath, System.Text.Encoding.Default)) sData = sr.ReadToEnd();
            }
            string[] split = sData.Trim().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < split.Length; i = i + 3)
            {
                float fCurrentTop = float.Parse(split[i]);
                float fCurrentBase = float.Parse(split[i + 1]);
                if (fTop <= fCurrentTop && fCurrentBase <= fBase)
                {
                    getTrackDataListLayerDepth.fListDS1.Add(fCurrentTop);
                    getTrackDataListLayerDepth.fListDS2.Add(fCurrentBase);
                    getTrackDataListLayerDepth.ltStrXCM.Add(split[i + 2]);
                }
            }
            return getTrackDataListLayerDepth;
        }
    }
}
