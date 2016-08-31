using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Xml.Linq;
using DOGPlatform.XML;
using System.Drawing;

namespace DOGPlatform.SVG
{
    class cSVGSectionTrackLayer : cSVGSectionTrack
    {
        public List<string> colorList = cfilePathProject.getProjectLayerColor();
       

        public cSVGSectionTrackLayer() 
        {

            iTextSize = 6;
        }

        public cSVGSectionTrackLayer(int _iTrackWidth)
            : base(_iTrackWidth)
        {
            iTextSize = 6;
        }
     
        public int iTextSize { get; set; }

        
      
        /// <summary>增加地层道
        /// 增加地层道
        /// </summary>
        /// <param name="fListTVD1">
        /// 地层顶深
        /// </param>
        /// <param name="fListTVD2">
        /// 地层底深
        /// </param>
        /// <param name="ltStrXCM">
        /// 层段名
        /// </param>
        /// <param name="m_KB">
        /// 补心海拔
        /// </param>
        /// <returns>
        /// 地层道g
        /// </returns>
        public XmlElement gTrackLayerDepth(string sJH,List<float> fListDS1, List<float> fListDS2, List<string> ltStrXCM, float m_KB)
        {
            XmlElement gLayerDepthTrack = svgDoc.CreateElement("g");

            for (int i = 0; i < ltStrXCM.Count; i++)
            {
                float _top = fListDS1[i];
                float _bottom = fListDS2[i];
                string sXCM = ltStrXCM[i];
                double x0 = 0;
                double y0 = -m_KB + _top;
                double height = _bottom - _top;
                if (height > 0) gLayerDepthTrack.AppendChild(gPatternLayer(x0, y0, height, sXCM));
            }
            return gLayerDepthTrack;
        }
        XmlElement gPatternLayer(double x0, double y0, double height,string _sXCM)
        {
            XmlElement gLayer = svgDoc.CreateElement("g");
            XmlElement gLayerDepthRect = svgDoc.CreateElement("rect");
            //gLayerDepthRect.SetAttribute("onmouseover", "this.style.stroke = '#ff0000'; this.style['stroke-width'] = 0.5;");
            //gLayerDepthRect.SetAttribute("onmouseout", "this.style.stroke = 'black'; this.style['stroke-width'] = 0.1;");
            gLayerDepthRect.SetAttribute("x", x0.ToString());
            gLayerDepthRect.SetAttribute("y", y0.ToString());
            gLayerDepthRect.SetAttribute("width", this.iTrackWidth.ToString());
            gLayerDepthRect.SetAttribute("height", height.ToString());
            gLayerDepthRect.SetAttribute("style", "stroke:black;stroke-width:0.1");
            if (cProjectData.ltStrProjectXCM.Contains(_sXCM))
            {
                int _iColorIndex = cProjectData.ltStrProjectXCM.IndexOf(_sXCM);
                gLayerDepthRect.SetAttribute("fill", colorList[_iColorIndex]);
            }
            else
            {
                gLayerDepthRect.SetAttribute("fill", "none");
            }
            gLayer.AppendChild(gLayerDepthRect);
            XmlElement textLayer = svgDoc.CreateElement("text");
            //gLayerDepthRect.SetAttribute("onmouseover", "this.style.font-size= '8'");
            //gLayerDepthRect.SetAttribute("onmouseout", "this.style.fill = 'blue'; this.style.font-size= '6'; ");
            textLayer.SetAttribute("x", (x0+3).ToString());
            textLayer.SetAttribute("y", (y0 + 0.5 * height).ToString());
            textLayer.SetAttribute("fill", "black");
            textLayer.SetAttribute("font-size", iTextSize.ToString());
            textLayer.SetAttribute("style", "stroke-width:1");
            textLayer.InnerText = _sXCM;
            gLayer.AppendChild(textLayer);
            return gLayer;
        }
        public XmlElement gXieTrack2VerticalLayerDepth(string sJH, trackDataListLayerDepth layerDepthDataList, float m_KB)
        {
            List<ItemDicWellPath> listWellPathDS1 = cIOinputWellPath.getWellPathItemListByJHAndMDList(sJH, layerDepthDataList.fListDS1);
            List<ItemDicWellPath> listWellPathDS2 = cIOinputWellPath.getWellPathItemListByJHAndMDList(sJH, layerDepthDataList.fListDS2);
            List<float> fListTVD1 = listWellPathDS1.Select(p => p.f_TVD).ToList();
            List<float> fListTVD2 = listWellPathDS2.Select(p => p.f_TVD).ToList();
            return gTrackLayerDepth(sJH, fListTVD1, fListTVD2, layerDepthDataList.ltStrXCM, m_KB);
        }
        public XmlElement gPathTrackLayerDepth(string sJH, List<float> fListDS1, List<float> fListDS2, List<string> ltStrXCM, float m_KB)
        {
            XmlElement gLayerDepthTrack = svgDoc.CreateElement("g");
            List<ItemDicWellPath> listWellPathTop = cIOinputWellPath.getWellPathItemListByJHAndMDList(sJH, fListDS1);
             List<ItemDicWellPath> listWellPathBase = cIOinputWellPath.getWellPathItemListByJHAndMDList(sJH, fListDS2);
            for (int i = 0; i < ltStrXCM.Count; i++)
            {
                string sXCM = ltStrXCM[i];
                double x0 = listWellPathTop[0].f_dx;
                double y0 = -m_KB + listWellPathTop[i].f_TVD;
                double height = listWellPathBase[i].f_TVD - listWellPathTop[i].f_TVD;
                if(height>0) gLayerDepthTrack.AppendChild(gPatternLayer(x0, y0, height, sXCM));
            }

            return gLayerDepthTrack;
        }
        public XmlElement gPathTrackLayerDepth(string sJH, trackDataListLayerDepth layerDepthDataList, float m_KB)
        {
            return gPathTrackLayerDepth(sJH, layerDepthDataList.fListDS1, layerDepthDataList.fListDS2, layerDepthDataList.ltStrXCM, m_KB);
        }
        public XmlElement gTrackLayerDepth(string sJH,trackDataListLayerDepth layerDepthDataList, float m_KB)
        {
            return gTrackLayerDepth(sJH,layerDepthDataList.fListDS1, layerDepthDataList.fListDS2, layerDepthDataList.ltStrXCM, m_KB);
        }

