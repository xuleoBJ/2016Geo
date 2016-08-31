using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Drawing;
using System.Windows.Forms;

namespace DOGPlatform.SVG
{
    class cFenceDiagramSVGDoc : cSVGBaseSection
    {
     
        //public void addgElement2BaseLayer(XmlElement gElement, int iDx, int iDY)
        //{
        //    string sTranslate = "translate(" + iDx.ToString() + "," + iDY.ToString() + ")";
        //    gElement.SetAttribute("transform", sTranslate);
        //    this.gBaseLayer.AppendChild(gElement);
        //}
        /// <summary>
        /// 增加井柱子，与剖面图有不同
        /// </summary>
        /// <param name="sJH"></param>
        /// <param name="m_minMesureDepth"></param>
        /// <param name="m_maxMesureDepth"></param>
        /// <param name="m_tickInveral_main">
        /// 主tick刻度值
        /// </param>
        /// <param name="bShowTicks">
        /// 是否显示深度tick，由于栅状图是不用深度ticks的</param>
        /// <returns></returns>
        public XmlElement gWellCone(string sJH, float m_minMesureDepth, float m_maxMesureDepth, int m_tickInveral_main, bool bShowTicks, int iTrackwidth)
        {
            XmlElement gWellCone = svgDoc.CreateElement("g");
            gWellCone.SetAttribute("ID", sJH);
            XmlElement gWellHead = svgDoc.CreateElement("circle");
            gWellHead.SetAttribute("cx", "0");
            gWellHead.SetAttribute("cy", ( m_minMesureDepth).ToString());
            gWellHead.SetAttribute("r", "3");
            gWellHead.SetAttribute("stroke", "black");
            gWellHead.SetAttribute("fill", "red");
            gWellCone.AppendChild(gWellHead);
            XmlElement gWellBole = svgDoc.CreateElement("line");
            gWellBole.SetAttribute("x1", "0");
            gWellBole.SetAttribute("y1", (m_minMesureDepth).ToString());
            gWellBole.SetAttribute("x2", "0");
            gWellBole.SetAttribute("y2", (m_maxMesureDepth).ToString());
            gWellBole.SetAttribute("fill", "none");
            gWellBole.SetAttribute("stroke", "black");
            gWellBole.SetAttribute("stroke-width", "0.5");
            gWellCone.AppendChild(gWellBole);

            XmlElement gJHText = svgDoc.CreateElement("text");
            gJHText.SetAttribute("x", "-5");
            gJHText.SetAttribute("y", (m_minMesureDepth-5).ToString());
            gJHText.SetAttribute("fill", "red");
            gJHText.SetAttribute("font-size", "10");
            gJHText.SetAttribute("strole-width", "0.5");
            gJHText.InnerText = sJH;
            gWellCone.AppendChild(gJHText);


            int iCurrentDepth = (Convert.ToInt16(m_minMesureDepth) / m_tickInveral_main + 1) * m_tickInveral_main;
            while (iCurrentDepth <= m_maxMesureDepth && bShowTicks==true)
            {
                XmlElement gDepthTick = svgDoc.CreateElement("path");
                gDepthTick.SetAttribute("style", "stroke:blue;stroke-width:0.5");
                string d = "M0 " + ( iCurrentDepth.ToString()) + " h 3 ";
                gDepthTick.SetAttribute("d", d);
                gWellCone.AppendChild(gDepthTick);
                XmlElement gTickText = svgDoc.CreateElement("text");
                gTickText.SetAttribute("x", "3");
                gTickText.SetAttribute("y", iCurrentDepth.ToString());
                gTickText.SetAttribute("fill", "black");
                gTickText.SetAttribute("font-size", "3");
                gTickText.SetAttribute("strole-width", "0.3");
                gTickText.InnerText = iCurrentDepth.ToString();
                gWellCone.AppendChild(gTickText);
                iCurrentDepth = iCurrentDepth + m_tickInveral_main;
            }

            return gWellCone;
        }
        public XmlElement gWellConeByxmlConfig(string sJH, float m_minMesureDepth, float m_maxMesureDepth)
        {
            XDocument sectionMapXML = XDocument.Load(cProjectManager.xmlConfigSection);
            string _radisHeadCircle = sectionMapXML.Element("SectionMap").Element("WellCone").Element("radisHeadCircle").Value;
            int m_tickInveral_main = int.Parse(sectionMapXML.Element("SectionMap").Element("WellCone").Element("MainScale").Value);
            string _textFontSize = sectionMapXML.Element("SectionMap").Element("WellCone").Element("tickTextFontSize").Value;
            string _textFontColor = sectionMapXML.Element("SectionMap").Element("WellCone").Element("tickTextFontColor").Value;

            XmlElement gWellCone = svgDoc.CreateElement("g");
            gWellCone.SetAttribute("ID", sJH);
             float m_KB = 0;


            XmlElement gJHText = svgDoc.CreateElement("text");
            gJHText.SetAttribute("x", "-5");
            gJHText.SetAttribute("y", (-m_KB - 5 + m_minMesureDepth).ToString());
            gJHText.SetAttribute("fill", "red");
            gJHText.SetAttribute("font-size", "10");
            gJHText.SetAttribute("strole-width", "1");
            gJHText.InnerText = sJH;
            gWellCone.AppendChild(gJHText);


            int iCurrentDepth = (Convert.ToInt16(m_minMesureDepth) / m_tickInveral_main + 1) * m_tickInveral_main;
            while (iCurrentDepth <= m_maxMesureDepth)
            {
                XmlElement gDepthTick = svgDoc.CreateElement("path");
                gDepthTick.SetAttribute("style", "stroke:blue;stroke-width:0.5");
                string d = "M0 " + ((-m_KB + iCurrentDepth).ToString()) + " h 3 ";
                gDepthTick.SetAttribute("d", d);
                gWellCone.AppendChild(gDepthTick);

                int m_tickInveral_min = 2;
                while (m_tickInveral_min <= m_tickInveral_main)
                {
                    XmlElement gDepthMinTick = svgDoc.CreateElement("path");
                    gDepthMinTick.SetAttribute("style", "stroke:blue;stroke-width:0.5");
                    string dDepthMinTick = "M0 " + ((-m_KB + iCurrentDepth + m_tickInveral_min).ToString()) + " h 2 ";
                    gDepthMinTick.SetAttribute("d", dDepthMinTick);
                    gWellCone.AppendChild(gDepthMinTick);
                    m_tickInveral_min += 2;
                }
                XmlElement gTickText = svgDoc.CreateElement("text");
                gTickText.SetAttribute("x", "3");
                gTickText.SetAttribute("y", (-m_KB + iCurrentDepth).ToString());
                gTickText.SetAttribute("fill", _textFontColor);
                gTickText.SetAttribute("font-size", _textFontSize);
                gTickText.SetAttribute("strole-width", "1");
                gTickText.InnerText = iCurrentDepth.ToString();
                gWellCone.AppendChild(gTickText);
                iCurrentDepth = iCurrentDepth + m_tickInveral_main;
            }
            XmlElement gWellBoleLine = svgDoc.CreateElement("line");
            gWellBoleLine.SetAttribute("x1", "0");
            gWellBoleLine.SetAttribute("y1", (-m_KB + m_minMesureDepth).ToString());
            gWellBoleLine.SetAttribute("x2", "0");
            gWellBoleLine.SetAttribute("y2", (-m_KB + m_maxMesureDepth).ToString());
            gWellBoleLine.SetAttribute("stroke", "black");
            gWellBoleLine.SetAttribute("stroke-width", "2");
            gWellCone.AppendChild(gWellBoleLine);
            XmlElement gWellHead = svgDoc.CreateElement("circle");
            gWellHead.SetAttribute("cx", "0");
            gWellHead.SetAttribute("cy", (-m_KB + m_minMesureDepth).ToString());
            gWellHead.SetAttribute("r", _radisHeadCircle);
            gWellHead.SetAttribute("stroke", "black");
            gWellHead.SetAttribute("fill", "red");
            gWellCone.AppendChild(gWellHead);


            return gWellCone;
        }
        public XmlElement gTrackJSJL(List<float> fListTopTVD, List<float> fListBottomTVD, List<int> iListJSJL, int iTrackwidth)
        {
            float m_KB = 0F;
            XmlElement gJSJLTrack = svgDoc.CreateElement("g");
            gJSJLTrack.SetAttribute("ID", "JSJLTrack");
            for (int i = 0; i < fListTopTVD.Count; i++)
            {
                float _top = fListTopTVD[i];
                float _bottom = fListBottomTVD[i];
                float _jsjl = iListJSJL[i];

                //gJSJLRect.SetAttribute("fill", "#none");
                if (_jsjl == 1)
                {

                    XmlElement gJSJLRect = svgDoc.CreateElement("rect");
                    gJSJLRect.SetAttribute("x", "0");
                    gJSJLRect.SetAttribute("y", (-m_KB + _top).ToString());
                    gJSJLRect.SetAttribute("width", (iTrackwidth).ToString());
                    gJSJLRect.SetAttribute("height", (_bottom - _top).ToString());
                    gJSJLRect.SetAttribute("style", "stroke-width:0.01");
                    gJSJLRect.SetAttribute("stroke", "none");
                    gJSJLRect.SetAttribute("fill", "red");
                    gJSJLTrack.AppendChild(gJSJLRect);

                }//oil
                else if (_jsjl == 2)
                {
                    XmlElement gJSJLRect = svgDoc.CreateElement("rect");
                    gJSJLRect.SetAttribute("x", "0");
                    gJSJLRect.SetAttribute("y", (-m_KB + _top).ToString());
                    gJSJLRect.SetAttribute("width", (iTrackwidth).ToString());
                    gJSJLRect.SetAttribute("height", (_bottom - _top).ToString());
                    gJSJLRect.SetAttribute("style", "stroke-width:0.01");
                    gJSJLRect.SetAttribute("stroke", "none");
                    gJSJLRect.SetAttribute("fill", "blue");
                    gJSJLTrack.AppendChild(gJSJLRect);
                }  //water
                else if (_jsjl == 3)
                {
                    XmlElement gJSJLRect = svgDoc.CreateElement("rect");
                    gJSJLRect.SetAttribute("x", "0");
                    gJSJLRect.SetAttribute("y", (-m_KB + _top).ToString());
                    gJSJLRect.SetAttribute("width", (iTrackwidth).ToString());
                    gJSJLRect.SetAttribute("height", (_bottom - _top).ToString());
                    gJSJLRect.SetAttribute("style", "stroke-width:0.01");
                    gJSJLRect.SetAttribute("stroke", "none");
                    gJSJLRect.SetAttribute("fill", "yellow");
                    gJSJLTrack.AppendChild(gJSJLRect);
                }  //gas
                else if (_jsjl == 4)
                {
                    XmlElement gJSJLRect = svgDoc.CreateElement("rect");
                    gJSJLRect.SetAttribute("x", "0");
                    gJSJLRect.SetAttribute("y", (-m_KB + _top).ToString());
                    gJSJLRect.SetAttribute("width", (iTrackwidth).ToString());
                    gJSJLRect.SetAttribute("height", (_bottom - _top).ToString());
                    gJSJLRect.SetAttribute("style", "stroke-width:0.01");
                    gJSJLRect.SetAttribute("stroke", "black");
                    gJSJLRect.SetAttribute("fill", "none");
                    gJSJLTrack.AppendChild(gJSJLRect);
                    XmlElement gJSJLDryLine = svgDoc.CreateElement("path");
                    string d = "M " + (0.33 * iTrackwidth).ToString() + " " + (-m_KB + _top).ToString() + "v" + (_bottom - _top).ToString() + "h" + (0.34 * iTrackwidth).ToString() + "v-" + (_bottom - _top).ToString();
                    gJSJLDryLine.SetAttribute("d", d);
                    gJSJLDryLine.SetAttribute("style", "stroke-width:0.01");
                    gJSJLDryLine.SetAttribute("stroke", "black");
                    gJSJLDryLine.SetAttribute("fill", "none");
                    gJSJLTrack.AppendChild(gJSJLDryLine);
                }  //dry
                else if (_jsjl == 5)
                {
                    XmlElement gJSJLTriUp = svgDoc.CreateElement("path");
                    string d = "M 0 " + (-m_KB + _top).ToString() + "h" + (iTrackwidth).ToString() + "L0 " + (-m_KB + _bottom).ToString() + "Z";
                    gJSJLTriUp.SetAttribute("d", d);
                    gJSJLTriUp.SetAttribute("style", "stroke-width:0.01");
                    gJSJLTriUp.SetAttribute("fill", "yellow");
                    gJSJLTrack.AppendChild(gJSJLTriUp);
                    XmlElement gJSJLTriDown = svgDoc.CreateElement("path");
                    d = "M 0 " + (-m_KB + _bottom).ToString() + "h" + (iTrackwidth).ToString() + "v  " + (_top - _bottom).ToString() + "Z";
                    gJSJLTriDown.SetAttribute("d", d);
                    gJSJLTriDown.SetAttribute("style", "stroke-width:0.01");
                    gJSJLTriDown.SetAttribute("fill", "red");
                    gJSJLTrack.AppendChild(gJSJLTriDown);
                }  //##oilandgas
                else if (_jsjl == 6)//##OilWater
                {
                    XmlElement gJSJLTriUp = svgDoc.CreateElement("path");
                    string d = "M 0 " + (-m_KB + _top).ToString() + "h" + (iTrackwidth).ToString() + "L0 " + (-m_KB + _bottom).ToString() + "Z";
                    gJSJLTriUp.SetAttribute("d", d);
                    gJSJLTriUp.SetAttribute("style", "stroke-width:0.01");
                    gJSJLTriUp.SetAttribute("fill", "red");
                    gJSJLTrack.AppendChild(gJSJLTriUp);
                    XmlElement gJSJLTriDown = svgDoc.CreateElement("path");
                    d = "M 0 " + (-m_KB + _bottom).ToString() + "h" + (iTrackwidth).ToString() + "v  " + (_top - _bottom).ToString() + "Z";
                    gJSJLTriDown.SetAttribute("d", d);
                    gJSJLTriDown.SetAttribute("style", "stroke-width:0.01");
                    gJSJLTriDown.SetAttribute("fill", "blue");
                    gJSJLTrack.AppendChild(gJSJLTriDown);
                }
                else if (_jsjl == 7)
                {
                    XmlElement gJSJLTriUp = svgDoc.CreateElement("path");
                    string d = "M 0 " + (-m_KB + _top).ToString() + "h" + (iTrackwidth).ToString() + "L0 " + (-m_KB + _bottom).ToString() + "Z";
                    gJSJLTriUp.SetAttribute("d", d);
                    gJSJLTriUp.SetAttribute("style", "stroke-width:0.01");
                    gJSJLTriUp.SetAttribute("fill", "yellow");
                    gJSJLTrack.AppendChild(gJSJLTriUp);
                    XmlElement gJSJLTriDown = svgDoc.CreateElement("path");
                    d = "M 0 " + (-m_KB + _bottom).ToString() + "h" + (iTrackwidth).ToString() + "v  " + (_top - _bottom).ToString() + "Z";
                    gJSJLTriDown.SetAttribute("d", d);
                    gJSJLTriDown.SetAttribute("style", "stroke-width:0.01");
                    gJSJLTriDown.SetAttribute("fill", "blue");
                    gJSJLTrack.AppendChild(gJSJLTriDown);
                } //##GasWater
                else if (_jsjl == 8)
                {
                    XmlElement gJSJLRect = svgDoc.CreateElement("rect");
                    gJSJLRect.SetAttribute("x", "0");
                    gJSJLRect.SetAttribute("y", (-m_KB + _top).ToString());
                    gJSJLRect.SetAttribute("width", (iTrackwidth*0.5).ToString());
                    gJSJLRect.SetAttribute("height", (_bottom - _top).ToString());
                    gJSJLRect.SetAttribute("style", "stroke-width:0.01");
                    gJSJLRect.SetAttribute("stroke", "red");
                    gJSJLRect.SetAttribute("fill", "none");
                    gJSJLTrack.AppendChild(gJSJLRect);

                    XmlElement gJSJLRect2 = svgDoc.CreateElement("rect");
                    gJSJLRect2.SetAttribute("x", (iTrackwidth * 0.5).ToString());
                    gJSJLRect2.SetAttribute("y", (-m_KB + _top).ToString());
                    gJSJLRect2.SetAttribute("width", (iTrackwidth * 0.5).ToString());
                    gJSJLRect2.SetAttribute("height", (_bottom - _top).ToString());
                    gJSJLRect2.SetAttribute("style", "stroke-width:0.01");
                    gJSJLRect2.SetAttribute("stroke", "red");
                    gJSJLRect2.SetAttribute("fill", "red");
                    gJSJLTrack.AppendChild(gJSJLRect2);
                }  //##MinorOil
                else if (_jsjl == 9)
                {
                    XmlElement gJSJLRect = svgDoc.CreateElement("rect");
                    gJSJLRect.SetAttribute("x", "0");
                    gJSJLRect.SetAttribute("y", (-m_KB + _top).ToString());
                    gJSJLRect.SetAttribute("width", (iTrackwidth * 0.5).ToString());
                    gJSJLRect.SetAttribute("height", (_bottom - _top).ToString());
                    gJSJLRect.SetAttribute("style", "stroke-width:0.01");
                    gJSJLRect.SetAttribute("fill", "none");
                    gJSJLRect.SetAttribute("stroke", "blue");
                    gJSJLTrack.AppendChild(gJSJLRect);

                    XmlElement gJSJLRect2 = svgDoc.CreateElement("rect");
                    gJSJLRect2.SetAttribute("x", (iTrackwidth * 0.5).ToString());
                    gJSJLRect2.SetAttribute("y", (-m_KB + _top).ToString());
                    gJSJLRect2.SetAttribute("width", (iTrackwidth * 0.5).ToString());
                    gJSJLRect2.SetAttribute("height", (_bottom - _top).ToString());
                    gJSJLRect2.SetAttribute("style", "stroke-width:0.01");
                    gJSJLRect2.SetAttribute("stroke", "blue");
                    gJSJLRect2.SetAttribute("fill", "blue");
                    gJSJLTrack.AppendChild(gJSJLRect2);
                }  //##MinorGas
                else if (_jsjl == 10)
                {
                    XmlElement gJSJLRect = svgDoc.CreateElement("rect");
                    gJSJLRect.SetAttribute("x", "0");
                    gJSJLRect.SetAttribute("y", (-m_KB + _top).ToString());
                    gJSJLRect.SetAttribute("width", (iTrackwidth ).ToString());
                    gJSJLRect.SetAttribute("height", (_bottom - _top).ToString());
                    gJSJLRect.SetAttribute("style", "stroke-width:0.01");
                    gJSJLRect.SetAttribute("fill", "none");
                    gJSJLRect.SetAttribute("stroke", "red");
                    gJSJLTrack.AppendChild(gJSJLRect);

                    XmlElement gJSJLTriUp = svgDoc.CreateElement("path");
                    string d = "M" + (iTrackwidth * 0.5).ToString() + " " + (-m_KB + _top).ToString() + "h" + (iTrackwidth * 0.5).ToString() + "L " + (iTrackwidth * 0.5).ToString() + " " + (-m_KB + _bottom).ToString() + "Z";
                    gJSJLTriUp.SetAttribute("d", d);
                    gJSJLTriUp.SetAttribute("style", "stroke-width:0.01");
                    gJSJLTriUp.SetAttribute("fill", "yellow");
                    gJSJLTrack.AppendChild(gJSJLTriUp);
                    XmlElement gJSJLTriDown = svgDoc.CreateElement("path");
                    d = "M" + (iTrackwidth * 0.5).ToString() + " " + (-m_KB + _bottom).ToString() + "h" + (iTrackwidth * 0.5).ToString() + "v  " + (_top - _bottom).ToString() + "Z";
                    gJSJLTriDown.SetAttribute("d", d);
                    gJSJLTriDown.SetAttribute("style", "stroke-width:0.01");
                    gJSJLTriDown.SetAttribute("fill", "red");
                    gJSJLTrack.AppendChild(gJSJLTriDown);
                } //##MinorOilGas
                else if (_jsjl == 12)
                {
                    XmlElement gJSJLRect = svgDoc.CreateElement("rect");
                    gJSJLRect.SetAttribute("x", "0");
                    gJSJLRect.SetAttribute("y", (-m_KB + _top).ToString());
                    gJSJLRect.SetAttribute("width", (iTrackwidth).ToString());
                    gJSJLRect.SetAttribute("height", (_bottom - _top).ToString());
                    gJSJLRect.SetAttribute("style", "stroke-width:0.01");
                    gJSJLRect.SetAttribute("fill", "black");
                    gJSJLTrack.AppendChild(gJSJLRect);
                }  //##Coal
                else
                {
                    XmlElement gJSJLRect = svgDoc.CreateElement("rect");
                    gJSJLRect.SetAttribute("x", "0");
                    gJSJLRect.SetAttribute("y", (-m_KB + _top).ToString());
                    gJSJLRect.SetAttribute("width", (iTrackwidth).ToString());
                    gJSJLRect.SetAttribute("height", (_bottom - _top).ToString());
                    gJSJLRect.SetAttribute("style", "stroke-width:0.01");
                    gJSJLRect.SetAttribute("stroke", "none");
                    gJSJLRect.SetAttribute("stroke", "black");
                    gJSJLRect.SetAttribute("fill", "none");
                    gJSJLTrack.AppendChild(gJSJLRect);
                    XmlElement gJSJLText = svgDoc.CreateElement("text");
                    gJSJLText.SetAttribute("x", (iTrackwidth * 0.45).ToString());
                    gJSJLText.SetAttribute("y", (-m_KB + _bottom).ToString());
                    gJSJLText.SetAttribute("fill", "red");
                    gJSJLText.SetAttribute("font-size", "3");
                    gJSJLText.SetAttribute("strole-width", "1");
                    gJSJLText.InnerText = "?";
                    gJSJLTrack.AppendChild(gJSJLText);
                }

            }

            return gJSJLTrack;
        }
        public XmlElement addgConnectLayerTrack
          (Point pScreenWell1, List<float> fListDS1_well1, List<float> fListDS2_well1, List<string> ltStrXCM_well1, Point pScreenWell2,
          List<float> fListDS1_well2, List<float> fListDS2_well2, List<string> ltStrXCM_well2)
        {
            XmlElement gConnectTrack = svgDoc.CreateElement("g");
            gConnectTrack.SetAttribute("ID", "connect");
          //  setLayerColorByXML();
            for (int i = 0; i < ltStrXCM_well1.Count; i++)
            {
                float top_well1 = fListDS1_well1[i];
                float bottom_well1 = fListDS2_well1[i];
                string sXCM = ltStrXCM_well1[i];
                int indexXCM_well2 = ltStrXCM_well2.IndexOf(sXCM);
                if (indexXCM_well2 >= 0)
                {
                    float top_well2 = fListDS1_well2[indexXCM_well2];
                    float bottom_well2 = fListDS2_well2[indexXCM_well2];
                    XmlElement gConnectPath = svgDoc.CreateElement("path");
                    string d = "M" + pScreenWell1.X.ToString() + " " + (pScreenWell1.Y + top_well1).ToString() + "v" + (bottom_well1 - top_well1).ToString() + "L " + pScreenWell2.X.ToString() + " " + (pScreenWell2.Y +bottom_well2).ToString() + " " + "v" + (top_well2 - bottom_well2).ToString() + "z";
                    gConnectPath.SetAttribute("d", d);
                    gConnectPath.SetAttribute("style", "stroke-width:0.01");
                    gConnectPath.SetAttribute("stroke", "black");
                    gConnectPath.SetAttribute("fill-opacity", "0.2");
                    if (cProjectData.ltStrProjectXCM.Contains(sXCM))
                    {
                        int _iColorIndex = cProjectData.ltStrProjectXCM.IndexOf(sXCM);
                       // gConnectPath.SetAttribute("fill", cProjectData.ltStrProjectXCMColor[_iColorIndex]);
                    }
                    else
                    {
                        gConnectPath.SetAttribute("fill", "none");
                    }
              
                    gConnectTrack.AppendChild(gConnectPath);

                }


            }

            return gConnectTrack;
        }

