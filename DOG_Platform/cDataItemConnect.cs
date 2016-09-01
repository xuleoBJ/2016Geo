using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using DOGPlatform.SVG;
using DOGPlatform.XML;
using System.IO;


namespace DOGPlatform
{
   
    class cDataItemConnect
    {
        public string sJH;
        public string sIDTrack;
        public string sIDDataItem;
        public string typeTrack;
        public double top;
        public double bot;
        public double width;
        public double height;
        public string sFill;

        public double xViewWellStart;//绘制的平面绝对位置
        public double yViewWellStart;//绘制的平面的绝对位置
        public double xViewTrack ;//图道的位置
        public double x1;
        public double y1;
        public cDataItemConnect() { }


        public cDataItemConnect(string _sJH, string _sIDTrack, string _sIDDataItem, string filePathOper) 
        {
            this.sJH = _sJH;
            this.sIDTrack = _sIDTrack;
            this.sIDDataItem = _sIDDataItem;
            this.typeTrack = cXmlDocSectionWell.getTrackTypeByID(filePathOper, sIDTrack);
        }
        public cDataItemConnect(string filePathSectionGeoCss, string filePathOper, string _sJH, string _sIDTrack, string _sIDDataItem,  float fVscale,float fHScaleWellDistance):
            this(_sJH, _sIDTrack, _sIDDataItem, filePathOper)
        {
            setupBySectioWell(filePathOper, fVscale);
            setupBySectionCss(filePathSectionGeoCss, fVscale);
        }
        public cDataItemConnect(string filePathSectionGeoCss,string filePathOper,string _sJH, string _sIDTrack, string _sIDDataItem):
            this(_sJH, _sIDTrack, _sIDDataItem, filePathOper)
        {
            float fVscale = float.Parse(cXmlBase.getNodeInnerText(filePathSectionGeoCss, cXEGeopage.fullPathSacleV));
       //     float fHScaleWellDistance = float.Parse(cXmlBase.getNodeInnerText(filePathSectionGeoCss, cXEpage.xmlFullPathPageHorizonWellDistanceScale));
            setupBySectioWell(filePathOper, fVscale);
            setupBySectionCss(filePathSectionGeoCss, fVscale);
        }

        void setupBySectioWell(string filePathOper, float fVscale)
        {
            if (File.Exists(filePathOper))
            {
                XmlDocument wellTemplateXML = new XmlDocument();
                wellTemplateXML.Load(filePathOper);

                //获取rect属性信息
                string sPath = string.Format("//*[@id='{0}']", sIDDataItem);
                XmlNode dataNode = wellTemplateXML.SelectSingleNode(sPath);

                if (dataNode != null)
                {
                    this.width = double.Parse(dataNode.ParentNode.ParentNode["trackWidth"].InnerText);
                    this.top = fVscale * double.Parse(dataNode["topTVD"].InnerText);
                    this.bot = fVscale * double.Parse(dataNode["botTVD"].InnerText);
                    this.sFill = dataNode["sProperty"].InnerText;
                }
            }
        }
        void setupBySectionCss(string filePathSectionGeoCss, float fVscale)
        {
            //获取位置
            XmlDocument sectionCss = new XmlDocument();
            sectionCss.Load(filePathSectionGeoCss);
            XmlNode wellNode = sectionCss.SelectSingleNode(string.Format("//*[@id='{0}']", this.sJH));
            //这块是变化的,可以动态生成，绘图时生成, 这个iPositionXFirstWell是第一口井的iDx位置
            //  Xview是井的相对位置是0 获取页面的横向绝对位置。
            this.xViewWellStart = double.Parse(wellNode["Xview"].InnerText); 
            this.yViewWellStart = fVscale * double.Parse(wellNode["Yview"].InnerText);
            XmlNode trackXViewNode = wellNode.SelectSingleNode(".//" + this.sIDTrack);
            this.xViewTrack = double.Parse(trackXViewNode.InnerText);   //道所在的位置的相对Xview
            this.setX1();
            this.setY1();
            this.setHeight();
        }
        public void setX1() 
        {
            x1 = xViewWellStart + xViewTrack;
        }
        public void setY1() 
        {
            y1 = yViewWellStart + top;
        }
        public void setHeight() 
        {
            height = bot - top;
        }
      
    }
}
