using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Drawing;

namespace DOGPlatform
{
    class cDogTrackEvationRuler : cDogTrack
    {
        int _iMainScale = 20;
        [Description("主刻度")]
        [Category("设置")]
        [DisplayName("主刻度")]
        public int iMainScale
        {
            get { return _iMainScale; }
            set { _iMainScale = value; }
        }

        int _iMinScale = 5;
        [Description("次刻度")]
        [Category("设置")]
        [DisplayName("次刻度")]
        public int iMinScale
        {
            get { return _iMinScale; }
            set { _iMinScale = value;  }
        }

        Color _tickColor = Color.Black;
        [Description("刻度颜色")]
        [Category("设置")]
        [DisplayName("刻度颜色")]
        public Color TickColor
        {
            get { return _tickColor; }
            set { _tickColor = value; }
        }
    }
}
