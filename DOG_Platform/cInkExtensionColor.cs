using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DOGPlatform
{
    class cInkExtensionColor
    {
        public static void WriteInxSetColorStrata(string _filePath, string _sName,string pyFileName)
        {
            WriteInxSetColor("SY/T5615-2004地层填色", _filePath, _sName, pyFileName); 
        }

        public static void WriteInxSetColorReserver(string _filePath, string _sName, string pyFileName)
        {
            WriteInxSetColor("SY/T5615-2004储层分级填色", _filePath, _sName, pyFileName);
        }

        public static void WriteInxSetColorFloodedRegion(string _filePath, string _sName, string pyFileName)
        {
            WriteInxSetColor("SY/T6796-2010水淹级别", _filePath, _sName, pyFileName);
        }

        public static void WriteInxSetColor(string sTreeName,string _filePath, string _sName, string pyFileName)
        {
            StreamWriter sw = new StreamWriter(_filePath, false, Encoding.UTF8);
            List<string> ltsLine = new List<string>();
            string sLine1 = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
            string sLine2 = "<inkscape-extension xmlns=\"http://www.inkscape.org/namespace/inkscape/extension\">";
            string sLine3 = string.Format("<_name>{0}</_name>", _sName);
            string sLine4 = string.Format("<id>xl.setColor.{0}</id>", _sName);
            string sLine5 = "<dependency type=\"executable\" location=\"extensions\">coloreffect.py</dependency>";
            string sLine6 = string.Format("<dependency type=\"executable\" location=\"extensions\">{0}</dependency>", pyFileName); 
            string sLine7 = "<dependency type=\"executable\" location=\"extensions\">simplestyle.py</dependency>";
            string sLine8 = "<effect>";
            string sLine9 = "<object-type>all</object-type>";
            string sLine10 = "<effects-menu>";
            string sLine11 = string.Format("<submenu _name=\"{0}\"/>", sTreeName);
            string sLine12 = "</effects-menu>";
            string sLine13 = "</effect>";
            string sLine14 = "<script>";
            string sLine15 = string.Format("<command reldir=\"extensions\" interpreter=\"python\">{0}</command>", pyFileName);
            string sLine16 = "</script>";
            string sLine17 = "</inkscape-extension>";
            ltsLine.Add(sLine1);
            ltsLine.Add(sLine2);
            ltsLine.Add(sLine3);
            ltsLine.Add(sLine4);
            ltsLine.Add(sLine5);
            ltsLine.Add(sLine6);
            ltsLine.Add(sLine7);
            ltsLine.Add(sLine8);
            ltsLine.Add(sLine9);
            ltsLine.Add(sLine10);
            ltsLine.Add(sLine11);
            ltsLine.Add(sLine12);
            ltsLine.Add(sLine13);
            ltsLine.Add(sLine14);
            ltsLine.Add(sLine15);
            ltsLine.Add(sLine16);
            ltsLine.Add(sLine17);

            foreach (string sItem in ltsLine) sw.WriteLine(sItem);
            sw.Close();
        }
        public static void WritePYSetColor(string _filePath, string _sColor)
        {
            StreamWriter sw = new StreamWriter(_filePath, false, Encoding.UTF8);
            List<string> ltsLine = new List<string>();
            string sLine1 = "#!/usr/bin/env python";
            string sLine2 = "import simplestyle,inkex";
            string sLine3 = "class XLchangeFillColorEffect(inkex.Effect):";
            string sLine4 = "\tdef __init__(self):";
            string sLine5 = "\t\tinkex.Effect.__init__(self)";
            string sLine6 = "\tdef effect(self):";
            string sLine7 = "\t\tfor id, node in self.selected.iteritems():";
            string sLine8 = "\t\t\tif node.attrib.has_key('style'):";
            string sLine9 = "\t\t\t\tstyles = simplestyle.parseStyle(node.get('style'))";
            string sLine10 = string.Format("\t\t\t\tthis_color = '#%02x%02x%02x' % {0}", _sColor);
            string sLine11 = "\t\t\t\tstyles['fill']=this_color";
            string sLine12 = "\t\t\t\tnode.set('style',simplestyle.formatStyle(styles))";
            string sLine13 = "e = XLchangeFillColorEffect()";
            string sLine14 = "e.affect()";
            ltsLine.Add(sLine1);
            ltsLine.Add(sLine2);
            ltsLine.Add(sLine3);
            ltsLine.Add(sLine4);
            ltsLine.Add(sLine5);
            ltsLine.Add(sLine6);
            ltsLine.Add(sLine7);
            ltsLine.Add(sLine8);
            ltsLine.Add(sLine9);
            ltsLine.Add(sLine10);
            ltsLine.Add(sLine11);
            ltsLine.Add(sLine12);
            ltsLine.Add(sLine13);
            ltsLine.Add(sLine14);
            foreach(string sItem in ltsLine) sw.WriteLine(sItem);
            sw.Close();
        }

        public static void configStrataColorExtension() 
        {
            List<string> listStata = new List<string>();
            listStata.Add("Cz (255,255,155)");
            listStata.Add("Mz (200,255,180)");
            listStata.Add("Pz (105,225,225)");
            listStata.Add("Pt (255,205,155)");
            listStata.Add("Ar (245,145,145)");
            listStata.Add("Anε (50,200,145)");
            listStata.Add("AnZ (210,130,190)");
            listStata.Add("Pz2 (128,128,0)");
            listStata.Add("Pz1 (0,130,110)");
            listStata.Add("Pt3 (255,195,130)");
            listStata.Add("Pt2 (255,205,180)");
            listStata.Add("Ar3 (245,220,200)");
            listStata.Add("Ar1-2 (245,80,130)");
            listStata.Add("Q (250,255,105)");
            listStata.Add("N (255,230,160)");
            listStata.Add("E (255,220,100)");
            listStata.Add("K (255,255,90)");
            listStata.Add("J (167,210,255)");
            listStata.Add("T (247,167,255)");
            listStata.Add("P (235,205,140)");
            listStata.Add("C (180,170,160)");
            listStata.Add("D (213,155,120)");
            listStata.Add("S (220,255,125)");
            listStata.Add("O (100,200,155)");
            listStata.Add("∈ (175,200,160)");
            listStata.Add("Z (255,150,80)");
            listStata.Add("Qb (255,225,185)");
            listStata.Add("Jx (255,205,135)");
            listStata.Add("Ch (250,150,130)");
            listStata.Add("Q4 (250,255,210)");
            listStata.Add("Q3 (250,255,175)");
            listStata.Add("Q2 (250,255,145)");
            listStata.Add("Q1 (250,255,115)");
            listStata.Add("N2 (255,235,195)");
            listStata.Add("N1 (255,230,145)");
            listStata.Add("E3 (255,215,100)");
            listStata.Add("E2 (255,220,145)");
            listStata.Add("E1 (255,190,100)");
            listStata.Add("K2 (235,255,155)");
            listStata.Add("K1 (225,255,90)");
            listStata.Add("J3 (185,230,255)");
            listStata.Add("J2 (145,225,255)");
            listStata.Add("J1 (85,230,255)");
            listStata.Add("T3 (250,220,245)");
            listStata.Add("T2 (250,170,245)");
            listStata.Add("T1 (222,130,222)");
            listStata.Add("P3 (245,240,205)");
            listStata.Add("P2 (240,230,160)");
            listStata.Add("P1 (230,215,120)");
            listStata.Add("C2 (210,207,200)");
            listStata.Add("C1 (178,172,158)");
            listStata.Add("D3 (255,230,210)");
            listStata.Add("D2 (245,205,160)");
            listStata.Add("D1 (240,170,90)");
            listStata.Add("S3 (240,255,195)");
            listStata.Add("S2 (220,255,125)");
            listStata.Add("S1 (195,255,60)");
            listStata.Add("O3 (210,240,230)");
            listStata.Add("O2 (150,220,190)");
            listStata.Add("O1 (100,200,155)");
            listStata.Add("Z2 (250,200,160)");
            listStata.Add("Z1 (240,165,85)");
            listStata.Add("∈3 (225,235,215)");
            listStata.Add("∈3 (200,215,190)");
            listStata.Add("∈1 (175,200,160)");

            foreach (string sItem in listStata)
            {
                string[] split = sItem.Split();
                string _sName = split[0];
                string _sColor = split[1]; ;
                string inxFileName = "xl_setColor" + _sName + ".inx";
                string pyFileName = "xl_setColor" + _sName + ".py";
                WriteInxSetColorStrata(Path.Combine(cProjectManager.dirPahtInkExtension, inxFileName), _sName, pyFileName);
                WritePYSetColor(Path.Combine(cProjectManager.dirPahtInkExtension, pyFileName), _sColor);
            }
        }

        public static void configReserverColorExtension()
        {
            List<string> listStata = new List<string>();
            listStata.Add("石油探明储量YTMJ-1H (255,70,70)");
            listStata.Add("石油控制储量YTMJ-2H (255,124,128)");
            listStata.Add("石油预测储量YTMJ-3H (255,204,204)");
            listStata.Add("气田探明储量QTMJ-1H (239,156,2)");
            listStata.Add("气田控制储量QTMJ-2H (255,255,0)");
            listStata.Add("气田预测储量QTMJ-3H (238,251,139)");

            foreach (string sItem in listStata)
            {
                string[] split = sItem.Split();
                string _sName = split[0];
                string _sColor = split[1]; ;
                string inxFileName = "xl_setColor" + _sName + ".inx";
                string pyFileName = "xl_setColor" + _sName + ".py";
                WriteInxSetColorReserver(Path.Combine(cProjectManager.dirPahtInkExtension, inxFileName), _sName, pyFileName);
                WritePYSetColor(Path.Combine(cProjectManager.dirPahtInkExtension, pyFileName), _sColor);
            }
        }

        public static void configFloodRegionColorExtension()
        {
            List<string> listStata = new List<string>();
            listStata.Add("未水淹 (255,0,0)");
            listStata.Add("低水淹 (0,255,0)");
            listStata.Add("中水淹 (0,128,128)");
            listStata.Add("高水淹 (0,255,255)");

            foreach (string sItem in listStata)
            {
                string[] split = sItem.Split();
                string _sName = split[0];
                string _sColor = split[1]; ;
                string inxFileName = "xl_setColor" + _sName + ".inx";
                string pyFileName = "xl_setColor" + _sName + ".py";
                WriteInxSetColorFloodedRegion(Path.Combine(cProjectManager.dirPahtInkExtension, inxFileName), _sName, pyFileName);
                WritePYSetColor(Path.Combine(cProjectManager.dirPahtInkExtension, pyFileName), _sColor);
            }
        }
    }
}
