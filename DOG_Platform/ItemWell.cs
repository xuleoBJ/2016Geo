using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DOGPlatform
{
    class ItemWell
    {
        public ItemWell()
        {
            this.sJH = "";
        }

        public List<ItemDicWellPath> WellPathList = new List<ItemDicWellPath>();
        public ItemWell(string _sJH) 
        {
            this.sJH = _sJH;
           
            ItemWellHead currentItemWellHead = cIOinputWellHead.getWellHeadByJH(_sJH);
            this.dbX = currentItemWellHead.dbX;
            this.dbY = currentItemWellHead.dbY;
            this.fKB = currentItemWellHead.fKB;
            this.iWellType = currentItemWellHead.iWellType;
            this.fWellBase = currentItemWellHead.fWellBase;
            WellPathList = cIOinputWellPath.readWellPath2Struct(_sJH);
        }
        public ItemWell(string _sJH, double _x, double _y, float _kb):this(_sJH,_x,_y,_kb,0,0)
        {
            
        } 
 
        public ItemWell(string _sJH, double _x, double _y, float _kb, int _iWellType,float _fWellBase)
        {
            this.sJH = _sJH;
            this.dbX = _x;
            this.dbY = _y;
            this.fKB = _kb;
            this.iWellType = _iWellType;
            this.fWellBase = _fWellBase;
            WellPathList = cIOinputWellPath.readWellPath2Struct(_sJH);
        }
        public string sJH { get; set; }

        public double dbX
        {
            get;
            set;
        }

        public double dbY
        {
            get;
            set;
        }

        public float fKB
        {
            get;
            set;
        }

        public int iWellType
        {
            get;
            set;
        }
        public float fWellBase
        {
            get;
            set;
        }

    }
}
