using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DOGPlatform
{
    class cPerforationList : cIOinputWellPerforation
    {
        public List<string> ltStrWellName_perforation = new List<string>();
        public List<string> ltStrYearMonth_perforation = new List<string>();
        public List<float> fListTopDepth_perforation = new List<float>();
        public List<float> fListBottomDepth_perforation = new List<float>();

    }
}
