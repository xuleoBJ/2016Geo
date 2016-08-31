﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml;

namespace DOGPlatform.XML
{
    class cXELayerPage
    {
        public double xRef = cProjectData.dfMapXrealRefer;
        public double yRef = cProjectData.dfMapYrealRefer;
        public double dfscale = cProjectData.dfMapScale;
        public int iShowCompass = 0;
        public int iShowScaleRuler = 1;
        public int iShowMapFrame = 1;
        public cXELayerPage(XmlDocument xmlDoc)
        {
            initial(xmlDoc);
        }
        void initial(XmlDocument xmlDoc)
        {
            XmlNode pageInor = xmlDoc.SelectSingleNode("//LayerMapConfig/PageInfor");
            xRef = double.Parse(pageInor["xRef"].InnerText);
            yRef = double.Parse(pageInor["YRef"].InnerText);
            dfscale = double.Parse(pageInor["dfMapScale"].InnerText);
        }
        public static XElement PageInfor()
        {
            //通过井底深度计算缺省页面高度
            return new XElement("PageInfor",
                                   new XElement("pageWidth", "3000"),
                                  new XElement("pageHeight", "10000"),
                                  new XElement("pageUnit", "mm"),
                                   new XElement("iShowMode", "1"),
                                   new XElement("xRef", cProjectData.dfMapXrealRefer.ToString()),
                                  new XElement("YRef", cProjectData.dfMapYrealRefer.ToString()),
                                 new XElement("dfMapScale", cProjectData.dfMapScale.ToString("0.00")),
                                 new XElement("mapTitle", ""),
                                  new XElement("fontSizeMapTitle", "20"),
                                  new XElement("mapTitleRectHeight", "40"),
                                 new XElement("trackRectHeight", "100"),
                                 new XElement("sBack1", "none"),
                                new XElement("sBack2", "none")
                            );
        }
        public static string fmpPageWidth = "/LayerMapConfig/PageInfor/pageWidth";
        public static string fmpPageHeight = "/LayerMapConfig/PageInfor/pageHeight";
        public static string fmpPageUnit = "/LayerMapConfig/PageInfor/pageUnit";
        public static string fmpMapTitle = "/LayerMapConfig/PageInfor/mapTitle";
        public static XElement ComPass() 
        {
            return new XElement("Compass",
                                   new XElement("visible", "0"),
                                  new XElement("type", "0"),
                                  new XElement("x", "100"),
                                   new XElement("y", "1"),
                                 new XElement("sBack1", "none"),
                                new XElement("sBack2", "none")
                            );
        }

        public static XElement ScaleRuler()
        {
            return new XElement("ScaleRuler",
                                   new XElement("visible", "1"),
                                  new XElement("type", "0"),
                                  new XElement("x", "100"),
                                   new XElement("y", "100"),
                                 new XElement("sacle", "1:500"),
                                new XElement("sBack2", "none")
                            );
        }

        public static XElement Mapframe()
        {
            return new XElement("Mapframe",
                                   new XElement("visible", "1"),
                                  new XElement("type", "0"),
                                  new XElement("x", "px"),
                                   new XElement("y", "1"),
                                 new XElement("sBack1", "none"),
                                new XElement("sBack2", "none")
                            );
        }
    }
}
