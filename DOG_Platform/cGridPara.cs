using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DOGPlatform
{
    class cGridPara
    {
        ///
        ///  Xsize Ysize
        ///  Xstep Ystep
        ///  Xmin Ymin
        ///
        public int iXsize , iYsize ;
        public double dXstep , dYstep;
        public double dXmin , dYmin ;
        

        public cGridPara(): this( 1, 1, 0.0,0.0,0.0,0.0)
        {
           
        }
        public cGridPara(int _iXsize, int _iYsize)
            : this( _iXsize, _iYsize, 0.0,0.0,0.0,0.0)
        {
   
        }

        public cGridPara(int _iXsize, int _iYsize, double _dXstep, double _dYstep, double _dXmin, double _dYmin)
        {
            iXsize = _iXsize; iYsize = _iYsize;
            dXstep = _dXstep; dYstep = _dYstep;
            dXmin = _dXmin; dYmin = _dYmin;
        }
       
        
    }
}
