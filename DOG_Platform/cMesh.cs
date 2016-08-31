using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DOGPlatform
{
    class cMesh
    {
        ///
        ///  Xsize Ysize
        ///  Xstep Ystep
        ///  Xmin Ymin
        ///
        public int iXsize , iYsize ;
        public double dXstep , dYstep;
        public double dXmin , dYmin ;
        public double[,] dZelevation;   //海拔深度

        public cMesh(): this( 1, 1, 0.0,0.0,0.0,0.0)
        {
           
        }
        public cMesh(int _iXsize, int _iYsize)
            : this( _iXsize, _iYsize, 0.0,0.0,0.0,0.0)
        {
   
        }

        public cMesh(int _iXsize, int _iYsize, double _dXstep, double _dYstep, double _dXmin, double _dYmin)
        {
            iXsize = _iXsize; iYsize = _iYsize;
            dXstep = _dXstep; dYstep = _dYstep;
            dXmin = _dXmin; dYmin = _dYmin;

            //海拔深度
            initDataStruct();
        }
        void initDataStruct()
        {
           dZelevation = new double[iXsize, iYsize];
           for (int i = 0; i < iXsize; i++)
               for (int j = 0; j < iYsize; j++)
                   dZelevation[i, j] = 99.0;
        }
        
    }
}
