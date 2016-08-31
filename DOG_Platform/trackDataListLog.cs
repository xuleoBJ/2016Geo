using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DOGPlatform
{
    public class trackDataListLog
    {
            public itemLogHeadInforDraw itemHeadInforDraw = new itemLogHeadInforDraw();
            public List<double> fListMD = new List<double>();
            public List<double> fListValue = new List<double>();
            public trackDataListLog() 
            {
            
            }
            public void clearList()
            {
                fListMD.Clear();
                fListValue.Clear();
            }
            
           public List<double> getListValueRangeByDepth(double fTop,double fBot)
           {
               List<double> ltRangeValue = new List<double>();
               for (int i = 0; i < fListMD.Count; i++) 
               {
                   if (fListMD[i] >= fTop && fListMD[i] <= fBot) ltRangeValue.Add(fListValue[i]);
                   else if (fListMD[i] > fBot) break;
               }
              return ltRangeValue;
           
           }
    }
}
