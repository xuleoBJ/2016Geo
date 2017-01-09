using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace DOGPlatform
{
    class cPublicPanel
    {
        public static void setPanel(Panel panel)
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
                panel.Dock = System.Windows.Forms.DockStyle.None;

                panel.Width = iPanelWidth;
                panel.Height = iPanelHeight;
                panel.Location = new Point(0, 0);

                panel.Invalidate();
                panel.Focus();
            }

        }

        public static void addGrid(Panel panel, PaintEventArgs e)
        {
            Graphics dc = e.Graphics;
            Font font = new Font("黑体", 8);
            Brush blueBrush = Brushes.Blue;
            Pen pen = new Pen(Color.LightBlue, 0.5F);
            for (int i = 1; i * 500 * cProjectData.dfMapScale < panel.Width; i++)
            {
                int iXCurrentView = Convert.ToInt32(i * 500 * cProjectData.dfMapScale);
                Point point1 = new Point(iXCurrentView, 0);
                Point point2 = new Point(iXCurrentView, panel.Height);
                dc.DrawLine(pen, point1, point2);
                dc.DrawString((cProjectData.dfMapXrealRefer + i * 500).ToString(), font, blueBrush, iXCurrentView, 0);
            }

            for (int i = 1; i * 500 * cProjectData.dfMapScale < panel.Height; i++)
            {
                int iYCurrentView = Convert.ToInt32(i * 500 * cProjectData.dfMapScale);
                Point point3 = new Point(0, iYCurrentView);
                Point point4 = new Point(panel.Width, iYCurrentView);
                dc.DrawLine(pen, point3, point4);
                dc.DrawString((cProjectData.dfMapYrealRefer - i * 500).ToString(), font, blueBrush, 0, iYCurrentView);
            }
        }

        public static void addWellPosion(PaintEventArgs e)
        {
            if (cProjectData.ltProjectWell.Count > 0)
            {
                Graphics dc = e.Graphics;
                dc.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                Font font = new Font("黑体", 8);
                foreach (ItemWell itemWell in cProjectData.ltProjectWell)
                {
                    Pen wellPen = new Pen(Color.Black, 2);
                    if (itemWell.iWellType == 3) wellPen = new Pen(Color.Red, 2);
                    else if (itemWell.iWellType == 5) wellPen = new Pen(Color.Green, 2);
                    else if (itemWell.iWellType == 15) wellPen = new Pen(Color.Blue, 2);

                    Pen blackPen = new Pen(Color.Black, 1);
                    List<ItemDicWellPath> currentWellPath = itemWell.WellPathList;
                    Point headView = cCordinationTransform.transRealPointF2ViewPoint(
                     currentWellPath[0].dbX, currentWellPath[0].dbY, cProjectData.dfMapXrealRefer, cProjectData.dfMapYrealRefer, cProjectData.dfMapScale);
                    dc.DrawEllipse(wellPen, headView.X - 3, headView.Y - 3, 6, 6);

                    int iCount = currentWellPath.Count;
                    if (iCount > 2)
                    {
                        List<Point> points = new List<Point>();
                        for (int k = 0; k < iCount; k++)
                        {
                            Point tailView = cCordinationTransform.transRealPointF2ViewPoint(
                            currentWellPath[k].dbX, currentWellPath[k].dbY, cProjectData.dfMapXrealRefer, cProjectData.dfMapYrealRefer, cProjectData.dfMapScale);
                            points.Add(tailView);

                        }
                        dc.DrawLines(blackPen, points.ToArray());
                    }
                    Brush blackBrush = Brushes.Black;
                    dc.DrawString(itemWell.sJH, font, blackBrush,
                                   headView.X + 3, headView.Y + 3);
                }

            }
          //  base.OnPaint(e);
        }

        void addPolygon(PaintEventArgs e, List<Point> listPoint)
        {
            Graphics dc = e.Graphics;
            Pen BlackPen = new Pen(Color.Blue, 1);
            dc.DrawPolygon(BlackPen, listPoint.ToArray());

           // base.OnPaint(e);
        }

        void addCircle(PaintEventArgs e, Point pR, int r)
        {
            Graphics dc = e.Graphics;

            Pen RedPen = new Pen(Color.Red, 1);
            dc.DrawEllipse(RedPen, pR.X, pR.Y, r, r);
          //  base.OnPaint(e);
        }
        void addLine(PaintEventArgs e, Point p1, Point p2)
        {
            Graphics dc = e.Graphics;
            Pen BlackPen = new Pen(Color.Blue, 1);

            dc.DrawLine(BlackPen, p1, p2);

            Pen RedPen = new Pen(Color.Red, 1);
            int r = 4;
            dc.DrawEllipse(RedPen, p1.X - r / 2, p1.Y - r / 2, r, r);
            dc.DrawEllipse(RedPen, p2.X - r / 2, p2.Y - r / 2, r, r);
         //   base.OnPaint(e);
        }

        public static void addVoronoi(PaintEventArgs e, string sXCM)
        {
            Graphics dc = e.Graphics;

            List<itemWellLayerVoi> listVoi = cIOVoronoi.read2Struct();
            int iIndex = 2;
            foreach (itemWellLayerVoi well in listVoi.FindAll(p => p.sXCM == sXCM))
            {
                if(iIndex<240) iIndex = iIndex + 10;
                Pen blackPen = new Pen(Color.Black, 1);
                SolidBrush redBrush = new SolidBrush(Color.FromArgb(iIndex, Color.Red));
                List<PointF> listViewVer = new List<PointF>();
                foreach (PointD _pf in well.ltdpVertex)
                {
                    PointF _currentVer = cCordinationTransform.transRealPointF2ViewPoint(
                     _pf.X, _pf.Y, cProjectData.dfMapXrealRefer, cProjectData.dfMapYrealRefer, cProjectData.dfMapScale);
                    listViewVer.Add(_currentVer);
                }
               dc.DrawPolygon(blackPen, listViewVer.ToArray());
               dc.FillPolygon(redBrush, listViewVer.ToArray());
            }

        }

        public static void addVoronoi(PaintEventArgs e, List<ItemWellLayerValue> ltItem,Color clr)
        {
            if (ltItem.Count > 0)
            {
                Graphics dc = e.Graphics;

                List<itemWellLayerVoi> listVoi = cIOVoronoi.read2Struct();
                float fMax = ltItem.Select(p => p.fValue).Max();
                foreach (itemWellLayerVoi well in listVoi.FindAll(p => p.sXCM == ltItem[0].sXCM))
                {
                    int iOpacity = 0;
                    if (fMax > 0) iOpacity = Convert.ToInt16(255 * ltItem.Find(p => p.sJH == well.sJH).fValue / fMax);
                    Pen blackPen = new Pen(Color.Black, 1);
                    if(iOpacity<0) iOpacity = 0;
                    SolidBrush redBrush = new SolidBrush(Color.FromArgb(iOpacity, clr));
                    List<PointF> listViewVer = new List<PointF>();
                    foreach (PointD _pf in well.ltdpVertex)
                    {
                        PointF _currentVer = cCordinationTransform.transRealPointF2ViewPoint(
                         _pf.X, _pf.Y, cProjectData.dfMapXrealRefer, cProjectData.dfMapYrealRefer, cProjectData.dfMapScale);
                        listViewVer.Add(_currentVer);
                    }
                    dc.DrawPolygon(blackPen, listViewVer.ToArray());
                    dc.FillPolygon(redBrush, listViewVer.ToArray());
                } //end foreach

            }//end if 
        }

        public static void addVoronoi(PaintEventArgs e, List<ItemWellLayerValue> ltItem, float fMin,float fMax,Color clr)
        {
            if (ltItem.Count > 0)
            {
                Graphics dc = e.Graphics;

                List<itemWellLayerVoi> listVoi = cIOVoronoi.read2Struct();
                foreach (itemWellLayerVoi well in listVoi.FindAll(p => p.sXCM == ltItem[0].sXCM))
                {
                    int iOpacity = 0;
                    float fCurrentValue = ltItem.Find(p => p.sJH == well.sJH).fValue;
                    if (fCurrentValue >= fMax) iOpacity = 255;
                    else if(fCurrentValue<=fMin) iOpacity=0;
                    else iOpacity = Convert.ToInt16(255 * (fCurrentValue - fMin) / (fMax - fMin));
                    Pen blackPen = new Pen(Color.Black, 1);
                    if (iOpacity < 0) iOpacity = 0;
                    SolidBrush redBrush = new SolidBrush(Color.FromArgb(iOpacity, clr));
                    List<PointF> listViewVer = new List<PointF>();
                    foreach (PointD _pf in well.ltdpVertex)
                    {
                        PointF _currentVer = cCordinationTransform.transRealPointF2ViewPoint(
                         _pf.X, _pf.Y, cProjectData.dfMapXrealRefer, cProjectData.dfMapYrealRefer, cProjectData.dfMapScale);
                        listViewVer.Add(_currentVer);
                    }
                    if (listViewVer.Count > 0)
                    {
                        dc.DrawPolygon(blackPen, listViewVer.ToArray());
                        dc.FillPolygon(redBrush, listViewVer.ToArray());
                    }
                } //end foreach
            }//end if 
        }

    }
}
