using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DOGPlatform
{
    /// <summary>
    /// 命名规则 id+父亲属性+本身属性+编码
    /// </summary>
    class cIDmake
    {
        public static int iElementCount=1;
        public static string idDepthTickMain = "idDepthMainTick";  //深度尺 main tick use id
        public static string idDepthTickMin = "idDepthMinTick";   //深度尺 min tick  use id
        public static string idGridVertical = "idGridLineV";    //垂直网格 use id 水平网格宽度不同 不需要
        public static string generateID() //产生12位 unicode
        {
            string strGuidID= Guid.NewGuid().ToString("N");
            return strGuidID.Substring(strGuidID.Length - 12);
        }

        public static string generateRandID() //产生12位 unicode
        {
            string strID = DateTime.Now.ToString("HHmmss") + iElementCount.ToString("000000");
            iElementCount++;
            return strID;
        }
        //有的id，比如填充方案不到12个字符 出错
        public static string reMakeID(string sID) //替换id后12位code
        {
            if (sID.Length>=12) return  sID.Remove(sID.Length - 12, 12) + generateID();
            else return sID+="copy"; 
        }
        public static string generateRandomFileNameID()
        {
            return generateID()+".xml";
        }
        public static string generateRandomDirName()
        {
            return generateID();
        }
        public static string idLayer()
        {
            return "idLayer" + generateID();
        }
        public static string idTrack()
        {
            return "idTrack" + generateID(); 
        }

        public static string idGridLineHorizonal()
        {
            return "idGridLineH" + generateID();
        }

        public static string idTrackRuler()
        {
            return "idTrackRuler" + generateID();  
        }
        public static string idJSJL(string sJH)
        {
            return "idJSJL" +sJH+ generateID();  
        }
        public static string idFault()
        {
            return "idFault" + generateID();  
        }
        public static string idLogCurve(string sLongName)
        {
            return "idLog" + sLongName + generateID();  
        }

        public static string getLogNameByID(string sIDlog) 
        {
            if (sIDlog.Length >= 12) sIDlog= sIDlog.Remove(sIDlog.Length - 12, 12);
            return sIDlog.Remove(0, 5);
        
        }

        public static string idFillLog()
        {
            return "idFillLog"+ generateID();
        }
      
        public static string idDataList()
        {
            return "idDataList" + generateID();  
        }
        public static string idDataItem()
        {
            return "idDataItem" + generateID();  
        }
        public static string idConnectItem()
        {
            return "idConnectItem" + generateID();  
        } 
    }
}
