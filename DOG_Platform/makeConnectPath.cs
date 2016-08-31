using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DOGPlatform.SVG;

namespace DOGPlatform
{
    class makeConnectPath
    {
        public static string makePathd(cDataItemConnect item1, cDataItemConnect item2)
        {
            //x1 左上 x2 左下  ``
            // 要注意 item1 和 item2 的位置问题 item.X1 > item2.X2 时  应该交换
            if (item1.x1 > item2.x1) swap(ref item1, ref item2);
            double x1 = item1.x1 + item1.width;
            double y1 = item1.y1;
            double x2 = x1;
            double y2 = y1 + item1.height;
            double x3 = item2.x1;
            double y3 = item2.y1;
            double x4 = x3;
            double y4 = y3 + item2.height;
            string d = makePathd(x1, y1, x2, y2, x3, y3, x4, y4);
            return d;
        }

        public static string makePathd(double x1,double y1, double x2,double y2, double x3,double y3, double x4,double y4)
        {
            //x1 左上 x2 左下  ``
            int iControlDis =(int) (x3 - x1) / 3;
            string d = "";
            d = "M " + x2.ToString() + " " + y2.ToString() + " L " + x1.ToString() + " " + y1.ToString() +
                "C" + (x1 + iControlDis).ToString() + " " + y1.ToString() + " " + (x3 - iControlDis).ToString() + " " + y3.ToString() + " " +
                x3.ToString() + " " + y3.ToString() + " L " + x4.ToString() + " " + y4.ToString() + " " +
                 "C" + (x4 - iControlDis).ToString() + " " + y4.ToString() + " " + (x2 + iControlDis).ToString() + " " + y2.ToString() + " " + x2.ToString() + " " + y2.ToString()
                + " z ";
            return d;
        }


        public static List<string> makePathd(List<itemDrawDataFaultItem> listFaultItem, cDataItemConnect item1, cDataItemConnect item2)
        {
            List<string> listPathd = new List<string>();
            if (item1.x1 > item2.x1) swap(ref item1, ref item2);
            foreach (itemDrawDataFaultItem item in listFaultItem)
            {
                listPathd = makePathd(item, item1, item2);
                if (listPathd.Count == 2) return listPathd;
            }
            if(listPathd.Count==0) listPathd.Add(makePathd(item1,item2));
            return listPathd;
        }

        public static List<string> makePathd(itemDrawDataFaultItem  faultItem, cDataItemConnect item1, cDataItemConnect item2)
        {
            List<string> listPathd = new List<string>();
          
            listPathd=faultSectionD(faultItem, item1, item2) ; 
          
            return listPathd;
        }

        public static List<string>  faultSectionD(itemDrawDataFaultItem  faultItem, cDataItemConnect item1, cDataItemConnect item2)
        {  
            //x1 左上 x2 左下  
            // 要注意 item1 和 item2 的位置问题 item.X1 > item2.X2 时  应该交换
            if (item1.x1 > item2.x1) swap(ref item1, ref item2);
            List<string> listPathFaultd = new List<string>();
            double x1 = item1.x1 + item1.width;
            double y1 = item1.y1;
            double x3 = item2.x1;
            double y3 = item2.y1;
            Vector2D intersection1;
            var actual1 = LineSegment.LineSegementsIntersect(
                new Vector2D(x1, y1),
                new Vector2D(x3, y3),
                new Vector2D(faultItem.x1View, faultItem.y1View),
                new Vector2D(faultItem.x2View, faultItem.y2View),
                out intersection1);
            //               MessageBox.Show(intersection1.X + " " + intersection1.Y);
            double x2 = item1.x1 + item1.width;
            double y2 = item1.y1 + item1.height;
            double x4 = item2.x1;
            double y4 = item2.y1 + item2.height;
            Vector2D intersection2;
            var actual2 = LineSegment.LineSegementsIntersect(
                new Vector2D(x2, y2),
                new Vector2D(x4, y4),
                 new Vector2D(faultItem.x1View, faultItem.y1View),
                new Vector2D(faultItem.x2View, faultItem.y2View),
                out intersection2);
            //       MessageBox.Show(intersection2.X + " " + intersection2.Y);
            //存在交点才处理
            if (actual1 == true && actual2 == true)
            {
                //正断层和逆断层的处理方式不同,你断层的处理方法不同，X上推
                double dX = faultItem.displacementView/2;
                // x5 y5  是 (x1,y1) (x3,y3) 交点后推的值
                // x6 y6  是 (x2,y2) (x4,y4) 交点后推的值
                double x5 = intersection1.X - dX;
                double y5 = cCalBase.linear(x5, intersection1.X, intersection2.X, intersection1.Y, intersection2.Y);
                double x6 = intersection2.X - dX;
                double y6 = cCalBase.linear(x6, intersection1.X, intersection2.X, intersection1.Y, intersection2.Y);
          //      string d1 = "M " + x1.ToString() + " " + y1.ToString() + " L " + x2.ToString() + " " + y2.ToString() + " L " +
          //x6.ToString() + " " + y6.ToString() + " L " + x5.ToString() + " " + y5.ToString() + " z ";

                string d1=makePathd(x1, y1, x2, y2, x5, y5, x6, y6);
                listPathFaultd.Add(d1);

                double x7 = intersection1.X + dX;
                double y7 = cCalBase.linear(x7, intersection1.X, intersection2.X, intersection1.Y, intersection2.Y);
                double x8 = intersection2.X + dX;
                double y8 = cCalBase.linear(x8, intersection1.X, intersection2.X, intersection1.Y, intersection2.Y);
         //       string d2 = "M " + x3.ToString() + " " + y3.ToString() + " L " + x4.ToString() + " " + y4.ToString() + " L " +
         //intersection2.X.ToString() + " " + intersection2.Y.ToString() + " L " + intersection1.X.ToString() + " " + intersection1.Y.ToString() + " z ";
                string d2 = makePathd( x7, y7, x8, y8,x3, y3, x4, y4);
                listPathFaultd.Add(d2);
            }
            return listPathFaultd;
        
        }

        public static void swap(ref cDataItemConnect ob1, ref cDataItemConnect ob2)
        {
            cDataItemConnect t;
            t = ob1;
            ob1 = ob2;
            ob2 = t;
        } 
    }
}



