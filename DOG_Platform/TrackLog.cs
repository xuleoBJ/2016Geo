using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;

namespace DOGPlatform
{
    class TrackLog:Track
    {
        bool _bHasGrid = false;
        [Browsable(true)]                         // this property should be visible
        //[ReadOnly(true)]                          // but just read only
        [Description("网格,true显示,false不显示")]           
        [Category("设置")]                   
        [DisplayName("是否显示网格")]       
        public bool bHasGrid
        {
            get { return _bHasGrid; }
            set { _bHasGrid = value; Invalidate(); }
        }
        void addGrid(PaintEventArgs e)
        {
            if (_bHasGrid == true)
            {
                Graphics dc = e.Graphics;
                Pen pen = new Pen(Color.LightBlue, 0.5F);
                for (int i = 1; i <= 10; i++)
                {
                    int iXCurrentView = Convert.ToInt32(i * this.Width * 0.1);
                    Point point1 = new Point(iXCurrentView, 0);
                    Point point2 = new Point(iXCurrentView, this.Height);
                    dc.DrawLine(pen, point1, point2);
                }
                for (int i = 10; i <= this.Height; i=i+10)
                {
                    Point point1 = new Point(0, i);
                    Point point2 = new Point(this.Width, i);
                    dc.DrawLine(pen, point1, point2);
                }
            }
        }

        float _fValueRight = 100.0F;
        [Description("曲线右端点值")]
        [Category("设置")]
        [DisplayName("曲线右端点值")]
        public float iValueCurveRight
        {
            get { return _fValueRight; }
            set { _fValueRight = value; Invalidate(); }
        }

        float _fValueLeft = 0.0F;
        [Description("曲线左端点值")]
        [Category("设置")]
        [DisplayName("曲线左端点值")]
        public float iValueCurveLeft
        {
            get { return _fValueLeft; }
            set { _fValueLeft = value; Invalidate(); }
        }

        Color _curveColor = Color.Blue;
        [Description("曲线颜色")]
        [Category("设置")]
        [DisplayName("曲线颜色")]     
        public Color colorLine
        {
            get { return _curveColor; }
            set { _curveColor = value; Invalidate(); }
        }

        float _curveWidth = 1.0F;
        [Description("曲线宽度")]
        [Category("设置")]
        [DisplayName("曲线宽度")]   
        public float fValueCurveRight
        {
            get { return _curveWidth; }
            set { _curveWidth = value; Invalidate(); }
        }

        private List<float> _fListDepth=new List<float>();
        [Browsable(false)]                         // this property should be visible
        public List<float> fListDepth
        {
            get { return _fListDepth; }
            set { _fListDepth = value; }
        }

        private List<float> _fListValue=new List<float>();
        [Browsable(false)]              
        public List<float> fListValue
        {
            get { return _fListValue; }
            set { _fListValue = value; }
        }

        void addCurve(PaintEventArgs e)
        {
            Graphics dc = e.Graphics;
            Pen pen = new Pen(_curveColor, _curveWidth);
 
            List<PointF> listPointF = new List<PointF>();
            for (int i = 0; i <fListDepth.Count; i=i+2)
            {
                float _depth = fListDepth[i];
                float _valueView = fListValue[i];
                if (_valueView >= 10000 || _valueView <= -500)
                {
                    _valueView = 0.0F;
                }
                else
                {
                    _valueView = this.Width * (_valueView - _fValueLeft) / (_fValueRight - _fValueLeft);
                }
                PointF point1 = new PointF(_valueView,_depth);
                listPointF.Add(point1);
            }
            dc.DrawLines(pen, listPointF.ToArray());
            pen.Dispose();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            addGrid(pe);
       //     addCurve(pe);
            base.OnPaint(pe);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // TrackLog
            // 
            this.ResumeLayout(false);
        }

    }
}