        public XmlElement gTrackLayerDepth(List<float> fListDS1, List<float> fListDS2, List<string> ltStrXCM, int iTrackwidth)
        {
            float m_KB = 0;
            XmlElement gLayerDepthTrack = svgDoc.CreateElement("g");
            gLayerDepthTrack.SetAttribute("ID", "LayerTrackTrack");
            //setLayerColorByXML();
            for (int i = 0; i < ltStrXCM.Count; i++)
            {
                float _top = fListDS1[i];
                float _bottom = fListDS2[i];
                string sXCM = ltStrXCM[i];

                XmlElement gLayerDepthRect = svgDoc.CreateElement("rect");
                gLayerDepthRect.SetAttribute("x", "3");
                gLayerDepthRect.SetAttribute("y", (-m_KB + _top).ToString());
                gLayerDepthRect.SetAttribute("width", (iTrackwidth).ToString());
                gLayerDepthRect.SetAttribute("height", (_bottom - _top).ToString());
                gLayerDepthRect.SetAttribute("style", "stroke:black;stroke-width:0.1");
                if (cProjectData.ltStrProjectXCM.Contains(sXCM))
                {
                    int _iColorIndex = cProjectData.ltStrProjectXCM.IndexOf(sXCM);
                 //   gLayerDepthRect.SetAttribute("fill", cProjectData.ltStrProjectXCMColor[_iColorIndex]);
                }
                else
                {
                    gLayerDepthRect.SetAttribute("fill", "none");
                }
                gLayerDepthTrack.AppendChild(gLayerDepthRect);
                XmlElement textLayer = svgDoc.CreateElement("text");
                textLayer.SetAttribute("x", "3");
                textLayer.SetAttribute("y", (-m_KB + _top * 0.5 + _bottom * 0.5).ToString());
                textLayer.SetAttribute("fill", "blue");
                textLayer.SetAttribute("font-size", "4");
                textLayer.SetAttribute("style", "strole-width:1");
                textLayer.InnerText = sXCM;
                gLayerDepthTrack.AppendChild(textLayer);
            }

            return gLayerDepthTrack;
        }
        public XmlElement gTrackText(List<float> fListTVD, List<string> ltStrValue)
        {
            XmlElement gTextTrack = svgDoc.CreateElement("g");
            gTextTrack.SetAttribute("ID", "textTrack");
            for (int i = 0; i < fListTVD.Count; i++)
            {
                XmlElement gTextTick = svgDoc.CreateElement("path");
                gTextTick.SetAttribute("style", "stroke:blue;stroke-width:0.5");
                string d = "M0 " +  fListTVD[i].ToString() + " h 4 ";
                gTextTick.SetAttribute("d", d);
                gTextTrack.AppendChild(gTextTick);
                XmlElement textTickText = svgDoc.CreateElement("text");
                textTickText.SetAttribute("x", "2");
                textTickText.SetAttribute("y",  fListTVD[i].ToString());
                textTickText.SetAttribute("fill", "blue");
                textTickText.SetAttribute("font-size", "5");
                textTickText.SetAttribute("style", "strole-width:1");
                textTickText.InnerText = ltStrValue[i];
                gTextTrack.AppendChild(textTickText);
            }

            return gTextTrack;
        }
        public XmlElement gTrackTextByxmlConfig(List<float> fListTVD, List<string> ltStrValue)
        {
            XDocument sectionMapXML = XDocument.Load(cProjectManager.xmlConfigSection);
            string _textFontSize = sectionMapXML.Element("SectionMap").Element("TextTrack").Element("textFontSize").Value;
            string _textFontColor = sectionMapXML.Element("SectionMap").Element("TextTrack").Element("textFontColor").Value;
            string iTrackwidth = sectionMapXML.Element("SectionMap").Element("TextTrack").Element("trackWidth").Value;

            XmlElement gTextTrack = svgDoc.CreateElement("g");
            gTextTrack.SetAttribute("ID", "textTrack");
           float m_KB=0;
            for (int i = 0; i < fListTVD.Count; i++)
            {
                XmlElement gTextTick = svgDoc.CreateElement("path");
                gTextTick.SetAttribute("style", "stroke:blue;stroke-width:0.5");
                string d = "M0 " + (-m_KB + fListTVD[i]).ToString() + " h 4 ";
                gTextTick.SetAttribute("d", d);
                gTextTrack.AppendChild(gTextTick);
                XmlElement textTickText = svgDoc.CreateElement("text");
                textTickText.SetAttribute("x", "3");
                textTickText.SetAttribute("y", (-m_KB + fListTVD[i]).ToString());
                textTickText.SetAttribute("fill", _textFontColor);
                textTickText.SetAttribute("font-size", _textFontSize);
                textTickText.SetAttribute("style", "strole-width:1");
                textTickText.InnerText = ltStrValue[i];
                gTextTrack.AppendChild(textTickText);
            }

            return gTextTrack;
        }
        public XmlElement gTrackPerfoation(List<float> fListTop, List<float> fListBottom)
        {
            float m_KB = 0f;
            XmlElement gPeforationTrack = svgDoc.CreateElement("g");
            gPeforationTrack.SetAttribute("ID", "PeforationTrack");
            for (int i = 0; i < fListTop.Count; i++)
            {
                float _top = fListTop[i];
                float _bottom = fListBottom[i];
                XmlElement gPeforationInterval = svgDoc.CreateElement("path");
                string sPath = "m3 " + (-m_KB + _top).ToString() + " h8 h -4 v " + (_bottom - _top).ToString() + " h4 h-8";
                gPeforationInterval.SetAttribute("d", sPath);
                gPeforationInterval.SetAttribute("stroke-width", "1");
                gPeforationInterval.SetAttribute("stroke", "red");
                gPeforationInterval.SetAttribute("fill", "none");
                gPeforationTrack.AppendChild(gPeforationInterval);
            }

            return gPeforationTrack;
        }
        public XmlElement gTrackLog(string sLogName, List<float> fListTVD, List<float> fListValue, int m_settingMinValue, int m_settingMaxValue, int iTrackwidth, string m_sColorCurve)
        {
            XmlElement gLogTrack = svgDoc.CreateElement("g");
            gLogTrack.SetAttribute("ID", "sLogName");
            string _points = "";
            float _xView_f = 0f;
            for (int i = 0; i < fListTVD.Count; i++)
            {
                if (i % 2 == 0) //抽稀点
                {
                    if (-500 <= fListValue[i] && fListValue[i] < 1000)
                    {
                        _xView_f = iTrackwidth * (fListValue[i] - m_settingMinValue) / (m_settingMaxValue - m_settingMinValue);
                    }
                    else
                    {
                        _xView_f = m_settingMinValue;

                    }
                    _points = _points + (_xView_f).ToString() + ',' + fListTVD[i].ToString() + " ";
                }

            }
            XmlElement gLogPolyline = svgDoc.CreateElement("polyline");
            gLogPolyline.SetAttribute("style", "stroke-width:1");
            gLogPolyline.SetAttribute("stroke", m_sColorCurve);
            gLogPolyline.SetAttribute("fill", "none");
            gLogPolyline.SetAttribute("points", _points);
            gLogTrack.AppendChild(gLogPolyline);
            //添加道头名，X位置取道宽一半偏左，Y位置去深度最小值对应的海拔更低一些##添加道头名，X位置取道宽一半偏左，Y位置去深度最小值对应的海拔更低一些
            XmlElement logHeadText = svgDoc.CreateElement("text");
            logHeadText.SetAttribute("x", (iTrackwidth * 0.4).ToString());
            logHeadText.SetAttribute("y", (- 3 + fListTVD.Min()).ToString());
            logHeadText.SetAttribute("font-size", "5");
            logHeadText.SetAttribute("fill", m_sColorCurve);
            logHeadText.InnerText = sLogName;
            gLogTrack.AppendChild(logHeadText);

            //添加道标尺，X位置取道宽一半偏左，Y位置去深度最小值对应的海拔更低一些
            XmlElement curveHeadInfor = svgDoc.CreateElement("path");
            string sPath = "m0 " + ( - 3 + fListTVD.Min()).ToString() + " h " + iTrackwidth.ToString();
            curveHeadInfor.SetAttribute("d", sPath);
            curveHeadInfor.SetAttribute("style", "stroke-width:1");
            curveHeadInfor.SetAttribute("stroke", m_sColorCurve);
            curveHeadInfor.SetAttribute("fill", "none");

            gLogTrack.AppendChild(curveHeadInfor);


            return gLogTrack;
        }
   
       
      
        
      
    }
}
