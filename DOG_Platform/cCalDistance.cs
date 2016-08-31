using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace DOGPlatform
{
    class cCalDistance
    {
        public static float calDistance2D(float x1, float y1, float x2, float y2)
        {
            return Convert.ToSingle(Math.Pow((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2), 0.5));
        }
        public static double calDistance2D(double x1, double y1, double x2, double y2)
        {
            return Math.Pow((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2), 0.5);
        }
        public static float calDistance2D(PointF p1, PointF p2)
        {
            return calDistance2D(p1.X, p1.Y, p2.X, p2.Y);
        }

        //找到井距离近的几口井
        public struct wellDis
        {
            public string sJH;
            public double distance;
        }
        public static List<string> getNearWells(string sJH, int iNum)
        {
            List<string> listJH = new List<string>();
            var newList = orderByWelldistance( sJH);
            for (int i = 1; i <= iNum; i++) listJH.Add(newList[i].sJH);
            return listJH;
        }

        public static List<wellDis> orderByWelldistance(string sJH)
        {
            List<string> listJH = new List<string>();
            ItemWell currentWell = cProjectData.ltProjectWell.Find(p => p.sJH == sJH);

            List<wellDis> ltWells = new List<wellDis>();
            foreach (ItemWell item in cProjectData.ltProjectWell)
            {
                double dfDis = cCalDistance.calDistance2D(currentWell.dbX, currentWell.dbY, item.dbX, item.dbY);
                wellDis newItem = new wellDis();
                newItem.sJH = item.sJH;
                newItem.distance = dfDis;
                ltWells.Add(newItem);
            }
            return ltWells.OrderBy(p => p.distance).ToList();
         
        }
    }
}
