using System;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;

namespace DOGPlatform
{
    class TrackDepthRuler : Track
    {
        int _iMainScale = 20;
        [Description("主刻度")]
        [Category("设置")]
        [DisplayName("主刻度")]
        public int iMainScale
        {
            get { return _iMainScale; }
            set { _iMainScale = value; Invalidate(); }
        }

        int _iMinScale = 5;
        [Description("次刻度")]
        [Category("设置")]
        [DisplayName("次刻度")]
        public int iMinScale
        {
            get { return _iMinScale; }
            set { _iMinScale = value; Invalidate(); }
        }

        Color _tickColor = Color.Black;
        [Description("刻度颜色")]
        [Category("设置")]
        [DisplayName("刻度颜色")]
        public Color TickColor
        {
            get { return _tickColor; }
            set { _tickColor = value; Invalidate(); }
        }

        void addTick(PaintEventArgs e)
        {
            Graphics dc = e.Graphics;
     //       dc.PageUnit = GraphicsUnit.Millimeter;
            Pen penTick = new Pen(_tickColor, 0.5F);

            Pen pen = new Pen(_tickColor, 1);
            dc.DrawLine(pen, new Point(2, 0), new Point(2, this.Height));
       

            for (int i = 0; i < this.Height; i=i+_iMainScale)
            {
                dc.DrawLine(penTick, new Point(2, i), new Point(this.Width/4, i));
                String drawString =i.ToString();
                Font drawFont = new Font("Arial", 8);
                SolidBrush drawBrush = new SolidBrush(Color.Black);

                // Create point for upper-left corner of drawing.
                PointF drawPoint = new PointF(this.Width / 3, i);

                // Draw string to screen.
                dc.DrawString(drawString, drawFont, drawBrush, drawPoint);
            }
            for (int i = 0; i < this.Height; i = i + _iMinScale )
            {
                dc.DrawLine(penTick, new Point(2, i), new Point(this.Width /8, i));
            }

            pen.Dispose();
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            addTick(pe);
            base.OnPaint(pe);
        }
    }
}
