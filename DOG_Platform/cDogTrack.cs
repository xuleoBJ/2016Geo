using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace DOGPlatform
{
    class cDogTrack
    {
        public cDogTrack():this(20)
        {
        }
        public cDogTrack(int _width)
        {
            this.iWidth = _width;
        }
        public cDogTrack(int _iTrackType, int _width)
        {
            this.iTrackType = _iTrackType;
            this.iWidth = _width;
        }
        public cDogTrack( int _iTrackType,int _width, int _height)
            : this(_width,_height,false)
        {

        }
         public cDogTrack(int _width, int _height,bool hasGrid)
        {
            this.iWidth = _width;
            this.iHeigth = _height;
            this.bShowGrid = hasGrid;
        }
        public cDogTrack(int _iTrackType ,int _width, int _height,bool hasGrid)
        {
            this.iTrackType = _iTrackType;
            this.iWidth = _width;
            this.iHeigth = _height;
            this.bShowGrid = hasGrid;
        }

       
        public int iTrackType { get; set; }
        [Description("道宽")]
        [Category("设置")]
        [DisplayName("道宽")]
        public int iWidth { get; set; }
        [Description("道高")]
        [Category("设置")]
        [DisplayName("道高")]
        public int iHeigth { get; set; }
        [Description("网格")]
        [Category("设置")]
        [DisplayName("网格")]
        public bool bShowGrid{ get; set; }
        
    }
}
