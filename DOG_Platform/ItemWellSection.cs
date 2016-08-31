using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DOGPlatform
{
   class ItemWellSection : ItemWell
    {
       public ItemWellSection(string _sJH)
           : base(_sJH)
       {

       }
     
        public ItemWellSection(string _sJH,float _fTopDepth,float _fBaseDepth)
            : base(_sJH)
        {
            fShowedDepthTop = _fTopDepth;
            fShowedDepthBase = _fBaseDepth;
        }
        public float fShowedDepthTop { get; set; }
        public float fShowedDepthBase { get; set; }

        public float fXview { get; set; }
        public float fYview { get; set; }
    }
}
