using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
namespace DOGPlatform.SVG
{
    class itemDrawDataDepthRuler
    {
        public int mainTick;
        public int minTick;
        public int tickFontSize;
        public int iTypeRuler;
        public itemDrawDataDepthRuler(XmlNode xn)
        {
            mainTick = int.Parse(xn["mainScale"].InnerText);
            minTick = int.Parse(xn["minScale"].InnerText);
            tickFontSize = int.Parse(xn["fontSize"].InnerText);
            iTypeRuler = int.Parse(xn["iTypeRuler"].InnerText);
        }

    }

    class cSVGSectionTrackWellRuler
    {
        public static XmlElement gElevationRulerSimple(XmlDocument svgDoc, int ElevationDepthTop, int ElevationDepthBase, int m_tickInveral_main, float fVsacle, int iFontSize)
        {
            int iWidth = 40;
            XmlElement gElevationRuler = svgDoc.CreateElement("g");
            gElevationRuler.SetAttribute("id", cIDmake.idTrackRuler());
            //加主轴
            XmlElement gLine = svgDoc.CreateElement("line");
            gLine.SetAttribute("x1", iWidth.ToString());
            gLine.SetAttribute("y1", (-ElevationDepthBase * fVsacle).ToString());
            gLine.SetAttribute("x2", iWidth.ToString());
            gLine.SetAttribute("y2", (-ElevationDepthTop * fVsacle).ToString());
            gLine.SetAttribute("stroke", "black");
            gLine.SetAttribute("stroke-width", "1.5");
            gElevationRuler.AppendChild(gLine);
            //当前深度
            int iCurrentDepth = (Convert.ToInt16(ElevationDepthBase) / m_tickInveral_main) * m_tickInveral_main;
            while (iCurrentDepth <= ElevationDepthTop)
            {
                XmlElement gDepthTick = svgDoc.CreateElement("path");
                gDepthTick.SetAttribute("stroke-width", "2");
                string d = "M " + iWidth.ToString() + " " + (-iCurrentDepth * fVsacle).ToString() + " h -20 ";
                if (iCurrentDepth % m_tickInveral_main != 0)
                {
                    d = "M" + iWidth.ToString() + " " + (-iCurrentDepth * fVsacle).ToString() + " h -10 ";
                }
                gDepthTick.SetAttribute("stroke", "black");
                gDepthTick.SetAttribute("d", d);
                gElevationRuler.AppendChild(gDepthTick);

                if (iCurrentDepth % m_tickInveral_main == 0)
                {
                    XmlElement gTickText = svgDoc.CreateElement("text");
                    gTickText.SetAttribute("x", (iWidth-10).ToString());
                    gTickText.SetAttribute("y", (-iCurrentDepth * fVsacle).ToString());
                    gTickText.SetAttribute("fill", "black");
                    gTickText.SetAttribute("font-size",iFontSize.ToString());
                    gTickText.SetAttribute("text-anchor", "end");
                    gTickText.SetAttribute("alignment-baseline", "central");
                    gTickText.SetAttribute("strole-width", "1");
                    gTickText.InnerText = iCurrentDepth.ToString();
                    gElevationRuler.AppendChild(gTickText);
                }
                iCurrentDepth = iCurrentDepth + m_tickInveral_main / 5;
            }
            return gElevationRuler;
        }
        public static XmlElement gElevationRuler(XmlDocument svgDoc, int ElevationDepthTop, int ElevationDepthBase, int m_tickInveral_main)
        {
            int iWidth = 40;
            XmlElement gElevationRuler = svgDoc.CreateElement("g");
            gElevationRuler.SetAttribute("id", cIDmake.idTrackRuler());

            //加主轴
            XmlElement gLine = svgDoc.CreateElement("line");
            gLine.SetAttribute("x1", "0");
            gLine.SetAttribute("y1", (-ElevationDepthBase).ToString());
            gLine.SetAttribute("x2", "0");
            gLine.SetAttribute("y2", (-ElevationDepthTop).ToString());
            gLine.SetAttribute("stroke", "black");
            gLine.SetAttribute("stroke-width", "0.5");
            gElevationRuler.AppendChild(gLine);
            //加方框
            XmlElement gRect = svgDoc.CreateElement("rect");
            gRect.SetAttribute("x", "0");
            gRect.SetAttribute("y", (-ElevationDepthTop).ToString());
            gRect.SetAttribute("width", iWidth.ToString());
            gRect.SetAttribute("height", (ElevationDepthTop-ElevationDepthBase).ToString());
            gRect.SetAttribute("style", "stroke-width:0.5");
            gRect.SetAttribute("stroke", "black");
            gRect.SetAttribute("fill", "none");
            gElevationRuler.AppendChild(gRect);
            //当前深度
            int iCurrentDepth = (Convert.ToInt16(ElevationDepthBase) / m_tickInveral_main) * m_tickInveral_main;
            while (iCurrentDepth <= ElevationDepthTop)
            {
                XmlElement gDepthTick = svgDoc.CreateElement("path");
                gDepthTick.SetAttribute("stroke-width", "1");
                string d = "M " + iWidth.ToString()+" " + (-iCurrentDepth).ToString() + " h -8 ";
                if  (iCurrentDepth % m_tickInveral_main != 0)
                {
                    d = "M" + iWidth.ToString() + " " + (-iCurrentDepth).ToString() + " h -4 "; 
                }
                gDepthTick.SetAttribute("stroke", "black");
                gDepthTick.SetAttribute("d", d);
                gElevationRuler.AppendChild(gDepthTick);

                if (iCurrentDepth % m_tickInveral_main == 0)
                {
                    XmlElement gTickText = svgDoc.CreateElement("text");
                    gTickText.SetAttribute("x", "4");
                    gTickText.SetAttribute("y", (-iCurrentDepth+4).ToString());
                    gTickText.SetAttribute("fill", "black");
                    gTickText.SetAttribute("font-size", "12");
                    gTickText.SetAttribute("strole-width", "0.5");
                    gTickText.InnerText = iCurrentDepth.ToString();
                    gElevationRuler.AppendChild(gTickText);
                }
                iCurrentDepth = iCurrentDepth + m_tickInveral_main / 5; 
            }

            return gElevationRuler;
        }

