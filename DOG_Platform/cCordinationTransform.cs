using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace DOGPlatform
{
    class cCordinationTransform:cPublicMethodBase
    {
        public static PointF transRealPointF2ViewPointF
          (double df_XReal, double df_YReal, double df_XRealRefer, double df_YRealRefer, float f_scale)
        {
            PointF PointFReturn = new PointF();
            PointFReturn.X = Convert.ToSingle((df_XReal - df_XRealRefer) * f_scale);
            PointFReturn.Y = Convert.ToSingle((df_YRealRefer - df_YReal) * f_scale);
            return PointFReturn;
        }

        public static Point transRealPointF2ViewPoint
    (double df_XReal, double df_YReal, double df_XRealRefer, double df_YRealRefer, int iWidth, double f_Xscale, int iheight, double f_Yscale)
        {
            Point PointReturn = new Point();
            PointReturn.X = Convert.ToInt32((df_XReal - df_XRealRefer) * f_Xscale);
            PointReturn.Y = Convert.ToInt32((df_YRealRefer - df_YReal) * f_Yscale);

            return PointReturn;
        }

        public static Point transRealPointF2ViewPoint
    (double df_XReal, double df_YReal, double df_XRealRefer, double df_YRealRefer, double dfscale)
        {
            Point PointReturn = new Point();
            PointReturn.X = Convert.ToInt32((df_XReal - df_XRealRefer) * dfscale);
            PointReturn.Y = Convert.ToInt32((df_YRealRefer - df_YReal) * dfscale);
            return PointReturn;
        }

        public static Point transRealPointF2ViewPointByCurrentSystemSetting(double df_XReal, double df_YReal)
        {
            Point PointReturn = new Point();
            PointReturn.X = Convert.ToInt32((df_XReal - cProjectData.dfMapXrealRefer) *  cProjectData.dfMapScale);
            PointReturn.Y = Convert.ToInt32((cProjectData.dfMapYrealRefer - df_YReal) * cProjectData.dfMapScale);
            return PointReturn;
        }
        public static double transXview2Xreal(int iXscreen, double df_XrealRefer, double dfscale)
        {
            return iXscreen / dfscale + df_XrealRefer;
        }

        public static double transYview2Yreal(int iYscreen, double df_YrealRefer, double dfscale)
        {
            return df_YrealRefer - iYscreen / dfscale;
        }
    
        public static Point getPointViewByJH(string sJH)
        {
            ItemWellHead wellHead = cIOinputWellHead.getWellHeadByJH(sJH); 
            Point pointView=transRealPointF2ViewPoint(wellHead.dbX, wellHead.dbY,
               cProjectData.dfMapXrealRefer, cProjectData.dfMapYrealRefer, cProjectData.dfMapScale);
            return pointView;
        }

    }
}
