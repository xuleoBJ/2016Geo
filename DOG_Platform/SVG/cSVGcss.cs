using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DOGPlatform.SVG
{
    class cSVGcss : cSVGBase
    {
        public cSVGcss( int iDX, int iDY) : base(800,1000,iDX, iDY)
        {
        
        }
  
        public  void add_dragable()
        {
            string sDragable = ".draggable { cursor: move; }";
            svgCss.InnerText += sDragable;
        }
    }
}