        public static XmlElement gTrackLayerDepth(XmlDocument svgDoc,string sID, List<float> fListDS1, List<float> fListDS2, List<string> ltStrXCM, int iTrackwidth)
        {
            List<string> listLayerColor = cfilePathProject.getProjectLayerColor();
            XmlElement gLayerDepthTrack = svgDoc.CreateElement("g");
            for (int i = 0; i < ltStrXCM.Count; i++)
            {
                float top = fListDS1[i];
                float bottom = fListDS2[i];
                string sXCM = ltStrXCM[i];
                string fillColor="none";
                  if (cProjectData.ltStrProjectXCM.Contains(sXCM))
                {
                    int _iColorIndex = cProjectData.ltStrProjectXCM.IndexOf(sXCM);
                    fillColor = listLayerColor[_iColorIndex];
                }
                  if (top < bottom) //删除顶底深相同的层位
                  {
                      XmlElement gLayerDepthRect = cSVGWrapText.rectWithText(svgDoc,sID, sXCM,0, top, bottom-top, iTrackwidth, "black", 10, fillColor);
                      gLayerDepthTrack.AppendChild(gLayerDepthRect);
                  }
            }

            return gLayerDepthTrack;
        }
        public static XmlElement gTrackItemLayer(XmlDocument svgDoc, itemDrawDataIntervalValue item, double fVScale, int iFontSize, double iTrackWidth)
        {
            //return gTrackItemLayer(svgDoc, item.sID, item.top, item.bot, item.sProperty, fVScale, iFontSize, iTrackWidth);
            return gTrackItemLayerUnconformity(svgDoc, item.sID, item.top, item.bot, item.sProperty, (int)item.fValue, fVScale, iFontSize, iTrackWidth);
        }

        public static XmlElement gTrackItemTVDLayer(XmlDocument svgDoc, ItemTrackDrawDataIntervalProperty item, double fVScale, int iFontSize, double iTrackWidth)
        {
            return gTrackItemLayer(svgDoc, item.sID, item.topTVD, item.botTVD, item.sProperty, fVScale, iFontSize, iTrackWidth);
        }
        public static string getLayerFillColor(string sXCM)
        {
            string fillColor = "none";
            List<string> listLayerColor = cfilePathProject.getProjectLayerColor();
            if (cProjectData.ltStrProjectXCM.Contains(sXCM))
            {
                int _iColorIndex = cProjectData.ltStrProjectXCM.IndexOf(sXCM);
                fillColor = listLayerColor[_iColorIndex];
            }
            return fillColor; 
        } 