        public static XmlElement gWellSecionRuler(ItemWell curWell, cSVGBaseSection cSVG_Well, double minMesureDepth, double maxMesureDepth, double dfVscale, itemDrawDataDepthRuler itemRuler)
        {
          if(itemRuler.iTypeRuler == 1) 
            return gMDTVDRuler(curWell,cSVG_Well.svgDoc, cSVG_Well.svgDefs, cSVG_Well.svgCss, minMesureDepth, maxMesureDepth, itemRuler.mainTick, itemRuler.minTick, dfVscale, itemRuler.tickFontSize);
          else
            return gMDRuler(cSVG_Well.svgDoc, cSVG_Well.svgDefs, cSVG_Well.svgCss, minMesureDepth, maxMesureDepth, itemRuler.mainTick, itemRuler.minTick, dfVscale, itemRuler.tickFontSize);

        }

        public static XmlElement gMDRuler(cSVGBaseSection cSVG_Well, double minMesureDepth, double maxMesureDepth,double dfVscale,itemDrawDataDepthRuler itemRuler)
        {
            return gMDRuler(cSVG_Well.svgDoc, cSVG_Well.svgDefs, cSVG_Well.svgCss, minMesureDepth, maxMesureDepth, itemRuler.mainTick, itemRuler.minTick, dfVscale, itemRuler.tickFontSize);
        }
        public static XmlElement gMDRuler(XmlDocument svgDoc,XmlElement svgDefs, XmlElement svgCss, double minMesureDepth, double maxMesureDepth, int m_tickInveral_main, int m_tickInveral_min, double dfVscale,int iTickFontSize)
        {
            List<double> ltdfMainTickDepth = new List<double>();
            List<string> ltStrMainTickText = new List<string>();
            List<double> ltdfminTickDepth = new List<double>();
            //主tick和标识
            int iStartMainDepth = (Convert.ToInt16(minMesureDepth) / m_tickInveral_main + 1) * m_tickInveral_main;
            while (iStartMainDepth <= maxMesureDepth)
            {
                ltdfMainTickDepth.Add(iStartMainDepth);
                ltStrMainTickText.Add(iStartMainDepth.ToString());
                iStartMainDepth = iStartMainDepth + m_tickInveral_main;
            }
            int iTinyTickValue = cPublicMethodBase.getCeilingNumer(minMesureDepth, m_tickInveral_min);
            if (ltdfMainTickDepth.Count > 0)
            {
                while (iTinyTickValue <= ltdfMainTickDepth.Last())
                {
                    ltdfminTickDepth.Add(iTinyTickValue);
                    iTinyTickValue = iTinyTickValue + m_tickInveral_min;
                }
            }
            List<double> ltdfViewMainTickDepth = cSVGBase.transformListVscale(ltdfMainTickDepth, dfVscale);
            XmlElement gMDRuler = svgDoc.CreateElement("g");
            gMDRuler.SetAttribute("id", cIDmake.idTrackRuler());
            //主tick和标识
            for (int i = 0; i < ltdfViewMainTickDepth.Count; i++)
            {
                XmlElement gDepthTick = svgDoc.CreateElement("use");
                gDepthTick.SetAttribute("x", "0");
                gDepthTick.SetAttribute("y", ltdfViewMainTickDepth[i].ToString());
                gDepthTick.SetAttribute("href", cSVGBase.svgNS, "#" + cIDmake.idDepthTickMain);
                gMDRuler.AppendChild(gDepthTick);
                
                XmlElement gTickText = svgDoc.CreateElement("text");
                gTickText.SetAttribute("class", "DepthMainTickTextCss");
                gTickText.SetAttribute("x", "6");
                gTickText.SetAttribute("y", ltdfViewMainTickDepth[i].ToString());
                gTickText.SetAttribute("font-size", iTickFontSize.ToString());
                gTickText.InnerText = ltStrMainTickText[i];
                gMDRuler.AppendChild(gTickText);
            }
            //minTick
            List<double> ltdfViewMinTickDepth = cSVGBase.transformListVscale(ltdfminTickDepth, dfVscale);
            for (int i = 0; i < ltdfViewMinTickDepth.Count; i++)
            {
                XmlElement gDepthMinTick = svgDoc.CreateElement("use");
                gDepthMinTick.SetAttribute("x", "0");
                gDepthMinTick.SetAttribute("y", ltdfViewMinTickDepth[i].ToString());
                gDepthMinTick.SetAttribute("href",cSVGBase.svgNS, "#"+cIDmake.idDepthTickMin);
                gMDRuler.AppendChild(gDepthMinTick);
            }
            //主轴
            if (ltdfViewMainTickDepth.Count > 0)
            {
                XmlElement gWellBoleLine = svgDoc.CreateElement("line");
                gWellBoleLine.SetAttribute("x1", "0");
                gWellBoleLine.SetAttribute("y1", (minMesureDepth * dfVscale).ToString());
                gWellBoleLine.SetAttribute("x2", "0");
                gWellBoleLine.SetAttribute("y2", ltdfViewMainTickDepth.Last().ToString());
                gWellBoleLine.SetAttribute("stroke", "black");
                gWellBoleLine.SetAttribute("stroke-width", "1");
                gMDRuler.AppendChild(gWellBoleLine);
            }
            return gMDRuler;
        }
        
