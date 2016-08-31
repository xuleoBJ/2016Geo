using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DOGPlatform
{
    class cInterpolation
    {
        private cInterpolation() { }

        /// <summary>
        /// Linear interpolation at a single point x.
        /// </summary>
        /// <param name="x">double</param>
        /// <param name="x0">double</param>
        /// <param name="x1">double</param>
        /// <param name="y0">double</param>
        /// <param name="y1">double</param>
        /// <returns>double</returns>
        static public double linear(double x, double x0, double y0, double x1, double y1)
        {
            if ((x1 - x0) == 0)
            {
                return (y0 + y1) / 2;
            }
            return y0 + (x - x0) * (y1 - y0) / (x1 - x0);
        }
        static public float linear(float x, float x0, float y0, float x1, float y1)
        {
            if ((x1 - x0) == 0)
            {
                return (y0 + y1) / 2;
            }
            return y0 + (x - x0) * (y1 - y0) / (x1 - x0);
        }

        /// <summary>
        /// Lagrange polynomial interpolation at a single point x. Because Lagrange polynomials tend to be ill behaved, this method should be used with care.
        /// A LagrangeInterpolator object should be used if multiple interpolations are to be performed using the same data
        /// </summary>
        /// <param name="x">double</param>
        /// <param name="xd">the x data</param>
        /// <param name="yd">the y data</param>
        /// <returns>double</returns>
        static public double lagrange(double x, double[] xd, double[] yd)
        {
            if (xd.Length != yd.Length)
            {
                throw new ArgumentException("Arrays must be of equal length."); //$NON-NLS-1$
            }
            double sum = 0;
            for (int i = 0, n = xd.Length; i < n; i++)
            {
                if (x - xd[i] == 0)
                {
                    return yd[i];
                }
                double product = yd[i];
                for (int j = 0; j < n; j++)
                {
                    if ((i == j) || (xd[i] - xd[j] == 0))
                    {
                        continue;
                    }
                    product *= (x - xd[i]) / (xd[i] - xd[j]);
                }
                sum += product;
            }
            return sum;
        }
    }
}
