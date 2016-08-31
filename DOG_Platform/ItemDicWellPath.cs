using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DOGPlatform
{
    struct ItemDicWellPath
    {
            public string sJH;
            public double dbX;
            public double dbY;
            public double dfZ;
            public float f_md;
            public float f_incl;
            public float f_azim;
            public float f_dx;
            public float f_dy;
            public float f_TVD;
            public float f_CalcDLS;

            public static string item2string(ItemDicWellPath _item)
            {
                List<string> _ltStr = new List<string>();
                _ltStr.Add(_item.sJH);
                _ltStr.Add(_item.dbX.ToString("0.00"));
                _ltStr.Add(_item.dbY.ToString("0.00"));
                _ltStr.Add(_item.dfZ.ToString("0.00"));
                _ltStr.Add(_item.f_md.ToString("0.00"));
                _ltStr.Add(_item.f_incl.ToString("0.00"));
                _ltStr.Add(_item.f_azim.ToString("0.00"));
                _ltStr.Add(_item.f_dx.ToString("0.00"));
                _ltStr.Add(_item.f_dy.ToString("0.00"));
                _ltStr.Add(_item.f_TVD.ToString("0.00"));
                _ltStr.Add(_item.f_CalcDLS.ToString("0.00"));
                return string.Join(" ", _ltStr);
            }

            public ItemDicWellPath(string _sJH) 
            {
                sJH = _sJH;
                dbX = 0.0;
                dbY = 0.0;
                dfZ = 0.0;
                f_md = 0.0f;
                f_incl = 0.0f;
                f_azim = 0.0f;
                f_dx = 0.0f;
                f_dy = 0.0f;
                f_TVD = 0.0f;
                f_CalcDLS = 0.0f;  
            }
            public ItemDicWellPath(ItemWellHead wellHead)
            {
                sJH = wellHead.sJH ;
                dbX = wellHead.dbX ;
                dbY = wellHead.dbY ;
                dfZ = wellHead.fKB;
                f_md = 0.0f;
                f_incl = 0.0f;
                f_azim = 0.0f;
                f_dx = 0.0f;
                f_dy = 0.0f;
                f_TVD = 0.0f;
                f_CalcDLS = 0.0f;
            } 
    }
}
