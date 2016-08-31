using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace DOGPlatform.XML
{
    class cXETrackText
    {
        public static XElement trackText(string id, int iTrackWidth)
        {
            return new XElement("TrackPerforation",
                                            new XElement("id", id),
                                            new XElement("trackWidth", iTrackWidth.ToString()),
                                            new XElement("textFontSize", "1"),
                                            new XElement("textFontColor","red")
                                        );
        }

       
    }
}
