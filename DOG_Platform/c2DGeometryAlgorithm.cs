using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Diagnostics;

namespace DOGPlatform
{
    class c2DGeometryAlgorithm
    {
        public static float calDistance2D(float x1, float y1, float x2, float y2)
        {
            return Convert.ToSingle(Math.Pow((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2), 0.5));
        }

        public static double calDistance2D(double x1, double y1, double x2, double y2)
        {
            return Math.Pow((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2), 0.5);
        }

        public static double calDistance2D(Point p1,Point p2 )
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }
        //返回值是弧度换角度 要×(180/Math.PI)
        public static double calAngel2D(Point p1, Point p2,Point p3)
        {
            double fAlen=Math.Sqrt(Math.Pow(p2.X - p3.X, 2) + Math.Pow(p2.Y - p3.Y, 2));
            double fBlen = Math.Sqrt(Math.Pow(p1.X - p3.X, 2) + Math.Pow(p1.Y - p3.Y, 2));
            double fClen = Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p3.Y, 2));
            double fAngle = Math.Acos((Math.Pow(fBlen, 2) + Math.Pow(fClen, 2) - Math.Pow(fAlen, 2)) / (fBlen * fClen));
            return fAngle;
        }
        private double AngleFrom3PointsInDegrees(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            double a = x2 - x1;
            double b = y2 - y1;
            double c = x3 - x2;
            double d = y3 - y2;

            double atanA = Math.Atan2(a, b);
            double atanB = Math.Atan2(c, d);

            return (atanA - atanB) * (-180 / Math.PI);
            // if Second line is counterclockwise from 1st line angle is 
            // positive, else negative
        }
        public static double PointToSegDist(double x, double y, double x1, double y1, double x2, double y2)
        {
            double cross = (x2 - x1) * (x - x1) + (y2 - y1) * (y - y1);
            if (cross <= 0) return Math.Sqrt((x - x1) * (x - x1) + (y - y1) * (y - y1));

            double d2 = (x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1);
            if (cross >= d2) return Math.Sqrt((x - x2) * (x - x2) + (y - y2) * (y - y2));

            double r = cross / d2;
            double px = x1 + (x2 - x1) * r;
            double py = y1 + (y2 - y1) * r;
            return Math.Sqrt((x - px) * (x - px) + (py - y1) * (py - y1));
        }
        /** * Determines the angle of a straight line drawn between point one and two. The number returned, which is a float in degrees, tells us how much we have to rotate a horizontal line clockwise for it to match the line between the two points. * If you prefer to deal with angles using radians instead of degrees, just change the last line to: "return Math.Atan2(yDiff, xDiff);" */ 
        public static double  GetAngleOfLineBetweenTwoPoints(PointF p1, PointF p2) 
        {
            float xDiff = p2.X - p1.X; 
            float yDiff = p2.Y - p1.Y; 
            return Math.Atan2(yDiff, xDiff) * (180 / Math.PI);
        } 
        /// 判断两条线是否相交
        /// </summary>
        /// <param name="a">线段1起点坐标</param>
        /// <param name="b">线段1终点坐标</param>
        /// <param name="c">线段2起点坐标</param>
        /// <param name="d">线段2终点坐标</param>
        /// <param name="intersection">相交点坐标</param>
        /// <returns>是否相交 0:两线平行  -1:不平行且未相交  1:两线相交</returns>
        private int GetIntersection(Point a, Point b, Point c, Point d ,ref Point intersection)
        {
            //判断异常
            if (Math.Abs(b.X - a.Y) + Math.Abs(b.X - a.X) + Math.Abs(d.Y - c.Y) + Math.Abs(d.X - c.X) == 0)
            {
                if (c.X - a.X == 0)
                {
                   Debug.Print("ABCD是同一个点！");
                }
                else
                {
                    Debug.Print("AB是一个点，CD是一个点，且AC不同！");
                }
                return 0;
            }
           
            if (Math.Abs(b.Y - a.Y) + Math.Abs(b.X - a.X) == 0)
            {
                if ((a.X - d.X) * (c.Y - d.Y) - (a.Y - d.Y) * (c.X - d.X) == 0)
                {
                    Debug.Print ("A、B是一个点，且在CD线段上！");
                }
                else
                {
                     Debug.Print ("A、B是一个点，且不在CD线段上！");
                }
                return 0;
            }
            if (Math.Abs(d.Y - c.Y) + Math.Abs(d.X - c.X) == 0)
            {
                if ((d.X - b.X) * (a.Y - b.Y) - (d.Y - b.Y) * (a.X - b.X) == 0)
                {
                    Debug.Print ("C、D是一个点，且在AB线段上！");
                }
                else
                {
                    Debug.Print ("C、D是一个点，且不在AB线段上！");
                }
            }
           
            if ((b.Y - a.Y) * (c.X - d.X) - (b.X - a.X) * (c.Y - d.Y) == 0)
            {
                Debug.Print ("线段平行，无交点！");
                return 0;
            }
           
            intersection.X = ((b.X - a.X) * (c.X - d.X) * (c.Y - a.Y) - c.X * (b.X - a.X) * (c.Y - d.Y) + a.X * (b.Y - a.Y) * (c.X - d.X)) / ((b.Y - a.Y) * (c.X - d.X) - (b.X - a.X) * (c.Y - d.Y));
            intersection.Y = ((b.Y - a.Y) * (c.Y - d.Y) * (c.X - a.X) - c.Y * (b.Y - a.Y) * (c.X - d.X) + a.Y * (b.X - a.X) * (c.Y - d.Y)) / ((b.X - a.X) * (c.Y - d.Y) - (b.Y - a.Y) * (c.X - d.X));
           
            if ((intersection.X - a.X) * (intersection.X - b.X) <= 0 && (intersection.X - c.X) * (intersection.X - d.X) <= 0 && (intersection.Y - a.Y) * (intersection.Y - b.Y) <= 0 && (intersection.Y - c.Y) * (intersection.Y - d.Y) <= 0)
            {
                Debug.Print ("线段相交于点(" + intersection.X + "," + intersection.Y + ")！");
                return 1; //'相交
            }
            else
            {
                Debug.Print("线段相交于虚交点(" + intersection.X + "," + intersection.Y + ")！");
                return -1; //'相交但不在线段上
            }
        }
        //判断点是否在多边形里
        static bool PointInPolygon(Point p, Point[] poly)
        {
            Point p1, p2;

            bool inside = false;

            if (poly.Length < 3)
            {
                return inside;
            }

            Point oldPoint = new Point(
            poly[poly.Length - 1].X, poly[poly.Length - 1].Y);

            for (int i = 0; i < poly.Length; i++)
            {
                Point newPoint = new Point(poly[i].X, poly[i].Y);

                if (newPoint.X > oldPoint.X)
                {
                    p1 = oldPoint;
                    p2 = newPoint;
                }
                else
                {
                    p1 = newPoint;
                    p2 = oldPoint;
                }

                if ((newPoint.X < p.X) == (p.X <= oldPoint.X)
                && ((long)p.Y - (long)p1.Y) * (long)(p2.X - p1.X)
                 < ((long)p2.Y - (long)p1.Y) * (long)(p.X - p1.X))
                {
                    inside = !inside;
                }

                oldPoint = newPoint;
            }

            return inside;
        }

      
      
    }
}