        //将TVD转为MD画 
        public static XmlElement gMDTVDRuler(ItemWell curWell, cSVGBaseSection cSVG_Well, double minMesureDepth, double maxMesureDepth, double dfVscale, itemDrawDataDepthRuler itemRuler)
        {
            return gMDTVDRuler(curWell,cSVG_Well.svgDoc, cSVG_Well.svgDefs, cSVG_Well.svgCss, minMesureDepth, maxMesureDepth, itemRuler.mainTick, itemRuler.minTick, dfVscale, itemRuler.tickFontSize);
        }
        public static XmlElement gMDTVDRuler(ItemWell curWell ,XmlDocument svgDoc,XmlElement svgDefs, XmlElement svgCss, double minMesureDepth, double maxMesureDepth, int m_tickInveral_main, int m_tickInveral_min, double dfVscale,int iTickFontSize)
        {
            List<double> ltdfMainTickDepth = new List<double>();
            List<string> ltStrMainTickText = new List<string>();
            List<double> ltdfminTickDepth = new List<double>();
            //主tick和标识
            int iStartMainDepth = (Convert.ToInt16(minMesureDepth) / m_tickInveral_main) * m_tickInveral_main;
            while (iStartMainDepth <= maxMesureDepth)
            {
                float fMD = cIOinputWellPath.getMDByJHAndTVD(curWell.sJH, iStartMainDepth, curWell.WellPathList);
                if (fMD >= maxMesureDepth) break;
                ltdfMainTickDepth.Add(fMD);
                ltStrMainTickText.Add(iStartMainDepth.ToString());
                iStartMainDepth = iStartMainDepth + m_tickInveral_main;
            }
            int iTinyTickValue = cPublicMethodBase.getCeilingNumer(minMesureDepth, m_tickInveral_min);
            while (iTinyTickValue <= maxMesureDepth)
            {
                float fMD = cIOinputWellPath.getMDByJHAndTVD(curWell.sJH, iTinyTickValue, curWell.WellPathList);
                if (fMD >= maxMesureDepth) break;
                ltdfminTickDepth.Add(fMD);
                iTinyTickValue = iTinyTickValue + m_tickInveral_min;
            }
            List<double> ltdfViewMainTickDepth = cSVGBase.transformListVscale(ltdfMainTickDepth, dfVscale);
            XmlElement gMDRuler = svgDoc.CreateElement("g");
            gMDRuler.SetAttribute("id", cIDmake.idTrackRuler());
            //主tick和标识
            for (int i = 0; i < ltdfViewMainTickDepth.Count; i++)
            {
                XmlElement gDepthTick = svgDoc.CreateElement("use");
                gDepthTick.SetAttribute("x", "0");
                gDepthTick.SetAttribute("y", ltdfViewMainTickDepth[i].ToString());
                gDepthTick.SetAttribute("href", cSVGBase.svgNS, "#" + cIDmake.idDepthTickMain);
                gMDRuler.AppendChild(gDepthTick);
                
                XmlElement gTickText = svgDoc.CreateElement("text");
                gTickText.SetAttribute("class", "DepthMainTickTextCss");
                gTickText.SetAttribute("x", "6");
                gTickText.SetAttribute("y", ltdfViewMainTickDepth[i].ToString());
                gTickText.SetAttribute("font-size", iTickFontSize.ToString());
                gTickText.InnerText = ltStrMainTickText[i];
                gMDRuler.AppendChild(gTickText);
            }
            //minTick
            List<double> ltdfViewMinTickDepth = cSVGBase.transformListVscale(ltdfminTickDepth, dfVscale);
            for (int i = 0; i < ltdfViewMinTickDepth.Count; i++)
            {
                XmlElement gDepthMinTick = svgDoc.CreateElement("use");
                gDepthMinTick.SetAttribute("x", "0");
                gDepthMinTick.SetAttribute("y", ltdfViewMinTickDepth[i].ToString());
                gDepthMinTick.SetAttribute("href",cSVGBase.svgNS, "#"+cIDmake.idDepthTickMin);
                gMDRuler.AppendChild(gDepthMinTick);
            }
            //主轴
            XmlElement gWellBoleLine = svgDoc.CreateElement("line");
            gWellBoleLine.SetAttribute("x1", "0");
            gWellBoleLine.SetAttribute("y1", (minMesureDepth * dfVscale).ToString());
            gWellBoleLine.SetAttribute("x2", "0");
            gWellBoleLine.SetAttribute("y2", ltdfViewMainTickDepth.Last().ToString());
            gWellBoleLine.SetAttribute("stroke", "black");
            gWellBoleLine.SetAttribute("stroke-width", "2");
            gMDRuler.AppendChild(gWellBoleLine);

            return gMDRuler;
        }

