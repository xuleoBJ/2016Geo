using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace DOGPlatform
{
    public struct PointD
    {
        public double X;
        public double Y;

        public PointD(double x, double y)
        {
            X = x;
            Y = y;
        }

        public void setPoint(double x, double y)
        {
            this.X  = x;
            this.Y = y;
        }
        public Point ToPoint()
        {
            return new Point((int)X, (int)Y);
        }
        public PointF ToPointF()
        {
            return new PointF(float.Parse(X.ToString("0.0")), float.Parse(Y.ToString("0.0")));
        }
        public override bool Equals(object obj)
        {
            return obj is PointD && this == (PointD)obj;
        }
        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }
        public static bool operator ==(PointD a, PointD b)
        {
            return a.X == b.X && a.Y == b.Y;
        }
        public static bool operator !=(PointD a, PointD b)
        {
            return !(a == b);
        }
    }
}
