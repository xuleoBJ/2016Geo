using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace DOGPlatform
{
    class codeReplace
    {
        public static List<string> ltStrJSJL = new List<string> { "未解释", "油层", "差油层", "含水油层", "油水同层", "含油水层", "可疑层", "油气同层", "气层", "气水同层", "含气水层", "水层", "致密层", "干层", "煤层" };
        public static List<string> ltStrLJJL = new List<string> { "饱含油", "富含油", "油侵", "油斑", "油迹", "荧光", "气砂", "含气", "水砂" };
        public static List<string> ltStrGeoCycle = new List<string> { "正旋回", "反旋回"};

        public static string codeReplaceJSJL2FillUrl(string _sInputCode)
        {
            if (_sInputCode.ToLower() == "oil" || _sInputCode == "油层" || _sInputCode == "1") _sInputCode = "red";
            else if (_sInputCode == "差油层" || _sInputCode == "2") _sInputCode = "url(#jsjl2)";
            else if (_sInputCode == "含水油层" || _sInputCode == "3") _sInputCode ="url(#jsjl3)";
            else if (_sInputCode == "油水同层" || _sInputCode == "4") _sInputCode = "url(#jsjl4Con)";
            else if (_sInputCode == "含油水层" || _sInputCode == "5") _sInputCode = "url(#jsjl5)";
            else if (_sInputCode == "可疑层" || _sInputCode == "6") _sInputCode = "url(#jsjl6)";
            else if (_sInputCode == "油气同层" || _sInputCode == "7") _sInputCode ="url(#jsjl7)";
            else if (_sInputCode.ToLower() == "gas" || _sInputCode == "气层" || _sInputCode == "8") _sInputCode = "yellow";
            else if (_sInputCode == "气水同层" || _sInputCode == "9") _sInputCode = "url(#jsjl9)";
            else if (_sInputCode == "含气水层" || _sInputCode == "10") _sInputCode = "url(#jsjl10)";
            else if (_sInputCode.ToLower() == "water" || _sInputCode == "水层" || _sInputCode == "11") _sInputCode = "blue";
            else if (_sInputCode == "致密层" || _sInputCode == "12") _sInputCode =  "url(#jsjl12)";
            else if (_sInputCode.ToLower() == "dry" || _sInputCode == "干层" || _sInputCode == "13") _sInputCode = "url(#jsjl13)";
            else if (_sInputCode.ToLower() == "coal" || _sInputCode.IndexOf("煤层") >= 0 || _sInputCode == "14") _sInputCode = "black";
            else _sInputCode = "none";
            return _sInputCode;
        }

        public static string codeReplaceiJSJL2Chinese(string _sInputCode)
        {
            if ( _sInputCode == "1") _sInputCode = "油层";
            else if (_sInputCode == "2") _sInputCode = "差油层";
            else if (_sInputCode == "3") _sInputCode = "含水油层";
            else if (_sInputCode == "4") _sInputCode = "油水同层";
            else if (_sInputCode == "5") _sInputCode = "含油水层";
            else if (_sInputCode == "6") _sInputCode = "可疑层";
            else if (_sInputCode == "7") _sInputCode = "油气同层";
            else if (_sInputCode == "8") _sInputCode = "气层";
            else if (_sInputCode == "9") _sInputCode = "气水同层";
            else if (_sInputCode == "10") _sInputCode = "url(#jsjl10)";
            else if (_sInputCode == "11") _sInputCode = "水层";
            else if (_sInputCode == "12") _sInputCode = "致密层";
            else if (_sInputCode == "13") _sInputCode = "干层";
            else if (_sInputCode == "14") _sInputCode = "煤层";
            return _sInputCode;
        }




        public static string codeReplaceJSJL2str(string _sInputCode)
        {
            if (_sInputCode.ToLower()=="oil" || _sInputCode == "油层" || _sInputCode == "1") _sInputCode = "1";
            else if (_sInputCode == "差油层" || _sInputCode == "2") _sInputCode = "2";
            else if (_sInputCode == "含水油层" || _sInputCode == "3") _sInputCode = "3";
            else if (_sInputCode == "油水同层" || _sInputCode == "4") _sInputCode = "4";
            else if (_sInputCode == "含油水层" || _sInputCode == "5") _sInputCode = "5";
            else if (_sInputCode.ToLower() == "possible" || _sInputCode == "可疑油气层" || _sInputCode == "6") _sInputCode = "6";
            else if (_sInputCode == "油气同层" || _sInputCode == "7") _sInputCode = "7";
            else if (_sInputCode.ToLower() == "gas" || _sInputCode == "气层" || _sInputCode == "8") _sInputCode = "8";
            else if (_sInputCode == "气水同层" || _sInputCode == "9") _sInputCode = "9";
            else if (_sInputCode == "含气水层" || _sInputCode == "10") _sInputCode = "10";
            else if (_sInputCode.ToLower() == "water" || _sInputCode == "水层" || _sInputCode == "11") _sInputCode = "11";
            else if (_sInputCode == "致密层" || _sInputCode == "12") _sInputCode = "12";
            else if (_sInputCode.ToLower() == "dry" || _sInputCode == "干层" || _sInputCode == "13") _sInputCode = "13";
            else if (_sInputCode.ToLower() == "coal" || _sInputCode.IndexOf("煤层") >= 0 || _sInputCode == "14") _sInputCode = "14";
            else _sInputCode = "0";
            return _sInputCode;
        }


        public static string codeReplaceGeoCycle2str(string _sInputCode)
        {
            if (_sInputCode == "正旋回" || _sInputCode == "1") _sInputCode = "cyclePositive";
            else if (_sInputCode == "反旋回" || _sInputCode == "2") _sInputCode = "cycleAnti";
            else if (_sInputCode == "复合旋回" || _sInputCode == "3") _sInputCode = "cycleComposite";
            else _sInputCode = "0";
            return _sInputCode;
        }

        public static int codeReplaceJSJL2int(string _sInputCode)
        {
            return int.Parse(codeReplaceJSJL2str(_sInputCode));
        }

        public static string codeReplaceWellType2str(string _sInputCode)
        {
            if (_sInputCode == "undefined" || _sInputCode == "0") _sInputCode = "0";
            else if (_sInputCode == "propose" || _sInputCode == "1") _sInputCode = "1";
            else if (_sInputCode == "dry" || _sInputCode == "2") _sInputCode = "2";
            else if (_sInputCode == "油井" || _sInputCode == "oil" || _sInputCode == "3") _sInputCode = "3";
            else if (_sInputCode == "minorOil" || _sInputCode == "4") _sInputCode = "4";
            else if (_sInputCode == "气井" || _sInputCode == "gas" || _sInputCode == "5") _sInputCode = "5";
            else if (_sInputCode == "MinorGas" || _sInputCode == "6") _sInputCode = "6";
            else if (_sInputCode == "Platform" || _sInputCode == "7") _sInputCode = "7";
            else if (_sInputCode == "水井" || _sInputCode == "Injectwater" || _sInputCode == "15") _sInputCode = "15";
            else _sInputCode = "0";
            return _sInputCode;
        }

        public static string codeReplaceStrokeDashInt2Str(int iStrokeDash)
        {
            string sRet = "none";
            if (iStrokeDash == 0) sRet = "none";
            else if (iStrokeDash == 1) sRet = "2,1";
            else if (iStrokeDash == 2) sRet = "8,8";
            else if (iStrokeDash == 3) sRet = "8,1,1,2";
            else sRet = "none";
            return sRet;
        }

    }
}
