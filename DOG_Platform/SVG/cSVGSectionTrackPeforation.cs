using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace DOGPlatform.SVG
{
    class cSVGSectionTrackPeforation : cSVGSectionTrack
    {
        public cSVGSectionTrackPeforation(int _iTrackWidth)
            : base(_iTrackWidth)
        {

        }
        public cSVGSectionTrackPeforation()
            : base()
        {

        }
       
        public XmlElement gTrackPerforation(string sJH,List<float> fListTop, List<float> fListBottom, float m_KB)
        {
            XmlElement gPeforationTrack = svgDoc.CreateElement("g");
            gPeforationTrack.SetAttribute("id", sJH+"#射孔");
            for (int i = 0; i < fListTop.Count; i++)
            {
                float _top = fListTop[i];
                float _bottom = fListBottom[i];
                double x0 = 0;
                double y0 = -m_KB + _top;
                double height = _bottom - _top;
                gPeforationTrack.AppendChild( gPatternPerforation(x0,  y0,  height));
            }

            return gPeforationTrack;
        }

        XmlElement gPatternPerforation(double x0, double y0, double height)
        {
            XmlElement gPeforationInterval = svgDoc.CreateElement("path");
            string sPath = "m "+(x0+3).ToString()+" " + y0.ToString() + " h8 h -4 v " + height.ToString() + " h4 h-8";
            gPeforationInterval.SetAttribute("d", sPath);
            gPeforationInterval.SetAttribute("stroke-width", "1");
            gPeforationInterval.SetAttribute("stroke", "red");
            gPeforationInterval.SetAttribute("fill", "none");
            return gPeforationInterval;
        }

        public XmlElement gTrackPerforation(string sJH,trackInputPerforationDataList perforationDataList, float m_KB)
        {
            return gTrackPerforation(sJH,perforationDataList.fListDS1, perforationDataList.fListDS2,  m_KB);
        }
        public XmlElement gXieTrack2VerticalPerforation(string sJH, trackInputPerforationDataList perforationDataList, float m_KB)
        {
            List<ItemDicWellPath> listWellPathDS1 = cIOinputWellPath.getWellPathItemListByJHAndMDList(sJH, perforationDataList.fListDS1);
            List<ItemDicWellPath> listWellPathDS2 = cIOinputWellPath.getWellPathItemListByJHAndMDList(sJH, perforationDataList.fListDS2);
            List<float> fListTVD1 = listWellPathDS1.Select(p => p.f_TVD).ToList();
            List<float> fListTVD2 = listWellPathDS2.Select(p => p.f_TVD).ToList();
            return gTrackPerforation(sJH, fListTVD1,fListTVD2, m_KB);
        }

        public XmlElement gPathTrackPerforation(string sJH, trackInputPerforationDataList perforationDataList, float m_KB)
        {
            return gPathTrackPerforation(sJH, perforationDataList.fListDS1, perforationDataList.fListDS2, m_KB);
        }

        public XmlElement gPathTrackPerforation(string sJH, List<float> fListDS1, List<float> fListDS2, float m_KB)
        {
           
            List<ItemDicWellPath> listWellPathTop = cIOinputWellPath.getWellPathItemListByJHAndMDList(sJH, fListDS1);
            List<ItemDicWellPath> listWellPathBase = cIOinputWellPath.getWellPathItemListByJHAndMDList(sJH, fListDS2);

            XmlElement gPeforationTrack = svgDoc.CreateElement("g");
            gPeforationTrack.SetAttribute("id", sJH + "#射孔");
            for (int i = 0; i < fListDS1.Count; i++)
            {
                double x0 = listWellPathTop[0].f_dx;
                double y0 = -m_KB + listWellPathTop[i].f_TVD;
                double height = listWellPathBase[i].f_TVD - listWellPathTop[i].f_TVD;
                gPeforationTrack.AppendChild(gPatternPerforation(x0, y0, height));
            }

            return gPeforationTrack;

        }
    }
}
