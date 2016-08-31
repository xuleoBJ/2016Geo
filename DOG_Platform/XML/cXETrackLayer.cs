using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace DOGPlatform.XML
{
    class cXETrackLayer 
    {

        public static XElement trackLayer( string id, int iTrackWidth)
        {
            return new XElement("TrackLayer",
                                            new XElement("id", id),
                                            new XElement("trackWidth", iTrackWidth.ToString()),
                                            new XElement("textFontSize","6"),
                                            new XElement("textFontColor","black"),
                                            new XElement("autoFill","1")

                                        );
        }

     
    }
}
