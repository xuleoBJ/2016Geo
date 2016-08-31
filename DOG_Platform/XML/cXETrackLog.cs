using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace DOGPlatform.XML
{
    class cXETrackLog
    {
        public static XElement trackLog(string id, int iTrackWidth, int iLeftorRight, string sLogName, double fLeftValue, double fRightValue, string sColor)
        {
            return new XElement("TrackLog",
                                            new XElement("logName", sLogName),
                                            new XElement("id", id),
                                            new XElement("trackWidth", iTrackWidth.ToString()),
                                            new XElement("RorL", iLeftorRight.ToString()),
                                            new XElement("leftValue", fLeftValue.ToString()),
                                            new XElement("rightValue", fRightValue.ToString()),
                                            new XElement("curveLineWidth", "1"),
                                            new XElement("curveColor", sColor),
                                            new XElement("intervalPiontNumber", "2")
                                        );
        }


        public static ItemLogHeadInfor getLogHeadInfor(string xmlFilePath, string sJH, string sLogName)
        {
            ItemLogHeadInfor item = new ItemLogHeadInfor();
            item.sJH = sJH;
            item.sLogName = sLogName;
            item.sLogColor = "black";
            item.iIsLog = 0;
            item.fLeftValue = 0;
            item.fRightValue = 100;
            XDocument xDoc = XDocument.Load(xmlFilePath);
            foreach (var track in xDoc.Element("SectionMap").Elements("TrackLog").ToList())
            {
                if (track.Element("logName").Value == sLogName)
                {
                    item.sLogColor = track.Element("curveColor").Value;
                    float.TryParse(track.Element("leftValue").Value, out item.fLeftValue);
                    float.TryParse(track.Element("rightValue").Value, out item.fRightValue);
                    break;
                }
            }
            return item;
        }
    }
}
