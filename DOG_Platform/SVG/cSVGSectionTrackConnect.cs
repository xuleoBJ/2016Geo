using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.Drawing;

namespace DOGPlatform.SVG
{
    class cSVGSectionTrackConnect 
    {
        public static XmlElement gConnectJSJL(XmlDocument svgDoc, String sID, cDataItemConnect connectJSJLItem1, cDataItemConnect connectJSJLItem2) 
        {
            //左侧的绘制
            XmlElement gConnectPath = svgDoc.CreateElement("path");
            gConnectPath.SetAttribute("id", sID);
            gConnectPath.SetAttribute("stroke-width", "1");
            gConnectPath.SetAttribute("onclick", "getID(evt)");
            string d = "";
            if (connectJSJLItem1.x1 <connectJSJLItem2.x1)
            {
                double x1 = connectJSJLItem1.x1 + connectJSJLItem1.width;
                double y1 = connectJSJLItem1.y1;
                double x2 = connectJSJLItem1.x1 + connectJSJLItem1.width;
                double y2 = connectJSJLItem1.y1 + connectJSJLItem1.height;
                double x3 =connectJSJLItem2.x1;
                double y3 =connectJSJLItem2.y1;
                double x4 =connectJSJLItem2.x1;
                double y4 =connectJSJLItem2.y1 +connectJSJLItem2.height;
                d = "M " + x1.ToString() + " " + y1.ToString() + " L " + x2.ToString() + " " + y2.ToString() + " L " +
                    x4.ToString() + " " + y4.ToString() + " L " + x3.ToString() + " " + y3.ToString() + " z ";
            }
            if (connectJSJLItem1.x1 >connectJSJLItem2.x1)
            {
                double x1 = connectJSJLItem1.x1;
                double y1 = connectJSJLItem1.y1;
                double x2 = connectJSJLItem1.x1;
                double y2 = connectJSJLItem1.y1 + connectJSJLItem1.height;
                double x3 =connectJSJLItem2.x1 +connectJSJLItem2.width;
                double y3 =connectJSJLItem2.y1;
                double x4 =connectJSJLItem2.x1 +connectJSJLItem2.width;
                double y4 =connectJSJLItem2.y1 +connectJSJLItem2.height;

                d = "M " + x1.ToString() + " " + y1.ToString() + " L " + x2.ToString() + " " + y2.ToString() + " L " +
                    x4.ToString() + " " + y4.ToString() + " L " + x3.ToString() + " " + y3.ToString() + " z ";
            }
            gConnectPath.SetAttribute("stroke", "black");
            gConnectPath.SetAttribute("d", d);
            gConnectPath.SetAttribute("fill", codeReplace.codeReplaceJSJL2FillUrl(connectJSJLItem1.sFill));
            return gConnectPath;
        }
        public static XmlElement gConnectJSJL(XmlDocument svgDoc, String sID, List<cDataItemConnect> listDataItem)
        {

            XmlElement gConnect = svgDoc.CreateElement("g");
            

            for (int i = 1; i < listDataItem.Count; i++)
            {
                XmlElement gConnectPath = svgDoc.CreateElement("path");
                gConnectPath.SetAttribute("id", sID);
                gConnectPath.SetAttribute("stroke-width", "1");
                gConnectPath.SetAttribute("onclick", "getID(evt)");
                //左侧的绘制
                gConnectPath.SetAttribute("stroke-width", "1");
                string d = "";
                if (listDataItem[i - 1].x1 < listDataItem[i].x1)
                {
                    double x1 = listDataItem[i - 1].x1 + listDataItem[i - 1].width;
                    double y1 = listDataItem[i - 1].y1;
                    double x2 = listDataItem[i - 1].x1 + listDataItem[i - 1].width;
                    double y2 = listDataItem[i - 1].y1 + listDataItem[i - 1].height;
                    double x3 = listDataItem[i].x1;
                    double y3 = listDataItem[i].y1;
                    double x4 = listDataItem[i].x1;
                    double y4 = listDataItem[i].y1 + listDataItem[i].height;
                    d = "M " + x1.ToString() + " " + y1.ToString() + " L " + x2.ToString() + " " + y2.ToString() + " L " +
                        x4.ToString() + " " + y4.ToString() + " L " + x3.ToString() + " " + y3.ToString() + " z ";
                }
                if (listDataItem[i - 1].x1 > listDataItem[i].x1)
                {
                    double x1 = listDataItem[i - 1].x1;
                    double y1 = listDataItem[i - 1].y1;
                    double x2 = listDataItem[i - 1].x1;
                    double y2 = listDataItem[i - 1].y1 + listDataItem[i - 1].height;
                    double x3 = listDataItem[i].x1 + listDataItem[i].width;
                    double y3 = listDataItem[i].y1;
                    double x4 = listDataItem[i].x1 + listDataItem[i].width;
                    double y4 = listDataItem[i].y1 + listDataItem[i].height;

                    d = "M " + x1.ToString() + " " + y1.ToString() + " L " + x2.ToString() + " " + y2.ToString() + " L " +
                        x4.ToString() + " " + y4.ToString() + " L " + x3.ToString() + " " + y3.ToString() + " z ";
                }
                gConnectPath.SetAttribute("stroke", "black");
                gConnectPath.SetAttribute("d", d);
                gConnectPath.SetAttribute("fill", codeReplace.codeReplaceJSJL2FillUrl(listDataItem[i - 1].sFill));
                gConnect.AppendChild(gConnectPath);
            }
            return gConnect;
        }
        public static XmlElement gConnectJSJLleftPin(XmlDocument svgDoc, String sID, cDataItemConnect connectJSJLItem)
        {
            XmlElement gConnectPath = svgDoc.CreateElement("path");
            gConnectPath.SetAttribute("id", sID);
            gConnectPath.SetAttribute("stroke-width", "1");
            gConnectPath.SetAttribute("onclick", "getID(evt)");
            //左侧的绘制
            gConnectPath.SetAttribute("stroke-width", "1");

            double x1 = connectJSJLItem.x1 ;
            double y1 = connectJSJLItem.y1;
            double x2 = connectJSJLItem.x1 ;
            double y2 = connectJSJLItem.y1 + connectJSJLItem.height;
            double x3 = x1 - 100;
            double y3 = y2;
            double x4 = x1 - 100;
            double y4 = y1;
            string d = "M " + x1.ToString() + " " + y1.ToString() + " L " + x2.ToString() + " " + y2.ToString() +
                 " Q " + x3.ToString() + " " + y3.ToString() + " " + x4.ToString() + " " + y4.ToString() + " z ";

            gConnectPath.SetAttribute("stroke", "black");
            gConnectPath.SetAttribute("d", d);
            gConnectPath.SetAttribute("fill", codeReplace.codeReplaceJSJL2FillUrl(connectJSJLItem.sFill));
            return gConnectPath;

        }
        public static XmlElement gConnectJSJLrightPin(XmlDocument svgDoc, String sID, cDataItemConnect connectJSJLItem)
        {
                XmlElement gConnectPath = svgDoc.CreateElement("path");
                gConnectPath.SetAttribute("id", sID);
                gConnectPath.SetAttribute("stroke-width", "1");
                gConnectPath.SetAttribute("onclick", "getID(evt)");
                //左侧的绘制
                gConnectPath.SetAttribute("stroke-width", "1");

                double x1 = connectJSJLItem.x1 + connectJSJLItem.width;
                double y1 = connectJSJLItem.y1;
                double x2 = connectJSJLItem.x1 + connectJSJLItem.width;
                double y2 = connectJSJLItem.y1 + connectJSJLItem.height;
                double x3 = x1 + 100;
                double y3 = y2;
                double x4 = x1 + 100;
                double y4 = y1;
                string d = "M " + x1.ToString() + " " + y1.ToString() + " L " + x2.ToString() + " " + y2.ToString() +
                     " Q " + x3.ToString() + " " + y3.ToString() + " " + x4.ToString() + " " + y4.ToString() + " z ";

                gConnectPath.SetAttribute("stroke", "black");
                gConnectPath.SetAttribute("d", d);
                gConnectPath.SetAttribute("fill", codeReplace.codeReplaceJSJL2FillUrl(connectJSJLItem.sFill));
                return gConnectPath;
          
        }

