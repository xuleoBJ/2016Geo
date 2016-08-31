using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace DigRobot
{
    class  cCalMatrix
    {
        //计算三阶行列式
        public static float calDet3 (float a11,float  a12,float  a13,float a21,float a22,float a23,float a31,float a32,float a33)
        {
             float output = a11 * a22 * a33 + a12 * a23 * a31 + a13 * a21 * a32 - (a13 * a22 * a31 + a23 * a32 * a11 + a33 * a12 * a21);
             return output;
        }

        //计算三阶行列式3×3行列式
        public static double calDet3(double[,] x)
        {
            return x[0, 0] * x[1, 1] * x[2, 2] + x[1, 0] * x[2, 1] * x[0, 2] + x[0, 1] * x[1, 2] * x[2, 0] - x[2, 0] * x[1, 1] * x[0, 2] - x[2, 1] * x[1, 2] * x[0, 0] - x[1, 0] * x[0, 1] * x[2, 2];
        }

        //计算三阶行列式3×3行列式
        public static float calDet3(float[,] x)
        {
            return x[0, 0] * x[1, 1] * x[2, 2] + x[1, 0] * x[2, 1] * x[0, 2] + x[0, 1] * x[1, 2] * x[2, 0] - x[2, 0] * x[1, 1] * x[0, 2] - x[2, 1] * x[1, 2] * x[0, 0] - x[1, 0] * x[0, 1] * x[2, 2];
        }

        //计算三元一次线性方程组
        //arrayX是一个3x4的矩阵，前三列是系数，第4列是解
        //返回值是ArrayList 包含3个元素，为解
        public static List<float>  solveLinear3( float[,] arrayX) 
        {
            List<float> fListSolve3D = new List<float>();
            float[,] det_arrayX = new float[3, 3]
            { 
                {arrayX[0,0],arrayX[0,1], arrayX[0,2]},
                {arrayX[1,0],arrayX[1,1], arrayX[1,2]},
                {arrayX[2,0],arrayX[2,1], arrayX[2,2]}
            };

            float[,] det1_arrayX = new float[3, 3] {                
                {arrayX[0,3],arrayX[0,1], arrayX[0,2]},
                {arrayX[1,3],arrayX[1,1], arrayX[1,2]},
                {arrayX[2,3],arrayX[2,1], arrayX[2,2]} 
            };

            float[,] det2_arrayX = new float[3, 3] {               
                {arrayX[0,0],arrayX[0,3], arrayX[0,2]},
                {arrayX[1,0],arrayX[1,3], arrayX[1,2]},
                {arrayX[2,0],arrayX[2,3], arrayX[2,2]}
            };

            float[,] det3_arrayX = new float[3, 3] {
                {arrayX[0,0],arrayX[0,1], arrayX[0,3]},
                {arrayX[1,0],arrayX[1,1], arrayX[1,3]},
                {arrayX[2,0],arrayX[2,1], arrayX[2,3]}};

            if (calDet3(det_arrayX) != 0)
            {
                
                fListSolve3D.Add(calDet3(det1_arrayX) / calDet3(det_arrayX));
                fListSolve3D.Add(calDet3(det2_arrayX) / calDet3(det_arrayX));
                fListSolve3D.Add(calDet3(det3_arrayX) / calDet3(det_arrayX));
            }
            else 
            {
                MessageBox.Show("矩阵非齐次。");
            }
            return fListSolve3D;
        }

        //返回值是ArrayList 包含3个元素，为解
        public static List<double> solveLinear3(double[,] arrayX)
        {
            List<double> fListSolve3D = new List<double>();
            double[,] det_arrayX = new double[3, 3]
            { 
                {arrayX[0,0],arrayX[0,1], arrayX[0,2]},
                {arrayX[1,0],arrayX[1,1], arrayX[1,2]},
                {arrayX[2,0],arrayX[2,1], arrayX[2,2]}
            };

            double[,] det1_arrayX = new double[3, 3] {                
                {arrayX[0,3],arrayX[0,1], arrayX[0,2]},
                {arrayX[1,3],arrayX[1,1], arrayX[1,2]},
                {arrayX[2,3],arrayX[2,1], arrayX[2,2]} 
            };

            double[,] det2_arrayX = new double[3, 3] {               
                {arrayX[0,0],arrayX[0,3], arrayX[0,2]},
                {arrayX[1,0],arrayX[1,3], arrayX[1,2]},
                {arrayX[2,0],arrayX[2,3], arrayX[2,2]}
            };

            double[,] det3_arrayX = new double[3, 3] {
                {arrayX[0,0],arrayX[0,1], arrayX[0,3]},
                {arrayX[1,0],arrayX[1,1], arrayX[1,3]},
                {arrayX[2,0],arrayX[2,1], arrayX[2,3]}};

            if (calDet3(det_arrayX) != 0)
            {

                fListSolve3D.Add(calDet3(det1_arrayX) / calDet3(det_arrayX));
                fListSolve3D.Add(calDet3(det2_arrayX) / calDet3(det_arrayX));
                fListSolve3D.Add(calDet3(det3_arrayX) / calDet3(det_arrayX));

                //fListSolve3D.Add(Math.Round(calDet3(det1_arrayX) / calDet3(det_arrayX), 4));
                //fListSolve3D.Add(Math.Round(calDet3(det2_arrayX) / calDet3(det_arrayX), 4));
                //fListSolve3D.Add(Math.Round(calDet3(det3_arrayX) / calDet3(det_arrayX), 4));
            }
            else
            {
                MessageBox.Show("矩阵非齐次。");
            }
            return fListSolve3D;
        }

        #region ///矩阵加减乘除等计算 需要测试

        
        /// 矩阵的乘
        public bool MatrixMultiply(double[,] a, double[,] b, ref double[,] c)
        {
            if (a.GetLength(1) != b.GetLength(0))
                return false;
            if (a.GetLength(0) != c.GetLength(0) || b.GetLength(1) != c.GetLength(1))
                return false;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    c[i, j] = 0;
                    for (int k = 0; k < b.GetLength(0); k++)
                    {
                        c[i, j] += a[i, k] * b[k, j];
                    }
                }
            }

            return true;
        }

        /// 矩阵的加
        public bool MatrixAdd(double[,] a, double[,] b, ref double[,] c)
        {
            if (a.GetLength(0) != b.GetLength(0) || a.GetLength(1) != b.GetLength(1)
                || a.GetLength(0) != c.GetLength(0) || a.GetLength(1) != c.GetLength(1))
                return false;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    c[i, j] = a[i, j] + b[i, j];
                }
            }

            return true;
        }

        /// 矩阵的减
        public bool MatrixSubtration(double[,] a, double[,] b, ref double[,] c)
        {
            if (a.GetLength(0) != b.GetLength(0) || a.GetLength(1) != b.GetLength(1)
                || a.GetLength(0) != c.GetLength(0) || a.GetLength(1) != c.GetLength(1))
                return false;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    c[i, j] = a[i, j] - b[i, j];
                }
            }

            return true;
        }

        /// 矩阵的行列式的值
        public double MatrixSurplus(double[,] a)
        {
            int i, j, k, p, r, m, n;
            m = a.GetLength(0);
            n = a.GetLength(1);
            double X, temp = 1, temp1 = 1, s = 0, s1 = 0;

            if (n == 2)
            {
                for (i = 0; i < m; i++)
                    for (j = 0; j < n; j++)
                        if ((i + j) % 2 > 0) temp1 *= a[i, j];
                        else temp *= a[i, j];
                X = temp - temp1;
            }
            else
            {
                for (k = 0; k < n; k++)
                {
                    for (i = 0, j = k; i < m && j < n; i++, j++)
                        temp *= a[i, j];
                    if (m - i > 0)
                    {
                        for (p = m - i, r = m - 1; p > 0; p--, r--)
                            temp *= a[r, p - 1];
                    }
                    s += temp;
                    temp = 1;
                }

                for (k = n - 1; k >= 0; k--)
                {
                    for (i = 0, j = k; i < m && j >= 0; i++, j--)
                        temp1 *= a[i, j];
                    if (m - i > 0)
                    {
                        for (p = m - 1, r = i; r < m; p--, r++)
                            temp1 *= a[r, p];
                    }
                    s1 += temp1;
                    temp1 = 1;
                }

                X = s - s1;
            }
            return X;
        }

        /// 矩阵的转置
        public bool MatrixInver(double[,] a, ref double[,] b)
        {
            if (a.GetLength(0) != b.GetLength(1) || a.GetLength(1) != b.GetLength(0))
                return false;
            for (int i = 0; i < a.GetLength(1); i++)
                for (int j = 0; j < a.GetLength(0); j++)
                    b[i, j] = a[j, i];

            return true;
        }

        /// 矩阵的逆
        public bool MatrixOpp(double[,] a, ref double[,] b)
        {
            double X = MatrixSurplus(a);
            if (X == 0) return false;
            X = 1 / X;

            double[,] B = new double[a.GetLength(0), a.GetLength(1)];
            double[,] SP = new double[a.GetLength(0), a.GetLength(1)];
            double[,] AB = new double[a.GetLength(0), a.GetLength(1)];

            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    for (int m = 0; m < a.GetLength(0); m++)
                        for (int n = 0; n < a.GetLength(1); n++)
                            B[m, n] = a[m, n];
                    {
                        for (int x = 0; x < a.GetLength(1); x++)
                            B[i, x] = 0;
                        for (int y = 0; y < a.GetLength(0); y++)
                            B[y, j] = 0;
                        B[i, j] = 1;
                        SP[i, j] = MatrixSurplus(B);
                        AB[i, j] = X * SP[i, j];
                    }
                }
            MatrixInver(AB, ref b);

            return true;
        }
        #endregion

    }
}
