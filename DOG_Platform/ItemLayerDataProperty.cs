using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DOGPlatform
{
    class ItemLayerDataProperty
    {
        public string sJH;
        public string sID;
        public string sXCM;
        public float top;
        public float bot;
        public float topTVD;
        public float botTVD;

        public string sText;
        public string sProperty;
        public object obj;
        public ItemLayerDataProperty(string _sJH,string _sXCM)
        {
            this.sJH = _sJH;
            this.sXCM = _sXCM;
            this.top = -999;
            this.bot = -999;
            //根据井号和小层名确定top bot
        }
        public ItemLayerDataProperty(string _sJH,float _fTop,float _fBot)
        {
            this.sJH = _sJH;
            this.top = _fBot;
            this.bot = _fBot;
        }  
    }
}
