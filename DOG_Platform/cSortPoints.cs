using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace DOGPlatform
{
    class cSortPoints
    {
        struct XYAngleID 
        {
            public int id;
            public double  fx;
            public double fy;
            public double angle;
        }

        public static List<PointD> sortPoints(List<PointD> points,PointD pCent)
        {
            List<XYAngleID> dfListAngle = new List<XYAngleID>();
            for (int i = 0; i < points.Count; i++)
            {
                XYAngleID agID = new XYAngleID();
                agID.id = i;
                agID.fx = points[i].X;
                agID.fy = points[i].Y;
                agID.angle = Angle(points[i], pCent); ;
                dfListAngle.Add(agID); 
            }

            List<PointD> listReturn = new List<PointD>();

            foreach (XYAngleID item in dfListAngle.OrderBy(p => p.angle))
            {
                listReturn.Add(new PointD(item.fx, item.fy));
            }

            return listReturn;

        }
         public static double Angle(PointD p1, PointD pCent)
        {
            //Calculate the angle
            double angle = System.Math.Atan2(p1.Y - pCent.Y, p1.X - pCent.X);

            // Convert to degrees
            angle = angle * 180 / System.Math.PI;
            if (p1.Y - pCent.Y > 0)
                angle = 180 + angle;
            return angle;
        }
       
      

    }
}
