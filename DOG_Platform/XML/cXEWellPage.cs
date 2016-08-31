using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml;

namespace DOGPlatform.XML
{
    class cXEWellPage
    {
       public double dfDS1Show = 0;
       public double dfDS2Show = 5000;
       public string sMapTitle = "";
        //图幅全部用px基本单位，fVScale已经包含了 px-> 到应用单位的转换。
       public double fVScale = 1;
       public int iHeightMapTitle = 40;
       public int iHeightTrackHead = 100;
       public int iShowMode = 1;
       public double PageWidth = 1000;
       public double PageHeight = 10000;

       public cXEWellPage()
       {
       }

        public cXEWellPage(string filePath)
        {
            initial(filePath);
        }

        public cXEWellPage(XmlDocument xmlDoc)
        {
            initial(xmlDoc);
        }

        public void initial(string filePath)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filePath);
            initial(xmlDoc);
        }

        void initial(XmlDocument curDoc)
        {
            dfDS1Show = double.Parse(cXmlBase.getNodeInnerText(curDoc, cXEWellPage.fullPathTopDepth));
            dfDS2Show = double.Parse(cXmlBase.getNodeInnerText(curDoc, cXEWellPage.fullPathBotDepth));
            sMapTitle = cXmlBase.getNodeInnerText(curDoc, cXEWellPage.fullPathMapTitle);
            //图幅全部用px基本单位，fVScale已经包含了 px-> 到应用单位的转换。
            fVScale = double.Parse(cXmlBase.getNodeInnerText(curDoc, cXEWellPage.fullPathVSacle));
            iHeightMapTitle = int.Parse(cXmlBase.getNodeInnerText(curDoc, cXEWellPage.fullPathMapTitleRectHeight));
            iHeightTrackHead = int.Parse(cXmlBase.getNodeInnerText(curDoc, cXEWellPage.fullPathTrackRectHeight));
            iShowMode = int.Parse(cXmlBase.getNodeInnerText(curDoc, cXEWellPage.fullPathShowMode));
            PageWidth = double.Parse(cXmlBase.getNodeInnerText(curDoc, cXEWellPage.fullPathPageWidth));
            PageHeight = double.Parse(cXmlBase.getNodeInnerText(curDoc, cXEWellPage.fullPathPageHeight));
        }
 
        public static string fullPathMapTitleRectHeight = "WellTemplate/Page/mapTitleRectHeight";
        public static string fullPathTrackRectHeight = "WellTemplate/Page/trackRectHeight";
        public static string fullPathPageWidth = "WellTemplate/Page/pageWidth";
        public static string fullPathPageHeight = "WellTemplate/Page/pageHeight";
        public static string fullPathPageUnit = "WellTemplate/Page/pageUnit";
        public static string fullPathMapTitle = "WellTemplate/Page/mapTitle";
        public static string fullPathTopDepth = "WellTemplate/Page/dfTopDepth";
        public static string fullPathBotDepth = "WellTemplate/Page/dfBottomDepth";
        public static string fullPathShowMode = "WellTemplate/Page/iShowMode";
        public static string fullPathVSacle = "WellTemplate/Page/fVScale";
        public static XElement Page(string sJH, double dfTopDepth, double dfBottomDepth, double fVScale)
        {
            //通过井底深度计算缺省页面高度
            return new XElement("Page",
                                               new XElement("pageWidth", "3000"),
                                              new XElement("pageHeight", "10000"),
                                              new XElement("pageUnit", "px"),
                                               new XElement("iShowMode", "1"),
                                                new XElement("dfTopDepth", dfTopDepth.ToString()),
                                                new XElement("dfBottomDepth", dfBottomDepth.ToString()),
                                               new XElement("fVScale", fVScale.ToString()),  //图幅全部用px基本单位，fVScale已经包含了 px-> 到应用单位的转换,全部计算应用fVscale就可以。
                                             new XElement("mapTitle", sJH),
                                                new XElement("fontSizeMapTitle", "20"),
                                              new XElement("mapTitleRectHeight", "40"),
                                             new XElement("trackRectHeight", "100"),
                                            new XElement("sBack1", "none"),
                                            new XElement("sBack2", "none") 
                                        ); 
        }
    }
}