        public static XmlElement gPathWellRuler(ItemWell curWell, cSVGBaseSection cSVG_Well, double minMesureDepth, double maxMesureDepth, double dfVscale, itemDrawDataDepthRuler itemRuler)
        {
            //与单井模式相反，单井是把垂深转md，这里是0相反。
            if(itemRuler.iTypeRuler==0)
            return gPathWellRuler(curWell,cSVG_Well.svgDoc, cSVG_Well.svgDefs, minMesureDepth, maxMesureDepth, itemRuler.mainTick, itemRuler.minTick, dfVscale, itemRuler.tickFontSize);
            else
            return gMDRuler(cSVG_Well.svgDoc, cSVG_Well.svgDefs, cSVG_Well.svgCss, minMesureDepth, maxMesureDepth, itemRuler.mainTick, itemRuler.minTick, dfVscale, itemRuler.tickFontSize);
        }
       
        public static XmlElement gPathWellRuler(ItemWell curWell, XmlDocument svgDoc, XmlElement svgDefs, double minMesureDepth, double maxMesureDepth,
       int m_tickInveral_main, int m_tickInveral_min,double dfVscale,int iTickFontSize)
        {
            string sJH = curWell.sJH;
            if (minMesureDepth > maxMesureDepth) 
            {
                double temp = minMesureDepth;
                minMesureDepth = maxMesureDepth;
                maxMesureDepth = temp;
            } 
            if (maxMesureDepth >= curWell.fWellBase) maxMesureDepth = curWell.fWellBase;
            XmlElement gWellCone = svgDoc.CreateElement("g");
            gWellCone.SetAttribute("stroke", "black");
            gWellCone.SetAttribute("stroke-width", "1");
            List<double> ltMainMD = new List<double>();
            List<string> ltStrMainTickText = new List<string>();
            List<double> ltdfminTickDepth = new List<double>();
            List<ItemDicWellPath> listWellPath = curWell.WellPathList;
            //主tick和标识
            int iStartMainDepth = (Convert.ToInt16(minMesureDepth) / m_tickInveral_main) * m_tickInveral_main;
            while (iStartMainDepth <= maxMesureDepth)
            {
                ltMainMD.Add(iStartMainDepth);
                ltStrMainTickText.Add(iStartMainDepth.ToString());
                iStartMainDepth = iStartMainDepth + m_tickInveral_main;
            }

            double dx0 = 0;
            double dy0 = 0;
            int iTinyTickValue = cPublicMethodBase.getCeilingNumer(minMesureDepth, m_tickInveral_min);
            if (ltMainMD.Count > 0)
            {
                while (iTinyTickValue <= ltMainMD.Last())
                {
                    ltdfminTickDepth.Add(iTinyTickValue);
                    iTinyTickValue = iTinyTickValue + m_tickInveral_min;
                }
                ItemDicWellPath topWellPath = new ItemDicWellPath();
                if (ltdfminTickDepth.Count > 0) topWellPath = cIOinputWellPath.getWellPathItemByJHAndMD(curWell, (float)ltdfminTickDepth[0]);
                dx0 = topWellPath.f_dx;
                dy0 = dfVscale * topWellPath.f_TVD;

                for (int i = 1; i < ltdfminTickDepth.Count; i++)
                {
                    //md 换成 tvd
                    ItemDicWellPath currentWellPath = cIOinputWellPath.getWellPathItemByJHAndMD(curWell, (float)ltdfminTickDepth[i]);
                    double dx = currentWellPath.f_dx - dx0;
                    double dy = dfVscale * currentWellPath.f_TVD;
                    if (currentWellPath.f_incl <= 80)
                    {
                        XmlElement gDepthTick = svgDoc.CreateElement("path");
                        string d = "M " + dx.ToString() + " " + dy.ToString() + " h 3 ";
                        gDepthTick.SetAttribute("d", d);
                        gWellCone.AppendChild(gDepthTick);
                    }
                }
            }


            string _pointWellPath = "";
            for (int i = 0; i < ltMainMD.Count; i++)
            {
                //md 换成 tvd
                ItemDicWellPath currentWellPath = cIOinputWellPath.getWellPathItemByJHAndMD(curWell,(float) ltMainMD[i]);
                double dx = currentWellPath.f_dx - dx0;
                double dy = dfVscale * currentWellPath.f_TVD;
                _pointWellPath = _pointWellPath + dx.ToString() + ',' + dy.ToString() + " ";
                if (currentWellPath.f_incl <= 80)
                {
                    XmlElement gDepthTick = svgDoc.CreateElement("path");
                    string d = "M " + dx.ToString() + " " + dy.ToString() + " h 5 ";
                    gDepthTick.SetAttribute("d", d);
                    gWellCone.AppendChild(gDepthTick);
                    if (i > 0) //第一个不标注
                    {
                        XmlElement gTickText = svgDoc.CreateElement("text");
                        gTickText.SetAttribute("x", (dx + 5).ToString());
                        gTickText.SetAttribute("y", (dy + 10).ToString());
                        gTickText.SetAttribute("font-size", iTickFontSize.ToString());
                        //   gTickText.SetAttribute("stroke-width", "0.5");//transform="translate(200,100)rotate(180)"
                        gTickText.SetAttribute("stroke", "black");
                        gTickText.InnerText = ltMainMD[i].ToString();
                        gWellCone.AppendChild(gTickText);
                    }
                }
                else
                {
                    XmlElement gDepthTick = svgDoc.CreateElement("path");
                    string d = "M " + dx.ToString() + " " + dy.ToString() + " v 1 ";
                    gDepthTick.SetAttribute("d", d);
                    gWellCone.AppendChild(gDepthTick);

                    XmlElement gTickText = svgDoc.CreateElement("text");
                    gTickText.SetAttribute("x", dx.ToString());
                    gTickText.SetAttribute("y", (dy + 1).ToString());
                    gTickText.SetAttribute("font-size", "6");
                    gTickText.SetAttribute("stroke-width", "0.5");//transform="translate(200,100)rotate(180)"
                    gTickText.SetAttribute("glyph-orientation-vertical", "90");
                    //  string rotate = "translate(" + _x0.ToString() + " " + _y0.ToString() + ")rotate(90)";
                    gTickText.SetAttribute("writing-mode", "tb");
                    gTickText.SetAttribute("letter-spacing", "-0.1");
                    gTickText.InnerText = ltMainMD[i].ToString();
                    gWellCone.AppendChild(gTickText);
                }
            }

            XmlElement gWellPath = svgDoc.CreateElement("polyline");
            gWellPath.SetAttribute("style", "stroke-width:1");
            gWellPath.SetAttribute("stroke", "black");
            gWellPath.SetAttribute("fill", "none");
            gWellPath.SetAttribute("points", _pointWellPath);
            gWellCone.AppendChild(gWellPath);


            return gWellCone;

        }

