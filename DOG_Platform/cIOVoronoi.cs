using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;

namespace DOGPlatform
{
    class cIOVoronoi
    {
        public static List<itemWellLayerVoi> read2Struct()
        {
            List<itemWellLayerVoi> listReturn = new List<itemWellLayerVoi>();
            if (File.Exists(cProjectManager.filePathVoi))
            {
                using (StreamReader sr = new StreamReader(cProjectManager.filePathVoi, System.Text.Encoding.UTF8))
                {
                    String line;
                    int indexLine = 0;

                    while ((line = sr.ReadLine()) != null) //delete the line whose legth is 0
                    {
                        indexLine++;
                        itemWellLayerVoi item = new itemWellLayerVoi();
                       
                        string[] split = line.Trim().Split();

                        item.sJH = split[0];
                        item.sXCM = split[1];
                        item.dbX = 0.0;
                        item.dbY = 0.0;
                        double.TryParse(split[2], out  item.dbX);
                        double.TryParse(split[3], out item.dbY);
                        int iCount = 4;
                        while (split.Length > iCount)
                        {
                            PointD pf = new PointD();
                            pf.X =double .Parse(split[iCount]);
                            pf.Y = double.Parse(split[iCount + 1]);
                            item.ltdpVertex.Add(pf);
                            iCount = iCount + 2;
                        }
                        listReturn.Add(item);
                    }
                }
            }
            return listReturn;
        }

        public static void calVoiAndwrite2File()
        {
            write2File(calVoi());
        }

        public static List<GraphEdge> readLayerGE(string sXCM)
        {
            List<GraphEdge> listGE = new List<GraphEdge>();
            string filePath = Path.Combine(cProjectManager.dirPathLayerDir, sXCM, cProjectManager.fileNameGE);
            if (File.Exists(filePath))
            {
                using (StreamReader sr = new StreamReader(filePath, System.Text.Encoding.UTF8))
                {
                    String line;
                    int indexLine = 0;

                    while ((line = sr.ReadLine()) != null) //delete the line whose legth is 0
                    {
                        indexLine++;
                        GraphEdge item = new GraphEdge();

                        string[] split = line.Trim().Split();
                        if (split.Length == 8)
                        {
                            item.site1 =int.Parse(split[1]);
                            item.x1 = float.Parse(split[2]);
                            item.y1 = float.Parse(split[3]);
                            item.site2 =int.Parse(split[5]);
                            item.x2 = float.Parse(split[6]);
                            item.y2 = float.Parse(split[7]);
                        }
                        listGE.Add(item); 
                    }
                }
            }
            return listGE;
        }

