using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using DOGPlatform.XML;
using System.Xml;

namespace DOGPlatform
{
    class cIOtemplate
    {   
        /// <summary>
        /// 注意xtmFile
        /// </summary>
        /// <param name="xtlFileName">模板文件名，带扩展名</param>
        /// <param name="goalFilePath">目标文件路径，全路径</param>
        /// <param name="sJH"></param>
        public static void copyTemplate(string xtlFileName,string goalFilePath,string sJH)
        {
         //加载模板
            string xtmPath = Path.Combine(cProjectManager.dirPathTemplate, xtlFileName);
            File.Copy(xtmPath, goalFilePath,true);
            cXmlBase.setNodeInnerText(goalFilePath, cXmlDocSectionWell.fullPathJH, sJH);
            cXmlBase.setNodeInnerText(goalFilePath, cXEWellPage.fullPathMapTitle, sJH);
            //加载曲线数据
            //foreach (XmlElement el_Track in cXmlDocSectionWell.getTrackNodes(goalFilePath))
            //{
            //    trackDataDraw curTrackDraw = new trackDataDraw(el_Track);
            //    //继续读取曲线,加载数据
            //    if (curTrackDraw.sTrackType == TypeTrack.曲线道.ToString())
            //    {
            //        XmlNodeList xnList = el_Track.SelectNodes(".//Log");
            //        foreach (XmlElement xnLog in xnList)
            //        {
            //            itemLogHeadInforDraw curLogHead = new itemLogHeadInforDraw(xnLog);
            //            //此处写入配置文件xml,tn.name 是 id
            //            string sLogID = curLogHead.sIDLog;
            //            string sLogName = curLogHead.sLogName;
            //            //如果测井文件存在，自动加载数据
            //            addLogData2Track(goalFilePath, sJH, sLogName, sLogID);
            //        }
            //    } 
            //} //end track loop
        }


        public static void copyTemplate(string xtlFileName, string goalFilePath, string sJH, double depthTopShow,double depthBotShow)
        {
            //加载模板
            string xtmPath = Path.Combine(cProjectManager.dirPathTemplate, xtlFileName);
            ItemWellHead item = new ItemWellHead(sJH);
            File.Copy(xtmPath, goalFilePath, true);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(goalFilePath);
            cXmlBase.setNodeInnerText(xmlDoc, cXmlDocSectionWell.fullPathJH, sJH);
            cXmlBase.setNodeInnerText(xmlDoc, cXEWellPage.fullPathMapTitle, sJH);
            cXmlBase.setNodeInnerText(xmlDoc, cXEWellPage.fullPathTopDepth, depthTopShow.ToString("0.00"));
            cXmlBase.setNodeInnerText(xmlDoc, cXEWellPage.fullPathBotDepth, depthBotShow.ToString("0.00"));
            cXmlBase.setNodeInnerText(xmlDoc, cXmlDocSectionWell.fullPathX, item.dbX.ToString());
            cXmlBase.setNodeInnerText(xmlDoc, cXmlDocSectionWell.fullPathY, item.dbY.ToString());
            cXmlBase.setNodeInnerText(xmlDoc, cXmlDocSectionWell.fullPathKB, item.fKB.ToString());
            cXmlBase.setNodeInnerText(xmlDoc, cXmlDocSectionWell.fullPathBase, item.fWellBase.ToString("0.00"));
            XmlNode currentNode = xmlDoc.SelectSingleNode(cXmlDocSectionWell.fullPathTrackCollection);
            cXmlDocSectionWell.remakeIDofNode(currentNode);
            //换ID
            xmlDoc.Save(goalFilePath);

        }
    }
}
