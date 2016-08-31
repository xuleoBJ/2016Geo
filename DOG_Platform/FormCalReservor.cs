using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
namespace DOGPlatform
{
  
    public partial class FormCalReservor : Form
    {
        Voronoi voroObject;
        struct itemReservePar
        {
            public string sXCM;
            public float destiny;
            public float fBo;
        }
        class itemWellLayerReserve
        {
            public string sJH;
            public string sXCM;
            public double dbX;
            public double dbY;
            public float fYXHD;
            public float fKXD;
            public float fBHD;
            public float destinyOil;
            public double dbArea;
            public float fBo;
            public double dbReserver;
            public double dbCLFD;//储量丰度
            public List<PointD> ltPD_Vertex_Voronoi;
        }
        List<itemReservePar> layerReservaParCal = new List<itemReservePar>();
        
        public FormCalReservor()
        {
            InitializeComponent();
            setPanel();
            voroObject = new Voronoi(0.1);
        }

         
        void setPanel()
        {
            if (cProjectData.ltStrProjectJH.Count > 0)
            {
                int iSacleUnit = 500; //定义网格单位
                if (cProjectData.dfMapScale == 0) cProjectData.dfMapScale = 0.1;
                cProjectData.dfMapXrealRefer = Math.Floor(cProjectData.ltProjectWell.Min(p => p.dbX) / iSacleUnit - 1) * iSacleUnit;
                cProjectData.dfMapYrealRefer = (Math.Ceiling(cProjectData.ltProjectWell.Max(p => p.dbY) / iSacleUnit) + 1) * iSacleUnit;

                double xMaxDistance = cProjectData.ltProjectWell.Max(p => p.dbX) - cProjectData.ltProjectWell.Min(p => p.dbX);
                double yMaxDistance = cProjectData.ltProjectWell.Max(p => p.dbY) - cProjectData.ltProjectWell.Min(p => p.dbY);

                int iPanelWidth = Convert.ToInt32((int)(xMaxDistance / iSacleUnit + 3) * iSacleUnit * cProjectData.dfMapScale);//显示好看pannel比最大大3个网格
                int iPanelHeight = Convert.ToInt32((int)(yMaxDistance / iSacleUnit + 3) * iSacleUnit * cProjectData.dfMapScale);//显示好看pannel比最大大3个网格
                panelResCal.Dock = System.Windows.Forms.DockStyle.None;

                panelResCal.Width = iPanelWidth;
                panelResCal.Height = iPanelHeight;
                panelResCal.Location = new Point(0, 0);
                 
                this.panelResCal.Invalidate();
                this.panelResCal.Focus();
            }

        }
        void spreadPoints(PaintEventArgs e)
        {
            Graphics dc = e.Graphics;

            List<PointF> sites = new List<PointF>();

            foreach (ItemWell well in cProjectData.ltProjectWell)
            {
                PointF headView = cCordinationTransform.transRealPointF2ViewPoint(
                    well.dbX, well.dbY, cProjectData.dfMapXrealRefer, cProjectData.dfMapYrealRefer, cProjectData.dfMapScale);
               // sites.Add(headView);
                sites.Add(new PointF(Convert.ToSingle(well.dbX), Convert.ToSingle(well.dbY)));
                Pen wellPen = new Pen(Color.Black, 2);
                if (well.iWellType == 3) wellPen = new Pen(Color.Red, 2);
                else if (well.iWellType == 5) wellPen = new Pen(Color.Green, 2);
                else if (well.iWellType == 15) wellPen = new Pen(Color.Blue, 2);

                Pen blackPen = new Pen(Color.Black, 1);
                dc.DrawEllipse(wellPen, headView.X-1.5f, headView.Y-1.5f, 3, 3);
                Brush blackBrush = Brushes.Black;
                Font font = new Font("黑体", 8);
                dc.DrawString(well.sJH, font, blackBrush,
                               headView.X + 3, headView.Y + 3);
            }
            int iExtentDis = 200;

            double[] xVal = new double[sites.Count];
            double[] yVal = new double[sites.Count];
            for (int i = 0; i < sites.Count; i++)
            {
                xVal[i] = sites[i].X;
                yVal[i] = sites[i].Y;
            }
            double minX = cProjectData.ltProjectWell.Min(p => p.dbX) - iExtentDis;
            double maxX = cProjectData.ltProjectWell.Max(p => p.dbX) + iExtentDis;
            double minY = cProjectData.ltProjectWell.Min(p => p.dbY) - iExtentDis;
            double maxY = cProjectData.ltProjectWell.Max(p => p.dbY) + iExtentDis;
            List<GraphEdge> list_ge = voroObject.generateVoronoi(xVal, yVal, minX, maxX, minY, maxY);

            //定义一个数据结构 就是返回 顶点序列，边的顺或者逆时针方向的结构列表
            //注意 这里安装sites的个数找 但是 ge里egde存的是
            List<List<PointD>> list_ClockPoints = new List<List<PointD>>();
            for (int i = 0; i < sites.Count; i++)
            {
                List<PointD> points = new List<PointD>();
                List<GraphEdge> ListEdgeCur = new List<GraphEdge>();
                foreach (GraphEdge ge in list_ge)
                {
                    if (ge.site2 == i || ge.site1 == i) ListEdgeCur.Add(ge);//收集环绕顶点的所有边
                }

                foreach (GraphEdge ge in ListEdgeCur)
                {
                    PointF p1 = cCordinationTransform.transRealPointF2ViewPoint(
                   ge.x1, ge.y1, cProjectData.dfMapXrealRefer, cProjectData.dfMapYrealRefer, cProjectData.dfMapScale);
                    PointF p2 = cCordinationTransform.transRealPointF2ViewPoint(
                  ge.x2, ge.y2, cProjectData.dfMapXrealRefer, cProjectData.dfMapYrealRefer, cProjectData.dfMapScale);
                    dc.DrawLine(Pens.Black, p1.X, p1.Y, p2.X, p2.Y);
                    //points.Add(new PointF(Convert.ToSingle(ge.x2), Convert.ToSingle(ge.y2)));
                    //points.Add(new PointF(Convert.ToSingle(ge.x1), Convert.ToSingle(ge.y1))); //获得顶点
                }
                //按序号找到所有的顶点，按顺时针或者逆时针排序后输出
                //list_ClockPoints.Add(cSortPoints.sortPoints(points.Distinct().OrderBy(p => p.Y).ToList(), sites[i]));
            }

            //List<GraphEdge> ge;
            //ge = MakeVoronoiGraph(sites, panelResCal.Width , panelResCal.Height);
            //StreamWriter swNew = new StreamWriter(cProjectManager.filePathRunInfor, true, Encoding.UTF8);
            //// رسم أضلاع فورونوي
            //for (int i = 0; i < ge.Count; i++)
            //{
                
            //        Point p1 = new Point((int)ge[i].x1, (int)ge[i].y1);
            //        Point p2 = new Point((int)ge[i].x2, (int)ge[i].y2);
            //        dc.DrawLine(Pens.Black, p1.X, p1.Y, p2.X, p2.Y);

            //        string sLine = "P" + i + " size1: " + ge[i].site1 + " " + ge[i].x1.ToString("0.0") + " " + ge[i].y1.ToString("0.0") + " size2: " + ge[i].site2 + "  " + ge[i].x2.ToString("0.0") + " " + ge[i].y2.ToString("0.0");
   
            //       swNew.WriteLine(sLine);      
            //}
            //swNew.Close();
            base.OnPaint(e);
        }

