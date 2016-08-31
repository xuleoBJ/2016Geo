using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace DOGPlatform
{
    class cCalBase
    {

        //去除fList中的无效值，大于0有效
        public List<float> deleteInvalidValueInList(List<float> fList)
        {
            List<float> fNewList = fList.Where(item => item > 0).ToList<float>();
            return fNewList;

        }
        //去除fList中的无效值,有最大，最小值门槛
        public List<float> deleteInvalidValueInList(List<float> fList, float m_MaxValid, float m_MinValid)
        {
            List<float> fNewList = fList.Where(item => item >= m_MinValid && item <= m_MaxValid).ToList<float>();
            return fNewList;
        }
        // 求带无效值得厚度加权 
        public float weightedBYThickNessWithourInvalidValue(List<float> fListProperty, List<float> fListHD)
        {
            float fReturn = 0;
            List<float> fListProperty_copy = new List<float>(fListProperty.ToArray()); // copy of t
            List<float> fListHD_copy = new List<float>(fListHD.ToArray()); // copy of t
            if (fListProperty.Count != fListHD.Count || fListProperty.Count == 0)
            {
                //MessageBox.Show("输入两个数组包元素不等或者输入为空");
                fReturn = 0;
            }
            else
            {
                int iItemInvalid = fListProperty_copy.FindLastIndex(item => item <= 0);
                while (iItemInvalid >= 0)
                {
                    fListProperty_copy.RemoveAt(iItemInvalid);
                    fListHD_copy.RemoveAt(iItemInvalid);
                    iItemInvalid = fListProperty_copy.FindLastIndex(item => item <= 0);
                }

                if (fListProperty_copy.Count > 0)
                {
                    for (int i = 0; i < fListProperty_copy.Count; i++)
                    {
                        fReturn = fReturn + fListProperty_copy[i] * fListHD_copy[i];
                    }
                    fReturn = fReturn / fListHD_copy.Sum();
                }
                else
                {
                    fReturn = 0;
                }

            }
            return fReturn;

        }

        //这段代码可能有问题！！！，需要test
        public float weightedBYThickNessWithourInvalidValue(List<float> fListProperty, List<float> fListHD, float m_MaxValid, float m_MinValid)
        {
            float fReturn = 0;
            List<float> fListProperty_copy = new List<float>(fListProperty.ToArray()); // copy of t
            List<float> fListHD_copy = new List<float>(fListHD.ToArray()); // copy of t
            if (fListProperty.Count != fListHD.Count || fListProperty.Count == 0)
            {
                //MessageBox.Show("输入两个数组包元素不等或者输入为空");
                fReturn = 0;
            }
            else
            {
                int iItemInvalid = fListProperty_copy.FindLastIndex(item => item < m_MinValid || item > m_MaxValid);
                while (iItemInvalid >= 0)
                {
                    fListProperty_copy.RemoveAt(iItemInvalid);
                    fListHD_copy.RemoveAt(iItemInvalid);
                    iItemInvalid = fListProperty_copy.FindLastIndex(item => item < m_MinValid || item > m_MaxValid);
                }

                if (fListProperty_copy.Count > 0)
                {
                    for (int i = 0; i < fListProperty_copy.Count; i++)
                    {
                        fReturn = fReturn + fListProperty_copy[i] * fListHD_copy[i];
                    }

                }
                fReturn = fReturn / fListHD_copy.Sum();
            }
            return fReturn;

        }

        //求带无效值得最小值
        public float minWithourInvalidValue(List<float> fListProperty)
        {
            fListProperty = deleteInvalidValueInList(fListProperty);
            float fReturn = 0;
            if (fListProperty.Count > 0)
            {
                fReturn = fListProperty.Min();
            }

            return fReturn;


        }
        public float minWithourInvalidValue(List<float> fListProperty, float m_MaxValid, float m_MinValid)
        {
            fListProperty = deleteInvalidValueInList(fListProperty, m_MaxValid, m_MinValid);
            float fReturn = 0;
            if (fListProperty.Count > 0)
            {
                fReturn = fListProperty.Min();
            }

            return fReturn;

        }
        //求带无效值得最大值
        public float maxWithourInvalidValue(List<float> fListProperty)
        {

            fListProperty = deleteInvalidValueInList(fListProperty);
            float fReturn = 0;
            if (fListProperty.Count > 0)
            {
                fReturn = fListProperty.Max();
            }

            return fReturn;

        }
        public float maxWithourInvalidValue(List<float> fListProperty, float m_MaxValid, float m_MinValid)
        {

            fListProperty = deleteInvalidValueInList(fListProperty, m_MaxValid, m_MinValid);
            float fReturn = 0;
            if (fListProperty.Count > 0)
            {
                fReturn = fListProperty.Max();
            }
            return fReturn;
        }
        //求带无效值得算术平均
        public float meanWithourInvalidValue(List<float> fListProperty)
        {
            fListProperty = deleteInvalidValueInList(fListProperty);
            float fReturn = 0;
            if (fListProperty.Count > 0)
            {
                fReturn = fListProperty.Average();
            }
            return fReturn;
        }
        public float meanWithourInvalidValue(List<float> fListProperty, float m_MaxValid, float m_MinValid)
        {
            fListProperty = deleteInvalidValueInList(fListProperty, m_MaxValid, m_MinValid);
            float fReturn = 0;
            if (fListProperty.Count > 0)
            {
                fReturn = fListProperty.Average();
            }
            return fReturn;
        }

        //求带无效值的几何平均值
        public double meanGeometricWithourInvalidValue(List<float> fListProperty, float m_MaxValid, float m_MinValid)
        {
            fListProperty = deleteInvalidValueInList(fListProperty, m_MaxValid, m_MinValid);
            double fReturn = 0;
            if (fListProperty.Count > 0)
            {
                fReturn = 1;
                foreach (float fItem in fListProperty)
                {
                    fReturn = fReturn * Math.Pow(fItem, 1 / Convert.ToSingle(fListProperty.Count));
                }

            }
            return fReturn;
        }
        public double meanGeometricWithourInvalidValue(List<float> fListProperty)
        {
            fListProperty = deleteInvalidValueInList(fListProperty);
            double fReturn = 0;
            if (fListProperty.Count > 0)
            {
                fReturn = 1;
                foreach (float fItem in fListProperty)
                {
                    fReturn = fReturn * Math.Pow(fItem, 1 / Convert.ToSingle(fListProperty.Count));
                }

            }
            return fReturn;

        }

        public static double calPI(List<double> dfListSJ, List<double> dfListValue)
        {
            double sum = 0.0f;
            for (int i = 0; i < dfListSJ.Count - 2; i++) 
            {
                sum = sum + (dfListValue[i] + dfListValue[i + 1]) * (dfListSJ[i + 1] - dfListSJ[i]) * 0.5;
            }

            return sum / dfListSJ[dfListSJ.Count - 1];
        }

        public static double calArea(List<PointF> points)
        {
            if (points.Count >= 3)
            {
                points.Add(points[0]);
                var area = Math.Abs(points.Take(points.Count - 1)
                   .Select((p, i) => (points[i + 1].X - p.X) * (points[i + 1].Y + p.Y))
                   .Sum() / 2);
                return area ;
            }
            else return 0;
        }

        public static double calArea(List<PointD> points)
        {
            if (points.Count >= 3)
            {
                points.Add(points[0]);
                var area = Math.Abs(points.Take(points.Count - 1)
                   .Select((p, i) => (points[i + 1].X - p.X) * (points[i + 1].Y + p.Y))
                   .Sum() / 2);
                return area;
            }
            else return 0;
        }
        public static double calLength(List<PointF> points)
        {
            if (points.Count >= 2)
            {
                float dis = 0.0f;
                for (int i = 0; i < points.Count - 2; i++) 
                {
                    dis = dis + cCalDistance.calDistance2D(points[i].X, points[i].Y, points[i + 1].X, points[i + 1].Y);
                }
                return dis / 1000;
            }
            else return 0;
        }

        public static double linear(double x, double x0, double x1, double y0, double y1)
        {
            if ((x1 - x0) == 0)
            {
                return (y0 + y1) / 2;
            }
            return y0 + (x - x0) * (y1 - y0) / (x1 - x0);
        }
       
 

    }
}
