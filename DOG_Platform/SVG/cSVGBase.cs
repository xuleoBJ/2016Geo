#region << 版 本 注 释 >>
/*
 * ========================================================================
 * Copyright(c) 2014 Xuleo,Riped, All Rights Reserved.
 * ========================================================================
 *  许磊，联系电话13581625021，qq：38643987

 * ========================================================================
*/
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Xml.Linq;
using System.Xml;

namespace DOGPlatform.SVG
{
    class cSVGBase
    {
        public XmlDocument svgDoc = new XmlDocument();
        public static string svgNS = "http://www.w3.org/1999/xlink";
        public static string inkNS = "http://www.inkscape.org/namespaces/inkscape";
        public double offsetX_gSVG = 0;//define x offset of baselayer
        public double offsetY_gSVG = 0;
        public string sUnit = "px";
        public XmlElement svgRoot;
        public XmlDeclaration svgDec;
        public XmlElement gBaseLayer;
        public XmlElement svgScript;
        public XmlElement svgCss;
        public XmlElement svgDefs;
        public XmlAttribute xLinkNode;

        public cSVGBase()
            : this(2000, 1500, 0, 0, "px")
        {

        }
        public cSVGBase(double iDX_gMain, double iDY_gMain)
            : this(2000, 1500, iDX_gMain, iDY_gMain, "px")
        {

        }
        public cSVGBase(double iWidth, double iHeight, double iDX_gMain, double iDY_gMain, string _sUnit)
        {
            this.offsetX_gSVG = iDX_gMain;
            this.offsetY_gSVG = iDY_gMain;
            this.sUnit = _sUnit;
            svgDec = svgDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
            svgDoc.AppendChild(svgDec);
            svgRoot = svgDoc.CreateElement("svg");
            svgRoot.SetAttribute("xmlns:svg", "http://www.w3.org/2000/svg");
            svgRoot.SetAttribute("xmlns", "http://www.w3.org/2000/svg");
            xLinkNode = svgDoc.CreateAttribute("xlink", "href", "http://www.w3.org/1999/xlink");
            svgRoot.Attributes.Append(xLinkNode);
            svgRoot.SetAttribute("xmlns:inkscape", "http://www.inkscape.org/namespaces/inkscape");
            svgRoot.SetAttribute("version", "1.1");
            svgRoot.SetAttribute("height",iHeight.ToString() + sUnit);
            svgRoot.SetAttribute("width",iWidth.ToString() + sUnit);
           
            setPageSize(iWidth,iHeight);
            
            setPageView(iWidth,iHeight);

            svgDefs = svgDoc.CreateElement("defs");
            svgRoot.AppendChild(svgDefs);
            initialDefs();

            svgCss = svgDoc.CreateElement("style");
            svgRoot.AppendChild(svgCss);
            svgCss.SetAttribute("type", "text/css");
            initialCss();

            svgScript = svgDoc.CreateElement("script");
            svgRoot.AppendChild(svgScript);
            initialScript();
            

            //创建一个Layer
            gBaseLayer = svgDoc.CreateElement("g");
            string sTranslate = "translate(" + offsetX_gSVG.ToString() + "," + offsetY_gSVG.ToString() + ")";
            gBaseLayer.SetAttribute("transform", sTranslate);
            gBaseLayer.SetAttribute("id", "BaseLayer");
            gBaseLayer.SetAttribute("label",inkNS, "BaseLayer");
            gBaseLayer.SetAttribute("groupmode",inkNS, "layer");
            gBaseLayer.SetAttribute("xml:space", "preserve");
            svgRoot.AppendChild(gBaseLayer);
            svgDoc.AppendChild(svgRoot);

        }

        public cSVGBase(double iWidth, double iHeight, double iDX_gMain, double iDY_gMain)
            : this(iWidth, iHeight, iDX_gMain, iDY_gMain,"pt")
        {
           
        }

        public void initialDefs() 
        {
            XmlElement gDefDepthTick = svgDoc.CreateElement("path");
            gDefDepthTick.SetAttribute("id", cIDmake.idDepthTickMain);
            gDefDepthTick.SetAttribute("style", "stroke:black;stroke-width:1");
            string d = "M0 0 h 6 ";
            gDefDepthTick.SetAttribute("d", d);
            svgDefs.AppendChild(gDefDepthTick);

            XmlElement gDepthMinTick = svgDoc.CreateElement("path");
            gDepthMinTick.SetAttribute("id", cIDmake.idDepthTickMin);
            gDepthMinTick.SetAttribute("style", "stroke:black;stroke-width:1");
            string dDepthMinTick = "M0 0 h 5 ";
            gDepthMinTick.SetAttribute("d", dDepthMinTick);
            svgDefs.AppendChild(gDepthMinTick); 
        }


        public void initialCss() 
        {
            string cssTickText = "text.DepthMainTickTextCss { fill:black; text-anchor:start; alignment-baseline:central; stroke-width:1;}";
            XmlCDataSection CData = svgDoc.CreateCDataSection(cssTickText);
            svgCss.AppendChild(CData);

            string cssTrackRect = "rect.TrackRectCss { fill:none; stroke:black; stroke-width:1;}";
            CData = svgDoc.CreateCDataSection(cssTrackRect);
            svgCss.AppendChild(CData);

            string cssImage= "image.ImageSizeCss { width:100%; height:100%;}";
            CData = svgDoc.CreateCDataSection(cssImage);
            svgCss.AppendChild(CData);
  
        }

