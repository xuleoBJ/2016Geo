using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DOGPlatform
{
    public class Vector2D
    {
        public double X;
        public double Y;

        // Constructors.
        public Vector2D(double x, double y) { X = x; Y = y; }
        public Vector2D() : this(double.NaN, double.NaN) { }

        public static Vector2D operator -(Vector2D v, Vector2D w)
        {
            return new Vector2D(v.X - w.X, v.Y - w.Y);
        }

        public static Vector2D operator +(Vector2D v, Vector2D w)
        {
            return new Vector2D(v.X + w.X, v.Y + w.Y);
        }

        public static double operator *(Vector2D v, Vector2D w)
        {
            return v.X * w.X + v.Y * w.Y;
        }

        public static Vector2D operator *(Vector2D v, double mult)
        {
            return new Vector2D(v.X * mult, v.Y * mult);
        }

        public static Vector2D operator *(double mult, Vector2D v)
        {
            return new Vector2D(v.X * mult, v.Y * mult);
        }

        public double Cross(Vector2D v)
        {
            return X * v.Y - Y * v.X;
        }

        public override bool Equals(object obj)
        {
            var v = (Vector2D)obj;
            return (X - v.X).IsZero() && (Y - v.Y).IsZero();
        }

        public override string ToString()
        {
            return string.Format("({0};{1})", X, Y);
        }
    }

    public static class Extensions
    {
        private const double Epsilon = 1e-10;

        public static bool IsZero(this double d)
        {
            return Math.Abs(d) < Epsilon;
        }
    }

    public class LineSegment
    {
        /// <summary>
        /// Test whether two line segments intersect. If so, calculate the intersection point.
        /// <see cref="http://stackoverflow.com/a/14143738/292237"/>
        /// </summary>
        /// <param name="p">Vector2D to the start point of p.</param>
        /// <param name="p2">Vector2D to the end point of p.</param>
        /// <param name="q">Vector2D to the start point of q.</param>
        /// <param name="q2">Vector2D to the end point of q.</param>
        /// <param name="intersection">The point of intersection, if any.</param>
        /// <param name="considerOverlapAsIntersect">Do we consider overlapping lines as intersecting?</param>
        /// <returns>True if an intersection point was found.</returns>
        public static bool LineSegementsIntersect(Vector2D p, Vector2D p2, Vector2D q, Vector2D q2, out Vector2D intersection, bool considerOverlapAsIntersect = false)
        {
            intersection = new Vector2D();

            var r = p2 - p;
            var s = q2 - q;
            var rxs = r.Cross(s);
            var qpxr = (q - p).Cross(r);

            // If r x s = 0 and (q - p) x r = 0, then the two lines are collinear.
            if (rxs.IsZero() && qpxr.IsZero())
            {
                // 1. If either  0 <= (q - p) * r <= r * r or 0 <= (p - q) * s <= * s
                // then the two lines are overlapping,
                if (considerOverlapAsIntersect)
                    if ((0 <= (q - p) * r && (q - p) * r <= r * r) || (0 <= (p - q) * s && (p - q) * s <= s * s))
                        return true;

                // 2. If neither 0 <= (q - p) * r ≤ r * r nor 0 <= (p - q) * s <= s * s
                // then the two lines are collinear but disjoint.
                // No need to implement this expression, as it follows from the expression above.
                return false;
            }

            // 3. If r x s = 0 and (q - p) x r != 0, then the two lines are parallel and non-intersecting.
            if (rxs.IsZero() && !qpxr.IsZero())
                return false;

            // t = (q - p) x s / (r x s)
            var t = (q - p).Cross(s) / rxs;

            // u = (q - p) x r / (r x s)

            var u = (q - p).Cross(r) / rxs;

            // 4. If r x s != 0 and 0 <= t <= 1 and 0 <= u <= 1
            // the two line segments meet at the point p + t r = q + u s.
            if (!rxs.IsZero() && (0 <= t && t <= 1) && (0 <= u && u <= 1))
            {
                // We can calculate the intersection point using either t or u.
                intersection = p + t * r;

                // An intersection was found.
                return true;
            }

            // 5. Otherwise, the two line segments are not parallel but do not intersect.
            return false;
        }
    }

   

}
