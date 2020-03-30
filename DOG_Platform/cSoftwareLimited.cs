using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DOGPlatform
{
    class cSoftwareLimited
    {
        public static bool  limitedDay()
        {
            bool bValidDay = true;
            int iValidEndDay=20221231;
            int iToday = int.Parse(DateTime.Today.ToString("yyyyMMdd"));
            if (iToday >= iValidEndDay)
            {
                //删除所有配置文件。
                string dirPathPattern = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "pattern");
                cPublicMethodBase.DirectoryDelAllFiles(dirPathPattern);
                bValidDay = false;
            }
            return bValidDay;
        }
    }
}
