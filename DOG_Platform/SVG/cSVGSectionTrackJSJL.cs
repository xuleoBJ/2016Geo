using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace DOGPlatform.SVG
{
    class cSVGSectionTrackJSJL : cSVGSectionTrack
    {
        public cSVGSectionTrackJSJL(int _iTrackWidth)
            : base(_iTrackWidth)
        {

        }
        public cSVGSectionTrackJSJL()
            : base()
        {

        }
        public static XmlElement gTrackItemJSJL(XmlDocument svgDoc, XmlElement svgDefs, ItemTrackDrawDataIntervalProperty item, double fVScale, int iTrackwidth)
        {
            return gTrackItemJSJL(svgDoc, svgDefs, item.sID, item.top, item.bot, fVScale, item.sProperty,  iTrackwidth);
        }

        public static XmlElement gTrackItemTVDJSJL( XmlDocument svgDoc, XmlElement svgDefs, ItemTrackDrawDataIntervalProperty item, double fVScale, int iTrackwidth)
        {
            return gTrackItemJSJL(svgDoc, svgDefs, item.sID, item.topTVD, item.botTVD,fVScale, item.sProperty, iTrackwidth);
        }
        public static XmlElement gTrackItemJSJL(XmlDocument svgDoc, XmlElement svgDefs, string sID, double fTop, double fBot, double fVScale, string sJSJL, int iTrackwidth)
        {
            fTop = fTop * fVScale;
            fBot = fBot * fVScale;
            XmlElement gJSJLItem = svgDoc.CreateElement("g");
            XmlElement gJSJLRect = svgDoc.CreateElement("rect");
            double height = fBot - fTop;
            gJSJLRect.SetAttribute("x", "0");
            gJSJLRect.SetAttribute("y", fTop.ToString("0.0"));
            gJSJLRect.SetAttribute("width", iTrackwidth.ToString());
            gJSJLRect.SetAttribute("height", height.ToString("0.0"));
            gJSJLRect.SetAttribute("id", sID);
            gJSJLRect.SetAttribute("style", "stroke-width:1");
            gJSJLRect.SetAttribute("stroke", "black");
            gJSJLRect.SetAttribute("fill", "none");
            gJSJLRect.SetAttribute("fill-opacity", "0.8");
            gJSJLRect.SetAttribute("onclick", "getID(evt)");

            int _jsjl = codeReplace.codeReplaceJSJL2int(sJSJL);
            if (_jsjl == 1)//油层
            {
                gJSJLRect.SetAttribute("fill", "red");
            }//oil
            else if (_jsjl == 2)  //差油层
            {
                string jsjlID = "jsjl2";
                string filePathPatternSVG = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "pattern", "jsjl", jsjlID + ".svg");
                if (File.Exists(filePathPatternSVG))
                {
                    cSVGoperate.addSVGpatternDefs(svgDoc, svgDefs,jsjlID, filePathPatternSVG);
                    gJSJLRect.SetAttribute("fill", string.Format("url(#{0})", jsjlID));
                }
                else
                {
                    gJSJLRect.SetAttribute("fill", "none");
                }
            }
            else if (_jsjl == 3)//##含水油层
            {
                string jsjlID = "jsjl3";
                string filePathPatternSVG = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "pattern", "jsjl", jsjlID + ".svg");
                if (File.Exists(filePathPatternSVG))
                {
                    cSVGoperate.addSVGpatternDefs(svgDoc, svgDefs, jsjlID, filePathPatternSVG);
                    gJSJLRect.SetAttribute("fill", string.Format("url(#{0})", jsjlID));
                }
                else
                {
                    gJSJLRect.SetAttribute("fill", "none");
                }
            }
            else if (_jsjl == 4)//##油水同层
            {
                string jsjlID = "jsjl4";
                string filePathPatternSVG = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "pattern", "jsjl", jsjlID + ".svg");
                if (File.Exists(filePathPatternSVG))
                {
                    cSVGoperate.addSVGpatternDefs(svgDoc, svgDefs, jsjlID, filePathPatternSVG);
                    gJSJLRect.SetAttribute("fill", string.Format("url(#{0})", jsjlID));
                }
                else
                {
                    gJSJLRect.SetAttribute("fill", "none");
                }
                //连接层图元
                string jsjlIDCon = "jsjl4Con";
                string filePathPatternConSVG = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "pattern", "jsjl", jsjlIDCon + ".svg");
                if (File.Exists(filePathPatternConSVG)) cSVGoperate.addSVGpatternDefs(svgDoc, svgDefs, jsjlIDCon, filePathPatternConSVG);
            }
            else if (_jsjl == 5)//##含油水层
            {
                string jsjlID = "jsjl5";
                string filePathPatternSVG = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "pattern", "jsjl", jsjlID + ".svg");
                if (File.Exists(filePathPatternSVG))
                {
                    cSVGoperate.addSVGpatternDefs(svgDoc, svgDefs, jsjlID, filePathPatternSVG);
                    gJSJLRect.SetAttribute("fill", string.Format("url(#{0})", jsjlID));
                }
                else
                {
                    gJSJLRect.SetAttribute("fill", "none");
                }
            }
            else if (_jsjl == 6)//## 可疑油气层
            {
                string jsjlID = "jsjl6";
                string filePathPatternSVG = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "pattern", "jsjl", jsjlID + ".svg");
                if (File.Exists(filePathPatternSVG))
                {
                    cSVGoperate.addSVGpatternDefs(svgDoc, svgDefs, jsjlID, filePathPatternSVG);
                    gJSJLRect.SetAttribute("fill", string.Format("url(#{0})", jsjlID));
                }
                else
                {
                    gJSJLRect.SetAttribute("fill", "none");
                }
            }
            else if (_jsjl == 7)//##油气同层
            {
                string jsjlID = "jsjl7";
                string filePathPatternSVG = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "pattern", "jsjl", jsjlID + ".svg");
                if (File.Exists(filePathPatternSVG))
                {
                    cSVGoperate.addSVGpatternDefs(svgDoc, svgDefs, jsjlID, filePathPatternSVG);
                    gJSJLRect.SetAttribute("fill", string.Format("url(#{0})", jsjlID));
                }
                else
                {
                    gJSJLRect.SetAttribute("fill", "none");
                }
                //连接层图元
                string jsjlIDCon = "jsjl7Con";
                string filePathPatternConSVG = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "pattern", "jsjl", jsjlIDCon + ".svg");
                if (File.Exists(filePathPatternConSVG)) cSVGoperate.addSVGpatternDefs(svgDoc, svgDefs, jsjlIDCon, filePathPatternConSVG);
            }
            else if (_jsjl == 8)//气层
            {
                gJSJLRect.SetAttribute("fill", "yellow");
            }  //gas
            else if (_jsjl == 9)//##气水同层
            {
                string jsjlID = "jsjl9";
                string filePathPatternSVG = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "pattern", "jsjl", jsjlID + ".svg");
                if (File.Exists(filePathPatternSVG))
                {
                    cSVGoperate.addSVGpatternDefs(svgDoc, svgDefs, jsjlID, filePathPatternSVG);
                    gJSJLRect.SetAttribute("fill", string.Format("url(#{0})", jsjlID));
                }
                else
                {
                    gJSJLRect.SetAttribute("fill", "none");
                }
            }
            else if (_jsjl == 10)//##含气水层
            {
                string jsjlID = "jsjl10";
                string filePathPatternSVG = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "pattern", "jsjl", jsjlID + ".svg");
                if (File.Exists(filePathPatternSVG))
                {
                    cSVGoperate.addSVGpatternDefs(svgDoc, svgDefs, jsjlID, filePathPatternSVG);
                    gJSJLRect.SetAttribute("fill", string.Format("url(#{0})", jsjlID));
                }
                else
                {
                    gJSJLRect.SetAttribute("fill", "none");
                }
            }
            else if (_jsjl == 11)//水层
            {
                gJSJLRect.SetAttribute("fill", "blue");
            }  //water
            else if (_jsjl == 12)//致密层
            {
                string jsjlID = "jsjl12";
                string filePathPatternSVG = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "pattern", "jsjl", jsjlID + ".svg");
                if (File.Exists(filePathPatternSVG))
                {
                    cSVGoperate.addSVGpatternDefs(svgDoc, svgDefs, jsjlID, filePathPatternSVG);
                    gJSJLRect.SetAttribute("fill", string.Format("url(#{0})", jsjlID));
                }
                else
                {
                    gJSJLRect.SetAttribute("fill", "white");
                }
            }  
            else if (_jsjl == 13)//干层
            {
                string jsjlID = "jsjl13";
                string filePathPatternSVG = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "pattern", "jsjl", jsjlID + ".svg");
                if (File.Exists(filePathPatternSVG))
                {
                    cSVGoperate.addSVGpatternDefs(svgDoc, svgDefs, jsjlID, filePathPatternSVG);
                    gJSJLRect.SetAttribute("fill", string.Format("url(#{0})", jsjlID));
                }
                else
                {
                    gJSJLRect.SetAttribute("fill", "none");
                }
            }  //dry
            else if (_jsjl == 14)//
            {
                gJSJLRect.SetAttribute("fill", "black");
            }//oil
            else
            {
                //空白方框

            }

            gJSJLItem.AppendChild(gJSJLRect);
            return gJSJLItem;
        }

        public XmlElement gXieTrack2VerticalJSJL(string sJH, trackDataListJSJL JSJLDataList, float m_KB)
        {
            List<ItemDicWellPath> listWellPathDS1 = cIOinputWellPath.getWellPathItemListByJHAndMDList(sJH, JSJLDataList.fListDS1);
            List<ItemDicWellPath> listWellPathDS2 = cIOinputWellPath.getWellPathItemListByJHAndMDList(sJH, JSJLDataList.fListDS2);
            List<float> fListTVD1 = listWellPathDS1.Select(p => p.f_TVD).ToList();
            List<float> fListTVD2 = listWellPathDS2.Select(p => p.f_TVD).ToList();
            return gTrackJSJL(sJH, fListTVD1, fListTVD2, JSJLDataList.sListJSJL,m_KB);
        }

        public XmlElement gPathTrackJSJL(string sJH, trackDataListJSJL JSJLDataList, float m_KB)
        {
            return gPathTrackJSJL(sJH, JSJLDataList.fListDS1, JSJLDataList.fListDS2, JSJLDataList.sListJSJL, m_KB);
        }

        public XmlElement gPathTrackJSJL(string sJH,List<float> fListTopMD, List<float> fListBottomMD, List<string> sListJSJL,float m_KB)
        {
            XmlElement gJSJLTrack = svgDoc.CreateElement("g");
            gJSJLTrack.SetAttribute("id", cIDmake.idJSJL(sJH));
          
            List<ItemDicWellPath> listWellPathTop = cIOinputWellPath.getWellPathItemListByJHAndMDList(sJH, fListTopMD);
            List<ItemDicWellPath> listWellPathBase = cIOinputWellPath.getWellPathItemListByJHAndMDList(sJH, fListBottomMD);
            for (int i = 0; i < fListTopMD.Count; i++)
            {
                int _jsjl =codeReplace.codeReplaceJSJL2int(sListJSJL[i]);
                double x0 = listWellPathTop[i].f_dx;
                double y0 = -m_KB + listWellPathTop[i].f_TVD;
                double height = listWellPathBase[i].f_TVD - listWellPathTop[i].f_TVD;
                if (_jsjl == 1) gJSJLTrack.AppendChild(gPatternJSJLOil(x0, y0, height)); //oil
                else if (_jsjl == 2) gJSJLTrack.AppendChild(gPatternJSJLWater(x0, y0, height));//water
                else if (_jsjl == 3) gJSJLTrack.AppendChild(gPatternJSJLGas(x0, y0, height));//gas
                else if (_jsjl == 4) gJSJLTrack.AppendChild(gPatternJSJLDry(x0, y0, height));//dry
                else if (_jsjl == 5) gJSJLTrack.AppendChild(gPatternJSJLOilGas(x0, y0, height)); //##oilandgas/
                else if (_jsjl == 6) gJSJLTrack.AppendChild(gPatternJSJLOilWater(x0, y0, height)); //##OilWater 
                else if (_jsjl == 7) gJSJLTrack.AppendChild(gPatternJSJLGasWater(x0, y0, height)); //## //##GasWater
                else if (_jsjl == 8) gJSJLTrack.AppendChild(gPatternJSJLMinorOil(x0, y0, height));  //##MinorOil
                else if (_jsjl == 9) gJSJLTrack.AppendChild(gPatternJSJLMinorGas(x0, y0, height)); //##MinorGas 
                else if (_jsjl == 10) gJSJLTrack.AppendChild(gPatternJSJLMinorOilGas(x0, y0, height)); // //##MinorOilGas
                else if (_jsjl == 12) gJSJLTrack.AppendChild(gPatternJSJLCoal(x0, y0, height)); ////##Coal
                else gJSJLTrack.AppendChild(gPatternJSJLUnKnown(x0, y0, height));

            }

            return gJSJLTrack;
        }
       
        public  XmlElement gTrackJSJL(string sJH,List<float> fListTopTVD, List<float> fListBottomTVD, List<string> sListJSJL, float m_KB)
        {
            XmlElement gJSJLTrack = svgDoc.CreateElement("g");
            gJSJLTrack.SetAttribute("id", cIDmake.idJSJL(sJH));
            for (int i = 0; i < fListTopTVD.Count; i++)
            {
                float _top = fListTopTVD[i];
                float _bottom = fListBottomTVD[i];
                int _jsjl = codeReplace.codeReplaceJSJL2int(sListJSJL[i]);
                float x0 = 0;
                float y0 = -m_KB + _top;
                float height = _bottom - _top;
                if (_jsjl == 1) gJSJLTrack.AppendChild(gPatternJSJLOil(x0,y0,height)); //oil
                else if (_jsjl == 2) gJSJLTrack.AppendChild(gPatternJSJLWater(x0,y0,height));//water
                else if (_jsjl == 3) gJSJLTrack.AppendChild(gPatternJSJLGas(x0,y0,height));//gas
                else if (_jsjl == 4)  gJSJLTrack.AppendChild(gPatternJSJLDry(x0,y0,height));//dry
                else if (_jsjl == 5) gJSJLTrack.AppendChild(gPatternJSJLOilGas(x0,y0,height)); //##oilandgas/
                else if (_jsjl == 6) gJSJLTrack.AppendChild(gPatternJSJLOilWater(x0,y0,height)); //##OilWater 
                else if (_jsjl == 7) gJSJLTrack.AppendChild(gPatternJSJLGasWater(x0,y0,height)); //## //##GasWater
                else if (_jsjl == 8)  gJSJLTrack.AppendChild(gPatternJSJLMinorOil(x0,y0,height));  //##MinorOil
                else if (_jsjl == 9)  gJSJLTrack.AppendChild(gPatternJSJLMinorGas(x0,y0,height)); //##MinorGas 
                else if (_jsjl == 10)  gJSJLTrack.AppendChild(gPatternJSJLMinorOilGas(x0,y0,height)); // //##MinorOilGas
                else if (_jsjl == 12)  gJSJLTrack.AppendChild(gPatternJSJLCoal(x0,y0,height)); ////##Coal
                else gJSJLTrack.AppendChild(gPatternJSJLUnKnown(x0, y0, height));

            }
            return gJSJLTrack;
        }
        public XmlElement gTrackJSJL(string sJH,trackDataListJSJL JSJLDataList, float m_KB)
        {
            return gTrackJSJL(sJH,JSJLDataList.fListDS1, JSJLDataList.fListDS2, JSJLDataList.sListJSJL, m_KB);
        }

        #region JSJLpattern
        XmlElement gPatternJSJLOil(double x0, double y0, double height)
        {
            XmlElement gJSJLRect = svgDoc.CreateElement("rect");
            gJSJLRect.SetAttribute("x", x0.ToString());
            gJSJLRect.SetAttribute("y", y0.ToString());
            gJSJLRect.SetAttribute("width", this.iTrackWidth.ToString());
            gJSJLRect.SetAttribute("height", height.ToString());
            gJSJLRect.SetAttribute("style", "stroke-width:0.5");
            gJSJLRect.SetAttribute("stroke", "black");
            gJSJLRect.SetAttribute("fill", "red");
            return gJSJLRect;
        }

        XmlElement gPatternJSJLGas(double x0, double y0, double height)
        {
            XmlElement gJSJLRect = svgDoc.CreateElement("rect");
            gJSJLRect.SetAttribute("x", x0.ToString());
            gJSJLRect.SetAttribute("y", y0.ToString());
            gJSJLRect.SetAttribute("width", this.iTrackWidth.ToString());
            gJSJLRect.SetAttribute("height", height.ToString());
            gJSJLRect.SetAttribute("style", "stroke-width:0.5");
            gJSJLRect.SetAttribute("stroke", "black");
            gJSJLRect.SetAttribute("fill", "yellow");
            return gJSJLRect;
        }

        XmlElement gPatternJSJLWater(double x0, double y0, double height)
        {
            XmlElement gJSJLRect = svgDoc.CreateElement("rect");
            gJSJLRect.SetAttribute("x", x0.ToString());
            gJSJLRect.SetAttribute("y", y0.ToString());
            gJSJLRect.SetAttribute("width", this.iTrackWidth.ToString());
            gJSJLRect.SetAttribute("height", height.ToString());
            gJSJLRect.SetAttribute("style", "stroke-width:0.5");
            gJSJLRect.SetAttribute("stroke", "black");
            gJSJLRect.SetAttribute("fill", "blue");
            return gJSJLRect;
        }
        XmlElement gPatternJSJLDry(double x0, double y0, double height)
        {
            XmlElement gJSJLDry = svgDoc.CreateElement("g");
            XmlElement gJSJLRect = svgDoc.CreateElement("rect");
            gJSJLRect.SetAttribute("x", x0.ToString());
            gJSJLRect.SetAttribute("y", y0.ToString());
            gJSJLRect.SetAttribute("width", this.iTrackWidth.ToString());
            gJSJLRect.SetAttribute("height", height.ToString());
            gJSJLRect.SetAttribute("style", "stroke-width:0.2");
            gJSJLRect.SetAttribute("stroke", "black");
            gJSJLRect.SetAttribute("fill", "none");
            gJSJLDry.AppendChild(gJSJLRect);
            XmlElement gJSJLRect2 = svgDoc.CreateElement("rect");
            gJSJLRect2.SetAttribute("x", (x0 + 0.33 * this.iTrackWidth).ToString());
            gJSJLRect2.SetAttribute("y", y0.ToString());
            gJSJLRect2.SetAttribute("width", (this.iTrackWidth * 0.34).ToString());
            gJSJLRect2.SetAttribute("height", height.ToString());
            gJSJLRect2.SetAttribute("style", "stroke-width:0.5");
            gJSJLRect2.SetAttribute("stroke", "black");
            gJSJLRect2.SetAttribute("fill", "none");
            gJSJLDry.AppendChild(gJSJLRect2);

            return gJSJLDry;
        }

        XmlElement gPatternJSJLOilGas(double x0, double y0, double height)
        {
            XmlElement gJSJLOG = svgDoc.CreateElement("g");
            XmlElement gJSJLTriUp = svgDoc.CreateElement("path");
            string d = "M " + x0.ToString() + " " + y0.ToString() + "h" + this.iTrackWidth.ToString() + "L " + x0.ToString() + " " + (y0 + height).ToString() + "Z";
            gJSJLTriUp.SetAttribute("d", d);
            gJSJLTriUp.SetAttribute("style", "stroke-width:0.5");
            gJSJLTriUp.SetAttribute("fill", "yellow");
            gJSJLOG.AppendChild(gJSJLTriUp);
            XmlElement gJSJLTriDown = svgDoc.CreateElement("path");
            d = "M " + x0.ToString() + " " + (y0 + height).ToString().ToString() + "h" + this.iTrackWidth.ToString() + "v  " + (-height).ToString() + "Z";
            gJSJLTriDown.SetAttribute("d", d);
            gJSJLTriDown.SetAttribute("style", "stroke-width:0.5");
            gJSJLTriDown.SetAttribute("fill", "red");
            gJSJLOG.AppendChild(gJSJLTriDown);
            return gJSJLOG;
        }

        XmlElement gPatternJSJLOilWater(double x0, double y0, double height) //##OilWater
        {
            XmlElement gJSJLOG = svgDoc.CreateElement("g");
            XmlElement gJSJLTriUp = svgDoc.CreateElement("path");
            string d = "M " + x0.ToString() + " " + y0.ToString() + "h" + this.iTrackWidth.ToString() + "L " + x0.ToString() + " " + (y0 + height).ToString() + "Z";
            gJSJLTriUp.SetAttribute("d", d);
            gJSJLTriUp.SetAttribute("style", "stroke-width:0.5");
            gJSJLTriUp.SetAttribute("fill", "red");
            gJSJLOG.AppendChild(gJSJLTriUp);
            XmlElement gJSJLTriDown = svgDoc.CreateElement("path");
            d = "M " + x0.ToString() + " " + (y0 + height).ToString().ToString() + "h" + this.iTrackWidth.ToString() + "v  " + (-height).ToString() + "Z";
            gJSJLTriDown.SetAttribute("d", d);
            gJSJLTriDown.SetAttribute("style", "stroke-width:0.5");
            gJSJLTriDown.SetAttribute("fill", "blue");
            gJSJLOG.AppendChild(gJSJLTriDown);
            return gJSJLOG;
        }
        XmlElement gPatternJSJLGasWater(double x0, double y0, double height) //##GasWater
        {
            XmlElement gJSJLOG = svgDoc.CreateElement("g");
            XmlElement gJSJLTriUp = svgDoc.CreateElement("path");
            string d = "M " + x0.ToString() + " " + y0.ToString() + "h" + this.iTrackWidth.ToString() + "L " + x0.ToString() + " " + (y0 + height).ToString() + "Z";
            gJSJLTriUp.SetAttribute("d", d);
            gJSJLTriUp.SetAttribute("style", "stroke-width:0.5");
            gJSJLTriUp.SetAttribute("fill", "yellow");
            gJSJLOG.AppendChild(gJSJLTriUp);
            XmlElement gJSJLTriDown = svgDoc.CreateElement("path");
            d = "M " + x0.ToString() + " " + (y0 + height).ToString().ToString() + "h" + this.iTrackWidth.ToString() + "v  " + (-height).ToString() + "Z";
            gJSJLTriDown.SetAttribute("d", d);
            gJSJLTriDown.SetAttribute("style", "stroke-width:0.5");
            gJSJLTriDown.SetAttribute("fill", "blue");
            gJSJLOG.AppendChild(gJSJLTriDown);
            return gJSJLOG;
        }
        XmlElement gPatternJSJLMinorOil(double x0, double y0, double height) //##MinorOil
        {
            XmlElement gJSJL = svgDoc.CreateElement("g");
            XmlElement gJSJLRect = svgDoc.CreateElement("rect");
            gJSJLRect.SetAttribute("x", x0.ToString());
            gJSJLRect.SetAttribute("y", y0.ToString());
            gJSJLRect.SetAttribute("width", (this.iTrackWidth * 0.5).ToString());
            gJSJLRect.SetAttribute("height", height.ToString());
            gJSJLRect.SetAttribute("style", "stroke-width:0.5");
            gJSJLRect.SetAttribute("stroke", "red");
            gJSJLRect.SetAttribute("fill", "none");
            gJSJL.AppendChild(gJSJLRect);

            XmlElement gJSJLRect2 = svgDoc.CreateElement("rect");
            gJSJLRect2.SetAttribute("x", (x0 + this.iTrackWidth * 0.5).ToString());
            gJSJLRect2.SetAttribute("y", y0.ToString());
            gJSJLRect2.SetAttribute("width", (this.iTrackWidth * 0.5).ToString());
            gJSJLRect2.SetAttribute("height", height.ToString());
            gJSJLRect2.SetAttribute("style", "stroke-width:0.5");
            gJSJLRect2.SetAttribute("stroke", "black");
            gJSJLRect2.SetAttribute("fill", "red");
            gJSJL.AppendChild(gJSJLRect2);
            return gJSJL;
        }


        XmlElement gPatternJSJLMinorGas(double x0, double y0, double height) //##MinorGs
        {
            XmlElement gJSJL = svgDoc.CreateElement("g");
            XmlElement gJSJLRect = svgDoc.CreateElement("rect");
            gJSJLRect.SetAttribute("x", x0.ToString());
            gJSJLRect.SetAttribute("y", y0.ToString());
            gJSJLRect.SetAttribute("width", (this.iTrackWidth * 0.5).ToString());
            gJSJLRect.SetAttribute("height", height.ToString());
            gJSJLRect.SetAttribute("style", "stroke-width:0.5");
            gJSJLRect.SetAttribute("stroke", "black");
            gJSJLRect.SetAttribute("fill", "none");
            gJSJL.AppendChild(gJSJLRect);

            XmlElement gJSJLRect2 = svgDoc.CreateElement("rect");
            gJSJLRect2.SetAttribute("x", (x0 + this.iTrackWidth * 0.5).ToString());
            gJSJLRect2.SetAttribute("y", y0.ToString());
            gJSJLRect2.SetAttribute("width", (this.iTrackWidth * 0.5).ToString());
            gJSJLRect2.SetAttribute("height", height.ToString());
            gJSJLRect2.SetAttribute("style", "stroke-width:0.5");
            gJSJLRect2.SetAttribute("stroke", "black");
            gJSJLRect2.SetAttribute("fill", "yellow");
            gJSJL.AppendChild(gJSJLRect2);
            return gJSJL;
        }

        XmlElement gPatternJSJLMinorOilGas(double x0, double y0, double height) //#差油气层
        {
            XmlElement gJSJL = svgDoc.CreateElement("g");
            XmlElement gJSJLRect = svgDoc.CreateElement("rect");
            gJSJLRect.SetAttribute("x", x0.ToString());
            gJSJLRect.SetAttribute("y", y0.ToString());
            gJSJLRect.SetAttribute("width", this.iTrackWidth.ToString());
            gJSJLRect.SetAttribute("height", height.ToString());
            gJSJLRect.SetAttribute("style", "stroke-width:0.5");
            gJSJLRect.SetAttribute("fill", "black");
            gJSJLRect.SetAttribute("stroke", "red");
            gJSJL.AppendChild(gJSJLRect);

            XmlElement gJSJLTriUp = svgDoc.CreateElement("path");
            string d = "M " + x0.ToString() + " " + y0.ToString() + "h" + this.iTrackWidth.ToString() + "L " + x0.ToString() + " " + (y0 + height).ToString() + "Z";
            gJSJLTriUp.SetAttribute("d", d);
            gJSJLTriUp.SetAttribute("style", "stroke-width:0.5");
            gJSJLTriUp.SetAttribute("fill", "yellow");
            gJSJL.AppendChild(gJSJLTriUp);
            XmlElement gJSJLTriDown = svgDoc.CreateElement("path");
            d = "M " + x0.ToString() + " " + (y0 + height).ToString().ToString() + "h" + this.iTrackWidth.ToString() + "v  " + (-height).ToString() + "Z";
            gJSJLTriDown.SetAttribute("d", d);
            gJSJLTriDown.SetAttribute("style", "stroke-width:0.5");
            gJSJLTriDown.SetAttribute("fill", "red");
            gJSJL.AppendChild(gJSJLTriDown);
            return gJSJL;
        }

        XmlElement gPatternJSJLCoal(double x0, double y0, double height) //#煤层
        {
            XmlElement gJSJLRect = svgDoc.CreateElement("rect");
            gJSJLRect.SetAttribute("x", x0.ToString());
            gJSJLRect.SetAttribute("y", y0.ToString());
            gJSJLRect.SetAttribute("width", this.iTrackWidth.ToString());
            gJSJLRect.SetAttribute("height", height.ToString());
            gJSJLRect.SetAttribute("style", "stroke-width:0.5");
            gJSJLRect.SetAttribute("stroke", "black");
            gJSJLRect.SetAttribute("fill", "black");
            return gJSJLRect;
        }

        XmlElement gPatternJSJLUnKnown(double x0, double y0, double height) //#未知
        {
            XmlElement gJSJL = svgDoc.CreateElement("g");
            XmlElement gJSJLRect = svgDoc.CreateElement("rect");
            gJSJLRect.SetAttribute("x", x0.ToString());
            gJSJLRect.SetAttribute("y", y0.ToString());
            gJSJLRect.SetAttribute("width", this.iTrackWidth.ToString());
            gJSJLRect.SetAttribute("height", height.ToString());
            gJSJLRect.SetAttribute("style", "stroke-width:0.5");
            gJSJLRect.SetAttribute("stroke", "red");
            gJSJLRect.SetAttribute("fill", "none");
            gJSJL.AppendChild(gJSJLRect);
            XmlElement gJSJLText = svgDoc.CreateElement("text");
            gJSJLText.SetAttribute("x", (x0 + this.iTrackWidth * 0.45).ToString());
            gJSJLText.SetAttribute("y", y0.ToString());
            gJSJLText.SetAttribute("fill", "red");
            gJSJLText.SetAttribute("font-size", "3");
            gJSJLText.SetAttribute("strole-width", "1");
            gJSJLText.InnerText = "?";
            gJSJL.AppendChild(gJSJLText);
            return gJSJL;
        }

        #endregion

    }
}