        public static XmlElement gPathWellTVDRuler(ItemWell curWell, XmlDocument svgDoc, XmlElement svgDefs, double minMesureDepth, double maxMesureDepth,
     int m_tickInveral_main, int m_tickInveral_min, double dfVscale, int iTickFontSize)
        {
            string sJH = curWell.sJH;
            XmlElement gWellCone = svgDoc.CreateElement("g");
            gWellCone.SetAttribute("stroke", "black");
            gWellCone.SetAttribute("stroke-width", "1");
            List<double> ltMainMD = new List<double>();
            List<string> ltStrMainTickText = new List<string>();
            List<double> ltdfminTickDepth = new List<double>();
            List<ItemDicWellPath> listWellPath = curWell.WellPathList;

            //主tick和标识
            int iStartMainDepth = (Convert.ToInt16(minMesureDepth) / m_tickInveral_main + 1) * m_tickInveral_main;
            while (iStartMainDepth <= maxMesureDepth)
            {
                ltMainMD.Add(iStartMainDepth);
                ltStrMainTickText.Add(iStartMainDepth.ToString());
                iStartMainDepth = iStartMainDepth + m_tickInveral_main;
            }

            string _pointWellPath = "";
            for (int i = 0; i < ltMainMD.Count; i++)
            {
                //md 换成 tvd
                ItemDicWellPath currentWellPath = cIOinputWellPath.getWellPathItemByJHAndMD(curWell, (float)ltMainMD[i]);
                double _x0 =0;
                double _y0 = dfVscale * currentWellPath.f_TVD;
                _pointWellPath = _pointWellPath + _x0.ToString() + ',' + _y0.ToString() + " ";
                if (currentWellPath.f_incl <= 60)
                {
                    XmlElement gDepthTick = svgDoc.CreateElement("path");
                    string d = "M " + _x0.ToString() + " " + _y0.ToString() + " h 3 ";
                    gDepthTick.SetAttribute("d", d);
                    gWellCone.AppendChild(gDepthTick);

                    XmlElement gTickText = svgDoc.CreateElement("text");
                    gTickText.SetAttribute("x", (_x0 + 3).ToString());
                    gTickText.SetAttribute("y", _y0.ToString());
                    gTickText.SetAttribute("font-size", iTickFontSize.ToString());
                    gTickText.SetAttribute("stroke-width", "0.2");
                    gTickText.InnerText = ltMainMD[i].ToString();
                    gWellCone.AppendChild(gTickText);
                }
                else
                {
                    XmlElement gDepthTick = svgDoc.CreateElement("path");
                    string d = "M " + _x0.ToString() + " " + _y0.ToString() + " v 1 ";
                    gDepthTick.SetAttribute("d", d);
                    gWellCone.AppendChild(gDepthTick);

                    XmlElement gTickText = svgDoc.CreateElement("text");
                    gTickText.SetAttribute("x", _x0.ToString());
                    gTickText.SetAttribute("y", (_y0 + 1).ToString());
                    gTickText.SetAttribute("font-size", "2");
                    gTickText.SetAttribute("stroke-width", "0.2");//transform="translate(200,100)rotate(180)"
                    gTickText.SetAttribute("glyph-orientation-vertical", "90");
                    //  string rotate = "translate(" + _x0.ToString() + " " + _y0.ToString() + ")rotate(90)";
                    gTickText.SetAttribute("writing-mode", "tb");
                    gTickText.SetAttribute("letter-spacing", "-0.1");
                    gTickText.InnerText = ltMainMD[i].ToString();
                    gWellCone.AppendChild(gTickText);
                }
            }

            XmlElement gWellPath = svgDoc.CreateElement("polyline");
            gWellPath.SetAttribute("style", "stroke-width:1");
            gWellPath.SetAttribute("stroke", "black");
            gWellPath.SetAttribute("fill", "none");
            gWellPath.SetAttribute("points", _pointWellPath);
            gWellCone.AppendChild(gWellPath);


            return gWellCone;

        }
        
    }
}