        List<GraphEdge> MakeVoronoiGraph(List<PointF> sites, int width, int height)
        {
            double[] xVal = new double[sites.Count];
            double[] yVal = new double[sites.Count];
            for (int i = 0; i < sites.Count; i++)
            {
                xVal[i] = sites[i].X;
                yVal[i] = sites[i].Y;
            }
            return voroObject.generateVoronoi(xVal, yVal, 0, width, 0, height);
        }

       

        private void panelResCal_Paint(object sender, PaintEventArgs e)
        {
            addGrid(e);
            spreadPoints(e);
        }
        void addGrid(PaintEventArgs e)
        {
            Graphics dc = e.Graphics;
            Font font = new Font("黑体", 8);
            Brush blueBrush = Brushes.Blue;
            Pen pen = new Pen(Color.LightBlue, 0.5F);
            for (int i = 1; i * 500 * cProjectData.dfMapScale < this.panelResCal.Width; i++)
            {
                int iXCurrentView = Convert.ToInt32(i * 500 * cProjectData.dfMapScale);
                Point point1 = new Point(iXCurrentView, 0);
                Point point2 = new Point(iXCurrentView, this.panelResCal.Height);
                dc.DrawLine(pen, point1, point2);
                dc.DrawString((cProjectData.dfMapXrealRefer + i * 500).ToString(), font, blueBrush, iXCurrentView, 0);
            }

            for (int i = 1; i * 500 * cProjectData.dfMapScale < this.panelResCal.Height; i++)
            {
                int iYCurrentView = Convert.ToInt32(i * 500 * cProjectData.dfMapScale);
                Point point3 = new Point(0, iYCurrentView);
                Point point4 = new Point(this.panelResCal.Width, iYCurrentView);
                dc.DrawLine(pen, point3, point4);
                dc.DrawString((cProjectData.dfMapYrealRefer - i * 500).ToString(), font, blueBrush, 0, iYCurrentView);
            }

            base.OnPaint(e);
        }