        public static XmlElement gTrackItemLayer(XmlDocument svgDoc, string sID, double fTop, double fBot, string sXCM, double fVScale, int iFontSize, double iTrackWidth)
        {
            fTop *= fVScale;
            fBot *= fVScale;
            XmlElement gLayer = svgDoc.CreateElement("g");
           
            string fillColor = getLayerFillColor(sXCM);
         
            if (fTop < fBot) //删除顶底深相同的层位
            {
                double height = fBot - fTop;
                XmlElement gLayerDepthRect = cSVGWrapText.rectWithText(svgDoc, sID, sXCM, 0, fTop, height, iTrackWidth, "black", iFontSize, fillColor);
                gLayerDepthRect.SetAttribute("onclick", "getID(evt)");
                gLayer.AppendChild(gLayerDepthRect);
            }

            return gLayer;
        }


        public static string makeWaveLinePathD() 
        {
                int amplitude=50;
                int wave=50;
                int startPointX=100;
                int startPointY=100;
                string d="M" + ( startPointX ).ToString() + "," + ( startPointY ).ToString();
                int up = 1;
               
                for(int i=0;i<20;i++)
                {
                    up=-1*up;
                    int startNewPointX=startPointX +i*wave;
                    string C1="C" + (startNewPointX + 0.33 * wave).ToString()+","+ ( startPointY+ up*amplitude/2).ToString();
                    int endPointX = startPointX +(i+1)*wave;
                    string C2=" "+(endPointX- 0.33*wave).ToString()+","+ ( startPointY+ up*amplitude/2).ToString();
                    d+=C1;
                    d+=C2;
                    d+=" "+(endPointX).ToString()+","+(startPointY).ToString();
                }
            return d;
        }


        public static string dWaveLine(
                double amplitude ,
                double wave,
                double startPointY,
                double iTrackWidth) 
        {
            string dStrWaveLine = "";
            double startNewWaveX = 0;
            int up = 1;
            while (startNewWaveX <= iTrackWidth - wave)
            {
                up *= -1;
                string C1 = "C" + (startNewWaveX + 0.33 * wave).ToString("0.0") + "," + (startPointY + up * amplitude / 2).ToString("0.0");
                double endPointX = startNewWaveX + wave;
                string C2 = " " + (endPointX - 0.33 * wave).ToString("0.0") + "," + (startPointY + up * amplitude / 2).ToString("0.0");
                dStrWaveLine += C1;
                dStrWaveLine += C2;
                dStrWaveLine += " " + (endPointX).ToString("0.0") + "," + (startPointY).ToString("0.0");
                startNewWaveX = endPointX;
            }
            return dStrWaveLine;
        }

