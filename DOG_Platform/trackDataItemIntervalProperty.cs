using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace DOGPlatform
{
    class ItemTrackDataIntervalProperty
    {
        public float top;
        public float bot;
        public float topTVD;
        public float botTVD;

        public string sText;
        public string sProperty;
        public object obj;
        public ItemTrackDataIntervalProperty() :this(-999,-999)
        {
        }

        public ItemTrackDataIntervalProperty(float fTop, float fBot)
        {
            this.top = fTop;
            this.bot = fBot;
            this.sText = "";
            this.sProperty = "";
        }

        public ItemTrackDataIntervalProperty(ItemWell curWell):this()
        {
           calTVD(curWell); 
        }
        public void calTVD(string sJH)
        {
            calTVD(cProjectData.ltProjectWell.FirstOrDefault(p => p.sJH == sJH));
        } 
        public void calTVD(ItemWell curWell) 
        {
            if (curWell == null)
            {
                topTVD = this.top;
                botTVD = this.bot;
            }
            else
            {
                topTVD = cIOinputWellPath.getTVDByJHAndMD(curWell, this.top);
                botTVD = cIOinputWellPath.getTVDByJHAndMD(curWell, this.bot);
            }
        } 
    }

    class itemDrawDataIntervalValue : ItemTrackDrawDataIntervalProperty
    {
        public double fValue;
        public itemDrawDataIntervalValue() { }
        public itemDrawDataIntervalValue(XmlNode xn)
        {
            this.sID = xn.Attributes["id"].Value;
            this.top = float.Parse(xn["top"].InnerText);
            this.bot = float.Parse(xn["bot"].InnerText);
            this.topTVD = float.Parse(xn["topTVD"].InnerText);
            this.botTVD = float.Parse(xn["botTVD"].InnerText);
            fValue = 1.0;
            if (xn["sText"] != null) this.sText = xn["sText"].InnerText;
            if (xn["sProperty"] != null) this.sProperty = xn["sProperty"].InnerText;
            if (xn["fValue"] != null) this.fValue = double.Parse(xn["fValue"].InnerText);
        }

    }

    class ItemTrackDrawDataIntervalProperty : ItemTrackDataIntervalProperty
    {
        public string sID;
        public ItemTrackDrawDataIntervalProperty()
        {
            this.sID = "";
            this.top = -999;
            this.bot = -999;
            this.topTVD = -999;
            this.botTVD = -999;
            this.sText = "";
            this.sProperty = "";
        }
        public ItemTrackDrawDataIntervalProperty(XmlNode xn)
        {
            this.sID = xn.Attributes["id"].Value;
            this.top = float.Parse(xn["top"].InnerText);
            this.bot = float.Parse(xn["bot"].InnerText);
            this.topTVD = float.Parse(xn["topTVD"].InnerText);
            this.botTVD = float.Parse(xn["botTVD"].InnerText);
            if (xn["sText"] != null) this.sText = xn["sText"].InnerText;
            if (xn["sProperty"] != null) this.sProperty = xn["sProperty"].InnerText;
        }
    }
}