        public static XmlElement gLineWellDistance(XmlDocument svgDoc,  double iXstart, double iYPotion, double length,double distance)
        {
            XmlElement gItemLogHeadInfor = svgDoc.CreateElement("g");
            int iFontSize = 20;
            XmlElement textValue = svgDoc.CreateElement("text");
            textValue.SetAttribute("x", (iXstart + length/2).ToString());
            textValue.SetAttribute("y", (iYPotion+20).ToString());
            textValue.SetAttribute("font-size", iFontSize.ToString());
            textValue.SetAttribute("text-anchor", "middle");
            textValue.SetAttribute("tdominant-baseline", "ideographic");
            textValue.SetAttribute("fill", "red");
            textValue.InnerText = distance.ToString("0.00");
            gItemLogHeadInfor.AppendChild(textValue);
            XmlElement distanceLine = svgDoc.CreateElement("path");
            string sPath = "m " + iXstart .ToString()+" "+ (iYPotion +6).ToString() +"v-6"+ " h " + length.ToString()+"v6";
            distanceLine.SetAttribute("d", sPath);
            distanceLine.SetAttribute("style", "stroke-width:2");
            distanceLine.SetAttribute("stroke", "red");
            distanceLine.SetAttribute("fill", "none");
            gItemLogHeadInfor.AppendChild(distanceLine);
            return gItemLogHeadInfor;
        }
    }
}
