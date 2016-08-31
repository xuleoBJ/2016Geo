using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace DOGPlatform
{
    struct ItemFaultLine
    {
        public string sXCM;
        public string sFaultName;
        public List<PointD> ltPoints;
        public int isUp;
    }

    struct ItemFaultPoint
    {
        public string sXCM;
        public string sFaultName;
        public double dbx;
        public double dby;
        public double dbz;
     
    }
}
