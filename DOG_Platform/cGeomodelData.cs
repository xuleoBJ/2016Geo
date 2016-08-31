using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using DOGPlatform;

namespace DOGPlatform
{
     class cGeomodelData 
    {
         public double[,] ddZelevation;   //海拔深度
         public double[,] ddPore;   //海拔深度
         public double[,] ddPermealiby;   //海拔深度
         public double[,] ddSo;   //海拔深度
         cGridPara gridPara;
         public cGeomodelData(cGridPara cgp) 
         {
             this.gridPara = cgp;
             initDataStruct();
         }
        
        void initDataStruct()
        {
            ddZelevation = new double[gridPara.iXsize, gridPara.iYsize];
            for (int i = 0; i <gridPara. iXsize; i++)
                for (int j = 0; j < gridPara.iYsize; j++)
                    ddZelevation[i, j] = 99.0;
        }
    }
}
