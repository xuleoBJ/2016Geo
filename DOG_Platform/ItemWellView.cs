using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace DOGPlatform
{
    struct ItemWellView
    {
        public string sJH;
        public double dbX;
        public double dbY;
        public int iXview;
        public int iYview;
        public int iWellType;

        public ItemWellView(string sJH)
        {
            ItemWellHead item = cIOinputWellHead.getWellHeadByJH(sJH);
            this.sJH = sJH;
            this.dbX = item.dbX;
            this.dbY = item.dbY;
            this.iWellType = item.iWellType; 
            Point pointConvert2View = cCordinationTransform.transRealPointF2ViewPoint(item.dbX, item.dbY,cProjectData.dfMapXrealRefer, cProjectData.dfMapYrealRefer, cProjectData.dfMapScale);
            this.iXview = pointConvert2View.X;
            this.iYview = pointConvert2View.Y;

        }
    }
}