        public void initialScript()
        {
            string fileName =Path.Combine( AppDomain.CurrentDomain.BaseDirectory,"Script","getID.js");
            svgScript.SetAttribute("href", svgNS, fileName);
        }

        public void setPageSize(double iWidth, double iHeight) 
        {
            svgRoot.SetAttribute("height",iHeight.ToString() + sUnit);
            svgRoot.SetAttribute("width",iWidth.ToString() + sUnit);
        }

        public void setPageView(double iWidth, double iHeight)
        {
            string sViewBox = "0 0 " + iWidth.ToString() + " " + iHeight.ToString();
            svgRoot.SetAttribute("viewBox", sViewBox);
        }

        public void addgElement2BaseLayer(XmlElement gElement, double ix, double iy)
        {
            string sTranslate = "translate(" + ix.ToString() + "," + iy.ToString() + ")";
            gElement.SetAttribute("transform", sTranslate);
            XmlNode importNewsItem = svgDoc.ImportNode(gElement, true);
            this.gBaseLayer.AppendChild(importNewsItem);
        }

        public void addgElement2BaseLayer(XmlElement gElement)
        {
            addgElement2BaseLayer(gElement, 0, 0);
        }
        public void addgElement2Layer(XmlElement gLayer, XmlElement gElement, double ix, double iy)
        {
            string sTranslate = "translate(" + ix.ToString() + "," + iy.ToString() + ")";
            gElement.SetAttribute("transform", sTranslate);
            XmlNode importNewsItem =gLayer.OwnerDocument.ImportNode(gElement, true);
            gLayer.AppendChild(importNewsItem);
        }

        public void addgSVG2Layer(XmlElement gLayer, string sPathSVG, double ix, double iy)
        {
            XmlElement svgEle = svgDoc.CreateElement("image");
            svgEle.SetAttribute("id", "id"+cIDmake.generateRandID());
            svgEle.SetAttribute("x", ix.ToString());
            svgEle.SetAttribute("y", iy.ToString());
             svgEle.SetAttribute("width", "100");
            svgEle.SetAttribute("height", "100");
            svgEle.SetAttribute("href", cSVGBase.svgNS, sPathSVG);
            gLayer.AppendChild(svgEle);
        }
        public void addgElement2Layer(XmlElement gLayer, XmlElement gElement, double ix)
        {
           addgElement2Layer(gLayer,gElement, ix, 0);
        }
        public void addgElement2Layer(XmlElement gLayer, XmlElement gElement)
        {
            addgElement2Layer(gLayer, gElement, 0, 0);
        }
        public void addgLayer(XmlElement gLayer, double ix, double iy)
        {
            string sTranslate = "translate(" + ix.ToString() + "," + iy.ToString() + ")";
            gLayer.SetAttribute("transform", sTranslate);
            this.svgRoot.AppendChild(gLayer);
        }
       
        public XmlElement gLayerElement(string sLayerName) 
        {
            XmlElement gLayer = svgDoc.CreateElement("g");
            gLayer.SetAttribute("style", "visibility:visible;");
            string sTranslate = "translate(" + offsetX_gSVG.ToString() + "," + offsetY_gSVG.ToString() + ")";
            gLayer.SetAttribute("transform", sLayerName);
         
            gLayer.SetAttribute("id", sLayerName);
            gLayer.SetAttribute("lable", inkNS, sLayerName);
            gLayer.SetAttribute("groupmode", inkNS, "layer");
            gLayer.SetAttribute("xml:space", "preserve");
            return gLayer; 
        }

        public void addMapTitle()
        {
            addMapTitle("Title", 0, 0);
        }
        public void addMapTitle(int ix, int iy)
        {
            addMapTitle("Title", ix, iy);
        }
        public void addMapTitle(string sTitle, int ix, int iy)
        {
            XmlElement svgTitle = svgDoc.CreateElement("text");
            svgTitle.SetAttribute("id", "idTitle");
            svgTitle.SetAttribute("x", ix.ToString());
            svgTitle.SetAttribute("y", iy.ToString());
            svgTitle.SetAttribute("font-size", "10pt");
            svgTitle.SetAttribute("fill", "red");
            svgTitle.InnerText = sTitle;
            svgRoot.AppendChild(svgTitle);
        }
        public void addMapTitle(string sTitle)
        {
            addMapTitle(sTitle, 0, 0);
        }

        public void makeSVGfile(string filePath)
        {
            svgDoc.Save(filePath);
        }

        public static List<double> transformListVscale(List<double> ltDepth,double dVscale) 
        {
            List<double> ltdfViewDepth = new List<double>();
            for (int i = 0; i < ltDepth.Count; i++)
            {
                ltdfViewDepth.Add(ltDepth[i] * dVscale);
            }
            return ltdfViewDepth; 
        }
    }
}
