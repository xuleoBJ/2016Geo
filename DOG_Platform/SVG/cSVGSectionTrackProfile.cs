using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace DOGPlatform.SVG
{
    class cSVGSectionTrackProfile : cSVGSectionTrack
    {
        public cSVGSectionTrackProfile(int _iTrackWidth)
            : base(_iTrackWidth)
        {

        }
       
        XmlElement gPatternProfile(double x0, double y0, float fpercentZRL,double height)
        {
            XmlElement gProfile = svgDoc.CreateElement("g");

            XmlElement gRect = svgDoc.CreateElement("rect");
            gRect.SetAttribute("x", x0.ToString());
            gRect.SetAttribute("y", y0.ToString());
            gRect.SetAttribute("width", (this.iTrackWidth * fpercentZRL).ToString());
            gRect.SetAttribute("height", height.ToString());
            gRect.SetAttribute("stroke-width", "0.1");
            gRect.SetAttribute("stroke", "none");
            gRect.SetAttribute("fill", "blue");
             if(fpercentZRL>=0.6) gRect.SetAttribute("fill-opacity", fpercentZRL.ToString("0.0"));
             else if (fpercentZRL >= 0.4) gRect.SetAttribute("fill-opacity","0.5");
             else  gRect.SetAttribute("fill-opacity", "0.3");

            gProfile.AppendChild(gRect);

            XmlElement textValue = svgDoc.CreateElement("text");
            textValue.SetAttribute("x", (x0 + this.iTrackWidth * fpercentZRL+1).ToString());
            textValue.SetAttribute("y", (y0+0.7*height).ToString());
            textValue.SetAttribute("fill", "blue");
            textValue.SetAttribute("font-size", "6");
            textValue.SetAttribute("style", "stroke-width:1");
            textValue.InnerText = (fpercentZRL*100).ToString("0.0")+"%";
            gProfile.AppendChild(textValue);

            return gProfile;
        }
        public XmlElement gTrackProfile(string sJH,List<float> fListTopTVD, List<float> fListBottomTVD, List<float> fListPercentZRL, List<float> fListZRL,float m_KB)
        {
            XmlElement gProfileTrack = svgDoc.CreateElement("g");
            for (int i = 0; i < fListTopTVD.Count; i++)
            {
                float _top = fListTopTVD[i];
                float _bottom = fListBottomTVD[i];
                float _fpercentZRL = fListPercentZRL[i];
                float _fZRL = fListZRL[i];
                float x0 = 0;
                float y0 = -m_KB + _top;
                float height = _bottom - _top;
               gProfileTrack.AppendChild(gPatternProfile(x0,y0,_fpercentZRL/100,height));

            }

            return gProfileTrack;
        }

        public XmlElement gTrackProfile(string sJH, trackDataListProfile trackDataList, float m_KB)
        {
            return gTrackProfile(sJH, trackDataList.fListDS1, trackDataList.fListDS2,trackDataList.fListPercent , trackDataList.fListZRL,  m_KB);
        }

        public XmlElement gXieTrack2VerticalProfile(string sJH, trackDataListProfile trackDataList, float m_KB)
        {
            List<ItemDicWellPath> listWellPathDS1 = cIOinputWellPath.getWellPathItemListByJHAndMDList(sJH, trackDataList.fListDS1);
            List<ItemDicWellPath> listWellPathDS2 = cIOinputWellPath.getWellPathItemListByJHAndMDList(sJH, trackDataList.fListDS2);
            List<float> fListTVD1 = listWellPathDS1.Select(p => p.f_TVD).ToList();
            List<float> fListTVD2 = listWellPathDS2.Select(p => p.f_TVD).ToList();
            return gTrackProfile(sJH, fListTVD1, fListTVD2, trackDataList.fListPercent, trackDataList.fListZRL, m_KB);
        }

        public XmlElement gPathTrackProfile(string sJH, trackDataListProfile trackDataList, float m_KB)
        {
            return gPathTrackProfile(sJH, trackDataList.fListDS1, trackDataList.fListDS2,trackDataList.fListPercent , trackDataList.fListZRL,  m_KB);
        }

        public XmlElement gPathTrackProfile(string sJH, List<float> fListDS1, List<float> fListDS2, List<float> fListPercentZRL, List<float> fListZRL, float m_KB)
        {

            List<ItemDicWellPath> listWellPathTop = cIOinputWellPath.getWellPathItemListByJHAndMDList(sJH, fListDS1);
            List<ItemDicWellPath> listWellPathBase = cIOinputWellPath.getWellPathItemListByJHAndMDList(sJH, fListDS2);

            XmlElement gProfileTrack = svgDoc.CreateElement("g");
            gProfileTrack.SetAttribute("id", sJH + "#吸水剖面");
            for (int i = 0; i < fListDS1.Count; i++)
            {
                float _fpercentZRL = fListPercentZRL[i];
                float _fZRL = fListZRL[i];
                double x0 = listWellPathTop[0].f_dx;
                double y0 = -m_KB + listWellPathTop[i].f_TVD;
                double height = listWellPathBase[i].f_TVD - listWellPathTop[i].f_TVD;
                gProfileTrack.AppendChild(gPatternProfile(x0, y0, _fpercentZRL / 100, height));
            }
            return gProfileTrack;
        }
    }
}