        private void panelResCal_Click(object sender, EventArgs e)
        {
            setPanel();
        }


        private void panelResCal_MouseMove(object sender, MouseEventArgs e)
        {
            this.tssLblInfor.Text = e.X + " " + e.Y;
        }

        List<itemWellLayerReserve> calReserve()
        {
            List<itemWellLayerReserve> listLayerWellReserves = new List<itemWellLayerReserve>();
         // 读入小层数据字典
            List<ItemDicLayerDataStatic> listData = cIODicLayerDataStatic.readDicLayerData2struct();
            List<itemWellLayerVoi> listVoi = cIOVoronoi.read2Struct();
       //   按小层顺序筛选，并计算voronoi，通过voronic 求取每个井层的面积
            foreach (string xcm in cProjectData.ltStrProjectXCM) 
            {
                List<ItemDicLayerDataStatic> listCurrentLayerData = listData.FindAll(p => p.sXCM == xcm);
                List<itemWellLayerVoi> listCurrenrLayerVoi = listVoi.FindAll(p => p.sXCM == xcm);
                itemReservePar currentCalResrvePar = layerReservaParCal.First(p => p.sXCM == xcm);
                  //如果没填得检查一遍
                //内部会排序并有对应的ID
                //尽量让排序后的sizes和Voronoi内部的size是同一个顺序，这块需要校验=Y的情况
                //如果都是相等的，可以从0开始找
    
                //有了 listCurrentLayerData和读取ListVoi 对应的计算参数，加上对应的密度，体积系数就能按容积法求出面积，然后输出了
                for (int i=0; i < listCurrentLayerData.Count; i++) 
                {
                    itemWellLayerReserve currentWellReserver = new itemWellLayerReserve();
                    currentWellReserver.sJH = listCurrentLayerData[i].sJH;
                    currentWellReserver.sXCM = listCurrentLayerData[i].sXCM;
                    currentWellReserver.dbX = listCurrentLayerData[i].dbX;
                    currentWellReserver.dbY = listCurrentLayerData[i].dbY;
                    currentWellReserver.fYXHD = listCurrentLayerData[i].fYXHD;
                    currentWellReserver.fKXD = listCurrentLayerData[i].fKXD;
                    currentWellReserver.fBHD = listCurrentLayerData[i].fBHD;
                    currentWellReserver.destinyOil = currentCalResrvePar.destiny;
                    currentWellReserver.fBo = currentCalResrvePar.fBo;
                    currentWellReserver.ltPD_Vertex_Voronoi = listCurrenrLayerVoi.Find(p=>p.sJH== listCurrentLayerData[i].sJH).ltdpVertex;
                    //N=100×Ao×h×ф×Soi×ρo/fBoi 
                    currentWellReserver.dbArea = cCalBase.calArea(currentWellReserver.ltPD_Vertex_Voronoi) / 1000000;
                    //面积计算还原坐标结构，存的是view坐标，需要还原成原坐标系坐标,注意面积单位问题
                    currentWellReserver.dbReserver = 0.01 * currentWellReserver.dbArea* currentWellReserver.fYXHD  * currentWellReserver.fBHD
                        * currentWellReserver.destinyOil / currentWellReserver.fBo;
                    listLayerWellReserves.Add(currentWellReserver);
                    currentWellReserver.dbCLFD = 0.0;
                    if (currentWellReserver.dbArea > 0) currentWellReserver.dbCLFD = currentWellReserver.dbReserver / currentWellReserver.dbArea;
                }

            }//end of layerXCM foreach
            return listLayerWellReserves;
        }//end of calRes

