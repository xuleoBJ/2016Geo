using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace DOGPlatform.XML
{
    class cXETrackPerforation
    {
        public static XElement trackPerfoation(string id, int iTrackWidth)
        {
            return new XElement("TrackPerforation",
                                            new XElement("id", id),
                                            new XElement("trackWidth", iTrackWidth.ToString())
                                        );
        }

      
    }
}
