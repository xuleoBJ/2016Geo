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
            ItemWell curWell = cProjectData.ltProjectWell.FirstOrDefault(p => p.sJH == sJH);
            foreach (XmlElement el_Track in cXmlDocSectionWell.getTrackNodes(goalFilePath))
            {
                trackDataDraw curTrackDraw = new trackDataDraw(el_Track);
                //继续读取曲线,加载数据
                if (curTrackDraw.sTrackType == TypeTrack.分层.ToString())
                {
                    List<itemDrawDataIntervalValue> listDataItem = new List<itemDrawDataIntervalValue>();
                    //判断库中是否有相关数据，如果有数据的话，构建 listDataItem，然后导入
                    cIOinputLayerDepth cSelectLayerDepth = new cIOinputLayerDepth();
                    List<string> listStrLine = cSelectLayerDepth.selectSectionDrawData2List(sJH);
                    foreach(string sLine in listStrLine)
                    {
                        string[] splitLine = sLine.Split();
                        if (splitLine.Length >= 3)
                        {
                            itemDrawDataIntervalValue itemPro = new itemDrawDataIntervalValue();
                            itemPro.top = float.Parse(splitLine[0]);
                            itemPro.bot = float.Parse(splitLine[1]);
                            itemPro.sProperty = splitLine[2];
                            itemPro.calTVD(curWell);
                            listDataItem.Add(itemPro);
                        }
                    }  //end 第一种类型
                    cXmlDocSectionWell.addDataItemListIntervaProperty(goalFilePath, curTrackDraw.sTrackID, listDataItem);
                }

                if (curTrackDraw.sTrackType == TypeTrack.测井解释.ToString())
                {
                    List<itemDrawDataIntervalValue> listDataItem = new List<itemDrawDataIntervalValue>();
                    //判断库中是否有相关数据，如果有数据的话，构建 listDataItem，然后导入
                    cIOinputJSJL cSelectJSJL = new cIOinputJSJL();
                    List<string> listStrLine = cSelectJSJL.selectSectionDrawData2List(sJH);
                    foreach (string sLine in listStrLine)
                    {
                        string[] splitLine = sLine.Split();
                        if (splitLine.Length >= 3)
                        {
                            itemDrawDataIntervalValue itemPro = new itemDrawDataIntervalValue();
                            itemPro.top = float.Parse(splitLine[0]);
                            itemPro.bot = float.Parse(splitLine[1]);
                            itemPro.sProperty = splitLine[2];
                            itemPro.calTVD(curWell);
                            listDataItem.Add(itemPro);
                        }
                    }  //end 第一种类型
                    cXmlDocSectionWell.addDataItemListIntervaProperty(goalFilePath, curTrackDraw.sTrackID, listDataItem);
                }

            } //end track loop
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
