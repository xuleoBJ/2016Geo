using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml;

namespace DOGPlatform.XML
{
    class cXEGeopage
    {
        public int PageWidth = 5000;
        public int PageHeight = 5000;
        public float TopElevation = 500;  //不同区不一样，青海3000，长庆2000，大庆200，应该根据区域设置。
        public float fMapScale = (float)cProjectData.dfMapScale;
        public float fVscale = 1;
        public float fHScaleWellDistance = 1;
        public int iPositionXFirstWell = 300;
        public int iShowTrackRect = 1;
        public int iShowTrackHeadRect = 1;
        public int iShowTitleRect = 1;
        public string sUnit = "px";
        public string mapTitle = "";
        public int iModeWellArrange=2;

        public cXEGeopage(string pathSectionCss)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(pathSectionCss);
            initial(xmlDoc);
        }

        public cXEGeopage(XmlDocument xmlDoc)
        {
            initial(xmlDoc);
        }

         void initial(XmlDocument xmlDoc)
        {
            PageWidth = int.Parse(cXmlBase.getNodeInnerText(xmlDoc, cXEGeopage.xmlFullPathPageWidth));
            PageHeight = int.Parse(cXmlBase.getNodeInnerText(xmlDoc, cXEGeopage.xmlFullPathPageHeight));
            TopElevation = float.Parse(cXmlBase.getNodeInnerText(xmlDoc, cXEGeopage.xmlFullPathPageTopElevation));
            fMapScale = float.Parse(cXmlBase.getNodeInnerText(xmlDoc, cXEGeopage.fullPathSacleMap));
            fVscale = float.Parse(cXmlBase.getNodeInnerText(xmlDoc, cXEGeopage.fullPathSacleV));
            fHScaleWellDistance = float.Parse(cXmlBase.getNodeInnerText(xmlDoc, cXEGeopage.xmlFullPathPageHorizonWellDistanceScale));
            iPositionXFirstWell = int.Parse(cXmlBase.getNodeInnerText(xmlDoc, cXEGeopage.xmlFullPathPageFirstWellXposition));
            sUnit = cXmlBase.getNodeInnerText(xmlDoc, cXEGeopage.xmlFullPathPageUnit);
            iModeWellArrange = int.Parse(cXmlBase.getNodeInnerText(xmlDoc, cXEGeopage.xmlFullPathPageFirstWellXposition));
            iShowTrackRect = int.Parse(cXmlBase.getNodeInnerText(xmlDoc, cXEGeopage.xmlFullPathPageiShowTrackRect));
            iShowTrackHeadRect = int.Parse(cXmlBase.getNodeInnerText(xmlDoc, cXEGeopage.xmlFullPathPageiShowTrackHeadRect));
            iShowTitleRect = int.Parse(cXmlBase.getNodeInnerText(xmlDoc, cXEGeopage.xmlFullPathPageiShowTitleRect));
        }

         public static string fullPathSacleMap = "SectionMap/Page/fScale"; //mapScale
        public static string fullPathSacleV = "SectionMap/Page/vScale";
        public static string fullPathSacleH = "SectionMap/Page/hScale";
        public static string xmlFullPathPageWidth = "SectionMap/Page/pageWidth";

        public static string xmlFullPathPageTopElevation = "SectionMap/Page/pageTopElevation";

        public static string xmlFullPathPageFirstWellXposition = "SectionMap/Page/firstWellXposition";

        public static string xmlFullPathPageHeight = "SectionMap/Page/pageHeight";

        public static string xmlFullPathPageUnit = "SectionMap/Page/pageUnit";

        public static string xmlFullPathPageWellArrange = "SectionMap/Page/wellArrange";

        public static string xmlFullPathPageHorizonWellDistanceScale = "SectionMap/Page/horizonWellDistanceScale";

        public static string xmlFullPathPageiModeWellArrange = "SectionMap/Page/wellArrange";

        public static string xmlFullPathPageiShowTrackRect = "SectionMap/Page/showTrackRect";
        public static string xmlFullPathPageiShowTrackHeadRect = "SectionMap/Page/showTrackHeadRect";
        public static string xmlFullPathPageiShowTitleRect = "SectionMap/Page/showTitleRect";

        public static XElement Page()
        {  
            //通过井底深度计算缺省页面高度
            return new XElement("Page",
                                            new XElement("pageWidth", "5000"),
                                            new XElement("pageHeight", "5000"),
                                            new XElement("pageTopElevation", "1000"),
                                            new XElement("firstWellXposition", makeSectionGeo.iPositionXFirstWell.ToString()),
                                            new XElement("iShowMode", "0"),
                                            new XElement("fScale", "1"),
                                            new XElement("vScale", "1"),
                                            new XElement("hScale", "1"),
                                            new XElement("showTitleRect", "1"),
                                            new XElement("showTrackHeadRect", "1"),
                                            new XElement("showTrackRect", "1"),
                                            new XElement("pageUnit", "px"),
                                            new XElement("mapTitle", ""),
                                            new XElement("wellArrange", "2"),   //定义 iChoise==1 等间隔排列，iChoise==2 相邻井真实距离缩放 
                                            new XElement("horizonWellDistanceScale", "1"),
                                            new XElement("fontSizeDefault", "14"),
                                            new XElement("topLayerShow", "none"),
                                            new XElement("botLayerShow", "none"),
                                            new XElement("sBack1", "none"),
                                            new XElement("sBack2", "none")
                                        );
        }

      
      
    }
}
