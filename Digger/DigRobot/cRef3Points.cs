using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Collections;
using System.IO;
namespace DigRobot
{
    public class cRef3Points
    {
        //定义 用户配置XML文件的路径
        

        //定义 ArrayList存储系统坐标设置
        public static List<PointF> ListRef3ScreenPosition = new List<PointF>();
        public static List<PointF> ListRef3RealPosition = new List<PointF>();

      

        //定义两个临时变量供传值用
        public static PointF tempPointScreen = new PointF();
        public static PointF tempPointReal = new PointF();

        //定义用户及屏幕坐标点
        public static PointF fCordiateSystemScreenP1 = new PointF(-1, -1);
        public static PointF fCordiateSystemScreenP2 = new PointF(-1, -1);
        public static PointF fCordiateSystemScreenP3 = new PointF(-1, -1);
        public static PointF fCordiateSystemUserP1 = new PointF(-1, -1);
        public static PointF fCordiateSystemUserP2 = new PointF(-1, -1);
        public static PointF fCordiateSystemUserP3 = new PointF(-1, -1);


        //转换系数
        public static double fCordA1 = -9999.0;
        public static double fCordB1 = -9999.0;
        public static double fCordC1 = -9999.0;
        public static double fCordA2 = -9999.0;
        public static double fCordB2 = -9999.0;
        public static double fCordC2 = -9999.0;
    }
}