         void write2File(List<itemWellLayerReserve> listLayerWellReserves)
        {

            StreamWriter sw = new StreamWriter(cProjectManager.filePathReserver, false, Encoding.UTF8);
            List<string> ltStrHeadColoum = new List<string>();  
            ltStrHeadColoum.Add("井号");
            ltStrHeadColoum.Add("小层名");
            ltStrHeadColoum.Add("X");
            ltStrHeadColoum.Add("Y");
            ltStrHeadColoum.Add("有效厚度(m)");
            ltStrHeadColoum.Add("孔隙度(%)");
            ltStrHeadColoum.Add("饱和度(%)");
            ltStrHeadColoum.Add("含油面积(km2)");
            ltStrHeadColoum.Add("密度(t/m3)");
            ltStrHeadColoum.Add("体积系数");
            ltStrHeadColoum.Add("储量(万吨)"); 
            ltStrHeadColoum.Add("储量丰度（万吨/平方公里）");
            sw.WriteLine(string.Join("\t", ltStrHeadColoum.ToArray()));
            foreach (itemWellLayerReserve item in listLayerWellReserves)
            {
                List<string> ltStrWrited = new List<string>();
                ltStrWrited.Add(item.sJH);
                ltStrWrited.Add(item.sXCM);
                ltStrWrited.Add(item.dbX.ToString("0.0"));
                ltStrWrited.Add(item.dbY.ToString("0.0"));
                ltStrWrited.Add(item.fYXHD.ToString("0.0")); //顶深海拔
                ltStrWrited.Add(item.fKXD.ToString("0.0"));
                ltStrWrited.Add(item.fBHD.ToString("0.0"));
                ltStrWrited.Add(item.dbArea.ToString("0.000"));
                ltStrWrited.Add(item.destinyOil.ToString("0.0"));
                ltStrWrited.Add(item.fBo.ToString("0.00"));

                ltStrWrited.Add(item.dbReserver.ToString("0.000")); //底深MD
                ltStrWrited.Add(item.dbCLFD.ToString("0.0")); //底深MD
                sw.WriteLine(string.Join("\t", ltStrWrited.ToArray()));

             
            }
            sw.Close();
        }
        void inialCalPar()
        {
         for(int i=0;i<this.dgvCalpar.RowCount-1;i++)
         {
             itemReservePar cureentLayerPar=new itemReservePar();
             cureentLayerPar.sXCM = dgvCalpar.Rows[i].Cells[0].Value.ToString();
             float des = 0.8f;
             float.TryParse(dgvCalpar.Rows[i].Cells[1].Value.ToString(), out des);
             cureentLayerPar.destiny = des;
             float fBo = 1.1f;
             float.TryParse(dgvCalpar.Rows[i].Cells[1].Value.ToString(), out fBo);
             cureentLayerPar.fBo = fBo;
             layerReservaParCal.Add(cureentLayerPar);
             
         }
         foreach (string sxcm in cProjectData.ltStrProjectXCM)
         {
             //如果没有对应的计算参数给个默认值
             if (layerReservaParCal.Count==0||layerReservaParCal.Select(p=>p.sXCM).ToList().IndexOf(sxcm)<0)
             {
                 itemReservePar currentCalResrvePar = new itemReservePar();
                 currentCalResrvePar.sXCM = sxcm;
                 currentCalResrvePar.destiny = 0.8f;
                 currentCalResrvePar.fBo = 1.1f;
                 layerReservaParCal.Add(currentCalResrvePar);
             }
         }
        }
        private void btnCalRes_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            inialCalPar();
            write2File(calReserve());
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
               ts.Hours, ts.Minutes, ts.Seconds,
               ts.Milliseconds / 10);
            MessageBox.Show("计算完成。消耗时间：" + elapsedTime);
            Cursor.Current = Cursors.Default;
            this.Close();
        }

        private void btnCopyFromExcelPayPropery_Click(object sender, EventArgs e)
        {
            cPublicMethodForm.DataGridViewCellPaste(this.dgvCalpar);
        }

     
    }
}
