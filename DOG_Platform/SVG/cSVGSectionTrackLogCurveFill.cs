using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DOGPlatform.XML;
using System.Xml;
using ClipperLib;

namespace DOGPlatform.SVG
{
    using Path = List<IntPoint>;
    using Paths = List<List<IntPoint>>;
    
    class cSVGSectionTrackLogCurveFill
    {
        public static List<trackDataListLog> listLogViewData4fill = new List<trackDataListLog>();
        public static XmlElement gLogCurveFillByLog(XmlDocument svgDoc, trackDataListLog logViewDataMain, trackDataListLog logViewDataSub, itemDrawDataTrackFill itemFill ,double fVScale)
        {
            string sFill= itemFill.sFill;
            double fTop =itemFill.fTop;
            double fBot = itemFill.fBot;

            XmlElement gFill = svgDoc.CreateElement("g");
            gFill.SetAttribute("id", itemFill.sID);
            gFill.SetAttribute("onclick", "getID(evt)");

            Paths subj = new Paths(1);
            trackDataListLog ploygon1 = logViewDataMain;
            fTop*=fVScale;
            fBot*=fVScale;
            //按深度段截取，构建多边形，注意为了防止畸变，两头需要加0点控制
            List<double> listDepthView = new List<double>();
            List<double> listValueView = new List<double>();
            for (int k = 0; k < ploygon1.fListMD.Count; k++)
            {
                double fDepthView = ploygon1.fListMD[k];
                if (fTop <= fDepthView && fDepthView <= fBot) 
                {
                    listDepthView.Add(fDepthView);
                    listValueView.Add(ploygon1.fListValue[k]);
                } 
            }
            listDepthView.Insert(0, fTop);
            listValueView.Insert(0,0);
            listDepthView.Add(fBot);
            listValueView.Add(0);
            subj.Add(new Path(listDepthView.Count));
            for (int k = 0; k < listDepthView.Count; k++)
            {
                subj[0].Add(new IntPoint(listValueView[k], listDepthView[k]));
            }
           

            Paths clips = new Paths(1);
            trackDataListLog ploygon2 = logViewDataSub;
            List<double> listDepthViewSub = new List<double>();
            List<double> listValueViewSub = new List<double>();
            for (int k = 0; k < ploygon2.fListMD.Count; k++)
            {
                double fDepthView = ploygon2.fListMD[k];
                if (fTop <= fDepthView && fDepthView <= fBot)
                {
                    listDepthViewSub.Add(fDepthView);
                    listValueViewSub.Add(ploygon2.fListValue[k]);
                }
            }
            listDepthViewSub.Insert(0, fTop);
            listValueViewSub.Insert(0, 0);
            listDepthViewSub.Add(fBot);
            listValueViewSub.Add(0);
            clips.Add(new Path(listDepthViewSub.Count));
            for (int k = 0; k < listDepthViewSub.Count; k++)
            {
                clips[0].Add(new IntPoint(listValueViewSub[k], listDepthViewSub[k]));
            }

            Paths solution = new Paths();
            Clipper c = new Clipper();
            c.AddPaths(subj, PolyType.ptSubject, true);
            c.AddPaths(clips, PolyType.ptClip, true);
            c.Execute(ClipType.ctDifference, solution);
            foreach (Path item in solution)
            {
                string _points = "";
                for (int kk = 0; kk < item.Count; kk++)
                {
                    _points += item[kk].X.ToString("0.00") + "," + item[kk].Y.ToString("0.00") + " ";
                }
                XmlElement gLogPolygon = svgDoc.CreateElement("polygon");
                gLogPolygon.SetAttribute("id", cIDmake.generateRandID());
                gLogPolygon.SetAttribute("fill", sFill);
                gLogPolygon.SetAttribute("fill-opacity", itemFill.fillOpacity.ToString());
                gLogPolygon.SetAttribute("points", _points);
                gFill.AppendChild(gLogPolygon);
            }  
      
            return gFill;
        }

        public static XmlElement gLogCurveFillByCutOff(XmlDocument svgDoc, string sID, trackDataListLog logViewDataMain, double cutOffValueView, itemDrawDataTrackFill itemFill, double fVScale)
        {
            string sFill = itemFill.sFill;
            double fTop = itemFill.fTop;
            double fBot = itemFill.fBot;
            XmlElement gFill = svgDoc.CreateElement("g");
            gFill.SetAttribute("id", sID);
            gFill.SetAttribute("onclick", "getID(evt)");

            Paths subj = new Paths(1);
            trackDataListLog ploygon1 = logViewDataMain;
            fTop *= fVScale;
            fBot *= fVScale;
            //按深度段截取，构建多边形，注意为了防止畸变，两头需要加0点控制
            List<double> listDepthView = new List<double>();
            List<double> listValueView = new List<double>();
            for (int k = 0; k < ploygon1.fListMD.Count; k++)
            {
                double fDepthView = ploygon1.fListMD[k];
                if (fTop <= fDepthView && fDepthView <= fBot)
                {
                    listDepthView.Add(fDepthView);
                    listValueView.Add(ploygon1.fListValue[k]);
                }
            }
            listDepthView.Insert(0, fTop);
            listValueView.Insert(0, 0);
            listDepthView.Add(fBot);
            listValueView.Add(0);
            subj.Add(new Path(listDepthView.Count));
            for (int k = 0; k < listDepthView.Count; k++)
            {
                subj[0].Add(new IntPoint(listValueView[k], listDepthView[k]));
            }

            Paths clips = new Paths(1);
            clips.Add(new Path(4));
            clips[0].Add(new IntPoint(0, fTop));
            clips[0].Add(new IntPoint(cutOffValueView, fTop));
            clips[0].Add(new IntPoint(cutOffValueView, fBot));
            clips[0].Add(new IntPoint(0, fBot));
            
            
            Paths solution = new Paths();
            Clipper c = new Clipper();
            c.AddPaths(subj, PolyType.ptSubject, true);
            c.AddPaths(clips, PolyType.ptClip, true);
            c.Execute(ClipType.ctDifference, solution);
            foreach (Path item in solution)
            {
                string _points = "";
                for (int kk = 0; kk < item.Count; kk++)
                {
                    _points += item[kk].X.ToString() + "," + item[kk].Y + " ";
                }
                XmlElement gLogPolygon = svgDoc.CreateElement("polygon");
                gLogPolygon.SetAttribute("fill", sFill);
                gLogPolygon.SetAttribute("points", _points);
                gLogPolygon.SetAttribute("fill-opacity", itemFill.fillOpacity.ToString());
                gFill.AppendChild(gLogPolygon);
            }

            return gFill;
        }
    }
}