        public static List<itemWellLayerVoi> calVoi()
        {
            Voronoi voroObject = new Voronoi(0.1);
            int iExtentDis = 200; //外边距
            List<itemWellLayerVoi> listLayerVoronoi = new List<itemWellLayerVoi>();
            // 读入小层数据字典
            List<ItemDicLayerDataStatic> listData = cIODicLayerDataStatic.readDicLayerData2struct();
            //   按小层顺序筛选，并计算voronoi，通过voronic 求取每个井层的面积
          
            foreach (string xcm in cProjectData.ltStrProjectXCM)
            {
                //写到每个小层文件夹内
                string filePath = Path.Combine(cProjectManager.dirPathLayerDir, xcm, cProjectManager.fileNameGE);
                StreamWriter swGe = new StreamWriter(filePath, false, Encoding.UTF8);
                List<ItemDicLayerDataStatic> listCurrentLayerData = listData.FindAll(p => p.sXCM == xcm);

                //如果没填得检查一遍
                //内部会排序并有对应的ID
                //尽量让排序后的sizes和Voronoi内部的size是同一个顺序，这块需要校验=Y的情况

                List<PointD> sites = new List<PointD>();
              
                foreach (ItemDicLayerDataStatic well in listCurrentLayerData)
                    sites.Add(new PointD(well.dbX, well.dbY));

                double[] xVal = new double[sites.Count];
                double[] yVal = new double[sites.Count];
                for (int i = 0; i < sites.Count; i++)
                {
                    xVal[i] = sites[i].X;
                    yVal[i] = sites[i].Y;
                    string sLine =i+" " + xVal[i] + " " + yVal[i]; 
                    swGe.WriteLine(sLine);
                }
                double minX = cProjectData.ltProjectWell.Min(p => p.dbX) - iExtentDis;
                double maxX = cProjectData.ltProjectWell.Max(p => p.dbX) + iExtentDis;
                double minY = cProjectData.ltProjectWell.Min(p => p.dbY) - iExtentDis;
                double maxY = cProjectData.ltProjectWell.Max(p => p.dbY) + iExtentDis;
                List<GraphEdge> list_ge = voroObject.generateVoronoi(xVal, yVal, minX, maxX, minY, maxY);
               
                for (int i = 0; i < list_ge.Count; i++)
                {
                        Point p1 = new Point((int)list_ge[i].x1, (int)list_ge[i].y1);
                        Point p2 = new Point((int)list_ge[i].x2, (int)list_ge[i].y2);
                        string sLine = " size1: " + list_ge[i].site1 + " " + list_ge[i].x1.ToString("0.0") + " " + list_ge[i].y1.ToString("0.0") + " size2: " + list_ge[i].site2 + " " + list_ge[i].x2.ToString("0.0") + " " + list_ge[i].y2.ToString("0.0");
                        swGe.WriteLine(sLine);
                }
                swGe.Close();
              
                //定义一个数据结构 就是返回 顶点序列，边的顺或者逆时针方向的结构列表
                //注意 这里安装sites的个数找 但是 ge里egde存的是
                List<List<PointD>> list_ClockPoints = new List<List<PointD>>();
                for (int i = 0; i < sites.Count; i++)
                {
                    List<PointD> points = new List<PointD>();
                    List<GraphEdge> ListEdgeCur = new List<GraphEdge>();
                    foreach (GraphEdge ge in list_ge)
                    {
                        if ((ge.site2 == i || ge.site1 == i) && (!(ge.x1==ge.x2&&ge.y1==ge.y2))) ListEdgeCur.Add(ge);//收集环绕顶点的所有边
                    }
                    foreach (GraphEdge ge in ListEdgeCur) 
                    {
                        PointD p1 = new PointD(ge.x1,ge.y1);
                        PointD p2=new PointD(ge.x2, ge.y2);

                        if (points.FindIndex(p=>p.X==p1.X&&p.Y==p1.Y) < 0) points.Add(p1);
                        if (points.FindIndex(p=>p.X==p2.X&&p.Y==p2.Y)<0)points.Add(p2);//获得顶点
                    }
                    List<PointD> PointDistinct=points.Distinct().ToList();
                    //按序号找到所有的顶点，按顺时针或者逆时针排序后输出
                    list_ClockPoints.Add(cSortPoints.sortPoints(PointDistinct, sites[i]));
                }

                //有了 listCurrentLayerData和对应的list_ClockPoints，加上对应的密度，体积系数就能按容积法求出面积，然后输出了
                for (int i = 0; i < listCurrentLayerData.Count; i++)
                {
                    itemWellLayerVoi item=new itemWellLayerVoi();
                    item.sJH = listCurrentLayerData[i].sJH;
                    item.sXCM = listCurrentLayerData[i].sXCM;
                    item.dbX = listCurrentLayerData[i].dbX;
                    item.dbY = listCurrentLayerData[i].dbY;
                    item.ltdpVertex= list_ClockPoints[i];//顶点
                    listLayerVoronoi.Add(item);
                }
             
            }//end of layerXCM foreach
           
            return listLayerVoronoi;
        }//end of calRes

        public static void write2File(List<itemWellLayerVoi> listLayerWellVoi)
        {
                   StreamWriter swVoi = new StreamWriter(cProjectManager.filePathVoi, false, Encoding.UTF8);
            List<string> ltStrHeadColoum = new List<string>();  //小层数据表头

            foreach (itemWellLayerVoi item in listLayerWellVoi)
            {
             
                List<string> liStrVoi = new List<string>();
                liStrVoi.Add(item.sJH);
                liStrVoi.Add(item.sXCM);
                liStrVoi.Add(item.dbX.ToString("0.0"));
                liStrVoi.Add(item.dbY.ToString("0.0"));
                foreach (PointD pd in item.ltdpVertex)
                {
                    liStrVoi.Add(pd.X.ToString("0.0"));
                    liStrVoi.Add(pd.Y.ToString("0.0"));
                }
                swVoi.WriteLine(string.Join("\t", liStrVoi.ToArray()));
            }
            swVoi.Close();
        }
    }
}
