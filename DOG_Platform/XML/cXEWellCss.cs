using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace DOGPlatform.XML
{
    class cXEWellCss
    {
        public int iFontSizeJH = 10;
       public  int iRadis = 3;
        public int iCirlceWidth = 2;
        public int DX_JHText = 10; 
        public int DY_JHText = 10; 
        public cXEWellCss(XmlDocument xmlDoc)
        {
            initial(xmlDoc);
        } 

    void initial(XmlDocument xmlLayerMap)
    {
        XmlNode wellCss = xmlLayerMap.SelectSingleNode("//LayerMapConfig/WellCss");
        int.TryParse(wellCss["JHTextFontSize"].InnerText,out iFontSizeJH);
        int.TryParse(wellCss["r"].InnerText,out iRadis);
        int.TryParse(wellCss["rLineWidth"].InnerText, out iCirlceWidth);
        int.TryParse(wellCss["JHTextDX_Text"].InnerText, out DX_JHText);
        int.TryParse(wellCss["JHTextDY_Text"].InnerText, out DY_JHText);
    } 

        public static XElement WellCss()
        {
            //通过井底深度计算缺省页面高度
            return new XElement("WellCss",
                                   new XElement("r", "4"),
                                   new XElement("rLineWidth", "2"),
                                   new XElement("JHTextFontColor", "black"),
                                   new XElement("JHTextFontSize", "12"),
                                   new XElement("JHTextDX_Text", "12"),
                                   new XElement("JHTextDY_Text", "10")
                            );
        }

        public static string fmpJHFontSize = "/LayerMapConfig/WellCss/JHTextFontSize";
        public static string fmpiR = "/LayerMapConfig/WellCss/r";
        public static  string fmpRlineWidth = "/LayerMapConfig/WellCss/rLineWidth";
        public static string fmpDX = "/LayerMapConfig/WellCss/JHTextDX_Text";
        public static string fmpDY = "/LayerMapConfig/WellCss/JHTextDY_Text";

        public static void setJHsize(string xmlFilePath, int iSize)
        {
            cXmlBase.updateNodeValueByAbsPath(xmlFilePath, fmpJHFontSize, iSize);
        }
        public static void setRdiusValueWellCircle(string xmlFilePath, int iR)
        {
            cXmlBase.updateNodeValueByAbsPath(xmlFilePath, fmpiR, iR);
        }
        public static void setLineWidthWellCircle(string xmlFilePath, int iWidth)
        {
            cXmlBase.updateNodeValueByAbsPath(xmlFilePath, fmpRlineWidth, iWidth);
        }
        public static void setJH_Dxoffset(string xmlFilePath, int iOffset)
        {
            cXmlBase.updateNodeValueByAbsPath(xmlFilePath, fmpDX, iOffset);
        }
    }
}