        public static string dWaveLineReverse(
                double amplitude,
                double wave,
                double startPointY,
                double iTrackWidth)
        {
            string dStrWaveLine = "";
            double startNewWaveX = iTrackWidth;
            int up = 1;
            while (startNewWaveX >= wave)
            {
                up *= -1;
                string C1 = "C" + (startNewWaveX - 0.33 * wave).ToString("0.0") + "," + (startPointY + up * amplitude / 2).ToString("0.0");
                double endPointX = startNewWaveX - wave;
                string C2 = " " + (endPointX + 0.33 * wave).ToString("0.0") + "," + (startPointY + up * amplitude / 2).ToString("0.0");
                dStrWaveLine += C1;
                dStrWaveLine += C2;
                dStrWaveLine += " " + (endPointX).ToString("0.0") + "," + (startPointY).ToString("0.0");
                startNewWaveX = endPointX;
            }
            return dStrWaveLine;
        } 
        public static XmlElement gTrackItemLayerUnconformity(XmlDocument svgDoc, string sID, double fTop, double fBot, string sXCM, int iUniformityType, double fVScale, int iFontSize, double iTrackWidth)
        {
            fTop *= fVScale;
            fBot *= fVScale;
            XmlElement gLayer = svgDoc.CreateElement("g");

            string fillColor = getLayerFillColor(sXCM);

            if (fTop < fBot) //删除顶底深相同的层位
            {
                double height = fBot - fTop;
                XmlElement gWrapTextWithRect = svgDoc.CreateElement("g");
                XmlElement gTextBoundpath = svgDoc.CreateElement("path");
                gTextBoundpath.SetAttribute("id", sID);
                gTextBoundpath.SetAttribute("onclick", "getID(evt)");
                string d = "";
                d="M "+ iTrackWidth.ToString()+","+fTop.ToString("0.00");
                d+=" v"+height.ToString() +" h-"+iTrackWidth.ToString()+" v-"+height.ToString();

                int amplitude = 6;
                int wave = 6;
               
                //这块设计得考虑，0 代表不整合 1代表整合
                if (iUniformityType == (int)TypeConformity.顶不整合 ) //顶部不整合
                {
                    d = "M " + iTrackWidth.ToString() + "," + fTop.ToString("0.00");
                    d += " v" + height.ToString() + " h-" + iTrackWidth.ToString() + " v-" + height.ToString();
                    int startPointY = (int)fTop;
                    d = d+ dWaveLine( amplitude , wave , startPointY, iTrackWidth) ;
                }
                else if (iUniformityType == (int)TypeConformity.底不整合) //底部不整合
                {
                    d = "M " + iTrackWidth.ToString() + "," + (fTop + height).ToString("0.00");
                    d += " v-" + height.ToString() + " h-" + iTrackWidth.ToString() + " v+" + height.ToString();
                    int startPointY = (int)(fTop + height);
                    d = d + dWaveLine(amplitude, wave, startPointY, iTrackWidth);
                }
                else if (iUniformityType == (int)TypeConformity.顶底不整合) //顶底部不整合
                {
                    d = "M " + iTrackWidth.ToString() + "," + (fTop + height).ToString("0.00");
                    d += " v-" + height.ToString() ;
                    int startPointY = (int)(fTop);
                    d = d + dWaveLineReverse(amplitude, wave, startPointY, iTrackWidth);
                    d +=  " v+" + height.ToString();
                    startPointY = (int)(fTop + height);
                    d = d + dWaveLine(amplitude, wave, startPointY, iTrackWidth);
                    //d = d + dWaveLineReverse(amplitude, wave, startPointY, iTrackWidth);
                    //这块得返身的d
                }
                else if (iUniformityType == 4) //顶部角度不整合
                {

                }
                else //整合
                {
                    d = "M " + iTrackWidth.ToString() + "," + fTop.ToString("0.00");
                    d += " v" + height.ToString() + " h-" + iTrackWidth.ToString() + " v-" + height.ToString();
                }
                d += "z";
                gTextBoundpath.SetAttribute("d", d);
                gTextBoundpath.SetAttribute("style", "stroke:black;stroke-width:1");
                gTextBoundpath.SetAttribute("fill", fillColor);
                gWrapTextWithRect.AppendChild(gTextBoundpath);

                //分行处理
                XmlElement text = svgDoc.CreateElement("text");
                text.SetAttribute("x", (iTrackWidth * 0.5).ToString());
                text.SetAttribute("y", (fTop + height * 0.5).ToString());
                text.SetAttribute("fill", "black");
                text.SetAttribute("text-anchor", "middle");
                text.SetAttribute("dominant-baseline", "text-after-edge");
                text.SetAttribute("font-size", iFontSize.ToString());
                text.SetAttribute("style", "strole-width:1");

                List<string> ltBreakText = cPublicMethodBase.splitText2LimitLineWithChangLine(sXCM, (int)iTrackWidth, SystemFonts.DefaultFont);
                double fStartTextY = fTop + height * 0.35;
                double fLineHeight = SystemFonts.DefaultFont.Height;
                int iLineNum = ltBreakText.Count;
                for (int k = 0; k < iLineNum; k++)
                {
                    XmlElement tspan = svgDoc.CreateElement("tspan");
                    tspan.SetAttribute("x", (iTrackWidth * 0.5).ToString());
                    tspan.SetAttribute("y", (fStartTextY + fLineHeight * k).ToString());
                    tspan.InnerText = ltBreakText[k];
                    text.AppendChild(tspan);
                }

                gWrapTextWithRect.AppendChild(text);
                gWrapTextWithRect.SetAttribute("onclick", "getID(evt)");
                gLayer.AppendChild(gWrapTextWithRect);
            }

            return gLayer;
        }
    }
}
