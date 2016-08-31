using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace DOGPlatform
{
    class cXMLFenceDiagram
    {
        public static void creatFenceDiagramSettingXML(string fileXMLPathLayerMap)
        {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "GB2312", null);
            doc.AppendChild(dec);
            //创建一个根节点（一级）
            XmlElement root = doc.CreateElement("LayerMapConfig");
            doc.AppendChild(root);

            XmlNode node;
            XmlElement eleMent;

            node = doc.CreateElement("Layer");

            eleMent = doc.CreateElement("LayerName");
            eleMent.SetAttribute("LayerName", "LayerName");
            eleMent.SetAttribute("LayerYearAndMonth", "201310");
            eleMent.InnerText = "LayerName";
            node.AppendChild(eleMent);

            eleMent = doc.CreateElement("x0RealRefer");
            eleMent.SetAttribute("value", "0");
            eleMent.InnerText = "x0RealRefer";
            node.AppendChild(eleMent);


            eleMent = doc.CreateElement("y0RealRefer");
            eleMent.SetAttribute("value", "0");
            eleMent.InnerText = "y0RealRefer";
            node.AppendChild(eleMent);

            eleMent = doc.CreateElement("width");
            eleMent.SetAttribute("width", "1000");
            eleMent.InnerText = "width";
            node.AppendChild(eleMent);

            eleMent = doc.CreateElement("height");
            eleMent.SetAttribute("height", "800");
            eleMent.InnerText = "height";
            node.AppendChild(eleMent);

            root.AppendChild(node);


            //定制井位图属性
            node = doc.CreateElement("WellPositonMap");
            //是否显示
            eleMent = doc.CreateElement("IsShow");
            eleMent.SetAttribute("value", "1");
            node.AppendChild(eleMent);
            eleMent = doc.CreateElement("Well");
            eleMent.SetAttribute("color", "rgb(0,255,255)");
            eleMent.SetAttribute("size", "5");
            node.AppendChild(eleMent);
            eleMent = doc.CreateElement("OilWell");
            eleMent.SetAttribute("color", "rgb(255,0,0)");
            eleMent.SetAttribute("size", "5");
            node.AppendChild(eleMent);
            eleMent = doc.CreateElement("WaterWell");
            eleMent.SetAttribute("color", "rgb(0,0,255)");
            eleMent.SetAttribute("size", "5");
            node.AppendChild(eleMent);
            root.AppendChild(node);


            //定制井数据
            node = doc.CreateElement("WellData");
            //是否显示
            eleMent = doc.CreateElement("IsShow");
            eleMent.SetAttribute("value", "1");
            eleMent = doc.CreateElement("numberOfShowData"); //显示属性数据数 可以为1，2，3
            eleMent.SetAttribute("value", "1");
            node.AppendChild(eleMent);
            eleMent = doc.CreateElement("fontColor");
            eleMent.SetAttribute("value", "black");
            node.AppendChild(eleMent);
            eleMent = doc.CreateElement("fontType");
            eleMent.SetAttribute("value", "black");
            node.AppendChild(eleMent);
            eleMent = doc.CreateElement("fontSize");
            eleMent.SetAttribute("value", "10");
            node.AppendChild(eleMent);
            eleMent = doc.CreateElement("DX_Text"); //标注偏移
            eleMent.SetAttribute("value", "10");
            node.AppendChild(eleMent);
            eleMent = doc.CreateElement("DY_Text"); //标注偏移
            eleMent.SetAttribute("value", "10");
            node.AppendChild(eleMent);
            root.AppendChild(node);


            //定制BubbleMap
            node = doc.CreateElement("BubbleMap");
            //是否显示
            eleMent = doc.CreateElement("IsShow");
            eleMent.SetAttribute("value", "1");
            node.AppendChild(eleMent);
            eleMent = doc.CreateElement("IsShowText");
            eleMent.SetAttribute("value", "1");
            node.AppendChild(eleMent);
            eleMent = doc.CreateElement("Size");
            eleMent.SetAttribute("value", "100");
            node.AppendChild(eleMent);
            eleMent = doc.CreateElement("DX_Text"); //标注偏移
            eleMent.SetAttribute("value", "10");
            node.AppendChild(eleMent);
            eleMent = doc.CreateElement("DY_Text"); //标注偏移
            eleMent.SetAttribute("value", "10");
            node.AppendChild(eleMent);
            root.AppendChild(node);


            //定制Histogram
            node = doc.CreateElement("Histogram");
            //是否显示
            eleMent = doc.CreateElement("IsShow");
            eleMent.SetAttribute("value", "1");
            node.AppendChild(eleMent);
            eleMent = doc.CreateElement("IsShowText");
            eleMent.SetAttribute("value", "1");
            node.AppendChild(eleMent);
            eleMent = doc.CreateElement("Size");
            eleMent.SetAttribute("value", "10");
            node.AppendChild(eleMent);
            eleMent = doc.CreateElement("DX_Text"); //标注偏移
            eleMent.SetAttribute("value", "10");
            node.AppendChild(eleMent);
            eleMent = doc.CreateElement("DY_Text"); //标注偏移
            eleMent.SetAttribute("value", "10");
            node.AppendChild(eleMent);
            root.AppendChild(node);


            //定制Fault
            node = doc.CreateElement("FaultLine");
            //是否显示
            eleMent = doc.CreateElement("IsShow");
            eleMent.SetAttribute("value", "1");
            node.AppendChild(eleMent);
            eleMent = doc.CreateElement("color");
            eleMent.SetAttribute("value", "red");
            node.AppendChild(eleMent);
            eleMent = doc.CreateElement("lineWidth"); //标注偏移
            eleMent.SetAttribute("value", "10");

            node.AppendChild(eleMent);
            root.AppendChild(node);






            //定制比例尺
            node = doc.CreateElement("ScaleRuler");
            //是否显示
            eleMent = doc.CreateElement("IsShow");
            eleMent.SetAttribute("value", "1");
            node.AppendChild(eleMent);
            eleMent = doc.CreateElement("sacle");
            eleMent.SetAttribute("value", "1:500");
            node.AppendChild(eleMent);
            root.AppendChild(node);

            //定制指南针
            node = doc.CreateElement("Compass");
            eleMent = doc.CreateElement("IsShow");
            eleMent.SetAttribute("value", "1");
            node.AppendChild(eleMent);
            root.AppendChild(node);

            //定制边框
            node = doc.CreateElement("Mapframe");
            eleMent = doc.CreateElement("IsShow");
            eleMent.SetAttribute("value", "1");
            node.AppendChild(eleMent);
            root.AppendChild(node);

            doc.Save(fileXMLPathLayerMap);
            MessageBox.Show("设置保存。");


        }
    }
}
