using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace DOGPlatform.XML
{
    class cXETrackJSJL
    {
        public static XElement trackJSJL(string id, int iTrackWidth)
        {
            return new XElement("TrackJSJL",
                                            new XElement("id", id),
                                            new XElement("trackWidth", iTrackWidth.ToString())
                                        );
        }
    }
}
